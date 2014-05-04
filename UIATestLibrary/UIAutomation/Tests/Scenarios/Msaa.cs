// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.CodeDom;
using System.Collections;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Automation;
using System.Windows;

namespace Microsoft.Test.UIAutomation.Tests.Scenarios
{
    using InternalHelper.Enumerations;
    using InternalHelper.Tests;
    using Microsoft.Test.UIAutomation;
    using Microsoft.Test.UIAutomation.Core;
    using Microsoft.Test.UIAutomation.Interfaces;
    using Microsoft.Test.UIAutomation.TestManager;

    /// -----------------------------------------------------------------------
    /// <summary></summary>
    /// -----------------------------------------------------------------------
    public class MsaaScenarioTests : ScenarioObject
    {
        const string THIS = "MsaaScenarioTests";

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public const string TestSuite = NAMESPACE + "." + THIS;

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        ArrayList _errorList;

        /// -------------------------------------------------------------------
        /// <summary>
        /// </summary>
        /// -------------------------------------------------------------------
        public MsaaScenarioTests(AutomationElement element, string testSuite, TestPriorities priority, TypeOfControl typeOfControl, TypeOfPattern typeOfPattern, string dirResults, bool testEvents, IApplicationCommands commands)
            :
            base(element, testSuite, priority, TypeOfControl.UnknownControl, TypeOfPattern.Unknown, null, testEvents, commands)
        {
        }

        #region Scenarios

        /// -------------------------------------------------------------------
        /// <summary>
        /// Starting point for tests (template)
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("MSAA.1",
            TestSummary = "Enumerate through the element and chilren and get ",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
            TestCaseType = TestCaseType.Scenario,
           Client = Client.ATG,
           Description = new string[] {
                "Step: empty test case", 
        })]
        public void MsaaScenario1(TestCaseAttribute testCase)
        {
            HeaderComment(testCase);
            _errorList = new ArrayList();
            GetProperties(m_le, true, false, "1");
            if (_errorList.Count != 0)
            {
                string error = "";
                foreach (string s in _errorList)
                    error += s + "\n";

                ThrowMe(CheckType.Verification, error);
            }
        }

        #endregion Scenarios

        #region Tests



        #endregion Tests

        #region Supporting code

        #endregion Supporting code

        void CacheError(Exception error, string action, string level)
        {
            string errorStr = level + ":Calling element.GetCurrentPropertyValue(" + action + ")";
            errorStr += error.Message + "\n";
            errorStr += error.StackTrace + "\n";
            _errorList.Add(errorStr);
        }
        private void GetProperties(AutomationElement element, bool recurseChildren, bool recurseFirstSiblings, string level)
        {
            if (element == null)
                return;

            if (element.Current.Name == "Desktop")
                Console.WriteLine("");

            Comment("----------------------------------------------------------------");
            Comment("Path : " + Library.GetUISpyLook(element));
            try
            {
                foreach (AutomationProperty property in element.GetSupportedProperties())
                {
                    try
                    {
                        Comment(level + " : " + property.ToString() + " : " + element.GetCurrentPropertyValue(property));
                    }
                    catch (Exception error)
                    {
                        CacheError(error, property.ToString(), level);
                    }
                }
            }
            catch (Exception error)
            {
                CacheError(error, "GetSupportedProperties", level);
            }

            try
            {
                // Don't do any console windows since it my be ourself and it's output 
                // which will be recursive in output.  I know this might nnot be correct, 
                // as it might be another console window.
                if (element.Current.ClassName != "ConsoleWindowClass")
                    GetProperties(TreeWalker.ControlViewWalker.GetFirstChild(element), recurseChildren, true, level + ".1");
            }
            catch (Exception error)
            {
                CacheError(error, "GetFirstChild", level);
            }

            if (recurseFirstSiblings)
            {

                int iloc = level.LastIndexOf('.');
                if (iloc < 1)
                    return; // we are at the end
                string after = level.Substring(iloc + 1);
                string before = level.Substring(0, iloc);

                int t = Convert.ToInt16(after);
                t++;
                level = before + "." + t.ToString();

                try
                {
                    this.GetProperties(TreeWalker.ControlViewWalker.GetNextSibling(element), recurseFirstSiblings, true, level);
                }
                catch (Exception error)
                {
                    CacheError(error, "GetNextSibling", level);
                }

            }
        }
    }
}