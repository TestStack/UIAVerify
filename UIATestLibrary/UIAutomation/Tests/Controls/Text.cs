// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Windows.Automation;
using System.Collections;

namespace Microsoft.Test.UIAutomation.Tests.Controls
{
	using InternalHelper;
	using InternalHelper.Tests;
	using InternalHelper.Enumerations;
	using Microsoft.Test.UIAutomation;
	using Microsoft.Test.UIAutomation.Core;
	using Microsoft.Test.UIAutomation.TestManager;
	using Microsoft.Test.UIAutomation.Interfaces;

	/// -----------------------------------------------------------------------
	/// <summary></summary>
	/// -----------------------------------------------------------------------
	public sealed class TextControlTests : ControlObject
    {
		/// -------------------------------------------------------------------
		/// <summary></summary>
		/// -------------------------------------------------------------------
		const string THIS = "TextControlTests";

		/// -------------------------------------------------------------------
		/// <summary></summary>
		/// -------------------------------------------------------------------
		public const string TestSuite = NAMESPACE + "." + THIS;

		/// -------------------------------------------------------------------
		/// <summary></summary>
		/// -------------------------------------------------------------------
		public TextControlTests(AutomationElement element, TestPriorities priority, string dirResults, bool testEvents, IApplicationCommands commands)
            :
        base(element, TestSuite, priority, TypeOfControl.TextControl, dirResults, testEvents, commands)
        {
        }

        #region Test Cases called by TestObject.RunTests()

        /// ---------------------------------------------------------------
        ///<summary></summary>
        /// ---------------------------------------------------------------
        [TestCaseAttribute("Static.LabeledBy",
           TestSummary = "If the control is a static control, verify that it does not have a valid LabeledBy property.",
            TestCaseType = TestCaseType.Generic,
            Priority = TestPriorities.Pri2,
            Status = TestStatus.Works,
            Description = new string[] 
                {
                    "Precondition: Classname is 'Static'",
                    "Verify: LabeledBy == null",
                })]
        public void StaticsDontHaveLabels(TestCaseAttribute testCaseAttribute)
        {
            HeaderComment(testCaseAttribute);

            //"Precondition: Classname is 'Static'",
            TSC_VerifyPropertyEqual(m_le.Current.ClassName.ToLower(), "static", AutomationElement.ClassNameProperty, CheckType.IncorrectElementConfiguration);

            //"Verify: LabeledBy == null",
            TSC_VerifyPropertyEqual(m_le.Current.LabeledBy, null, AutomationElement.LabeledByProperty, CheckType.Verification);

        }
        /// ---------------------------------------------------------------
        ///<summary></summary>
        /// ---------------------------------------------------------------
        [TestCaseAttribute("IsTextPatternAvailableProperty.1",
           TestSummary = "Depends on framework whether TextPattern will be supported on text elements.  For Avalon elements TextPattern will be supported.  For legacy text elements it will not be able to be supported.  Any new framework supporting UIAutomation must expose TextPattern for text elements.",
            TestCaseType = TestCaseType.Generic,
            Priority = TestPriorities.Pri1,
            Status = TestStatus.Works,
            Description = new string[] 
                {
                    "Precondition: AutomationElement has a valid hwnd",
                    "Precondition: FrameworkID = Win32",
                    "Verification: AutomationElement.IsTextPatternAvailableProperty == false",
                })]
        public void IsTextPatternAvailableProperty1(TestCaseAttribute testCaseAttribute)
        {
            HeaderComment(testCaseAttribute);

            // "Precondition: Element has a valid hwnd",
            TSC_VerifyProperty(m_le.Current.NativeWindowHandle, 0, false, AutomationElement.NativeWindowHandleProperty, CheckType.IncorrectElementConfiguration);

            // "Verification: HelpTextProeprty != null",
            TSC_VerifyProperty(m_le.Current.FrameworkId, "Win32", true, AutomationElement.FrameworkIdProperty, CheckType.IncorrectElementConfiguration);

            // "Verification: HelpTextProeprty != \"\"",
            TSC_VerifyPropertyEqual((bool)m_le.GetCurrentPropertyValue(AutomationElement.IsTextPatternAvailableProperty), false, AutomationElement.IsTextPatternAvailableProperty, CheckType.Verification);
        }

        /// ---------------------------------------------------------------
        ///<summary></summary>
        /// ---------------------------------------------------------------
        [TestCaseAttribute("IsTextPatternAvailableProperty.2",
           TestSummary = "Depends on framework whether TextPattern will be supported on text elements.  For Avalon elements TextPattern will be supported.  For legacy text elements it will not be able to be supported.  Any new framework supporting UIAutomation must expose TextPattern for text elements.",
            TestCaseType = TestCaseType.Generic,
            Priority = TestPriorities.Pri1,
            Status = TestStatus.Works,
            Description = new string[] 
                {
                    "Precondition: AutomationElement has a valid hwnd",
                    "Precondition: FrameworkID != Win32",
                    "Verification: AutomationElement.IsTextPatternAvailableProperty == true",
                })]
        public void IsTextPatternAvailableProperty2(TestCaseAttribute testCaseAttribute)
        {
            HeaderComment(testCaseAttribute);

            // "Precondition: Element has a valid hwnd",
            TSC_VerifyProperty(m_le.Current.NativeWindowHandle, 0, false, AutomationElement.NativeWindowHandleProperty, CheckType.IncorrectElementConfiguration);

            // "Verification: HelpTextProeprty != null",
            TSC_VerifyProperty(m_le.Current.FrameworkId, "Win32", false, AutomationElement.FrameworkIdProperty, CheckType.IncorrectElementConfiguration);

            // "Verification: HelpTextProeprty != \"\"",
            TSC_VerifyPropertyEqual((bool)m_le.GetCurrentPropertyValue(AutomationElement.IsTextPatternAvailableProperty), false, AutomationElement.IsTextPatternAvailableProperty, CheckType.Verification);
        }


        #endregion Test Cases called by TestObject.RunTests()

        #region Misc
        #endregion Misc
    }
}