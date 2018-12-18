using MarkTek.SharePoint.Provisioning.Core.Configuration;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core.Template;
using System;
using System.IO;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Handlers
{
    public class PnPTemplateHandler : IComponentHandler<PnPTemplateHandler>, IComponentImport
    {
        private ITemplateManager templateManger;
        private IProvisionManager provisioningManager;

        public PnPTemplateHandler(ITemplateManager templateManager, IProvisionManager provisioningManager)
        {
            this.templateManger = templateManager;
            this.provisioningManager = provisioningManager;
        }

        public bool CanHandle(ImportBaseElement x)
        {
            return (x.IsSearchConfig == false && !x.IsCustomScript());
        }

        public void Provision(ImportBaseElement x, string templateRootFolder, string sharePointSiteUrl, string sharePointUserName, string sharePointPassword)
        {
            if (x.Enabled)
            {
                var fullPath = Path.Combine(templateRootFolder, x.SourceFolder);

                if (!templateManger.DirectoryExists(fullPath)) return;

                var templates = templateManger.GetTemplates(fullPath);
                Console.WriteLine($"Deploying from folder : {x.SourceFolder} - Templates found : {templates.Count}");

                templates.ForEach(template =>
                {
                    provisioningManager.Provision(sharePointSiteUrl, sharePointUserName, sharePointPassword, template);
                });
            }
        }
    }
}
