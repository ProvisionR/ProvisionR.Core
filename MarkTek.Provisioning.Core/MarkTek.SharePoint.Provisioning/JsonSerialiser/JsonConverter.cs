using Newtonsoft.Json;
using MarkTek.SharePoint.Provisioning.Core.Configuration;
using System;
using System.IO;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;

namespace MarkTek.SharePoint.Provisioning.Core.JsonSerialiser
{
    public class JsonConverter : IJsonConverter
    {     

        public ProvisioningConfig GetConfiguration(string filePath)
        {
            return JsonConvert.DeserializeObject<ProvisioningConfig>(File.ReadAllText(filePath), new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
        }

        public string GetJsonFile(ProvisioningConfig configObject)
        {
            return JsonConvert.SerializeObject(configObject);
        }               

    }
}
