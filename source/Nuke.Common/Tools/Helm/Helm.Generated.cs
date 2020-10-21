// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/Helm.json

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

namespace Nuke.Common.Tools.Helm
{
    /// <summary>
    ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmTasks
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public static string HelmPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("HELM_EXE") ??
            ToolPathResolver.GetPathExecutable("helm");
        public static Action<OutputType, string> HelmLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Helm(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, bool? logTimestamp = null, string logFile = null, Func<string, string> outputFilter = null)
        {
            using var process = ProcessTasks.StartProcess(HelmPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logTimestamp, logFile, HelmLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Generate the autocompletion script for Helm for the bash shell. To load completions in your current shell session: $ source &lt;(helm completion bash) To load completions for every new session, execute once: Linux:   $ helm completion bash &gt; /etc/bash_completion.d/helm MacOS:   $ helm completion bash &gt; /usr/local/etc/bash_completion.d/helm.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmCompletionBashSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmCompletionBash(HelmCompletionBashSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmCompletionBashSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Generate the autocompletion script for Helm for the bash shell. To load completions in your current shell session: $ source &lt;(helm completion bash) To load completions for every new session, execute once: Linux:   $ helm completion bash &gt; /etc/bash_completion.d/helm MacOS:   $ helm completion bash &gt; /usr/local/etc/bash_completion.d/helm.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmCompletionBashSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmCompletionBash(Configure<HelmCompletionBashSettings> configurator)
        {
            return HelmCompletionBash(configurator(new HelmCompletionBashSettings()));
        }
        /// <summary>
        ///   <p>Generate the autocompletion script for Helm for the bash shell. To load completions in your current shell session: $ source &lt;(helm completion bash) To load completions for every new session, execute once: Linux:   $ helm completion bash &gt; /etc/bash_completion.d/helm MacOS:   $ helm completion bash &gt; /usr/local/etc/bash_completion.d/helm.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmCompletionBashSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmCompletionBashSettings Settings, IReadOnlyCollection<Output> Output)> HelmCompletionBash(CombinatorialConfigure<HelmCompletionBashSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmCompletionBash, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Generate the autocompletion script for Helm for the zsh shell. To load completions in your current shell session: $ source &lt;(helm completion zsh) To load completions for every new session, execute once: $ helm completion zsh &gt; "${fpath[1]}/_helm".</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmCompletionZshSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmCompletionZsh(HelmCompletionZshSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmCompletionZshSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Generate the autocompletion script for Helm for the zsh shell. To load completions in your current shell session: $ source &lt;(helm completion zsh) To load completions for every new session, execute once: $ helm completion zsh &gt; "${fpath[1]}/_helm".</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmCompletionZshSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmCompletionZsh(Configure<HelmCompletionZshSettings> configurator)
        {
            return HelmCompletionZsh(configurator(new HelmCompletionZshSettings()));
        }
        /// <summary>
        ///   <p>Generate the autocompletion script for Helm for the zsh shell. To load completions in your current shell session: $ source &lt;(helm completion zsh) To load completions for every new session, execute once: $ helm completion zsh &gt; "${fpath[1]}/_helm".</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmCompletionZshSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmCompletionZshSettings Settings, IReadOnlyCollection<Output> Output)> HelmCompletionZsh(CombinatorialConfigure<HelmCompletionZshSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmCompletionZsh, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command creates a chart directory along with the common files and directories used in a chart. For example, 'helm create foo' will create a directory structure that looks something like this:     foo/     ├── .helmignore   # Contains patterns to ignore when packaging Helm charts.     ├── Chart.yaml    # Information about your chart     ├── values.yaml   # The default values for your templates     ├── charts/       # Charts that this chart depends on     └── templates/    # The template files         └── tests/    # The test files 'helm create' takes a path for an argument. If directories in the given path do not exist, Helm will attempt to create them as it goes. If the given destination exists and there are files in that directory, conflicting files will be overwritten, but other files will be left alone.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="HelmCreateSettings.Name"/></li>
        ///     <li><c>--help</c> via <see cref="HelmCreateSettings.Help"/></li>
        ///     <li><c>--starter</c> via <see cref="HelmCreateSettings.Starter"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmCreate(HelmCreateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmCreateSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command creates a chart directory along with the common files and directories used in a chart. For example, 'helm create foo' will create a directory structure that looks something like this:     foo/     ├── .helmignore   # Contains patterns to ignore when packaging Helm charts.     ├── Chart.yaml    # Information about your chart     ├── values.yaml   # The default values for your templates     ├── charts/       # Charts that this chart depends on     └── templates/    # The template files         └── tests/    # The test files 'helm create' takes a path for an argument. If directories in the given path do not exist, Helm will attempt to create them as it goes. If the given destination exists and there are files in that directory, conflicting files will be overwritten, but other files will be left alone.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="HelmCreateSettings.Name"/></li>
        ///     <li><c>--help</c> via <see cref="HelmCreateSettings.Help"/></li>
        ///     <li><c>--starter</c> via <see cref="HelmCreateSettings.Starter"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmCreate(Configure<HelmCreateSettings> configurator)
        {
            return HelmCreate(configurator(new HelmCreateSettings()));
        }
        /// <summary>
        ///   <p>This command creates a chart directory along with the common files and directories used in a chart. For example, 'helm create foo' will create a directory structure that looks something like this:     foo/     ├── .helmignore   # Contains patterns to ignore when packaging Helm charts.     ├── Chart.yaml    # Information about your chart     ├── values.yaml   # The default values for your templates     ├── charts/       # Charts that this chart depends on     └── templates/    # The template files         └── tests/    # The test files 'helm create' takes a path for an argument. If directories in the given path do not exist, Helm will attempt to create them as it goes. If the given destination exists and there are files in that directory, conflicting files will be overwritten, but other files will be left alone.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="HelmCreateSettings.Name"/></li>
        ///     <li><c>--help</c> via <see cref="HelmCreateSettings.Help"/></li>
        ///     <li><c>--starter</c> via <see cref="HelmCreateSettings.Starter"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmCreateSettings Settings, IReadOnlyCollection<Output> Output)> HelmCreate(CombinatorialConfigure<HelmCreateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmCreate, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Build out the charts/ directory from the Chart.lock file. Build is used to reconstruct a chart's dependencies to the state specified in the lock file. This will not re-negotiate dependencies, as 'helm dependency update' does. If no lock file is found, 'helm dependency build' will mirror the behavior of 'helm dependency update'.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyBuildSettings.Chart"/></li>
        ///     <li><c>--help</c> via <see cref="HelmDependencyBuildSettings.Help"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmDependencyBuildSettings.Keyring"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmDependencyBuildSettings.Verify"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmDependencyBuild(HelmDependencyBuildSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmDependencyBuildSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Build out the charts/ directory from the Chart.lock file. Build is used to reconstruct a chart's dependencies to the state specified in the lock file. This will not re-negotiate dependencies, as 'helm dependency update' does. If no lock file is found, 'helm dependency build' will mirror the behavior of 'helm dependency update'.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyBuildSettings.Chart"/></li>
        ///     <li><c>--help</c> via <see cref="HelmDependencyBuildSettings.Help"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmDependencyBuildSettings.Keyring"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmDependencyBuildSettings.Verify"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmDependencyBuild(Configure<HelmDependencyBuildSettings> configurator)
        {
            return HelmDependencyBuild(configurator(new HelmDependencyBuildSettings()));
        }
        /// <summary>
        ///   <p>Build out the charts/ directory from the Chart.lock file. Build is used to reconstruct a chart's dependencies to the state specified in the lock file. This will not re-negotiate dependencies, as 'helm dependency update' does. If no lock file is found, 'helm dependency build' will mirror the behavior of 'helm dependency update'.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyBuildSettings.Chart"/></li>
        ///     <li><c>--help</c> via <see cref="HelmDependencyBuildSettings.Help"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmDependencyBuildSettings.Keyring"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmDependencyBuildSettings.Verify"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmDependencyBuildSettings Settings, IReadOnlyCollection<Output> Output)> HelmDependencyBuild(CombinatorialConfigure<HelmDependencyBuildSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmDependencyBuild, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>List all of the dependencies declared in a chart. This can take chart archives and chart directories as input. It will not alter the contents of a chart. This will produce an error if the chart cannot be loaded.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyListSettings.Chart"/></li>
        ///     <li><c>--help</c> via <see cref="HelmDependencyListSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmDependencyList(HelmDependencyListSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmDependencyListSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>List all of the dependencies declared in a chart. This can take chart archives and chart directories as input. It will not alter the contents of a chart. This will produce an error if the chart cannot be loaded.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyListSettings.Chart"/></li>
        ///     <li><c>--help</c> via <see cref="HelmDependencyListSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmDependencyList(Configure<HelmDependencyListSettings> configurator)
        {
            return HelmDependencyList(configurator(new HelmDependencyListSettings()));
        }
        /// <summary>
        ///   <p>List all of the dependencies declared in a chart. This can take chart archives and chart directories as input. It will not alter the contents of a chart. This will produce an error if the chart cannot be loaded.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyListSettings.Chart"/></li>
        ///     <li><c>--help</c> via <see cref="HelmDependencyListSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmDependencyListSettings Settings, IReadOnlyCollection<Output> Output)> HelmDependencyList(CombinatorialConfigure<HelmDependencyListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmDependencyList, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Update the on-disk dependencies to mirror Chart.yaml. This command verifies that the required charts, as expressed in 'Chart.yaml', are present in 'charts/' and are at an acceptable version. It will pull down the latest charts that satisfy the dependencies, and clean up old dependencies. On successful update, this will generate a lock file that can be used to rebuild the dependencies to an exact version. Dependencies are not required to be represented in 'Chart.yaml'. For that reason, an update command will not remove charts unless they are (a) present in the Chart.yaml file, but (b) at the wrong version.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyUpdateSettings.Chart"/></li>
        ///     <li><c>--help</c> via <see cref="HelmDependencyUpdateSettings.Help"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmDependencyUpdateSettings.Keyring"/></li>
        ///     <li><c>--skip-refresh</c> via <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmDependencyUpdateSettings.Verify"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmDependencyUpdate(HelmDependencyUpdateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmDependencyUpdateSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Update the on-disk dependencies to mirror Chart.yaml. This command verifies that the required charts, as expressed in 'Chart.yaml', are present in 'charts/' and are at an acceptable version. It will pull down the latest charts that satisfy the dependencies, and clean up old dependencies. On successful update, this will generate a lock file that can be used to rebuild the dependencies to an exact version. Dependencies are not required to be represented in 'Chart.yaml'. For that reason, an update command will not remove charts unless they are (a) present in the Chart.yaml file, but (b) at the wrong version.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyUpdateSettings.Chart"/></li>
        ///     <li><c>--help</c> via <see cref="HelmDependencyUpdateSettings.Help"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmDependencyUpdateSettings.Keyring"/></li>
        ///     <li><c>--skip-refresh</c> via <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmDependencyUpdateSettings.Verify"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmDependencyUpdate(Configure<HelmDependencyUpdateSettings> configurator)
        {
            return HelmDependencyUpdate(configurator(new HelmDependencyUpdateSettings()));
        }
        /// <summary>
        ///   <p>Update the on-disk dependencies to mirror Chart.yaml. This command verifies that the required charts, as expressed in 'Chart.yaml', are present in 'charts/' and are at an acceptable version. It will pull down the latest charts that satisfy the dependencies, and clean up old dependencies. On successful update, this will generate a lock file that can be used to rebuild the dependencies to an exact version. Dependencies are not required to be represented in 'Chart.yaml'. For that reason, an update command will not remove charts unless they are (a) present in the Chart.yaml file, but (b) at the wrong version.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyUpdateSettings.Chart"/></li>
        ///     <li><c>--help</c> via <see cref="HelmDependencyUpdateSettings.Help"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmDependencyUpdateSettings.Keyring"/></li>
        ///     <li><c>--skip-refresh</c> via <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmDependencyUpdateSettings.Verify"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmDependencyUpdateSettings Settings, IReadOnlyCollection<Output> Output)> HelmDependencyUpdate(CombinatorialConfigure<HelmDependencyUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmDependencyUpdate, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Env prints out all the environment information in use by Helm.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmEnvSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmEnv(HelmEnvSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmEnvSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Env prints out all the environment information in use by Helm.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmEnvSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmEnv(Configure<HelmEnvSettings> configurator)
        {
            return HelmEnv(configurator(new HelmEnvSettings()));
        }
        /// <summary>
        ///   <p>Env prints out all the environment information in use by Helm.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmEnvSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmEnvSettings Settings, IReadOnlyCollection<Output> Output)> HelmEnv(CombinatorialConfigure<HelmEnvSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmEnv, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command prints a human readable collection of information about the notes, hooks, supplied values, and generated manifest file of the given release.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetAllSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetAllSettings.Help"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetAllSettings.Revision"/></li>
        ///     <li><c>--template</c> via <see cref="HelmGetAllSettings.Template"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmGetAll(HelmGetAllSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmGetAllSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command prints a human readable collection of information about the notes, hooks, supplied values, and generated manifest file of the given release.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetAllSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetAllSettings.Help"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetAllSettings.Revision"/></li>
        ///     <li><c>--template</c> via <see cref="HelmGetAllSettings.Template"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmGetAll(Configure<HelmGetAllSettings> configurator)
        {
            return HelmGetAll(configurator(new HelmGetAllSettings()));
        }
        /// <summary>
        ///   <p>This command prints a human readable collection of information about the notes, hooks, supplied values, and generated manifest file of the given release.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetAllSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetAllSettings.Help"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetAllSettings.Revision"/></li>
        ///     <li><c>--template</c> via <see cref="HelmGetAllSettings.Template"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmGetAllSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetAll(CombinatorialConfigure<HelmGetAllSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmGetAll, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command downloads hooks for a given release. Hooks are formatted in YAML and separated by the YAML '---\n' separator.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetHooksSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetHooksSettings.Help"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetHooksSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmGetHooks(HelmGetHooksSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmGetHooksSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command downloads hooks for a given release. Hooks are formatted in YAML and separated by the YAML '---\n' separator.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetHooksSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetHooksSettings.Help"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetHooksSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmGetHooks(Configure<HelmGetHooksSettings> configurator)
        {
            return HelmGetHooks(configurator(new HelmGetHooksSettings()));
        }
        /// <summary>
        ///   <p>This command downloads hooks for a given release. Hooks are formatted in YAML and separated by the YAML '---\n' separator.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetHooksSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetHooksSettings.Help"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetHooksSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmGetHooksSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetHooks(CombinatorialConfigure<HelmGetHooksSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmGetHooks, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command fetches the generated manifest for a given release. A manifest is a YAML-encoded representation of the Kubernetes resources that were generated from this release's chart(s). If a chart is dependent on other charts, those resources will also be included in the manifest.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetManifestSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetManifestSettings.Help"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetManifestSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmGetManifest(HelmGetManifestSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmGetManifestSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command fetches the generated manifest for a given release. A manifest is a YAML-encoded representation of the Kubernetes resources that were generated from this release's chart(s). If a chart is dependent on other charts, those resources will also be included in the manifest.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetManifestSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetManifestSettings.Help"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetManifestSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmGetManifest(Configure<HelmGetManifestSettings> configurator)
        {
            return HelmGetManifest(configurator(new HelmGetManifestSettings()));
        }
        /// <summary>
        ///   <p>This command fetches the generated manifest for a given release. A manifest is a YAML-encoded representation of the Kubernetes resources that were generated from this release's chart(s). If a chart is dependent on other charts, those resources will also be included in the manifest.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetManifestSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetManifestSettings.Help"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetManifestSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmGetManifestSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetManifest(CombinatorialConfigure<HelmGetManifestSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmGetManifest, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command shows notes provided by the chart of a named release.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetNotesSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetNotesSettings.Help"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetNotesSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmGetNotes(HelmGetNotesSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmGetNotesSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command shows notes provided by the chart of a named release.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetNotesSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetNotesSettings.Help"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetNotesSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmGetNotes(Configure<HelmGetNotesSettings> configurator)
        {
            return HelmGetNotes(configurator(new HelmGetNotesSettings()));
        }
        /// <summary>
        ///   <p>This command shows notes provided by the chart of a named release.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetNotesSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetNotesSettings.Help"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetNotesSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmGetNotesSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetNotes(CombinatorialConfigure<HelmGetNotesSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmGetNotes, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command downloads a values file for a given release.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetValuesSettings.ReleaseName"/></li>
        ///     <li><c>--all</c> via <see cref="HelmGetValuesSettings.All"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetValuesSettings.Help"/></li>
        ///     <li><c>--output</c> via <see cref="HelmGetValuesSettings.Output"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetValuesSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmGetValues(HelmGetValuesSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmGetValuesSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command downloads a values file for a given release.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetValuesSettings.ReleaseName"/></li>
        ///     <li><c>--all</c> via <see cref="HelmGetValuesSettings.All"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetValuesSettings.Help"/></li>
        ///     <li><c>--output</c> via <see cref="HelmGetValuesSettings.Output"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetValuesSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmGetValues(Configure<HelmGetValuesSettings> configurator)
        {
            return HelmGetValues(configurator(new HelmGetValuesSettings()));
        }
        /// <summary>
        ///   <p>This command downloads a values file for a given release.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetValuesSettings.ReleaseName"/></li>
        ///     <li><c>--all</c> via <see cref="HelmGetValuesSettings.All"/></li>
        ///     <li><c>--help</c> via <see cref="HelmGetValuesSettings.Help"/></li>
        ///     <li><c>--output</c> via <see cref="HelmGetValuesSettings.Output"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmGetValuesSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmGetValuesSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetValues(CombinatorialConfigure<HelmGetValuesSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmGetValues, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>History prints historical revisions for a given release. A default maximum of 256 revisions will be returned. Setting '--max' configures the maximum length of the revision list returned. The historical release set is printed as a formatted table, e.g:     $ helm history angry-bird     REVISION    UPDATED                     STATUS          CHART             APP VERSION     DESCRIPTION     1           Mon Oct 3 10:15:13 2016     superseded      alpine-0.1.0      1.0             Initial install     2           Mon Oct 3 10:15:13 2016     superseded      alpine-0.1.0      1.0             Upgraded successfully     3           Mon Oct 3 10:15:13 2016     superseded      alpine-0.1.0      1.0             Rolled back to 2     4           Mon Oct 3 10:15:13 2016     deployed        alpine-0.1.0      1.0             Upgraded successfully.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmHistorySettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmHistorySettings.Help"/></li>
        ///     <li><c>--max</c> via <see cref="HelmHistorySettings.Max"/></li>
        ///     <li><c>--output</c> via <see cref="HelmHistorySettings.Output"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmHistory(HelmHistorySettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmHistorySettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>History prints historical revisions for a given release. A default maximum of 256 revisions will be returned. Setting '--max' configures the maximum length of the revision list returned. The historical release set is printed as a formatted table, e.g:     $ helm history angry-bird     REVISION    UPDATED                     STATUS          CHART             APP VERSION     DESCRIPTION     1           Mon Oct 3 10:15:13 2016     superseded      alpine-0.1.0      1.0             Initial install     2           Mon Oct 3 10:15:13 2016     superseded      alpine-0.1.0      1.0             Upgraded successfully     3           Mon Oct 3 10:15:13 2016     superseded      alpine-0.1.0      1.0             Rolled back to 2     4           Mon Oct 3 10:15:13 2016     deployed        alpine-0.1.0      1.0             Upgraded successfully.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmHistorySettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmHistorySettings.Help"/></li>
        ///     <li><c>--max</c> via <see cref="HelmHistorySettings.Max"/></li>
        ///     <li><c>--output</c> via <see cref="HelmHistorySettings.Output"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmHistory(Configure<HelmHistorySettings> configurator)
        {
            return HelmHistory(configurator(new HelmHistorySettings()));
        }
        /// <summary>
        ///   <p>History prints historical revisions for a given release. A default maximum of 256 revisions will be returned. Setting '--max' configures the maximum length of the revision list returned. The historical release set is printed as a formatted table, e.g:     $ helm history angry-bird     REVISION    UPDATED                     STATUS          CHART             APP VERSION     DESCRIPTION     1           Mon Oct 3 10:15:13 2016     superseded      alpine-0.1.0      1.0             Initial install     2           Mon Oct 3 10:15:13 2016     superseded      alpine-0.1.0      1.0             Upgraded successfully     3           Mon Oct 3 10:15:13 2016     superseded      alpine-0.1.0      1.0             Rolled back to 2     4           Mon Oct 3 10:15:13 2016     deployed        alpine-0.1.0      1.0             Upgraded successfully.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmHistorySettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmHistorySettings.Help"/></li>
        ///     <li><c>--max</c> via <see cref="HelmHistorySettings.Max"/></li>
        ///     <li><c>--output</c> via <see cref="HelmHistorySettings.Output"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmHistorySettings Settings, IReadOnlyCollection<Output> Output)> HelmHistory(CombinatorialConfigure<HelmHistorySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmHistory, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command installs a chart archive. The install argument must be a chart reference, a path to a packaged chart, a path to an unpacked chart directory or a URL. To override values in a chart, use either the '--values' flag and pass in a file or use the '--set' flag and pass configuration from the command line, to force a string value use '--set-string'. In case a value is large and therefore you want not to use neither '--values' nor '--set', use '--set-file' to read the single large value from file.     $ helm install -f myvalues.yaml myredis ./redis or     $ helm install --set name=prod myredis ./redis or     $ helm install --set-string long_int=1234567890 myredis ./redis or     $ helm install --set-file my_script=dothings.sh myredis ./redis You can specify the '--values'/'-f' flag multiple times. The priority will be given to the last (right-most) file specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence:     $ helm install -f myvalues.yaml -f override.yaml  myredis ./redis You can specify the '--set' flag multiple times. The priority will be given to the last (right-most) set specified. For example, if both 'bar' and 'newbar' values are set for a key called 'foo', the 'newbar' value would take precedence:     $ helm install --set foo=bar --set foo=newbar  myredis ./redis To check the generated manifests of a release without installing the chart, the '--debug' and '--dry-run' flags can be combined. If --verify is set, the chart MUST have a provenance file, and the provenance file MUST pass all verification steps. There are five different ways you can express the chart you want to install: 1. By chart reference: helm install mymaria example/mariadb 2. By path to a packaged chart: helm install mynginx ./nginx-1.2.3.tgz 3. By path to an unpacked chart directory: helm install mynginx ./nginx 4. By absolute URL: helm install mynginx https://example.com/charts/nginx-1.2.3.tgz 5. By chart reference and repo url: helm install --repo https://example.com/charts/ mynginx nginx CHART REFERENCES A chart reference is a convenient way of referencing a chart in a chart repository. When you use a chart reference with a repo prefix ('example/mariadb'), Helm will look in the local configuration for a chart repository named 'example', and will then look for a chart in that repository whose name is 'mariadb'. It will install the latest stable version of that chart until you specify '--devel' flag to also include development version (alpha, beta, and release candidate releases), or supply a version number with the '--version' flag. To see the list of chart repositories, use 'helm repo list'. To search for charts in a repository, use 'helm search'.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInstallSettings.Chart"/></li>
        ///     <li><c>&lt;name&gt;</c> via <see cref="HelmInstallSettings.Name"/></li>
        ///     <li><c>--atomic</c> via <see cref="HelmInstallSettings.Atomic"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmInstallSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmInstallSettings.CertFile"/></li>
        ///     <li><c>--create-namespace</c> via <see cref="HelmInstallSettings.CreateNamespace"/></li>
        ///     <li><c>--dependency-update</c> via <see cref="HelmInstallSettings.DependencyUpdate"/></li>
        ///     <li><c>--description</c> via <see cref="HelmInstallSettings.Description"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmInstallSettings.Devel"/></li>
        ///     <li><c>--disable-openapi-validation</c> via <see cref="HelmInstallSettings.DisableOpenapiValidation"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmInstallSettings.DryRun"/></li>
        ///     <li><c>--generate-name</c> via <see cref="HelmInstallSettings.GenerateName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmInstallSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmInstallSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmInstallSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmInstallSettings.Keyring"/></li>
        ///     <li><c>--name-template</c> via <see cref="HelmInstallSettings.NameTemplate"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmInstallSettings.NoHooks"/></li>
        ///     <li><c>--output</c> via <see cref="HelmInstallSettings.Output"/></li>
        ///     <li><c>--password</c> via <see cref="HelmInstallSettings.Password"/></li>
        ///     <li><c>--post-renderer</c> via <see cref="HelmInstallSettings.PostRenderer"/></li>
        ///     <li><c>--render-subchart-notes</c> via <see cref="HelmInstallSettings.RenderSubchartNotes"/></li>
        ///     <li><c>--replace</c> via <see cref="HelmInstallSettings.Replace"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmInstallSettings.Repo"/></li>
        ///     <li><c>--set</c> via <see cref="HelmInstallSettings.Set"/></li>
        ///     <li><c>--set-file</c> via <see cref="HelmInstallSettings.SetFile"/></li>
        ///     <li><c>--set-string</c> via <see cref="HelmInstallSettings.SetString"/></li>
        ///     <li><c>--skip-crds</c> via <see cref="HelmInstallSettings.SkipCrds"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmInstallSettings.Timeout"/></li>
        ///     <li><c>--username</c> via <see cref="HelmInstallSettings.Username"/></li>
        ///     <li><c>--values</c> via <see cref="HelmInstallSettings.Values"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmInstallSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmInstallSettings.Version"/></li>
        ///     <li><c>--wait</c> via <see cref="HelmInstallSettings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmInstall(HelmInstallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmInstallSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command installs a chart archive. The install argument must be a chart reference, a path to a packaged chart, a path to an unpacked chart directory or a URL. To override values in a chart, use either the '--values' flag and pass in a file or use the '--set' flag and pass configuration from the command line, to force a string value use '--set-string'. In case a value is large and therefore you want not to use neither '--values' nor '--set', use '--set-file' to read the single large value from file.     $ helm install -f myvalues.yaml myredis ./redis or     $ helm install --set name=prod myredis ./redis or     $ helm install --set-string long_int=1234567890 myredis ./redis or     $ helm install --set-file my_script=dothings.sh myredis ./redis You can specify the '--values'/'-f' flag multiple times. The priority will be given to the last (right-most) file specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence:     $ helm install -f myvalues.yaml -f override.yaml  myredis ./redis You can specify the '--set' flag multiple times. The priority will be given to the last (right-most) set specified. For example, if both 'bar' and 'newbar' values are set for a key called 'foo', the 'newbar' value would take precedence:     $ helm install --set foo=bar --set foo=newbar  myredis ./redis To check the generated manifests of a release without installing the chart, the '--debug' and '--dry-run' flags can be combined. If --verify is set, the chart MUST have a provenance file, and the provenance file MUST pass all verification steps. There are five different ways you can express the chart you want to install: 1. By chart reference: helm install mymaria example/mariadb 2. By path to a packaged chart: helm install mynginx ./nginx-1.2.3.tgz 3. By path to an unpacked chart directory: helm install mynginx ./nginx 4. By absolute URL: helm install mynginx https://example.com/charts/nginx-1.2.3.tgz 5. By chart reference and repo url: helm install --repo https://example.com/charts/ mynginx nginx CHART REFERENCES A chart reference is a convenient way of referencing a chart in a chart repository. When you use a chart reference with a repo prefix ('example/mariadb'), Helm will look in the local configuration for a chart repository named 'example', and will then look for a chart in that repository whose name is 'mariadb'. It will install the latest stable version of that chart until you specify '--devel' flag to also include development version (alpha, beta, and release candidate releases), or supply a version number with the '--version' flag. To see the list of chart repositories, use 'helm repo list'. To search for charts in a repository, use 'helm search'.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInstallSettings.Chart"/></li>
        ///     <li><c>&lt;name&gt;</c> via <see cref="HelmInstallSettings.Name"/></li>
        ///     <li><c>--atomic</c> via <see cref="HelmInstallSettings.Atomic"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmInstallSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmInstallSettings.CertFile"/></li>
        ///     <li><c>--create-namespace</c> via <see cref="HelmInstallSettings.CreateNamespace"/></li>
        ///     <li><c>--dependency-update</c> via <see cref="HelmInstallSettings.DependencyUpdate"/></li>
        ///     <li><c>--description</c> via <see cref="HelmInstallSettings.Description"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmInstallSettings.Devel"/></li>
        ///     <li><c>--disable-openapi-validation</c> via <see cref="HelmInstallSettings.DisableOpenapiValidation"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmInstallSettings.DryRun"/></li>
        ///     <li><c>--generate-name</c> via <see cref="HelmInstallSettings.GenerateName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmInstallSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmInstallSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmInstallSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmInstallSettings.Keyring"/></li>
        ///     <li><c>--name-template</c> via <see cref="HelmInstallSettings.NameTemplate"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmInstallSettings.NoHooks"/></li>
        ///     <li><c>--output</c> via <see cref="HelmInstallSettings.Output"/></li>
        ///     <li><c>--password</c> via <see cref="HelmInstallSettings.Password"/></li>
        ///     <li><c>--post-renderer</c> via <see cref="HelmInstallSettings.PostRenderer"/></li>
        ///     <li><c>--render-subchart-notes</c> via <see cref="HelmInstallSettings.RenderSubchartNotes"/></li>
        ///     <li><c>--replace</c> via <see cref="HelmInstallSettings.Replace"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmInstallSettings.Repo"/></li>
        ///     <li><c>--set</c> via <see cref="HelmInstallSettings.Set"/></li>
        ///     <li><c>--set-file</c> via <see cref="HelmInstallSettings.SetFile"/></li>
        ///     <li><c>--set-string</c> via <see cref="HelmInstallSettings.SetString"/></li>
        ///     <li><c>--skip-crds</c> via <see cref="HelmInstallSettings.SkipCrds"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmInstallSettings.Timeout"/></li>
        ///     <li><c>--username</c> via <see cref="HelmInstallSettings.Username"/></li>
        ///     <li><c>--values</c> via <see cref="HelmInstallSettings.Values"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmInstallSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmInstallSettings.Version"/></li>
        ///     <li><c>--wait</c> via <see cref="HelmInstallSettings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmInstall(Configure<HelmInstallSettings> configurator)
        {
            return HelmInstall(configurator(new HelmInstallSettings()));
        }
        /// <summary>
        ///   <p>This command installs a chart archive. The install argument must be a chart reference, a path to a packaged chart, a path to an unpacked chart directory or a URL. To override values in a chart, use either the '--values' flag and pass in a file or use the '--set' flag and pass configuration from the command line, to force a string value use '--set-string'. In case a value is large and therefore you want not to use neither '--values' nor '--set', use '--set-file' to read the single large value from file.     $ helm install -f myvalues.yaml myredis ./redis or     $ helm install --set name=prod myredis ./redis or     $ helm install --set-string long_int=1234567890 myredis ./redis or     $ helm install --set-file my_script=dothings.sh myredis ./redis You can specify the '--values'/'-f' flag multiple times. The priority will be given to the last (right-most) file specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence:     $ helm install -f myvalues.yaml -f override.yaml  myredis ./redis You can specify the '--set' flag multiple times. The priority will be given to the last (right-most) set specified. For example, if both 'bar' and 'newbar' values are set for a key called 'foo', the 'newbar' value would take precedence:     $ helm install --set foo=bar --set foo=newbar  myredis ./redis To check the generated manifests of a release without installing the chart, the '--debug' and '--dry-run' flags can be combined. If --verify is set, the chart MUST have a provenance file, and the provenance file MUST pass all verification steps. There are five different ways you can express the chart you want to install: 1. By chart reference: helm install mymaria example/mariadb 2. By path to a packaged chart: helm install mynginx ./nginx-1.2.3.tgz 3. By path to an unpacked chart directory: helm install mynginx ./nginx 4. By absolute URL: helm install mynginx https://example.com/charts/nginx-1.2.3.tgz 5. By chart reference and repo url: helm install --repo https://example.com/charts/ mynginx nginx CHART REFERENCES A chart reference is a convenient way of referencing a chart in a chart repository. When you use a chart reference with a repo prefix ('example/mariadb'), Helm will look in the local configuration for a chart repository named 'example', and will then look for a chart in that repository whose name is 'mariadb'. It will install the latest stable version of that chart until you specify '--devel' flag to also include development version (alpha, beta, and release candidate releases), or supply a version number with the '--version' flag. To see the list of chart repositories, use 'helm repo list'. To search for charts in a repository, use 'helm search'.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmInstallSettings.Chart"/></li>
        ///     <li><c>&lt;name&gt;</c> via <see cref="HelmInstallSettings.Name"/></li>
        ///     <li><c>--atomic</c> via <see cref="HelmInstallSettings.Atomic"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmInstallSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmInstallSettings.CertFile"/></li>
        ///     <li><c>--create-namespace</c> via <see cref="HelmInstallSettings.CreateNamespace"/></li>
        ///     <li><c>--dependency-update</c> via <see cref="HelmInstallSettings.DependencyUpdate"/></li>
        ///     <li><c>--description</c> via <see cref="HelmInstallSettings.Description"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmInstallSettings.Devel"/></li>
        ///     <li><c>--disable-openapi-validation</c> via <see cref="HelmInstallSettings.DisableOpenapiValidation"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmInstallSettings.DryRun"/></li>
        ///     <li><c>--generate-name</c> via <see cref="HelmInstallSettings.GenerateName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmInstallSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmInstallSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmInstallSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmInstallSettings.Keyring"/></li>
        ///     <li><c>--name-template</c> via <see cref="HelmInstallSettings.NameTemplate"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmInstallSettings.NoHooks"/></li>
        ///     <li><c>--output</c> via <see cref="HelmInstallSettings.Output"/></li>
        ///     <li><c>--password</c> via <see cref="HelmInstallSettings.Password"/></li>
        ///     <li><c>--post-renderer</c> via <see cref="HelmInstallSettings.PostRenderer"/></li>
        ///     <li><c>--render-subchart-notes</c> via <see cref="HelmInstallSettings.RenderSubchartNotes"/></li>
        ///     <li><c>--replace</c> via <see cref="HelmInstallSettings.Replace"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmInstallSettings.Repo"/></li>
        ///     <li><c>--set</c> via <see cref="HelmInstallSettings.Set"/></li>
        ///     <li><c>--set-file</c> via <see cref="HelmInstallSettings.SetFile"/></li>
        ///     <li><c>--set-string</c> via <see cref="HelmInstallSettings.SetString"/></li>
        ///     <li><c>--skip-crds</c> via <see cref="HelmInstallSettings.SkipCrds"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmInstallSettings.Timeout"/></li>
        ///     <li><c>--username</c> via <see cref="HelmInstallSettings.Username"/></li>
        ///     <li><c>--values</c> via <see cref="HelmInstallSettings.Values"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmInstallSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmInstallSettings.Version"/></li>
        ///     <li><c>--wait</c> via <see cref="HelmInstallSettings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmInstallSettings Settings, IReadOnlyCollection<Output> Output)> HelmInstall(CombinatorialConfigure<HelmInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmInstall, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command takes a path to a chart and runs a series of tests to verify that the chart is well-formed. If the linter encounters things that will cause the chart to fail installation, it will emit [ERROR] messages. If it encounters issues that break with convention or recommendation, it will emit [WARNING] messages.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;path&gt;</c> via <see cref="HelmLintSettings.Path"/></li>
        ///     <li><c>--help</c> via <see cref="HelmLintSettings.Help"/></li>
        ///     <li><c>--set</c> via <see cref="HelmLintSettings.Set"/></li>
        ///     <li><c>--set-file</c> via <see cref="HelmLintSettings.SetFile"/></li>
        ///     <li><c>--set-string</c> via <see cref="HelmLintSettings.SetString"/></li>
        ///     <li><c>--strict</c> via <see cref="HelmLintSettings.Strict"/></li>
        ///     <li><c>--values</c> via <see cref="HelmLintSettings.Values"/></li>
        ///     <li><c>--with-subcharts</c> via <see cref="HelmLintSettings.WithSubcharts"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmLint(HelmLintSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmLintSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command takes a path to a chart and runs a series of tests to verify that the chart is well-formed. If the linter encounters things that will cause the chart to fail installation, it will emit [ERROR] messages. If it encounters issues that break with convention or recommendation, it will emit [WARNING] messages.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;path&gt;</c> via <see cref="HelmLintSettings.Path"/></li>
        ///     <li><c>--help</c> via <see cref="HelmLintSettings.Help"/></li>
        ///     <li><c>--set</c> via <see cref="HelmLintSettings.Set"/></li>
        ///     <li><c>--set-file</c> via <see cref="HelmLintSettings.SetFile"/></li>
        ///     <li><c>--set-string</c> via <see cref="HelmLintSettings.SetString"/></li>
        ///     <li><c>--strict</c> via <see cref="HelmLintSettings.Strict"/></li>
        ///     <li><c>--values</c> via <see cref="HelmLintSettings.Values"/></li>
        ///     <li><c>--with-subcharts</c> via <see cref="HelmLintSettings.WithSubcharts"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmLint(Configure<HelmLintSettings> configurator)
        {
            return HelmLint(configurator(new HelmLintSettings()));
        }
        /// <summary>
        ///   <p>This command takes a path to a chart and runs a series of tests to verify that the chart is well-formed. If the linter encounters things that will cause the chart to fail installation, it will emit [ERROR] messages. If it encounters issues that break with convention or recommendation, it will emit [WARNING] messages.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;path&gt;</c> via <see cref="HelmLintSettings.Path"/></li>
        ///     <li><c>--help</c> via <see cref="HelmLintSettings.Help"/></li>
        ///     <li><c>--set</c> via <see cref="HelmLintSettings.Set"/></li>
        ///     <li><c>--set-file</c> via <see cref="HelmLintSettings.SetFile"/></li>
        ///     <li><c>--set-string</c> via <see cref="HelmLintSettings.SetString"/></li>
        ///     <li><c>--strict</c> via <see cref="HelmLintSettings.Strict"/></li>
        ///     <li><c>--values</c> via <see cref="HelmLintSettings.Values"/></li>
        ///     <li><c>--with-subcharts</c> via <see cref="HelmLintSettings.WithSubcharts"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmLintSettings Settings, IReadOnlyCollection<Output> Output)> HelmLint(CombinatorialConfigure<HelmLintSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmLint, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command lists all of the releases for a specified namespace (uses current namespace context if namespace not specified). By default, it lists only releases that are deployed or failed. Flags like '--uninstalled' and '--all' will alter this behavior. Such flags can be combined: '--uninstalled --failed'. By default, items are sorted alphabetically. Use the '-d' flag to sort by release date. If the --filter flag is provided, it will be treated as a filter. Filters are regular expressions (Perl compatible) that are applied to the list of releases. Only items that match the filter will be returned.     $ helm list --filter 'ara[a-z]+'     NAME                UPDATED                     CHART     maudlin-arachnid    Mon May  9 16:07:08 2016    alpine-0.1.0 If no results are found, 'helm list' will exit 0, but with no output (or in the case of no '-q' flag, only headers). By default, up to 256 items may be returned. To limit this, use the '--max' flag. Setting '--max' to 0 will not return all results. Rather, it will return the server's default, which may be much higher than 256. Pairing the '--max' flag with the '--offset' flag allows you to page through results.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--all</c> via <see cref="HelmListSettings.All"/></li>
        ///     <li><c>--all-namespaces</c> via <see cref="HelmListSettings.AllNamespaces"/></li>
        ///     <li><c>--date</c> via <see cref="HelmListSettings.Date"/></li>
        ///     <li><c>--deployed</c> via <see cref="HelmListSettings.Deployed"/></li>
        ///     <li><c>--failed</c> via <see cref="HelmListSettings.Failed"/></li>
        ///     <li><c>--filter</c> via <see cref="HelmListSettings.Filter"/></li>
        ///     <li><c>--help</c> via <see cref="HelmListSettings.Help"/></li>
        ///     <li><c>--max</c> via <see cref="HelmListSettings.Max"/></li>
        ///     <li><c>--offset</c> via <see cref="HelmListSettings.Offset"/></li>
        ///     <li><c>--output</c> via <see cref="HelmListSettings.Output"/></li>
        ///     <li><c>--pending</c> via <see cref="HelmListSettings.Pending"/></li>
        ///     <li><c>--reverse</c> via <see cref="HelmListSettings.Reverse"/></li>
        ///     <li><c>--short</c> via <see cref="HelmListSettings.Short"/></li>
        ///     <li><c>--superseded</c> via <see cref="HelmListSettings.Superseded"/></li>
        ///     <li><c>--uninstalled</c> via <see cref="HelmListSettings.Uninstalled"/></li>
        ///     <li><c>--uninstalling</c> via <see cref="HelmListSettings.Uninstalling"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmList(HelmListSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmListSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command lists all of the releases for a specified namespace (uses current namespace context if namespace not specified). By default, it lists only releases that are deployed or failed. Flags like '--uninstalled' and '--all' will alter this behavior. Such flags can be combined: '--uninstalled --failed'. By default, items are sorted alphabetically. Use the '-d' flag to sort by release date. If the --filter flag is provided, it will be treated as a filter. Filters are regular expressions (Perl compatible) that are applied to the list of releases. Only items that match the filter will be returned.     $ helm list --filter 'ara[a-z]+'     NAME                UPDATED                     CHART     maudlin-arachnid    Mon May  9 16:07:08 2016    alpine-0.1.0 If no results are found, 'helm list' will exit 0, but with no output (or in the case of no '-q' flag, only headers). By default, up to 256 items may be returned. To limit this, use the '--max' flag. Setting '--max' to 0 will not return all results. Rather, it will return the server's default, which may be much higher than 256. Pairing the '--max' flag with the '--offset' flag allows you to page through results.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--all</c> via <see cref="HelmListSettings.All"/></li>
        ///     <li><c>--all-namespaces</c> via <see cref="HelmListSettings.AllNamespaces"/></li>
        ///     <li><c>--date</c> via <see cref="HelmListSettings.Date"/></li>
        ///     <li><c>--deployed</c> via <see cref="HelmListSettings.Deployed"/></li>
        ///     <li><c>--failed</c> via <see cref="HelmListSettings.Failed"/></li>
        ///     <li><c>--filter</c> via <see cref="HelmListSettings.Filter"/></li>
        ///     <li><c>--help</c> via <see cref="HelmListSettings.Help"/></li>
        ///     <li><c>--max</c> via <see cref="HelmListSettings.Max"/></li>
        ///     <li><c>--offset</c> via <see cref="HelmListSettings.Offset"/></li>
        ///     <li><c>--output</c> via <see cref="HelmListSettings.Output"/></li>
        ///     <li><c>--pending</c> via <see cref="HelmListSettings.Pending"/></li>
        ///     <li><c>--reverse</c> via <see cref="HelmListSettings.Reverse"/></li>
        ///     <li><c>--short</c> via <see cref="HelmListSettings.Short"/></li>
        ///     <li><c>--superseded</c> via <see cref="HelmListSettings.Superseded"/></li>
        ///     <li><c>--uninstalled</c> via <see cref="HelmListSettings.Uninstalled"/></li>
        ///     <li><c>--uninstalling</c> via <see cref="HelmListSettings.Uninstalling"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmList(Configure<HelmListSettings> configurator)
        {
            return HelmList(configurator(new HelmListSettings()));
        }
        /// <summary>
        ///   <p>This command lists all of the releases for a specified namespace (uses current namespace context if namespace not specified). By default, it lists only releases that are deployed or failed. Flags like '--uninstalled' and '--all' will alter this behavior. Such flags can be combined: '--uninstalled --failed'. By default, items are sorted alphabetically. Use the '-d' flag to sort by release date. If the --filter flag is provided, it will be treated as a filter. Filters are regular expressions (Perl compatible) that are applied to the list of releases. Only items that match the filter will be returned.     $ helm list --filter 'ara[a-z]+'     NAME                UPDATED                     CHART     maudlin-arachnid    Mon May  9 16:07:08 2016    alpine-0.1.0 If no results are found, 'helm list' will exit 0, but with no output (or in the case of no '-q' flag, only headers). By default, up to 256 items may be returned. To limit this, use the '--max' flag. Setting '--max' to 0 will not return all results. Rather, it will return the server's default, which may be much higher than 256. Pairing the '--max' flag with the '--offset' flag allows you to page through results.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--all</c> via <see cref="HelmListSettings.All"/></li>
        ///     <li><c>--all-namespaces</c> via <see cref="HelmListSettings.AllNamespaces"/></li>
        ///     <li><c>--date</c> via <see cref="HelmListSettings.Date"/></li>
        ///     <li><c>--deployed</c> via <see cref="HelmListSettings.Deployed"/></li>
        ///     <li><c>--failed</c> via <see cref="HelmListSettings.Failed"/></li>
        ///     <li><c>--filter</c> via <see cref="HelmListSettings.Filter"/></li>
        ///     <li><c>--help</c> via <see cref="HelmListSettings.Help"/></li>
        ///     <li><c>--max</c> via <see cref="HelmListSettings.Max"/></li>
        ///     <li><c>--offset</c> via <see cref="HelmListSettings.Offset"/></li>
        ///     <li><c>--output</c> via <see cref="HelmListSettings.Output"/></li>
        ///     <li><c>--pending</c> via <see cref="HelmListSettings.Pending"/></li>
        ///     <li><c>--reverse</c> via <see cref="HelmListSettings.Reverse"/></li>
        ///     <li><c>--short</c> via <see cref="HelmListSettings.Short"/></li>
        ///     <li><c>--superseded</c> via <see cref="HelmListSettings.Superseded"/></li>
        ///     <li><c>--uninstalled</c> via <see cref="HelmListSettings.Uninstalled"/></li>
        ///     <li><c>--uninstalling</c> via <see cref="HelmListSettings.Uninstalling"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmListSettings Settings, IReadOnlyCollection<Output> Output)> HelmList(CombinatorialConfigure<HelmListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmList, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command packages a chart into a versioned chart archive file. If a path is given, this will look at that path for a chart (which must contain a Chart.yaml file) and then package that directory. Versioned chart archives are used by Helm package repositories. To sign a chart, use the '--sign' flag. In most cases, you should also provide '--keyring path/to/secret/keys' and '--key keyname'.   $ helm package --sign ./mychart --key mykey --keyring ~/.gnupg/secring.gpg If '--keyring' is not specified, Helm usually defaults to the public keyring unless your environment is otherwise configured.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chartPaths&gt;</c> via <see cref="HelmPackageSettings.ChartPaths"/></li>
        ///     <li><c>--app-version</c> via <see cref="HelmPackageSettings.AppVersion"/></li>
        ///     <li><c>--dependency-update</c> via <see cref="HelmPackageSettings.DependencyUpdate"/></li>
        ///     <li><c>--destination</c> via <see cref="HelmPackageSettings.Destination"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPackageSettings.Help"/></li>
        ///     <li><c>--key</c> via <see cref="HelmPackageSettings.Key"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmPackageSettings.Keyring"/></li>
        ///     <li><c>--sign</c> via <see cref="HelmPackageSettings.Sign"/></li>
        ///     <li><c>--version</c> via <see cref="HelmPackageSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmPackage(HelmPackageSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmPackageSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command packages a chart into a versioned chart archive file. If a path is given, this will look at that path for a chart (which must contain a Chart.yaml file) and then package that directory. Versioned chart archives are used by Helm package repositories. To sign a chart, use the '--sign' flag. In most cases, you should also provide '--keyring path/to/secret/keys' and '--key keyname'.   $ helm package --sign ./mychart --key mykey --keyring ~/.gnupg/secring.gpg If '--keyring' is not specified, Helm usually defaults to the public keyring unless your environment is otherwise configured.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chartPaths&gt;</c> via <see cref="HelmPackageSettings.ChartPaths"/></li>
        ///     <li><c>--app-version</c> via <see cref="HelmPackageSettings.AppVersion"/></li>
        ///     <li><c>--dependency-update</c> via <see cref="HelmPackageSettings.DependencyUpdate"/></li>
        ///     <li><c>--destination</c> via <see cref="HelmPackageSettings.Destination"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPackageSettings.Help"/></li>
        ///     <li><c>--key</c> via <see cref="HelmPackageSettings.Key"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmPackageSettings.Keyring"/></li>
        ///     <li><c>--sign</c> via <see cref="HelmPackageSettings.Sign"/></li>
        ///     <li><c>--version</c> via <see cref="HelmPackageSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmPackage(Configure<HelmPackageSettings> configurator)
        {
            return HelmPackage(configurator(new HelmPackageSettings()));
        }
        /// <summary>
        ///   <p>This command packages a chart into a versioned chart archive file. If a path is given, this will look at that path for a chart (which must contain a Chart.yaml file) and then package that directory. Versioned chart archives are used by Helm package repositories. To sign a chart, use the '--sign' flag. In most cases, you should also provide '--keyring path/to/secret/keys' and '--key keyname'.   $ helm package --sign ./mychart --key mykey --keyring ~/.gnupg/secring.gpg If '--keyring' is not specified, Helm usually defaults to the public keyring unless your environment is otherwise configured.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chartPaths&gt;</c> via <see cref="HelmPackageSettings.ChartPaths"/></li>
        ///     <li><c>--app-version</c> via <see cref="HelmPackageSettings.AppVersion"/></li>
        ///     <li><c>--dependency-update</c> via <see cref="HelmPackageSettings.DependencyUpdate"/></li>
        ///     <li><c>--destination</c> via <see cref="HelmPackageSettings.Destination"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPackageSettings.Help"/></li>
        ///     <li><c>--key</c> via <see cref="HelmPackageSettings.Key"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmPackageSettings.Keyring"/></li>
        ///     <li><c>--sign</c> via <see cref="HelmPackageSettings.Sign"/></li>
        ///     <li><c>--version</c> via <see cref="HelmPackageSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmPackageSettings Settings, IReadOnlyCollection<Output> Output)> HelmPackage(CombinatorialConfigure<HelmPackageSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmPackage, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command allows you to install a plugin from a url to a VCS repo or a local path.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;options&gt;</c> via <see cref="HelmPluginInstallSettings.Options"/></li>
        ///     <li><c>&lt;paths&gt;</c> via <see cref="HelmPluginInstallSettings.Paths"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPluginInstallSettings.Help"/></li>
        ///     <li><c>--version</c> via <see cref="HelmPluginInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmPluginInstall(HelmPluginInstallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmPluginInstallSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command allows you to install a plugin from a url to a VCS repo or a local path.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;options&gt;</c> via <see cref="HelmPluginInstallSettings.Options"/></li>
        ///     <li><c>&lt;paths&gt;</c> via <see cref="HelmPluginInstallSettings.Paths"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPluginInstallSettings.Help"/></li>
        ///     <li><c>--version</c> via <see cref="HelmPluginInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmPluginInstall(Configure<HelmPluginInstallSettings> configurator)
        {
            return HelmPluginInstall(configurator(new HelmPluginInstallSettings()));
        }
        /// <summary>
        ///   <p>This command allows you to install a plugin from a url to a VCS repo or a local path.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;options&gt;</c> via <see cref="HelmPluginInstallSettings.Options"/></li>
        ///     <li><c>&lt;paths&gt;</c> via <see cref="HelmPluginInstallSettings.Paths"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPluginInstallSettings.Help"/></li>
        ///     <li><c>--version</c> via <see cref="HelmPluginInstallSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmPluginInstallSettings Settings, IReadOnlyCollection<Output> Output)> HelmPluginInstall(CombinatorialConfigure<HelmPluginInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmPluginInstall, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>List installed Helm plugins.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmPluginListSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmPluginList(HelmPluginListSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmPluginListSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>List installed Helm plugins.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmPluginListSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmPluginList(Configure<HelmPluginListSettings> configurator)
        {
            return HelmPluginList(configurator(new HelmPluginListSettings()));
        }
        /// <summary>
        ///   <p>List installed Helm plugins.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmPluginListSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmPluginListSettings Settings, IReadOnlyCollection<Output> Output)> HelmPluginList(CombinatorialConfigure<HelmPluginListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmPluginList, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Uninstall one or more Helm plugins.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginUninstallSettings.Plugins"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPluginUninstallSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmPluginUninstall(HelmPluginUninstallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmPluginUninstallSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Uninstall one or more Helm plugins.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginUninstallSettings.Plugins"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPluginUninstallSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmPluginUninstall(Configure<HelmPluginUninstallSettings> configurator)
        {
            return HelmPluginUninstall(configurator(new HelmPluginUninstallSettings()));
        }
        /// <summary>
        ///   <p>Uninstall one or more Helm plugins.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginUninstallSettings.Plugins"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPluginUninstallSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmPluginUninstallSettings Settings, IReadOnlyCollection<Output> Output)> HelmPluginUninstall(CombinatorialConfigure<HelmPluginUninstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmPluginUninstall, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Update one or more Helm plugins.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginUpdateSettings.Plugins"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPluginUpdateSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmPluginUpdate(HelmPluginUpdateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmPluginUpdateSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Update one or more Helm plugins.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginUpdateSettings.Plugins"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPluginUpdateSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmPluginUpdate(Configure<HelmPluginUpdateSettings> configurator)
        {
            return HelmPluginUpdate(configurator(new HelmPluginUpdateSettings()));
        }
        /// <summary>
        ///   <p>Update one or more Helm plugins.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginUpdateSettings.Plugins"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPluginUpdateSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmPluginUpdateSettings Settings, IReadOnlyCollection<Output> Output)> HelmPluginUpdate(CombinatorialConfigure<HelmPluginUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmPluginUpdate, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Retrieve a package from a package repository, and download it locally. This is useful for fetching packages to inspect, modify, or repackage. It can also be used to perform cryptographic verification of a chart without installing the chart. There are options for unpacking the chart after download. This will create a directory for the chart and uncompress into that directory. If the --verify flag is specified, the requested chart MUST have a provenance file, and MUST pass the verification process. Failure in any part of this will result in an error, and the chart will not be saved locally.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;urls&gt;</c> via <see cref="HelmPullSettings.Urls"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmPullSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmPullSettings.CertFile"/></li>
        ///     <li><c>--destination</c> via <see cref="HelmPullSettings.Destination"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmPullSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPullSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmPullSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmPullSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmPullSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmPullSettings.Password"/></li>
        ///     <li><c>--prov</c> via <see cref="HelmPullSettings.Prov"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmPullSettings.Repo"/></li>
        ///     <li><c>--untar</c> via <see cref="HelmPullSettings.Untar"/></li>
        ///     <li><c>--untardir</c> via <see cref="HelmPullSettings.Untardir"/></li>
        ///     <li><c>--username</c> via <see cref="HelmPullSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmPullSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmPullSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmPull(HelmPullSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmPullSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Retrieve a package from a package repository, and download it locally. This is useful for fetching packages to inspect, modify, or repackage. It can also be used to perform cryptographic verification of a chart without installing the chart. There are options for unpacking the chart after download. This will create a directory for the chart and uncompress into that directory. If the --verify flag is specified, the requested chart MUST have a provenance file, and MUST pass the verification process. Failure in any part of this will result in an error, and the chart will not be saved locally.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;urls&gt;</c> via <see cref="HelmPullSettings.Urls"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmPullSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmPullSettings.CertFile"/></li>
        ///     <li><c>--destination</c> via <see cref="HelmPullSettings.Destination"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmPullSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPullSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmPullSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmPullSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmPullSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmPullSettings.Password"/></li>
        ///     <li><c>--prov</c> via <see cref="HelmPullSettings.Prov"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmPullSettings.Repo"/></li>
        ///     <li><c>--untar</c> via <see cref="HelmPullSettings.Untar"/></li>
        ///     <li><c>--untardir</c> via <see cref="HelmPullSettings.Untardir"/></li>
        ///     <li><c>--username</c> via <see cref="HelmPullSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmPullSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmPullSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmPull(Configure<HelmPullSettings> configurator)
        {
            return HelmPull(configurator(new HelmPullSettings()));
        }
        /// <summary>
        ///   <p>Retrieve a package from a package repository, and download it locally. This is useful for fetching packages to inspect, modify, or repackage. It can also be used to perform cryptographic verification of a chart without installing the chart. There are options for unpacking the chart after download. This will create a directory for the chart and uncompress into that directory. If the --verify flag is specified, the requested chart MUST have a provenance file, and MUST pass the verification process. Failure in any part of this will result in an error, and the chart will not be saved locally.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;urls&gt;</c> via <see cref="HelmPullSettings.Urls"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmPullSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmPullSettings.CertFile"/></li>
        ///     <li><c>--destination</c> via <see cref="HelmPullSettings.Destination"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmPullSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmPullSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmPullSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmPullSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmPullSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmPullSettings.Password"/></li>
        ///     <li><c>--prov</c> via <see cref="HelmPullSettings.Prov"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmPullSettings.Repo"/></li>
        ///     <li><c>--untar</c> via <see cref="HelmPullSettings.Untar"/></li>
        ///     <li><c>--untardir</c> via <see cref="HelmPullSettings.Untardir"/></li>
        ///     <li><c>--username</c> via <see cref="HelmPullSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmPullSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmPullSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmPullSettings Settings, IReadOnlyCollection<Output> Output)> HelmPull(CombinatorialConfigure<HelmPullSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmPull, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Add a chart repository.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="HelmRepoAddSettings.Name"/></li>
        ///     <li><c>&lt;url&gt;</c> via <see cref="HelmRepoAddSettings.Url"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmRepoAddSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmRepoAddSettings.CertFile"/></li>
        ///     <li><c>--force-update</c> via <see cref="HelmRepoAddSettings.ForceUpdate"/></li>
        ///     <li><c>--help</c> via <see cref="HelmRepoAddSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmRepoAddSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmRepoAddSettings.KeyFile"/></li>
        ///     <li><c>--no-update</c> via <see cref="HelmRepoAddSettings.NoUpdate"/></li>
        ///     <li><c>--password</c> via <see cref="HelmRepoAddSettings.Password"/></li>
        ///     <li><c>--username</c> via <see cref="HelmRepoAddSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmRepoAdd(HelmRepoAddSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmRepoAddSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Add a chart repository.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="HelmRepoAddSettings.Name"/></li>
        ///     <li><c>&lt;url&gt;</c> via <see cref="HelmRepoAddSettings.Url"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmRepoAddSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmRepoAddSettings.CertFile"/></li>
        ///     <li><c>--force-update</c> via <see cref="HelmRepoAddSettings.ForceUpdate"/></li>
        ///     <li><c>--help</c> via <see cref="HelmRepoAddSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmRepoAddSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmRepoAddSettings.KeyFile"/></li>
        ///     <li><c>--no-update</c> via <see cref="HelmRepoAddSettings.NoUpdate"/></li>
        ///     <li><c>--password</c> via <see cref="HelmRepoAddSettings.Password"/></li>
        ///     <li><c>--username</c> via <see cref="HelmRepoAddSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmRepoAdd(Configure<HelmRepoAddSettings> configurator)
        {
            return HelmRepoAdd(configurator(new HelmRepoAddSettings()));
        }
        /// <summary>
        ///   <p>Add a chart repository.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;name&gt;</c> via <see cref="HelmRepoAddSettings.Name"/></li>
        ///     <li><c>&lt;url&gt;</c> via <see cref="HelmRepoAddSettings.Url"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmRepoAddSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmRepoAddSettings.CertFile"/></li>
        ///     <li><c>--force-update</c> via <see cref="HelmRepoAddSettings.ForceUpdate"/></li>
        ///     <li><c>--help</c> via <see cref="HelmRepoAddSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmRepoAddSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmRepoAddSettings.KeyFile"/></li>
        ///     <li><c>--no-update</c> via <see cref="HelmRepoAddSettings.NoUpdate"/></li>
        ///     <li><c>--password</c> via <see cref="HelmRepoAddSettings.Password"/></li>
        ///     <li><c>--username</c> via <see cref="HelmRepoAddSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmRepoAddSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoAdd(CombinatorialConfigure<HelmRepoAddSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmRepoAdd, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Read the current directory and generate an index file based on the charts found. This tool is used for creating an 'index.yaml' file for a chart repository. To set an absolute URL to the charts, use '--url' flag. To merge the generated index with an existing index file, use the '--merge' flag. In this case, the charts found in the current directory will be merged into the existing index, with local charts taking priority over existing charts.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;directory&gt;</c> via <see cref="HelmRepoIndexSettings.Directory"/></li>
        ///     <li><c>--help</c> via <see cref="HelmRepoIndexSettings.Help"/></li>
        ///     <li><c>--merge</c> via <see cref="HelmRepoIndexSettings.Merge"/></li>
        ///     <li><c>--url</c> via <see cref="HelmRepoIndexSettings.Url"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmRepoIndex(HelmRepoIndexSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmRepoIndexSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Read the current directory and generate an index file based on the charts found. This tool is used for creating an 'index.yaml' file for a chart repository. To set an absolute URL to the charts, use '--url' flag. To merge the generated index with an existing index file, use the '--merge' flag. In this case, the charts found in the current directory will be merged into the existing index, with local charts taking priority over existing charts.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;directory&gt;</c> via <see cref="HelmRepoIndexSettings.Directory"/></li>
        ///     <li><c>--help</c> via <see cref="HelmRepoIndexSettings.Help"/></li>
        ///     <li><c>--merge</c> via <see cref="HelmRepoIndexSettings.Merge"/></li>
        ///     <li><c>--url</c> via <see cref="HelmRepoIndexSettings.Url"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmRepoIndex(Configure<HelmRepoIndexSettings> configurator)
        {
            return HelmRepoIndex(configurator(new HelmRepoIndexSettings()));
        }
        /// <summary>
        ///   <p>Read the current directory and generate an index file based on the charts found. This tool is used for creating an 'index.yaml' file for a chart repository. To set an absolute URL to the charts, use '--url' flag. To merge the generated index with an existing index file, use the '--merge' flag. In this case, the charts found in the current directory will be merged into the existing index, with local charts taking priority over existing charts.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;directory&gt;</c> via <see cref="HelmRepoIndexSettings.Directory"/></li>
        ///     <li><c>--help</c> via <see cref="HelmRepoIndexSettings.Help"/></li>
        ///     <li><c>--merge</c> via <see cref="HelmRepoIndexSettings.Merge"/></li>
        ///     <li><c>--url</c> via <see cref="HelmRepoIndexSettings.Url"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmRepoIndexSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoIndex(CombinatorialConfigure<HelmRepoIndexSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmRepoIndex, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>List chart repositories.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmRepoListSettings.Help"/></li>
        ///     <li><c>--output</c> via <see cref="HelmRepoListSettings.Output"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmRepoList(HelmRepoListSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmRepoListSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>List chart repositories.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmRepoListSettings.Help"/></li>
        ///     <li><c>--output</c> via <see cref="HelmRepoListSettings.Output"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmRepoList(Configure<HelmRepoListSettings> configurator)
        {
            return HelmRepoList(configurator(new HelmRepoListSettings()));
        }
        /// <summary>
        ///   <p>List chart repositories.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmRepoListSettings.Help"/></li>
        ///     <li><c>--output</c> via <see cref="HelmRepoListSettings.Output"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmRepoListSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoList(CombinatorialConfigure<HelmRepoListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmRepoList, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Remove one or more chart repositories.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;repositories&gt;</c> via <see cref="HelmRepoRemoveSettings.Repositories"/></li>
        ///     <li><c>--help</c> via <see cref="HelmRepoRemoveSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmRepoRemove(HelmRepoRemoveSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmRepoRemoveSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Remove one or more chart repositories.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;repositories&gt;</c> via <see cref="HelmRepoRemoveSettings.Repositories"/></li>
        ///     <li><c>--help</c> via <see cref="HelmRepoRemoveSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmRepoRemove(Configure<HelmRepoRemoveSettings> configurator)
        {
            return HelmRepoRemove(configurator(new HelmRepoRemoveSettings()));
        }
        /// <summary>
        ///   <p>Remove one or more chart repositories.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;repositories&gt;</c> via <see cref="HelmRepoRemoveSettings.Repositories"/></li>
        ///     <li><c>--help</c> via <see cref="HelmRepoRemoveSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmRepoRemoveSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoRemove(CombinatorialConfigure<HelmRepoRemoveSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmRepoRemove, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Update gets the latest information about charts from the respective chart repositories. Information is cached locally, where it is used by commands like 'helm search'.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmRepoUpdateSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmRepoUpdate(HelmRepoUpdateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmRepoUpdateSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Update gets the latest information about charts from the respective chart repositories. Information is cached locally, where it is used by commands like 'helm search'.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmRepoUpdateSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmRepoUpdate(Configure<HelmRepoUpdateSettings> configurator)
        {
            return HelmRepoUpdate(configurator(new HelmRepoUpdateSettings()));
        }
        /// <summary>
        ///   <p>Update gets the latest information about charts from the respective chart repositories. Information is cached locally, where it is used by commands like 'helm search'.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmRepoUpdateSettings.Help"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmRepoUpdateSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoUpdate(CombinatorialConfigure<HelmRepoUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmRepoUpdate, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command rolls back a release to a previous revision. The first argument of the rollback command is the name of a release, and the second is a revision (version) number. If this argument is omitted, it will roll back to the previous release. To see revision numbers, run 'helm history RELEASE'.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;release&gt;</c> via <see cref="HelmRollbackSettings.Release"/></li>
        ///     <li><c>&lt;revision&gt;</c> via <see cref="HelmRollbackSettings.Revision"/></li>
        ///     <li><c>--cleanup-on-fail</c> via <see cref="HelmRollbackSettings.CleanupOnFail"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmRollbackSettings.DryRun"/></li>
        ///     <li><c>--force</c> via <see cref="HelmRollbackSettings.Force"/></li>
        ///     <li><c>--help</c> via <see cref="HelmRollbackSettings.Help"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmRollbackSettings.NoHooks"/></li>
        ///     <li><c>--recreate-pods</c> via <see cref="HelmRollbackSettings.RecreatePods"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmRollbackSettings.Timeout"/></li>
        ///     <li><c>--wait</c> via <see cref="HelmRollbackSettings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmRollback(HelmRollbackSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmRollbackSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command rolls back a release to a previous revision. The first argument of the rollback command is the name of a release, and the second is a revision (version) number. If this argument is omitted, it will roll back to the previous release. To see revision numbers, run 'helm history RELEASE'.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;release&gt;</c> via <see cref="HelmRollbackSettings.Release"/></li>
        ///     <li><c>&lt;revision&gt;</c> via <see cref="HelmRollbackSettings.Revision"/></li>
        ///     <li><c>--cleanup-on-fail</c> via <see cref="HelmRollbackSettings.CleanupOnFail"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmRollbackSettings.DryRun"/></li>
        ///     <li><c>--force</c> via <see cref="HelmRollbackSettings.Force"/></li>
        ///     <li><c>--help</c> via <see cref="HelmRollbackSettings.Help"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmRollbackSettings.NoHooks"/></li>
        ///     <li><c>--recreate-pods</c> via <see cref="HelmRollbackSettings.RecreatePods"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmRollbackSettings.Timeout"/></li>
        ///     <li><c>--wait</c> via <see cref="HelmRollbackSettings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmRollback(Configure<HelmRollbackSettings> configurator)
        {
            return HelmRollback(configurator(new HelmRollbackSettings()));
        }
        /// <summary>
        ///   <p>This command rolls back a release to a previous revision. The first argument of the rollback command is the name of a release, and the second is a revision (version) number. If this argument is omitted, it will roll back to the previous release. To see revision numbers, run 'helm history RELEASE'.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;release&gt;</c> via <see cref="HelmRollbackSettings.Release"/></li>
        ///     <li><c>&lt;revision&gt;</c> via <see cref="HelmRollbackSettings.Revision"/></li>
        ///     <li><c>--cleanup-on-fail</c> via <see cref="HelmRollbackSettings.CleanupOnFail"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmRollbackSettings.DryRun"/></li>
        ///     <li><c>--force</c> via <see cref="HelmRollbackSettings.Force"/></li>
        ///     <li><c>--help</c> via <see cref="HelmRollbackSettings.Help"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmRollbackSettings.NoHooks"/></li>
        ///     <li><c>--recreate-pods</c> via <see cref="HelmRollbackSettings.RecreatePods"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmRollbackSettings.Timeout"/></li>
        ///     <li><c>--wait</c> via <see cref="HelmRollbackSettings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmRollbackSettings Settings, IReadOnlyCollection<Output> Output)> HelmRollback(CombinatorialConfigure<HelmRollbackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmRollback, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Search the Helm Hub or an instance of Monocular for Helm charts. The Helm Hub provides a centralized search for publicly available distributed charts. It is maintained by the Helm project. It can be visited at https://hub.helm.sh Monocular is a web-based application that enables the search and discovery of charts from multiple Helm Chart repositories. It is the codebase that powers the Helm Hub. You can find it at https://github.com/helm/monocular.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;keyword&gt;</c> via <see cref="HelmSearchHubSettings.Keyword"/></li>
        ///     <li><c>--endpoint</c> via <see cref="HelmSearchHubSettings.Endpoint"/></li>
        ///     <li><c>--help</c> via <see cref="HelmSearchHubSettings.Help"/></li>
        ///     <li><c>--max-col-width</c> via <see cref="HelmSearchHubSettings.MaxColWidth"/></li>
        ///     <li><c>--output</c> via <see cref="HelmSearchHubSettings.Output"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmSearchHub(HelmSearchHubSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmSearchHubSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Search the Helm Hub or an instance of Monocular for Helm charts. The Helm Hub provides a centralized search for publicly available distributed charts. It is maintained by the Helm project. It can be visited at https://hub.helm.sh Monocular is a web-based application that enables the search and discovery of charts from multiple Helm Chart repositories. It is the codebase that powers the Helm Hub. You can find it at https://github.com/helm/monocular.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;keyword&gt;</c> via <see cref="HelmSearchHubSettings.Keyword"/></li>
        ///     <li><c>--endpoint</c> via <see cref="HelmSearchHubSettings.Endpoint"/></li>
        ///     <li><c>--help</c> via <see cref="HelmSearchHubSettings.Help"/></li>
        ///     <li><c>--max-col-width</c> via <see cref="HelmSearchHubSettings.MaxColWidth"/></li>
        ///     <li><c>--output</c> via <see cref="HelmSearchHubSettings.Output"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmSearchHub(Configure<HelmSearchHubSettings> configurator)
        {
            return HelmSearchHub(configurator(new HelmSearchHubSettings()));
        }
        /// <summary>
        ///   <p>Search the Helm Hub or an instance of Monocular for Helm charts. The Helm Hub provides a centralized search for publicly available distributed charts. It is maintained by the Helm project. It can be visited at https://hub.helm.sh Monocular is a web-based application that enables the search and discovery of charts from multiple Helm Chart repositories. It is the codebase that powers the Helm Hub. You can find it at https://github.com/helm/monocular.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;keyword&gt;</c> via <see cref="HelmSearchHubSettings.Keyword"/></li>
        ///     <li><c>--endpoint</c> via <see cref="HelmSearchHubSettings.Endpoint"/></li>
        ///     <li><c>--help</c> via <see cref="HelmSearchHubSettings.Help"/></li>
        ///     <li><c>--max-col-width</c> via <see cref="HelmSearchHubSettings.MaxColWidth"/></li>
        ///     <li><c>--output</c> via <see cref="HelmSearchHubSettings.Output"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmSearchHubSettings Settings, IReadOnlyCollection<Output> Output)> HelmSearchHub(CombinatorialConfigure<HelmSearchHubSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmSearchHub, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Search reads through all of the repositories configured on the system, and looks for matches. Search of these repositories uses the metadata stored on the system. It will display the latest stable versions of the charts found. If you specify the --devel flag, the output will include pre-release versions. If you want to search using a version constraint, use --version. Examples:     # Search for stable release versions matching the keyword "nginx"     $ helm search repo nginx     # Search for release versions matching the keyword "nginx", including pre-release versions     $ helm search repo nginx --devel     # Search for the latest stable release for nginx-ingress with a major version of 1     $ helm search repo nginx-ingress --version ^1.0.0 Repositories are managed with 'helm repo' commands.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;keyword&gt;</c> via <see cref="HelmSearchRepoSettings.Keyword"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmSearchRepoSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmSearchRepoSettings.Help"/></li>
        ///     <li><c>--max-col-width</c> via <see cref="HelmSearchRepoSettings.MaxColWidth"/></li>
        ///     <li><c>--output</c> via <see cref="HelmSearchRepoSettings.Output"/></li>
        ///     <li><c>--regexp</c> via <see cref="HelmSearchRepoSettings.Regexp"/></li>
        ///     <li><c>--version</c> via <see cref="HelmSearchRepoSettings.Version"/></li>
        ///     <li><c>--versions</c> via <see cref="HelmSearchRepoSettings.Versions"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmSearchRepo(HelmSearchRepoSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmSearchRepoSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Search reads through all of the repositories configured on the system, and looks for matches. Search of these repositories uses the metadata stored on the system. It will display the latest stable versions of the charts found. If you specify the --devel flag, the output will include pre-release versions. If you want to search using a version constraint, use --version. Examples:     # Search for stable release versions matching the keyword "nginx"     $ helm search repo nginx     # Search for release versions matching the keyword "nginx", including pre-release versions     $ helm search repo nginx --devel     # Search for the latest stable release for nginx-ingress with a major version of 1     $ helm search repo nginx-ingress --version ^1.0.0 Repositories are managed with 'helm repo' commands.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;keyword&gt;</c> via <see cref="HelmSearchRepoSettings.Keyword"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmSearchRepoSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmSearchRepoSettings.Help"/></li>
        ///     <li><c>--max-col-width</c> via <see cref="HelmSearchRepoSettings.MaxColWidth"/></li>
        ///     <li><c>--output</c> via <see cref="HelmSearchRepoSettings.Output"/></li>
        ///     <li><c>--regexp</c> via <see cref="HelmSearchRepoSettings.Regexp"/></li>
        ///     <li><c>--version</c> via <see cref="HelmSearchRepoSettings.Version"/></li>
        ///     <li><c>--versions</c> via <see cref="HelmSearchRepoSettings.Versions"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmSearchRepo(Configure<HelmSearchRepoSettings> configurator)
        {
            return HelmSearchRepo(configurator(new HelmSearchRepoSettings()));
        }
        /// <summary>
        ///   <p>Search reads through all of the repositories configured on the system, and looks for matches. Search of these repositories uses the metadata stored on the system. It will display the latest stable versions of the charts found. If you specify the --devel flag, the output will include pre-release versions. If you want to search using a version constraint, use --version. Examples:     # Search for stable release versions matching the keyword "nginx"     $ helm search repo nginx     # Search for release versions matching the keyword "nginx", including pre-release versions     $ helm search repo nginx --devel     # Search for the latest stable release for nginx-ingress with a major version of 1     $ helm search repo nginx-ingress --version ^1.0.0 Repositories are managed with 'helm repo' commands.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;keyword&gt;</c> via <see cref="HelmSearchRepoSettings.Keyword"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmSearchRepoSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmSearchRepoSettings.Help"/></li>
        ///     <li><c>--max-col-width</c> via <see cref="HelmSearchRepoSettings.MaxColWidth"/></li>
        ///     <li><c>--output</c> via <see cref="HelmSearchRepoSettings.Output"/></li>
        ///     <li><c>--regexp</c> via <see cref="HelmSearchRepoSettings.Regexp"/></li>
        ///     <li><c>--version</c> via <see cref="HelmSearchRepoSettings.Version"/></li>
        ///     <li><c>--versions</c> via <see cref="HelmSearchRepoSettings.Versions"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmSearchRepoSettings Settings, IReadOnlyCollection<Output> Output)> HelmSearchRepo(CombinatorialConfigure<HelmSearchRepoSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmSearchRepo, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command inspects a chart (directory, file, or URL) and displays all its content (values.yaml, Charts.yaml, README).</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmShowAllSettings.Chart"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmShowAllSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmShowAllSettings.CertFile"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmShowAllSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmShowAllSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmShowAllSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmShowAllSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmShowAllSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmShowAllSettings.Password"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmShowAllSettings.Repo"/></li>
        ///     <li><c>--username</c> via <see cref="HelmShowAllSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmShowAllSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmShowAllSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmShowAll(HelmShowAllSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmShowAllSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command inspects a chart (directory, file, or URL) and displays all its content (values.yaml, Charts.yaml, README).</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmShowAllSettings.Chart"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmShowAllSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmShowAllSettings.CertFile"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmShowAllSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmShowAllSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmShowAllSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmShowAllSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmShowAllSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmShowAllSettings.Password"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmShowAllSettings.Repo"/></li>
        ///     <li><c>--username</c> via <see cref="HelmShowAllSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmShowAllSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmShowAllSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmShowAll(Configure<HelmShowAllSettings> configurator)
        {
            return HelmShowAll(configurator(new HelmShowAllSettings()));
        }
        /// <summary>
        ///   <p>This command inspects a chart (directory, file, or URL) and displays all its content (values.yaml, Charts.yaml, README).</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmShowAllSettings.Chart"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmShowAllSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmShowAllSettings.CertFile"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmShowAllSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmShowAllSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmShowAllSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmShowAllSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmShowAllSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmShowAllSettings.Password"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmShowAllSettings.Repo"/></li>
        ///     <li><c>--username</c> via <see cref="HelmShowAllSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmShowAllSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmShowAllSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmShowAllSettings Settings, IReadOnlyCollection<Output> Output)> HelmShowAll(CombinatorialConfigure<HelmShowAllSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmShowAll, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the Charts.yaml file.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmShowChartSettings.Chart"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmShowChartSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmShowChartSettings.CertFile"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmShowChartSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmShowChartSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmShowChartSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmShowChartSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmShowChartSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmShowChartSettings.Password"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmShowChartSettings.Repo"/></li>
        ///     <li><c>--username</c> via <see cref="HelmShowChartSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmShowChartSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmShowChartSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmShowChart(HelmShowChartSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmShowChartSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the Charts.yaml file.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmShowChartSettings.Chart"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmShowChartSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmShowChartSettings.CertFile"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmShowChartSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmShowChartSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmShowChartSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmShowChartSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmShowChartSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmShowChartSettings.Password"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmShowChartSettings.Repo"/></li>
        ///     <li><c>--username</c> via <see cref="HelmShowChartSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmShowChartSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmShowChartSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmShowChart(Configure<HelmShowChartSettings> configurator)
        {
            return HelmShowChart(configurator(new HelmShowChartSettings()));
        }
        /// <summary>
        ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the Charts.yaml file.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmShowChartSettings.Chart"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmShowChartSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmShowChartSettings.CertFile"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmShowChartSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmShowChartSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmShowChartSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmShowChartSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmShowChartSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmShowChartSettings.Password"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmShowChartSettings.Repo"/></li>
        ///     <li><c>--username</c> via <see cref="HelmShowChartSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmShowChartSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmShowChartSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmShowChartSettings Settings, IReadOnlyCollection<Output> Output)> HelmShowChart(CombinatorialConfigure<HelmShowChartSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmShowChart, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the README file.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmShowReadmeSettings.Chart"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmShowReadmeSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmShowReadmeSettings.CertFile"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmShowReadmeSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmShowReadmeSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmShowReadmeSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmShowReadmeSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmShowReadmeSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmShowReadmeSettings.Password"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmShowReadmeSettings.Repo"/></li>
        ///     <li><c>--username</c> via <see cref="HelmShowReadmeSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmShowReadmeSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmShowReadmeSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmShowReadme(HelmShowReadmeSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmShowReadmeSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the README file.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmShowReadmeSettings.Chart"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmShowReadmeSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmShowReadmeSettings.CertFile"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmShowReadmeSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmShowReadmeSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmShowReadmeSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmShowReadmeSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmShowReadmeSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmShowReadmeSettings.Password"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmShowReadmeSettings.Repo"/></li>
        ///     <li><c>--username</c> via <see cref="HelmShowReadmeSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmShowReadmeSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmShowReadmeSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmShowReadme(Configure<HelmShowReadmeSettings> configurator)
        {
            return HelmShowReadme(configurator(new HelmShowReadmeSettings()));
        }
        /// <summary>
        ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the README file.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmShowReadmeSettings.Chart"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmShowReadmeSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmShowReadmeSettings.CertFile"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmShowReadmeSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmShowReadmeSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmShowReadmeSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmShowReadmeSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmShowReadmeSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmShowReadmeSettings.Password"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmShowReadmeSettings.Repo"/></li>
        ///     <li><c>--username</c> via <see cref="HelmShowReadmeSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmShowReadmeSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmShowReadmeSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmShowReadmeSettings Settings, IReadOnlyCollection<Output> Output)> HelmShowReadme(CombinatorialConfigure<HelmShowReadmeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmShowReadme, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the values.yaml file.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmShowValuesSettings.Chart"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmShowValuesSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmShowValuesSettings.CertFile"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmShowValuesSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmShowValuesSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmShowValuesSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmShowValuesSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmShowValuesSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmShowValuesSettings.Password"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmShowValuesSettings.Repo"/></li>
        ///     <li><c>--username</c> via <see cref="HelmShowValuesSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmShowValuesSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmShowValuesSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmShowValues(HelmShowValuesSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmShowValuesSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the values.yaml file.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmShowValuesSettings.Chart"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmShowValuesSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmShowValuesSettings.CertFile"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmShowValuesSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmShowValuesSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmShowValuesSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmShowValuesSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmShowValuesSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmShowValuesSettings.Password"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmShowValuesSettings.Repo"/></li>
        ///     <li><c>--username</c> via <see cref="HelmShowValuesSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmShowValuesSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmShowValuesSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmShowValues(Configure<HelmShowValuesSettings> configurator)
        {
            return HelmShowValues(configurator(new HelmShowValuesSettings()));
        }
        /// <summary>
        ///   <p>This command inspects a chart (directory, file, or URL) and displays the contents of the values.yaml file.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmShowValuesSettings.Chart"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmShowValuesSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmShowValuesSettings.CertFile"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmShowValuesSettings.Devel"/></li>
        ///     <li><c>--help</c> via <see cref="HelmShowValuesSettings.Help"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmShowValuesSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmShowValuesSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmShowValuesSettings.Keyring"/></li>
        ///     <li><c>--password</c> via <see cref="HelmShowValuesSettings.Password"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmShowValuesSettings.Repo"/></li>
        ///     <li><c>--username</c> via <see cref="HelmShowValuesSettings.Username"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmShowValuesSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmShowValuesSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmShowValuesSettings Settings, IReadOnlyCollection<Output> Output)> HelmShowValues(CombinatorialConfigure<HelmShowValuesSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmShowValues, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command shows the status of a named release. The status consists of: - last deployment time - k8s namespace in which the release lives - state of the release (can be: unknown, deployed, uninstalled, superseded, failed, uninstalling, pending-install, pending-upgrade or pending-rollback) - list of resources that this release consists of, sorted by kind - details on last test suite run, if applicable - additional notes provided by the chart.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmStatusSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmStatusSettings.Help"/></li>
        ///     <li><c>--output</c> via <see cref="HelmStatusSettings.Output"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmStatusSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmStatus(HelmStatusSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmStatusSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command shows the status of a named release. The status consists of: - last deployment time - k8s namespace in which the release lives - state of the release (can be: unknown, deployed, uninstalled, superseded, failed, uninstalling, pending-install, pending-upgrade or pending-rollback) - list of resources that this release consists of, sorted by kind - details on last test suite run, if applicable - additional notes provided by the chart.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmStatusSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmStatusSettings.Help"/></li>
        ///     <li><c>--output</c> via <see cref="HelmStatusSettings.Output"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmStatusSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmStatus(Configure<HelmStatusSettings> configurator)
        {
            return HelmStatus(configurator(new HelmStatusSettings()));
        }
        /// <summary>
        ///   <p>This command shows the status of a named release. The status consists of: - last deployment time - k8s namespace in which the release lives - state of the release (can be: unknown, deployed, uninstalled, superseded, failed, uninstalling, pending-install, pending-upgrade or pending-rollback) - list of resources that this release consists of, sorted by kind - details on last test suite run, if applicable - additional notes provided by the chart.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseName&gt;</c> via <see cref="HelmStatusSettings.ReleaseName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmStatusSettings.Help"/></li>
        ///     <li><c>--output</c> via <see cref="HelmStatusSettings.Output"/></li>
        ///     <li><c>--revision</c> via <see cref="HelmStatusSettings.Revision"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmStatusSettings Settings, IReadOnlyCollection<Output> Output)> HelmStatus(CombinatorialConfigure<HelmStatusSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmStatus, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Render chart templates locally and display the output. Any values that would normally be looked up or retrieved in-cluster will be faked locally. Additionally, none of the server-side testing of chart validity (e.g. whether an API is supported) is done.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmTemplateSettings.Chart"/></li>
        ///     <li><c>&lt;name&gt;</c> via <see cref="HelmTemplateSettings.Name"/></li>
        ///     <li><c>--api-versions</c> via <see cref="HelmTemplateSettings.ApiVersions"/></li>
        ///     <li><c>--atomic</c> via <see cref="HelmTemplateSettings.Atomic"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmTemplateSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmTemplateSettings.CertFile"/></li>
        ///     <li><c>--create-namespace</c> via <see cref="HelmTemplateSettings.CreateNamespace"/></li>
        ///     <li><c>--dependency-update</c> via <see cref="HelmTemplateSettings.DependencyUpdate"/></li>
        ///     <li><c>--description</c> via <see cref="HelmTemplateSettings.Description"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmTemplateSettings.Devel"/></li>
        ///     <li><c>--disable-openapi-validation</c> via <see cref="HelmTemplateSettings.DisableOpenapiValidation"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmTemplateSettings.DryRun"/></li>
        ///     <li><c>--generate-name</c> via <see cref="HelmTemplateSettings.GenerateName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmTemplateSettings.Help"/></li>
        ///     <li><c>--include-crds</c> via <see cref="HelmTemplateSettings.IncludeCrds"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmTemplateSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--is-upgrade</c> via <see cref="HelmTemplateSettings.IsUpgrade"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmTemplateSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmTemplateSettings.Keyring"/></li>
        ///     <li><c>--name-template</c> via <see cref="HelmTemplateSettings.NameTemplate"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmTemplateSettings.NoHooks"/></li>
        ///     <li><c>--output-dir</c> via <see cref="HelmTemplateSettings.OutputDir"/></li>
        ///     <li><c>--password</c> via <see cref="HelmTemplateSettings.Password"/></li>
        ///     <li><c>--post-renderer</c> via <see cref="HelmTemplateSettings.PostRenderer"/></li>
        ///     <li><c>--release-name</c> via <see cref="HelmTemplateSettings.ReleaseName"/></li>
        ///     <li><c>--render-subchart-notes</c> via <see cref="HelmTemplateSettings.RenderSubchartNotes"/></li>
        ///     <li><c>--replace</c> via <see cref="HelmTemplateSettings.Replace"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmTemplateSettings.Repo"/></li>
        ///     <li><c>--set</c> via <see cref="HelmTemplateSettings.Set"/></li>
        ///     <li><c>--set-file</c> via <see cref="HelmTemplateSettings.SetFile"/></li>
        ///     <li><c>--set-string</c> via <see cref="HelmTemplateSettings.SetString"/></li>
        ///     <li><c>--show-only</c> via <see cref="HelmTemplateSettings.ShowOnly"/></li>
        ///     <li><c>--skip-crds</c> via <see cref="HelmTemplateSettings.SkipCrds"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmTemplateSettings.Timeout"/></li>
        ///     <li><c>--username</c> via <see cref="HelmTemplateSettings.Username"/></li>
        ///     <li><c>--validate</c> via <see cref="HelmTemplateSettings.Validate"/></li>
        ///     <li><c>--values</c> via <see cref="HelmTemplateSettings.Values"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmTemplateSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmTemplateSettings.Version"/></li>
        ///     <li><c>--wait</c> via <see cref="HelmTemplateSettings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmTemplate(HelmTemplateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmTemplateSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Render chart templates locally and display the output. Any values that would normally be looked up or retrieved in-cluster will be faked locally. Additionally, none of the server-side testing of chart validity (e.g. whether an API is supported) is done.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmTemplateSettings.Chart"/></li>
        ///     <li><c>&lt;name&gt;</c> via <see cref="HelmTemplateSettings.Name"/></li>
        ///     <li><c>--api-versions</c> via <see cref="HelmTemplateSettings.ApiVersions"/></li>
        ///     <li><c>--atomic</c> via <see cref="HelmTemplateSettings.Atomic"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmTemplateSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmTemplateSettings.CertFile"/></li>
        ///     <li><c>--create-namespace</c> via <see cref="HelmTemplateSettings.CreateNamespace"/></li>
        ///     <li><c>--dependency-update</c> via <see cref="HelmTemplateSettings.DependencyUpdate"/></li>
        ///     <li><c>--description</c> via <see cref="HelmTemplateSettings.Description"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmTemplateSettings.Devel"/></li>
        ///     <li><c>--disable-openapi-validation</c> via <see cref="HelmTemplateSettings.DisableOpenapiValidation"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmTemplateSettings.DryRun"/></li>
        ///     <li><c>--generate-name</c> via <see cref="HelmTemplateSettings.GenerateName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmTemplateSettings.Help"/></li>
        ///     <li><c>--include-crds</c> via <see cref="HelmTemplateSettings.IncludeCrds"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmTemplateSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--is-upgrade</c> via <see cref="HelmTemplateSettings.IsUpgrade"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmTemplateSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmTemplateSettings.Keyring"/></li>
        ///     <li><c>--name-template</c> via <see cref="HelmTemplateSettings.NameTemplate"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmTemplateSettings.NoHooks"/></li>
        ///     <li><c>--output-dir</c> via <see cref="HelmTemplateSettings.OutputDir"/></li>
        ///     <li><c>--password</c> via <see cref="HelmTemplateSettings.Password"/></li>
        ///     <li><c>--post-renderer</c> via <see cref="HelmTemplateSettings.PostRenderer"/></li>
        ///     <li><c>--release-name</c> via <see cref="HelmTemplateSettings.ReleaseName"/></li>
        ///     <li><c>--render-subchart-notes</c> via <see cref="HelmTemplateSettings.RenderSubchartNotes"/></li>
        ///     <li><c>--replace</c> via <see cref="HelmTemplateSettings.Replace"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmTemplateSettings.Repo"/></li>
        ///     <li><c>--set</c> via <see cref="HelmTemplateSettings.Set"/></li>
        ///     <li><c>--set-file</c> via <see cref="HelmTemplateSettings.SetFile"/></li>
        ///     <li><c>--set-string</c> via <see cref="HelmTemplateSettings.SetString"/></li>
        ///     <li><c>--show-only</c> via <see cref="HelmTemplateSettings.ShowOnly"/></li>
        ///     <li><c>--skip-crds</c> via <see cref="HelmTemplateSettings.SkipCrds"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmTemplateSettings.Timeout"/></li>
        ///     <li><c>--username</c> via <see cref="HelmTemplateSettings.Username"/></li>
        ///     <li><c>--validate</c> via <see cref="HelmTemplateSettings.Validate"/></li>
        ///     <li><c>--values</c> via <see cref="HelmTemplateSettings.Values"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmTemplateSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmTemplateSettings.Version"/></li>
        ///     <li><c>--wait</c> via <see cref="HelmTemplateSettings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmTemplate(Configure<HelmTemplateSettings> configurator)
        {
            return HelmTemplate(configurator(new HelmTemplateSettings()));
        }
        /// <summary>
        ///   <p>Render chart templates locally and display the output. Any values that would normally be looked up or retrieved in-cluster will be faked locally. Additionally, none of the server-side testing of chart validity (e.g. whether an API is supported) is done.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmTemplateSettings.Chart"/></li>
        ///     <li><c>&lt;name&gt;</c> via <see cref="HelmTemplateSettings.Name"/></li>
        ///     <li><c>--api-versions</c> via <see cref="HelmTemplateSettings.ApiVersions"/></li>
        ///     <li><c>--atomic</c> via <see cref="HelmTemplateSettings.Atomic"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmTemplateSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmTemplateSettings.CertFile"/></li>
        ///     <li><c>--create-namespace</c> via <see cref="HelmTemplateSettings.CreateNamespace"/></li>
        ///     <li><c>--dependency-update</c> via <see cref="HelmTemplateSettings.DependencyUpdate"/></li>
        ///     <li><c>--description</c> via <see cref="HelmTemplateSettings.Description"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmTemplateSettings.Devel"/></li>
        ///     <li><c>--disable-openapi-validation</c> via <see cref="HelmTemplateSettings.DisableOpenapiValidation"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmTemplateSettings.DryRun"/></li>
        ///     <li><c>--generate-name</c> via <see cref="HelmTemplateSettings.GenerateName"/></li>
        ///     <li><c>--help</c> via <see cref="HelmTemplateSettings.Help"/></li>
        ///     <li><c>--include-crds</c> via <see cref="HelmTemplateSettings.IncludeCrds"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmTemplateSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--is-upgrade</c> via <see cref="HelmTemplateSettings.IsUpgrade"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmTemplateSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmTemplateSettings.Keyring"/></li>
        ///     <li><c>--name-template</c> via <see cref="HelmTemplateSettings.NameTemplate"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmTemplateSettings.NoHooks"/></li>
        ///     <li><c>--output-dir</c> via <see cref="HelmTemplateSettings.OutputDir"/></li>
        ///     <li><c>--password</c> via <see cref="HelmTemplateSettings.Password"/></li>
        ///     <li><c>--post-renderer</c> via <see cref="HelmTemplateSettings.PostRenderer"/></li>
        ///     <li><c>--release-name</c> via <see cref="HelmTemplateSettings.ReleaseName"/></li>
        ///     <li><c>--render-subchart-notes</c> via <see cref="HelmTemplateSettings.RenderSubchartNotes"/></li>
        ///     <li><c>--replace</c> via <see cref="HelmTemplateSettings.Replace"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmTemplateSettings.Repo"/></li>
        ///     <li><c>--set</c> via <see cref="HelmTemplateSettings.Set"/></li>
        ///     <li><c>--set-file</c> via <see cref="HelmTemplateSettings.SetFile"/></li>
        ///     <li><c>--set-string</c> via <see cref="HelmTemplateSettings.SetString"/></li>
        ///     <li><c>--show-only</c> via <see cref="HelmTemplateSettings.ShowOnly"/></li>
        ///     <li><c>--skip-crds</c> via <see cref="HelmTemplateSettings.SkipCrds"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmTemplateSettings.Timeout"/></li>
        ///     <li><c>--username</c> via <see cref="HelmTemplateSettings.Username"/></li>
        ///     <li><c>--validate</c> via <see cref="HelmTemplateSettings.Validate"/></li>
        ///     <li><c>--values</c> via <see cref="HelmTemplateSettings.Values"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmTemplateSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmTemplateSettings.Version"/></li>
        ///     <li><c>--wait</c> via <see cref="HelmTemplateSettings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmTemplateSettings Settings, IReadOnlyCollection<Output> Output)> HelmTemplate(CombinatorialConfigure<HelmTemplateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmTemplate, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>The test command runs the tests for a release. The argument this command takes is the name of a deployed release. The tests to be run are defined in the chart that was installed.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;release&gt;</c> via <see cref="HelmTestSettings.Release"/></li>
        ///     <li><c>--help</c> via <see cref="HelmTestSettings.Help"/></li>
        ///     <li><c>--logs</c> via <see cref="HelmTestSettings.Logs"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmTestSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmTest(HelmTestSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmTestSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The test command runs the tests for a release. The argument this command takes is the name of a deployed release. The tests to be run are defined in the chart that was installed.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;release&gt;</c> via <see cref="HelmTestSettings.Release"/></li>
        ///     <li><c>--help</c> via <see cref="HelmTestSettings.Help"/></li>
        ///     <li><c>--logs</c> via <see cref="HelmTestSettings.Logs"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmTestSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmTest(Configure<HelmTestSettings> configurator)
        {
            return HelmTest(configurator(new HelmTestSettings()));
        }
        /// <summary>
        ///   <p>The test command runs the tests for a release. The argument this command takes is the name of a deployed release. The tests to be run are defined in the chart that was installed.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;release&gt;</c> via <see cref="HelmTestSettings.Release"/></li>
        ///     <li><c>--help</c> via <see cref="HelmTestSettings.Help"/></li>
        ///     <li><c>--logs</c> via <see cref="HelmTestSettings.Logs"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmTestSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmTestSettings Settings, IReadOnlyCollection<Output> Output)> HelmTest(CombinatorialConfigure<HelmTestSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmTest, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command takes a release name and uninstalls the release. It removes all of the resources associated with the last release of the chart as well as the release history, freeing it up for future use. Use the '--dry-run' flag to see which releases will be uninstalled without actually uninstalling them.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseNames&gt;</c> via <see cref="HelmUninstallSettings.ReleaseNames"/></li>
        ///     <li><c>--description</c> via <see cref="HelmUninstallSettings.Description"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmUninstallSettings.DryRun"/></li>
        ///     <li><c>--help</c> via <see cref="HelmUninstallSettings.Help"/></li>
        ///     <li><c>--keep-history</c> via <see cref="HelmUninstallSettings.KeepHistory"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmUninstallSettings.NoHooks"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmUninstallSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmUninstall(HelmUninstallSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmUninstallSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command takes a release name and uninstalls the release. It removes all of the resources associated with the last release of the chart as well as the release history, freeing it up for future use. Use the '--dry-run' flag to see which releases will be uninstalled without actually uninstalling them.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseNames&gt;</c> via <see cref="HelmUninstallSettings.ReleaseNames"/></li>
        ///     <li><c>--description</c> via <see cref="HelmUninstallSettings.Description"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmUninstallSettings.DryRun"/></li>
        ///     <li><c>--help</c> via <see cref="HelmUninstallSettings.Help"/></li>
        ///     <li><c>--keep-history</c> via <see cref="HelmUninstallSettings.KeepHistory"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmUninstallSettings.NoHooks"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmUninstallSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmUninstall(Configure<HelmUninstallSettings> configurator)
        {
            return HelmUninstall(configurator(new HelmUninstallSettings()));
        }
        /// <summary>
        ///   <p>This command takes a release name and uninstalls the release. It removes all of the resources associated with the last release of the chart as well as the release history, freeing it up for future use. Use the '--dry-run' flag to see which releases will be uninstalled without actually uninstalling them.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;releaseNames&gt;</c> via <see cref="HelmUninstallSettings.ReleaseNames"/></li>
        ///     <li><c>--description</c> via <see cref="HelmUninstallSettings.Description"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmUninstallSettings.DryRun"/></li>
        ///     <li><c>--help</c> via <see cref="HelmUninstallSettings.Help"/></li>
        ///     <li><c>--keep-history</c> via <see cref="HelmUninstallSettings.KeepHistory"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmUninstallSettings.NoHooks"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmUninstallSettings.Timeout"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmUninstallSettings Settings, IReadOnlyCollection<Output> Output)> HelmUninstall(CombinatorialConfigure<HelmUninstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmUninstall, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>This command upgrades a release to a new version of a chart. The upgrade arguments must be a release and chart. The chart argument can be either: a chart reference('example/mariadb'), a path to a chart directory, a packaged chart, or a fully qualified URL. For chart references, the latest version will be specified unless the '--version' flag is set. To override values in a chart, use either the '--values' flag and pass in a file or use the '--set' flag and pass configuration from the command line, to force string values, use '--set-string'. In case a value is large and therefore you want not to use neither '--values' nor '--set', use '--set-file' to read the single large value from file. You can specify the '--values'/'-f' flag multiple times. The priority will be given to the last (right-most) file specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence:     $ helm upgrade -f myvalues.yaml -f override.yaml redis ./redis You can specify the '--set' flag multiple times. The priority will be given to the last (right-most) set specified. For example, if both 'bar' and 'newbar' values are set for a key called 'foo', the 'newbar' value would take precedence:     $ helm upgrade --set foo=bar --set foo=newbar redis ./redis.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmUpgradeSettings.Chart"/></li>
        ///     <li><c>&lt;release&gt;</c> via <see cref="HelmUpgradeSettings.Release"/></li>
        ///     <li><c>--atomic</c> via <see cref="HelmUpgradeSettings.Atomic"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmUpgradeSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmUpgradeSettings.CertFile"/></li>
        ///     <li><c>--cleanup-on-fail</c> via <see cref="HelmUpgradeSettings.CleanupOnFail"/></li>
        ///     <li><c>--create-namespace</c> via <see cref="HelmUpgradeSettings.CreateNamespace"/></li>
        ///     <li><c>--description</c> via <see cref="HelmUpgradeSettings.Description"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmUpgradeSettings.Devel"/></li>
        ///     <li><c>--disable-openapi-validation</c> via <see cref="HelmUpgradeSettings.DisableOpenapiValidation"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmUpgradeSettings.DryRun"/></li>
        ///     <li><c>--force</c> via <see cref="HelmUpgradeSettings.Force"/></li>
        ///     <li><c>--help</c> via <see cref="HelmUpgradeSettings.Help"/></li>
        ///     <li><c>--history-max</c> via <see cref="HelmUpgradeSettings.HistoryMax"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmUpgradeSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--install</c> via <see cref="HelmUpgradeSettings.Install"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmUpgradeSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmUpgradeSettings.Keyring"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmUpgradeSettings.NoHooks"/></li>
        ///     <li><c>--output</c> via <see cref="HelmUpgradeSettings.Output"/></li>
        ///     <li><c>--password</c> via <see cref="HelmUpgradeSettings.Password"/></li>
        ///     <li><c>--post-renderer</c> via <see cref="HelmUpgradeSettings.PostRenderer"/></li>
        ///     <li><c>--render-subchart-notes</c> via <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmUpgradeSettings.Repo"/></li>
        ///     <li><c>--reset-values</c> via <see cref="HelmUpgradeSettings.ResetValues"/></li>
        ///     <li><c>--reuse-values</c> via <see cref="HelmUpgradeSettings.ReuseValues"/></li>
        ///     <li><c>--set</c> via <see cref="HelmUpgradeSettings.Set"/></li>
        ///     <li><c>--set-file</c> via <see cref="HelmUpgradeSettings.SetFile"/></li>
        ///     <li><c>--set-string</c> via <see cref="HelmUpgradeSettings.SetString"/></li>
        ///     <li><c>--skip-crds</c> via <see cref="HelmUpgradeSettings.SkipCrds"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmUpgradeSettings.Timeout"/></li>
        ///     <li><c>--username</c> via <see cref="HelmUpgradeSettings.Username"/></li>
        ///     <li><c>--values</c> via <see cref="HelmUpgradeSettings.Values"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmUpgradeSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmUpgradeSettings.Version"/></li>
        ///     <li><c>--wait</c> via <see cref="HelmUpgradeSettings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmUpgrade(HelmUpgradeSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmUpgradeSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>This command upgrades a release to a new version of a chart. The upgrade arguments must be a release and chart. The chart argument can be either: a chart reference('example/mariadb'), a path to a chart directory, a packaged chart, or a fully qualified URL. For chart references, the latest version will be specified unless the '--version' flag is set. To override values in a chart, use either the '--values' flag and pass in a file or use the '--set' flag and pass configuration from the command line, to force string values, use '--set-string'. In case a value is large and therefore you want not to use neither '--values' nor '--set', use '--set-file' to read the single large value from file. You can specify the '--values'/'-f' flag multiple times. The priority will be given to the last (right-most) file specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence:     $ helm upgrade -f myvalues.yaml -f override.yaml redis ./redis You can specify the '--set' flag multiple times. The priority will be given to the last (right-most) set specified. For example, if both 'bar' and 'newbar' values are set for a key called 'foo', the 'newbar' value would take precedence:     $ helm upgrade --set foo=bar --set foo=newbar redis ./redis.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmUpgradeSettings.Chart"/></li>
        ///     <li><c>&lt;release&gt;</c> via <see cref="HelmUpgradeSettings.Release"/></li>
        ///     <li><c>--atomic</c> via <see cref="HelmUpgradeSettings.Atomic"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmUpgradeSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmUpgradeSettings.CertFile"/></li>
        ///     <li><c>--cleanup-on-fail</c> via <see cref="HelmUpgradeSettings.CleanupOnFail"/></li>
        ///     <li><c>--create-namespace</c> via <see cref="HelmUpgradeSettings.CreateNamespace"/></li>
        ///     <li><c>--description</c> via <see cref="HelmUpgradeSettings.Description"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmUpgradeSettings.Devel"/></li>
        ///     <li><c>--disable-openapi-validation</c> via <see cref="HelmUpgradeSettings.DisableOpenapiValidation"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmUpgradeSettings.DryRun"/></li>
        ///     <li><c>--force</c> via <see cref="HelmUpgradeSettings.Force"/></li>
        ///     <li><c>--help</c> via <see cref="HelmUpgradeSettings.Help"/></li>
        ///     <li><c>--history-max</c> via <see cref="HelmUpgradeSettings.HistoryMax"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmUpgradeSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--install</c> via <see cref="HelmUpgradeSettings.Install"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmUpgradeSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmUpgradeSettings.Keyring"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmUpgradeSettings.NoHooks"/></li>
        ///     <li><c>--output</c> via <see cref="HelmUpgradeSettings.Output"/></li>
        ///     <li><c>--password</c> via <see cref="HelmUpgradeSettings.Password"/></li>
        ///     <li><c>--post-renderer</c> via <see cref="HelmUpgradeSettings.PostRenderer"/></li>
        ///     <li><c>--render-subchart-notes</c> via <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmUpgradeSettings.Repo"/></li>
        ///     <li><c>--reset-values</c> via <see cref="HelmUpgradeSettings.ResetValues"/></li>
        ///     <li><c>--reuse-values</c> via <see cref="HelmUpgradeSettings.ReuseValues"/></li>
        ///     <li><c>--set</c> via <see cref="HelmUpgradeSettings.Set"/></li>
        ///     <li><c>--set-file</c> via <see cref="HelmUpgradeSettings.SetFile"/></li>
        ///     <li><c>--set-string</c> via <see cref="HelmUpgradeSettings.SetString"/></li>
        ///     <li><c>--skip-crds</c> via <see cref="HelmUpgradeSettings.SkipCrds"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmUpgradeSettings.Timeout"/></li>
        ///     <li><c>--username</c> via <see cref="HelmUpgradeSettings.Username"/></li>
        ///     <li><c>--values</c> via <see cref="HelmUpgradeSettings.Values"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmUpgradeSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmUpgradeSettings.Version"/></li>
        ///     <li><c>--wait</c> via <see cref="HelmUpgradeSettings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmUpgrade(Configure<HelmUpgradeSettings> configurator)
        {
            return HelmUpgrade(configurator(new HelmUpgradeSettings()));
        }
        /// <summary>
        ///   <p>This command upgrades a release to a new version of a chart. The upgrade arguments must be a release and chart. The chart argument can be either: a chart reference('example/mariadb'), a path to a chart directory, a packaged chart, or a fully qualified URL. For chart references, the latest version will be specified unless the '--version' flag is set. To override values in a chart, use either the '--values' flag and pass in a file or use the '--set' flag and pass configuration from the command line, to force string values, use '--set-string'. In case a value is large and therefore you want not to use neither '--values' nor '--set', use '--set-file' to read the single large value from file. You can specify the '--values'/'-f' flag multiple times. The priority will be given to the last (right-most) file specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence:     $ helm upgrade -f myvalues.yaml -f override.yaml redis ./redis You can specify the '--set' flag multiple times. The priority will be given to the last (right-most) set specified. For example, if both 'bar' and 'newbar' values are set for a key called 'foo', the 'newbar' value would take precedence:     $ helm upgrade --set foo=bar --set foo=newbar redis ./redis.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;chart&gt;</c> via <see cref="HelmUpgradeSettings.Chart"/></li>
        ///     <li><c>&lt;release&gt;</c> via <see cref="HelmUpgradeSettings.Release"/></li>
        ///     <li><c>--atomic</c> via <see cref="HelmUpgradeSettings.Atomic"/></li>
        ///     <li><c>--ca-file</c> via <see cref="HelmUpgradeSettings.CaFile"/></li>
        ///     <li><c>--cert-file</c> via <see cref="HelmUpgradeSettings.CertFile"/></li>
        ///     <li><c>--cleanup-on-fail</c> via <see cref="HelmUpgradeSettings.CleanupOnFail"/></li>
        ///     <li><c>--create-namespace</c> via <see cref="HelmUpgradeSettings.CreateNamespace"/></li>
        ///     <li><c>--description</c> via <see cref="HelmUpgradeSettings.Description"/></li>
        ///     <li><c>--devel</c> via <see cref="HelmUpgradeSettings.Devel"/></li>
        ///     <li><c>--disable-openapi-validation</c> via <see cref="HelmUpgradeSettings.DisableOpenapiValidation"/></li>
        ///     <li><c>--dry-run</c> via <see cref="HelmUpgradeSettings.DryRun"/></li>
        ///     <li><c>--force</c> via <see cref="HelmUpgradeSettings.Force"/></li>
        ///     <li><c>--help</c> via <see cref="HelmUpgradeSettings.Help"/></li>
        ///     <li><c>--history-max</c> via <see cref="HelmUpgradeSettings.HistoryMax"/></li>
        ///     <li><c>--insecure-skip-tls-verify</c> via <see cref="HelmUpgradeSettings.InsecureSkipTlsVerify"/></li>
        ///     <li><c>--install</c> via <see cref="HelmUpgradeSettings.Install"/></li>
        ///     <li><c>--key-file</c> via <see cref="HelmUpgradeSettings.KeyFile"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmUpgradeSettings.Keyring"/></li>
        ///     <li><c>--no-hooks</c> via <see cref="HelmUpgradeSettings.NoHooks"/></li>
        ///     <li><c>--output</c> via <see cref="HelmUpgradeSettings.Output"/></li>
        ///     <li><c>--password</c> via <see cref="HelmUpgradeSettings.Password"/></li>
        ///     <li><c>--post-renderer</c> via <see cref="HelmUpgradeSettings.PostRenderer"/></li>
        ///     <li><c>--render-subchart-notes</c> via <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></li>
        ///     <li><c>--repo</c> via <see cref="HelmUpgradeSettings.Repo"/></li>
        ///     <li><c>--reset-values</c> via <see cref="HelmUpgradeSettings.ResetValues"/></li>
        ///     <li><c>--reuse-values</c> via <see cref="HelmUpgradeSettings.ReuseValues"/></li>
        ///     <li><c>--set</c> via <see cref="HelmUpgradeSettings.Set"/></li>
        ///     <li><c>--set-file</c> via <see cref="HelmUpgradeSettings.SetFile"/></li>
        ///     <li><c>--set-string</c> via <see cref="HelmUpgradeSettings.SetString"/></li>
        ///     <li><c>--skip-crds</c> via <see cref="HelmUpgradeSettings.SkipCrds"/></li>
        ///     <li><c>--timeout</c> via <see cref="HelmUpgradeSettings.Timeout"/></li>
        ///     <li><c>--username</c> via <see cref="HelmUpgradeSettings.Username"/></li>
        ///     <li><c>--values</c> via <see cref="HelmUpgradeSettings.Values"/></li>
        ///     <li><c>--verify</c> via <see cref="HelmUpgradeSettings.Verify"/></li>
        ///     <li><c>--version</c> via <see cref="HelmUpgradeSettings.Version"/></li>
        ///     <li><c>--wait</c> via <see cref="HelmUpgradeSettings.Wait"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmUpgradeSettings Settings, IReadOnlyCollection<Output> Output)> HelmUpgrade(CombinatorialConfigure<HelmUpgradeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmUpgrade, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Verify that the given chart has a valid provenance file. Provenance files provide cryptographic verification that a chart has not been tampered with, and was packaged by a trusted provider. This command can be used to verify a local chart. Several other commands provide '--verify' flags that run the same validation. To generate a signed package, use the 'helm package --sign' command.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;path&gt;</c> via <see cref="HelmVerifySettings.Path"/></li>
        ///     <li><c>--help</c> via <see cref="HelmVerifySettings.Help"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmVerifySettings.Keyring"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmVerify(HelmVerifySettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmVerifySettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Verify that the given chart has a valid provenance file. Provenance files provide cryptographic verification that a chart has not been tampered with, and was packaged by a trusted provider. This command can be used to verify a local chart. Several other commands provide '--verify' flags that run the same validation. To generate a signed package, use the 'helm package --sign' command.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;path&gt;</c> via <see cref="HelmVerifySettings.Path"/></li>
        ///     <li><c>--help</c> via <see cref="HelmVerifySettings.Help"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmVerifySettings.Keyring"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmVerify(Configure<HelmVerifySettings> configurator)
        {
            return HelmVerify(configurator(new HelmVerifySettings()));
        }
        /// <summary>
        ///   <p>Verify that the given chart has a valid provenance file. Provenance files provide cryptographic verification that a chart has not been tampered with, and was packaged by a trusted provider. This command can be used to verify a local chart. Several other commands provide '--verify' flags that run the same validation. To generate a signed package, use the 'helm package --sign' command.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;path&gt;</c> via <see cref="HelmVerifySettings.Path"/></li>
        ///     <li><c>--help</c> via <see cref="HelmVerifySettings.Help"/></li>
        ///     <li><c>--keyring</c> via <see cref="HelmVerifySettings.Keyring"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmVerifySettings Settings, IReadOnlyCollection<Output> Output)> HelmVerify(CombinatorialConfigure<HelmVerifySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmVerify, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Show the version for Helm. This will print a representation the version of Helm. The output will look something like this: version.BuildInfo{Version:"v3.2.1", GitCommit:"fe51cd1e31e6a202cba7dead9552a6d418ded79a", GitTreeState:"clean", GoVersion:"go1.13.10"} - Version is the semantic version of the release. - GitCommit is the SHA for the commit that this version was built from. - GitTreeState is "clean" if there are no local code changes when this binary was   built, and "dirty" if the binary was built from locally modified code. - GoVersion is the version of Go that was used to compile Helm. When using the --template flag the following properties are available to use in the template: - .Version contains the semantic version of Helm - .GitCommit is the git commit - .GitTreeState is the state of the git tree when Helm was built - .GoVersion contains the version of Go that Helm was compiled with.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmVersionSettings.Help"/></li>
        ///     <li><c>--short</c> via <see cref="HelmVersionSettings.Short"/></li>
        ///     <li><c>--template</c> via <see cref="HelmVersionSettings.Template"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmVersion(HelmVersionSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new HelmVersionSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Show the version for Helm. This will print a representation the version of Helm. The output will look something like this: version.BuildInfo{Version:"v3.2.1", GitCommit:"fe51cd1e31e6a202cba7dead9552a6d418ded79a", GitTreeState:"clean", GoVersion:"go1.13.10"} - Version is the semantic version of the release. - GitCommit is the SHA for the commit that this version was built from. - GitTreeState is "clean" if there are no local code changes when this binary was   built, and "dirty" if the binary was built from locally modified code. - GoVersion is the version of Go that was used to compile Helm. When using the --template flag the following properties are available to use in the template: - .Version contains the semantic version of Helm - .GitCommit is the git commit - .GitTreeState is the state of the git tree when Helm was built - .GoVersion contains the version of Go that Helm was compiled with.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmVersionSettings.Help"/></li>
        ///     <li><c>--short</c> via <see cref="HelmVersionSettings.Short"/></li>
        ///     <li><c>--template</c> via <see cref="HelmVersionSettings.Template"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> HelmVersion(Configure<HelmVersionSettings> configurator)
        {
            return HelmVersion(configurator(new HelmVersionSettings()));
        }
        /// <summary>
        ///   <p>Show the version for Helm. This will print a representation the version of Helm. The output will look something like this: version.BuildInfo{Version:"v3.2.1", GitCommit:"fe51cd1e31e6a202cba7dead9552a6d418ded79a", GitTreeState:"clean", GoVersion:"go1.13.10"} - Version is the semantic version of the release. - GitCommit is the SHA for the commit that this version was built from. - GitTreeState is "clean" if there are no local code changes when this binary was   built, and "dirty" if the binary was built from locally modified code. - GoVersion is the version of Go that was used to compile Helm. When using the --template flag the following properties are available to use in the template: - .Version contains the semantic version of Helm - .GitCommit is the git commit - .GitTreeState is the state of the git tree when Helm was built - .GoVersion contains the version of Go that Helm was compiled with.</p>
        ///   <p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--help</c> via <see cref="HelmVersionSettings.Help"/></li>
        ///     <li><c>--short</c> via <see cref="HelmVersionSettings.Short"/></li>
        ///     <li><c>--template</c> via <see cref="HelmVersionSettings.Template"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(HelmVersionSettings Settings, IReadOnlyCollection<Output> Output)> HelmVersion(CombinatorialConfigure<HelmVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(HelmVersion, HelmLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region HelmCompletionBashSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmCompletionBashSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for bash.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("completion bash")
              .Add("--help", Help);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmCompletionZshSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmCompletionZshSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for zsh.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("completion zsh")
              .Add("--help", Help);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmCreateSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmCreateSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for create.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   The name or absolute path to Helm starter scaffold.
        /// </summary>
        public virtual string Starter { get; internal set; }
        /// <summary>
        ///   The name of chart directory to create.
        /// </summary>
        public virtual string Name { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("create")
              .Add("--help", Help)
              .Add("--starter {value}", Starter)
              .Add("{value}", Name);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmDependencyBuildSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmDependencyBuildSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for build.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Keyring containing public keys (default "~/.gnupg/pubring.gpg").
        /// </summary>
        public virtual string Keyring { get; internal set; }
        /// <summary>
        ///   Verify the packages against signatures.
        /// </summary>
        public virtual bool? Verify { get; internal set; }
        /// <summary>
        ///   The name of the chart to build.
        /// </summary>
        public virtual string Chart { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("dependency build")
              .Add("--help", Help)
              .Add("--keyring {value}", Keyring)
              .Add("--verify", Verify)
              .Add("{value}", Chart);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmDependencyListSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmDependencyListSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for list.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   The name of the chart to list.
        /// </summary>
        public virtual string Chart { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("dependency list")
              .Add("--help", Help)
              .Add("{value}", Chart);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmDependencyUpdateSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmDependencyUpdateSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for update.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Keyring containing public keys (default "~/.gnupg/pubring.gpg").
        /// </summary>
        public virtual string Keyring { get; internal set; }
        /// <summary>
        ///   Do not refresh the local repository cache.
        /// </summary>
        public virtual bool? SkipRefresh { get; internal set; }
        /// <summary>
        ///   Verify the packages against signatures.
        /// </summary>
        public virtual bool? Verify { get; internal set; }
        /// <summary>
        ///   The name of the chart to update.
        /// </summary>
        public virtual string Chart { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("dependency update")
              .Add("--help", Help)
              .Add("--keyring {value}", Keyring)
              .Add("--skip-refresh", SkipRefresh)
              .Add("--verify", Verify)
              .Add("{value}", Chart);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmEnvSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmEnvSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for env.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("env")
              .Add("--help", Help);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmGetAllSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmGetAllSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for all.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Get the named release with revision.
        /// </summary>
        public virtual long? Revision { get; internal set; }
        /// <summary>
        ///   Go template for formatting the output, eg: {{.Release.Name}}.
        /// </summary>
        public virtual string Template { get; internal set; }
        public virtual string ReleaseName { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("get all")
              .Add("--help", Help)
              .Add("--revision {value}", Revision)
              .Add("--template {value}", Template)
              .Add("{value}", ReleaseName);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmGetHooksSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmGetHooksSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for hooks.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Get the named release with revision.
        /// </summary>
        public virtual long? Revision { get; internal set; }
        /// <summary>
        ///   The name of the release to get the hooks for.
        /// </summary>
        public virtual string ReleaseName { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("get hooks")
              .Add("--help", Help)
              .Add("--revision {value}", Revision)
              .Add("{value}", ReleaseName);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmGetManifestSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmGetManifestSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for manifest.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Get the named release with revision.
        /// </summary>
        public virtual long? Revision { get; internal set; }
        /// <summary>
        ///   The name of the release to get the manifest for.
        /// </summary>
        public virtual string ReleaseName { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("get manifest")
              .Add("--help", Help)
              .Add("--revision {value}", Revision)
              .Add("{value}", ReleaseName);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmGetNotesSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmGetNotesSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for notes.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Get the named release with revision.
        /// </summary>
        public virtual long? Revision { get; internal set; }
        public virtual string ReleaseName { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("get notes")
              .Add("--help", Help)
              .Add("--revision {value}", Revision)
              .Add("{value}", ReleaseName);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmGetValuesSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmGetValuesSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Dump all (computed) values.
        /// </summary>
        public virtual bool? All { get; internal set; }
        /// <summary>
        ///   Help for values.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Prints the output in the specified format. Allowed values: table, json, yaml (default table).
        /// </summary>
        public virtual HelmOutputFormat Output { get; internal set; }
        /// <summary>
        ///   Get the named release with revision.
        /// </summary>
        public virtual long? Revision { get; internal set; }
        /// <summary>
        ///   The name of the release to get the values for.
        /// </summary>
        public virtual string ReleaseName { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("get values")
              .Add("--all", All)
              .Add("--help", Help)
              .Add("--output {value}", Output)
              .Add("--revision {value}", Revision)
              .Add("{value}", ReleaseName);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmHistorySettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmHistorySettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for history.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Maximum number of revision to include in history (default 256).
        /// </summary>
        public virtual long? Max { get; internal set; }
        /// <summary>
        ///   Prints the output in the specified format. Allowed values: table, json, yaml (default table).
        /// </summary>
        public virtual HelmOutputFormat Output { get; internal set; }
        /// <summary>
        ///   The name of the release to get the history for.
        /// </summary>
        public virtual string ReleaseName { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("history")
              .Add("--help", Help)
              .Add("--max {value}", Max)
              .Add("--output {value}", Output)
              .Add("{value}", ReleaseName);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmInstallSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmInstallSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   If set, the installation process deletes the installation on failure. The --wait flag will be set automatically if --atomic is used.
        /// </summary>
        public virtual bool? Atomic { get; internal set; }
        /// <summary>
        ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
        /// </summary>
        public virtual string CaFile { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL certificate file.
        /// </summary>
        public virtual string CertFile { get; internal set; }
        /// <summary>
        ///   Create the release namespace if not present.
        /// </summary>
        public virtual bool? CreateNamespace { get; internal set; }
        /// <summary>
        ///   Run helm dependency update before installing the chart.
        /// </summary>
        public virtual bool? DependencyUpdate { get; internal set; }
        /// <summary>
        ///   Add a custom description.
        /// </summary>
        public virtual string Description { get; internal set; }
        /// <summary>
        ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
        /// </summary>
        public virtual bool? Devel { get; internal set; }
        /// <summary>
        ///   If set, the installation process will not validate rendered templates against the Kubernetes OpenAPI Schema.
        /// </summary>
        public virtual bool? DisableOpenapiValidation { get; internal set; }
        /// <summary>
        ///   Simulate an install.
        /// </summary>
        public virtual bool? DryRun { get; internal set; }
        /// <summary>
        ///   Generate the name (and omit the NAME parameter).
        /// </summary>
        public virtual bool? GenerateName { get; internal set; }
        /// <summary>
        ///   Help for install.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Skip tls certificate checks for the chart download.
        /// </summary>
        public virtual bool? InsecureSkipTlsVerify { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL key file.
        /// </summary>
        public virtual string KeyFile { get; internal set; }
        /// <summary>
        ///   Location of public keys used for verification (default "~/.gnupg/pubring.gpg").
        /// </summary>
        public virtual string Keyring { get; internal set; }
        /// <summary>
        ///   Specify template used to name the release.
        /// </summary>
        public virtual string NameTemplate { get; internal set; }
        /// <summary>
        ///   Prevent hooks from running during install.
        /// </summary>
        public virtual bool? NoHooks { get; internal set; }
        /// <summary>
        ///   Prints the output in the specified format. Allowed values: table, json, yaml (default table).
        /// </summary>
        public virtual HelmOutputFormat Output { get; internal set; }
        /// <summary>
        ///   Chart repository password where to locate the requested chart.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   The path to an executable to be used for post rendering. If it exists in $PATH, the binary will be used, otherwise it will try to look for the executable at the given path (default exec).
        /// </summary>
        public virtual string PostRenderer { get; internal set; }
        /// <summary>
        ///   If set, render subchart notes along with the parent.
        /// </summary>
        public virtual bool? RenderSubchartNotes { get; internal set; }
        /// <summary>
        ///   Re-use the given name, only if that name is a deleted release which remains in the history. This is unsafe in production.
        /// </summary>
        public virtual bool? Replace { get; internal set; }
        /// <summary>
        ///   Chart repository url where to locate the requested chart.
        /// </summary>
        public virtual string Repo { get; internal set; }
        /// <summary>
        ///   Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Set => SetInternal.AsReadOnly();
        internal Dictionary<string, object> SetInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> SetFile => SetFileInternal.AsReadOnly();
        internal Dictionary<string, object> SetFileInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> SetString => SetStringInternal.AsReadOnly();
        internal Dictionary<string, object> SetStringInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   If set, no CRDs will be installed. By default, CRDs are installed if not already present.
        /// </summary>
        public virtual bool? SkipCrds { get; internal set; }
        /// <summary>
        ///   Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).
        /// </summary>
        public virtual string Timeout { get; internal set; }
        /// <summary>
        ///   Chart repository username where to locate the requested chart.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Specify values in a YAML file or a URL (can specify multiple).
        /// </summary>
        public virtual IReadOnlyList<string> Values => ValuesInternal.AsReadOnly();
        internal List<string> ValuesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Verify the package before using it.
        /// </summary>
        public virtual bool? Verify { get; internal set; }
        /// <summary>
        ///   Specify the exact chart version to use. If this is not specified, the latest version is used.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.
        /// </summary>
        public virtual bool? Wait { get; internal set; }
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   The name of the chart to install.
        /// </summary>
        public virtual string Chart { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("install")
              .Add("--atomic", Atomic)
              .Add("--ca-file {value}", CaFile)
              .Add("--cert-file {value}", CertFile)
              .Add("--create-namespace", CreateNamespace)
              .Add("--dependency-update", DependencyUpdate)
              .Add("--description {value}", Description)
              .Add("--devel", Devel)
              .Add("--disable-openapi-validation", DisableOpenapiValidation)
              .Add("--dry-run", DryRun)
              .Add("--generate-name", GenerateName)
              .Add("--help", Help)
              .Add("--insecure-skip-tls-verify", InsecureSkipTlsVerify)
              .Add("--key-file {value}", KeyFile)
              .Add("--keyring {value}", Keyring)
              .Add("--name-template {value}", NameTemplate)
              .Add("--no-hooks", NoHooks)
              .Add("--output {value}", Output)
              .Add("--password {value}", Password, secret: true)
              .Add("--post-renderer {value}", PostRenderer)
              .Add("--render-subchart-notes", RenderSubchartNotes)
              .Add("--replace", Replace)
              .Add("--repo {value}", Repo)
              .Add("--set {value}", Set, "{key}={value}", separator: ',')
              .Add("--set-file {value}", SetFile, "{key}={value}", separator: ',')
              .Add("--set-string {value}", SetString, "{key}={value}", separator: ',')
              .Add("--skip-crds", SkipCrds)
              .Add("--timeout {value}", Timeout)
              .Add("--username {value}", Username)
              .Add("--values {value}", Values)
              .Add("--verify", Verify)
              .Add("--version {value}", Version)
              .Add("--wait", Wait)
              .Add("{value}", Name)
              .Add("{value}", Chart);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmLintSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmLintSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for lint.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Set => SetInternal.AsReadOnly();
        internal Dictionary<string, object> SetInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> SetFile => SetFileInternal.AsReadOnly();
        internal Dictionary<string, object> SetFileInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> SetString => SetStringInternal.AsReadOnly();
        internal Dictionary<string, object> SetStringInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Fail on lint warnings.
        /// </summary>
        public virtual bool? Strict { get; internal set; }
        /// <summary>
        ///   Specify values in a YAML file or a URL (can specify multiple).
        /// </summary>
        public virtual IReadOnlyList<string> Values => ValuesInternal.AsReadOnly();
        internal List<string> ValuesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Lint dependent charts.
        /// </summary>
        public virtual bool? WithSubcharts { get; internal set; }
        /// <summary>
        ///   The Path to a chart.
        /// </summary>
        public virtual string Path { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("lint")
              .Add("--help", Help)
              .Add("--set {value}", Set, "{key}={value}", separator: ',')
              .Add("--set-file {value}", SetFile, "{key}={value}", separator: ',')
              .Add("--set-string {value}", SetString, "{key}={value}", separator: ',')
              .Add("--strict", Strict)
              .Add("--values {value}", Values)
              .Add("--with-subcharts", WithSubcharts)
              .Add("{value}", Path);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmListSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmListSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Show all releases without any filter applied.
        /// </summary>
        public virtual bool? All { get; internal set; }
        /// <summary>
        ///   List releases across all namespaces.
        /// </summary>
        public virtual bool? AllNamespaces { get; internal set; }
        /// <summary>
        ///   Sort by release date.
        /// </summary>
        public virtual bool? Date { get; internal set; }
        /// <summary>
        ///   Show deployed releases. If no other is specified, this will be automatically enabled.
        /// </summary>
        public virtual bool? Deployed { get; internal set; }
        /// <summary>
        ///   Show failed releases.
        /// </summary>
        public virtual bool? Failed { get; internal set; }
        /// <summary>
        ///   The filter to use.
        /// </summary>
        public virtual string Filter { get; internal set; }
        /// <summary>
        ///   Help for list.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Maximum number of releases to fetch (default 256).
        /// </summary>
        public virtual long? Max { get; internal set; }
        /// <summary>
        ///   Next release name in the list, used to offset from start value.
        /// </summary>
        public virtual long? Offset { get; internal set; }
        /// <summary>
        ///   Prints the output in the specified format. Allowed values: table, json, yaml (default table).
        /// </summary>
        public virtual HelmOutputFormat Output { get; internal set; }
        /// <summary>
        ///   Show pending releases.
        /// </summary>
        public virtual bool? Pending { get; internal set; }
        /// <summary>
        ///   Reverse the sort order.
        /// </summary>
        public virtual bool? Reverse { get; internal set; }
        /// <summary>
        ///   Output short (quiet) listing format.
        /// </summary>
        public virtual bool? Short { get; internal set; }
        /// <summary>
        ///   Show superseded releases.
        /// </summary>
        public virtual bool? Superseded { get; internal set; }
        /// <summary>
        ///   Show uninstalled releases (if 'helm uninstall --keep-history' was used).
        /// </summary>
        public virtual bool? Uninstalled { get; internal set; }
        /// <summary>
        ///   Show releases that are currently being uninstalled.
        /// </summary>
        public virtual bool? Uninstalling { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("list")
              .Add("--all", All)
              .Add("--all-namespaces", AllNamespaces)
              .Add("--date", Date)
              .Add("--deployed", Deployed)
              .Add("--failed", Failed)
              .Add("--filter {value}", Filter)
              .Add("--help", Help)
              .Add("--max {value}", Max)
              .Add("--offset {value}", Offset)
              .Add("--output {value}", Output)
              .Add("--pending", Pending)
              .Add("--reverse", Reverse)
              .Add("--short", Short)
              .Add("--superseded", Superseded)
              .Add("--uninstalled", Uninstalled)
              .Add("--uninstalling", Uninstalling);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmPackageSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmPackageSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Set the appVersion on the chart to this version.
        /// </summary>
        public virtual string AppVersion { get; internal set; }
        /// <summary>
        ///   Update dependencies from "Chart.yaml" to dir "charts/" before packaging.
        /// </summary>
        public virtual bool? DependencyUpdate { get; internal set; }
        /// <summary>
        ///   Location to write the chart. (default ".").
        /// </summary>
        public virtual string Destination { get; internal set; }
        /// <summary>
        ///   Help for package.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Name of the key to use when signing. Used if --sign is true.
        /// </summary>
        public virtual string Key { get; internal set; }
        /// <summary>
        ///   Location of a public keyring (default "~/.gnupg/pubring.gpg").
        /// </summary>
        public virtual string Keyring { get; internal set; }
        /// <summary>
        ///   Use a PGP private key to sign this package.
        /// </summary>
        public virtual bool? Sign { get; internal set; }
        /// <summary>
        ///   Set the version on the chart to this semver version.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   The paths to the charts to package.
        /// </summary>
        public virtual IReadOnlyList<string> ChartPaths => ChartPathsInternal.AsReadOnly();
        internal List<string> ChartPathsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("package")
              .Add("--app-version {value}", AppVersion)
              .Add("--dependency-update", DependencyUpdate)
              .Add("--destination {value}", Destination)
              .Add("--help", Help)
              .Add("--key {value}", Key)
              .Add("--keyring {value}", Keyring)
              .Add("--sign", Sign)
              .Add("--version {value}", Version)
              .Add("{value}", ChartPaths, separator: ' ');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmPluginInstallSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmPluginInstallSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for install.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Specify a version constraint. If this is not specified, the latest version is installed.
        /// </summary>
        public virtual string Version { get; internal set; }
        public virtual string Options { get; internal set; }
        /// <summary>
        ///   List of paths or urls of packages to install.
        /// </summary>
        public virtual IReadOnlyList<string> Paths => PathsInternal.AsReadOnly();
        internal List<string> PathsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("plugin install")
              .Add("--help", Help)
              .Add("--version {value}", Version)
              .Add("{value}", Options)
              .Add("{value}", Paths, separator: ' ');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmPluginListSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmPluginListSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for list.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("plugin list")
              .Add("--help", Help);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmPluginUninstallSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmPluginUninstallSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for uninstall.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        public virtual IReadOnlyList<string> Plugins => PluginsInternal.AsReadOnly();
        internal List<string> PluginsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("plugin uninstall")
              .Add("--help", Help)
              .Add("{value}", Plugins, separator: ' ');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmPluginUpdateSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmPluginUpdateSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for update.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   List of plugins to update.
        /// </summary>
        public virtual IReadOnlyList<string> Plugins => PluginsInternal.AsReadOnly();
        internal List<string> PluginsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("plugin update")
              .Add("--help", Help)
              .Add("{value}", Plugins, separator: ' ');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmPullSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmPullSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
        /// </summary>
        public virtual string CaFile { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL certificate file.
        /// </summary>
        public virtual string CertFile { get; internal set; }
        /// <summary>
        ///   Location to write the chart. If this and tardir are specified, tardir is appended to this (default ".").
        /// </summary>
        public virtual string Destination { get; internal set; }
        /// <summary>
        ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
        /// </summary>
        public virtual bool? Devel { get; internal set; }
        /// <summary>
        ///   Help for pull.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Skip tls certificate checks for the chart download.
        /// </summary>
        public virtual bool? InsecureSkipTlsVerify { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL key file.
        /// </summary>
        public virtual string KeyFile { get; internal set; }
        /// <summary>
        ///   Location of public keys used for verification (default "~/.gnupg/pubring.gpg").
        /// </summary>
        public virtual string Keyring { get; internal set; }
        /// <summary>
        ///   Chart repository password where to locate the requested chart.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Fetch the provenance file, but don't perform verification.
        /// </summary>
        public virtual bool? Prov { get; internal set; }
        /// <summary>
        ///   Chart repository url where to locate the requested chart.
        /// </summary>
        public virtual string Repo { get; internal set; }
        /// <summary>
        ///   If set to true, will untar the chart after downloading it.
        /// </summary>
        public virtual bool? Untar { get; internal set; }
        /// <summary>
        ///   If untar is specified, this flag specifies the name of the directory into which the chart is expanded (default ".").
        /// </summary>
        public virtual string Untardir { get; internal set; }
        /// <summary>
        ///   Chart repository username where to locate the requested chart.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Verify the package before using it.
        /// </summary>
        public virtual bool? Verify { get; internal set; }
        /// <summary>
        ///   Specify the exact chart version to use. If this is not specified, the latest version is used.
        /// </summary>
        public virtual string Version { get; internal set; }
        public virtual IReadOnlyList<string> Urls => UrlsInternal.AsReadOnly();
        internal List<string> UrlsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("pull")
              .Add("--ca-file {value}", CaFile)
              .Add("--cert-file {value}", CertFile)
              .Add("--destination {value}", Destination)
              .Add("--devel", Devel)
              .Add("--help", Help)
              .Add("--insecure-skip-tls-verify", InsecureSkipTlsVerify)
              .Add("--key-file {value}", KeyFile)
              .Add("--keyring {value}", Keyring)
              .Add("--password {value}", Password, secret: true)
              .Add("--prov", Prov)
              .Add("--repo {value}", Repo)
              .Add("--untar", Untar)
              .Add("--untardir {value}", Untardir)
              .Add("--username {value}", Username)
              .Add("--verify", Verify)
              .Add("--version {value}", Version)
              .Add("{value}", Urls, separator: ' ');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmRepoAddSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmRepoAddSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
        /// </summary>
        public virtual string CaFile { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL certificate file.
        /// </summary>
        public virtual string CertFile { get; internal set; }
        /// <summary>
        ///   Replace (overwrite) the repo if it already exists.
        /// </summary>
        public virtual bool? ForceUpdate { get; internal set; }
        /// <summary>
        ///   Help for add.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Skip tls certificate checks for the repository.
        /// </summary>
        public virtual bool? InsecureSkipTlsVerify { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL key file.
        /// </summary>
        public virtual string KeyFile { get; internal set; }
        /// <summary>
        ///   Ignored. Formerly, it would disabled forced updates. It is deprecated by force-update.
        /// </summary>
        public virtual bool? NoUpdate { get; internal set; }
        /// <summary>
        ///   Chart repository password.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Chart repository username.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   The name of the repository to add.
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   The url of the repository to add.
        /// </summary>
        public virtual string Url { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("repo add")
              .Add("--ca-file {value}", CaFile)
              .Add("--cert-file {value}", CertFile)
              .Add("--force-update", ForceUpdate)
              .Add("--help", Help)
              .Add("--insecure-skip-tls-verify", InsecureSkipTlsVerify)
              .Add("--key-file {value}", KeyFile)
              .Add("--no-update", NoUpdate)
              .Add("--password {value}", Password, secret: true)
              .Add("--username {value}", Username)
              .Add("{value}", Name)
              .Add("{value}", Url);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmRepoIndexSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmRepoIndexSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for index.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Merge the generated index into the given index.
        /// </summary>
        public virtual string Merge { get; internal set; }
        /// <summary>
        ///   Url of chart repository.
        /// </summary>
        public virtual string Url { get; internal set; }
        /// <summary>
        ///   The directory of the repository.
        /// </summary>
        public virtual string Directory { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("repo index")
              .Add("--help", Help)
              .Add("--merge {value}", Merge)
              .Add("--url {value}", Url)
              .Add("{value}", Directory);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmRepoListSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmRepoListSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for list.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Prints the output in the specified format. Allowed values: table, json, yaml (default table).
        /// </summary>
        public virtual HelmOutputFormat Output { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("repo list")
              .Add("--help", Help)
              .Add("--output {value}", Output);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmRepoRemoveSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmRepoRemoveSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for remove.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        public virtual IReadOnlyList<string> Repositories => RepositoriesInternal.AsReadOnly();
        internal List<string> RepositoriesInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("repo remove")
              .Add("--help", Help)
              .Add("{value}", Repositories);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmRepoUpdateSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmRepoUpdateSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for update.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("repo update")
              .Add("--help", Help);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmRollbackSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmRollbackSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Allow deletion of new resources created in this rollback when rollback fails.
        /// </summary>
        public virtual bool? CleanupOnFail { get; internal set; }
        /// <summary>
        ///   Simulate a rollback.
        /// </summary>
        public virtual bool? DryRun { get; internal set; }
        /// <summary>
        ///   Force resource update through delete/recreate if needed.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Help for rollback.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Prevent hooks from running during rollback.
        /// </summary>
        public virtual bool? NoHooks { get; internal set; }
        /// <summary>
        ///   Performs pods restart for the resource if applicable.
        /// </summary>
        public virtual bool? RecreatePods { get; internal set; }
        /// <summary>
        ///   Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).
        /// </summary>
        public virtual string Timeout { get; internal set; }
        /// <summary>
        ///   If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.
        /// </summary>
        public virtual bool? Wait { get; internal set; }
        /// <summary>
        ///   The name of the release.
        /// </summary>
        public virtual string Release { get; internal set; }
        /// <summary>
        ///   The revison to roll back.
        /// </summary>
        public virtual string Revision { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("rollback")
              .Add("--cleanup-on-fail", CleanupOnFail)
              .Add("--dry-run", DryRun)
              .Add("--force", Force)
              .Add("--help", Help)
              .Add("--no-hooks", NoHooks)
              .Add("--recreate-pods", RecreatePods)
              .Add("--timeout {value}", Timeout)
              .Add("--wait", Wait)
              .Add("{value}", Release)
              .Add("{value}", Revision);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmSearchHubSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmSearchHubSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Monocular instance to query for charts (default "https://hub.helm.sh").
        /// </summary>
        public virtual string Endpoint { get; internal set; }
        /// <summary>
        ///   Help for hub.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Maximum column width for output table (default 50).
        /// </summary>
        public virtual uint? MaxColWidth { get; internal set; }
        /// <summary>
        ///   Prints the output in the specified format. Allowed values: table, json, yaml (default table).
        /// </summary>
        public virtual HelmOutputFormat Output { get; internal set; }
        public virtual string Keyword { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("search hub")
              .Add("--endpoint {value}", Endpoint)
              .Add("--help", Help)
              .Add("--max-col-width {value}", MaxColWidth)
              .Add("--output {value}", Output)
              .Add("{value}", Keyword);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmSearchRepoSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmSearchRepoSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Use development versions (alpha, beta, and release candidate releases), too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
        /// </summary>
        public virtual bool? Devel { get; internal set; }
        /// <summary>
        ///   Help for repo.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Maximum column width for output table (default 50).
        /// </summary>
        public virtual uint? MaxColWidth { get; internal set; }
        /// <summary>
        ///   Prints the output in the specified format. Allowed values: table, json, yaml (default table).
        /// </summary>
        public virtual HelmOutputFormat Output { get; internal set; }
        /// <summary>
        ///   Use regular expressions for searching repositories you have added.
        /// </summary>
        public virtual bool? Regexp { get; internal set; }
        /// <summary>
        ///   Search using semantic versioning constraints on repositories you have added.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   Show the long listing, with each version of each chart on its own line, for repositories you have added.
        /// </summary>
        public virtual bool? Versions { get; internal set; }
        public virtual string Keyword { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("search repo")
              .Add("--devel", Devel)
              .Add("--help", Help)
              .Add("--max-col-width {value}", MaxColWidth)
              .Add("--output {value}", Output)
              .Add("--regexp", Regexp)
              .Add("--version {value}", Version)
              .Add("--versions", Versions)
              .Add("{value}", Keyword);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmShowAllSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmShowAllSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
        /// </summary>
        public virtual string CaFile { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL certificate file.
        /// </summary>
        public virtual string CertFile { get; internal set; }
        /// <summary>
        ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
        /// </summary>
        public virtual bool? Devel { get; internal set; }
        /// <summary>
        ///   Help for all.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Skip tls certificate checks for the chart download.
        /// </summary>
        public virtual bool? InsecureSkipTlsVerify { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL key file.
        /// </summary>
        public virtual string KeyFile { get; internal set; }
        /// <summary>
        ///   Location of public keys used for verification (default "~/.gnupg/pubring.gpg").
        /// </summary>
        public virtual string Keyring { get; internal set; }
        /// <summary>
        ///   Chart repository password where to locate the requested chart.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Chart repository url where to locate the requested chart.
        /// </summary>
        public virtual string Repo { get; internal set; }
        /// <summary>
        ///   Chart repository username where to locate the requested chart.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Verify the package before using it.
        /// </summary>
        public virtual bool? Verify { get; internal set; }
        /// <summary>
        ///   Specify the exact chart version to use. If this is not specified, the latest version is used.
        /// </summary>
        public virtual string Version { get; internal set; }
        public virtual string Chart { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("show all")
              .Add("--ca-file {value}", CaFile)
              .Add("--cert-file {value}", CertFile)
              .Add("--devel", Devel)
              .Add("--help", Help)
              .Add("--insecure-skip-tls-verify", InsecureSkipTlsVerify)
              .Add("--key-file {value}", KeyFile)
              .Add("--keyring {value}", Keyring)
              .Add("--password {value}", Password, secret: true)
              .Add("--repo {value}", Repo)
              .Add("--username {value}", Username)
              .Add("--verify", Verify)
              .Add("--version {value}", Version)
              .Add("{value}", Chart);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmShowChartSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmShowChartSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
        /// </summary>
        public virtual string CaFile { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL certificate file.
        /// </summary>
        public virtual string CertFile { get; internal set; }
        /// <summary>
        ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
        /// </summary>
        public virtual bool? Devel { get; internal set; }
        /// <summary>
        ///   Help for chart.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Skip tls certificate checks for the chart download.
        /// </summary>
        public virtual bool? InsecureSkipTlsVerify { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL key file.
        /// </summary>
        public virtual string KeyFile { get; internal set; }
        /// <summary>
        ///   Location of public keys used for verification (default "~/.gnupg/pubring.gpg").
        /// </summary>
        public virtual string Keyring { get; internal set; }
        /// <summary>
        ///   Chart repository password where to locate the requested chart.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Chart repository url where to locate the requested chart.
        /// </summary>
        public virtual string Repo { get; internal set; }
        /// <summary>
        ///   Chart repository username where to locate the requested chart.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Verify the package before using it.
        /// </summary>
        public virtual bool? Verify { get; internal set; }
        /// <summary>
        ///   Specify the exact chart version to use. If this is not specified, the latest version is used.
        /// </summary>
        public virtual string Version { get; internal set; }
        public virtual string Chart { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("show chart")
              .Add("--ca-file {value}", CaFile)
              .Add("--cert-file {value}", CertFile)
              .Add("--devel", Devel)
              .Add("--help", Help)
              .Add("--insecure-skip-tls-verify", InsecureSkipTlsVerify)
              .Add("--key-file {value}", KeyFile)
              .Add("--keyring {value}", Keyring)
              .Add("--password {value}", Password, secret: true)
              .Add("--repo {value}", Repo)
              .Add("--username {value}", Username)
              .Add("--verify", Verify)
              .Add("--version {value}", Version)
              .Add("{value}", Chart);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmShowReadmeSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmShowReadmeSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
        /// </summary>
        public virtual string CaFile { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL certificate file.
        /// </summary>
        public virtual string CertFile { get; internal set; }
        /// <summary>
        ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
        /// </summary>
        public virtual bool? Devel { get; internal set; }
        /// <summary>
        ///   Help for readme.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Skip tls certificate checks for the chart download.
        /// </summary>
        public virtual bool? InsecureSkipTlsVerify { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL key file.
        /// </summary>
        public virtual string KeyFile { get; internal set; }
        /// <summary>
        ///   Location of public keys used for verification (default "~/.gnupg/pubring.gpg").
        /// </summary>
        public virtual string Keyring { get; internal set; }
        /// <summary>
        ///   Chart repository password where to locate the requested chart.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Chart repository url where to locate the requested chart.
        /// </summary>
        public virtual string Repo { get; internal set; }
        /// <summary>
        ///   Chart repository username where to locate the requested chart.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Verify the package before using it.
        /// </summary>
        public virtual bool? Verify { get; internal set; }
        /// <summary>
        ///   Specify the exact chart version to use. If this is not specified, the latest version is used.
        /// </summary>
        public virtual string Version { get; internal set; }
        public virtual string Chart { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("show readme")
              .Add("--ca-file {value}", CaFile)
              .Add("--cert-file {value}", CertFile)
              .Add("--devel", Devel)
              .Add("--help", Help)
              .Add("--insecure-skip-tls-verify", InsecureSkipTlsVerify)
              .Add("--key-file {value}", KeyFile)
              .Add("--keyring {value}", Keyring)
              .Add("--password {value}", Password, secret: true)
              .Add("--repo {value}", Repo)
              .Add("--username {value}", Username)
              .Add("--verify", Verify)
              .Add("--version {value}", Version)
              .Add("{value}", Chart);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmShowValuesSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmShowValuesSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
        /// </summary>
        public virtual string CaFile { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL certificate file.
        /// </summary>
        public virtual string CertFile { get; internal set; }
        /// <summary>
        ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
        /// </summary>
        public virtual bool? Devel { get; internal set; }
        /// <summary>
        ///   Help for values.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Skip tls certificate checks for the chart download.
        /// </summary>
        public virtual bool? InsecureSkipTlsVerify { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL key file.
        /// </summary>
        public virtual string KeyFile { get; internal set; }
        /// <summary>
        ///   Location of public keys used for verification (default "~/.gnupg/pubring.gpg").
        /// </summary>
        public virtual string Keyring { get; internal set; }
        /// <summary>
        ///   Chart repository password where to locate the requested chart.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   Chart repository url where to locate the requested chart.
        /// </summary>
        public virtual string Repo { get; internal set; }
        /// <summary>
        ///   Chart repository username where to locate the requested chart.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Verify the package before using it.
        /// </summary>
        public virtual bool? Verify { get; internal set; }
        /// <summary>
        ///   Specify the exact chart version to use. If this is not specified, the latest version is used.
        /// </summary>
        public virtual string Version { get; internal set; }
        public virtual string Chart { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("show values")
              .Add("--ca-file {value}", CaFile)
              .Add("--cert-file {value}", CertFile)
              .Add("--devel", Devel)
              .Add("--help", Help)
              .Add("--insecure-skip-tls-verify", InsecureSkipTlsVerify)
              .Add("--key-file {value}", KeyFile)
              .Add("--keyring {value}", Keyring)
              .Add("--password {value}", Password, secret: true)
              .Add("--repo {value}", Repo)
              .Add("--username {value}", Username)
              .Add("--verify", Verify)
              .Add("--version {value}", Version)
              .Add("{value}", Chart);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmStatusSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmStatusSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for status.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Prints the output in the specified format. Allowed values: table, json, yaml (default table).
        /// </summary>
        public virtual HelmOutputFormat Output { get; internal set; }
        /// <summary>
        ///   If set, display the status of the named release with revision.
        /// </summary>
        public virtual long? Revision { get; internal set; }
        /// <summary>
        ///   The name of the release to get the status for.
        /// </summary>
        public virtual string ReleaseName { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("status")
              .Add("--help", Help)
              .Add("--output {value}", Output)
              .Add("--revision {value}", Revision)
              .Add("{value}", ReleaseName);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmTemplateSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmTemplateSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Kubernetes api versions used for Capabilities.APIVersions.
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> ApiVersions => ApiVersionsInternal.AsReadOnly();
        internal Dictionary<string, object> ApiVersionsInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   If set, the installation process deletes the installation on failure. The --wait flag will be set automatically if --atomic is used.
        /// </summary>
        public virtual bool? Atomic { get; internal set; }
        /// <summary>
        ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
        /// </summary>
        public virtual string CaFile { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL certificate file.
        /// </summary>
        public virtual string CertFile { get; internal set; }
        /// <summary>
        ///   Create the release namespace if not present.
        /// </summary>
        public virtual bool? CreateNamespace { get; internal set; }
        /// <summary>
        ///   Run helm dependency update before installing the chart.
        /// </summary>
        public virtual bool? DependencyUpdate { get; internal set; }
        /// <summary>
        ///   Add a custom description.
        /// </summary>
        public virtual string Description { get; internal set; }
        /// <summary>
        ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
        /// </summary>
        public virtual bool? Devel { get; internal set; }
        /// <summary>
        ///   If set, the installation process will not validate rendered templates against the Kubernetes OpenAPI Schema.
        /// </summary>
        public virtual bool? DisableOpenapiValidation { get; internal set; }
        /// <summary>
        ///   Simulate an install.
        /// </summary>
        public virtual bool? DryRun { get; internal set; }
        /// <summary>
        ///   Generate the name (and omit the NAME parameter).
        /// </summary>
        public virtual bool? GenerateName { get; internal set; }
        /// <summary>
        ///   Help for template.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Include CRDs in the templated output.
        /// </summary>
        public virtual bool? IncludeCrds { get; internal set; }
        /// <summary>
        ///   Skip tls certificate checks for the chart download.
        /// </summary>
        public virtual bool? InsecureSkipTlsVerify { get; internal set; }
        /// <summary>
        ///   Set .Release.IsUpgrade instead of .Release.IsInstall.
        /// </summary>
        public virtual bool? IsUpgrade { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL key file.
        /// </summary>
        public virtual string KeyFile { get; internal set; }
        /// <summary>
        ///   Location of public keys used for verification (default "~/.gnupg/pubring.gpg").
        /// </summary>
        public virtual string Keyring { get; internal set; }
        /// <summary>
        ///   Specify template used to name the release.
        /// </summary>
        public virtual string NameTemplate { get; internal set; }
        /// <summary>
        ///   Prevent hooks from running during install.
        /// </summary>
        public virtual bool? NoHooks { get; internal set; }
        /// <summary>
        ///   Writes the executed templates to files in output-dir instead of stdout.
        /// </summary>
        public virtual string OutputDir { get; internal set; }
        /// <summary>
        ///   Chart repository password where to locate the requested chart.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   The path to an executable to be used for post rendering. If it exists in $PATH, the binary will be used, otherwise it will try to look for the executable at the given path (default exec).
        /// </summary>
        public virtual string PostRenderer { get; internal set; }
        /// <summary>
        ///   Use release name in the output-dir path.
        /// </summary>
        public virtual bool? ReleaseName { get; internal set; }
        /// <summary>
        ///   If set, render subchart notes along with the parent.
        /// </summary>
        public virtual bool? RenderSubchartNotes { get; internal set; }
        /// <summary>
        ///   Re-use the given name, only if that name is a deleted release which remains in the history. This is unsafe in production.
        /// </summary>
        public virtual bool? Replace { get; internal set; }
        /// <summary>
        ///   Chart repository url where to locate the requested chart.
        /// </summary>
        public virtual string Repo { get; internal set; }
        /// <summary>
        ///   Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Set => SetInternal.AsReadOnly();
        internal Dictionary<string, object> SetInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> SetFile => SetFileInternal.AsReadOnly();
        internal Dictionary<string, object> SetFileInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> SetString => SetStringInternal.AsReadOnly();
        internal Dictionary<string, object> SetStringInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Only show manifests rendered from the given templates.
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> ShowOnly => ShowOnlyInternal.AsReadOnly();
        internal Dictionary<string, object> ShowOnlyInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   If set, no CRDs will be installed. By default, CRDs are installed if not already present.
        /// </summary>
        public virtual bool? SkipCrds { get; internal set; }
        /// <summary>
        ///   Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).
        /// </summary>
        public virtual string Timeout { get; internal set; }
        /// <summary>
        ///   Chart repository username where to locate the requested chart.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Validate your manifests against the Kubernetes cluster you are currently pointing at. This is the same validation performed on an install.
        /// </summary>
        public virtual bool? Validate { get; internal set; }
        /// <summary>
        ///   Specify values in a YAML file or a URL (can specify multiple).
        /// </summary>
        public virtual IReadOnlyList<string> Values => ValuesInternal.AsReadOnly();
        internal List<string> ValuesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Verify the package before using it.
        /// </summary>
        public virtual bool? Verify { get; internal set; }
        /// <summary>
        ///   Specify the exact chart version to use. If this is not specified, the latest version is used.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.
        /// </summary>
        public virtual bool? Wait { get; internal set; }
        public virtual string Name { get; internal set; }
        public virtual string Chart { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("template")
              .Add("--api-versions {value}", ApiVersions, "{key}={value}", separator: ',')
              .Add("--atomic", Atomic)
              .Add("--ca-file {value}", CaFile)
              .Add("--cert-file {value}", CertFile)
              .Add("--create-namespace", CreateNamespace)
              .Add("--dependency-update", DependencyUpdate)
              .Add("--description {value}", Description)
              .Add("--devel", Devel)
              .Add("--disable-openapi-validation", DisableOpenapiValidation)
              .Add("--dry-run", DryRun)
              .Add("--generate-name", GenerateName)
              .Add("--help", Help)
              .Add("--include-crds", IncludeCrds)
              .Add("--insecure-skip-tls-verify", InsecureSkipTlsVerify)
              .Add("--is-upgrade", IsUpgrade)
              .Add("--key-file {value}", KeyFile)
              .Add("--keyring {value}", Keyring)
              .Add("--name-template {value}", NameTemplate)
              .Add("--no-hooks", NoHooks)
              .Add("--output-dir {value}", OutputDir)
              .Add("--password {value}", Password, secret: true)
              .Add("--post-renderer {value}", PostRenderer)
              .Add("--release-name", ReleaseName)
              .Add("--render-subchart-notes", RenderSubchartNotes)
              .Add("--replace", Replace)
              .Add("--repo {value}", Repo)
              .Add("--set {value}", Set, "{key}={value}", separator: ',')
              .Add("--set-file {value}", SetFile, "{key}={value}", separator: ',')
              .Add("--set-string {value}", SetString, "{key}={value}", separator: ',')
              .Add("--show-only {value}", ShowOnly, "{key}={value}", separator: ',')
              .Add("--skip-crds", SkipCrds)
              .Add("--timeout {value}", Timeout)
              .Add("--username {value}", Username)
              .Add("--validate", Validate)
              .Add("--values {value}", Values)
              .Add("--verify", Verify)
              .Add("--version {value}", Version)
              .Add("--wait", Wait)
              .Add("{value}", Name)
              .Add("{value}", Chart);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmTestSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmTestSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for test.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Dump the logs from test pods (this runs after all tests are complete, but before any cleanup).
        /// </summary>
        public virtual bool? Logs { get; internal set; }
        /// <summary>
        ///   Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).
        /// </summary>
        public virtual string Timeout { get; internal set; }
        /// <summary>
        ///   The name of the release to test.
        /// </summary>
        public virtual string Release { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("test")
              .Add("--help", Help)
              .Add("--logs", Logs)
              .Add("--timeout {value}", Timeout)
              .Add("{value}", Release);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmUninstallSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmUninstallSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Add a custom description.
        /// </summary>
        public virtual string Description { get; internal set; }
        /// <summary>
        ///   Simulate a uninstall.
        /// </summary>
        public virtual bool? DryRun { get; internal set; }
        /// <summary>
        ///   Help for uninstall.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Remove all associated resources and mark the release as deleted, but retain the release history.
        /// </summary>
        public virtual bool? KeepHistory { get; internal set; }
        /// <summary>
        ///   Prevent hooks from running during uninstallation.
        /// </summary>
        public virtual bool? NoHooks { get; internal set; }
        /// <summary>
        ///   Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).
        /// </summary>
        public virtual string Timeout { get; internal set; }
        public virtual IReadOnlyList<string> ReleaseNames => ReleaseNamesInternal.AsReadOnly();
        internal List<string> ReleaseNamesInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("uninstall")
              .Add("--description {value}", Description)
              .Add("--dry-run", DryRun)
              .Add("--help", Help)
              .Add("--keep-history", KeepHistory)
              .Add("--no-hooks", NoHooks)
              .Add("--timeout {value}", Timeout)
              .Add("{value}", ReleaseNames, separator: ' ');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmUpgradeSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmUpgradeSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   If set, upgrade process rolls back changes made in case of failed upgrade. The --wait flag will be set automatically if --atomic is used.
        /// </summary>
        public virtual bool? Atomic { get; internal set; }
        /// <summary>
        ///   Verify certificates of HTTPS-enabled servers using this CA bundle.
        /// </summary>
        public virtual string CaFile { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL certificate file.
        /// </summary>
        public virtual string CertFile { get; internal set; }
        /// <summary>
        ///   Allow deletion of new resources created in this upgrade when upgrade fails.
        /// </summary>
        public virtual bool? CleanupOnFail { get; internal set; }
        /// <summary>
        ///   If --install is set, create the release namespace if not present.
        /// </summary>
        public virtual bool? CreateNamespace { get; internal set; }
        /// <summary>
        ///   Add a custom description.
        /// </summary>
        public virtual string Description { get; internal set; }
        /// <summary>
        ///   Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.
        /// </summary>
        public virtual bool? Devel { get; internal set; }
        /// <summary>
        ///   If set, the upgrade process will not validate rendered templates against the Kubernetes OpenAPI Schema.
        /// </summary>
        public virtual bool? DisableOpenapiValidation { get; internal set; }
        /// <summary>
        ///   Simulate an upgrade.
        /// </summary>
        public virtual bool? DryRun { get; internal set; }
        /// <summary>
        ///   Force resource updates through a replacement strategy.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   Help for upgrade.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Limit the maximum number of revisions saved per release. Use 0 for no limit (default 10).
        /// </summary>
        public virtual long? HistoryMax { get; internal set; }
        /// <summary>
        ///   Skip tls certificate checks for the chart download.
        /// </summary>
        public virtual bool? InsecureSkipTlsVerify { get; internal set; }
        /// <summary>
        ///   If a release by this name doesn't already exist, run an install.
        /// </summary>
        public virtual bool? Install { get; internal set; }
        /// <summary>
        ///   Identify HTTPS client using this SSL key file.
        /// </summary>
        public virtual string KeyFile { get; internal set; }
        /// <summary>
        ///   Location of public keys used for verification (default "~/.gnupg/pubring.gpg").
        /// </summary>
        public virtual string Keyring { get; internal set; }
        /// <summary>
        ///   Disable pre/post upgrade hooks.
        /// </summary>
        public virtual bool? NoHooks { get; internal set; }
        /// <summary>
        ///   Prints the output in the specified format. Allowed values: table, json, yaml (default table).
        /// </summary>
        public virtual HelmOutputFormat Output { get; internal set; }
        /// <summary>
        ///   Chart repository password where to locate the requested chart.
        /// </summary>
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   The path to an executable to be used for post rendering. If it exists in $PATH, the binary will be used, otherwise it will try to look for the executable at the given path (default exec).
        /// </summary>
        public virtual string PostRenderer { get; internal set; }
        /// <summary>
        ///   If set, render subchart notes along with the parent.
        /// </summary>
        public virtual bool? RenderSubchartNotes { get; internal set; }
        /// <summary>
        ///   Chart repository url where to locate the requested chart.
        /// </summary>
        public virtual string Repo { get; internal set; }
        /// <summary>
        ///   When upgrading, reset the values to the ones built into the chart.
        /// </summary>
        public virtual bool? ResetValues { get; internal set; }
        /// <summary>
        ///   When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.
        /// </summary>
        public virtual bool? ReuseValues { get; internal set; }
        /// <summary>
        ///   Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Set => SetInternal.AsReadOnly();
        internal Dictionary<string, object> SetInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> SetFile => SetFileInternal.AsReadOnly();
        internal Dictionary<string, object> SetFileInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> SetString => SetStringInternal.AsReadOnly();
        internal Dictionary<string, object> SetStringInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   If set, no CRDs will be installed when an upgrade is performed with install flag enabled. By default, CRDs are installed if not already present, when an upgrade is performed with install flag enabled.
        /// </summary>
        public virtual bool? SkipCrds { get; internal set; }
        /// <summary>
        ///   Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).
        /// </summary>
        public virtual string Timeout { get; internal set; }
        /// <summary>
        ///   Chart repository username where to locate the requested chart.
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Specify values in a YAML file or a URL (can specify multiple).
        /// </summary>
        public virtual IReadOnlyList<string> Values => ValuesInternal.AsReadOnly();
        internal List<string> ValuesInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Verify the package before using it.
        /// </summary>
        public virtual bool? Verify { get; internal set; }
        /// <summary>
        ///   Specify the exact chart version to use. If this is not specified, the latest version is used.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.
        /// </summary>
        public virtual bool? Wait { get; internal set; }
        /// <summary>
        ///   The name of the release to upgrade.
        /// </summary>
        public virtual string Release { get; internal set; }
        /// <summary>
        ///   The name of the chart to upgrade.
        /// </summary>
        public virtual string Chart { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("upgrade")
              .Add("--atomic", Atomic)
              .Add("--ca-file {value}", CaFile)
              .Add("--cert-file {value}", CertFile)
              .Add("--cleanup-on-fail", CleanupOnFail)
              .Add("--create-namespace", CreateNamespace)
              .Add("--description {value}", Description)
              .Add("--devel", Devel)
              .Add("--disable-openapi-validation", DisableOpenapiValidation)
              .Add("--dry-run", DryRun)
              .Add("--force", Force)
              .Add("--help", Help)
              .Add("--history-max {value}", HistoryMax)
              .Add("--insecure-skip-tls-verify", InsecureSkipTlsVerify)
              .Add("--install", Install)
              .Add("--key-file {value}", KeyFile)
              .Add("--keyring {value}", Keyring)
              .Add("--no-hooks", NoHooks)
              .Add("--output {value}", Output)
              .Add("--password {value}", Password, secret: true)
              .Add("--post-renderer {value}", PostRenderer)
              .Add("--render-subchart-notes", RenderSubchartNotes)
              .Add("--repo {value}", Repo)
              .Add("--reset-values", ResetValues)
              .Add("--reuse-values", ReuseValues)
              .Add("--set {value}", Set, "{key}={value}", separator: ',')
              .Add("--set-file {value}", SetFile, "{key}={value}", separator: ',')
              .Add("--set-string {value}", SetString, "{key}={value}", separator: ',')
              .Add("--skip-crds", SkipCrds)
              .Add("--timeout {value}", Timeout)
              .Add("--username {value}", Username)
              .Add("--values {value}", Values)
              .Add("--verify", Verify)
              .Add("--version {value}", Version)
              .Add("--wait", Wait)
              .Add("{value}", Release)
              .Add("{value}", Chart);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmVerifySettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmVerifySettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for verify.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Keyring containing public keys (default "~/.gnupg/pubring.gpg").
        /// </summary>
        public virtual string Keyring { get; internal set; }
        /// <summary>
        ///   The path to the chart to verify.
        /// </summary>
        public virtual string Path { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("verify")
              .Add("--help", Help)
              .Add("--keyring {value}", Keyring)
              .Add("{value}", Path);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmVersionSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmVersionSettings : HelmToolSettings
    {
        /// <summary>
        ///   Path to the Helm executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? HelmTasks.HelmPath;
        public override Action<OutputType, string> ProcessCustomLogger => HelmTasks.HelmLogger;
        /// <summary>
        ///   Help for version.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Print the version number.
        /// </summary>
        public virtual bool? Short { get; internal set; }
        /// <summary>
        ///   Template for version string format.
        /// </summary>
        public virtual string Template { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("version")
              .Add("--help", Help)
              .Add("--short", Short)
              .Add("--template {value}", Template);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmCommonSettings
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class HelmCommonSettings : ToolSettings
    {
        /// <summary>
        ///   If true, adds the file directory to the header.
        /// </summary>
        public virtual bool? AddDirHeader { get; internal set; }
        /// <summary>
        ///   Log to standard error as well as files.
        /// </summary>
        public virtual bool? Alsologtostderr { get; internal set; }
        /// <summary>
        ///   Enable verbose output.
        /// </summary>
        public virtual bool? Debug { get; internal set; }
        /// <summary>
        ///   Help for helm.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   The address and the port for the Kubernetes API server.
        /// </summary>
        public virtual string KubeApiserver { get; internal set; }
        /// <summary>
        ///   Name of the kubeconfig context to use.
        /// </summary>
        public virtual string KubeContext { get; internal set; }
        /// <summary>
        ///   Bearer token used for authentication.
        /// </summary>
        public virtual string KubeToken { get; internal set; }
        /// <summary>
        ///   Path to the kubeconfig file.
        /// </summary>
        public virtual string Kubeconfig { get; internal set; }
        /// <summary>
        ///   When logging hits line file:N, emit a stack trace (default :0).
        /// </summary>
        public virtual string LogBacktraceAt { get; internal set; }
        /// <summary>
        ///   If non-empty, write log files in this directory.
        /// </summary>
        public virtual string LogDir { get; internal set; }
        /// <summary>
        ///   If non-empty, use this log file.
        /// </summary>
        public virtual string LogFile { get; internal set; }
        /// <summary>
        ///   Defines the maximum size a log file can grow to. Unit is megabytes. If the value is 0, the maximum file size is unlimited. (default 1800).
        /// </summary>
        public virtual uint? LogFileMaxSize { get; internal set; }
        /// <summary>
        ///   Log to standard error instead of files (default true).
        /// </summary>
        public virtual bool? Logtostderr { get; internal set; }
        /// <summary>
        ///   Namespace scope for this request.
        /// </summary>
        public virtual string Namespace { get; internal set; }
        /// <summary>
        ///   Path to the registry config file (default "~/.config/helm/registry.json").
        /// </summary>
        public virtual string RegistryConfig { get; internal set; }
        /// <summary>
        ///   Path to the file containing cached repository indexes (default "~/snap/code/common/.cache/helm/repository").
        /// </summary>
        public virtual string RepositoryCache { get; internal set; }
        /// <summary>
        ///   Path to the file containing repository names and URLs (default "~/.config/helm/repositories.yaml").
        /// </summary>
        public virtual string RepositoryConfig { get; internal set; }
        /// <summary>
        ///   If true, avoid header prefixes in the log messages.
        /// </summary>
        public virtual bool? SkipHeaders { get; internal set; }
        /// <summary>
        ///   If true, avoid headers when opening log files.
        /// </summary>
        public virtual bool? SkipLogHeaders { get; internal set; }
        /// <summary>
        ///   Logs at or above this threshold go to stderr (default 2).
        /// </summary>
        public virtual int? Stderrthreshold { get; internal set; }
        /// <summary>
        ///   Number for the log level verbosity.
        /// </summary>
        public virtual int? V { get; internal set; }
        /// <summary>
        ///   Comma-separated list of pattern=N settings for file-filtered logging.
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Vmodule => VmoduleInternal.AsReadOnly();
        internal Dictionary<string, object> VmoduleInternal { get; set; } = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("--add-dir-header", AddDirHeader)
              .Add("--alsologtostderr", Alsologtostderr)
              .Add("--debug", Debug)
              .Add("--help", Help)
              .Add("--kube-apiserver {value}", KubeApiserver)
              .Add("--kube-context {value}", KubeContext)
              .Add("--kube-token {value}", KubeToken)
              .Add("--kubeconfig {value}", Kubeconfig)
              .Add("--log-backtrace-at {value}", LogBacktraceAt)
              .Add("--log-dir {value}", LogDir)
              .Add("--log-file {value}", LogFile)
              .Add("--log-file-max-size {value}", LogFileMaxSize)
              .Add("--logtostderr", Logtostderr)
              .Add("--namespace {value}", Namespace)
              .Add("--registry-config {value}", RegistryConfig)
              .Add("--repository-cache {value}", RepositoryCache)
              .Add("--repository-config {value}", RepositoryConfig)
              .Add("--skip-headers", SkipHeaders)
              .Add("--skip-log-headers", SkipLogHeaders)
              .Add("--stderrthreshold {value}", Stderrthreshold)
              .Add("--v {value}", V)
              .Add("--vmodule {value}", Vmodule, "{key}={value}", separator: ',');
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region HelmCompletionBashSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmCompletionBashSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCompletionBashSettings.Help"/></em></p>
        ///   <p>Help for bash.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmCompletionBashSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCompletionBashSettings.Help"/></em></p>
        ///   <p>Help for bash.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmCompletionBashSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmCompletionBashSettings.Help"/></em></p>
        ///   <p>Help for bash.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmCompletionBashSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmCompletionBashSettings.Help"/></em></p>
        ///   <p>Help for bash.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmCompletionBashSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmCompletionBashSettings.Help"/></em></p>
        ///   <p>Help for bash.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmCompletionBashSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmCompletionZshSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmCompletionZshSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCompletionZshSettings.Help"/></em></p>
        ///   <p>Help for zsh.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmCompletionZshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCompletionZshSettings.Help"/></em></p>
        ///   <p>Help for zsh.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmCompletionZshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmCompletionZshSettings.Help"/></em></p>
        ///   <p>Help for zsh.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmCompletionZshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmCompletionZshSettings.Help"/></em></p>
        ///   <p>Help for zsh.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmCompletionZshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmCompletionZshSettings.Help"/></em></p>
        ///   <p>Help for zsh.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmCompletionZshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmCreateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmCreateSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCreateSettings.Help"/></em></p>
        ///   <p>Help for create.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCreateSettings.Help"/></em></p>
        ///   <p>Help for create.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmCreateSettings.Help"/></em></p>
        ///   <p>Help for create.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmCreateSettings.Help"/></em></p>
        ///   <p>Help for create.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmCreateSettings.Help"/></em></p>
        ///   <p>Help for create.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Starter
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCreateSettings.Starter"/></em></p>
        ///   <p>The name or absolute path to Helm starter scaffold.</p>
        /// </summary>
        [Pure]
        public static T SetStarter<T>(this T toolSettings, string starter) where T : HelmCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Starter = starter;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCreateSettings.Starter"/></em></p>
        ///   <p>The name or absolute path to Helm starter scaffold.</p>
        /// </summary>
        [Pure]
        public static T ResetStarter<T>(this T toolSettings) where T : HelmCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Starter = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCreateSettings.Name"/></em></p>
        ///   <p>The name of chart directory to create.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : HelmCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCreateSettings.Name"/></em></p>
        ///   <p>The name of chart directory to create.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : HelmCreateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmDependencyBuildSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmDependencyBuildSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmDependencyBuildSettings.Help"/></em></p>
        ///   <p>Help for build.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmDependencyBuildSettings.Help"/></em></p>
        ///   <p>Help for build.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmDependencyBuildSettings.Help"/></em></p>
        ///   <p>Help for build.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmDependencyBuildSettings.Help"/></em></p>
        ///   <p>Help for build.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmDependencyBuildSettings.Help"/></em></p>
        ///   <p>Help for build.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Keyring
        /// <summary>
        ///   <p><em>Sets <see cref="HelmDependencyBuildSettings.Keyring"/></em></p>
        ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = keyring;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmDependencyBuildSettings.Keyring"/></em></p>
        ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T ResetKeyring<T>(this T toolSettings) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = null;
            return toolSettings;
        }
        #endregion
        #region Verify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmDependencyBuildSettings.Verify"/></em></p>
        ///   <p>Verify the packages against signatures.</p>
        /// </summary>
        [Pure]
        public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = verify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmDependencyBuildSettings.Verify"/></em></p>
        ///   <p>Verify the packages against signatures.</p>
        /// </summary>
        [Pure]
        public static T ResetVerify<T>(this T toolSettings) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmDependencyBuildSettings.Verify"/></em></p>
        ///   <p>Verify the packages against signatures.</p>
        /// </summary>
        [Pure]
        public static T EnableVerify<T>(this T toolSettings) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmDependencyBuildSettings.Verify"/></em></p>
        ///   <p>Verify the packages against signatures.</p>
        /// </summary>
        [Pure]
        public static T DisableVerify<T>(this T toolSettings) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmDependencyBuildSettings.Verify"/></em></p>
        ///   <p>Verify the packages against signatures.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerify<T>(this T toolSettings) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = !toolSettings.Verify;
            return toolSettings;
        }
        #endregion
        #region Chart
        /// <summary>
        ///   <p><em>Sets <see cref="HelmDependencyBuildSettings.Chart"/></em></p>
        ///   <p>The name of the chart to build.</p>
        /// </summary>
        [Pure]
        public static T SetChart<T>(this T toolSettings, string chart) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = chart;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmDependencyBuildSettings.Chart"/></em></p>
        ///   <p>The name of the chart to build.</p>
        /// </summary>
        [Pure]
        public static T ResetChart<T>(this T toolSettings) where T : HelmDependencyBuildSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmDependencyListSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmDependencyListSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmDependencyListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmDependencyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmDependencyListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmDependencyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmDependencyListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmDependencyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmDependencyListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmDependencyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmDependencyListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmDependencyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Chart
        /// <summary>
        ///   <p><em>Sets <see cref="HelmDependencyListSettings.Chart"/></em></p>
        ///   <p>The name of the chart to list.</p>
        /// </summary>
        [Pure]
        public static T SetChart<T>(this T toolSettings, string chart) where T : HelmDependencyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = chart;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmDependencyListSettings.Chart"/></em></p>
        ///   <p>The name of the chart to list.</p>
        /// </summary>
        [Pure]
        public static T ResetChart<T>(this T toolSettings) where T : HelmDependencyListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmDependencyUpdateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmDependencyUpdateSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmDependencyUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmDependencyUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmDependencyUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmDependencyUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmDependencyUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Keyring
        /// <summary>
        ///   <p><em>Sets <see cref="HelmDependencyUpdateSettings.Keyring"/></em></p>
        ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = keyring;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmDependencyUpdateSettings.Keyring"/></em></p>
        ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T ResetKeyring<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = null;
            return toolSettings;
        }
        #endregion
        #region SkipRefresh
        /// <summary>
        ///   <p><em>Sets <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></em></p>
        ///   <p>Do not refresh the local repository cache.</p>
        /// </summary>
        [Pure]
        public static T SetSkipRefresh<T>(this T toolSettings, bool? skipRefresh) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipRefresh = skipRefresh;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></em></p>
        ///   <p>Do not refresh the local repository cache.</p>
        /// </summary>
        [Pure]
        public static T ResetSkipRefresh<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipRefresh = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></em></p>
        ///   <p>Do not refresh the local repository cache.</p>
        /// </summary>
        [Pure]
        public static T EnableSkipRefresh<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipRefresh = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></em></p>
        ///   <p>Do not refresh the local repository cache.</p>
        /// </summary>
        [Pure]
        public static T DisableSkipRefresh<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipRefresh = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></em></p>
        ///   <p>Do not refresh the local repository cache.</p>
        /// </summary>
        [Pure]
        public static T ToggleSkipRefresh<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipRefresh = !toolSettings.SkipRefresh;
            return toolSettings;
        }
        #endregion
        #region Verify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmDependencyUpdateSettings.Verify"/></em></p>
        ///   <p>Verify the packages against signatures.</p>
        /// </summary>
        [Pure]
        public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = verify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmDependencyUpdateSettings.Verify"/></em></p>
        ///   <p>Verify the packages against signatures.</p>
        /// </summary>
        [Pure]
        public static T ResetVerify<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmDependencyUpdateSettings.Verify"/></em></p>
        ///   <p>Verify the packages against signatures.</p>
        /// </summary>
        [Pure]
        public static T EnableVerify<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmDependencyUpdateSettings.Verify"/></em></p>
        ///   <p>Verify the packages against signatures.</p>
        /// </summary>
        [Pure]
        public static T DisableVerify<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmDependencyUpdateSettings.Verify"/></em></p>
        ///   <p>Verify the packages against signatures.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerify<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = !toolSettings.Verify;
            return toolSettings;
        }
        #endregion
        #region Chart
        /// <summary>
        ///   <p><em>Sets <see cref="HelmDependencyUpdateSettings.Chart"/></em></p>
        ///   <p>The name of the chart to update.</p>
        /// </summary>
        [Pure]
        public static T SetChart<T>(this T toolSettings, string chart) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = chart;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmDependencyUpdateSettings.Chart"/></em></p>
        ///   <p>The name of the chart to update.</p>
        /// </summary>
        [Pure]
        public static T ResetChart<T>(this T toolSettings) where T : HelmDependencyUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmEnvSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmEnvSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmEnvSettings.Help"/></em></p>
        ///   <p>Help for env.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmEnvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmEnvSettings.Help"/></em></p>
        ///   <p>Help for env.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmEnvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmEnvSettings.Help"/></em></p>
        ///   <p>Help for env.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmEnvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmEnvSettings.Help"/></em></p>
        ///   <p>Help for env.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmEnvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmEnvSettings.Help"/></em></p>
        ///   <p>Help for env.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmEnvSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmGetAllSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmGetAllSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetAllSettings.Help"/></em></p>
        ///   <p>Help for all.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmGetAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetAllSettings.Help"/></em></p>
        ///   <p>Help for all.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmGetAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmGetAllSettings.Help"/></em></p>
        ///   <p>Help for all.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmGetAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmGetAllSettings.Help"/></em></p>
        ///   <p>Help for all.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmGetAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmGetAllSettings.Help"/></em></p>
        ///   <p>Help for all.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmGetAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Revision
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetAllSettings.Revision"/></em></p>
        ///   <p>Get the named release with revision.</p>
        /// </summary>
        [Pure]
        public static T SetRevision<T>(this T toolSettings, long? revision) where T : HelmGetAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = revision;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetAllSettings.Revision"/></em></p>
        ///   <p>Get the named release with revision.</p>
        /// </summary>
        [Pure]
        public static T ResetRevision<T>(this T toolSettings) where T : HelmGetAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = null;
            return toolSettings;
        }
        #endregion
        #region Template
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetAllSettings.Template"/></em></p>
        ///   <p>Go template for formatting the output, eg: {{.Release.Name}}.</p>
        /// </summary>
        [Pure]
        public static T SetTemplate<T>(this T toolSettings, string template) where T : HelmGetAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Template = template;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetAllSettings.Template"/></em></p>
        ///   <p>Go template for formatting the output, eg: {{.Release.Name}}.</p>
        /// </summary>
        [Pure]
        public static T ResetTemplate<T>(this T toolSettings) where T : HelmGetAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Template = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseName
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetAllSettings.ReleaseName"/></em></p>
        /// </summary>
        [Pure]
        public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmGetAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = releaseName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetAllSettings.ReleaseName"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetReleaseName<T>(this T toolSettings) where T : HelmGetAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmGetHooksSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmGetHooksSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetHooksSettings.Help"/></em></p>
        ///   <p>Help for hooks.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmGetHooksSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetHooksSettings.Help"/></em></p>
        ///   <p>Help for hooks.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmGetHooksSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmGetHooksSettings.Help"/></em></p>
        ///   <p>Help for hooks.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmGetHooksSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmGetHooksSettings.Help"/></em></p>
        ///   <p>Help for hooks.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmGetHooksSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmGetHooksSettings.Help"/></em></p>
        ///   <p>Help for hooks.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmGetHooksSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Revision
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetHooksSettings.Revision"/></em></p>
        ///   <p>Get the named release with revision.</p>
        /// </summary>
        [Pure]
        public static T SetRevision<T>(this T toolSettings, long? revision) where T : HelmGetHooksSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = revision;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetHooksSettings.Revision"/></em></p>
        ///   <p>Get the named release with revision.</p>
        /// </summary>
        [Pure]
        public static T ResetRevision<T>(this T toolSettings) where T : HelmGetHooksSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseName
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetHooksSettings.ReleaseName"/></em></p>
        ///   <p>The name of the release to get the hooks for.</p>
        /// </summary>
        [Pure]
        public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmGetHooksSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = releaseName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetHooksSettings.ReleaseName"/></em></p>
        ///   <p>The name of the release to get the hooks for.</p>
        /// </summary>
        [Pure]
        public static T ResetReleaseName<T>(this T toolSettings) where T : HelmGetHooksSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmGetManifestSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmGetManifestSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetManifestSettings.Help"/></em></p>
        ///   <p>Help for manifest.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmGetManifestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetManifestSettings.Help"/></em></p>
        ///   <p>Help for manifest.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmGetManifestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmGetManifestSettings.Help"/></em></p>
        ///   <p>Help for manifest.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmGetManifestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmGetManifestSettings.Help"/></em></p>
        ///   <p>Help for manifest.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmGetManifestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmGetManifestSettings.Help"/></em></p>
        ///   <p>Help for manifest.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmGetManifestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Revision
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetManifestSettings.Revision"/></em></p>
        ///   <p>Get the named release with revision.</p>
        /// </summary>
        [Pure]
        public static T SetRevision<T>(this T toolSettings, long? revision) where T : HelmGetManifestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = revision;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetManifestSettings.Revision"/></em></p>
        ///   <p>Get the named release with revision.</p>
        /// </summary>
        [Pure]
        public static T ResetRevision<T>(this T toolSettings) where T : HelmGetManifestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseName
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetManifestSettings.ReleaseName"/></em></p>
        ///   <p>The name of the release to get the manifest for.</p>
        /// </summary>
        [Pure]
        public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmGetManifestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = releaseName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetManifestSettings.ReleaseName"/></em></p>
        ///   <p>The name of the release to get the manifest for.</p>
        /// </summary>
        [Pure]
        public static T ResetReleaseName<T>(this T toolSettings) where T : HelmGetManifestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmGetNotesSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmGetNotesSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetNotesSettings.Help"/></em></p>
        ///   <p>Help for notes.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmGetNotesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetNotesSettings.Help"/></em></p>
        ///   <p>Help for notes.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmGetNotesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmGetNotesSettings.Help"/></em></p>
        ///   <p>Help for notes.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmGetNotesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmGetNotesSettings.Help"/></em></p>
        ///   <p>Help for notes.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmGetNotesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmGetNotesSettings.Help"/></em></p>
        ///   <p>Help for notes.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmGetNotesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Revision
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetNotesSettings.Revision"/></em></p>
        ///   <p>Get the named release with revision.</p>
        /// </summary>
        [Pure]
        public static T SetRevision<T>(this T toolSettings, long? revision) where T : HelmGetNotesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = revision;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetNotesSettings.Revision"/></em></p>
        ///   <p>Get the named release with revision.</p>
        /// </summary>
        [Pure]
        public static T ResetRevision<T>(this T toolSettings) where T : HelmGetNotesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseName
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetNotesSettings.ReleaseName"/></em></p>
        /// </summary>
        [Pure]
        public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmGetNotesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = releaseName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetNotesSettings.ReleaseName"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetReleaseName<T>(this T toolSettings) where T : HelmGetNotesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmGetValuesSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmGetValuesSettingsExtensions
    {
        #region All
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetValuesSettings.All"/></em></p>
        ///   <p>Dump all (computed) values.</p>
        /// </summary>
        [Pure]
        public static T SetAll<T>(this T toolSettings, bool? all) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = all;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetValuesSettings.All"/></em></p>
        ///   <p>Dump all (computed) values.</p>
        /// </summary>
        [Pure]
        public static T ResetAll<T>(this T toolSettings) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmGetValuesSettings.All"/></em></p>
        ///   <p>Dump all (computed) values.</p>
        /// </summary>
        [Pure]
        public static T EnableAll<T>(this T toolSettings) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmGetValuesSettings.All"/></em></p>
        ///   <p>Dump all (computed) values.</p>
        /// </summary>
        [Pure]
        public static T DisableAll<T>(this T toolSettings) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmGetValuesSettings.All"/></em></p>
        ///   <p>Dump all (computed) values.</p>
        /// </summary>
        [Pure]
        public static T ToggleAll<T>(this T toolSettings) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = !toolSettings.All;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetValuesSettings.Help"/></em></p>
        ///   <p>Help for values.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetValuesSettings.Help"/></em></p>
        ///   <p>Help for values.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmGetValuesSettings.Help"/></em></p>
        ///   <p>Help for values.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmGetValuesSettings.Help"/></em></p>
        ///   <p>Help for values.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmGetValuesSettings.Help"/></em></p>
        ///   <p>Help for values.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetValuesSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, HelmOutputFormat output) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetValuesSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Revision
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetValuesSettings.Revision"/></em></p>
        ///   <p>Get the named release with revision.</p>
        /// </summary>
        [Pure]
        public static T SetRevision<T>(this T toolSettings, long? revision) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = revision;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetValuesSettings.Revision"/></em></p>
        ///   <p>Get the named release with revision.</p>
        /// </summary>
        [Pure]
        public static T ResetRevision<T>(this T toolSettings) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseName
        /// <summary>
        ///   <p><em>Sets <see cref="HelmGetValuesSettings.ReleaseName"/></em></p>
        ///   <p>The name of the release to get the values for.</p>
        /// </summary>
        [Pure]
        public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = releaseName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmGetValuesSettings.ReleaseName"/></em></p>
        ///   <p>The name of the release to get the values for.</p>
        /// </summary>
        [Pure]
        public static T ResetReleaseName<T>(this T toolSettings) where T : HelmGetValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmHistorySettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmHistorySettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmHistorySettings.Help"/></em></p>
        ///   <p>Help for history.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmHistorySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmHistorySettings.Help"/></em></p>
        ///   <p>Help for history.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmHistorySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmHistorySettings.Help"/></em></p>
        ///   <p>Help for history.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmHistorySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmHistorySettings.Help"/></em></p>
        ///   <p>Help for history.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmHistorySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmHistorySettings.Help"/></em></p>
        ///   <p>Help for history.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmHistorySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Max
        /// <summary>
        ///   <p><em>Sets <see cref="HelmHistorySettings.Max"/></em></p>
        ///   <p>Maximum number of revision to include in history (default 256).</p>
        /// </summary>
        [Pure]
        public static T SetMax<T>(this T toolSettings, long? max) where T : HelmHistorySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Max = max;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmHistorySettings.Max"/></em></p>
        ///   <p>Maximum number of revision to include in history (default 256).</p>
        /// </summary>
        [Pure]
        public static T ResetMax<T>(this T toolSettings) where T : HelmHistorySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Max = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="HelmHistorySettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, HelmOutputFormat output) where T : HelmHistorySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmHistorySettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : HelmHistorySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseName
        /// <summary>
        ///   <p><em>Sets <see cref="HelmHistorySettings.ReleaseName"/></em></p>
        ///   <p>The name of the release to get the history for.</p>
        /// </summary>
        [Pure]
        public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmHistorySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = releaseName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmHistorySettings.ReleaseName"/></em></p>
        ///   <p>The name of the release to get the history for.</p>
        /// </summary>
        [Pure]
        public static T ResetReleaseName<T>(this T toolSettings) where T : HelmHistorySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmInstallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmInstallSettingsExtensions
    {
        #region Atomic
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Atomic"/></em></p>
        ///   <p>If set, the installation process deletes the installation on failure. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T SetAtomic<T>(this T toolSettings, bool? atomic) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = atomic;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Atomic"/></em></p>
        ///   <p>If set, the installation process deletes the installation on failure. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T ResetAtomic<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.Atomic"/></em></p>
        ///   <p>If set, the installation process deletes the installation on failure. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T EnableAtomic<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.Atomic"/></em></p>
        ///   <p>If set, the installation process deletes the installation on failure. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T DisableAtomic<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.Atomic"/></em></p>
        ///   <p>If set, the installation process deletes the installation on failure. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T ToggleAtomic<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = !toolSettings.Atomic;
            return toolSettings;
        }
        #endregion
        #region CaFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = caFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T ResetCaFile<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = null;
            return toolSettings;
        }
        #endregion
        #region CertFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = certFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T ResetCertFile<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = null;
            return toolSettings;
        }
        #endregion
        #region CreateNamespace
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.CreateNamespace"/></em></p>
        ///   <p>Create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T SetCreateNamespace<T>(this T toolSettings, bool? createNamespace) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = createNamespace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.CreateNamespace"/></em></p>
        ///   <p>Create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T ResetCreateNamespace<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.CreateNamespace"/></em></p>
        ///   <p>Create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T EnableCreateNamespace<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.CreateNamespace"/></em></p>
        ///   <p>Create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T DisableCreateNamespace<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.CreateNamespace"/></em></p>
        ///   <p>Create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T ToggleCreateNamespace<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = !toolSettings.CreateNamespace;
            return toolSettings;
        }
        #endregion
        #region DependencyUpdate
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.DependencyUpdate"/></em></p>
        ///   <p>Run helm dependency update before installing the chart.</p>
        /// </summary>
        [Pure]
        public static T SetDependencyUpdate<T>(this T toolSettings, bool? dependencyUpdate) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = dependencyUpdate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.DependencyUpdate"/></em></p>
        ///   <p>Run helm dependency update before installing the chart.</p>
        /// </summary>
        [Pure]
        public static T ResetDependencyUpdate<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.DependencyUpdate"/></em></p>
        ///   <p>Run helm dependency update before installing the chart.</p>
        /// </summary>
        [Pure]
        public static T EnableDependencyUpdate<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.DependencyUpdate"/></em></p>
        ///   <p>Run helm dependency update before installing the chart.</p>
        /// </summary>
        [Pure]
        public static T DisableDependencyUpdate<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.DependencyUpdate"/></em></p>
        ///   <p>Run helm dependency update before installing the chart.</p>
        /// </summary>
        [Pure]
        public static T ToggleDependencyUpdate<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = !toolSettings.DependencyUpdate;
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Description"/></em></p>
        ///   <p>Add a custom description.</p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Description"/></em></p>
        ///   <p>Add a custom description.</p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region Devel
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = devel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ResetDevel<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T EnableDevel<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T DisableDevel<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ToggleDevel<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = !toolSettings.Devel;
            return toolSettings;
        }
        #endregion
        #region DisableOpenapiValidation
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the installation process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T SetDisableOpenapiValidation<T>(this T toolSettings, bool? disableOpenapiValidation) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = disableOpenapiValidation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the installation process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableOpenapiValidation<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the installation process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableOpenapiValidation<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the installation process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableOpenapiValidation<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the installation process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableOpenapiValidation<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = !toolSettings.DisableOpenapiValidation;
            return toolSettings;
        }
        #endregion
        #region DryRun
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.DryRun"/></em></p>
        ///   <p>Simulate an install.</p>
        /// </summary>
        [Pure]
        public static T SetDryRun<T>(this T toolSettings, bool? dryRun) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = dryRun;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.DryRun"/></em></p>
        ///   <p>Simulate an install.</p>
        /// </summary>
        [Pure]
        public static T ResetDryRun<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.DryRun"/></em></p>
        ///   <p>Simulate an install.</p>
        /// </summary>
        [Pure]
        public static T EnableDryRun<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.DryRun"/></em></p>
        ///   <p>Simulate an install.</p>
        /// </summary>
        [Pure]
        public static T DisableDryRun<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.DryRun"/></em></p>
        ///   <p>Simulate an install.</p>
        /// </summary>
        [Pure]
        public static T ToggleDryRun<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = !toolSettings.DryRun;
            return toolSettings;
        }
        #endregion
        #region GenerateName
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.GenerateName"/></em></p>
        ///   <p>Generate the name (and omit the NAME parameter).</p>
        /// </summary>
        [Pure]
        public static T SetGenerateName<T>(this T toolSettings, bool? generateName) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateName = generateName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.GenerateName"/></em></p>
        ///   <p>Generate the name (and omit the NAME parameter).</p>
        /// </summary>
        [Pure]
        public static T ResetGenerateName<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateName = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.GenerateName"/></em></p>
        ///   <p>Generate the name (and omit the NAME parameter).</p>
        /// </summary>
        [Pure]
        public static T EnableGenerateName<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateName = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.GenerateName"/></em></p>
        ///   <p>Generate the name (and omit the NAME parameter).</p>
        /// </summary>
        [Pure]
        public static T DisableGenerateName<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateName = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.GenerateName"/></em></p>
        ///   <p>Generate the name (and omit the NAME parameter).</p>
        /// </summary>
        [Pure]
        public static T ToggleGenerateName<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateName = !toolSettings.GenerateName;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Help"/></em></p>
        ///   <p>Help for install.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Help"/></em></p>
        ///   <p>Help for install.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.Help"/></em></p>
        ///   <p>Help for install.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.Help"/></em></p>
        ///   <p>Help for install.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.Help"/></em></p>
        ///   <p>Help for install.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region InsecureSkipTlsVerify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T SetInsecureSkipTlsVerify<T>(this T toolSettings, bool? insecureSkipTlsVerify) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = insecureSkipTlsVerify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ResetInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T EnableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T DisableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ToggleInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = !toolSettings.InsecureSkipTlsVerify;
            return toolSettings;
        }
        #endregion
        #region KeyFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = keyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyFile<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = null;
            return toolSettings;
        }
        #endregion
        #region Keyring
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = keyring;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T ResetKeyring<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = null;
            return toolSettings;
        }
        #endregion
        #region NameTemplate
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.NameTemplate"/></em></p>
        ///   <p>Specify template used to name the release.</p>
        /// </summary>
        [Pure]
        public static T SetNameTemplate<T>(this T toolSettings, string nameTemplate) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NameTemplate = nameTemplate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.NameTemplate"/></em></p>
        ///   <p>Specify template used to name the release.</p>
        /// </summary>
        [Pure]
        public static T ResetNameTemplate<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NameTemplate = null;
            return toolSettings;
        }
        #endregion
        #region NoHooks
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during install.</p>
        /// </summary>
        [Pure]
        public static T SetNoHooks<T>(this T toolSettings, bool? noHooks) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = noHooks;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during install.</p>
        /// </summary>
        [Pure]
        public static T ResetNoHooks<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during install.</p>
        /// </summary>
        [Pure]
        public static T EnableNoHooks<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during install.</p>
        /// </summary>
        [Pure]
        public static T DisableNoHooks<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during install.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoHooks<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = !toolSettings.NoHooks;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, HelmOutputFormat output) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, string password) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region PostRenderer
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.PostRenderer"/></em></p>
        ///   <p>The path to an executable to be used for post rendering. If it exists in $PATH, the binary will be used, otherwise it will try to look for the executable at the given path (default exec).</p>
        /// </summary>
        [Pure]
        public static T SetPostRenderer<T>(this T toolSettings, string postRenderer) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostRenderer = postRenderer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.PostRenderer"/></em></p>
        ///   <p>The path to an executable to be used for post rendering. If it exists in $PATH, the binary will be used, otherwise it will try to look for the executable at the given path (default exec).</p>
        /// </summary>
        [Pure]
        public static T ResetPostRenderer<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostRenderer = null;
            return toolSettings;
        }
        #endregion
        #region RenderSubchartNotes
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T SetRenderSubchartNotes<T>(this T toolSettings, bool? renderSubchartNotes) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = renderSubchartNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T ResetRenderSubchartNotes<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T EnableRenderSubchartNotes<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T DisableRenderSubchartNotes<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T ToggleRenderSubchartNotes<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = !toolSettings.RenderSubchartNotes;
            return toolSettings;
        }
        #endregion
        #region Replace
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Replace"/></em></p>
        ///   <p>Re-use the given name, only if that name is a deleted release which remains in the history. This is unsafe in production.</p>
        /// </summary>
        [Pure]
        public static T SetReplace<T>(this T toolSettings, bool? replace) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Replace = replace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Replace"/></em></p>
        ///   <p>Re-use the given name, only if that name is a deleted release which remains in the history. This is unsafe in production.</p>
        /// </summary>
        [Pure]
        public static T ResetReplace<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Replace = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.Replace"/></em></p>
        ///   <p>Re-use the given name, only if that name is a deleted release which remains in the history. This is unsafe in production.</p>
        /// </summary>
        [Pure]
        public static T EnableReplace<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Replace = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.Replace"/></em></p>
        ///   <p>Re-use the given name, only if that name is a deleted release which remains in the history. This is unsafe in production.</p>
        /// </summary>
        [Pure]
        public static T DisableReplace<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Replace = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.Replace"/></em></p>
        ///   <p>Re-use the given name, only if that name is a deleted release which remains in the history. This is unsafe in production.</p>
        /// </summary>
        [Pure]
        public static T ToggleReplace<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Replace = !toolSettings.Replace;
            return toolSettings;
        }
        #endregion
        #region Repo
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = repo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetRepo<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = null;
            return toolSettings;
        }
        #endregion
        #region Set
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Set"/> to a new dictionary</em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSet<T>(this T toolSettings, IDictionary<string, object> set) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal = set.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmInstallSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T ClearSet<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmInstallSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T AddSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal.Add(setKey, setValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmInstallSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T RemoveSet<T>(this T toolSettings, string setKey) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal.Remove(setKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmInstallSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal[setKey] = setValue;
            return toolSettings;
        }
        #endregion
        #region SetFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.SetFile"/> to a new dictionary</em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T SetSetFile<T>(this T toolSettings, IDictionary<string, object> setFile) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal = setFile.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmInstallSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T ClearSetFile<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmInstallSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T AddSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal.Add(setFileKey, setFileValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmInstallSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T RemoveSetFile<T>(this T toolSettings, string setFileKey) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal.Remove(setFileKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmInstallSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T SetSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal[setFileKey] = setFileValue;
            return toolSettings;
        }
        #endregion
        #region SetString
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.SetString"/> to a new dictionary</em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSetString<T>(this T toolSettings, IDictionary<string, object> setString) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal = setString.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmInstallSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T ClearSetString<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmInstallSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T AddSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal.Add(setStringKey, setStringValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmInstallSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T RemoveSetString<T>(this T toolSettings, string setStringKey) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal.Remove(setStringKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmInstallSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal[setStringKey] = setStringValue;
            return toolSettings;
        }
        #endregion
        #region SkipCrds
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed. By default, CRDs are installed if not already present.</p>
        /// </summary>
        [Pure]
        public static T SetSkipCrds<T>(this T toolSettings, bool? skipCrds) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = skipCrds;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed. By default, CRDs are installed if not already present.</p>
        /// </summary>
        [Pure]
        public static T ResetSkipCrds<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed. By default, CRDs are installed if not already present.</p>
        /// </summary>
        [Pure]
        public static T EnableSkipCrds<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed. By default, CRDs are installed if not already present.</p>
        /// </summary>
        [Pure]
        public static T DisableSkipCrds<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed. By default, CRDs are installed if not already present.</p>
        /// </summary>
        [Pure]
        public static T ToggleSkipCrds<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = !toolSettings.SkipCrds;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Timeout"/></em></p>
        ///   <p>Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, string timeout) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Timeout"/></em></p>
        ///   <p>Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Values
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Values"/> to a new list</em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T SetValues<T>(this T toolSettings, params string[] values) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal = values.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Values"/> to a new list</em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T SetValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal = values.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmInstallSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T AddValues<T>(this T toolSettings, params string[] values) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal.AddRange(values);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmInstallSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T AddValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal.AddRange(values);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmInstallSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T ClearValues<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmInstallSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T RemoveValues<T>(this T toolSettings, params string[] values) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(values);
            toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmInstallSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T RemoveValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(values);
            toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = verify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ResetVerify<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T EnableVerify<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T DisableVerify<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerify<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = !toolSettings.Verify;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Wait
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T SetWait<T>(this T toolSettings, bool? wait) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = wait;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T ResetWait<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmInstallSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T EnableWait<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmInstallSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T DisableWait<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmInstallSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T ToggleWait<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = !toolSettings.Wait;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Name"/></em></p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Name"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Chart
        /// <summary>
        ///   <p><em>Sets <see cref="HelmInstallSettings.Chart"/></em></p>
        ///   <p>The name of the chart to install.</p>
        /// </summary>
        [Pure]
        public static T SetChart<T>(this T toolSettings, string chart) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = chart;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmInstallSettings.Chart"/></em></p>
        ///   <p>The name of the chart to install.</p>
        /// </summary>
        [Pure]
        public static T ResetChart<T>(this T toolSettings) where T : HelmInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmLintSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmLintSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmLintSettings.Help"/></em></p>
        ///   <p>Help for lint.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmLintSettings.Help"/></em></p>
        ///   <p>Help for lint.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmLintSettings.Help"/></em></p>
        ///   <p>Help for lint.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmLintSettings.Help"/></em></p>
        ///   <p>Help for lint.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmLintSettings.Help"/></em></p>
        ///   <p>Help for lint.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Set
        /// <summary>
        ///   <p><em>Sets <see cref="HelmLintSettings.Set"/> to a new dictionary</em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSet<T>(this T toolSettings, IDictionary<string, object> set) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal = set.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmLintSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T ClearSet<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmLintSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T AddSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal.Add(setKey, setValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmLintSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T RemoveSet<T>(this T toolSettings, string setKey) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal.Remove(setKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmLintSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal[setKey] = setValue;
            return toolSettings;
        }
        #endregion
        #region SetFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmLintSettings.SetFile"/> to a new dictionary</em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T SetSetFile<T>(this T toolSettings, IDictionary<string, object> setFile) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal = setFile.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmLintSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T ClearSetFile<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmLintSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T AddSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal.Add(setFileKey, setFileValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmLintSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T RemoveSetFile<T>(this T toolSettings, string setFileKey) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal.Remove(setFileKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmLintSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T SetSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal[setFileKey] = setFileValue;
            return toolSettings;
        }
        #endregion
        #region SetString
        /// <summary>
        ///   <p><em>Sets <see cref="HelmLintSettings.SetString"/> to a new dictionary</em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSetString<T>(this T toolSettings, IDictionary<string, object> setString) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal = setString.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmLintSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T ClearSetString<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmLintSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T AddSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal.Add(setStringKey, setStringValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmLintSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T RemoveSetString<T>(this T toolSettings, string setStringKey) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal.Remove(setStringKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmLintSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal[setStringKey] = setStringValue;
            return toolSettings;
        }
        #endregion
        #region Strict
        /// <summary>
        ///   <p><em>Sets <see cref="HelmLintSettings.Strict"/></em></p>
        ///   <p>Fail on lint warnings.</p>
        /// </summary>
        [Pure]
        public static T SetStrict<T>(this T toolSettings, bool? strict) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Strict = strict;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmLintSettings.Strict"/></em></p>
        ///   <p>Fail on lint warnings.</p>
        /// </summary>
        [Pure]
        public static T ResetStrict<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Strict = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmLintSettings.Strict"/></em></p>
        ///   <p>Fail on lint warnings.</p>
        /// </summary>
        [Pure]
        public static T EnableStrict<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Strict = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmLintSettings.Strict"/></em></p>
        ///   <p>Fail on lint warnings.</p>
        /// </summary>
        [Pure]
        public static T DisableStrict<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Strict = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmLintSettings.Strict"/></em></p>
        ///   <p>Fail on lint warnings.</p>
        /// </summary>
        [Pure]
        public static T ToggleStrict<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Strict = !toolSettings.Strict;
            return toolSettings;
        }
        #endregion
        #region Values
        /// <summary>
        ///   <p><em>Sets <see cref="HelmLintSettings.Values"/> to a new list</em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T SetValues<T>(this T toolSettings, params string[] values) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal = values.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="HelmLintSettings.Values"/> to a new list</em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T SetValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal = values.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmLintSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T AddValues<T>(this T toolSettings, params string[] values) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal.AddRange(values);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmLintSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T AddValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal.AddRange(values);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmLintSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T ClearValues<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmLintSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T RemoveValues<T>(this T toolSettings, params string[] values) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(values);
            toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmLintSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T RemoveValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(values);
            toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region WithSubcharts
        /// <summary>
        ///   <p><em>Sets <see cref="HelmLintSettings.WithSubcharts"/></em></p>
        ///   <p>Lint dependent charts.</p>
        /// </summary>
        [Pure]
        public static T SetWithSubcharts<T>(this T toolSettings, bool? withSubcharts) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WithSubcharts = withSubcharts;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmLintSettings.WithSubcharts"/></em></p>
        ///   <p>Lint dependent charts.</p>
        /// </summary>
        [Pure]
        public static T ResetWithSubcharts<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WithSubcharts = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmLintSettings.WithSubcharts"/></em></p>
        ///   <p>Lint dependent charts.</p>
        /// </summary>
        [Pure]
        public static T EnableWithSubcharts<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WithSubcharts = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmLintSettings.WithSubcharts"/></em></p>
        ///   <p>Lint dependent charts.</p>
        /// </summary>
        [Pure]
        public static T DisableWithSubcharts<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WithSubcharts = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmLintSettings.WithSubcharts"/></em></p>
        ///   <p>Lint dependent charts.</p>
        /// </summary>
        [Pure]
        public static T ToggleWithSubcharts<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.WithSubcharts = !toolSettings.WithSubcharts;
            return toolSettings;
        }
        #endregion
        #region Path
        /// <summary>
        ///   <p><em>Sets <see cref="HelmLintSettings.Path"/></em></p>
        ///   <p>The Path to a chart.</p>
        /// </summary>
        [Pure]
        public static T SetPath<T>(this T toolSettings, string path) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = path;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmLintSettings.Path"/></em></p>
        ///   <p>The Path to a chart.</p>
        /// </summary>
        [Pure]
        public static T ResetPath<T>(this T toolSettings) where T : HelmLintSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmListSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmListSettingsExtensions
    {
        #region All
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.All"/></em></p>
        ///   <p>Show all releases without any filter applied.</p>
        /// </summary>
        [Pure]
        public static T SetAll<T>(this T toolSettings, bool? all) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = all;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.All"/></em></p>
        ///   <p>Show all releases without any filter applied.</p>
        /// </summary>
        [Pure]
        public static T ResetAll<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmListSettings.All"/></em></p>
        ///   <p>Show all releases without any filter applied.</p>
        /// </summary>
        [Pure]
        public static T EnableAll<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmListSettings.All"/></em></p>
        ///   <p>Show all releases without any filter applied.</p>
        /// </summary>
        [Pure]
        public static T DisableAll<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmListSettings.All"/></em></p>
        ///   <p>Show all releases without any filter applied.</p>
        /// </summary>
        [Pure]
        public static T ToggleAll<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.All = !toolSettings.All;
            return toolSettings;
        }
        #endregion
        #region AllNamespaces
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.AllNamespaces"/></em></p>
        ///   <p>List releases across all namespaces.</p>
        /// </summary>
        [Pure]
        public static T SetAllNamespaces<T>(this T toolSettings, bool? allNamespaces) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllNamespaces = allNamespaces;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.AllNamespaces"/></em></p>
        ///   <p>List releases across all namespaces.</p>
        /// </summary>
        [Pure]
        public static T ResetAllNamespaces<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllNamespaces = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmListSettings.AllNamespaces"/></em></p>
        ///   <p>List releases across all namespaces.</p>
        /// </summary>
        [Pure]
        public static T EnableAllNamespaces<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllNamespaces = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmListSettings.AllNamespaces"/></em></p>
        ///   <p>List releases across all namespaces.</p>
        /// </summary>
        [Pure]
        public static T DisableAllNamespaces<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllNamespaces = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmListSettings.AllNamespaces"/></em></p>
        ///   <p>List releases across all namespaces.</p>
        /// </summary>
        [Pure]
        public static T ToggleAllNamespaces<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllNamespaces = !toolSettings.AllNamespaces;
            return toolSettings;
        }
        #endregion
        #region Date
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Date"/></em></p>
        ///   <p>Sort by release date.</p>
        /// </summary>
        [Pure]
        public static T SetDate<T>(this T toolSettings, bool? date) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Date = date;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Date"/></em></p>
        ///   <p>Sort by release date.</p>
        /// </summary>
        [Pure]
        public static T ResetDate<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Date = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmListSettings.Date"/></em></p>
        ///   <p>Sort by release date.</p>
        /// </summary>
        [Pure]
        public static T EnableDate<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Date = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmListSettings.Date"/></em></p>
        ///   <p>Sort by release date.</p>
        /// </summary>
        [Pure]
        public static T DisableDate<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Date = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmListSettings.Date"/></em></p>
        ///   <p>Sort by release date.</p>
        /// </summary>
        [Pure]
        public static T ToggleDate<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Date = !toolSettings.Date;
            return toolSettings;
        }
        #endregion
        #region Deployed
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Deployed"/></em></p>
        ///   <p>Show deployed releases. If no other is specified, this will be automatically enabled.</p>
        /// </summary>
        [Pure]
        public static T SetDeployed<T>(this T toolSettings, bool? deployed) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Deployed = deployed;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Deployed"/></em></p>
        ///   <p>Show deployed releases. If no other is specified, this will be automatically enabled.</p>
        /// </summary>
        [Pure]
        public static T ResetDeployed<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Deployed = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmListSettings.Deployed"/></em></p>
        ///   <p>Show deployed releases. If no other is specified, this will be automatically enabled.</p>
        /// </summary>
        [Pure]
        public static T EnableDeployed<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Deployed = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmListSettings.Deployed"/></em></p>
        ///   <p>Show deployed releases. If no other is specified, this will be automatically enabled.</p>
        /// </summary>
        [Pure]
        public static T DisableDeployed<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Deployed = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmListSettings.Deployed"/></em></p>
        ///   <p>Show deployed releases. If no other is specified, this will be automatically enabled.</p>
        /// </summary>
        [Pure]
        public static T ToggleDeployed<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Deployed = !toolSettings.Deployed;
            return toolSettings;
        }
        #endregion
        #region Failed
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Failed"/></em></p>
        ///   <p>Show failed releases.</p>
        /// </summary>
        [Pure]
        public static T SetFailed<T>(this T toolSettings, bool? failed) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Failed = failed;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Failed"/></em></p>
        ///   <p>Show failed releases.</p>
        /// </summary>
        [Pure]
        public static T ResetFailed<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Failed = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmListSettings.Failed"/></em></p>
        ///   <p>Show failed releases.</p>
        /// </summary>
        [Pure]
        public static T EnableFailed<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Failed = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmListSettings.Failed"/></em></p>
        ///   <p>Show failed releases.</p>
        /// </summary>
        [Pure]
        public static T DisableFailed<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Failed = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmListSettings.Failed"/></em></p>
        ///   <p>Show failed releases.</p>
        /// </summary>
        [Pure]
        public static T ToggleFailed<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Failed = !toolSettings.Failed;
            return toolSettings;
        }
        #endregion
        #region Filter
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Filter"/></em></p>
        ///   <p>The filter to use.</p>
        /// </summary>
        [Pure]
        public static T SetFilter<T>(this T toolSettings, string filter) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = filter;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Filter"/></em></p>
        ///   <p>The filter to use.</p>
        /// </summary>
        [Pure]
        public static T ResetFilter<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Filter = null;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Max
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Max"/></em></p>
        ///   <p>Maximum number of releases to fetch (default 256).</p>
        /// </summary>
        [Pure]
        public static T SetMax<T>(this T toolSettings, long? max) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Max = max;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Max"/></em></p>
        ///   <p>Maximum number of releases to fetch (default 256).</p>
        /// </summary>
        [Pure]
        public static T ResetMax<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Max = null;
            return toolSettings;
        }
        #endregion
        #region Offset
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Offset"/></em></p>
        ///   <p>Next release name in the list, used to offset from start value.</p>
        /// </summary>
        [Pure]
        public static T SetOffset<T>(this T toolSettings, long? offset) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Offset = offset;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Offset"/></em></p>
        ///   <p>Next release name in the list, used to offset from start value.</p>
        /// </summary>
        [Pure]
        public static T ResetOffset<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Offset = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, HelmOutputFormat output) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Pending
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Pending"/></em></p>
        ///   <p>Show pending releases.</p>
        /// </summary>
        [Pure]
        public static T SetPending<T>(this T toolSettings, bool? pending) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pending = pending;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Pending"/></em></p>
        ///   <p>Show pending releases.</p>
        /// </summary>
        [Pure]
        public static T ResetPending<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pending = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmListSettings.Pending"/></em></p>
        ///   <p>Show pending releases.</p>
        /// </summary>
        [Pure]
        public static T EnablePending<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pending = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmListSettings.Pending"/></em></p>
        ///   <p>Show pending releases.</p>
        /// </summary>
        [Pure]
        public static T DisablePending<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pending = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmListSettings.Pending"/></em></p>
        ///   <p>Show pending releases.</p>
        /// </summary>
        [Pure]
        public static T TogglePending<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pending = !toolSettings.Pending;
            return toolSettings;
        }
        #endregion
        #region Reverse
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Reverse"/></em></p>
        ///   <p>Reverse the sort order.</p>
        /// </summary>
        [Pure]
        public static T SetReverse<T>(this T toolSettings, bool? reverse) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reverse = reverse;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Reverse"/></em></p>
        ///   <p>Reverse the sort order.</p>
        /// </summary>
        [Pure]
        public static T ResetReverse<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reverse = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmListSettings.Reverse"/></em></p>
        ///   <p>Reverse the sort order.</p>
        /// </summary>
        [Pure]
        public static T EnableReverse<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reverse = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmListSettings.Reverse"/></em></p>
        ///   <p>Reverse the sort order.</p>
        /// </summary>
        [Pure]
        public static T DisableReverse<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reverse = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmListSettings.Reverse"/></em></p>
        ///   <p>Reverse the sort order.</p>
        /// </summary>
        [Pure]
        public static T ToggleReverse<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reverse = !toolSettings.Reverse;
            return toolSettings;
        }
        #endregion
        #region Short
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Short"/></em></p>
        ///   <p>Output short (quiet) listing format.</p>
        /// </summary>
        [Pure]
        public static T SetShort<T>(this T toolSettings, bool? @short) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = @short;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Short"/></em></p>
        ///   <p>Output short (quiet) listing format.</p>
        /// </summary>
        [Pure]
        public static T ResetShort<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmListSettings.Short"/></em></p>
        ///   <p>Output short (quiet) listing format.</p>
        /// </summary>
        [Pure]
        public static T EnableShort<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmListSettings.Short"/></em></p>
        ///   <p>Output short (quiet) listing format.</p>
        /// </summary>
        [Pure]
        public static T DisableShort<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmListSettings.Short"/></em></p>
        ///   <p>Output short (quiet) listing format.</p>
        /// </summary>
        [Pure]
        public static T ToggleShort<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = !toolSettings.Short;
            return toolSettings;
        }
        #endregion
        #region Superseded
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Superseded"/></em></p>
        ///   <p>Show superseded releases.</p>
        /// </summary>
        [Pure]
        public static T SetSuperseded<T>(this T toolSettings, bool? superseded) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Superseded = superseded;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Superseded"/></em></p>
        ///   <p>Show superseded releases.</p>
        /// </summary>
        [Pure]
        public static T ResetSuperseded<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Superseded = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmListSettings.Superseded"/></em></p>
        ///   <p>Show superseded releases.</p>
        /// </summary>
        [Pure]
        public static T EnableSuperseded<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Superseded = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmListSettings.Superseded"/></em></p>
        ///   <p>Show superseded releases.</p>
        /// </summary>
        [Pure]
        public static T DisableSuperseded<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Superseded = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmListSettings.Superseded"/></em></p>
        ///   <p>Show superseded releases.</p>
        /// </summary>
        [Pure]
        public static T ToggleSuperseded<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Superseded = !toolSettings.Superseded;
            return toolSettings;
        }
        #endregion
        #region Uninstalled
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Uninstalled"/></em></p>
        ///   <p>Show uninstalled releases (if 'helm uninstall --keep-history' was used).</p>
        /// </summary>
        [Pure]
        public static T SetUninstalled<T>(this T toolSettings, bool? uninstalled) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstalled = uninstalled;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Uninstalled"/></em></p>
        ///   <p>Show uninstalled releases (if 'helm uninstall --keep-history' was used).</p>
        /// </summary>
        [Pure]
        public static T ResetUninstalled<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstalled = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmListSettings.Uninstalled"/></em></p>
        ///   <p>Show uninstalled releases (if 'helm uninstall --keep-history' was used).</p>
        /// </summary>
        [Pure]
        public static T EnableUninstalled<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstalled = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmListSettings.Uninstalled"/></em></p>
        ///   <p>Show uninstalled releases (if 'helm uninstall --keep-history' was used).</p>
        /// </summary>
        [Pure]
        public static T DisableUninstalled<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstalled = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmListSettings.Uninstalled"/></em></p>
        ///   <p>Show uninstalled releases (if 'helm uninstall --keep-history' was used).</p>
        /// </summary>
        [Pure]
        public static T ToggleUninstalled<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstalled = !toolSettings.Uninstalled;
            return toolSettings;
        }
        #endregion
        #region Uninstalling
        /// <summary>
        ///   <p><em>Sets <see cref="HelmListSettings.Uninstalling"/></em></p>
        ///   <p>Show releases that are currently being uninstalled.</p>
        /// </summary>
        [Pure]
        public static T SetUninstalling<T>(this T toolSettings, bool? uninstalling) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstalling = uninstalling;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmListSettings.Uninstalling"/></em></p>
        ///   <p>Show releases that are currently being uninstalled.</p>
        /// </summary>
        [Pure]
        public static T ResetUninstalling<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstalling = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmListSettings.Uninstalling"/></em></p>
        ///   <p>Show releases that are currently being uninstalled.</p>
        /// </summary>
        [Pure]
        public static T EnableUninstalling<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstalling = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmListSettings.Uninstalling"/></em></p>
        ///   <p>Show releases that are currently being uninstalled.</p>
        /// </summary>
        [Pure]
        public static T DisableUninstalling<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstalling = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmListSettings.Uninstalling"/></em></p>
        ///   <p>Show releases that are currently being uninstalled.</p>
        /// </summary>
        [Pure]
        public static T ToggleUninstalling<T>(this T toolSettings) where T : HelmListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Uninstalling = !toolSettings.Uninstalling;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmPackageSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmPackageSettingsExtensions
    {
        #region AppVersion
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPackageSettings.AppVersion"/></em></p>
        ///   <p>Set the appVersion on the chart to this version.</p>
        /// </summary>
        [Pure]
        public static T SetAppVersion<T>(this T toolSettings, string appVersion) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppVersion = appVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPackageSettings.AppVersion"/></em></p>
        ///   <p>Set the appVersion on the chart to this version.</p>
        /// </summary>
        [Pure]
        public static T ResetAppVersion<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppVersion = null;
            return toolSettings;
        }
        #endregion
        #region DependencyUpdate
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPackageSettings.DependencyUpdate"/></em></p>
        ///   <p>Update dependencies from "Chart.yaml" to dir "charts/" before packaging.</p>
        /// </summary>
        [Pure]
        public static T SetDependencyUpdate<T>(this T toolSettings, bool? dependencyUpdate) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = dependencyUpdate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPackageSettings.DependencyUpdate"/></em></p>
        ///   <p>Update dependencies from "Chart.yaml" to dir "charts/" before packaging.</p>
        /// </summary>
        [Pure]
        public static T ResetDependencyUpdate<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPackageSettings.DependencyUpdate"/></em></p>
        ///   <p>Update dependencies from "Chart.yaml" to dir "charts/" before packaging.</p>
        /// </summary>
        [Pure]
        public static T EnableDependencyUpdate<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPackageSettings.DependencyUpdate"/></em></p>
        ///   <p>Update dependencies from "Chart.yaml" to dir "charts/" before packaging.</p>
        /// </summary>
        [Pure]
        public static T DisableDependencyUpdate<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPackageSettings.DependencyUpdate"/></em></p>
        ///   <p>Update dependencies from "Chart.yaml" to dir "charts/" before packaging.</p>
        /// </summary>
        [Pure]
        public static T ToggleDependencyUpdate<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = !toolSettings.DependencyUpdate;
            return toolSettings;
        }
        #endregion
        #region Destination
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPackageSettings.Destination"/></em></p>
        ///   <p>Location to write the chart. (default ".").</p>
        /// </summary>
        [Pure]
        public static T SetDestination<T>(this T toolSettings, string destination) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destination = destination;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPackageSettings.Destination"/></em></p>
        ///   <p>Location to write the chart. (default ".").</p>
        /// </summary>
        [Pure]
        public static T ResetDestination<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destination = null;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPackageSettings.Help"/></em></p>
        ///   <p>Help for package.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPackageSettings.Help"/></em></p>
        ///   <p>Help for package.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPackageSettings.Help"/></em></p>
        ///   <p>Help for package.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPackageSettings.Help"/></em></p>
        ///   <p>Help for package.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPackageSettings.Help"/></em></p>
        ///   <p>Help for package.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Key
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPackageSettings.Key"/></em></p>
        ///   <p>Name of the key to use when signing. Used if --sign is true.</p>
        /// </summary>
        [Pure]
        public static T SetKey<T>(this T toolSettings, string key) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Key = key;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPackageSettings.Key"/></em></p>
        ///   <p>Name of the key to use when signing. Used if --sign is true.</p>
        /// </summary>
        [Pure]
        public static T ResetKey<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Key = null;
            return toolSettings;
        }
        #endregion
        #region Keyring
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPackageSettings.Keyring"/></em></p>
        ///   <p>Location of a public keyring (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = keyring;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPackageSettings.Keyring"/></em></p>
        ///   <p>Location of a public keyring (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T ResetKeyring<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = null;
            return toolSettings;
        }
        #endregion
        #region Sign
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPackageSettings.Sign"/></em></p>
        ///   <p>Use a PGP private key to sign this package.</p>
        /// </summary>
        [Pure]
        public static T SetSign<T>(this T toolSettings, bool? sign) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Sign = sign;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPackageSettings.Sign"/></em></p>
        ///   <p>Use a PGP private key to sign this package.</p>
        /// </summary>
        [Pure]
        public static T ResetSign<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Sign = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPackageSettings.Sign"/></em></p>
        ///   <p>Use a PGP private key to sign this package.</p>
        /// </summary>
        [Pure]
        public static T EnableSign<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Sign = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPackageSettings.Sign"/></em></p>
        ///   <p>Use a PGP private key to sign this package.</p>
        /// </summary>
        [Pure]
        public static T DisableSign<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Sign = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPackageSettings.Sign"/></em></p>
        ///   <p>Use a PGP private key to sign this package.</p>
        /// </summary>
        [Pure]
        public static T ToggleSign<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Sign = !toolSettings.Sign;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPackageSettings.Version"/></em></p>
        ///   <p>Set the version on the chart to this semver version.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPackageSettings.Version"/></em></p>
        ///   <p>Set the version on the chart to this semver version.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region ChartPaths
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPackageSettings.ChartPaths"/> to a new list</em></p>
        ///   <p>The paths to the charts to package.</p>
        /// </summary>
        [Pure]
        public static T SetChartPaths<T>(this T toolSettings, params string[] chartPaths) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChartPathsInternal = chartPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPackageSettings.ChartPaths"/> to a new list</em></p>
        ///   <p>The paths to the charts to package.</p>
        /// </summary>
        [Pure]
        public static T SetChartPaths<T>(this T toolSettings, IEnumerable<string> chartPaths) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChartPathsInternal = chartPaths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmPackageSettings.ChartPaths"/></em></p>
        ///   <p>The paths to the charts to package.</p>
        /// </summary>
        [Pure]
        public static T AddChartPaths<T>(this T toolSettings, params string[] chartPaths) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChartPathsInternal.AddRange(chartPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmPackageSettings.ChartPaths"/></em></p>
        ///   <p>The paths to the charts to package.</p>
        /// </summary>
        [Pure]
        public static T AddChartPaths<T>(this T toolSettings, IEnumerable<string> chartPaths) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChartPathsInternal.AddRange(chartPaths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmPackageSettings.ChartPaths"/></em></p>
        ///   <p>The paths to the charts to package.</p>
        /// </summary>
        [Pure]
        public static T ClearChartPaths<T>(this T toolSettings) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChartPathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmPackageSettings.ChartPaths"/></em></p>
        ///   <p>The paths to the charts to package.</p>
        /// </summary>
        [Pure]
        public static T RemoveChartPaths<T>(this T toolSettings, params string[] chartPaths) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(chartPaths);
            toolSettings.ChartPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmPackageSettings.ChartPaths"/></em></p>
        ///   <p>The paths to the charts to package.</p>
        /// </summary>
        [Pure]
        public static T RemoveChartPaths<T>(this T toolSettings, IEnumerable<string> chartPaths) where T : HelmPackageSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(chartPaths);
            toolSettings.ChartPathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmPluginInstallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmPluginInstallSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPluginInstallSettings.Help"/></em></p>
        ///   <p>Help for install.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPluginInstallSettings.Help"/></em></p>
        ///   <p>Help for install.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPluginInstallSettings.Help"/></em></p>
        ///   <p>Help for install.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPluginInstallSettings.Help"/></em></p>
        ///   <p>Help for install.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPluginInstallSettings.Help"/></em></p>
        ///   <p>Help for install.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPluginInstallSettings.Version"/></em></p>
        ///   <p>Specify a version constraint. If this is not specified, the latest version is installed.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPluginInstallSettings.Version"/></em></p>
        ///   <p>Specify a version constraint. If this is not specified, the latest version is installed.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Options
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPluginInstallSettings.Options"/></em></p>
        /// </summary>
        [Pure]
        public static T SetOptions<T>(this T toolSettings, string options) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Options = options;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPluginInstallSettings.Options"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetOptions<T>(this T toolSettings) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Options = null;
            return toolSettings;
        }
        #endregion
        #region Paths
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPluginInstallSettings.Paths"/> to a new list</em></p>
        ///   <p>List of paths or urls of packages to install.</p>
        /// </summary>
        [Pure]
        public static T SetPaths<T>(this T toolSettings, params string[] paths) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PathsInternal = paths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPluginInstallSettings.Paths"/> to a new list</em></p>
        ///   <p>List of paths or urls of packages to install.</p>
        /// </summary>
        [Pure]
        public static T SetPaths<T>(this T toolSettings, IEnumerable<string> paths) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PathsInternal = paths.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmPluginInstallSettings.Paths"/></em></p>
        ///   <p>List of paths or urls of packages to install.</p>
        /// </summary>
        [Pure]
        public static T AddPaths<T>(this T toolSettings, params string[] paths) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PathsInternal.AddRange(paths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmPluginInstallSettings.Paths"/></em></p>
        ///   <p>List of paths or urls of packages to install.</p>
        /// </summary>
        [Pure]
        public static T AddPaths<T>(this T toolSettings, IEnumerable<string> paths) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PathsInternal.AddRange(paths);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmPluginInstallSettings.Paths"/></em></p>
        ///   <p>List of paths or urls of packages to install.</p>
        /// </summary>
        [Pure]
        public static T ClearPaths<T>(this T toolSettings) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PathsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmPluginInstallSettings.Paths"/></em></p>
        ///   <p>List of paths or urls of packages to install.</p>
        /// </summary>
        [Pure]
        public static T RemovePaths<T>(this T toolSettings, params string[] paths) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(paths);
            toolSettings.PathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmPluginInstallSettings.Paths"/></em></p>
        ///   <p>List of paths or urls of packages to install.</p>
        /// </summary>
        [Pure]
        public static T RemovePaths<T>(this T toolSettings, IEnumerable<string> paths) where T : HelmPluginInstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(paths);
            toolSettings.PathsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmPluginListSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmPluginListSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPluginListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmPluginListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPluginListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmPluginListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPluginListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmPluginListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPluginListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmPluginListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPluginListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmPluginListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmPluginUninstallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmPluginUninstallSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPluginUninstallSettings.Help"/></em></p>
        ///   <p>Help for uninstall.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmPluginUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPluginUninstallSettings.Help"/></em></p>
        ///   <p>Help for uninstall.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmPluginUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPluginUninstallSettings.Help"/></em></p>
        ///   <p>Help for uninstall.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmPluginUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPluginUninstallSettings.Help"/></em></p>
        ///   <p>Help for uninstall.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmPluginUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPluginUninstallSettings.Help"/></em></p>
        ///   <p>Help for uninstall.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmPluginUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Plugins
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPluginUninstallSettings.Plugins"/> to a new list</em></p>
        /// </summary>
        [Pure]
        public static T SetPlugins<T>(this T toolSettings, params string[] plugins) where T : HelmPluginUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal = plugins.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPluginUninstallSettings.Plugins"/> to a new list</em></p>
        /// </summary>
        [Pure]
        public static T SetPlugins<T>(this T toolSettings, IEnumerable<string> plugins) where T : HelmPluginUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal = plugins.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmPluginUninstallSettings.Plugins"/></em></p>
        /// </summary>
        [Pure]
        public static T AddPlugins<T>(this T toolSettings, params string[] plugins) where T : HelmPluginUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.AddRange(plugins);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmPluginUninstallSettings.Plugins"/></em></p>
        /// </summary>
        [Pure]
        public static T AddPlugins<T>(this T toolSettings, IEnumerable<string> plugins) where T : HelmPluginUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.AddRange(plugins);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmPluginUninstallSettings.Plugins"/></em></p>
        /// </summary>
        [Pure]
        public static T ClearPlugins<T>(this T toolSettings) where T : HelmPluginUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmPluginUninstallSettings.Plugins"/></em></p>
        /// </summary>
        [Pure]
        public static T RemovePlugins<T>(this T toolSettings, params string[] plugins) where T : HelmPluginUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(plugins);
            toolSettings.PluginsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmPluginUninstallSettings.Plugins"/></em></p>
        /// </summary>
        [Pure]
        public static T RemovePlugins<T>(this T toolSettings, IEnumerable<string> plugins) where T : HelmPluginUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(plugins);
            toolSettings.PluginsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmPluginUpdateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmPluginUpdateSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPluginUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmPluginUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPluginUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmPluginUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPluginUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmPluginUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPluginUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmPluginUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPluginUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmPluginUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Plugins
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPluginUpdateSettings.Plugins"/> to a new list</em></p>
        ///   <p>List of plugins to update.</p>
        /// </summary>
        [Pure]
        public static T SetPlugins<T>(this T toolSettings, params string[] plugins) where T : HelmPluginUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal = plugins.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPluginUpdateSettings.Plugins"/> to a new list</em></p>
        ///   <p>List of plugins to update.</p>
        /// </summary>
        [Pure]
        public static T SetPlugins<T>(this T toolSettings, IEnumerable<string> plugins) where T : HelmPluginUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal = plugins.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmPluginUpdateSettings.Plugins"/></em></p>
        ///   <p>List of plugins to update.</p>
        /// </summary>
        [Pure]
        public static T AddPlugins<T>(this T toolSettings, params string[] plugins) where T : HelmPluginUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.AddRange(plugins);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmPluginUpdateSettings.Plugins"/></em></p>
        ///   <p>List of plugins to update.</p>
        /// </summary>
        [Pure]
        public static T AddPlugins<T>(this T toolSettings, IEnumerable<string> plugins) where T : HelmPluginUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.AddRange(plugins);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmPluginUpdateSettings.Plugins"/></em></p>
        ///   <p>List of plugins to update.</p>
        /// </summary>
        [Pure]
        public static T ClearPlugins<T>(this T toolSettings) where T : HelmPluginUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmPluginUpdateSettings.Plugins"/></em></p>
        ///   <p>List of plugins to update.</p>
        /// </summary>
        [Pure]
        public static T RemovePlugins<T>(this T toolSettings, params string[] plugins) where T : HelmPluginUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(plugins);
            toolSettings.PluginsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmPluginUpdateSettings.Plugins"/></em></p>
        ///   <p>List of plugins to update.</p>
        /// </summary>
        [Pure]
        public static T RemovePlugins<T>(this T toolSettings, IEnumerable<string> plugins) where T : HelmPluginUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(plugins);
            toolSettings.PluginsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmPullSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmPullSettingsExtensions
    {
        #region CaFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = caFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T ResetCaFile<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = null;
            return toolSettings;
        }
        #endregion
        #region CertFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = certFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T ResetCertFile<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = null;
            return toolSettings;
        }
        #endregion
        #region Destination
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Destination"/></em></p>
        ///   <p>Location to write the chart. If this and tardir are specified, tardir is appended to this (default ".").</p>
        /// </summary>
        [Pure]
        public static T SetDestination<T>(this T toolSettings, string destination) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destination = destination;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.Destination"/></em></p>
        ///   <p>Location to write the chart. If this and tardir are specified, tardir is appended to this (default ".").</p>
        /// </summary>
        [Pure]
        public static T ResetDestination<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destination = null;
            return toolSettings;
        }
        #endregion
        #region Devel
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = devel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ResetDevel<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPullSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T EnableDevel<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPullSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T DisableDevel<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPullSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ToggleDevel<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = !toolSettings.Devel;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Help"/></em></p>
        ///   <p>Help for pull.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.Help"/></em></p>
        ///   <p>Help for pull.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPullSettings.Help"/></em></p>
        ///   <p>Help for pull.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPullSettings.Help"/></em></p>
        ///   <p>Help for pull.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPullSettings.Help"/></em></p>
        ///   <p>Help for pull.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region InsecureSkipTlsVerify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T SetInsecureSkipTlsVerify<T>(this T toolSettings, bool? insecureSkipTlsVerify) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = insecureSkipTlsVerify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ResetInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPullSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T EnableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPullSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T DisableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPullSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ToggleInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = !toolSettings.InsecureSkipTlsVerify;
            return toolSettings;
        }
        #endregion
        #region KeyFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = keyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyFile<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = null;
            return toolSettings;
        }
        #endregion
        #region Keyring
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = keyring;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T ResetKeyring<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, string password) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Prov
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Prov"/></em></p>
        ///   <p>Fetch the provenance file, but don't perform verification.</p>
        /// </summary>
        [Pure]
        public static T SetProv<T>(this T toolSettings, bool? prov) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prov = prov;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.Prov"/></em></p>
        ///   <p>Fetch the provenance file, but don't perform verification.</p>
        /// </summary>
        [Pure]
        public static T ResetProv<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prov = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPullSettings.Prov"/></em></p>
        ///   <p>Fetch the provenance file, but don't perform verification.</p>
        /// </summary>
        [Pure]
        public static T EnableProv<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prov = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPullSettings.Prov"/></em></p>
        ///   <p>Fetch the provenance file, but don't perform verification.</p>
        /// </summary>
        [Pure]
        public static T DisableProv<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prov = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPullSettings.Prov"/></em></p>
        ///   <p>Fetch the provenance file, but don't perform verification.</p>
        /// </summary>
        [Pure]
        public static T ToggleProv<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prov = !toolSettings.Prov;
            return toolSettings;
        }
        #endregion
        #region Repo
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = repo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetRepo<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = null;
            return toolSettings;
        }
        #endregion
        #region Untar
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Untar"/></em></p>
        ///   <p>If set to true, will untar the chart after downloading it.</p>
        /// </summary>
        [Pure]
        public static T SetUntar<T>(this T toolSettings, bool? untar) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Untar = untar;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.Untar"/></em></p>
        ///   <p>If set to true, will untar the chart after downloading it.</p>
        /// </summary>
        [Pure]
        public static T ResetUntar<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Untar = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPullSettings.Untar"/></em></p>
        ///   <p>If set to true, will untar the chart after downloading it.</p>
        /// </summary>
        [Pure]
        public static T EnableUntar<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Untar = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPullSettings.Untar"/></em></p>
        ///   <p>If set to true, will untar the chart after downloading it.</p>
        /// </summary>
        [Pure]
        public static T DisableUntar<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Untar = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPullSettings.Untar"/></em></p>
        ///   <p>If set to true, will untar the chart after downloading it.</p>
        /// </summary>
        [Pure]
        public static T ToggleUntar<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Untar = !toolSettings.Untar;
            return toolSettings;
        }
        #endregion
        #region Untardir
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Untardir"/></em></p>
        ///   <p>If untar is specified, this flag specifies the name of the directory into which the chart is expanded (default ".").</p>
        /// </summary>
        [Pure]
        public static T SetUntardir<T>(this T toolSettings, string untardir) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Untardir = untardir;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.Untardir"/></em></p>
        ///   <p>If untar is specified, this flag specifies the name of the directory into which the chart is expanded (default ".").</p>
        /// </summary>
        [Pure]
        public static T ResetUntardir<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Untardir = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Verify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = verify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ResetVerify<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmPullSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T EnableVerify<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmPullSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T DisableVerify<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmPullSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerify<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = !toolSettings.Verify;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmPullSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Urls
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Urls"/> to a new list</em></p>
        /// </summary>
        [Pure]
        public static T SetUrls<T>(this T toolSettings, params string[] urls) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UrlsInternal = urls.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="HelmPullSettings.Urls"/> to a new list</em></p>
        /// </summary>
        [Pure]
        public static T SetUrls<T>(this T toolSettings, IEnumerable<string> urls) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UrlsInternal = urls.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmPullSettings.Urls"/></em></p>
        /// </summary>
        [Pure]
        public static T AddUrls<T>(this T toolSettings, params string[] urls) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UrlsInternal.AddRange(urls);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmPullSettings.Urls"/></em></p>
        /// </summary>
        [Pure]
        public static T AddUrls<T>(this T toolSettings, IEnumerable<string> urls) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UrlsInternal.AddRange(urls);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmPullSettings.Urls"/></em></p>
        /// </summary>
        [Pure]
        public static T ClearUrls<T>(this T toolSettings) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UrlsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmPullSettings.Urls"/></em></p>
        /// </summary>
        [Pure]
        public static T RemoveUrls<T>(this T toolSettings, params string[] urls) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(urls);
            toolSettings.UrlsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmPullSettings.Urls"/></em></p>
        /// </summary>
        [Pure]
        public static T RemoveUrls<T>(this T toolSettings, IEnumerable<string> urls) where T : HelmPullSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(urls);
            toolSettings.UrlsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmRepoAddSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmRepoAddSettingsExtensions
    {
        #region CaFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoAddSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = caFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoAddSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T ResetCaFile<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = null;
            return toolSettings;
        }
        #endregion
        #region CertFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoAddSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = certFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoAddSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T ResetCertFile<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = null;
            return toolSettings;
        }
        #endregion
        #region ForceUpdate
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoAddSettings.ForceUpdate"/></em></p>
        ///   <p>Replace (overwrite) the repo if it already exists.</p>
        /// </summary>
        [Pure]
        public static T SetForceUpdate<T>(this T toolSettings, bool? forceUpdate) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceUpdate = forceUpdate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoAddSettings.ForceUpdate"/></em></p>
        ///   <p>Replace (overwrite) the repo if it already exists.</p>
        /// </summary>
        [Pure]
        public static T ResetForceUpdate<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceUpdate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRepoAddSettings.ForceUpdate"/></em></p>
        ///   <p>Replace (overwrite) the repo if it already exists.</p>
        /// </summary>
        [Pure]
        public static T EnableForceUpdate<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceUpdate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRepoAddSettings.ForceUpdate"/></em></p>
        ///   <p>Replace (overwrite) the repo if it already exists.</p>
        /// </summary>
        [Pure]
        public static T DisableForceUpdate<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceUpdate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRepoAddSettings.ForceUpdate"/></em></p>
        ///   <p>Replace (overwrite) the repo if it already exists.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceUpdate<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceUpdate = !toolSettings.ForceUpdate;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoAddSettings.Help"/></em></p>
        ///   <p>Help for add.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoAddSettings.Help"/></em></p>
        ///   <p>Help for add.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRepoAddSettings.Help"/></em></p>
        ///   <p>Help for add.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRepoAddSettings.Help"/></em></p>
        ///   <p>Help for add.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRepoAddSettings.Help"/></em></p>
        ///   <p>Help for add.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region InsecureSkipTlsVerify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoAddSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the repository.</p>
        /// </summary>
        [Pure]
        public static T SetInsecureSkipTlsVerify<T>(this T toolSettings, bool? insecureSkipTlsVerify) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = insecureSkipTlsVerify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoAddSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the repository.</p>
        /// </summary>
        [Pure]
        public static T ResetInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRepoAddSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the repository.</p>
        /// </summary>
        [Pure]
        public static T EnableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRepoAddSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the repository.</p>
        /// </summary>
        [Pure]
        public static T DisableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRepoAddSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the repository.</p>
        /// </summary>
        [Pure]
        public static T ToggleInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = !toolSettings.InsecureSkipTlsVerify;
            return toolSettings;
        }
        #endregion
        #region KeyFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoAddSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = keyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoAddSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyFile<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = null;
            return toolSettings;
        }
        #endregion
        #region NoUpdate
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoAddSettings.NoUpdate"/></em></p>
        ///   <p>Ignored. Formerly, it would disabled forced updates. It is deprecated by force-update.</p>
        /// </summary>
        [Pure]
        public static T SetNoUpdate<T>(this T toolSettings, bool? noUpdate) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoUpdate = noUpdate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoAddSettings.NoUpdate"/></em></p>
        ///   <p>Ignored. Formerly, it would disabled forced updates. It is deprecated by force-update.</p>
        /// </summary>
        [Pure]
        public static T ResetNoUpdate<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoUpdate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRepoAddSettings.NoUpdate"/></em></p>
        ///   <p>Ignored. Formerly, it would disabled forced updates. It is deprecated by force-update.</p>
        /// </summary>
        [Pure]
        public static T EnableNoUpdate<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoUpdate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRepoAddSettings.NoUpdate"/></em></p>
        ///   <p>Ignored. Formerly, it would disabled forced updates. It is deprecated by force-update.</p>
        /// </summary>
        [Pure]
        public static T DisableNoUpdate<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoUpdate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRepoAddSettings.NoUpdate"/></em></p>
        ///   <p>Ignored. Formerly, it would disabled forced updates. It is deprecated by force-update.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoUpdate<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoUpdate = !toolSettings.NoUpdate;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoAddSettings.Password"/></em></p>
        ///   <p>Chart repository password.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, string password) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoAddSettings.Password"/></em></p>
        ///   <p>Chart repository password.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoAddSettings.Username"/></em></p>
        ///   <p>Chart repository username.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoAddSettings.Username"/></em></p>
        ///   <p>Chart repository username.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoAddSettings.Name"/></em></p>
        ///   <p>The name of the repository to add.</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoAddSettings.Name"/></em></p>
        ///   <p>The name of the repository to add.</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Url
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoAddSettings.Url"/></em></p>
        ///   <p>The url of the repository to add.</p>
        /// </summary>
        [Pure]
        public static T SetUrl<T>(this T toolSettings, string url) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoAddSettings.Url"/></em></p>
        ///   <p>The url of the repository to add.</p>
        /// </summary>
        [Pure]
        public static T ResetUrl<T>(this T toolSettings) where T : HelmRepoAddSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmRepoIndexSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmRepoIndexSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoIndexSettings.Help"/></em></p>
        ///   <p>Help for index.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmRepoIndexSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoIndexSettings.Help"/></em></p>
        ///   <p>Help for index.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmRepoIndexSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRepoIndexSettings.Help"/></em></p>
        ///   <p>Help for index.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmRepoIndexSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRepoIndexSettings.Help"/></em></p>
        ///   <p>Help for index.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmRepoIndexSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRepoIndexSettings.Help"/></em></p>
        ///   <p>Help for index.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmRepoIndexSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Merge
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoIndexSettings.Merge"/></em></p>
        ///   <p>Merge the generated index into the given index.</p>
        /// </summary>
        [Pure]
        public static T SetMerge<T>(this T toolSettings, string merge) where T : HelmRepoIndexSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Merge = merge;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoIndexSettings.Merge"/></em></p>
        ///   <p>Merge the generated index into the given index.</p>
        /// </summary>
        [Pure]
        public static T ResetMerge<T>(this T toolSettings) where T : HelmRepoIndexSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Merge = null;
            return toolSettings;
        }
        #endregion
        #region Url
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoIndexSettings.Url"/></em></p>
        ///   <p>Url of chart repository.</p>
        /// </summary>
        [Pure]
        public static T SetUrl<T>(this T toolSettings, string url) where T : HelmRepoIndexSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoIndexSettings.Url"/></em></p>
        ///   <p>Url of chart repository.</p>
        /// </summary>
        [Pure]
        public static T ResetUrl<T>(this T toolSettings) where T : HelmRepoIndexSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region Directory
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoIndexSettings.Directory"/></em></p>
        ///   <p>The directory of the repository.</p>
        /// </summary>
        [Pure]
        public static T SetDirectory<T>(this T toolSettings, string directory) where T : HelmRepoIndexSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Directory = directory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoIndexSettings.Directory"/></em></p>
        ///   <p>The directory of the repository.</p>
        /// </summary>
        [Pure]
        public static T ResetDirectory<T>(this T toolSettings) where T : HelmRepoIndexSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Directory = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmRepoListSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmRepoListSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmRepoListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmRepoListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRepoListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmRepoListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRepoListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmRepoListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRepoListSettings.Help"/></em></p>
        ///   <p>Help for list.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmRepoListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoListSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, HelmOutputFormat output) where T : HelmRepoListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoListSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : HelmRepoListSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmRepoRemoveSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmRepoRemoveSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoRemoveSettings.Help"/></em></p>
        ///   <p>Help for remove.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmRepoRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoRemoveSettings.Help"/></em></p>
        ///   <p>Help for remove.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmRepoRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRepoRemoveSettings.Help"/></em></p>
        ///   <p>Help for remove.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmRepoRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRepoRemoveSettings.Help"/></em></p>
        ///   <p>Help for remove.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmRepoRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRepoRemoveSettings.Help"/></em></p>
        ///   <p>Help for remove.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmRepoRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Repositories
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoRemoveSettings.Repositories"/> to a new list</em></p>
        /// </summary>
        [Pure]
        public static T SetRepositories<T>(this T toolSettings, params string[] repositories) where T : HelmRepoRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoriesInternal = repositories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoRemoveSettings.Repositories"/> to a new list</em></p>
        /// </summary>
        [Pure]
        public static T SetRepositories<T>(this T toolSettings, IEnumerable<string> repositories) where T : HelmRepoRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoriesInternal = repositories.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmRepoRemoveSettings.Repositories"/></em></p>
        /// </summary>
        [Pure]
        public static T AddRepositories<T>(this T toolSettings, params string[] repositories) where T : HelmRepoRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoriesInternal.AddRange(repositories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmRepoRemoveSettings.Repositories"/></em></p>
        /// </summary>
        [Pure]
        public static T AddRepositories<T>(this T toolSettings, IEnumerable<string> repositories) where T : HelmRepoRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoriesInternal.AddRange(repositories);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmRepoRemoveSettings.Repositories"/></em></p>
        /// </summary>
        [Pure]
        public static T ClearRepositories<T>(this T toolSettings) where T : HelmRepoRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoriesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmRepoRemoveSettings.Repositories"/></em></p>
        /// </summary>
        [Pure]
        public static T RemoveRepositories<T>(this T toolSettings, params string[] repositories) where T : HelmRepoRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(repositories);
            toolSettings.RepositoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmRepoRemoveSettings.Repositories"/></em></p>
        /// </summary>
        [Pure]
        public static T RemoveRepositories<T>(this T toolSettings, IEnumerable<string> repositories) where T : HelmRepoRemoveSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(repositories);
            toolSettings.RepositoriesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmRepoUpdateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmRepoUpdateSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRepoUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmRepoUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRepoUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmRepoUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRepoUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmRepoUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRepoUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmRepoUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRepoUpdateSettings.Help"/></em></p>
        ///   <p>Help for update.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmRepoUpdateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmRollbackSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmRollbackSettingsExtensions
    {
        #region CleanupOnFail
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRollbackSettings.CleanupOnFail"/></em></p>
        ///   <p>Allow deletion of new resources created in this rollback when rollback fails.</p>
        /// </summary>
        [Pure]
        public static T SetCleanupOnFail<T>(this T toolSettings, bool? cleanupOnFail) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupOnFail = cleanupOnFail;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRollbackSettings.CleanupOnFail"/></em></p>
        ///   <p>Allow deletion of new resources created in this rollback when rollback fails.</p>
        /// </summary>
        [Pure]
        public static T ResetCleanupOnFail<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupOnFail = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRollbackSettings.CleanupOnFail"/></em></p>
        ///   <p>Allow deletion of new resources created in this rollback when rollback fails.</p>
        /// </summary>
        [Pure]
        public static T EnableCleanupOnFail<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupOnFail = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRollbackSettings.CleanupOnFail"/></em></p>
        ///   <p>Allow deletion of new resources created in this rollback when rollback fails.</p>
        /// </summary>
        [Pure]
        public static T DisableCleanupOnFail<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupOnFail = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRollbackSettings.CleanupOnFail"/></em></p>
        ///   <p>Allow deletion of new resources created in this rollback when rollback fails.</p>
        /// </summary>
        [Pure]
        public static T ToggleCleanupOnFail<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupOnFail = !toolSettings.CleanupOnFail;
            return toolSettings;
        }
        #endregion
        #region DryRun
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRollbackSettings.DryRun"/></em></p>
        ///   <p>Simulate a rollback.</p>
        /// </summary>
        [Pure]
        public static T SetDryRun<T>(this T toolSettings, bool? dryRun) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = dryRun;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRollbackSettings.DryRun"/></em></p>
        ///   <p>Simulate a rollback.</p>
        /// </summary>
        [Pure]
        public static T ResetDryRun<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRollbackSettings.DryRun"/></em></p>
        ///   <p>Simulate a rollback.</p>
        /// </summary>
        [Pure]
        public static T EnableDryRun<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRollbackSettings.DryRun"/></em></p>
        ///   <p>Simulate a rollback.</p>
        /// </summary>
        [Pure]
        public static T DisableDryRun<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRollbackSettings.DryRun"/></em></p>
        ///   <p>Simulate a rollback.</p>
        /// </summary>
        [Pure]
        public static T ToggleDryRun<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = !toolSettings.DryRun;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRollbackSettings.Force"/></em></p>
        ///   <p>Force resource update through delete/recreate if needed.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRollbackSettings.Force"/></em></p>
        ///   <p>Force resource update through delete/recreate if needed.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRollbackSettings.Force"/></em></p>
        ///   <p>Force resource update through delete/recreate if needed.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRollbackSettings.Force"/></em></p>
        ///   <p>Force resource update through delete/recreate if needed.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRollbackSettings.Force"/></em></p>
        ///   <p>Force resource update through delete/recreate if needed.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRollbackSettings.Help"/></em></p>
        ///   <p>Help for rollback.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRollbackSettings.Help"/></em></p>
        ///   <p>Help for rollback.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRollbackSettings.Help"/></em></p>
        ///   <p>Help for rollback.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRollbackSettings.Help"/></em></p>
        ///   <p>Help for rollback.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRollbackSettings.Help"/></em></p>
        ///   <p>Help for rollback.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region NoHooks
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRollbackSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during rollback.</p>
        /// </summary>
        [Pure]
        public static T SetNoHooks<T>(this T toolSettings, bool? noHooks) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = noHooks;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRollbackSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during rollback.</p>
        /// </summary>
        [Pure]
        public static T ResetNoHooks<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRollbackSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during rollback.</p>
        /// </summary>
        [Pure]
        public static T EnableNoHooks<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRollbackSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during rollback.</p>
        /// </summary>
        [Pure]
        public static T DisableNoHooks<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRollbackSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during rollback.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoHooks<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = !toolSettings.NoHooks;
            return toolSettings;
        }
        #endregion
        #region RecreatePods
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRollbackSettings.RecreatePods"/></em></p>
        ///   <p>Performs pods restart for the resource if applicable.</p>
        /// </summary>
        [Pure]
        public static T SetRecreatePods<T>(this T toolSettings, bool? recreatePods) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecreatePods = recreatePods;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRollbackSettings.RecreatePods"/></em></p>
        ///   <p>Performs pods restart for the resource if applicable.</p>
        /// </summary>
        [Pure]
        public static T ResetRecreatePods<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecreatePods = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRollbackSettings.RecreatePods"/></em></p>
        ///   <p>Performs pods restart for the resource if applicable.</p>
        /// </summary>
        [Pure]
        public static T EnableRecreatePods<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecreatePods = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRollbackSettings.RecreatePods"/></em></p>
        ///   <p>Performs pods restart for the resource if applicable.</p>
        /// </summary>
        [Pure]
        public static T DisableRecreatePods<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecreatePods = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRollbackSettings.RecreatePods"/></em></p>
        ///   <p>Performs pods restart for the resource if applicable.</p>
        /// </summary>
        [Pure]
        public static T ToggleRecreatePods<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RecreatePods = !toolSettings.RecreatePods;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRollbackSettings.Timeout"/></em></p>
        ///   <p>Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, string timeout) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRollbackSettings.Timeout"/></em></p>
        ///   <p>Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Wait
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRollbackSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T SetWait<T>(this T toolSettings, bool? wait) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = wait;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRollbackSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T ResetWait<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmRollbackSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T EnableWait<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmRollbackSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T DisableWait<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmRollbackSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T ToggleWait<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = !toolSettings.Wait;
            return toolSettings;
        }
        #endregion
        #region Release
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRollbackSettings.Release"/></em></p>
        ///   <p>The name of the release.</p>
        /// </summary>
        [Pure]
        public static T SetRelease<T>(this T toolSettings, string release) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Release = release;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRollbackSettings.Release"/></em></p>
        ///   <p>The name of the release.</p>
        /// </summary>
        [Pure]
        public static T ResetRelease<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Release = null;
            return toolSettings;
        }
        #endregion
        #region Revision
        /// <summary>
        ///   <p><em>Sets <see cref="HelmRollbackSettings.Revision"/></em></p>
        ///   <p>The revison to roll back.</p>
        /// </summary>
        [Pure]
        public static T SetRevision<T>(this T toolSettings, string revision) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = revision;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmRollbackSettings.Revision"/></em></p>
        ///   <p>The revison to roll back.</p>
        /// </summary>
        [Pure]
        public static T ResetRevision<T>(this T toolSettings) where T : HelmRollbackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmSearchHubSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmSearchHubSettingsExtensions
    {
        #region Endpoint
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchHubSettings.Endpoint"/></em></p>
        ///   <p>Monocular instance to query for charts (default "https://hub.helm.sh").</p>
        /// </summary>
        [Pure]
        public static T SetEndpoint<T>(this T toolSettings, string endpoint) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Endpoint = endpoint;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchHubSettings.Endpoint"/></em></p>
        ///   <p>Monocular instance to query for charts (default "https://hub.helm.sh").</p>
        /// </summary>
        [Pure]
        public static T ResetEndpoint<T>(this T toolSettings) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Endpoint = null;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchHubSettings.Help"/></em></p>
        ///   <p>Help for hub.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchHubSettings.Help"/></em></p>
        ///   <p>Help for hub.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmSearchHubSettings.Help"/></em></p>
        ///   <p>Help for hub.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmSearchHubSettings.Help"/></em></p>
        ///   <p>Help for hub.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmSearchHubSettings.Help"/></em></p>
        ///   <p>Help for hub.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region MaxColWidth
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchHubSettings.MaxColWidth"/></em></p>
        ///   <p>Maximum column width for output table (default 50).</p>
        /// </summary>
        [Pure]
        public static T SetMaxColWidth<T>(this T toolSettings, uint? maxColWidth) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxColWidth = maxColWidth;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchHubSettings.MaxColWidth"/></em></p>
        ///   <p>Maximum column width for output table (default 50).</p>
        /// </summary>
        [Pure]
        public static T ResetMaxColWidth<T>(this T toolSettings) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxColWidth = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchHubSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, HelmOutputFormat output) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchHubSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Keyword
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchHubSettings.Keyword"/></em></p>
        /// </summary>
        [Pure]
        public static T SetKeyword<T>(this T toolSettings, string keyword) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyword = keyword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchHubSettings.Keyword"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetKeyword<T>(this T toolSettings) where T : HelmSearchHubSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyword = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmSearchRepoSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmSearchRepoSettingsExtensions
    {
        #region Devel
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchRepoSettings.Devel"/></em></p>
        ///   <p>Use development versions (alpha, beta, and release candidate releases), too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = devel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchRepoSettings.Devel"/></em></p>
        ///   <p>Use development versions (alpha, beta, and release candidate releases), too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ResetDevel<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmSearchRepoSettings.Devel"/></em></p>
        ///   <p>Use development versions (alpha, beta, and release candidate releases), too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T EnableDevel<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmSearchRepoSettings.Devel"/></em></p>
        ///   <p>Use development versions (alpha, beta, and release candidate releases), too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T DisableDevel<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmSearchRepoSettings.Devel"/></em></p>
        ///   <p>Use development versions (alpha, beta, and release candidate releases), too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ToggleDevel<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = !toolSettings.Devel;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchRepoSettings.Help"/></em></p>
        ///   <p>Help for repo.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchRepoSettings.Help"/></em></p>
        ///   <p>Help for repo.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmSearchRepoSettings.Help"/></em></p>
        ///   <p>Help for repo.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmSearchRepoSettings.Help"/></em></p>
        ///   <p>Help for repo.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmSearchRepoSettings.Help"/></em></p>
        ///   <p>Help for repo.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region MaxColWidth
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchRepoSettings.MaxColWidth"/></em></p>
        ///   <p>Maximum column width for output table (default 50).</p>
        /// </summary>
        [Pure]
        public static T SetMaxColWidth<T>(this T toolSettings, uint? maxColWidth) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxColWidth = maxColWidth;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchRepoSettings.MaxColWidth"/></em></p>
        ///   <p>Maximum column width for output table (default 50).</p>
        /// </summary>
        [Pure]
        public static T ResetMaxColWidth<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxColWidth = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchRepoSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, HelmOutputFormat output) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchRepoSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Regexp
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchRepoSettings.Regexp"/></em></p>
        ///   <p>Use regular expressions for searching repositories you have added.</p>
        /// </summary>
        [Pure]
        public static T SetRegexp<T>(this T toolSettings, bool? regexp) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Regexp = regexp;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchRepoSettings.Regexp"/></em></p>
        ///   <p>Use regular expressions for searching repositories you have added.</p>
        /// </summary>
        [Pure]
        public static T ResetRegexp<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Regexp = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmSearchRepoSettings.Regexp"/></em></p>
        ///   <p>Use regular expressions for searching repositories you have added.</p>
        /// </summary>
        [Pure]
        public static T EnableRegexp<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Regexp = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmSearchRepoSettings.Regexp"/></em></p>
        ///   <p>Use regular expressions for searching repositories you have added.</p>
        /// </summary>
        [Pure]
        public static T DisableRegexp<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Regexp = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmSearchRepoSettings.Regexp"/></em></p>
        ///   <p>Use regular expressions for searching repositories you have added.</p>
        /// </summary>
        [Pure]
        public static T ToggleRegexp<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Regexp = !toolSettings.Regexp;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchRepoSettings.Version"/></em></p>
        ///   <p>Search using semantic versioning constraints on repositories you have added.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchRepoSettings.Version"/></em></p>
        ///   <p>Search using semantic versioning constraints on repositories you have added.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Versions
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchRepoSettings.Versions"/></em></p>
        ///   <p>Show the long listing, with each version of each chart on its own line, for repositories you have added.</p>
        /// </summary>
        [Pure]
        public static T SetVersions<T>(this T toolSettings, bool? versions) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Versions = versions;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchRepoSettings.Versions"/></em></p>
        ///   <p>Show the long listing, with each version of each chart on its own line, for repositories you have added.</p>
        /// </summary>
        [Pure]
        public static T ResetVersions<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Versions = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmSearchRepoSettings.Versions"/></em></p>
        ///   <p>Show the long listing, with each version of each chart on its own line, for repositories you have added.</p>
        /// </summary>
        [Pure]
        public static T EnableVersions<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Versions = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmSearchRepoSettings.Versions"/></em></p>
        ///   <p>Show the long listing, with each version of each chart on its own line, for repositories you have added.</p>
        /// </summary>
        [Pure]
        public static T DisableVersions<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Versions = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmSearchRepoSettings.Versions"/></em></p>
        ///   <p>Show the long listing, with each version of each chart on its own line, for repositories you have added.</p>
        /// </summary>
        [Pure]
        public static T ToggleVersions<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Versions = !toolSettings.Versions;
            return toolSettings;
        }
        #endregion
        #region Keyword
        /// <summary>
        ///   <p><em>Sets <see cref="HelmSearchRepoSettings.Keyword"/></em></p>
        /// </summary>
        [Pure]
        public static T SetKeyword<T>(this T toolSettings, string keyword) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyword = keyword;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmSearchRepoSettings.Keyword"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetKeyword<T>(this T toolSettings) where T : HelmSearchRepoSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyword = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmShowAllSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmShowAllSettingsExtensions
    {
        #region CaFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = caFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T ResetCaFile<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = null;
            return toolSettings;
        }
        #endregion
        #region CertFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = certFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T ResetCertFile<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = null;
            return toolSettings;
        }
        #endregion
        #region Devel
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = devel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ResetDevel<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowAllSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T EnableDevel<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowAllSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T DisableDevel<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowAllSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ToggleDevel<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = !toolSettings.Devel;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.Help"/></em></p>
        ///   <p>Help for all.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.Help"/></em></p>
        ///   <p>Help for all.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowAllSettings.Help"/></em></p>
        ///   <p>Help for all.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowAllSettings.Help"/></em></p>
        ///   <p>Help for all.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowAllSettings.Help"/></em></p>
        ///   <p>Help for all.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region InsecureSkipTlsVerify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T SetInsecureSkipTlsVerify<T>(this T toolSettings, bool? insecureSkipTlsVerify) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = insecureSkipTlsVerify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ResetInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowAllSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T EnableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowAllSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T DisableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowAllSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ToggleInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = !toolSettings.InsecureSkipTlsVerify;
            return toolSettings;
        }
        #endregion
        #region KeyFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = keyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyFile<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = null;
            return toolSettings;
        }
        #endregion
        #region Keyring
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = keyring;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T ResetKeyring<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, string password) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Repo
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = repo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetRepo<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Verify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = verify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ResetVerify<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowAllSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T EnableVerify<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowAllSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T DisableVerify<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowAllSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerify<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = !toolSettings.Verify;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Chart
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowAllSettings.Chart"/></em></p>
        /// </summary>
        [Pure]
        public static T SetChart<T>(this T toolSettings, string chart) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = chart;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowAllSettings.Chart"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetChart<T>(this T toolSettings) where T : HelmShowAllSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmShowChartSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmShowChartSettingsExtensions
    {
        #region CaFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = caFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T ResetCaFile<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = null;
            return toolSettings;
        }
        #endregion
        #region CertFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = certFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T ResetCertFile<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = null;
            return toolSettings;
        }
        #endregion
        #region Devel
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = devel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ResetDevel<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowChartSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T EnableDevel<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowChartSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T DisableDevel<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowChartSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ToggleDevel<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = !toolSettings.Devel;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.Help"/></em></p>
        ///   <p>Help for chart.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.Help"/></em></p>
        ///   <p>Help for chart.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowChartSettings.Help"/></em></p>
        ///   <p>Help for chart.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowChartSettings.Help"/></em></p>
        ///   <p>Help for chart.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowChartSettings.Help"/></em></p>
        ///   <p>Help for chart.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region InsecureSkipTlsVerify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T SetInsecureSkipTlsVerify<T>(this T toolSettings, bool? insecureSkipTlsVerify) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = insecureSkipTlsVerify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ResetInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowChartSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T EnableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowChartSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T DisableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowChartSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ToggleInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = !toolSettings.InsecureSkipTlsVerify;
            return toolSettings;
        }
        #endregion
        #region KeyFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = keyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyFile<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = null;
            return toolSettings;
        }
        #endregion
        #region Keyring
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = keyring;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T ResetKeyring<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, string password) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Repo
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = repo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetRepo<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Verify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = verify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ResetVerify<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowChartSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T EnableVerify<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowChartSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T DisableVerify<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowChartSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerify<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = !toolSettings.Verify;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Chart
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowChartSettings.Chart"/></em></p>
        /// </summary>
        [Pure]
        public static T SetChart<T>(this T toolSettings, string chart) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = chart;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowChartSettings.Chart"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetChart<T>(this T toolSettings) where T : HelmShowChartSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmShowReadmeSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmShowReadmeSettingsExtensions
    {
        #region CaFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = caFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T ResetCaFile<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = null;
            return toolSettings;
        }
        #endregion
        #region CertFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = certFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T ResetCertFile<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = null;
            return toolSettings;
        }
        #endregion
        #region Devel
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = devel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ResetDevel<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowReadmeSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T EnableDevel<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowReadmeSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T DisableDevel<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowReadmeSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ToggleDevel<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = !toolSettings.Devel;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.Help"/></em></p>
        ///   <p>Help for readme.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.Help"/></em></p>
        ///   <p>Help for readme.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowReadmeSettings.Help"/></em></p>
        ///   <p>Help for readme.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowReadmeSettings.Help"/></em></p>
        ///   <p>Help for readme.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowReadmeSettings.Help"/></em></p>
        ///   <p>Help for readme.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region InsecureSkipTlsVerify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T SetInsecureSkipTlsVerify<T>(this T toolSettings, bool? insecureSkipTlsVerify) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = insecureSkipTlsVerify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ResetInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowReadmeSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T EnableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowReadmeSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T DisableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowReadmeSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ToggleInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = !toolSettings.InsecureSkipTlsVerify;
            return toolSettings;
        }
        #endregion
        #region KeyFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = keyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyFile<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = null;
            return toolSettings;
        }
        #endregion
        #region Keyring
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = keyring;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T ResetKeyring<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, string password) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Repo
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = repo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetRepo<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Verify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = verify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ResetVerify<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowReadmeSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T EnableVerify<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowReadmeSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T DisableVerify<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowReadmeSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerify<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = !toolSettings.Verify;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Chart
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowReadmeSettings.Chart"/></em></p>
        /// </summary>
        [Pure]
        public static T SetChart<T>(this T toolSettings, string chart) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = chart;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowReadmeSettings.Chart"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetChart<T>(this T toolSettings) where T : HelmShowReadmeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmShowValuesSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmShowValuesSettingsExtensions
    {
        #region CaFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = caFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T ResetCaFile<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = null;
            return toolSettings;
        }
        #endregion
        #region CertFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = certFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T ResetCertFile<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = null;
            return toolSettings;
        }
        #endregion
        #region Devel
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = devel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ResetDevel<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowValuesSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T EnableDevel<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowValuesSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T DisableDevel<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowValuesSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ToggleDevel<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = !toolSettings.Devel;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.Help"/></em></p>
        ///   <p>Help for values.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.Help"/></em></p>
        ///   <p>Help for values.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowValuesSettings.Help"/></em></p>
        ///   <p>Help for values.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowValuesSettings.Help"/></em></p>
        ///   <p>Help for values.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowValuesSettings.Help"/></em></p>
        ///   <p>Help for values.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region InsecureSkipTlsVerify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T SetInsecureSkipTlsVerify<T>(this T toolSettings, bool? insecureSkipTlsVerify) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = insecureSkipTlsVerify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ResetInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowValuesSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T EnableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowValuesSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T DisableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowValuesSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ToggleInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = !toolSettings.InsecureSkipTlsVerify;
            return toolSettings;
        }
        #endregion
        #region KeyFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = keyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyFile<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = null;
            return toolSettings;
        }
        #endregion
        #region Keyring
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = keyring;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T ResetKeyring<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, string password) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Repo
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = repo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetRepo<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Verify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = verify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ResetVerify<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmShowValuesSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T EnableVerify<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmShowValuesSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T DisableVerify<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmShowValuesSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerify<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = !toolSettings.Verify;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Chart
        /// <summary>
        ///   <p><em>Sets <see cref="HelmShowValuesSettings.Chart"/></em></p>
        /// </summary>
        [Pure]
        public static T SetChart<T>(this T toolSettings, string chart) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = chart;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmShowValuesSettings.Chart"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetChart<T>(this T toolSettings) where T : HelmShowValuesSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmStatusSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmStatusSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmStatusSettings.Help"/></em></p>
        ///   <p>Help for status.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmStatusSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmStatusSettings.Help"/></em></p>
        ///   <p>Help for status.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmStatusSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmStatusSettings.Help"/></em></p>
        ///   <p>Help for status.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmStatusSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmStatusSettings.Help"/></em></p>
        ///   <p>Help for status.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmStatusSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmStatusSettings.Help"/></em></p>
        ///   <p>Help for status.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmStatusSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="HelmStatusSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, HelmOutputFormat output) where T : HelmStatusSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmStatusSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : HelmStatusSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Revision
        /// <summary>
        ///   <p><em>Sets <see cref="HelmStatusSettings.Revision"/></em></p>
        ///   <p>If set, display the status of the named release with revision.</p>
        /// </summary>
        [Pure]
        public static T SetRevision<T>(this T toolSettings, long? revision) where T : HelmStatusSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = revision;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmStatusSettings.Revision"/></em></p>
        ///   <p>If set, display the status of the named release with revision.</p>
        /// </summary>
        [Pure]
        public static T ResetRevision<T>(this T toolSettings) where T : HelmStatusSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Revision = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseName
        /// <summary>
        ///   <p><em>Sets <see cref="HelmStatusSettings.ReleaseName"/></em></p>
        ///   <p>The name of the release to get the status for.</p>
        /// </summary>
        [Pure]
        public static T SetReleaseName<T>(this T toolSettings, string releaseName) where T : HelmStatusSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = releaseName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmStatusSettings.ReleaseName"/></em></p>
        ///   <p>The name of the release to get the status for.</p>
        /// </summary>
        [Pure]
        public static T ResetReleaseName<T>(this T toolSettings) where T : HelmStatusSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmTemplateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmTemplateSettingsExtensions
    {
        #region ApiVersions
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.ApiVersions"/> to a new dictionary</em></p>
        ///   <p>Kubernetes api versions used for Capabilities.APIVersions.</p>
        /// </summary>
        [Pure]
        public static T SetApiVersions<T>(this T toolSettings, IDictionary<string, object> apiVersions) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiVersionsInternal = apiVersions.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmTemplateSettings.ApiVersions"/></em></p>
        ///   <p>Kubernetes api versions used for Capabilities.APIVersions.</p>
        /// </summary>
        [Pure]
        public static T ClearApiVersions<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiVersionsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmTemplateSettings.ApiVersions"/></em></p>
        ///   <p>Kubernetes api versions used for Capabilities.APIVersions.</p>
        /// </summary>
        [Pure]
        public static T AddApiVersion<T>(this T toolSettings, string apiVersionKey, object apiVersionValue) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiVersionsInternal.Add(apiVersionKey, apiVersionValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmTemplateSettings.ApiVersions"/></em></p>
        ///   <p>Kubernetes api versions used for Capabilities.APIVersions.</p>
        /// </summary>
        [Pure]
        public static T RemoveApiVersion<T>(this T toolSettings, string apiVersionKey) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiVersionsInternal.Remove(apiVersionKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmTemplateSettings.ApiVersions"/></em></p>
        ///   <p>Kubernetes api versions used for Capabilities.APIVersions.</p>
        /// </summary>
        [Pure]
        public static T SetApiVersion<T>(this T toolSettings, string apiVersionKey, object apiVersionValue) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiVersionsInternal[apiVersionKey] = apiVersionValue;
            return toolSettings;
        }
        #endregion
        #region Atomic
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Atomic"/></em></p>
        ///   <p>If set, the installation process deletes the installation on failure. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T SetAtomic<T>(this T toolSettings, bool? atomic) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = atomic;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Atomic"/></em></p>
        ///   <p>If set, the installation process deletes the installation on failure. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T ResetAtomic<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.Atomic"/></em></p>
        ///   <p>If set, the installation process deletes the installation on failure. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T EnableAtomic<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.Atomic"/></em></p>
        ///   <p>If set, the installation process deletes the installation on failure. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T DisableAtomic<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.Atomic"/></em></p>
        ///   <p>If set, the installation process deletes the installation on failure. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T ToggleAtomic<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = !toolSettings.Atomic;
            return toolSettings;
        }
        #endregion
        #region CaFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = caFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T ResetCaFile<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = null;
            return toolSettings;
        }
        #endregion
        #region CertFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = certFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T ResetCertFile<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = null;
            return toolSettings;
        }
        #endregion
        #region CreateNamespace
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.CreateNamespace"/></em></p>
        ///   <p>Create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T SetCreateNamespace<T>(this T toolSettings, bool? createNamespace) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = createNamespace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.CreateNamespace"/></em></p>
        ///   <p>Create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T ResetCreateNamespace<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.CreateNamespace"/></em></p>
        ///   <p>Create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T EnableCreateNamespace<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.CreateNamespace"/></em></p>
        ///   <p>Create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T DisableCreateNamespace<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.CreateNamespace"/></em></p>
        ///   <p>Create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T ToggleCreateNamespace<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = !toolSettings.CreateNamespace;
            return toolSettings;
        }
        #endregion
        #region DependencyUpdate
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.DependencyUpdate"/></em></p>
        ///   <p>Run helm dependency update before installing the chart.</p>
        /// </summary>
        [Pure]
        public static T SetDependencyUpdate<T>(this T toolSettings, bool? dependencyUpdate) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = dependencyUpdate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.DependencyUpdate"/></em></p>
        ///   <p>Run helm dependency update before installing the chart.</p>
        /// </summary>
        [Pure]
        public static T ResetDependencyUpdate<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.DependencyUpdate"/></em></p>
        ///   <p>Run helm dependency update before installing the chart.</p>
        /// </summary>
        [Pure]
        public static T EnableDependencyUpdate<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.DependencyUpdate"/></em></p>
        ///   <p>Run helm dependency update before installing the chart.</p>
        /// </summary>
        [Pure]
        public static T DisableDependencyUpdate<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.DependencyUpdate"/></em></p>
        ///   <p>Run helm dependency update before installing the chart.</p>
        /// </summary>
        [Pure]
        public static T ToggleDependencyUpdate<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DependencyUpdate = !toolSettings.DependencyUpdate;
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Description"/></em></p>
        ///   <p>Add a custom description.</p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Description"/></em></p>
        ///   <p>Add a custom description.</p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region Devel
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = devel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ResetDevel<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T EnableDevel<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T DisableDevel<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ToggleDevel<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = !toolSettings.Devel;
            return toolSettings;
        }
        #endregion
        #region DisableOpenapiValidation
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the installation process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T SetDisableOpenapiValidation<T>(this T toolSettings, bool? disableOpenapiValidation) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = disableOpenapiValidation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the installation process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableOpenapiValidation<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the installation process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableOpenapiValidation<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the installation process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableOpenapiValidation<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the installation process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableOpenapiValidation<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = !toolSettings.DisableOpenapiValidation;
            return toolSettings;
        }
        #endregion
        #region DryRun
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.DryRun"/></em></p>
        ///   <p>Simulate an install.</p>
        /// </summary>
        [Pure]
        public static T SetDryRun<T>(this T toolSettings, bool? dryRun) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = dryRun;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.DryRun"/></em></p>
        ///   <p>Simulate an install.</p>
        /// </summary>
        [Pure]
        public static T ResetDryRun<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.DryRun"/></em></p>
        ///   <p>Simulate an install.</p>
        /// </summary>
        [Pure]
        public static T EnableDryRun<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.DryRun"/></em></p>
        ///   <p>Simulate an install.</p>
        /// </summary>
        [Pure]
        public static T DisableDryRun<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.DryRun"/></em></p>
        ///   <p>Simulate an install.</p>
        /// </summary>
        [Pure]
        public static T ToggleDryRun<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = !toolSettings.DryRun;
            return toolSettings;
        }
        #endregion
        #region GenerateName
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.GenerateName"/></em></p>
        ///   <p>Generate the name (and omit the NAME parameter).</p>
        /// </summary>
        [Pure]
        public static T SetGenerateName<T>(this T toolSettings, bool? generateName) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateName = generateName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.GenerateName"/></em></p>
        ///   <p>Generate the name (and omit the NAME parameter).</p>
        /// </summary>
        [Pure]
        public static T ResetGenerateName<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateName = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.GenerateName"/></em></p>
        ///   <p>Generate the name (and omit the NAME parameter).</p>
        /// </summary>
        [Pure]
        public static T EnableGenerateName<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateName = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.GenerateName"/></em></p>
        ///   <p>Generate the name (and omit the NAME parameter).</p>
        /// </summary>
        [Pure]
        public static T DisableGenerateName<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateName = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.GenerateName"/></em></p>
        ///   <p>Generate the name (and omit the NAME parameter).</p>
        /// </summary>
        [Pure]
        public static T ToggleGenerateName<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GenerateName = !toolSettings.GenerateName;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Help"/></em></p>
        ///   <p>Help for template.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Help"/></em></p>
        ///   <p>Help for template.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.Help"/></em></p>
        ///   <p>Help for template.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.Help"/></em></p>
        ///   <p>Help for template.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.Help"/></em></p>
        ///   <p>Help for template.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region IncludeCrds
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.IncludeCrds"/></em></p>
        ///   <p>Include CRDs in the templated output.</p>
        /// </summary>
        [Pure]
        public static T SetIncludeCrds<T>(this T toolSettings, bool? includeCrds) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeCrds = includeCrds;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.IncludeCrds"/></em></p>
        ///   <p>Include CRDs in the templated output.</p>
        /// </summary>
        [Pure]
        public static T ResetIncludeCrds<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeCrds = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.IncludeCrds"/></em></p>
        ///   <p>Include CRDs in the templated output.</p>
        /// </summary>
        [Pure]
        public static T EnableIncludeCrds<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeCrds = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.IncludeCrds"/></em></p>
        ///   <p>Include CRDs in the templated output.</p>
        /// </summary>
        [Pure]
        public static T DisableIncludeCrds<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeCrds = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.IncludeCrds"/></em></p>
        ///   <p>Include CRDs in the templated output.</p>
        /// </summary>
        [Pure]
        public static T ToggleIncludeCrds<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeCrds = !toolSettings.IncludeCrds;
            return toolSettings;
        }
        #endregion
        #region InsecureSkipTlsVerify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T SetInsecureSkipTlsVerify<T>(this T toolSettings, bool? insecureSkipTlsVerify) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = insecureSkipTlsVerify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ResetInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T EnableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T DisableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ToggleInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = !toolSettings.InsecureSkipTlsVerify;
            return toolSettings;
        }
        #endregion
        #region IsUpgrade
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.IsUpgrade"/></em></p>
        ///   <p>Set .Release.IsUpgrade instead of .Release.IsInstall.</p>
        /// </summary>
        [Pure]
        public static T SetIsUpgrade<T>(this T toolSettings, bool? isUpgrade) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IsUpgrade = isUpgrade;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.IsUpgrade"/></em></p>
        ///   <p>Set .Release.IsUpgrade instead of .Release.IsInstall.</p>
        /// </summary>
        [Pure]
        public static T ResetIsUpgrade<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IsUpgrade = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.IsUpgrade"/></em></p>
        ///   <p>Set .Release.IsUpgrade instead of .Release.IsInstall.</p>
        /// </summary>
        [Pure]
        public static T EnableIsUpgrade<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IsUpgrade = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.IsUpgrade"/></em></p>
        ///   <p>Set .Release.IsUpgrade instead of .Release.IsInstall.</p>
        /// </summary>
        [Pure]
        public static T DisableIsUpgrade<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IsUpgrade = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.IsUpgrade"/></em></p>
        ///   <p>Set .Release.IsUpgrade instead of .Release.IsInstall.</p>
        /// </summary>
        [Pure]
        public static T ToggleIsUpgrade<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IsUpgrade = !toolSettings.IsUpgrade;
            return toolSettings;
        }
        #endregion
        #region KeyFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = keyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyFile<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = null;
            return toolSettings;
        }
        #endregion
        #region Keyring
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = keyring;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T ResetKeyring<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = null;
            return toolSettings;
        }
        #endregion
        #region NameTemplate
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.NameTemplate"/></em></p>
        ///   <p>Specify template used to name the release.</p>
        /// </summary>
        [Pure]
        public static T SetNameTemplate<T>(this T toolSettings, string nameTemplate) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NameTemplate = nameTemplate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.NameTemplate"/></em></p>
        ///   <p>Specify template used to name the release.</p>
        /// </summary>
        [Pure]
        public static T ResetNameTemplate<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NameTemplate = null;
            return toolSettings;
        }
        #endregion
        #region NoHooks
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during install.</p>
        /// </summary>
        [Pure]
        public static T SetNoHooks<T>(this T toolSettings, bool? noHooks) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = noHooks;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during install.</p>
        /// </summary>
        [Pure]
        public static T ResetNoHooks<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during install.</p>
        /// </summary>
        [Pure]
        public static T EnableNoHooks<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during install.</p>
        /// </summary>
        [Pure]
        public static T DisableNoHooks<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during install.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoHooks<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = !toolSettings.NoHooks;
            return toolSettings;
        }
        #endregion
        #region OutputDir
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.OutputDir"/></em></p>
        ///   <p>Writes the executed templates to files in output-dir instead of stdout.</p>
        /// </summary>
        [Pure]
        public static T SetOutputDir<T>(this T toolSettings, string outputDir) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDir = outputDir;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.OutputDir"/></em></p>
        ///   <p>Writes the executed templates to files in output-dir instead of stdout.</p>
        /// </summary>
        [Pure]
        public static T ResetOutputDir<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.OutputDir = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, string password) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region PostRenderer
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.PostRenderer"/></em></p>
        ///   <p>The path to an executable to be used for post rendering. If it exists in $PATH, the binary will be used, otherwise it will try to look for the executable at the given path (default exec).</p>
        /// </summary>
        [Pure]
        public static T SetPostRenderer<T>(this T toolSettings, string postRenderer) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostRenderer = postRenderer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.PostRenderer"/></em></p>
        ///   <p>The path to an executable to be used for post rendering. If it exists in $PATH, the binary will be used, otherwise it will try to look for the executable at the given path (default exec).</p>
        /// </summary>
        [Pure]
        public static T ResetPostRenderer<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostRenderer = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseName
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.ReleaseName"/></em></p>
        ///   <p>Use release name in the output-dir path.</p>
        /// </summary>
        [Pure]
        public static T SetReleaseName<T>(this T toolSettings, bool? releaseName) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = releaseName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.ReleaseName"/></em></p>
        ///   <p>Use release name in the output-dir path.</p>
        /// </summary>
        [Pure]
        public static T ResetReleaseName<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.ReleaseName"/></em></p>
        ///   <p>Use release name in the output-dir path.</p>
        /// </summary>
        [Pure]
        public static T EnableReleaseName<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.ReleaseName"/></em></p>
        ///   <p>Use release name in the output-dir path.</p>
        /// </summary>
        [Pure]
        public static T DisableReleaseName<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.ReleaseName"/></em></p>
        ///   <p>Use release name in the output-dir path.</p>
        /// </summary>
        [Pure]
        public static T ToggleReleaseName<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseName = !toolSettings.ReleaseName;
            return toolSettings;
        }
        #endregion
        #region RenderSubchartNotes
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T SetRenderSubchartNotes<T>(this T toolSettings, bool? renderSubchartNotes) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = renderSubchartNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T ResetRenderSubchartNotes<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T EnableRenderSubchartNotes<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T DisableRenderSubchartNotes<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T ToggleRenderSubchartNotes<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = !toolSettings.RenderSubchartNotes;
            return toolSettings;
        }
        #endregion
        #region Replace
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Replace"/></em></p>
        ///   <p>Re-use the given name, only if that name is a deleted release which remains in the history. This is unsafe in production.</p>
        /// </summary>
        [Pure]
        public static T SetReplace<T>(this T toolSettings, bool? replace) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Replace = replace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Replace"/></em></p>
        ///   <p>Re-use the given name, only if that name is a deleted release which remains in the history. This is unsafe in production.</p>
        /// </summary>
        [Pure]
        public static T ResetReplace<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Replace = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.Replace"/></em></p>
        ///   <p>Re-use the given name, only if that name is a deleted release which remains in the history. This is unsafe in production.</p>
        /// </summary>
        [Pure]
        public static T EnableReplace<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Replace = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.Replace"/></em></p>
        ///   <p>Re-use the given name, only if that name is a deleted release which remains in the history. This is unsafe in production.</p>
        /// </summary>
        [Pure]
        public static T DisableReplace<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Replace = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.Replace"/></em></p>
        ///   <p>Re-use the given name, only if that name is a deleted release which remains in the history. This is unsafe in production.</p>
        /// </summary>
        [Pure]
        public static T ToggleReplace<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Replace = !toolSettings.Replace;
            return toolSettings;
        }
        #endregion
        #region Repo
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = repo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetRepo<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = null;
            return toolSettings;
        }
        #endregion
        #region Set
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Set"/> to a new dictionary</em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSet<T>(this T toolSettings, IDictionary<string, object> set) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal = set.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmTemplateSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T ClearSet<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmTemplateSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T AddSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal.Add(setKey, setValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmTemplateSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T RemoveSet<T>(this T toolSettings, string setKey) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal.Remove(setKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmTemplateSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal[setKey] = setValue;
            return toolSettings;
        }
        #endregion
        #region SetFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.SetFile"/> to a new dictionary</em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T SetSetFile<T>(this T toolSettings, IDictionary<string, object> setFile) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal = setFile.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmTemplateSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T ClearSetFile<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmTemplateSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T AddSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal.Add(setFileKey, setFileValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmTemplateSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T RemoveSetFile<T>(this T toolSettings, string setFileKey) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal.Remove(setFileKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmTemplateSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T SetSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal[setFileKey] = setFileValue;
            return toolSettings;
        }
        #endregion
        #region SetString
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.SetString"/> to a new dictionary</em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSetString<T>(this T toolSettings, IDictionary<string, object> setString) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal = setString.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmTemplateSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T ClearSetString<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmTemplateSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T AddSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal.Add(setStringKey, setStringValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmTemplateSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T RemoveSetString<T>(this T toolSettings, string setStringKey) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal.Remove(setStringKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmTemplateSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal[setStringKey] = setStringValue;
            return toolSettings;
        }
        #endregion
        #region ShowOnly
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.ShowOnly"/> to a new dictionary</em></p>
        ///   <p>Only show manifests rendered from the given templates.</p>
        /// </summary>
        [Pure]
        public static T SetShowOnly<T>(this T toolSettings, IDictionary<string, object> showOnly) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowOnlyInternal = showOnly.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmTemplateSettings.ShowOnly"/></em></p>
        ///   <p>Only show manifests rendered from the given templates.</p>
        /// </summary>
        [Pure]
        public static T ClearShowOnly<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowOnlyInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmTemplateSettings.ShowOnly"/></em></p>
        ///   <p>Only show manifests rendered from the given templates.</p>
        /// </summary>
        [Pure]
        public static T AddShowOnly<T>(this T toolSettings, string showOnlyKey, object showOnlyValue) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowOnlyInternal.Add(showOnlyKey, showOnlyValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmTemplateSettings.ShowOnly"/></em></p>
        ///   <p>Only show manifests rendered from the given templates.</p>
        /// </summary>
        [Pure]
        public static T RemoveShowOnly<T>(this T toolSettings, string showOnlyKey) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowOnlyInternal.Remove(showOnlyKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmTemplateSettings.ShowOnly"/></em></p>
        ///   <p>Only show manifests rendered from the given templates.</p>
        /// </summary>
        [Pure]
        public static T SetShowOnly<T>(this T toolSettings, string showOnlyKey, object showOnlyValue) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ShowOnlyInternal[showOnlyKey] = showOnlyValue;
            return toolSettings;
        }
        #endregion
        #region SkipCrds
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed. By default, CRDs are installed if not already present.</p>
        /// </summary>
        [Pure]
        public static T SetSkipCrds<T>(this T toolSettings, bool? skipCrds) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = skipCrds;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed. By default, CRDs are installed if not already present.</p>
        /// </summary>
        [Pure]
        public static T ResetSkipCrds<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed. By default, CRDs are installed if not already present.</p>
        /// </summary>
        [Pure]
        public static T EnableSkipCrds<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed. By default, CRDs are installed if not already present.</p>
        /// </summary>
        [Pure]
        public static T DisableSkipCrds<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed. By default, CRDs are installed if not already present.</p>
        /// </summary>
        [Pure]
        public static T ToggleSkipCrds<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = !toolSettings.SkipCrds;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Timeout"/></em></p>
        ///   <p>Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, string timeout) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Timeout"/></em></p>
        ///   <p>Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Validate
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Validate"/></em></p>
        ///   <p>Validate your manifests against the Kubernetes cluster you are currently pointing at. This is the same validation performed on an install.</p>
        /// </summary>
        [Pure]
        public static T SetValidate<T>(this T toolSettings, bool? validate) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Validate = validate;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Validate"/></em></p>
        ///   <p>Validate your manifests against the Kubernetes cluster you are currently pointing at. This is the same validation performed on an install.</p>
        /// </summary>
        [Pure]
        public static T ResetValidate<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Validate = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.Validate"/></em></p>
        ///   <p>Validate your manifests against the Kubernetes cluster you are currently pointing at. This is the same validation performed on an install.</p>
        /// </summary>
        [Pure]
        public static T EnableValidate<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Validate = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.Validate"/></em></p>
        ///   <p>Validate your manifests against the Kubernetes cluster you are currently pointing at. This is the same validation performed on an install.</p>
        /// </summary>
        [Pure]
        public static T DisableValidate<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Validate = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.Validate"/></em></p>
        ///   <p>Validate your manifests against the Kubernetes cluster you are currently pointing at. This is the same validation performed on an install.</p>
        /// </summary>
        [Pure]
        public static T ToggleValidate<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Validate = !toolSettings.Validate;
            return toolSettings;
        }
        #endregion
        #region Values
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Values"/> to a new list</em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T SetValues<T>(this T toolSettings, params string[] values) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal = values.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Values"/> to a new list</em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T SetValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal = values.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmTemplateSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T AddValues<T>(this T toolSettings, params string[] values) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal.AddRange(values);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmTemplateSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T AddValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal.AddRange(values);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmTemplateSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T ClearValues<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmTemplateSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T RemoveValues<T>(this T toolSettings, params string[] values) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(values);
            toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmTemplateSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T RemoveValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(values);
            toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = verify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ResetVerify<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T EnableVerify<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T DisableVerify<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerify<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = !toolSettings.Verify;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Wait
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T SetWait<T>(this T toolSettings, bool? wait) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = wait;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T ResetWait<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTemplateSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T EnableWait<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTemplateSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T DisableWait<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTemplateSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T ToggleWait<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = !toolSettings.Wait;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Name"/></em></p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Name"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Chart
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTemplateSettings.Chart"/></em></p>
        /// </summary>
        [Pure]
        public static T SetChart<T>(this T toolSettings, string chart) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = chart;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTemplateSettings.Chart"/></em></p>
        /// </summary>
        [Pure]
        public static T ResetChart<T>(this T toolSettings) where T : HelmTemplateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmTestSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmTestSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTestSettings.Help"/></em></p>
        ///   <p>Help for test.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTestSettings.Help"/></em></p>
        ///   <p>Help for test.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTestSettings.Help"/></em></p>
        ///   <p>Help for test.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTestSettings.Help"/></em></p>
        ///   <p>Help for test.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTestSettings.Help"/></em></p>
        ///   <p>Help for test.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Logs
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTestSettings.Logs"/></em></p>
        ///   <p>Dump the logs from test pods (this runs after all tests are complete, but before any cleanup).</p>
        /// </summary>
        [Pure]
        public static T SetLogs<T>(this T toolSettings, bool? logs) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logs = logs;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTestSettings.Logs"/></em></p>
        ///   <p>Dump the logs from test pods (this runs after all tests are complete, but before any cleanup).</p>
        /// </summary>
        [Pure]
        public static T ResetLogs<T>(this T toolSettings) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logs = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmTestSettings.Logs"/></em></p>
        ///   <p>Dump the logs from test pods (this runs after all tests are complete, but before any cleanup).</p>
        /// </summary>
        [Pure]
        public static T EnableLogs<T>(this T toolSettings) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logs = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmTestSettings.Logs"/></em></p>
        ///   <p>Dump the logs from test pods (this runs after all tests are complete, but before any cleanup).</p>
        /// </summary>
        [Pure]
        public static T DisableLogs<T>(this T toolSettings) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logs = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmTestSettings.Logs"/></em></p>
        ///   <p>Dump the logs from test pods (this runs after all tests are complete, but before any cleanup).</p>
        /// </summary>
        [Pure]
        public static T ToggleLogs<T>(this T toolSettings) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logs = !toolSettings.Logs;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTestSettings.Timeout"/></em></p>
        ///   <p>Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, string timeout) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTestSettings.Timeout"/></em></p>
        ///   <p>Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Release
        /// <summary>
        ///   <p><em>Sets <see cref="HelmTestSettings.Release"/></em></p>
        ///   <p>The name of the release to test.</p>
        /// </summary>
        [Pure]
        public static T SetRelease<T>(this T toolSettings, string release) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Release = release;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmTestSettings.Release"/></em></p>
        ///   <p>The name of the release to test.</p>
        /// </summary>
        [Pure]
        public static T ResetRelease<T>(this T toolSettings) where T : HelmTestSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Release = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmUninstallSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmUninstallSettingsExtensions
    {
        #region Description
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUninstallSettings.Description"/></em></p>
        ///   <p>Add a custom description.</p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUninstallSettings.Description"/></em></p>
        ///   <p>Add a custom description.</p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region DryRun
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUninstallSettings.DryRun"/></em></p>
        ///   <p>Simulate a uninstall.</p>
        /// </summary>
        [Pure]
        public static T SetDryRun<T>(this T toolSettings, bool? dryRun) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = dryRun;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUninstallSettings.DryRun"/></em></p>
        ///   <p>Simulate a uninstall.</p>
        /// </summary>
        [Pure]
        public static T ResetDryRun<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUninstallSettings.DryRun"/></em></p>
        ///   <p>Simulate a uninstall.</p>
        /// </summary>
        [Pure]
        public static T EnableDryRun<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUninstallSettings.DryRun"/></em></p>
        ///   <p>Simulate a uninstall.</p>
        /// </summary>
        [Pure]
        public static T DisableDryRun<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUninstallSettings.DryRun"/></em></p>
        ///   <p>Simulate a uninstall.</p>
        /// </summary>
        [Pure]
        public static T ToggleDryRun<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = !toolSettings.DryRun;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUninstallSettings.Help"/></em></p>
        ///   <p>Help for uninstall.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUninstallSettings.Help"/></em></p>
        ///   <p>Help for uninstall.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUninstallSettings.Help"/></em></p>
        ///   <p>Help for uninstall.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUninstallSettings.Help"/></em></p>
        ///   <p>Help for uninstall.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUninstallSettings.Help"/></em></p>
        ///   <p>Help for uninstall.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region KeepHistory
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUninstallSettings.KeepHistory"/></em></p>
        ///   <p>Remove all associated resources and mark the release as deleted, but retain the release history.</p>
        /// </summary>
        [Pure]
        public static T SetKeepHistory<T>(this T toolSettings, bool? keepHistory) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepHistory = keepHistory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUninstallSettings.KeepHistory"/></em></p>
        ///   <p>Remove all associated resources and mark the release as deleted, but retain the release history.</p>
        /// </summary>
        [Pure]
        public static T ResetKeepHistory<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepHistory = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUninstallSettings.KeepHistory"/></em></p>
        ///   <p>Remove all associated resources and mark the release as deleted, but retain the release history.</p>
        /// </summary>
        [Pure]
        public static T EnableKeepHistory<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepHistory = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUninstallSettings.KeepHistory"/></em></p>
        ///   <p>Remove all associated resources and mark the release as deleted, but retain the release history.</p>
        /// </summary>
        [Pure]
        public static T DisableKeepHistory<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepHistory = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUninstallSettings.KeepHistory"/></em></p>
        ///   <p>Remove all associated resources and mark the release as deleted, but retain the release history.</p>
        /// </summary>
        [Pure]
        public static T ToggleKeepHistory<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeepHistory = !toolSettings.KeepHistory;
            return toolSettings;
        }
        #endregion
        #region NoHooks
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUninstallSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during uninstallation.</p>
        /// </summary>
        [Pure]
        public static T SetNoHooks<T>(this T toolSettings, bool? noHooks) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = noHooks;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUninstallSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during uninstallation.</p>
        /// </summary>
        [Pure]
        public static T ResetNoHooks<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUninstallSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during uninstallation.</p>
        /// </summary>
        [Pure]
        public static T EnableNoHooks<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUninstallSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during uninstallation.</p>
        /// </summary>
        [Pure]
        public static T DisableNoHooks<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUninstallSettings.NoHooks"/></em></p>
        ///   <p>Prevent hooks from running during uninstallation.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoHooks<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = !toolSettings.NoHooks;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUninstallSettings.Timeout"/></em></p>
        ///   <p>Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, string timeout) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUninstallSettings.Timeout"/></em></p>
        ///   <p>Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region ReleaseNames
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUninstallSettings.ReleaseNames"/> to a new list</em></p>
        /// </summary>
        [Pure]
        public static T SetReleaseNames<T>(this T toolSettings, params string[] releaseNames) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNamesInternal = releaseNames.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUninstallSettings.ReleaseNames"/> to a new list</em></p>
        /// </summary>
        [Pure]
        public static T SetReleaseNames<T>(this T toolSettings, IEnumerable<string> releaseNames) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNamesInternal = releaseNames.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmUninstallSettings.ReleaseNames"/></em></p>
        /// </summary>
        [Pure]
        public static T AddReleaseNames<T>(this T toolSettings, params string[] releaseNames) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNamesInternal.AddRange(releaseNames);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmUninstallSettings.ReleaseNames"/></em></p>
        /// </summary>
        [Pure]
        public static T AddReleaseNames<T>(this T toolSettings, IEnumerable<string> releaseNames) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNamesInternal.AddRange(releaseNames);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmUninstallSettings.ReleaseNames"/></em></p>
        /// </summary>
        [Pure]
        public static T ClearReleaseNames<T>(this T toolSettings) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReleaseNamesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmUninstallSettings.ReleaseNames"/></em></p>
        /// </summary>
        [Pure]
        public static T RemoveReleaseNames<T>(this T toolSettings, params string[] releaseNames) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(releaseNames);
            toolSettings.ReleaseNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmUninstallSettings.ReleaseNames"/></em></p>
        /// </summary>
        [Pure]
        public static T RemoveReleaseNames<T>(this T toolSettings, IEnumerable<string> releaseNames) where T : HelmUninstallSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(releaseNames);
            toolSettings.ReleaseNamesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmUpgradeSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmUpgradeSettingsExtensions
    {
        #region Atomic
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Atomic"/></em></p>
        ///   <p>If set, upgrade process rolls back changes made in case of failed upgrade. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T SetAtomic<T>(this T toolSettings, bool? atomic) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = atomic;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Atomic"/></em></p>
        ///   <p>If set, upgrade process rolls back changes made in case of failed upgrade. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T ResetAtomic<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.Atomic"/></em></p>
        ///   <p>If set, upgrade process rolls back changes made in case of failed upgrade. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T EnableAtomic<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.Atomic"/></em></p>
        ///   <p>If set, upgrade process rolls back changes made in case of failed upgrade. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T DisableAtomic<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Atomic"/></em></p>
        ///   <p>If set, upgrade process rolls back changes made in case of failed upgrade. The --wait flag will be set automatically if --atomic is used.</p>
        /// </summary>
        [Pure]
        public static T ToggleAtomic<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Atomic = !toolSettings.Atomic;
            return toolSettings;
        }
        #endregion
        #region CaFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T SetCaFile<T>(this T toolSettings, string caFile) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = caFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.CaFile"/></em></p>
        ///   <p>Verify certificates of HTTPS-enabled servers using this CA bundle.</p>
        /// </summary>
        [Pure]
        public static T ResetCaFile<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CaFile = null;
            return toolSettings;
        }
        #endregion
        #region CertFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T SetCertFile<T>(this T toolSettings, string certFile) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = certFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.CertFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL certificate file.</p>
        /// </summary>
        [Pure]
        public static T ResetCertFile<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CertFile = null;
            return toolSettings;
        }
        #endregion
        #region CleanupOnFail
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.CleanupOnFail"/></em></p>
        ///   <p>Allow deletion of new resources created in this upgrade when upgrade fails.</p>
        /// </summary>
        [Pure]
        public static T SetCleanupOnFail<T>(this T toolSettings, bool? cleanupOnFail) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupOnFail = cleanupOnFail;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.CleanupOnFail"/></em></p>
        ///   <p>Allow deletion of new resources created in this upgrade when upgrade fails.</p>
        /// </summary>
        [Pure]
        public static T ResetCleanupOnFail<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupOnFail = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.CleanupOnFail"/></em></p>
        ///   <p>Allow deletion of new resources created in this upgrade when upgrade fails.</p>
        /// </summary>
        [Pure]
        public static T EnableCleanupOnFail<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupOnFail = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.CleanupOnFail"/></em></p>
        ///   <p>Allow deletion of new resources created in this upgrade when upgrade fails.</p>
        /// </summary>
        [Pure]
        public static T DisableCleanupOnFail<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupOnFail = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.CleanupOnFail"/></em></p>
        ///   <p>Allow deletion of new resources created in this upgrade when upgrade fails.</p>
        /// </summary>
        [Pure]
        public static T ToggleCleanupOnFail<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CleanupOnFail = !toolSettings.CleanupOnFail;
            return toolSettings;
        }
        #endregion
        #region CreateNamespace
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.CreateNamespace"/></em></p>
        ///   <p>If --install is set, create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T SetCreateNamespace<T>(this T toolSettings, bool? createNamespace) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = createNamespace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.CreateNamespace"/></em></p>
        ///   <p>If --install is set, create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T ResetCreateNamespace<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.CreateNamespace"/></em></p>
        ///   <p>If --install is set, create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T EnableCreateNamespace<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.CreateNamespace"/></em></p>
        ///   <p>If --install is set, create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T DisableCreateNamespace<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.CreateNamespace"/></em></p>
        ///   <p>If --install is set, create the release namespace if not present.</p>
        /// </summary>
        [Pure]
        public static T ToggleCreateNamespace<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CreateNamespace = !toolSettings.CreateNamespace;
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Description"/></em></p>
        ///   <p>Add a custom description.</p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Description"/></em></p>
        ///   <p>Add a custom description.</p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region Devel
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T SetDevel<T>(this T toolSettings, bool? devel) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = devel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ResetDevel<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T EnableDevel<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T DisableDevel<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Devel"/></em></p>
        ///   <p>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ToggleDevel<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Devel = !toolSettings.Devel;
            return toolSettings;
        }
        #endregion
        #region DisableOpenapiValidation
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the upgrade process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T SetDisableOpenapiValidation<T>(this T toolSettings, bool? disableOpenapiValidation) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = disableOpenapiValidation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the upgrade process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T ResetDisableOpenapiValidation<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the upgrade process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T EnableDisableOpenapiValidation<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the upgrade process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T DisableDisableOpenapiValidation<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.DisableOpenapiValidation"/></em></p>
        ///   <p>If set, the upgrade process will not validate rendered templates against the Kubernetes OpenAPI Schema.</p>
        /// </summary>
        [Pure]
        public static T ToggleDisableOpenapiValidation<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DisableOpenapiValidation = !toolSettings.DisableOpenapiValidation;
            return toolSettings;
        }
        #endregion
        #region DryRun
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.DryRun"/></em></p>
        ///   <p>Simulate an upgrade.</p>
        /// </summary>
        [Pure]
        public static T SetDryRun<T>(this T toolSettings, bool? dryRun) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = dryRun;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.DryRun"/></em></p>
        ///   <p>Simulate an upgrade.</p>
        /// </summary>
        [Pure]
        public static T ResetDryRun<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.DryRun"/></em></p>
        ///   <p>Simulate an upgrade.</p>
        /// </summary>
        [Pure]
        public static T EnableDryRun<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.DryRun"/></em></p>
        ///   <p>Simulate an upgrade.</p>
        /// </summary>
        [Pure]
        public static T DisableDryRun<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.DryRun"/></em></p>
        ///   <p>Simulate an upgrade.</p>
        /// </summary>
        [Pure]
        public static T ToggleDryRun<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = !toolSettings.DryRun;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Force"/></em></p>
        ///   <p>Force resource updates through a replacement strategy.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Force"/></em></p>
        ///   <p>Force resource updates through a replacement strategy.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.Force"/></em></p>
        ///   <p>Force resource updates through a replacement strategy.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.Force"/></em></p>
        ///   <p>Force resource updates through a replacement strategy.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Force"/></em></p>
        ///   <p>Force resource updates through a replacement strategy.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Help"/></em></p>
        ///   <p>Help for upgrade.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Help"/></em></p>
        ///   <p>Help for upgrade.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.Help"/></em></p>
        ///   <p>Help for upgrade.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.Help"/></em></p>
        ///   <p>Help for upgrade.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Help"/></em></p>
        ///   <p>Help for upgrade.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region HistoryMax
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.HistoryMax"/></em></p>
        ///   <p>Limit the maximum number of revisions saved per release. Use 0 for no limit (default 10).</p>
        /// </summary>
        [Pure]
        public static T SetHistoryMax<T>(this T toolSettings, long? historyMax) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HistoryMax = historyMax;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.HistoryMax"/></em></p>
        ///   <p>Limit the maximum number of revisions saved per release. Use 0 for no limit (default 10).</p>
        /// </summary>
        [Pure]
        public static T ResetHistoryMax<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HistoryMax = null;
            return toolSettings;
        }
        #endregion
        #region InsecureSkipTlsVerify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T SetInsecureSkipTlsVerify<T>(this T toolSettings, bool? insecureSkipTlsVerify) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = insecureSkipTlsVerify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ResetInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T EnableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T DisableInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.InsecureSkipTlsVerify"/></em></p>
        ///   <p>Skip tls certificate checks for the chart download.</p>
        /// </summary>
        [Pure]
        public static T ToggleInsecureSkipTlsVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InsecureSkipTlsVerify = !toolSettings.InsecureSkipTlsVerify;
            return toolSettings;
        }
        #endregion
        #region Install
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Install"/></em></p>
        ///   <p>If a release by this name doesn't already exist, run an install.</p>
        /// </summary>
        [Pure]
        public static T SetInstall<T>(this T toolSettings, bool? install) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Install = install;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Install"/></em></p>
        ///   <p>If a release by this name doesn't already exist, run an install.</p>
        /// </summary>
        [Pure]
        public static T ResetInstall<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Install = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.Install"/></em></p>
        ///   <p>If a release by this name doesn't already exist, run an install.</p>
        /// </summary>
        [Pure]
        public static T EnableInstall<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Install = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.Install"/></em></p>
        ///   <p>If a release by this name doesn't already exist, run an install.</p>
        /// </summary>
        [Pure]
        public static T DisableInstall<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Install = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Install"/></em></p>
        ///   <p>If a release by this name doesn't already exist, run an install.</p>
        /// </summary>
        [Pure]
        public static T ToggleInstall<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Install = !toolSettings.Install;
            return toolSettings;
        }
        #endregion
        #region KeyFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = keyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.KeyFile"/></em></p>
        ///   <p>Identify HTTPS client using this SSL key file.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyFile<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = null;
            return toolSettings;
        }
        #endregion
        #region Keyring
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = keyring;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Keyring"/></em></p>
        ///   <p>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T ResetKeyring<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = null;
            return toolSettings;
        }
        #endregion
        #region NoHooks
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.NoHooks"/></em></p>
        ///   <p>Disable pre/post upgrade hooks.</p>
        /// </summary>
        [Pure]
        public static T SetNoHooks<T>(this T toolSettings, bool? noHooks) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = noHooks;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.NoHooks"/></em></p>
        ///   <p>Disable pre/post upgrade hooks.</p>
        /// </summary>
        [Pure]
        public static T ResetNoHooks<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.NoHooks"/></em></p>
        ///   <p>Disable pre/post upgrade hooks.</p>
        /// </summary>
        [Pure]
        public static T EnableNoHooks<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.NoHooks"/></em></p>
        ///   <p>Disable pre/post upgrade hooks.</p>
        /// </summary>
        [Pure]
        public static T DisableNoHooks<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.NoHooks"/></em></p>
        ///   <p>Disable pre/post upgrade hooks.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoHooks<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoHooks = !toolSettings.NoHooks;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, HelmOutputFormat output) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Output"/></em></p>
        ///   <p>Prints the output in the specified format. Allowed values: table, json, yaml (default table).</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetPassword<T>(this T toolSettings, string password) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Password"/></em></p>
        ///   <p>Chart repository password where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetPassword<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region PostRenderer
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.PostRenderer"/></em></p>
        ///   <p>The path to an executable to be used for post rendering. If it exists in $PATH, the binary will be used, otherwise it will try to look for the executable at the given path (default exec).</p>
        /// </summary>
        [Pure]
        public static T SetPostRenderer<T>(this T toolSettings, string postRenderer) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostRenderer = postRenderer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.PostRenderer"/></em></p>
        ///   <p>The path to an executable to be used for post rendering. If it exists in $PATH, the binary will be used, otherwise it will try to look for the executable at the given path (default exec).</p>
        /// </summary>
        [Pure]
        public static T ResetPostRenderer<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PostRenderer = null;
            return toolSettings;
        }
        #endregion
        #region RenderSubchartNotes
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T SetRenderSubchartNotes<T>(this T toolSettings, bool? renderSubchartNotes) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = renderSubchartNotes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T ResetRenderSubchartNotes<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T EnableRenderSubchartNotes<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T DisableRenderSubchartNotes<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></em></p>
        ///   <p>If set, render subchart notes along with the parent.</p>
        /// </summary>
        [Pure]
        public static T ToggleRenderSubchartNotes<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenderSubchartNotes = !toolSettings.RenderSubchartNotes;
            return toolSettings;
        }
        #endregion
        #region Repo
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetRepo<T>(this T toolSettings, string repo) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = repo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Repo"/></em></p>
        ///   <p>Chart repository url where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetRepo<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Repo = null;
            return toolSettings;
        }
        #endregion
        #region ResetValues
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.ResetValues"/></em></p>
        ///   <p>When upgrading, reset the values to the ones built into the chart.</p>
        /// </summary>
        [Pure]
        public static T SetResetValues<T>(this T toolSettings, bool? resetValues) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResetValues = resetValues;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.ResetValues"/></em></p>
        ///   <p>When upgrading, reset the values to the ones built into the chart.</p>
        /// </summary>
        [Pure]
        public static T ResetResetValues<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResetValues = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.ResetValues"/></em></p>
        ///   <p>When upgrading, reset the values to the ones built into the chart.</p>
        /// </summary>
        [Pure]
        public static T EnableResetValues<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResetValues = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.ResetValues"/></em></p>
        ///   <p>When upgrading, reset the values to the ones built into the chart.</p>
        /// </summary>
        [Pure]
        public static T DisableResetValues<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResetValues = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.ResetValues"/></em></p>
        ///   <p>When upgrading, reset the values to the ones built into the chart.</p>
        /// </summary>
        [Pure]
        public static T ToggleResetValues<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ResetValues = !toolSettings.ResetValues;
            return toolSettings;
        }
        #endregion
        #region ReuseValues
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.ReuseValues"/></em></p>
        ///   <p>When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T SetReuseValues<T>(this T toolSettings, bool? reuseValues) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseValues = reuseValues;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.ReuseValues"/></em></p>
        ///   <p>When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ResetReuseValues<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseValues = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.ReuseValues"/></em></p>
        ///   <p>When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T EnableReuseValues<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseValues = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.ReuseValues"/></em></p>
        ///   <p>When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T DisableReuseValues<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseValues = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.ReuseValues"/></em></p>
        ///   <p>When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.</p>
        /// </summary>
        [Pure]
        public static T ToggleReuseValues<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ReuseValues = !toolSettings.ReuseValues;
            return toolSettings;
        }
        #endregion
        #region Set
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Set"/> to a new dictionary</em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSet<T>(this T toolSettings, IDictionary<string, object> set) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal = set.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmUpgradeSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T ClearSet<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmUpgradeSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T AddSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal.Add(setKey, setValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmUpgradeSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T RemoveSet<T>(this T toolSettings, string setKey) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal.Remove(setKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmUpgradeSettings.Set"/></em></p>
        ///   <p>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSet<T>(this T toolSettings, string setKey, object setValue) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetInternal[setKey] = setValue;
            return toolSettings;
        }
        #endregion
        #region SetFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.SetFile"/> to a new dictionary</em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T SetSetFile<T>(this T toolSettings, IDictionary<string, object> setFile) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal = setFile.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmUpgradeSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T ClearSetFile<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmUpgradeSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T AddSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal.Add(setFileKey, setFileValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmUpgradeSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T RemoveSetFile<T>(this T toolSettings, string setFileKey) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal.Remove(setFileKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmUpgradeSettings.SetFile"/></em></p>
        ///   <p>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</p>
        /// </summary>
        [Pure]
        public static T SetSetFile<T>(this T toolSettings, string setFileKey, object setFileValue) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetFileInternal[setFileKey] = setFileValue;
            return toolSettings;
        }
        #endregion
        #region SetString
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.SetString"/> to a new dictionary</em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSetString<T>(this T toolSettings, IDictionary<string, object> setString) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal = setString.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmUpgradeSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T ClearSetString<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmUpgradeSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T AddSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal.Add(setStringKey, setStringValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmUpgradeSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T RemoveSetString<T>(this T toolSettings, string setStringKey) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal.Remove(setStringKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmUpgradeSettings.SetString"/></em></p>
        ///   <p>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</p>
        /// </summary>
        [Pure]
        public static T SetSetString<T>(this T toolSettings, string setStringKey, object setStringValue) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SetStringInternal[setStringKey] = setStringValue;
            return toolSettings;
        }
        #endregion
        #region SkipCrds
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed when an upgrade is performed with install flag enabled. By default, CRDs are installed if not already present, when an upgrade is performed with install flag enabled.</p>
        /// </summary>
        [Pure]
        public static T SetSkipCrds<T>(this T toolSettings, bool? skipCrds) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = skipCrds;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed when an upgrade is performed with install flag enabled. By default, CRDs are installed if not already present, when an upgrade is performed with install flag enabled.</p>
        /// </summary>
        [Pure]
        public static T ResetSkipCrds<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed when an upgrade is performed with install flag enabled. By default, CRDs are installed if not already present, when an upgrade is performed with install flag enabled.</p>
        /// </summary>
        [Pure]
        public static T EnableSkipCrds<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed when an upgrade is performed with install flag enabled. By default, CRDs are installed if not already present, when an upgrade is performed with install flag enabled.</p>
        /// </summary>
        [Pure]
        public static T DisableSkipCrds<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.SkipCrds"/></em></p>
        ///   <p>If set, no CRDs will be installed when an upgrade is performed with install flag enabled. By default, CRDs are installed if not already present, when an upgrade is performed with install flag enabled.</p>
        /// </summary>
        [Pure]
        public static T ToggleSkipCrds<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipCrds = !toolSettings.SkipCrds;
            return toolSettings;
        }
        #endregion
        #region Timeout
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Timeout"/></em></p>
        ///   <p>Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).</p>
        /// </summary>
        [Pure]
        public static T SetTimeout<T>(this T toolSettings, string timeout) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = timeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Timeout"/></em></p>
        ///   <p>Time to wait for any individual Kubernetes operation (like Jobs for hooks) (default 5m0s).</p>
        /// </summary>
        [Pure]
        public static T ResetTimeout<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Timeout = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Username"/></em></p>
        ///   <p>Chart repository username where to locate the requested chart.</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Values
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Values"/> to a new list</em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T SetValues<T>(this T toolSettings, params string[] values) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal = values.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Values"/> to a new list</em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T SetValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal = values.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmUpgradeSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T AddValues<T>(this T toolSettings, params string[] values) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal.AddRange(values);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="HelmUpgradeSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T AddValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal.AddRange(values);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmUpgradeSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T ClearValues<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ValuesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmUpgradeSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T RemoveValues<T>(this T toolSettings, params string[] values) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(values);
            toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="HelmUpgradeSettings.Values"/></em></p>
        ///   <p>Specify values in a YAML file or a URL (can specify multiple).</p>
        /// </summary>
        [Pure]
        public static T RemoveValues<T>(this T toolSettings, IEnumerable<string> values) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(values);
            toolSettings.ValuesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Verify
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T SetVerify<T>(this T toolSettings, bool? verify) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = verify;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ResetVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T EnableVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T DisableVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Verify"/></em></p>
        ///   <p>Verify the package before using it.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerify<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verify = !toolSettings.Verify;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Version"/></em></p>
        ///   <p>Specify the exact chart version to use. If this is not specified, the latest version is used.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Wait
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T SetWait<T>(this T toolSettings, bool? wait) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = wait;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T ResetWait<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmUpgradeSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T EnableWait<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmUpgradeSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T DisableWait<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmUpgradeSettings.Wait"/></em></p>
        ///   <p>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment, StatefulSet, or ReplicaSet are in a ready state before marking the release as successful. It will wait for as long as --timeout.</p>
        /// </summary>
        [Pure]
        public static T ToggleWait<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wait = !toolSettings.Wait;
            return toolSettings;
        }
        #endregion
        #region Release
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Release"/></em></p>
        ///   <p>The name of the release to upgrade.</p>
        /// </summary>
        [Pure]
        public static T SetRelease<T>(this T toolSettings, string release) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Release = release;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Release"/></em></p>
        ///   <p>The name of the release to upgrade.</p>
        /// </summary>
        [Pure]
        public static T ResetRelease<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Release = null;
            return toolSettings;
        }
        #endregion
        #region Chart
        /// <summary>
        ///   <p><em>Sets <see cref="HelmUpgradeSettings.Chart"/></em></p>
        ///   <p>The name of the chart to upgrade.</p>
        /// </summary>
        [Pure]
        public static T SetChart<T>(this T toolSettings, string chart) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = chart;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmUpgradeSettings.Chart"/></em></p>
        ///   <p>The name of the chart to upgrade.</p>
        /// </summary>
        [Pure]
        public static T ResetChart<T>(this T toolSettings) where T : HelmUpgradeSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Chart = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmVerifySettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmVerifySettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmVerifySettings.Help"/></em></p>
        ///   <p>Help for verify.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmVerifySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmVerifySettings.Help"/></em></p>
        ///   <p>Help for verify.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmVerifySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmVerifySettings.Help"/></em></p>
        ///   <p>Help for verify.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmVerifySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmVerifySettings.Help"/></em></p>
        ///   <p>Help for verify.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmVerifySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmVerifySettings.Help"/></em></p>
        ///   <p>Help for verify.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmVerifySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Keyring
        /// <summary>
        ///   <p><em>Sets <see cref="HelmVerifySettings.Keyring"/></em></p>
        ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T SetKeyring<T>(this T toolSettings, string keyring) where T : HelmVerifySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = keyring;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmVerifySettings.Keyring"/></em></p>
        ///   <p>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</p>
        /// </summary>
        [Pure]
        public static T ResetKeyring<T>(this T toolSettings) where T : HelmVerifySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Keyring = null;
            return toolSettings;
        }
        #endregion
        #region Path
        /// <summary>
        ///   <p><em>Sets <see cref="HelmVerifySettings.Path"/></em></p>
        ///   <p>The path to the chart to verify.</p>
        /// </summary>
        [Pure]
        public static T SetPath<T>(this T toolSettings, string path) where T : HelmVerifySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = path;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmVerifySettings.Path"/></em></p>
        ///   <p>The path to the chart to verify.</p>
        /// </summary>
        [Pure]
        public static T ResetPath<T>(this T toolSettings) where T : HelmVerifySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmVersionSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmVersionSettingsExtensions
    {
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmVersionSettings.Help"/></em></p>
        ///   <p>Help for version.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmVersionSettings.Help"/></em></p>
        ///   <p>Help for version.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmVersionSettings.Help"/></em></p>
        ///   <p>Help for version.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmVersionSettings.Help"/></em></p>
        ///   <p>Help for version.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmVersionSettings.Help"/></em></p>
        ///   <p>Help for version.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region Short
        /// <summary>
        ///   <p><em>Sets <see cref="HelmVersionSettings.Short"/></em></p>
        ///   <p>Print the version number.</p>
        /// </summary>
        [Pure]
        public static T SetShort<T>(this T toolSettings, bool? @short) where T : HelmVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = @short;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmVersionSettings.Short"/></em></p>
        ///   <p>Print the version number.</p>
        /// </summary>
        [Pure]
        public static T ResetShort<T>(this T toolSettings) where T : HelmVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmVersionSettings.Short"/></em></p>
        ///   <p>Print the version number.</p>
        /// </summary>
        [Pure]
        public static T EnableShort<T>(this T toolSettings) where T : HelmVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmVersionSettings.Short"/></em></p>
        ///   <p>Print the version number.</p>
        /// </summary>
        [Pure]
        public static T DisableShort<T>(this T toolSettings) where T : HelmVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmVersionSettings.Short"/></em></p>
        ///   <p>Print the version number.</p>
        /// </summary>
        [Pure]
        public static T ToggleShort<T>(this T toolSettings) where T : HelmVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Short = !toolSettings.Short;
            return toolSettings;
        }
        #endregion
        #region Template
        /// <summary>
        ///   <p><em>Sets <see cref="HelmVersionSettings.Template"/></em></p>
        ///   <p>Template for version string format.</p>
        /// </summary>
        [Pure]
        public static T SetTemplate<T>(this T toolSettings, string template) where T : HelmVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Template = template;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmVersionSettings.Template"/></em></p>
        ///   <p>Template for version string format.</p>
        /// </summary>
        [Pure]
        public static T ResetTemplate<T>(this T toolSettings) where T : HelmVersionSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Template = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmCommonSettingsExtensions
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class HelmCommonSettingsExtensions
    {
        #region AddDirHeader
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.AddDirHeader"/></em></p>
        ///   <p>If true, adds the file directory to the header.</p>
        /// </summary>
        [Pure]
        public static T SetAddDirHeader<T>(this T toolSettings, bool? addDirHeader) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddDirHeader = addDirHeader;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.AddDirHeader"/></em></p>
        ///   <p>If true, adds the file directory to the header.</p>
        /// </summary>
        [Pure]
        public static T ResetAddDirHeader<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddDirHeader = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmCommonSettings.AddDirHeader"/></em></p>
        ///   <p>If true, adds the file directory to the header.</p>
        /// </summary>
        [Pure]
        public static T EnableAddDirHeader<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddDirHeader = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmCommonSettings.AddDirHeader"/></em></p>
        ///   <p>If true, adds the file directory to the header.</p>
        /// </summary>
        [Pure]
        public static T DisableAddDirHeader<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddDirHeader = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmCommonSettings.AddDirHeader"/></em></p>
        ///   <p>If true, adds the file directory to the header.</p>
        /// </summary>
        [Pure]
        public static T ToggleAddDirHeader<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AddDirHeader = !toolSettings.AddDirHeader;
            return toolSettings;
        }
        #endregion
        #region Alsologtostderr
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.Alsologtostderr"/></em></p>
        ///   <p>Log to standard error as well as files.</p>
        /// </summary>
        [Pure]
        public static T SetAlsologtostderr<T>(this T toolSettings, bool? alsologtostderr) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Alsologtostderr = alsologtostderr;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.Alsologtostderr"/></em></p>
        ///   <p>Log to standard error as well as files.</p>
        /// </summary>
        [Pure]
        public static T ResetAlsologtostderr<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Alsologtostderr = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmCommonSettings.Alsologtostderr"/></em></p>
        ///   <p>Log to standard error as well as files.</p>
        /// </summary>
        [Pure]
        public static T EnableAlsologtostderr<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Alsologtostderr = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmCommonSettings.Alsologtostderr"/></em></p>
        ///   <p>Log to standard error as well as files.</p>
        /// </summary>
        [Pure]
        public static T DisableAlsologtostderr<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Alsologtostderr = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmCommonSettings.Alsologtostderr"/></em></p>
        ///   <p>Log to standard error as well as files.</p>
        /// </summary>
        [Pure]
        public static T ToggleAlsologtostderr<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Alsologtostderr = !toolSettings.Alsologtostderr;
            return toolSettings;
        }
        #endregion
        #region Debug
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.Debug"/></em></p>
        ///   <p>Enable verbose output.</p>
        /// </summary>
        [Pure]
        public static T SetDebug<T>(this T toolSettings, bool? debug) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = debug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.Debug"/></em></p>
        ///   <p>Enable verbose output.</p>
        /// </summary>
        [Pure]
        public static T ResetDebug<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmCommonSettings.Debug"/></em></p>
        ///   <p>Enable verbose output.</p>
        /// </summary>
        [Pure]
        public static T EnableDebug<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmCommonSettings.Debug"/></em></p>
        ///   <p>Enable verbose output.</p>
        /// </summary>
        [Pure]
        public static T DisableDebug<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmCommonSettings.Debug"/></em></p>
        ///   <p>Enable verbose output.</p>
        /// </summary>
        [Pure]
        public static T ToggleDebug<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Debug = !toolSettings.Debug;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.Help"/></em></p>
        ///   <p>Help for helm.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.Help"/></em></p>
        ///   <p>Help for helm.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmCommonSettings.Help"/></em></p>
        ///   <p>Help for helm.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmCommonSettings.Help"/></em></p>
        ///   <p>Help for helm.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmCommonSettings.Help"/></em></p>
        ///   <p>Help for helm.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region KubeApiserver
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.KubeApiserver"/></em></p>
        ///   <p>The address and the port for the Kubernetes API server.</p>
        /// </summary>
        [Pure]
        public static T SetKubeApiserver<T>(this T toolSettings, string kubeApiserver) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KubeApiserver = kubeApiserver;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.KubeApiserver"/></em></p>
        ///   <p>The address and the port for the Kubernetes API server.</p>
        /// </summary>
        [Pure]
        public static T ResetKubeApiserver<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KubeApiserver = null;
            return toolSettings;
        }
        #endregion
        #region KubeContext
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.KubeContext"/></em></p>
        ///   <p>Name of the kubeconfig context to use.</p>
        /// </summary>
        [Pure]
        public static T SetKubeContext<T>(this T toolSettings, string kubeContext) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KubeContext = kubeContext;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.KubeContext"/></em></p>
        ///   <p>Name of the kubeconfig context to use.</p>
        /// </summary>
        [Pure]
        public static T ResetKubeContext<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KubeContext = null;
            return toolSettings;
        }
        #endregion
        #region KubeToken
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.KubeToken"/></em></p>
        ///   <p>Bearer token used for authentication.</p>
        /// </summary>
        [Pure]
        public static T SetKubeToken<T>(this T toolSettings, string kubeToken) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KubeToken = kubeToken;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.KubeToken"/></em></p>
        ///   <p>Bearer token used for authentication.</p>
        /// </summary>
        [Pure]
        public static T ResetKubeToken<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KubeToken = null;
            return toolSettings;
        }
        #endregion
        #region Kubeconfig
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.Kubeconfig"/></em></p>
        ///   <p>Path to the kubeconfig file.</p>
        /// </summary>
        [Pure]
        public static T SetKubeconfig<T>(this T toolSettings, string kubeconfig) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Kubeconfig = kubeconfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.Kubeconfig"/></em></p>
        ///   <p>Path to the kubeconfig file.</p>
        /// </summary>
        [Pure]
        public static T ResetKubeconfig<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Kubeconfig = null;
            return toolSettings;
        }
        #endregion
        #region LogBacktraceAt
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.LogBacktraceAt"/></em></p>
        ///   <p>When logging hits line file:N, emit a stack trace (default :0).</p>
        /// </summary>
        [Pure]
        public static T SetLogBacktraceAt<T>(this T toolSettings, string logBacktraceAt) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogBacktraceAt = logBacktraceAt;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.LogBacktraceAt"/></em></p>
        ///   <p>When logging hits line file:N, emit a stack trace (default :0).</p>
        /// </summary>
        [Pure]
        public static T ResetLogBacktraceAt<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogBacktraceAt = null;
            return toolSettings;
        }
        #endregion
        #region LogDir
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.LogDir"/></em></p>
        ///   <p>If non-empty, write log files in this directory.</p>
        /// </summary>
        [Pure]
        public static T SetLogDir<T>(this T toolSettings, string logDir) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogDir = logDir;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.LogDir"/></em></p>
        ///   <p>If non-empty, write log files in this directory.</p>
        /// </summary>
        [Pure]
        public static T ResetLogDir<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogDir = null;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.LogFile"/></em></p>
        ///   <p>If non-empty, use this log file.</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.LogFile"/></em></p>
        ///   <p>If non-empty, use this log file.</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region LogFileMaxSize
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.LogFileMaxSize"/></em></p>
        ///   <p>Defines the maximum size a log file can grow to. Unit is megabytes. If the value is 0, the maximum file size is unlimited. (default 1800).</p>
        /// </summary>
        [Pure]
        public static T SetLogFileMaxSize<T>(this T toolSettings, uint? logFileMaxSize) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFileMaxSize = logFileMaxSize;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.LogFileMaxSize"/></em></p>
        ///   <p>Defines the maximum size a log file can grow to. Unit is megabytes. If the value is 0, the maximum file size is unlimited. (default 1800).</p>
        /// </summary>
        [Pure]
        public static T ResetLogFileMaxSize<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFileMaxSize = null;
            return toolSettings;
        }
        #endregion
        #region Logtostderr
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.Logtostderr"/></em></p>
        ///   <p>Log to standard error instead of files (default true).</p>
        /// </summary>
        [Pure]
        public static T SetLogtostderr<T>(this T toolSettings, bool? logtostderr) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logtostderr = logtostderr;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.Logtostderr"/></em></p>
        ///   <p>Log to standard error instead of files (default true).</p>
        /// </summary>
        [Pure]
        public static T ResetLogtostderr<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logtostderr = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmCommonSettings.Logtostderr"/></em></p>
        ///   <p>Log to standard error instead of files (default true).</p>
        /// </summary>
        [Pure]
        public static T EnableLogtostderr<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logtostderr = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmCommonSettings.Logtostderr"/></em></p>
        ///   <p>Log to standard error instead of files (default true).</p>
        /// </summary>
        [Pure]
        public static T DisableLogtostderr<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logtostderr = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmCommonSettings.Logtostderr"/></em></p>
        ///   <p>Log to standard error instead of files (default true).</p>
        /// </summary>
        [Pure]
        public static T ToggleLogtostderr<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Logtostderr = !toolSettings.Logtostderr;
            return toolSettings;
        }
        #endregion
        #region Namespace
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.Namespace"/></em></p>
        ///   <p>Namespace scope for this request.</p>
        /// </summary>
        [Pure]
        public static T SetNamespace<T>(this T toolSettings, string @namespace) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Namespace = @namespace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.Namespace"/></em></p>
        ///   <p>Namespace scope for this request.</p>
        /// </summary>
        [Pure]
        public static T ResetNamespace<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Namespace = null;
            return toolSettings;
        }
        #endregion
        #region RegistryConfig
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.RegistryConfig"/></em></p>
        ///   <p>Path to the registry config file (default "~/.config/helm/registry.json").</p>
        /// </summary>
        [Pure]
        public static T SetRegistryConfig<T>(this T toolSettings, string registryConfig) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RegistryConfig = registryConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.RegistryConfig"/></em></p>
        ///   <p>Path to the registry config file (default "~/.config/helm/registry.json").</p>
        /// </summary>
        [Pure]
        public static T ResetRegistryConfig<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RegistryConfig = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryCache
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.RepositoryCache"/></em></p>
        ///   <p>Path to the file containing cached repository indexes (default "~/snap/code/common/.cache/helm/repository").</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryCache<T>(this T toolSettings, string repositoryCache) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryCache = repositoryCache;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.RepositoryCache"/></em></p>
        ///   <p>Path to the file containing cached repository indexes (default "~/snap/code/common/.cache/helm/repository").</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryCache<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryCache = null;
            return toolSettings;
        }
        #endregion
        #region RepositoryConfig
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.RepositoryConfig"/></em></p>
        ///   <p>Path to the file containing repository names and URLs (default "~/.config/helm/repositories.yaml").</p>
        /// </summary>
        [Pure]
        public static T SetRepositoryConfig<T>(this T toolSettings, string repositoryConfig) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryConfig = repositoryConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.RepositoryConfig"/></em></p>
        ///   <p>Path to the file containing repository names and URLs (default "~/.config/helm/repositories.yaml").</p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryConfig<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepositoryConfig = null;
            return toolSettings;
        }
        #endregion
        #region SkipHeaders
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.SkipHeaders"/></em></p>
        ///   <p>If true, avoid header prefixes in the log messages.</p>
        /// </summary>
        [Pure]
        public static T SetSkipHeaders<T>(this T toolSettings, bool? skipHeaders) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipHeaders = skipHeaders;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.SkipHeaders"/></em></p>
        ///   <p>If true, avoid header prefixes in the log messages.</p>
        /// </summary>
        [Pure]
        public static T ResetSkipHeaders<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipHeaders = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmCommonSettings.SkipHeaders"/></em></p>
        ///   <p>If true, avoid header prefixes in the log messages.</p>
        /// </summary>
        [Pure]
        public static T EnableSkipHeaders<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipHeaders = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmCommonSettings.SkipHeaders"/></em></p>
        ///   <p>If true, avoid header prefixes in the log messages.</p>
        /// </summary>
        [Pure]
        public static T DisableSkipHeaders<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipHeaders = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmCommonSettings.SkipHeaders"/></em></p>
        ///   <p>If true, avoid header prefixes in the log messages.</p>
        /// </summary>
        [Pure]
        public static T ToggleSkipHeaders<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipHeaders = !toolSettings.SkipHeaders;
            return toolSettings;
        }
        #endregion
        #region SkipLogHeaders
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.SkipLogHeaders"/></em></p>
        ///   <p>If true, avoid headers when opening log files.</p>
        /// </summary>
        [Pure]
        public static T SetSkipLogHeaders<T>(this T toolSettings, bool? skipLogHeaders) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipLogHeaders = skipLogHeaders;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.SkipLogHeaders"/></em></p>
        ///   <p>If true, avoid headers when opening log files.</p>
        /// </summary>
        [Pure]
        public static T ResetSkipLogHeaders<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipLogHeaders = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="HelmCommonSettings.SkipLogHeaders"/></em></p>
        ///   <p>If true, avoid headers when opening log files.</p>
        /// </summary>
        [Pure]
        public static T EnableSkipLogHeaders<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipLogHeaders = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="HelmCommonSettings.SkipLogHeaders"/></em></p>
        ///   <p>If true, avoid headers when opening log files.</p>
        /// </summary>
        [Pure]
        public static T DisableSkipLogHeaders<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipLogHeaders = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="HelmCommonSettings.SkipLogHeaders"/></em></p>
        ///   <p>If true, avoid headers when opening log files.</p>
        /// </summary>
        [Pure]
        public static T ToggleSkipLogHeaders<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipLogHeaders = !toolSettings.SkipLogHeaders;
            return toolSettings;
        }
        #endregion
        #region Stderrthreshold
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.Stderrthreshold"/></em></p>
        ///   <p>Logs at or above this threshold go to stderr (default 2).</p>
        /// </summary>
        [Pure]
        public static T SetStderrthreshold<T>(this T toolSettings, int? stderrthreshold) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Stderrthreshold = stderrthreshold;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.Stderrthreshold"/></em></p>
        ///   <p>Logs at or above this threshold go to stderr (default 2).</p>
        /// </summary>
        [Pure]
        public static T ResetStderrthreshold<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Stderrthreshold = null;
            return toolSettings;
        }
        #endregion
        #region V
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.V"/></em></p>
        ///   <p>Number for the log level verbosity.</p>
        /// </summary>
        [Pure]
        public static T SetV<T>(this T toolSettings, int? v) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.V = v;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="HelmCommonSettings.V"/></em></p>
        ///   <p>Number for the log level verbosity.</p>
        /// </summary>
        [Pure]
        public static T ResetV<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.V = null;
            return toolSettings;
        }
        #endregion
        #region Vmodule
        /// <summary>
        ///   <p><em>Sets <see cref="HelmCommonSettings.Vmodule"/> to a new dictionary</em></p>
        ///   <p>Comma-separated list of pattern=N settings for file-filtered logging.</p>
        /// </summary>
        [Pure]
        public static T SetVmodule<T>(this T toolSettings, IDictionary<string, object> vmodule) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VmoduleInternal = vmodule.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="HelmCommonSettings.Vmodule"/></em></p>
        ///   <p>Comma-separated list of pattern=N settings for file-filtered logging.</p>
        /// </summary>
        [Pure]
        public static T ClearVmodule<T>(this T toolSettings) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VmoduleInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="HelmCommonSettings.Vmodule"/></em></p>
        ///   <p>Comma-separated list of pattern=N settings for file-filtered logging.</p>
        /// </summary>
        [Pure]
        public static T AddVmodule<T>(this T toolSettings, string vmoduleKey, object vmoduleValue) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VmoduleInternal.Add(vmoduleKey, vmoduleValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="HelmCommonSettings.Vmodule"/></em></p>
        ///   <p>Comma-separated list of pattern=N settings for file-filtered logging.</p>
        /// </summary>
        [Pure]
        public static T RemoveVmodule<T>(this T toolSettings, string vmoduleKey) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VmoduleInternal.Remove(vmoduleKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="HelmCommonSettings.Vmodule"/></em></p>
        ///   <p>Comma-separated list of pattern=N settings for file-filtered logging.</p>
        /// </summary>
        [Pure]
        public static T SetVmodule<T>(this T toolSettings, string vmoduleKey, object vmoduleValue) where T : HelmCommonSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VmoduleInternal[vmoduleKey] = vmoduleValue;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HelmOutputFormat
    /// <summary>
    ///   Used within <see cref="HelmTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<HelmOutputFormat>))]
    public partial class HelmOutputFormat : Enumeration
    {
        public static HelmOutputFormat json = (HelmOutputFormat) "json";
        public static HelmOutputFormat yaml = (HelmOutputFormat) "yaml";
        public static explicit operator HelmOutputFormat(string value)
        {
            return new HelmOutputFormat { Value = value };
        }
    }
    #endregion
}
