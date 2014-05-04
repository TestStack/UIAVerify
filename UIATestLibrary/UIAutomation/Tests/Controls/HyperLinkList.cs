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
	public sealed class HyperLinkListControlTests : ControlObject
    {
        const string THIS = "HyperLinkListControlTests";

        /// <summary></summary>
        public const string TestSuite = NAMESPACE + "." + THIS;

        internal HyperLinkListControlTests(AutomationElement element, TestPriorities priority, string dirResults, bool testEvents, IApplicationCommands commands)
            :
        base(element, TestSuite, priority, TypeOfControl.HyperLinkListControl, dirResults, testEvents, commands)
        {
        }

        #region Test Cases called by TestObject.RunTests()

        #endregion Test Cases called by TestObject.RunTests()

        #region Misc
        #endregion Misc
    }
}