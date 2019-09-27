using MarkTek.SharePoint.Provisioning.Core.Configuration;
using MarkTek.SharePoint.Provisioning.Core.Engine.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace MarkTek.SharePoint.Provisioning.Core.Engine
{
    public class PowerShellHandler : IComponentHandler<PnPTemplateHandler>, IComponentImport
    {
        public bool CanHandle(ImportBaseElement x)
        {
            return x.IsCustomScript() && !x.IsSearchConfig;
        }

        public void Provision(ImportBaseElement x, string templateRootFolder, string sharePointSiteUrl, string sharePointUserName, string sharePointPassword)
        {
            try
            {
                RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
                Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration);
                runspace.Open();
                RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);

                Pipeline pipeline = runspace.CreatePipeline();

                var scriptPath = Path.Combine(templateRootFolder, x.SourceFolder, x.Handler.CustomCommand);

                Command myCommand = new Command(scriptPath, false);

                foreach (var p in x.Handler.CustomCommandArguments)
                {
                    myCommand.Parameters.Add(p.ParameterName, p.ParameterValue);
                }

                myCommand.Parameters.Add("SharePointSiteUrl", sharePointSiteUrl);
                myCommand.Parameters.Add("SharePointSiteUserName", sharePointUserName);
                myCommand.Parameters.Add("SharePointPassword", sharePointPassword);

                pipeline.Commands.Add(myCommand);
                Collection<PSObject> psObjects;
                psObjects = pipeline.Invoke();
                runspace.Close();
            }
            catch (Exception ex)
            {
                Console.Error.Write($"##vso[task.logissue type=error] Failed to Execute Powershell script with message {ex.Message}");
            }           

        }
    }
}
