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
    /// TableItem pattern test class
    /// </summary>
    /// -----------------------------------------------------------------------
	public sealed class TableItemTests : PatternObject
    {
        #region Member variables

        /// <summary>
        /// Specific interface associated with this pattern
        /// </summary>
        TableItemPattern m_pattern = null;


        #endregion Member variables
        const string THIS = "TableItemTests";

		/// -------------------------------------------------------------------
		/// <summary>
        /// TestSuite associtated for this class
        /// </summary>
		/// -------------------------------------------------------------------
		public const string TestSuite = NAMESPACE + "." + THIS;

		/// -------------------------------------------------------------------
		/// <summary>
        /// Pattern name for TableItemPattern
        /// </summary>
		/// -------------------------------------------------------------------
		public static readonly string TestWhichPattern = Automation.PatternName(TableItemPattern.Pattern);

		/// -------------------------------------------------------------------
		/// <summary>
        /// Get the TableItemPattern on the element
        /// </summary>
		/// -------------------------------------------------------------------
		public TableItemTests(AutomationElement element, TestPriorities priority, string dirResults, bool testEvents, TypeOfControl typeOfControl, IApplicationCommands commands)
            :
            base(element, TestSuite, priority, typeOfControl, TypeOfPattern.TableItem, dirResults, testEvents, commands)
        {
            m_pattern = (TableItemPattern)GetPattern(m_le, m_useCurrent, TableItemPattern.Pattern);
            if (m_pattern == null)
                throw new Exception(Helpers.PatternNotSupported);
        }
        
        #region Tests

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for Row Property
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("TableItem.Row",
            TestSummary = "Get the Row number and verify that it is >= 0",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            ProblemDescription = "Testing the Row property",
            TestCaseType = TestCaseType.Generic,
            Client = Client.ATG,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: None",                
                "Step: Get the Row number",
                "Verify: Row >= 0"
            })]
        public void GetRowNumber(TestCaseAttribute testCaseAtrribute)
        {
            HeaderComment(testCaseAtrribute);
            int retrievedRowNum;
            //"Step: Get the AutomationElement's row",
            TS_GetRow(out retrievedRowNum, CheckType.Verification);

            Comment("Row Number is {0}", retrievedRowNum);
            if (retrievedRowNum < 0)
            {
                ThrowMe(CheckType.Verification, "{0} :  negative value returned for Row number on the Table Item", retrievedRowNum);
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for Column property
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("TableItem.Column",
            TestSummary = "Get the Column number and verify that it is >= 0",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            ProblemDescription = "Testing the Column property",
            TestCaseType = TestCaseType.Generic,
            Client = Client.ATG,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: None",                
                "Step: Get the Column number",
                "Verify: Column >= 0"
            })]
        public void GetColumnNumber(TestCaseAttribute testCaseAtrribute)
        {
            HeaderComment(testCaseAtrribute);
            int retrievedColumnNum;
            TS_GetColumn(out retrievedColumnNum, CheckType.Verification);
            
            Comment("Column Number is {0}", retrievedColumnNum);
            if (retrievedColumnNum < 0)
            {
                ThrowMe(CheckType.Verification, "{0} :  negative value returned for Column number on the Table Item", retrievedColumnNum);
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for RowSpan property
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("TableItem.RowSpan",
            TestSummary = "Get the RowSpan value and verify that it is >= 0",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            ProblemDescription = "Testing the RowSpan property",
            TestCaseType = TestCaseType.Generic,
            Client = Client.ATG,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: None",                
                "Step: Get the RowSpan value",
                "Verify: RowSpan >= 0"
            })]
        public void GetRowSpanValue(TestCaseAttribute testCaseAtrribute)
        {
            HeaderComment(testCaseAtrribute);
            int retrievedRowSpanVal;
            TS_GetRowSpan(out retrievedRowSpanVal, CheckType.Verification);
            Comment("RowSpan Value is {0}", retrievedRowSpanVal);
            if (retrievedRowSpanVal < 0)
            {
                ThrowMe(CheckType.Verification, "{0} :  negative value returned for RowSpan value on the Table Item", retrievedRowSpanVal);
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for ColumnSpan property
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("TableItem.ColumnSpan",
            TestSummary = "Get the ColumnSpan value and verify that it is >= 0",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            ProblemDescription = "Testing the ColumnSpan property",
            TestCaseType = TestCaseType.Generic,
            Client = Client.ATG,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: None",                
                "Step: Get the ColumnSpan value",
                "Verify: ColumnSpan >= 0"
            })]
        public void GetColumnSpanValue(TestCaseAttribute testCaseAtrribute)
        {
            HeaderComment(testCaseAtrribute);
            int retrievedColumnSpanVal;
            TS_GetColumnSpan(out retrievedColumnSpanVal, CheckType.Verification);
            Comment("ColumnSpan Value is {0}", retrievedColumnSpanVal);
            if (retrievedColumnSpanVal < 0)
            {
                ThrowMe(CheckType.Verification, "{0} :  negative value returned for ColumnSpan value on the Table Item", retrievedColumnSpanVal);
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for GetColumnHeaderItems
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("TableItem.GetColumnHeaderItems",
            TestSummary = "Get the ColumnHeaderItems and verify that it is >= 0. Verify that they are header control type",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            ProblemDescription = "Testing the GetColumnHeaderItems property",
            TestCaseType = TestCaseType.Generic,
            Client = Client.ATG,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: None",                
                "Step: Get the Number of Column Headers",
                "Step: Get the Column Header control type",
                "Verify: Number of Column headers >= 0",
                "Verify: Control Type is header"
            })]
        public void GetColumnHeaderItems(TestCaseAttribute testCaseAtrribute)
        {
            HeaderComment(testCaseAtrribute);
            AutomationElement[] tableColumnHeaderItems;
            TS_GetColumnHeaderItems(out tableColumnHeaderItems, CheckType.Verification);
            Comment("Number of ColumnHeaderItems: {0}", tableColumnHeaderItems.Length);
            if (tableColumnHeaderItems.Length < 0)
            {
                ThrowMe(CheckType.Verification, "{0} :  negative value returned for ColumnHeaderItems", tableColumnHeaderItems.Length);
            }
            foreach (AutomationElement header in tableColumnHeaderItems)
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
        /// Test case for GetRowHeaderItems
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("Table.GetRowHeaderItems",
            TestSummary = "Get the RowHeaders and verify that it is >= 0. Verify that they are header control type",
            Priority = TestPriorities.Pri0,
            Status = TestStatus.Works,
            ProblemDescription = "Testing the GetRowHeaderItems property",
            TestCaseType = TestCaseType.Generic,
            Client = Client.ATG,
            Author = "Microsoft Corp.",
            Description = new string[] {
                "Precondition: None",                
                "Step: Get the Number of Row Headers",
                "Step: Get the Row Header control type",
                "Verify: Number of Row headers >= 0",
                "Verify: Control Type is header"
            })]
        public void GetRowHeaderItems(TestCaseAttribute testCaseAtrribute)
        {
            HeaderComment(testCaseAtrribute);
            AutomationElement[] tableRowHeaderItems;
            TS_GetRowHeaderItems(out tableRowHeaderItems, CheckType.Verification);
            Comment("Number of RowHeaderItems: {0}", tableRowHeaderItems.Length);
            if (tableRowHeaderItems.Length < 0)
            {
                ThrowMe(CheckType.Verification, "{0} :  negative value returned for RowHeaders", tableRowHeaderItems.Length);
            }
            foreach (AutomationElement header in tableRowHeaderItems)
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
        /// Test case for ContainingGrid method
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("TableItem.ContainingGridProperty.S.1.1",
            Priority = TestPriorities.Pri0,
            TestCaseType = TestCaseType.Events,
            EventTested = "AutomationPropertyChangedEventHandler(TableItemPattern.ContainingGridProperty)",
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
            Description = new string[]{
                "Step: Traverse up the tree to find a AutomationElement that supports TablePattern",
                "Step: Get the ContainingGrid property",
                "Step: Verify that the two AutomationElements are the same"
            })]
        public void TestTableItemContainingGridPropertyS11(TestCaseAttribute checkType)
        {
            HeaderComment(checkType);
            AutomationElement table1 = null;
            AutomationElement table2 = null;

            //"Step: Traverse up the tree to find a AutomationElement that supports TablePattern",
            TS_GetContainTableByNavigation(m_le, out table1, CheckType.Verification);

            //"Step: Get the ContainingGrid property",
            TS_GetContainTableByCall(out table2, CheckType.Verification);

            //"Step: Verify that the two AutomationElements are the same"
            TS_AreTheseTheSame(table1, table2, true, CheckType.Verification);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for ContainingGrid method
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("TableItem.ContainingGridProperty.S.1.3",
            Priority = TestPriorities.Pri0,
            TestCaseType = TestCaseType.Events,
            EventTested = "AutomationPropertyChangedEventHandler(TableItemPattern.ContainingGridProperty)",
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
            Description = new string[]{
                "Step: Get the AutomationElement's col",
                "Step: Get the AutomationElement's row",
                "Step: Add and event listener for ContainingGridProperty property change event",
                "Step: Call containing table's GetCell(row, col)",
                "Step: Wait for event to occur",
                "Step: Verify that listener for ContainingGridProperty property change event did not fire",
                "Step: Verify that AutomationElement and one from GetCell() are the same"
            })]
        public void TestTableItemContainingGridPropertyS13(TestCaseAttribute checkType)
        {
            HeaderComment(checkType);
            int col;
            int row;
            AutomationElement cell = null;

            //"Step: Get the AutomationElement's col",
            TS_GetColumn(out col, CheckType.Verification);

            //"Step: Get the AutomationElement's row",
            TS_GetRow(out row, CheckType.Verification);

            //"Step: Add and event listener for ContainingGridProperty property change event",
            TSC_AddPropertyChangedListener(m_le, TreeScope.Element, new AutomationProperty[] { TableItemPattern.ContainingGridProperty }, CheckType.Verification);

            //"Step: Call containing table's GetCell(row, col)",
            TS_GetCell(row, col, out cell, CheckType.Verification);

            // "Step: Wait for event to occur",
            TSC_WaitForEvents(1);

            //"Step: Verify that listener for ContainingGridProperty property change event did not fire",
            TSC_VerifyPropertyChangedListener(m_le, new EventFired[] { EventFired.False }, new AutomationProperty[] { TableItemPattern.ContainingGridProperty }, CheckType.Verification);

            //"Step: Verify that AutomationElement and one from GetCell() are the same"
            TS_AreTheseTheSame(m_le, cell, true, CheckType.Verification);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for ColumnProperty
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("TableItem.ColumnProperty.S.3.1",
            Priority = TestPriorities.BuildVerificationTest,
            TestCaseType = TestCaseType.Arguments,
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
            Description = new string[]{
                "Verify: Argument supplied is the expected ColumnProperty(y) of the logical element and is of System.Int32 type",
                "Cell is at (x, y), verify that ColumnProperty returns y: ",
            })]
        public void TestTableItemColumnPropertyS31(TestCaseAttribute checkType, object args)
        {
            HeaderComment(checkType);

            if (args == null)
                throw new ArgumentException();

            if (!args.GetType().Equals(typeof(int)))
                ThrowMe(CheckType.Verification, "Invalid argument type");

            if (!m_pattern.Current.Column.Equals(Convert.ToInt32(args, CultureInfo.CurrentUICulture)))
                ThrowMe(CheckType.Verification, "ColumnProperty returned " + m_pattern.Current.Column);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for ColumnSpan Property
        /// </summary>
        /// -------------------------------------------------------------------
        [TestCaseAttribute("TableItem.ColumnSpanProperty.S.4.1",
            Priority = TestPriorities.BuildVerificationTest,
            TestCaseType = TestCaseType.Arguments,
            Status = TestStatus.Works,
            Author = "Microsoft Corp.",
            Description = new string[]{
                "Verify: Argument supplied is the expected RowSpanProperty with System.Int32 type",
                "Cell is merged according to argument supplied",
            })]
        public void TestTableItemColumnPropertyS41(TestCaseAttribute checkType, object args)
        {
            HeaderComment(checkType);

            if (args == null)
                throw new ArgumentException();

            if (!args.GetType().Equals(typeof(int)))
                ThrowMe(CheckType.Verification, "Invalid argument type");

            if (!m_pattern.Current.ColumnSpan.Equals(Convert.ToInt32(args, CultureInfo.CurrentUICulture)))
                ThrowMe(CheckType.Verification, "ColumnSpan returned " + m_pattern.Current.ColumnSpan);
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test step for ContainingGrid method
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetContainTableByCall(out AutomationElement table, CheckType ct)
        {
            table = Table;
            Comment("Found ContainingGrid(" + Library.GetUISpyLook(table) + ")");
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test step for GetCell method
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetCell(int row, int col, out AutomationElement cell, CheckType ct)
        {
            cell = (AutomationElement)TablePat.GetItem(row, col);
            Comment("GetCell(" + row + ", " + col + ") = " + Library.GetUISpyLook(cell));
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test step for Column property
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetColumn(out int col, CheckType ct)
        {
            if (m_useCurrent)
            {
                col = m_pattern.Current.Column;
            }
            else
            {
                col = m_pattern.Cached.Column;
            }
            Comment("Getting column count(" + col + ")");
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test step for Row property
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetRow(out int row, CheckType ct)
        {
            if (m_useCurrent)
            {
                row = m_pattern.Current.Row;
            }
            else
            {
                row = m_pattern.Cached.Row;
            }
            Comment("Getting row count(" + row + ")");
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test step for ColumnSpan property
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetColumnSpan(out int colSpan, CheckType ct)
        {
            if (m_useCurrent)
            {
                colSpan = m_pattern.Current.ColumnSpan;
            }
            else
            {
                colSpan = m_pattern.Cached.ColumnSpan;
            }
            Comment("Getting column span count(" + colSpan + ")");
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test step for RowSpan property
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetRowSpan(out int rowSpan, CheckType ct)
        {
            if (m_useCurrent)
            {
                rowSpan = m_pattern.Current.RowSpan;
            }
            else
            {
                rowSpan = m_pattern.Cached.RowSpan;
            }
            Comment("Getting row span count(" + rowSpan + ")");
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for ColumnHeaderItems
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetColumnHeaderItems(out AutomationElement[] columnHeaderItems, CheckType ct)
        {
            if (m_useCurrent)
            {
                columnHeaderItems = m_pattern.Current.GetColumnHeaderItems();
            }
            else
            {
                columnHeaderItems = m_pattern.Cached.GetColumnHeaderItems();
            }
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test case for RowHeaderItems property
        /// </summary>        
        /// -------------------------------------------------------------------
        void TS_GetRowHeaderItems(out AutomationElement[] rowHeaderItems, CheckType ct)
        {
            if (m_useCurrent)
            {
                rowHeaderItems = m_pattern.Current.GetRowHeaderItems();
            }
            else
            {
                rowHeaderItems = m_pattern.Cached.GetRowHeaderItems();
            }
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test step to verify that automation elements are same
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_AreTheseTheSame(AutomationElement le1, AutomationElement le2, bool ShouldTheyBe, CheckType ct)
        {
            Comment("Comparing AutomationElements (" + Library.GetUISpyLook(le1) + ") and (" + Library.GetUISpyLook(le2) + ")");
            bool results = Automation.Compare(le1, le2).Equals(ShouldTheyBe);
            if (!results)
                ThrowMe(ct, "Compare(" + Library.GetUISpyLook(le1) + ", " + Library.GetUISpyLook(le2) + ") = " + results + " but should be " + ShouldTheyBe);
            Comment("Compare(" + Library.GetUISpyLook(le1) + ", " + Library.GetUISpyLook(le2) + ") == " + ShouldTheyBe);
            m_TestStep++;
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Test step to get the containing table that has table pattern implemented
        /// </summary>
        /// -------------------------------------------------------------------
        void TS_GetContainTableByNavigation(AutomationElement element, out AutomationElement table, CheckType ct)
        {
            table = element;
            while (
                !(bool)table.GetCurrentPropertyValue(AutomationElement.IsTablePatternAvailableProperty)
                && element != AutomationElement.RootElement
                )
            {
                table = TreeWalker.RawViewWalker.GetParent(table);
                if (table == null)
                    ThrowMe(ct, "There were no ancestors that suupported TablePattern");
            }

            if (element == AutomationElement.RootElement)
                ThrowMe(ct, "Could not find parent element that supports TablePattern");

            Comment("Found containing table w/navigation(" + Library.GetUISpyLook(table) + ")");
            m_TestStep++;
        }

        #endregion Tests

        #region Step/Verification

        #endregion Step/Verification

        /// -------------------------------------------------------------------
        /// <summary>
        /// Get the current Table Pattern
        /// </summary>
        /// -------------------------------------------------------------------
        TablePattern TablePat
        {
            get
            {
                return (TablePattern)((AutomationElement)m_pattern.Current.ContainingGrid).GetCurrentPattern(TablePattern.Pattern);
            }
        }

        /// -------------------------------------------------------------------
        /// <summary>
        /// Get the containing grid
        /// </summary>
        /// -------------------------------------------------------------------
        AutomationElement Table
        {
            get
            {
                if (m_useCurrent)
                {
                    return (AutomationElement)m_pattern.Current.ContainingGrid;
                }
                else
                {
                    return (AutomationElement)m_pattern.Cached.ContainingGrid;
                }
            }
        }
    }
}