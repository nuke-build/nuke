using JetBrains.Annotations;
using Nuke.Common.Tools;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Tooling;
using Nuke.Core.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

[assembly: IconClass(typeof(Nuke.Common.Tools.DupFinder.DupFinderTasks), "code")]

namespace Nuke.Common.Tools.DupFinder
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DupFinderTasks
    {
        static partial void PreProcess (DupFinderSettings dupFinderSettings);
        static partial void PostProcess (DupFinderSettings dupFinderSettings);
        /// <summary><p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/dupFinder.html">official website</a>.</p></summary>
        public static void DupFinder (Configure<DupFinderSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var dupFinderSettings = new DupFinderSettings();
            dupFinderSettings = configurator(dupFinderSettings);
            PreProcess(dupFinderSettings);
            var process = ProcessTasks.StartProcess(dupFinderSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(dupFinderSettings);
        }
    }
    /// <summary><p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DupFinderSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"JetBrains.ReSharper.CommandLineTools", packageExecutable: $"dupfinder.exe");
        /// <summary><p>Defines files included into the duplicates search. Use Visual Studio solution or project files, Ant-like wildcards or specific source file and folder names. Paths should be either absolute or relative to the working directory.</p></summary>
        public virtual string Source { get; internal set; }
        /// <summary><p>Lets you set the output file.</p></summary>
        public virtual string OutputFile { get; internal set; }
        /// <summary><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        public virtual IReadOnlyList<string> ExcludeFiles => ExcludeFilesInternal.AsReadOnly();
        internal List<string> ExcludeFilesInternal { get; set; } = new List<string>();
        /// <summary><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        public virtual IReadOnlyList<string> ExcludeComments => ExcludeCommentsInternal.AsReadOnly();
        internal List<string> ExcludeCommentsInternal { get; set; } = new List<string>();
        /// <summary><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <i>generated code</i> will exclude regions containing <i>Windows Form Designer generated code</i>).</p></summary>
        public virtual IReadOnlyList<string> ExcludeCodeRegions => ExcludeCodeRegionsInternal.AsReadOnly();
        internal List<string> ExcludeCodeRegionsInternal { get; set; } = new List<string>();
        /// <summary><p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p></summary>
        public virtual bool DiscardFields { get; internal set; }
        /// <summary><p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p></summary>
        public virtual bool DiscardLiterals { get; internal set; }
        /// <summary><p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p></summary>
        public virtual bool DiscardLocalVars { get; internal set; }
        /// <summary><p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p></summary>
        public virtual bool DiscardTypes { get; internal set; }
        /// <summary><p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p></summary>
        public virtual bool DiscardCost { get; internal set; }
        /// <summary><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        public virtual IReadOnlyDictionary<string, string> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, string> PropertiesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        /// <summary><p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p></summary>
        public virtual bool NormalizeTypes { get; internal set; }
        /// <summary><p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p></summary>
        public virtual bool ShowText { get; internal set; }
        /// <summary><p>Used to save the current parameters to a configuration file.</p></summary>
        public virtual string CreateConfigFile { get; internal set; }
        /// <summary><p>Used to load the parameters described above from a configuration file.</p></summary>
        public virtual string ConfigFile { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("{value}", Source)
              .Add("--output={value}", OutputFile)
              .Add("--exclude={value}", ExcludeFiles, mainSeparator: $";")
              .Add("--exclude-by-comment={value}", ExcludeComments, mainSeparator: $";")
              .Add("--exclude-code-regions={value}", ExcludeCodeRegions, mainSeparator: $";")
              .Add("--discard-fields={value}", DiscardFields)
              .Add("--discard-literals={value}", DiscardLiterals)
              .Add("--discard-local-vars={value}", DiscardLocalVars)
              .Add("--discard-types={value}", DiscardTypes)
              .Add("--discard-cost={value}", DiscardCost)
              .Add("--properties:{value}", Properties, keyValueSeparator: $"=")
              .Add("--normalize-types={value}", NormalizeTypes)
              .Add("--show-text={value}", ShowText)
              .Add("--config-create={value}", CreateConfigFile)
              .Add("--config={value}", ConfigFile);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DupFinderSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.Source"/>.</i></p><p>Defines files included into the duplicates search. Use Visual Studio solution or project files, Ant-like wildcards or specific source file and folder names. Paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings SetSource(this DupFinderSettings dupFinderSettings, string source)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.Source = source;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.OutputFile"/>.</i></p><p>Lets you set the output file.</p></summary>
        [Pure]
        public static DupFinderSettings SetOutputFile(this DupFinderSettings dupFinderSettings, string outputFile)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.OutputFile = outputFile;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.ExcludeFiles"/> to a new list.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings SetExcludeFiles(this DupFinderSettings dupFinderSettings, params string[] excludeFiles)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeFilesInternal = excludeFiles.ToList();
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.ExcludeFiles"/> to a new list.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings SetExcludeFiles(this DupFinderSettings dupFinderSettings, IEnumerable<string> excludeFiles)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeFilesInternal = excludeFiles.ToList();
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeFiles to the existing <see cref="DupFinderSettings.ExcludeFiles"/>.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeFiles(this DupFinderSettings dupFinderSettings, params string[] excludeFiles)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeFilesInternal.AddRange(excludeFiles);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeFiles to the existing <see cref="DupFinderSettings.ExcludeFiles"/>.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeFiles(this DupFinderSettings dupFinderSettings, IEnumerable<string> excludeFiles)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeFilesInternal.AddRange(excludeFiles);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DupFinderSettings.ExcludeFiles"/>.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings ClearExcludeFiles(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeFilesInternal.Clear();
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for adding a single excludeFile to <see cref="DupFinderSettings.ExcludeFiles"/>.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeFile(this DupFinderSettings dupFinderSettings, string excludeFile)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeFilesInternal.Add(excludeFile);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for removing a single excludeFile from <see cref="DupFinderSettings.ExcludeFiles"/>.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings RemoveExcludeFile(this DupFinderSettings dupFinderSettings, string excludeFile)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeFilesInternal.Remove(excludeFile);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.ExcludeComments"/> to a new list.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings SetExcludeComments(this DupFinderSettings dupFinderSettings, params string[] excludeComments)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCommentsInternal = excludeComments.ToList();
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.ExcludeComments"/> to a new list.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings SetExcludeComments(this DupFinderSettings dupFinderSettings, IEnumerable<string> excludeComments)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCommentsInternal = excludeComments.ToList();
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeComments to the existing <see cref="DupFinderSettings.ExcludeComments"/>.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeComments(this DupFinderSettings dupFinderSettings, params string[] excludeComments)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCommentsInternal.AddRange(excludeComments);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeComments to the existing <see cref="DupFinderSettings.ExcludeComments"/>.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeComments(this DupFinderSettings dupFinderSettings, IEnumerable<string> excludeComments)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCommentsInternal.AddRange(excludeComments);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DupFinderSettings.ExcludeComments"/>.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings ClearExcludeComments(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCommentsInternal.Clear();
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for adding a single excludeComment to <see cref="DupFinderSettings.ExcludeComments"/>.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeComment(this DupFinderSettings dupFinderSettings, string excludeComment)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCommentsInternal.Add(excludeComment);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for removing a single excludeComment from <see cref="DupFinderSettings.ExcludeComments"/>.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings RemoveExcludeComment(this DupFinderSettings dupFinderSettings, string excludeComment)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCommentsInternal.Remove(excludeComment);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.ExcludeCodeRegions"/> to a new list.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <i>generated code</i> will exclude regions containing <i>Windows Form Designer generated code</i>).</p></summary>
        [Pure]
        public static DupFinderSettings SetExcludeCodeRegions(this DupFinderSettings dupFinderSettings, params string[] excludeCodeRegions)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCodeRegionsInternal = excludeCodeRegions.ToList();
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.ExcludeCodeRegions"/> to a new list.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <i>generated code</i> will exclude regions containing <i>Windows Form Designer generated code</i>).</p></summary>
        [Pure]
        public static DupFinderSettings SetExcludeCodeRegions(this DupFinderSettings dupFinderSettings, IEnumerable<string> excludeCodeRegions)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCodeRegionsInternal = excludeCodeRegions.ToList();
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeCodeRegions to the existing <see cref="DupFinderSettings.ExcludeCodeRegions"/>.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <i>generated code</i> will exclude regions containing <i>Windows Form Designer generated code</i>).</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeCodeRegions(this DupFinderSettings dupFinderSettings, params string[] excludeCodeRegions)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCodeRegionsInternal.AddRange(excludeCodeRegions);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for adding new excludeCodeRegions to the existing <see cref="DupFinderSettings.ExcludeCodeRegions"/>.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <i>generated code</i> will exclude regions containing <i>Windows Form Designer generated code</i>).</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeCodeRegions(this DupFinderSettings dupFinderSettings, IEnumerable<string> excludeCodeRegions)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCodeRegionsInternal.AddRange(excludeCodeRegions);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DupFinderSettings.ExcludeCodeRegions"/>.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <i>generated code</i> will exclude regions containing <i>Windows Form Designer generated code</i>).</p></summary>
        [Pure]
        public static DupFinderSettings ClearExcludeCodeRegions(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCodeRegionsInternal.Clear();
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for adding a single excludeCodeRegion to <see cref="DupFinderSettings.ExcludeCodeRegions"/>.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <i>generated code</i> will exclude regions containing <i>Windows Form Designer generated code</i>).</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeCodeRegion(this DupFinderSettings dupFinderSettings, string excludeCodeRegion)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCodeRegionsInternal.Add(excludeCodeRegion);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for removing a single excludeCodeRegion from <see cref="DupFinderSettings.ExcludeCodeRegions"/>.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <i>generated code</i> will exclude regions containing <i>Windows Form Designer generated code</i>).</p></summary>
        [Pure]
        public static DupFinderSettings RemoveExcludeCodeRegion(this DupFinderSettings dupFinderSettings, string excludeCodeRegion)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ExcludeCodeRegionsInternal.Remove(excludeCodeRegion);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.DiscardFields"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings SetDiscardFields(this DupFinderSettings dupFinderSettings, bool discardFields)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardFields = discardFields;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DupFinderSettings.DiscardFields"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings EnableDiscardFields(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardFields = true;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DupFinderSettings.DiscardFields"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings DisableDiscardFields(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardFields = false;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DupFinderSettings.DiscardFields"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings ToggleDiscardFields(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardFields = !dupFinderSettings.DiscardFields;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.DiscardLiterals"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings SetDiscardLiterals(this DupFinderSettings dupFinderSettings, bool discardLiterals)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardLiterals = discardLiterals;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DupFinderSettings.DiscardLiterals"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings EnableDiscardLiterals(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardLiterals = true;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DupFinderSettings.DiscardLiterals"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings DisableDiscardLiterals(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardLiterals = false;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DupFinderSettings.DiscardLiterals"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings ToggleDiscardLiterals(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardLiterals = !dupFinderSettings.DiscardLiterals;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.DiscardLocalVars"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings SetDiscardLocalVars(this DupFinderSettings dupFinderSettings, bool discardLocalVars)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardLocalVars = discardLocalVars;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DupFinderSettings.DiscardLocalVars"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings EnableDiscardLocalVars(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardLocalVars = true;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DupFinderSettings.DiscardLocalVars"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings DisableDiscardLocalVars(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardLocalVars = false;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DupFinderSettings.DiscardLocalVars"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings ToggleDiscardLocalVars(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardLocalVars = !dupFinderSettings.DiscardLocalVars;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.DiscardTypes"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings SetDiscardTypes(this DupFinderSettings dupFinderSettings, bool discardTypes)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardTypes = discardTypes;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DupFinderSettings.DiscardTypes"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings EnableDiscardTypes(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardTypes = true;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DupFinderSettings.DiscardTypes"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings DisableDiscardTypes(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardTypes = false;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DupFinderSettings.DiscardTypes"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings ToggleDiscardTypes(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardTypes = !dupFinderSettings.DiscardTypes;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.DiscardCost"/>.</i></p><p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p></summary>
        [Pure]
        public static DupFinderSettings SetDiscardCost(this DupFinderSettings dupFinderSettings, bool discardCost)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardCost = discardCost;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DupFinderSettings.DiscardCost"/>.</i></p><p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p></summary>
        [Pure]
        public static DupFinderSettings EnableDiscardCost(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardCost = true;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DupFinderSettings.DiscardCost"/>.</i></p><p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p></summary>
        [Pure]
        public static DupFinderSettings DisableDiscardCost(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardCost = false;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DupFinderSettings.DiscardCost"/>.</i></p><p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p></summary>
        [Pure]
        public static DupFinderSettings ToggleDiscardCost(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.DiscardCost = !dupFinderSettings.DiscardCost;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.Properties"/> to a new dictionary.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static DupFinderSettings SetProperties(this DupFinderSettings dupFinderSettings, IDictionary<string, string> properties)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for clearing <see cref="DupFinderSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static DupFinderSettings ClearProperties(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.PropertiesInternal.Clear();
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for adding a property to <see cref="DupFinderSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static DupFinderSettings AddProperty(this DupFinderSettings dupFinderSettings, string propertyKey, string propertyValue)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for removing a property from <see cref="DupFinderSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static DupFinderSettings RemoveProperty(this DupFinderSettings dupFinderSettings, string propertyKey)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.PropertiesInternal.Remove(propertyKey);
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting a property in <see cref="DupFinderSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static DupFinderSettings SetProperty(this DupFinderSettings dupFinderSettings, string propertyKey, string propertyValue)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.PropertiesInternal[propertyKey] = propertyValue;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.NormalizeTypes"/>.</i></p><p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p></summary>
        [Pure]
        public static DupFinderSettings SetNormalizeTypes(this DupFinderSettings dupFinderSettings, bool normalizeTypes)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.NormalizeTypes = normalizeTypes;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DupFinderSettings.NormalizeTypes"/>.</i></p><p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p></summary>
        [Pure]
        public static DupFinderSettings EnableNormalizeTypes(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.NormalizeTypes = true;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DupFinderSettings.NormalizeTypes"/>.</i></p><p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p></summary>
        [Pure]
        public static DupFinderSettings DisableNormalizeTypes(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.NormalizeTypes = false;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DupFinderSettings.NormalizeTypes"/>.</i></p><p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p></summary>
        [Pure]
        public static DupFinderSettings ToggleNormalizeTypes(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.NormalizeTypes = !dupFinderSettings.NormalizeTypes;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.ShowText"/>.</i></p><p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p></summary>
        [Pure]
        public static DupFinderSettings SetShowText(this DupFinderSettings dupFinderSettings, bool showText)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ShowText = showText;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for enabling <see cref="DupFinderSettings.ShowText"/>.</i></p><p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p></summary>
        [Pure]
        public static DupFinderSettings EnableShowText(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ShowText = true;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for disabling <see cref="DupFinderSettings.ShowText"/>.</i></p><p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p></summary>
        [Pure]
        public static DupFinderSettings DisableShowText(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ShowText = false;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for toggling <see cref="DupFinderSettings.ShowText"/>.</i></p><p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p></summary>
        [Pure]
        public static DupFinderSettings ToggleShowText(this DupFinderSettings dupFinderSettings)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ShowText = !dupFinderSettings.ShowText;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.CreateConfigFile"/>.</i></p><p>Used to save the current parameters to a configuration file.</p></summary>
        [Pure]
        public static DupFinderSettings SetCreateConfigFile(this DupFinderSettings dupFinderSettings, string createConfigFile)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.CreateConfigFile = createConfigFile;
            return dupFinderSettings;
        }
        /// <summary><p><i>Extension method for setting <see cref="DupFinderSettings.ConfigFile"/>.</i></p><p>Used to load the parameters described above from a configuration file.</p></summary>
        [Pure]
        public static DupFinderSettings SetConfigFile(this DupFinderSettings dupFinderSettings, string configFile)
        {
            dupFinderSettings = dupFinderSettings.NewInstance();
            dupFinderSettings.ConfigFile = configFile;
            return dupFinderSettings;
        }
    }
}
