//---------------------------------------------------------------------------
//
// <copyright file="AutomationHelper" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Definition of helper automation technology class.
//
// History:  
//  08/29/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace VisualUIAVerify.Utils
{
    /// <summary>
    /// Helper class.
    /// </summary>
    static class AutomationHelper
    {
        /// <summary>
        /// This method returns all automation technology patterns.
        /// </summary>
        public static AutomationPattern[] GetAllAutomationPatterns()
        {
            return new AutomationPattern[] {
                DockPattern.Pattern,
                ExpandCollapsePattern.Pattern, 
                GridPattern.Pattern, 
                InvokePattern.Pattern,  
                MultipleViewPattern.Pattern, 
                RangeValuePattern.Pattern,
                ScrollItemPattern.Pattern, ScrollPattern.Pattern,  SelectionItemPattern.Pattern, SelectionPattern.Pattern,
                TableItemPattern.Pattern, TablePattern.Pattern, TextPattern.Pattern, TogglePattern.Pattern, TransformPattern.Pattern,
                ValuePattern.Pattern,  
                WindowPattern.Pattern
            };
        }

        /// <summary>
        /// This method returns all automation technology ControlTypes.
        /// </summary>
        /// <returns></returns>
        public static ControlType[] GetAllAutomationControlTypes()
        {
            return new ControlType[] {
                ControlType.Button,ControlType.Calendar,ControlType.CheckBox,ControlType.ComboBox,ControlType.Edit,ControlType.Hyperlink,
                ControlType.Image,ControlType.ListItem,ControlType.List,ControlType.Menu,ControlType.MenuBar,ControlType.MenuItem,
                ControlType.ProgressBar,ControlType.RadioButton,ControlType.ScrollBar,ControlType.Slider,ControlType.Spinner,
                ControlType.StatusBar,ControlType.Tab,ControlType.TabItem,ControlType.Text,ControlType.ToolBar,ControlType.ToolTip,
                ControlType.Tree,ControlType.TreeItem,ControlType.Custom,ControlType.Group,ControlType.Thumb,ControlType.DataGrid,
                ControlType.DataItem,ControlType.Document,ControlType.SplitButton,ControlType.Window,ControlType.Pane,ControlType.Header,
                ControlType.HeaderItem,ControlType.Table,ControlType.TitleBar,ControlType.Separator
            };
        }
    }
}
