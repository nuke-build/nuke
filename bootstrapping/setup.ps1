[CmdletBinding()]
Param()

$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

###########################################################################
# CONFIGURATION
###########################################################################

$BootstrappingUrl = "https://raw.githubusercontent.com/nuke-build/nuke/master/bootstrapping"
$DefaultNuGetUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
$DefaultBuildDirectoryName = ".\build"
$DefaultBuildProjectName = ".build"

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
       (Get-ChildItem -Path $RootDirectory -Force | Where-Object { $_.Name -match '^.git$|^.svn$' }).length -eq 0) {
  $RootDirectory = Split-Path $RootDirectory -Parent
}
if ($RootDirectory -eq "") { $RootDirectory = $PSScriptRoot }
Write-Host "Searching for solution files under '$RootDirectory' (2-levels)..."

$SolutionFiles = @(Get-ChildItem "*.sln" -Path $RootDirectory -Depth 2)
if ($SolutionFiles.length -eq 0) { throw "No solution file (*.sln) could be found." }

$SolutionFileSelection = 0
if ($SolutionFiles.length -gt 1) {
  do {
    Write-Host "Found multiple solution files:"
    $SolutionFiles | % {$i=0} { Write-Host "[$i] $(GetRelative $PSScriptRoot $_.FullName)" ; $i++}
    $SolutionFileSelection = Read-host "Default solution file id"
  }
  until ($SolutionFileSelection -ge 0 -and $SolutionFileSelection -lt $SolutionFiles.length)
}

$SolutionFile = $SolutionFiles[$SolutionFileSelection].FullName
$SolutionDirectory = Split-Path $SolutionFile -Parent
((GetRelative $RootDirectory $SolutionFile) -replace "\\","/") | Out-File "$RootDirectory\.nuke"

Write-Host "Using '$(GetRelative $PSScriptRoot $SolutionFile)' as solution file."

###########################################################################
# GENERATE BUILD SCRIPTS
###########################################################################

$NuGetUrl = (ReadWithDefault "NuGet executable download url" $DefaultNuGetUrl)
$BuildDirectoryName = (ReadWithDefault "Directory for build project" $DefaultBuildDirectoryName)
$BuildProjectName = (ReadWithDefault "Name for build project" $DefaultBuildProjectName)

Write-Host "Generating build.ps1, build.sh and configuration file..."

Set-Content "build.ps1" ((New-Object System.Net.WebClient).DownloadString("$BootstrappingUrl/build.ps1") `
    -replace "_NUGET_URL_",$NuGetUrl `
    -replace "_BUILD_DIRECTORY_NAME_",$BuildDirectoryName `
    -replace "_BUILD_PROJECT_NAME_",$BuildProjectName `
    -replace "_SOLUTION_DIRECTORY_",(GetRelative $PSScriptRoot $SolutionDirectory) `
    -replace "_ROOT_DIRECTORY_",(GetRelative $PSScriptRoot $RootDirectory))

Set-Content "build.sh" ((New-Object System.Net.WebClient).DownloadString("$BootstrappingUrl/build.sh") `
    -replace "_NUGET_URL_",$NuGetUrl `
    -replace "_BUILD_DIRECTORY_NAME_",$BuildDirectoryName `
    -replace "_BUILD_PROJECT_NAME_",$BuildProjectName `
    -replace "_SOLUTION_DIRECTORY_",((GetRelative $PSScriptRoot $SolutionDirectory) -replace "\\","/") `
    -replace "_ROOT_DIRECTORY_",((GetRelative $PSScriptRoot $RootDirectory) -replace "\\","/"))

###########################################################################
# DOWNLOAD NUGET.EXE
###########################################################################

Write-Host "Downloading nuget.exe..."
$NuGetFile = "$RootDirectory\.tmp\nuget.exe"
Download $NuGetUrl $NuGetFile

###########################################################################
# GENERATE TEMPLATE FILES
###########################################################################

$FormatSelection = $host.ui.PromptForChoice(
  $null,
  "Which format do you want to use for your build project?",
  @(
    (New-Object System.Management.Automation.Host.ChoiceDescription "&Legacy format", "Supported by all MSBuild versions."),
    (New-Object System.Management.Automation.Host.ChoiceDescription "&SDK-based format", "Requires MSBuild 15.0.")
  ),
  1)

Write-Host "Generating template files..."

$BuildProjectUrl = @("$BootstrappingUrl/.build.legacy.csproj", "$BootstrappingUrl/.build.sdk.csproj")[$FormatSelection]
$DotSettingsUrl = "$BootstrappingUrl/.build.csproj.DotSettings"
$DefaultBuildUrl = "$BootstrappingUrl/Build.cs"

$BuildDirectory = "$PSScriptRoot\$BuildDirectoryName"
$BuildProjectFile = "$BuildDirectory\$BuildProjectName.csproj"
md -force $BuildDirectory > $null

Download $BuildProjectUrl "$BuildProjectFile"
Download $DotSettingsUrl "$BuildProjectFile.dotsettings"
Download $DefaultBuildUrl "$BuildDirectory\Build.cs"

$ProjectGuid = [guid]::NewGuid().ToString().ToUpper()
$ProjectKindGuid = @("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC", "9A19103F-16F7-4668-BE54-9A1E7A4F7556")[$FormatSelection]

if ($FormatSelection -eq 0) {
    Download "$BootstrappingUrl/.build.legacy.packages.config" "$BuildDirectory\packages.config"

    Set-Content $BuildProjectFile ((Get-Content $BuildProjectFile) `
        -replace "_BUILD_PROJECT_GUID_",$ProjectGuid `
        -replace "_BUILD_PROJECT_NAME_",$BuildProjectName `
        -replace "_SOLUTION_DIRECTORY_",(GetRelative $BuildDirectory $SolutionDirectory))

    & $NuGetFile restore $BuildProjectFile -SolutionDirectory $SolutionDirectory
    & $NuGetFile update $BuildProjectFile
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
