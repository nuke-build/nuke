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

$BuildProjectFile = "$PSScriptRoot\_BUILD_DIRECTORY_NAME_\_BUILD_PROJECT_NAME_.csproj"
$TempDirectory = "$PSScriptRoot\_ROOT_DIRECTORY_\.tmp"

$DotNetChannel = "2.0"
$DotNetScriptUrl = "https://raw.githubusercontent.com/dotnet/cli/master/scripts/obtain/dotnet-install.ps1"
$DotNetDirectory = "$TempDirectory\dotnet-win"

$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = 1
$env:DOTNET_CLI_TELEMETRY_OPTOUT = 1
$env:NUGET_XMLDOC_MODE = "skip"

###########################################################################
# EXECUTION
###########################################################################

function ExecSafe([scriptblock] $cmd) {
    & $cmd
    if ($LASTEXITCODE) { exit $LASTEXITCODE }
}

if (-not $Local -and (Get-Command "dotnet" -ErrorAction SilentlyContinue) -ne $null) {
    $env:DOTNET_EXE = (Get-Command "dotnet").Path
}
else {
    $env:DOTNET_EXE = "$DotNetDirectory\dotnet.exe"
    
    if (!(Test-Path $env:DOTNET_EXE)) {
        md -force $DotNetDirectory > $null

        $DotNetScriptFile = "$TempDirectory\dotnet-install.ps1"
        (New-Object System.Net.WebClient).DownloadFile($DotNetScriptUrl, $DotNetScriptFile)

        ExecSafe { & $DotNetScriptFile -InstallDir $DotNetDirectory -Channel $DotNetChannel -NoPath }
    }
}

ExecSafe { & $env:DOTNET_EXE run --project $BuildProjectFile -- $args }
