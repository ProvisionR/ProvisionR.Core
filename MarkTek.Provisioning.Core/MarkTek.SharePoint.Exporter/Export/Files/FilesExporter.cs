using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System.Linq;

namespace MarkTek.SharePoint.Exporter.Files
{
    public class FilesExporter : BaseExporter, IExportableComponent
    {
        public FilesExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
        {
        }

        public ComponentType ComponentType
        {
            get
            {
                return ComponentType.Files;
            }
        }

        public string ExportFolderName
        {
            get
            {
                return "Files";
            }
        }

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.Files);

            template.Files.ToList().ForEach(x =>
            {
                //var p = new ProvisioningTemplate();
                //p.Features.SiteFeatures.Add(x);
                //provider.SaveAs(p, $"{ExportFolderName}/SiteFeatures/{x.TargetFileName}.xml");
            });

        }
    }
}