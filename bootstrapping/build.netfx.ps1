[CmdletBinding()]
Param(
    [switch]$Local,
    [Parameter(Position=0,Mandatory=$false,ValueFromRemainingArguments=$true)]
    [string[]]$BuildArguments
)

Set-StrictMode -Version 2.0; $ErrorActionPreference = "Stop"; $ConfirmPreference = "None"; trap { $host.SetShouldExit(1) }
$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

###########################################################################
# CONFIGURATION
###########################################################################

$SolutionDirectory = "$PSScriptRoot\_SOLUTION_DIRECTORY_"
$BuildProjectFile = "$PSScriptRoot\_BUILD_DIRECTORY_NAME_\_BUILD_PROJECT_NAME_.csproj"
$BuildExeFile = "$PSScriptRoot\_BUILD_DIRECTORY_NAME_\bin\debug\_BUILD_PROJECT_NAME_.exe"
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

if (-not ($Local) -and (Get-Command "nuget" -ErrorAction SilentlyContinue) -ne $null) {
    $env:NUGET_EXE = (Get-Command "nuget").Path
}
else {
    $env:NUGET_EXE = "$TempDirectory\nuget.exe"

    if (!(Test-Path $env:NUGET_EXE)) {
        md -force $TempDirectory > $null
        (New-Object System.Net.WebClient).DownloadFile($NuGetUrl, $env:NUGET_EXE)
    }
    elseif ($NuGetVersion -eq "latest") {
        ExecSafe { & $env:NUGET_EXE update -Self }
    }
}

ExecSafe { & $env:NUGET_EXE install Nuke.MSBuildLocator -ExcludeVersion -OutputDirectory $TempDirectory -SolutionDirectory $SolutionDirectory }
$MSBuildFile = & "$TempDirectory\Nuke.MSBuildLocator\tools\Nuke.MSBuildLocator.exe"

ExecSafe { & $env:NUGET_EXE restore $BuildProjectFile -SolutionDirectory $SolutionDirectory }
ExecSafe { & $MSBuildFile $BuildProjectFile }
ExecSafe { & $BuildExeFile $BuildArguments }
