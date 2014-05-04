// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Automation;
using System.Collections;
using System.Drawing;
using System.CodeDom;
using System.Text;
using System.Threading;

// This suppresses warnings #'s not recognized by the compiler.
#pragma warning disable 1634, 1691

namespace InternalHelper.Tests
{
    using InternalHelper.Enumerations;
    using UIVerifyLogger = Microsoft.Test.UIAutomation.Logging.UIVerifyLogger;
    using Microsoft.Test.UIAutomation.Core;

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Object used to store an event that is processed by CodeGenEventObject.OnEvent().
    /// This object is them stored in the EventObject._eventList field.
    /// </summary>
    /// -----------------------------------------------------------------------
    public class EventItem
    {
        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        internal AutomationElement m_le = null;

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        internal object m_EventArg = null;

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        internal EventItem(AutomationElement element, object argument)
        {
            m_le = element;
            m_EventArg = argument;
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        internal static bool Equals(EventItem newEvent, EventItem storedEvent)
        {
            // WindowClosedEvent does not pass the element in as it is gone...
            if (newEvent.m_le == null && storedEvent.m_le == null)
            {
                if (((AutomationEventArgs)newEvent.m_EventArg).EventId != storedEvent.m_EventArg)
                    return false;
                else
                    return true;
            }

            if (Automation.Compare(newEvent.m_le, storedEvent.m_le))
            {
                if (newEvent.m_EventArg is AutomationFocusChangedEventArgs && (storedEvent.m_EventArg == null))
                {
                    return true;
                }
                else
                {
                    if (((newEvent.m_EventArg == null) || (storedEvent.m_EventArg == null)))
                    {
                        return false;
                    }
                    else
                    {
                        object obj = newEvent.m_EventArg;

                        if (obj.GetType().Equals(typeof(AutomationPropertyChangedEventArgs)))
                        {
                            return (((AutomationPropertyChangedEventArgs)obj).Property == storedEvent.m_EventArg);
                        }
                        else
                        {
                            if (obj.GetType().Equals(typeof(AutomationEventArgs)))
                            {
                                return (((AutomationEventArgs)obj).EventId == storedEvent.m_EventArg);
                            }
                            else
                            {
                                if (obj.GetType().Equals(typeof(StructureChangedEventArgs)))
                                {
                                    return (((StructureChangedEventArgs)(obj)).StructureChangeType == (StructureChangeType)storedEvent.m_EventArg);
                                }
                                return false;
                            }
                        }
                    }
                }
            }
            else
            {
                return false;
            }
        }
    }

    /// -----------------------------------------------------------------------
    /// <summary>
    /// This base object manages the events that are fired by the EventFramework
    /// </summary>
    /// -----------------------------------------------------------------------
    public class EventObject
    {
        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        internal static string PRETAG = "    EVENTS:  ";

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        static System.Threading.ManualResetEvent _gotNotifiedEvent = new System.Threading.ManualResetEvent(false);

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        static System.Threading.ManualResetEvent _haveNotifiedEvent = new System.Threading.ManualResetEvent(false);

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        static System.Collections.ArrayList _eventList = new System.Collections.ArrayList();

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        static DateTime _lastEvent;

        /// -------------------------------------------------------------------
        /// <summary>
        /// This is for debugging purpose in the tests since it is easy not to 
        /// call the TSC_WaitForEvents() before checking for events.
        /// </summary>
        /// -------------------------------------------------------------------
        static bool _waitedForEventToFire = false;

        /// -------------------------------------------------------------------
        /// <summary>
        /// List of events that got fired
        /// </summary>
        /// -------------------------------------------------------------------
        static internal ArrayList EventList
        {
            get
            {
                return _eventList;
            }
            set
            {
                _eventList = value;
            }
        }


        /// -------------------------------------------------------------------
        /// <summary>
        /// Object that stores the event
        /// </summary>
        /// -------------------------------------------------------------------
        internal EventObject()
        {
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Removes all event handlers
        /// </summary>
        /// -------------------------------------------------------------------
        public static void RemoveAllEventHandlers()
        {
            Comment("RemoveAllEvents");
            Automation.RemoveAllEventHandlers();
            Thread.Sleep(1);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Return the number of events fired
        /// </summary>
        /// -------------------------------------------------------------------
        public int EventCount
        {
            get
            {
                if (_eventList == null)
                    return 0;
                else
                    return _eventList.Count;
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Called by the test cases to make sure the number of desired events have been fired before they start doing eny event verification.
        /// </summary>
        /// -------------------------------------------------------------------
        internal static bool WaitForEvents(int number, int millSeconds)
        {
            int time = (number * millSeconds);
            Comment("Waiting for a period of " + time + " milliseconds for no events to occur");

            _waitedForEventToFire = true;

            _lastEvent = DateTime.Now;

            // Wait for a specific time span since the last event occured before
            // return back to the calling test.
            while (((DateTime.Now.Ticks - _lastEvent.Ticks) / TimeSpan.TicksPerMillisecond) < time)
            {

                // _haveNotifiedEvent.Set() will let OnEvent() process events if it has stoped processing at the _haveNotifiedEvent.WaitOne() call.
                _haveNotifiedEvent.Set();

                // Wait until OnEvent() has called _gotNotifiedEvent.Set() or the amount of time defined by millSeconds has expired, which ever comes first.
                _gotNotifiedEvent.WaitOne(millSeconds, true);

                // Reset so _gotNotifiedEvent.Wait() will pause on the next iteration.
                _gotNotifiedEvent.Reset();
            }

            int count = _eventList == null ? 0 : _eventList.Count;

            Comment("Stop waiting for events.  Found " + count + " event(s)");
            //RemoveAllEventHandlers();
            //Thread.Sleep(1);
            return (count == number);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method that is called from the inherited OnEvent() and will store the event in the _eventList ArrayList.
        /// </summary>
        /// -------------------------------------------------------------------
        internal void OnEvent(object eventElement, object argument)
        {
            // Validate the element by calling something on it
            AutomationElement element = null;
            if (eventElement is AutomationElement)
            {
                element = eventElement as AutomationElement;
            }
            string elName = Helpers.GetXmlPathFromAutomationElement(element);
            string uiSpyLook = Library.GetUISpyLook(element);
            Comment("Got event on...({0})", uiSpyLook);

#pragma warning suppress 6517
            lock (this)
            {
                // Let WaitForEvents() know when the last event has occured.
                _lastEvent = DateTime.Now;

                if (_eventList == null)
                    _eventList = new ArrayList();

                // Stop here and wait until we are ready to process events by a call into WaitForEvents().
                _haveNotifiedEvent.WaitOne(1000, true);

                EventItem ei = new EventItem(element, argument);

                int i = _eventList.Add(ei);

                StringBuilder buffer = new StringBuilder("   FIRED!! EVENT[" + i + "/" + _eventList.Count + "](" + uiSpyLook + ")...INFO(");

                if (argument is AutomationPropertyChangedEventArgs)
                {
                    AutomationPropertyChangedEventArgs arg = argument as AutomationPropertyChangedEventArgs;

                    if (arg == null)
                        throw new ArgumentException();

                    buffer.Append(arg.Property.ProgrammaticName + " Property[" + arg.Property + "] NewValue[" + arg.NewValue + "] OldValue[" + arg.OldValue + "])");
                }
                else
                {
                    if (argument is AutomationEventArgs)
                    {
                        AutomationEventArgs arg = argument as AutomationEventArgs;

                        if (arg == null)
                            throw new ArgumentException();

                        buffer.Append(arg.EventId.ProgrammaticName + ")");
                    }
                    else
                    {
                        if (argument is StructureChangedEventArgs)
                        {
                            StructureChangedEventArgs arg = argument as StructureChangedEventArgs;

                            if (arg == null)
                                throw new ArgumentException();

                            Comment("StructureChangedEventArgs:" + ((StructureChangedEventArgs)argument).StructureChangeType.ToString());

                            buffer.Append(arg.EventId.ProgrammaticName + ") StructureChangeType[" + arg.StructureChangeType.ToString() + "])");
                        }
                        else
                        {
                            if (argument is WindowClosedEventArgs)
                            {
                                Comment("WindowClosedEventArgs");
                                WindowClosedEventArgs arg = argument as WindowClosedEventArgs;

                                if (arg == null)
                                    throw new ArgumentException();

                                buffer.Append(arg.EventId.ProgrammaticName + ")");
                            }
                            else
                            {
                                if (argument is AutomationFocusChangedEventArgs)
                                {
                                    AutomationFocusChangedEventArgs arg = argument as AutomationFocusChangedEventArgs;

                                    if (arg == null)
                                        throw new ArgumentException();

                                    buffer.Append(arg.EventId.ProgrammaticName + ") ChildId[" + arg.ChildId + "] ObjectId[" + arg.ObjectId + "])");
                                }
                            }
                        }
                    }
                }

                Comment(buffer.ToString() + " Control Path = " + elName);

                // _haveNotifiedEvent.Reset() will let _haveNotifiedEvent.WaitOne() to pause at the top of this procedure next time in.
                _haveNotifiedEvent.Reset();

                // _gotNotifiedEvent.Set() will allow WaitForEvents() to continue to process at the _gotNotifiedEvent.WaitOne() call.
                _gotNotifiedEvent.Set();

            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Called by the inheriting EventFramework class to reset the ManualResetEvent
        /// </summary>
        /// -------------------------------------------------------------------
        internal virtual void AddEventHandler()
        {
            _waitedForEventToFire = false;

            _haveNotifiedEvent.Reset();
            _gotNotifiedEvent.Reset();
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Called by the inheriting EventFramework class to determine if an event has been fired 
        /// </summary>
        /// -------------------------------------------------------------------
        internal static EventFired WasEventFired(EventItem eventItem)
        {
            if (_waitedForEventToFire == false)
                throw new Exception("Did not wait for event to happen.  Call TSC_WaitForEvents() first");

            if (_eventList == null)
                return EventFired.False;

            string eventName = string.Empty;

            if (eventItem.m_EventArg != null)
            {
                if (eventItem.m_EventArg is StructureChangeType)
                    eventName = eventItem.m_EventArg.ToString();
                else if (eventItem.m_EventArg is AutomationIdentifier)
                    eventName = ((AutomationIdentifier)(eventItem.m_EventArg)).ProgrammaticName;
            }
            else
                eventName = "AutomationFocusChangedEvent";

            Comment(_eventList.Count + " was/were fired");

            for (int index = 0; (index < _eventList.Count); index++)
            {
                EventItem tempEventItem = (EventItem)_eventList[index];

                // Focused events are a bit complex.  You can set focus to a combobox with
                // and edit window and the edit window is the one that gets the focus...so
                // need to search up tree and see if it or one of it's parent controls
                // received the focus. Since we cannot instantiate an AutomationFocusChangedEventArgs
                // we set it to null and this is the flag to tell us that we are testing focus change
                // events
                if (eventItem.m_EventArg == null & tempEventItem.m_EventArg is AutomationFocusChangedEventArgs) // focus event 
                {
                    AutomationElement eventListElement = tempEventItem.m_le;
                    while (!Automation.Compare(eventListElement, AutomationElement.RootElement) && !Automation.Compare(eventListElement, eventItem.m_le))
                        eventListElement = TreeWalker.ControlViewWalker.GetParent(eventListElement);
                    if (Automation.Compare(eventListElement, eventItem.m_le))
                        return EventFired.True;

                }
                else
                {

                    if (EventItem.Equals(tempEventItem, eventItem))
                    {
                        {
                            Comment("{0} was fired on ({1})", eventName, Library.GetUISpyLook(eventItem.m_le));
                            return EventFired.True;
                        }
                    }
                }
            }

            Comment(eventName + " was not fired");

            return EventFired.False;
        }

        internal static void Comment(string format, params object[] args)
        {
            lock (typeof(EventObject))
            {
                if (args.Length == 0)
                    format = new StringBuilder(format).Replace('{', '[').Replace('}', ']').ToString();

                /* changing to new flexible logging */
                //Logger.LogComment("{0} {1}", PRETAG, String.Format(format, args));
                UIVerifyLogger.LogComment("{0} {1}", PRETAG, String.Format(format, args));

            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Delete the contents of the event list
        /// </summary>
        /// -------------------------------------------------------------------
        internal static void RemoveAllEventsFired()
        {
            UIVerifyLogger.LogComment("{0} Clearing {1} items from the queue", PRETAG, _eventList.Count);

            _eventList.Clear();
        }
    }

    /// -------------------------------------------------------------------------------- 
    /// <summary>
    /// Object called from the test cases to test out AutomationEvents
    /// </summary>
    /// -------------------------------------------------------------------------------- 
    public class AutomationEvents : EventObject
    {
        AutomationEventHandler handler;

        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public AutomationEvents() : base() { }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method that registers the event handler OnEvent()
        /// </summary>
        /// -------------------------------------------------------------------
        public virtual void AddEventHandler(AutomationEvent eventId, string eventName, AutomationElement element, TreeScope treeScope)
        {
            if (eventName == null)
                throw new ArgumentException();

            base.AddEventHandler();
            Comment("Adding AddAutomationEventHandler({0}, [{1}], TreeScope.{2}) Control Path = {3}",
                eventId.ProgrammaticName,
                Library.GetUISpyLook(element),
                treeScope.ToString(),
                Helpers.GetXmlPathFromAutomationElement(element));

            handler = new AutomationEventHandler(OnEvent);
            Automation.AddAutomationEventHandler(eventId, element, treeScope, handler);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method registered by AddEventHandler() as an event handler
        /// </summary>
        /// -------------------------------------------------------------------
        public void OnEvent(object element, AutomationEventArgs argument)
        {
            base.OnEvent(((AutomationElement)(element)), ((object)(argument)));
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public virtual void RemoveEventHandler(AutomationEvent eventId, AutomationElement element)
        {
            if (handler != null)
                Automation.RemoveAutomationEventHandler(eventId, element, handler);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method determines if the desired event was fired
        /// </summary>
        /// -------------------------------------------------------------------
        public virtual EventFired WasEventFired(AutomationElement element, AutomationEvent automationEvent)
        {
            return EventObject.WasEventFired(new EventItem(element, automationEvent));
        }
    }

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Object called from the test cases to test out AutomationEvents
    /// </summary>
    /// -----------------------------------------------------------------------
    public class StructureChangedEvents : EventObject
    {
        StructureChangedEventHandler handler = null;

        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public StructureChangedEvents() : base() { }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method that registers the event handler OnEvent()
        /// </summary>
        /// -------------------------------------------------------------------
        public virtual void AddEventHandler(AutomationElement element, TreeScope treeScope)
        {
            base.AddEventHandler();
            Comment("Adding AddLogicalStructureChangedEventHandler(el, " + treeScope + ")");
            handler = new StructureChangedEventHandler(OnEvent);
            Automation.AddStructureChangedEventHandler(element, treeScope, handler);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method registered by AddEventHandler() as an event handler
        /// </summary>
        /// -------------------------------------------------------------------
        public virtual void OnEvent(object element, StructureChangedEventArgs argument)
        {
            base.OnEvent(((AutomationElement)(element)), ((object)(argument)));
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public virtual void RemoveEventHandler(AutomationElement element)
        {
            if (handler != null)
                Automation.RemoveStructureChangedEventHandler(element, handler);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method determines if the desired event was fired
        /// </summary>
        /// -------------------------------------------------------------------
        public virtual EventFired WasEventFired(AutomationElement element, StructureChangeType structureChangeType)
        {
            return EventObject.WasEventFired(new EventItem(element, structureChangeType));
        }
    }

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Object called from the test cases to test out AutomationEvents
    /// </summary>
    /// -----------------------------------------------------------------------
    public class AutomationFocusChangedEvents : EventObject
    {
        AutomationFocusChangedEventHandler handler;

        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public AutomationFocusChangedEvents() : base() { }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method that registers the event handler OnEvent()
        /// </summary>
        /// -------------------------------------------------------------------
        new public virtual void AddEventHandler()
        {
            base.AddEventHandler();
            Comment("Adding AddAutomationFocusChangedEventHandler");
            handler = new AutomationFocusChangedEventHandler(OnEvent);
            Automation.AddAutomationFocusChangedEventHandler(handler);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method registered by AddEventHandler() as an event handler
        /// </summary>
        /// -------------------------------------------------------------------
        public virtual void OnEvent(object element, AutomationFocusChangedEventArgs argument)
        {
            base.OnEvent(((AutomationElement)(element)), argument);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method determines if the desired event was fired
        /// </summary>
        /// -------------------------------------------------------------------
        public virtual EventFired WasEventFired(AutomationElement element)
        {
            return EventObject.WasEventFired(new EventItem(element, null));
        }
    }

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Object called from the test cases to test out AutomationEvents
    /// </summary>
    /// -----------------------------------------------------------------------
    public class PropertyChangeEvents : EventObject
    {
        AutomationPropertyChangedEventHandler handler;

        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public PropertyChangeEvents() : base() { }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method that registers the event handler OnEvent()
        /// </summary>
        /// -------------------------------------------------------------------
        public void AddEventHandler(AutomationElement element, TreeScope treeScope, AutomationProperty[] properties)
        {
            base.AddEventHandler();
            StringBuilder sb = new StringBuilder("[");
            string divider = ", ";
            foreach (AutomationProperty prop in properties)
            {
                sb.Append(prop.ProgrammaticName);
                sb.Append(divider);
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - divider.Length, divider.Length).Append("]");
            }
            Comment("Adding AddAutomationPropertyChangedEventHandler({0}, TreeScope.{1}, {2}) ControlPath = {3}", Library.GetUISpyLook(element), treeScope.ToString(), sb.ToString(), Helpers.GetXmlPathFromAutomationElement(element));
            handler = new AutomationPropertyChangedEventHandler(OnEvent);
            Automation.AddAutomationPropertyChangedEventHandler(element, treeScope, handler, properties);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method registered by AddEventHandler() as an event handler
        /// </summary>
        /// -------------------------------------------------------------------
        public virtual void OnEvent(object element, AutomationPropertyChangedEventArgs argument)
        {
            base.OnEvent(((AutomationElement)(element)), ((object)(argument)));
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// -------------------------------------------------------------------
        public virtual void RemoveEventHandler(AutomationElement element)
        {
            if (handler != null)
                Automation.RemoveAutomationPropertyChangedEventHandler(element, handler);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Method determines if the desired event was fired
        /// </summary>
        /// -------------------------------------------------------------------
        public virtual EventFired WasEventFired(AutomationElement element, AutomationProperty automationProperty)
        {
            return EventObject.WasEventFired(new EventItem(element, automationProperty));
        }
    }
    }