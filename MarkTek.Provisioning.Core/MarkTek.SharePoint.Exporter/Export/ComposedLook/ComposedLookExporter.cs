using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTek.SharePoint.Exporter.ComposedLook
{
    public class ComposedLookExporter : BaseExporter, IExportableComponent
    {

        public ComposedLookExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
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
