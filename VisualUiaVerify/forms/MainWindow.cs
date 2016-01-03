//---------------------------------------------------------------------------
//
// <copyright file="MainWindow" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: main window of the application
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
using System.Diagnostics;
using VisualUIAVerify.Controls;
using VisualUIAVerify.Features;
using VisualUIAVerify.Misc;
using VisualUIAVerify.Win32;
using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.Test.UIAutomation;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Test.UIAutomation.Logging;

namespace VisualUIAVerify.Forms
{
    /// <summary>
    /// This class is main window of the application
    /// </summary>
    public partial class MainWindow : Form
    {
        private ElementHighlighter _highlighter;
        private HotKey[] _hotKeys;
        string _configFile = @"uiverify.config";                        // Configuration file to persist settings between runs
        string _filterFileName = "Win7BugFilter.xml";                   // Win7BugFilter.xml is the default XML. This can be overwritten
        ApplicationState _applicationState = new ApplicationState();    // Object that loads/saves the persisted settings between runs
        static string BaseTitle = "Visual UI Automation Verify";

        /// <summary>
        /// initializes main window
        /// </summary>
        public MainWindow(params string[] args)
        {
            // Obtain the state of the application on last shut down
            ApplicationStateDeserialize();

            //set logging handlers
            Misc.ApplicationLogger.LoggingProgress += new ApplicationLogger.LoggingProgressEventDelegate(ApplicationLogger_LoggingProgressEvent);

            InitializeComponent();

            //initialize menu items tags
            rectangleHighlightingToolStripMenuItem.Tag = ElementHighlighterFactory.BoundingRectangle;
            fadingRectangleHighlightingToolStripMenuItem.Tag = ElementHighlighterFactory.FadingBoundingRectangle;
            raysAndRectangleHighlightingToolStripMenuItem.Tag = ElementHighlighterFactory.BoundingRectangleAndRays;
            noneHighlightingToolStripMenuItem.Tag = ElementHighlighterFactory.None;

            testsForSelectedAutomationElementToolStripMenuItem.Tag = TestsScope.SelectedElementTests;
            allTestsToolStripMenuItem.Tag = TestsScope.AllTests;

            automationElementTestsToolStripMenuItem.Tag = TestTypes.AutomationElementTest;
            patternTestsToolStripMenuItem.Tag = TestTypes.PatternTest;
            controlTestsToolStripMenuItem.Tag = TestTypes.ControlTest;

            buildVerificationTestsToolStripMenuItem.Tag = TestPriorities.BuildVerificationTests;
            priority0TestsToolStripMenuItem.Tag = TestPriorities.Priority0Tests;
            priority1TestsToolStripMenuItem.Tag = TestPriorities.Priority1Tests;
            priority2TestsToolStripMenuItem.Tag = TestPriorities.Priority2Tests;
            priority3TestsToolStripMenuItem.Tag = TestPriorities.Priority3Tests;

            overallToolStripButton.Tag = TestResultsControl.LogTypes.OverallResults;
            allResultsToolStripButton.Tag = TestResultsControl.LogTypes.AllResults;
            FullDetailToolStripButton.Tag = TestResultsControl.LogTypes.FullDetailResults;
            xmlToolStripButton.Tag = TestResultsControl.LogTypes.XmlOutput;

            showCategoriesToolStripButton.Tag = PropertySort.Categorized;
            sortAlphabeticalToolStripButton.Tag = PropertySort.Alphabetical;

            goLeftToolStripButton.Tag = MovementDirections.Left;
            goUpToolStripButton.Tag = MovementDirections.Up;
            goRightToolStripButton.Tag = MovementDirections.Right;
            goDownToolStripButton.Tag = MovementDirections.Down;

            goLeftToolStripMenuItem.Tag = MovementDirections.Left;
            goUpToolStripMenuItem.Tag = MovementDirections.Up;
            goRightToolStripMenuItem.Tag = MovementDirections.Right;
            goDownToolStripMenuItem.Tag = MovementDirections.Down;

            //Initialize HighLighting
            switch (this._applicationState.HighLight)
            {
                case ElementHighlighterFactory.BoundingRectangle:
                    {
                        highlightingToolStripMenuItem_Click(this.rectangleHighlightingToolStripMenuItem, new EventArgs());
                        break;
                    }
                case ElementHighlighterFactory.FadingBoundingRectangle:
                    {
                        highlightingToolStripMenuItem_Click(this.fadingRectangleHighlightingToolStripMenuItem, new EventArgs());
                        break;
                    }
                case ElementHighlighterFactory.BoundingRectangleAndRays:
                    {
                        highlightingToolStripMenuItem_Click(this.raysAndRectangleHighlightingToolStripMenuItem, new EventArgs());
                        break;
                    }
                case ElementHighlighterFactory.None:
                    {
                        highlightingToolStripMenuItem_Click(this.noneHighlightingToolStripMenuItem, new EventArgs());
                        break;
                    }
            }

            //Initialize TopMost
            if (this._applicationState.ModeAlwaysOnTop)
            {
                alwaysOnTopToolStripMenuItem.Checked = true;
                alwaysOnTopToolStripMenuItem_Click(this.alwaysOnTopToolStripMenuItem, new EventArgs());
            }

            //Initialize Tracking HoverMode
            if (this._applicationState.ModeHoverMode)
            {
                this.hoverModeToolStripMenuItem.Checked = true;
                hoverModeToolStripMenuItem_Click(this.hoverModeToolStripMenuItem, new EventArgs());
            }

            //Initialize Tracking Focus tracking
            if (this._applicationState.ModeFocusTracking)
            {
                this.focusTrackingToolStripMenuItem1.Checked = true;
                focusTrackingToolStripMenuItem1_Click(this.focusTrackingToolStripMenuItem1, new EventArgs());
            }

            //Initilize Automation Tests control
            _automationElementTree.RootElement = AutomationElement.RootElement;

            //Initilize Automation Element Tree: set root element
            _automationTests.SelectedElement = AutomationElement.RootElement;

            _automationTests.Scope = TestsScope.SelectedElementTests;
            _automationTests.Types = TestTypes.AutomationElementTest | TestTypes.PatternTest | TestTypes.ControlTest;
            _automationTests.Priorities = TestPriorities.Priority0Tests | TestPriorities.Priority1Tests |
                    TestPriorities.Priority2Tests | TestPriorities.Priority3Tests;

            _automationTests.ShowTests();
            RegisterHotKeys();

            if (args == null || (Array.IndexOf<string>(args, "NOCLIENTSIDEPROVIDER") != -1))
            {
                UnloadClientSideProviders();
            }
            else
            {
                this.Text = string.Format("{0} : {1}", BaseTitle, "Client Side Provider");
            }
            TestRuns.BugFilterFile = TestRuns.FilterOutBugs ? _filterFileName : String.Empty;
        }

        
        private void ApplicationStateDeserialize()
        {

            _configFile = Path.Combine(Directory.GetCurrentDirectory(), _configFile);

            if (File.Exists(_configFile))
            {
                Stream stream = File.Open(_configFile, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                _applicationState = (ApplicationState)formatter.Deserialize(stream);
                stream.Close();
            }
        }

        private void ApplicationStateSerialize()
        {
            Stream stream = File.Open(_configFile, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, _applicationState);
            stream.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            ApplicationStateSerialize();
            UnregisterHotKeys();
            base.OnClosed(e);
        }

        private void StopHighlighting()
        {
            if (this._highlighter != null)
            {
                this._highlighter.Dispose();
                this._highlighter = null;
            }
        }

        private void ShowLog()
        {
            _testResults.ReadAndRefreshLog();
        }

        #region hot keys hook


        private void RegisterHotKeys()
        {
            this._hotKeys = new HotKey[]
            {
                new HotKey("Ctrl+Shift", "F5", new EventHandler(this.refreshElementToolStripButton_Click)),

                new HotKey("Ctrl+Shift", "F6", new EventHandler(this.goToParentToolStripButton_Click)),
                new HotKey("Ctrl+Shift", "F7", new EventHandler(this.goToFirstChildToolStripButton_Click)),
                new HotKey("Ctrl+Shift", "F8", new EventHandler(this.goToNextSiblingToolStripButton_Click)),
                new HotKey("Ctrl+Shift", "F9", new EventHandler(this.goToPrevSiblingToolStripButton_Click)),
                new HotKey("Ctrl+Shift", "F10", new EventHandler(this.goToLastChildToolStripButton_Click)),

                new HotKey("Ctrl+Shift", "7", new EventHandler(this.leftArrowToolStripMenuItem_Click)),
                new HotKey("Ctrl+Shift", "8", new EventHandler(this.upArrowToolStripMenuItem_Click)),
                new HotKey("Ctrl+Shift", "9", new EventHandler(this.downArrowToolStripMenuItem_Click)),
                new HotKey("Ctrl+Shift", "0", new EventHandler(this.rightArrowToolStripMenuItem_Click)),

                new HotKey("Ctrl+Shift", "R", new EventHandler(this.runSelectedTestToolStripMenuItem_Click)),
                new HotKey("Ctrl+Shift", "E", new EventHandler(this.runSelectedTestsOnSelectedElementAndAllChildrenToolStripMenuItem_Click)),

                new HotKey("Ctrl+Shift", "T", new EventHandler(this.alwaysOnTopHotKey)),
                new HotKey("Ctrl+Shift", "H", new EventHandler(this.hoverModeHotKey)),
                new HotKey("Ctrl+Shift", "F", new EventHandler(this.focusTrackingHotKey))
            };

            int index = 0;
            foreach (HotKey hotKey in this._hotKeys)
            {
                if (!UnsafeNativeMethods.RegisterHotKey(base.Handle, index, hotKey.Mask, hotKey.VKCode))
                {
                    MessageBox.Show(string.Format("Cannot register HotKey {0}", hotKey.Description), "Visual UI Automation Verify Error");
                }
                index++;
            }
        }

        private void UnregisterHotKeys()
        {
            int index = 0;
            foreach (HotKey hotKey in this._hotKeys)
            {
                UnsafeNativeMethods.UnregisterHotKey(base.Handle, index++);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == 0x312)
            {
                this._hotKeys[msg.WParam.ToInt32()].Handler(this, EventArgs.Empty);
            }
            base.WndProc(ref msg);
        }



        #endregion

        private void SetLogNavigationButtons()
        {
            backToolStripButton.Enabled = _testResults.CanGoBack;
            forwardToolStripButton.Enabled = _testResults.CanGoForward;
        }

        private void RunSelectedTest()
        {
            try
            {
                Console.WriteLine(_automationTests.SelectedElement.Current.LocalizedControlType);
                AutomationTestManager.RunTest(_automationTests.SelectedTests, _automationTests.SelectedElement, true, this);
                ShowLog();
            }
            catch (Exception)
            {
                // bug: if you select AutomationElement instead of the tests
            }
        }

        private void RunSelectedTestOnAllChildren()
        {
            AutomationTestManager.RunTestOnAllChildren(_automationTests.SelectedTests, _automationTests.SelectedElement, true, this);
            ShowLog();
        }

        #region logging

        void ApplicationLogger_LoggingProgressEvent(string message, int percentage)
        {
            ShowLoggingMessage(message, percentage);
        }

        private delegate void ShowLoggingMessageDelegate(string message, int percentage);

        private void ShowLoggingMessage(string message, int percentage)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new ShowLoggingMessageDelegate(ShowLoggingMessage), message, percentage);
            }
            else
            {
                this._messageToolStrip.Visible = true;
                this._progressToolStrip.Visible = true;

                this._messageToolStrip.Text = message;
                this._progressToolStrip.Value = percentage;


                if (percentage == 100)
                {
                    this._messageToolStrip.Visible = false;
                    this._progressToolStrip.Visible = false;
                }
            }
        }

        #endregion

        #region events

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //user wants to quit application
            Application.Exit();
        }

        private void goToParentToolStripButton_Click(object sender, EventArgs e)
        {
            //if some currentTestTypeRootNode is selected then go to its parent

            AutomationElementTreeNode selectedNode = this._automationElementTree.SelectedNode;
            if (selectedNode != null)
            {
                this._automationElementTree.GoToParentFromNode(selectedNode);
            }
        }

        private void goToFirstChildToolStripButton_Click(object sender, EventArgs e)
        {
            //if some currentTestTypeRootNode is selected then go to its first child

            AutomationElementTreeNode selectedNode = this._automationElementTree.SelectedNode;
            if (selectedNode != null)
            {
                this._automationElementTree.GoToFirstChildFromNode(selectedNode);
            }
        }

        private void goToNextSiblingToolStripButton_Click(object sender, EventArgs e)
        {
            //if some currentTestTypeRootNode is selected then go to its next sibling

            AutomationElementTreeNode selectedNode = this._automationElementTree.SelectedNode;
            if (selectedNode != null)
            {
                this._automationElementTree.GoToNextSiblingFromNode(selectedNode);
            }
        }

        private void goToPrevSiblingToolStripButton_Click(object sender, EventArgs e)
        {
            //if some currentTestTypeRootNode is selected then go to its previous sibling

            AutomationElementTreeNode selectedNode = this._automationElementTree.SelectedNode;
            if (selectedNode != null)
            {
                this._automationElementTree.GoToPreviousSiblingFromNode(selectedNode);
            }
        }

        private void goToLastChildToolStripButton_Click(object sender, EventArgs e)
        {
            //if some currentTestTypeRootNode is selected then go to its last child

            AutomationElementTreeNode selectedNode = this._automationElementTree.SelectedNode;
            if (selectedNode != null)
            {
                this._automationElementTree.GoToLastChildFromNode(selectedNode);
            }
        }

        private void parentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //resend message
            goToParentToolStripButton_Click(null, EventArgs.Empty);
        }

        private void firstChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //resend message
            goToFirstChildToolStripButton_Click(null, EventArgs.Empty);
        }

        private void nextSiblingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //resend message
            goToNextSiblingToolStripButton_Click(null, EventArgs.Empty);
        }

        private void prevSiblingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //resend message
            goToPrevSiblingToolStripButton_Click(null, EventArgs.Empty);
        }

        private void lastChildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //resend message
            goToLastChildToolStripButton_Click(null, EventArgs.Empty);
        }

        private void FocusTrackingToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (FocusTrackingToolStripMenuItem.Checked)
                _automationElementTree.StartFocusTracing();
            else
                _automationElementTree.StopFocusTracing();
        }

        private void alwaysOnTopHotKey(object sender, EventArgs e)
        {
            alwaysOnTopToolStripMenuItem.Checked = !alwaysOnTopToolStripMenuItem.Checked;
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
            this._applicationState.ModeAlwaysOnTop = alwaysOnTopToolStripMenuItem.Checked;
        }

        private void highlightingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem senderMenuItem = (ToolStripMenuItem)sender;

            if (senderMenuItem.Checked)
                return;

            this._applicationState.HighLight = (string)senderMenuItem.Tag;

            rectangleHighlightingToolStripMenuItem.Checked = false;
            fadingRectangleHighlightingToolStripMenuItem.Checked = false;
            raysAndRectangleHighlightingToolStripMenuItem.Checked = false;
            noneHighlightingToolStripMenuItem.Checked = false;
            senderMenuItem.Checked = true;

            StopHighlighting();

            switch (this._applicationState.HighLight)
            {
                case ElementHighlighterFactory.None:
                    {
                        break;
                    }
                default:
                    {
                        _highlighter = ElementHighlighterFactory.CreateHighlighterById(this._applicationState.HighLight, this._automationElementTree);
                        _highlighter.StartHighlighting();
                        break;
                    }
            }
        }

        private void _automationElementTree_SelectedNodeChanged(object sender, EventArgs e)
        {
            //selected currentTestTypeRootNode has been changed so notify change to AutomationTests Control
            AutomationElementTreeNode selectedNode = _automationElementTree.SelectedNode;
            AutomationElement selectedElement = null;

            if (selectedNode != null)
                selectedElement = selectedNode.AutomationElement;

            _automationTests.SelectedElement = selectedElement;
            _automationElementPropertyGrid.AutomationElement = selectedElement;
        }

        private void hoverModeHotKey(object sender, EventArgs e)
        {
            hoverModeToolStripMenuItem.Checked = !hoverModeToolStripMenuItem.Checked;

            hoverModeToolStripMenuItem_Click(sender, e);
        }


        private void hoverModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._applicationState.ModeHoverMode = hoverModeToolStripMenuItem.Checked;

            if (hoverModeToolStripMenuItem.Checked)
                this._automationElementTree.StartHoverMode();
            else
                this._automationElementTree.StopHoverMode();
        }

        private void testsScopeToolStrip_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem senderMenu = (ToolStripMenuItem)sender;

            //if item is checked then exit, the item can be unchecked only by checking another item
            if (senderMenu.Checked)
                return;

            //check new item, uncheck old items
            allTestsToolStripMenuItem.Checked = false;
            testsForSelectedAutomationElementToolStripMenuItem.Checked = false;
            senderMenu.Checked = true;

            Debug.Assert(senderMenu.Tag is TestsScope, "MainWindow design is broken!");
            TestsScope scope = (TestsScope)senderMenu.Tag;

            _automationTests.Scope = scope;
        }

        private void testTypesMenuToolStrip_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem senderMenu = (ToolStripMenuItem)sender;

            Debug.Assert(senderMenu.Tag is TestTypes, "MainWindow design is broken!");
            TestTypes testType = (TestTypes)senderMenu.Tag;

            TestTypes newValue = _automationTests.Types;

            if (senderMenu.Checked)
                newValue |= testType; //add flag
            else
                newValue &= ~testType; //remove flag

            _automationTests.Types = newValue;
        }

        private void testPrioritiesToolStrip_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem senderMenu = (ToolStripMenuItem)sender;

            Debug.Assert(senderMenu.Tag is TestPriorities, "MainWindow design is broken!");
            TestPriorities testPriority = (TestPriorities)senderMenu.Tag;

            TestPriorities newValue = _automationTests.Priorities;

            // remove TestPriorities.PriorityAllTests tests
            newValue &= ~TestPriorities.OnlyPriorityAllTests;

            if (senderMenu.Checked)
                newValue |= testPriority; //add flag
            else
                newValue &= ~testPriority; //remove flag

            _automationTests.Priorities = newValue;

        }

        private void _automationTests_RunTestRequired(object sender, EventArgs e)
        {
            RunSelectedTest();
        }


        private void _automationTests_RunTestOnAllChildrenRequired(object sender, EventArgs e)
        {
            AutomationTestManager.RunTestOnAllChildren(_automationTests.SelectedTests, _automationTests.SelectedElement, true, this);
            ShowLog();
        }

        private void _testResultsToolStrip_ButtonClick(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;

            foreach (ToolStripItem item in _testResultsToolStrip.Items)
            {
                if (item is ToolStripButton)
                    ((ToolStripButton)item).Checked = false;
            }

            button.Checked = true;

            _testResults.LogType = (TestResultsControl.LogTypes)button.Tag;

            _testResults.RefreshLog();
        }

        private void _testResults_NavigationChanged(object sender, NavigationChangedEventArgs e)
        {
            foreach (ToolStripItem item in _testResultsToolStrip.Items)
            {
                ToolStripButton button = item as ToolStripButton;
                if (button != null)
                {
                    if (button.Tag is TestResultsControl.LogTypes)
                    {
                        button.Checked = ((TestResultsControl.LogTypes)button.Tag) == e.LogType;
                    }
                }
            }

            SetLogNavigationButtons();
        }

        private void backToolStripButton_Click(object sender, EventArgs e)
        {
            _testResults.GoBack();
            SetLogNavigationButtons();
        }

        private void forwardToolStripButton_Click(object sender, EventArgs e)
        {
            _testResults.GoForward();
            SetLogNavigationButtons();
        }

        private void quickFindToolStripButton_Click(object sender, EventArgs e)
        {
            _testResults.ShowQuickFind();
        }

        private void openInNewWindowToolStripButton_Click(object sender, EventArgs e)
        {
            _testResults.OpenInNewWindow();
        }

        private void propertyPaneToolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;

            if (button != null)
            {
                PropertySort propertySort = (PropertySort)button.Tag;

                PropertySort newValue = _automationElementPropertyGrid.PropertySort;

                if (button.Checked)
                    newValue |= propertySort;
                else
                    newValue &= ~propertySort;

                _automationElementPropertyGrid.PropertySort = newValue;
            }
        }

        private void refreshElementToolStripButton_Click(object sender, EventArgs e)
        {
            AutomationElementTreeNode node = _automationElementTree.SelectedNode;
            if (node != null)
            {
                _automationElementTree.RefreshNode(node);
            }
        }

        private void focusTrackingHotKey(object sender, EventArgs e)
        {
            focusTrackingToolStripMenuItem1.Checked = !focusTrackingToolStripMenuItem1.Checked;

            focusTrackingToolStripMenuItem1_Click(sender, e);
        }

        private void focusTrackingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this._applicationState.ModeFocusTracking = focusTrackingToolStripMenuItem1.Checked;

            if (focusTrackingToolStripMenuItem1.Checked)
                _automationElementTree.StartFocusTracing();
            else
                _automationElementTree.StopFocusTracing();

        }

        private void testArrowButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;

            if (button != null)
            {
                MovementDirections direction = (MovementDirections)button.Tag;
                _automationTests.MoveToTest(direction);
            }
        }

        private void testArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            if (menuItem != null)
            {
                MovementDirections direction = (MovementDirections)menuItem.Tag;
                _automationTests.MoveToTest(direction);
            }
        }

        private void leftArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _automationTests.MoveToTest(MovementDirections.Left);
        }
        private void rightArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _automationTests.MoveToTest(MovementDirections.Right);
        }
        private void upArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _automationTests.MoveToTest(MovementDirections.Up);
        }
        private void downArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _automationTests.MoveToTest(MovementDirections.Down);
        }

        private void runTestToolStripButton_Click(object sender, EventArgs e)
        {
            RunSelectedTest();
        }

        private void runSelectedTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunSelectedTest();
        }

        private void refreshTestsToolStripButton_Click(object sender, EventArgs e)
        {
            _automationTests.RefreshTests(true);
        }

        private void refreshPropertyPaneToolStripButton_Click(object sender, EventArgs e)
        {
            _automationElementPropertyGrid.RefreshValues();
        }

        private void expandAllToolStripButton_Click(object sender, EventArgs e)
        {
            _automationElementPropertyGrid.ExpandAll = expandAllToolStripButton.Checked;
        }

        private void runTestOnAllChildrenToolStripButton_Click(object sender, EventArgs e)
        {
            RunSelectedTestOnAllChildren();
        }

        private void runSelectedTestsOnSelectedElementAndAllChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunSelectedTestOnAllChildren();
        }

        private void aboutVisualUIAVerifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutWindow().ShowDialog(this);
        }

        #endregion

        private void UnmanagedProxiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnloadClientSideProviders();
        }

        // Set up pInvoke for UiaRegisterProviderCallback
        [DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
        private static extern void UiaRegisterProviderCallback(IntPtr callback);

        /// <summary>
        /// Unload client side provider.  This will default to the MSAA Proxy.
        /// </summary>
        public void UnloadClientSideProviders()
        {
            // First, do something to ensure the proxy loading call has been made
            AutomationElement root = AutomationElement.RootElement;

            // Register a Null callback, this tells UI Automation to use the new proxies in Core
            UiaRegisterProviderCallback(IntPtr.Zero);

            VerifyWeHaveUIAutomation();

            this.UnmanagedProxiesToolStripMenuItem.Enabled = false;
            Text = string.Format("{0} : {1}", BaseTitle, "No Client Side Provider");

            AutomationElementTreeNode node = _automationElementTree.RootNode;
            if (node != null)
            {
                _automationElementTree.RefreshNode(node);
            }
        }

        /// <summary>
        /// Quick test to determine if we have a valid UIAutomationCore dynamic library.
        /// </summary>
        public static void VerifyWeHaveUIAutomation()
        {
            try
            {
                AutomationElement root = AutomationElement.RootElement;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Exception has occured that indicates you are trying to turn off 'Client Side Provider'.  You may not have the most recent version of UIAutomationCore.dll installed on your system.  Please contact your accessibility contact to find out how to obtain a newer version of UIAutomationCoredll.  Visual UIVerify / UIAutomationCore are now unstable.  Please restart Visual UIVerify to use the default Client Side Provider (Windows Vista/.NET Framework 3.0).");
            }
            catch (Exception error)
            {
                while (null != error.InnerException)
                {
                    error = error.InnerException;
                }
                MessageBox.Show(error.Message + error.GetType().ToString());
                throw error;
            }
        }

        private void filterKnownIssuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filterKnownIssuesToolStripMenuItem.Checked = !filterKnownIssuesToolStripMenuItem.Checked;
            TestRuns.FilterOutBugs = filterKnownIssuesToolStripMenuItem.Checked;
            if (TestRuns.FilterOutBugs)
            {
                if (openFilterFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _filterFileName = openFilterFileDialog.FileName;
                    TestRuns.BugFilterFile = _filterFileName;
                }
            }
            else
            {
                TestRuns.BugFilterFile = String.Empty;
            }
        }

        private void saveLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveLogFileDialog.ShowDialog() == DialogResult.OK)
            {
                UIVerifyLogger.GenerateXMLLog(saveLogFileDialog.FileName);
            }
        }

    }
}
