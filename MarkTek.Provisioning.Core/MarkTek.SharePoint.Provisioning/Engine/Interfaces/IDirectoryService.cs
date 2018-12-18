using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces
{
    public interface IDirectoryService
    {
        List<string> GetAllFiles(string rootDirectory,string wildCard);

        bool DirectoryExists(string path);

        string GetFileContent(string filePath);

        void SaveFileContent(string path, string contents);

    }
}
