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
using System.Text;
using System.Windows.Automation;
using System.Windows;
using System.Xml;

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
    public class ShellScenarioTests : ScenarioObject
    {
        const string THIS = "ShellScenarioTests";

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public const string TestSuite = NAMESPACE + "." + THIS;

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public ShellScenarioTests(AutomationElement element, string testSuite, TestPriorities priority, TypeOfControl typeOfControl, TypeOfPattern typeOfPattern, string dirResults, bool testEvents, IApplicationCommands commands)
            :
            base(element, testSuite, priority, TypeOfControl.UnknownControl, TypeOfPattern.Unknown, null, testEvents, commands)
        {
        }
    }
}

 