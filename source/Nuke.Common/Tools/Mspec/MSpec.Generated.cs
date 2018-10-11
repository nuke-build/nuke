// Generated from https://github.com/Slesa/nuke/blob/master/build/specifications/MSpec.json
// Generated with Nuke.CodeGeneration, Version: Local

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Tooling;
using Nuke.Common.Tools;
using Nuke.Common.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.Mspec
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MspecTasks
    {
        /// <summary><p>Path to the Mspec executable.</p></summary>
        public static string MspecPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("MSPEC_EXE") ??
            ToolPathResolver.GetPackageExecutable("Machine.Specifications.Runner.Console", "mspec-clr4.exe");
        /// <summary><p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p></summary>
        public static IReadOnlyCollection<Output> Mspec(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(MspecPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, null, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p><p>For more details, visit the <a href="https://github.com/machine/machine.specifications">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> Mspec(Configure<MspecSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new MspecSettings());
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary><p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p><p>For more details, visit the <a href="https://github.com/machine/machine.specifications">official website</a>.</p></summary>
        public static IReadOnlyCollection<Output> Mspec(List<string> assemblies, Configure<MspecSettings> configurator = null)
        {
            configurator = configurator ?? (x => x);
            return Mspec(x => configurator(x).SetAssemblies(assemblies));
        }
    }
    #region MspecSettings
    /// <summary><p>Used within <see cref="MspecTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class MspecSettings : ToolSettings
    {
        /// <summary><p>Path to the Mspec executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? MspecTasks.MspecPath;
        /// <summary><p>Assemblies with tests to be executed executed.</p></summary>
        public virtual IReadOnlyList<string> Assemblies => AssembliesInternal.AsReadOnly();
        internal List<string> AssembliesInternal { get; set; } = new List<string>();
        /// <summary><p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p></summary>
        public virtual IReadOnlyList<string> Filters => FiltersInternal.AsReadOnly();
        internal List<string> FiltersInternal { get; set; } = new List<string>();
        /// <summary><p>Executes all specifications in contexts with these comma delimited tags. Ex. -i 'foo, bar, foo_bar'.</p></summary>
        public virtual IReadOnlyList<string> Includes => IncludesInternal.AsReadOnly();
        internal List<string> IncludesInternal { get; set; } = new List<string>();
        /// <summary><p>Exclude specifications in contexts with these comma delimited tags. Ex. -x 'foo, bar, foo_bar'.</p></summary>
        public virtual IReadOnlyList<string> Excludes => ExcludesInternal.AsReadOnly();
        internal List<string> ExcludesInternal { get; set; } = new List<string>();
        /// <summary><p>Outputs the HTML report to path, one-per-assembly w/ index.html (if directory, otherwise all are in one file).</p></summary>
        public virtual string HtmlOutput { get; internal set; }
        /// <summary><p>Outputs the XML report to the file referenced by the path.</p></summary>
        public virtual string XmlOutput { get; internal set; }
        /// <summary><p>Reporting for TeamCity CI integration (also auto-detected).</p></summary>
        public virtual bool? TeamCity { get; internal set; }
        /// <summary><p>Disables TeamCity autodetection.</p></summary>
        public virtual bool? NoTeamCity { get; internal set; }
        /// <summary><p>Reporting for AppVeyor CI integration (also auto-detected).</p></summary>
        public virtual bool? AppVeyor { get; internal set; }
        /// <summary><p>Disables AppVeyor autodetection.</p></summary>
        public virtual bool? NoAppVeyor { get; internal set; }
        /// <summary><p>Shows time-related information in HTML output.</p></summary>
        public virtual bool? TimeInfo { get; internal set; }
        /// <summary><p>Suppress progress output (print fatal errors, failures and summary).</p></summary>
        public virtual bool? Silent { get; internal set; }
        /// <summary><p>Print dotted progress output.</p></summary>
        public virtual bool? DottedProgress { get; internal set; }
        /// <summary><p>Suppress colored console output.</p></summary>
        public virtual bool? NoColor { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
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
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region MspecSettingsExtensions
    /// <summary><p>Used within <see cref="MspecTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class MspecSettingsExtensions
    {
        #region Assemblies
        /// <summary><p><em>Sets <see cref="MspecSettings.Assemblies"/> to a new list.</em></p><p>Assemblies with tests to be executed executed.</p></summary>
        [Pure]
        public static MspecSettings SetAssemblies(this MspecSettings toolSettings, params string[] assemblies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal = assemblies.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="MspecSettings.Assemblies"/> to a new list.</em></p><p>Assemblies with tests to be executed executed.</p></summary>
        [Pure]
        public static MspecSettings SetAssemblies(this MspecSettings toolSettings, IEnumerable<string> assemblies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal = assemblies.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="MspecSettings.Assemblies"/>.</em></p><p>Assemblies with tests to be executed executed.</p></summary>
        [Pure]
        public static MspecSettings AddAssemblies(this MspecSettings toolSettings, params string[] assemblies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal.AddRange(assemblies);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="MspecSettings.Assemblies"/>.</em></p><p>Assemblies with tests to be executed executed.</p></summary>
        [Pure]
        public static MspecSettings AddAssemblies(this MspecSettings toolSettings, IEnumerable<string> assemblies)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal.AddRange(assemblies);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="MspecSettings.Assemblies"/>.</em></p><p>Assemblies with tests to be executed executed.</p></summary>
        [Pure]
        public static MspecSettings ClearAssemblies(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="MspecSettings.Assemblies"/>.</em></p><p>Assemblies with tests to be executed executed.</p></summary>
        [Pure]
        public static MspecSettings RemoveAssemblies(this MspecSettings toolSettings, params string[] assemblies)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assemblies);
            toolSettings.AssembliesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="MspecSettings.Assemblies"/>.</em></p><p>Assemblies with tests to be executed executed.</p></summary>
        [Pure]
        public static MspecSettings RemoveAssemblies(this MspecSettings toolSettings, IEnumerable<string> assemblies)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assemblies);
            toolSettings.AssembliesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Filters
        /// <summary><p><em>Sets <see cref="MspecSettings.Filters"/> to a new list.</em></p><p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p></summary>
        [Pure]
        public static MspecSettings SetFilters(this MspecSettings toolSettings, params string[] filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="MspecSettings.Filters"/> to a new list.</em></p><p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p></summary>
        [Pure]
        public static MspecSettings SetFilters(this MspecSettings toolSettings, IEnumerable<string> filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal = filters.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="MspecSettings.Filters"/>.</em></p><p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p></summary>
        [Pure]
        public static MspecSettings AddFilters(this MspecSettings toolSettings, params string[] filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="MspecSettings.Filters"/>.</em></p><p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p></summary>
        [Pure]
        public static MspecSettings AddFilters(this MspecSettings toolSettings, IEnumerable<string> filters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.AddRange(filters);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="MspecSettings.Filters"/>.</em></p><p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p></summary>
        [Pure]
        public static MspecSettings ClearFilters(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FiltersInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="MspecSettings.Filters"/>.</em></p><p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p></summary>
        [Pure]
        public static MspecSettings RemoveFilters(this MspecSettings toolSettings, params string[] filters)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="MspecSettings.Filters"/>.</em></p><p>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</p></summary>
        [Pure]
        public static MspecSettings RemoveFilters(this MspecSettings toolSettings, IEnumerable<string> filters)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(filters);
            toolSettings.FiltersInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Includes
        /// <summary><p><em>Sets <see cref="MspecSettings.Includes"/> to a new list.</em></p><p>Executes all specifications in contexts with these comma delimited tags. Ex. -i 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings SetIncludes(this MspecSettings toolSettings, params string[] includes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludesInternal = includes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="MspecSettings.Includes"/> to a new list.</em></p><p>Executes all specifications in contexts with these comma delimited tags. Ex. -i 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings SetIncludes(this MspecSettings toolSettings, IEnumerable<string> includes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludesInternal = includes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="MspecSettings.Includes"/>.</em></p><p>Executes all specifications in contexts with these comma delimited tags. Ex. -i 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings AddIncludes(this MspecSettings toolSettings, params string[] includes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludesInternal.AddRange(includes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="MspecSettings.Includes"/>.</em></p><p>Executes all specifications in contexts with these comma delimited tags. Ex. -i 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings AddIncludes(this MspecSettings toolSettings, IEnumerable<string> includes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludesInternal.AddRange(includes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="MspecSettings.Includes"/>.</em></p><p>Executes all specifications in contexts with these comma delimited tags. Ex. -i 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings ClearIncludes(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="MspecSettings.Includes"/>.</em></p><p>Executes all specifications in contexts with these comma delimited tags. Ex. -i 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings RemoveIncludes(this MspecSettings toolSettings, params string[] includes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(includes);
            toolSettings.IncludesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="MspecSettings.Includes"/>.</em></p><p>Executes all specifications in contexts with these comma delimited tags. Ex. -i 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings RemoveIncludes(this MspecSettings toolSettings, IEnumerable<string> includes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(includes);
            toolSettings.IncludesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Excludes
        /// <summary><p><em>Sets <see cref="MspecSettings.Excludes"/> to a new list.</em></p><p>Exclude specifications in contexts with these comma delimited tags. Ex. -x 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings SetExcludes(this MspecSettings toolSettings, params string[] excludes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludesInternal = excludes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="MspecSettings.Excludes"/> to a new list.</em></p><p>Exclude specifications in contexts with these comma delimited tags. Ex. -x 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings SetExcludes(this MspecSettings toolSettings, IEnumerable<string> excludes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludesInternal = excludes.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="MspecSettings.Excludes"/>.</em></p><p>Exclude specifications in contexts with these comma delimited tags. Ex. -x 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings AddExcludes(this MspecSettings toolSettings, params string[] excludes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludesInternal.AddRange(excludes);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="MspecSettings.Excludes"/>.</em></p><p>Exclude specifications in contexts with these comma delimited tags. Ex. -x 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings AddExcludes(this MspecSettings toolSettings, IEnumerable<string> excludes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludesInternal.AddRange(excludes);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="MspecSettings.Excludes"/>.</em></p><p>Exclude specifications in contexts with these comma delimited tags. Ex. -x 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings ClearExcludes(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="MspecSettings.Excludes"/>.</em></p><p>Exclude specifications in contexts with these comma delimited tags. Ex. -x 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings RemoveExcludes(this MspecSettings toolSettings, params string[] excludes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludes);
            toolSettings.ExcludesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="MspecSettings.Excludes"/>.</em></p><p>Exclude specifications in contexts with these comma delimited tags. Ex. -x 'foo, bar, foo_bar'.</p></summary>
        [Pure]
        public static MspecSettings RemoveExcludes(this MspecSettings toolSettings, IEnumerable<string> excludes)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludes);
            toolSettings.ExcludesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region HtmlOutput
        /// <summary><p><em>Sets <see cref="MspecSettings.HtmlOutput"/>.</em></p><p>Outputs the HTML report to path, one-per-assembly w/ index.html (if directory, otherwise all are in one file).</p></summary>
        [Pure]
        public static MspecSettings SetHtmlOutput(this MspecSettings toolSettings, string htmlOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HtmlOutput = htmlOutput;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="MspecSettings.HtmlOutput"/>.</em></p><p>Outputs the HTML report to path, one-per-assembly w/ index.html (if directory, otherwise all are in one file).</p></summary>
        [Pure]
        public static MspecSettings ResetHtmlOutput(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HtmlOutput = null;
            return toolSettings;
        }
        #endregion
        #region XmlOutput
        /// <summary><p><em>Sets <see cref="MspecSettings.XmlOutput"/>.</em></p><p>Outputs the XML report to the file referenced by the path.</p></summary>
        [Pure]
        public static MspecSettings SetXmlOutput(this MspecSettings toolSettings, string xmlOutput)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlOutput = xmlOutput;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="MspecSettings.XmlOutput"/>.</em></p><p>Outputs the XML report to the file referenced by the path.</p></summary>
        [Pure]
        public static MspecSettings ResetXmlOutput(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XmlOutput = null;
            return toolSettings;
        }
        #endregion
        #region TeamCity
        /// <summary><p><em>Sets <see cref="MspecSettings.TeamCity"/>.</em></p><p>Reporting for TeamCity CI integration (also auto-detected).</p></summary>
        [Pure]
        public static MspecSettings SetTeamCity(this MspecSettings toolSettings, bool? teamCity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = teamCity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="MspecSettings.TeamCity"/>.</em></p><p>Reporting for TeamCity CI integration (also auto-detected).</p></summary>
        [Pure]
        public static MspecSettings ResetTeamCity(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="MspecSettings.TeamCity"/>.</em></p><p>Reporting for TeamCity CI integration (also auto-detected).</p></summary>
        [Pure]
        public static MspecSettings EnableTeamCity(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="MspecSettings.TeamCity"/>.</em></p><p>Reporting for TeamCity CI integration (also auto-detected).</p></summary>
        [Pure]
        public static MspecSettings DisableTeamCity(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="MspecSettings.TeamCity"/>.</em></p><p>Reporting for TeamCity CI integration (also auto-detected).</p></summary>
        [Pure]
        public static MspecSettings ToggleTeamCity(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TeamCity = !toolSettings.TeamCity;
            return toolSettings;
        }
        #endregion
        #region NoTeamCity
        /// <summary><p><em>Sets <see cref="MspecSettings.NoTeamCity"/>.</em></p><p>Disables TeamCity autodetection.</p></summary>
        [Pure]
        public static MspecSettings SetNoTeamCity(this MspecSettings toolSettings, bool? noTeamCity)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTeamCity = noTeamCity;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="MspecSettings.NoTeamCity"/>.</em></p><p>Disables TeamCity autodetection.</p></summary>
        [Pure]
        public static MspecSettings ResetNoTeamCity(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTeamCity = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="MspecSettings.NoTeamCity"/>.</em></p><p>Disables TeamCity autodetection.</p></summary>
        [Pure]
        public static MspecSettings EnableNoTeamCity(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTeamCity = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="MspecSettings.NoTeamCity"/>.</em></p><p>Disables TeamCity autodetection.</p></summary>
        [Pure]
        public static MspecSettings DisableNoTeamCity(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTeamCity = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="MspecSettings.NoTeamCity"/>.</em></p><p>Disables TeamCity autodetection.</p></summary>
        [Pure]
        public static MspecSettings ToggleNoTeamCity(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTeamCity = !toolSettings.NoTeamCity;
            return toolSettings;
        }
        #endregion
        #region AppVeyor
        /// <summary><p><em>Sets <see cref="MspecSettings.AppVeyor"/>.</em></p><p>Reporting for AppVeyor CI integration (also auto-detected).</p></summary>
        [Pure]
        public static MspecSettings SetAppVeyor(this MspecSettings toolSettings, bool? appVeyor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppVeyor = appVeyor;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="MspecSettings.AppVeyor"/>.</em></p><p>Reporting for AppVeyor CI integration (also auto-detected).</p></summary>
        [Pure]
        public static MspecSettings ResetAppVeyor(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppVeyor = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="MspecSettings.AppVeyor"/>.</em></p><p>Reporting for AppVeyor CI integration (also auto-detected).</p></summary>
        [Pure]
        public static MspecSettings EnableAppVeyor(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppVeyor = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="MspecSettings.AppVeyor"/>.</em></p><p>Reporting for AppVeyor CI integration (also auto-detected).</p></summary>
        [Pure]
        public static MspecSettings DisableAppVeyor(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppVeyor = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="MspecSettings.AppVeyor"/>.</em></p><p>Reporting for AppVeyor CI integration (also auto-detected).</p></summary>
        [Pure]
        public static MspecSettings ToggleAppVeyor(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppVeyor = !toolSettings.AppVeyor;
            return toolSettings;
        }
        #endregion
        #region NoAppVeyor
        /// <summary><p><em>Sets <see cref="MspecSettings.NoAppVeyor"/>.</em></p><p>Disables AppVeyor autodetection.</p></summary>
        [Pure]
        public static MspecSettings SetNoAppVeyor(this MspecSettings toolSettings, bool? noAppVeyor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppVeyor = noAppVeyor;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="MspecSettings.NoAppVeyor"/>.</em></p><p>Disables AppVeyor autodetection.</p></summary>
        [Pure]
        public static MspecSettings ResetNoAppVeyor(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppVeyor = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="MspecSettings.NoAppVeyor"/>.</em></p><p>Disables AppVeyor autodetection.</p></summary>
        [Pure]
        public static MspecSettings EnableNoAppVeyor(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppVeyor = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="MspecSettings.NoAppVeyor"/>.</em></p><p>Disables AppVeyor autodetection.</p></summary>
        [Pure]
        public static MspecSettings DisableNoAppVeyor(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppVeyor = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="MspecSettings.NoAppVeyor"/>.</em></p><p>Disables AppVeyor autodetection.</p></summary>
        [Pure]
        public static MspecSettings ToggleNoAppVeyor(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoAppVeyor = !toolSettings.NoAppVeyor;
            return toolSettings;
        }
        #endregion
        #region TimeInfo
        /// <summary><p><em>Sets <see cref="MspecSettings.TimeInfo"/>.</em></p><p>Shows time-related information in HTML output.</p></summary>
        [Pure]
        public static MspecSettings SetTimeInfo(this MspecSettings toolSettings, bool? timeInfo)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeInfo = timeInfo;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="MspecSettings.TimeInfo"/>.</em></p><p>Shows time-related information in HTML output.</p></summary>
        [Pure]
        public static MspecSettings ResetTimeInfo(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeInfo = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="MspecSettings.TimeInfo"/>.</em></p><p>Shows time-related information in HTML output.</p></summary>
        [Pure]
        public static MspecSettings EnableTimeInfo(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeInfo = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="MspecSettings.TimeInfo"/>.</em></p><p>Shows time-related information in HTML output.</p></summary>
        [Pure]
        public static MspecSettings DisableTimeInfo(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeInfo = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="MspecSettings.TimeInfo"/>.</em></p><p>Shows time-related information in HTML output.</p></summary>
        [Pure]
        public static MspecSettings ToggleTimeInfo(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TimeInfo = !toolSettings.TimeInfo;
            return toolSettings;
        }
        #endregion
        #region Silent
        /// <summary><p><em>Sets <see cref="MspecSettings.Silent"/>.</em></p><p>Suppress progress output (print fatal errors, failures and summary).</p></summary>
        [Pure]
        public static MspecSettings SetSilent(this MspecSettings toolSettings, bool? silent)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = silent;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="MspecSettings.Silent"/>.</em></p><p>Suppress progress output (print fatal errors, failures and summary).</p></summary>
        [Pure]
        public static MspecSettings ResetSilent(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="MspecSettings.Silent"/>.</em></p><p>Suppress progress output (print fatal errors, failures and summary).</p></summary>
        [Pure]
        public static MspecSettings EnableSilent(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="MspecSettings.Silent"/>.</em></p><p>Suppress progress output (print fatal errors, failures and summary).</p></summary>
        [Pure]
        public static MspecSettings DisableSilent(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="MspecSettings.Silent"/>.</em></p><p>Suppress progress output (print fatal errors, failures and summary).</p></summary>
        [Pure]
        public static MspecSettings ToggleSilent(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Silent = !toolSettings.Silent;
            return toolSettings;
        }
        #endregion
        #region DottedProgress
        /// <summary><p><em>Sets <see cref="MspecSettings.DottedProgress"/>.</em></p><p>Print dotted progress output.</p></summary>
        [Pure]
        public static MspecSettings SetDottedProgress(this MspecSettings toolSettings, bool? dottedProgress)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DottedProgress = dottedProgress;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="MspecSettings.DottedProgress"/>.</em></p><p>Print dotted progress output.</p></summary>
        [Pure]
        public static MspecSettings ResetDottedProgress(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DottedProgress = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="MspecSettings.DottedProgress"/>.</em></p><p>Print dotted progress output.</p></summary>
        [Pure]
        public static MspecSettings EnableDottedProgress(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DottedProgress = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="MspecSettings.DottedProgress"/>.</em></p><p>Print dotted progress output.</p></summary>
        [Pure]
        public static MspecSettings DisableDottedProgress(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DottedProgress = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="MspecSettings.DottedProgress"/>.</em></p><p>Print dotted progress output.</p></summary>
        [Pure]
        public static MspecSettings ToggleDottedProgress(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DottedProgress = !toolSettings.DottedProgress;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary><p><em>Sets <see cref="MspecSettings.NoColor"/>.</em></p><p>Suppress colored console output.</p></summary>
        [Pure]
        public static MspecSettings SetNoColor(this MspecSettings toolSettings, bool? noColor)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="MspecSettings.NoColor"/>.</em></p><p>Suppress colored console output.</p></summary>
        [Pure]
        public static MspecSettings ResetNoColor(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="MspecSettings.NoColor"/>.</em></p><p>Suppress colored console output.</p></summary>
        [Pure]
        public static MspecSettings EnableNoColor(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="MspecSettings.NoColor"/>.</em></p><p>Suppress colored console output.</p></summary>
        [Pure]
        public static MspecSettings DisableNoColor(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="MspecSettings.NoColor"/>.</em></p><p>Suppress colored console output.</p></summary>
        [Pure]
        public static MspecSettings ToggleNoColor(this MspecSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
