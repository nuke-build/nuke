// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// Generated from https://github.com/nuke-build/tools/blob/master/DocFx.json with Nuke.ToolGenerator.

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

namespace Nuke.Common.Tools.DocFx
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFxTasks
    {
        static partial void PreProcess (DocFxMetadataSettings toolSettings);
        static partial void PostProcess (DocFxMetadataSettings toolSettings);
        /// <summary><p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <em>github.io</em>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
        public static void DocFxMetadata (Configure<DocFxMetadataSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new DocFxMetadataSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <em>github.io</em>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
        public static void DocFxMetadata (string configPath, Configure<DocFxMetadataSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DocFxMetadata(x => configurator(x).SetConfigPath(configPath));
        }
        static partial void PreProcess (DocFxBuildSettings toolSettings);
        static partial void PostProcess (DocFxBuildSettings toolSettings);
        /// <summary><p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <em>github.io</em>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
        public static void DocFxBuild (Configure<DocFxBuildSettings> configurator = null, ProcessSettings processSettings = null)
        {
            var toolSettings = configurator.InvokeSafe(new DocFxBuildSettings());
            PreProcess(toolSettings);
            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(toolSettings);
        }
        /// <summary><p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <em>github.io</em>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p><p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p></summary>
        public static void DocFxBuild (string configPath, Configure<DocFxBuildSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DocFxBuild(x => configurator(x).SetConfigPath(configPath));
        }
    }
    #region DocFxMetadataSettings
    /// <summary><p>Used within <see cref="DocFxTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFxMetadataSettings : ToolSettings
    {
        /// <summary><p>Path to the DocFx executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetPackageExecutable($"docfx.console", $"docfx.exe");
        /// <summary><p>Path to the docfx.json configuration file.</p></summary>
        public virtual string ConfigPath { get; internal set; }
        /// <summary><p>Force re-generate all the metadata.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Specify the GIT repository root folder.</p></summary>
        public virtual string RepositoryRoot { get; internal set; }
        /// <summary><p>Specify the file name to save processing log.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p></summary>
        public virtual DocFxLogLevel LogLevel { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(ConfigPath) || ConfigPath == null, "File.Exists(ConfigPath) || ConfigPath == null");
            ControlFlow.Assert(Directory.Exists(RepositoryRoot) || RepositoryRoot == null, "Directory.Exists(RepositoryRoot) || RepositoryRoot == null");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("metadata")
              .Add("{value}", ConfigPath)
              .Add("--force", Force)
              .Add("--repositoryRoot {value}", RepositoryRoot)
              .Add("--log {value}", LogFile)
              .Add("--logLevel {value}", LogLevel);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DocFxBuildSettings
    /// <summary><p>Used within <see cref="DocFxTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFxBuildSettings : ToolSettings
    {
        /// <summary><p>Path to the DocFx executable.</p></summary>
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetPackageExecutable($"docfx.console", $"docfx.exe");
        /// <summary><p>Path to the docfx.json configuration file.</p></summary>
        public virtual string ConfigPath { get; internal set; }
        /// <summary><p>Force re-generate all the metadata.</p></summary>
        public virtual bool? Force { get; internal set; }
        /// <summary><p>Specify the GIT repository root folder.</p></summary>
        public virtual string RepositoryRoot { get; internal set; }
        /// <summary><p>Specify which theme to use. By default 'default' theme is offered.</p></summary>
        public virtual string Theme { get; internal set; }
        /// <summary><p>Specify the file name to save processing log.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p></summary>
        public virtual DocFxLogLevel LogLevel { get; internal set; }
        /// <summary><p>Specify the urls of xrefmap used by content files.</p></summary>
        public virtual IReadOnlyList<string> XRefMaps => XRefMapsInternal.AsReadOnly();
        internal List<string> XRefMapsInternal { get; set; } = new List<string>();
        /// <summary><p>Host the generated documentation to a website.</p></summary>
        public virtual bool? Serve { get; internal set; }
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(ConfigPath) || ConfigPath == null, "File.Exists(ConfigPath) || ConfigPath == null");
            ControlFlow.Assert(Directory.Exists(RepositoryRoot) || RepositoryRoot == null, "Directory.Exists(RepositoryRoot) || RepositoryRoot == null");
            ControlFlow.Assert(Directory.Exists(Theme) || Theme == null, "Directory.Exists(Theme) || Theme == null");
        }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("build")
              .Add("{value}", ConfigPath)
              .Add("--force", Force)
              .Add("--repositoryRoot {value}", RepositoryRoot)
              .Add("--theme {value}", Theme)
              .Add("--log {value}", LogFile)
              .Add("--logLevel {value}", LogLevel)
              .Add("--xref {value}", XRefMaps, separator: ',')
              .Add("--serve", Serve);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region DocFxMetadataSettingsExtensions
    /// <summary><p>Used within <see cref="DocFxTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFxMetadataSettingsExtensions
    {
        #region ConfigPath
        /// <summary><p><em>Sets <see cref="DocFxMetadataSettings.ConfigPath"/>.</em></p><p>Path to the docfx.json configuration file.</p></summary>
        [Pure]
        public static DocFxMetadataSettings SetConfigPath(this DocFxMetadataSettings toolSettings, string configPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigPath = configPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DocFxMetadataSettings.ConfigPath"/>.</em></p><p>Path to the docfx.json configuration file.</p></summary>
        [Pure]
        public static DocFxMetadataSettings ResetConfigPath(this DocFxMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigPath = null;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="DocFxMetadataSettings.Force"/>.</em></p><p>Force re-generate all the metadata.</p></summary>
        [Pure]
        public static DocFxMetadataSettings SetForce(this DocFxMetadataSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DocFxMetadataSettings.Force"/>.</em></p><p>Force re-generate all the metadata.</p></summary>
        [Pure]
        public static DocFxMetadataSettings ResetForce(this DocFxMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DocFxMetadataSettings.Force"/>.</em></p><p>Force re-generate all the metadata.</p></summary>
        [Pure]
        public static DocFxMetadataSettings EnableForce(this DocFxMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DocFxMetadataSettings.Force"/>.</em></p><p>Force re-generate all the metadata.</p></summary>
        [Pure]
        public static DocFxMetadataSettings DisableForce(this DocFxMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DocFxMetadataSettings.Force"/>.</em></p><p>Force re-generate all the metadata.</p></summary>
        [Pure]
        public static DocFxMetadataSettings ToggleForce(this DocFxMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region RepositoryRoot
        /// <summary><p><em>Sets <see cref="DocFxMetadataSettings.RepositoryRoot"/>.</em></p><p>Specify the GIT repository root folder.</p></summary>
        [Pure]
        public static DocFxMetadataSettings SetRepositoryRoot(this DocFxMetadataSettings toolSettings, string repositoryRoot)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryRoot = repositoryRoot;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DocFxMetadataSettings.RepositoryRoot"/>.</em></p><p>Specify the GIT repository root folder.</p></summary>
        [Pure]
        public static DocFxMetadataSettings ResetRepositoryRoot(this DocFxMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryRoot = null;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary><p><em>Sets <see cref="DocFxMetadataSettings.LogFile"/>.</em></p><p>Specify the file name to save processing log.</p></summary>
        [Pure]
        public static DocFxMetadataSettings SetLogFile(this DocFxMetadataSettings toolSettings, string logFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DocFxMetadataSettings.LogFile"/>.</em></p><p>Specify the file name to save processing log.</p></summary>
        [Pure]
        public static DocFxMetadataSettings ResetLogFile(this DocFxMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region LogLevel
        /// <summary><p><em>Sets <see cref="DocFxMetadataSettings.LogLevel"/>.</em></p><p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p></summary>
        [Pure]
        public static DocFxMetadataSettings SetLogLevel(this DocFxMetadataSettings toolSettings, DocFxLogLevel logLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = logLevel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DocFxMetadataSettings.LogLevel"/>.</em></p><p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p></summary>
        [Pure]
        public static DocFxMetadataSettings ResetLogLevel(this DocFxMetadataSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DocFxBuildSettingsExtensions
    /// <summary><p>Used within <see cref="DocFxTasks"/>.</p></summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFxBuildSettingsExtensions
    {
        #region ConfigPath
        /// <summary><p><em>Sets <see cref="DocFxBuildSettings.ConfigPath"/>.</em></p><p>Path to the docfx.json configuration file.</p></summary>
        [Pure]
        public static DocFxBuildSettings SetConfigPath(this DocFxBuildSettings toolSettings, string configPath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigPath = configPath;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DocFxBuildSettings.ConfigPath"/>.</em></p><p>Path to the docfx.json configuration file.</p></summary>
        [Pure]
        public static DocFxBuildSettings ResetConfigPath(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigPath = null;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary><p><em>Sets <see cref="DocFxBuildSettings.Force"/>.</em></p><p>Force re-generate all the metadata.</p></summary>
        [Pure]
        public static DocFxBuildSettings SetForce(this DocFxBuildSettings toolSettings, bool? force)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DocFxBuildSettings.Force"/>.</em></p><p>Force re-generate all the metadata.</p></summary>
        [Pure]
        public static DocFxBuildSettings ResetForce(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DocFxBuildSettings.Force"/>.</em></p><p>Force re-generate all the metadata.</p></summary>
        [Pure]
        public static DocFxBuildSettings EnableForce(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DocFxBuildSettings.Force"/>.</em></p><p>Force re-generate all the metadata.</p></summary>
        [Pure]
        public static DocFxBuildSettings DisableForce(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DocFxBuildSettings.Force"/>.</em></p><p>Force re-generate all the metadata.</p></summary>
        [Pure]
        public static DocFxBuildSettings ToggleForce(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region RepositoryRoot
        /// <summary><p><em>Sets <see cref="DocFxBuildSettings.RepositoryRoot"/>.</em></p><p>Specify the GIT repository root folder.</p></summary>
        [Pure]
        public static DocFxBuildSettings SetRepositoryRoot(this DocFxBuildSettings toolSettings, string repositoryRoot)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryRoot = repositoryRoot;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DocFxBuildSettings.RepositoryRoot"/>.</em></p><p>Specify the GIT repository root folder.</p></summary>
        [Pure]
        public static DocFxBuildSettings ResetRepositoryRoot(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryRoot = null;
            return toolSettings;
        }
        #endregion
        #region Theme
        /// <summary><p><em>Sets <see cref="DocFxBuildSettings.Theme"/>.</em></p><p>Specify which theme to use. By default 'default' theme is offered.</p></summary>
        [Pure]
        public static DocFxBuildSettings SetTheme(this DocFxBuildSettings toolSettings, string theme)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Theme = theme;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DocFxBuildSettings.Theme"/>.</em></p><p>Specify which theme to use. By default 'default' theme is offered.</p></summary>
        [Pure]
        public static DocFxBuildSettings ResetTheme(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Theme = null;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary><p><em>Sets <see cref="DocFxBuildSettings.LogFile"/>.</em></p><p>Specify the file name to save processing log.</p></summary>
        [Pure]
        public static DocFxBuildSettings SetLogFile(this DocFxBuildSettings toolSettings, string logFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DocFxBuildSettings.LogFile"/>.</em></p><p>Specify the file name to save processing log.</p></summary>
        [Pure]
        public static DocFxBuildSettings ResetLogFile(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region LogLevel
        /// <summary><p><em>Sets <see cref="DocFxBuildSettings.LogLevel"/>.</em></p><p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p></summary>
        [Pure]
        public static DocFxBuildSettings SetLogLevel(this DocFxBuildSettings toolSettings, DocFxLogLevel logLevel)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = logLevel;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DocFxBuildSettings.LogLevel"/>.</em></p><p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p></summary>
        [Pure]
        public static DocFxBuildSettings ResetLogLevel(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogLevel = null;
            return toolSettings;
        }
        #endregion
        #region XRefMaps
        /// <summary><p><em>Sets <see cref="DocFxBuildSettings.XRefMaps"/> to a new list.</em></p><p>Specify the urls of xrefmap used by content files.</p></summary>
        [Pure]
        public static DocFxBuildSettings SetXRefMaps(this DocFxBuildSettings toolSettings, params string[] xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal = xrefMaps.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Sets <see cref="DocFxBuildSettings.XRefMaps"/> to a new list.</em></p><p>Specify the urls of xrefmap used by content files.</p></summary>
        [Pure]
        public static DocFxBuildSettings SetXRefMaps(this DocFxBuildSettings toolSettings, IEnumerable<string> xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal = xrefMaps.ToList();
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DocFxBuildSettings.XRefMaps"/>.</em></p><p>Specify the urls of xrefmap used by content files.</p></summary>
        [Pure]
        public static DocFxBuildSettings AddXRefMaps(this DocFxBuildSettings toolSettings, params string[] xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal.AddRange(xrefMaps);
            return toolSettings;
        }
        /// <summary><p><em>Adds values to <see cref="DocFxBuildSettings.XRefMaps"/>.</em></p><p>Specify the urls of xrefmap used by content files.</p></summary>
        [Pure]
        public static DocFxBuildSettings AddXRefMaps(this DocFxBuildSettings toolSettings, IEnumerable<string> xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal.AddRange(xrefMaps);
            return toolSettings;
        }
        /// <summary><p><em>Clears <see cref="DocFxBuildSettings.XRefMaps"/>.</em></p><p>Specify the urls of xrefmap used by content files.</p></summary>
        [Pure]
        public static DocFxBuildSettings ClearXRefMaps(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.XRefMapsInternal.Clear();
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DocFxBuildSettings.XRefMaps"/>.</em></p><p>Specify the urls of xrefmap used by content files.</p></summary>
        [Pure]
        public static DocFxBuildSettings RemoveXRefMaps(this DocFxBuildSettings toolSettings, params string[] xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(xrefMaps);
            toolSettings.XRefMapsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary><p><em>Removes values from <see cref="DocFxBuildSettings.XRefMaps"/>.</em></p><p>Specify the urls of xrefmap used by content files.</p></summary>
        [Pure]
        public static DocFxBuildSettings RemoveXRefMaps(this DocFxBuildSettings toolSettings, IEnumerable<string> xrefMaps)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(xrefMaps);
            toolSettings.XRefMapsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Serve
        /// <summary><p><em>Sets <see cref="DocFxBuildSettings.Serve"/>.</em></p><p>Host the generated documentation to a website.</p></summary>
        [Pure]
        public static DocFxBuildSettings SetServe(this DocFxBuildSettings toolSettings, bool? serve)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = serve;
            return toolSettings;
        }
        /// <summary><p><em>Resets <see cref="DocFxBuildSettings.Serve"/>.</em></p><p>Host the generated documentation to a website.</p></summary>
        [Pure]
        public static DocFxBuildSettings ResetServe(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = null;
            return toolSettings;
        }
        /// <summary><p><em>Enables <see cref="DocFxBuildSettings.Serve"/>.</em></p><p>Host the generated documentation to a website.</p></summary>
        [Pure]
        public static DocFxBuildSettings EnableServe(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = true;
            return toolSettings;
        }
        /// <summary><p><em>Disables <see cref="DocFxBuildSettings.Serve"/>.</em></p><p>Host the generated documentation to a website.</p></summary>
        [Pure]
        public static DocFxBuildSettings DisableServe(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = false;
            return toolSettings;
        }
        /// <summary><p><em>Toggles <see cref="DocFxBuildSettings.Serve"/>.</em></p><p>Host the generated documentation to a website.</p></summary>
        [Pure]
        public static DocFxBuildSettings ToggleServe(this DocFxBuildSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Serve = !toolSettings.Serve;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region DocFxLogLevel
    /// <summary><p>Used within <see cref="DocFxTasks"/>.</p></summary>
    [PublicAPI]
    [Serializable]
    public partial class DocFxLogLevel : Enumeration
    {
        public static DocFxLogLevel Verbose = new DocFxLogLevel { Value = "Verbose" };
        public static DocFxLogLevel Info = new DocFxLogLevel { Value = "Info" };
        public static DocFxLogLevel Warning = new DocFxLogLevel { Value = "Warning" };
        public static DocFxLogLevel Error = new DocFxLogLevel { Value = "Error" };
    }
    #endregion
}
