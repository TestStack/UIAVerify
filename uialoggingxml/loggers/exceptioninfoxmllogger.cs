// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Test.UIAutomation.Logging.InfoObjects
{
    using Microsoft.Test.UIAutomation.Logging.XmlSerializableObjects;

    class ExceptionInfoObject : ILoggedComponent
    {
        public void Persist(object Object)
        {
            if (Object is ExceptionInfo)
            {
                XmlLog.CurrentTest.AddException(new XmlExceptionInfo((ExceptionInfo)Object));
            }
            else
                ExceptionsHelper.ThrowObjectLoggerDoesNotSupportThisObjectType(Object, typeof(ExceptionInfo));
        }
    }
}
