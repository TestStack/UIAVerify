// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.CodeDom;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Windows.Automation;
using System.Windows;
using Drawing = System.Drawing;

namespace InternalHelper.Tests.Patterns
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
    public class TogglePatternWrapper : PatternObject
    {
        #region Variables

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        TogglePattern _pattern = null;

        #endregion

        #region Constructor

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        protected TogglePatternWrapper(AutomationElement element, string testSuite, TestPriorities priority, TypeOfControl typeOfControl, TypeOfPattern typeOfPattern, string dirResults, bool testEvents, IApplicationCommands commands)
            :
            base(element, testSuite, priority, typeOfControl, typeOfPattern, dirResults, testEvents, commands)
        {
            _pattern = (TogglePattern)element.GetCurrentPattern(TogglePattern.Pattern);

            if (_pattern == null)
                throw new Exception("TogglePattern: " + Helpers.PatternNotSupported);
        }

        #endregion

        #region Properties

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        internal ToggleState pToggleState
        {
            get
            {
                ToggleState ts = _pattern.Current.ToggleState;
                Comment("Current ToggleState == " + ts);
                return ts;
            }
        }

        #endregion Properties

        #region Methods

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        internal void patternToggle(Type expectedException, CheckType checkType)
        {
            string call = "Toggle()";
            try
            {
                _pattern.Toggle();
            }
            catch (Exception actualException)
            {
                if (Library.IsCriticalException(actualException))
                    throw;

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
    public sealed class ToggleTests : TogglePatternWrapper
    {
        #region InternalHelper Generic code common to all patterns/controls

        #region Member variables

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        const string THIS = "ToggleTests";

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public const string TestSuite = NAMESPACE + "." + THIS;

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public static readonly string TestWhichPattern = Automation.PatternName(TogglePattern.Pattern);

        #endregion Member variables

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        public ToggleTests(AutomationElement element, TestPriorities priority, string dirResults, bool testEvents, TypeOfControl typeOfControl, IApplicationCommands commands)
            :
            base(element, TestSuite, priority, typeOfControl, TypeOfPattern.Toggle, dirResults, testEvents, commands)
        {
        }

        #endregion InternalHelper Generic code common to all patterns/controls

        #region Toggle Method

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("Toggle.1.1",
            TestSummary = "Toggle to the next state when ToggleStateProperty == ToggleStateProperty.On",
            TestCaseType = TestCaseType.Events,
            EventTested = "AutomationPropertyChangedEventHandler(TogglePattern.ToggleStateProperty)",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: ToggleStateProperty == On",
                "Precondition: SetFocus to the element",
                "Step: Setup a StateProperty PropertyChange event", 
                "Step: Successful call TogglePattern.Toggle()", 
                "Step: Wait for 1 event to occur",
                "Verify: The StateProperty PropertyChange event is fired", 
                "Verify: The StateProperty has changed",
                "Cleanup: Call Toggle() until ToggleStateProperty == original state(On)"
        })]
        public void Toggle11(TestCaseAttribute testCase)
        {
            try
            {
                HeaderComment(testCase);
                TestToggle1(ToggleState.On, EventFired.True, false);
            }
            catch (Exception e)
            {
                throw e; /* amd64fre does not include this function (1st called in assembly?) in the trace unless we do this */
            }
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("Toggle.1.2",
            TestSummary = "Toggle to the next state when ToggleStateProperty == Off",
            TestCaseType = TestCaseType.Events,
            EventTested = "AutomationPropertyChangedEventHandler(TogglePattern.ToggleStateProperty)",
            Priority = TestPriorities.Pri1,
            Status = TestStatus.Problem,
            ProblemDescription = "Radio buttons have an issue if the value is On",
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: ToggleStateProperty == Off",
                "Precondition: SetFocus to the element",
                "Step: Setup a StateProperty PropertyChange event", 
                "Step: Successful call TogglePattern.Toggle()", 
                "Step: Wait for 1 event to occur",
                "Verify: The StateProperty PropertyChange event is fired", 
                "Verify: The StateProperty has changed",
                "Cleanup: Call Toggle() until ToggleStateProperty == original state(Off)"
        })]
        public void Toggle12(TestCaseAttribute testCase)
        {
            try
            {
                HeaderComment(testCase);
                TestToggle1(ToggleState.Off, EventFired.True, false);
            }
            catch (Exception e)
            {
                throw e; /* amd64fre does not include this function (1st called in assembly?) in the trace unless we do this */
            }
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("Toggle.1.3",
            TestSummary = "Toggle to the next state when ToggleState = ToggleState.Indeterminate",
            TestCaseType = TestCaseType.Events,
            EventTested = "AutomationPropertyChangedEventHandler(TogglePattern.ToggleStateProperty)",
            Priority = TestPriorities.Pri1,
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: ToggleStateProperty == Indeterminate",
                "Precondition: SetFocus to the element",
                "Step: Setup a StateProperty PropertyChange event", 
                "Verify: Successful call TogglePattern.Toggle()", 
                "Step: Wait for 1 event to occur",
                "Verify: The StateProperty PropertyChange event is fired", 
                "Verify: The StateProperty has changed",
                "Cleanup: Call Toggle() until ToggleStateProperty == original state(Off)"
        })]
        public void Toggle13(TestCaseAttribute testCase)
        {
            try
            {
                HeaderComment(testCase);
                TestToggle1(ToggleState.Indeterminate, EventFired.True, false);
            }
            catch (Exception e)
            {
                throw e; /* amd64fre does not include this function (1st called in assembly?) in the trace unless we do this */
            }
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("Toggle.1.4",
            TestSummary = "Toggle to the next state when ToggleState = ToggleState.Off using spacebar",
            TestCaseType = TestCaseType.Events,
            EventTested = "AutomationPropertyChangedEventHandler(TogglePattern.ToggleStateProperty)",
            Priority = TestPriorities.Pri1,
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Procendition: ToggleStateProperty == off",
                "Precondition: SetFocus to the element",
                "Step: Setup a StateProperty PropertyChange event", 
                "Step: Press the spacebar to toggle the item", 
                "Step: Wait for 1 event to occur",
                "Verify: The StateProperty PropertyChange event is fired", 
                "Verify: The StateProperty has changed",
                "Cleanup: Call Toggle() until ToggleStateProperty == original state(Off)"
        })]
        public void Toggle14(TestCaseAttribute testCase)
        {
            try
            {
                HeaderComment(testCase);
                TestToggle1(ToggleState.Off, EventFired.True, true);
            }
            catch (Exception e)
            {
                throw e; /* amd64fre does not include this function (1st called in assembly?) in the trace unless we do this */
            }
        }

        #endregion Toggle Method

        #region ToggleState Property

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("ToggleState.2.1",
            TestSummary = "Verify the control is at the ToggleState is as defined by 'argument'",
            TestCaseType = TestCaseType.Arguments | TestCaseType.Events,
            EventTested = "AutomationPropertyChangedEventHandler(TogglePattern.ToggleStateProperty)",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Verify: The element is at the On state", 
        })]
        public void Toggle21(TestCaseAttribute testCase, object[] argument)
        {
            try
            {
                HeaderComment(testCase);

                if (argument == null)
                    throw new ArgumentException();

                if (argument[0] == null)
                    throw new ArgumentException();

                if (argument.Length != 1)
                    throw new ArgumentException();

                // Get the value passed into the test case
                ToggleState expectedValue = (ToggleState)(argument[0]);

                TS_VerifyToggleState(expectedValue, true, CheckType.Verification);
            }
            catch (Exception e)
            {
                throw e; /* amd64fre does not include this function (1st called in assembly?) in the trace unless we do this */
            }
        }

        #endregion ToggleState Property

        #region Tests

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        void TestToggle1(ToggleState expectedState, EventFired eventShouldFire, bool usingKeyboard)
        {
            ToggleState orgState = pToggleState;

            // "Precondition: ToggleStateProperty == expectedState",
            TS_VerifyToggleState(orgState, true, CheckType.IncorrectElementConfiguration);

            // "SetFocus to the element",
            TS_SetFocus(m_le, null, CheckType.IncorrectElementConfiguration);

            //    "Step: Setup a StateProperty PropertyChange event", 
            TSC_AddPropertyChangedListener(m_le, TreeScope.Element, new AutomationProperty[] { TogglePattern.ToggleStateProperty }, CheckType.Verification);

            //    "Verify: Successful call TogglePattern.Toggle()", 
            if (!usingKeyboard)
                TS_Toggle(null, CheckType.Verification);
            else
                TS_PressKeys(true, System.Windows.Input.Key.Space);

            // "Step: Wait for 1 event to occur 
            TSC_WaitForEvents(1);

            // "Verify: The StateProperty PropertyChange event is fired", 
            TSC_VerifyPropertyChangedListener(m_le, new EventFired[] { eventShouldFire }, new AutomationProperty[] { TogglePattern.ToggleStateProperty }, CheckType.Verification);

            // "Verify: The StateProperty has changed",
            TS_VerifyToggleState(orgState, false, CheckType.Verification);

            // "Cleanup: Call Toggle() until ToggleStateProperty == original state(Off)"        
            //TS_ToggleTo(orgState, null, CheckType.Verification);

            m_TestStep++;
        }

        #endregion Tests

        #region TS_

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        void TS_ToggleTo(ToggleState toggleState, Type exceptionExpected, CheckType checkType)
        {
            // I don't know, lets try 5 times max<g>
            const int MAX = 5;

            for (int count = 0; count < MAX; count++)
            {
                patternToggle(exceptionExpected, checkType);
                if (toggleState == pToggleState)
                {
                    m_TestStep++;
                    return;
                }
            }
            ThrowMe(checkType, "Could not set ToggeState == " + toggleState + " in " + MAX + " tries");
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        void TS_Toggle(Type expectedExpection, CheckType checkType)
        {
            patternToggle(expectedExpection, checkType);
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary></summary>
        /// -------------------------------------------------------------------
        void TS_VerifyToggleState(ToggleState state, bool shouldBe, CheckType checkType)
        {
            ToggleState ts = pToggleState;
            if ((ts == state) != shouldBe)
                ThrowMe(checkType, "TogglePattern.ToggleState == " + ts);
            m_TestStep++;
        }

        #endregion TS_
    }
}