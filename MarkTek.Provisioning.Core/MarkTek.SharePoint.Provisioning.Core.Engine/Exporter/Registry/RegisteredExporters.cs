using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using System.Collections.Generic;
using System.Threading;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.ComposedLook;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.ContentTypes;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.CustomActions;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Features;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Files;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Lists;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Languages;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Navigation;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Pages;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.PropertyBag;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Region;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.SearchSettings;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Security;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.SiteFields;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.SitePolicy;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.SiteProperties;
using MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.TermGroup;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter
{
    public class RegisteredExporters
    {
        public List<IExportableComponent> GetExporters(string url, string user, string password)
        {
            var context = new Microsoft.SharePoint.Client.ClientContext(url)
            {
                Credentials = new SharePointOnlineCredentials(user, password.GetSecureString()),
                RequestTimeout = Timeout.Infinite
            };

            return new List<IExportableComponent>
            {
                new ComposedLookExporter(context),
                new ContentTypeExporter(context),
                new CustomActionsExporter(context),
                new FeaturesExporter(context),
                new FilesExporter(context),
                new LanguagesExporter(context),
                new ListExporter(context),
                new NavigationExporter(context),
                new PagesExporter(context),
                new PropertyBagExporter(context),
                new RegionSettingsExporter(context),
                new SearchSettingsExporter(context),
                new SecurityExporter(context),
                new SiteFieldsExporter(context),
                new SitePolicyExporter(context),
                new SitePropertiesExporter(context),
                new ExportTermGroup(context)
            };
        }
    }
}
