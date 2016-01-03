// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;

namespace VisualUIAVerify.Forms
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

       
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.UnmanagedProxiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleHighlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fadingRectangleHighlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.raysAndRectangleHighlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.noneHighlightingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automationElementTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.parentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextSiblingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prevSiblingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lastChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.hoverModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.focusTrackingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.testsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goRightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.runSelectedTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.filterKnownIssuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();			
            this.openFilterFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveLogFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutVisualUIAVerifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._messageToolStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this._progressToolStrip = new System.Windows.Forms.ToolStripProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._automationElementTree = new VisualUIAVerify.Controls.AutomationElementTreeControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.refreshElementToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.goToParentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.goToFirstChildToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.goToNextSiblingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.goToPrevSiblingToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.goToLastChildToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FocusTrackingToolStripMenuItem = new System.Windows.Forms.ToolStripButton();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._automationElementPropertyGrid = new VisualUIAVerify.Controls.AutomationElementPropertyGrid();
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.refreshPropertyPaneToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.showCategoriesToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.sortAlphabeticalToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripSeparator();
            this.expandAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this._automationTests = new VisualUIAVerify.Controls.AutomationTestsControl();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.refreshTestsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.testsScopeToolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.testsForSelectedAutomationElementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.testTypesMenuToolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.automationElementTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patternTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testPrioritiesToolStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.buildVerificationTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priority0TestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priority1TestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priority2TestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priority3TestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.goLeftToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.goUpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.goDownToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.goRightToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.runTestToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.runTestOnAllChildrenToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this._testResults = new VisualUIAVerify.Controls.TestResultsControl();
            this._testResultsToolStrip = new System.Windows.Forms.ToolStrip();
            this.backToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.forwardToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.overallToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.allResultsToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.FullDetailToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.xmlToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.quickFindToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.openInNewWindowToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStrip5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this._testResultsToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.viewToolStripMenuItem,
            this.automationElementTreeToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.testsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1032, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UnmanagedProxiesToolStripMenuItem,
            this.saveLogToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "&File";
            // 
            // UnmanagedProxiesToolStripMenuItem
            // 
            this.UnmanagedProxiesToolStripMenuItem.Name = "UnmanagedProxiesToolStripMenuItem";
            this.UnmanagedProxiesToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.UnmanagedProxiesToolStripMenuItem.Text = "Remove Client Side Provider";
            this.UnmanagedProxiesToolStripMenuItem.Click += new System.EventHandler(this.UnmanagedProxiesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // saveLogToolStripMenuItem
            // 
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.saveLogToolStripMenuItem.Text = "Save Log";
            this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);

            // 
            // saveLogFileDialog
            // 
            this.saveLogFileDialog.Filter = "XML files|*.xml";            
            this.saveLogFileDialog.RestoreDirectory = true;
            this.saveLogFileDialog.DefaultExt = "xml";

            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highlightingToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // highlightingToolStripMenuItem
            // 
            this.highlightingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rectangleHighlightingToolStripMenuItem,
            this.fadingRectangleHighlightingToolStripMenuItem,
            this.raysAndRectangleHighlightingToolStripMenuItem,
            this.toolStripSeparator2,
            this.noneHighlightingToolStripMenuItem});
            this.highlightingToolStripMenuItem.Name = "highlightingToolStripMenuItem";
            this.highlightingToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.highlightingToolStripMenuItem.Text = "Highlighting";
            // 
            // rectangleHighlightingToolStripMenuItem
            // 
            this.rectangleHighlightingToolStripMenuItem.Name = "rectangleHighlightingToolStripMenuItem";
            this.rectangleHighlightingToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.rectangleHighlightingToolStripMenuItem.Tag = "Rectangle";
            this.rectangleHighlightingToolStripMenuItem.Text = "&Rectangle";
            this.rectangleHighlightingToolStripMenuItem.Click += new System.EventHandler(this.highlightingToolStripMenuItem_Click);
            // 
            // fadingRectangleHighlightingToolStripMenuItem
            // 
            this.fadingRectangleHighlightingToolStripMenuItem.Name = "fadingRectangleHighlightingToolStripMenuItem";
            this.fadingRectangleHighlightingToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.fadingRectangleHighlightingToolStripMenuItem.Tag = "fadingRectangle";
            this.fadingRectangleHighlightingToolStripMenuItem.Text = "&Fading Rectangle";
            this.fadingRectangleHighlightingToolStripMenuItem.Click += new System.EventHandler(this.highlightingToolStripMenuItem_Click);
            // 
            // raysAndRectangleHighlightingToolStripMenuItem
            // 
            this.raysAndRectangleHighlightingToolStripMenuItem.Name = "raysAndRectangleHighlightingToolStripMenuItem";
            this.raysAndRectangleHighlightingToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.raysAndRectangleHighlightingToolStripMenuItem.Tag = "rays";
            this.raysAndRectangleHighlightingToolStripMenuItem.Text = "Ra&ys and Rectangle";
            this.raysAndRectangleHighlightingToolStripMenuItem.Click += new System.EventHandler(this.highlightingToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // noneHighlightingToolStripMenuItem
            // 
            this.noneHighlightingToolStripMenuItem.Name = "noneHighlightingToolStripMenuItem";
            this.noneHighlightingToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.noneHighlightingToolStripMenuItem.Text = "None";
            this.noneHighlightingToolStripMenuItem.Click += new System.EventHandler(this.highlightingToolStripMenuItem_Click);
            // 
            // automationElementTreeToolStripMenuItem
            // 
            this.automationElementTreeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.navigationToolStripMenuItem1});
            this.automationElementTreeToolStripMenuItem.Name = "automationElementTreeToolStripMenuItem";
            this.automationElementTreeToolStripMenuItem.Size = new System.Drawing.Size(155, 20);
            this.automationElementTreeToolStripMenuItem.Text = "&Automation Element Tree";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.elemtyperefresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+F5";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(284, 22);
            this.refreshToolStripMenuItem.Text = "&Refresh Selected Element";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshElementToolStripButton_Click);
            // 
            // navigationToolStripMenuItem1
            // 
            this.navigationToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parentToolStripMenuItem,
            this.firstChildToolStripMenuItem,
            this.nextSiblingToolStripMenuItem,
            this.prevSiblingToolStripMenuItem1,
            this.lastChildToolStripMenuItem});
            this.navigationToolStripMenuItem1.Name = "navigationToolStripMenuItem1";
            this.navigationToolStripMenuItem1.Size = new System.Drawing.Size(284, 22);
            this.navigationToolStripMenuItem1.Text = "Navigation";
            // 
            // parentToolStripMenuItem
            // 
            this.parentToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotoparent;
            this.parentToolStripMenuItem.Name = "parentToolStripMenuItem";
            this.parentToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+F6";
            this.parentToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.parentToolStripMenuItem.Text = "&Parent";
            this.parentToolStripMenuItem.Click += new System.EventHandler(this.goToParentToolStripButton_Click);
            // 
            // firstChildToolStripMenuItem
            // 
            this.firstChildToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotofirstchild;
            this.firstChildToolStripMenuItem.Name = "firstChildToolStripMenuItem";
            this.firstChildToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+F7";
            this.firstChildToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.firstChildToolStripMenuItem.Text = "&First Child";
            this.firstChildToolStripMenuItem.Click += new System.EventHandler(this.goToFirstChildToolStripButton_Click);
            // 
            // nextSiblingToolStripMenuItem
            // 
            this.nextSiblingToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotonextsibling;
            this.nextSiblingToolStripMenuItem.Name = "nextSiblingToolStripMenuItem";
            this.nextSiblingToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+F8";
            this.nextSiblingToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.nextSiblingToolStripMenuItem.Text = "&Next Sibling";
            this.nextSiblingToolStripMenuItem.Click += new System.EventHandler(this.goToNextSiblingToolStripButton_Click);
            // 
            // prevSiblingToolStripMenuItem1
            // 
            this.prevSiblingToolStripMenuItem1.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotoprevsibling;
            this.prevSiblingToolStripMenuItem1.Name = "prevSiblingToolStripMenuItem1";
            this.prevSiblingToolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl+Shift+F9";
            this.prevSiblingToolStripMenuItem1.Size = new System.Drawing.Size(215, 22);
            this.prevSiblingToolStripMenuItem1.Text = "&Prev Sibling";
            this.prevSiblingToolStripMenuItem1.Click += new System.EventHandler(this.goToPrevSiblingToolStripButton_Click);
            // 
            // lastChildToolStripMenuItem
            // 
            this.lastChildToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotolastchild;
            this.lastChildToolStripMenuItem.Name = "lastChildToolStripMenuItem";
            this.lastChildToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+F10";
            this.lastChildToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.lastChildToolStripMenuItem.Text = "&Last Child";
            this.lastChildToolStripMenuItem.Click += new System.EventHandler(this.goToLastChildToolStripButton_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alwaysOnTopToolStripMenuItem,
            this.toolStripSeparator10,
            this.hoverModeToolStripMenuItem,
            this.focusTrackingToolStripMenuItem1});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "&Mode";
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.CheckOnClick = true;
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+T";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "&Always On Top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(263, 6);
            // 
            // hoverModeToolStripMenuItem
            // 
            this.hoverModeToolStripMenuItem.CheckOnClick = true;
            this.hoverModeToolStripMenuItem.Name = "hoverModeToolStripMenuItem";
            this.hoverModeToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+H";
            this.hoverModeToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
            this.hoverModeToolStripMenuItem.Text = "&Hover Mode (use Ctrl)";
            this.hoverModeToolStripMenuItem.Click += new System.EventHandler(this.hoverModeToolStripMenuItem_Click);
            // 
            // focusTrackingToolStripMenuItem1
            // 
            this.focusTrackingToolStripMenuItem1.CheckOnClick = true;
            this.focusTrackingToolStripMenuItem1.Name = "focusTrackingToolStripMenuItem1";
            this.focusTrackingToolStripMenuItem1.ShortcutKeyDisplayString = "Ctrl+Shift+F";
            this.focusTrackingToolStripMenuItem1.Size = new System.Drawing.Size(266, 22);
            this.focusTrackingToolStripMenuItem1.Text = "&Focus Tracking";
            this.focusTrackingToolStripMenuItem1.Click += new System.EventHandler(this.focusTrackingToolStripMenuItem1_Click);
            // 
            // testsToolStripMenuItem
            // 
            this.testsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goLeftToolStripMenuItem,
            this.goUpToolStripMenuItem,
            this.goDownToolStripMenuItem,
            this.goRightToolStripMenuItem,
            this.toolStripSeparator13,
            this.runSelectedTestToolStripMenuItem,
            this.toolStripSeparator3,
            this.filterKnownIssuesToolStripMenuItem});
            this.testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            this.testsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.testsToolStripMenuItem.Text = "&Tests";
            // 
            // goLeftToolStripMenuItem
            // 
            this.goLeftToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.arrowLeft;
            this.goLeftToolStripMenuItem.Name = "goLeftToolStripMenuItem";
            this.goLeftToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+7";
            this.goLeftToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.goLeftToolStripMenuItem.Text = "Go &Left";
            this.goLeftToolStripMenuItem.Click += new System.EventHandler(this.testArrowToolStripMenuItem_Click);
            // 
            // goUpToolStripMenuItem
            // 
            this.goUpToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.arrowUp;
            this.goUpToolStripMenuItem.Name = "goUpToolStripMenuItem";
            this.goUpToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+8";
            this.goUpToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.goUpToolStripMenuItem.Text = "Go &Up";
            this.goUpToolStripMenuItem.Click += new System.EventHandler(this.testArrowToolStripMenuItem_Click);
            // 
            // goDownToolStripMenuItem
            // 
            this.goDownToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.arrowDown;
            this.goDownToolStripMenuItem.Name = "goDownToolStripMenuItem";
            this.goDownToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+9";
            this.goDownToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.goDownToolStripMenuItem.Text = "Go &Down";
            this.goDownToolStripMenuItem.Click += new System.EventHandler(this.testArrowToolStripMenuItem_Click);
            // 
            // goRightToolStripMenuItem
            // 
            this.goRightToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.arrowRight;
            this.goRightToolStripMenuItem.Name = "goRightToolStripMenuItem";
            this.goRightToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+0";
            this.goRightToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.goRightToolStripMenuItem.Text = "Go &Right";
            this.goRightToolStripMenuItem.Click += new System.EventHandler(this.testArrowToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(360, 6);
            // 
            // runSelectedTestToolStripMenuItem
            // 
            this.runSelectedTestToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.testToRun;
            this.runSelectedTestToolStripMenuItem.Name = "runSelectedTestToolStripMenuItem";
            this.runSelectedTestToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.R)));
            this.runSelectedTestToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.runSelectedTestToolStripMenuItem.Text = "Run &Selected Test(s) on Selected Element";
            this.runSelectedTestToolStripMenuItem.Click += new System.EventHandler(this.runSelectedTestToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(360, 6);
            // 
            // filterKnownIssuesToolStripMenuItem
            // 
            this.filterKnownIssuesToolStripMenuItem.Checked = true;
            this.filterKnownIssuesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.filterKnownIssuesToolStripMenuItem.Name = "filterKnownIssuesToolStripMenuItem";
            this.filterKnownIssuesToolStripMenuItem.Size = new System.Drawing.Size(363, 22);
            this.filterKnownIssuesToolStripMenuItem.Text = "Filter Known Problems";
            this.filterKnownIssuesToolStripMenuItem.Click += new System.EventHandler(this.filterKnownIssuesToolStripMenuItem_Click);
            // 
            // openFilterFileDialog
            // 
            this.openFilterFileDialog.Filter = "XML files|*.xml";
            this.openFilterFileDialog.Multiselect = false;
            this.openFilterFileDialog.RestoreDirectory = true;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutVisualUIAVerifyToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutVisualUIAVerifyToolStripMenuItem
            // 
            this.aboutVisualUIAVerifyToolStripMenuItem.Name = "aboutVisualUIAVerifyToolStripMenuItem";
            this.aboutVisualUIAVerifyToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.aboutVisualUIAVerifyToolStripMenuItem.Text = "&About Visual UI Automation Verify.";
            this.aboutVisualUIAVerifyToolStripMenuItem.Click += new System.EventHandler(this.aboutVisualUIAVerifyToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 663);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1032, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _messageToolStrip
            // 
            this._messageToolStrip.Name = "_messageToolStrip";
            this._messageToolStrip.Size = new System.Drawing.Size(233, 17);
            this._messageToolStrip.Text = "status text . . . . . . . . . . . . . . . . . . . . . . . . . . . . . ";
            this._messageToolStrip.Visible = false;
            // 
            // _progressToolStrip
            // 
            this._progressToolStrip.Name = "_progressToolStrip";
            this._progressToolStrip.Size = new System.Drawing.Size(100, 16);
            this._progressToolStrip.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 639);
            this.panel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._automationElementTree);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 639);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automation Elements Tree";
            // 
            // _automationElementTree
            // 
            this._automationElementTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this._automationElementTree.Location = new System.Drawing.Point(3, 41);
            this._automationElementTree.Name = "_automationElementTree";
            this._automationElementTree.Size = new System.Drawing.Size(310, 595);
            this._automationElementTree.TabIndex = 1;
            this._automationElementTree.SelectedNodeChanged += new VisualUIAVerify.Controls.SelectedNodeChangedEventDelegate(this._automationElementTree_SelectedNodeChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshElementToolStripButton,
            this.toolStripSeparator9,
            this.goToParentToolStripButton,
            this.goToFirstChildToolStripButton,
            this.goToNextSiblingToolStripButton,
            this.goToPrevSiblingToolStripButton,
            this.goToLastChildToolStripButton,
            this.toolStripSeparator1,
            this.FocusTrackingToolStripMenuItem});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(310, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // refreshElementToolStripButton
            // 
            this.refreshElementToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshElementToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.elemtyperefresh;
            this.refreshElementToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshElementToolStripButton.Name = "refreshElementToolStripButton";
            this.refreshElementToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshElementToolStripButton.Text = "Refresh selected element";
            this.refreshElementToolStripButton.Click += new System.EventHandler(this.refreshElementToolStripButton_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // goToParentToolStripButton
            // 
            this.goToParentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goToParentToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotoparent;
            this.goToParentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goToParentToolStripButton.Name = "goToParentToolStripButton";
            this.goToParentToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.goToParentToolStripButton.Text = "Parent";
            this.goToParentToolStripButton.ToolTipText = "Parent (Ctrl+Shift+F6)";
            this.goToParentToolStripButton.Click += new System.EventHandler(this.goToParentToolStripButton_Click);
            // 
            // goToFirstChildToolStripButton
            // 
            this.goToFirstChildToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goToFirstChildToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotofirstchild;
            this.goToFirstChildToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goToFirstChildToolStripButton.Name = "goToFirstChildToolStripButton";
            this.goToFirstChildToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.goToFirstChildToolStripButton.Text = "First Child";
            this.goToFirstChildToolStripButton.ToolTipText = "First Child (Ctrl+Shift+F7)";
            this.goToFirstChildToolStripButton.Click += new System.EventHandler(this.goToFirstChildToolStripButton_Click);
            // 
            // goToNextSiblingToolStripButton
            // 
            this.goToNextSiblingToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goToNextSiblingToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotonextsibling;
            this.goToNextSiblingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goToNextSiblingToolStripButton.Name = "goToNextSiblingToolStripButton";
            this.goToNextSiblingToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.goToNextSiblingToolStripButton.Text = "Next Sibling";
            this.goToNextSiblingToolStripButton.ToolTipText = "Next Sibling (Ctrl+Shift+F8)";
            this.goToNextSiblingToolStripButton.Click += new System.EventHandler(this.goToNextSiblingToolStripButton_Click);
            // 
            // goToPrevSiblingToolStripButton
            // 
            this.goToPrevSiblingToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goToPrevSiblingToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotoprevsibling;
            this.goToPrevSiblingToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goToPrevSiblingToolStripButton.Name = "goToPrevSiblingToolStripButton";
            this.goToPrevSiblingToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.goToPrevSiblingToolStripButton.Text = "Prev Sibling";
            this.goToPrevSiblingToolStripButton.ToolTipText = "Prev Sibling (Ctrl+Shift+F9)";
            this.goToPrevSiblingToolStripButton.Click += new System.EventHandler(this.goToPrevSiblingToolStripButton_Click);
            // 
            // goToLastChildToolStripButton
            // 
            this.goToLastChildToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goToLastChildToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotolastchild;
            this.goToLastChildToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goToLastChildToolStripButton.Name = "goToLastChildToolStripButton";
            this.goToLastChildToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.goToLastChildToolStripButton.Text = "Last Child";
            this.goToLastChildToolStripButton.ToolTipText = "Last Child (Ctrl+Shift+F0)";
            this.goToLastChildToolStripButton.Click += new System.EventHandler(this.goToLastChildToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // FocusTrackingToolStripMenuItem
            // 
            this.FocusTrackingToolStripMenuItem.CheckOnClick = true;
            this.FocusTrackingToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FocusTrackingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("FocusTrackingToolStripMenuItem.Image")));
            this.FocusTrackingToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FocusTrackingToolStripMenuItem.Name = "FocusTrackingToolStripMenuItem";
            this.FocusTrackingToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.FocusTrackingToolStripMenuItem.Text = "Focus Tracking";
            this.FocusTrackingToolStripMenuItem.Visible = false;
            this.FocusTrackingToolStripMenuItem.Click += new System.EventHandler(this.FocusTrackingToolStripMenuItem_CheckedChanged);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(316, 24);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 639);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._automationElementPropertyGrid);
            this.groupBox3.Controls.Add(this.toolStrip5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(832, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 639);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Properties";
            // 
            // _automationElementPropertyGrid
            // 
            this._automationElementPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._automationElementPropertyGrid.Location = new System.Drawing.Point(3, 41);
            this._automationElementPropertyGrid.Name = "_automationElementPropertyGrid";
            this._automationElementPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.CategorizedAlphabetical;
            this._automationElementPropertyGrid.Size = new System.Drawing.Size(194, 595);
            this._automationElementPropertyGrid.TabIndex = 0;
            // 
            // toolStrip5
            // 
            this.toolStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshPropertyPaneToolStripButton,
            this.toolStripSeparator15,
            this.showCategoriesToolStripButton,
            this.sortAlphabeticalToolStripButton,
            this.toolStripButton4,
            this.expandAllToolStripButton});
            this.toolStrip5.Location = new System.Drawing.Point(3, 16);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(194, 25);
            this.toolStrip5.TabIndex = 1;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // refreshPropertyPaneToolStripButton
            // 
            this.refreshPropertyPaneToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshPropertyPaneToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.elemtyperefresh;
            this.refreshPropertyPaneToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshPropertyPaneToolStripButton.Name = "refreshPropertyPaneToolStripButton";
            this.refreshPropertyPaneToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshPropertyPaneToolStripButton.Text = "toolStripButton3";
            this.refreshPropertyPaneToolStripButton.ToolTipText = "Refresh";
            this.refreshPropertyPaneToolStripButton.Click += new System.EventHandler(this.refreshPropertyPaneToolStripButton_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator15.Visible = false;
            // 
            // showCategoriesToolStripButton
            // 
            this.showCategoriesToolStripButton.Checked = true;
            this.showCategoriesToolStripButton.CheckOnClick = true;
            this.showCategoriesToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCategoriesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showCategoriesToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.orderCategorized;
            this.showCategoriesToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showCategoriesToolStripButton.Name = "showCategoriesToolStripButton";
            this.showCategoriesToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.showCategoriesToolStripButton.Text = "Show categories";
            this.showCategoriesToolStripButton.Visible = false;
            this.showCategoriesToolStripButton.Click += new System.EventHandler(this.propertyPaneToolStripButton_Click);
            // 
            // sortAlphabeticalToolStripButton
            // 
            this.sortAlphabeticalToolStripButton.Checked = true;
            this.sortAlphabeticalToolStripButton.CheckOnClick = true;
            this.sortAlphabeticalToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sortAlphabeticalToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sortAlphabeticalToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.orderAlphabetical;
            this.sortAlphabeticalToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortAlphabeticalToolStripButton.Name = "sortAlphabeticalToolStripButton";
            this.sortAlphabeticalToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.sortAlphabeticalToolStripButton.Text = "SortAlphabetical";
            this.sortAlphabeticalToolStripButton.Visible = false;
            this.sortAlphabeticalToolStripButton.Click += new System.EventHandler(this.propertyPaneToolStripButton_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(6, 25);
            this.toolStripButton4.Visible = false;
            // 
            // expandAllToolStripButton
            // 
            this.expandAllToolStripButton.CheckOnClick = true;
            this.expandAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.expandAllToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.ExpandAll;
            this.expandAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.expandAllToolStripButton.Name = "expandAllToolStripButton";
            this.expandAllToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.expandAllToolStripButton.Text = "Expand All";
            this.expandAllToolStripButton.Click += new System.EventHandler(this.expandAllToolStripButton_Click);
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter3.Location = new System.Drawing.Point(827, 24);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(5, 639);
            this.splitter3.TabIndex = 7;
            this.splitter3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this._automationTests);
            this.groupBox4.Controls.Add(this.toolStrip2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(321, 24);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(506, 286);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tests";
            // 
            // _automationTests
            // 
            this._automationTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this._automationTests.Location = new System.Drawing.Point(3, 41);
            this._automationTests.Name = "_automationTests";
            this._automationTests.Priorities = VisualUIAVerify.TestPriorities.None;
            this._automationTests.Scope = VisualUIAVerify.TestsScope.SelectedElementTests;
            this._automationTests.SelectedElement = null;
            this._automationTests.Size = new System.Drawing.Size(500, 242);
            this._automationTests.TabIndex = 2;
            this._automationTests.Types = VisualUIAVerify.TestTypes.None;
            this._automationTests.RunTestOnAllChildrenRequired += new System.EventHandler(this._automationTests_RunTestOnAllChildrenRequired);
            this._automationTests.RunTestRequired += new System.EventHandler(this._automationTests_RunTestRequired);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshTestsToolStripButton,
            this.toolStripSeparator14,
            this.testsScopeToolStrip,
            this.toolStripSeparator4,
            this.testTypesMenuToolStrip,
            this.testPrioritiesToolStrip,
            this.toolStripSeparator11,
            this.goLeftToolStripButton,
            this.goUpToolStripButton,
            this.goDownToolStripButton,
            this.goRightToolStripButton,
            this.toolStripSeparator12,
            this.runTestToolStripButton,
            this.runTestOnAllChildrenToolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(500, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // refreshTestsToolStripButton
            // 
            this.refreshTestsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshTestsToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.elemtyperefresh;
            this.refreshTestsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshTestsToolStripButton.Name = "refreshTestsToolStripButton";
            this.refreshTestsToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshTestsToolStripButton.Text = "Refresh Tests (reload test libraries)";
            this.refreshTestsToolStripButton.Visible = false;
            this.refreshTestsToolStripButton.Click += new System.EventHandler(this.refreshTestsToolStripButton_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator14.Visible = false;
            // 
            // testsScopeToolStrip
            // 
            this.testsScopeToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.testsScopeToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testsForSelectedAutomationElementToolStripMenuItem,
            this.allTestsToolStripMenuItem});
            this.testsScopeToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("testsScopeToolStrip.Image")));
            this.testsScopeToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.testsScopeToolStrip.Name = "testsScopeToolStrip";
            this.testsScopeToolStrip.Size = new System.Drawing.Size(49, 22);
            this.testsScopeToolStrip.Text = "Show";
            // 
            // testsForSelectedAutomationElementToolStripMenuItem
            // 
            this.testsForSelectedAutomationElementToolStripMenuItem.Checked = true;
            this.testsForSelectedAutomationElementToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.testsForSelectedAutomationElementToolStripMenuItem.Name = "testsForSelectedAutomationElementToolStripMenuItem";
            this.testsForSelectedAutomationElementToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.testsForSelectedAutomationElementToolStripMenuItem.Text = "Tests for Selected Automation Element";
            this.testsForSelectedAutomationElementToolStripMenuItem.Click += new System.EventHandler(this.testsScopeToolStrip_Click);
            // 
            // allTestsToolStripMenuItem
            // 
            this.allTestsToolStripMenuItem.Name = "allTestsToolStripMenuItem";
            this.allTestsToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.allTestsToolStripMenuItem.Text = "All Tests";
            this.allTestsToolStripMenuItem.Click += new System.EventHandler(this.testsScopeToolStrip_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // testTypesMenuToolStrip
            // 
            this.testTypesMenuToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.testTypesMenuToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.automationElementTestsToolStripMenuItem,
            this.patternTestsToolStripMenuItem,
            this.controlTestsToolStripMenuItem});
            this.testTypesMenuToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("testTypesMenuToolStrip.Image")));
            this.testTypesMenuToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.testTypesMenuToolStrip.Name = "testTypesMenuToolStrip";
            this.testTypesMenuToolStrip.Size = new System.Drawing.Size(46, 22);
            this.testTypesMenuToolStrip.Text = "Type";
            // 
            // automationElementTestsToolStripMenuItem
            // 
            this.automationElementTestsToolStripMenuItem.Checked = true;
            this.automationElementTestsToolStripMenuItem.CheckOnClick = true;
            this.automationElementTestsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.automationElementTestsToolStripMenuItem.Name = "automationElementTestsToolStripMenuItem";
            this.automationElementTestsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.automationElementTestsToolStripMenuItem.Text = "Automation Element Tests";
            this.automationElementTestsToolStripMenuItem.Click += new System.EventHandler(this.testTypesMenuToolStrip_Click);
            // 
            // patternTestsToolStripMenuItem
            // 
            this.patternTestsToolStripMenuItem.Checked = true;
            this.patternTestsToolStripMenuItem.CheckOnClick = true;
            this.patternTestsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.patternTestsToolStripMenuItem.Name = "patternTestsToolStripMenuItem";
            this.patternTestsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.patternTestsToolStripMenuItem.Text = "PatternTests";
            this.patternTestsToolStripMenuItem.Click += new System.EventHandler(this.testTypesMenuToolStrip_Click);
            // 
            // controlTestsToolStripMenuItem
            // 
            this.controlTestsToolStripMenuItem.Checked = true;
            this.controlTestsToolStripMenuItem.CheckOnClick = true;
            this.controlTestsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.controlTestsToolStripMenuItem.Name = "controlTestsToolStripMenuItem";
            this.controlTestsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.controlTestsToolStripMenuItem.Text = "Control Tests";
            this.controlTestsToolStripMenuItem.Click += new System.EventHandler(this.testTypesMenuToolStrip_Click);
            // 
            // testPrioritiesToolStrip
            // 
            this.testPrioritiesToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.testPrioritiesToolStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buildVerificationTestsToolStripMenuItem,
            this.priority0TestsToolStripMenuItem,
            this.priority1TestsToolStripMenuItem,
            this.priority2TestsToolStripMenuItem,
            this.priority3TestsToolStripMenuItem});
            this.testPrioritiesToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("testPrioritiesToolStrip.Image")));
            this.testPrioritiesToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.testPrioritiesToolStrip.Name = "testPrioritiesToolStrip";
            this.testPrioritiesToolStrip.Size = new System.Drawing.Size(66, 22);
            this.testPrioritiesToolStrip.Text = "Priorities";
            // 
            // buildVerificationTestsToolStripMenuItem
            // 
            this.buildVerificationTestsToolStripMenuItem.Checked = true;
            this.buildVerificationTestsToolStripMenuItem.CheckOnClick = true;
            this.buildVerificationTestsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.buildVerificationTestsToolStripMenuItem.Name = "buildVerificationTestsToolStripMenuItem";
            this.buildVerificationTestsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.buildVerificationTestsToolStripMenuItem.Text = "Build Verification Tests";
            this.buildVerificationTestsToolStripMenuItem.Click += new System.EventHandler(this.testPrioritiesToolStrip_Click);
            // 
            // priority0TestsToolStripMenuItem
            // 
            this.priority0TestsToolStripMenuItem.Checked = true;
            this.priority0TestsToolStripMenuItem.CheckOnClick = true;
            this.priority0TestsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.priority0TestsToolStripMenuItem.Name = "priority0TestsToolStripMenuItem";
            this.priority0TestsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.priority0TestsToolStripMenuItem.Text = "Priority 0 Tests";
            this.priority0TestsToolStripMenuItem.Click += new System.EventHandler(this.testPrioritiesToolStrip_Click);
            // 
            // priority1TestsToolStripMenuItem
            // 
            this.priority1TestsToolStripMenuItem.Checked = true;
            this.priority1TestsToolStripMenuItem.CheckOnClick = true;
            this.priority1TestsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.priority1TestsToolStripMenuItem.Name = "priority1TestsToolStripMenuItem";
            this.priority1TestsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.priority1TestsToolStripMenuItem.Text = "Priority 1 Tests";
            this.priority1TestsToolStripMenuItem.Click += new System.EventHandler(this.testPrioritiesToolStrip_Click);
            // 
            // priority2TestsToolStripMenuItem
            // 
            this.priority2TestsToolStripMenuItem.Checked = true;
            this.priority2TestsToolStripMenuItem.CheckOnClick = true;
            this.priority2TestsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.priority2TestsToolStripMenuItem.Name = "priority2TestsToolStripMenuItem";
            this.priority2TestsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.priority2TestsToolStripMenuItem.Text = "Priority 2 Tests";
            this.priority2TestsToolStripMenuItem.Click += new System.EventHandler(this.testPrioritiesToolStrip_Click);
            // 
            // priority3TestsToolStripMenuItem
            // 
            this.priority3TestsToolStripMenuItem.Checked = true;
            this.priority3TestsToolStripMenuItem.CheckOnClick = true;
            this.priority3TestsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.priority3TestsToolStripMenuItem.Name = "priority3TestsToolStripMenuItem";
            this.priority3TestsToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.priority3TestsToolStripMenuItem.Text = "Priority 3 Tests";
            this.priority3TestsToolStripMenuItem.Click += new System.EventHandler(this.testPrioritiesToolStrip_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // goLeftToolStripButton
            // 
            this.goLeftToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goLeftToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.arrowLeft;
            this.goLeftToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goLeftToolStripButton.Name = "goLeftToolStripButton";
            this.goLeftToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.goLeftToolStripButton.Text = "Go Left";
            this.goLeftToolStripButton.ToolTipText = "Go Left (Ctrl+Shift+7)";
            this.goLeftToolStripButton.Click += new System.EventHandler(this.testArrowButton_Click);
            // 
            // goUpToolStripButton
            // 
            this.goUpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goUpToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.arrowUp;
            this.goUpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goUpToolStripButton.Name = "goUpToolStripButton";
            this.goUpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.goUpToolStripButton.Text = "Go Up";
            this.goUpToolStripButton.ToolTipText = "Go Up (Ctrl+Shift+8)";
            this.goUpToolStripButton.Click += new System.EventHandler(this.testArrowButton_Click);
            // 
            // goDownToolStripButton
            // 
            this.goDownToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goDownToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.arrowDown;
            this.goDownToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goDownToolStripButton.Name = "goDownToolStripButton";
            this.goDownToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.goDownToolStripButton.Text = "Go Down";
            this.goDownToolStripButton.ToolTipText = "Go Down (Ctrl+Shift+9)";
            this.goDownToolStripButton.Click += new System.EventHandler(this.testArrowButton_Click);
            // 
            // goRightToolStripButton
            // 
            this.goRightToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.goRightToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.arrowRight;
            this.goRightToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goRightToolStripButton.Name = "goRightToolStripButton";
            this.goRightToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.goRightToolStripButton.Text = "Go Right";
            this.goRightToolStripButton.ToolTipText = "Go Right (Ctrl+Shift+0)";
            this.goRightToolStripButton.Click += new System.EventHandler(this.testArrowButton_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(6, 25);
            // 
            // runTestToolStripButton
            // 
            this.runTestToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.runTestToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.testToRun;
            this.runTestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runTestToolStripButton.Name = "runTestToolStripButton";
            this.runTestToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.runTestToolStripButton.Text = "Run Selected Test(s)";
            this.runTestToolStripButton.Click += new System.EventHandler(this.runTestToolStripButton_Click);
            // 
            // runTestOnAllChildrenToolStripButton
            // 
            this.runTestOnAllChildrenToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.runTestOnAllChildrenToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.testToRunWithChildren;
            this.runTestOnAllChildrenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.runTestOnAllChildrenToolStripButton.Name = "runTestOnAllChildrenToolStripButton";
            this.runTestOnAllChildrenToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.runTestOnAllChildrenToolStripButton.Text = "Run Selected Test On Selected Element and All Children Elements";
            this.runTestOnAllChildrenToolStripButton.Visible = false;
            this.runTestOnAllChildrenToolStripButton.Click += new System.EventHandler(this.runTestOnAllChildrenToolStripButton_Click);
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter4.Location = new System.Drawing.Point(321, 310);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(506, 5);
            this.splitter4.TabIndex = 9;
            this.splitter4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this._testResults);
            this.groupBox5.Controls.Add(this._testResultsToolStrip);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(321, 315);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(506, 348);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Test Results";
            // 
            // _testResults
            // 
            this._testResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._testResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this._testResults.Location = new System.Drawing.Point(3, 41);
            this._testResults.Name = "_testResults";
            this._testResults.Size = new System.Drawing.Size(500, 304);
            this._testResults.TabIndex = 1;
            this._testResults.NavigationChanged += new VisualUIAVerify.Controls.NavigationChangedEventHandler(this._testResults_NavigationChanged);
            // 
            // _testResultsToolStrip
            // 
            this._testResultsToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._testResultsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripButton,
            this.forwardToolStripButton,
            this.toolStripSeparator6,
            this.overallToolStripButton,
            this.allResultsToolStripButton,
            this.FullDetailToolStripButton,
            this.xmlToolStripButton,
            this.toolStripSeparator7,
            this.quickFindToolStripButton,
            this.toolStripSeparator8,
            this.openInNewWindowToolStripButton});
            this._testResultsToolStrip.Location = new System.Drawing.Point(3, 16);
            this._testResultsToolStrip.Name = "_testResultsToolStrip";
            this._testResultsToolStrip.Size = new System.Drawing.Size(500, 25);
            this._testResultsToolStrip.TabIndex = 0;
            this._testResultsToolStrip.Text = "toolStrip4";
            // 
            // backToolStripButton
            // 
            this.backToolStripButton.Enabled = false;
            this.backToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("backToolStripButton.Image")));
            this.backToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backToolStripButton.Name = "backToolStripButton";
            this.backToolStripButton.Size = new System.Drawing.Size(52, 22);
            this.backToolStripButton.Text = "Back";
            this.backToolStripButton.Click += new System.EventHandler(this.backToolStripButton_Click);
            // 
            // forwardToolStripButton
            // 
            this.forwardToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.forwardToolStripButton.Enabled = false;
            this.forwardToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("forwardToolStripButton.Image")));
            this.forwardToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forwardToolStripButton.Name = "forwardToolStripButton";
            this.forwardToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.forwardToolStripButton.Text = "Forward";
            this.forwardToolStripButton.Click += new System.EventHandler(this.forwardToolStripButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // overallToolStripButton
            // 
            this.overallToolStripButton.Checked = true;
            this.overallToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overallToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.overallToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("overallToolStripButton.Image")));
            this.overallToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.overallToolStripButton.Name = "overallToolStripButton";
            this.overallToolStripButton.Size = new System.Drawing.Size(48, 22);
            this.overallToolStripButton.Text = "Overall";
            this.overallToolStripButton.Click += new System.EventHandler(this._testResultsToolStrip_ButtonClick);
            // 
            // allResultsToolStripButton
            // 
            this.allResultsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.allResultsToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("allResultsToolStripButton.Image")));
            this.allResultsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.allResultsToolStripButton.Name = "allResultsToolStripButton";
            this.allResultsToolStripButton.Size = new System.Drawing.Size(65, 22);
            this.allResultsToolStripButton.Text = "All Results";
            this.allResultsToolStripButton.Click += new System.EventHandler(this._testResultsToolStrip_ButtonClick);
            // 
            // FullDetailToolStripButton
            // 
            this.FullDetailToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FullDetailToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("FullDetailToolStripButton.Image")));
            this.FullDetailToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FullDetailToolStripButton.Name = "FullDetailToolStripButton";
            this.FullDetailToolStripButton.Size = new System.Drawing.Size(53, 22);
            this.FullDetailToolStripButton.Text = "Full Log";
            this.FullDetailToolStripButton.Click += new System.EventHandler(this._testResultsToolStrip_ButtonClick);
            // 
            // xmlToolStripButton
            // 
            this.xmlToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.xmlToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("xmlToolStripButton.Image")));
            this.xmlToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.xmlToolStripButton.Name = "xmlToolStripButton";
            this.xmlToolStripButton.Size = new System.Drawing.Size(35, 22);
            this.xmlToolStripButton.Text = "XML";
            this.xmlToolStripButton.Click += new System.EventHandler(this._testResultsToolStrip_ButtonClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // quickFindToolStripButton
            // 
            this.quickFindToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.quickFind;
            this.quickFindToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quickFindToolStripButton.Name = "quickFindToolStripButton";
            this.quickFindToolStripButton.Size = new System.Drawing.Size(84, 22);
            this.quickFindToolStripButton.Text = "Quick Find";
            this.quickFindToolStripButton.Click += new System.EventHandler(this.quickFindToolStripButton_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // openInNewWindowToolStripButton
            // 
            this.openInNewWindowToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openInNewWindowToolStripButton.Image = global::VisualUIAVerify.VisualUIAVerifyResources.ieIcon;
            this.openInNewWindowToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openInNewWindowToolStripButton.Name = "openInNewWindowToolStripButton";
            this.openInNewWindowToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openInNewWindowToolStripButton.Text = "Open in new window";
            this.openInNewWindowToolStripButton.Click += new System.EventHandler(this.openInNewWindowToolStripButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton2.Text = "AllDetails";
            // 
            // toolStrip4
            // 
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Location = new System.Drawing.Point(3, 16);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(241, 25);
            this.toolStrip4.TabIndex = 0;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(48, 22);
            this.toolStripButton1.Text = "Overall";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 685);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.splitter4);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.splitter3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Visual UI Automation Verify";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this._testResultsToolStrip.ResumeLayout(false);
            this._testResultsToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private VisualUIAVerify.Controls.AutomationElementTreeControl _automationElementTree;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ToolStripStatusLabel _messageToolStrip;
        private System.Windows.Forms.ToolStripProgressBar _progressToolStrip;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleHighlightingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fadingRectangleHighlightingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raysAndRectangleHighlightingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem noneHighlightingToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.GroupBox groupBox5;
        private Controls.AutomationElementPropertyGrid _automationElementPropertyGrid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton goToParentToolStripButton;
        private System.Windows.Forms.ToolStripButton goToFirstChildToolStripButton;
        private System.Windows.Forms.ToolStripButton goToNextSiblingToolStripButton;
        private System.Windows.Forms.ToolStripButton goToPrevSiblingToolStripButton;
        private System.Windows.Forms.ToolStripButton goToLastChildToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStrip _testResultsToolStrip;
        private System.Windows.Forms.ToolStrip toolStrip5;
        private VisualUIAVerify.Controls.TestResultsControl _testResults;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hoverModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton FocusTrackingToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton testsScopeToolStrip;
        private System.Windows.Forms.ToolStripMenuItem testsForSelectedAutomationElementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton testTypesMenuToolStrip;
        private System.Windows.Forms.ToolStripMenuItem automationElementTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patternTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton testPrioritiesToolStrip;
        private System.Windows.Forms.ToolStripMenuItem buildVerificationTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priority0TestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priority1TestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priority2TestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priority3TestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton overallToolStripButton;
        private System.Windows.Forms.ToolStripButton FullDetailToolStripButton;
        private System.Windows.Forms.ToolStripButton xmlToolStripButton;
        private System.Windows.Forms.ToolStripButton allResultsToolStripButton;
        private System.Windows.Forms.ToolStripButton backToolStripButton;
        private System.Windows.Forms.ToolStripButton forwardToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton quickFindToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton openInNewWindowToolStripButton;
        private System.Windows.Forms.ToolStripButton showCategoriesToolStripButton;
        private System.Windows.Forms.ToolStripButton sortAlphabeticalToolStripButton;
        private System.Windows.Forms.ToolStripButton refreshElementToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem automationElementTreeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem parentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firstChildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextSiblingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prevSiblingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lastChildToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem focusTrackingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton goLeftToolStripButton;
        private System.Windows.Forms.ToolStripButton goUpToolStripButton;
        private System.Windows.Forms.ToolStripButton goDownToolStripButton;
        private System.Windows.Forms.ToolStripButton goRightToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem testsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goRightToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripButton runTestToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem runSelectedTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton refreshTestsToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton refreshPropertyPaneToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripSeparator toolStripButton4;
        private System.Windows.Forms.ToolStripButton expandAllToolStripButton;
        private System.Windows.Forms.ToolStripButton runTestOnAllChildrenToolStripButton;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutVisualUIAVerifyToolStripMenuItem;

        /// <summary>
        /// 
        /// </summary>
        public VisualUIAVerify.Controls.AutomationTestsControl _automationTests;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem filterKnownIssuesToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFilterFileDialog;
        private System.Windows.Forms.ToolStripMenuItem UnmanagedProxiesToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveLogFileDialog;
    }
}
