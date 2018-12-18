using MarkTek.SharePoint.Provisioning.Core.Configuration;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces
{
    public interface IJsonConverter
    {
        ProvisioningConfig GetConfiguration(string filePath);
        string GetJsonFile(ProvisioningConfig configObject);
    }
}