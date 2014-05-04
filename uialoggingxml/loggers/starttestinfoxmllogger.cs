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

    class StartTestInfoObject : ILoggedComponent
    {
        public void Persist(object Object)
        {
            if (Object is StartTestInfo)
            {
                XmlLog.StartNewTest();
                XmlLog.CurrentTest.TestInfo = new XmlTestInfo((StartTestInfo)Object);

                string possibleIssuesMessage = ((StartTestInfo)Object).PossibleIssuesMessage;
                if(!string.IsNullOrEmpty(possibleIssuesMessage))
                    new CommentInfoObject().Persist(new CommentInfo(possibleIssuesMessage));
            }
            else
                ExceptionsHelper.ThrowObjectLoggerDoesNotSupportThisObjectType(Object, typeof(StartTestInfo));
        }
    }
}
