using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Connectors;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export
{
    public class WebSettingsExporter : BaseExporter, IExportableComponent
    {

        public WebSettingsExporter(ClientContext clientContext) : base(clientContext)
        {
        }

        public ComponentType ComponentType
        {
            get
            {
                return ComponentType.WebSettings;
            }
        }

        public string ExportFolderName
        {
            get
            {
                return "WebSettings";
            }
        }

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.WebSettings);

            Provider.SaveAs(template, $"{ExportFolderName}/WebSettings.xml");
        }

       

    }
}
