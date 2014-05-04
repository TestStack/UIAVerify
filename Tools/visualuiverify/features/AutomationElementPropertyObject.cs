// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Drawing = System.Drawing;
using System.Drawing.Design;
using System.Windows;
using System.Windows.Automation;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections;

namespace VisualUIAVerify.Features
{
    class AutomationElementPropertyObject
    {

        const string constGeneralAccessibilityCategory = "General Accessibility";
        const string constStateCategory = "State";
        const string constIdentificationCategory = "Identification";
        const string constVisibilityCategory = "Visibility";
        const string constPatternsCategory = "Patterns";
        const string constInvokeMethod = "(invoke method)";
        const string constMessageCaption = "Message";

        public readonly AutomationElement AutomationElement;

        DockPatternPropertyObject _dockPatternPropertyObject;
        ExpandCollapsePatternPropertyObject _expandCollapsePatternPropertyObject;
        GridPatternPropertyObject _gridPatternPropertyObject;
        InvokePatternPropertyObject _invokePatternPropertyObject;
        MultipleViewPatternPropertyObject _multipleViewPatternPropertyObject;
        RangeValuePatternPropertyObject _rangeValuePatternPropertyObject;
        ScrollItemPatternPropertyObject _scrollItemPatternPropertyObject;
        ScrollPatternPropertyObject _scrollPatternPropertyObject;
        SelectionItemPatternPropertyObject _selectionItemPatternPropertyObject;
        SelectionPatternPropertyObject _selectionPatternPropertyObject;
        TableItemPatternPropertyObject _tableItemPatternPropertyObject;
        TablePatternPropertyObject _tablePatternPropertyObject;
        TextPatternPropertyObject _textPatternPropertyObject;
        TogglePatternPropertyObject _togglePatternPropertyObject;
        TransformPatternPropertyObject _transformPatternPropertyObject;
        ValuePatternPropertyObject _valuePatternPropertyObject;
        WindowPatternPropertyObject _windowPatternPropertyObject;

        /// <summary>
        /// Initializes all pattern objects within the property grid with the AutomationElement patterns supported
        /// </summary>
        public AutomationElementPropertyObject(AutomationElement automationElement)
        {
            this.AutomationElement = automationElement;

            foreach (AutomationPattern patternId in automationElement.GetSupportedPatterns())
            {
                object pattern = null;
                if (false == automationElement.TryGetCurrentPattern(patternId, out pattern))
                    continue;

                if (pattern is DockPattern)
                    this._dockPatternPropertyObject = new DockPatternPropertyObject((DockPattern)pattern);
                else if (pattern is ExpandCollapsePattern)
                    this._expandCollapsePatternPropertyObject = new ExpandCollapsePatternPropertyObject((ExpandCollapsePattern)pattern);
                else if (pattern is GridPattern)
                    this._gridPatternPropertyObject = new GridPatternPropertyObject((GridPattern)pattern);
                else if (pattern is InvokePattern)
                    this._invokePatternPropertyObject = new InvokePatternPropertyObject((InvokePattern)pattern);
                else if (pattern is MultipleViewPattern)
                    this._multipleViewPatternPropertyObject = new MultipleViewPatternPropertyObject((MultipleViewPattern)pattern);
                else if (pattern is RangeValuePattern)
                    this._rangeValuePatternPropertyObject = new RangeValuePatternPropertyObject((RangeValuePattern)pattern);
                else if (pattern is ScrollItemPattern)
                    this._scrollItemPatternPropertyObject = new ScrollItemPatternPropertyObject((ScrollItemPattern)pattern);
                else if (pattern is ScrollPattern)
                    this._scrollPatternPropertyObject = new ScrollPatternPropertyObject((ScrollPattern)pattern);
                else if (pattern is SelectionItemPattern)
                    this._selectionItemPatternPropertyObject = new SelectionItemPatternPropertyObject((SelectionItemPattern)pattern);
                else if (pattern is SelectionPattern)
                    this._selectionPatternPropertyObject = new SelectionPatternPropertyObject((SelectionPattern)pattern);
                else if (pattern is TableItemPattern)
                    this._tableItemPatternPropertyObject = new TableItemPatternPropertyObject((TableItemPattern)pattern);
                else if (pattern is TablePattern)
                    this._tablePatternPropertyObject = new TablePatternPropertyObject((TablePattern)pattern);
                else if (pattern is TextPattern)
                    this._textPatternPropertyObject = new TextPatternPropertyObject((TextPattern)pattern);
                else if (pattern is TogglePattern)
                    this._togglePatternPropertyObject = new TogglePatternPropertyObject((TogglePattern)pattern);
                else if (pattern is TransformPattern)
                    this._transformPatternPropertyObject = new TransformPatternPropertyObject((TransformPattern)pattern);
                else if (pattern is ValuePattern)
                    this._valuePatternPropertyObject = new ValuePatternPropertyObject((ValuePattern)pattern);
                else if (pattern is WindowPattern)
                    this._windowPatternPropertyObject = new WindowPatternPropertyObject((WindowPattern)pattern);
            }
        }

        #region general properties

        [Category(constGeneralAccessibilityCategory)]
        public string AccessKey { get { return this.AutomationElement.Current.AccessKey; } }

        [Category(constGeneralAccessibilityCategory)]
        public string AcceleratorKey { get { return this.AutomationElement.Current.AcceleratorKey; } }

        [Category(constGeneralAccessibilityCategory)]
        public bool IsKeyboardFocusable { get { return this.AutomationElement.Current.IsKeyboardFocusable; } }

        [Category(constGeneralAccessibilityCategory)]
        public string LabeledBy
        {
            get
            {
                AutomationElement labeledBy = this.AutomationElement.Current.LabeledBy;
                if (labeledBy != null)
                    return Controls.TreeHelper.GetAutomationElementTreeNodeText(labeledBy);

                return null;
            }
        }

        [Category(constGeneralAccessibilityCategory)]
        public string HelpText { get { return this.AutomationElement.Current.HelpText; } }

        [Category(constStateCategory)]
        public bool IsEnabled { get { return this.AutomationElement.Current.IsEnabled; } }

        [Category(constStateCategory)]
        public bool HasKeyboardFocus { get { return this.AutomationElement.Current.HasKeyboardFocus; } }

        [Category(constIdentificationCategory)]
        public string ClassName { get { return this.AutomationElement.Current.ClassName; } }

        [Category(constIdentificationCategory)]
        public string ControlType { get { return this.AutomationElement.Current.ControlType.ProgrammaticName; } }

        [Category(constIdentificationCategory)]
        public string AutomationId { get { return this.AutomationElement.Current.AutomationId; } }

        //Adds the MainWindow Handle as Hex to the properties window
        [Category(constIdentificationCategory)]
        public string hWnd { get { return "0x" + this.AutomationElement.Current.NativeWindowHandle.ToString("X"); } }

        [Category(constIdentificationCategory)]
        public string LocalizedControlType { get { return this.AutomationElement.Current.LocalizedControlType; } }

        [Category(constIdentificationCategory)]
        public string Name { get { return this.AutomationElement.Current.Name; } }

        [Category(constIdentificationCategory)]
        public int ProcessId { get { return this.AutomationElement.Current.ProcessId; } }

        [Category(constIdentificationCategory)]
        public string FrameworkId { get { return this.AutomationElement.Current.FrameworkId; } }

        [Category(constIdentificationCategory)]
        public bool IsPassword { get { return this.AutomationElement.Current.IsPassword; } }

        [Category(constIdentificationCategory)]
        public bool IsControlElement { get { return this.AutomationElement.Current.IsControlElement; } }

        [Category(constIdentificationCategory)]
        public bool IsContentElement { get { return this.AutomationElement.Current.IsContentElement; } }

        [Category(constVisibilityCategory)]
        //[TypeConverter(typeof(ExpandableObjectConverter))]
        public Rect BoundingRectangle { get { return this.AutomationElement.Current.BoundingRectangle; } }

        [Category(constVisibilityCategory)]
        public bool IsOffscreen { get { return this.AutomationElement.Current.IsOffscreen; } }

        #endregion

        #region Pattern

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public DockPatternPropertyObject DockPattern { get { return this._dockPatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ExpandCollapsePatternPropertyObject ExpandCollapsePattern { get { return this._expandCollapsePatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public GridPatternPropertyObject GridPattern { get { return this._gridPatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public InvokePatternPropertyObject InvokePattern { get { return this._invokePatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public MultipleViewPatternPropertyObject MultipleViewPattern { get { return this._multipleViewPatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public RangeValuePatternPropertyObject RangeValuePattern { get { return this._rangeValuePatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ScrollItemPatternPropertyObject ScrollItemPattern { get { return this._scrollItemPatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ScrollPatternPropertyObject ScrollPattern { get { return this._scrollPatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public SelectionItemPatternPropertyObject SelectionItemPattern { get { return this._selectionItemPatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public SelectionPatternPropertyObject SelectionPattern { get { return this._selectionPatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TableItemPatternPropertyObject TableItemPattern { get { return this._tableItemPatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TablePatternPropertyObject TablePattern { get { return this._tablePatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TextPatternPropertyObject TextPattern { get { return this._textPatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TogglePatternPropertyObject TogglePattern { get { return this._togglePatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TransformPatternPropertyObject TransformPattern { get { return this._transformPatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ValuePatternPropertyObject ValuePattern { get { return this._valuePatternPropertyObject; } }

        /// <summary>Actual pattern object in the property grid</summary>
        [Category(constPatternsCategory)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public WindowPatternPropertyObject WindowPattern { get { return this._windowPatternPropertyObject; } }

        #endregion Patterns

        #region DockPattern 

        public class DockPatternPropertyObject
        {
            DockPattern _pattern;
            DockPositionArg _setDockPositionArg = new DockPositionArg();

            public DockPatternPropertyObject(DockPattern dockPattern) { this._pattern = dockPattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            /// <summary>_pattern.SetDockPosition</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object SetDockPosition
            {
                set { _pattern.SetDockPosition(_setDockPositionArg.DockPosition); }
                get { return _setDockPositionArg; }
            }
        }


        #endregion

        #region ExpandCollapsePattern 

        public class ExpandCollapsePatternPropertyObject
        {
            ExpandCollapsePattern _pattern;

            public ExpandCollapsePatternPropertyObject(ExpandCollapsePattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            /// <summary>_pattern.Collapse</summary>
            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object Collapse
            {
                get { return constInvokeMethod; }
                set { this._pattern.Collapse(); }
            }

            /// <summary>_pattern.Expand</summary>
            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object Expand
            {
                get { return constInvokeMethod; }
                set { this._pattern.Expand(); }
            }
        }

        #endregion

        #region GridPattern 

        public class GridPatternPropertyObject
        {
            GridPattern _pattern;

            GridCoordinate _getItemArgs = new GridCoordinate();

            public GridPatternPropertyObject(GridPattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            /// <summary>_pattern.GetItem</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object GetItem
            {
                get { return _getItemArgs; }
                set { MessageBox.Show(_pattern.GetItem(_getItemArgs.Column, _getItemArgs.Row).Current.Name); }
            }
        }

        #endregion

        #region InvokePattern 

        public class InvokePatternPropertyObject
        {
            InvokePattern _pattern;

            public InvokePatternPropertyObject(InvokePattern pattern) { this._pattern = pattern; }

            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object InvokeMethod
            {
                get { return constInvokeMethod; }
                set { this._pattern.Invoke(); }
            }
        }

        #endregion

        #region MultipleViewPattern 

        public class MultipleViewPatternPropertyObject
        {
            MultipleViewPattern _pattern;

            public MultipleViewPatternPropertyObject(MultipleViewPattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            /// <summary>_pattern.SetCurrentView</summary>
            public int SetCurrentView
            {
                get { return this._pattern.Current.CurrentView; }
                set { this._pattern.SetCurrentView(value); }

            }

            /// <summary>_pattern.Current.GetSupportedViews</summary>
            public string GetSupportedViews
            {
                get
                {
                    StringBuilder buffer = new StringBuilder("Views(");
                    string delim = ",";

                    foreach (int view in _pattern.Current.GetSupportedViews())
                    {
                        buffer.Append(view + delim);
                    }

                    if (buffer[buffer.Length - 1].ToString() == delim)
                        buffer.Remove(buffer.Length - 1, 1);

                    return buffer.Append(")").ToString();
                }
            }

            /// <summary>_pattern.GetViewName</summary>
            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public int GetViewName
            {
                get { return _pattern.Current.CurrentView; }
                set { MessageBox.Show(this._pattern.GetViewName(value), constMessageCaption); }
            }
        }

        #endregion

        #region RangeValuePattern properties

        public class RangeValuePatternPropertyObject
        {
            RangeValuePattern _pattern;

            /// <summary></summary>
            public RangeValuePatternPropertyObject(RangeValuePattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            /// <summary>_pattern.Current.SetValue</summary>
            public double SetValue
            {
                get { return _pattern.Current.Value; }
                set { this._pattern.SetValue(value); }
            }
        }

        #endregion

        #region ScrollItemPattern properties

        public class ScrollItemPatternPropertyObject
        {
            ScrollItemPattern _pattern;

            public ScrollItemPatternPropertyObject(ScrollItemPattern pattern) { this._pattern = pattern; }

            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object ScrollIntoView
            {
                get { return constInvokeMethod; }
                set { this._pattern.ScrollIntoView(); }
            }
        }

        #endregion

        #region ScrollPattern properties  

        public class ScrollPatternPropertyObject
        {

            ScrollPattern _pattern;
            ScrollPatternProperty_ScrollMethodArgs _scrollMethodArgs = new ScrollPatternProperty_ScrollMethodArgs();
            ScrollPatternProperty_ScrollAmountArgs _scrollAmountArgsHorz = new ScrollPatternProperty_ScrollAmountArgs();
            ScrollPatternProperty_ScrollAmountArgs _scrollAmountArgsVert = new ScrollPatternProperty_ScrollAmountArgs();
            ScrollPatternProperty_SetScrollPercentArgs _setScrollPercentArgs = new ScrollPatternProperty_SetScrollPercentArgs();

            public ScrollPatternPropertyObject(ScrollPattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            /// <summary>_pattern.Scroll</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object Scroll
            {
                set { _pattern.Scroll(_scrollMethodArgs._horizontalAmount, _scrollMethodArgs._verticalAmount); }
                get { return _scrollMethodArgs; }
            }

            /// <summary>_pattern.ScrollHorizontal</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object ScrollHorizontal
            {
                set { _pattern.ScrollHorizontal(_scrollAmountArgsHorz.ScrollAmount); }
                get { return _scrollAmountArgsHorz; }
            }

            /// <summary>_pattern.ScrollVertical</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object ScrollVertical
            {
                set { _pattern.ScrollVertical(_scrollAmountArgsVert.ScrollAmount); }
                get { return _scrollAmountArgsVert; }
            }

            /// <summary>_pattern.SetScrollPercent</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object SetScrollPercent
            {
                set { _pattern.SetScrollPercent(_setScrollPercentArgs.HorizontalPercent, _setScrollPercentArgs.VerticalPercent); }
                get { return _setScrollPercentArgs; }
            }
        }

        #endregion

        #region SelectionItemPattern properties

        public class SelectionItemPatternPropertyObject
        {
            SelectionItemPattern _pattern;

            public SelectionItemPatternPropertyObject(SelectionItemPattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object AddToSelection
            {
                get { return constInvokeMethod; }
                set { this._pattern.AddToSelection(); }
            }

            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object RemoveFromSelection
            {
                get { return constInvokeMethod; }
                set { this._pattern.RemoveFromSelection(); }
            }

            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object Select
            {
                get { return constInvokeMethod; }
                set { this._pattern.Select(); }
            }
        }

        #endregion

        #region SelectionPattern 

        public class SelectionPatternPropertyObject
        {
            SelectionPattern _pattern;

            public SelectionPatternPropertyObject(SelectionPattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public string GetSelection
            {
                get
                {
                    StringBuilder buffer = new StringBuilder();
                    foreach (AutomationElement element in _pattern.Current.GetSelection())
                    {
                        buffer.Append(element.Current.Name + "\n");
                    }
                    return buffer.ToString();
                }
            }
        }

        #endregion

        #region TableItemPattern properties

        public class TableItemPatternPropertyObject
        {
            TableItemPattern _pattern;

            public TableItemPatternPropertyObject(TableItemPattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }
        }


        #endregion

        #region TablePattern properties

        public class TablePatternPropertyObject
        {
            TablePattern _pattern;
            CoordinateArgs<int> _getItemArgs = new CoordinateArgs<int>(0, 0);

            public TablePatternPropertyObject(TablePattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            /// <summary>_pattern.GetItem</summary>
            public CoordinateArgs<int> GetItem
            {
                get { return _getItemArgs; }
                set { MessageBox.Show(_pattern.GetItem(_getItemArgs.X, _getItemArgs.Y).Current.Name); }
            }
        }

        #endregion

        #region TextPattern properties

        public class TextPatternPropertyObject
        {
            TextPattern _pattern;

            public TextPatternPropertyObject(TextPattern pattern) { this._pattern = pattern; }

        }

        #endregion TextPattern properties

        #region TogglePattern properties

        public class TogglePatternPropertyObject
        {
            TogglePattern _pattern;

            public TogglePatternPropertyObject(TogglePattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object Toggle
            {
                get { return constInvokeMethod; }
                set { this._pattern.Toggle(); }
            }
        }

        #endregion

        #region TransformPattern properties

        public class TransformPatternPropertyObject
        {
            TransformPattern _pattern;

            CoordinateArgs<double> _moveArgs = new CoordinateArgs<double>();
            CoordinateArgs<double> _resizeArgs = new CoordinateArgs<double>();
            NumericArgument<double> _rotateArg = new NumericArgument<double>();

            public TransformPatternPropertyObject(TransformPattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Move
            {
                get { return _moveArgs; }
                set { _pattern.Move(_moveArgs.X, _moveArgs.Y); }
            }
            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Resize
            {
                get { return _resizeArgs; }
                set { _pattern.Resize(_resizeArgs.X, _resizeArgs.Y); }
            }
            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public NumericArgument<double> Rotate
            {
                get { return _rotateArg; }
                set { _pattern.Rotate(_rotateArg.X); }
            }
        }

        #endregion

        #region ValuePattern properties

        public class ValuePatternPropertyObject
        {
            ValuePattern _pattern;

            public ValuePatternPropertyObject(ValuePattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            /// <summary>_pattern.SetValue</summary>
            public string SetValue
            {
                get { return this._pattern.Current.Value; }
                set { this._pattern.SetValue(value); }
            }
        }

        #endregion

        #region WindowPattern properties

        public class WindowPatternPropertyObject
        {
            WindowPattern _pattern;

            public WindowPatternPropertyObject(WindowPattern pattern) { this._pattern = pattern; }

            /// <summary>_pattern.Current</summary>
            [TypeConverter(typeof(ExpandableObjectConverter))]
            public object Current { get { return _pattern.Current; } }

            /// <summary>_pattern.SetWindowVisualState</summary>
            public WindowVisualState SetWindowVisualState
            {
                get { return this._pattern.Current.WindowVisualState; }
                set { this._pattern.SetWindowVisualState(value); }
            }

            /// <summary>_pattern.Close</summary>
            [Editor(typeof(InvokeMethodButtonEditor), typeof(System.Drawing.Design.UITypeEditor))]
            public object Close
            {
                get { return constInvokeMethod; }
                set { this._pattern.Close(); }
            }
        }

        #endregion

        #region Args

        public class DockPositionArg
        {
            DockPosition _dockPosition = DockPosition.None;

            public DockPosition DockPosition
            {
                get { return _dockPosition; }
                set { _dockPosition = value; }
            }
        }

        public class GridCoordinate
        {
            int _row;

            public int Row
            {
                get { return _row; }
                set { _row = value; }
            }
            int _column;

            public int Column
            {
                get { return _column; }
                set { _column = value; }
            }

        }

        public class CoordinateArgs<T>
        {
            T _x;
            T _y;

            public T X
            {
                get { return _x; }
                set { _x = value; }
            }

            public T Y
            {
                get { return _y; }
                set { _y = value; }
            }

            public CoordinateArgs(T x, T y)
            {
                x = X;
                y = Y;
            }

            public CoordinateArgs()
            {
            }
        }

        public class NumericArgument<T>
        {
            T _x;

            public T X
            {
                get { return _x; }
                set { _x = value; }
            }

            public NumericArgument()
            {
            }
        }

        public class ScrollPatternProperty_ScrollMethodArgs
        {
            internal ScrollAmount _horizontalAmount = ScrollAmount.NoAmount;

            internal ScrollAmount _verticalAmount = ScrollAmount.NoAmount;

            public ScrollPatternProperty_ScrollMethodArgs() { }

            public ScrollAmount HorizontallyAmount
            {
                get { return _horizontalAmount; }
                set { _horizontalAmount = value; }
            }
            public ScrollAmount VerticalAmount
            {
                get { return _verticalAmount; }
                set { _verticalAmount = value; }
            }
        }
        public class ScrollPatternProperty_ScrollAmountArgs
        {
            ScrollAmount _scrollAmount = ScrollAmount.NoAmount;

            internal ScrollPatternProperty_ScrollAmountArgs() { }

            public ScrollAmount ScrollAmount
            {
                get { return _scrollAmount; }
                set { _scrollAmount = value; }
            }
        }

        public class ScrollPatternProperty_SetScrollPercentArgs
        {
            double horizontalPercent = -1;
            double verticalPercent = -1;

            public double HorizontalPercent
            {
                get { return horizontalPercent; }
                set { horizontalPercent = value; }
            }

            public double VerticalPercent
            {
                get { return verticalPercent; }
                set { verticalPercent = value; }
            }
        }

        #endregion Args
    }
}
