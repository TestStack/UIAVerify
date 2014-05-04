// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Automation;
using System.Runtime.InteropServices;

namespace VisualUIAVerify
{
    static class Program
    {
        [DllImport("UIAutomationCore.dll", CharSet = CharSet.Unicode)]
        private static extern void UiaRegisterProviderCallback(IntPtr callback);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            try
            {
                System.Diagnostics.Debug.AutoFlush = true;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Forms.MainWindow(args));

                Automation.RemoveAllEventHandlers();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            System.Diagnostics.Debug.Fail(e.Exception.Message, e.Exception.StackTrace);
        }
    }
}