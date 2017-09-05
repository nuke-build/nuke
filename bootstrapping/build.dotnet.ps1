[CmdletBinding()]
Param(
    [string]$Target = "Default",
    [ValidateSet("Release", "Debug")]
    [string]$Configuration = "Release",
    [ValidateSet("Quiet", "Minimal", "Normal", "Verbose")]
    [string]$Verbosity = "Verbose",
    [Parameter(Position=0,Mandatory=$false,ValueFromRemainingArguments=$true)]
    [string[]]$ScriptArgs
)

Set-StrictMode -Version 2.0; $ErrorActionPreference = "Stop"; $ConfirmPreference = "None"; trap { $host.SetShouldExit(1) }
$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

###########################################################################
# CONFIGURATION
###########################################################################

$InstallScriptUrl = "https://raw.githubusercontent.com/dotnet/cli/master/scripts/obtain/dotnet-install.ps1"
$InstallChannel = "master"
$InstallVersion = "latest"
$SolutionDirectory = "$PSScriptRoot\_SOLUTION_DIRECTORY_"
$BuildProjectFile = "$PSScriptRoot\_BUILD_DIRECTORY_NAME_\_BUILD_PROJECT_NAME_.csproj"
$BuildAssemblyFile = "$PSScriptRoot\_BUILD_DIRECTORY_NAME_\bin\debug\_BUILD_PROJECT_NAME_.dll"
$DotNetDirectory = "$PSScriptRoot\_ROOT_DIRECTORY_\.dotnet"

###########################################################################
# PREPARE BUILD
###########################################################################

function ExecSafe([scriptblock] $cmd) {
    & $cmd
    if ($LastExitCode -ne 0) { throw "The following call failed with exit code $LastExitCode. '$cmd'" }
}

md -force $DotNetDirectory > $null

$InstallScriptFile = "$DotNetDirectory\dotnet-install.ps1"
if (!(Test-Path $InstallScriptFile)) { (New-Object System.Net.WebClient).DownloadFile($InstallScriptUrl, $InstallScriptFile) }
ExecSafe { & $InstallScriptFile -Channel $InstallChannel -Version $InstallVersion -NoPath }

$DotNetFile = "$DotNetDirectory\dotnet.exe"
ExecSafe { & $DotNetFile restore $BuildProjectFile }
ExecSafe { & $DotNetFile build $BuildProjectFile }

###########################################################################
# EXECUTE BUILD
###########################################################################

$Arguments = @{
    target=$Target;
    configuration=$Configuration;
    verbosity=$Verbosity;
}.GetEnumerator() | %{"--{0}=`"{1}`"" -f $_.key, $_.value };

ExecSafe { & $DotNetFile run $BuildAssemblyFile $Arguments $ScriptArgs }
