using System.Collections.Generic;

namespace MarkTek.SharePoint.Provisioning.Core.Configuration
{
    public class ImportBaseElement
    {
        public string SourceFolder { get; set; }
        public bool Enabled { get; set; }
        public CustomExtensibleHander Handler { get; set; }
        public string Key { get; internal set; }
        public bool IsSearchConfig { get; set; }

        public SearchConfiguration SearchConfiguration { get; set; }
      
        public bool IsCustomScript()
        {
            return Handler != null;
        }
    }
}