using Microsoft.SharePoint.Client.Search.Administration;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces
{
    public interface IProvisionManager
    {
        void Provision(string SPUrl, string tenantAdminUser, string tenantAdminPassword, ProvisioningTemplate template);

        void ProvisionSearchSchema(string SPUrl, string tenantAdminUser, string tenantAdminPassword, string templatePath, SearchObjectLevel level);
    }
}