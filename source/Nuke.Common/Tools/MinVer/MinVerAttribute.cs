// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Tooling;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tools.MinVer;

/// <summary>
/// Injects an instance of <see cref="MinVer"/> based on the local repository.
/// </summary>
[PublicAPI]
[UsedImplicitly(ImplicitUseKindFlags.Default)]
public class MinVerAttribute : ValueInjectionAttributeBase
{
    public MinVerVersionPart AutoIncrement { get; internal set; }
    public string BuildMetadata { get; set; }
    public string DefaultPreReleasePhase { get; set; }
    public string MinimumMajorMinor { get; set; }
    public string TagPrefix { get; set; }
    public MinVerVerbosity Verbosity { get; set; }
    public string Framework { get; set; }
    public bool UpdateBuildNumber { get; set; }

    public override object GetValue(MemberInfo member, object instance)
    {
        var version = MinVerTasks.MinVer(s => s
                .SetAutoIncrement(AutoIncrement)
                .SetBuildMetadata(BuildMetadata)
                .SetDefaultPreReleasePhase(DefaultPreReleasePhase)
                .SetMinimumMajorMinor(MinimumMajorMinor)
                .SetTagPrefix(TagPrefix)
                .SetVerbosity(Verbosity)
                .SetFramework(Framework)
                .DisableProcessLogOutput())
            .Result;

        if (UpdateBuildNumber)
        {
            AzurePipelines.Instance?.UpdateBuildNumber(version.Version);
            TeamCity.Instance?.SetBuildNumber(version.Version);
            AppVeyor.Instance?.UpdateBuildVersion(version.Version);
        }

        return version;
    }
}
