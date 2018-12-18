using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System.Linq;
using System.Threading;

namespace MarkTek.SharePoint.Exporter.SitePolicy
{

    public class SitePolicyExporter : BaseExporter, IExportableComponent
    {
        public SitePolicyExporter(string sharePointUrl, string username, string password) : base(sharePointUrl,username,password)
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
