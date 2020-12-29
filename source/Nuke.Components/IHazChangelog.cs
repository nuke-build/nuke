// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common;
using static Nuke.Common.ChangeLog.ChangelogTasks;

namespace Nuke.Components
{
    public interface IHazChangelog : INukeBuild
    {
        // TODO: assert file exists
        string ChangelogFile => RootDirectory / "CHANGELOG.md";

        string ReleaseNotes => GetNuGetReleaseNotes(
            ChangelogFile,
            (this as IHazGitRepository)?.GitRepository);
    }
}
