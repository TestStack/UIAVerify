// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.IO;
using System.Collections;

namespace Microsoft.Test.UIAutomation.TestManager
{
    using Microsoft.Test.UIAutomation;


    /// -------------------------------------------------------------------
    /// <summary>
    /// Flag for specifying priority of test to run
    /// </summary>
    /// -------------------------------------------------------------------
    [FlagsAttribute]
    public enum TestPriorities
    {
        /// <summary></summary>
        BuildVerificationTest = 1,
        /// <summary></summary>
        Pri0 = 2,
        /// <summary></summary>
        Pri1 = 4,
        /// <summary></summary>
        Pri2 = 8,
        /// <summary></summary>
        Pri3 = 16,
        /// <summary></summary>
        PriAll = BuildVerificationTest | Pri0 | Pri1 | Pri2 | Pri3
    }

    /// ---------------------------------------
    /// <summary>
    /// 
    /// </summary>
    /// ---------------------------------------
    public enum ProviderTypeEnum
    {
        Unmanaged,
        Managed
    }

    /// ---------------------------------------
    /// <summary>
    /// Filter to determine what type this test is
    /// </summary>
    /// ---------------------------------------
    [Flags]
    public enum TestCaseType
    {
        /// <summary>
        /// Can be ran within LeVerify application and does not require any
        /// up front planning other than identifying the element to test.
        /// </summary>
        Generic = 1,
        /// <summary>
        /// Is a test that run from a controlled environment since it may take some up front
        /// planning such as opening Notepad, or may require arguments
        /// </summary>
        Scenario = 2,
        /// <summary>
        /// Whether the test case tests out events or not
        /// </summary>
        Events = 4,
        /// <summary>
        /// Arguements are required for the test case
        /// </summary>
        Arguments = 8,
        /// <summary>
        /// Test must preserve content of control (for TextPattern and ValuePattern tests)
        /// </summary>
        PreservesContent = 16,
    }

    /// ---------------------------------------
    /// <summary>
    /// Id's the client that is asking for this test
    /// </summary>
    /// ---------------------------------------
    public enum Client
    {
        /// <summary></summary>
        NoneSet,
        /// <summary></summary>
        ActiveContentWizard,
        /// <summary></summary>
        Hoolie,
        /// <summary></summary>
        ATG,
        /// <summary></summary>
        Narrator,
        /// <summary></summary>
        ScreenReader
    }

    /// ---------------------------------------
    /// <summary>
    /// States the status of a test
    /// </summary>
    /// ---------------------------------------
    public enum TestStatus
    {
        /// <summary>Test works</summary>
        Works = 1,
        /// <summary>Under development</summary>
        WorkingOn = 2,
        /// <summary>Problem with the test</summary>
        Problem = 3,
        /// <summary>Bug entered on the test</summary>
        BugEntered = 4,
        /// <summary>Test is blocked</summary>
        Blocked = 5,
        /// <summary>Test ready to be checked into Wtt</summary>
        ReadyToAddToWtt = 6,
        /// <summary>Test is covered in another test</summary>
        CoveredInOtherTest,
    }

    /// ------------------------------------------------------------------------
    /// <summary></summary>
    /// ------------------------------------------------------------------------
    public enum CheckType
    {
        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        IncorrectElementConfiguration,
        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        Verification,
        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        InformationalException,
        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        Warning,
        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        KnownProductIssue
        
    }

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Identify provider being used
    /// </summary>
    /// -----------------------------------------------------------------------
    public enum TypeOfProvider
    {
        /// <summary>Win32 Proxy</summary>
        Win32,
        /// <summary>Avalon Proxy</summary>
        Avalon,
        /// <summary>DUI Proxy</summary>
        DUI,
        /// <summary>MSAA Proxy</summary>
        MSAA,
        /// <summary>Unknown Proxy (will default to Win32)</summary>
        Unknown
    };

    /// <summary>
    /// This is the custom attribues on each test cases
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Struct, AllowMultiple = true)]
    public sealed class TestCaseAttribute : Attribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="TestName"></param>
        public TestCaseAttribute(string TestName)
        {
            _testName = TestName;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public TestCaseAttribute()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="TestName"></param>
        /// <param name="priority"></param>
        /// <param name="TestStatus"></param>
        /// <param name="Author"></param>
        /// <param name="Description"></param>
        public TestCaseAttribute(string TestName, TestPriorities priority, TestStatus TestStatus, string Author, string[] Description)
        {
            _testName = TestName;
            status = TestStatus;
            _description = Description;
            priority = Priority;
            _author = Author;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="TestSummary"></param>
        /// <param name="TestName"></param>
        /// <param name="priority"></param>
        /// <param name="TestStatus"></param>
        /// <param name="Author"></param>
        /// <param name="Description"></param>
        public TestCaseAttribute(string testSummary, string testName, TestPriorities _priority, TestStatus TestStatus, string Author, string[] Description)
        {
            _testSummary = testSummary;
            _testName = testName;
            Status = TestStatus;
            _description = Description;
            _priority = Priority;
            _author = Author;
        }

        string _testSummary = string.Empty;

        string _testName = string.Empty;

        string _author = string.Empty;

        TestStatus status = TestStatus.WorkingOn;

        TestPriorities priority = TestPriorities.Pri0;

        string[] _description = new string[] { "Empty" };

        string problemDescription = string.Empty;

        string eventTested = null;

        TestCaseType testCaseType = TestCaseType.Generic;

        Client client = Client.ATG;

        string _UISpyLookName =  string.Empty;

        int _wttJob = 0;

        /// -------------------------------------------------------------------
        /// <summary>Wtt JobID</summary>
        /// -------------------------------------------------------------------
        public int WttJob
        {
            get { return _wttJob; }
            set { _wttJob = value; }
        }

        /// -------------------------------------------------------------------
        /// <summary>String generated by Libary.GetUISpyLook</summary>
        /// -------------------------------------------------------------------
        public string UISpyLookName
        {
            get { return _UISpyLookName; }
            set { _UISpyLookName = value; }
        }

        /// <summary>
        /// Summary of what the test does
        /// </summary>
        /// <value></value>
        public string TestSummary { set { _testSummary = value; } get { return _testSummary; } }

        /// <summary>
        /// Name of the test
        /// </summary>
        /// <value></value>
        public string TestName { set { _testName = value; } get { return _testName; } }

        /// <summary>
        /// Author of the test
        /// </summary>
        /// <value></value>
        public string Author { set { _author = value; } get { return _author; } }

        /// <summary>
        /// Status of the test
        /// </summary>
        /// <value></value>
        public TestStatus Status { set { status = value; } get { return status; } }

        /// <summary>
        /// Priority of the test
        /// </summary>
        /// <value></value>
        public TestPriorities Priority { set { priority = value; } get { return priority; } }

        /// <summary>
        /// Instructions that the test willl execute
        /// </summary>
        public string[] Description { set { _description = value; } get { return _description; } }

        /// <summary>
        /// Description if the test has any problems
        /// </summary>
        public string ProblemDescription { set { problemDescription = value; } get { return problemDescription; } }

        /// <summary>
        /// Type of test
        /// </summary>
        public TestCaseType TestCaseType 
        { 
            set 
            {
                // Scenarios are explicitly called so should not 
                // have any other TestCaseType associated with them.
                // Anything other and we want to make sure we | it 
                // with the default TestCaseType.Generic
                if (TestCaseType == TestCaseType.Scenario)
                    testCaseType = value;
                else
                    testCaseType |= value;
            } 
            get { return testCaseType; } }

        /// <summary>
        /// Used for reporting when TestCaseType = Events
        /// </summary>
        /// <value></value>
        public string EventTested { set { eventTested = value; } get { return eventTested; } }

        /// <summary>
        /// Client associated with the test
        /// </summary>
        /// <value></value>
        public Client Client { set { client = value; } get { return client; } }

    }
}
