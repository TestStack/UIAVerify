//---------------------------------------------------------------------------
//
// <copyright file="AutomationElementTreeControlEvents" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: definition delegates and event agruments for AutomationElementTreeControl
//
// History:  
//  09/06/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace VisualUIAVerify.Controls
{
    /// <summary>
    /// this delegate is used to SelectedNodeChanged event of AutomationElementTreeControl
    /// </summary>
    public delegate void SelectedNodeChangedEventDelegate(object sender, EventArgs e);

}
