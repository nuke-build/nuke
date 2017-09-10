// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitLink;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Tools.InspectCode;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Tools.NuGet;
using Nuke.Common.Tools.OpenCover;
using Nuke.Core;

namespace Nuke.Common
{
    /// <summary>
    /// Variety of default settings, pre-filled with <see cref="NukeBuild.Instance"/> properties
    /// (e.g., <see cref="NukeBuild.SolutionFile"/> and inject values (e.g., <see cref="GitRepository"/> and
    /// best-practice values (e.g., excluding test attributes from coverage analysis).
    /// For more details it's recommended to browse the actual source code.
    /// </summary>
    /// <example>
    /// <code>
    /// Target Restore =&gt; _ =&gt; _
    ///         .DependsOn(Clean)
    ///         .Executes(() =&gt; NuGetRestore(s =&gt; DefaultSettings.NuGetRestore));
    /// </code>
    /// <code>
    /// Target Compile =&gt; _ =&gt; _
    ///         .DependsOn(Restore)
    ///         .Executes(() =&gt; MSBuild(s =&gt; DefaultSettings.MSBuildCompile));
    /// </code>
    /// <code>
    /// Target Pack =&gt; _ =&gt; _
    ///         .DependsOn(Compile)
    ///         .Executes(() =&gt; MSBuild(s =&gt; DefaultSettings.MSBuildPack));
    /// </code>
    /// </example>
    [PublicAPI]
    public class DefaultSettings
    {
        [Obsolete("Use " + nameof(MSBuildTasks) + "." + nameof(MSBuildTasks.DefaultMSBuild))]
        public static MSBuildSettings MSBuildCommon => MSBuildTasks.DefaultMSBuild;

        [Obsolete("Use " + nameof(MSBuildTasks) + "." + nameof(MSBuildTasks.DefaultMSBuildRestore))]
        public static MSBuildSettings MSBuildRestore => MSBuildTasks.DefaultMSBuildRestore;

        [Obsolete("Use " + nameof(MSBuildTasks) + "." + nameof(MSBuildTasks.DefaultMSBuildCompile))]
        public static MSBuildSettings MSBuildCompile => MSBuildTasks.DefaultMSBuildCompile;

        [Obsolete("Use " + nameof(MSBuildTasks) + "." + nameof(MSBuildTasks.DefaultMSBuildCompile))]
        public static MSBuildSettings MSBuildCompileWithVersion => MSBuildTasks.DefaultMSBuildCompile;

        [Obsolete("Use " + nameof(MSBuildTasks) + "." + nameof(MSBuildTasks.DefaultMSBuildPack))]
        public static MSBuildSettings MSBuildPack => MSBuildTasks.DefaultMSBuildPack;

        [Obsolete("Use " + nameof(GitVersionTasks) + "." + nameof(GitVersionTasks.DefaultGitVersion))]
        public static GitVersionSettings GitVersion => GitVersionTasks.DefaultGitVersion;

        [Obsolete("Use " + nameof(NuGetTasks) + "." + nameof(NuGetTasks.DefaultNuGetPack))]
        public static NuGetPackSettings NuGetPack => NuGetTasks.DefaultNuGetPack;

        [Obsolete("Use " + nameof(NuGetTasks) + "." + nameof(NuGetTasks.DefaultNuGetRestore))]
        public static NuGetRestoreSettings NuGetRestore => NuGetTasks.DefaultNuGetRestore;

        [Obsolete("Use " + nameof(InspectCodeTasks) + "." + nameof(InspectCodeTasks.DefaultInspectCode))]
        public static InspectCodeSettings InspectCode => InspectCodeTasks.DefaultInspectCode;

        [Obsolete("Use " + nameof(OpenCoverTasks) + "." + nameof(OpenCoverTasks.DefaultOpenCover))]
        public static OpenCoverSettings OpenCover => OpenCoverTasks.DefaultOpenCover;

        [Obsolete("Use " + nameof(GitLinkTasks) + "." + nameof(GitLinkTasks.DefaultGitLink2))]
        public static GitLink2Settings GitLink2 => GitLinkTasks.DefaultGitLink2;

        [Obsolete("Use " + nameof(GitLinkTasks) + "." + nameof(GitLinkTasks.DefaultGitLink3))]
        public static GitLink3Settings GitLink3 => GitLinkTasks.DefaultGitLink3;
    }
}
