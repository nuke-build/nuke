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
    public static partial class DocFxTasks
    {
        static partial void PreProcess (DocFxMetadataSettings docFxMetadataSettings);
        static partial void PostProcess (DocFxMetadataSettings docFxMetadataSettings);
        /// <summary>
        /// <p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <i>github.io</i>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p>
        /// <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        public static void DocFxMetadata (Configure<DocFxMetadataSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var docFxMetadataSettings = new DocFxMetadataSettings();
            docFxMetadataSettings = configurator(docFxMetadataSettings);
            PreProcess(docFxMetadataSettings);
            var process = ProcessTasks.StartProcess(docFxMetadataSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(docFxMetadataSettings);
        }
        /// <summary>
        /// <p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <i>github.io</i>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p>
        /// <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
        /// </summary>
        public static void DocFxMetadata (string configPath, Configure<DocFxMetadataSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            DocFxMetadata(x => configurator(x).SetConfigPath(configPath));
        }
    }
    /// <summary>
    /// <p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <i>github.io</i>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p>
    /// <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DocFxMetadataSettings : ToolSettings
    {
        /// <inheritdoc />
        public override string ToolPath => base.ToolPath ?? ToolPathResolver.GetToolPath(packageId: $"docfx.console", packageExecutable: $"docfx.exe");
        /// <summary><p>Path to the docfx.json configuration file.</p></summary>
        public virtual string ConfigPath { get; internal set; }
        /// <summary><p>Force re-generate all the metadata.</p></summary>
        public virtual bool Force { get; internal set; }
        /// <summary><p>Specify the GIT repository root folder.</p></summary>
        public virtual string RepositoryRoot { get; internal set; }
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
        }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add("metadata")
              .Add("{value}", ConfigPath)
              .Add("--force", Force)
              .Add("--repositoryRoot {value}", RepositoryRoot)
              .Add("--log {value}", LogFile)
              .Add("--logLevel {value}", LogLevel);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DocFxMetadataSettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DocFxMetadataSettings.ConfigPath"/>.</i></p>
        /// <p>Path to the docfx.json configuration file.</p>
        /// </summary>
        [Pure]
        public static DocFxMetadataSettings SetConfigPath(this DocFxMetadataSettings docFxMetadataSettings, string configPath)
        {
            docFxMetadataSettings = docFxMetadataSettings.NewInstance();
            docFxMetadataSettings.ConfigPath = configPath;
            return docFxMetadataSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DocFxMetadataSettings.Force"/>.</i></p>
        /// <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFxMetadataSettings SetForce(this DocFxMetadataSettings docFxMetadataSettings, bool force)
        {
            docFxMetadataSettings = docFxMetadataSettings.NewInstance();
            docFxMetadataSettings.Force = force;
            return docFxMetadataSettings;
        }
        /// <summary>
        /// <p><i>Extension method for enabling <see cref="DocFxMetadataSettings.Force"/>.</i></p>
        /// <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFxMetadataSettings EnableForce(this DocFxMetadataSettings docFxMetadataSettings)
        {
            docFxMetadataSettings = docFxMetadataSettings.NewInstance();
            docFxMetadataSettings.Force = true;
            return docFxMetadataSettings;
        }
        /// <summary>
        /// <p><i>Extension method for disabling <see cref="DocFxMetadataSettings.Force"/>.</i></p>
        /// <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFxMetadataSettings DisableForce(this DocFxMetadataSettings docFxMetadataSettings)
        {
            docFxMetadataSettings = docFxMetadataSettings.NewInstance();
            docFxMetadataSettings.Force = false;
            return docFxMetadataSettings;
        }
        /// <summary>
        /// <p><i>Extension method for toggling <see cref="DocFxMetadataSettings.Force"/>.</i></p>
        /// <p>Force re-generate all the metadata.</p>
        /// </summary>
        [Pure]
        public static DocFxMetadataSettings ToggleForce(this DocFxMetadataSettings docFxMetadataSettings)
        {
            docFxMetadataSettings = docFxMetadataSettings.NewInstance();
            docFxMetadataSettings.Force = !docFxMetadataSettings.Force;
            return docFxMetadataSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DocFxMetadataSettings.RepositoryRoot"/>.</i></p>
        /// <p>Specify the GIT repository root folder.</p>
        /// </summary>
        [Pure]
        public static DocFxMetadataSettings SetRepositoryRoot(this DocFxMetadataSettings docFxMetadataSettings, string repositoryRoot)
        {
            docFxMetadataSettings = docFxMetadataSettings.NewInstance();
            docFxMetadataSettings.RepositoryRoot = repositoryRoot;
            return docFxMetadataSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DocFxMetadataSettings.LogFile"/>.</i></p>
        /// <p>Specify the file name to save processing log.</p>
        /// </summary>
        [Pure]
        public static DocFxMetadataSettings SetLogFile(this DocFxMetadataSettings docFxMetadataSettings, string logFile)
        {
            docFxMetadataSettings = docFxMetadataSettings.NewInstance();
            docFxMetadataSettings.LogFile = logFile;
            return docFxMetadataSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DocFxMetadataSettings.LogLevel"/>.</i></p>
        /// <p>Specify to which log level will be logged. By default log level &gt;= Info will be logged. The acceptable value could be Verbose, Info, Warning, Error.</p>
        /// </summary>
        [Pure]
        public static DocFxMetadataSettings SetLogLevel(this DocFxMetadataSettings docFxMetadataSettings, DocFxLogLevel? logLevel)
        {
            docFxMetadataSettings = docFxMetadataSettings.NewInstance();
            docFxMetadataSettings.LogLevel = logLevel;
            return docFxMetadataSettings;
        }
    }
    /// <summary>
    /// <p>DocFX is an API documentation generator for .NET, and currently it supports C# and VB. It generates API reference documentation from triple-slash comments in your source code. It also allows you to use Markdown files to create additional topics such as tutorials and how-tos, and to customize the generated reference documentation. DocFX builds a static HTML website from your source code and Markdown files, which can be easily hosted on any web servers (for example, <i>github.io</i>). Also, DocFX provides you the flexibility to customize the layout and style of your website through templates. If you are interested in creating your own website with your own styles, you can follow <a href="http://dotnet.github.io/docfx/tutorial/howto_create_custom_template.html">how to create custom template</a> to create custom templates.</p>
    /// <p>For more details, visit the <a href="https://dotnet.github.io/docfx/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    public enum DocFxLogLevel
    {
        Verbose,
        Info,
        Warning,
        Error
    }
}
