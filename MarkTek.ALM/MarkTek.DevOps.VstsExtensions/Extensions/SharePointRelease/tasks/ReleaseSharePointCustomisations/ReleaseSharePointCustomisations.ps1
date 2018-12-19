[CmdletBinding()] 
param
(
	[parameter(Mandatory=$true)]
	[string]$importConfigPath, #The folder to extract the SharePoint Customisations
	[parameter(Mandatory=$true)]
	[string]$importPath, #The folder to extract the SharePoint Customisations
	[parameter(Mandatory=$true)]
	[string]$sharePointSiteUrl, #The SharePoint site Url,
	[parameter(Mandatory=$true)]
	[string]$username,
	[parameter(Mandatory=$true)]
	[string]$password 
)


Import-Module $PSScriptRoot\Libs\MarkTek.Devops.SharePoint.PowerShellModule.dll -Force

Write-Host "MarkTek.Devops.SharePoint.PowerShellModule.dll modules imported successfully"

Import-Customisations -SharePointSiteUrl $sharePointSiteUrl -SharePointUserName $username -SharePointPassword $password -ImportPath $importPath -ImportConfig $importConfigPath
Write-Output "SharePoint Customisation import Task completed successfully"

# End of script

