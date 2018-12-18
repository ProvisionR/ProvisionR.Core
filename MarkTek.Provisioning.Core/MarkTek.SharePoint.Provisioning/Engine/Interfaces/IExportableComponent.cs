using System;


namespace MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces
{
    public interface IExportableComponent : IComponent
    {
        void Export();
                         
        String ExportFolderName { get; }

        void SetExportPath(string exportPath);
    }
}
