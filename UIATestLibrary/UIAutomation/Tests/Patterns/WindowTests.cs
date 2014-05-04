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

namespace InternalHelper.Tests.Patterns
{
    using InternalHelper;
    using InternalHelper.Tests;
    using InternalHelper.Enumerations;
    using Microsoft.Test.UIAutomation;
    using Microsoft.Test.UIAutomation.Core;
    using Microsoft.Test.UIAutomation.TestManager;
    using Microsoft.Test.UIAutomation.Interfaces;

    enum EventHappened
    {
        Yes,
        No,
        Undetermined
    }

    /// -----------------------------------------------------------------------
    /// <summary></summary>
    /// -----------------------------------------------------------------------
    public class WindowPatternWrapper : PatternObject
    {
        #region Variables
        WindowPattern m_pattern = null;
        #endregion

        #region constructor

        /// <summary></summary>
        protected WindowPatternWrapper(AutomationElement element, string testSuite, TestPriorities priority, TypeOfControl typeOfControl, TypeOfPattern typeOfPattern, string dirResults, bool testEvents, IApplicationCommands commands)
            :
            base(element, testSuite, priority, typeOfControl, typeOfPattern, dirResults, testEvents, commands)
        {
            m_pattern = (WindowPattern)GetPattern(m_le, m_useCurrent, WindowPattern.Pattern);
        }

        #endregion Constructor

        #region Properties

        internal WindowInteractionState pattern_getWindowInteractionState
        {
            get
            {
                if (m_useCurrent == true)
                    return m_pattern.Current.WindowInteractionState;
                else
                    return m_pattern.Cached.WindowInteractionState;
            }
        }

        internal WindowVisualState pattern_getVisualState
        {
            get
            {
                if (m_useCurrent == true)
                    return m_pattern.Current.WindowVisualState;
                else
                    return m_pattern.Cached.WindowVisualState;
            }
        }

        internal bool pattern_getCanMaximize
        {
            get
            {
                if (m_useCurrent == true)
                    return m_pattern.Current.CanMaximize;
                else
                    return m_pattern.Cached.CanMaximize;
            }
        }
        internal bool pattern_getCanMinimize
        {
            get
            {
                if (m_useCurrent)
                    return m_pattern.Current.CanMinimize;
                else
                    return m_pattern.Cached.CanMinimize;
            }
        }

        internal bool pattern_getIsModal
        {
            get
            {
                if (m_useCurrent)
                    return m_pattern.Current.IsModal;
                else
                    return m_pattern.Cached.IsModal;

            }
        }

        #endregion Properties

        #region Methods

        internal void pattern_SetWindowVisualState(WindowVisualState state, Type expectedException, CheckType checkType)
        {
            string call = "SetWindowVisualState(" + state + ")";
            try
            {
                m_pattern.SetWindowVisualState(state);
            }
            catch (Exception actualException)
            {
                TestException(expectedException, actualException, call, checkType);
                return;
            }
            TestNoException(expectedException, call, checkType);
        }

        #endregion Methods

    }
}

namespace Microsoft.Test.UIAutomation.Tests.Patterns
{
    using InternalHelper;
    using InternalHelper.Tests;
    using InternalHelper.Tests.Patterns;
    using InternalHelper.Enumerations;
    using Microsoft.Test.UIAutomation;
    using Microsoft.Test.UIAutomation.Core;
    using Microsoft.Test.UIAutomation.TestManager;
    using Microsoft.Test.UIAutomation.Interfaces;

    /// -----------------------------------------------------------------------
    /// <summary></summary>
    /// -----------------------------------------------------------------------
	public sealed class WindowTests : WindowPatternWrapper
    {
        #region Member variables

        const string THIS = "WindowTests";

        /// <summary></summary>
        public const string TestSuite = NAMESPACE + "." + THIS;

        /// <summary>Defines which UIAutomation Pattern this tests</summary>
        public static readonly string TestWhichPattern = Automation.PatternName(WindowPattern.Pattern);

        #endregion

		/// -------------------------------------------------------------------
		/// <summary></summary>
		/// -------------------------------------------------------------------
		public WindowTests(AutomationElement element, TestPriorities priority, string dirResults, bool testEvents, TypeOfControl typeOfControl, IApplicationCommands commands)
            :
            base(element, TestSuite, priority, typeOfControl, TypeOfPattern.Window, dirResults, testEvents, commands)
        {
        }

        #region WindowPattern.SetWindowState

        //		/// -------------------------------------------------------------------
        //		/// <summary>
        //		/// Verifies that the interaction state is correct
        //		/// </summary>
        //		/// <param name="state"></param>
        //		/// <param name="checkType"></param>
        //		/// -------------------------------------------------------------------
        //		void TS_VerifyInteractionState (int state, CheckType checkType)
        //		{
        //			int good = (int)pattern_getWindowInteractionState & state;
        //			if (!good.Equals(0))
        //			{
        //				m_TestStep++;
        //			}
        //			else
        //			{
        //				ThrowMe ("InteractioState == " + pattern_getWindowInteractionState, checkType);
        //			}
        //		}


        #endregion WindowPattern.SetWindowState

        #region WindowPattern.MaximizableProperty

        ///<summary>TestCase: Window.MaximizableProperty.S.6.1</summary>
        [TestCaseAttribute("Window.MaximizableProperty.S.6.1",
             Priority = TestPriorities.Pri1,
             TestCaseType = TestCaseType.Generic | TestCaseType.Events,
             EventTested = "PropertyChangeEvents",
             Status = TestStatus.Works,
             Author = "Microsoft Corp.",
             Description = new string[]{
                 "Verify that Current.CanMaximize is true",
                 "Verify that Current.CanMinimize is true",
                 "Step: Setup WindowPattern.WindowVisualStateProperty property change event listener",
                 "Step: Set WindowVisualState = WindowVisualState.Minimized",
                 "Wait for WindowVisualState(Minimized) event",
                 "Verify that Current.CanMaximize is true",
                 "Set the WindowVisualState = WindowVisualState.Maximized",
                 "Wait for WindowVisualState(Maximized) to fire",
                 "Verify: WindowPattern.WindowVisualStateProperty property change event was fired",
                 "Verify that the WindowVisualState = WindowVisualState.Maximized after setting the property"
            })]
        public void TestMaximizeS61(TestCaseAttribute testCase)
        {
            HeaderComment(testCase);

            AutomationProperty[] properties = new AutomationProperty [] { WindowPattern.WindowVisualStateProperty };

            // "Verify that Current.CanMaximize is true",
            TSC_VerifyPropertyEqual(pattern_getCanMaximize, true, WindowPattern.CanMaximizeProperty, CheckType.IncorrectElementConfiguration);

            // "Verify that Current.CanMinimize is true",
            TSC_VerifyPropertyEqual(pattern_getCanMinimize, true, WindowPattern.CanMinimizeProperty, CheckType.IncorrectElementConfiguration);

            // "Step: Setup WindowPattern.WindowVisualStateProperty property change event listener",
            TSC_AddPropertyChangedListener(m_le, TreeScope.Element, properties, CheckType.Verification);

            // "Step: Set WindowVisualState = WindowVisualState.Minimized",
            TS_VerifySetVisualState(WindowVisualState.Minimized, null, CheckType.Verification);

            // "Wait for WindowVisualState(Minimized) event",
            TSC_WaitForEvents(1);

            RemoveAllEventsFired();

            // "Verify that Current.CanMaximize is true",
            TSC_VerifyPropertyEqual(pattern_getCanMaximize, true, WindowPattern.CanMaximizeProperty, CheckType.IncorrectElementConfiguration);

            // "Set the WindowVisualState = WindowVisualState.Maximized",
            TS_VerifySetVisualState(WindowVisualState.Maximized, null, CheckType.Verification);

            // "Wait for WindowVisualState(Maximized) to fire",
            TSC_WaitForEvents(1);

            // "Verify: WindowPattern.WindowVisualStateProperty property change event was fired",
            TSC_VerifyPropertyChangedListener(m_le, new EventFired[] { EventFired.True }, properties, CheckType.Verification);

            // "Verify that the WindowVisualState = WindowVisualState.Maximized after setting the property"
            TS_VerifyVisualState(WindowVisualState.Maximized, true, CheckType.Verification);
        }

        ///<summary>TestCase: Window.MaximizableProperty.S.6.2</summary>
        [TestCaseAttribute("Window.MaximizableProperty.S.6.2",
            Priority = TestPriorities.Pri1,
            TestCaseType = TestCaseType.Generic,
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
             Description = new string[]{
											"Precondition: Maximizable property is false",
											"Verify that setting the VisualState property to WindowVisualState.Maximizable returns false",
											"Verify that the WindowVisualState is not WindowVisualState.Maximizable after setting the property"
										}
             )]
        public void TestMaximizeS62(TestCaseAttribute testCase)
        {
            HeaderComment(testCase);
            // "Precondition: Maximizable property is false",
            TSC_VerifyPropertyEqual(pattern_getCanMaximize, false, WindowPattern.CanMaximizeProperty, CheckType.IncorrectElementConfiguration);

            // "Verify that you can set the VisualState property to WindowVisualState.Maximizable",
            TS_VerifySetVisualState(WindowVisualState.Maximized, typeof(InvalidOperationException), CheckType.Verification);

            // "Verify that the WindowVisualState is WindowVisualState.Maximizable after setting the property"
            TS_VerifyVisualState(WindowVisualState.Maximized, false, CheckType.Verification);
        }

        #endregion WindowPattern.MaximizableProperty

        #region WindowPattern.MinimizableProperty

        ///<summary>TestCase: Window.MinimizableProperty.S.7.2</summary>
        [TestCaseAttribute("Window.MinimizableProperty.S.7.2",
            Priority = TestPriorities.Pri1,
            TestCaseType = TestCaseType.Generic,
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
            Description = new string[]{
											"Precondition: Minimizable property is false",
											"Verify that you cannot set the VisualState property to WindowVisualState.Minimized and that SetVisualStats returns false",
											"Verify that the WindowVisualState is not WindowVisualState.MinimizableProperty after setting the VisualState property"
										}
             )]
        public void TestMinimizePropertyS72(TestCaseAttribute testCase)
        {
            HeaderComment(testCase);
            // "Precondition: Minimizable property is false",,
            TSC_VerifyPropertyEqual(pattern_getCanMinimize, false, WindowPattern.CanMinimizeProperty, CheckType.IncorrectElementConfiguration);

            // "Verify that you cannot set the VisualState property to WindowVisualState.Minimizable",
            TS_VerifySetVisualState(WindowVisualState.Minimized, typeof(InvalidOperationException), CheckType.Verification);

            // "Verify that the WindowVisualState is not WindowVisualState.Minimizable after setting the property"
            TS_VerifyVisualState(WindowVisualState.Minimized, false, CheckType.Verification);
        }

        #endregion WindowPattern.MinimizableProperty

        #region WindowPattern.ResizableProperty

        #endregion WindowPattern.ResizableProperty

        #region WindowPattern.ModalProperty

        ///<summary>TestCase: Window.ModalProperty.S.10.1</summary>
        [TestCaseAttribute("Window.ModalProperty.S.10.1",
            Priority = TestPriorities.Pri1,
            TestCaseType = TestCaseType.Generic,
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
            Description = new string[] {
				"Precondition: Modal property is true",
			})]
        public void TestWindowModalS101(TestCaseAttribute testCase)
        {
            HeaderComment(testCase);

            // Precondition: Resizable = false
            TSC_VerifyPropertyEqual(pattern_getIsModal, true, WindowPattern.IsModalProperty, CheckType.IncorrectElementConfiguration);
        }

        #endregion WindowPattern.ModalProperty

        #region Verification

        //        /// -------------------------------------------------------------------
        //        void TS_Minimizable(bool ShouldBeMinimized, CheckType checkType)
        //        {
        //            if (!pattern_getCanMinimize.Equals(ShouldBeMinimized))
        //                ThrowMe("CanMinimize == " + pattern_getCanMinimize, checkType);
        //
        //            m_TestStep++;
        //		}

        /// -------------------------------------------------------------------
        void TS_VerifyVisualState(WindowVisualState WindowVisualState, bool shouldBe, CheckType checkType)
        {
            if (!pattern_getVisualState.Equals(WindowVisualState).Equals(shouldBe))
                ThrowMe(checkType, TestCaseCurrentStep + ": WindowVisualState = " + pattern_getVisualState);

            Comment("WindowVisualState = " + pattern_getWindowInteractionState);
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        void TS_VerifySetVisualState(WindowVisualState WindowVisualState, Type expectedException, CheckType checkType)
        {
            pattern_SetWindowVisualState(WindowVisualState, expectedException, checkType);
            m_TestStep++;
        }


        #endregion Verification

    }
}