using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace MarkTek.SharePoint.Exporter.SearchSettings
{
    public class PublishingExporter : BaseExporter, IExportableComponent
    {
        public PublishingExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
        {
        }

        public ComponentType ComponentType => ComponentType.Publishing;

        public string ExportFolderName => "Publishing";
        
        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.Publishing);

            Provider.SaveAs(template, $"{ExportFolderName}/Publishing.xml");
        }

    }
}
