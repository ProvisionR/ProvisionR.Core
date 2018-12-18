using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTek.SharePoint.Exporter.Languages
{
    public class LanguagesExporter : BaseExporter, IExportableComponent
    {

        public LanguagesExporter(string sharePointUrl, string username, string password) : base(sharePointUrl, username, password)
        {
        }

        public ComponentType ComponentType=> ComponentType.SupportedUILanguages;
            
        public string ExportFolderName => "SupportedUILanguages";

        public override void Export()
        {
            var template = base.GetProvisioningTemplate(Handlers.SupportedUILanguages);
            Provider.SaveAs(template, $"{ExportFolderName}/SupportedUILanguages.xml");
        }

    }
}
