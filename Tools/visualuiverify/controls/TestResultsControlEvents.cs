//---------------------------------------------------------------------------
//
// <copyright file="TestResultsControlEvents" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: definition delegates and event agruments for TestResultsControl
//
// History:  
//  10/12/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace VisualUIAVerify.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public class NavigationChangedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly TestResultsControl.LogTypes LogType;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LogType"></param>
        public NavigationChangedEventArgs(TestResultsControl.LogTypes LogType)
        {
            this.LogType = LogType;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void NavigationChangedEventHandler(object sender, NavigationChangedEventArgs e);

}
