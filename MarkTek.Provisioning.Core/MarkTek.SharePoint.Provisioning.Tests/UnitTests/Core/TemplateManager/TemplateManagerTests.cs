using System;
using MarkTek.SharePoint.Provisioning.Core.Template;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarkTek.SharePoint.Provisioning.Tests.UnitTests.Core
{
    [TestClass]
    public class TemplateManagerTests
    {
        [TestMethod]
        public void Can_Check_TemplateManager_Directory_Exists()
        {
            var c = new TemplateManager(MockObjects.MockObjects.GetMockDirectoryService(true).Object);
            var res = c.DirectoryExists(Environment.CurrentDirectory);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Can_Get_Templates_From_TemplateManager_Files()
        {
            var c = new TemplateManager(MockObjects.MockObjects.GetMockDirectoryService(true).Object);
            var res = c.GetTemplates(Environment.CurrentDirectory, "*.xml");
        }

    }
}
