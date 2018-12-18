using MarkTek.SharePoint.Provisioning.Core.Configuration;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarkTek.SharePoint.Provisioning.Tests.UnitTests.Core.Configuration
{
    [TestClass]
    public class ConfigurationTests
    {
        private ProvisioningConfig c;
       
        [TestMethod]
        public void Can()
        {
            c = new ProvisioningConfig
            {
                ImportableElements = new System.Collections.Generic.List<ImportBaseElement>
                {
                    new ImportBaseElement
                    {
                        Enabled=true,
                        IsSearchConfig = true,
                        SourceFolder="Folder",
                        Handler = new CustomExtensibleHander{ ScriptType= ScriptType.PowerShell, CustomCommand="PowerShell.ps1", CustomCommandArguments=new System.Collections.Generic.List<CommandParameter>{
                            new CommandParameter
                            {
                                ParameterName="Name",
                                ParameterValue="Hello World"
                            }
                        } }
                    },
                     new ImportBaseElement
                    {
                        Enabled=true,
                        IsSearchConfig = true,
                        SourceFolder="Folder",
                        Handler = null
                    }
                }
            };

            Assert.IsTrue(c.ImportableElements[0].IsCustomScript());
            Assert.IsFalse(c.ImportableElements[1].IsCustomScript());
        }

    }
}
