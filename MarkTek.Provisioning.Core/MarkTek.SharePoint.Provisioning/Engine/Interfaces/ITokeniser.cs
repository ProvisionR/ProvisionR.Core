using MarkTek.SharePoint.Provisioning.Core.Configuration;
using System.Collections.Generic;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces
{
    public interface ITokeniser
    {    
        void TokeniseDirectory(string directoryPath, List<Token> Tokens, bool recursive = true);
    }

}