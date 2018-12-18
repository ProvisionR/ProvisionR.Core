using MarkTek.SharePoint.Provisioning.Core;
using MarkTek.SharePoint.Provisioning.Core.Engine.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarkTek.SharePoint.Provisioning.Tests.UnitTests.Core.Factory
{
    [TestClass]
    public class HandlerFactoryTests
    {
        public HandlerFactory factory { get; private set; }

        [TestCategory("Unit Tests")]
        [TestInitialize]
        public void Setup()
        {
            factory = new HandlerFactory(MockObjects.MockObjects.GetContainer().Object);
        }

        [TestMethod]
        public void Can_Get_PnPHandler()
        {
            var handler = factory.GetHandlerForElement(MockObjects.MockObjects.GetImportElement(false,true));

            Assert.IsNotNull(handler);
            Assert.IsInstanceOfType(handler, typeof(PnPTemplateHandler));
        }

        [TestMethod]
        public void Can_Get_SearchHandler_When_IsSearchConfig_Is_True()
        {
            var handler = factory.GetHandlerForElement(MockObjects.MockObjects.GetImportElement(true, true));

            Assert.IsNotNull(handler);
            Assert.IsInstanceOfType(handler, typeof(SharePointSearchHandler));
        }
    }
}
