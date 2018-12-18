namespace MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces
{
    /// <summary>
    /// Taken from The PNP Schema, Defines the Component being release or Deployed
    /// https://github.com/SharePoint/PnP-Provisioning-Schema/blob/master/ProvisioningSchema-2018-01.md
    /// </summary>
    public enum ScriptType
    {
       PowerShell,
       CSOM,
       PnP
    }
}