using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;

using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System.Linq;
using System.Threading;


namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Navigation
{
    public class NavigationExporter : BaseExporter, IExportableComponent
    {
        public NavigationExporter(ClientContext clientContext) : base(clientContext)
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
