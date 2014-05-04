// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Test.UIAutomation.Logging
{
    public class ObjectLoggerDoesNotSupportThisObjectType : ArgumentException
    {
        public readonly object Object;
        public readonly Type ExpectedObjectType;

        public ObjectLoggerDoesNotSupportThisObjectType(object Object, Type ExpectedObjectType)
        {
            this.Object = Object;
            this.ExpectedObjectType = ExpectedObjectType;
        }
    }

    static class ExceptionsHelper
    {
        public static void ThrowObjectLoggerDoesNotSupportThisObjectType(object Object, Type ExpectedObjectType)
        {
            throw new ObjectLoggerDoesNotSupportThisObjectType(Object, ExpectedObjectType);
        }
    }
}
