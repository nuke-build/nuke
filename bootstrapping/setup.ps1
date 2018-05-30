[CmdletBinding()]
Param(
    [switch]$Default
)

Set-StrictMode -Version 2.0; $ErrorActionPreference = "Stop"; $ConfirmPreference = "None"; trap { $host.SetShouldExit(1) }
$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

###########################################################################
# HELPER FUNCTIONS
###########################################################################

function ReadWithDefault($text, $default) {
    Write-Host "$text. Leave blank for default: $($default)."
    $prompt = Read-Host "Value"
    return ($default,$prompt)[[bool]$prompt]
}

function GetRelative($base, $destination) {
    $baseUri = [System.Uri]$($base + '/')
    $destinationUri = [System.Uri]$($destination + '/')
    $relativePath = $baseUri.MakeRelativeUri($destinationUri).OriginalString.TrimEnd('/').Replace('/', '\');
    if ([string]::IsNullOrEmpty($relativePath)) { return "." }
    else { return $relativePath }
}

function WriteFile($path, $content) {
    [System.IO.File]::WriteAllText($path, $content)
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

$SolutionFiles = @(Get-ChildItem "*.sln" -Path "$RootDirectory\*","$RootDirectory\*\*")
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

WriteFile "$RootDirectory\.nuke"  ((GetRelative $RootDirectory $SolutionFile) -replace "\\","/")

Write-Host "Using '$(GetRelative $PSScriptRoot $SolutionFile)' as solution file."

###########################################################################
# CONFIGURATION
###########################################################################

$BootstrappingUrl = "https://raw.githubusercontent.com/nuke-build/nuke/master/bootstrapping"
$NukeVersion = $(Invoke-WebRequest -UseBasicParsing https://api-v2v3search-0.nuget.org/query?q=packageid:Nuke.Common | ConvertFrom-Json).data.version
$NuGetVersion = "latest"
$BuildDirectoryName = ".\build"
$BuildProjectName = ".build"
$TargetPlatformSelection = 1
$ProjectFormatSelection = 1

if (-not $Default) {
    $TargetPlatformSelection = $host.ui.PromptForChoice(
            $null,
            "Build project target platform:",
            @(
            (New-Object System.Management.Automation.Host.ChoiceDescription ".NET &Framework", "boostrapping with MSBuild/Mono."),
            (New-Object System.Management.Automation.Host.ChoiceDescription ".NET &Core", "bootstrapping with dotnet CLT.")
            ),
            $TargetPlatformSelection)

    if ($TargetPlatformSelection -eq 0) {
        $ProjectFormatSelection = $host.ui.PromptForChoice(
                $null,
                "Build project format:",
                @(
                (New-Object System.Management.Automation.Host.ChoiceDescription "&Legacy format", "supported by all MSBuild versions."),
                (New-Object System.Management.Automation.Host.ChoiceDescription "&SDK-based format", "requires MSBuild 15.0.")
                ),
                $ProjectFormatSelection)

        $NuGetVersion = (ReadWithDefault "NuGet executable version" $NuGetVersion)
    }

    if ($TargetPlatformSelection -eq 1 -or $ProjectFormatSelection -eq 1) {
        # $NukeVersion = "$($NukeVersionArray[0]).$($NukeVersionArray[1]).*"
        $NukeVersion = (ReadWithDefault "NUKE framework version (use '*' for always latest)" $NukeVersion)
    }
    
    $BuildDirectoryName = (ReadWithDefault "Directory for build project" $BuildDirectoryName)
    $BuildProjectName = (ReadWithDefault "Name for build project" $BuildProjectName)
}

$TargetPlatform = @("netfx", "netcore")[$TargetPlatformSelection]
$TargetFramework = @("net461", "netcoreapp2.0")[$TargetPlatformSelection]
$NukeVersionParts = $NukeVersion.Split('.')
$ProjectGuid = [guid]::NewGuid().ToString().ToUpper()
$ProjectKindGuid = @("FAE04EC0-301F-11D3-BF4B-00C04F79EFBC", "9A19103F-16F7-4668-BE54-9A1E7A4F7556")[$ProjectFormatSelection]
$ProjectFormat = @("legacy", "sdk")[$ProjectFormatSelection]
$BuildDirectory = "$PSScriptRoot\$BuildDirectoryName"
$BuildProjectFile = "$BuildDirectory\$BuildProjectName.csproj"

###########################################################################
# GENERATE BUILD SCRIPTS
###########################################################################

Write-Host "Generating build scripts..."

$SolutionDirectoryRelative = (GetRelative $PSScriptRoot $SolutionDirectory)
$RootDirectoryRelative = (GetRelative $PSScriptRoot $RootDirectory)

WriteFile "$(Get-Location)/build.ps1" ((New-Object System.Net.WebClient).DownloadString("$BootstrappingUrl/build.$($TargetPlatform).ps1") `
    -replace "_NUGET_VERSION_",$NuGetVersion `
    -replace "_BUILD_DIRECTORY_NAME_",$BuildDirectoryName `
    -replace "_BUILD_PROJECT_NAME_",$BuildProjectName `
    -replace "_SOLUTION_DIRECTORY_",$SolutionDirectoryRelative `
    -replace "_ROOT_DIRECTORY_",$RootDirectoryRelative)

WriteFile "$(Get-Location)/build.sh" ((New-Object System.Net.WebClient).DownloadString("$BootstrappingUrl/build.$($TargetPlatform).sh") `
    -replace "_NUGET_VERSION_",$NuGetVersion `
    -replace "_BUILD_DIRECTORY_NAME_",($BuildDirectoryName -replace "\\","/") `
    -replace "_BUILD_PROJECT_NAME_",$BuildProjectName `
    -replace "_SOLUTION_DIRECTORY_",($SolutionDirectoryRelative -replace "\\","/") `
    -replace "_ROOT_DIRECTORY_",($RootDirectoryRelative -replace "\\","/"))

(New-Object System.Net.WebClient).DownloadFile("$BootstrappingUrl/../build.cmd", "$(Get-Location)/build.cmd")

###########################################################################
# GENERATE PROJECT FILES
###########################################################################

Write-Host "Generating build project..."

md -force $BuildDirectory > $null
$SolutionDirectoryRelative = (GetRelative $BuildDirectory $SolutionDirectory)

WriteFile "$BuildProjectFile" ((New-Object System.Net.WebClient).DownloadString("$BootstrappingUrl/.build.$($ProjectFormat).csproj") `
    -replace "_TARGET_FRAMEWORK_",$TargetFramework `
    -replace "_BUILD_PROJECT_GUID_",$ProjectGuid `
    -replace "_BUILD_PROJECT_NAME_",$BuildProjectName `
    -replace "_SOLUTION_DIRECTORY_",$SolutionDirectoryRelative `
    -replace "_NUKE_VERSION_",$NukeVersion `
    -replace "_NUKE_VERSION_MAJOR_MINOR_","$($NukeVersionParts[0]).$($NukeVersionParts[1])")

(New-Object System.Net.WebClient).DownloadFile("$BootstrappingUrl/../build/.build.csproj.DotSettings", "$BuildProjectFile.DotSettings")

if (!(Test-Path "$BuildDirectory\Build.cs")) {
    (New-Object System.Net.WebClient).DownloadFile("$BootstrappingUrl/Build.$($TargetPlatform).cs", "$BuildDirectory\Build.cs")
}

if ($ProjectFormatSelection -eq 0) {
    WriteFile "$BuildDirectory\packages.config" ((New-Object System.Net.WebClient).DownloadString("$BootstrappingUrl/.build.legacy.packages.config") `
        -replace "_NUKE_VERSION_",$NukeVersion)
}

###########################################################################
# ADD TO SOLUTION
###########################################################################

$SolutionFileContent = (Get-Content $SolutionFile)
if (!($SolutionFileContent -match "`"$BuildProjectName`"")) {
    Write-Host "Adding build project to solution..."

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
Write-Host "Finished setting up build."
