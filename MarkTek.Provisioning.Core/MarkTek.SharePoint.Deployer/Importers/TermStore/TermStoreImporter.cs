using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using MarkTek.SharePoint.Provisioning.Engine.Interfaces;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace MarkTek.SharePoint.Deployer.Search
{
    public class TermStoreImporter : BaseDeployer, IDeployableComponent
    {
        private string searchConfigPath;

        public TermStoreImporter(string sharePointUrl, string username, string password, string searchConfigPath) : base(sharePointUrl, username, password)
        {
            this.searchConfigPath = searchConfigPath;
        }

        public ComponentType ComponentType => ComponentType.TermGroups;

        public string ImportFolderName => "TermGroups";

        public override void Import()
        {
            var template = new ProvisioningTemplate();
           template.Id = "TAXONOMYPROVISIONING";

            var outputStream = XMLPnPSchemaFormatter.LatestFormatter.ToFormattedTemplate(template);

            var reader = new StreamReader(outputStream);

            var fullXml = reader.ReadToEnd();

            var document = XDocument.Parse(fullXml);

            XElement termGroupsElement;
           
              termGroupsElement = XElement.Parse(System.IO.File.ReadAllText(searchConfigPath));
            
            //XNamespace pnp = XMLConstants.PROVISIONING_SCHEMA_NAMESPACE_25_12;
            var templateElement = document.Root.Descendants(document.Root.GetNamespaceOfPrefix("pnp") + "ProvisioningTemplate").FirstOrDefault();

            templateElement?.Add(termGroupsElement);

            var stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;

            var completeTemplate = XMLPnPSchemaFormatter.LatestFormatter.ToProvisioningTemplate(stream);

            ProvisioningTemplateApplyingInformation templateAI = new ProvisioningTemplateApplyingInformation();
            templateAI.HandlersToProcess = Handlers.TermGroups;

            var ctx = base.AcquireContext();
            ctx.Web.ApplyProvisioningTemplate(completeTemplate, templateAI);
        }

    }
}
