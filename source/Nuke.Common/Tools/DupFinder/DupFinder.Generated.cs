// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/DupFinder.json

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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.Tools.DupFinder
{
    /// <summary>
    ///   <p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p>
    ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/dupFinder.html">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DupFinderTasks
    {
        /// <summary>
        ///   Path to the DupFinder executable.
        /// </summary>
        public static string DupFinderPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("DUPFINDER_EXE") ??
            ToolPathResolver.GetPackageExecutable("JetBrains.ReSharper.CommandLineTools", "dupfinder.exe");
        public static Action<OutputType, string> DupFinderLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/dupFinder.html">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> DupFinder(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, bool? logTimestamp = null, string logFile = null, Func<string, string> outputFilter = null)
        {
            using var process = ProcessTasks.StartProcess(DupFinderPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logTimestamp, logFile, DupFinderLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/dupFinder.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;source&gt;</c> via <see cref="DupFinderSettings.Source"/></li>
        ///     <li><c>--config</c> via <see cref="DupFinderSettings.ConfigFile"/></li>
        ///     <li><c>--config-create</c> via <see cref="DupFinderSettings.CreateConfigFile"/></li>
        ///     <li><c>--discard-cost</c> via <see cref="DupFinderSettings.DiscardCost"/></li>
        ///     <li><c>--discard-fields</c> via <see cref="DupFinderSettings.DiscardFields"/></li>
        ///     <li><c>--discard-literals</c> via <see cref="DupFinderSettings.DiscardLiterals"/></li>
        ///     <li><c>--discard-local-vars</c> via <see cref="DupFinderSettings.DiscardLocalVars"/></li>
        ///     <li><c>--discard-types</c> via <see cref="DupFinderSettings.DiscardTypes"/></li>
        ///     <li><c>--exclude</c> via <see cref="DupFinderSettings.ExcludeFiles"/></li>
        ///     <li><c>--exclude-by-comment</c> via <see cref="DupFinderSettings.ExcludeComments"/></li>
        ///     <li><c>--exclude-code-regions</c> via <see cref="DupFinderSettings.ExcludeCodeRegions"/></li>
        ///     <li><c>--normalize-types</c> via <see cref="DupFinderSettings.NormalizeTypes"/></li>
        ///     <li><c>--output</c> via <see cref="DupFinderSettings.OutputFile"/></li>
        ///     <li><c>--properties</c> via <see cref="DupFinderSettings.Properties"/></li>
        ///     <li><c>--show-text</c> via <see cref="DupFinderSettings.ShowText"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DupFinder(DupFinderSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DupFinderSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/dupFinder.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;source&gt;</c> via <see cref="DupFinderSettings.Source"/></li>
        ///     <li><c>--config</c> via <see cref="DupFinderSettings.ConfigFile"/></li>
        ///     <li><c>--config-create</c> via <see cref="DupFinderSettings.CreateConfigFile"/></li>
        ///     <li><c>--discard-cost</c> via <see cref="DupFinderSettings.DiscardCost"/></li>
        ///     <li><c>--discard-fields</c> via <see cref="DupFinderSettings.DiscardFields"/></li>
        ///     <li><c>--discard-literals</c> via <see cref="DupFinderSettings.DiscardLiterals"/></li>
        ///     <li><c>--discard-local-vars</c> via <see cref="DupFinderSettings.DiscardLocalVars"/></li>
        ///     <li><c>--discard-types</c> via <see cref="DupFinderSettings.DiscardTypes"/></li>
        ///     <li><c>--exclude</c> via <see cref="DupFinderSettings.ExcludeFiles"/></li>
        ///     <li><c>--exclude-by-comment</c> via <see cref="DupFinderSettings.ExcludeComments"/></li>
        ///     <li><c>--exclude-code-regions</c> via <see cref="DupFinderSettings.ExcludeCodeRegions"/></li>
        ///     <li><c>--normalize-types</c> via <see cref="DupFinderSettings.NormalizeTypes"/></li>
        ///     <li><c>--output</c> via <see cref="DupFinderSettings.OutputFile"/></li>
        ///     <li><c>--properties</c> via <see cref="DupFinderSettings.Properties"/></li>
        ///     <li><c>--show-text</c> via <see cref="DupFinderSettings.ShowText"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> DupFinder(Configure<DupFinderSettings> configurator)
        {
            return DupFinder(configurator(new DupFinderSettings()));
        }
        /// <summary>
        ///   <p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p>
        ///   <p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/dupFinder.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;source&gt;</c> via <see cref="DupFinderSettings.Source"/></li>
        ///     <li><c>--config</c> via <see cref="DupFinderSettings.ConfigFile"/></li>
        ///     <li><c>--config-create</c> via <see cref="DupFinderSettings.CreateConfigFile"/></li>
        ///     <li><c>--discard-cost</c> via <see cref="DupFinderSettings.DiscardCost"/></li>
        ///     <li><c>--discard-fields</c> via <see cref="DupFinderSettings.DiscardFields"/></li>
        ///     <li><c>--discard-literals</c> via <see cref="DupFinderSettings.DiscardLiterals"/></li>
        ///     <li><c>--discard-local-vars</c> via <see cref="DupFinderSettings.DiscardLocalVars"/></li>
        ///     <li><c>--discard-types</c> via <see cref="DupFinderSettings.DiscardTypes"/></li>
        ///     <li><c>--exclude</c> via <see cref="DupFinderSettings.ExcludeFiles"/></li>
        ///     <li><c>--exclude-by-comment</c> via <see cref="DupFinderSettings.ExcludeComments"/></li>
        ///     <li><c>--exclude-code-regions</c> via <see cref="DupFinderSettings.ExcludeCodeRegions"/></li>
        ///     <li><c>--normalize-types</c> via <see cref="DupFinderSettings.NormalizeTypes"/></li>
        ///     <li><c>--output</c> via <see cref="DupFinderSettings.OutputFile"/></li>
        ///     <li><c>--properties</c> via <see cref="DupFinderSettings.Properties"/></li>
        ///     <li><c>--show-text</c> via <see cref="DupFinderSettings.ShowText"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(DupFinderSettings Settings, IReadOnlyCollection<Output> Output)> DupFinder(CombinatorialConfigure<DupFinderSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DupFinder, DupFinderLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region DupFinderSettings
    /// <summary>
    ///   Used within <see cref="DupFinderTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DupFinderSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the DupFinder executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? DupFinderTasks.DupFinderPath;
        public override Action<OutputType, string> CustomLogger => DupFinderTasks.DupFinderLogger;
        /// <summary>
        ///   Defines files included into the duplicates search. Use Visual Studio solution or project files, Ant-like wildcards or specific source file and folder names. Paths should be either absolute or relative to the working directory.
        /// </summary>
        public virtual string Source { get; internal set; }
        /// <summary>
        ///   Lets you set the output file.
        /// </summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary>
        ///   Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.
        /// </summary>
        public virtual IReadOnlyList<string> ExcludeFiles => ExcludeFilesInternal.AsReadOnly();
        internal List<string> ExcludeFilesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Allows excluding files that have a matching substrings in the opening comments.
        /// </summary>
        public virtual IReadOnlyList<string> ExcludeComments => ExcludeCommentsInternal.AsReadOnly();
        internal List<string> ExcludeCommentsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).
        /// </summary>
        public virtual IReadOnlyList<string> ExcludeCodeRegions => ExcludeCodeRegionsInternal.AsReadOnly();
        internal List<string> ExcludeCodeRegionsInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.
        /// </summary>
        public virtual bool? DiscardFields { get; internal set; }
        /// <summary>
        ///   Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.
        /// </summary>
        public virtual bool? DiscardLiterals { get; internal set; }
        /// <summary>
        ///   Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.
        /// </summary>
        public virtual bool? DiscardLocalVars { get; internal set; }
        /// <summary>
        ///   Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.
        /// </summary>
        public virtual bool? DiscardTypes { get; internal set; }
        /// <summary>
        ///   Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.
        /// </summary>
        public virtual int? DiscardCost { get; internal set; }
        /// <summary>
        ///   Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Allows normalizing type names to the last subtype in the output (default: <c>false</c>).
        /// </summary>
        public virtual bool? NormalizeTypes { get; internal set; }
        /// <summary>
        ///   If you use this parameter, the detected duplicate fragments will be embedded into the report.
        /// </summary>
        public virtual bool? ShowText { get; internal set; }
        /// <summary>
        ///   Used to save the current parameters to a configuration file.
        /// </summary>
        public virtual string CreateConfigFile { get; internal set; }
        /// <summary>
        ///   Used to load the parameters described above from a configuration file.
        /// </summary>
        public virtual string ConfigFile { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("{value}", Source)
              .Add("--output={value}", OutputFile)
              .Add("--exclude={value}", ExcludeFiles, separator: ';')
              .Add("--exclude-by-comment={value}", ExcludeComments, separator: ';')
              .Add("--exclude-code-regions={value}", ExcludeCodeRegions, separator: ';')
              .Add("--discard-fields={value}", DiscardFields)
              .Add("--discard-literals={value}", DiscardLiterals)
              .Add("--discard-local-vars={value}", DiscardLocalVars)
              .Add("--discard-types={value}", DiscardTypes)
              .Add("--discard-cost={value}", DiscardCost)
              .Add("--properties:{value}", Properties, "{key}={value}")
              .Add("--normalize-types={value}", NormalizeTypes)
              .Add("--show-text={value}", ShowText)
              .Add("--config-create={value}", CreateConfigFile)
              .Add("--config={value}", ConfigFile);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DupFinderSettingsExtensions
    /// <summary>
    ///   Used within <see cref="DupFinderTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DupFinderSettingsExtensions
    {
        #region Source
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.Source"/></em></p>
        ///   <p>Defines files included into the duplicates search. Use Visual Studio solution or project files, Ant-like wildcards or specific source file and folder names. Paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T SetSource<T>(this T toolSettings, string source) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DupFinderSettings.Source"/></em></p>
        ///   <p>Defines files included into the duplicates search. Use Visual Studio solution or project files, Ant-like wildcards or specific source file and folder names. Paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T ResetSource<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = null;
            return toolSettings;
        }
        #endregion
        #region OutputFile
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.OutputFile"/></em></p>
        ///   <p>Lets you set the output file.</p>
        /// </summary>
        [Pure]
        public static T SetOutputFile<T>(this T toolSettings, string outputFile) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DupFinderSettings.OutputFile"/></em></p>
        ///   <p>Lets you set the output file.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputFile<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = null;
            return toolSettings;
        }
        #endregion
        #region ExcludeFiles
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.ExcludeFiles"/> to a new list</em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeFiles<T>(this T toolSettings, params string[] excludeFiles) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal = excludeFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.ExcludeFiles"/> to a new list</em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeFiles<T>(this T toolSettings, IEnumerable<string> excludeFiles) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal = excludeFiles.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DupFinderSettings.ExcludeFiles"/></em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeFiles<T>(this T toolSettings, params string[] excludeFiles) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal.AddRange(excludeFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DupFinderSettings.ExcludeFiles"/></em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeFiles<T>(this T toolSettings, IEnumerable<string> excludeFiles) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal.AddRange(excludeFiles);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DupFinderSettings.ExcludeFiles"/></em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T ClearExcludeFiles<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DupFinderSettings.ExcludeFiles"/></em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeFiles<T>(this T toolSettings, params string[] excludeFiles) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeFiles);
            toolSettings.ExcludeFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DupFinderSettings.ExcludeFiles"/></em></p>
        ///   <p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeFiles<T>(this T toolSettings, IEnumerable<string> excludeFiles) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeFiles);
            toolSettings.ExcludeFilesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExcludeComments
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.ExcludeComments"/> to a new list</em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeComments<T>(this T toolSettings, params string[] excludeComments) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal = excludeComments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.ExcludeComments"/> to a new list</em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T SetExcludeComments<T>(this T toolSettings, IEnumerable<string> excludeComments) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal = excludeComments.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DupFinderSettings.ExcludeComments"/></em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeComments<T>(this T toolSettings, params string[] excludeComments) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal.AddRange(excludeComments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DupFinderSettings.ExcludeComments"/></em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T AddExcludeComments<T>(this T toolSettings, IEnumerable<string> excludeComments) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal.AddRange(excludeComments);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DupFinderSettings.ExcludeComments"/></em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T ClearExcludeComments<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DupFinderSettings.ExcludeComments"/></em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeComments<T>(this T toolSettings, params string[] excludeComments) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeComments);
            toolSettings.ExcludeCommentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DupFinderSettings.ExcludeComments"/></em></p>
        ///   <p>Allows excluding files that have a matching substrings in the opening comments.</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeComments<T>(this T toolSettings, IEnumerable<string> excludeComments) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeComments);
            toolSettings.ExcludeCommentsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region ExcludeCodeRegions
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.ExcludeCodeRegions"/> to a new list</em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T SetExcludeCodeRegions<T>(this T toolSettings, params string[] excludeCodeRegions) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal = excludeCodeRegions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.ExcludeCodeRegions"/> to a new list</em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T SetExcludeCodeRegions<T>(this T toolSettings, IEnumerable<string> excludeCodeRegions) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal = excludeCodeRegions.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DupFinderSettings.ExcludeCodeRegions"/></em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T AddExcludeCodeRegions<T>(this T toolSettings, params string[] excludeCodeRegions) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal.AddRange(excludeCodeRegions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="DupFinderSettings.ExcludeCodeRegions"/></em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T AddExcludeCodeRegions<T>(this T toolSettings, IEnumerable<string> excludeCodeRegions) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal.AddRange(excludeCodeRegions);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DupFinderSettings.ExcludeCodeRegions"/></em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T ClearExcludeCodeRegions<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DupFinderSettings.ExcludeCodeRegions"/></em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeCodeRegions<T>(this T toolSettings, params string[] excludeCodeRegions) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeCodeRegions);
            toolSettings.ExcludeCodeRegionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="DupFinderSettings.ExcludeCodeRegions"/></em></p>
        ///   <p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p>
        /// </summary>
        [Pure]
        public static T RemoveExcludeCodeRegions<T>(this T toolSettings, IEnumerable<string> excludeCodeRegions) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(excludeCodeRegions);
            toolSettings.ExcludeCodeRegionsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region DiscardFields
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.DiscardFields"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDiscardFields<T>(this T toolSettings, bool? discardFields) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = discardFields;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DupFinderSettings.DiscardFields"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDiscardFields<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DupFinderSettings.DiscardFields"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableDiscardFields<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DupFinderSettings.DiscardFields"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableDiscardFields<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DupFinderSettings.DiscardFields"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDiscardFields<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = !toolSettings.DiscardFields;
            return toolSettings;
        }
        #endregion
        #region DiscardLiterals
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.DiscardLiterals"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDiscardLiterals<T>(this T toolSettings, bool? discardLiterals) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = discardLiterals;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DupFinderSettings.DiscardLiterals"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDiscardLiterals<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DupFinderSettings.DiscardLiterals"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableDiscardLiterals<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DupFinderSettings.DiscardLiterals"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableDiscardLiterals<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DupFinderSettings.DiscardLiterals"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDiscardLiterals<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = !toolSettings.DiscardLiterals;
            return toolSettings;
        }
        #endregion
        #region DiscardLocalVars
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.DiscardLocalVars"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDiscardLocalVars<T>(this T toolSettings, bool? discardLocalVars) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = discardLocalVars;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DupFinderSettings.DiscardLocalVars"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDiscardLocalVars<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DupFinderSettings.DiscardLocalVars"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableDiscardLocalVars<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DupFinderSettings.DiscardLocalVars"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableDiscardLocalVars<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DupFinderSettings.DiscardLocalVars"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDiscardLocalVars<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = !toolSettings.DiscardLocalVars;
            return toolSettings;
        }
        #endregion
        #region DiscardTypes
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.DiscardTypes"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T SetDiscardTypes<T>(this T toolSettings, bool? discardTypes) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = discardTypes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DupFinderSettings.DiscardTypes"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetDiscardTypes<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DupFinderSettings.DiscardTypes"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableDiscardTypes<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DupFinderSettings.DiscardTypes"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableDiscardTypes<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DupFinderSettings.DiscardTypes"/></em></p>
        ///   <p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleDiscardTypes<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = !toolSettings.DiscardTypes;
            return toolSettings;
        }
        #endregion
        #region DiscardCost
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.DiscardCost"/></em></p>
        ///   <p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p>
        /// </summary>
        [Pure]
        public static T SetDiscardCost<T>(this T toolSettings, int? discardCost) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardCost = discardCost;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DupFinderSettings.DiscardCost"/></em></p>
        ///   <p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p>
        /// </summary>
        [Pure]
        public static T ResetDiscardCost<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardCost = null;
            return toolSettings;
        }
        #endregion
        #region Properties
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.Properties"/> to a new dictionary</em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, string> properties) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="DupFinderSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="DupFinderSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, string propertyValue) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="DupFinderSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="DupFinderSettings.Properties"/></em></p>
        ///   <p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, string propertyValue) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        #endregion
        #region NormalizeTypes
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.NormalizeTypes"/></em></p>
        ///   <p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p>
        /// </summary>
        [Pure]
        public static T SetNormalizeTypes<T>(this T toolSettings, bool? normalizeTypes) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = normalizeTypes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DupFinderSettings.NormalizeTypes"/></em></p>
        ///   <p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p>
        /// </summary>
        [Pure]
        public static T ResetNormalizeTypes<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DupFinderSettings.NormalizeTypes"/></em></p>
        ///   <p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p>
        /// </summary>
        [Pure]
        public static T EnableNormalizeTypes<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DupFinderSettings.NormalizeTypes"/></em></p>
        ///   <p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p>
        /// </summary>
        [Pure]
        public static T DisableNormalizeTypes<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DupFinderSettings.NormalizeTypes"/></em></p>
        ///   <p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p>
        /// </summary>
        [Pure]
        public static T ToggleNormalizeTypes<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = !toolSettings.NormalizeTypes;
            return toolSettings;
        }
        #endregion
        #region ShowText
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.ShowText"/></em></p>
        ///   <p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p>
        /// </summary>
        [Pure]
        public static T SetShowText<T>(this T toolSettings, bool? showText) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = showText;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DupFinderSettings.ShowText"/></em></p>
        ///   <p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p>
        /// </summary>
        [Pure]
        public static T ResetShowText<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="DupFinderSettings.ShowText"/></em></p>
        ///   <p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p>
        /// </summary>
        [Pure]
        public static T EnableShowText<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="DupFinderSettings.ShowText"/></em></p>
        ///   <p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p>
        /// </summary>
        [Pure]
        public static T DisableShowText<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="DupFinderSettings.ShowText"/></em></p>
        ///   <p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p>
        /// </summary>
        [Pure]
        public static T ToggleShowText<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = !toolSettings.ShowText;
            return toolSettings;
        }
        #endregion
        #region CreateConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.CreateConfigFile"/></em></p>
        ///   <p>Used to save the current parameters to a configuration file.</p>
        /// </summary>
        [Pure]
        public static T SetCreateConfigFile<T>(this T toolSettings, string createConfigFile) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateConfigFile = createConfigFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DupFinderSettings.CreateConfigFile"/></em></p>
        ///   <p>Used to save the current parameters to a configuration file.</p>
        /// </summary>
        [Pure]
        public static T ResetCreateConfigFile<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateConfigFile = null;
            return toolSettings;
        }
        #endregion
        #region ConfigFile
        /// <summary>
        ///   <p><em>Sets <see cref="DupFinderSettings.ConfigFile"/></em></p>
        ///   <p>Used to load the parameters described above from a configuration file.</p>
        /// </summary>
        [Pure]
        public static T SetConfigFile<T>(this T toolSettings, string configFile) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="DupFinderSettings.ConfigFile"/></em></p>
        ///   <p>Used to load the parameters described above from a configuration file.</p>
        /// </summary>
        [Pure]
        public static T ResetConfigFile<T>(this T toolSettings) where T : DupFinderSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
