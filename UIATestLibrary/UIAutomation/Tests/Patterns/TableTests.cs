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

namespace Microsoft.Test.UIAutomation.Tests.Patterns
{
	using InternalHelper;
	using InternalHelper.Tests;
	using InternalHelper.Enumerations;
	using Microsoft.Test.UIAutomation;
	using Microsoft.Test.UIAutomation.Core;
	using Microsoft.Test.UIAutomation.TestManager;
	using Microsoft.Test.UIAutomation.Interfaces;

    /// -----------------------------------------------------------------------
    /// <summary>
    /// Table pattern test class
    /// </summary>
    /// -----------------------------------------------------------------------
	public sealed class TableTests : PatternObject
    {
        #region Member variables

        /// <summary>
        /// Specific interface associated with this pattern
        /// </summary>
        TablePattern m_pattern = null;


        #endregion Member variables
        const string THIS = "TableTests";

		/// -------------------------------------------------------------------
		/// <summary>
        /// TestSuite associtated for this class
        /// </summary>
		/// -------------------------------------------------------------------
		public const string TestSuite = NAMESPACE + "." + THIS;

		/// -------------------------------------------------------------------
		/// <summary>
        /// Pattern name for TablePattern
        /// </summary>
		/// -------------------------------------------------------------------
		public static readonly string TestWhichPattern = Automation.PatternName(TablePattern.Pattern);

		/// -------------------------------------------------------------------
		/// <summary>
        /// Get the tablepattern on the element
        /// </summary>
		/// -------------------------------------------------------------------
		public TableTests(AutomationElement element, TestPriorities priority, string dirResults, bool testEvents, TypeOfControl typeOfControl, IApplicationCommands commands)
            :
            base(element, TestSuite, priority, typeOfControl, TypeOfPattern.Table, dirResults, testEvents, commands)
        {
            m_pattern = (TablePattern)GetPattern(m_le, m_useCurrent, TablePattern.Pattern);
            if (m_pattern == null)
                throw new Exception(Helpers.PatternNotSupported);
        }        

        #region Tests
        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for RowOrColumnMajor
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("Table.RowOrColumnMajor",
            TestSummary = "Get the RowOrColumnMajor and verify that it is one of the enums - RowOrColumnMajor",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            ProblemDescription = "Testing the RowOrColumnMajor property",
            TestCaseType = TestCaseType.Generic ,
            Client = Client.ATG,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: None",                
                "Step: Get the RowOrColumnMajor",                 
                "Verify: The enum is on of the values in 'RowOrColumnMajor'"
            })]
        public void GetRowOrColumnMajor(TestCaseAttribute testCaseAtrribute)
        {
            HeaderComment(testCaseAtrribute);
            RowOrColumnMajor retrievedRowOrColumnMajor;
            //Step: Get the RowOrColumnMajor
            TS_GetRowOrColumnMajor(out retrievedRowOrColumnMajor, CheckType.Verification);

            if (retrievedRowOrColumnMajor == RowOrColumnMajor.RowMajor)
            {
                Comment("RowOrColumnMajor is RowMajor");
            }
            else if (retrievedRowOrColumnMajor == RowOrColumnMajor.ColumnMajor)
            {
                Comment("RowOrColumnMajor is ColumnMajor");
            }
            else if (retrievedRowOrColumnMajor == RowOrColumnMajor.Indeterminate)
            {
                Comment("RowOrColumnMajor is Indeterminate");
            }
            else
            {
                ThrowMe(CheckType.Verification, "{0} :  returned for RowOrColumnMajor", retrievedRowOrColumnMajor);
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for RowCount property
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("Table.RowCount",
            TestSummary = "Get the RowCount and verify that it is >= 0",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            ProblemDescription = "Testing the RowCount property",
            TestCaseType = TestCaseType.Generic,
            Client = Client.ATG,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: None",                
                "Step: Get the RowCount",                 
                "Verify: RowCount >= 0"
            })]
        public void GetRowCount(TestCaseAttribute testCaseAtrribute)
        {
            HeaderComment(testCaseAtrribute);
            int retrievedRowCount;
            //Step: Get the RowCount
            TS_GetRowCount(out retrievedRowCount, CheckType.Verification);

            Comment("RowCount is {0}", retrievedRowCount);
            if (retrievedRowCount < 0)
            {
                ThrowMe(CheckType.Verification, "{0} :  negative value returned for RowCount", retrievedRowCount);
            }            
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for ColumnCount property
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("Table.ColumnCount",
            TestSummary = "Get the ColumnCount and verify that it is >= 0",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            ProblemDescription = "Testing the ColumnCount property",
            TestCaseType = TestCaseType.Generic,
            Client = Client.ATG,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: None",                
                "Step: Get the ColumnCount",                 
                "Verify: ColumnCount >= 0"
            })]
        public void GetColumnCount(TestCaseAttribute testCaseAtrribute)
        {
            HeaderComment(testCaseAtrribute);
            int retrievedColumnCount;
            //Step: Get the ColumnCount
            TS_GetColumnCount(out retrievedColumnCount, CheckType.Verification);

            Comment("ColumnCount is {0}", retrievedColumnCount);
            if (retrievedColumnCount < 0)
            {
                ThrowMe(CheckType.Verification, "{0} :  negative value returned for ColumnCount", retrievedColumnCount);
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for ColumnHeaders
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("Table.GetColumnHeaders",
            TestSummary = "Get the ColumnHeaders and verify that it is >= 0. Verify that they are header control type",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            ProblemDescription = "Testing the GetColumnHeaders property",
            TestCaseType = TestCaseType.Generic,
            Client = Client.ATG,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: None",                
                "Step: Get the Number of ColumnHeaders",
                "Step: Get the Column Header control type",
                "Verify: Number of Column headers >= 0",
                "Verify: Control Type is header"
            })]
        public void GetColumnHeaders(TestCaseAttribute testCaseAtrribute)
        {
            HeaderComment(testCaseAtrribute);
            AutomationElement[] tableColumnHeaders;
            //Step: Get the ColumnHeaders
            TS_GetColumnHeaders(out tableColumnHeaders, CheckType.Verification);

            Comment("Number of ColumnHeaders: {0}", tableColumnHeaders.Length);
            if (tableColumnHeaders.Length < 0)
            {
                ThrowMe(CheckType.Verification, "{0} :  negative value returned for ColumnHeaders", tableColumnHeaders.Length);
            }
            foreach (AutomationElement header in tableColumnHeaders)
            {
                if (header.Current.ControlType == ControlType.HeaderItem)
                {
                    Comment("Header Control Type verified for Column Header: {0}", header.Current.Name);
                }
                else
                {
                    ThrowMe(CheckType.Verification, "{0} :  Control Type on Column Header", header.Current.ControlType, header.Current.Name);
                }
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for RowHeaders
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("Table.GetRowHeaders",
            TestSummary = "Get the RowHeaders and verify that it is >= 0. Verify that they are header control type",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            ProblemDescription = "Testing the GetRowHeaders property",
            TestCaseType = TestCaseType.Generic,
            Client = Client.ATG,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: None",                
                "Step: Get the Number of RowHeaders",
                "Step: Get the Row Header control type",
                "Verify: Number of Row headers >= 0",
                "Verify: Control Type is header"
            })]
        public void GetRowHeaders(TestCaseAttribute testCaseAtrribute)
        {
            HeaderComment(testCaseAtrribute);
            AutomationElement[] tableRowHeaders;
            TS_GetRowHeaders(out tableRowHeaders, CheckType.Verification);
            Comment("Number of RowHeaders: {0}", tableRowHeaders.Length);
            if (tableRowHeaders.Length < 0)
            {
                ThrowMe(CheckType.Verification, "{0} :  negative value returned for RowHeaders", tableRowHeaders.Length);
            }
            foreach (AutomationElement header in tableRowHeaders)
            {
                if (header.Current.ControlType == ControlType.HeaderItem)
                {
                    Comment("Header Control Type verified for Row Header: {0}", header.Current.Name);
                }
                else
                {
                    ThrowMe(CheckType.Verification, "{0} :  Control Type on Row Header", header.Current.ControlType, header.Current.Name);
                }
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for RowOrColumnMajor
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetRowOrColumnMajor(out RowOrColumnMajor rowOrColumnMajor, CheckType ct)
        {
            if (m_useCurrent)
            {
                rowOrColumnMajor = m_pattern.Current.RowOrColumnMajor;
            }
            else
            {
                rowOrColumnMajor = m_pattern.Cached.RowOrColumnMajor;
            }
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for ColumnCount
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetColumnCount(out int colCount, CheckType ct)
        {
            if (m_useCurrent)
            {
                colCount = m_pattern.Current.ColumnCount;
            }
            else
            {
                colCount = m_pattern.Cached.ColumnCount;
            }
            Comment("Getting column count(" + colCount + ")");
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for RowCount
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetRowCount(out int rowCount, CheckType ct)
        {
            if (m_useCurrent)
            {
                rowCount = m_pattern.Current.RowCount;
            }
            else
            {
                rowCount = m_pattern.Cached.RowCount;
            }
            Comment("Getting row count(" + rowCount + ")");
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for ColumnHeaders
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetColumnHeaders(out AutomationElement[] columnHeaders, CheckType ct)
        {
            if (m_useCurrent)
            {
                columnHeaders = m_pattern.Current.GetColumnHeaders();
            }
            else
            {
                columnHeaders = m_pattern.Cached.GetColumnHeaders();
            }
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for RowHeaders
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetRowHeaders(out AutomationElement[] rowHeaders, CheckType ct)
        {
            if (m_useCurrent)
            {
                rowHeaders = m_pattern.Current.GetRowHeaders();
            }
            else
            {
                rowHeaders = m_pattern.Cached.GetRowHeaders();
            }
            m_TestStep++;
        }

        #endregion Tests

        #region Step/Verification
        #endregion Step/Verification
    }
}