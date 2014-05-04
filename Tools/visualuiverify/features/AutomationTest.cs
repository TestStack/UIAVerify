//---------------------------------------------------------------------------
//
// <copyright file="AutomationTest" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Definition of AutomationTest class which is used to encapsulate each automation
//              test.
//
// History:  
//  09/18/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using WUILib=Microsoft.Test.UIAutomation.TestManager;

namespace VisualUIAVerify.Features
{
    /// <summary>
    /// class encapsulating automation test
    /// </summary>
    public class AutomationTest
    {
        /// <summary>
        /// TestCaseAttribute
        /// </summary>
        public readonly WUILib.TestCaseAttribute TestCaseAttribute;

        /// <summary>
        /// Method reflection info.
        /// </summary>
        public readonly MethodInfo Method;

        /// <summary>
        /// TestPriority of this test.
        /// </summary>
        private TestPriorities _testPriority;

        /// <summary>
        /// TestType of this test.
        /// </summary>
        private TestTypes _testType;

        /// <summary>
        /// initializes new instance, extracts test priority and test type
        /// </summary>
        public AutomationTest(WUILib.TestCaseAttribute testCaseAttribute, MethodInfo method)
        {
            this.TestCaseAttribute = testCaseAttribute;
            this.Method = method;

            ReadTestPriority();
            ExtractTestType();
        }

        /// <summary>
        /// initializes new instance with the testPriority and testType
        /// </summary>
        public AutomationTest(AutomationTest originalTest, TestPriorities testPriority, TestTypes testType)
        {
            this.TestCaseAttribute = originalTest.TestCaseAttribute;
            this.Method = originalTest.Method;

            this._testPriority = testPriority;
            this._testType = testType;
        }

        /// <summary>
        /// this method is used for comparison of two instances of automation tests.
        /// Two tests are consideded equal if both are the same method of the same class and there
        /// is assigned the same TestType.
        /// </summary>
        public override bool Equals(object obj)
        {
            AutomationTest test2 = (AutomationTest)obj;

            return this.Method.Name == test2.Method.Name &&
                this.Method.ReflectedType.FullName == test2.Method.ReflectedType.FullName &&
                this._testType == test2._testType;
        }

        /// <summary>
        /// have to override because the compiler warning which is treated as error 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Get Test Priority.
        /// </summary>
        public TestPriorities Priority { get { return this._testPriority; } }

        /// <summary>
        /// Get Test Type
        /// </summary>
        public TestTypes Type { get { return this._testType; } }

        /// <summary>
        /// Get name of the test.
        /// </summary>
        public string Name
        {
            get { return this.TestCaseAttribute.TestName; }
        }

        /// <summary>
        /// This method translates WUILib.TestCaseAttribute.Priority to TestPriority enum value.
        /// </summary>
        private void ReadTestPriority()
        {
            //I have to translate WUILib.TestPriorities to VisulaUIVerify.TestPriorities
            WUILib.TestPriorities wuiLibTestPriority = this.TestCaseAttribute.Priority;
            VisualUIAVerify.TestPriorities vuiTestPriority = TestPriorities.None;

            if ((wuiLibTestPriority & WUILib.TestPriorities.BuildVerificationTest) == WUILib.TestPriorities.BuildVerificationTest)
                vuiTestPriority |= TestPriorities.BuildVerificationTests;

            if ((wuiLibTestPriority & WUILib.TestPriorities.Pri0) == WUILib.TestPriorities.Pri0)
                vuiTestPriority |= TestPriorities.Priority0Tests;

            if ((wuiLibTestPriority & WUILib.TestPriorities.Pri1) == WUILib.TestPriorities.Pri1)
                vuiTestPriority |= TestPriorities.Priority1Tests;

            if ((wuiLibTestPriority & WUILib.TestPriorities.Pri2) == WUILib.TestPriorities.Pri2)
                vuiTestPriority |= TestPriorities.Priority2Tests;

            if ((wuiLibTestPriority & WUILib.TestPriorities.Pri3) == WUILib.TestPriorities.Pri3)
                vuiTestPriority |= TestPriorities.Priority3Tests;

            if ((wuiLibTestPriority & WUILib.TestPriorities.PriAll) == WUILib.TestPriorities.PriAll)
                vuiTestPriority |= TestPriorities.OnlyPriorityAllTests;

            this._testPriority = vuiTestPriority;
        }

        /// <summary>
        /// This method extracts test type of the test.
        /// </summary>
        private void ExtractTestType()
        {
            //we have to use hard-coded names because there is no other way how to get the type

            TestTypes testType = TestTypes.None;

            if (this.Method.ReflectedType.FullName.EndsWith(".AutomationElementTests"))
                testType |= TestTypes.AutomationElementTest;

            if (this.Method.ReflectedType.FullName.Contains(".Tests.Patterns."))
                testType |= TestTypes.PatternTest;
            else if (this.Method.ReflectedType.FullName.Contains(".Tests.Controls."))
                testType |= TestTypes.ControlTest;
            //else if (this.Method.ReflectedType.FullName.Contains(".Tests.Scenarios."))
            //    testType |= TestTypes.ScenarioTest;
            else if (this.Method.ReflectedType.FullName.EndsWith(".Tests.ControlObject"))
                testType |= TestTypes.ControlTest;
            //else
            //    //in debug mode we will notidy user about notsupported test
            //    //in release mode we will ignore this test
            //    Debug.Fail("not supported TestType: " + this.Method.ReflectedType.FullName);

            this._testType = testType;
        }

        /// <summary>
        /// Gets true if the test is ControlType test for ControlTypeName
        /// </summary>
        public bool IsControlTestForControlType(string ControlTypeName)
        {
            if (this._testType != TestTypes.ControlTest || ControlTypeName == null)
                return false;

            return this.Method.ReflectedType.FullName.EndsWith(".Tests.Controls." + ControlTypeName + "ControlTests");
        }

        /// <summary>
        /// Gets true if the test is Pattern test for PatternName
        /// </summary>
        public bool IsPatternTestForSupportedPatterns(string PatternName)
        {
            if (this._testType != TestTypes.PatternTest || PatternName == null)
                return false;

            return this.Method.ReflectedType.FullName.EndsWith(".Tests.Patterns." + PatternName + "Tests");
        }

    }
}