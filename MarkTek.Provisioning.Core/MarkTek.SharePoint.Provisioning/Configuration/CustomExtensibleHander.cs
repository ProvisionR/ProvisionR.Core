using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using System.Collections.Generic;

namespace MarkTek.SharePoint.Provisioning.Core.Configuration
{
    public class CustomExtensibleHander
    {
        public ScriptType ScriptType { get; set; }
        public string CustomCommand { get; set; }
        public List<CommandParameter> CustomCommandArguments { get; set; }
    }
}