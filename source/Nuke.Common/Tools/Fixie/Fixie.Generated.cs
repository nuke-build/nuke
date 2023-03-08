// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Fixie/Fixie.json

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

namespace Nuke.Common.Tools.Fixie
{
    /// <summary>
    ///   <p>Fixie is a .NET modern test framework similar to NUnit and xUnit, but with an emphasis on low-ceremony defaults and flexible customization.</p>
    ///   <p>For more details, visit the <a href="https://fixie.github.io/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(FixiePackageId)]
    public partial class FixieTasks
        : IRequireNuGetPackage
    {
        public const string FixiePackageId = "fixie.console";
        /// <summary>
        ///   Path to the Fixie executable.
        /// </summary>
        public static string FixiePath =>
            ToolPathResolver.TryGetEnvironmentExecutable("FIXIE_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("fixie.console", "dotnet-fixie.dll");
        public static Action<OutputType, string> FixieLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Fixie is a .NET modern test framework similar to NUnit and xUnit, but with an emphasis on low-ceremony defaults and flexible customization.</p>
        ///   <p>For more details, visit the <a href="https://fixie.github.io/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Fixie(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(FixiePath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? FixieLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet fixie</c> command is used to execute Fixie unit tests in a given project.</p>
        ///   <p>For more details, visit the <a href="https://fixie.github.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="FixieSettings.CustomArguments"/></li>
        ///     <li><c>--configuration</c> via <see cref="FixieSettings.Configuration"/></li>
        ///     <li><c>--framework</c> via <see cref="FixieSettings.Framework"/></li>
        ///     <li><c>--no-build</c> via <see cref="FixieSettings.NoBuild"/></li>
        ///     <li><c>--report</c> via <see cref="FixieSettings.Report"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Fixie(FixieSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new FixieSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet fixie</c> command is used to execute Fixie unit tests in a given project.</p>
        ///   <p>For more details, visit the <a href="https://fixie.github.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="FixieSettings.CustomArguments"/></li>
        ///     <li><c>--configuration</c> via <see cref="FixieSettings.Configuration"/></li>
        ///     <li><c>--framework</c> via <see cref="FixieSettings.Framework"/></li>
        ///     <li><c>--no-build</c> via <see cref="FixieSettings.NoBuild"/></li>
        ///     <li><c>--report</c> via <see cref="FixieSettings.Report"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> Fixie(Configure<FixieSettings> configurator)
        {
            return Fixie(configurator(new FixieSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet fixie</c> command is used to execute Fixie unit tests in a given project.</p>
        ///   <p>For more details, visit the <a href="https://fixie.github.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--</c> via <see cref="FixieSettings.CustomArguments"/></li>
        ///     <li><c>--configuration</c> via <see cref="FixieSettings.Configuration"/></li>
        ///     <li><c>--framework</c> via <see cref="FixieSettings.Framework"/></li>
        ///     <li><c>--no-build</c> via <see cref="FixieSettings.NoBuild"/></li>
        ///     <li><c>--report</c> via <see cref="FixieSettings.Report"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(FixieSettings Settings, IReadOnlyCollection<Output> Output)> Fixie(CombinatorialConfigure<FixieSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(Fixie, FixieLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region FixieSettings
    /// <summary>
    ///   Used within <see cref="FixieTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class FixieSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Fixie executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? FixieTasks.FixiePath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? FixieTasks.FixieLogger;
        /// <summary>
        ///   The configuration under which to build. When this option is omitted, the default configuration is `Debug`.
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///   Skip building the test project prior to running it.
        /// </summary>
        public virtual bool? NoBuild { get; internal set; }
        /// <summary>
        ///   Only run test assemblies targeting a specific framework.
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///   Write test results to the specified path, using the xUnit XML format.
        /// </summary>
        public virtual string Report { get; internal set; }
        /// <summary>
        ///   Arbitrary arguments made available to custom discovery/execution classes.
        /// </summary>
        public virtual string CustomArguments { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("--configuration {value}", Configuration)
              .Add("--no-build", NoBuild)
              .Add("--framework {value}", Framework)
              .Add("--report {value}", Report)
              .Add("-- {value}", CustomArguments);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region FixieSettingsExtensions
    /// <summary>
    ///   Used within <see cref="FixieTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class FixieSettingsExtensions
    {
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="FixieSettings.Configuration"/></em></p>
        ///   <p>The configuration under which to build. When this option is omitted, the default configuration is `Debug`.</p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="FixieSettings.Configuration"/></em></p>
        ///   <p>The configuration under which to build. When this option is omitted, the default configuration is `Debug`.</p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region NoBuild
        /// <summary>
        ///   <p><em>Sets <see cref="FixieSettings.NoBuild"/></em></p>
        ///   <p>Skip building the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static T SetNoBuild<T>(this T toolSettings, bool? noBuild) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = noBuild;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="FixieSettings.NoBuild"/></em></p>
        ///   <p>Skip building the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static T ResetNoBuild<T>(this T toolSettings) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="FixieSettings.NoBuild"/></em></p>
        ///   <p>Skip building the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static T EnableNoBuild<T>(this T toolSettings) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="FixieSettings.NoBuild"/></em></p>
        ///   <p>Skip building the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static T DisableNoBuild<T>(this T toolSettings) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="FixieSettings.NoBuild"/></em></p>
        ///   <p>Skip building the test project prior to running it.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoBuild<T>(this T toolSettings) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = !toolSettings.NoBuild;
            return toolSettings;
        }
        #endregion
        #region Framework
        /// <summary>
        ///   <p><em>Sets <see cref="FixieSettings.Framework"/></em></p>
        ///   <p>Only run test assemblies targeting a specific framework.</p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="FixieSettings.Framework"/></em></p>
        ///   <p>Only run test assemblies targeting a specific framework.</p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }
        #endregion
        #region Report
        /// <summary>
        ///   <p><em>Sets <see cref="FixieSettings.Report"/></em></p>
        ///   <p>Write test results to the specified path, using the xUnit XML format.</p>
        /// </summary>
        [Pure]
        public static T SetReport<T>(this T toolSettings, string report) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Report = report;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="FixieSettings.Report"/></em></p>
        ///   <p>Write test results to the specified path, using the xUnit XML format.</p>
        /// </summary>
        [Pure]
        public static T ResetReport<T>(this T toolSettings) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Report = null;
            return toolSettings;
        }
        #endregion
        #region CustomArguments
        /// <summary>
        ///   <p><em>Sets <see cref="FixieSettings.CustomArguments"/></em></p>
        ///   <p>Arbitrary arguments made available to custom discovery/execution classes.</p>
        /// </summary>
        [Pure]
        public static T SetCustomArguments<T>(this T toolSettings, string customArguments) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CustomArguments = customArguments;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="FixieSettings.CustomArguments"/></em></p>
        ///   <p>Arbitrary arguments made available to custom discovery/execution classes.</p>
        /// </summary>
        [Pure]
        public static T ResetCustomArguments<T>(this T toolSettings) where T : FixieSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CustomArguments = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
