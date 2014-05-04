// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Windows.Automation;
using System.Windows;
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
    public sealed class TitleBarControlTests : ControlObject
    {
        const string THIS = "TitleBarControlTests";

        /// <summary></summary>
        public const string TestSuite = NAMESPACE + "." + THIS;

        public TitleBarControlTests(AutomationElement element, TestPriorities priority, string dirResults, bool testEvents, IApplicationCommands commands)
            :
        base(element, TestSuite, priority, TypeOfControl.TitleBarControl, dirResults, testEvents, commands)
        {
        }

        #region Test Cases called by TestObject.RunTests()
        [TestCaseAttribute("GetBoundingRect.1",
            TestSummary = "Verify that the immediate children return actual BoundingRectangles and are withing the parents BoundingRectangle",
            Priority = TestPriorities.Pri1,
            TestCaseType = TestCaseType.Generic,
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Verify: BoundingRect of all the children of the titlebar are within the parent, and that all BoundingRectangles Width and Hieght are not zero",
			})]
        public void GetBoundingRect1(TestCaseAttribute testAttribute)
        {
            HeaderComment(testAttribute);
            Rect rect;
            Rect parentRect = m_le.Current.BoundingRectangle;

            if (!m_le.Current.IsOffscreen)
            {
                if (parentRect.Width == 0)
                    ThrowMe(CheckType.Verification, "TitleBar Width cannot be zero");

                if (parentRect.Height == 0)
                    ThrowMe(CheckType.Verification, "TitleBar Height cannot be zero");
            }

            foreach (AutomationElement child in m_le.FindAll(TreeScope.Subtree, Condition.TrueCondition))
            {
                rect = child.Current.BoundingRectangle;

                if (rect.Width == 0)
                    ThrowMe(CheckType.Verification, "{0}'s Width cannot be zero", child.Current.Name);

                if (rect.Height == 0)
                    ThrowMe(CheckType.Verification, "{0}'s Height cannot be zero", child.Current.Name);

                if (Rect.Intersect(parentRect, rect) != rect)
                    ThrowMe(CheckType.Verification, "{0}'s BoundingRectangle is not within the parents BoundingRectangle", child.Current.Name);
            }
            
            m_TestStep++;

        }
        #endregion Test Cases called by TestObject.RunTests()

        #region Misc
        #endregion Misc
    }
}