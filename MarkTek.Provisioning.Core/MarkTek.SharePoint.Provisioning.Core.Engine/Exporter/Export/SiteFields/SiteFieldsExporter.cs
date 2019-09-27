using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System.Linq;
using System.Xml.Linq;
using Microsoft.SharePoint.Client;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.SiteFields
{

    public class SiteFieldsExporter : BaseExporter, IExportableComponent
    {
        public SiteFieldsExporter(ClientContext clientContext) : base(clientContext)
        {
        }

        public ComponentType ComponentType => ComponentType.SiteFields;
        
        public string ExportFolderName => "SiteFields";
    
        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.Fields);

            template.SiteFields.ToList().ForEach(x =>
            {
                var p = new ProvisioningTemplate();
                p.MapFieldsFromParent(template);
                p.SiteFields.Add(x);
                Provider.SaveAs(p, $"{ExportFolderName}/{XElement.Parse(x.SchemaXml).Attribute("DisplayName").Value}.xml");
            });
        }
    }
}
