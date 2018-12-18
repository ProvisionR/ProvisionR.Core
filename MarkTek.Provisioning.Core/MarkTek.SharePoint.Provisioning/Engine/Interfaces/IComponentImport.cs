using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkTek.SharePoint.Provisioning.Core.Configuration;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces
{
    public interface IComponentImport
    {
        void Provision(ImportBaseElement x, string templateRootFolder, string sharePointSiteUrl, string sharePointUserName, string sharePointPassword);

        bool CanHandle(ImportBaseElement x);

    }
}
