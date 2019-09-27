using MarkTek.SharePoint.Provisioning.Core;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System;
using System.Threading;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export
{
    /// <summary>
    /// Base Class for All Export Components
    /// </summary>
    public abstract class BaseExporter
    {
        public string ExportPath { get; private set; }
        public XMLFileSystemTemplateProvider Provider { get; private set; }
        private ClientContext _context;

        public BaseExporter(ClientContext clientContext)
        {
            this._context = clientContext;
        }

        internal Site GetSite()
        {
            return AcquireContext().Site;
        }

        protected ClientContext AcquireContext()
        {      
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