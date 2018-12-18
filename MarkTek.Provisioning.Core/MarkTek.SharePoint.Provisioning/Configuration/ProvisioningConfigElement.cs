using System.Collections.Generic;

namespace MarkTek.SharePoint.Provisioning.Core.Configuration
{
    public class ProvisioningConfig
    {
        public List<Token> Tokens { get; set; }
        public List<ImportBaseElement> ImportableElements { get; set; }
    }
}