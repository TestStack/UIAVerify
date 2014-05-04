//---------------------------------------------------------------------------
//
// <copyright file="AutomationTestManager" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Definition on automation tests manager class.
//
//
// History:  
//  09/18/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using VisualUIAVerify.Forms;
using VisualUIAVerify.Misc;
using System.Windows.Automation;
using System.Diagnostics;
using System.Reflection;

namespace VisualUIAVerify.Features
{
    using Microsoft.Test.UIAutomation;
    using Microsoft.Test.UIAutomation.Logging;
    using Microsoft.Test.UIAutomation.Interfaces;
    //using WUIATestLibrary.Logging.Xml;

    /// <summary>
    /// definition of all possible test results.
    /// </summary>
    enum TestResults
    {
        ReadyToRun,
        Succeed,
        Failed,
        UnexpectedError
    }

    /// <summary>
    /// This class is Controller Design-Pattern class which is responsible for running tests.
    /// </summary>
    class AutomationTestManager : IDisposable
    {
        /// <summary>
        /// this Method will run automationTests for automationElement
        /// </summary>
        public static void RunTest(IEnumerable<AutomationTest> automationTests, AutomationElement automationElement, bool TestEvents, IWin32Window parentWindow)
        {
            using (AutomationTestManager manager = new AutomationTestManager(TestEvents, false))
            {
                RunTestInternal(automationTests, automationElement, parentWindow, manager);
            }
        }

        /// <summary>
        /// this method will run all automationTests on automationElement and all its children.
        /// </summary>
        public static void RunTestOnAllChildren(IEnumerable<AutomationTest> automationTests, AutomationElement automationElement, bool TestEvents, IWin32Window parentWindow)
        {
            using (AutomationTestManager manager = new AutomationTestManager(TestEvents, true))
            {
                //((MainWindow)parentWindow).
                RunTestInternal(automationTests, automationElement, parentWindow, manager);
            }
        }

        private static void RunTestInternal(IEnumerable<AutomationTest> automationTests, AutomationElement element, IWin32Window parentWindow, AutomationTestManager manager)
        {
            //create window
            RunningTestsWindow testWindow = new RunningTestsWindow();

            if (manager._testChildren)
            {
                //// Determine if this is a control/pattern/Automation test
                //// Construct the PropertyCondition
                Condition condition = null;

                //// Add all the tests
                foreach (AutomationTest test in automationTests)
                {

                    // The tests are within a class the defines what pattern type this in is
                    StringBuilder buffer = new StringBuilder(((MainWindow)parentWindow)._automationTests._testsTreeView.SelectedNode.FullPath);
                    switch (test.Type)
                    {
                        case TestTypes.AutomationElementTest:
                            // Tests\Automation Element Tests\Priority 2 Tests\AutomationElement.PropertyChange.Enabled.1
                            condition = Condition.TrueCondition;
                            break;
                        case TestTypes.ControlTest:
                            {
                                // Tests\Control Tests\Slider\Priority 1 Tests\BulkAdd.1
                                buffer.Replace(@"Tests\Control Tests\", "");
                                int indexOf = buffer.ToString().IndexOf(@"\");
                                buffer.Remove(indexOf, buffer.Length - indexOf);
                                condition = new PropertyCondition(AutomationElement.ControlTypeProperty, GetControlType(buffer.ToString()));
                            }
                            break;
                        case TestTypes.PatternTest:
                            {
                                // Tests\Pattern Tests\Grid\Priority 1 Tests\GridPattern.S.1.1/2/3
                                buffer.Replace(@"Tests\Pattern Tests\", "");
                                int indexOf = buffer.ToString().IndexOf(@"\");
                                buffer.Remove(indexOf, buffer.Length - indexOf);
                                condition = new PropertyCondition(GetProperty("Is" + buffer.ToString() + "PatternAvailableProperty"), true);
                            }
                            break;
                        default:
                            throw new ArgumentException("Cannot run " + test.Type + " tests");

                    }
                    //// Find all elements
                    AutomationElementCollection collection = element.FindAll(TreeScope.Subtree, condition);
                    foreach (AutomationElement temp in collection)
                        testWindow.AddTest(test, temp);
                }

            }
            else
            {
                //add all tests
                foreach (AutomationTest test in automationTests)
                    testWindow.AddTest(test, element);
            }
            //let them run
            testWindow.ShowAndRunTests(manager, parentWindow);
        }

        static AutomationProperty GetProperty(string name)
        {
            Assembly assembly = Assembly.GetEntryAssembly();

            foreach (FieldInfo fieldInfo in typeof(AutomationElement).GetFields())
            {
                if (((MemberInfo)(fieldInfo)).Name == name)
                    return (AutomationProperty)fieldInfo.GetValue(null);
            }

            return null;
        }
        static ControlType GetControlType(string name)
        {
            Assembly assembly = Assembly.GetEntryAssembly();

            foreach (FieldInfo fieldInfo in typeof(ControlType).GetFields())
            {
                if (((MemberInfo)(fieldInfo)).Name == name)
                    return (ControlType)fieldInfo.GetValue(null);
            }

            return null;
        }

        /// <summary>
        /// indicating if this we should tests events
        /// </summary>
        private bool _testEvents;

        /// <summary>
        /// indicating if log is assigned
        /// </summary>
        private bool _logAssigned;

        private bool _testChildren;

        /// <summary>
        /// initilizes new instance
        /// </summary>
        private AutomationTestManager(bool TestEvents, bool TestChildren)
        {
            this._testEvents = TestEvents;
            this._testChildren = TestChildren;

            SetLogger();
            ClearTestRunLog();
        }

        /// <summary>
        /// this method performs automation test on automation element.
        /// </summary>
        public TestResults PerformTest(AutomationTest test, AutomationElement element)
        {
            try
            {
                bool result = false;
                switch (test.Type)
                {
                    case TestTypes.AutomationElementTest:
                        {
                            if(!this._testChildren)
                                result = TestRuns.RunAutomationElementTest(element, this._testEvents, GetTestName(test), false, null, true, GetFakeApplicationCommands());
                            else
                                result = TestRuns.RunAutomationElementTests(element, this._testEvents, test.TestCaseAttribute.Priority, test.TestCaseAttribute.TestCaseType, this._testChildren, true, GetFakeApplicationCommands());
                            break;
                        }
                    case TestTypes.ControlTest:
                        {
                            if (!this._testChildren)
                                result = TestRuns.RunControlTest(element, this._testEvents, GetTestSuite(test), GetTestName(test), null, GetFakeApplicationCommands());
                            else
                                result = TestRuns.RunControlTests(element, this._testEvents, this._testChildren, test.TestCaseAttribute.Priority, test.TestCaseAttribute.TestCaseType, GetFakeApplicationCommands());
                            break;
                        }
                    case TestTypes.PatternTest:
                        {
                            if (!this._testChildren)
                                result = TestRuns.RunPatternTest(element, this._testEvents, false, GetTestSuite(test), GetTestName(test), null, GetFakeApplicationCommands());
                            else
                                result = TestRuns.RunPatternTests(element, this._testEvents, this._testChildren, GetTestSuite(test), test.TestCaseAttribute.TestCaseType, GetFakeApplicationCommands());
                            break;
                        }
                    //case TestTypes.ScenarioTest:
                    //    {
                    //        if (!this._testChildren)
                    //            result = TestRuns.RunScenarioTest(GetTestSuite(test), GetTestName(test), null, this._testEvents, GetFakeApplicationCommands());

                    //        break;
                    //    }
                    default:
                        throw new ArgumentException("not supported test type! test.Type = " + test.Type.ToString() );
                }
                return (result ? TestResults.Succeed : TestResults.Failed);
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogException(ex);
                return TestResults.UnexpectedError; 
            }
        }

        /// <summary>
        /// returns name for the test
        /// </summary>
        private string GetTestName(AutomationTest test)
        {
            return test.Name;
        }

        /// <summary>
        /// returns test suite for the test
        /// </summary>
        private string GetTestSuite(AutomationTest test)
        {
            return test.Method.ReflectedType.FullName;
        }

        /// <summary>
        /// returns fake application command. We are not going to use them
        /// </summary>
        private IApplicationCommands GetFakeApplicationCommands()
        {
            return null;
        }

        /// <summary>
        /// opens the log
        /// </summary>
        private void SetLogger()
        {
            if (!this._logAssigned)
            {
                UIVerifyLogger.SetLogger(new XmlLogger());
                this._logAssigned = true;
            }
        }

        /// <summary>
        /// clears the log
        /// </summary>
        private void ClearTestRunLog()
        {
            XmlLog.ClearTestRunLog();
        }

        #region IDisposable Members

        /// <summary>
        /// this method disposes this testManager instance (closes the log).
        /// </summary>
        public void Dispose()
        {
            //some code to clean up
        }

        #endregion
    }
}
