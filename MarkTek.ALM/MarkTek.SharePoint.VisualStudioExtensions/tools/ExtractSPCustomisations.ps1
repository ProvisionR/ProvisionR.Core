
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

Import-Module $moduleName

# Method to intercept resolution of binaries
$onAssemblyResolveEventHandler = [System.ResolveEventHandler] {
    param($sender, $e)

    Write-Host "ResolveEventHandler: Attempting FullName resolution of $($e.Name)" 
    foreach($assembly in [System.AppDomain]::CurrentDomain.GetAssemblies()) {
        if ($assembly.FullName -eq $e.Name) {
            Write-Host "Successful FullName resolution of $($e.Name)" 
            return $assembly
        }
    }

    Write-Host "ResolveEventHandler: Attempting name-only resolution of $($e.Name)" 
    foreach($assembly in [System.AppDomain]::CurrentDomain.GetAssemblies()) {
        # Get just the name from the FullName (no version)
        $assemblyName = $assembly.FullName.Substring(0, $assembly.FullName.IndexOf(", "))

        if ($e.Name.StartsWith($($assemblyName + ","))) {

            Write-Host "Successful name-only (no version) resolution of $assemblyName" 
            return $assembly
        }
    }

    Write-Host "Unable to resolve $($e.Name)" 
    return $null
}

# Wire-up event handler
[System.AppDomain]::CurrentDomain.add_AssemblyResolve($onAssemblyResolveEventHandler)

# Load into app domain
$assembly = [System.Reflection.Assembly]::LoadFrom($moduleName) 

try
{
    # this ensures that all dependencies were loaded correctly
    $assembly.GetTypes() 
} 
catch [System.Reflection.ReflectionTypeLoadException] 
{ 
     Write-Host "Message: $($_.Exception.Message)" 
     Write-Host "StackTrace: $($_.Exception.StackTrace)"
     Write-Host "LoaderExceptions: $($_.Exception.LoaderExceptions)"
}






Import-Module $moduleName
$error[0].Exception.GetBaseException().LoaderExceptions

Export-Customisations -SharePointSiteUrl $connectionString -SharePointUserName $username -SharePointPassword $password -ExportPath $solutionFilesFolder



