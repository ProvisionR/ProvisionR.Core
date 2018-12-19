[CmdletBinding()] 
param
(
	[parameter(Mandatory=$true)]
	[string]$templateFile, #The folder to extract the SharePoint Customisations
	[parameter(Mandatory=$true)]
	[string]$connectionString, #The SharePoint site Url,
	[parameter(Mandatory=$true)]
	[string]$username,
	[parameter(Mandatory=$true)]
	[string]$password 
)

$xrmPsModuleDir = "$PSScriptRoot\ps-modules"
Write-Verbose "Importing: SharePointPnPPowerShellOnline" 
Import-Module "$xrmPsModuleDir\SharePointPnPPowerShellOnline" -Force

$SecurePassword=Convertto-SecureString –String $password –AsPlainText –force
$cred = New-Object System.Management.Automation.PSCredential ($username, $SecurePassword)

Connect-PnPOnline –Url $connectionString –Credentials $cred

Set-PnPSearchConfiguration -Path "$templateFile" -Scope Subscription