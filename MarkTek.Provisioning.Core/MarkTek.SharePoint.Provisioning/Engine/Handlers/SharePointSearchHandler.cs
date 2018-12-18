using MarkTek.SharePoint.Provisioning.Core.Configuration;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core.Template;
using System.IO;
using System.Linq;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Handlers
{
    public class SharePointSearchHandler : IComponentHandler<SharePointSearchHandler>, IComponentImport
    {
        private ITemplateManager templateManger;
        private IProvisionManager provisioningManager;

        public SharePointSearchHandler(ITemplateManager templateManager, IProvisionManager provisioningManager)
        {
            this.templateManger = templateManager;
            this.provisioningManager = provisioningManager;
        }
        
        public bool CanHandle(ImportBaseElement x)
        {
            return x.IsSearchConfig == true;
        }

        public void Provision(ImportBaseElement x, string templateRootFolder, string sharePointSiteUrl, string sharePointUserName, string sharePointPassword)
        {
            if (x.Enabled)
            {
                var fullPath = Path.Combine(templateRootFolder, x.SourceFolder);

                var files = templateManger.GetTemplates(fullPath, "*.xml");
                var config = files.FirstOrDefault();

                provisioningManager.ProvisionSearchSchema(sharePointSiteUrl, sharePointUserName, sharePointPassword, config, x.SearchConfiguration.SearchObjectLevel);
            }
        }
    }
}
