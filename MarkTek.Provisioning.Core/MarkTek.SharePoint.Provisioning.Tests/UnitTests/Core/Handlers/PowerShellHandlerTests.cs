using MarkTek.SharePoint.Provisioning.Core.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarkTek.SharePoint.Provisioning.Tests.UnitTests.Core.Handlers
{
    [TestClass]
    public class PowerShellHandlerTests
    {
        private PowerShellHandler powerShellHandler;

        [TestInitialize]
        public void Setup()
        {
            powerShellHandler = new PowerShellHandler();
        }
        
        [TestMethod]
        public void Can_Handle_When_CustomScript_Is_True()
        {
            powerShellHandler.CanHandle(new SharePoint.Provisioning.Core.Configuration.ImportBaseElement());
        }
                

        //public void Can_Error_When_Invalid()
        //{
        //   throw new NotImplementedException();
        //}

        //public void Can_Provision_When_Valid_With_Parameters()
        //{
        //   throw new NotImplementedException();
        //}

    }
}
