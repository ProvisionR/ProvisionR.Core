using System;
using MarkTek.SharePoint.Provisioning.Core.Engine;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core.Template;
using Microsoft.SharePoint.Client.Search.Administration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace MarkTek.SharePoint.Provisioning.Tests.UnitTests.Core.Handlers
{
    [TestClass]
    public class HandlerTests
    {
        private PnPTemplateHandler pnpTemplateHandler;
        private SharePointSearchHandler searchTemplateHadler;
        Mock<ITemplateManager> templateManager;
        Mock<IProvisionManager> provisionManager;

        [TestInitialize]
        public void Setup()
        {
            templateManager = MockObjects.MockObjects.GetMockTemplateManager();
            provisionManager = MockObjects.MockObjects.GetMockProvisionManager();

            pnpTemplateHandler = new PnPTemplateHandler(templateManager.Object, provisionManager.Object);
            searchTemplateHadler = new SharePointSearchHandler(templateManager.Object, provisionManager.Object);
        }

        [TestMethod]
        public void Can_Handle_Standard_Template()
        {
            Assert.IsTrue(pnpTemplateHandler.CanHandle(MockObjects.MockObjects.GetImportElement(false, true)));
        }

        [TestMethod]
        public void Can_PnPHandler_Handle_Search_Confg()
        {
            Assert.IsFalse(pnpTemplateHandler.CanHandle(MockObjects.MockObjects.GetImportElement(true, true)));
        }

        [TestMethod]
        public void Can_PnPHandler_Provision_When_Config_Enabled()
        {
            templateManager.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(true);
            pnpTemplateHandler = new PnPTemplateHandler(templateManager.Object, provisionManager.Object);

            pnpTemplateHandler.Provision(MockObjects.MockObjects.GetImportElement(false,true), Environment.CurrentDirectory, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            
            templateManager.Verify(x => x.GetTemplates(It.IsAny<string>()), Times.Once);
            templateManager.Verify(x => x.DirectoryExists(It.IsAny<string>()), Times.Once);

        }

        [TestMethod]
        public void Can_Skip_Processing_When_Directory_Not_Found()
        {
            templateManager.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(false);
            
            pnpTemplateHandler.Provision(MockObjects.MockObjects.GetImportElement(false, true), Environment.CurrentDirectory, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            templateManager.Verify(x => x.GetTemplates(It.IsAny<string>()), Times.Never);
            templateManager.Verify(x => x.DirectoryExists(It.IsAny<string>()), Times.Once);

        }


        [TestMethod]
        public void Can_PnPHandler_Provision_When_Config_Disabled()
        {
            pnpTemplateHandler.Provision(MockObjects.MockObjects.GetImportElement(true, false), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
            templateManager.Verify(x => x.GetTemplates(It.IsAny<string>()), Times.Never);
        }


        [TestMethod]
        public void Can_SearchHandler_Handle_Standard_Template()
        {
            Assert.IsTrue(searchTemplateHadler.CanHandle(MockObjects.MockObjects.GetImportElement(true,true)));
        }

        [TestMethod]
        public void Can_SearchHandler_Handle_Search_Template()
        {
            Assert.IsFalse(searchTemplateHadler.CanHandle(MockObjects.MockObjects.GetImportElement(false, true)));
        }


        [TestMethod]
        public void Can_SearchHandler_Provision_When_Config_Enabled()
        {
            templateManager.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(true);
            searchTemplateHadler = new SharePointSearchHandler(templateManager.Object, provisionManager.Object);

            searchTemplateHadler.Provision(MockObjects.MockObjects.GetImportElement(true, true), Environment.CurrentDirectory, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            templateManager.Verify(x => x.GetTemplates(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            provisionManager.Verify(x => x.ProvisionSearchSchema(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<SearchObjectLevel>()), Times.Once);
        }


    }
}
