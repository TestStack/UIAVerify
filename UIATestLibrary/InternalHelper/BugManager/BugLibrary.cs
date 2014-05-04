// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Test.UIAutomation.TestManager;
using System.Windows.Automation;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Text;
using Microsoft.Test.UIAutomation;

namespace InternalHelper.Tests
{
    class TestNode
    {

        const string str_AttributeValuePair = "@{0}='{1}'";
        const string str_AndAttribute = "[{0} and {1}]";
        const string str_SingleAttribute = "[{0}]";
        const string str_Issue = "Issue";
        const string str_OSVersion = "OSVersion";
        const string str_IsClientSideProvider = "ClientSideProvider";
        const string str_Method = "Method";
        const string str_Step = "Step";
        const string str_Steps = "Steps";
        const string str_Priority = "Pri";
        const string str_Bugs = "Bugs";
        const string str_BugNumber = "PS";
        const string str_Test = "Test";
        const string str_Desc = "Descr";
        const string str_TestName = "TestName";
        public const string str_VerificationMethod = "Verification";
        const string str_Repro = "Repro";
        const string str_OS = "OS";
        const string str_ControlPath = "ControlPath";
        const string str_CommandLine = "CommandLine";
        const string str_DateRun = "Date";
        const string str_Message = "Error";
        const string str_FailedStep = "FailedStep";
        /*
  <Test Method="Microsoft.Test.UIAutomation.Tests.Patterns.SelectionItemTests.TestSelect28" Step="4" Pri="Pri3" TestName="AddToSelection.2.8">
    <Steps>
      <Step Step="0" Descr="Precondition: There is a selection container (ie. Win32 radio buttons do not support a selection container)" />
      <Step Step="1" Descr="Precondition: Selection containers SelectionPattern.IsSelectionRequired should be true" />
      <Step Step="2" Descr="Precondition: Selection containers SelectionPattern.CanSelectMultiple should be false" />
      <Step Step="3" Descr="Step: Select the element" />
      <Step Step="4" Descr="Step: Call AddToSelection on the same element and verify that System.InvalidOperationException is thrown" />
      <Step Step="5" Descr="Verify element is selected" />
    </Steps>
    <FailedStep Step="4">
      <Issue Verification="Check_IsListItem">
        <Repro PS="TBD" OS="6.0" ClientSideProvider="T" ControlPath="List(1006)ListItem(NULL)" Error="Step 4 : SelectionItemPattern.AddToSelection() did not throw an System.InvalidOperationException expection as expected" CommandLine="WUIAGenericDriver.exe  /EVENTS /PRI Pri3 /LOG WUIALogging.dll /EXE CtrlTestVista.exe /ID 1006.ListBoxSingleSelect /UNMANAGED FALSE /FILTERFILE Win7BugFilter.xml" OSVersion="Microsoft Windows NT 6.0.6002 Service Pack 2, v.286" Date="5/19/2009 11:44:45 AM" />
      </Issue>
    </FailedStep>
  </Test>
                  */

        public int Step; public string MethodName; public string IsClientSideProvider; public string VerificationMethod; public string ControlPath;
        public TestCaseAttribute Attribute; public string Message;
        public XmlDocument Document;
        public TestNode(XmlDocument document, int step, string message, string methodName, bool isClientSideProvider, TestCaseAttribute testCaseAttribute, string verificationMethod, string controlPath)
        {
            Document = document;
            Step = step; MethodName = methodName; IsClientSideProvider = isClientSideProvider.ToString().Substring(0, 1).ToUpper();
            Attribute = testCaseAttribute;
            VerificationMethod = verificationMethod;
            ControlPath = controlPath;
            Message = message;
        }
        public TestNode(XmlDocument document, int step, string methodName, bool isClientSideProvider)
        {
            Document = document;
            Step = step; MethodName = methodName; IsClientSideProvider = isClientSideProvider.ToString().Substring(0, 1).ToUpper();
        }

        public string TestMethodNodeString { get { return "//Bugs/Test"; } }
        public string TestMethodNodeAttributeString { get { return string.Format(TestNode.str_SingleAttribute, MethodAttributeString); } }

        public string FailedStepNodeString { get { return string.Format("/{0}", TestNode.str_FailedStep); } }
        public string FailedStepNodeAttributeString { get { return string.Format(TestNode.str_SingleAttribute, this.StepAttributeString); } }

        public string IssueNodeString { get { return string.Format("/{0}", TestNode.str_Issue); } }
        public string IssueNodeAttributeString { get { return string.Format(TestNode.str_AndAttribute, this.OSVersionAttributeString, this.IsClientSideProviderAttributeString); } }

        public string ReproNodeString { get { return string.Format("/{0}", TestNode.str_Repro); } }
        public string ReproNodeAttributeString { get { return string.Format(TestNode.str_AndAttribute, OSAttributeString, IsClientSideProviderAttributeString); } }

        public string OSVersionAttributeString { get { return string.Format(TestNode.str_AttributeValuePair, TestNode.str_OSVersion, String.Format("{0}.{1}", Environment.OSVersion.Version.Major, Environment.OSVersion.Version.Minor)); } }
        public string OSAttributeString { get { return string.Format(TestNode.str_AttributeValuePair, TestNode.str_OS, String.Format("{0}.{1}", Environment.OSVersion.Version.Major, Environment.OSVersion.Version.Minor)); } }
        public string IsClientSideProviderAttributeString { get { return string.Format(TestNode.str_AttributeValuePair, TestNode.str_IsClientSideProvider, this.IsClientSideProvider); } }
        public string MethodAttributeString { get { return string.Format(TestNode.str_AttributeValuePair, TestNode.str_Method, this.MethodName); } }
        public string StepAttributeString { get { return string.Format(TestNode.str_AttributeValuePair, TestNode.str_Step, this.Step); } }
        public string PriorityAttributeString { get { return string.Format(TestNode.str_AttributeValuePair, TestNode.str_Priority, this.Attribute.Priority.ToString()); } }

        public string ReproPathString
        {
            get
            {
                return this.TestMethodNodeString + this.TestMethodNodeAttributeString + this.FailedStepNodeString + this.FailedStepNodeAttributeString + this.IssueNodeString + this.ReproNodeString + this.ReproNodeAttributeString;
            }
        }

        public bool GetBugNode(out XmlElement xmlNode)
        {
            return GetNode(null, TestNode.str_Bugs, string.Empty, null, out xmlNode);
        }

        /// --------------------------------------------------------------------
        /// <summary>Gets the node.  If it is adding a new node, return 
        /// true.</summary>
        /// --------------------------------------------------------------------
        private void GetNode(XmlElement parent, string name, string value, string[] attributes)
        {
            XmlElement newNode;
            GetNode(parent, name, value, attributes, out newNode);
        }

        // --------------------------------------------------------------------
        public bool GetTestNode(out XmlElement xmlNode)
        {
            XmlElement parent;
            GetBugNode(out parent);
            bool results = GetNode(parent, TestNode.str_Test, string.Empty, new string[] { 
                    TestNode.str_Method, this.MethodName, 
                    TestNode.str_TestName, this.Attribute.TestName,
                    TestNode.str_Priority, this.Attribute.Priority.ToString(),
            }, out xmlNode);
            if (results)
            {

                XmlComment comment = this.Document.CreateComment("".PadRight(120, '_'));
                parent.InsertBefore(comment, xmlNode);
            }
            return results;
        }

        // --------------------------------------------------------------------
        public bool GetStepNode(out XmlElement xmlTestNode)
        {
            XmlElement testNode;
            GetTestNode(out testNode);
            bool results = GetNode(testNode, TestNode.str_Steps, null, null, out xmlTestNode);
            if (results)
            {
                for (int i = 0; i < Attribute.Description.Length; i++)
                {
                    AddNode(xmlTestNode, TestNode.str_Step, Attribute.Description[i], new string[] { TestNode.str_Step, i.ToString() });
                }
            }
            return results;
        }

        // --------------------------------------------------------------------
        public bool GetFailedStepNode(out XmlElement xmlNode)
        {
            XmlElement parent;
            GetTestNode(out parent);
            return GetNode(parent, TestNode.str_FailedStep, null, new string[] { 
                    TestNode.str_Step, this.Step.ToString()},
                     out xmlNode);
        }

        // --------------------------------------------------------------------
        public bool GetIssueNode(out XmlElement xmlNode)
        {
            XmlElement parent;
            GetFailedStepNode(out parent);
            return GetNode(parent, TestNode.str_Issue, null, new string[] { 
                    TestNode.str_VerificationMethod, this.VerificationMethod},
                     out xmlNode);

        }


        // --------------------------------------------------------------------
        public bool GetReproNode(out XmlElement xmlNode)
        {
            XmlElement parent;
            GetIssueNode(out parent);
            bool results = GetNode(parent, TestNode.str_Repro, null,
                                new string[]{
                                    TestNode.str_OS, String.Format("{0}.{1}", Environment.OSVersion.Version.Major, Environment.OSVersion.Version.Minor),
                                    TestNode.str_IsClientSideProvider, this.IsClientSideProvider.ToString(), 
                                    TestNode.str_BugNumber, "TBD",
                                    TestNode.str_ControlPath, this.ControlPath,
                                    TestNode.str_Message, this.Message,
                                    TestNode.str_CommandLine, TestRuns.CommandLine,
                                },
                    out xmlNode);
            if (results)
            {
                AddAttributes(xmlNode, new string[] {
                    TestNode.str_OSVersion, Environment.OSVersion.VersionString,
                    TestNode.str_DateRun, DateTime.Now.ToString() });

            }
            return results;
        }

        /// --------------------------------------------------------------------
        /// <summary>Remove unwanted and unexceptable chars in an XML node 
        /// value string</summary>
        /// --------------------------------------------------------------------
        private static string XMLFixUP(string str)
        {
            str = str.Replace("'", "");
            return str;
        }

        /// --------------------------------------------------------------------
        /// <summary>Gets the node.  If it is adding a new node, return true.</summary>
        /// <returns>True if a new node is created, false if it already existed</returns>
        /// --------------------------------------------------------------------
        private bool GetNode(XmlElement parent, string name, string value, string[] attributes, out XmlElement newNode)
        {
            string srcString = name;

            if (null != attributes)
            {
                string srcAttr = string.Empty;
                const string andStr = " and ";
                for (int i = 0; i < attributes.Length; )
                {
                    srcAttr += ("@" + attributes[i++] + "='" + XMLFixUP(attributes[i++]) + "'" + andStr);
                }
                srcAttr = srcAttr.Remove(srcAttr.Length - andStr.Length);
                srcString += ("[" + srcAttr + "]");
            }

            XmlNodeList list;
            if (null == parent)
            {
                list = this.Document.SelectNodes(srcString);
            }
            else
            {
                list = parent.SelectNodes(srcString);
            }

            if (list.Count > 0)
            {
                newNode = (XmlElement)list[0];
                return false;  // Node exists, return false that it was created
            }

            AddNode(parent, name, value, attributes, out newNode);
            return true; // Node does exists, return true that it was created
        }
        /// --------------------------------------------------------------------
        /// <summary>Add a node under an XML parented node</summary>
        /// --------------------------------------------------------------------
        private bool AddNode(XmlElement parent, string name, string value, string[] attributes)
        {
            XmlElement newNode;
            return AddNode(parent, name, value, attributes, out newNode);
        }

        /// --------------------------------------------------------------------
        /// <summary>Add a node under an XML parented node</summary>
        /// --------------------------------------------------------------------
        private bool AddNode(XmlElement parent, string name, string value, string[] attributes, out XmlElement newNode)
        {
            // Can't find it, now create it and return the new node
            newNode = this.Document.CreateElement(name);
            if (!string.IsNullOrEmpty(value))
            {
                newNode.InnerText = value;
            }

            AddAttributes(newNode, attributes);

            if (parent == null)
            {
                this.Document.AppendChild(newNode);
            }
            else
            {
                parent.AppendChild(newNode);
            }
            return true;
        }

        /// --------------------------------------------------------------------
        /// <summary>Add an attribute collection to an XML node</summary>
        /// --------------------------------------------------------------------
        public void AddAttributes(XmlElement node, string[] attributes)
        {
            AddAttributes(node, attributes, true);
        }

        /// --------------------------------------------------------------------
        /// <summary>Add an attribute collection to an XML node</summary>
        /// --------------------------------------------------------------------
        public void AddAttributes(XmlElement node, string[] attributes, bool append)
        {
            Debug.Assert(node != null);

            if (null == attributes || attributes.Length == 0)
                return;

            for (int i = 0; i < attributes.Length; )
            {
                XmlAttribute attr = this.Document.CreateAttribute(attributes[i++]);
                attr.Value = XMLFixUP(attributes[i++]);
                if (append)
                    node.Attributes.Append(attr);
                else
                    node.Attributes.Prepend(attr);

            }
        }
    }

    public class BugLibrary
    {
        static XmlDocument _filterDoc;
        static XmlDocument _newFilterDoc;

        /// --------------------------------------------------------------------
        static public bool Check_IsButton(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Button); }
        static public bool Check_IsCalendar(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Calendar); }
        static public bool Check_IsCheckBox(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.CheckBox); }
        static public bool Check_IsComboBox(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.ComboBox); }
        static public bool Check_IsCustom(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Custom); }
        static public bool Check_IsDataGrid(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.DataGrid); }
        static public bool Check_IsDataItem(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.DataItem); }
        static public bool Check_IsDocument(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Document); }
        static public bool Check_IsEdit(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Edit); }
        static public bool Check_IsGroup(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Group); }
        static public bool Check_IsHeader(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Header); }
        static public bool Check_IsHeaderItem(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.HeaderItem); }
        static public bool Check_IsHyperlink(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Hyperlink); }
        static public bool Check_IsImage(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Image); }
        static public bool Check_IsList(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.List); }
        static public bool Check_IsListItem(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.ListItem); }
        static public bool Check_IsMenu(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Menu); }
        static public bool Check_IsMenuBar(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.MenuBar); }
        static public bool Check_IsMenuItem(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.MenuItem); }
        static public bool Check_IsPane(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Pane); }
        static public bool Check_IsProgressBar(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.ProgressBar); }
        static public bool Check_IsRadioButton(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.RadioButton); }
        static public bool Check_IsScrollBar(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.ScrollBar); }
        static public bool Check_IsSeparator(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Separator); }
        static public bool Check_IsSlider(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Slider); }
        static public bool Check_IsSpinner(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Spinner); }
        static public bool Check_IsSplitButton(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.SplitButton); }
        static public bool Check_IsStatusBar(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.StatusBar); }
        static public bool Check_IsTab(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Tab); }
        static public bool Check_IsTabItem(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.TabItem); }
        static public bool Check_IsTable(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Table); }
        static public bool Check_IsText(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Text); }
        static public bool Check_IsThumb(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Thumb); }
        static public bool Check_IsTitleBar(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.TitleBar); }
        static public bool Check_IsToolBar(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.ToolBar); }
        static public bool Check_IsToolTip(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.ToolTip); }
        static public bool Check_IsTree(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Tree); }
        static public bool Check_IsTreeItem(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.TreeItem); }
        static public bool Check_IsWindow(AutomationElement element) { return IsControlTypeHierarchy(element, ControlType.Window); }
        /// --------------------------------------------------------------------
        static public bool Check_IsButtonScrollbarEdit(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Button, ControlType.ScrollBar, ControlType.Edit }); }
        static public bool Check_IsButtonComboBox(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Button, ControlType.ComboBox }); }
        static public bool Check_IsButtonSlider(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Button, ControlType.Slider }); }
        static public bool Check_IsButtonTab(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Button, ControlType.Tab }); }
        /// --------------------------------------------------------------------
        static public bool Check_IsDataGridScrollBar(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.DataGrid, ControlType.ScrollBar }); }
        /// --------------------------------------------------------------------
        static public bool Check_IsDataItemDataGrid(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.DataItem, ControlType.DataGrid }); }
        static public bool Check_IsDataItemGroupDataGrid(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.DataItem, ControlType.Group, ControlType.DataGrid }); }
        /// --------------------------------------------------------------------
        static public bool Check_IsEditComboBox(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Edit, ControlType.ComboBox }); }
        static public bool Check_IsEditDataItemDataGrid(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Edit, ControlType.DataItem, ControlType.DataGrid }); }
        static public bool Check_IsEditDataItemGroupDataGrid(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Edit, ControlType.DataItem, ControlType.Group, ControlType.DataGrid }); }
        /// --------------------------------------------------------------------
        static public bool Check_IsGroupList(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Group, ControlType.List }); }
        static public bool Check_IsGroupDataGrid(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Group, ControlType.DataGrid }); }
        /// --------------------------------------------------------------------
        static public bool Check_IsHeaderItemHeaderList(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.HeaderItem, ControlType.Header, ControlType.List }); }
        static public bool Check_IsHeaderList(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Header, ControlType.List }); }
        static public bool Check_IsHeaderListList(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Header, ControlType.List, ControlType.List }); }
        /// --------------------------------------------------------------------
        static public bool Check_IsScrollBarEdit(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.ScrollBar, ControlType.Edit }); }
        static public bool Check_IsScrollBarList(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.ScrollBar, ControlType.List }); }
        static public bool Check_IsScrollBarTree(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.ScrollBar, ControlType.Tree }); }
        /// --------------------------------------------------------------------
        static public bool Check_IsSpinnerTab(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Spinner, ControlType.Tab }); }
        /// --------------------------------------------------------------------
        static public bool Check_IsSliderButton(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Button, ControlType.Slider }); }
        static public bool Check_IsSliderThumb(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Thumb, ControlType.Slider }); }
        /// --------------------------------------------------------------------
        static public bool Check_IsTabItemTab(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.TabItem, ControlType.Tab }); }
        static public bool Check_IsTabSpinner(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Spinner, ControlType.Tab }); }
        static public bool Check_IsTabSpinnerButton(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Button, ControlType.Spinner, ControlType.Tab }); }
        /// --------------------------------------------------------------------
        static public bool Check_IsTextComboBox(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Text, ControlType.ComboBox }); }
        /// --------------------------------------------------------------------
        static public bool Check_IsThumbEdit(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Thumb, ControlType.Edit }); }
        static public bool Check_IsThumbList(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Thumb, ControlType.List }); }
        static public bool Check_IsThumbScrollbarEdit(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Thumb, ControlType.ScrollBar, ControlType.Edit }); }
        static public bool Check_IsThumbTree(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Thumb, ControlType.Tree }); }
        static public bool Check_IsThumbSlider(AutomationElement element) { return IsControlTypeHierarchy(element, new ControlType[] { ControlType.Thumb, ControlType.Slider }); }

        /// --------------------------------------------------------------------
        private static bool IsControlTypeHierarchy(AutomationElement element, ControlType controlType)
        {
            return IsControlTypeHierarchy(element, new ControlType[] { controlType });
        }

        /// --------------------------------------------------------------------
        private static bool IsControlTypeHierarchy(AutomationElement element, ControlType[] controlTypes)
        {
            AutomationElement temp = element;
            foreach (ControlType controlType in controlTypes)
            {
                if (!Helper_IsControlType(temp, controlType))
                {
                    return false;
                }
                else
                {
                    if (temp == null)
                    {
                        return false;
                    }
                    else
                    {
                        temp = TreeWalker.ControlViewWalker.GetParent(temp);
                    }
                }
            }
            return true;
        }

        /// --------------------------------------------------------------------
        private static bool Helper_IsControlType(AutomationElement element, ControlType controlType)
        {
            Trace.WriteLine(element.Current.ControlType.ProgrammaticName);
            if (element == null)
                return false;
            else
                return element.Current.ControlType == controlType;
        }

        /// --------------------------------------------------------------------
        private static bool Helper_ClassnameIs(AutomationElement element, string className)
        {
            if (element == null)
                return false;
            else
                return element.Current.ClassName.ToLower() == className.ToLower();
        }

        /// --------------------------------------------------------------------
        /// <summary>This will match up the test method BugAttribute, then 
        /// BugLibrary BugAttributes, and the known step that is occuring in 
        /// real time. If these threse items do not match, there will not be a 
        /// matching BugAttribute.</summary>
        /// <returns>If any of the bugs associated with the test case repro</returns>
        /// --------------------------------------------------------------------
        public static bool IsIssueKnown(Exception exception, AutomationElement element, int step, out string knownIssue)
        {
            knownIssue = exception.Message;
            string fullQualified;
            if (Path.IsPathRooted(TestRuns.BugFilterFile))
            {
                fullQualified = TestRuns.BugFilterFile;
            }
            else
            {
                fullQualified = Path.Combine(Directory.GetCurrentDirectory(), TestRuns.BugFilterFile);
            }

            // Could load this once, but do it everytime.  This helps when reporting errors, you can update the xml on the fly and
            // re-run your tests without restarting UIV.  Hardcode the name for now, come back in and add it dynamically if we need it.
            if (TestRuns.BugFilterFile != string.Empty && TestRuns.FilterOutBugs)
            {
                if (System.IO.File.Exists(fullQualified))
                {
                    TestCaseAttribute attribute;
                    string methodName = GetTestMethodThatThrowException(exception, out attribute);
                    _filterDoc = new XmlDocument();
                    _filterDoc.Load(fullQualified);

                    TestObject.Comment(string.Format(string.Format("Verifying if this is a know issue by verify results in {0}.", fullQualified)));

                    TestNode tn = new TestNode(_filterDoc, step, methodName, TestRuns.IsClientSideProviderLoaded);

                    foreach (XmlNode node in _filterDoc.SelectNodes(tn.ReproPathString))
                    {
                        XmlAttribute attrVerificationMethod = node.ParentNode.Attributes[TestNode.str_VerificationMethod];
                        if (null != attrVerificationMethod)
                        {
                            string verificationMethod = attrVerificationMethod.Value;
                            if (!string.IsNullOrEmpty(verificationMethod))
                            {
                                MethodInfo methodInfo = typeof(BugLibrary).GetMethod(verificationMethod);

                                if (methodInfo == null)
                                {
                                    throw new ArgumentException("There is no verification called '{0}' in BugsLibrary.cs", verificationMethod);
                                }

                                bool isScenario = (bool)methodInfo.Invoke(null, new object[] { element });
                                if (isScenario)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    TestObject.Comment("Could not find issue with [{0}]", tn.ReproPathString);
                }
            }
            
            return false;
        }

        /// --------------------------------------------------------------------
        /// <summary>Add the issue to the FailedFilter xml file.  This is a file 
        /// that has the appended new errors.  After viewing this, replace/add 
        /// the nodes to the actual filter file.</summary>
        /// --------------------------------------------------------------------
        internal static void AddIssue(Exception exception, AutomationElement element, int testStep)
        {
            try
            {
                string filterFile = @"FailedFilter.xml";

                if (null == _newFilterDoc)
                {
                    _newFilterDoc = new XmlDocument();

                    if (System.IO.File.Exists(filterFile))
                    {
                        _newFilterDoc.Load(filterFile);
                    }
                }

                /*
                 <Test Method="Microsoft.Test.UIAutomation.Tests.Patterns.AutomationElementTests.TestSetFocus1a" TestName="SetFocus.1" Pri="Pri1">
                    <FailedStep Step="9">
                        <Issue Verification="Check_IsCheckBox">
                            <Repro OS="6.1" ClientSideProvider="T" PS
                 */

                TestCaseAttribute attribute;
                StringBuilder sbPath;
                StringBuilder verificationMethod;

                string methodName = GetTestMethodThatThrowException(exception, out attribute);

                GetElementsPathAndPossibleVerificationMethod(element, out sbPath, out verificationMethod);

                TestNode tn = new TestNode(_newFilterDoc, testStep, exception.Message, methodName, TestRuns.IsClientSideProviderLoaded, attribute, verificationMethod.ToString(), sbPath.ToString());

                XmlElement nodeSteps;
                tn.GetStepNode(out nodeSteps);

                XmlElement nodeRepro;
                tn.GetReproNode(out nodeRepro);

                TestObject.Comment("_________");
                TestObject.Comment("Test Method        = {0}", methodName);
                TestObject.Comment("FailedStep Step    = {0}", testStep);
                TestObject.Comment("Issue Verification = {0}", verificationMethod);
                TestObject.Comment("Path               = {0}", sbPath);
                TestObject.Comment("XML                = {0}", nodeRepro.ParentNode.OuterXml);
                TestObject.Comment("_________");


                _newFilterDoc.Save(filterFile);
                TestObject.Comment("{0} is saved.", filterFile);

            }
            catch (Exception)
            {
                TestObject.Comment(exception.Message);
                // Eat the exception and go on
                //System.Windows.Forms.MessageBox.Show(string.Format("Could not update the bug file({0});", e.Message));
            }
        }

        /// --------------------------------------------------------------------
        /// <summary>Scans the exception stack trace for methods that have a 
        /// BugAttribute. Then, performs a lookup of the BugAttribute within 
        /// the BugLibrary for a repro</summary>
        /// --------------------------------------------------------------------
        private static string GetTestMethodThatThrowException(Exception exception, out TestCaseAttribute attribute)
        {
            StackTrace stackTrace = new StackTrace(exception, true);
            attribute = null;

            foreach (StackFrame stackFrame in stackTrace.GetFrames())
            {
                foreach (TestCaseAttribute attr in stackFrame.GetMethod().GetCustomAttributes(typeof(TestCaseAttribute), true))
                {
                    MethodBase mb = stackFrame.GetMethod();
                    attribute = attr;
                    return string.Format("{0}.{1}", mb.DeclaringType.FullName, mb.Name);
                }
            }
            return String.Empty;
        }

        /// --------------------------------------------------------------------
        /// <summary>Get elements fill path and a verification method for the 
        /// item</summary>
        /// --------------------------------------------------------------------
        private static void GetElementsPathAndPossibleVerificationMethod(AutomationElement element, out StringBuilder sbPath, out StringBuilder sbVerificationMethod)
        {
            sbVerificationMethod = new StringBuilder(string.Format("Check_Is{0}", element.Current.ControlType.ProgrammaticName.ToString()));
            sbVerificationMethod.Replace("ControlType.", "");

            sbPath = new StringBuilder();

            AutomationElement el = element;
            //bool addControlType = true;
            while (el != null)
            {
                StringBuilder sbControlType = new StringBuilder(el.Current.ControlType.ProgrammaticName);
                sbControlType.Replace("ControlType.", "");

                // Only go as high as the containing window
                if (el.Current.ControlType == ControlType.Window || el.Current.ControlType == ControlType.Pane)
                {
                    return;
                }

                sbPath.Insert(0, string.Format("{0}({1})",
                    sbControlType.ToString(),
                    !String.IsNullOrEmpty(el.Current.AutomationId) ? el.Current.AutomationId : "NULL"));

                // This will ensure that we add a duplicate coontrol the 1st time around.  Seen next block for more info.
                //if (addControlType)
                //  sbVerificationMethod.Append(sbControlType);

                // Don't want to do Tree.TreeItem.TreeItem.TreeItem for example.  Only take the 1st occurance.
                if (el.Current.ControlType == ControlType.TreeItem ||
                    el.Current.ControlType == ControlType.Tree ||
                    el.Current.ControlType == ControlType.ListItem ||
                    el.Current.ControlType == ControlType.List
                    )
                {
                    //addControlType = false;
                }

                // Get the elements parent and continue walking the tree for information
                el = TreeWalker.ControlViewWalker.GetParent(el);
            }
        }
    }
}