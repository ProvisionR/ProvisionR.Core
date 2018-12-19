#
# VstsExtensionPackageGenerator.ps1
# 

param(
[string][Parameter(Mandatory=$true)] $ExtensionsPackagesDir,
[string][Parameter(Mandatory=$true)] $npmToolPath,
[string][Parameter(Mandatory=$true)] $VstsExtensionsRoot,
[string][Parameter(Mandatory=$true)] $BuildMode
)

$ErrorActionPreference = "Stop"

if(Test-Path $ExtensionsPackagesDir)
{
	Get-ChildItem -Path $ExtensionsPackagesDir -Include * | remove-Item -recurse 
}

$ExtensionsPackagesDir = $ExtensionsPackagesDir.substring(0,$ExtensionsPackagesDir.Length-1)
$VstsExtensionsRoot = $VstsExtensionsRoot.substring(0,$VstsExtensionsRoot.Length-1)

$extensionsFolders = Get-ChildItem -Path "$VstsExtensionsRoot\Extensions"

foreach($extensionFolder in $extensionsFolders)
{
    Write-Host "Extension folder name: $extensionFolder"
    
    $extensionsDestinationDir = "$ExtensionsPackagesDir\$extensionFolder"
    New-Item $extensionsDestinationDir -ItemType directory
    Write-Host "Directory $extensionsDestinationDir successfully created!"
    Copy-Item ("$VstsExtensionsRoot\Extensions\$extensionFolder\vss-extension.json") $extensionsDestinationDir -Force
    Copy-Item ("$VstsExtensionsRoot\Extensions\$extensionFolder\logo.png") "$extensionsDestinationDir" -Force
    Copy-Item ("$VstsExtensionsRoot\Extensions\$extensionFolder\overview.md") "$extensionsDestinationDir" -Force

    $tasksFoldername = "$VstsExtensionsRoot\Extensions\$extensionFolder\Tasks"
    $tasksFolders = Get-ChildItem -Path "$tasksFoldername"

    foreach($taskFolder in $tasksFolders)
    {
        Write-Host "Task folder name: $taskFolder"
        Copy-Item ("$tasksFoldername\$taskFolder") $extensionsDestinationDir -Force -Recurse

	
		#embeding required powershell scripts
		if($extensionFolder.Name -eq "SharePointBuild" )
		{
		    Write-Host "$taskFolder - copying powershell module"
		    New-Item "$extensionsDestinationDir\$taskFolder\ps-modules" -type directory
			Copy-Item ("$VstsExtensionsRoot\..\MarkTek.DevOps.PowerShell\PowerShellPNP\*") "$extensionsDestinationDir\$taskFolder\ps-modules" -Force
		
		}

		if($extensionFolder.Name -eq "SharePointRelease" )
		{
		 #   Write-Host "$taskFolder - copying powershell module"
		 #   New-Item "$extensionsDestinationDir\$taskFolder\ps-modules" -type directory
			#Copy-Item ("$VstsExtensionsRoot\..\MarkTek.DevOps.PowerShell\PowerShellPNP\*") "$extensionsDestinationDir\$taskFolder\ps-modules" -Force
		
			#Copy MarkTek SharePoint Framework
			Write-Host "$taskFolder - copying powershell module"
		    New-Item "$extensionsDestinationDir\$taskFolder\Libs" -type directory
		    Copy-Item ("$VstsExtensionsRoot/../MarkTek.SharePoint.VisualStudioExtensions/tools/*.dll") "$extensionsDestinationDir\$taskFolder\Libs" -Force
		}

     }

	 Write-Host "Packing $extensionFolder ...."
	 Write-Host $npmToolPath
	 Write-Host $extensionsDestinationDir
	 Write-Host $ExtensionsPackagesDir
	
	 Write-Host "Packing command line":
	 Write-Host "$npmToolPath\tfx extension create --manifest-globs $extensionsDestinationDir\vss-extension.json --output-path $ExtensionsPackagesDir --root $extensionsDestinationDir"
	
    & "$npmToolPath\tfx" extension create --manifest-globs "$extensionsDestinationDir\vss-extension.json" --output-path $ExtensionsPackagesDir --root $extensionsDestinationDir

 }


