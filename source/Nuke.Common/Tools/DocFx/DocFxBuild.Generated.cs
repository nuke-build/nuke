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

[assembly: IconClass(typeof(Nuke.Common.Tools.DocFx.DocFxTasks), "books")]
namespace Nuke.Common.Tools.DocFx
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFxTasks
    {
        static partial void PreProcess (DocFxBuildSettings docFxBuildSettings);
        static partial void PostProcess (DocFxBuildSettings docFxBuildSettings);
        /// <summary>
        /// <p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <i>github.io</i>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p>
        /// <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        public static void DocFxBuild (Configure<DocFxBuildSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var docFxBuildSettings = new DocFxBuildSettings();
            docFxBuildSettings = configurator(docFxBuildSettings);
            PreProcess(docFxBuildSettings);
            var process = ProcessManager.Instance.StartProcess(docFxBuildSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(docFxBuildSettings);
        }
        /// <summary>
        /// <p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <i>github.io</i>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p>
        /// <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        public static void DocFxBuild (string configPath, Configure<DocFxBuildSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DocFxBuild(x => configurator(x).SetConfigPath(configPath));
        }
    }
    /// <summary>
    /// <p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <i>github.io</i>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p>
    /// <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFxBuildSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? NuGetPackageResolver.GetToolPath($"docfx.console", $"docfx.exe");
        /// <summary><p>Path to the docfx.json configuration file.</p></summary>
        public virtual string ConfigPath { get; internal set; }
        /// <summary><p>Force re-generate all the metadata.</p></summary>
        public virtual bool Force { get; internal set; }
        /// <summary><p>Specify the GIT repository root folder.</p></summary>
        public virtual string RepositoryRoot { get; internal set; }
        /// <summary><p>Specify which theme to use. By default 'default' theme is offered.</p></summary>
        public virtual string Theme { get; internal set; }
        /// <summary><p>Specify the file name to save processing log.</p></summary>
        public virtual string LogFile { get; internal set; }
        /// <summary><p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p></summary>
        public virtual DocFxLogLevel? LogLevel { get; internal set; }
        /// <inheritdoc />
        protected override void AssertValid()
        {
            base.AssertValid();
            ControlFlow.Assert(File.Exists(ConfigPath) || ConfigPath == null, $"File.Exists(ConfigPath) || ConfigPath == null");
            ControlFlow.Assert(Directory.Exists(RepositoryRoot) || RepositoryRoot == null, $"Directory.Exists(RepositoryRoot) || RepositoryRoot == null");
            ControlFlow.Assert(Directory.Exists(Theme) || Theme == null, $"Directory.Exists(Theme) || Theme == null");
        }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add($"build")
              .Add("{value}", ConfigPath)
              .Add("--force", Force)
              .Add("--repositoryRoot {value}", RepositoryRoot)
              .Add("--theme {value}", Theme)
              .Add("--log {value}", LogFile)
              .Add("--logLevel {value}", LogLevel);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFxBuildSettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DocFxBuildSettings.ConfigPath"/>.</i></p>
        /// <p>Path to the docfx.json configuration file.</p>
        /// </summary>
        [Pure]
        public static DocFxBuildSettings SetConfigPath(this DocFxBuildSettings docFxBuildSettings, string configPath)
        {
            docFxBuildSettings = docFxBuildSettings.NewInstance();
            docFxBuildSettings.ConfigPath = configPath;
            return docFxBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DocFxBuildSettings.Force"/>.</i></p>
        /// <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFxBuildSettings SetForce(this DocFxBuildSettings docFxBuildSettings, bool force)
        {
            docFxBuildSettings = docFxBuildSettings.NewInstance();
            docFxBuildSettings.Force = force;
            return docFxBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DocFxBuildSettings.Force"/>.</i></p>
        /// <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFxBuildSettings EnableForce(this DocFxBuildSettings docFxBuildSettings)
        {
            docFxBuildSettings = docFxBuildSettings.NewInstance();
            docFxBuildSettings.Force = true;
            return docFxBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DocFxBuildSettings.Force"/>.</i></p>
        /// <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFxBuildSettings DisableForce(this DocFxBuildSettings docFxBuildSettings)
        {
            docFxBuildSettings = docFxBuildSettings.NewInstance();
            docFxBuildSettings.Force = false;
            return docFxBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DocFxBuildSettings.Force"/>.</i></p>
        /// <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFxBuildSettings ToggleForce(this DocFxBuildSettings docFxBuildSettings)
        {
            docFxBuildSettings = docFxBuildSettings.NewInstance();
            docFxBuildSettings.Force = !docFxBuildSettings.Force;
            return docFxBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DocFxBuildSettings.RepositoryRoot"/>.</i></p>
        /// <p>Specify the GIT repository root folder.</p>
        /// </summary>
        [Pure]
        public static DocFxBuildSettings SetRepositoryRoot(this DocFxBuildSettings docFxBuildSettings, string repositoryRoot)
        {
            docFxBuildSettings = docFxBuildSettings.NewInstance();
            docFxBuildSettings.RepositoryRoot = repositoryRoot;
            return docFxBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DocFxBuildSettings.Theme"/>.</i></p>
        /// <p>Specify which theme to use. By default 'default' theme is offered.</p>
        /// </summary>
        [Pure]
        public static DocFxBuildSettings SetTheme(this DocFxBuildSettings docFxBuildSettings, string theme)
        {
            docFxBuildSettings = docFxBuildSettings.NewInstance();
            docFxBuildSettings.Theme = theme;
            return docFxBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DocFxBuildSettings.LogFile"/>.</i></p>
        /// <p>Specify the file name to save processing log.</p>
        /// </summary>
        [Pure]
        public static DocFxBuildSettings SetLogFile(this DocFxBuildSettings docFxBuildSettings, string logFile)
        {
            docFxBuildSettings = docFxBuildSettings.NewInstance();
            docFxBuildSettings.LogFile = logFile;
            return docFxBuildSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DocFxBuildSettings.LogLevel"/>.</i></p>
        /// <p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p>
        /// </summary>
        [Pure]
        public static DocFxBuildSettings SetLogLevel(this DocFxBuildSettings docFxBuildSettings, DocFxLogLevel? logLevel)
        {
            docFxBuildSettings = docFxBuildSettings.NewInstance();
            docFxBuildSettings.LogLevel = logLevel;
            return docFxBuildSettings;
        }
    }
}
