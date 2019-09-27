using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using System.Collections.Generic;
using System.Threading;
using MarkTek.SharePoint.Provisioning.Core;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Registry
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
                new ComposedLook.ComposedLookExporter(context),
                new ContentTypes.ContentTypeExporter(context),
                new CustomActions.CustomActionsExporter(context),
                new Features.FeaturesExporter(context),
                new Files.FilesExporter(context),
                new Languages.LanguagesExporter(context),
                new Lists.ListExporter(context),
                new Navigation.NavigationExporter(context),
                new Pages.PagesExporter(context),
                new PropertyBag.PropertyBagExporter(context),
                new Region.RegionSettingsExporter(context),
                new SearchSettings.SearchSettingsExporter(context),
                new Security.SecurityExporter(context),
                new SiteFields.SiteFieldsExporter(context),
                new SitePolicy.SitePolicyExporter(context),
                new SiteProperties.SitePropertiesExporter(context),
                new TermGroup.ExportTermGroup(context)
            };
        }
    }
}
