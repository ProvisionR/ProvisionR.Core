#
# CrmBuildPackageTest.ps1
#


$scriptPath = "$PSScriptRoot\..\..\Capgemini.DevOps.VstsExtensions\Extensions\CrmBuild\Tasks\CrmBuildPackageTask\CrmBuildPackageTask.ps1"
[string][Parameter(Mandatory=$true)] $targetFolder = "C:\!temp\TestPackage"
[string][Parameter(Mandatory=$true)] $solutionsFolder = "C:\GitRepos\CRM\CrmSolutions"
[string][Parameter(Mandatory=$true)] $packageBuildOutput = "C:\GitRepos\CRM\xxxxxx.xxxx.Deployment\xxxx.xxxx.PackageDeployer\bin\Debug\**"
[string][Parameter(Mandatory=$false)] $packageTemplateZip = "$PSScriptRoot\..\..\Capgemini.DevOps.VstsExtensions\Extensions\CrmBuild\Libs\PackageDeployer.zip"


& "$scriptPath" $targetFolder  $solutionsFolder $packageBuildOutput $packageTemplateZip