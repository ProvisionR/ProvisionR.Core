using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTek.SharePoint.Exporter.SiteProperties
{
    public class SitePropertiesExporter : BaseExporter, IExportableComponent
    {
        public SitePropertiesExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
        {
        }

        public ComponentType ComponentType =>ComponentType.Properties;

        public string ExportFolderName => "SiteProperties";

        public override void Export()
        {

            //var ctx = AcquireContext();
            //var templateCi = new ProvisioningTemplateCreationInformation(ctx.Web);
            //templateCi.HandlersToProcess = Handlers.PropertyBagEntries;

            //var template = ctx.Web.GetProvisioningTemplate(templateCi);

            //XMLTemplateProvider provider = new XMLFileSystemTemplateProvider(ExportPath, string.Empty);

            //provider.SaveAs(template, "Property.xml");

            //var id = template.Lists;

            //id.ToList().ForEach(x =>
            //{
            //    var p = new ProvisioningTemplate();
            //    p.Lists.Add(x);
            //    provider.SaveAs(p, $"{ExportFolderName}/{x.Title}.xml");
            //});
        }
    }
}
