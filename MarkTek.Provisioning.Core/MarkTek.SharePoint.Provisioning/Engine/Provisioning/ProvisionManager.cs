using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client.Search.Administration;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace MarkTek.SharePoint.Provisioning.Core
{
    public class ProvisionManager : IProvisionManager
    {
        private ISharePointContext context;

        public ProvisionManager(ISharePointContext context)
        {
            this.context = context;
        }

        public void Provision(string SPUrl, string tenantAdminUser, string tenantAdminPassword, ProvisioningTemplate template)
        {
            context.ApplyProvisioningTemplate(template, SPUrl, tenantAdminUser, tenantAdminPassword);
        }

        public void ProvisionSearchSchema(string SPUrl, string tenantAdminUser, string tenantAdminPassword, string templatePath, SearchObjectLevel level)
        {
            context.ApplySearchSchema(templatePath, SPUrl, tenantAdminUser, tenantAdminPassword, level);
        }
    }
}