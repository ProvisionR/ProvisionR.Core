using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.SearchSettings
{
    public class PublishingExporter : BaseExporter, IExportableComponent
    {
        public PublishingExporter(ClientContext clientContext) : base(clientContext)
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
