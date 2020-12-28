// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
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
                var settings = new JsonSerializerSettings { ContractResolver = new AllWritableContractResolver() };
                return JsonConvert.DeserializeObject<NerdbankGitVersioning>(string.Join("\r\n", output), settings);
            }
            catch (Exception exception)
            {
                throw new Exception($"{nameof(NerdbankGitVersioning)} exited with code {process.ExitCode}, but cannot parse output as JSON:"
                        .Concat(process.Output.Select(x => x.Text)).JoinNewLine(),
                    exception);
            }
        }
    }

    [PublicAPI]
    public class NerdbankGitVersioning
    {
        public string CloudBuildNumber { get; set; }
        public List<string> BuildMetadataWithCommitId { get; set; }
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
        public List<string> BuildMetadata { get; set; }
        public string BuildMetadataFragment { get; set; }
        public string NuGetPackageVersion { get; set; }
        public string ChocolateyPackageVersion { get; set; }
        public string NpmPackageVersion { get; set; }
        public string SemVer1 { get; set; }
        public string SemVer2 { get; set; }
        public int SemVer1NumericIdentifierPadding { get; set; }
    }
}
