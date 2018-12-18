
using Capgemini.SharePoint.Provisioning.Core;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System;
using System.Threading;

namespace Capgemini.SharePoint.Deployer
{
    /// <summary>
    /// Base Class for All Export Components
    /// </summary>
    public abstract class BaseDeployer
    {
        public string SiteUrl { get; }
        public string UserName { get; }
        public string Password { get; }
        public string ImportPath { get; private set; }
        public XMLFileSystemTemplateProvider Provider { get; private set; }

        public BaseDeployer(string siteUrl, string username, string password)
        {
            this.SiteUrl = siteUrl;
            this.UserName = username;
            this.Password = password;
        }

        protected ClientContext AcquireContext() => new ClientContext(SiteUrl)
        {
            Credentials = new SharePointOnlineCredentials(UserName, Password.GetSecureString()),
            RequestTimeout = Timeout.Infinite
        };

        public void SetImportPath(string path)
        {
            this.ImportPath = path;
            Provider = new XMLFileSystemTemplateProvider(path, String.Empty);
        }

        public virtual void Import()
        {
        }

    }
}