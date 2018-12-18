using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System.Linq;

namespace MarkTek.SharePoint.Exporter.Pages
{
    public class PagesExporter : BaseExporter, IExportableComponent
    {

        public PagesExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
        {
        }

        public ComponentType ComponentType
        {
            get
            {
                return ComponentType.Pages;
            }
        }

        public string ExportFolderName
        {
            get
            {
                return "Pages";
            }
        }

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.Pages);

            template.Pages.ToList().ForEach(x =>
            {
                var p = new ProvisioningTemplate();
                p.Pages.Add(x);
                p.MapFieldsFromParent(template);
                Provider.SaveAs(p, $"{ExportFolderName}/{x.Fields["Name"]}.xml");
            });
        }
    }
}
