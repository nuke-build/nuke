// Generated from https://github.com/MoodieG/cmake-tool/blob/master/source/Nuke.Common/Tools/CMake/CMake.json

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

namespace Nuke.Common.Tools.CMake
{
    /// <summary>
    ///   <p>The cmake executable is the command-line interface of the cross-platform build system generator CMake.</p>
    ///   <p>For more details, visit the <a href="https://cmake.org/cmake/help/latest/manual/cmake.1.html">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CMakeTasks
    {
        /// <summary>
        ///   Path to the CMake executable.
        /// </summary>
        public static string CMakePath =>
            ToolPathResolver.TryGetEnvironmentExecutable("CMAKE_EXE") ??
            ToolPathResolver.GetPathExecutable("cmake");
        public static Action<OutputType, string> CMakeLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>The cmake executable is the command-line interface of the cross-platform build system generator CMake.</p>
        ///   <p>For more details, visit the <a href="https://cmake.org/cmake/help/latest/manual/cmake.1.html">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> CMake(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            using var process = ProcessTasks.StartProcess(CMakePath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, CMakeLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Generates a build project using cmake.</p>
        ///   <p>For more details, visit the <a href="https://cmake.org/cmake/help/latest/manual/cmake.1.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-A</c> via <see cref="CMakeGenerateSettings.Platform"/></li>
        ///     <li><c>-B</c> via <see cref="CMakeGenerateSettings.OutputDirectory"/></li>
        ///     <li><c>-DCMAKE_TOOLCHAIN_FILE:FILEPATH</c> via <see cref="CMakeGenerateSettings.ToolChain"/></li>
        ///     <li><c>-G</c> via <see cref="CMakeGenerateSettings.Generator"/></li>
        ///     <li><c>-S</c> via <see cref="CMakeGenerateSettings.RootDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CMakeGenerate(CMakeGenerateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CMakeGenerateSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Generates a build project using cmake.</p>
        ///   <p>For more details, visit the <a href="https://cmake.org/cmake/help/latest/manual/cmake.1.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-A</c> via <see cref="CMakeGenerateSettings.Platform"/></li>
        ///     <li><c>-B</c> via <see cref="CMakeGenerateSettings.OutputDirectory"/></li>
        ///     <li><c>-DCMAKE_TOOLCHAIN_FILE:FILEPATH</c> via <see cref="CMakeGenerateSettings.ToolChain"/></li>
        ///     <li><c>-G</c> via <see cref="CMakeGenerateSettings.Generator"/></li>
        ///     <li><c>-S</c> via <see cref="CMakeGenerateSettings.RootDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CMakeGenerate(Configure<CMakeGenerateSettings> configurator)
        {
            return CMakeGenerate(configurator(new CMakeGenerateSettings()));
        }
        /// <summary>
        ///   <p>Generates a build project using cmake.</p>
        ///   <p>For more details, visit the <a href="https://cmake.org/cmake/help/latest/manual/cmake.1.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-A</c> via <see cref="CMakeGenerateSettings.Platform"/></li>
        ///     <li><c>-B</c> via <see cref="CMakeGenerateSettings.OutputDirectory"/></li>
        ///     <li><c>-DCMAKE_TOOLCHAIN_FILE:FILEPATH</c> via <see cref="CMakeGenerateSettings.ToolChain"/></li>
        ///     <li><c>-G</c> via <see cref="CMakeGenerateSettings.Generator"/></li>
        ///     <li><c>-S</c> via <see cref="CMakeGenerateSettings.RootDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CMakeGenerateSettings Settings, IReadOnlyCollection<Output> Output)> CMakeGenerate(CombinatorialConfigure<CMakeGenerateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CMakeGenerate, CMakeLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Runs the `cmake --install` command on a project generated with cmake.</p>
        ///   <p>For more details, visit the <a href="https://cmake.org/cmake/help/latest/manual/cmake.1.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;rootDirectory&gt;</c> via <see cref="CMakeInstallSettings.RootDirectory"/></li>
        ///     <li><c>--component</c> via <see cref="CMakeInstallSettings.Component"/></li>
        ///     <li><c>--config</c> via <see cref="CMakeInstallSettings.Configuration"/></li>
        ///     <li><c>--prefix</c> via <see cref="CMakeInstallSettings.OutputDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CMakeInstall(CMakeInstallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CMakeInstallSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Runs the `cmake --install` command on a project generated with cmake.</p>
        ///   <p>For more details, visit the <a href="https://cmake.org/cmake/help/latest/manual/cmake.1.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;rootDirectory&gt;</c> via <see cref="CMakeInstallSettings.RootDirectory"/></li>
        ///     <li><c>--component</c> via <see cref="CMakeInstallSettings.Component"/></li>
        ///     <li><c>--config</c> via <see cref="CMakeInstallSettings.Configuration"/></li>
        ///     <li><c>--prefix</c> via <see cref="CMakeInstallSettings.OutputDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CMakeInstall(Configure<CMakeInstallSettings> configurator)
        {
            return CMakeInstall(configurator(new CMakeInstallSettings()));
        }
        /// <summary>
        ///   <p>Runs the `cmake --install` command on a project generated with cmake.</p>
        ///   <p>For more details, visit the <a href="https://cmake.org/cmake/help/latest/manual/cmake.1.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;rootDirectory&gt;</c> via <see cref="CMakeInstallSettings.RootDirectory"/></li>
        ///     <li><c>--component</c> via <see cref="CMakeInstallSettings.Component"/></li>
        ///     <li><c>--config</c> via <see cref="CMakeInstallSettings.Configuration"/></li>
        ///     <li><c>--prefix</c> via <see cref="CMakeInstallSettings.OutputDirectory"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CMakeInstallSettings Settings, IReadOnlyCollection<Output> Output)> CMakeInstall(CombinatorialConfigure<CMakeInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CMakeInstall, CMakeLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region CMakeGenerateSettings
    /// <summary>
    ///   Used within <see cref="CMakeTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CMakeGenerateSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CMake executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? CMakeTasks.CMakePath;
        public override Action<OutputType, string> ProcessCustomLogger => CMakeTasks.CMakeLogger;
        /// <summary>
        ///   Specify the build system to generate.
        /// </summary>
        public virtual CMakeGenerator Generator { get; internal set; } = CMakeGenerator.Visual_Studio_16_2019;
        /// <summary>
        ///   Specify the platform to build for.
        /// </summary>
        public virtual CMakePlatform Platform { get; internal set; } = CMakePlatform.x64;
        /// <summary>
        ///   Specify the root directory of the 'CMakeLists.txt' file.
        /// </summary>
        public virtual string RootDirectory { get; internal set; } = ".";
        /// <summary>
        ///   Specify the configuration to use when running the install script.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; } = "./out";
        /// <summary>
        ///   Specify the path to a toolchain file to use.
        /// </summary>
        public virtual string ToolChain { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("-G {value}", Generator)
              .Add("-A {value}", Platform)
              .Add("-S {value}", RootDirectory)
              .Add("-B {value}", OutputDirectory)
              .Add("-DCMAKE_TOOLCHAIN_FILE:FILEPATH={value}", ToolChain);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region CMakeInstallSettings
    /// <summary>
    ///   Used within <see cref="CMakeTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CMakeInstallSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CMake executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? CMakeTasks.CMakePath;
        public override Action<OutputType, string> ProcessCustomLogger => CMakeTasks.CMakeLogger;
        /// <summary>
        ///   Specify the root directory of the cmake install script.
        /// </summary>
        public virtual string RootDirectory { get; internal set; } = ".";
        /// <summary>
        ///   Specify the root directory of the 'CMakeLists.txt' file.
        /// </summary>
        public virtual CMakeConfiguration Configuration { get; internal set; } = CMakeConfiguration.Debug;
        /// <summary>
        ///   Specify the output directory of the install script.
        /// </summary>
        public virtual string OutputDirectory { get; internal set; }
        /// <summary>
        ///   Specify the component to install.
        /// </summary>
        public virtual string Component { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("--install")
              .Add("{value}", RootDirectory)
              .Add("--config {value}", Configuration)
              .Add("--prefix {value}", OutputDirectory)
              .Add("--component {value}", Component);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region CMakeGenerateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CMakeTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CMakeGenerateSettingsExtensions
    {
        #region Generator
        /// <summary>
        ///   <p><em>Sets <see cref="CMakeGenerateSettings.Generator"/></em></p>
        ///   <p>Specify the build system to generate.</p>
        /// </summary>
        [Pure]
        public static T SetGenerator<T>(this T toolSettings, CMakeGenerator generator) where T : CMakeGenerateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Generator = generator;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CMakeGenerateSettings.Generator"/></em></p>
        ///   <p>Specify the build system to generate.</p>
        /// </summary>
        [Pure]
        public static T ResetGenerator<T>(this T toolSettings) where T : CMakeGenerateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Generator = null;
            return toolSettings;
        }
        #endregion
        #region Platform
        /// <summary>
        ///   <p><em>Sets <see cref="CMakeGenerateSettings.Platform"/></em></p>
        ///   <p>Specify the platform to build for.</p>
        /// </summary>
        [Pure]
        public static T SetPlatform<T>(this T toolSettings, CMakePlatform platform) where T : CMakeGenerateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Platform = platform;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CMakeGenerateSettings.Platform"/></em></p>
        ///   <p>Specify the platform to build for.</p>
        /// </summary>
        [Pure]
        public static T ResetPlatform<T>(this T toolSettings) where T : CMakeGenerateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Platform = null;
            return toolSettings;
        }
        #endregion
        #region RootDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="CMakeGenerateSettings.RootDirectory"/></em></p>
        ///   <p>Specify the root directory of the 'CMakeLists.txt' file.</p>
        /// </summary>
        [Pure]
        public static T SetRootDirectory<T>(this T toolSettings, string rootDirectory) where T : CMakeGenerateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RootDirectory = rootDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CMakeGenerateSettings.RootDirectory"/></em></p>
        ///   <p>Specify the root directory of the 'CMakeLists.txt' file.</p>
        /// </summary>
        [Pure]
        public static T ResetRootDirectory<T>(this T toolSettings) where T : CMakeGenerateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RootDirectory = null;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="CMakeGenerateSettings.OutputDirectory"/></em></p>
        ///   <p>Specify the configuration to use when running the install script.</p>
        /// </summary>
        [Pure]
        public static T SetOutputDirectory<T>(this T toolSettings, string outputDirectory) where T : CMakeGenerateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CMakeGenerateSettings.OutputDirectory"/></em></p>
        ///   <p>Specify the configuration to use when running the install script.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputDirectory<T>(this T toolSettings) where T : CMakeGenerateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region ToolChain
        /// <summary>
        ///   <p><em>Sets <see cref="CMakeGenerateSettings.ToolChain"/></em></p>
        ///   <p>Specify the path to a toolchain file to use.</p>
        /// </summary>
        [Pure]
        public static T SetToolChain<T>(this T toolSettings, string toolChain) where T : CMakeGenerateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolChain = toolChain;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CMakeGenerateSettings.ToolChain"/></em></p>
        ///   <p>Specify the path to a toolchain file to use.</p>
        /// </summary>
        [Pure]
        public static T ResetToolChain<T>(this T toolSettings) where T : CMakeGenerateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ToolChain = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CMakeInstallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CMakeTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CMakeInstallSettingsExtensions
    {
        #region RootDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="CMakeInstallSettings.RootDirectory"/></em></p>
        ///   <p>Specify the root directory of the cmake install script.</p>
        /// </summary>
        [Pure]
        public static T SetRootDirectory<T>(this T toolSettings, string rootDirectory) where T : CMakeInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RootDirectory = rootDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CMakeInstallSettings.RootDirectory"/></em></p>
        ///   <p>Specify the root directory of the cmake install script.</p>
        /// </summary>
        [Pure]
        public static T ResetRootDirectory<T>(this T toolSettings) where T : CMakeInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RootDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Configuration
        /// <summary>
        ///   <p><em>Sets <see cref="CMakeInstallSettings.Configuration"/></em></p>
        ///   <p>Specify the root directory of the 'CMakeLists.txt' file.</p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, CMakeConfiguration configuration) where T : CMakeInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CMakeInstallSettings.Configuration"/></em></p>
        ///   <p>Specify the root directory of the 'CMakeLists.txt' file.</p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : CMakeInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }
        #endregion
        #region OutputDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="CMakeInstallSettings.OutputDirectory"/></em></p>
        ///   <p>Specify the output directory of the install script.</p>
        /// </summary>
        [Pure]
        public static T SetOutputDirectory<T>(this T toolSettings, string outputDirectory) where T : CMakeInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = outputDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CMakeInstallSettings.OutputDirectory"/></em></p>
        ///   <p>Specify the output directory of the install script.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputDirectory<T>(this T toolSettings) where T : CMakeInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Component
        /// <summary>
        ///   <p><em>Sets <see cref="CMakeInstallSettings.Component"/></em></p>
        ///   <p>Specify the component to install.</p>
        /// </summary>
        [Pure]
        public static T SetComponent<T>(this T toolSettings, string component) where T : CMakeInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Component = component;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CMakeInstallSettings.Component"/></em></p>
        ///   <p>Specify the component to install.</p>
        /// </summary>
        [Pure]
        public static T ResetComponent<T>(this T toolSettings) where T : CMakeInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Component = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CMakeGenerator
    /// <summary>
    ///   Used within <see cref="CMakeTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<CMakeGenerator>))]
    public partial class CMakeGenerator : Enumeration
    {
        public static CMakeGenerator Visual_Studio_15_2017 = (CMakeGenerator) "Visual Studio 15 2017";
        public static CMakeGenerator Visual_Studio_16_2019 = (CMakeGenerator) "Visual Studio 16 2019";
        public static CMakeGenerator Visual_Studio_17_2022 = (CMakeGenerator) "Visual Studio 17 2022";
        public static CMakeGenerator Ninja = (CMakeGenerator) "Ninja";
        public static CMakeGenerator Xcode = (CMakeGenerator) "Xcode";
        public static implicit operator CMakeGenerator(string value)
        {
            return new CMakeGenerator { Value = value };
        }
    }
    #endregion
    #region CMakePlatform
    /// <summary>
    ///   Used within <see cref="CMakeTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<CMakePlatform>))]
    public partial class CMakePlatform : Enumeration
    {
        public static CMakePlatform Win32 = (CMakePlatform) "Win32";
        public static CMakePlatform x64 = (CMakePlatform) "x64";
        public static CMakePlatform ARM = (CMakePlatform) "ARM";
        public static CMakePlatform ARM64 = (CMakePlatform) "ARM64";
        public static CMakePlatform Gaming_Desktop_x64 = (CMakePlatform) "Gaming.Desktop.x64";
        public static CMakePlatform Gaming_Xbox_XboxOne_x64 = (CMakePlatform) "Gaming.Xbox.XboxOne.x64";
        public static CMakePlatform Gaming_Xbox_Scarlett_x64 = (CMakePlatform) "Gaming.Xbox.Scarlett.x64";
        public static implicit operator CMakePlatform(string value)
        {
            return new CMakePlatform { Value = value };
        }
    }
    #endregion
    #region CMakeConfiguration
    /// <summary>
    ///   Used within <see cref="CMakeTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<CMakeConfiguration>))]
    public partial class CMakeConfiguration : Enumeration
    {
        public static CMakeConfiguration Debug = (CMakeConfiguration) "Debug";
        public static CMakeConfiguration RelWithDebInfo = (CMakeConfiguration) "RelWithDebInfo";
        public static CMakeConfiguration Release = (CMakeConfiguration) "Release";
        public static CMakeConfiguration MinSizeRel = (CMakeConfiguration) "MinSizeRel";
        public static implicit operator CMakeConfiguration(string value)
        {
            return new CMakeConfiguration { Value = value };
        }
    }
    #endregion
}
