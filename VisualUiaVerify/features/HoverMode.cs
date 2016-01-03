//---------------------------------------------------------------------------
//
// <copyright file="HoverMode" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: contains class implementing hover mode
//
// History:  
//  09/06/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Drawing = System.Drawing;
using System.Windows;
using System.Windows.Automation;
using System.Diagnostics;
using VisualUIAVerify.Controls;
using VisualUIAVerify.Utils;
using VisualUIAVerify.Misc;


namespace VisualUIAVerify.Features
{
    /// <summary>
    /// Implements Hover Mode functionality
    /// </summary>
    class HoverMode
    {
        private AutomationElementTreeControl _treeControl;
        private Timer _timerHovering;

        private bool _hovering;

        /// <summary>
        /// initialize with tree control
        /// </summary>
        public HoverMode(AutomationElementTreeControl TreeControl)
        {
            this._treeControl = TreeControl;
        }

        /// <summary>
        /// start hovering mode
        /// </summary>
        public void Start()
        {
            if (!_hovering)
            {
                _timerHovering = new Timer();
                _timerHovering.Tick += new EventHandler(_timerHovering_Tick);
                _timerHovering.Interval = 500;
                _timerHovering.Start();

                _hovering = true;
            }
        }

        /// <summary>
        /// stop hovering mode
        /// </summary>
        public void Stop()
        {
            if (_hovering)
            {
                _timerHovering.Stop();
                _timerHovering.Tick -= new EventHandler(_timerHovering_Tick);
                _timerHovering.Dispose();
                _timerHovering = null;

                _hovering = false;
            }
        }

        void _timerHovering_Tick(object sender, EventArgs e)
        {
            OnHovering();
        }

        private void OnHovering()
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                using (new WaitCursor())
                {
                    AutomationElement element = null;
                    try
                    {
                        element = AutomationElement.FromPoint(new Point((double)Cursor.Position.X, (double)Cursor.Position.Y));
                    }
                    catch (Exception ex)
                    {
                        ApplicationLogger.LogException(ex);
                    }

                    if (element != null)
                    {
                        if(this._treeControl.IsMember(element))
                            SelectNode(this._treeControl.BuildTreeFromRootToElement(element));
                    }
                }
            }
        }

        private void SelectNode(AutomationElementTreeNode node)
        {
            if (node != null)
            {
                //there can be problem that the element does not longer exists 
                try
                {
                    this._treeControl.SelectedNode = node;
                    node.TreeNode.EnsureVisible();
                }
                catch (Exception) { }
            }
        }
    }
}
