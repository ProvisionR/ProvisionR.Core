using MarkTek.SharePoint.Provisioning.Core.Configuration;

namespace MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces
{
    public interface IDeployer
    {
        /// <summary>
        /// Refactor when working and 
        /// </summary>
        /// <param name="res"></param>
        /// <param name="templateRootFolder"></param>
        /// <param name="SharePointSiteUrl"></param>
        /// <param name="SharePointUserName"></param>
        /// <param name="SharePointPassword"></param>

        void Deploy(ProvisioningConfig res, string templateRootFolder, string SharePointSiteUrl, string SharePointUserName, string SharePointPassword);

    }
}
