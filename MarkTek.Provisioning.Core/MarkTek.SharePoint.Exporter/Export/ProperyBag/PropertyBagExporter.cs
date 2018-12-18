using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System.Linq;

namespace MarkTek.SharePoint.Exporter.PropertyBag
{
    public class PropertyBagExporter : BaseExporter, IExportableComponent
    {

        public PropertyBagExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
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