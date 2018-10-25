// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Nuke.Common.BuildServers;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common
{
    public abstract partial class NukeBuild
    {
        static NukeBuild()
        {
            RootDirectory = ParameterService.Instance.GetParameter(() => RootDirectory) ??
                            GetRootDirectoryFromWorkingDirectory();
            TemporaryDirectory = RootDirectory / TemporaryDirectoryName;
            FileSystemTasks.EnsureExistingDirectory(TemporaryDirectory);
            BuildAssemblyDirectory = GetBuildAssemblyDirectory();
            BuildProjectDirectory = GetBuildProjectDirectory(BuildAssemblyDirectory);

            InvokedTargets = ParameterService.Instance.GetParameter(() => InvokedTargets) ??
                             ParameterService.Instance.GetPositionalCommandLineArguments<string>(separator: '+') ??
                             new[] { BuildExecutor.DefaultTarget };
            SkippedTargets = ParameterService.Instance.GetParameter(() => SkippedTargets);

            Verbosity = ParameterService.Instance.GetParameter<Verbosity?>(()  => Verbosity) ?? Verbosity.Normal;
            Host = ParameterService.Instance.GetParameter<HostType?>(()  => Host) ?? GetHostType();
            Graph = ParameterService.Instance.GetParameter(() => Graph);
            Help = ParameterService.Instance.GetParameter(() => Help);
        }

        /// <summary>
        /// Gets the full path to the root directory.
        /// </summary>
        [Parameter("Root directory during build execution.", Name = RootDirectoryParameterName)]
        public static PathConstruction.AbsolutePath RootDirectory { get; }

        /// <summary>
        /// Gets the full path to the temporary directory <c>/.tmp</c>.
        /// </summary>
        public static PathConstruction.AbsolutePath TemporaryDirectory { get; }

        /// <summary>
        /// Gets the full path to the build assembly directory.
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
        /// Gets a value whether to show the target dependency graph (HTML).
        /// </summary>
        [Parameter("Shows the target dependency graph (HTML).")]
        public static bool Graph { get; }

        /// <summary>
        /// Gets a value whether to show the help text for this build assembly.
        /// </summary>
        [Parameter("Shows the help text for this build assembly.")]
        public static bool Help { get; }

        public static bool IsLocalBuild => Host == HostType.Console;
        public static bool IsServerBuild => Host != HostType.Console;

        public static LogLevel LogLevel => (LogLevel) Verbosity;

        /// <summary>
        /// Gets the list of targets that were invoked.
        /// </summary>
        [Parameter("List of targets to be executed. Default is '{default_target}'.", Name = InvokedTargetsParameterName)]
        public static string[] InvokedTargets { get; }
        
        /// <summary>
        /// Gets the list of targets that are skipped.
        /// </summary>
        [Parameter("List of targets to be skipped. Empty list skips all dependencies.", Name = SkippedTargetsParameterName, Separator = "+")]
        public static string[] SkippedTargets { get; }
        
        /// <summary>
        /// Gets the list of targets that are executing.
        /// </summary>
        public static string[] ExecutingTargets { get; }
        
        private static PathConstruction.AbsolutePath GetRootDirectoryFromWorkingDirectory()
        {
            return (PathConstruction.AbsolutePath) FileSystemTasks.FindParentDirectory(
                    EnvironmentInfo.WorkingDirectory,
                    x => x.GetFiles(ConfigurationFileName).Any())
                .NotNull(
                    $"Could not locate '{ConfigurationFileName}' file while walking up from working directory '{EnvironmentInfo.WorkingDirectory}'.");
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
            if (TeamServices.IsRunningTeamServices)
                return HostType.TeamServices;
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
