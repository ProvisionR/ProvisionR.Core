using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTek.SharePoint.Exporter.CustomActions
{
    public class CustomActionsExporter : BaseExporter, IExportableComponent
    {

        public CustomActionsExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
        {
        }

        public ComponentType ComponentType=> ComponentType.CustomActions;
            
        public string ExportFolderName => "CustomActions";
        
        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.CustomActions);
            Provider.SaveAs(template, $"{ExportFolderName}/CustomActions.xml");
        }

    }
}
