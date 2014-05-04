//---------------------------------------------------------------------------
//
// <copyright file="ApplicationLogger" company="Microsoft">
// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.
// </copyright>
// 
//
// Description: Used to log running application 
//
// History:  
//  09/05/2006 : Ondrej Lehecka, created
//
//---------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Text;

namespace VisualUIAVerify.Misc
{
    /// <summary>
    /// this class is used to log running application
    /// </summary>
    class ApplicationLogger
    {
        //definitions of used delegates
        public delegate void LoggingProgressEventDelegate(string message, int percentage);
        public delegate void LoggingExceptionEventDelegate(Exception ex);

        //definitions of logging events
        public static event LoggingProgressEventDelegate LoggingProgress;
        public static event LoggingExceptionEventDelegate LoggingException;

        /// <summary>
        /// this method will log progress of some task
        /// </summary>
        /// <param name="message">short message identifying task</param>
        /// <param name="percentage">pecentage part of done task</param>
        public static void LogProgress(string message, int percentage)
        {
            if (LoggingProgress != null)
                LoggingProgress(message, percentage);
        }

        /// <summary>
        /// this method will log expected exception
        /// </summary>
        /// <param name="ex"></param>
        public static void LogException(Exception ex)
        {
            if (LoggingException != null)
                LoggingException(ex);
        }
    }
}
