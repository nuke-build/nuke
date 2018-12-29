[CmdletBinding()]
Param(
    [Parameter(Position=0,Mandatory=$false,ValueFromRemainingArguments=$true)]
    [string[]]$BuildArguments
)

Write-Output "Windows PowerShell $($Host.Version)"

Set-StrictMode -Version 2.0; $ErrorActionPreference = "Stop"; $ConfirmPreference = "None"; trap { exit 1 }
$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

###########################################################################
# CONFIGURATION
###########################################################################

$SolutionDirectory = "$PSScriptRoot\_SOLUTION_DIRECTORY_"
$BuildProjectFile = "$PSScriptRoot\_BUILD_DIRECTORY_\_BUILD_PROJECT_NAME_.csproj"
$BuildExeFile = "$PSScriptRoot\_BUILD_DIRECTORY_\bin\debug\_BUILD_PROJECT_NAME_.exe"
$TempDirectory = "$PSScriptRoot\_ROOT_DIRECTORY_\.tmp"

$NuGetVersion = "_NUGET_VERSION_"
$NuGetUrl = "https://dist.nuget.org/win-x86-commandline/$NuGetVersion/nuget.exe"

###########################################################################
# EXECUTION
###########################################################################

function ExecSafe([scriptblock] $cmd) {
    & $cmd
    if ($LASTEXITCODE) { exit $LASTEXITCODE }
}

$env:NUGET_EXE = "$TempDirectory\nuget.exe"
if (!(Test-Path $env:NUGET_EXE)) {
    md -force $TempDirectory > $null
    (New-Object System.Net.WebClient).DownloadFile($NuGetUrl, $env:NUGET_EXE)
}
elseif ($NuGetVersion -eq "latest") {
    ExecSafe { & $env:NUGET_EXE update -Self }
}
Write-Output $(& $env:NUGET_EXE help | select -First 1)

ExecSafe { & $env:NUGET_EXE install Nuke.MSBuildLocator -ExcludeVersion -OutputDirectory $TempDirectory -SolutionDirectory $SolutionDirectory }
$MSBuildFile = & "$TempDirectory\Nuke.MSBuildLocator\tools\Nuke.MSBuildLocator.exe" "$TempDirectory\vswhere\tools\vswhere.exe"

ExecSafe { & $env:NUGET_EXE restore $BuildProjectFile -SolutionDirectory $SolutionDirectory }
ExecSafe { & $MSBuildFile $BuildProjectFile /nodeReuse:false }
ExecSafe { & $BuildExeFile $BuildArguments }
