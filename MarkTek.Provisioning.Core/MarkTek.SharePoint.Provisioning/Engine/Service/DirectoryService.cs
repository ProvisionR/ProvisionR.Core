using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Service
{
    [ExcludeFromCodeCoverage]
    public class DirectoryService : IDirectoryService
    {
        public bool DirectoryExists(string path)
        {
            return System.IO.Directory.Exists(path);
        }

        public List<string> GetAllFiles(string rootDirectory, string wildCard)
        {
            return Directory.GetFiles(rootDirectory, wildCard, SearchOption.AllDirectories).ToList();
        }

        public string GetFileContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public void SaveFileContent(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }
}
