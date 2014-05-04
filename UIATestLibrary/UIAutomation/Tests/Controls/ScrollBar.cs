// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Windows.Automation;
using System.Collections;
using System.Windows;           // Need this to for wpf and vista compatability with Rect
using Drawing = System.Drawing; // Need this to for wpf and vista compatability with Rect
using InternalHelper.Tests;

namespace Microsoft.Test.UIAutomation.Tests.Controls
{
    using InternalHelper;
    using InternalHelper.Tests;
    using InternalHelper.Enumerations;
    using Microsoft.Test.UIAutomation;
    using Microsoft.Test.UIAutomation.Core;
    using Microsoft.Test.UIAutomation.TestManager;
    using Microsoft.Test.UIAutomation.Interfaces;
    using MS.Win32;

    /// -----------------------------------------------------------------------
    /// <summary></summary>
    /// -----------------------------------------------------------------------
    public sealed class ScrollBarControlTests : ControlObject
    {
        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        const string THIS = "ScrollBarControlTests";

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public const string TestSuite = NAMESPACE + "." + THIS;

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public ScrollBarControlTests(AutomationElement element, TestPriorities priority, string dirResults, bool testEvents, IApplicationCommands commands)
            :
        base(element, TestSuite, priority, TypeOfControl.ScrollBarControl, dirResults, testEvents, commands)
        {
        }

        #region Test Cases called by TestObject.RunTests()

        /// ---------------------------------------------------------------
        ///<summary></summary>
        /// ---------------------------------------------------------------
        [TestCaseAttribute("Veritical scrollbar layout with Left to Right",
           TestSummary = "Verify that if this is a vertical scroll bar that the layout is correct (not RTL vs. RTL). This test is iffy since you can have different border sizes and sometimes UI can't even see the true parent container",
            TestCaseType = TestCaseType.Generic,
            Priority = TestPriorities.Pri1,
            Status = TestStatus.Works,
            Description = new string[] 
                {
                    "Precondition: This is a vertical scrollbar",
                    "If this is a non Right to Left layout, the bounding rectangle will be on the right side, if Right to Left, bounding rectangle will be on the left side of the parent control",
                })]
        public void Layout1(TestCaseAttribute testCaseAttribute)
        {
            HeaderComment(testCaseAttribute);

            // "Precondition: This is a vertical scrollbar",
            TSC_VerifyPropertyEqual(m_le.GetCurrentPropertyValue(AutomationElement.OrientationProperty), OrientationType.Vertical, AutomationElement.OrientationProperty, CheckType.IncorrectElementConfiguration);

            // "If this is a non Right to Left layout, the bounding rectangle will be on the right side, if Right to Left, bounding rectangle will be on the left side of the parent control",
            TS_VerifyLayout(m_le, CheckType.Verification);
        }

        /// ---------------------------------------------------------------
        ///<summary></summary>
        /// ---------------------------------------------------------------
        [TestCaseAttribute("IsRangeValuePatternAvailableProperty.1",
            TestSummary = "This functionality only is required to be supported on the scroll bar if ScrollPattern is not supported on the container that has the scrollbars.",
            TestCaseType = TestCaseType.Generic,
            Priority = TestPriorities.Pri1,
            Status = TestStatus.Works,
            Description = new string[] 
                {
                    "Precondition: AutomationElement does not have a valid hwnd, ie. this scrollbar is a sub componet",
                    "Precondition: Get the scrollbars parent control",
                    "Precondition: Parent's IsScrollPatternAvailableProperty == false",
                    "Verification: AutomationElement.IsRangeValuePatternAvailableProperty == true"
                })]
        public void IsTextPatternAvailableProperty1(TestCaseAttribute testCaseAttribute)
        {
            HeaderComment(testCaseAttribute);

            AutomationElement parent;

            //"Precondition: AutomationElement does not have a valid hwnd, ie. this scrollbar is a sub componet",
            TSC_VerifyPropertyEqual(m_le.Current.NativeWindowHandle, 0, AutomationElement.NativeWindowHandleProperty, CheckType.IncorrectElementConfiguration);

            //"Precondition: Get the scrollbars parent control",
            TS_GetScrollbarsParent(m_le, out parent, CheckType.IncorrectElementConfiguration);

            //"Precondition: parent.IsScrollPatternAvailableProperty == false",
            TSC_VerifyPropertyEqual(parent.GetCurrentPropertyValue(AutomationElement.IsScrollPatternAvailableProperty), false, AutomationElement.IsScrollPatternAvailableProperty, CheckType.IncorrectElementConfiguration);

            //"Verification: AutomationElement.IsRangeValuePatternAvailableProperty == true"
            TSC_VerifyPropertyEqual((bool)m_le.GetCurrentPropertyValue(AutomationElement.IsRangeValuePatternAvailableProperty), true, AutomationElement.IsRangeValuePatternAvailableProperty, CheckType.Verification);
        }


        #endregion Test Cases called by TestObject.RunTests()

        #region Misc

        /// -------------------------------------------------------------------
        /// <summary>Get the scrollbars parent AutomationElement</summary>
        /// -------------------------------------------------------------------
        private void TS_GetScrollbarsParent(AutomationElement le, out AutomationElement parent, CheckType checkType)
        {
            Helpers.GetParentHwndControl(le, out parent);
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>Verify that the scroll bar is on the correct side of the container</summary>
        /// -------------------------------------------------------------------
        private void TS_VerifyLayout(AutomationElement element, CheckType checkType)
        {
            if ((OrientationType)m_le.GetCurrentPropertyValue(AutomationElement.OrientationProperty) != OrientationType.Vertical)
                ThrowMe(CheckType.IncorrectElementConfiguration, "This test only tests OrientationProperty = OrientationType.Vertical");
            
            bool rtl = IsRightToLeft(element);

            Rect scrollRect = element.Current.BoundingRectangle;

            AutomationElement parent = TreeWalker.ControlViewWalker.GetParent(element);
            Comment("Found the parent of the element to be {0}", Library.GetUISpyLook(parent));

            Rect parentRect = TreeWalker.ControlViewWalker.GetParent(element).Current.BoundingRectangle;
            Comment("Parent Rect is ({0})", parentRect);
            Comment("Controls Rect is ({0})", scrollRect);

            // With client windows, the win32 client window is not always included as a parent automation element, 
            // so you can't tell  just by looking that the scrollbar is right on the border of the window...because 
            // of this for our tests, we can only determine reletively that if this is right to left, there most 
            // likley will be more space on the left side of the scrollbar and the parent window of the scrollbar, 
            // and the other way with left to right.

            double leftSpace = Math.Abs(parentRect.Left - scrollRect.Left);
            double rightSpace = Math.Abs(parentRect.Right - scrollRect.Right);

            Comment("There is {0} points on the left of the scrollbar and {1} points on the right side of the scrollbar in relation to the parented Control", leftSpace, rightSpace);

            if (rtl)
            {
                if (rightSpace < leftSpace)
                    ThrowMe(checkType, "WARNING: Scrollbar's left({0}) is not bumped up to the right side of the container({1}). This test is iffy since you can have different border sizes and sometimes UI can't even see the true parent container.  And sometimes people actually want it on the opposite side", scrollRect.Left, parentRect.Left);
            }
            else
            {
                // Scrollbar should be bumped up to the right side of the container
                if (rightSpace > leftSpace)
                    ThrowMe(checkType, "WARNING: Scrollbar's right({0}) is not bumped up to the right side of the container({1}). This test is iffy since you can have different border sizes and sometimes UI can't even see the true parent container.   And sometimes people actually want it on the opposite side", scrollRect.Right, parentRect.Right);
            }

            m_TestStep++;
        }

        #endregion Misc
    }
}