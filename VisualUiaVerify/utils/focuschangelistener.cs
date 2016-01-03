//---------------------------------------------------------------------------
//
// <copyright file="FocusChangeListener" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Base class for all focus-change listeners
//
// History:  
//  09/06/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Automation;
using VisualUIAVerify.Misc;


namespace VisualUIAVerify.Utils
{
    class FocusChangeListener
    {
        //to remember if we are listening to AutomationFocusChanged event
        bool _isFocusTracing;

        // virtual methods that are intended to override in inheriting class
        protected virtual void OnStartFocusTracing() { }
        protected virtual void OnEndFocusTracing() { }
        protected virtual void OnAutomationFocusChanged(AutomationElement element) { }



        /// <summary>
        /// this method will start listening to AutomationFocusChanged event.
        /// </summary>
        public void Start()
        {
            //check if we are tracing
            if (_isFocusTracing == true)
                throw new InvalidOperationException("cannot call StartFocusTracing mutliple times");

            using (new WaitCursor())
            {
                try
                {
                    //set the event handler
                    Automation.AddAutomationFocusChangedEventHandler(new AutomationFocusChangedEventHandler(OnAutomationFocusChanged));
                    _isFocusTracing = true;
                    OnStartFocusTracing();
                }
                catch (Exception ex)
                {
                    Misc.ApplicationLogger.LogException(ex);
                    _isFocusTracing = false;
                }
            }
        }

        /// <summary>
        /// this method will stop listening to AutomationFocusChanged event.
        /// </summary>
        public void Stop()
        {
            //check if we are tracing
            if (_isFocusTracing == false)
                throw new InvalidOperationException("cannot call EndFocusTracing before StartFocusTracing");

            using (new WaitCursor())
            {
                try
                {
                    //remove handler
                    Automation.RemoveAutomationFocusChangedEventHandler(new AutomationFocusChangedEventHandler(OnAutomationFocusChanged));
                }
                catch (Exception ex)
                {
                    Misc.ApplicationLogger.LogException(ex);
                }

                this._isFocusTracing = false;

                OnEndFocusTracing();
            }
        }

        /// <summary>
        /// this method will handle the AutomationFocusChanged event
        /// </summary>
        private void OnAutomationFocusChanged(object src, AutomationFocusChangedEventArgs e)
        {
            Debug.WriteLine("OnAutomationFocusChanged ...");

            OnAutomationFocusChanged((AutomationElement)src);
        }
    }
}
