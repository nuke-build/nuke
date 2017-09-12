[CmdletBinding()]
Param()

Set-StrictMode -Version 2.0; $ErrorActionPreference = "Stop"; $ConfirmPreference = "None"; trap { $host.SetShouldExit(1) }
$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

###########################################################################
# CONFIGURATION
###########################################################################

$BootstrappingUrl = "https://raw.githubusercontent.com/nuke-build/nuke/master/bootstrapping"
$NuGetVersion = "latest"
$BuildDirectoryName = ".\build"
$BuildProjectName = ".build"
$TargetFrameworkSelection = 1
$FormatSelection = 1

###########################################################################
# HELPER FUNCTIONS
###########################################################################

function ReadWithDefault($text, $default) {
    Write-Host "$text. Leave blank for default: $($default)."
    $prompt = Read-Host "Value"
    return ($default,$prompt)[[bool]$prompt]
}

function Download($url, $file) {
    md -force (Split-Path $file -Parent) > $null
    (New-Object System.Net.WebClient).DownloadFile($url, $file)
}

function GetRelative($base, $destination) {
    Push-Location $base
    try {
        return (Resolve-Path -relative $destination)
    } finally {
        Pop-Location
    }
}

###########################################################################
# LOCATE SOLUTION FILE
###########################################################################

$RootDirectory = $PSScriptRoot
while ($RootDirectory -ne "" -and 
       @(Get-ChildItem -Path $RootDirectory -Force | Where-Object { $_.Name -match '^.git$|^.svn$' }).length -eq 0) {
  $RootDirectory = Split-Path $RootDirectory -Parent
}
if ($RootDirectory -eq "") { $RootDirectory = $PSScriptRoot }
Write-Host "Searching for solution files under '$RootDirectory' (2-levels)..."

$SolutionFiles = @(Get-ChildItem "*.sln" -Path $RootDirectory -Depth 2)
if (@($SolutionFiles).length -eq 0) { throw "No solution file (*.sln) could be found." }

$SolutionFileSelection = 0
if (@($SolutionFiles).length -gt 1) {
  do {
    Write-Host "Found multiple solution files:"
    $SolutionFiles | % {$i=0} { Write-Host "[$i] $(GetRelative $PSScriptRoot $_.FullName)" ; $i++}
    $SolutionFileSelection = Read-host "Default solution file id"
  }
  until ($SolutionFileSelection -ge 0 -and $SolutionFileSelection -lt @($SolutionFiles).length)
}

$SolutionFile = $SolutionFiles[$SolutionFileSelection].FullName
$SolutionDirectory = Split-Path $SolutionFile -Parent
((GetRelative $RootDirectory $SolutionFile) -replace "\\","/") | Out-File "$RootDirectory\.nuke"

Write-Host "Using '$(GetRelative $PSScriptRoot $SolutionFile)' as solution file."

###########################################################################
# OTHER CONFIGURATIONS
###########################################################################

$TargetFrameworkSelection = $host.ui.PromptForChoice(
  $null,
  "Build project target framework:",
  @(
    (New-Object System.Management.Automation.Host.ChoiceDescription ".NET &Framework", "Will use MSBuild/Mono."),
    (New-Object System.Management.Automation.Host.ChoiceDescription ".NET &Core", "Will use dotnet CLI.")
  ),
  $TargetFrameworkSelection)

if ($TargetFrameworkSelection -eq 0) {
  $FormatSelection = $host.ui.PromptForChoice(
    $null,
    "Build project format:",
    @(
      (New-Object System.Management.Automation.Host.ChoiceDescription "&Legacy format", "Supported by all MSBuild versions."),
      (New-Object System.Management.Automation.Host.ChoiceDescription "&SDK-based format", "Requires MSBuild 15.0.")
    ),
    $FormatSelection)
    
  $NuGetVersion = (ReadWithDefault "NuGet executable version" $NuGetVersion)
}

$BuildDirectoryName = (ReadWithDefault "Directory for build project" $BuildDirectoryName)
$BuildProjectName = (ReadWithDefault "Name for build project" $BuildProjectName)
$BuildDirectory = "$PSScriptRoot\$BuildDirectoryName"

###########################################################################
# GENERATE BUILD SCRIPTS
###########################################################################

Write-Host "Generating build.ps1 and build.sh..."

$ScriptKind = @("netfx", "netcore")[$TargetFrameworkSelection]

md -force $BuildDirectory > $null

Set-Content "build.ps1" ((New-Object System.Net.WebClient).DownloadString("$BootstrappingUrl/build.$($ScriptKind).ps1") `
    -replace "_NUGET_VERSION_",$NuGetVersion `
    -replace "_BUILD_DIRECTORY_NAME_",$BuildDirectoryName `
    -replace "_BUILD_PROJECT_NAME_",$BuildProjectName `
    -replace "_SOLUTION_DIRECTORY_",(GetRelative $PSScriptRoot $SolutionDirectory) `
    -replace "_ROOT_DIRECTORY_",(GetRelative $PSScriptRoot $RootDirectory))

Set-Content "build.sh" ((New-Object System.Net.WebClient).DownloadString("$BootstrappingUrl/build.$($ScriptKind).sh") `
    -replace "_NUGET_VERSION_",$NuGetVersion `
    -replace "_BUILD_DIRECTORY_NAME_",$BuildDirectoryName `
    -replace "_BUILD_PROJECT_NAME_",$BuildProjectName `
    -replace "_SOLUTION_DIRECTORY_",((GetRelative $PSScriptRoot $SolutionDirectory) -replace "\\","/") `
    -replace "_ROOT_DIRECTORY_",((GetRelative $PSScriptRoot $RootDirectory) -replace "\\","/"))

###########################################################################
# GENERATE PROJECT FILES
###########################################################################

Write-Host "Generating project template..."

$LatestVersion = $(Invoke-WebRequest https://api-v2v3search-0.nuget.org/query?q=packageid:Nuke.Common | ConvertFrom-Json).data.version
$ProjectGuid = [guid]::NewGuid().ToString().ToUpper()
$TargetFramework = @("net461", "netcoreapp2.0")[$TargetFrameworkSelection]
$ProjectKindGuid = @("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC", "9A19103F-16F7-4668-BE54-9A1E7A4F7556")[$FormatSelection]
$ProjectFormat = @("legacy", "sdk")[$FormatSelection]
$BuildProjectFile = "$BuildDirectory\$BuildProjectName.csproj"
$SolutionDirectoryRelative = (GetRelative $BuildDirectory $SolutionDirectory)

(New-Object System.Net.WebClient).DownloadFile("$BootstrappingUrl/.build.csproj.DotSettings", "$BuildProjectFile.dotsettings")
(New-Object System.Net.WebClient).DownloadFile("$BootstrappingUrl/Build.cs", "$BuildDirectory\Build.cs")

Set-Content "$BuildProjectFile" ((New-Object System.Net.WebClient).DownloadString("$BootstrappingUrl/.build.$($ProjectFormat).csproj") `
    -replace "_TARGET_FRAMEWORK_",$TargetFramework `
    -replace "_BUILD_PROJECT_GUID_",$ProjectGuid `
    -replace "_BUILD_PROJECT_NAME_",$BuildProjectName `
    -replace "_SOLUTION_DIRECTORY_",$SolutionDirectoryRelative `
    -replace "_LATEST_VERSION_",$LatestVersion)

if ($FormatSelection -eq 0) {
    Set-Content "$BuildDirectory\packages.config" ((New-Object System.Net.WebClient).DownloadString("$BootstrappingUrl/.build.legacy.packages.config") `
        -replace "_LATEST_VERSION_",$LatestVersion)
}

###########################################################################
# ADD TO SOLUTION
###########################################################################

$SolutionFileContent = (Get-Content $SolutionFile)
if (!($SolutionFileContent -match "`"$BuildProjectName`"")) {
    Write-Host "Adding $BuildProjectName project to solution..."

    $SolutionFileContent | Foreach-Object {
        $_
        if ($_ -match "MinimumVisualStudioVersion") {
            "Project(`"{$ProjectKindGuid}`") = `"$BuildProjectName`", `"$(GetRelative $SolutionDirectory $BuildProjectFile)`", `"{$ProjectGuid}`""
            "EndProject"
        }
        if ($_ -match "ProjectConfigurationPlatforms") {
            "`t`t{$ProjectGuid}.Debug|Any CPU.ActiveCfg = Debug|Any CPU"
            "`t`t{$ProjectGuid}.Release|Any CPU.ActiveCfg = Release|Any CPU"
        }
    } | Set-Content $SolutionFile -Encoding UTF8
}

###########################################################################
# FINISH
###########################################################################

Remove-Item $MyInvocation.MyCommand.Path
Write-Host "Finished setting up build project."
