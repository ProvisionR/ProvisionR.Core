using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using System.Linq;

namespace MarkTek.SharePoint.Exporter.TermGroup
{
    public class ExportTermGroup : BaseExporter, IExportableComponent
    {


        public ExportTermGroup(ClientContext clientContext) : base(clientContext)
        {
        }

        public string ExportFolderName => "TermGroups";

        public ComponentType ComponentType => ComponentType.TermGroups;

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.TermGroups);

            template.TermGroups.ToList().ForEach(x =>
                {
                    var p = new ProvisioningTemplate();
                    p.MapFieldsFromParent(template);
                    p.TermGroups.Add(x);
                    Provider.SaveAs(p, $"{ExportFolderName}/{x.Name}.xml");
                });
        }

        public override ProvisioningTemplateCreationInformation GetProvisionInformation(Web web, Handlers handlers)
        {
            var templateCi = new ProvisioningTemplateCreationInformation(web) { IncludeAllTermGroups = true, IncludeSiteCollectionTermGroup = true };
            templateCi.HandlersToProcess = handlers;
            return templateCi;
        }

    }
}
