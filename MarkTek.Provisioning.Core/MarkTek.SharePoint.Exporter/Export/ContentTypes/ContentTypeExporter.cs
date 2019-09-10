using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System.Linq;

namespace MarkTek.SharePoint.Exporter.ContentTypes
{
    public class ContentTypeExporter : BaseExporter, IExportableComponent
    {

        public ContentTypeExporter(ClientContext clientContext) : base(clientContext)
        {
        }

        public ComponentType ComponentType => ComponentType.ContentTypes;

        public string ExportFolderName => "ContentTypes";

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.ContentTypes);

            template.ContentTypes.ToList().ForEach(x =>
            {
                var p = new ProvisioningTemplate();
                p.ContentTypes.Add(x);
                p.MapFieldsFromParent(template);
                Provider.SaveAs(p, $"{ExportFolderName}/{x.Name}.xml");
            });
        }

        public override ProvisioningTemplateCreationInformation GetProvisionInformation(Web web, Handlers handlers)
        {
            var templateCi = new ProvisioningTemplateCreationInformation(web) { IncludeContentTypesFromSyndication = true };
            templateCi.HandlersToProcess = handlers;
            return templateCi;
        }


    }
}
