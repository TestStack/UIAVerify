// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Automation;
using System.Collections;
using System.Drawing;
using System.CodeDom;
using System.Text;
using System.Threading;

// This suppresses warnings #'s not recognized by the compiler.
#pragma warning disable 1634, 1691

namespace InternalHelper.Tests
{
    using InternalHelper.Enumerations;
    using Microsoft.Test.UIAutomation;
    using Microsoft.Test.UIAutomation.Interfaces;
	using Microsoft.Test.UIAutomation.TestManager;

    /// -----------------------------------------------------------------------
    /// <summary></summary>
    /// -----------------------------------------------------------------------
    public class ScenarioObject : TestObject
    {
		internal const string NAMESPACE = IDSStrings.IDS_NAMESPACE_UIVERIFY + "." + IDSStrings.IDS_NAPESPACE_SCENARIO;

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public ScenarioObject(AutomationElement element, string testSuite, TestPriorities priority, TypeOfControl typeOfControl, TypeOfPattern typeOfPattern, string dirResults, bool testEvents, IApplicationCommands commands)
            :
		base (element, testSuite, priority, typeOfControl, typeOfPattern, dirResults, testEvents, commands)
        {
            _testCaseSampleType = TestCaseSampleType.Scenario;
		}
	}
}
