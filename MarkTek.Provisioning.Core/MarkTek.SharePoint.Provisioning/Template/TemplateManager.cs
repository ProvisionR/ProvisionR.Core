using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using OfficeDevPnP.Core.Framework.Provisioning.Model;
using OfficeDevPnP.Core.Framework.Provisioning.Providers.Xml;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace MarkTek.SharePoint.Provisioning.Core.Template
{
    public class TemplateManager : ITemplateManager
    {
        private IDirectoryService directoryService;

        public TemplateManager(IDirectoryService service)
        {
            this.directoryService = service;
        }

        public bool DirectoryExists(string path)
        {
            return directoryService.DirectoryExists(path);
        }

        [ExcludeFromCodeCoverage]
        public List<ProvisioningTemplate> GetTemplates(string Directory)
        {
            var provider = new XMLFileSystemTemplateProvider(Directory, string.Empty);

            try
            {           
                return provider.GetTemplates();
            }
            catch (ReflectionTypeLoadException e)
            {
                foreach (var item in e.LoaderExceptions)
                {
                    Console.WriteLine(item.Message);
                }
                return new List<ProvisioningTemplate>();
            }          
        }

        public string[] GetTemplates(string fullPath, string extensionWildcard)
        {
            return System.IO.Directory.GetFiles(fullPath, extensionWildcard);
        }
    }
}
