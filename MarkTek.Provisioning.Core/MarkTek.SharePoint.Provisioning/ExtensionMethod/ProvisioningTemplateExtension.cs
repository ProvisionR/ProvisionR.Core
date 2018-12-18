using OfficeDevPnP.Core.Framework.Provisioning.Model;


namespace MarkTek.SharePoint.Provisioning.Core
{
    public static class ProvisioningTemplateExtension
    {
        public static ProvisioningTemplate MapFieldsFromParent(this ProvisioningTemplate p, ProvisioningTemplate template)
        {
            p.Id = template.Id;
            p.BaseSiteTemplate = template.BaseSiteTemplate;
            p.Scope = template.Scope;
            p.Version = template.Version;
            return p;
        }
    }
}
