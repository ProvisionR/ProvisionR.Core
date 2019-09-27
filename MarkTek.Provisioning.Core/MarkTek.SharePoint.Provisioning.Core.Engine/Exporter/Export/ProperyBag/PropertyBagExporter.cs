using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System.Linq;
using Microsoft.SharePoint.Client;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.PropertyBag
{
    public class PropertyBagExporter : BaseExporter, IExportableComponent
    {

        public PropertyBagExporter(ClientContext clientContext) : base(clientContext)
        {
        }

        public ComponentType ComponentType => ComponentType.PropertyBagEntries;

        public string ExportFolderName => "PropertyBag";
            
        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.PropertyBagEntries);

            template.PropertyBagEntries.ToList().ForEach(x =>
            {
                var p = new ProvisioningTemplate();
                p.PropertyBagEntries.Add(x);
                p.MapFieldsFromParent(template);
                Provider.SaveAs(p, $"{ExportFolderName}/{x.Key}.xml");
            });
        }
    }
}