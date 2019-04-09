##Intro 
This document will cover the process to use the Capgemini SharePoint Provisioning engine. This guide assumes some knowledge of PowerShell and Visual Studio.

##Extracting the Customisations

You essentially have 2 options to extract your customisations from SharePoint.

####Option 1 - PowerShell
With this method, you import the Capgemini Provisioning Engine and use the cmdlets. If you use this method, source control management will be manual but **is still possible**
Download the dll's from : [Insert Link to Build OutPut]

1) Open PowerShell
2) Run the commands 

> Import-Module [Path to the physical dll file]\Capgemini.Devops.SharePoint.PowerShellModule.dll

>Get-Module

> Export-Customisations -SharePointSiteUrl "https://xxx.sharepoint.com" -SharePointUserName "myUser" -SharePointPassword "myPassword" -ExportPath "C:\OutPut\Admin"

There are 2 exposed CommandLets that you can use after importing the module

>Import-Customisations
>Export-Customisations

####Option 2 - Visual Studio

The Guide here explains the process in detail but essentially you create a new project in visual studio, point to sharepoint using a config file and then clean the solution. Once the clean is done you can check it in to source control.


##Importing the Customisations to another tenant

####The import Configuration
In the previous chapter we introduced you to the powershell cmdlets Import-Customisations and Export-Customisations. You will be configuring a JSON file that will support your deployment to SharePoint, we will cover this in the next section. Please visit [Import Configuration](/Capgemini-DevOps/Technical-Documentation/Capgemini.DevOps.VstsExtensions/Capgemini-SharePoint-Build-&-Release-tools/SharePoint-Provisioning-Engine-%2D-Usage-Examples/Import-Configuration-file) for more information.

You have 3 options to do this:

####Option 1 - PowerShell

1) Run the following command (Replacing the tokens with your values)

> Import-Customisations -SharePointSiteUrl "https://xxx.sharepoint.com" -SharePointUserName "myUser" -SharePointPassword "myPassword" -ImportPath "C:\OutPut\Admin" -ImportConfig "C:\ImportConfig.json"


####Option 2 - VSTS

There is a VSTS accelerator to help with the release, It is named 'Release SharePoint Customisations', MarketPlace Download is [Extension](https://marketplace.visualstudio.com/items?itemName=MarkCunninghamUK.MarkTeksharepoint-release-extension)


####Option 3 - C# Code
The engine is ultimately wrapped in a C# Nuget Package, you will at some point be able to get it via nuget, but for now it is privately hosted.

https://capgeminiuk.pkgs.visualstudio.com/_packaging/CapgeminiIp/nuget/v3/index.json

or using the command

> Install-Package Capgemini.SharePoint.Provisioning.Core.Engine -version 1.0.0.18

#####C# Example Usage
Below shows the 2 exposed examples of the engine.
#####Export Example

>var c = new ExportManager();
c.Export("https://xxxxx.sharepoint.com","xxx@xxxxx.onmicrosoft.com","xxxxxx",@"C:\_SP\Admin\xxxxx");

#####Import Example
>var import = new ImportManager();import.Import("https://xxxx.sharepoint.com","admin@xxxxx.onmicrosoft.com", "myPassword",@"C:\_ImportConfig\import.json",@"C:\_SP\Admin\xxx");




