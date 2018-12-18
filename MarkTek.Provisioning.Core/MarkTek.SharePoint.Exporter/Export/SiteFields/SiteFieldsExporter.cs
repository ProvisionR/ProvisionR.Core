using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System.Linq;
using System.Xml.Linq;

namespace MarkTek.SharePoint.Exporter.SiteFields
{

    public class SiteFieldsExporter : BaseExporter, IExportableComponent
    {
        public SiteFieldsExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
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
