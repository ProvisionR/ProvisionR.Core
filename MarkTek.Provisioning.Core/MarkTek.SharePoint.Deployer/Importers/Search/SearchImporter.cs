using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Engine.Interfaces;
using Microsoft.SharePoint.Client.Search.Administration;
using Microsoft.SharePoint.Client.Search.Portability;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTek.SharePoint.Deployer.Search
{
    public class SearchImporter : BaseDeployer, IDeployableComponent //, ISearchImporter
    {
        private string searchConfigPath;

        public SearchImporter(string sharePointUrl, string username, string password, string searchConfigPath) : base(sharePointUrl, username, password)
        {
            this.searchConfigPath = searchConfigPath;
        }

        public ComponentType ComponentType => ComponentType.SearchSettings;

        public string ImportFolderName => "SearchSettings";

        public override void Import()
        {
            var ctx = base.AcquireContext();
            SearchConfigurationPortability conf = new SearchConfigurationPortability(ctx);
            SearchObjectOwner owner = new SearchObjectOwner(ctx,SearchObjectLevel.SPSiteSubscription);
            conf.ImportSearchConfiguration(owner, File.ReadAllText(searchConfigPath));
            ctx.ExecuteQuery();
        }

    }
}
