using System;
using MarkTek.SharePoint.Provisioning.Core;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client.Search.Administration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace MarkTek.SharePoint.Provisioning.Tests.UnitTests.Core.Provisioning
{
    [TestClass]
    public class ProvisionManagerTests
    {
        Mock<ISharePointContext> context;

        [TestInitialize]
        public void Setup()
        {
            context = MockObjects.MockObjects.GetMockSharePointContext();
        }

        [TestMethod]
        public void Can_ProvisionManager_Execute_Template()
        {
            
            var c = new ProvisionManager(context.Object);
            c.Provision(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ProvisioningTemplate>());
            context.Verify(x => x.ApplyProvisioningTemplate(It.IsAny<ProvisioningTemplate>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Can_ProvisionManager_Execute_Search_Template()
        {
            var c = new ProvisionManager(context.Object);
            c.ProvisionSearchSchema(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<SearchObjectLevel>());
            context.Verify(x => x.ApplySearchSchema(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<SearchObjectLevel>()), Times.Once);
        }


    }
}
