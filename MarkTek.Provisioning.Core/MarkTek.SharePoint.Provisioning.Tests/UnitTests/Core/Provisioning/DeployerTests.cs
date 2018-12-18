using System;
using MarkTek.SharePoint.Provisioning.Core.Configuration;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarkTek.SharePoint.Provisioning.Tests.UnitTests.Core.Provisioning
{
    [TestClass]
    public class DeployerTests
    {
        private Mock<IHandlerFactory> factory;

        public Deployer Deployer { get; private set; }

        [TestInitialize]
        public void Setuo()
        {
            factory = MockObjects.MockObjects.GetMockHandlerFactory();
            Deployer = new Deployer(MockObjects.MockObjects.GetMockTemplateManager().Object, MockObjects.MockObjects.GetMockProvisionManager().Object, factory.Object, MockObjects.MockObjects.GetMockTokeniser().Object);
        }

        [TestMethod]
        public void Deployer_Can_Deploy()
        {
            Deployer.Deploy(MockObjects.MockObjects.GetMockProvisionConfig(), "", "", "", "");
            factory.Verify(x => x.GetHandlerForElement(It.IsAny<ImportBaseElement>()), Times.Exactly(2));
        }
    }
}
