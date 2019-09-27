using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using Microsoft.SharePoint.Client;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.ObjectHandlers;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Exporter.Export.Features
{
    public class FeaturesExporter : BaseExporter, IExportableComponent
    {

        public FeaturesExporter(ClientContext clientContext) : base(clientContext)
        {
        }

        public ComponentType ComponentType
        {
            get
            {
                return ComponentType.Features;
            }
        }

        public string ExportFolderName
        {
            get
            {
                return "SiteFeatures";
            }
        }

        public override  void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.Features);

            template.Features.SiteFeatures.ToList().ForEach(x =>
             {
                 var p = new ProvisioningTemplate();
                 p.Features.SiteFeatures.Add(x);
                 
                 Provider.SaveAs(p, $"{ExportFolderName}/SiteFeatures/{x.Id}.xml");
             });

            template.Features.WebFeatures.ToList().ForEach(x =>
            {
                var p = new ProvisioningTemplate();
                p.Features.SiteFeatures.Add(x);
                Provider.SaveAs(p, $"{ExportFolderName}/WebFeatures/{x.Id}.xml");
            });

        }
    }
}
