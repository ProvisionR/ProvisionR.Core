using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Core;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using System.Linq;

namespace MarkTek.SharePoint.Exporter.TermGroup
{
    public class WorkflowExporter : BaseExporter, IExportableComponent
    {


        public WorkflowExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
        {
        }

        public string ExportFolderName => "Workflows";

        public ComponentType ComponentType => ComponentType.Workflows;

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.Workflows);

            Provider.SaveAs(template, $"{ExportFolderName}/Workflows.xml");

        }

    }
}
