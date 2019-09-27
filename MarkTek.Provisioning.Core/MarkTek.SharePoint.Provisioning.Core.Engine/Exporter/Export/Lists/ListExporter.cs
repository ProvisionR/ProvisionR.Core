using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using Microsoft.SharePoint.Client;
using System.Linq;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Lists
{
    public class ListExporter : BaseExporter, IExportableComponent
    {

        public ListExporter(ClientContext clientContext) : base(clientContext)
        {
        }

        public ComponentType ComponentType => ComponentType.Lists;

        public string ExportFolderName => "Lists";

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.Lists);

            template.Lists.ToList().ForEach(x =>
            {
                var p = new ProvisioningTemplate();
                p.Lists.Add(x);
                p.MapFieldsFromParent(template);
                Provider.SaveAs(p, $"{ExportFolderName}/{x.Title}.xml");
            });
        }        
    }
}