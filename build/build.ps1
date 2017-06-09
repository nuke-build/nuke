[CmdletBinding()]
Param(
    [switch]$NoInit,
    [string]$Target,
    [ValidateSet("Release", "Debug")]
    [string]$Configuration,
    [ValidateSet("Quiet", "Minimal", "Normal", "Verbose")]
    [string]$Verbosity,
    [Parameter(Position=0,Mandatory=$false,ValueFromRemainingArguments=$true)]
    [string[]]$ScriptArgs
)

Set-StrictMode -Version 2.0; $ErrorActionPreference = "Stop"; $ConfirmPreference = "None"; trap { $host.SetShouldExit(1) }
$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

###########################################################################
# CONFIGURATION
###########################################################################

$NuGetUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
$SolutionDirectory = "$PSScriptRoot\..\source"
$BuildProjectFile = "$PSScriptRoot\.\.build.csproj"
$BuildExeFile = "$PSScriptRoot\.\bin\debug\.build.exe"
$TempDirectory = "$PSScriptRoot\..\.tmp"

###########################################################################
# PREPARE BUILD
###########################################################################

function ExecSafe([scriptblock] $cmd) {
    & $cmd
    if ($LastExitCode -ne 0) { throw "The following call failed with exit code $LastExitCode. '$cmd'" }
}

Write-Host "##teamcity[blockOpened name='Prepare']"

if (!$NoInit) {
    md -force $TempDirectory > $null

    $NuGetFile = "$TempDirectory\nuget.exe"
    $env:NUGET_EXE = $NuGetFile
    if (!(Test-Path $NuGetFile)) { (New-Object System.Net.WebClient).DownloadFile($NuGetUrl, $NuGetFile) }
    elseif ($NuGetUrl.Contains("latest")) { & $NuGetFile update -Self }

    ExecSafe { & $NuGetFile restore $BuildProjectFile -SolutionDirectory $SolutionDirectory -NoCache }
    ExecSafe { & $NuGetFile install Nuke.MSBuildLocator -ExcludeVersion -OutputDirectory $TempDirectory -SolutionDirectory $SolutionDirectory }
}

$MSBuildFile = & "$TempDirectory\Nuke.MSBuildLocator\tools\Nuke.MSBuildLocator.exe"
ExecSafe { & $MSBuildFile $BuildProjectFile }

Write-Host "##teamcity[blockClosed name='Prepare']"

###########################################################################
# EXECUTE BUILD
###########################################################################

ExecSafe { & $BuildExeFile "-Target=$Target" "-Configuration=$Configuration" "-Verbosity=$Verbosity" $ScriptArgs }
