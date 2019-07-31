// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.BuildServers;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Constants;

namespace Nuke.Common
{
    public abstract partial class NukeBuild
    {
        static NukeBuild()
        {
            RootDirectory = GetRootDirectory();
            TemporaryDirectory = GetTemporaryDirectory(RootDirectory);
            FileSystemTasks.EnsureExistingDirectory(TemporaryDirectory);
            BuildAssemblyDirectory = GetBuildAssemblyDirectory();
            BuildProjectDirectory = GetBuildProjectDirectory(BuildAssemblyDirectory);

            Verbosity = ParameterService.Instance.GetParameter<Verbosity?>(() => Verbosity) ?? Verbosity.Normal;
            Host = ParameterService.Instance.GetParameter<HostType?>(() => Host) ?? GetHostType();
            Continue = ParameterService.Instance.GetParameter(() => Continue);
            Plan = ParameterService.Instance.GetParameter(() => Plan);
            Help = ParameterService.Instance.GetParameter(() => Help);
            NoLogo = ParameterService.Instance.GetParameter(() => NoLogo);
        }

        /// <summary>
        /// Gets the full path to the root directory.
        /// </summary>
        [Parameter("Root directory during build execution.", Name = "Root")]
        public static PathConstruction.AbsolutePath RootDirectory { get; }

        /// <summary>
        /// Gets the full path to the temporary directory <c>/.tmp</c>.
        /// </summary>
        public static PathConstruction.AbsolutePath TemporaryDirectory { get; }

        /// <summary>
        /// Gets the full path to the build assembly directory, or <c>null</c>.
        /// </summary>
        [CanBeNull]
        public static PathConstruction.AbsolutePath BuildAssemblyDirectory { get; }

        /// <summary>
        /// Gets the full path to the build project directory, or <c>null</c>
        /// </summary>
        [CanBeNull]
        public static PathConstruction.AbsolutePath BuildProjectDirectory { get; }

        /// <summary>
        /// Gets the logging verbosity during build execution. Default is <see cref="Nuke.Common.Verbosity.Normal"/>.
        /// </summary>
        [Parameter("Logging verbosity during build execution. Default is 'Normal'.")]
        public static Verbosity Verbosity { get; set; }

        /// <summary>
        /// Gets the host for execution. Default is <em>automatic</em>.
        /// </summary>
        [Parameter("Host for execution. Default is 'automatic'.")]
        public static HostType Host { get; }

        /// <summary>
        /// Gets a value whether to show the execution plan (HTML).
        /// </summary>
        [Parameter("Shows the execution plan (HTML).")]
        public static bool Plan { get; }

        /// <summary>
        /// Gets a value whether to show the help text for this build assembly.
        /// </summary>
        [Parameter("Shows the help text for this build assembly.")]
        public static bool Help { get; }

        /// <summary>
        /// Gets a value whether to display the NUKE logo.
        /// </summary>
        [Parameter("Disables displaying the NUKE logo.")]
        public static bool NoLogo { get; }

        public static bool IsLocalBuild => Host == HostType.Console;
        public static bool IsServerBuild => Host != HostType.Console;

        public static LogLevel LogLevel => (LogLevel) Verbosity;

        [Parameter("Indicates to continue a previously failed build attempt.")]
        public static bool Continue { get; internal set; }

        private static PathConstruction.AbsolutePath GetRootDirectory()
        {
            var parameterValue = ParameterService.Instance.GetParameter(() => RootDirectory);
            if (parameterValue != null)
                return parameterValue;

            if (ParameterService.Instance.GetParameter<bool>(() => RootDirectory))
                return (PathConstruction.AbsolutePath) EnvironmentInfo.WorkingDirectory;

            return TryGetRootDirectoryFrom(EnvironmentInfo.WorkingDirectory)
                .NotNull(new[]
                         {
                             $"Could not locate '{ConfigurationFileName}' file while walking up from '{EnvironmentInfo.WorkingDirectory}'.",
                             "Either create the file to mark the root directory, or use the --root parameter."
                         }.JoinNewLine());
        }

        [CanBeNull]
        private static PathConstruction.AbsolutePath GetBuildAssemblyDirectory()
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly == null || entryAssembly.GetTypes().All(x => !x.IsSubclassOf(typeof(NukeBuild))))
                return null;

            return (PathConstruction.AbsolutePath) Path.GetDirectoryName(entryAssembly.Location).NotNull();
        }

        [CanBeNull]
        private static PathConstruction.AbsolutePath GetBuildProjectDirectory(PathConstruction.AbsolutePath buildAssemblyDirectory)
        {
            if (buildAssemblyDirectory == null)
                return null;

            return (PathConstruction.AbsolutePath) new DirectoryInfo(buildAssemblyDirectory)
                .DescendantsAndSelf(x => x.Parent)
                .Select(x => x.GetFiles("*.csproj", SearchOption.TopDirectoryOnly)
                    .SingleOrDefaultOrError($"Found multiple project files in '{x}'."))
                .FirstOrDefault(x => x != null)
                ?.DirectoryName;
        }

        private static HostType GetHostType()
        {
            if (AppVeyor.IsRunningAppVeyor)
                return HostType.AppVeyor;
            if (Jenkins.IsRunningJenkins)
                return HostType.Jenkins;
            if (TeamCity.IsRunningTeamCity)
                return HostType.TeamCity;
            if (AzureDevOps.IsRunningAzureDevOps)
                return HostType.AzureDevOps;
            if (Bitrise.IsRunningBitrise)
                return HostType.Bitrise;
            if (GitLab.IsRunningGitLab)
                return HostType.GitLab;
            if (Travis.IsRunningTravis)
                return HostType.Travis;

            return HostType.Console;
        }
    }
}
