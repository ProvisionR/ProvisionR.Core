using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;

using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System.Linq;
using System.Threading;


namespace MarkTek.SharePoint.Exporter.Navigation
{
    public class NavigationExporter : BaseExporter, IExportableComponent
    {
        public NavigationExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
        {
        }

        public ComponentType ComponentType =>ComponentType.Navigation;
            
        public string ExportFolderName=> "Navigation";
           
        /// <summary>
        /// POC Code for now to try, will be refactored once working
        /// </summary>
        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.Navigation);
            Provider.SaveAs(template, $"{ExportFolderName}/Navigation.xml");
        }
    }

}
