// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/MSpec/MSpec.json

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

namespace Nuke.Common.Tools.MSpec
{
    /// <summary>
    ///   <p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p>
    ///   <p>For more details, visit the <a href="https://github.com/machine/machine.specifications">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(MSpecPackageId)]
    public partial class MSpecTasks
        : IRequireNuGetPackage
    {
        public const string MSpecPackageId = "machine.specifications.runner.console";
        /// <summary>
        ///   Path to the MSpec executable.
        /// </summary>
        public static string MSpecPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("MSPEC_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> MSpecLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p>
        ///   <p>For more details, visit the <a href="https://github.com/machine/machine.specifications">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> MSpec(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(MSpecPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? MSpecLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p>
        ///   <p>For more details, visit the <a href="https://github.com/machine/machine.specifications">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assemblies&gt;</c> via <see cref="MSpecSettings.Assemblies"/></li>
        ///     <li><c>--appveyor</c> via <see cref="MSpecSettings.AppVeyor"/></li>
        ///     <li><c>--html</c> via <see cref="MSpecSettings.HtmlOutput"/></li>
        ///     <li><c>--no-appveyor-autodetect</c> via <see cref="MSpecSettings.NoAppVeyor"/></li>
        ///     <li><c>--no-color</c> via <see cref="MSpecSettings.NoColor"/></li>
        ///     <li><c>--no-teamcity-autodetect</c> via <see cref="MSpecSettings.NoTeamCity"/></li>
        ///     <li><c>--progress</c> via <see cref="MSpecSettings.DottedProgress"/></li>
        ///     <li><c>--silent</c> via <see cref="MSpecSettings.Silent"/></li>
        ///     <li><c>--teamcity</c> via <see cref="MSpecSettings.TeamCity"/></li>
        ///     <li><c>--timeinfo</c> via <see cref="MSpecSettings.TimeInfo"/></li>
        ///     <li><c>--xml</c> via <see cref="MSpecSettings.XmlOutput"/></li>
        ///     <li><c>-f</c> via <see cref="MSpecSettings.Filters"/></li>
        ///     <li><c>-i</c> via <see cref="MSpecSettings.Includes"/></li>
        ///     <li><c>-x</c> via <see cref="MSpecSettings.Excludes"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> MSpec(MSpecSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new MSpecSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p>
        ///   <p>For more details, visit the <a href="https://github.com/machine/machine.specifications">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assemblies&gt;</c> via <see cref="MSpecSettings.Assemblies"/></li>
        ///     <li><c>--appveyor</c> via <see cref="MSpecSettings.AppVeyor"/></li>
        ///     <li><c>--html</c> via <see cref="MSpecSettings.HtmlOutput"/></li>
        ///     <li><c>--no-appveyor-autodetect</c> via <see cref="MSpecSettings.NoAppVeyor"/></li>
        ///     <li><c>--no-color</c> via <see cref="MSpecSettings.NoColor"/></li>
        ///     <li><c>--no-teamcity-autodetect</c> via <see cref="MSpecSettings.NoTeamCity"/></li>
        ///     <li><c>--progress</c> via <see cref="MSpecSettings.DottedProgress"/></li>
        ///     <li><c>--silent</c> via <see cref="MSpecSettings.Silent"/></li>
        ///     <li><c>--teamcity</c> via <see cref="MSpecSettings.TeamCity"/></li>
        ///     <li><c>--timeinfo</c> via <see cref="MSpecSettings.TimeInfo"/></li>
        ///     <li><c>--xml</c> via <see cref="MSpecSettings.XmlOutput"/></li>
        ///     <li><c>-f</c> via <see cref="MSpecSettings.Filters"/></li>
        ///     <li><c>-i</c> via <see cref="MSpecSettings.Includes"/></li>
        ///     <li><c>-x</c> via <see cref="MSpecSettings.Excludes"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> MSpec(Configure<MSpecSettings> configurator)
        {
            return MSpec(configurator(new MSpecSettings()));
        }
        /// <summary>
        ///   <p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p>
        ///   <p>For more details, visit the <a href="https://github.com/machine/machine.specifications">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assemblies&gt;</c> via <see cref="MSpecSettings.Assemblies"/></li>
        ///     <li><c>--appveyor</c> via <see cref="MSpecSettings.AppVeyor"/></li>
        ///     <li><c>--html</c> via <see cref="MSpecSettings.HtmlOutput"/></li>
        ///     <li><c>--no-appveyor-autodetect</c> via <see cref="MSpecSettings.NoAppVeyor"/></li>
        ///     <li><c>--no-color</c> via <see cref="MSpecSettings.NoColor"/></li>
        ///     <li><c>--no-teamcity-autodetect</c> via <see cref="MSpecSettings.NoTeamCity"/></li>
        ///     <li><c>--progress</c> via <see cref="MSpecSettings.DottedProgress"/></li>
        ///     <li><c>--silent</c> via <see cref="MSpecSettings.Silent"/></li>
        ///     <li><c>--teamcity</c> via <see cref="MSpecSettings.TeamCity"/></li>
        ///     <li><c>--timeinfo</c> via <see cref="MSpecSettings.TimeInfo"/></li>
        ///     <li><c>--xml</c> via <see cref="MSpecSettings.XmlOutput"/></li>
        ///     <li><c>-f</c> via <see cref="MSpecSettings.Filters"/></li>
        ///     <li><c>-i</c> via <see cref="MSpecSettings.Includes"/></li>
        ///     <li><c>-x</c> via <see cref="MSpecSettings.Excludes"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(MSpecSettings Settings, IReadOnlyCollection<Output> Output)> MSpec(CombinatorialConfigure<MSpecSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(MSpec, MSpecLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region MSpecSettings
    /// <summary>
    ///   Used within <see cref="MSpecTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class MSpecSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the MSpec executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? GetProcessToolPath();
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? MSpecTasks.MSpecLogger;
        /// <summary>
        ///   Assemblies with tests to be executed.
        /// </summary>
        public virtual IReadOnlyList<string> Assemblies => AssembliesInternal.AsReadOnly();
        internal List<string> AssembliesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.
        /// </summary>
        public virtual IReadOnlyList<string> Filters => FiltersInternal.AsReadOnly();
        internal List<string> FiltersInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Executes all specifications in contexts with these comma delimited tags. Ex. <c>-i 'foo, bar, foo_bar'</c>.
        /// </summary>
        public virtual IReadOnlyList<string> Includes => IncludesInternal.AsReadOnly();
        internal List<string> IncludesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Exclude specifications in contexts with these comma delimited tags. Ex. <c>-x 'foo, bar, foo_bar'</c>.
        /// </summary>
        public virtual IReadOnlyList<string> Excludes => ExcludesInternal.AsReadOnly();
        internal List<string> ExcludesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Outputs the HTML report to path, one-per-assembly w/ index.html (if directory, otherwise all are in one file). Ex. <c>--html=output/reports/</c>
        /// </summary>
        public virtual string HtmlOutput { get; internal set; }
        /// <summary>
        ///   Outputs the XML report to the file referenced by the path. Ex. <c>--xml=output/reports/MSpecResults.xml</c>
        /// </summary>
        public virtual string XmlOutput { get; internal set; }
        /// <summary>
        ///   Reporting for TeamCity CI integration (also auto-detected).
        /// </summary>
        public virtual bool? TeamCity { get; internal set; }
        /// <summary>
        ///   Disables TeamCity autodetection.
        /// </summary>
        public virtual bool? NoTeamCity { get; internal set; }
        /// <summary>
        ///   Reporting for AppVeyor CI integration (also auto-detected).
        /// </summary>
        public virtual bool? AppVeyor { get; internal set; }
        /// <summary>
        ///   Disables AppVeyor autodetection.
        /// </summary>
        public virtual bool? NoAppVeyor { get; internal set; }
        /// <summary>
        ///   Shows time-related information in HTML output.
        /// </summary>
        public virtual bool? TimeInfo { get; internal set; }
        /// <summary>
        ///   Suppress progress output (print fatal errors, failures and summary).
        /// </summary>
        public virtual bool? Silent { get; internal set; }
        /// <summary>
        ///   Print dotted progress output.
        /// </summary>
        public virtual bool? DottedProgress { get; internal set; }
        /// <summary>
        ///   Suppress colored console output.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", Assemblies, separator: ' ')
              .Add("-f={value}", Filters, separator: ',')
              .Add("-i={value}", Includes, separator: ',')
              .Add("-x={value}", Excludes, separator: ',')
              .Add("--html={value}", HtmlOutput)
              .Add("--xml={value}", XmlOutput)
              .Add("--teamcity", TeamCity)
              .Add("--no-teamcity-autodetect", NoTeamCity)
              .Add("--appveyor", AppVeyor)
              .Add("--no-appveyor-autodetect", NoAppVeyor)
              .Add("--timeinfo", TimeInfo)
              .Add("--silent", Silent)
              .Add("--progress", DottedProgress)
              .Add("--no-color", NoColor);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region MSpecSettingsExtensions
    /// <summary>
    ///   Used within <see cref="MSpecTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MSpecSettingsExtensions
    {
        #region Assemblies
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.Assemblies"/> to a new list</em></p>
        ///   <p>Assemblies with tests to be executed.</p>
        /// </summary>
        [Pure]
        public static T SetAssemblies<T>(this T toolSettings, params string[] assemblies) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal = assemblies.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.Assemblies"/> to a new list</em></p>
        ///   <p>Assemblies with tests to be executed.</p>
        /// </summary>
        [Pure]
        public static T SetAssemblies<T>(this T toolSettings, IEnumerable<string> assemblies) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal = assemblies.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MSpecSettings.Assemblies"/></em></p>
        ///   <p>Assemblies with tests to be executed.</p>
        /// </summary>
        [Pure]
        public static T AddAssemblies<T>(this T toolSettings, params string[] assemblies) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal.AddRange(assemblies);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MSpecSettings.Assemblies"/></em></p>
        ///   <p>Assemblies with tests to be executed.</p>
        /// </summary>
        [Pure]
        public static T AddAssemblies<T>(this T toolSettings, IEnumerable<string> assemblies) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal.AddRange(assemblies);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="MSpecSettings.Assemblies"/></em></p>
        ///   <p>Assemblies with tests to be executed.</p>
        /// </summary>
        [Pure]
        public static T ClearAssemblies<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MSpecSettings.Assemblies"/></em></p>
        ///   <p>Assemblies with tests to be executed.</p>
        /// </summary>
        [Pure]
        public static T RemoveAssemblies<T>(this T toolSettings, params string[] assemblies) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assemblies);
            toolSettings.AssembliesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MSpecSettings.Assemblies"/></em></p>
        ///   <p>Assemblies with tests to be executed.</p>
        /// </summary>
        [Pure]
        public static T RemoveAssemblies<T>(this T toolSettings, IEnumerable<string> assemblies) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assemblies);
            toolSettings.AssembliesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Filters
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.Filters"/> to a new list</em></p>
        ///   <p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p>
        /// </summary>
        [Pure]
        public static T SetFilters<T>(this T toolSettings, params string[] filters) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.Filters"/> to a new list</em></p>
        ///   <p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p>
        /// </summary>
        [Pure]
        public static T SetFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MSpecSettings.Filters"/></em></p>
        ///   <p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p>
        /// </summary>
        [Pure]
        public static T AddFilters<T>(this T toolSettings, params string[] filters) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MSpecSettings.Filters"/></em></p>
        ///   <p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p>
        /// </summary>
        [Pure]
        public static T AddFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="MSpecSettings.Filters"/></em></p>
        ///   <p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p>
        /// </summary>
        [Pure]
        public static T ClearFilters<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MSpecSettings.Filters"/></em></p>
        ///   <p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p>
        /// </summary>
        [Pure]
        public static T RemoveFilters<T>(this T toolSettings, params string[] filters) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MSpecSettings.Filters"/></em></p>
        ///   <p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p>
        /// </summary>
        [Pure]
        public static T RemoveFilters<T>(this T toolSettings, IEnumerable<string> filters) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Includes
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.Includes"/> to a new list</em></p>
        ///   <p>Executes all specifications in contexts with these comma delimited tags. Ex. <c>-i 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T SetIncludes<T>(this T toolSettings, params string[] includes) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludesInternal = includes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.Includes"/> to a new list</em></p>
        ///   <p>Executes all specifications in contexts with these comma delimited tags. Ex. <c>-i 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T SetIncludes<T>(this T toolSettings, IEnumerable<string> includes) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludesInternal = includes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MSpecSettings.Includes"/></em></p>
        ///   <p>Executes all specifications in contexts with these comma delimited tags. Ex. <c>-i 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T AddIncludes<T>(this T toolSettings, params string[] includes) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludesInternal.AddRange(includes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MSpecSettings.Includes"/></em></p>
        ///   <p>Executes all specifications in contexts with these comma delimited tags. Ex. <c>-i 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T AddIncludes<T>(this T toolSettings, IEnumerable<string> includes) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludesInternal.AddRange(includes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="MSpecSettings.Includes"/></em></p>
        ///   <p>Executes all specifications in contexts with these comma delimited tags. Ex. <c>-i 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearIncludes<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MSpecSettings.Includes"/></em></p>
        ///   <p>Executes all specifications in contexts with these comma delimited tags. Ex. <c>-i 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveIncludes<T>(this T toolSettings, params string[] includes) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(includes);
            toolSettings.IncludesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MSpecSettings.Includes"/></em></p>
        ///   <p>Executes all specifications in contexts with these comma delimited tags. Ex. <c>-i 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveIncludes<T>(this T toolSettings, IEnumerable<string> includes) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(includes);
            toolSettings.IncludesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Excludes
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.Excludes"/> to a new list</em></p>
        ///   <p>Exclude specifications in contexts with these comma delimited tags. Ex. <c>-x 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T SetExcludes<T>(this T toolSettings, params string[] excludes) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludesInternal = excludes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.Excludes"/> to a new list</em></p>
        ///   <p>Exclude specifications in contexts with these comma delimited tags. Ex. <c>-x 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T SetExcludes<T>(this T toolSettings, IEnumerable<string> excludes) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludesInternal = excludes.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MSpecSettings.Excludes"/></em></p>
        ///   <p>Exclude specifications in contexts with these comma delimited tags. Ex. <c>-x 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T AddExcludes<T>(this T toolSettings, params string[] excludes) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludesInternal.AddRange(excludes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="MSpecSettings.Excludes"/></em></p>
        ///   <p>Exclude specifications in contexts with these comma delimited tags. Ex. <c>-x 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T AddExcludes<T>(this T toolSettings, IEnumerable<string> excludes) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludesInternal.AddRange(excludes);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="MSpecSettings.Excludes"/></em></p>
        ///   <p>Exclude specifications in contexts with these comma delimited tags. Ex. <c>-x 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T ClearExcludes<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MSpecSettings.Excludes"/></em></p>
        ///   <p>Exclude specifications in contexts with these comma delimited tags. Ex. <c>-x 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludes<T>(this T toolSettings, params string[] excludes) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludes);
            toolSettings.ExcludesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="MSpecSettings.Excludes"/></em></p>
        ///   <p>Exclude specifications in contexts with these comma delimited tags. Ex. <c>-x 'foo, bar, foo_bar'</c>.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludes<T>(this T toolSettings, IEnumerable<string> excludes) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludes);
            toolSettings.ExcludesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region HtmlOutput
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.HtmlOutput"/></em></p>
        ///   <p>Outputs the HTML report to path, one-per-assembly w/ index.html (if directory, otherwise all are in one file). Ex. <c>--html=output/reports/</c></p>
        /// </summary>
        [Pure]
        public static T SetHtmlOutput<T>(this T toolSettings, string htmlOutput) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HtmlOutput = htmlOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSpecSettings.HtmlOutput"/></em></p>
        ///   <p>Outputs the HTML report to path, one-per-assembly w/ index.html (if directory, otherwise all are in one file). Ex. <c>--html=output/reports/</c></p>
        /// </summary>
        [Pure]
        public static T ResetHtmlOutput<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HtmlOutput = null;
            return toolSettings;
        }
        #endregion
        #region XmlOutput
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.XmlOutput"/></em></p>
        ///   <p>Outputs the XML report to the file referenced by the path. Ex. <c>--xml=output/reports/MSpecResults.xml</c></p>
        /// </summary>
        [Pure]
        public static T SetXmlOutput<T>(this T toolSettings, string xmlOutput) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlOutput = xmlOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSpecSettings.XmlOutput"/></em></p>
        ///   <p>Outputs the XML report to the file referenced by the path. Ex. <c>--xml=output/reports/MSpecResults.xml</c></p>
        /// </summary>
        [Pure]
        public static T ResetXmlOutput<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlOutput = null;
            return toolSettings;
        }
        #endregion
        #region TeamCity
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.TeamCity"/></em></p>
        ///   <p>Reporting for TeamCity CI integration (also auto-detected).</p>
        /// </summary>
        [Pure]
        public static T SetTeamCity<T>(this T toolSettings, bool? teamCity) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = teamCity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSpecSettings.TeamCity"/></em></p>
        ///   <p>Reporting for TeamCity CI integration (also auto-detected).</p>
        /// </summary>
        [Pure]
        public static T ResetTeamCity<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSpecSettings.TeamCity"/></em></p>
        ///   <p>Reporting for TeamCity CI integration (also auto-detected).</p>
        /// </summary>
        [Pure]
        public static T EnableTeamCity<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSpecSettings.TeamCity"/></em></p>
        ///   <p>Reporting for TeamCity CI integration (also auto-detected).</p>
        /// </summary>
        [Pure]
        public static T DisableTeamCity<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSpecSettings.TeamCity"/></em></p>
        ///   <p>Reporting for TeamCity CI integration (also auto-detected).</p>
        /// </summary>
        [Pure]
        public static T ToggleTeamCity<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = !toolSettings.TeamCity;
            return toolSettings;
        }
        #endregion
        #region NoTeamCity
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.NoTeamCity"/></em></p>
        ///   <p>Disables TeamCity autodetection.</p>
        /// </summary>
        [Pure]
        public static T SetNoTeamCity<T>(this T toolSettings, bool? noTeamCity) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTeamCity = noTeamCity;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSpecSettings.NoTeamCity"/></em></p>
        ///   <p>Disables TeamCity autodetection.</p>
        /// </summary>
        [Pure]
        public static T ResetNoTeamCity<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTeamCity = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSpecSettings.NoTeamCity"/></em></p>
        ///   <p>Disables TeamCity autodetection.</p>
        /// </summary>
        [Pure]
        public static T EnableNoTeamCity<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTeamCity = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSpecSettings.NoTeamCity"/></em></p>
        ///   <p>Disables TeamCity autodetection.</p>
        /// </summary>
        [Pure]
        public static T DisableNoTeamCity<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTeamCity = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSpecSettings.NoTeamCity"/></em></p>
        ///   <p>Disables TeamCity autodetection.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoTeamCity<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTeamCity = !toolSettings.NoTeamCity;
            return toolSettings;
        }
        #endregion
        #region AppVeyor
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.AppVeyor"/></em></p>
        ///   <p>Reporting for AppVeyor CI integration (also auto-detected).</p>
        /// </summary>
        [Pure]
        public static T SetAppVeyor<T>(this T toolSettings, bool? appVeyor) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppVeyor = appVeyor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSpecSettings.AppVeyor"/></em></p>
        ///   <p>Reporting for AppVeyor CI integration (also auto-detected).</p>
        /// </summary>
        [Pure]
        public static T ResetAppVeyor<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppVeyor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSpecSettings.AppVeyor"/></em></p>
        ///   <p>Reporting for AppVeyor CI integration (also auto-detected).</p>
        /// </summary>
        [Pure]
        public static T EnableAppVeyor<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppVeyor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSpecSettings.AppVeyor"/></em></p>
        ///   <p>Reporting for AppVeyor CI integration (also auto-detected).</p>
        /// </summary>
        [Pure]
        public static T DisableAppVeyor<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppVeyor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSpecSettings.AppVeyor"/></em></p>
        ///   <p>Reporting for AppVeyor CI integration (also auto-detected).</p>
        /// </summary>
        [Pure]
        public static T ToggleAppVeyor<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppVeyor = !toolSettings.AppVeyor;
            return toolSettings;
        }
        #endregion
        #region NoAppVeyor
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.NoAppVeyor"/></em></p>
        ///   <p>Disables AppVeyor autodetection.</p>
        /// </summary>
        [Pure]
        public static T SetNoAppVeyor<T>(this T toolSettings, bool? noAppVeyor) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppVeyor = noAppVeyor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSpecSettings.NoAppVeyor"/></em></p>
        ///   <p>Disables AppVeyor autodetection.</p>
        /// </summary>
        [Pure]
        public static T ResetNoAppVeyor<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppVeyor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSpecSettings.NoAppVeyor"/></em></p>
        ///   <p>Disables AppVeyor autodetection.</p>
        /// </summary>
        [Pure]
        public static T EnableNoAppVeyor<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppVeyor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSpecSettings.NoAppVeyor"/></em></p>
        ///   <p>Disables AppVeyor autodetection.</p>
        /// </summary>
        [Pure]
        public static T DisableNoAppVeyor<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppVeyor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSpecSettings.NoAppVeyor"/></em></p>
        ///   <p>Disables AppVeyor autodetection.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoAppVeyor<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppVeyor = !toolSettings.NoAppVeyor;
            return toolSettings;
        }
        #endregion
        #region TimeInfo
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.TimeInfo"/></em></p>
        ///   <p>Shows time-related information in HTML output.</p>
        /// </summary>
        [Pure]
        public static T SetTimeInfo<T>(this T toolSettings, bool? timeInfo) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeInfo = timeInfo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSpecSettings.TimeInfo"/></em></p>
        ///   <p>Shows time-related information in HTML output.</p>
        /// </summary>
        [Pure]
        public static T ResetTimeInfo<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeInfo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSpecSettings.TimeInfo"/></em></p>
        ///   <p>Shows time-related information in HTML output.</p>
        /// </summary>
        [Pure]
        public static T EnableTimeInfo<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeInfo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSpecSettings.TimeInfo"/></em></p>
        ///   <p>Shows time-related information in HTML output.</p>
        /// </summary>
        [Pure]
        public static T DisableTimeInfo<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeInfo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSpecSettings.TimeInfo"/></em></p>
        ///   <p>Shows time-related information in HTML output.</p>
        /// </summary>
        [Pure]
        public static T ToggleTimeInfo<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeInfo = !toolSettings.TimeInfo;
            return toolSettings;
        }
        #endregion
        #region Silent
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.Silent"/></em></p>
        ///   <p>Suppress progress output (print fatal errors, failures and summary).</p>
        /// </summary>
        [Pure]
        public static T SetSilent<T>(this T toolSettings, bool? silent) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = silent;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSpecSettings.Silent"/></em></p>
        ///   <p>Suppress progress output (print fatal errors, failures and summary).</p>
        /// </summary>
        [Pure]
        public static T ResetSilent<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSpecSettings.Silent"/></em></p>
        ///   <p>Suppress progress output (print fatal errors, failures and summary).</p>
        /// </summary>
        [Pure]
        public static T EnableSilent<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSpecSettings.Silent"/></em></p>
        ///   <p>Suppress progress output (print fatal errors, failures and summary).</p>
        /// </summary>
        [Pure]
        public static T DisableSilent<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSpecSettings.Silent"/></em></p>
        ///   <p>Suppress progress output (print fatal errors, failures and summary).</p>
        /// </summary>
        [Pure]
        public static T ToggleSilent<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = !toolSettings.Silent;
            return toolSettings;
        }
        #endregion
        #region DottedProgress
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.DottedProgress"/></em></p>
        ///   <p>Print dotted progress output.</p>
        /// </summary>
        [Pure]
        public static T SetDottedProgress<T>(this T toolSettings, bool? dottedProgress) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DottedProgress = dottedProgress;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSpecSettings.DottedProgress"/></em></p>
        ///   <p>Print dotted progress output.</p>
        /// </summary>
        [Pure]
        public static T ResetDottedProgress<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DottedProgress = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSpecSettings.DottedProgress"/></em></p>
        ///   <p>Print dotted progress output.</p>
        /// </summary>
        [Pure]
        public static T EnableDottedProgress<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DottedProgress = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSpecSettings.DottedProgress"/></em></p>
        ///   <p>Print dotted progress output.</p>
        /// </summary>
        [Pure]
        public static T DisableDottedProgress<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DottedProgress = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSpecSettings.DottedProgress"/></em></p>
        ///   <p>Print dotted progress output.</p>
        /// </summary>
        [Pure]
        public static T ToggleDottedProgress<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DottedProgress = !toolSettings.DottedProgress;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="MSpecSettings.NoColor"/></em></p>
        ///   <p>Suppress colored console output.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="MSpecSettings.NoColor"/></em></p>
        ///   <p>Suppress colored console output.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="MSpecSettings.NoColor"/></em></p>
        ///   <p>Suppress colored console output.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="MSpecSettings.NoColor"/></em></p>
        ///   <p>Suppress colored console output.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="MSpecSettings.NoColor"/></em></p>
        ///   <p>Suppress colored console output.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : MSpecSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
