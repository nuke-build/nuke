// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.IO;

namespace Nuke.Common
{
    public abstract partial class NukeBuild
    {
        AbsolutePath INukeBuild.RootDirectory => RootDirectory;
        AbsolutePath INukeBuild.TemporaryDirectory => TemporaryDirectory;
        AbsolutePath INukeBuild.BuildAssemblyDirectory => BuildAssemblyDirectory;
        AbsolutePath INukeBuild.BuildProjectDirectory => BuildProjectDirectory;
        AbsolutePath INukeBuild.BuildProjectFile => BuildProjectFile;
        Verbosity INukeBuild.Verbosity => Verbosity;
        HostType INukeBuild.Host => Host;
        bool INukeBuild.Plan => Plan;
        bool INukeBuild.Help => Help;
        bool INukeBuild.NoLogo => NoLogo;
        bool INukeBuild.IsLocalBuild => IsLocalBuild;
        bool INukeBuild.IsServerBuild => IsServerBuild;
        LogLevel INukeBuild.LogLevel => LogLevel;
        bool INukeBuild.Continue => Continue;
    }
}
