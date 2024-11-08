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

namespace Nuke.Common.Tools.MSpec;

/// <summary><p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p><p>For more details, visit the <a href="https://github.com/machine/machine.specifications">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId)]
public partial class MSpecTasks : ToolTasks, IRequireNuGetPackage
{
    public static string MSpecPath => new MSpecTasks().GetToolPath();
    public const string PackageId = "machine.specifications.runner.console";
    /// <summary><p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p><p>For more details, visit the <a href="https://github.com/machine/machine.specifications">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> MSpec(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new MSpecTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p><p>For more details, visit the <a href="https://github.com/machine/machine.specifications">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assemblies&gt;</c> via <see cref="MSpecSettings.Assemblies"/></li><li><c>--appveyor</c> via <see cref="MSpecSettings.AppVeyor"/></li><li><c>--html</c> via <see cref="MSpecSettings.HtmlOutput"/></li><li><c>--no-appveyor-autodetect</c> via <see cref="MSpecSettings.NoAppVeyor"/></li><li><c>--no-color</c> via <see cref="MSpecSettings.NoColor"/></li><li><c>--no-teamcity-autodetect</c> via <see cref="MSpecSettings.NoTeamCity"/></li><li><c>--progress</c> via <see cref="MSpecSettings.DottedProgress"/></li><li><c>--silent</c> via <see cref="MSpecSettings.Silent"/></li><li><c>--teamcity</c> via <see cref="MSpecSettings.TeamCity"/></li><li><c>--timeinfo</c> via <see cref="MSpecSettings.TimeInfo"/></li><li><c>--xml</c> via <see cref="MSpecSettings.XmlOutput"/></li><li><c>-exclude</c> via <see cref="MSpecSettings.Excludes"/></li><li><c>-filters</c> via <see cref="MSpecSettings.Filters"/></li><li><c>-include</c> via <see cref="MSpecSettings.Includes"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> MSpec(MSpecSettings options = null) => new MSpecTasks().Run(options);
    /// <summary><p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p><p>For more details, visit the <a href="https://github.com/machine/machine.specifications">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assemblies&gt;</c> via <see cref="MSpecSettings.Assemblies"/></li><li><c>--appveyor</c> via <see cref="MSpecSettings.AppVeyor"/></li><li><c>--html</c> via <see cref="MSpecSettings.HtmlOutput"/></li><li><c>--no-appveyor-autodetect</c> via <see cref="MSpecSettings.NoAppVeyor"/></li><li><c>--no-color</c> via <see cref="MSpecSettings.NoColor"/></li><li><c>--no-teamcity-autodetect</c> via <see cref="MSpecSettings.NoTeamCity"/></li><li><c>--progress</c> via <see cref="MSpecSettings.DottedProgress"/></li><li><c>--silent</c> via <see cref="MSpecSettings.Silent"/></li><li><c>--teamcity</c> via <see cref="MSpecSettings.TeamCity"/></li><li><c>--timeinfo</c> via <see cref="MSpecSettings.TimeInfo"/></li><li><c>--xml</c> via <see cref="MSpecSettings.XmlOutput"/></li><li><c>-exclude</c> via <see cref="MSpecSettings.Excludes"/></li><li><c>-filters</c> via <see cref="MSpecSettings.Filters"/></li><li><c>-include</c> via <see cref="MSpecSettings.Includes"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> MSpec(Configure<MSpecSettings> configurator) => new MSpecTasks().Run(configurator.Invoke(new MSpecSettings()));
    /// <summary><p>MSpec is called a 'context/specification' test framework because of the 'grammar' that is used in describing and coding the tests or 'specs'.</p><p>For more details, visit the <a href="https://github.com/machine/machine.specifications">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;assemblies&gt;</c> via <see cref="MSpecSettings.Assemblies"/></li><li><c>--appveyor</c> via <see cref="MSpecSettings.AppVeyor"/></li><li><c>--html</c> via <see cref="MSpecSettings.HtmlOutput"/></li><li><c>--no-appveyor-autodetect</c> via <see cref="MSpecSettings.NoAppVeyor"/></li><li><c>--no-color</c> via <see cref="MSpecSettings.NoColor"/></li><li><c>--no-teamcity-autodetect</c> via <see cref="MSpecSettings.NoTeamCity"/></li><li><c>--progress</c> via <see cref="MSpecSettings.DottedProgress"/></li><li><c>--silent</c> via <see cref="MSpecSettings.Silent"/></li><li><c>--teamcity</c> via <see cref="MSpecSettings.TeamCity"/></li><li><c>--timeinfo</c> via <see cref="MSpecSettings.TimeInfo"/></li><li><c>--xml</c> via <see cref="MSpecSettings.XmlOutput"/></li><li><c>-exclude</c> via <see cref="MSpecSettings.Excludes"/></li><li><c>-filters</c> via <see cref="MSpecSettings.Filters"/></li><li><c>-include</c> via <see cref="MSpecSettings.Includes"/></li></ul></remarks>
    public static IEnumerable<(MSpecSettings Settings, IReadOnlyCollection<Output> Output)> MSpec(CombinatorialConfigure<MSpecSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(MSpec, degreeOfParallelism, completeOnFailure);
}
#region MSpecSettings
/// <summary>Used within <see cref="MSpecTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<MSpecSettings>))]
[Command(Type = typeof(MSpecTasks), Command = nameof(MSpecTasks.MSpec))]
public partial class MSpecSettings : ToolOptions
{
    /// <summary>Assemblies with tests to be executed.</summary>
    [Argument(Format = "{value}", Position = 1, Separator = " ")] public IReadOnlyList<string> Assemblies => Get<List<string>>(() => Assemblies);
    /// <summary>Filter file specifying contexts to execute (full type name, one per line). Takes precedence over tags.</summary>
    [Argument(Format = "-filters {value}", Separator = ",")] public IReadOnlyList<string> Filters => Get<List<string>>(() => Filters);
    /// <summary>Executes all specifications in contexts with these comma delimited tags. Ex. <c>-i 'foo, bar, foo_bar'</c>.</summary>
    [Argument(Format = "-include {value}", Separator = ",")] public IReadOnlyList<string> Includes => Get<List<string>>(() => Includes);
    /// <summary>Exclude specifications in contexts with these comma delimited tags. Ex. <c>-x 'foo, bar, foo_bar'</c>.</summary>
    [Argument(Format = "-exclude {value}", Separator = ",")] public IReadOnlyList<string> Excludes => Get<List<string>>(() => Excludes);
    /// <summary>Outputs the HTML report to path, one-per-assembly w/ index.html (if directory, otherwise all are in one file). Ex. <c>--html=output/reports/</c></summary>
    [Argument(Format = "--html {value}")] public string HtmlOutput => Get<string>(() => HtmlOutput);
    /// <summary>Outputs the XML report to the file referenced by the path. Ex. <c>--xml=output/reports/MSpecResults.xml</c></summary>
    [Argument(Format = "--xml {value}")] public string XmlOutput => Get<string>(() => XmlOutput);
    /// <summary>Reporting for TeamCity CI integration (also auto-detected).</summary>
    [Argument(Format = "--teamcity")] public bool? TeamCity => Get<bool?>(() => TeamCity);
    /// <summary>Disables TeamCity autodetection.</summary>
    [Argument(Format = "--no-teamcity-autodetect")] public bool? NoTeamCity => Get<bool?>(() => NoTeamCity);
    /// <summary>Reporting for AppVeyor CI integration (also auto-detected).</summary>
    [Argument(Format = "--appveyor")] public bool? AppVeyor => Get<bool?>(() => AppVeyor);
    /// <summary>Disables AppVeyor autodetection.</summary>
    [Argument(Format = "--no-appveyor-autodetect")] public bool? NoAppVeyor => Get<bool?>(() => NoAppVeyor);
    /// <summary>Shows time-related information in HTML output.</summary>
    [Argument(Format = "--timeinfo")] public bool? TimeInfo => Get<bool?>(() => TimeInfo);
    /// <summary>Suppress progress output (print fatal errors, failures and summary).</summary>
    [Argument(Format = "--silent")] public bool? Silent => Get<bool?>(() => Silent);
    /// <summary>Print dotted progress output.</summary>
    [Argument(Format = "--progress")] public bool? DottedProgress => Get<bool?>(() => DottedProgress);
    /// <summary>Suppress colored console output.</summary>
    [Argument(Format = "--no-color")] public bool? NoColor => Get<bool?>(() => NoColor);
}
#endregion
#region MSpecSettingsExtensions
/// <summary>Used within <see cref="MSpecTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class MSpecSettingsExtensions
{
    #region Assemblies
    /// <inheritdoc cref="MSpecSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Assemblies))]
    public static T SetAssemblies<T>(this T o, params string[] v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.Assemblies, v));
    /// <inheritdoc cref="MSpecSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Assemblies))]
    public static T SetAssemblies<T>(this T o, IEnumerable<string> v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.Assemblies, v));
    /// <inheritdoc cref="MSpecSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Assemblies))]
    public static T AddAssemblies<T>(this T o, params string[] v) where T : MSpecSettings => o.Modify(b => b.AddCollection(() => o.Assemblies, v));
    /// <inheritdoc cref="MSpecSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Assemblies))]
    public static T AddAssemblies<T>(this T o, IEnumerable<string> v) where T : MSpecSettings => o.Modify(b => b.AddCollection(() => o.Assemblies, v));
    /// <inheritdoc cref="MSpecSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Assemblies))]
    public static T RemoveAssemblies<T>(this T o, params string[] v) where T : MSpecSettings => o.Modify(b => b.RemoveCollection(() => o.Assemblies, v));
    /// <inheritdoc cref="MSpecSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Assemblies))]
    public static T RemoveAssemblies<T>(this T o, IEnumerable<string> v) where T : MSpecSettings => o.Modify(b => b.RemoveCollection(() => o.Assemblies, v));
    /// <inheritdoc cref="MSpecSettings.Assemblies"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Assemblies))]
    public static T ClearAssemblies<T>(this T o) where T : MSpecSettings => o.Modify(b => b.ClearCollection(() => o.Assemblies));
    #endregion
    #region Filters
    /// <inheritdoc cref="MSpecSettings.Filters"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Filters))]
    public static T SetFilters<T>(this T o, params string[] v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.Filters, v));
    /// <inheritdoc cref="MSpecSettings.Filters"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Filters))]
    public static T SetFilters<T>(this T o, IEnumerable<string> v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.Filters, v));
    /// <inheritdoc cref="MSpecSettings.Filters"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Filters))]
    public static T AddFilters<T>(this T o, params string[] v) where T : MSpecSettings => o.Modify(b => b.AddCollection(() => o.Filters, v));
    /// <inheritdoc cref="MSpecSettings.Filters"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Filters))]
    public static T AddFilters<T>(this T o, IEnumerable<string> v) where T : MSpecSettings => o.Modify(b => b.AddCollection(() => o.Filters, v));
    /// <inheritdoc cref="MSpecSettings.Filters"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Filters))]
    public static T RemoveFilters<T>(this T o, params string[] v) where T : MSpecSettings => o.Modify(b => b.RemoveCollection(() => o.Filters, v));
    /// <inheritdoc cref="MSpecSettings.Filters"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Filters))]
    public static T RemoveFilters<T>(this T o, IEnumerable<string> v) where T : MSpecSettings => o.Modify(b => b.RemoveCollection(() => o.Filters, v));
    /// <inheritdoc cref="MSpecSettings.Filters"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Filters))]
    public static T ClearFilters<T>(this T o) where T : MSpecSettings => o.Modify(b => b.ClearCollection(() => o.Filters));
    #endregion
    #region Includes
    /// <inheritdoc cref="MSpecSettings.Includes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Includes))]
    public static T SetIncludes<T>(this T o, params string[] v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.Includes, v));
    /// <inheritdoc cref="MSpecSettings.Includes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Includes))]
    public static T SetIncludes<T>(this T o, IEnumerable<string> v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.Includes, v));
    /// <inheritdoc cref="MSpecSettings.Includes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Includes))]
    public static T AddIncludes<T>(this T o, params string[] v) where T : MSpecSettings => o.Modify(b => b.AddCollection(() => o.Includes, v));
    /// <inheritdoc cref="MSpecSettings.Includes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Includes))]
    public static T AddIncludes<T>(this T o, IEnumerable<string> v) where T : MSpecSettings => o.Modify(b => b.AddCollection(() => o.Includes, v));
    /// <inheritdoc cref="MSpecSettings.Includes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Includes))]
    public static T RemoveIncludes<T>(this T o, params string[] v) where T : MSpecSettings => o.Modify(b => b.RemoveCollection(() => o.Includes, v));
    /// <inheritdoc cref="MSpecSettings.Includes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Includes))]
    public static T RemoveIncludes<T>(this T o, IEnumerable<string> v) where T : MSpecSettings => o.Modify(b => b.RemoveCollection(() => o.Includes, v));
    /// <inheritdoc cref="MSpecSettings.Includes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Includes))]
    public static T ClearIncludes<T>(this T o) where T : MSpecSettings => o.Modify(b => b.ClearCollection(() => o.Includes));
    #endregion
    #region Excludes
    /// <inheritdoc cref="MSpecSettings.Excludes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Excludes))]
    public static T SetExcludes<T>(this T o, params string[] v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.Excludes, v));
    /// <inheritdoc cref="MSpecSettings.Excludes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Excludes))]
    public static T SetExcludes<T>(this T o, IEnumerable<string> v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.Excludes, v));
    /// <inheritdoc cref="MSpecSettings.Excludes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Excludes))]
    public static T AddExcludes<T>(this T o, params string[] v) where T : MSpecSettings => o.Modify(b => b.AddCollection(() => o.Excludes, v));
    /// <inheritdoc cref="MSpecSettings.Excludes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Excludes))]
    public static T AddExcludes<T>(this T o, IEnumerable<string> v) where T : MSpecSettings => o.Modify(b => b.AddCollection(() => o.Excludes, v));
    /// <inheritdoc cref="MSpecSettings.Excludes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Excludes))]
    public static T RemoveExcludes<T>(this T o, params string[] v) where T : MSpecSettings => o.Modify(b => b.RemoveCollection(() => o.Excludes, v));
    /// <inheritdoc cref="MSpecSettings.Excludes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Excludes))]
    public static T RemoveExcludes<T>(this T o, IEnumerable<string> v) where T : MSpecSettings => o.Modify(b => b.RemoveCollection(() => o.Excludes, v));
    /// <inheritdoc cref="MSpecSettings.Excludes"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Excludes))]
    public static T ClearExcludes<T>(this T o) where T : MSpecSettings => o.Modify(b => b.ClearCollection(() => o.Excludes));
    #endregion
    #region HtmlOutput
    /// <inheritdoc cref="MSpecSettings.HtmlOutput"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.HtmlOutput))]
    public static T SetHtmlOutput<T>(this T o, string v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.HtmlOutput, v));
    /// <inheritdoc cref="MSpecSettings.HtmlOutput"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.HtmlOutput))]
    public static T ResetHtmlOutput<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Remove(() => o.HtmlOutput));
    #endregion
    #region XmlOutput
    /// <inheritdoc cref="MSpecSettings.XmlOutput"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.XmlOutput))]
    public static T SetXmlOutput<T>(this T o, string v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.XmlOutput, v));
    /// <inheritdoc cref="MSpecSettings.XmlOutput"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.XmlOutput))]
    public static T ResetXmlOutput<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Remove(() => o.XmlOutput));
    #endregion
    #region TeamCity
    /// <inheritdoc cref="MSpecSettings.TeamCity"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.TeamCity))]
    public static T SetTeamCity<T>(this T o, bool? v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.TeamCity, v));
    /// <inheritdoc cref="MSpecSettings.TeamCity"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.TeamCity))]
    public static T ResetTeamCity<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Remove(() => o.TeamCity));
    /// <inheritdoc cref="MSpecSettings.TeamCity"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.TeamCity))]
    public static T EnableTeamCity<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.TeamCity, true));
    /// <inheritdoc cref="MSpecSettings.TeamCity"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.TeamCity))]
    public static T DisableTeamCity<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.TeamCity, false));
    /// <inheritdoc cref="MSpecSettings.TeamCity"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.TeamCity))]
    public static T ToggleTeamCity<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.TeamCity, !o.TeamCity));
    #endregion
    #region NoTeamCity
    /// <inheritdoc cref="MSpecSettings.NoTeamCity"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoTeamCity))]
    public static T SetNoTeamCity<T>(this T o, bool? v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.NoTeamCity, v));
    /// <inheritdoc cref="MSpecSettings.NoTeamCity"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoTeamCity))]
    public static T ResetNoTeamCity<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Remove(() => o.NoTeamCity));
    /// <inheritdoc cref="MSpecSettings.NoTeamCity"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoTeamCity))]
    public static T EnableNoTeamCity<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.NoTeamCity, true));
    /// <inheritdoc cref="MSpecSettings.NoTeamCity"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoTeamCity))]
    public static T DisableNoTeamCity<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.NoTeamCity, false));
    /// <inheritdoc cref="MSpecSettings.NoTeamCity"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoTeamCity))]
    public static T ToggleNoTeamCity<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.NoTeamCity, !o.NoTeamCity));
    #endregion
    #region AppVeyor
    /// <inheritdoc cref="MSpecSettings.AppVeyor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.AppVeyor))]
    public static T SetAppVeyor<T>(this T o, bool? v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.AppVeyor, v));
    /// <inheritdoc cref="MSpecSettings.AppVeyor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.AppVeyor))]
    public static T ResetAppVeyor<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Remove(() => o.AppVeyor));
    /// <inheritdoc cref="MSpecSettings.AppVeyor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.AppVeyor))]
    public static T EnableAppVeyor<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.AppVeyor, true));
    /// <inheritdoc cref="MSpecSettings.AppVeyor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.AppVeyor))]
    public static T DisableAppVeyor<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.AppVeyor, false));
    /// <inheritdoc cref="MSpecSettings.AppVeyor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.AppVeyor))]
    public static T ToggleAppVeyor<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.AppVeyor, !o.AppVeyor));
    #endregion
    #region NoAppVeyor
    /// <inheritdoc cref="MSpecSettings.NoAppVeyor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoAppVeyor))]
    public static T SetNoAppVeyor<T>(this T o, bool? v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.NoAppVeyor, v));
    /// <inheritdoc cref="MSpecSettings.NoAppVeyor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoAppVeyor))]
    public static T ResetNoAppVeyor<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Remove(() => o.NoAppVeyor));
    /// <inheritdoc cref="MSpecSettings.NoAppVeyor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoAppVeyor))]
    public static T EnableNoAppVeyor<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.NoAppVeyor, true));
    /// <inheritdoc cref="MSpecSettings.NoAppVeyor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoAppVeyor))]
    public static T DisableNoAppVeyor<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.NoAppVeyor, false));
    /// <inheritdoc cref="MSpecSettings.NoAppVeyor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoAppVeyor))]
    public static T ToggleNoAppVeyor<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.NoAppVeyor, !o.NoAppVeyor));
    #endregion
    #region TimeInfo
    /// <inheritdoc cref="MSpecSettings.TimeInfo"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.TimeInfo))]
    public static T SetTimeInfo<T>(this T o, bool? v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.TimeInfo, v));
    /// <inheritdoc cref="MSpecSettings.TimeInfo"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.TimeInfo))]
    public static T ResetTimeInfo<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Remove(() => o.TimeInfo));
    /// <inheritdoc cref="MSpecSettings.TimeInfo"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.TimeInfo))]
    public static T EnableTimeInfo<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.TimeInfo, true));
    /// <inheritdoc cref="MSpecSettings.TimeInfo"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.TimeInfo))]
    public static T DisableTimeInfo<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.TimeInfo, false));
    /// <inheritdoc cref="MSpecSettings.TimeInfo"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.TimeInfo))]
    public static T ToggleTimeInfo<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.TimeInfo, !o.TimeInfo));
    #endregion
    #region Silent
    /// <inheritdoc cref="MSpecSettings.Silent"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Silent))]
    public static T SetSilent<T>(this T o, bool? v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.Silent, v));
    /// <inheritdoc cref="MSpecSettings.Silent"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Silent))]
    public static T ResetSilent<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Remove(() => o.Silent));
    /// <inheritdoc cref="MSpecSettings.Silent"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Silent))]
    public static T EnableSilent<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.Silent, true));
    /// <inheritdoc cref="MSpecSettings.Silent"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Silent))]
    public static T DisableSilent<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.Silent, false));
    /// <inheritdoc cref="MSpecSettings.Silent"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.Silent))]
    public static T ToggleSilent<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.Silent, !o.Silent));
    #endregion
    #region DottedProgress
    /// <inheritdoc cref="MSpecSettings.DottedProgress"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.DottedProgress))]
    public static T SetDottedProgress<T>(this T o, bool? v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.DottedProgress, v));
    /// <inheritdoc cref="MSpecSettings.DottedProgress"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.DottedProgress))]
    public static T ResetDottedProgress<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Remove(() => o.DottedProgress));
    /// <inheritdoc cref="MSpecSettings.DottedProgress"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.DottedProgress))]
    public static T EnableDottedProgress<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.DottedProgress, true));
    /// <inheritdoc cref="MSpecSettings.DottedProgress"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.DottedProgress))]
    public static T DisableDottedProgress<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.DottedProgress, false));
    /// <inheritdoc cref="MSpecSettings.DottedProgress"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.DottedProgress))]
    public static T ToggleDottedProgress<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.DottedProgress, !o.DottedProgress));
    #endregion
    #region NoColor
    /// <inheritdoc cref="MSpecSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoColor))]
    public static T SetNoColor<T>(this T o, bool? v) where T : MSpecSettings => o.Modify(b => b.Set(() => o.NoColor, v));
    /// <inheritdoc cref="MSpecSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoColor))]
    public static T ResetNoColor<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Remove(() => o.NoColor));
    /// <inheritdoc cref="MSpecSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoColor))]
    public static T EnableNoColor<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.NoColor, true));
    /// <inheritdoc cref="MSpecSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoColor))]
    public static T DisableNoColor<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.NoColor, false));
    /// <inheritdoc cref="MSpecSettings.NoColor"/>
    [Pure] [Builder(Type = typeof(MSpecSettings), Property = nameof(MSpecSettings.NoColor))]
    public static T ToggleNoColor<T>(this T o) where T : MSpecSettings => o.Modify(b => b.Set(() => o.NoColor, !o.NoColor));
    #endregion
}
#endregion
