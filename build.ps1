[CmdletBinding()]
Param(
    [switch]$Local,
    [switch]$RefExt,
    [Parameter(Position=0,Mandatory=$false,ValueFromRemainingArguments=$true)]
    [string[]]$BuildArguments
)

Write-Output "Windows PowerShell $($Host.Version)"

Set-StrictMode -Version 2.0; $ErrorActionPreference = "Stop"; $ConfirmPreference = "None"; trap { $host.SetShouldExit(1) }
$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

###########################################################################
# CONFIGURATION
###########################################################################

$BuildProjectFile = "$PSScriptRoot\build\.build.csproj"
$TempDirectory = "$PSScriptRoot\.tmp"

$DotNetChannel = "2.0"
$DotNetScriptUrl = "https://raw.githubusercontent.com/dotnet/cli/master/scripts/obtain/dotnet-install.ps1"

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

if ((-not $Local) -and (Get-Command "dotnet" -ErrorAction SilentlyContinue) -ne $null) {
    $env:DOTNET_EXE = (Get-Command "dotnet").Path
}
else {
    $DotNetDirectory = "$TempDirectory\dotnet-win"
    $env:DOTNET_EXE = "$DotNetDirectory\dotnet.exe"

    $DotNetScriptFile = "$TempDirectory\dotnet-install.ps1"
    if (!(Test-Path $DotNetScriptFile)) {
        md -force $TempDirectory > $null
        (New-Object System.Net.WebClient).DownloadFile($DotNetScriptUrl, $DotNetScriptFile)
    }
    
    ExecSafe { & $DotNetScriptFile -InstallDir $DotNetDirectory -Channel $DotNetChannel -NoPath }
}
Write-Output "Microsoft (R) .NET Core SDK version $(& $env:DOTNET_EXE --version)"

ExecSafe { & $env:DOTNET_EXE build $BuildProjectFile /p:ReferenceExternal=$RefExt }
ExecSafe { & $env:DOTNET_EXE run --project $BuildProjectFile -- $BuildArguments }
