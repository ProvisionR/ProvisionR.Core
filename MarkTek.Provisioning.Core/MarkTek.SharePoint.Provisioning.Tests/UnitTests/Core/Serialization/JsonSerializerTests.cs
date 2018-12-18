using System;
using System.IO;
using MarkTek.SharePoint.Provisioning.Core.JsonSerialiser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarkTek.SharePoint.Provisioning.Tests.UnitTests.Core.Serialization
{
    [TestClass]
    public class JsonSerializerTests
    {
        private JsonConverter s;

        [TestMethod]
        public void Can_Serialise_Object()
        {
            s = new JsonConverter();

            var file = s.GetJsonFile(MockObjects.MockObjects.GetProvisioningConfig());

            Assert.IsNotNull(file);

        }

        [TestMethod]
        public void Can_Get_Config_From_File()
        {
            s = new JsonConverter();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "UnitTests\\import.json");
            var file = s.GetConfiguration(path);

            Assert.IsNotNull(file);
            Assert.IsNotNull(file.ImportableElements);

        }
    }
}

