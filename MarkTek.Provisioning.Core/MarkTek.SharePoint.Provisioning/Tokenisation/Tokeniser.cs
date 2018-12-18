using MarkTek.SharePoint.Provisioning.Core.Configuration;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace MarkTek.SharePoint.Provisioning.Core.Tokenisation
{
    public class Tokeniser : ITokeniser
    {
        private IDirectoryService service;

        public Tokeniser(IDirectoryService directoryInfo)
        {
            this.service = directoryInfo;
        }

        public void TokeniseDirectory(string rootDirectoryPath, List<Token> Tokens, bool recursive = true)
        {
            var allFiles = service.GetAllFiles(rootDirectoryPath, "*.xml");

         //   Regex r = new Regex("{{[A-Z0-9]}}");

            foreach (var item in allFiles)
            {
                string fileContent = service.GetFileContent(item);
                bool fileModified = false;

                foreach (Token token in Tokens)
                {
                    if (fileContent.Contains(token.TokenName))
                    {
                        fileContent = fileContent.Replace(token.TokenName, token.TokenValue);
                        fileModified = true;
                    }
                }
                if (fileModified) 
                    service.SaveFileContent(item, fileContent);
            }
            
        }
    }
}