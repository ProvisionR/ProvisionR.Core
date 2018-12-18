using MarkTek.SharePoint.Provisioning.Core;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System;
using System.Threading;

namespace MarkTek.SharePoint.Exporter
{
    /// <summary>
    /// Base Class for All Export Components
    /// </summary>
    public abstract class BaseExporter
    {
        public string SiteUrl { get; }
        public string UserName { get; }
        public string Password { get; }
        public string ExportPath { get; private set; }
        public XMLFileSystemTemplateProvider Provider { get; private set; }
        private static ClientContext _context;

        public BaseExporter(string siteUrl, string username, string password)
        {
            this.SiteUrl = siteUrl;
            this.UserName = username;
            this.Password = password;
        }

        internal Site GetSite()
        {
            return AcquireContext().Site;
        }

        protected ClientContext AcquireContext()
        {
            if (_context ==null)
            {
                _context = new ClientContext(SiteUrl)
                {
                    Credentials = new SharePointOnlineCredentials(UserName, Password.GetSecureString()),
                    RequestTimeout = Timeout.Infinite
                };
            }
          
            return _context;
        }

        public void SetExportPath(string path)
        {
            this.ExportPath = path;
            Provider = new XMLFileSystemTemplateProvider(path, String.Empty);
        }

        public virtual void Export() { }

        internal ProvisioningTemplate GetProvisioningTemplate(Handlers handlers)
        {
            var ctx = AcquireContext();
            var templateCi = GetProvisionInformation(ctx.Web, handlers);
            var template = ctx.Web.GetProvisioningTemplate(templateCi);

            template.Id = "TEMPLATE-4F451C46F6C6439FB1D60636C9021578";
            return template;
        }

        public virtual ProvisioningTemplateCreationInformation GetProvisionInformation(Web web, Handlers handlers)
        {
            var createInfo = new ProvisioningTemplateCreationInformation(web);
            createInfo.HandlersToProcess = handlers;
            return createInfo;
        }


    }
}