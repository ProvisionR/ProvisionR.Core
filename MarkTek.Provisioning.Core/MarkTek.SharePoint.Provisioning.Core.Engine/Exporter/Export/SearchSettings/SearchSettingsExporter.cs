using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Search.Administration;
using Microsoft.SharePoint.Client.Search.Portability;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System.IO;

namespace MarkTek.SharePoint.Exporter.SearchSettings
{
    public class SearchSettingsExporter : BaseExporter, IExportableComponent
    {
        public SearchSettingsExporter(ClientContext clientContext) : base(clientContext)
        {
        }

        public ComponentType ComponentType => ComponentType.SearchSettings;

        public string ExportFolderName => "SearchSettings";
        
        public override void Export()
        {
            var ctx = base.AcquireContext();
            //var site = base.GetSite();
            SearchConfigurationPortability conf = new SearchConfigurationPortability(ctx);
            SearchObjectOwner owner = new SearchObjectOwner(ctx, SearchObjectLevel.SPSiteSubscription);
            var buff = conf.ExportSearchConfiguration(owner);
            ctx.ExecuteQuery();
            var dir = Path.Combine(Provider.Connector.Parameters["ConnectionString"].ToString(), $"{ExportFolderName}");
            var path = Path.Combine($"{dir}\\SearchSettings.xml");

            System.IO.Directory.CreateDirectory(dir);

            System.IO.File.WriteAllText(path, buff.Value);

        }

    }
}
