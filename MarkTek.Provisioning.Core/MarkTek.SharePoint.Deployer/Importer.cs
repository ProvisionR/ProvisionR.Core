using Capgemini.SharePoint.Deployer.ExtensibleHandlers;
using Capgemini.SharePoint.Provisioning.Core;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.SharePoint.Deployer
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
                c.Assembly = "Capgemini.SharePoint.Deployer,Version=1.0.0.0,Culture=neutral,PublicKeyToken=null";
                c.Type = "Capgemini.SharePoint.Deployer.ExtensibleHandlers.CustomExtender";

                   //Capgemini.SharePoint.Deployer.ExtensibleHandlers.CustomHanderl, Capgemini.SharePoint.Deployer, Version = 1.0.0.0, Culture = neutral, PublicKeyToken = null

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
