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

namespace Nuke.Common.Tools.DotNet
{
    public static partial class DotNetTasks
    {
        static partial void PreProcess (DotNetRunSettings dotNetRunSettings);
        static partial void PostProcess (DotNetRunSettings dotNetRunSettings);
        /// <summary>
        /// <p>The <c>dotnet run</c> command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build"><c>dotnet build</c></a> command to build the code. Any requirements for the build, such as that the project must be restored first, apply to <c>dotnet run</c> as well.</p><p>Output files are written into the default location, which is <c>bin/&lt;configuration&gt;/&lt;target&gt;</c>. For example if you have a <c>netcoreapp1.0</c> application and you run <c>dotnet run</c>, the output is placed in <c>bin/Debug/netcoreapp1.0</c>. Files are overwritten as needed. Temporary files are placed in the <c>obj</c> directory.</p><p>If the project specifies multiple frameworks, executing <c>dotnet run</c> results in an error unless the <c>-f|--framework &lt;FRAMEWORK&gt;</c> option is used to specify the framework.</p><p>The <c>dotnet run</c> command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet">dotnet</a> without a command. For example, to run <c>myapp.dll</c>, use: <c>dotnet myapp.dll</c></p><p>For more information on the <c>dotnet</c> driver, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/index">.NET Core Command Line Tools (CLI)</a> topic.</p><p>In order to run the application, the <c>dotnet run</c> command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use <c>dotnet run</c> to run applications in production. Instead, <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">create a deployment</a> using the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command and deploy the published output.</p>
        /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run">official website</a>.</p>
        /// </summary>
        public static void DotNetRun (Configure<DotNetRunSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            var dotNetRunSettings = new DotNetRunSettings();
            dotNetRunSettings = configurator(dotNetRunSettings);
            PreProcess(dotNetRunSettings);
            var process = ProcessManager.Instance.StartProcess(dotNetRunSettings, processSettings);
            process.AssertZeroExitCode();
            PostProcess(dotNetRunSettings);
        }
    }
    /// <summary>
    /// <p>The <c>dotnet run</c> command provides a convenient option to run your application from the source code with one command. It's useful for fast iterative development from the command line. The command depends on the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build"><c>dotnet build</c></a> command to build the code. Any requirements for the build, such as that the project must be restored first, apply to <c>dotnet run</c> as well.</p><p>Output files are written into the default location, which is <c>bin/&lt;configuration&gt;/&lt;target&gt;</c>. For example if you have a <c>netcoreapp1.0</c> application and you run <c>dotnet run</c>, the output is placed in <c>bin/Debug/netcoreapp1.0</c>. Files are overwritten as needed. Temporary files are placed in the <c>obj</c> directory.</p><p>If the project specifies multiple frameworks, executing <c>dotnet run</c> results in an error unless the <c>-f|--framework &lt;FRAMEWORK&gt;</c> option is used to specify the framework.</p><p>The <c>dotnet run</c> command is used in the context of projects, not built assemblies. If you're trying to run a framework-dependent application DLL instead, you must use <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet">dotnet</a> without a command. For example, to run <c>myapp.dll</c>, use: <c>dotnet myapp.dll</c></p><p>For more information on the <c>dotnet</c> driver, see the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/index">.NET Core Command Line Tools (CLI)</a> topic.</p><p>In order to run the application, the <c>dotnet run</c> command resolves the dependencies of the application that are outside of the shared runtime from the NuGet cache. Because it uses cached dependencies, it's not recommended to use <c>dotnet run</c> to run applications in production. Instead, <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/index">create a deployment</a> using the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish"><c>dotnet publish</c></a> command and deploy the published output.</p>
    /// <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class DotNetRunSettings : DotNetSettings
    {
        /// <summary><p>Configuration to use for building the project. The default value is Debug.</p></summary>
        public virtual string Configuration { get; internal set; }
        /// <summary><p>Builds and runs the app using the specified framework. The framework must be specified in the project file.</p></summary>
        public virtual string Framework { get; internal set; }
        /// <summary><p>Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified.</p></summary>
        public virtual string ProjectFile { get; internal set; }
        protected override Arguments GetArgumentsInternal()
        {
            return base.GetArgumentsInternal()
              .Add($"run")
              .Add("--configuration {value}", Configuration)
              .Add("--framework {value}", Framework)
              .Add("--project {value}", ProjectFile);
        }
    }
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class DotNetRunSettingsExtensions
    {
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRunSettings.Configuration"/>.</i></p>
        /// <p>Configuration to use for building the project. The default value is Debug.</p>
        /// </summary>
        [Pure]
        public static DotNetRunSettings SetConfiguration(this DotNetRunSettings dotNetRunSettings, string configuration)
        {
            dotNetRunSettings = dotNetRunSettings.NewInstance();
            dotNetRunSettings.Configuration = configuration;
            return dotNetRunSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRunSettings.Framework"/>.</i></p>
        /// <p>Builds and runs the app using the specified framework. The framework must be specified in the project file.</p>
        /// </summary>
        [Pure]
        public static DotNetRunSettings SetFramework(this DotNetRunSettings dotNetRunSettings, string framework)
        {
            dotNetRunSettings = dotNetRunSettings.NewInstance();
            dotNetRunSettings.Framework = framework;
            return dotNetRunSettings;
        }
        /// <summary>
        /// <p><i>Extension method for setting <see cref="DotNetRunSettings.ProjectFile"/>.</i></p>
        /// <p>Specifies the path and name of the project file. (See the NOTE.) It defaults to the current directory if not specified.</p>
        /// </summary>
        [Pure]
        public static DotNetRunSettings SetProjectFile(this DotNetRunSettings dotNetRunSettings, string projectFile)
        {
            dotNetRunSettings = dotNetRunSettings.NewInstance();
            dotNetRunSettings.ProjectFile = projectFile;
            return dotNetRunSettings;
        }
    }
}
