using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using Microsoft.SharePoint.Client;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.CustomActions
{
    public class CustomActionsExporter : BaseExporter, IExportableComponent
    {

        public CustomActionsExporter(ClientContext clientContext) : base(clientContext)
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
