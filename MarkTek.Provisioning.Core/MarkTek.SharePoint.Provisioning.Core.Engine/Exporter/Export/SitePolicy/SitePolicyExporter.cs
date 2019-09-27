using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.SitePolicy
{

    public class SitePolicyExporter : BaseExporter, IExportableComponent
    {
        public SitePolicyExporter(ClientContext clientContext) : base(clientContext)
        {           
        }

        public ComponentType ComponentType => ComponentType.SitePolicy;
        
        public string ExportFolderName => "SitePolicy";
            
        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.SitePolicy);            
            Provider.SaveAs(template, $"{ExportFolderName}/SitePolicy.xml");
        }

    }

}
