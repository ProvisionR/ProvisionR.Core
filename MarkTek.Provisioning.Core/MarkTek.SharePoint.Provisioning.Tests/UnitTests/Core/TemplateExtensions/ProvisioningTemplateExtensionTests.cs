using System;
using MarkTek.SharePoint.Provisioning.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarkTek.SharePoint.Provisioning.Tests.UnitTests.Core.TemplateExtensions
{
    [TestClass]
    public class TemplateExtensionTests
    {
      
       
        [TestMethod]
        public void Can_TemplateExtension_Map_Fields_For_Splitting()
        {
            var original = new OfficeDevPnP.Core.Framework.Provisioning.Model.ProvisioningTemplate()
            {
                Id = Guid.NewGuid().ToString(),
                Version = 1,
                Scope = OfficeDevPnP.Core.Framework.Provisioning.Model.ProvisioningTemplateScope.RootSite,
                BaseSiteTemplate = "STS0"
            };

            var newTemplate = new OfficeDevPnP.Core.Framework.Provisioning.Model.ProvisioningTemplate();

            ProvisioningTemplateExtension.MapFieldsFromParent(newTemplate, original);

            Assert.AreEqual(original.Id, newTemplate.Id);
            Assert.AreEqual(original.Version, newTemplate.Version);
            Assert.AreEqual(original.Scope, newTemplate.Scope);
            Assert.AreEqual(original.BaseSiteTemplate, newTemplate.BaseSiteTemplate);
        }
    }
}
