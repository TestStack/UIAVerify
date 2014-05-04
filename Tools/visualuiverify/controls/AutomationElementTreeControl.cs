//---------------------------------------------------------------------------
//
// <copyright file="AutomationElementTreeControl" company="Microsoft">
//    Copyright (C) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
//
// Description: User Control showing Automation-Elements in a tree
//
// History:  
//  08/29/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using Drawing = System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Diagnostics;
using VisualUIAVerify.Misc;
using VisualUIAVerify.Features;

namespace VisualUIAVerify.Controls
{
    /// <summary>
    /// This control shows Automation-Elements in a tree. Root element of a tree is set up with RootElement property.
    /// </summary>
    public partial class AutomationElementTreeControl : UserControl
    {
        //this property holds root element of a tree
        AutomationElement _rootElement;

        //this property is used to store which kind of TreeWalker should be used to populate the tree
        TreeWalker _treeWalker;

        //to store instance of FocusTracer
        FocusTracer _focusTracer;

        //to store instance of HoverMode class
        HoverMode _hoverMode;

        #region events

        /// <summary>
        /// this event raises when tree selected currentTestTypeRootNode changes
        /// </summary>
        public event SelectedNodeChangedEventDelegate SelectedNodeChanged;

        #endregion


        /// <summary>
        /// Initilizes new instance of control
        /// </summary>
        public AutomationElementTreeControl()
        {
            InitializeComponent();
        }

        #region initializing methods

        /// <summary>
        /// This method initiliazes all required classes and builds a tree from the root element.
        /// </summary>
        private void InitializeElementTree()
        {
            InitializeTreeWalker();
            //            InitializeTreeBuilder();

            _elementsTreeView.Nodes.Clear();

            if (this._rootElement != null)
            {
                TreeNode rootNode = TreeHelper.CreateNodeForAutomationElement(this._rootElement, this);
                _elementsTreeView.Nodes.Add(rootNode);

                //populate children for root element
                ((AutomationElementTreeNode)rootNode.Tag).EnsureChildrenNodesPopulated(true);
            }
        }

        /// <summary>
        /// this method will asign default tree walker if there is not asigned one
        /// </summary>
        private void InitializeTreeWalker()
        {
            // if _treeWalker hasn't been assigned then use default walker (which is ControlViewWalker)
            if (this._treeWalker == null)
            {
//                this._treeWalker = TreeWalker.ControlViewWalker;

                //I am going to ignore all elements of this application
                Condition condition1 = new PropertyCondition(AutomationElement.ProcessIdProperty, Process.GetCurrentProcess().Id);
                Condition condition2 = new AndCondition(new Condition[] { System.Windows.Automation.Automation.ControlViewCondition, new NotCondition(condition1) });
                this._treeWalker = new TreeWalker(condition2);
            }
        }

        #endregion
        
        #region public properties (TreeWalker, RootElement, RootNode, SelectedNode)

        /// <summary>
        /// This property is to get/set TreeWalker class to be used to populate the tree
        /// </summary>
        [System.ComponentModel.DefaultValue(null)]
        public TreeWalker TreeWalker
        {
            get
            {
                InitializeTreeWalker();
                return this._treeWalker; 
            }
            set
            {
                //TODO: cannot change treeWalker when populating children...

                if (value == null)
                    throw new ArgumentNullException();

                this._treeWalker = value;
            }
        }


        /// <summary>
        /// This property is used to get/set root element of a tree. By setting the root element,
        /// the tree will be automaticaly refreshed.
        /// </summary>
        [System.ComponentModel.DefaultValue(null)]
        public AutomationElement RootElement
        {
            get { return this._rootElement; }
            set
            {
                this._rootElement = value;

                InitializeElementTree();
//                _elementsTreeView.Nodes[0].Expand();
            }
        }
        
        /// <summary>
        /// Gets RootNode of the tree
        /// </summary>
        [System.ComponentModel.DefaultValue(null)] //we don't want designer to initilize property with null value
        [System.ComponentModel.Browsable(false)] //we don't need to show this property in PropertyWindow
        public AutomationElementTreeNode RootNode
        {
            get
            {
                TreeNode rootNode = null;

                if (this._elementsTreeView.Nodes.Count > 0)
                {
                    rootNode = this._elementsTreeView.Nodes[0];
                    return (AutomationElementTreeNode)rootNode.Tag;
                }

                return null;
            }
        }

        /// <summary>
        /// Get/Set currently selected currentTestTypeRootNode. If no currentTestTypeRootNode is selected then null is returned.
        /// </summary>
        [System.ComponentModel.DefaultValue(null)] //we don't want designer to initilize property with null value
        [System.ComponentModel.Browsable(false)] //we don't need to show this property in PropertyWindow
        public AutomationElementTreeNode SelectedNode
        {
            get
            {
                //if currentTestTypeRootNode is selected then return it
                if (this._elementsTreeView.SelectedNode != null)
                {
                    return (AutomationElementTreeNode)this._elementsTreeView.SelectedNode.Tag;
                }
                //else return null
                return null;
            }
            set
            {
                SetSelectedNodeTransparentColor();

                if (value == null)
                    this._elementsTreeView.SelectedNode = null;
                else //else set proper TreeNode
                {
                    CheckNodeIsValid(value);
                    this._elementsTreeView.SelectedNode = value.TreeNode;
                    SetSelectedNodeActiveColor();
                    OnSelectedNodeChanged();
                }
            }
        }

        #endregion

        
        #region public methods

        /// <summary>
        /// This method will refresh currentTestTypeRootNode...
        /// </summary>
        public void RefreshNode(AutomationElementTreeNode Node)
        {
            CheckNodeIsValid(Node);

            Node.RefreshChildrenNodes();
            PrepareNodeToExpand(Node);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public bool IsMember(AutomationElement element)
        {
            return (element == this.TreeWalker.Normalize(element));
        }

        /// <summary>
        /// This method causes that the currentTestTypeRootNode in param becomes a root of a tree.
        /// </summary>
        public void ScopeToNode(AutomationElementTreeNode node)
        {
            CheckNodeIsValid(node);

            this._elementsTreeView.Nodes.Clear();
            this._elementsTreeView.Nodes.Add(node.TreeNode);
            this._elementsTreeView.SelectedNode = node.TreeNode;
        }

        /// <summary>
        /// This method marks currentTestTypeRootNode in param as 'live' so it will listen to StructureChangedEvent and
        /// everytime the event fires the currentTestTypeRootNode will be refeshed.
        /// </summary>
        public void MarkElementLive(AutomationElementTreeNode node, bool live)
        {
            CheckNodeIsValid(node);

            node.Live = live;
        }

        /// <summary>
        /// this method will set focus to the automation element
        /// </summary>
        public static void SetFocusToElement(AutomationElement element)
        {
            if (element != null)
            {
                try
                {
                    element.SetFocus();
                }
                catch (Exception ex)
                {
                    ApplicationLogger.LogException(ex);
                }
            }
        }

        /// <summary>
        /// This method will snap mouse cursor to element's clickable point.
        /// </summary>
        public void SnapMouseToClickablePoint(AutomationElement element)
        {
            Point clickablePoint;

            if (element.TryGetClickablePoint(out clickablePoint))
            {
                this.Cursor = new Cursor(Cursor.Current.Handle);
                Cursor.Position = new System.Drawing.Point((int)clickablePoint.X, (int)clickablePoint.Y);
            }
        }

        /// <summary>
        /// this method starts listening to AutomationFocusChange event and highlights automationelement belonging to focused control
        /// in the tree.
        /// </summary>
        public void StartFocusTracing()
        {
            if (this._focusTracer == null)
                this._focusTracer = new FocusTracer(this);

            this._focusTracer.Start();
        }

        /// <summary>
        /// This method stops highlighting of focused control
        /// </summary>
        public void StopFocusTracing()
        {
            if (this._focusTracer == null)
                throw new InvalidOperationException("cannot call StopFocusTracing before StartFocusTracing");

            this._focusTracer.Stop();
        }

        /// <summary>
        /// this method starts hover mode.
        /// </summary>
        public void StartHoverMode()
        {
            if (this._hoverMode == null)
                this._hoverMode = new HoverMode(this);

            this._hoverMode.Start();
        }

        /// <summary>
        /// This method stops hover mode
        /// </summary>
        public void StopHoverMode()
        {
            if (this._hoverMode == null)
                throw new InvalidOperationException("cannot call StopHoverMode before StartHoverMode");

            this._hoverMode.Stop();
        }

        /// <summary>
        /// this method will build tree from the AutomationElementTreeControl.RootElement to focusedElement
        /// </summary>
        public AutomationElementTreeNode BuildTreeFromRootToElement(AutomationElement element)
        {
            //we will build path from focusedElement to its root element...

            //save the path on stack
            Stack<AutomationElement> pathToRoot = new Stack<AutomationElement>();

            while (element != null)
            {
                //check it is not circular relationship
                if (pathToRoot.Contains(element))
                    break;

                pathToRoot.Push(element);
                try
                {
                    element = _treeWalker.GetParent(element);
                }
                catch (Exception ex)
                {
                    Misc.ApplicationLogger.LogException(ex);
                }
            }

            //now we have to find RootElement in the pathToRoot...

            //cache the RootElement property
            AutomationElement rootElement = this.RootElement;

            while (pathToRoot.Count > 0)
            {
                //pick the top element and compare it to rootElement
                AutomationElement elementOnPath = pathToRoot.Pop();

                if (elementOnPath == rootElement)
                    break;

                //if they not equal to each other then continue in pathToRoot
            }

            // let's build nodes on path
            return BuildNodeTreePath(this.RootNode, pathToRoot);
        }

        /// <summary>
        /// this method will build currentTestTypeRootNode tree from rootNode to last item in path
        /// </summary>
        /// <returns>Returns last created AutomationElementTreeNode</returns>
        private AutomationElementTreeNode BuildNodeTreePath(AutomationElementTreeNode rootNode, Stack<AutomationElement> path)
        {
            // local variable to store current currentTestTypeRootNode
            AutomationElementTreeNode currentNode = rootNode;

            while (path.Count > 0 && currentNode != null)
            {
                AutomationElement elementOnPath = path.Pop();

                Debug.WriteLine("finding/inserting child currentTestTypeRootNode for automation element");
                currentNode = currentNode.FindOrInsertChildElement(elementOnPath);
                Debug.WriteLine("finding/inserting complete");
            }

            return currentNode;
        }


        #endregion

        #region public currentTestTypeRootNode navigation methods

        /// <summary>
        /// This method will select to parent AutomationElement from the currentTestTypeRootNode. If the parent element
        /// is not in a tree then this method will try to find the element and show him in a tree. 
        /// </summary>
        public void GoToParentFromNode(AutomationElementTreeNode node)
        {
            CheckNodeIsValid(node);

            TreeNode nodeToSelect = node.TreeNode.Parent;

            if (nodeToSelect == null)
            { //there is no parent to this currentTestTypeRootNode, we should try to find one
                AutomationElement parentElement = this._treeWalker.GetParent(node.AutomationElement);

                if (parentElement == null)
                    return;

                //we create tree currentTestTypeRootNode for the element
                TreeNode newRootNode = TreeHelper.CreateNodeForAutomationElement(parentElement, this);

                //take old root
                TreeNode currentRootNode = this._elementsTreeView.Nodes[0];

                //clear the tree
                this._elementsTreeView.Nodes.Clear();

                //insert it as a new root
                this._elementsTreeView.Nodes.Add(newRootNode);

                AutomationElementTreeNode newRootElementNode = (AutomationElementTreeNode)newRootNode.Tag;
                //insert old root to children collection of new root
                newRootElementNode.InsertChildNode(currentRootNode);

                nodeToSelect = newRootNode;
            }

            _elementsTreeView.SelectedNode = nodeToSelect;
            nodeToSelect.EnsureVisible();

            //expand new root which cause populating of all child elements
            nodeToSelect.Expand();
        }

        /// <summary>
        /// This method will select first child currentTestTypeRootNode from the parameter currentTestTypeRootNode in a tree. If there is no child currentTestTypeRootNode then
        /// nothing happens.
        /// </summary>
        public void GoToFirstChildFromNode(AutomationElementTreeNode node)
        {
            CheckNodeIsValid(node);

            if (node.Children.Count > 0)
            {
                TreeNode firstChildrenNode = node.Children[0].TreeNode;
                _elementsTreeView.SelectedNode = firstChildrenNode;
                firstChildrenNode.EnsureVisible();
            }
            //if there is no child currentTestTypeRootNode, then nothing
        }

        /// <summary>
        /// This method will select next sibling currentTestTypeRootNode from the parameter currentTestTypeRootNode in a tree. If there is no next sibling
        /// nothing happens.
        /// </summary>
        public void GoToNextSiblingFromNode(AutomationElementTreeNode node)
        {
            CheckNodeIsValid(node);

            TreeNode nextSiblingNode = node.TreeNode.NextNode;

            if (nextSiblingNode != null)
            {
                this._elementsTreeView.SelectedNode = nextSiblingNode;
                nextSiblingNode.EnsureVisible();
            }
        }

        /// <summary>
        /// This method will select previous sibling currentTestTypeRootNode from the parameter currentTestTypeRootNode in a tree. If there is no previous sibling
        /// nothing happens.
        /// </summary>
        public void GoToPreviousSiblingFromNode(AutomationElementTreeNode node)
        {
            CheckNodeIsValid(node);

            TreeNode prevSiblingNode = node.TreeNode.PrevNode;

            if (prevSiblingNode != null)
            {
                this._elementsTreeView.SelectedNode = prevSiblingNode;
                prevSiblingNode.EnsureVisible();
            }
        }

        /// <summary>
        /// This method will select last child currentTestTypeRootNode from the parameter currentTestTypeRootNode in a tree. If there is no child currentTestTypeRootNode then
        /// nothing happens.
        /// </summary>
        public void GoToLastChildFromNode(AutomationElementTreeNode node)
        {
            CheckNodeIsValid(node);

            if (node.Children.Count > 0)
            {
                TreeNode lastChildrenNode = node.Children[node.Children.Count - 1].TreeNode;
                _elementsTreeView.SelectedNode = lastChildrenNode;
                lastChildrenNode.EnsureVisible();
            }
            //if no child currentTestTypeRootNode then nothing happens
        }

        #endregion

        
        #region helper private methods
        /// <summary>
        /// This method is for validating that currentTestTypeRootNode in parametr is not null and belongs to this tree
        /// </summary>
        private void CheckNodeIsValid(AutomationElementTreeNode node)
        {
            if (node == null)
                throw new ArgumentNullException();

            //does it belong to this tree?
            if ((node.AutomationElementTreeControl != this) || (node.TreeNode.TreeView != this._elementsTreeView))
                throw new ArgumentException("This node does not belong to this tree control");
        }

        /// <summary>
        /// This method will make sure that for every child currentTestTypeRootNode of the currentTestTypeRootNode in parameter all children
        /// will be populated
        /// </summary>
        internal void PrepareNodeToExpand(AutomationElementTreeNode node)
        {
            foreach (AutomationElementTreeNode childNode in node.Children)
            {
                childNode.EnsureChildrenNodesPopulated(true);
            }
        }

        private void SetSelectedNodeActiveColor()
        {
            TreeNode selectedNode = _elementsTreeView.SelectedNode;
            if (selectedNode != null)
                selectedNode.BackColor = Drawing.SystemColors.GradientActiveCaption;
        }

        private void SetSelectedNodeTransparentColor()
        {
            TreeNode selectedNode = _elementsTreeView.SelectedNode;
            if (selectedNode != null)
                selectedNode.BackColor = Drawing.Color.Transparent;
        }


        #endregion

        #region protected methods (for rising events)

        /// <summary>
        /// this methid will raise SelectedNodeChanged event
        /// </summary>
        protected virtual void OnSelectedNodeChanged()
        {
            if (this.SelectedNodeChanged != null)
                this.SelectedNodeChanged(this, EventArgs.Empty);
        }

        #endregion

        #region events handlers

        private void _elementsTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //populate children child nodes
            PrepareNodeToExpand((AutomationElementTreeNode)e.Node.Tag);
        }


        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedNode != null)
            {
                this.RefreshNode(this.SelectedNode);
            }
        }

        private void goToParentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedNode != null)
            {
                GoToParentFromNode(this.SelectedNode);
            }
        }

        private void goToFirstChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedNode != null)
            {
                GoToFirstChildFromNode(this.SelectedNode);
            }
        }

        private void goToNextSiblingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedNode != null)
            {
                GoToNextSiblingFromNode(this.SelectedNode);
            }
        }

        private void goToPreviousSiblingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedNode != null)
            {
                GoToPreviousSiblingFromNode(this.SelectedNode);
            }
        }

        private void goToLastChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedNode != null)
            {
                GoToLastChildFromNode(this.SelectedNode);
            }
        }

        private void ScopeToElement_Click(object sender, EventArgs e)
        {
            if (this.SelectedNode != null)
            {
                ScopeToNode(this.SelectedNode);
            }
        }

        private void setControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedNode != null)
            {
                SetFocusToElement(this.SelectedNode.AutomationElement);
            }
        }

        private void snapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SelectedNode != null)
            {
                SnapMouseToClickablePoint(this.SelectedNode.AutomationElement);
            }
        }


        // whatever mouse button pressed, it will select the currentTestTypeRootNode
        private void _elementsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //we will select the currentTestTypeRootNode which was clicked
            this._elementsTreeView.SelectedNode = e.Node;
        }


        private void _elementsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OnSelectedNodeChanged();
            SetSelectedNodeActiveColor();
        }

        //private void _contextMenuStrip_Opening(object sender, CancelEventArgs e)
        //{
        //    AutomationElementTreeNode selectedNode = this.SelectedNode;
        //    if (selectedNode != null)
        //        markElementliveToolStripMenuItem.Checked = selectedNode.Live;
        //}

        private void _elementsTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            SetSelectedNodeTransparentColor();
        }

        #endregion
    }
}
