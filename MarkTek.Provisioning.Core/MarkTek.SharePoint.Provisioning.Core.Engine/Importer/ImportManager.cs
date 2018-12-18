using MarkTek.SharePoint.Provisioning.Core.Engine.DependencyResolution;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using StructureMap;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Importer
{
    /// <summary>
    /// A Facade Class to help you to Import SharePoint Customisations from PowerShell
    /// </summary>
    public class ImportManager
    {
        private IContainer container;

        public void Import(string SharePointSiteUrl, string SharePointUserName, string SharePointPassword, string ImportConfigPath, string TemplateRootFolder)
        {
            IOC.Register();
            container = IOC.GetContainer();
                        
            IJsonConverter converter = container.GetInstance<IJsonConverter>();
            var mapped = converter.GetConfiguration(ImportConfigPath);
            
            IDeployer deployer = container.GetInstance<IDeployer>();
            deployer.Deploy(mapped, TemplateRootFolder,  SharePointSiteUrl,  SharePointUserName, SharePointPassword);

        }
    }
}