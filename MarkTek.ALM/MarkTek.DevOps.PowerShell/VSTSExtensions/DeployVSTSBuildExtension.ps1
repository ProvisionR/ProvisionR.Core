#
# DeployVSTSBuildExtension.ps1
#

$tokenVSTS = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
$tfxPAth = "%AppData%\npm\tfx"

Set-Location "C:\GitRepos\Capgemini.DevOps\Capgemini.DevOps\Capgemini.DevOps.VstsBuildTasks"
$result = & "$tfxPAth" extension create --manifest-globs vss-extension.json

 #& "$tfxPAth" build tasks upload --token $tokenVSTS --auth-type pat --task-path ./UpdateCrmSolutionVersionTask --service-url "https://marketplace.visualstudio.com"
