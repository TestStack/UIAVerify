//---------------------------------------------------------------------------
//
// <copyright file="LiveTreeNodes" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: this file contains LiveTreeNodes class which is responsible to refresh
//              AutomationElementTreeNode whenever Automation.StructureChanged event
//              for particulat automation element rises
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
    class LiveTreeNode
    {
        AutomationElementTreeNode _node;

        bool _isNodeLive;

        public LiveTreeNode(AutomationElementTreeNode node)
        {
            this._node = node;
        }

        public void Start()
        {
            if (!this._isNodeLive)
            {
                using (new WaitCursor())
                {
                    Automation.AddStructureChangedEventHandler(this._node.AutomationElement, TreeScope.Children, new StructureChangedEventHandler(OnStructureChanged));
                    this._isNodeLive = true;
                }
            }
        }

        public void Stop()
        {
            if (this._isNodeLive)
            {
                using (new WaitCursor())
                {
                    Automation.RemoveStructureChangedEventHandler(this._node.AutomationElement, new StructureChangedEventHandler(OnStructureChanged));
                    this._isNodeLive = false;
                }
            }
        }

        private void OnStructureChanged(object sender, StructureChangedEventArgs e)
        {
            Debug.WriteLine("\n\n----------------------------\nOnStructureChanged\n-----------------------------\n" +
            "e.StructureChangeType = " + Enum.GetName(typeof(StructureChangeType), e.StructureChangeType) + 
            "\ne.EventId.ProgrammaticName = " + e.EventId.ProgrammaticName +
            "\n\n");

            if (this._node.TreeNode.TreeView == null) //if tree currentTestTypeRootNode was removed then stop listening
                Stop();
            else
            {
                //we will refresh child nodes
                this._node.RefreshChildrenNodes();

                //and make sure that children children nodes are populated
                foreach (AutomationElementTreeNode childNode in this._node.Children)
                {
                    childNode.EnsureChildrenNodesPopulated(true);
                }
            }
        }
    }
}
