//---------------------------------------------------------------------------
//
// <copyright file="WaitCursor" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Definition of helper class responsible for setting application cursor.
//
// History:  
//  08/29/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace VisualUIAVerify.Misc
{
    /// <summary>
    /// Helper class to set cursors. This class is thread safe.
    /// </summary>
    internal class WaitCursor : IDisposable
    {
        // to stroe number of requests for wait cursors
        private static int _count;

        //used for synchronization
        private static object _SyncObject = new object();

        
        //this will set the cursor to AppStarting if this is first call
        public WaitCursor()
        {
            lock (WaitCursor._SyncObject)
            {
                if (WaitCursor._count == 0)
                {
                    Debug.WriteLine("WaitingCursor - setting cursor to AppStarting");
                    Cursor.Current = Cursors.AppStarting;
                }
                WaitCursor._count++;
            }
        }

        //this will setup the cursor to Default if this is last call
        public void Dispose()
        {
            lock (WaitCursor._SyncObject)
            {
                WaitCursor._count--;
                if (WaitCursor._count == 0)
                {
                    Debug.WriteLine("WaitingCursor - setting cursor to Default");
                    Cursor.Current = Cursors.Default;
                }
                GC.SuppressFinalize(this);
            }
        }
    }
}
