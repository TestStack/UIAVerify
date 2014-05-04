//---------------------------------------------------------------------------
//
// <copyright file="AutomationElementTreeNode" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Class representing currentTestTypeRootNode in AutomationElementsTreeControl
//
// History:  
//  08/29/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Diagnostics;
using System.Threading;
using VisualUIAVerify.Features;

namespace VisualUIAVerify.Controls
{
    /// <summary>
    /// Represents currentTestTypeRootNode in AutomationElementsTreeControl
    /// </summary>
    public class AutomationElementTreeNode
    {
        enum ChildrenElementsStatus
        {
            NotPopulated, //childern nodes haven't been populated yet
            Populated //children nodes have been populated
        }

        /// <summary>
        /// Which AutomationElement does this currentTestTypeRootNode belong to
        /// </summary>
        public readonly AutomationElement AutomationElement;

        /// <summary>
        /// Which AutomationElementTreeControl does this currentTestTypeRootNode belong to
        /// </summary>
        public readonly AutomationElementTreeControl AutomationElementTreeControl;

        /// <summary>
        /// Which TreeNode of TreeView belong to this currentTestTypeRootNode
        /// </summary>
        internal readonly TreeNode TreeNode;

        //to remember status of children nodes
        private ChildrenElementsStatus _childrenStatus = ChildrenElementsStatus.NotPopulated;

        //to indicate that some child nodes were inserted to children collection before children population
        private bool _newChildElementInserted;

        //instance of feature class providing 'live' functionality
        private LiveTreeNode _liveNode;

        //set of flags:
        bool _errorInPopulatingChildren;
        bool _isNodeLive;

        internal AutomationElementTreeNode(AutomationElement element, TreeNode node, AutomationElementTreeControl automationElementTreeControl)
        {
            Debug.Assert(element != null);
            this.AutomationElement = element;

            this.TreeNode = node;
            this.AutomationElementTreeControl = automationElementTreeControl;
        }

        /// <summary>
        /// get/set currentTestTypeRootNode live. This makes the currentTestTypeRootNode still fresh.
        /// </summary>
        public bool Live
        {
            get
            {
                using(SynchronizationManager.Lock())
                {
                    return this._isNodeLive; 
                }
            }
            set
            {
                using (SynchronizationManager.Lock())
                {
                    //if (this._liveNode == null && value == false) then do nothing else set new value:
                    if (this._liveNode != null || value != false)
                    {
                        if (this._liveNode == null)
                            this._liveNode = new LiveTreeNode(this);

                        if (value)
                            this._liveNode.Start();
                        else
                            this._liveNode.Stop();
                    }
                    this._isNodeLive = value;
                    SetTreeNodeImageIndex();
                }
            }
        }

        /// <summary>
        /// Collection of children nodes. Iterating children collection is never thread safe 
        /// operation. Other thread can modify the collection. To make iteration thread-safe
        /// use lock on this instance.
        /// </summary>
        public AutomationElementTreeNodeCollection Children
        {
            get
            {
                //make sure that children nodes has been populated
                EnsureChildrenNodesPopulated();
                return new AutomationElementTreeNodeCollection(this);
            }
        }

        /// <summary>
        /// This methid Ensures that children nodes of this nodes are populated
        /// </summary>
        public void EnsureChildrenNodesPopulated() { EnsureChildrenNodesPopulated(false); }

        /// <summary>
        /// This methid Ensures that children nodes of this nodes are populated
        /// </summary>
        /// <param name="Asynchronous">If true then creating of children will be performed on another thread.</param>
        public void EnsureChildrenNodesPopulated(bool Asynchronous)
        {
            //if Asynchronous = true then we should call this method on anothe thread once again with Asynchronous = false
            if (Asynchronous)
            {
                //wee will ensure children 
                new MethodInvoker(EnsureChildrenNodesPopulated).BeginInvoke(null, null);
            }
            else
            {
                using (this.SynchronizationManager.Lock())
                {
                        //if children has not been populated then create them
                        if (this._childrenStatus == ChildrenElementsStatus.NotPopulated)
                            CreateChildrenNodes(false);
                }
            }
        }

        /// <summary>
        /// This method will refresh children nodes
        /// </summary>
        public void RefreshChildrenNodes()
        {
            using (SynchronizationManager.Lock())
            {
                if (this._childrenStatus != ChildrenElementsStatus.NotPopulated)
                {
                    this._childrenStatus = ChildrenElementsStatus.NotPopulated;
                    SetTreeNodeImageIndex();

                    CreateChildrenNodes(true);
                }
            }
        }


/*        /// <summary>
        /// this method will clear child nodes and set state to children not populated
        /// </summary>
        private void ClearChildNodes()
        {
            //this call this this.TreeView.Nodes.Clear() on the right thread
            AddChildrenNodesToTreeNode(new TreeNode[] { }, true);

            this._childrenStatus = ChildrenElementsStatus.NotPopulated;
            this._newChildElementInserted = false;
        }*/

        /// <summary>
        /// this method will find AutomatinElementTreeNode for automationElement in children collection
        /// </summary>
        public AutomationElementTreeNode FindChildNodeForAutomationElement(AutomationElement automationElement)
        {
            using (SynchronizationManager.Lock())
            {
                //if children has been polupated then find the element 
                if (this._childrenStatus == ChildrenElementsStatus.Populated)
                {
                    return FindChildNodeForAutomationElementInternal(automationElement);
                }
                //if not then return null
                return null;
            }
        }

        internal AutomationElementTreeNode FindChildNodeForAutomationElementInternal(AutomationElement element)
        {
            //go thru the childern collection and compare them
            foreach (AutomationElementTreeNode childNode in new AutomationElementTreeNodeCollection(this))
            {
                if (childNode.AutomationElement == element)
                    return childNode; //yes! we found it
            }

            //currentTestTypeRootNode was not founded
            return null;
        }

        /// <summary>
        /// This method will insert currentTestTypeRootNode for automationElement between child nodes of this currentTestTypeRootNode. If there is existing
        /// currentTestTypeRootNode for the automationElement in children collection then return existing currentTestTypeRootNode.
        /// </summary>
        /// <returns>Returns AutomationElementTreeNode for inserted automationElement.</returns>
        internal AutomationElementTreeNode FindOrInsertChildElement(AutomationElement automationElement)
        {
            Debug.WriteLine("InsertChildElement ENTER");

            // this variable will hold the currentTestTypeRootNode for inserted automationElement
            AutomationElementTreeNode node = null;

            // if there is some currentTestTypeRootNode inserted before then try to find if it is not currentTestTypeRootNode for this automationElement
            if (this._newChildElementInserted || this._childrenStatus == ChildrenElementsStatus.Populated)
            {
                Debug.WriteLine("finding currentTestTypeRootNode for the element");
                try
                {
                    node = FindChildNodeForAutomationElementInternal(automationElement);
                }
                catch { /* it does not matter */ }
            }

            //if we didn't find child currentTestTypeRootNode for automationElement then create it
            if (node == null)
            {
                Debug.WriteLine("creating new currentTestTypeRootNode for the element");

                TreeNode newNode = CreateTreeNodeForAutomationElement(automationElement);

                this._newChildElementInserted = true;

                //add this new children to collection; we can call clear when there is no element inserted before

                //because this method does not have to be synchronized, we call AddChildrenNodesToTree directly
                //without using SyncManager
                if(this.AutomationElementTreeControl.InvokeRequired)
                {
                    this.AutomationElementTreeControl.Invoke(
                        new AddChildrenNodesToTreeNodeDelegate(AddChildrenNodesToTreeNodeInternal),
                        new TreeNode[] { newNode }, false, true);
                }
                else
                {
                    AddChildrenNodesToTreeNodeInternal(new TreeNode[] { newNode }, false, true);
                }

//                AddChildrenNodesToTreeNode(new TreeNode[] { newNode }, false, true);
                
                node = (AutomationElementTreeNode)newNode.Tag;
            }

            Debug.WriteLine("InsertChildElement EXIT");
            return node;
        }

        /// <summary>
        /// This method will insert currentTestTypeRootNode between child nodes of this currentTestTypeRootNode
        /// </summary>
        internal void InsertChildNode(TreeNode childNode)
        {
            Debug.Assert(childNode.TreeView == null, "childNode.TreeView must be null otherwise it will not be added to children collection");
            //we need to safe
            using (SynchronizationManager.Lock())
            {
                //add this new children to collection
                AddChildrenNodesToTreeNode(new TreeNode[] { childNode }, false, true);

                this._newChildElementInserted = true;
            }
        }


        /// <summary>
        /// This is only a helper function to create TreeNode to AutomationElement.
        /// </summary>
        private TreeNode CreateTreeNodeForAutomationElement(AutomationElement element)
        {
            return TreeHelper.CreateNodeForAutomationElement(element, this.AutomationElementTreeControl);
        }

        /// <summary>
        /// This method creates children nodes.
        /// </summary>
        private void CreateChildrenNodes(bool beAwareOfExisting)
        {
            //join flags together
            beAwareOfExisting |= this._newChildElementInserted;

            System.Diagnostics.Debug.WriteLine("CreateChildrenNodes ENTER");
            AutomationElement element = null;
            //set waiting cursor for this block
            using (new Misc.WaitCursor())
            {
                //here we store all new child nodes
                LinkedList<TreeNode> childNodes = new LinkedList<TreeNode>();

                // Do FirstChild
                System.Diagnostics.Debug.WriteLine("CreateChildrenNodes, Getting firstChild");
                try
                {
                    element = AutomationElementTreeControl.TreeWalker.GetFirstChild(this.AutomationElement);
                    Trace.WriteLine("GetChildren(start)" + "".PadRight(80, '-'));
                    while (null != element)
                    {
                        childNodes.AddLast(CreateTreeNodeForAutomationElement(element));

                        // Do NextSibling
                        element = AutomationElementTreeControl.TreeWalker.GetNextSibling(element);
                    }
                    this._errorInPopulatingChildren = false;
                    Trace.WriteLine("GetChildren(end)" + "".PadRight(80, '-'));
                }
                catch (ElementNotAvailableException)
                {
                    this._errorInPopulatingChildren = true;
                    Debug.WriteLine("\n\nGetting children automation elements FAILED. Element not available.\n\n");
                }
                catch (ThreadAbortException)
                {
                    this._errorInPopulatingChildren = true;
                    Debug.WriteLine("\n\nGetting children automation elements FAILED\n\n");
                }
                catch (Exception ex)
                {
                    Debug.Fail(ex.Message, ex.StackTrace);
                    throw;
                }

                //add new children to collection; we can call clear when there is no element inserted before 
                AddChildrenNodesToTreeNode(childNodes, !beAwareOfExisting, false);

                this._childrenStatus = ChildrenElementsStatus.Populated;
                this._newChildElementInserted = false; //we merged new children and child nodes inserted before

                //set image to this currentTestTypeRootNode
                SetTreeNodeImageIndex();
            }
            System.Diagnostics.Debug.WriteLine("CreateChildrenNodes EXIT");
        }

        //this delegate is used only for cross-thread marshaling
        private delegate void AddChildrenNodesToTreeNodeDelegate(ICollection<TreeNode> childrenNodes, bool clearChildrenCollection, bool onlyInsertNew);

        //this method is thread-safe
        private void AddChildrenNodesToTreeNode(ICollection<TreeNode> childrenNodes, bool clearChildrenCollection, bool onlyInsertNew)
        {
            SynchronizationManager.RunOnUIThread(new AddChildrenNodesToTreeNodeDelegate(AddChildrenNodesToTreeNodeInternal), childrenNodes, clearChildrenCollection, onlyInsertNew);
        }

        
        /// <summary>
        /// This method adds child nodes to this.TreeNode. This can run only on UIThread!
        /// </summary>
        private void AddChildrenNodesToTreeNodeInternal(ICollection<TreeNode> childrenNodes, bool clearChildrenCollection, bool onlyInsertNew)
        {
            Debug.Assert(!this.AutomationElementTreeControl.InvokeRequired, "this method can run only on IUThread!");

            //this is used to mark which node is new (and will be inserted) and
            //which is obsolete(and will be removed)
            bool[] newNodeFlags = new bool[childrenNodes.Count]; //true means new
            bool[] obsoleteNodesFlags = new bool[this.TreeNode.Nodes.Count]; //true means obsolete

            //lets mark all new children nodes new
            for (int k = 0; k < newNodeFlags.Length; k++)
                newNodeFlags[k] = true;

            //lets mark all old children nodes obsolete
            for (int k = 0; k < obsoleteNodesFlags.Length; k++)
                obsoleteNodesFlags[k] = true;

            //if we are not going to clear the collection and we have some old and some new nodes
            if (!clearChildrenCollection && childrenNodes.Count > 0 && this.TreeNode.Nodes.Count > 0)
            {
                //lets compare old nodes with new nodes and set flags which nodes should be inserted and which 
                //should be removed
                int i = 0;
                foreach (TreeNode newNode in childrenNodes)
                {
                    AutomationElement newElement = TreeHelper.GetNodeElement(newNode);

                    for (int j = 0; j < this.TreeNode.Nodes.Count; j++)
                    {
                        TreeNode oldNode = this.TreeNode.Nodes[j];
                        AutomationElement oldElement = TreeHelper.GetNodeElement(oldNode);

                        if (newElement == oldElement)
                        {
                            newNodeFlags[i] = false;
                            obsoleteNodesFlags[j] = false;
                        }
                    }
                    i++;
                }
            }

            if (!onlyInsertNew)
            {
                //lets remove all obsolete nodes
                for (int i = 0, j = 0; i < obsoleteNodesFlags.Length; i++, j++)
                {
                    //i is used to iterate thru flags array
                    //j is used to iterate thru nodes collection

                    if (obsoleteNodesFlags[i] || clearChildrenCollection)
                    {
                        //this will decrement index of all nodes after j-node
                        this.TreeNode.Nodes[j].Remove();
                        j--;
                    }
                }
            }

            //lets go and insert new nodes
            int l = 0;
            foreach (TreeNode newNode in childrenNodes)
            {
                if (newNodeFlags[l])
                {
                    this.TreeNode.Nodes.Insert(Math.Max(0, Math.Min(l, this.TreeNode.Nodes.Count - 1)), newNode);
                }
                l++;
            }
        }

        #region setting TreeNode ImageIndex

        /// <summary>
        /// used to categorizing AutomationElementTreeNodes for icons
        /// </summary>
        enum ImageIndexes
        {
            NodeBeeingRefreshed = 0, //element is now refreshing
            GeneralNode = 1,         //general element, no special type
            GeneralError = 2,        //used for signalizing error (ex. when children populating caused exception)
            NodeIsLive = 3           //currentTestTypeRootNode is live
        }

        /// <summary>
        /// this method sets image index for this currentTestTypeRootNode
        /// </summary>
        private void SetTreeNodeImageIndex()
        {
            if (this.AutomationElementTreeControl.InvokeRequired)
            {
                this.AutomationElementTreeControl.BeginInvoke(new MethodInvoker(SetTreeNodeImageIndex));
            }
            else
            {
                ImageIndexes imageIndex = ImageIndexes.GeneralNode;

                if (this._isNodeLive)
                    imageIndex = ImageIndexes.NodeIsLive;

                if (this._childrenStatus == ChildrenElementsStatus.NotPopulated)
                    imageIndex = ImageIndexes.NodeBeeingRefreshed;

                if (this._errorInPopulatingChildren)
                    imageIndex = ImageIndexes.GeneralError;

                this.TreeNode.ImageIndex = this.TreeNode.SelectedImageIndex = (int)imageIndex;
            }
        }

        #endregion

        #region synchronization manager

        /* this region contains reference and implementation of Synchronization manager
         * this Manager is used to synchronize threads working with this instance and to avoid 
         * deadlocks when UI-Thread calls methods on this instance */

        // to hold sync manager instance
        AutomationElementTreeNodeSynchornizationManager _synchronizationManager;

        AutomationElementTreeNodeSynchornizationManager SynchronizationManager
        {
            get
            {
                if (this._synchronizationManager == null)
                    this._synchronizationManager = new AutomationElementTreeNodeSynchornizationManager(this);

                return this._synchronizationManager;
            }
        }

        /// <summary>
        /// this class takes case of synchronization issues on AutomationElementTreeNode
        /// </summary>
        class AutomationElementTreeNodeSynchornizationManager
        {
            // which currentTestTypeRootNode does this manager belongs to
            AutomationElementTreeNode _ownerNode;

            public AutomationElementTreeNodeSynchornizationManager(AutomationElementTreeNode OwnerNode)
            {
                this._ownerNode = OwnerNode;
            }

            /// <summary>
            /// this method returns true if this call is made on currentTestTypeRootNode UI-Thread. Else return false.
            /// </summary>
            protected bool IsThisCallOnUIThread()
            {
                return !this._ownerNode.AutomationElementTreeControl.InvokeRequired;
            }

            protected void BeginInvokeOnUIThread(Delegate Method)
            {
                Debug.WriteLine("BeginInvokeOnUIThread");
                this._ownerNode.AutomationElementTreeControl.BeginInvoke(Method);
            }

            /* this manager uses three locks. First two locks are used to avoid deadlock when UI-thread is calling method
             * on currentTestTypeRootNode and the same currentTestTypeRootNode is waiting for UI-thread to complete some operation (like adding child nodes to
             * TreeNode.Child collection.
             * The third lock is used to synchronize calls on the same AutomationElementTreeNode instance. */
            private object lock1 = new object();
            private object lock2 = new object();
            private object workLock = new object();

            // to remember if lock1 is locked
            private volatile bool lock1Locked;

            // to hold UI-Thread waiting operation
            private WaitingOperation _uiThreadWaitingOperation;

            /// <summary>
            /// This method is used to synchronize calls on AutomationElementTreeNode instance.
            /// </summary>
            public IDisposable Lock()
            {
                Debug.WriteLine("SyncManager.Lock, locking lock1");
                Monitor.Enter(lock1);

                //if this call is made on UIThread then try to complete UIThread waiting operation
                if (IsThisCallOnUIThread())
                {
                    Debug.WriteLine("SyncManager.Lock, waiting for lock2");

                    lock (lock2) //this lock is used to wait until waiting operation is created
                    {
                        Debug.WriteLine("SyncManager.Lock, got lock2!");
                        if (this._uiThreadWaitingOperation != null)
                        {
                            Debug.WriteLine("\nSyncManager.Lock, WOW, going to do waiting job!\n");

                            this._uiThreadWaitingOperation.DoOperation();
                            this._uiThreadWaitingOperation = null;
                        }
                    }
                }

                Debug.WriteLine("SyncManager.Lock, locking workLock");
                Monitor.Enter(workLock);
                lock1Locked = true;

                return new LockDisposer(this);
            }

            /// <summary>
            /// this method is called when something is neede to perform on UI-Thread. This method must be called
            /// only within the Lock method
            /// </summary>
            /// <param name="Method">Which method should be performed on UIThread.</param>
            /// <param name="Arguments">arguments for the Mmethod.</param>
            public void RunOnUIThread(Delegate Method, params object[] Arguments)
            {
                Debug.WriteLine("RunOnUIThread, locking lock2");
                Monitor.Enter(this.lock2);

                Debug.WriteLine("RunOnUIThread, releasing lock1");
                Monitor.Exit(this.lock1);
                this.lock1Locked = false;

                Debug.WriteLine("RunOnUIThread, creating waiting operation");
                WaitingOperation waitingOperation = this._uiThreadWaitingOperation = new WaitingOperation(Method, Arguments);

                if (IsThisCallOnUIThread())
                {
                    Debug.WriteLine("RunOnUIThread, I am on UIThread now");
                    waitingOperation.DoOperation();
                }
                else
                    BeginInvokeOnUIThread(new MethodInvoker(waitingOperation.DoOperation));

                Debug.WriteLine("RunOnUIThread, releasing lock2");
                Monitor.Exit(this.lock2);

                Debug.WriteLine("RunOnUIThread, waiting to async operation to complete");
                waitingOperation.CompletedEvent.WaitOne();

                Debug.WriteLine("RunOnUIThread EXIT");
            }

            #region Lock Disposer

            // to cache instance of LockDisposer
            private IDisposable _lockDisposer;

            private IDisposable GetLockDisposer()
            {
                if (this._lockDisposer == null)
                    this._lockDisposer = new LockDisposer(this);

                return this._lockDisposer;
            }

            /// <summary>
            /// LockDisposer is used to release all synchronization locks locked in SynchronizationManager.Lock
            /// </summary>
            class LockDisposer : IDisposable
            {
                //we have to remember wchich synchronization manager does this LockDisposer belong to
                AutomationElementTreeNodeSynchornizationManager _manager;

                public LockDisposer(AutomationElementTreeNodeSynchornizationManager manager)
                {
                    this._manager = manager;
                }

                #region IDisposable Members

                void IDisposable.Dispose()
                {
                    Debug.WriteLine("Disposing synchronization manager");

                    //if there is lock1 locked then release it
                    if (this._manager.lock1Locked)
                    {
                        Debug.WriteLine("releasing lock 1");
                        Monitor.Exit(this._manager.lock1);
                    }

                    Debug.WriteLine("releasing work lock");
                    //also we have to release work lock
                    Monitor.Exit(this._manager.workLock);

                    GC.SuppressFinalize(this);
                }

                #endregion
            }

            #endregion 

            #region Waiting operation implementation

            /// <summary>
            /// this class is used to store waiting operation
            /// </summary>
            class WaitingOperation
            {
                // delegate to method that is going to be performed
                Delegate _method;

                // arguments for the method
                object[] _arguments;

                // event to signalize that method run completed
                ManualResetEvent _completedResetEvent;

                // to store if the waitiong operation was completed
                bool _completed;

                public WaitingOperation(Delegate Method, params object[] Arguments)
                {
                    this._method = Method;
                    this._arguments = Arguments;
                    this._completed = false;
                    this._completedResetEvent = new ManualResetEvent(false);
                }

                /// <summary>
                /// Gets if the waiting method was completed
                /// </summary>
                public bool Completed { get { return this._completed; } }

                /// <summary>
                /// Gets waiting handle to wait until method is complete
                /// </summary>
                public EventWaitHandle CompletedEvent { get { return _completedResetEvent; } }

                /// <summary>
                /// this will run the waiting operation
                /// </summary>
                public void DoOperation()
                {
                    Debug.WriteLine("Doing waiting operation ...");
                    if (this._completed == false)
                    {
                        Debug.WriteLine("dynamic invoking");

                        this._method.DynamicInvoke(this._arguments);

                        this._completed = true;
                        _completedResetEvent.Set();
                    }
                    Debug.WriteLine("Doing waiting operation EXIT");
                }
            }

            #endregion
        }

        #endregion 
    }
}
