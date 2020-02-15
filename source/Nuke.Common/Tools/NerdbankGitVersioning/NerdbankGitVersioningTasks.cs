// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tools.NerdbankGitVersioning
{
    public partial class NerdbankGitVersioningTasks
    {
        private static NerdbankGitVersioning GetResult(IProcess process, NerdbankGitVersioningGetVersionSettings toolSettings)
        {
            try
            {
                var output = process.Output.EnsureOnlyStd().Select(x => x.Text).ToList();
                return JsonConvert.DeserializeObject<NerdbankGitVersioning>(string.Join("\r\n", output));
            }
            catch (Exception exception)
            {
                throw new Exception($"{nameof(NerdbankGitVersioning)} exited with code {process.ExitCode}, but cannot parse output as JSON:"
                        .Concat(process.Output.Select(x => x.Text)).JoinNewLine(),
                    exception);
            }
        }
    }
    public class GitVersion
    {
        public string Version { get; set; }
        public string Prerelease { get; set; }
        public string BuildMetadata { get; set; }
    }

    public class BuildNumber
    {
        public bool Enabled { get; set; }
        public object IncludeCommitId { get; set; }
    }

    public class CloudBuild
    {
        public object SetAllVariables { get; set; }
        public object SetVersionVariables { get; set; }
        public BuildNumber BuildNumber { get; set; }
    }

    public class VersionOptions
    {
        public GitVersion Version { get; set; }
        public List<string> PublicReleaseRefSpec { get; set; }
        public CloudBuild CloudBuild { get; set; }
    }

    public class CloudBuildAllVars
    {
        public string NBGV_CloudBuildNumber { get; set; }
        public string NBGV_VersionFileFound { get; set; }
        public string NBGV_VersionOptions { get; set; }
        public string NBGV_AssemblyVersion { get; set; }
        public string NBGV_AssemblyFileVersion { get; set; }
        public string NBGV_AssemblyInformationalVersion { get; set; }
        public string NBGV_PublicRelease { get; set; }
        public string NBGV_PrereleaseVersion { get; set; }
        public string NBGV_PrereleaseVersionNoLeadingHyphen { get; set; }
        public string NBGV_SimpleVersion { get; set; }
        public string NBGV_BuildNumber { get; set; }
        public string NBGV_VersionRevision { get; set; }
        public string NBGV_MajorMinorVersion { get; set; }
        public string NBGV_VersionMajor { get; set; }
        public string NBGV_VersionMinor { get; set; }
        public string NBGV_GitCommitId { get; set; }
        public string NBGV_GitCommitIdShort { get; set; }
        public string NBGV_GitCommitDate { get; set; }
        public string NBGV_VersionHeight { get; set; }
        public string NBGV_VersionHeightOffset { get; set; }
        public string NBGV_Version { get; set; }
        public string NBGV_BuildMetadataFragment { get; set; }
        public string NBGV_NuGetPackageVersion { get; set; }
        public string NBGV_ChocolateyPackageVersion { get; set; }
        public string NBGV_NpmPackageVersion { get; set; }
        public string NBGV_SemVer1 { get; set; }
        public string NBGV_SemVer2 { get; set; }
        public string NBGV_SemVer1NumericIdentifierPadding { get; set; }
    }

    public class CloudBuildVersionVars
    {
        public string GitAssemblyInformationalVersion { get; set; }
        public string GitBuildVersion { get; set; }
        public string GitBuildVersionSimple { get; set; }
    }

    public class NerdbankGitVersioning
    {
        public string CloudBuildNumber { get; set; }
        public bool CloudBuildNumberEnabled { get; set; }
        public List<string> BuildMetadataWithCommitId { get; set; }
        public bool VersionFileFound { get; set; }
        public VersionOptions VersionOptions { get; set; }
        public string AssemblyVersion { get; set; }
        public string AssemblyFileVersion { get; set; }
        public string AssemblyInformationalVersion { get; set; }
        public bool PublicRelease { get; set; }
        public string PrereleaseVersion { get; set; }
        public string PrereleaseVersionNoLeadingHyphen { get; set; }
        public string SimpleVersion { get; set; }
        public int BuildNumber { get; set; }
        public int VersionRevision { get; set; }
        public string MajorMinorVersion { get; set; }
        public int VersionMajor { get; set; }
        public int VersionMinor { get; set; }
        public string GitCommitId { get; set; }
        public string GitCommitIdShort { get; set; }
        public DateTime GitCommitDate { get; set; }
        public int VersionHeight { get; set; }
        public int VersionHeightOffset { get; set; }
        public string Version { get; set; }
        public bool CloudBuildAllVarsEnabled { get; set; }
        public CloudBuildAllVars CloudBuildAllVars { get; set; }
        public bool CloudBuildVersionVarsEnabled { get; set; }
        public CloudBuildVersionVars CloudBuildVersionVars { get; set; }
        public List<object> BuildMetadata { get; set; }
        public string BuildMetadataFragment { get; set; }
        public string NuGetPackageVersion { get; set; }
        public string ChocolateyPackageVersion { get; set; }
        public string NpmPackageVersion { get; set; }
        public string SemVer1 { get; set; }
        public string SemVer2 { get; set; }
        public int SemVer1NumericIdentifierPadding { get; set; }
    }
}