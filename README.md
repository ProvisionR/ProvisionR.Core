## Intro 
This document will cover the process to use the SharePoint Provisioning engine. This guide assumes some knowledge of PowerShell and Visual Studio.

## Extracting the Customisations

You essentially have 2 options to extract your customisations from SharePoint.

#### Option 1 - PowerShell
With this method, you import the Provisioning Engine and use the cmdlets. If you use this method, source control management will be manual but **is still possible**
Download the dll's from : [Insert Link to Build OutPut]

1) Open PowerShell
2) Run the commands 

> Import-Module [Path to the physical dll file]\MarkTek.Devops.SharePoint.PowerShellModule.dll

>Get-Module

> Export-Customisations -SharePointSiteUrl "https://xxx.sharepoint.com" -SharePointUserName "myUser" -SharePointPassword "myPassword" -ExportPath "C:\OutPut\Admin"

There are 2 exposed CommandLets that you can use after importing the module

>Import-Customisations

>Export-Customisations

#### Option 2 - Visual Studio

The Guide here explains the process in detail but essentially you create a new project in visual studio, point to sharepoint using a config file and then clean the solution. Once the clean is done you can check it in to source control.

## Importing the Customisations to another tenant

#### The import Configuration
In the previous chapter we introduced you to the powershell cmdlets Import-Customisations and Export-Customisations. You will be configuring a JSON file that will support your deployment to SharePoint, we will cover this in the next section. 

You have 3 options to do this:

#### Option 1 - PowerShell

1) Run the following command (Replacing the tokens with your values)

> Import-Customisations -SharePointSiteUrl "https://xxx.sharepoint.com" -SharePointUserName "myUser" -SharePointPassword "myPassword" -ImportPath "C:\OutPut\Admin" -ImportConfig "C:\ImportConfig.json"


#### Option 2 - Azure DevOps

There is an Azure DevOps accelerator to help with the release, It is named 'Release SharePoint Customisations', MarketPlace Download is [Extension](https://marketplace.visualstudio.com/items?itemName=MarkCunninghamUK.MarkTeksharepoint-release-extension)

#### Option 3 - C# Code
The engine is ultimately wrapped in a C# Nuget Package https://www.nuget.org/packages/MarkTek.SharePoint.VisualStudioExtensions/

or using the command

> Install-Package MarkTek.SharePoint.Provisioning.Core.Engine

##### C# Example Usage
Below shows the 2 exposed examples of the engine.
##### Export Example

>var c = new ExportManager();
c.Export("https://xxxxx.sharepoint.com","xxx@xxxxx.onmicrosoft.com","xxxxxx",@"C:\_SP\Admin\xxxxx");

##### Import Example
>var import = new ImportManager();import.Import("https://xxxx.sharepoint.com","admin@xxxxx.onmicrosoft.com", "myPassword",@"C:\_ImportConfig\import.json",@"C:\_SP\Admin\xxx");



## Import Config File for C# , Azure DevOps
The Import Config file is used to control the following things when deploying to SharePoint

>The Sequence of Events (It executes in the order the file so it reads top down)
>The choice of Handler (PnP, PowerShell, Search)
> The search configuration
> Replaceable tokens

For each extracted folder you will need to create an element pointing to the source folder (Relative to the path)

The hierarchy Structure is as follows

```json
{
  "Tokens": [],
  "ImportableElements": []
}
```

A real world example below.

```json
{
  "Tokens": [
    {
      "TokenName": "{{siteName}}",
      "TokenValue": "nhsidev"
    }
  ],
  "ImportableElements": [
    {
      "SourceFolder": "PSScripts",
      "Enabled": true,
      "Handler": {
        "CustomCommand": "ExamplePowerShell.ps1",
        "CustomCommandArguments": [
          {
            "ParameterName": "Param1",
            "ParameterValue": "HelloWorld"
          }
        ]
      }
    },
    {
      "SourceFolder": "SearchSettings",
      "Enabled": true,
      "IsSearchConfig": true,
      "SearchConfiguration": {
        "SearchObjectLevel": 2
      }
    },
    {
      "SourceFolder": "PropertyBag",
      "Enabled": false
    },
  ]
}
```

Most of the time you will want to use normal PnP handler. To do this all you need is the following example.
```json  
    { 
      "SourceFolder": "PropertyBag",
      "Enabled": false
    }
```

However if you decide you dont like PnP, you can replace it with a powershell script, so you would replace
 
```json  
    { 
      "SourceFolder": "PropertyBag",
      "Enabled": false
    }
```
with a custom powershell command to handle property bag (You must of course write this script)

```json  {
      "SourceFolder": "PSScripts",
      "Enabled": true,
      "Handler": {
        "CustomCommand": "ExamplePowerShell.ps1",
        "CustomCommandArguments": [
          {
            "ParameterName": "Param1",
            "ParameterValue": "HelloWorld"
          }
        ]
       }
    }
```

#### Search Handler
Search is specialised in SharePoint in the sense that it is different to the others.
The search config can be seen below

```json  {
      "SourceFolder": "SearchSettings",
      "Enabled": true,
      "IsSearchConfig": true,
      "SearchConfiguration": {
        "SearchObjectLevel": 2
      }
    }
```
Please note: Search Object level takes 3 settings:

```csharp 
    public enum SearchObjectLevel
    {
        SPWeb = 0,
        SPSite = 1,
        SPSiteSubscription = 2,
        Ssa = 3
    }
```
