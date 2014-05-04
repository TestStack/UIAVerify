//---------------------------------------------------------------------------
//
// <copyright file="AutomationTestsFilter" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Classes used for filtering automation tests
//
// History:  
//  09/06/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Automation;
using WUILib=Microsoft.Test.UIAutomation.TestManager;

namespace VisualUIAVerify.Features
{
    /// <summary>
    /// Automation tests filtering base abstract class
    /// </summary>
    abstract class AutomationTestsFilter
    {
        /// <summary>
        /// Method which return TRUE if test fits this filter. Otherwise FALSE.
        /// </summary>
        public abstract bool Fit(AutomationTest test);
    }

    /// <summary>
    /// This filter returns always true.
    /// </summary>
    class NullFilter : AutomationTestsFilter
    {
        public override bool Fit(AutomationTest test)
        {
            return true;
        }
    }

    /// <summary>
    /// This filter is used to combine two filters and returns TRUE if both are true.
    /// </summary>
    class AndFilter: AutomationTestsFilter
    {
        AutomationTestsFilter _a, _b;

        public AndFilter(AutomationTestsFilter a, AutomationTestsFilter b)
        {
            Debug.Assert(a != null);
            Debug.Assert(b != null);

            this._a = a;
            this._b = b;
        }

        public override bool Fit(AutomationTest test)
        {
            return _a.Fit(test) && _b.Fit(test);
        }
    }

    /// <summary>
    /// This filter filters automation tests and returns TRUE only for tests with particular testPriority
    /// </summary>
    class TestFilterPriority : AutomationTestsFilter
    {
        TestPriorities _testPriority;

        public TestFilterPriority(TestPriorities testPriority)
        {
            this._testPriority = testPriority;
        }

        public override bool Fit(AutomationTest test)
        {
            return (test.Priority & this._testPriority) == this._testPriority;
        }
    }

    /// <summary>
    /// This filter filters automation tests and returns TRUE only for tests with particular testType
    /// </summary>
    class TestFilterType : AutomationTestsFilter
    {
       TestTypes _testType;

        public TestFilterType(TestTypes testType)
        {
            this._testType = testType;
        }


        public override bool Fit(AutomationTest test)
        {
            return (test.Type & this._testType) == this._testType;
        }
    }

    /// <summary>
    /// This filter filters automation tests and returns TRUE only for tests for particular controlType
    /// </summary>
    class FilterControlTypeTests : AutomationTestsFilter
    {
        ControlType _controlType;
        string _controlTypeName;

        public FilterControlTypeTests(ControlType controlType)
        {
            this._controlType = controlType;

            this._controlTypeName = controlType.ProgrammaticName;
            this._controlTypeName = this._controlTypeName.Remove(0, this._controlTypeName.IndexOf(".") + 1);
        }

        public string ControlTypeName { get { return this._controlTypeName; } }

        public override bool Fit(AutomationTest test)
        {
            return test.IsControlTestForControlType(this._controlTypeName);
        }
    }

    /// <summary>
    /// This filter filters automation tests and returns TRUE only for tests supporting particular pattern
    /// </summary>
    class FilterPatternTests : AutomationTestsFilter
    {
        AutomationPattern _pattern;
        string _patternName;

        public FilterPatternTests(AutomationPattern pattern)
        {
            this._pattern = pattern;

            this._patternName = pattern.ProgrammaticName;
            this._patternName = this._patternName.Remove(this._patternName.IndexOf("Pattern"));
        }

        public string PatternName { get { return this._patternName; } }

        public override bool Fit(AutomationTest test)
        {
            return test.IsPatternTestForSupportedPatterns(this._patternName);
        }
    }
}
