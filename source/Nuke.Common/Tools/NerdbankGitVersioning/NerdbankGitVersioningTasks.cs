// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tools.NerdbankGitVersioning;

partial class NerdbankGitVersioningTasks
{
    protected override object GetResult<T>(ToolOptions options, IReadOnlyCollection<Output> output)
    {
        // var output = process.Output.EnsureOnlyStd().Select(x => x.Text).JoinNewLine();
        try
        {
            return output.EnsureOnlyStd().StdToJson<NerdbankGitVersioning>();
        }
        catch (Exception exception)
        {
            throw new Exception($"Cannot parse {nameof(NerdbankGitVersioning)} output:".Concat(output.Select(x => x.Text)).JoinNewLine(), exception);
        }
    }
}

[PublicAPI]
public record NerdbankGitVersioning(
    string CloudBuildNumber,
    List<string> BuildMetadataWithCommitId,
    string AssemblyVersion,
    string AssemblyFileVersion,
    string AssemblyInformationalVersion,
    bool PublicRelease,
    string PrereleaseVersion,
    string PrereleaseVersionNoLeadingHyphen,
    string SimpleVersion,
    int BuildNumber,
    int VersionRevision,
    string MajorMinorVersion,
    int VersionMajor,
    int VersionMinor,
    string GitCommitId,
    string GitCommitIdShort,
    DateTime GitCommitDate,
    int VersionHeight,
    int VersionHeightOffset,
    string Version,
    List<string> BuildMetadata,
    string BuildMetadataFragment,
    string NuGetPackageVersion,
    string ChocolateyPackageVersion,
    string NpmPackageVersion,
    string SemVer1,
    string SemVer2,
    int SemVer1NumericIdentifierPadding);
