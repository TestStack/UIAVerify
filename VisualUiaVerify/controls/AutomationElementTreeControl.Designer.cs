// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

namespace VisualUIAVerify.Controls
{
    partial class AutomationElementTreeControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutomationElementTreeControl));
            this._elementsTreeView = new System.Windows.Forms.TreeView();
            this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.navigateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToParentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToFirstChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToNextSiblingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToPreviousSiblingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToLastChildrenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._elementsImageList = new System.Windows.Forms.ImageList(this.components);
            this._contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _elementsTreeView
            // 
            this._elementsTreeView.ContextMenuStrip = this._contextMenuStrip;
            this._elementsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._elementsTreeView.ImageIndex = 0;
            this._elementsTreeView.ImageList = this._elementsImageList;
            this._elementsTreeView.Location = new System.Drawing.Point(0, 0);
            this._elementsTreeView.Name = "_elementsTreeView";
            this._elementsTreeView.SelectedImageIndex = 0;
            this._elementsTreeView.Size = new System.Drawing.Size(282, 411);
            this._elementsTreeView.TabIndex = 0;
            this._elementsTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this._elementsTreeView_BeforeExpand);
            this._elementsTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._elementsTreeView_AfterSelect);
            this._elementsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this._elementsTreeView_NodeMouseClick);
            this._elementsTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this._elementsTreeView_BeforeSelect);
            // 
            // _contextMenuStrip
            // 
            this._contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.navigateToolStripMenuItem,
            this.snapToolStripMenuItem});
            this._contextMenuStrip.Name = "contextMenuStrip1";
            this._contextMenuStrip.Size = new System.Drawing.Size(233, 136);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.elemtyperefresh;
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // navigateToolStripMenuItem
            // 
            this.navigateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToParentToolStripMenuItem,
            this.goToFirstChildrenToolStripMenuItem,
            this.goToNextSiblingToolStripMenuItem,
            this.goToPreviousSiblingToolStripMenuItem,
            this.goToLastChildrenToolStripMenuItem});
            this.navigateToolStripMenuItem.Name = "navigateToolStripMenuItem";
            this.navigateToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.navigateToolStripMenuItem.Text = "Navigate";
            // 
            // goToParentToolStripMenuItem
            // 
            this.goToParentToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotoparent;
            this.goToParentToolStripMenuItem.Name = "goToParentToolStripMenuItem";
            this.goToParentToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.goToParentToolStripMenuItem.Text = "Go to Parent";
            this.goToParentToolStripMenuItem.Click += new System.EventHandler(this.goToParentToolStripMenuItem_Click);
            // 
            // goToFirstChildrenToolStripMenuItem
            // 
            this.goToFirstChildrenToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotofirstchild;
            this.goToFirstChildrenToolStripMenuItem.Name = "goToFirstChildrenToolStripMenuItem";
            this.goToFirstChildrenToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.goToFirstChildrenToolStripMenuItem.Text = "Go to First Child";
            this.goToFirstChildrenToolStripMenuItem.Click += new System.EventHandler(this.goToFirstChildrenToolStripMenuItem_Click);
            // 
            // goToNextSiblingToolStripMenuItem
            // 
            this.goToNextSiblingToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotonextsibling;
            this.goToNextSiblingToolStripMenuItem.Name = "goToNextSiblingToolStripMenuItem";
            this.goToNextSiblingToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.goToNextSiblingToolStripMenuItem.Text = "Go to Next Sibling";
            this.goToNextSiblingToolStripMenuItem.Click += new System.EventHandler(this.goToNextSiblingToolStripMenuItem_Click);
            // 
            // goToPreviousSiblingToolStripMenuItem
            // 
            this.goToPreviousSiblingToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotoprevsibling;
            this.goToPreviousSiblingToolStripMenuItem.Name = "goToPreviousSiblingToolStripMenuItem";
            this.goToPreviousSiblingToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.goToPreviousSiblingToolStripMenuItem.Text = "Go to Previous Sibling";
            this.goToPreviousSiblingToolStripMenuItem.Click += new System.EventHandler(this.goToPreviousSiblingToolStripMenuItem_Click);
            // 
            // goToLastChildrenToolStripMenuItem
            // 
            this.goToLastChildrenToolStripMenuItem.Image = global::VisualUIAVerify.VisualUIAVerifyResources.gotolastchild;
            this.goToLastChildrenToolStripMenuItem.Name = "goToLastChildrenToolStripMenuItem";
            this.goToLastChildrenToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.goToLastChildrenToolStripMenuItem.Text = "Go to Last Child";
            this.goToLastChildrenToolStripMenuItem.Click += new System.EventHandler(this.goToLastChildrenToolStripMenuItem_Click);
            // 
            // setControlToolStripMenuItem
            // 
            this.setControlToolStripMenuItem.Name = "setControlToolStripMenuItem";
            this.setControlToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.setControlToolStripMenuItem.Text = "Set Focus";
            this.setControlToolStripMenuItem.Click += new System.EventHandler(this.setControlToolStripMenuItem_Click);
            // 
            // snapToolStripMenuItem
            // 
            this.snapToolStripMenuItem.Name = "snapToolStripMenuItem";
            this.snapToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.snapToolStripMenuItem.Text = "Snap mouse to ClickablePoint";
            this.snapToolStripMenuItem.Click += new System.EventHandler(this.snapToolStripMenuItem_Click);
            // 
            // _elementsImageList
            // 
            this._elementsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_elementsImageList.ImageStream")));
            this._elementsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this._elementsImageList.Images.SetKeyName(0, "elemtyperefresh.ico");
            this._elementsImageList.Images.SetKeyName(1, "elemTypeGeneral.ico");
            this._elementsImageList.Images.SetKeyName(2, "elemtypeerror.ico");
            this._elementsImageList.Images.SetKeyName(3, "elemTypeGeneralLive.ico");
            // 
            // AutomationElementTreeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._elementsTreeView);
            this.Name = "AutomationElementTreeControl";
            this.Size = new System.Drawing.Size(282, 411);
            this._contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView _elementsTreeView;
        private System.Windows.Forms.ImageList _elementsImageList;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem navigateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToParentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToFirstChildrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToNextSiblingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToPreviousSiblingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goToLastChildrenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem snapToolStripMenuItem;
    }
}
