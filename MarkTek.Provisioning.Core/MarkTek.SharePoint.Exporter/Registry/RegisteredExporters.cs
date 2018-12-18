using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using System.Collections.Generic;

namespace MarkTek.SharePoint.Exporter.Registry
{
    public class RegisteredExporters
    {
        public List<IExportableComponent> GetExporters(string url, string user, string password)
        {
            return new List<IExportableComponent>
            {
                new ComposedLook.ComposedLookExporter(url, user, password),
                new ContentTypes.ContentTypeExporter(url, user, password),
                new CustomActions.CustomActionsExporter(url, user, password),
                new Features.FeaturesExporter(url, user, password),
                new Files.FilesExporter(url, user, password),
                new Languages.LanguagesExporter(url, user, password),
                new Lists.ListExporter(url, user, password),
                new Navigation.NavigationExporter(url, user, password),
                new Pages.PagesExporter(url, user, password),
                new PropertyBag.PropertyBagExporter(url, user, password),
                new Region.RegionSettingsExporter(url, user, password),
                new SearchSettings.SearchSettingsExporter(url, user, password),
                new Security.SecurityExporter(url, user, password),
                new SiteFields.SiteFieldsExporter(url, user, password),
                new SitePolicy.SitePolicyExporter(url, user, password),
                new SiteProperties.SitePropertiesExporter(url, user, password),
                new TermGroup.ExportTermGroup(url, user, password)
            };
        }
    }
}
