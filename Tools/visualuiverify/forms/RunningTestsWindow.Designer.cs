// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

namespace VisualUIAVerify.Forms
{
    partial class RunningTestsWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RunningTestsWindow));
            this.btnCancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.btnRunTests = new System.Windows.Forms.Button();
            this._testListView = new System.Windows.Forms.ListView();
            this.testNameHeader = new System.Windows.Forms.ColumnHeader();
            this.elementNameHeader = new System.Windows.Forms.ColumnHeader();
            this.testStatusHeader = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(516, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 32);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "testToRun.ico");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            // 
            // _progressBar
            // 
            this._progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._progressBar.Location = new System.Drawing.Point(12, 307);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(591, 23);
            this._progressBar.TabIndex = 2;
            // 
            // _backgroundWorker
            // 
            this._backgroundWorker.WorkerReportsProgress = true;
            this._backgroundWorker.WorkerSupportsCancellation = true;
            this._backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this._backgroundWorker_DoWork);
            this._backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._backgroundWorker_RunWorkerCompleted);
            this._backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._backgroundWorker_ProgressChanged);
            // 
            // btnRunTests
            // 
            this.btnRunTests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunTests.Location = new System.Drawing.Point(203, 340);
            this.btnRunTests.Name = "btnRunTests";
            this.btnRunTests.Size = new System.Drawing.Size(208, 32);
            this.btnRunTests.TabIndex = 3;
            this.btnRunTests.Text = "RunTests";
            this.btnRunTests.UseVisualStyleBackColor = true;
            this.btnRunTests.Visible = false;
            this.btnRunTests.Click += new System.EventHandler(this.btnRunTests_Click);
            // 
            // _testListView
            // 
            this._testListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._testListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.testNameHeader,
            this.elementNameHeader,
            this.testStatusHeader});
            this._testListView.GridLines = true;
            this._testListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._testListView.Location = new System.Drawing.Point(12, 12);
            this._testListView.MultiSelect = false;
            this._testListView.Name = "_testListView";
            this._testListView.Size = new System.Drawing.Size(591, 281);
            this._testListView.SmallImageList = this.imageList1;
            this._testListView.TabIndex = 4;
            this._testListView.UseCompatibleStateImageBehavior = false;
            this._testListView.View = System.Windows.Forms.View.Details;
            // 
            // testNameHeader
            // 
            this.testNameHeader.Text = "Test Name";
            this.testNameHeader.Width = 300;
            // 
            // elementNameHeader
            // 
            this.elementNameHeader.Text = "ElementName";
            this.elementNameHeader.Width = 200;
            // 
            // testStatusHeader
            // 
            this.testStatusHeader.Text = "Status";
            this.testStatusHeader.Width = 85;
            // 
            // RunningTestsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(615, 378);
            this.Controls.Add(this._testListView);
            this.Controls.Add(this.btnRunTests);
            this.Controls.Add(this._progressBar);
            this.Controls.Add(this.btnCancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RunningTestsWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tests to run";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RunningTestsWindow_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ProgressBar _progressBar;
        private System.ComponentModel.BackgroundWorker _backgroundWorker;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnRunTests;
        private System.Windows.Forms.ListView _testListView;
        private System.Windows.Forms.ColumnHeader testNameHeader;
        private System.Windows.Forms.ColumnHeader elementNameHeader;
        private System.Windows.Forms.ColumnHeader testStatusHeader;
    }
}