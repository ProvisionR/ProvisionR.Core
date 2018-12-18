using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

using System.Linq;

namespace MarkTek.SharePoint.Exporter.Lists
{
    public class ListExporter : BaseExporter, IExportableComponent
    {

        public ListExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
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