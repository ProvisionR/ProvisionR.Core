using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Connectors;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;

namespace MarkTek.SharePoint.Exporter.Export
{
    public class ClientSidePagesExporter : BaseExporter, IExportableComponent
    {

        public ClientSidePagesExporter(ClientContext clientContext) : base(clientContext)
        {
        }

        public ComponentType ComponentType
        {
            get
            {
                return ComponentType.ClientSidePages;
            }
        }

        public string ExportFolderName
        {
            get
            {
                return "ClientSidePages";
            }
        }

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.PageContents);

            Provider.SaveAs(template, $"{ExportFolderName}/ClientSidePages.xml");
        }

        public override ProvisioningTemplateCreationInformation GetProvisionInformation(Web web, Handlers handlers)
        {
            var templateCi = new ProvisioningTemplateCreationInformation(web) { IncludeNativePublishingFiles = true, PersistBrandingFiles =true, PersistPublishingFiles = true };
            templateCi.HandlersToProcess = handlers;
            templateCi.FileConnector = new FileSystemConnector(base.ExportPath,"");

            return templateCi;
        }

    }
}
