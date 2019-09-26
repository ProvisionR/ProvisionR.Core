using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace MarkTek.SharePoint.Exporter.Region
{
    public class RegionSettingsExporter : BaseExporter, IExportableComponent
    {
        public RegionSettingsExporter(ClientContext clientContext) : base(clientContext)
        {
        }

        public ComponentType ComponentType => ComponentType.RegionalSettings;
         
        public string ExportFolderName => "RegionalSettings";
            
        public override  void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.RegionalSettings);

            Provider.SaveAs(template, $"{ExportFolderName}/RegionalSettings.xml");
        }
    }
}
