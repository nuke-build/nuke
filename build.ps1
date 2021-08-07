[CmdletBinding()]
Param(
    [Parameter(Position=0,Mandatory=$false,ValueFromRemainingArguments=$true)]
    [string[]]$BuildArguments
)

Write-Output "PowerShell $($PSVersionTable.PSEdition) version $($PSVersionTable.PSVersion)"

Set-StrictMode -Version 2.0; $ErrorActionPreference = "Stop"; $ConfirmPreference = "None"; trap { Write-Error $_ -ErrorAction Continue; exit 1 }
$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

###########################################################################
# CONFIGURATION
###########################################################################

$BuildProjectFile = "$PSScriptRoot\build\_build.csproj"
$TempDirectory = "$PSScriptRoot\.nuke\temp"

$DotNetGlobalFile = "$PSScriptRoot\global.json"
$DotNetInstallUrl = "https://dot.net/v1/dotnet-install.ps1"

$PrivateDotNetChannel = "Current"
$PrivateDotNetDirectory = "$TempDirectory\dotnet-win"
$PrivateDotNetExe = "$PrivateDotNetDirectory\dotnet.exe"

$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = 1
$env:DOTNET_CLI_TELEMETRY_OPTOUT = 1
$env:DOTNET_MULTILEVEL_LOOKUP = 0
$env:DOTNET_ROLL_FORWARD = "Major"
$env:NUKE_TELEMETRY_OPTOUT = 1
$env:MSBUILDDISABLENODEREUSE = 1

#$env:NUKE_ENTERPRISE_SOURCE = "https://nuget.pkg.github.com/nuke-build/index.json"
#$env:NUKE_ENTERPRISE_USERNAME = "nuke-bot"

###########################################################################
# EXECUTION
###########################################################################

function ExecSafe([scriptblock] $cmd) {
    & $cmd
    if ($LASTEXITCODE) { exit $LASTEXITCODE }
}

function CheckDotNetVersion([string] $dotNetCommand = "dotnet") {
    $null -ne (Get-Command "dotnet" -ErrorAction SilentlyContinue) -and `
        $(dotnet --version) -and $LASTEXITCODE -eq 0
}

# Print environment variables
# WARNING: Make sure that secrets are actually scrambled in build log
# Get-Item -Path Env:* | Sort-Object -Property Name | ForEach-Object {"{0}={1}" -f $_.Name,$_.Value}

# Check if any dotnet is installed
if ($null -ne (Get-Command "dotnet" -ErrorAction SilentlyContinue)) {
    ExecSafe { & dotnet --info }
} else {
    Write-Output "NUKE: no dotnet CLI installed"
}

# If dotnet CLI is installed globally and it matches requested version, use for execution
if (CheckDotNetVersion) {
    Write-Output "NUKE: Using installed dotnet CLI"
    $env:DOTNET_EXE = (Get-Command "dotnet").Path
}
elseif(CheckDotNetVersion $PrivateDotNetExe) {
    Write-Output "NUKE: Using private installed dotnet CLI at \"$PrivateDotNetDirectory\""
    $env:DOTNET_EXE = "$PrivateDotNetExe"
}
else {
    # If global.json exists, load expected version
    if (Test-Path $DotNetGlobalFile) {
        $DotNetGlobal = $(Get-Content $DotNetGlobalFile | Out-String | ConvertFrom-Json)
        if ($DotNetGlobal.PSObject.Properties["sdk"] -and $DotNetGlobal.sdk.PSObject.Properties["version"]) {
            $DotNetVersion = $DotNetGlobal.sdk.version
        }
    }

    # Install by channel or version
    if (!(Test-Path variable:DotNetVersion)) {
        $PrivateDotNetSpec = "-Channel", $PrivateDotNetChannel
    } else {
        $PrivateDotNetSpec = "-Version", $DotNetVersion
    }

    Write-Output "NUKE: Downloading dotnet CLI ($PrivateDotNetSpec) to ""$PrivateDotNetDirectory"""
    # Download install script
    $DotNetInstallFile = "$TempDirectory\dotnet-install.ps1"
    New-Item -ItemType Directory -Path $TempDirectory -Force | Out-Null
    [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
    (New-Object System.Net.WebClient).DownloadFile($DotNetInstallUrl, $DotNetInstallFile)

    ExecSafe { & powershell $DotNetInstallFile -InstallDir $PrivateDotNetDirectory $PrivateDotNetSpec -NoPath }

    Write-Output "NUKE: Using private installed dotnet CLI at \"$PrivateDotNetDirectory\""
    $env:DOTNET_EXE = "$PrivateDotNetExe"
}

Write-Output "Microsoft (R) .NET Core SDK version $(& $env:DOTNET_EXE --version)"

#if (Test-Path env:NUKE_ENTERPRISE_PASSWORD) {
#    ExecSafe { & $env:DOTNET_EXE nuget add source $env:NUKE_ENTERPRISE_SOURCE --username $env:NUKE_ENTERPRISE_USERNAME --password $env:NUKE_ENTERPRISE_PASSWORD }
#}

ExecSafe { & $env:DOTNET_EXE build $BuildProjectFile /nodeReuse:false /p:UseSharedCompilation=false -nologo -clp:NoSummary }
ExecSafe { & $env:DOTNET_EXE run --project $BuildProjectFile --no-build -- $BuildArguments }
