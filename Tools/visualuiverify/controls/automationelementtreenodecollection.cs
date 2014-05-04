//---------------------------------------------------------------------------
//
// <copyright file="AutomationElementTreeNodeCollection" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Adapter collection class for AutomationElementTreeNode children nodes
//
// History:  
//  08/29/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace VisualUIAVerify.Controls
{
    /// <summary>
    /// This collection class is used to enumerate through children nodes
    /// </summary>
    public class AutomationElementTreeNodeCollection : IEnumerable<AutomationElementTreeNode>
    {
        AutomationElementTreeNode _parentNode;

        internal AutomationElementTreeNodeCollection(AutomationElementTreeNode parentNode)
        {
            this._parentNode = parentNode;
        }

        /// <summary>
        /// returns number of nodes in children collection
        /// </summary>
        public int Count
        {
            get { return _parentNode.TreeNode.Nodes.Count; }
        }

        /// <summary>
        /// Will return AutomationElementTreeNode on certain index in this collection
        /// </summary>
        public AutomationElementTreeNode this[int index]
        {
            get
            {
                return (AutomationElementTreeNode)this._parentNode.TreeNode.Nodes[index].Tag;
            }
        }

        #region IEnumerable<AutomationElementTreeNode> Members

        /// <summary>
        /// Implementacion of IEnumerator interface for children collection
        /// </summary>
        class AutomationElementTreeNodeCollectionEnumerator : IEnumerator<AutomationElementTreeNode>
        {
            System.Collections.IEnumerator _treeViewNodesEnumerator;

            public AutomationElementTreeNodeCollectionEnumerator(System.Collections.IEnumerator treeViewNodesEnumerator)
            {
                this._treeViewNodesEnumerator = treeViewNodesEnumerator;
            }

            #region IEnumerator<AutomationElementTreeNode> Members

            public AutomationElementTreeNode Current
            {
                get { return (AutomationElementTreeNode)((System.Windows.Forms.TreeNode)this._treeViewNodesEnumerator.Current).Tag; }
            }

            #endregion

            #region IDisposable Members

            public void Dispose()
            {
            }

            #endregion

            #region IEnumerator Members

            object System.Collections.IEnumerator.Current
            {
                get { return (AutomationElementTreeNode)((System.Windows.Forms.TreeNode)this._treeViewNodesEnumerator.Current).Tag; }
            }

            public bool MoveNext()
            {
                return this._treeViewNodesEnumerator.MoveNext();
            }

            public void Reset()
            {
                this._treeViewNodesEnumerator.Reset();
            }

            #endregion
        }

        /// <summary>
        /// Returns enumerator for AutomationElementTreeNodeCollection
        /// </summary>
        public IEnumerator<AutomationElementTreeNode> GetEnumerator()
        {
            return new AutomationElementTreeNodeCollectionEnumerator(this._parentNode.TreeNode.Nodes.GetEnumerator());
        }

        #endregion


        #region IEnumerable Members

        /// <summary>
        /// Returns enumerator for AutomationElementTreeNodeCollection
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return new AutomationElementTreeNodeCollectionEnumerator(this._parentNode.TreeNode.Nodes.GetEnumerator());
        }

        #endregion
    }
}