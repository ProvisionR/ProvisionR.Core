using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace MarkTek.SharePoint.Exporter.Export
{
    public class Audit : BaseExporter, IExportableComponent
    {

        public Audit(ClientContext clientContext) : base(clientContext)
        {
        }

        public ComponentType ComponentType
        {
            get
            {
                return ComponentType.AuditSettings;
            }
        }

        public string ExportFolderName
        {
            get
            {
                return "AuditSettings";
            }
        }

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.AuditSettings);
            Provider.SaveAs(template, $"{ExportFolderName}/AuditSettings.xml");
        }       

    }
}
