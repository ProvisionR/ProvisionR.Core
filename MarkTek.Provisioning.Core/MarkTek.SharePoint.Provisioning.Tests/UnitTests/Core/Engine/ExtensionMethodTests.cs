using MarkTek.SharePoint.Provisioning.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MarkTek.SharePoint.Provisioning.Tests.UnitTests.Core.Engine
{
    [TestClass]
    public class ExtensionMethodTests
    {
        [TestMethod]
        public void Can_Get_SecureString_From_ClearText()
        {
            var res = "AAAUAYAU";
            var output = res.GetSecureString();
            Assert.IsInstanceOfType(output, typeof(SecureString));
        }
    }  

}
