// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Threading;
using System.Windows.Automation;
using System.Diagnostics;

namespace Microsoft.Test
{
    class NarratorErrorDialogs
    {
        #region variables

        /// -------------------------------------------------------------------
        /// <summary>Event listener that will watch for the dialogs</summary>
        /// -------------------------------------------------------------------
        static AutomationEventHandler _handler = null;

        /// -------------------------------------------------------------------
        /// <summary>Thread for watching for events</summary>
        /// -------------------------------------------------------------------
        static Thread _thread = null;

        #endregion variables

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        ~NarratorErrorDialogs()
        {
            Trace.WriteLine("Removing window handler for the language error dialog");
            if (NarratorErrorDialogs._handler != null)
                Automation.RemoveAllEventHandlers();

        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public void HandleVoiceLanguageWarningForm()
        {
            _thread = new Thread(VoiceLanguageWarningForm);
            _thread.Start();
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        static void VoiceLanguageWarningForm()
        {
            Trace.WriteLine("Setting up window handler for the language error dialog");
            _handler = new AutomationEventHandler(WindowOpenedEventHandler);
            Automation.AddAutomationEventHandler(WindowPattern.WindowOpenedEvent, AutomationElement.RootElement, TreeScope.Subtree, _handler);
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        static public void WindowOpenedEventHandler(object obj, AutomationEventArgs argument)
        {
            try
            {
                if (obj is AutomationElement)
                {
                    AutomationElement element = (AutomationElement)obj;
                    Trace.WriteLine("Window Opened: \"" + element.Current.Name + "\" with AutomationId({" + element.Current.AutomationId + "})");
                    switch (element.Current.AutomationId)
                    {
                        case "VoiceLanguageWarningForm":
                            // I know this UIAutomationID supports WindowPattern...
                            ((WindowPattern)element.GetCurrentPattern(WindowPattern.Pattern)).Close();
                            _thread.Abort();
                            break;

                    }
                }
            }
            catch (Exception exception)
            {
                // Just eat the exception
                Trace.WriteLine("Exception thrown (" + exception.GetType().ToString() + ") - " + exception.Message + "\"");
            }
        }
    }
}
