//---------------------------------------------------------------------------
//
// <copyright file="FocusTracer" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Class taking care of Focus tracing in AutomationElementTreeControl
//
// History:  
//  09/5/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using VisualUIAVerify.Misc;
using System.Threading;
using VisualUIAVerify.Controls;
using VisualUIAVerify.Utils;

namespace VisualUIAVerify.Features
{
    /// <summary>
    /// This class is focus-change listener. When focus tracing is started then AutomationElement in tree for focused control is
    /// highlighted.
    /// </summary>
    class FocusTracer : FocusChangeListener
    {
        private const string LoggingMessageString = "Tracing focused element";

        //we will store instance of AutomationElementTreeControl
        AutomationElementTreeControl _treeControl;

        ////to remember if we are listening to AutomationFocusChanged event
        //bool _isFocusTracing;

        //to store background worker
        BackgroundWorker _focusChangedWorker;

        public FocusTracer(AutomationElementTreeControl TreeControl)
        {
            this._treeControl = TreeControl;
        }

        protected override void OnAutomationFocusChanged(AutomationElement element)
        {
            if (this._treeControl.IsMember(element))
            {

                //prepare background thread worker for work.
                InitiliazeBackgroundWorker();

                //we will lock the workLock so we have to wait until previous work completes
                if (this._focusChangedWorker.IsBusy)
                    return;

                this._focusChangedWorker.RunWorkerAsync(element);
            }
        }

        protected override void OnEndFocusTracing()
        {
            //also we don't need the background thread yet
            ReleaseInstanceOfBackgroundWorker();
            HightlightNode(null);
        }

        /// <summary>
        /// this will set instance of background thread worker.
        /// </summary>
        private void InitiliazeBackgroundWorker()
        {
            if (this._focusChangedWorker == null)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(focusChangedWorker_DoWork);
                worker.ProgressChanged += new ProgressChangedEventHandler(focusChangedWorker_ProgressChanged);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(focusChangedWorker_RunWorkerCompleted);
                worker.WorkerSupportsCancellation = true;
                worker.WorkerReportsProgress = true;

                this._focusChangedWorker = worker;
            }
            //else
            //{
            //    this._focusChangedWorker.CancelAsync();
            //}
        }

        /// <summary>
        /// this will release instance of background thread worker.
        /// </summary>
        private void ReleaseInstanceOfBackgroundWorker()
        {
            if (this._focusChangedWorker != null)
            {
                _focusChangedWorker.DoWork -= new DoWorkEventHandler(focusChangedWorker_DoWork);
                _focusChangedWorker.ProgressChanged -= new ProgressChangedEventHandler(focusChangedWorker_ProgressChanged);
                _focusChangedWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(focusChangedWorker_RunWorkerCompleted);

                _focusChangedWorker.Dispose();

                this._focusChangedWorker = null;
            }
        }

        #region background worker events

        void focusChangedWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;

            //if we should stop running this job then stop
            //if (worker.CancellationPending)
            //    return;

            //we will show progress on this job
            worker.ReportProgress(20);

            using (new WaitCursor())
            {
                //get focused element
                AutomationElement focusedElement = (AutomationElement)e.Argument;
                if (focusedElement != null)
                {
                    AutomationElementTreeNode node = this._treeControl.BuildTreeFromRootToElement(focusedElement);

                    //we will show progress on this job
                    worker.ReportProgress(80);

                    //if we should stop running this job then stop
                    //if (worker.CancellationPending)
                    //    return;

                    //show focused element
                    HightlightNode(node);

                    //we will show progress on this job
                    worker.ReportProgress(100);
                }
            }
        }

        void focusChangedWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Misc.ApplicationLogger.LogProgress(LoggingMessageString, 100);
        }

        void focusChangedWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Misc.ApplicationLogger.LogProgress(LoggingMessageString, e.ProgressPercentage);
        }

        #endregion

        //this delegate is used only to cross thread calling
        private delegate void HightlightNodeDelegate(AutomationElementTreeNode newFocusedNode);

        /// <summary>
        /// this method will highlight newFocusedNode in the tree
        /// </summary>
        /// <param name="newFocusedNode"></param>
        private void HightlightNode(AutomationElementTreeNode newFocusedNode)
        {
            if (this._treeControl.InvokeRequired)
            {
                this._treeControl.BeginInvoke(new HightlightNodeDelegate(HightlightNode), newFocusedNode);
            }
            else
            {
                //there can be problem that the element does not longer exists
                try
                {
                    this._treeControl.SelectedNode = newFocusedNode;
                    newFocusedNode.TreeNode.EnsureVisible();
                }
                catch (Exception) { }

            }
        }
    }
}
