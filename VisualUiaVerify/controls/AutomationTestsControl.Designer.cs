// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

namespace VisualUIAVerify.Controls
{
    partial class AutomationTestsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._testsTreeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _testsTreeView
            // 
            this._testsTreeView.ContextMenuStrip = this.contextMenuStrip1;
            this._testsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._testsTreeView.Location = new System.Drawing.Point(0, 0);
            this._testsTreeView.Name = "_testsTreeView";
            this._testsTreeView.Size = new System.Drawing.Size(226, 230);
            this._testsTreeView.TabIndex = 1;
            this._testsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._testsTreeView_AfterSelect);
            this._testsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._testsTreeView_NodeMouseClick);
            this._testsTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this._testsTreeView_BeforeSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(254, 70);
            // 
            // runTestToolStripMenuItem
            // 
            this.runTestToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.testToRun1;
            this.runTestToolStripMenuItem.Name = "runTestToolStripMenuItem";
            this.runTestToolStripMenuItem.Size = new System.Drawing.Size(253, 22);
            this.runTestToolStripMenuItem.Text = "Run Test(s) on Selected Element";
            this.runTestToolStripMenuItem.Click += new System.EventHandler(this.runTestToolStripMenuItem_Click);
            // 
            // AutomationTestsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._testsTreeView);
            this.Name = "AutomationTestsControl";
            this.Size = new System.Drawing.Size(226, 230);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView _testsTreeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runTestToolStripMenuItem;
    }
}
