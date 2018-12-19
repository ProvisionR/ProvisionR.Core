#
# CrmUpdateTask.ps1
#



[string]$configKey = "abc"
[string]$configValue = "test 2 2"
[PSObject]$isEncrypted = "true"
[string]$connectionString = "Url=https://xxxxxx.crm4.dynamics.com; Username=ciauth@xxxxxx.onmicrosoft.com; Password=xxxxxxx; AuthType=Office365; Timeout=00:30:00;"
[string]$configDescription = "test descr"

$ErrorActionPreference = "Stop"

$xrmPsModuleDir = "$PSScriptRoot\..\Microsoft.Xrm.Data.PowerShell"

Write-Host "Updating CRM config $configKey with value $configValue"
Write-Verbose "Importing: Microsoft.Xrm.Data.PowerShell"
Import-Module "$xrmPsModuleDir\Microsoft.Xrm.Data.PowerShell.psm1" -Force
Write-Verbose "Importing: Microsoft.Xrm.Tooling.Connector.dll" 
Import-Module "$xrmPsModuleDir\Microsoft.Xrm.Tooling.Connector.dll" -Force

$configItems = (Get-CrmRecords -conn $connectionString -EntityLogicalName cap_configurationparameter -FilterAttribute cap_key -FilterOperator "like" -FilterValue $configKey -Fields cap_key,cap_value,cap_isencrypted,cap_description )
$updated = $false

[bool]$isEncryptedTyped = $true
if ($isEncrypted -eq "false")
{
	$isEncryptedTyped = $false
}
Write-Host "Is Encrypted set to $isEncryptedTyped"

# Operate each record
foreach($config in $configItems.CrmRecords)
{
  if ($config.cap_key -eq $configKey)
  {
  	$updated = $true
	Write-Verbose ("Found value " + $config.cap_value)

	if ($config.cap_value -ne $configValue)
	{
	   [hashtable]$Fields =  @{}
	   $Fields.Add("cap_value", $configValue)
	   $Fields.Add("cap_isencrypted", $isEncryptedTyped)
	   
	   if ($configDescription -ne $null -and $configDescription -ne "")
	   {
	      $Fields.Add("cap_description", $configDescription)
	   }

	   Set-CrmRecord -conn $connectionString -EntityLogicalName cap_configurationparameter -Id $config.cap_configurationparameterid  -Fields $Fields
	   Write-Verbose ("Value has been updated")
	}
	else
	{
	  Write-Verbose ("Value has not ben changed")
	}

    break

  }
}

if ($updated -ne $true)
{
   New-CrmRecord -conn $connectionString -EntityLogicalName cap_configurationparameter -Fields @{"cap_key"=$configKey;"cap_value"=$configValue;"cap_isencrypted"=$isEncryptedTyped;"cap_description"=$configDescription;}
   Write-Host "Configuration record has been created with key:$configKey"
}



