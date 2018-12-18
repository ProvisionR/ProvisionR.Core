using OfficeDevPnP.Core.Framework.Provisioning.Model;
using System.Collections.Generic;

namespace MarkTek.SharePoint.Provisioning.Core.Template
{
    public interface ITemplateManager
    {
        List<ProvisioningTemplate> GetTemplates(string Directory);

        bool DirectoryExists(string path);
        string[] GetTemplates(string fullPath, string extensionWildcard);
    }
}