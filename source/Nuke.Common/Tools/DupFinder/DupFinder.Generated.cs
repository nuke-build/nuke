// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Auto-generated with Nuke.ToolGenerator.

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
        static partial void PreProcess (DupFinderSettings toolSettings);
        static partial void PostProcess (DupFinderSettings toolSettings);
        /// <summary><p>dupFinder is a free command line tool that finds duplicates in C# and Visual Basic .NET code - no more, no less. But being a JetBrains tool, dupFinder does it in a smart way. By default, it considers code fragments as duplicates not only if they are identical, but also if they are structurally similar, even if they contain different variables, fields, methods, types or literals. Of course, you can configure the allowed similarity as well as the minimum relative size of duplicated fragments.</p><p>For more details, visit the <a href="https://www.jetbrains.com/help/resharper/dupFinder.html">official website</a>.</p></summary>
        public static void DupFinder (Configure<DupFinderSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new DupFinderSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
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
        /// <summary><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p></summary>
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
        /// <summary><p><i>Sets <see cref="DupFinderSettings.Source"/>.</i></p><p>Defines files included into the duplicates search. Use Visual Studio solution or project files, Ant-like wildcards or specific source file and folder names. Paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings SetSource(this DupFinderSettings toolSettings, string source)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Source = source;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.OutputFile"/>.</i></p><p>Lets you set the output file.</p></summary>
        [Pure]
        public static DupFinderSettings SetOutputFile(this DupFinderSettings toolSettings, string outputFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputFile = outputFile;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.ExcludeFiles"/> to a new list.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings SetExcludeFiles(this DupFinderSettings toolSettings, params string[] excludeFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal = excludeFiles.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.ExcludeFiles"/> to a new list.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings SetExcludeFiles(this DupFinderSettings toolSettings, IEnumerable<string> excludeFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal = excludeFiles.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Adds new excludeFiles to the existing <see cref="DupFinderSettings.ExcludeFiles"/>.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeFiles(this DupFinderSettings toolSettings, params string[] excludeFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal.AddRange(excludeFiles);
            return toolSettings;
        }
        /// <summary><p><i>Adds new excludeFiles to the existing <see cref="DupFinderSettings.ExcludeFiles"/>.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeFiles(this DupFinderSettings toolSettings, IEnumerable<string> excludeFiles)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal.AddRange(excludeFiles);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="DupFinderSettings.ExcludeFiles"/>.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings ClearExcludeFiles(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a single excludeFile to <see cref="DupFinderSettings.ExcludeFiles"/>.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeFile(this DupFinderSettings toolSettings, string excludeFile, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (excludeFile != null || evenIfNull) toolSettings.ExcludeFilesInternal.Add(excludeFile);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single excludeFile from <see cref="DupFinderSettings.ExcludeFiles"/>.</i></p><p>Allows excluding files from the duplicates search. Wildcards can be used; for example, <c>*Generated.cs</c>. Note that the paths should be either absolute or relative to the working directory.</p></summary>
        [Pure]
        public static DupFinderSettings RemoveExcludeFile(this DupFinderSettings toolSettings, string excludeFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeFilesInternal.Remove(excludeFile);
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.ExcludeComments"/> to a new list.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings SetExcludeComments(this DupFinderSettings toolSettings, params string[] excludeComments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal = excludeComments.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.ExcludeComments"/> to a new list.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings SetExcludeComments(this DupFinderSettings toolSettings, IEnumerable<string> excludeComments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal = excludeComments.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Adds new excludeComments to the existing <see cref="DupFinderSettings.ExcludeComments"/>.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeComments(this DupFinderSettings toolSettings, params string[] excludeComments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal.AddRange(excludeComments);
            return toolSettings;
        }
        /// <summary><p><i>Adds new excludeComments to the existing <see cref="DupFinderSettings.ExcludeComments"/>.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeComments(this DupFinderSettings toolSettings, IEnumerable<string> excludeComments)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal.AddRange(excludeComments);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="DupFinderSettings.ExcludeComments"/>.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings ClearExcludeComments(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a single excludeComment to <see cref="DupFinderSettings.ExcludeComments"/>.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeComment(this DupFinderSettings toolSettings, string excludeComment, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (excludeComment != null || evenIfNull) toolSettings.ExcludeCommentsInternal.Add(excludeComment);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single excludeComment from <see cref="DupFinderSettings.ExcludeComments"/>.</i></p><p>Allows excluding files that have a matching substrings in the opening comments.</p></summary>
        [Pure]
        public static DupFinderSettings RemoveExcludeComment(this DupFinderSettings toolSettings, string excludeComment)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCommentsInternal.Remove(excludeComment);
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.ExcludeCodeRegions"/> to a new list.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p></summary>
        [Pure]
        public static DupFinderSettings SetExcludeCodeRegions(this DupFinderSettings toolSettings, params string[] excludeCodeRegions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal = excludeCodeRegions.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.ExcludeCodeRegions"/> to a new list.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p></summary>
        [Pure]
        public static DupFinderSettings SetExcludeCodeRegions(this DupFinderSettings toolSettings, IEnumerable<string> excludeCodeRegions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal = excludeCodeRegions.ToList();
            return toolSettings;
        }
        /// <summary><p><i>Adds new excludeCodeRegions to the existing <see cref="DupFinderSettings.ExcludeCodeRegions"/>.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeCodeRegions(this DupFinderSettings toolSettings, params string[] excludeCodeRegions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal.AddRange(excludeCodeRegions);
            return toolSettings;
        }
        /// <summary><p><i>Adds new excludeCodeRegions to the existing <see cref="DupFinderSettings.ExcludeCodeRegions"/>.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeCodeRegions(this DupFinderSettings toolSettings, IEnumerable<string> excludeCodeRegions)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal.AddRange(excludeCodeRegions);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="DupFinderSettings.ExcludeCodeRegions"/>.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p></summary>
        [Pure]
        public static DupFinderSettings ClearExcludeCodeRegions(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a single excludeCodeRegion to <see cref="DupFinderSettings.ExcludeCodeRegions"/>.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p></summary>
        [Pure]
        public static DupFinderSettings AddExcludeCodeRegion(this DupFinderSettings toolSettings, string excludeCodeRegion, bool evenIfNull = true)
        {
            toolSettings = toolSettings.NewInstance();
            if (excludeCodeRegion != null || evenIfNull) toolSettings.ExcludeCodeRegionsInternal.Add(excludeCodeRegion);
            return toolSettings;
        }
        /// <summary><p><i>Removes a single excludeCodeRegion from <see cref="DupFinderSettings.ExcludeCodeRegions"/>.</i></p><p>Allows excluding code regions that have a matching substrings in their names. (e.g. <em>generated code</em> will exclude regions containing <em>Windows Form Designer generated code</em>).</p></summary>
        [Pure]
        public static DupFinderSettings RemoveExcludeCodeRegion(this DupFinderSettings toolSettings, string excludeCodeRegion)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ExcludeCodeRegionsInternal.Remove(excludeCodeRegion);
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.DiscardFields"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings SetDiscardFields(this DupFinderSettings toolSettings, bool discardFields)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = discardFields;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="DupFinderSettings.DiscardFields"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings EnableDiscardFields(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="DupFinderSettings.DiscardFields"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings DisableDiscardFields(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="DupFinderSettings.DiscardFields"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different fields. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings ToggleDiscardFields(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardFields = !toolSettings.DiscardFields;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.DiscardLiterals"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings SetDiscardLiterals(this DupFinderSettings toolSettings, bool discardLiterals)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = discardLiterals;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="DupFinderSettings.DiscardLiterals"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings EnableDiscardLiterals(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="DupFinderSettings.DiscardLiterals"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings DisableDiscardLiterals(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="DupFinderSettings.DiscardLiterals"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different literals. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings ToggleDiscardLiterals(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLiterals = !toolSettings.DiscardLiterals;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.DiscardLocalVars"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings SetDiscardLocalVars(this DupFinderSettings toolSettings, bool discardLocalVars)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = discardLocalVars;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="DupFinderSettings.DiscardLocalVars"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings EnableDiscardLocalVars(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="DupFinderSettings.DiscardLocalVars"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings DisableDiscardLocalVars(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="DupFinderSettings.DiscardLocalVars"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different local variables. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings ToggleDiscardLocalVars(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardLocalVars = !toolSettings.DiscardLocalVars;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.DiscardTypes"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings SetDiscardTypes(this DupFinderSettings toolSettings, bool discardTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = discardTypes;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="DupFinderSettings.DiscardTypes"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings EnableDiscardTypes(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="DupFinderSettings.DiscardTypes"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings DisableDiscardTypes(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="DupFinderSettings.DiscardTypes"/>.</i></p><p>Whether to consider similar fragments as duplicates if they have different types. The default value is <c>false</c>.</p></summary>
        [Pure]
        public static DupFinderSettings ToggleDiscardTypes(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardTypes = !toolSettings.DiscardTypes;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.DiscardCost"/>.</i></p><p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p></summary>
        [Pure]
        public static DupFinderSettings SetDiscardCost(this DupFinderSettings toolSettings, bool discardCost)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardCost = discardCost;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="DupFinderSettings.DiscardCost"/>.</i></p><p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p></summary>
        [Pure]
        public static DupFinderSettings EnableDiscardCost(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardCost = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="DupFinderSettings.DiscardCost"/>.</i></p><p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p></summary>
        [Pure]
        public static DupFinderSettings DisableDiscardCost(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardCost = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="DupFinderSettings.DiscardCost"/>.</i></p><p>Allows setting a threshold for code complexity of the duplicated fragments. The fragments with lower complexity are discarded as non-duplicates. The value for this option is provided in relative units. Using this option, you can filter out equal code fragments that present no semantic duplication. E.g. you can often have the following statements in tests: <c>Assert.AreEqual(gold, result);</c>. If the <c>discard-cost</c> value is less than 10, statements like that will appear as duplicates, which is obviously unhelpful. You'll need to play a bit with this value to find a balance between avoiding false positives and missing real duplicates. The proper values will differ for different codebases.</p></summary>
        [Pure]
        public static DupFinderSettings ToggleDiscardCost(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DiscardCost = !toolSettings.DiscardCost;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.Properties"/> to a new dictionary.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static DupFinderSettings SetProperties(this DupFinderSettings toolSettings, IDictionary<string, string> properties)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary><p><i>Clears <see cref="DupFinderSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static DupFinderSettings ClearProperties(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><i>Adds a property to <see cref="DupFinderSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static DupFinderSettings AddProperty(this DupFinderSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }
        /// <summary><p><i>Removes a property from <see cref="DupFinderSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static DupFinderSettings RemoveProperty(this DupFinderSettings toolSettings, string propertyKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }
        /// <summary><p><i>Sets a property in <see cref="DupFinderSettings.Properties"/>.</i></p><p>Lets you override MSBuild properties. The specified properties are applied to all analyzed projects. Currently, there is no direct way to set a property to a specific project only. The workaround is to create a custom property in this project and assign it to the desired property, then use the custom property in dupFinder parameters.</p></summary>
        [Pure]
        public static DupFinderSettings SetProperty(this DupFinderSettings toolSettings, string propertyKey, string propertyValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.NormalizeTypes"/>.</i></p><p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p></summary>
        [Pure]
        public static DupFinderSettings SetNormalizeTypes(this DupFinderSettings toolSettings, bool normalizeTypes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = normalizeTypes;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="DupFinderSettings.NormalizeTypes"/>.</i></p><p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p></summary>
        [Pure]
        public static DupFinderSettings EnableNormalizeTypes(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="DupFinderSettings.NormalizeTypes"/>.</i></p><p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p></summary>
        [Pure]
        public static DupFinderSettings DisableNormalizeTypes(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="DupFinderSettings.NormalizeTypes"/>.</i></p><p>Allows normalizing type names to the last subtype in the output (default: <c>false</c>).</p></summary>
        [Pure]
        public static DupFinderSettings ToggleNormalizeTypes(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NormalizeTypes = !toolSettings.NormalizeTypes;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.ShowText"/>.</i></p><p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p></summary>
        [Pure]
        public static DupFinderSettings SetShowText(this DupFinderSettings toolSettings, bool showText)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = showText;
            return toolSettings;
        }
        /// <summary><p><i>Enables <see cref="DupFinderSettings.ShowText"/>.</i></p><p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p></summary>
        [Pure]
        public static DupFinderSettings EnableShowText(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = true;
            return toolSettings;
        }
        /// <summary><p><i>Disables <see cref="DupFinderSettings.ShowText"/>.</i></p><p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p></summary>
        [Pure]
        public static DupFinderSettings DisableShowText(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = false;
            return toolSettings;
        }
        /// <summary><p><i>Toggles <see cref="DupFinderSettings.ShowText"/>.</i></p><p>If you use this parameter, the detected duplicate fragments will be embedded into the report.</p></summary>
        [Pure]
        public static DupFinderSettings ToggleShowText(this DupFinderSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowText = !toolSettings.ShowText;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.CreateConfigFile"/>.</i></p><p>Used to save the current parameters to a configuration file.</p></summary>
        [Pure]
        public static DupFinderSettings SetCreateConfigFile(this DupFinderSettings toolSettings, string createConfigFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateConfigFile = createConfigFile;
            return toolSettings;
        }
        /// <summary><p><i>Sets <see cref="DupFinderSettings.ConfigFile"/>.</i></p><p>Used to load the parameters described above from a configuration file.</p></summary>
        [Pure]
        public static DupFinderSettings SetConfigFile(this DupFinderSettings toolSettings, string configFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigFile = configFile;
            return toolSettings;
        }
    }
}
