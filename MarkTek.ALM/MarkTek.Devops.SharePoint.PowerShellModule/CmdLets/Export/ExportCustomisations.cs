using System.Management.Automation;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter;

namespace MarkTek.Devops.SharePoint.PowerShellModule.CmdLets.Export
{

    [Cmdlet("Export", "Customisations")]
    public class ExportCustomisations : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "The SharePoint Site Url")]
        public string SharePointSiteUrl { get; set; }
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "The SharePoint User Account")]
        public string SharePointUserName { get; set; }
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "The SharePoint User Password")]
        public string SharePointPassword { get; set; }
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "The Folder to export to")]
        public string ExportPath { get; set; }

        protected override void ProcessRecord()
        {
            var export = new RegisteredExporters().GetExporters(SharePointSiteUrl, SharePointUserName, SharePointPassword);

            export.ForEach(e =>
            {
                e.SetExportPath(ExportPath);
                e.Export();
            });
        }
    }
}
