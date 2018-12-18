using System;
using System.IO;
using MarkTek.SharePoint.Provisioning.Core.Configuration;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core.Template;

namespace MarkTek.SharePoint.Provisioning
{
    public class Deployer : IDeployer
    {
        private readonly ITemplateManager templateManger;
        private readonly IProvisionManager provisioningManager;
        private readonly IHandlerFactory handlerFactory;
        private readonly ITokeniser tokeniser;

        public Deployer(ITemplateManager templateManager, IProvisionManager provisioningManager, IHandlerFactory handlerFactory, ITokeniser tokeniser)
        {
            this.templateManger = templateManager;
            this.provisioningManager = provisioningManager;
            this.handlerFactory = handlerFactory;
            this.tokeniser = tokeniser;
        }

        public void Deploy(ProvisioningConfig res, string templateRootFolder, string SharePointSiteUrl, string SharePointUserName, string SharePointPassword)
        {
            tokeniser.TokeniseDirectory(templateRootFolder, res.Tokens, true);

            res.ImportableElements.ForEach(x =>
            {
                var handler = this.handlerFactory.GetHandlerForElement(x);
                handler.Provision(x, templateRootFolder, SharePointSiteUrl, SharePointUserName, SharePointPassword);
            });
        }
    }
}
