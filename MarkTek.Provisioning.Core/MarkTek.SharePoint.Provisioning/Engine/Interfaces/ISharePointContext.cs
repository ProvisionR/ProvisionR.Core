
using Microsoft.SharePoint.Client.Search.Administration;
using OfficeDevPnP.Core.Framework.Provisioning.Model;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces
{
    public interface ISharePointContext
    {
        void ApplyProvisioningTemplate(ProvisioningTemplate template, string SPUrl, string deploymentUser, string deploymentPassword);
        void ApplySearchSchema(string templatePath, string sPUrl, string tenantAdminUser, string tenantAdminPassword, SearchObjectLevel level);
    }
}
