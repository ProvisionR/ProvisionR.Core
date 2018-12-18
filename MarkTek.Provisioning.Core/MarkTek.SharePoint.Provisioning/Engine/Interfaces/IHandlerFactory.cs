using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkTek.SharePoint.Provisioning.Core.Configuration;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces
{
    public interface IHandlerFactory
    {
        IComponentImport GetHandlerForElement(ImportBaseElement x);
    }
}
