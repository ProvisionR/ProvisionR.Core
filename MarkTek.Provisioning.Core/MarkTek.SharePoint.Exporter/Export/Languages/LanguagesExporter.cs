using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using Microsoft.SharePoint.Client;

namespace MarkTek.SharePoint.Exporter.Languages
{
    public class LanguagesExporter : BaseExporter, IExportableComponent
    {

        public LanguagesExporter(ClientContext clientContext) : base(clientContext)
        {
        }

        public ComponentType ComponentType=> ComponentType.SupportedUILanguages;
            
        public string ExportFolderName => "SupportedUILanguages";

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.SupportedUILanguages);
            Provider.SaveAs(template, $"{ExportFolderName}/SupportedUILanguages.xml");
        }

    }
}
