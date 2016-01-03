// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Automation;

namespace VisualUIAVerify.Controls
{
    using VisualUIAVerify.Features;

    public partial class AutomationElementPropertyGrid : UserControl
    {
        private AutomationElement _automationElement;
        private bool _expandAll;

        /// <summary>
        /// 
        /// </summary>
        public AutomationElementPropertyGrid()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(null)]
        public AutomationElement AutomationElement
        {
            get { return this._automationElement; }
            set
            {
                this._automationElement = value;
                RefreshValues();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PropertySort PropertySort
        {
            get { return _propertyGrid.PropertySort; }
            set { _propertyGrid.PropertySort = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        public bool ExpandAll
        {
            get { return this._expandAll; }
            set
            { 
                this._expandAll = value;
                if (value)
                    _propertyGrid.ExpandAllGridItems();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshValues()
        {
             _propertyGrid.SelectedObject = new AutomationElementPropertyObject(this._automationElement);

            if (this._expandAll)
                _propertyGrid.ExpandAllGridItems();
        }
    }
}
