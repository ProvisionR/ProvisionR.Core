using MarkTek.SharePoint.Deployer.ExtensibleHandlers;
using System;
using System.IO;
using System.Linq;

namespace MarkTek.SharePoint.Deployer
{
    public class  Importer 
    {
        public void ReadDirectory()
        {
            var files = Directory.GetFiles(@"C:\Export", "*.xml", SearchOption.AllDirectories);

            files.ToList().ForEach(x =>
            {
                string tenantAdminUser = "testciprocess@testciprocess.onmicrosoft.com";
                string tenantAdminPassword = "Goodearl123";
                string siteCollectionUrl = "https://testciprocess.sharepoint.com";

                XMLTemplateProvider provider = new XMLFileSystemTemplateProvider(Environment.CurrentDirectory, "");

                var template = provider.GetTemplate(@"C:\_SP\Extension.xml");

                template = new OfficeDevPnP.Core.Framework.Provisioning.Model.ProvisioningTemplate();
                template.Id = Guid.NewGuid().ToString();

                var c = new CustomExtender();
                c.Enabled = true;
                c.Assembly = "MarkTek.SharePoint.Deployer,Version=1.0.0.0,Culture=neutral,PublicKeyToken=null";
                c.Type = "MarkTek.SharePoint.Deployer.ExtensibleHandlers.CustomExtender";

                   //MarkTek.SharePoint.Deployer.ExtensibleHandlers.CustomHanderl, MarkTek.SharePoint.Deployer, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null

                template.ExtensibilityHandlers.Add(c);

                using (ClientContext context = new ClientContext(siteCollectionUrl))
                {
                    context.Credentials =
                        new SharePointOnlineCredentials(
                            tenantAdminUser,
                            tenantAdminPassword.GetSecureString());

                    context.Web.ApplyProvisioningTemplate(template);
                }

              
            });

        }
    }
}
