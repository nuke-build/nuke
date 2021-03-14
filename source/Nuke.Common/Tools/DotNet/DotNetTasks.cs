// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.DotNet
{
    [PublicAPI]
    public class DotNetVerbosityMappingAttribute : VerbosityMappingAttribute
    {
        public DotNetVerbosityMappingAttribute()
            : base(typeof(DotNetVerbosity))
        {
            Quiet = nameof(DotNetVerbosity.Quiet);
            Minimal = nameof(DotNetVerbosity.Minimal);
            Normal = nameof(DotNetVerbosity.Minimal);
            Verbose = nameof(DotNetVerbosity.Detailed);
        }
    }

    partial class DotNetRunSettings
    {
        private string GetApplicationArguments()
        {
            return ApplicationArguments;
        }
    }

    public static partial class DotNetTasks
    {
        // ReSharper disable once CognitiveComplexity
        internal static void CustomLogger(OutputType type, string output)
        {
            if (type == OutputType.Err)
            {
                Logger.Error(output);
                return;
            }

            var spaces = 0;
            for (var i = 0; i < output.Length && spaces < 3; i++)
            {
                if (output[i] == ' ')
                {
                    spaces++;
                    continue;
                }

                if (i >= 4 &&
                    'e' == output[i - 4] &&
                    'r' == output[i - 3] &&
                    'r' == output[i - 2] &&
                    'o' == output[i - 1] &&
                    'r' == output[i])
                {
                    Logger.Error(output);
                    return;
                }

                if (i >= 6 &&
                    'w' == output[i - 6] &&
                    'a' == output[i - 5] &&
                    'r' == output[i - 4] &&
                    'n' == output[i - 3] &&
                    'i' == output[i - 2] &&
                    'n' == output[i - 1] &&
                    'g' == output[i])
                {
                    Logger.Warn(output);
                    return;
                }
            }

            Logger.Normal(output);
        }

        public static string EscapeMSBuild(this string str)
        {
            // https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-special-characters
            return str
                .Replace("%", "%25")  // Referencing metadata
                .Replace("$", "%24")  // Referencing properties
                .Replace("@", "%40")  // Referencing item lists
                .Replace("'", "%27")  // Conditions and other expressions
                .Replace(";", "%3B")  // List separator
                .Replace("?", "%3F")  // Wildcard character for file names in Include and Exclude attributes
                .Replace("*", "%2A"); // Wildcard character for use in file names in Include and Exclude attributes
        }

        /// <summary>
        ///   <p>The <c>dotnet msbuild</c> command allows access to a fully functional MSBuild.</p><p>The command has the exact same capabilities as the existing MSBuild command-line client for SDK-style projects only. The options are all the same. For more information about the available options, see the [MSBuild command-line reference](/visualstudio/msbuild/msbuild-command-line-reference).</p><p>The [dotnet build](dotnet-build.md) command is equivalent to <c>dotnet msbuild -restore</c>. When you don't want to build the project and you have a specific target you want to run, use <c>dotnet build</c> or <c>>dotnet msbuild</c> and specify the target.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetMSBuild(DotNetMSBuildSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DotNetMSBuildSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The <c>dotnet msbuild</c> command allows access to a fully functional MSBuild.</p><p>The command has the exact same capabilities as the existing MSBuild command-line client for SDK-style projects only. The options are all the same. For more information about the available options, see the [MSBuild command-line reference](/visualstudio/msbuild/msbuild-command-line-reference).</p><p>The [dotnet build](dotnet-build.md) command is equivalent to <c>dotnet msbuild -restore</c>. When you don't want to build the project and you have a specific target you want to run, use <c>dotnet build</c> or <c>>dotnet msbuild</c> and specify the target.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        /// </remarks>
        public static IReadOnlyCollection<Output> DotNetMSBuild(Configure<DotNetMSBuildSettings> configurator)
        {
            return DotNetMSBuild(configurator(new DotNetMSBuildSettings()));
        }
        /// <summary>
        ///   <p>The <c>dotnet msbuild</c> command allows access to a fully functional MSBuild.</p><p>The command has the exact same capabilities as the existing MSBuild command-line client for SDK-style projects only. The options are all the same. For more information about the available options, see the [MSBuild command-line reference](/visualstudio/msbuild/msbuild-command-line-reference).</p><p>The [dotnet build](dotnet-build.md) command is equivalent to <c>dotnet msbuild -restore</c>. When you don't want to build the project and you have a specific target you want to run, use <c>dotnet build</c> or <c>>dotnet msbuild</c> and specify the target.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        /// </remarks>
        public static IEnumerable<(DotNetMSBuildSettings Settings, IReadOnlyCollection<Output> Output)> DotNetMSBuild(CombinatorialConfigure<DotNetMSBuildSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(DotNetMSBuild, DotNetLogger, degreeOfParallelism, completeOnFailure);
        }
#region DotNetMSBuildSettings
        /// <summary>
        ///   Used within <see cref="DotNetTasks"/>.
        /// </summary>
        [PublicAPI]
        [ExcludeFromCodeCoverage]
        [Serializable]
        public partial class DotNetMSBuildSettings : MSBuild.MSBuildSettings
        {
            /// <summary>
            ///   Path to the DotNet executable.
            /// </summary>
            public override string ProcessToolPath => base.ProcessToolPath ?? DotNetTasks.DotNetPath;
            public override Action<OutputType, string> ProcessCustomLogger => DotNetTasks.DotNetLogger;
            protected override Arguments ConfigureProcessArguments(Arguments arguments)
            {
                arguments
                .Add("msbuild");
                return base.ConfigureProcessArguments(arguments);
            }
        }
#endregion
    }
}
