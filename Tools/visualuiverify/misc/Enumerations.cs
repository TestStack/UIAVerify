//---------------------------------------------------------------------------
//
// <copyright file="Enumerations" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Definitions of all enumerations
//
// History:  
//  09/20/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace VisualUIAVerify
{
    /// <summary>
    /// This is used to set the range of shown tests
    /// </summary>
    public enum TestsScope
    {
        /// <summary>
        /// this is to set that only tests for selected automation element are needed
        /// </summary>
        SelectedElementTests,

        /// <summary>
        /// this is to set that all tests are to be shown
        /// </summary>
        AllTests
    }

    /// <summary>
    /// this is used to set which kind of tests are going to be shown
    /// </summary>
    [Flags]
    public enum TestTypes
    {
        /// <summary>
        /// default value, not used
        /// </summary>
        None,

        /// <summary>
        /// type of test testing automation element in general
        /// </summary>
        AutomationElementTest = 1,

        /// <summary>
        /// type of test testing particular automation pattern
        /// </summary>
        PatternTest = 2,

        /// <summary>
        /// type of test testing particular control type
        /// </summary>
        ControlTest = 4,

        /// <summary>
        /// type of test testing particulat scenario
        /// </summary>
        ScenarioTest = 8,

        //        AllTypes = AutomationElementTests | PatternTests | ControlTests | ScenarioTests
    }

    /// <summary>
    /// this is to used to set which kind of tests are going to be shown
    /// </summary>
    [Flags]
    public enum TestPriorities
    {
        /// <summary>
        /// default value, not used
        /// </summary>
        None,

        /// <summary>
        /// 
        /// </summary>
        BuildVerificationTests = 1,
        /// <summary>
        /// 
        /// </summary>
        Priority0Tests = 2,
        /// <summary>
        /// 
        /// </summary>
        Priority1Tests = 4,
        /// <summary>
        /// 
        /// </summary>
        Priority2Tests = 8,
        /// <summary>
        /// 
        /// </summary>
        Priority3Tests = 16,
        /// <summary>
        /// 
        /// </summary>
        OnlyPriorityAllTests = 32
    }

}
