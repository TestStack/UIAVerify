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
	public sealed class MenuItemControlTests : ControlObject
    {
		/// -------------------------------------------------------------------
		/// <summary></summary>
		/// -------------------------------------------------------------------
		const string THIS = "MenuItemControlTests";

		/// -------------------------------------------------------------------
		/// <summary></summary>
		/// -------------------------------------------------------------------
		public const string TestSuite = NAMESPACE + "." + THIS;

		/// -------------------------------------------------------------------
		/// <summary></summary>
		/// -------------------------------------------------------------------
		public MenuItemControlTests(AutomationElement element, TestPriorities priority, string dirResults, bool testEvents, IApplicationCommands commands)
            :
        base(element, TestSuite, priority, TypeOfControl.MenuItemControl, dirResults, testEvents, commands)
        {
        }

        #region Test Cases called by TestObject.RunTests()

        /// ---------------------------------------------------------------
        ///<summary></summary>
        /// ---------------------------------------------------------------
        [TestCaseAttribute("AccessKey.One.Character",
           TestSummary = "Access keys should only be one character in length",
            TestCaseType = TestCaseType.Generic,
            Priority = TestPriorities.Pri2,
            Status = TestStatus.Works,
            Description = new string[] 
                {
                    "Precondition: There is an access key character",
                    "Verify: AccessKey length must be one character in length",
                })]
        public void AccessOneCharacter(TestCaseAttribute testCaseAttribute)
        {
            HeaderComment(testCaseAttribute);

            //"Precondition: There is an access key character",
            TSC_VerifyProperty(m_le.Current.AccessKey.Length, 0, false, AutomationElement.AcceleratorKeyProperty, CheckType.IncorrectElementConfiguration);

            //"Verify: AccessKey length must be one character in length",
            TSC_VerifyProperty(m_le.Current.AccessKey.Length, 1, true, AutomationElement.AcceleratorKeyProperty, CheckType.Verification);

        }

        #endregion Test Cases called by TestObject.RunTests()

        #region Misc
        #endregion Misc
    }
}