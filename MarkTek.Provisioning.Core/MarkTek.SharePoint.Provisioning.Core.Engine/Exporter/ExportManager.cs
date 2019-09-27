using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Registry;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter
{
    /// <summary>
    /// A Facade Class to help you to export SharePoint Customisations from PowerShell
    /// </summary>
    public class ExportManager
    {
        public void Export(string SharePointSiteUrl, string SharePointUserName, string SharePointPassword, string ExportPath)
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
