using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using Microsoft.SharePoint.Client;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.ComposedLook
{
    public class ComposedLookExporter : BaseExporter, IExportableComponent
    {

        public ComposedLookExporter(ClientContext clientContext) : base(clientContext)
        {
        }

        public ComponentType ComponentType => ComponentType.ComposedLook;

        public string ExportFolderName => "ComposedLook";

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.ComposedLook);

            Provider.SaveAs(template, $"{ExportFolderName}/ComposedLook.xml");
        }

    }
}
