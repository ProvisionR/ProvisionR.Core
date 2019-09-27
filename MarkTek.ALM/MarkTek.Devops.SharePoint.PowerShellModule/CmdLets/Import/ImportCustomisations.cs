using MarkTek.SharePoint.Provisioning.Core.Engine.Importer;
using System.Management.Automation;

namespace MarkTek.Devops.SharePoint.PowerShellModule.CmdLets.Import
{
    [Cmdlet("Import", "Customisations")]
    public class ImportCustomisations : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 1, HelpMessage = "The SharePoint Site Url")]
        public string SharePointSiteUrl { get; set; }
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 2, HelpMessage = "The SharePoint User Account")]
        public string SharePointUserName { get; set; }
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 3, HelpMessage = "The SharePoint User Password")]
        public string SharePointPassword { get; set; }
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4, HelpMessage = "The Folder to Import from")]
        public string ImportPath { get; set; }
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 5, HelpMessage = "The JSON Import Config path")]
        public string ImportConfig { get; set; }

        protected override void ProcessRecord()
        {
            var importer = new ImportManager();
            importer.Import(SharePointSiteUrl, SharePointUserName, SharePointPassword, ImportConfig, ImportPath);

        }
    }
}
