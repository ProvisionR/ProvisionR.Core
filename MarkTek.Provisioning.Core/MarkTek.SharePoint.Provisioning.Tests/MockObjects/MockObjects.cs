using MarkTek.SharePoint.Provisioning.Core.Configuration;
using MarkTek.SharePoint.Provisioning.Core.Engine;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core.Template;
using Microsoft.SharePoint.Client.Search.Administration;
using Moq;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System.Collections.Generic;

namespace MarkTek.SharePoint.Provisioning.Tests.MockObjects
{
    public class MockObjects
    {
        public static Mock<IProvisionContainer> GetContainer()
        {
            var res = new Mock<IProvisionContainer>();

            res.Setup(x => x.GetAllInstances<IComponentImport>()).Returns((new List<IComponentImport> {
                new PnPTemplateHandler(GetMockTemplateManager().Object,GetMockProvisionManager().Object),
                new SharePointSearchHandler(GetMockTemplateManager().Object,GetMockProvisionManager().Object),
                new PowerShellHandler()
            }));

            return res;
        }

        public static Mock<ITokeniser> GetMockTokeniser()
        {
            var tokeniser = new Mock<ITokeniser>();
            tokeniser.Setup(x => x.TokeniseDirectory(It.IsAny<string>(), It.IsAny<List<Token>>(),  true)).Verifiable("Unable to Create Mock Tokeniser");
            return tokeniser;
        }

        internal static ProvisioningConfig GetProvisioningConfig()
        {
            return new ProvisioningConfig
            {
                ImportableElements = new List<ImportBaseElement>
                {
                    new ImportBaseElement
                    {
                        Enabled=true,
                         Handler= new CustomExtensibleHander
                         {                             
                             ScriptType= ScriptType.PowerShell
                         },
                          IsSearchConfig=false,
                          SourceFolder="Folder1"
                    }
                }
            };
        }

        internal static ProvisioningConfig GetMockProvisionConfig()
        {
            return new ProvisioningConfig
            {
                ImportableElements = new List<ImportBaseElement>
                {
                    new ImportBaseElement
                    {
                        Enabled=true
                    },
                    new ImportBaseElement
                    {
                        Enabled = true,
                        IsSearchConfig = true
                    }
                }
            };
        }

        public static Mock<IHandlerFactory> GetMockHandlerFactory()
        {
            var factory = new Mock<IHandlerFactory>();
            factory.Setup(x => x.GetHandlerForElement(It.IsAny<ImportBaseElement>())).Returns(GetMockPnPHandler().Object);
            return factory;
        }

        public static Mock<IComponentImport> GetMockPnPHandler()
        {
            return new Mock<IComponentImport>();
        }

        internal static ImportBaseElement GetImportElement(bool IsSearchConfig, bool IsEnabled)
        {
            var res = new ImportBaseElement
            {
                IsSearchConfig = IsSearchConfig,
                Enabled = IsEnabled,
                SourceFolder = "Test"
            };

            if (res.IsSearchConfig)
            {
                res.SearchConfiguration = new SearchConfiguration
                {
                    SearchObjectLevel = SearchObjectLevel.SPSite,
                };
            }

            return res;

        }

        public static Mock<ITemplateManager> GetMockTemplateManager()
        {
            var mock = new Mock<ITemplateManager>();
            mock.Setup(x => x.GetTemplates(It.IsAny<string>())).Returns(new List<OfficeDevPnP.Core.Framework.Provisioning.Model.ProvisioningTemplate>
            {
                new OfficeDevPnP.Core.Framework.Provisioning.Model.ProvisioningTemplate()
            });

            mock.Setup(x => x.GetTemplates(It.IsAny<string>(), It.IsAny<string>())).Returns(
                new string[] { "A", "B" }
            );

            return mock;
        }

        public static Mock<IProvisionManager> GetMockProvisionManager()
        {
            return new Mock<IProvisionManager>();
        }

        internal static Mock<ISharePointContext> GetMockSharePointContext()
        {
            var c = new Mock<ISharePointContext>();

            c.Setup(x => x.ApplyProvisioningTemplate(It.IsAny<ProvisioningTemplate>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Verifiable();
            c.Setup(x => x.ApplySearchSchema(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<SearchObjectLevel>())).Verifiable();

            return c;
        }

        internal static Mock<IDirectoryService> GetMockDirectoryService(bool directoryExists)
        {
            var mockDirectoryService = new Mock<IDirectoryService>();
            mockDirectoryService.Setup(x => x.DirectoryExists(It.IsAny<string>())).Returns(directoryExists);
            mockDirectoryService.Setup(x => x.GetAllFiles(It.IsAny<string>(), It.IsAny<string>())).Returns(new List<string>
            {
                "//Test/Test",
                "//Test/Test",
                "//Test/Test",
                "//Test/Test",
                "//Test/Test",
                "//Test/Test"
            });
            mockDirectoryService.Setup(x => x.GetFileContent(It.IsAny<string>())).Returns("Sample Text with Some {{token}} internal tokens added");
            mockDirectoryService.Setup(x => x.SaveFileContent(It.IsAny<string>(), It.IsAny<string>())).Verifiable();

            return mockDirectoryService;
        }
    }
}
