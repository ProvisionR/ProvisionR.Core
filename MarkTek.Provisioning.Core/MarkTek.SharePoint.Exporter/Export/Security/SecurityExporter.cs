﻿using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System.Linq;
using System.Threading;

namespace MarkTek.SharePoint.Exporter.Security
{

    public class SecurityExporter : BaseExporter, IExportableComponent
    {
        public SecurityExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
        {
        }

        public ComponentType ComponentType => ComponentType.Security;
        public string ExportFolderName => "SiteSecurity";

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.ContentTypes);

            Provider.SaveAs(template, $"{ExportFolderName}/SiteSecurity.xml");
        }

        public override ProvisioningTemplateCreationInformation GetProvisionInformation(Web web, Handlers handlers)
        {
            var templateCi = new ProvisioningTemplateCreationInformation(web) { IncludeTermGroupsSecurity = true };
            templateCi.HandlersToProcess = handlers;
            return templateCi;
        }
    }

}
