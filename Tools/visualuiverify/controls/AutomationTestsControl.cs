//---------------------------------------------------------------------------
//
// <copyright file="AutomationTestsControl" company="Microsoft">
//    Copyright (C) Microsoft Corporation.  All rights reserved.
// </copyright>
// 
//
// Description: User Control showing Automation-Element Tests
//
// History:  
//  08/29/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Drawing=System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Diagnostics;
using VisualUIAVerify.Features;
using VisualUIAVerify.Utils;

namespace VisualUIAVerify.Controls
{
    /// <summary></summary>
    public enum MovementDirections
    {
        /// <summary></summary>
        Left,
        /// <summary></summary>
        Right,
        /// <summary></summary>
        Up,
        /// <summary></summary>
        Down
    }


    /// <summary>
    /// This control shows AutomationElementTests
    /// </summary>
    public partial class AutomationTestsControl : UserControl
    {
        #region private properties
        

        /// <summary>
        /// scope of shown the tests
        /// </summary>
        private TestsScope _scope;

        /// <summary>
        /// types of shown tests
        /// </summary>
        private TestTypes _types;

        /// <summary>
        /// priorities of shown tests
        /// </summary>
        private TestPriorities _priorities;

        /// <summary>
        /// selected element
        /// </summary>
        private AutomationElement _selectedElement;

        /// <summary>
        /// indicating that ShowTests method was called
        /// </summary>
        private bool _showTests;
        
        #endregion

        /// <summary>
        /// events fired when menu items clicked
        /// </summary>
        public event EventHandler RunTestRequired, RunTestOnAllChildrenRequired;

        /// <summary>
        /// initializes new instance.
        /// </summary>
        public AutomationTestsControl()
        {
            InitializeComponent();
        }


        /// <summary>
        /// get/set scope of tests
        /// </summary>
        public TestsScope Scope
        {
            get { return this._scope; }
            set
            {
                if(this._scope != value)
                {
                    this._scope = value;
                    RefreshTests();
                }
            }
        }

        /// <summary>
        /// get/set types of the tests to be shown
        /// </summary>
        public TestTypes Types
        {
            get { return this._types; }
            set
            {
                if(this._types != value)
                {
                    this._types = value;
                    RefreshTests();
                }
            }
        }
            
        /// <summary>
        /// get/set test priorities
        /// </summary>
        public TestPriorities Priorities
        {
            get { return this._priorities; }
            set
            {
                if(this._priorities != value)
                {
                    this._priorities = value;
                    RefreshTests();
                }
            }
        }

        /// <summary>
        /// get/set selected automation element which is to be tested
        /// </summary>
        public AutomationElement SelectedElement
        {
            get { return this._selectedElement; }
            set
            {
                if(this._selectedElement != value)
                {
                    this._selectedElement = value;

                    if(this._scope == TestsScope.SelectedElementTests)
                        RefreshTests();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        public void MoveToTest(MovementDirections direction)
        {
            TreeNode selectedNode = _testsTreeView.SelectedNode;

            if (selectedNode == null)
                selectedNode = _testsTreeView.Nodes[0];

            switch (direction)
            {
                case MovementDirections.Left:
                    selectedNode = selectedNode.Parent;
                    break;

                case MovementDirections.Right:
                    if (selectedNode.Nodes.Count > 0)
                        selectedNode = selectedNode.Nodes[0];
                    else
                        selectedNode = null;
                    
                    break;

                case MovementDirections.Up:
//                  SendKeys.Send("UP");
//                  it does not work on certain builds of Vista

                    selectedNode = selectedNode.PrevNode;
                    break;

                case MovementDirections.Down:
//                  SendKeys.Send("DOWN");

                    selectedNode = selectedNode.NextNode;
                    break;
            }

            if (selectedNode != null)
            {
                _testsTreeView.SelectedNode = selectedNode;
                selectedNode.EnsureVisible();
            }
        }

        /// <summary>
        /// this is to grab all selected tests
        /// </summary>
        public IEnumerable<AutomationTest> SelectedTests
        {
            get
            {
                List<AutomationTest> selectedTests = new List<AutomationTest>();

                if(this._testsTreeView.SelectedNode != null)
                    GrabTests(this._testsTreeView.SelectedNode, selectedTests);

                return selectedTests;
            }
        }

        /// <summary>
        /// helper method to grab selected tests
        /// </summary>
        private void GrabTests(TreeNode treeNode, List<AutomationTest> selectedTests)
        {
            // get automation test for treeNode
            AutomationTest nodeTest = treeNode.Tag as AutomationTest;

            // if automation test is not contained in tests collection then add him to the collection
            if (nodeTest != null && !selectedTests.Contains(nodeTest))
                selectedTests.Add(nodeTest);

            // add all tests in children nodes
            foreach (TreeNode childNode in treeNode.Nodes)
                GrabTests(childNode, selectedTests);
        }

        /// <summary>
        /// this method causes showing of tests in the tree.
        /// </summary>
        public void ShowTests()
        {
            this._showTests = true;
            RefreshTests();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="refreshTestsCollection"></param>
        public void RefreshTests(bool refreshTestsCollection)
        {
            if(refreshTestsCollection)
                AutomationTestCollection.RefreshTests();

            RefreshTests();
        }


        #region creating the automation tests tree

        /// <summary>
        /// this method will clear and create new tree of automation tests according to required
        /// TestScope, TestTypes, TestPriorities.
        /// </summary>
        private void RefreshTests()
        {
            // if we are not showing tests then we don't have to do anything
            if(!_showTests)
                return;

            //editing is starting, so don't update the tree until it finishes
            _testsTreeView.BeginUpdate();

            //ensure we have one root currentTestTypeRootNode named 'Tests' without children nodes
            if (_testsTreeView.Nodes.Count == 0)
                _testsTreeView.Nodes.Add("Tests");
            else
                _testsTreeView.Nodes[0].Nodes.Clear();

            SetSelectedTest(_testsTreeView.Nodes[0]);
            
            //go thru all kinds of possible TestTypes and if there is any required, create subtree for it
            foreach (TestTypes testType in Enum.GetValues(typeof(TestTypes)))
            {
                if (testType != TestTypes.None && 
                    (this._types & testType) == testType
                    )
                {
                    //create subtree for this type of tests
                    CreateTestTypeNodeSubtree(testType, new TestFilterType(testType));
                }
            }

            // sort tree nodes
            _testsTreeView.Sort();

            // expand the tree to certain level
            ExpandTree(_testsTreeView.Nodes, 2);

            //editing of the tree is finished
            _testsTreeView.EndUpdate();
        }

        /// <summary>
        /// this method expand tests tree to certain level
        /// </summary>
        private void ExpandTree(TreeNodeCollection nodes, int levels)
        {
            if (levels > 0)
            {
                foreach (TreeNode node in nodes)
                {
                    node.Expand();
                    ExpandTree(node.Nodes, levels - 1);
                }
            }
        }

        /// <summary>
        /// this method creates automation tests subtree for particular test type
        /// </summary>
        /// <param name="testType"></param>
        /// <param name="testFilter">filter to be applied on all available automation tests collection</param>
        private void CreateTestTypeNodeSubtree(TestTypes testType, AutomationTestsFilter testFilter)
        {
            //create root currentTestTypeRootNode for the currentTestTypeRootNode type
            TreeNode currentTestTypeRootNode = new TreeNode(GetTestTypeName(testType));
            _testsTreeView.Nodes[0].Nodes.Add(currentTestTypeRootNode);

            if (testType == TestTypes.ControlTest)
            {
                //if ControlTest test type is required then let's get automation ControlType
                //for the selected automation element. If we are showing all tests, not only for selected
                //elements then let's get all automation element ControlTypes.
                //for all grabbed ControlTypes let's create subtree with tests

                ControlType[] controlTypes;

                if (this._scope == TestsScope.SelectedElementTests)
                {
                    try
                    {
                        //get control type if selected automation element
                        controlTypes = new ControlType[] { this._selectedElement.Current.ControlType };
                    }
                    catch (ElementNotAvailableException)
                    {
                        //if there are problems with the elements then ignore it
                        controlTypes = new ControlType[] { };
                    }
                }
                else
                {
                    // let's get all automation technology ControlTypes
                    controlTypes = AutomationHelper.GetAllAutomationControlTypes();
                }

                //fore each control type, let's create subtree
                foreach (ControlType controlType in controlTypes)
                {
                    //create automation tests filter for the controlType
                    FilterControlTypeTests controlTypeFilter = new FilterControlTypeTests(controlType);

                    //create tree currentTestTypeRootNode for the control type
                    TreeNode controlTypeNode = new TreeNode(controlTypeFilter.ControlTypeName);
                    currentTestTypeRootNode.Nodes.Add(controlTypeNode);

                    //create priority subtree for the controlType
                    CreatePrioritySubtreesForTestType(controlTypeNode, new AndFilter(testFilter, controlTypeFilter), testType);

                    //if the currentRootNode has no children nodes then remove it
                    if (controlTypeNode.Nodes.Count == 0)
                        controlTypeNode.Remove();
                }
            }
            else
            {
                if (testType == TestTypes.PatternTest)
                {
                    //if PatternTest test type is required then let's get all supported patterns
                    //for the selected automation element. If we are showing all tests, not only for selected
                    //elements then let's get all automation element Patterns.
                    //for all grabbed Patterns let's create subtree with tests

                    IEnumerable<AutomationPattern> supportedPatterns;

                    if (this._scope == TestsScope.SelectedElementTests)
                    {
                        try
                        {
                            //get all supported patterns
                            supportedPatterns = this._selectedElement.GetSupportedPatterns();
                        }
                        catch (ElementNotAvailableException)
                        {
                            //is there is problem with the element then ignore his patterns
                            supportedPatterns = new AutomationPattern[0];
                        }
                    }
                    else
                    {
                        //let's get all automation technology patterns
                        supportedPatterns = AutomationHelper.GetAllAutomationPatterns();
                    }

                    //for each pattern let's create subtree
                    foreach (AutomationPattern pattern in supportedPatterns)
                    {
                        //create filter filtering automation tests testing this pattern
                        FilterPatternTests patternFilter = new FilterPatternTests(pattern);

                        //create tree currentRootNode for the pattern
                        TreeNode patternNode = new TreeNode(patternFilter.PatternName);
                        currentTestTypeRootNode.Nodes.Add(patternNode);

                        //create priority subtree for the pattern
                        CreatePrioritySubtreesForTestType(patternNode, new AndFilter(testFilter, patternFilter), testType);

                        //if the currentRootNode has no children nodes then remove it
                        if (patternNode.Nodes.Count == 0)
                            patternNode.Remove();
                    }
                }
                else
                {
                    //if other TestType than ControlTests or PatternTests is required then
                    //create subtree for it
                    CreatePrioritySubtreesForTestType(currentTestTypeRootNode, testFilter, testType);
                }
            }

            //if there are no children then remove the currentTestTypeRootNode
            if (currentTestTypeRootNode.Nodes.Count == 0)
                currentTestTypeRootNode.Remove();
        }

        /// <summary>
        /// create subtree for currentRootNode according to the testType and testFilter
        /// </summary>
        private void CreatePrioritySubtreesForTestType(TreeNode node, AutomationTestsFilter testFilter, TestTypes testType)
        {
            //go thru all test priorities and create subtree for each
            foreach (TestPriorities priority in Enum.GetValues(typeof(TestPriorities)))
            {
                if (priority != TestPriorities.None && (this._priorities & priority) == priority)
                    CreateTestPrioritySubtree(priority, testType, node, testFilter);
            }
        }

        /// <summary>
        /// create subtree for parentNode according to the testPriority, testType and testFilter
        /// </summary>
        private void CreateTestPrioritySubtree(TestPriorities testPriority, TestTypes testType, TreeNode parentNode, AutomationTestsFilter testFilter)
        {
            //create node for the priority
            TreeNode priorityNode = new TreeNode(GetPriorityName(testPriority));
            parentNode.Nodes.Add(priorityNode);
            TreeNode currentRootNode = priorityNode;

            //create filter for the priority
            AndFilter priorityFilter = new AndFilter(new TestFilterPriority(testPriority), testFilter);

            //for all filtered available automation tests lets create tree node
            foreach (AutomationTest test in AutomationTestCollection.Filter(priorityFilter))
            {
                //lets make copy ot the test with only TestType and TestPriority belonging to this
                //branch

                AutomationTest testClone = new AutomationTest(test, testPriority, testType);

                TreeNode testNode = new TreeNode(testClone.Name);
                testNode.Tag = testClone;

                currentRootNode.Nodes.Add(testNode);
            }

            //if no child currentTestTypeRootNode was added then remove priority currentTestTypeRootNode
            if (currentRootNode.Nodes.Count == 0)
                currentRootNode.Remove();
        }

        /// <summary>
        /// returns user friendly name for testType
        /// </summary>
        private string GetTestTypeName(TestTypes testType)
        {
            string name;

            switch (testType)
            {
                case TestTypes.AutomationElementTest: name = "Automation Element Tests"; break;
                case TestTypes.PatternTest: name = "Pattern Tests"; break;
                case TestTypes.ControlTest: name = "Control Tests"; break;
                //case TestTypes.ScenarioTest: name = "Scenario Tests"; break;

                default:
                    {
                        Debug.Fail("unexpected TestTypes value");
                        name = Enum.GetName(typeof(TestTypes), testType);
                    }
                    break;
            }

            return name;
        }

        /// <summary>
        /// returns user friendly name for testPriority
        /// </summary>
        /// <param name="testPriority"></param>
        /// <returns></returns>
        private string GetPriorityName(TestPriorities testPriority)
        {
            string name;

            switch (testPriority)
            {
                case TestPriorities.BuildVerificationTests: name = "Build Verification Tests"; break;
                case TestPriorities.Priority0Tests: name = "Priority 0 Tests"; break;
                case TestPriorities.Priority1Tests: name = "Priority 1 Tests"; break;
                case TestPriorities.Priority2Tests: name = "Priority 2 Tests"; break;
                case TestPriorities.Priority3Tests: name = "Priority 3 Tests"; break;
                case TestPriorities.OnlyPriorityAllTests: name = "Priority All Tests"; break;

                default:
                    {
                        Debug.Fail("unexpected TestPriorities value");
                        name = Enum.GetName(typeof(TestPriorities), testPriority);
                    }
                    break;
            }

            return name;
        }

        #endregion

        /// <summary>
        /// Causes firing RunTestRequired event
        /// </summary>
        protected virtual void OnRunTest()
        {
            if (this.RunTestRequired != null)
                this.RunTestRequired(this, EventArgs.Empty);
        }

        /// <summary>
        /// Causes firing RunTestOnAllChildrenRequired event
        /// </summary>
        protected virtual void OnRunTestOnAllChildren()
        {
            if (this.RunTestOnAllChildrenRequired != null)
                this.RunTestOnAllChildrenRequired(this, EventArgs.Empty);
        }

        private void SetSelectedTest(TreeNode node)
        {
            SetSelectedNodeTransparentColor();
            _testsTreeView.SelectedNode = node;
            SetSelectedNodeActiveColor();
        }

        private void SetSelectedNodeActiveColor()
        {
            TreeNode selectedNode = _testsTreeView.SelectedNode;
            if (selectedNode != null)
                selectedNode.BackColor = Drawing.SystemColors.GradientActiveCaption;
        }

        private void SetSelectedNodeTransparentColor()
        {
            TreeNode selectedNode = _testsTreeView.SelectedNode;
            if (selectedNode != null)
                selectedNode.BackColor = Drawing.Color.Transparent;
        }


        #region events

        private void _testsTreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            SetSelectedNodeTransparentColor();
        }

        private void _testsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetSelectedNodeActiveColor();
        }

        // whatever mouse button pressed, it will select the currentTestTypeRootNode
        private void _testsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //we will select the currentTestTypeRootNode which was clicked
            this._testsTreeView.SelectedNode = e.Node;
        }

        private void runTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnRunTest();
        }

        #endregion
    }
}
