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
	public sealed class SliderControlTests : ControlObject
    {
		/// -------------------------------------------------------------------
		/// <summary></summary>
		/// -------------------------------------------------------------------
		const string THIS = "SliderControlTests";

		/// -------------------------------------------------------------------
		/// <summary></summary>
		/// -------------------------------------------------------------------
		public const string TestSuite = NAMESPACE + "." + THIS;

		/// -------------------------------------------------------------------
		/// <summary></summary>
		/// -------------------------------------------------------------------
		public SliderControlTests(AutomationElement element, TestPriorities priority, string dirResults, bool testEvents, IApplicationCommands commands)
            :
        base(element, TestSuite, priority, TypeOfControl.SliderControl, dirResults, testEvents, commands)
        {
        }

        #region Test Cases called by TestObject.RunTests()
        #endregion Test Cases called by TestObject.RunTests()

        #region Misc
        #endregion Misc
    }
}