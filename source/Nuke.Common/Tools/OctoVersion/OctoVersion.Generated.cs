// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/OctoVersion/OctoVersion.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.OctoVersion
{
    /// <summary>
    ///   <p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(OctoVersionPackageId)]
    public partial class OctoVersionTasks
        : IRequireNuGetPackage
    {
        public const string OctoVersionPackageId = "OctoVersion.Tool";
        /// <summary>
        ///   Path to the OctoVersion executable.
        /// </summary>
        public static string OctoVersionPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("OCTOVERSION_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("OctoVersion.Tool", "OctoVersion.Tool.dll");
        public static Action<OutputType, string> OctoVersionLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> OctoVersion(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(OctoVersionPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? OctoVersionLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Gets the version information for a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--BuildMetadata</c> via <see cref="OctoVersionGetVersionSettings.BuildMetadata"/></li>
        ///     <li><c>--CurrentBranch</c> via <see cref="OctoVersionGetVersionSettings.CurrentBranch"/></li>
        ///     <li><c>--DetectEnvironment</c> via <see cref="OctoVersionGetVersionSettings.DetectEnvironment"/></li>
        ///     <li><c>--FullSemVer</c> via <see cref="OctoVersionGetVersionSettings.FullSemVer"/></li>
        ///     <li><c>--Major</c> via <see cref="OctoVersionGetVersionSettings.Major"/></li>
        ///     <li><c>--Minor</c> via <see cref="OctoVersionGetVersionSettings.Minor"/></li>
        ///     <li><c>--NonPreReleaseTags</c> via <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/></li>
        ///     <li><c>--OutputFormats</c> via <see cref="OctoVersionGetVersionSettings.OutputFormats"/></li>
        ///     <li><c>--OutputJsonFile</c> via <see cref="OctoVersionGetVersionSettings.OutputJsonFile"/></li>
        ///     <li><c>--Patch</c> via <see cref="OctoVersionGetVersionSettings.Patch"/></li>
        ///     <li><c>--PreReleaseTag</c> via <see cref="OctoVersionGetVersionSettings.PreReleaseTag"/></li>
        ///     <li><c>--RepositoryPath</c> via <see cref="OctoVersionGetVersionSettings.RepositoryPath"/></li>
        ///   </ul>
        /// </remarks>
        public static (OctoVersionInfo Result, IReadOnlyCollection<Output> Output) OctoVersionGetVersion(OctoVersionGetVersionSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new OctoVersionGetVersionSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return (GetResult(process, toolSettings), process.Output);
        }
        /// <summary>
        ///   <p>Gets the version information for a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--BuildMetadata</c> via <see cref="OctoVersionGetVersionSettings.BuildMetadata"/></li>
        ///     <li><c>--CurrentBranch</c> via <see cref="OctoVersionGetVersionSettings.CurrentBranch"/></li>
        ///     <li><c>--DetectEnvironment</c> via <see cref="OctoVersionGetVersionSettings.DetectEnvironment"/></li>
        ///     <li><c>--FullSemVer</c> via <see cref="OctoVersionGetVersionSettings.FullSemVer"/></li>
        ///     <li><c>--Major</c> via <see cref="OctoVersionGetVersionSettings.Major"/></li>
        ///     <li><c>--Minor</c> via <see cref="OctoVersionGetVersionSettings.Minor"/></li>
        ///     <li><c>--NonPreReleaseTags</c> via <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/></li>
        ///     <li><c>--OutputFormats</c> via <see cref="OctoVersionGetVersionSettings.OutputFormats"/></li>
        ///     <li><c>--OutputJsonFile</c> via <see cref="OctoVersionGetVersionSettings.OutputJsonFile"/></li>
        ///     <li><c>--Patch</c> via <see cref="OctoVersionGetVersionSettings.Patch"/></li>
        ///     <li><c>--PreReleaseTag</c> via <see cref="OctoVersionGetVersionSettings.PreReleaseTag"/></li>
        ///     <li><c>--RepositoryPath</c> via <see cref="OctoVersionGetVersionSettings.RepositoryPath"/></li>
        ///   </ul>
        /// </remarks>
        public static (OctoVersionInfo Result, IReadOnlyCollection<Output> Output) OctoVersionGetVersion(Configure<OctoVersionGetVersionSettings> configurator)
        {
            return OctoVersionGetVersion(configurator(new OctoVersionGetVersionSettings()));
        }
        /// <summary>
        ///   <p>Gets the version information for a project.</p>
        ///   <p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--BuildMetadata</c> via <see cref="OctoVersionGetVersionSettings.BuildMetadata"/></li>
        ///     <li><c>--CurrentBranch</c> via <see cref="OctoVersionGetVersionSettings.CurrentBranch"/></li>
        ///     <li><c>--DetectEnvironment</c> via <see cref="OctoVersionGetVersionSettings.DetectEnvironment"/></li>
        ///     <li><c>--FullSemVer</c> via <see cref="OctoVersionGetVersionSettings.FullSemVer"/></li>
        ///     <li><c>--Major</c> via <see cref="OctoVersionGetVersionSettings.Major"/></li>
        ///     <li><c>--Minor</c> via <see cref="OctoVersionGetVersionSettings.Minor"/></li>
        ///     <li><c>--NonPreReleaseTags</c> via <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/></li>
        ///     <li><c>--OutputFormats</c> via <see cref="OctoVersionGetVersionSettings.OutputFormats"/></li>
        ///     <li><c>--OutputJsonFile</c> via <see cref="OctoVersionGetVersionSettings.OutputJsonFile"/></li>
        ///     <li><c>--Patch</c> via <see cref="OctoVersionGetVersionSettings.Patch"/></li>
        ///     <li><c>--PreReleaseTag</c> via <see cref="OctoVersionGetVersionSettings.PreReleaseTag"/></li>
        ///     <li><c>--RepositoryPath</c> via <see cref="OctoVersionGetVersionSettings.RepositoryPath"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(OctoVersionGetVersionSettings Settings, OctoVersionInfo Result, IReadOnlyCollection<Output> Output)> OctoVersionGetVersion(CombinatorialConfigure<OctoVersionGetVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(OctoVersionGetVersion, OctoVersionLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Executes OctoVersion information for a project, without trying to parse the output.</p>
        ///   <p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--BuildMetadata</c> via <see cref="OctoVersionExecuteSettings.BuildMetadata"/></li>
        ///     <li><c>--CurrentBranch</c> via <see cref="OctoVersionExecuteSettings.CurrentBranch"/></li>
        ///     <li><c>--DetectEnvironment</c> via <see cref="OctoVersionExecuteSettings.DetectEnvironment"/></li>
        ///     <li><c>--FullSemVer</c> via <see cref="OctoVersionExecuteSettings.FullSemVer"/></li>
        ///     <li><c>--Major</c> via <see cref="OctoVersionExecuteSettings.Major"/></li>
        ///     <li><c>--Minor</c> via <see cref="OctoVersionExecuteSettings.Minor"/></li>
        ///     <li><c>--NonPreReleaseTags</c> via <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/></li>
        ///     <li><c>--OutputFormats</c> via <see cref="OctoVersionExecuteSettings.OutputFormats"/></li>
        ///     <li><c>--OutputJsonFile</c> via <see cref="OctoVersionExecuteSettings.OutputJsonFile"/></li>
        ///     <li><c>--Patch</c> via <see cref="OctoVersionExecuteSettings.Patch"/></li>
        ///     <li><c>--PreReleaseTag</c> via <see cref="OctoVersionExecuteSettings.PreReleaseTag"/></li>
        ///     <li><c>--RepositoryPath</c> via <see cref="OctoVersionExecuteSettings.RepositoryPath"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OctoVersionExecute(OctoVersionExecuteSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new OctoVersionExecuteSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Executes OctoVersion information for a project, without trying to parse the output.</p>
        ///   <p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--BuildMetadata</c> via <see cref="OctoVersionExecuteSettings.BuildMetadata"/></li>
        ///     <li><c>--CurrentBranch</c> via <see cref="OctoVersionExecuteSettings.CurrentBranch"/></li>
        ///     <li><c>--DetectEnvironment</c> via <see cref="OctoVersionExecuteSettings.DetectEnvironment"/></li>
        ///     <li><c>--FullSemVer</c> via <see cref="OctoVersionExecuteSettings.FullSemVer"/></li>
        ///     <li><c>--Major</c> via <see cref="OctoVersionExecuteSettings.Major"/></li>
        ///     <li><c>--Minor</c> via <see cref="OctoVersionExecuteSettings.Minor"/></li>
        ///     <li><c>--NonPreReleaseTags</c> via <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/></li>
        ///     <li><c>--OutputFormats</c> via <see cref="OctoVersionExecuteSettings.OutputFormats"/></li>
        ///     <li><c>--OutputJsonFile</c> via <see cref="OctoVersionExecuteSettings.OutputJsonFile"/></li>
        ///     <li><c>--Patch</c> via <see cref="OctoVersionExecuteSettings.Patch"/></li>
        ///     <li><c>--PreReleaseTag</c> via <see cref="OctoVersionExecuteSettings.PreReleaseTag"/></li>
        ///     <li><c>--RepositoryPath</c> via <see cref="OctoVersionExecuteSettings.RepositoryPath"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> OctoVersionExecute(Configure<OctoVersionExecuteSettings> configurator)
        {
            return OctoVersionExecute(configurator(new OctoVersionExecuteSettings()));
        }
        /// <summary>
        ///   <p>Executes OctoVersion information for a project, without trying to parse the output.</p>
        ///   <p>For more details, visit the <a href="https://github.com/OctopusDeploy/OctoVersion">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--BuildMetadata</c> via <see cref="OctoVersionExecuteSettings.BuildMetadata"/></li>
        ///     <li><c>--CurrentBranch</c> via <see cref="OctoVersionExecuteSettings.CurrentBranch"/></li>
        ///     <li><c>--DetectEnvironment</c> via <see cref="OctoVersionExecuteSettings.DetectEnvironment"/></li>
        ///     <li><c>--FullSemVer</c> via <see cref="OctoVersionExecuteSettings.FullSemVer"/></li>
        ///     <li><c>--Major</c> via <see cref="OctoVersionExecuteSettings.Major"/></li>
        ///     <li><c>--Minor</c> via <see cref="OctoVersionExecuteSettings.Minor"/></li>
        ///     <li><c>--NonPreReleaseTags</c> via <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/></li>
        ///     <li><c>--OutputFormats</c> via <see cref="OctoVersionExecuteSettings.OutputFormats"/></li>
        ///     <li><c>--OutputJsonFile</c> via <see cref="OctoVersionExecuteSettings.OutputJsonFile"/></li>
        ///     <li><c>--Patch</c> via <see cref="OctoVersionExecuteSettings.Patch"/></li>
        ///     <li><c>--PreReleaseTag</c> via <see cref="OctoVersionExecuteSettings.PreReleaseTag"/></li>
        ///     <li><c>--RepositoryPath</c> via <see cref="OctoVersionExecuteSettings.RepositoryPath"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(OctoVersionExecuteSettings Settings, IReadOnlyCollection<Output> Output)> OctoVersionExecute(CombinatorialConfigure<OctoVersionExecuteSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(OctoVersionExecute, OctoVersionLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region OctoVersionGetVersionSettings
    /// <summary>
    ///   Used within <see cref="OctoVersionTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OctoVersionGetVersionSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the OctoVersion executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? OctoVersionTasks.OctoVersionLogger;
        /// <summary>
        ///   Pass in the name of the branch. If not set, OctoVersion will attempt to derive it, but this may lead to incorrect values.
        /// </summary>
        public virtual string CurrentBranch { get; internal set; }
        /// <summary>
        ///   Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').
        /// </summary>
        public virtual IReadOnlyList<string> NonPreReleaseTags => NonPreReleaseTagsInternal.AsReadOnly();
        internal List<string> NonPreReleaseTagsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Path to the Git repository. If not set, assumes that the current working folder is the root of the repository
        /// </summary>
        public virtual string RepositoryPath { get; internal set; }
        /// <summary>
        ///   Override the calculated Major with a specific value.
        /// </summary>
        public virtual int? Major { get; internal set; }
        /// <summary>
        ///   Override the calculated Minor with a specific value.
        /// </summary>
        public virtual int? Minor { get; internal set; }
        /// <summary>
        ///   Override the calculated Patch with a specific value.
        /// </summary>
        public virtual int? Patch { get; internal set; }
        /// <summary>
        ///   Override the calculated PreReleaseTag with a specific value.
        /// </summary>
        public virtual string PreReleaseTag { get; internal set; }
        /// <summary>
        ///   Override the calculated build metadata with a specific value.
        /// </summary>
        public virtual string BuildMetadata { get; internal set; }
        /// <summary>
        ///   If set, this version number will override all of the other values and OctoVersion will just adopt it wholesale.
        /// </summary>
        public virtual string FullSemVer { get; internal set; }
        /// <summary>
        ///   How to format the output. Defaults to Console.
        /// </summary>
        public virtual IReadOnlyList<OctoVersionOutputFormatter> OutputFormats => OutputFormatsInternal.AsReadOnly();
        internal List<OctoVersionOutputFormatter> OutputFormatsInternal { get; set; } = new List<OctoVersionOutputFormatter>();
        /// <summary>
        ///   Detect the output format from the runtime environment (usually the CI environment).
        /// </summary>
        public virtual bool? DetectEnvironment { get; internal set; }
        /// <summary>
        ///   Emit json to the specified file. Ensure that either the `JsonFile` output formatter is added, or that `DetectEnvironment` is `true`.
        /// </summary>
        public virtual string OutputJsonFile { get; internal set; }
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("octoversion")
              .Add("--CurrentBranch {value}", CurrentBranch)
              .Add("--NonPreReleaseTags {value}", NonPreReleaseTags, separator: ' ')
              .Add("--RepositoryPath {value}", RepositoryPath)
              .Add("--Major {value}", Major)
              .Add("--Minor {value}", Minor)
              .Add("--Patch {value}", Patch)
              .Add("--PreReleaseTag {value}", PreReleaseTag)
              .Add("--BuildMetadata {value}", BuildMetadata)
              .Add("--FullSemVer {value}", FullSemVer)
              .Add("--OutputFormats {value}", OutputFormats)
              .Add("--DetectEnvironment {value}", DetectEnvironment)
              .Add("--OutputJsonFile {value}", OutputJsonFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region OctoVersionExecuteSettings
    /// <summary>
    ///   Used within <see cref="OctoVersionTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OctoVersionExecuteSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the OctoVersion executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? OctoVersionTasks.OctoVersionLogger;
        /// <summary>
        ///   Pass in the name of the branch. If not set, OctoVersion will attempt to derive it, but this may lead to incorrect values.
        /// </summary>
        public virtual string CurrentBranch { get; internal set; }
        /// <summary>
        ///   Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').
        /// </summary>
        public virtual IReadOnlyList<string> NonPreReleaseTags => NonPreReleaseTagsInternal.AsReadOnly();
        internal List<string> NonPreReleaseTagsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Path to the Git repository. If not set, assumes that the current working folder is the root of the repository
        /// </summary>
        public virtual string RepositoryPath { get; internal set; }
        /// <summary>
        ///   Override the calculated Major with a specific value.
        /// </summary>
        public virtual int? Major { get; internal set; }
        /// <summary>
        ///   Override the calculated Minor with a specific value.
        /// </summary>
        public virtual int? Minor { get; internal set; }
        /// <summary>
        ///   Override the calculated Patch with a specific value.
        /// </summary>
        public virtual int? Patch { get; internal set; }
        /// <summary>
        ///   Override the calculated PreReleaseTag with a specific value.
        /// </summary>
        public virtual string PreReleaseTag { get; internal set; }
        /// <summary>
        ///   Override the calculated build metadata with a specific value.
        /// </summary>
        public virtual string BuildMetadata { get; internal set; }
        /// <summary>
        ///   If set, this version number will override all of the other values and OctoVersion will just adopt it wholesale.
        /// </summary>
        public virtual string FullSemVer { get; internal set; }
        /// <summary>
        ///   How to format the output. Defaults to Console.
        /// </summary>
        public virtual IReadOnlyList<OctoVersionOutputFormatter> OutputFormats => OutputFormatsInternal.AsReadOnly();
        internal List<OctoVersionOutputFormatter> OutputFormatsInternal { get; set; } = new List<OctoVersionOutputFormatter>();
        /// <summary>
        ///   Detect the output format from the runtime environment (usually the CI environment).
        /// </summary>
        public virtual bool? DetectEnvironment { get; internal set; }
        /// <summary>
        ///   Emit json to the specified file. Ensure that either the `JsonFile` output formatter is added, or that `DetectEnvironment` is `true`.
        /// </summary>
        public virtual string OutputJsonFile { get; internal set; }
        public virtual string Framework { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("octoversion")
              .Add("--CurrentBranch {value}", CurrentBranch)
              .Add("--NonPreReleaseTags {value}", NonPreReleaseTags, separator: ' ')
              .Add("--RepositoryPath {value}", RepositoryPath)
              .Add("--Major {value}", Major)
              .Add("--Minor {value}", Minor)
              .Add("--Patch {value}", Patch)
              .Add("--PreReleaseTag {value}", PreReleaseTag)
              .Add("--BuildMetadata {value}", BuildMetadata)
              .Add("--FullSemVer {value}", FullSemVer)
              .Add("--OutputFormats {value}", OutputFormats)
              .Add("--DetectEnvironment {value}", DetectEnvironment)
              .Add("--OutputJsonFile {value}", OutputJsonFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region OctoVersionInfo
    /// <summary>
    ///   Used within <see cref="OctoVersionTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class OctoVersionInfo : ISettingsEntity
    {
        public virtual int? Major { get; internal set; }
        public virtual int? Minor { get; internal set; }
        public virtual int? Patch { get; internal set; }
        public virtual string PreReleaseTag { get; internal set; }
        public virtual string PreReleaseTagWithDash { get; internal set; }
        public virtual string BuildMetaData { get; internal set; }
        public virtual string BuildMetadataWithPlus { get; internal set; }
        public virtual string MajorMinorPatch { get; internal set; }
        public virtual string NuGetCompatiblePreReleaseWithDash { get; internal set; }
        public virtual string FullSemVer { get; internal set; }
        public virtual string InformationalVersion { get; internal set; }
        public virtual string NuGetVersion { get; internal set; }
    }
    #endregion
    #region OctoVersionGetVersionSettingsExtensions
    /// <summary>
    ///   Used within <see cref="OctoVersionTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OctoVersionGetVersionSettingsExtensions
    {
        #region CurrentBranch
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.CurrentBranch"/></em></p>
        ///   <p>Pass in the name of the branch. If not set, OctoVersion will attempt to derive it, but this may lead to incorrect values.</p>
        /// </summary>
        [Pure]
        public static T SetCurrentBranch<T>(this T toolSettings, string currentBranch) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CurrentBranch = currentBranch;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionGetVersionSettings.CurrentBranch"/></em></p>
        ///   <p>Pass in the name of the branch. If not set, OctoVersion will attempt to derive it, but this may lead to incorrect values.</p>
        /// </summary>
        [Pure]
        public static T ResetCurrentBranch<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CurrentBranch = null;
            return toolSettings;
        }
        #endregion
        #region NonPreReleaseTags
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/> to a new list</em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T SetNonPreReleaseTags<T>(this T toolSettings, params string[] nonPreReleaseTags) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonPreReleaseTagsInternal = nonPreReleaseTags.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/> to a new list</em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T SetNonPreReleaseTags<T>(this T toolSettings, IEnumerable<string> nonPreReleaseTags) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonPreReleaseTagsInternal = nonPreReleaseTags.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/></em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T AddNonPreReleaseTags<T>(this T toolSettings, params string[] nonPreReleaseTags) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonPreReleaseTagsInternal.AddRange(nonPreReleaseTags);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/></em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T AddNonPreReleaseTags<T>(this T toolSettings, IEnumerable<string> nonPreReleaseTags) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonPreReleaseTagsInternal.AddRange(nonPreReleaseTags);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/></em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T ClearNonPreReleaseTags<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonPreReleaseTagsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/></em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T RemoveNonPreReleaseTags<T>(this T toolSettings, params string[] nonPreReleaseTags) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(nonPreReleaseTags);
            toolSettings.NonPreReleaseTagsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctoVersionGetVersionSettings.NonPreReleaseTags"/></em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T RemoveNonPreReleaseTags<T>(this T toolSettings, IEnumerable<string> nonPreReleaseTags) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(nonPreReleaseTags);
            toolSettings.NonPreReleaseTagsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region RepositoryPath
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.RepositoryPath"/></em></p>
        ///   <p>Path to the Git repository. If not set, assumes that the current working folder is the root of the repository</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryPath<T>(this T toolSettings, string repositoryPath) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryPath = repositoryPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionGetVersionSettings.RepositoryPath"/></em></p>
        ///   <p>Path to the Git repository. If not set, assumes that the current working folder is the root of the repository</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryPath<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryPath = null;
            return toolSettings;
        }
        #endregion
        #region Major
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.Major"/></em></p>
        ///   <p>Override the calculated Major with a specific value.</p>
        /// </summary>
        [Pure]
        public static T SetMajor<T>(this T toolSettings, int? major) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Major = major;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionGetVersionSettings.Major"/></em></p>
        ///   <p>Override the calculated Major with a specific value.</p>
        /// </summary>
        [Pure]
        public static T ResetMajor<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Major = null;
            return toolSettings;
        }
        #endregion
        #region Minor
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.Minor"/></em></p>
        ///   <p>Override the calculated Minor with a specific value.</p>
        /// </summary>
        [Pure]
        public static T SetMinor<T>(this T toolSettings, int? minor) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Minor = minor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionGetVersionSettings.Minor"/></em></p>
        ///   <p>Override the calculated Minor with a specific value.</p>
        /// </summary>
        [Pure]
        public static T ResetMinor<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Minor = null;
            return toolSettings;
        }
        #endregion
        #region Patch
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.Patch"/></em></p>
        ///   <p>Override the calculated Patch with a specific value.</p>
        /// </summary>
        [Pure]
        public static T SetPatch<T>(this T toolSettings, int? patch) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Patch = patch;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionGetVersionSettings.Patch"/></em></p>
        ///   <p>Override the calculated Patch with a specific value.</p>
        /// </summary>
        [Pure]
        public static T ResetPatch<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Patch = null;
            return toolSettings;
        }
        #endregion
        #region PreReleaseTag
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.PreReleaseTag"/></em></p>
        ///   <p>Override the calculated PreReleaseTag with a specific value.</p>
        /// </summary>
        [Pure]
        public static T SetPreReleaseTag<T>(this T toolSettings, string preReleaseTag) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreReleaseTag = preReleaseTag;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionGetVersionSettings.PreReleaseTag"/></em></p>
        ///   <p>Override the calculated PreReleaseTag with a specific value.</p>
        /// </summary>
        [Pure]
        public static T ResetPreReleaseTag<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreReleaseTag = null;
            return toolSettings;
        }
        #endregion
        #region BuildMetadata
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.BuildMetadata"/></em></p>
        ///   <p>Override the calculated build metadata with a specific value.</p>
        /// </summary>
        [Pure]
        public static T SetBuildMetadata<T>(this T toolSettings, string buildMetadata) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildMetadata = buildMetadata;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionGetVersionSettings.BuildMetadata"/></em></p>
        ///   <p>Override the calculated build metadata with a specific value.</p>
        /// </summary>
        [Pure]
        public static T ResetBuildMetadata<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildMetadata = null;
            return toolSettings;
        }
        #endregion
        #region FullSemVer
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.FullSemVer"/></em></p>
        ///   <p>If set, this version number will override all of the other values and OctoVersion will just adopt it wholesale.</p>
        /// </summary>
        [Pure]
        public static T SetFullSemVer<T>(this T toolSettings, string fullSemVer) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FullSemVer = fullSemVer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionGetVersionSettings.FullSemVer"/></em></p>
        ///   <p>If set, this version number will override all of the other values and OctoVersion will just adopt it wholesale.</p>
        /// </summary>
        [Pure]
        public static T ResetFullSemVer<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FullSemVer = null;
            return toolSettings;
        }
        #endregion
        #region OutputFormats
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.OutputFormats"/> to a new list</em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFormats<T>(this T toolSettings, params OctoVersionOutputFormatter[] outputFormats) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormatsInternal = outputFormats.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.OutputFormats"/> to a new list</em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFormats<T>(this T toolSettings, IEnumerable<OctoVersionOutputFormatter> outputFormats) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormatsInternal = outputFormats.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctoVersionGetVersionSettings.OutputFormats"/></em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T AddOutputFormats<T>(this T toolSettings, params OctoVersionOutputFormatter[] outputFormats) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormatsInternal.AddRange(outputFormats);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctoVersionGetVersionSettings.OutputFormats"/></em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T AddOutputFormats<T>(this T toolSettings, IEnumerable<OctoVersionOutputFormatter> outputFormats) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormatsInternal.AddRange(outputFormats);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctoVersionGetVersionSettings.OutputFormats"/></em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T ClearOutputFormats<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormatsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctoVersionGetVersionSettings.OutputFormats"/></em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T RemoveOutputFormats<T>(this T toolSettings, params OctoVersionOutputFormatter[] outputFormats) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<OctoVersionOutputFormatter>(outputFormats);
            toolSettings.OutputFormatsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctoVersionGetVersionSettings.OutputFormats"/></em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T RemoveOutputFormats<T>(this T toolSettings, IEnumerable<OctoVersionOutputFormatter> outputFormats) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<OctoVersionOutputFormatter>(outputFormats);
            toolSettings.OutputFormatsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DetectEnvironment
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.DetectEnvironment"/></em></p>
        ///   <p>Detect the output format from the runtime environment (usually the CI environment).</p>
        /// </summary>
        [Pure]
        public static T SetDetectEnvironment<T>(this T toolSettings, bool? detectEnvironment) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetectEnvironment = detectEnvironment;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionGetVersionSettings.DetectEnvironment"/></em></p>
        ///   <p>Detect the output format from the runtime environment (usually the CI environment).</p>
        /// </summary>
        [Pure]
        public static T ResetDetectEnvironment<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetectEnvironment = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctoVersionGetVersionSettings.DetectEnvironment"/></em></p>
        ///   <p>Detect the output format from the runtime environment (usually the CI environment).</p>
        /// </summary>
        [Pure]
        public static T EnableDetectEnvironment<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetectEnvironment = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctoVersionGetVersionSettings.DetectEnvironment"/></em></p>
        ///   <p>Detect the output format from the runtime environment (usually the CI environment).</p>
        /// </summary>
        [Pure]
        public static T DisableDetectEnvironment<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetectEnvironment = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctoVersionGetVersionSettings.DetectEnvironment"/></em></p>
        ///   <p>Detect the output format from the runtime environment (usually the CI environment).</p>
        /// </summary>
        [Pure]
        public static T ToggleDetectEnvironment<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetectEnvironment = !toolSettings.DetectEnvironment;
            return toolSettings;
        }
        #endregion
        #region OutputJsonFile
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.OutputJsonFile"/></em></p>
        ///   <p>Emit json to the specified file. Ensure that either the `JsonFile` output formatter is added, or that `DetectEnvironment` is `true`.</p>
        /// </summary>
        [Pure]
        public static T SetOutputJsonFile<T>(this T toolSettings, string outputJsonFile) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputJsonFile = outputJsonFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionGetVersionSettings.OutputJsonFile"/></em></p>
        ///   <p>Emit json to the specified file. Ensure that either the `JsonFile` output formatter is added, or that `DetectEnvironment` is `true`.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputJsonFile<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputJsonFile = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionGetVersionSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionGetVersionSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : OctoVersionGetVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OctoVersionExecuteSettingsExtensions
    /// <summary>
    ///   Used within <see cref="OctoVersionTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class OctoVersionExecuteSettingsExtensions
    {
        #region CurrentBranch
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.CurrentBranch"/></em></p>
        ///   <p>Pass in the name of the branch. If not set, OctoVersion will attempt to derive it, but this may lead to incorrect values.</p>
        /// </summary>
        [Pure]
        public static T SetCurrentBranch<T>(this T toolSettings, string currentBranch) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CurrentBranch = currentBranch;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionExecuteSettings.CurrentBranch"/></em></p>
        ///   <p>Pass in the name of the branch. If not set, OctoVersion will attempt to derive it, but this may lead to incorrect values.</p>
        /// </summary>
        [Pure]
        public static T ResetCurrentBranch<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CurrentBranch = null;
            return toolSettings;
        }
        #endregion
        #region NonPreReleaseTags
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/> to a new list</em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T SetNonPreReleaseTags<T>(this T toolSettings, params string[] nonPreReleaseTags) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonPreReleaseTagsInternal = nonPreReleaseTags.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/> to a new list</em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T SetNonPreReleaseTags<T>(this T toolSettings, IEnumerable<string> nonPreReleaseTags) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonPreReleaseTagsInternal = nonPreReleaseTags.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/></em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T AddNonPreReleaseTags<T>(this T toolSettings, params string[] nonPreReleaseTags) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonPreReleaseTagsInternal.AddRange(nonPreReleaseTags);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/></em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T AddNonPreReleaseTags<T>(this T toolSettings, IEnumerable<string> nonPreReleaseTags) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonPreReleaseTagsInternal.AddRange(nonPreReleaseTags);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/></em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T ClearNonPreReleaseTags<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NonPreReleaseTagsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/></em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T RemoveNonPreReleaseTags<T>(this T toolSettings, params string[] nonPreReleaseTags) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(nonPreReleaseTags);
            toolSettings.NonPreReleaseTagsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctoVersionExecuteSettings.NonPreReleaseTags"/></em></p>
        ///   <p>Names of branches that will not get a pre-release suffix. Defaults to 'main' (with legacy support for 'master').</p>
        /// </summary>
        [Pure]
        public static T RemoveNonPreReleaseTags<T>(this T toolSettings, IEnumerable<string> nonPreReleaseTags) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(nonPreReleaseTags);
            toolSettings.NonPreReleaseTagsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region RepositoryPath
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.RepositoryPath"/></em></p>
        ///   <p>Path to the Git repository. If not set, assumes that the current working folder is the root of the repository</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryPath<T>(this T toolSettings, string repositoryPath) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryPath = repositoryPath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionExecuteSettings.RepositoryPath"/></em></p>
        ///   <p>Path to the Git repository. If not set, assumes that the current working folder is the root of the repository</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryPath<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryPath = null;
            return toolSettings;
        }
        #endregion
        #region Major
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.Major"/></em></p>
        ///   <p>Override the calculated Major with a specific value.</p>
        /// </summary>
        [Pure]
        public static T SetMajor<T>(this T toolSettings, int? major) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Major = major;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionExecuteSettings.Major"/></em></p>
        ///   <p>Override the calculated Major with a specific value.</p>
        /// </summary>
        [Pure]
        public static T ResetMajor<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Major = null;
            return toolSettings;
        }
        #endregion
        #region Minor
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.Minor"/></em></p>
        ///   <p>Override the calculated Minor with a specific value.</p>
        /// </summary>
        [Pure]
        public static T SetMinor<T>(this T toolSettings, int? minor) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Minor = minor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionExecuteSettings.Minor"/></em></p>
        ///   <p>Override the calculated Minor with a specific value.</p>
        /// </summary>
        [Pure]
        public static T ResetMinor<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Minor = null;
            return toolSettings;
        }
        #endregion
        #region Patch
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.Patch"/></em></p>
        ///   <p>Override the calculated Patch with a specific value.</p>
        /// </summary>
        [Pure]
        public static T SetPatch<T>(this T toolSettings, int? patch) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Patch = patch;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionExecuteSettings.Patch"/></em></p>
        ///   <p>Override the calculated Patch with a specific value.</p>
        /// </summary>
        [Pure]
        public static T ResetPatch<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Patch = null;
            return toolSettings;
        }
        #endregion
        #region PreReleaseTag
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.PreReleaseTag"/></em></p>
        ///   <p>Override the calculated PreReleaseTag with a specific value.</p>
        /// </summary>
        [Pure]
        public static T SetPreReleaseTag<T>(this T toolSettings, string preReleaseTag) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreReleaseTag = preReleaseTag;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionExecuteSettings.PreReleaseTag"/></em></p>
        ///   <p>Override the calculated PreReleaseTag with a specific value.</p>
        /// </summary>
        [Pure]
        public static T ResetPreReleaseTag<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PreReleaseTag = null;
            return toolSettings;
        }
        #endregion
        #region BuildMetadata
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.BuildMetadata"/></em></p>
        ///   <p>Override the calculated build metadata with a specific value.</p>
        /// </summary>
        [Pure]
        public static T SetBuildMetadata<T>(this T toolSettings, string buildMetadata) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildMetadata = buildMetadata;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionExecuteSettings.BuildMetadata"/></em></p>
        ///   <p>Override the calculated build metadata with a specific value.</p>
        /// </summary>
        [Pure]
        public static T ResetBuildMetadata<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildMetadata = null;
            return toolSettings;
        }
        #endregion
        #region FullSemVer
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.FullSemVer"/></em></p>
        ///   <p>If set, this version number will override all of the other values and OctoVersion will just adopt it wholesale.</p>
        /// </summary>
        [Pure]
        public static T SetFullSemVer<T>(this T toolSettings, string fullSemVer) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FullSemVer = fullSemVer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionExecuteSettings.FullSemVer"/></em></p>
        ///   <p>If set, this version number will override all of the other values and OctoVersion will just adopt it wholesale.</p>
        /// </summary>
        [Pure]
        public static T ResetFullSemVer<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FullSemVer = null;
            return toolSettings;
        }
        #endregion
        #region OutputFormats
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.OutputFormats"/> to a new list</em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFormats<T>(this T toolSettings, params OctoVersionOutputFormatter[] outputFormats) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormatsInternal = outputFormats.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.OutputFormats"/> to a new list</em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFormats<T>(this T toolSettings, IEnumerable<OctoVersionOutputFormatter> outputFormats) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormatsInternal = outputFormats.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctoVersionExecuteSettings.OutputFormats"/></em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T AddOutputFormats<T>(this T toolSettings, params OctoVersionOutputFormatter[] outputFormats) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormatsInternal.AddRange(outputFormats);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="OctoVersionExecuteSettings.OutputFormats"/></em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T AddOutputFormats<T>(this T toolSettings, IEnumerable<OctoVersionOutputFormatter> outputFormats) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormatsInternal.AddRange(outputFormats);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="OctoVersionExecuteSettings.OutputFormats"/></em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T ClearOutputFormats<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFormatsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctoVersionExecuteSettings.OutputFormats"/></em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T RemoveOutputFormats<T>(this T toolSettings, params OctoVersionOutputFormatter[] outputFormats) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<OctoVersionOutputFormatter>(outputFormats);
            toolSettings.OutputFormatsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="OctoVersionExecuteSettings.OutputFormats"/></em></p>
        ///   <p>How to format the output. Defaults to Console.</p>
        /// </summary>
        [Pure]
        public static T RemoveOutputFormats<T>(this T toolSettings, IEnumerable<OctoVersionOutputFormatter> outputFormats) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<OctoVersionOutputFormatter>(outputFormats);
            toolSettings.OutputFormatsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DetectEnvironment
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.DetectEnvironment"/></em></p>
        ///   <p>Detect the output format from the runtime environment (usually the CI environment).</p>
        /// </summary>
        [Pure]
        public static T SetDetectEnvironment<T>(this T toolSettings, bool? detectEnvironment) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetectEnvironment = detectEnvironment;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionExecuteSettings.DetectEnvironment"/></em></p>
        ///   <p>Detect the output format from the runtime environment (usually the CI environment).</p>
        /// </summary>
        [Pure]
        public static T ResetDetectEnvironment<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetectEnvironment = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="OctoVersionExecuteSettings.DetectEnvironment"/></em></p>
        ///   <p>Detect the output format from the runtime environment (usually the CI environment).</p>
        /// </summary>
        [Pure]
        public static T EnableDetectEnvironment<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetectEnvironment = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="OctoVersionExecuteSettings.DetectEnvironment"/></em></p>
        ///   <p>Detect the output format from the runtime environment (usually the CI environment).</p>
        /// </summary>
        [Pure]
        public static T DisableDetectEnvironment<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetectEnvironment = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="OctoVersionExecuteSettings.DetectEnvironment"/></em></p>
        ///   <p>Detect the output format from the runtime environment (usually the CI environment).</p>
        /// </summary>
        [Pure]
        public static T ToggleDetectEnvironment<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetectEnvironment = !toolSettings.DetectEnvironment;
            return toolSettings;
        }
        #endregion
        #region OutputJsonFile
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.OutputJsonFile"/></em></p>
        ///   <p>Emit json to the specified file. Ensure that either the `JsonFile` output formatter is added, or that `DetectEnvironment` is `true`.</p>
        /// </summary>
        [Pure]
        public static T SetOutputJsonFile<T>(this T toolSettings, string outputJsonFile) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputJsonFile = outputJsonFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionExecuteSettings.OutputJsonFile"/></em></p>
        ///   <p>Emit json to the specified file. Ensure that either the `JsonFile` output formatter is added, or that `DetectEnvironment` is `true`.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputJsonFile<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputJsonFile = null;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="OctoVersionExecuteSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="OctoVersionExecuteSettings.Framework"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : OctoVersionExecuteSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region OctoVersionOutputFormatter
    /// <summary>
    ///   Used within <see cref="OctoVersionTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<OctoVersionOutputFormatter>))]
    public partial class OctoVersionOutputFormatter : Enumeration
    {
        public static OctoVersionOutputFormatter Nuke = (OctoVersionOutputFormatter) "Nuke";
        public static OctoVersionOutputFormatter Cake = (OctoVersionOutputFormatter) "Cake";
        public static OctoVersionOutputFormatter Console = (OctoVersionOutputFormatter) "Console";
        public static OctoVersionOutputFormatter QuietConsole = (OctoVersionOutputFormatter) "QuietConsole";
        public static OctoVersionOutputFormatter Environment = (OctoVersionOutputFormatter) "Environment";
        public static OctoVersionOutputFormatter Json = (OctoVersionOutputFormatter) "Json";
        public static OctoVersionOutputFormatter TeamCity = (OctoVersionOutputFormatter) "TeamCity";
        public static implicit operator OctoVersionOutputFormatter(string value)
        {
            return new OctoVersionOutputFormatter { Value = value };
        }
    }
    #endregion
}
