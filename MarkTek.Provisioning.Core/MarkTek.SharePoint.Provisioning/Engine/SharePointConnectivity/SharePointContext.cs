using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Search.Administration;
using Microsoft.SharePoint.Client.Search.Portability;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System;
using System.Diagnostics.CodeAnalysis;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.SharePointConnectivity
{
    [ExcludeFromCodeCoverage]
    public class SharePointContext : ISharePointContext
    {
        public void ApplyProvisioningTemplate(ProvisioningTemplate template, string SPUrl, string deploymentUser, string deploymentPassword)
        {
            try
            {
                using (ClientContext context = new ClientContext(SPUrl))
                {
                    context.Credentials =
                        new SharePointOnlineCredentials(
                            deploymentUser,
                            deploymentPassword.GetSecureString());

                    context.Web.ApplyProvisioningTemplate(template);

                }
            }
            catch (System.Exception e)
            {
                Console.Error.WriteLine($"##vso[task.logissue type=error] Failed to apply template with error {e.Message}");
            }
           
        }

        public void ApplySearchSchema(string templatePath, string SPUrl, string tenantAdminUser, string tenantAdminPassword, SearchObjectLevel level)
        {
            try
            {
                using (ClientContext ctx = new ClientContext(SPUrl))
                {
                    ctx.Credentials =
                        new SharePointOnlineCredentials(
                            tenantAdminUser,
                            tenantAdminPassword.GetSecureString());

                    SearchConfigurationPortability conf = new SearchConfigurationPortability(ctx);
                    SearchObjectOwner owner = new SearchObjectOwner(ctx, level);
                    conf.ImportSearchConfiguration(owner, System.IO.File.ReadAllText(templatePath));
                    ctx.ExecuteQuery();
                }
            }
            catch (System.Exception e)
            {
                Console.Error.WriteLine($"##vso[task.logissue type=error] Failed to apply search settings with error {e.Message}");
            }
         
        }
    }
}
