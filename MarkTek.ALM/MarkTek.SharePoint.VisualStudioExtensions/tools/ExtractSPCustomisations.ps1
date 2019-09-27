[CmdletBinding()] 
param
(
	[parameter(Mandatory=$true)]
	[string]$solutionFilesFolder ="C:\Users\macunnin\Desktop\Extract",
	[parameter(Mandatory=$true)]
	[string]$connectionString = "https://scottishwaterdev.sharepoint.com/sites/DevelopmentServices-Demo",
	[parameter(Mandatory=$true)]
	[string]$username = "sharepointadmin@scottishwaterdev.onmicrosoft.com",
	[parameter(Mandatory=$true)]
	[string]$password = "U2NvdHRpc2hXYXRlckFzdHJvU1A="
)

Set-ExecutionPolicy –ExecutionPolicy RemoteSigned –Scope CurrentUser

$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition

$moduleName = $scriptPath + "\MarkTek.Devops.SharePoint.PowerShellModule.dll"        

Write-Output "Importing: $moduleName" 

Import-Module -Name $moduleName   

Export-Customisations -SharePointSiteUrl $connectionString -SharePointUserName $username -SharePointPassword $password -ExportPath $solutionFilesFolder
