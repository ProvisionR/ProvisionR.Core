[CmdletBinding()] 
param
(
	[parameter(Mandatory=$true)]
	[string]$solutionFilesFolder, #The folder to extract the SharePoint Customisations
	[parameter(Mandatory=$true)]
	[string]$connectionString, #The SharePoint site Url,
	[parameter(Mandatory=$true)]
	[string]$username,
	[parameter(Mandatory=$true)]
	[string]$password
)

Set-ExecutionPolicy –ExecutionPolicy RemoteSigned –Scope CurrentUser

$scriptPath = split-path -parent $MyInvocation.MyCommand.Definition

$moduleName = $scriptPath + "\MarkTek.Devops.SharePoint.PowerShellModule.dll"        

Write-Output "Importing: $moduleName" 

Import-Module -Name $moduleName   

Export-Customisations -SharePointSiteUrl $connectionString -SharePointUserName $username -SharePointPassword $password -ExportPath $solutionFilesFolder
