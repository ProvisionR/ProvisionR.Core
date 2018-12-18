using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkTek.SharePoint.Provisioning.Engine.Interfaces
{
    /// <summary>
    /// A Component that is designed to be deployable.
    /// Summary Here..
    /// </summary>
    public interface IDeployableComponent : IComponent
    {
        void Import();

        String ImportFolderName { get; }

        void SetImportPath(string importPath);

    }
}