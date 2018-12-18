using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace MarkTek.SharePoint.Exporter.Export
{
    public class Audit : BaseExporter, IExportableComponent
    {

        public Audit(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
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
