namespace MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces
{
    /// <summary>
    /// Taken from The PNP Schema, Defines the Component being release or Deployed
    /// https://github.com/SharePoint/PnP-Provisioning-Schema/blob/master/ProvisioningSchema-2018-01.md
    /// </summary>
    public enum ComponentType
    {
        Properties,
        SitePolicy,
        WebSettings,
        RegionalSettings,
        SupportedUILanguages,
        AuditSettings,
        PropertyBagEntries,
        Security,
        Navigation,
        SiteFields,
        ContentTypes,
        Lists,
        Features,
        CustomActions,
        Files,
        Pages,
        TermGroups,
        ComposedLook,
        Workflows,
        SearchSettings,
        Publishing,
        ApplicationLifecycleManagement,
        Providers,
        SiteWebhooks,
        ClientSidePages,
        Everything,
        Other
    }
}