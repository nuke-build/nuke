[CmdletBinding()]
Param(
    [switch]$NoInit,
    [switch]$RefExt,
    [Parameter(Position=0,Mandatory=$false,ValueFromRemainingArguments=$true)]
    [string[]]$BuildArguments
)

Set-StrictMode -Version 2.0; $ErrorActionPreference = "Stop"; $ConfirmPreference = "None"; trap { $host.SetShouldExit(1) }
$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

###########################################################################
# CONFIGURATION
###########################################################################

$DotNetChannel = "2.0"
$BuildProjectFile = "$PSScriptRoot\build\.build.csproj"

$TempDirectory = "$PSScriptRoot\.tmp"

$DotNetScriptUrl = "https://raw.githubusercontent.com/dotnet/cli/master/scripts/obtain/dotnet-install.ps1"
$DotNetDirectory = "$TempDirectory\dotnet-win"
$DotNetFile = "$DotNetDirectory\dotnet.exe"
$env:DOTNET_EXE = $DotNetFile

$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = 1
$env:DOTNET_CLI_TELEMETRY_OPTOUT = 1
$env:NUGET_XMLDOC_MODE = "skip"

###########################################################################
# PREPARE BUILD
###########################################################################

function ExecSafe([scriptblock] $cmd) {
    & $cmd
    if ($LastExitCode -ne 0) { throw "The following call failed with exit code $LastExitCode. '$cmd'" }
}

if (!$NoInit) {
    md -force $DotNetDirectory > $null

    $DotNetScriptFile = "$TempDirectory\dotnet-install.ps1"
    if (!(Test-Path $DotNetScriptFile)) { (New-Object System.Net.WebClient).DownloadFile($DotNetScriptUrl, $DotNetScriptFile) }
    ExecSafe { & $DotNetScriptFile -InstallDir $DotNetDirectory -Channel $DotNetChannel -NoPath }

    ExecSafe { & $DotNetFile restore $BuildProjectFile }
}

ExecSafe { & $DotNetFile build $BuildProjectFile --no-restore /p:ReferenceExternal=$RefExt }

###########################################################################
# EXECUTE BUILD
###########################################################################

ExecSafe { & $DotNetFile run --project $BuildProjectFile --no-build -- $BuildArguments }
