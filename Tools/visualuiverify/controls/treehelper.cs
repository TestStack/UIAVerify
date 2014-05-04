//---------------------------------------------------------------------------
//
// <copyright file="TreeHelper" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: class with helper methods
//
// History:  
//  08/29/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------
    
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Automation;

namespace VisualUIAVerify.Controls
{
    //containting helper static methods 
    static class TreeHelper
    {
        /// ---------------------------------------------------------
        /// <summary>Returns AutomationElement for TreeNode</summary>
        /// ----------------------------------------------------------
        public static AutomationElement GetNodeElement(TreeNode node)
        {
            System.Diagnostics.Debug.Assert(node.Tag != null);
            return ((AutomationElementTreeNode)node.Tag).AutomationElement;
        }

        /// <summary>
        /// Creates TreeNode for the AutomationElement
        /// </summary>
        public static TreeNode CreateNodeForAutomationElement(AutomationElement element, AutomationElementTreeControl parentControl)
        {
//            System.Diagnostics.Debug.WriteLine("CreateNodeForAutomationElement...");

            TreeNode node = new TreeNode(TreeHelper.GetAutomationElementTreeNodeText(element));
            node.Tag = new AutomationElementTreeNode(element, node, parentControl);

            if ((bool)element.GetCurrentPropertyValue(AutomationElement.IsContentElementProperty))
            {
                node.ForeColor = Color.Black; //.NodeFont = new Font(FontFamily.GenericSerif, 10, FontStyle.Bold);
            }
            else
            {
                node.ForeColor = Color.DarkGray;
            }


            /*************************************************/
            // this is only for test purposes, it makes the creation of each TreeNode slower
            //DateTime now = DateTime.Now;
            //DateTime endTime = now.AddMilliseconds(400);

            //while (DateTime.Now < endTime) ;
            /*************************************************/

//            System.Diagnostics.Debug.WriteLine("CreateNodeForAutomationElement EXIT");

            return node;
        }

        /// <summary>
        /// creates name for AutomationElement
        /// </summary>
        public static string GetAutomationElementTreeNodeText(AutomationElement element)
        {
            System.Diagnostics.Debug.Assert(element != null);

            //let's create buffer for 50 chars
            StringBuilder buffer = new StringBuilder(50);

            // Wrap calls since in the ExceptionNotFound tests, calling the properties throws an exception
            buffer.Append('\"');
            try
            {
                buffer.Append(element.Current.LocalizedControlType);
            }
            catch (ElementNotAvailableException)
            {
                // For the ElementNotAvailableException tests, this might justifiably get thrown.
                buffer.Append("ElementNotAvailable");
            }
            buffer.Append('\"');
            buffer.Append(' ');
            buffer.Append('\"');
            try
            {
                buffer.Append(element.Current.Name);
            }
            catch (ElementNotAvailableException)
            {
                // For the ElementNotAvailableException tests, this might justifiably get thrown.
                // Do something so that OARC does not complain
                buffer.Append("ElementNotAvailable");
            }
            buffer.Append('\"');
            buffer.Append(' ');
            buffer.Append('\"');
            try
            {
                buffer.Append(element.Current.AutomationId);
            }
            catch (ElementNotAvailableException)
            {
                // For the ElementNotAvailableException tests, this might justifiably get thrown.
                // Do something so that OARC does not complain
                buffer.Append("ElementNotAvailable");
            }
            buffer.Append('\"');

            return buffer.ToString();
        }
    }
}
