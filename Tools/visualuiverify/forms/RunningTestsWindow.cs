//---------------------------------------------------------------------------
//
// <copyright file="RunningTestsWindow" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Window showing running Automation-Element Tests
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Automation;
using VisualUIAVerify.Features;
using VisualUIAVerify.Utils;
using VisualUIAVerify.Controls;
using System.Threading;

namespace VisualUIAVerify.Forms
{
    /// <summary>
    /// Window for showing running tests
    /// </summary>
    public partial class RunningTestsWindow : Form
    {
        /// <summary>
        /// instance of test manager
        /// </summary>
        AutomationTestManager _testManager;

        /// <summary>
        /// list of all tests to be performed
        /// </summary>
        List<object[]> _testList = new List<object[]>();


        ///// <summary>
        ///// indicates that after worker is done he whould close the window
        ///// </summary>
        //bool _closeWindowAfterTheTestsExecution;


        /// <summary>
        /// initialize new window
        /// </summary>
        public RunningTestsWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method will show window and run all tests previously added by Add Test method.
        /// </summary>
        internal void ShowAndRunTests(AutomationTestManager manager, IWin32Window parentWindow)
        {
            this._testManager = manager;

            RunTests();

            this.ShowDialog(parentWindow);
        }

        /// <summary>
        /// This method add test to list of all test.
        /// </summary>
        internal void AddTest(AutomationTest test, AutomationElement automationElement)
        {
            //creare ListView item for the test
            ListViewItem item = new ListViewItem();
            item.Text = GetTestName(test);
            item.SubItems.Add(GetAutomationElementName(automationElement));
            item.SubItems.Add(GetTestResultName(TestResults.ReadyToRun));
            item.ImageIndex = GetImageIndexForStatus(TestResults.ReadyToRun);
            
            this._testListView.Items.Add(item);

            //ad it to the collection of all tests
            this._testList.Add(new object[] { test, automationElement, item });
        }

        /// <summary>
        /// starts execution of tests on worker thread
        /// </summary>
        private void RunTests()
        {
            btnRunTests.Visible = false;
            btnCancel.Visible = true;
            this.Text = "Tests running";

            _backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// worker thread work.
        /// </summary>
        private void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker) sender;

            int testCount = this._testList.Count;
            int testIndex = 0;

            foreach (object[] testData in this._testList)
            {
                if(worker.CancellationPending)
                    break;

                //report that we started the test
                worker.ReportProgress((testIndex * 100) / testCount + 1);

                AutomationTest test = (AutomationTest)testData[0];
                AutomationElement element = (AutomationElement)testData[1];
                ListViewItem item = (ListViewItem)testData[2];

                //perform the test
//                SetTestStatus(item, TestResults.ReadyToRun);
                TestResults result = this._testManager.PerformTest(test, element);
                SetTestStatus(item, result);

                //report the progress
                testIndex++;
                worker.ReportProgress((testIndex * 100) / testCount);
            }
        }

        #region helper methods

        /// <summary>
        /// sets status of the test
        /// </summary>
        private void SetTestStatus(ListViewItem item, TestResults result)
        {
            if (this._testListView.InvokeRequired)
            {
                this._testListView.BeginInvoke(new MethodInvoker(delegate() { SetTestStatus(item, result); }));
            }
            else
            {
                ListViewItem.ListViewSubItem statusSubItem = item.SubItems[2];
                Color statusTextColor = Color.Black;
                Color statusBackgroundColor = Color.Transparent;

                switch (result)
                {
                    case TestResults.Succeed: statusTextColor = Color.Green; break;
                    case TestResults.Failed: statusTextColor = Color.Red; break;

                    case TestResults.UnexpectedError:
                        statusTextColor = Color.White;
                        statusBackgroundColor = Color.Red;
                        break;
                }

                statusSubItem.Text = GetTestResultName(result);
                statusSubItem.BackColor = statusBackgroundColor;
                statusSubItem.ForeColor = statusTextColor;
                item.ImageIndex = GetImageIndexForStatus(result);
                item.EnsureVisible();
            }
        }

        private static int GetImageIndexForStatus(TestResults result)
        {
            return (int)result;
        }

        private string GetTestName(AutomationTest test)
        {
            return test.Method.ReflectedType.Name + "." + test.Name;
        }

        private string GetAutomationElementName(AutomationElement automationElement)
        {
            return TreeHelper.GetAutomationElementTreeNodeText(automationElement);
        }

        private string GetTestResultName(TestResults testResults)
        {
            return testResults.ToString();
        }

        private void SetProgress(int value)
        {
            if (_progressBar.InvokeRequired)
                _progressBar.BeginInvoke(new MethodInvoker(delegate() { SetProgress(value); }));
            else
                _progressBar.Value = value;
        }

        #endregion

        #region events

        private void btnRunTests_Click(object sender, EventArgs e)
        {
            RunTests();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            _backgroundWorker.CancelAsync();
            this.Text = "Tests Canceled";
        }

        private void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker) sender;

            SetProgress(100);

            btnCancel.Text = "Close";

//            if (this._closeWindowAfterTheTestsExecution)
            this.BeginInvoke(new MethodInvoker(delegate() { this.Close(); }));
        }

        private void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetProgress(e.ProgressPercentage);
        }

        private void RunningTestsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            _backgroundWorker.CancelAsync();
//            this._closeWindowAfterTheTestsExecution = true;

            //if the worker is still working then wait for him
            e.Cancel = _backgroundWorker.IsBusy;

            this.Text = "Waiting for test to complete...";
        }

        #endregion
    }
}