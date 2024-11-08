// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Helm/Helm.json

using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common;
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

namespace Nuke.Common.Tools.Helm;

/// <summary><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[PathToolRequirement(PathExecutable)]
[PathTool(Executable = PathExecutable)]
public partial class HelmTasks : ToolTasks, IRequirePathTool
{
    public static string HelmPath => new HelmTasks().GetToolPath();
    public const string PathExecutable = "helm";
    /// <summary><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Helm(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new HelmTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Generate autocompletions script for Helm for the specified shell (bash or zsh). This command can generate shell autocompletions. e.g. 	$ helm completion bash Can be sourced as such 	$ source &lt;(helm completion bash).</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;shell&gt;</c> via <see cref="HelmCompletionSettings.Shell"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmCompletion(HelmCompletionSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Generate autocompletions script for Helm for the specified shell (bash or zsh). This command can generate shell autocompletions. e.g. 	$ helm completion bash Can be sourced as such 	$ source &lt;(helm completion bash).</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;shell&gt;</c> via <see cref="HelmCompletionSettings.Shell"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmCompletion(Configure<HelmCompletionSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmCompletionSettings()));
    /// <summary><p>Generate autocompletions script for Helm for the specified shell (bash or zsh). This command can generate shell autocompletions. e.g. 	$ helm completion bash Can be sourced as such 	$ source &lt;(helm completion bash).</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;shell&gt;</c> via <see cref="HelmCompletionSettings.Shell"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IEnumerable<(HelmCompletionSettings Settings, IReadOnlyCollection<Output> Output)> HelmCompletion(CombinatorialConfigure<HelmCompletionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmCompletion, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command creates a chart directory along with the common files and directories used in a chart. For example, 'helm create foo' will create a directory structure that looks something like this: 	foo/ 	  | 	  |- .helmignore        # Contains patterns to ignore when packaging Helm charts. 	  | 	  |- Chart.yaml         # Information about your chart 	  | 	  |- values.yaml        # The default values for your templates 	  | 	  |- charts/            # Charts that this chart depends on 	  | 	  |- templates/         # The template files 	  | 	  |- templates/tests/   # The test files 'helm create' takes a path for an argument. If directories in the given path do not exist, Helm will attempt to create them as it goes. If the given destination exists and there are files in that directory, conflicting files will be overwritten, but other files will be left alone.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="HelmCreateSettings.Name"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--starter</c> via <see cref="HelmCreateSettings.Starter"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmCreate(HelmCreateSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command creates a chart directory along with the common files and directories used in a chart. For example, 'helm create foo' will create a directory structure that looks something like this: 	foo/ 	  | 	  |- .helmignore        # Contains patterns to ignore when packaging Helm charts. 	  | 	  |- Chart.yaml         # Information about your chart 	  | 	  |- values.yaml        # The default values for your templates 	  | 	  |- charts/            # Charts that this chart depends on 	  | 	  |- templates/         # The template files 	  | 	  |- templates/tests/   # The test files 'helm create' takes a path for an argument. If directories in the given path do not exist, Helm will attempt to create them as it goes. If the given destination exists and there are files in that directory, conflicting files will be overwritten, but other files will be left alone.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="HelmCreateSettings.Name"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--starter</c> via <see cref="HelmCreateSettings.Starter"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmCreate(Configure<HelmCreateSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmCreateSettings()));
    /// <summary><p>This command creates a chart directory along with the common files and directories used in a chart. For example, 'helm create foo' will create a directory structure that looks something like this: 	foo/ 	  | 	  |- .helmignore        # Contains patterns to ignore when packaging Helm charts. 	  | 	  |- Chart.yaml         # Information about your chart 	  | 	  |- values.yaml        # The default values for your templates 	  | 	  |- charts/            # Charts that this chart depends on 	  | 	  |- templates/         # The template files 	  | 	  |- templates/tests/   # The test files 'helm create' takes a path for an argument. If directories in the given path do not exist, Helm will attempt to create them as it goes. If the given destination exists and there are files in that directory, conflicting files will be overwritten, but other files will be left alone.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="HelmCreateSettings.Name"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--starter</c> via <see cref="HelmCreateSettings.Starter"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IEnumerable<(HelmCreateSettings Settings, IReadOnlyCollection<Output> Output)> HelmCreate(CombinatorialConfigure<HelmCreateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmCreate, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command takes a release name, and then deletes the release from Kubernetes. It removes all of the resources associated with the last release of the chart. Use the '--dry-run' flag to see which releases will be deleted without actually deleting them.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseNames&gt;</c> via <see cref="HelmDeleteSettings.ReleaseNames"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--description</c> via <see cref="HelmDeleteSettings.Description"/></li><li><c>--dry-run</c> via <see cref="HelmDeleteSettings.DryRun"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--no-hooks</c> via <see cref="HelmDeleteSettings.NoHooks"/></li><li><c>--purge</c> via <see cref="HelmDeleteSettings.Purge"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmDeleteSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmDeleteSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmDeleteSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmDeleteSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmDeleteSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmDeleteSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmDeleteSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmDelete(HelmDeleteSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command takes a release name, and then deletes the release from Kubernetes. It removes all of the resources associated with the last release of the chart. Use the '--dry-run' flag to see which releases will be deleted without actually deleting them.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseNames&gt;</c> via <see cref="HelmDeleteSettings.ReleaseNames"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--description</c> via <see cref="HelmDeleteSettings.Description"/></li><li><c>--dry-run</c> via <see cref="HelmDeleteSettings.DryRun"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--no-hooks</c> via <see cref="HelmDeleteSettings.NoHooks"/></li><li><c>--purge</c> via <see cref="HelmDeleteSettings.Purge"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmDeleteSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmDeleteSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmDeleteSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmDeleteSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmDeleteSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmDeleteSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmDeleteSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmDelete(Configure<HelmDeleteSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmDeleteSettings()));
    /// <summary><p>This command takes a release name, and then deletes the release from Kubernetes. It removes all of the resources associated with the last release of the chart. Use the '--dry-run' flag to see which releases will be deleted without actually deleting them.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseNames&gt;</c> via <see cref="HelmDeleteSettings.ReleaseNames"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--description</c> via <see cref="HelmDeleteSettings.Description"/></li><li><c>--dry-run</c> via <see cref="HelmDeleteSettings.DryRun"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--no-hooks</c> via <see cref="HelmDeleteSettings.NoHooks"/></li><li><c>--purge</c> via <see cref="HelmDeleteSettings.Purge"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmDeleteSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmDeleteSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmDeleteSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmDeleteSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmDeleteSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmDeleteSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmDeleteSettings.TlsVerify"/></li></ul></remarks>
    public static IEnumerable<(HelmDeleteSettings Settings, IReadOnlyCollection<Output> Output)> HelmDelete(CombinatorialConfigure<HelmDeleteSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmDelete, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Build out the charts/ directory from the requirements.lock file. Build is used to reconstruct a chart's dependencies to the state specified in the lock file. This will not re-negotiate dependencies, as 'helm dependency update' does. If no lock file is found, 'helm dependency build' will mirror the behavior of 'helm dependency update'.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyBuildSettings.Chart"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--keyring</c> via <see cref="HelmDependencyBuildSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--verify</c> via <see cref="HelmDependencyBuildSettings.Verify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmDependencyBuild(HelmDependencyBuildSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Build out the charts/ directory from the requirements.lock file. Build is used to reconstruct a chart's dependencies to the state specified in the lock file. This will not re-negotiate dependencies, as 'helm dependency update' does. If no lock file is found, 'helm dependency build' will mirror the behavior of 'helm dependency update'.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyBuildSettings.Chart"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--keyring</c> via <see cref="HelmDependencyBuildSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--verify</c> via <see cref="HelmDependencyBuildSettings.Verify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmDependencyBuild(Configure<HelmDependencyBuildSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmDependencyBuildSettings()));
    /// <summary><p>Build out the charts/ directory from the requirements.lock file. Build is used to reconstruct a chart's dependencies to the state specified in the lock file. This will not re-negotiate dependencies, as 'helm dependency update' does. If no lock file is found, 'helm dependency build' will mirror the behavior of 'helm dependency update'.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyBuildSettings.Chart"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--keyring</c> via <see cref="HelmDependencyBuildSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--verify</c> via <see cref="HelmDependencyBuildSettings.Verify"/></li></ul></remarks>
    public static IEnumerable<(HelmDependencyBuildSettings Settings, IReadOnlyCollection<Output> Output)> HelmDependencyBuild(CombinatorialConfigure<HelmDependencyBuildSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmDependencyBuild, degreeOfParallelism, completeOnFailure);
    /// <summary><p>List all of the dependencies declared in a chart. This can take chart archives and chart directories as input. It will not alter the contents of a chart. This will produce an error if the chart cannot be loaded. It will emit a warning if it cannot find a requirements.yaml.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyListSettings.Chart"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmDependencyList(HelmDependencyListSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>List all of the dependencies declared in a chart. This can take chart archives and chart directories as input. It will not alter the contents of a chart. This will produce an error if the chart cannot be loaded. It will emit a warning if it cannot find a requirements.yaml.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyListSettings.Chart"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmDependencyList(Configure<HelmDependencyListSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmDependencyListSettings()));
    /// <summary><p>List all of the dependencies declared in a chart. This can take chart archives and chart directories as input. It will not alter the contents of a chart. This will produce an error if the chart cannot be loaded. It will emit a warning if it cannot find a requirements.yaml.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyListSettings.Chart"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IEnumerable<(HelmDependencyListSettings Settings, IReadOnlyCollection<Output> Output)> HelmDependencyList(CombinatorialConfigure<HelmDependencyListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmDependencyList, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Update the on-disk dependencies to mirror the requirements.yaml file. This command verifies that the required charts, as expressed in 'requirements.yaml', are present in 'charts/' and are at an acceptable version. It will pull down the latest charts that satisfy the dependencies, and clean up old dependencies. On successful update, this will generate a lock file that can be used to rebuild the requirements to an exact version. Dependencies are not required to be represented in 'requirements.yaml'. For that reason, an update command will not remove charts unless they are (a) present in the requirements.yaml file, but (b) at the wrong version.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyUpdateSettings.Chart"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--keyring</c> via <see cref="HelmDependencyUpdateSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--skip-refresh</c> via <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--verify</c> via <see cref="HelmDependencyUpdateSettings.Verify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmDependencyUpdate(HelmDependencyUpdateSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Update the on-disk dependencies to mirror the requirements.yaml file. This command verifies that the required charts, as expressed in 'requirements.yaml', are present in 'charts/' and are at an acceptable version. It will pull down the latest charts that satisfy the dependencies, and clean up old dependencies. On successful update, this will generate a lock file that can be used to rebuild the requirements to an exact version. Dependencies are not required to be represented in 'requirements.yaml'. For that reason, an update command will not remove charts unless they are (a) present in the requirements.yaml file, but (b) at the wrong version.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyUpdateSettings.Chart"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--keyring</c> via <see cref="HelmDependencyUpdateSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--skip-refresh</c> via <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--verify</c> via <see cref="HelmDependencyUpdateSettings.Verify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmDependencyUpdate(Configure<HelmDependencyUpdateSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmDependencyUpdateSettings()));
    /// <summary><p>Update the on-disk dependencies to mirror the requirements.yaml file. This command verifies that the required charts, as expressed in 'requirements.yaml', are present in 'charts/' and are at an acceptable version. It will pull down the latest charts that satisfy the dependencies, and clean up old dependencies. On successful update, this will generate a lock file that can be used to rebuild the requirements to an exact version. Dependencies are not required to be represented in 'requirements.yaml'. For that reason, an update command will not remove charts unless they are (a) present in the requirements.yaml file, but (b) at the wrong version.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmDependencyUpdateSettings.Chart"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--keyring</c> via <see cref="HelmDependencyUpdateSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--skip-refresh</c> via <see cref="HelmDependencyUpdateSettings.SkipRefresh"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--verify</c> via <see cref="HelmDependencyUpdateSettings.Verify"/></li></ul></remarks>
    public static IEnumerable<(HelmDependencyUpdateSettings Settings, IReadOnlyCollection<Output> Output)> HelmDependencyUpdate(CombinatorialConfigure<HelmDependencyUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmDependencyUpdate, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Retrieve a package from a package repository, and download it locally. This is useful for fetching packages to inspect, modify, or repackage. It can also be used to perform cryptographic verification of a chart without installing the chart. There are options for unpacking the chart after download. This will create a directory for the chart and uncompress into that directory. If the --verify flag is specified, the requested chart MUST have a provenance file, and MUST pass the verification process. Failure in any part of this will result in an error, and the chart will not be saved locally.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;charts&gt;</c> via <see cref="HelmFetchSettings.Charts"/></li><li><c>--ca-file</c> via <see cref="HelmFetchSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmFetchSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--destination</c> via <see cref="HelmFetchSettings.Destination"/></li><li><c>--devel</c> via <see cref="HelmFetchSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmFetchSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmFetchSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--password</c> via <see cref="HelmFetchSettings.Password"/></li><li><c>--prov</c> via <see cref="HelmFetchSettings.Prov"/></li><li><c>--repo</c> via <see cref="HelmFetchSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--untar</c> via <see cref="HelmFetchSettings.Untar"/></li><li><c>--untardir</c> via <see cref="HelmFetchSettings.Untardir"/></li><li><c>--username</c> via <see cref="HelmFetchSettings.Username"/></li><li><c>--verify</c> via <see cref="HelmFetchSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmFetchSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmFetch(HelmFetchSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Retrieve a package from a package repository, and download it locally. This is useful for fetching packages to inspect, modify, or repackage. It can also be used to perform cryptographic verification of a chart without installing the chart. There are options for unpacking the chart after download. This will create a directory for the chart and uncompress into that directory. If the --verify flag is specified, the requested chart MUST have a provenance file, and MUST pass the verification process. Failure in any part of this will result in an error, and the chart will not be saved locally.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;charts&gt;</c> via <see cref="HelmFetchSettings.Charts"/></li><li><c>--ca-file</c> via <see cref="HelmFetchSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmFetchSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--destination</c> via <see cref="HelmFetchSettings.Destination"/></li><li><c>--devel</c> via <see cref="HelmFetchSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmFetchSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmFetchSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--password</c> via <see cref="HelmFetchSettings.Password"/></li><li><c>--prov</c> via <see cref="HelmFetchSettings.Prov"/></li><li><c>--repo</c> via <see cref="HelmFetchSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--untar</c> via <see cref="HelmFetchSettings.Untar"/></li><li><c>--untardir</c> via <see cref="HelmFetchSettings.Untardir"/></li><li><c>--username</c> via <see cref="HelmFetchSettings.Username"/></li><li><c>--verify</c> via <see cref="HelmFetchSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmFetchSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmFetch(Configure<HelmFetchSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmFetchSettings()));
    /// <summary><p>Retrieve a package from a package repository, and download it locally. This is useful for fetching packages to inspect, modify, or repackage. It can also be used to perform cryptographic verification of a chart without installing the chart. There are options for unpacking the chart after download. This will create a directory for the chart and uncompress into that directory. If the --verify flag is specified, the requested chart MUST have a provenance file, and MUST pass the verification process. Failure in any part of this will result in an error, and the chart will not be saved locally.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;charts&gt;</c> via <see cref="HelmFetchSettings.Charts"/></li><li><c>--ca-file</c> via <see cref="HelmFetchSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmFetchSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--destination</c> via <see cref="HelmFetchSettings.Destination"/></li><li><c>--devel</c> via <see cref="HelmFetchSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmFetchSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmFetchSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--password</c> via <see cref="HelmFetchSettings.Password"/></li><li><c>--prov</c> via <see cref="HelmFetchSettings.Prov"/></li><li><c>--repo</c> via <see cref="HelmFetchSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--untar</c> via <see cref="HelmFetchSettings.Untar"/></li><li><c>--untardir</c> via <see cref="HelmFetchSettings.Untardir"/></li><li><c>--username</c> via <see cref="HelmFetchSettings.Username"/></li><li><c>--verify</c> via <see cref="HelmFetchSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmFetchSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(HelmFetchSettings Settings, IReadOnlyCollection<Output> Output)> HelmFetch(CombinatorialConfigure<HelmFetchSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmFetch, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command shows the details of a named release. It can be used to get extended information about the release, including:   - The values used to generate the release   - The chart used to generate the release   - The generated manifest file By default, this prints a human readable collection of information about the chart, the supplied values, and the generated manifest file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--revision</c> via <see cref="HelmGetSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmGet(HelmGetSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command shows the details of a named release. It can be used to get extended information about the release, including:   - The values used to generate the release   - The chart used to generate the release   - The generated manifest file By default, this prints a human readable collection of information about the chart, the supplied values, and the generated manifest file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--revision</c> via <see cref="HelmGetSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmGet(Configure<HelmGetSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmGetSettings()));
    /// <summary><p>This command shows the details of a named release. It can be used to get extended information about the release, including:   - The values used to generate the release   - The chart used to generate the release   - The generated manifest file By default, this prints a human readable collection of information about the chart, the supplied values, and the generated manifest file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--revision</c> via <see cref="HelmGetSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetSettings.TlsVerify"/></li></ul></remarks>
    public static IEnumerable<(HelmGetSettings Settings, IReadOnlyCollection<Output> Output)> HelmGet(CombinatorialConfigure<HelmGetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmGet, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command downloads hooks for a given release. Hooks are formatted in YAML and separated by the YAML '---\n' separator.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetHooksSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--revision</c> via <see cref="HelmGetHooksSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetHooksSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetHooksSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetHooksSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetHooksSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetHooksSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetHooksSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmGetHooks(HelmGetHooksSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command downloads hooks for a given release. Hooks are formatted in YAML and separated by the YAML '---\n' separator.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetHooksSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--revision</c> via <see cref="HelmGetHooksSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetHooksSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetHooksSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetHooksSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetHooksSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetHooksSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetHooksSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmGetHooks(Configure<HelmGetHooksSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmGetHooksSettings()));
    /// <summary><p>This command downloads hooks for a given release. Hooks are formatted in YAML and separated by the YAML '---\n' separator.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetHooksSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--revision</c> via <see cref="HelmGetHooksSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetHooksSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetHooksSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetHooksSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetHooksSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetHooksSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetHooksSettings.TlsVerify"/></li></ul></remarks>
    public static IEnumerable<(HelmGetHooksSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetHooks(CombinatorialConfigure<HelmGetHooksSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmGetHooks, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command fetches the generated manifest for a given release. A manifest is a YAML-encoded representation of the Kubernetes resources that were generated from this release's chart(s). If a chart is dependent on other charts, those resources will also be included in the manifest.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetManifestSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--revision</c> via <see cref="HelmGetManifestSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetManifestSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetManifestSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetManifestSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetManifestSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetManifestSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetManifestSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmGetManifest(HelmGetManifestSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command fetches the generated manifest for a given release. A manifest is a YAML-encoded representation of the Kubernetes resources that were generated from this release's chart(s). If a chart is dependent on other charts, those resources will also be included in the manifest.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetManifestSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--revision</c> via <see cref="HelmGetManifestSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetManifestSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetManifestSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetManifestSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetManifestSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetManifestSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetManifestSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmGetManifest(Configure<HelmGetManifestSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmGetManifestSettings()));
    /// <summary><p>This command fetches the generated manifest for a given release. A manifest is a YAML-encoded representation of the Kubernetes resources that were generated from this release's chart(s). If a chart is dependent on other charts, those resources will also be included in the manifest.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetManifestSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--revision</c> via <see cref="HelmGetManifestSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetManifestSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetManifestSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetManifestSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetManifestSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetManifestSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetManifestSettings.TlsVerify"/></li></ul></remarks>
    public static IEnumerable<(HelmGetManifestSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetManifest(CombinatorialConfigure<HelmGetManifestSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmGetManifest, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command shows notes provided by the chart of a named release.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetNotesSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--revision</c> via <see cref="HelmGetNotesSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetNotesSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetNotesSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetNotesSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetNotesSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetNotesSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetNotesSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmGetNotes(HelmGetNotesSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command shows notes provided by the chart of a named release.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetNotesSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--revision</c> via <see cref="HelmGetNotesSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetNotesSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetNotesSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetNotesSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetNotesSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetNotesSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetNotesSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmGetNotes(Configure<HelmGetNotesSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmGetNotesSettings()));
    /// <summary><p>This command shows notes provided by the chart of a named release.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetNotesSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--revision</c> via <see cref="HelmGetNotesSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetNotesSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetNotesSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetNotesSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetNotesSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetNotesSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetNotesSettings.TlsVerify"/></li></ul></remarks>
    public static IEnumerable<(HelmGetNotesSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetNotes(CombinatorialConfigure<HelmGetNotesSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmGetNotes, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command downloads a values file for a given release.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetValuesSettings.ReleaseName"/></li><li><c>--all</c> via <see cref="HelmGetValuesSettings.All"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--output</c> via <see cref="HelmGetValuesSettings.Output"/></li><li><c>--revision</c> via <see cref="HelmGetValuesSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetValuesSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetValuesSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetValuesSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetValuesSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetValuesSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetValuesSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmGetValues(HelmGetValuesSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command downloads a values file for a given release.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetValuesSettings.ReleaseName"/></li><li><c>--all</c> via <see cref="HelmGetValuesSettings.All"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--output</c> via <see cref="HelmGetValuesSettings.Output"/></li><li><c>--revision</c> via <see cref="HelmGetValuesSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetValuesSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetValuesSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetValuesSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetValuesSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetValuesSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetValuesSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmGetValues(Configure<HelmGetValuesSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmGetValuesSettings()));
    /// <summary><p>This command downloads a values file for a given release.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmGetValuesSettings.ReleaseName"/></li><li><c>--all</c> via <see cref="HelmGetValuesSettings.All"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--output</c> via <see cref="HelmGetValuesSettings.Output"/></li><li><c>--revision</c> via <see cref="HelmGetValuesSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmGetValuesSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmGetValuesSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmGetValuesSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmGetValuesSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmGetValuesSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmGetValuesSettings.TlsVerify"/></li></ul></remarks>
    public static IEnumerable<(HelmGetValuesSettings Settings, IReadOnlyCollection<Output> Output)> HelmGetValues(CombinatorialConfigure<HelmGetValuesSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmGetValues, degreeOfParallelism, completeOnFailure);
    /// <summary><p>History prints historical revisions for a given release. A default maximum of 256 revisions will be returned. Setting '--max' configures the maximum length of the revision list returned. The historical release set is printed as a formatted table, e.g:     $ helm history angry-bird --max=4     REVISION   UPDATED                      STATUS           CHART        DESCRIPTION     1           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Initial install     2           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Upgraded successfully     3           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Rolled back to 2     4           Mon Oct 3 10:15:13 2016     DEPLOYED        alpine-0.1.0  Upgraded successfully.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmHistorySettings.ReleaseName"/></li><li><c>--col-width</c> via <see cref="HelmHistorySettings.ColWidth"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--max</c> via <see cref="HelmHistorySettings.Max"/></li><li><c>--output</c> via <see cref="HelmHistorySettings.Output"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmHistorySettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmHistorySettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmHistorySettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmHistorySettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmHistorySettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmHistorySettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmHistory(HelmHistorySettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>History prints historical revisions for a given release. A default maximum of 256 revisions will be returned. Setting '--max' configures the maximum length of the revision list returned. The historical release set is printed as a formatted table, e.g:     $ helm history angry-bird --max=4     REVISION   UPDATED                      STATUS           CHART        DESCRIPTION     1           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Initial install     2           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Upgraded successfully     3           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Rolled back to 2     4           Mon Oct 3 10:15:13 2016     DEPLOYED        alpine-0.1.0  Upgraded successfully.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmHistorySettings.ReleaseName"/></li><li><c>--col-width</c> via <see cref="HelmHistorySettings.ColWidth"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--max</c> via <see cref="HelmHistorySettings.Max"/></li><li><c>--output</c> via <see cref="HelmHistorySettings.Output"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmHistorySettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmHistorySettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmHistorySettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmHistorySettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmHistorySettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmHistorySettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmHistory(Configure<HelmHistorySettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmHistorySettings()));
    /// <summary><p>History prints historical revisions for a given release. A default maximum of 256 revisions will be returned. Setting '--max' configures the maximum length of the revision list returned. The historical release set is printed as a formatted table, e.g:     $ helm history angry-bird --max=4     REVISION   UPDATED                      STATUS           CHART        DESCRIPTION     1           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Initial install     2           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Upgraded successfully     3           Mon Oct 3 10:15:13 2016     SUPERSEDED      alpine-0.1.0  Rolled back to 2     4           Mon Oct 3 10:15:13 2016     DEPLOYED        alpine-0.1.0  Upgraded successfully.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmHistorySettings.ReleaseName"/></li><li><c>--col-width</c> via <see cref="HelmHistorySettings.ColWidth"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--max</c> via <see cref="HelmHistorySettings.Max"/></li><li><c>--output</c> via <see cref="HelmHistorySettings.Output"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmHistorySettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmHistorySettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmHistorySettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmHistorySettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmHistorySettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmHistorySettings.TlsVerify"/></li></ul></remarks>
    public static IEnumerable<(HelmHistorySettings Settings, IReadOnlyCollection<Output> Output)> HelmHistory(CombinatorialConfigure<HelmHistorySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmHistory, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command displays the location of HELM_HOME. This is where any helm configuration files live.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmHome(HelmHomeSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command displays the location of HELM_HOME. This is where any helm configuration files live.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmHome(Configure<HelmHomeSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmHomeSettings()));
    /// <summary><p>This command displays the location of HELM_HOME. This is where any helm configuration files live.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IEnumerable<(HelmHomeSettings Settings, IReadOnlyCollection<Output> Output)> HelmHome(CombinatorialConfigure<HelmHomeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmHome, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command installs Tiller (the Helm server-side component) onto your Kubernetes Cluster and sets up local configuration in $HELM_HOME (default ~/.helm/). As with the rest of the Helm commands, 'helm init' discovers Kubernetes clusters by reading $KUBECONFIG (default '~/.kube/config') and using the default context. To set up just a local environment, use '--client-only'. That will configure $HELM_HOME, but not attempt to connect to a Kubernetes cluster and install the Tiller deployment. When installing Tiller, 'helm init' will attempt to install the latest released version. You can specify an alternative image with '--tiller-image'. For those frequently working on the latest code, the flag '--canary-image' will install the latest pre-release version of Tiller (e.g. the HEAD commit in the GitHub repository on the master branch). To dump a manifest containing the Tiller deployment YAML, combine the '--dry-run' and '--debug' flags.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--automount-service-account-token</c> via <see cref="HelmInitSettings.AutomountServiceAccountToken"/></li><li><c>--canary-image</c> via <see cref="HelmInitSettings.CanaryImage"/></li><li><c>--client-only</c> via <see cref="HelmInitSettings.ClientOnly"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--dry-run</c> via <see cref="HelmInitSettings.DryRun"/></li><li><c>--force-upgrade</c> via <see cref="HelmInitSettings.ForceUpgrade"/></li><li><c>--history-max</c> via <see cref="HelmInitSettings.HistoryMax"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--local-repo-url</c> via <see cref="HelmInitSettings.LocalRepoUrl"/></li><li><c>--net-host</c> via <see cref="HelmInitSettings.NetHost"/></li><li><c>--node-selectors</c> via <see cref="HelmInitSettings.NodeSelectors"/></li><li><c>--output</c> via <see cref="HelmInitSettings.Output"/></li><li><c>--override</c> via <see cref="HelmInitSettings.Override"/></li><li><c>--replicas</c> via <see cref="HelmInitSettings.Replicas"/></li><li><c>--service-account</c> via <see cref="HelmInitSettings.ServiceAccount"/></li><li><c>--skip-refresh</c> via <see cref="HelmInitSettings.SkipRefresh"/></li><li><c>--stable-repo-url</c> via <see cref="HelmInitSettings.StableRepoUrl"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-image</c> via <see cref="HelmInitSettings.TillerImage"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tiller-tls</c> via <see cref="HelmInitSettings.TillerTls"/></li><li><c>--tiller-tls-cert</c> via <see cref="HelmInitSettings.TillerTlsCert"/></li><li><c>--tiller-tls-hostname</c> via <see cref="HelmInitSettings.TillerTlsHostname"/></li><li><c>--tiller-tls-key</c> via <see cref="HelmInitSettings.TillerTlsKey"/></li><li><c>--tiller-tls-verify</c> via <see cref="HelmInitSettings.TillerTlsVerify"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmInitSettings.TlsCaCert"/></li><li><c>--upgrade</c> via <see cref="HelmInitSettings.Upgrade"/></li><li><c>--wait</c> via <see cref="HelmInitSettings.Wait"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmInit(HelmInitSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command installs Tiller (the Helm server-side component) onto your Kubernetes Cluster and sets up local configuration in $HELM_HOME (default ~/.helm/). As with the rest of the Helm commands, 'helm init' discovers Kubernetes clusters by reading $KUBECONFIG (default '~/.kube/config') and using the default context. To set up just a local environment, use '--client-only'. That will configure $HELM_HOME, but not attempt to connect to a Kubernetes cluster and install the Tiller deployment. When installing Tiller, 'helm init' will attempt to install the latest released version. You can specify an alternative image with '--tiller-image'. For those frequently working on the latest code, the flag '--canary-image' will install the latest pre-release version of Tiller (e.g. the HEAD commit in the GitHub repository on the master branch). To dump a manifest containing the Tiller deployment YAML, combine the '--dry-run' and '--debug' flags.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--automount-service-account-token</c> via <see cref="HelmInitSettings.AutomountServiceAccountToken"/></li><li><c>--canary-image</c> via <see cref="HelmInitSettings.CanaryImage"/></li><li><c>--client-only</c> via <see cref="HelmInitSettings.ClientOnly"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--dry-run</c> via <see cref="HelmInitSettings.DryRun"/></li><li><c>--force-upgrade</c> via <see cref="HelmInitSettings.ForceUpgrade"/></li><li><c>--history-max</c> via <see cref="HelmInitSettings.HistoryMax"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--local-repo-url</c> via <see cref="HelmInitSettings.LocalRepoUrl"/></li><li><c>--net-host</c> via <see cref="HelmInitSettings.NetHost"/></li><li><c>--node-selectors</c> via <see cref="HelmInitSettings.NodeSelectors"/></li><li><c>--output</c> via <see cref="HelmInitSettings.Output"/></li><li><c>--override</c> via <see cref="HelmInitSettings.Override"/></li><li><c>--replicas</c> via <see cref="HelmInitSettings.Replicas"/></li><li><c>--service-account</c> via <see cref="HelmInitSettings.ServiceAccount"/></li><li><c>--skip-refresh</c> via <see cref="HelmInitSettings.SkipRefresh"/></li><li><c>--stable-repo-url</c> via <see cref="HelmInitSettings.StableRepoUrl"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-image</c> via <see cref="HelmInitSettings.TillerImage"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tiller-tls</c> via <see cref="HelmInitSettings.TillerTls"/></li><li><c>--tiller-tls-cert</c> via <see cref="HelmInitSettings.TillerTlsCert"/></li><li><c>--tiller-tls-hostname</c> via <see cref="HelmInitSettings.TillerTlsHostname"/></li><li><c>--tiller-tls-key</c> via <see cref="HelmInitSettings.TillerTlsKey"/></li><li><c>--tiller-tls-verify</c> via <see cref="HelmInitSettings.TillerTlsVerify"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmInitSettings.TlsCaCert"/></li><li><c>--upgrade</c> via <see cref="HelmInitSettings.Upgrade"/></li><li><c>--wait</c> via <see cref="HelmInitSettings.Wait"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmInit(Configure<HelmInitSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmInitSettings()));
    /// <summary><p>This command installs Tiller (the Helm server-side component) onto your Kubernetes Cluster and sets up local configuration in $HELM_HOME (default ~/.helm/). As with the rest of the Helm commands, 'helm init' discovers Kubernetes clusters by reading $KUBECONFIG (default '~/.kube/config') and using the default context. To set up just a local environment, use '--client-only'. That will configure $HELM_HOME, but not attempt to connect to a Kubernetes cluster and install the Tiller deployment. When installing Tiller, 'helm init' will attempt to install the latest released version. You can specify an alternative image with '--tiller-image'. For those frequently working on the latest code, the flag '--canary-image' will install the latest pre-release version of Tiller (e.g. the HEAD commit in the GitHub repository on the master branch). To dump a manifest containing the Tiller deployment YAML, combine the '--dry-run' and '--debug' flags.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--automount-service-account-token</c> via <see cref="HelmInitSettings.AutomountServiceAccountToken"/></li><li><c>--canary-image</c> via <see cref="HelmInitSettings.CanaryImage"/></li><li><c>--client-only</c> via <see cref="HelmInitSettings.ClientOnly"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--dry-run</c> via <see cref="HelmInitSettings.DryRun"/></li><li><c>--force-upgrade</c> via <see cref="HelmInitSettings.ForceUpgrade"/></li><li><c>--history-max</c> via <see cref="HelmInitSettings.HistoryMax"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--local-repo-url</c> via <see cref="HelmInitSettings.LocalRepoUrl"/></li><li><c>--net-host</c> via <see cref="HelmInitSettings.NetHost"/></li><li><c>--node-selectors</c> via <see cref="HelmInitSettings.NodeSelectors"/></li><li><c>--output</c> via <see cref="HelmInitSettings.Output"/></li><li><c>--override</c> via <see cref="HelmInitSettings.Override"/></li><li><c>--replicas</c> via <see cref="HelmInitSettings.Replicas"/></li><li><c>--service-account</c> via <see cref="HelmInitSettings.ServiceAccount"/></li><li><c>--skip-refresh</c> via <see cref="HelmInitSettings.SkipRefresh"/></li><li><c>--stable-repo-url</c> via <see cref="HelmInitSettings.StableRepoUrl"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-image</c> via <see cref="HelmInitSettings.TillerImage"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tiller-tls</c> via <see cref="HelmInitSettings.TillerTls"/></li><li><c>--tiller-tls-cert</c> via <see cref="HelmInitSettings.TillerTlsCert"/></li><li><c>--tiller-tls-hostname</c> via <see cref="HelmInitSettings.TillerTlsHostname"/></li><li><c>--tiller-tls-key</c> via <see cref="HelmInitSettings.TillerTlsKey"/></li><li><c>--tiller-tls-verify</c> via <see cref="HelmInitSettings.TillerTlsVerify"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmInitSettings.TlsCaCert"/></li><li><c>--upgrade</c> via <see cref="HelmInitSettings.Upgrade"/></li><li><c>--wait</c> via <see cref="HelmInitSettings.Wait"/></li></ul></remarks>
    public static IEnumerable<(HelmInitSettings Settings, IReadOnlyCollection<Output> Output)> HelmInit(CombinatorialConfigure<HelmInitSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmInit, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command inspects a chart and displays information. It takes a chart reference ('stable/drupal'), a full path to a directory or packaged chart, or a URL. Inspect prints the contents of the Chart.yaml file and the values.yaml file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInspectSettings.Chart"/></li><li><c>--ca-file</c> via <see cref="HelmInspectSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInspectSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--devel</c> via <see cref="HelmInspectSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInspectSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInspectSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--password</c> via <see cref="HelmInspectSettings.Password"/></li><li><c>--repo</c> via <see cref="HelmInspectSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--username</c> via <see cref="HelmInspectSettings.Username"/></li><li><c>--verify</c> via <see cref="HelmInspectSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInspectSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmInspect(HelmInspectSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command inspects a chart and displays information. It takes a chart reference ('stable/drupal'), a full path to a directory or packaged chart, or a URL. Inspect prints the contents of the Chart.yaml file and the values.yaml file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInspectSettings.Chart"/></li><li><c>--ca-file</c> via <see cref="HelmInspectSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInspectSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--devel</c> via <see cref="HelmInspectSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInspectSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInspectSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--password</c> via <see cref="HelmInspectSettings.Password"/></li><li><c>--repo</c> via <see cref="HelmInspectSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--username</c> via <see cref="HelmInspectSettings.Username"/></li><li><c>--verify</c> via <see cref="HelmInspectSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInspectSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmInspect(Configure<HelmInspectSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmInspectSettings()));
    /// <summary><p>This command inspects a chart and displays information. It takes a chart reference ('stable/drupal'), a full path to a directory or packaged chart, or a URL. Inspect prints the contents of the Chart.yaml file and the values.yaml file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInspectSettings.Chart"/></li><li><c>--ca-file</c> via <see cref="HelmInspectSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInspectSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--devel</c> via <see cref="HelmInspectSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInspectSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInspectSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--password</c> via <see cref="HelmInspectSettings.Password"/></li><li><c>--repo</c> via <see cref="HelmInspectSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--username</c> via <see cref="HelmInspectSettings.Username"/></li><li><c>--verify</c> via <see cref="HelmInspectSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInspectSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(HelmInspectSettings Settings, IReadOnlyCollection<Output> Output)> HelmInspect(CombinatorialConfigure<HelmInspectSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmInspect, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command inspects a chart (directory, file, or URL) and displays the contents of the Charts.yaml file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInspectChartSettings.Chart"/></li><li><c>--ca-file</c> via <see cref="HelmInspectChartSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInspectChartSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--devel</c> via <see cref="HelmInspectChartSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInspectChartSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInspectChartSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--password</c> via <see cref="HelmInspectChartSettings.Password"/></li><li><c>--repo</c> via <see cref="HelmInspectChartSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--username</c> via <see cref="HelmInspectChartSettings.Username"/></li><li><c>--verify</c> via <see cref="HelmInspectChartSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInspectChartSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmInspectChart(HelmInspectChartSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command inspects a chart (directory, file, or URL) and displays the contents of the Charts.yaml file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInspectChartSettings.Chart"/></li><li><c>--ca-file</c> via <see cref="HelmInspectChartSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInspectChartSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--devel</c> via <see cref="HelmInspectChartSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInspectChartSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInspectChartSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--password</c> via <see cref="HelmInspectChartSettings.Password"/></li><li><c>--repo</c> via <see cref="HelmInspectChartSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--username</c> via <see cref="HelmInspectChartSettings.Username"/></li><li><c>--verify</c> via <see cref="HelmInspectChartSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInspectChartSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmInspectChart(Configure<HelmInspectChartSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmInspectChartSettings()));
    /// <summary><p>This command inspects a chart (directory, file, or URL) and displays the contents of the Charts.yaml file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInspectChartSettings.Chart"/></li><li><c>--ca-file</c> via <see cref="HelmInspectChartSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInspectChartSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--devel</c> via <see cref="HelmInspectChartSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInspectChartSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInspectChartSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--password</c> via <see cref="HelmInspectChartSettings.Password"/></li><li><c>--repo</c> via <see cref="HelmInspectChartSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--username</c> via <see cref="HelmInspectChartSettings.Username"/></li><li><c>--verify</c> via <see cref="HelmInspectChartSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInspectChartSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(HelmInspectChartSettings Settings, IReadOnlyCollection<Output> Output)> HelmInspectChart(CombinatorialConfigure<HelmInspectChartSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmInspectChart, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command inspects a chart (directory, file, or URL) and displays the contents of the README file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInspectReadmeSettings.Chart"/></li><li><c>--ca-file</c> via <see cref="HelmInspectReadmeSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInspectReadmeSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--devel</c> via <see cref="HelmInspectReadmeSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInspectReadmeSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInspectReadmeSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--repo</c> via <see cref="HelmInspectReadmeSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--verify</c> via <see cref="HelmInspectReadmeSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInspectReadmeSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmInspectReadme(HelmInspectReadmeSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command inspects a chart (directory, file, or URL) and displays the contents of the README file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInspectReadmeSettings.Chart"/></li><li><c>--ca-file</c> via <see cref="HelmInspectReadmeSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInspectReadmeSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--devel</c> via <see cref="HelmInspectReadmeSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInspectReadmeSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInspectReadmeSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--repo</c> via <see cref="HelmInspectReadmeSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--verify</c> via <see cref="HelmInspectReadmeSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInspectReadmeSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmInspectReadme(Configure<HelmInspectReadmeSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmInspectReadmeSettings()));
    /// <summary><p>This command inspects a chart (directory, file, or URL) and displays the contents of the README file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInspectReadmeSettings.Chart"/></li><li><c>--ca-file</c> via <see cref="HelmInspectReadmeSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInspectReadmeSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--devel</c> via <see cref="HelmInspectReadmeSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInspectReadmeSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInspectReadmeSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--repo</c> via <see cref="HelmInspectReadmeSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--verify</c> via <see cref="HelmInspectReadmeSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInspectReadmeSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(HelmInspectReadmeSettings Settings, IReadOnlyCollection<Output> Output)> HelmInspectReadme(CombinatorialConfigure<HelmInspectReadmeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmInspectReadme, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command inspects a chart (directory, file, or URL) and displays the contents of the values.yaml file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInspectValuesSettings.Chart"/></li><li><c>--ca-file</c> via <see cref="HelmInspectValuesSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInspectValuesSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--devel</c> via <see cref="HelmInspectValuesSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInspectValuesSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInspectValuesSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--password</c> via <see cref="HelmInspectValuesSettings.Password"/></li><li><c>--repo</c> via <see cref="HelmInspectValuesSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--username</c> via <see cref="HelmInspectValuesSettings.Username"/></li><li><c>--verify</c> via <see cref="HelmInspectValuesSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInspectValuesSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmInspectValues(HelmInspectValuesSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command inspects a chart (directory, file, or URL) and displays the contents of the values.yaml file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInspectValuesSettings.Chart"/></li><li><c>--ca-file</c> via <see cref="HelmInspectValuesSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInspectValuesSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--devel</c> via <see cref="HelmInspectValuesSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInspectValuesSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInspectValuesSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--password</c> via <see cref="HelmInspectValuesSettings.Password"/></li><li><c>--repo</c> via <see cref="HelmInspectValuesSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--username</c> via <see cref="HelmInspectValuesSettings.Username"/></li><li><c>--verify</c> via <see cref="HelmInspectValuesSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInspectValuesSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmInspectValues(Configure<HelmInspectValuesSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmInspectValuesSettings()));
    /// <summary><p>This command inspects a chart (directory, file, or URL) and displays the contents of the values.yaml file.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInspectValuesSettings.Chart"/></li><li><c>--ca-file</c> via <see cref="HelmInspectValuesSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInspectValuesSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--devel</c> via <see cref="HelmInspectValuesSettings.Devel"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInspectValuesSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInspectValuesSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--password</c> via <see cref="HelmInspectValuesSettings.Password"/></li><li><c>--repo</c> via <see cref="HelmInspectValuesSettings.Repo"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--username</c> via <see cref="HelmInspectValuesSettings.Username"/></li><li><c>--verify</c> via <see cref="HelmInspectValuesSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInspectValuesSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(HelmInspectValuesSettings Settings, IReadOnlyCollection<Output> Output)> HelmInspectValues(CombinatorialConfigure<HelmInspectValuesSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmInspectValues, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command installs a chart archive. The install argument must be a chart reference, a path to a packaged chart, a path to an unpacked chart directory or a URL. To override values in a chart, use either the '--values' flag and pass in a file or use the '--set' flag and pass configuration from the command line.  To force string values in '--set', use '--set-string' instead. In case a value is large and therefore you want not to use neither '--values' nor '--set', use '--set-file' to read the single large value from file. 	$ helm install -f myvalues.yaml ./redis or 	$ helm install --set name=prod ./redis or 	$ helm install --set-string long_int=1234567890 ./redis or     $ helm install --set-file multiline_text=path/to/textfile You can specify the '--values'/'-f' flag multiple times. The priority will be given to the last (right-most) file specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence: 	$ helm install -f myvalues.yaml -f override.yaml ./redis You can specify the '--set' flag multiple times. The priority will be given to the last (right-most) set specified. For example, if both 'bar' and 'newbar' values are set for a key called 'foo', the 'newbar' value would take precedence: 	$ helm install --set foo=bar --set foo=newbar ./redis To check the generated manifests of a release without installing the chart, the '--debug' and '--dry-run' flags can be combined. This will still require a round-trip to the Tiller server. If --verify is set, the chart MUST have a provenance file, and the provenance file MUST pass all verification steps. There are five different ways you can express the chart you want to install: 1. By chart reference: helm install stable/mariadb 2. By path to a packaged chart: helm install ./nginx-1.2.3.tgz 3. By path to an unpacked chart directory: helm install ./nginx 4. By absolute URL: helm install https://example.com/charts/nginx-1.2.3.tgz 5. By chart reference and repo url: helm install --repo https://example.com/charts/ nginx CHART REFERENCES A chart reference is a convenient way of reference a chart in a chart repository. When you use a chart reference with a repo prefix ('stable/mariadb'), Helm will look in the local configuration for a chart repository named 'stable', and will then look for a chart in that repository whose name is 'mariadb'. It will install the latest version of that chart unless you also supply a version number with the '--version' flag. To see the list of chart repositories, use 'helm repo list'. To search for charts in a repository, use 'helm search'.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInstallSettings.Chart"/></li><li><c>--atomic</c> via <see cref="HelmInstallSettings.Atomic"/></li><li><c>--ca-file</c> via <see cref="HelmInstallSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInstallSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--dep-up</c> via <see cref="HelmInstallSettings.DepUp"/></li><li><c>--description</c> via <see cref="HelmInstallSettings.Description"/></li><li><c>--devel</c> via <see cref="HelmInstallSettings.Devel"/></li><li><c>--dry-run</c> via <see cref="HelmInstallSettings.DryRun"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInstallSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInstallSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--name</c> via <see cref="HelmInstallSettings.Name"/></li><li><c>--name-template</c> via <see cref="HelmInstallSettings.NameTemplate"/></li><li><c>--namespace</c> via <see cref="HelmInstallSettings.Namespace"/></li><li><c>--no-crd-hook</c> via <see cref="HelmInstallSettings.NoCrdHook"/></li><li><c>--no-hooks</c> via <see cref="HelmInstallSettings.NoHooks"/></li><li><c>--password</c> via <see cref="HelmInstallSettings.Password"/></li><li><c>--render-subchart-notes</c> via <see cref="HelmInstallSettings.RenderSubchartNotes"/></li><li><c>--replace</c> via <see cref="HelmInstallSettings.Replace"/></li><li><c>--repo</c> via <see cref="HelmInstallSettings.Repo"/></li><li><c>--set</c> via <see cref="HelmInstallSettings.Set"/></li><li><c>--set-file</c> via <see cref="HelmInstallSettings.SetFile"/></li><li><c>--set-string</c> via <see cref="HelmInstallSettings.SetString"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmInstallSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmInstallSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmInstallSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmInstallSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmInstallSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmInstallSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmInstallSettings.TlsVerify"/></li><li><c>--username</c> via <see cref="HelmInstallSettings.Username"/></li><li><c>--values</c> via <see cref="HelmInstallSettings.Values"/></li><li><c>--verify</c> via <see cref="HelmInstallSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInstallSettings.Version"/></li><li><c>--wait</c> via <see cref="HelmInstallSettings.Wait"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmInstall(HelmInstallSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command installs a chart archive. The install argument must be a chart reference, a path to a packaged chart, a path to an unpacked chart directory or a URL. To override values in a chart, use either the '--values' flag and pass in a file or use the '--set' flag and pass configuration from the command line.  To force string values in '--set', use '--set-string' instead. In case a value is large and therefore you want not to use neither '--values' nor '--set', use '--set-file' to read the single large value from file. 	$ helm install -f myvalues.yaml ./redis or 	$ helm install --set name=prod ./redis or 	$ helm install --set-string long_int=1234567890 ./redis or     $ helm install --set-file multiline_text=path/to/textfile You can specify the '--values'/'-f' flag multiple times. The priority will be given to the last (right-most) file specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence: 	$ helm install -f myvalues.yaml -f override.yaml ./redis You can specify the '--set' flag multiple times. The priority will be given to the last (right-most) set specified. For example, if both 'bar' and 'newbar' values are set for a key called 'foo', the 'newbar' value would take precedence: 	$ helm install --set foo=bar --set foo=newbar ./redis To check the generated manifests of a release without installing the chart, the '--debug' and '--dry-run' flags can be combined. This will still require a round-trip to the Tiller server. If --verify is set, the chart MUST have a provenance file, and the provenance file MUST pass all verification steps. There are five different ways you can express the chart you want to install: 1. By chart reference: helm install stable/mariadb 2. By path to a packaged chart: helm install ./nginx-1.2.3.tgz 3. By path to an unpacked chart directory: helm install ./nginx 4. By absolute URL: helm install https://example.com/charts/nginx-1.2.3.tgz 5. By chart reference and repo url: helm install --repo https://example.com/charts/ nginx CHART REFERENCES A chart reference is a convenient way of reference a chart in a chart repository. When you use a chart reference with a repo prefix ('stable/mariadb'), Helm will look in the local configuration for a chart repository named 'stable', and will then look for a chart in that repository whose name is 'mariadb'. It will install the latest version of that chart unless you also supply a version number with the '--version' flag. To see the list of chart repositories, use 'helm repo list'. To search for charts in a repository, use 'helm search'.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInstallSettings.Chart"/></li><li><c>--atomic</c> via <see cref="HelmInstallSettings.Atomic"/></li><li><c>--ca-file</c> via <see cref="HelmInstallSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInstallSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--dep-up</c> via <see cref="HelmInstallSettings.DepUp"/></li><li><c>--description</c> via <see cref="HelmInstallSettings.Description"/></li><li><c>--devel</c> via <see cref="HelmInstallSettings.Devel"/></li><li><c>--dry-run</c> via <see cref="HelmInstallSettings.DryRun"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInstallSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInstallSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--name</c> via <see cref="HelmInstallSettings.Name"/></li><li><c>--name-template</c> via <see cref="HelmInstallSettings.NameTemplate"/></li><li><c>--namespace</c> via <see cref="HelmInstallSettings.Namespace"/></li><li><c>--no-crd-hook</c> via <see cref="HelmInstallSettings.NoCrdHook"/></li><li><c>--no-hooks</c> via <see cref="HelmInstallSettings.NoHooks"/></li><li><c>--password</c> via <see cref="HelmInstallSettings.Password"/></li><li><c>--render-subchart-notes</c> via <see cref="HelmInstallSettings.RenderSubchartNotes"/></li><li><c>--replace</c> via <see cref="HelmInstallSettings.Replace"/></li><li><c>--repo</c> via <see cref="HelmInstallSettings.Repo"/></li><li><c>--set</c> via <see cref="HelmInstallSettings.Set"/></li><li><c>--set-file</c> via <see cref="HelmInstallSettings.SetFile"/></li><li><c>--set-string</c> via <see cref="HelmInstallSettings.SetString"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmInstallSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmInstallSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmInstallSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmInstallSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmInstallSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmInstallSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmInstallSettings.TlsVerify"/></li><li><c>--username</c> via <see cref="HelmInstallSettings.Username"/></li><li><c>--values</c> via <see cref="HelmInstallSettings.Values"/></li><li><c>--verify</c> via <see cref="HelmInstallSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInstallSettings.Version"/></li><li><c>--wait</c> via <see cref="HelmInstallSettings.Wait"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmInstall(Configure<HelmInstallSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmInstallSettings()));
    /// <summary><p>This command installs a chart archive. The install argument must be a chart reference, a path to a packaged chart, a path to an unpacked chart directory or a URL. To override values in a chart, use either the '--values' flag and pass in a file or use the '--set' flag and pass configuration from the command line.  To force string values in '--set', use '--set-string' instead. In case a value is large and therefore you want not to use neither '--values' nor '--set', use '--set-file' to read the single large value from file. 	$ helm install -f myvalues.yaml ./redis or 	$ helm install --set name=prod ./redis or 	$ helm install --set-string long_int=1234567890 ./redis or     $ helm install --set-file multiline_text=path/to/textfile You can specify the '--values'/'-f' flag multiple times. The priority will be given to the last (right-most) file specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence: 	$ helm install -f myvalues.yaml -f override.yaml ./redis You can specify the '--set' flag multiple times. The priority will be given to the last (right-most) set specified. For example, if both 'bar' and 'newbar' values are set for a key called 'foo', the 'newbar' value would take precedence: 	$ helm install --set foo=bar --set foo=newbar ./redis To check the generated manifests of a release without installing the chart, the '--debug' and '--dry-run' flags can be combined. This will still require a round-trip to the Tiller server. If --verify is set, the chart MUST have a provenance file, and the provenance file MUST pass all verification steps. There are five different ways you can express the chart you want to install: 1. By chart reference: helm install stable/mariadb 2. By path to a packaged chart: helm install ./nginx-1.2.3.tgz 3. By path to an unpacked chart directory: helm install ./nginx 4. By absolute URL: helm install https://example.com/charts/nginx-1.2.3.tgz 5. By chart reference and repo url: helm install --repo https://example.com/charts/ nginx CHART REFERENCES A chart reference is a convenient way of reference a chart in a chart repository. When you use a chart reference with a repo prefix ('stable/mariadb'), Helm will look in the local configuration for a chart repository named 'stable', and will then look for a chart in that repository whose name is 'mariadb'. It will install the latest version of that chart unless you also supply a version number with the '--version' flag. To see the list of chart repositories, use 'helm repo list'. To search for charts in a repository, use 'helm search'.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmInstallSettings.Chart"/></li><li><c>--atomic</c> via <see cref="HelmInstallSettings.Atomic"/></li><li><c>--ca-file</c> via <see cref="HelmInstallSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmInstallSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--dep-up</c> via <see cref="HelmInstallSettings.DepUp"/></li><li><c>--description</c> via <see cref="HelmInstallSettings.Description"/></li><li><c>--devel</c> via <see cref="HelmInstallSettings.Devel"/></li><li><c>--dry-run</c> via <see cref="HelmInstallSettings.DryRun"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmInstallSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmInstallSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--name</c> via <see cref="HelmInstallSettings.Name"/></li><li><c>--name-template</c> via <see cref="HelmInstallSettings.NameTemplate"/></li><li><c>--namespace</c> via <see cref="HelmInstallSettings.Namespace"/></li><li><c>--no-crd-hook</c> via <see cref="HelmInstallSettings.NoCrdHook"/></li><li><c>--no-hooks</c> via <see cref="HelmInstallSettings.NoHooks"/></li><li><c>--password</c> via <see cref="HelmInstallSettings.Password"/></li><li><c>--render-subchart-notes</c> via <see cref="HelmInstallSettings.RenderSubchartNotes"/></li><li><c>--replace</c> via <see cref="HelmInstallSettings.Replace"/></li><li><c>--repo</c> via <see cref="HelmInstallSettings.Repo"/></li><li><c>--set</c> via <see cref="HelmInstallSettings.Set"/></li><li><c>--set-file</c> via <see cref="HelmInstallSettings.SetFile"/></li><li><c>--set-string</c> via <see cref="HelmInstallSettings.SetString"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmInstallSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmInstallSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmInstallSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmInstallSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmInstallSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmInstallSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmInstallSettings.TlsVerify"/></li><li><c>--username</c> via <see cref="HelmInstallSettings.Username"/></li><li><c>--values</c> via <see cref="HelmInstallSettings.Values"/></li><li><c>--verify</c> via <see cref="HelmInstallSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmInstallSettings.Version"/></li><li><c>--wait</c> via <see cref="HelmInstallSettings.Wait"/></li></ul></remarks>
    public static IEnumerable<(HelmInstallSettings Settings, IReadOnlyCollection<Output> Output)> HelmInstall(CombinatorialConfigure<HelmInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmInstall, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command takes a path to a chart and runs a series of tests to verify that the chart is well-formed. If the linter encounters things that will cause the chart to fail installation, it will emit [ERROR] messages. If it encounters issues that break with convention or recommendation, it will emit [WARNING] messages.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;path&gt;</c> via <see cref="HelmLintSettings.Path"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--namespace</c> via <see cref="HelmLintSettings.Namespace"/></li><li><c>--set</c> via <see cref="HelmLintSettings.Set"/></li><li><c>--set-file</c> via <see cref="HelmLintSettings.SetFile"/></li><li><c>--set-string</c> via <see cref="HelmLintSettings.SetString"/></li><li><c>--strict</c> via <see cref="HelmLintSettings.Strict"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--values</c> via <see cref="HelmLintSettings.Values"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmLint(HelmLintSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command takes a path to a chart and runs a series of tests to verify that the chart is well-formed. If the linter encounters things that will cause the chart to fail installation, it will emit [ERROR] messages. If it encounters issues that break with convention or recommendation, it will emit [WARNING] messages.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;path&gt;</c> via <see cref="HelmLintSettings.Path"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--namespace</c> via <see cref="HelmLintSettings.Namespace"/></li><li><c>--set</c> via <see cref="HelmLintSettings.Set"/></li><li><c>--set-file</c> via <see cref="HelmLintSettings.SetFile"/></li><li><c>--set-string</c> via <see cref="HelmLintSettings.SetString"/></li><li><c>--strict</c> via <see cref="HelmLintSettings.Strict"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--values</c> via <see cref="HelmLintSettings.Values"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmLint(Configure<HelmLintSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmLintSettings()));
    /// <summary><p>This command takes a path to a chart and runs a series of tests to verify that the chart is well-formed. If the linter encounters things that will cause the chart to fail installation, it will emit [ERROR] messages. If it encounters issues that break with convention or recommendation, it will emit [WARNING] messages.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;path&gt;</c> via <see cref="HelmLintSettings.Path"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--namespace</c> via <see cref="HelmLintSettings.Namespace"/></li><li><c>--set</c> via <see cref="HelmLintSettings.Set"/></li><li><c>--set-file</c> via <see cref="HelmLintSettings.SetFile"/></li><li><c>--set-string</c> via <see cref="HelmLintSettings.SetString"/></li><li><c>--strict</c> via <see cref="HelmLintSettings.Strict"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--values</c> via <see cref="HelmLintSettings.Values"/></li></ul></remarks>
    public static IEnumerable<(HelmLintSettings Settings, IReadOnlyCollection<Output> Output)> HelmLint(CombinatorialConfigure<HelmLintSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmLint, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command lists all of the releases. By default, it lists only releases that are deployed or failed. Flags like '--deleted' and '--all' will alter this behavior. Such flags can be combined: '--deleted --failed'. By default, items are sorted alphabetically. Use the '-d' flag to sort by release date. If an argument is provided, it will be treated as a filter. Filters are regular expressions (Perl compatible) that are applied to the list of releases. Only items that match the filter will be returned. 	$ helm list 'ara[a-z]+' 	NAME            	UPDATED                 	CHART 	maudlin-arachnid	Mon May  9 16:07:08 2016	alpine-0.1.0 If no results are found, 'helm list' will exit 0, but with no output (or in the case of no '-q' flag, only headers). By default, up to 256 items may be returned. To limit this, use the '--max' flag. Setting '--max' to 0 will not return all results. Rather, it will return the server's default, which may be much higher than 256. Pairing the '--max' flag with the '--offset' flag allows you to page through results.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;filter&gt;</c> via <see cref="HelmListSettings.Filter"/></li><li><c>--all</c> via <see cref="HelmListSettings.All"/></li><li><c>--chart-name</c> via <see cref="HelmListSettings.ChartName"/></li><li><c>--col-width</c> via <see cref="HelmListSettings.ColWidth"/></li><li><c>--date</c> via <see cref="HelmListSettings.Date"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--deleted</c> via <see cref="HelmListSettings.Deleted"/></li><li><c>--deleting</c> via <see cref="HelmListSettings.Deleting"/></li><li><c>--deployed</c> via <see cref="HelmListSettings.Deployed"/></li><li><c>--failed</c> via <see cref="HelmListSettings.Failed"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--max</c> via <see cref="HelmListSettings.Max"/></li><li><c>--namespace</c> via <see cref="HelmListSettings.Namespace"/></li><li><c>--offset</c> via <see cref="HelmListSettings.Offset"/></li><li><c>--output</c> via <see cref="HelmListSettings.Output"/></li><li><c>--pending</c> via <see cref="HelmListSettings.Pending"/></li><li><c>--reverse</c> via <see cref="HelmListSettings.Reverse"/></li><li><c>--short</c> via <see cref="HelmListSettings.Short"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmListSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmListSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmListSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmListSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmListSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmListSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmList(HelmListSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command lists all of the releases. By default, it lists only releases that are deployed or failed. Flags like '--deleted' and '--all' will alter this behavior. Such flags can be combined: '--deleted --failed'. By default, items are sorted alphabetically. Use the '-d' flag to sort by release date. If an argument is provided, it will be treated as a filter. Filters are regular expressions (Perl compatible) that are applied to the list of releases. Only items that match the filter will be returned. 	$ helm list 'ara[a-z]+' 	NAME            	UPDATED                 	CHART 	maudlin-arachnid	Mon May  9 16:07:08 2016	alpine-0.1.0 If no results are found, 'helm list' will exit 0, but with no output (or in the case of no '-q' flag, only headers). By default, up to 256 items may be returned. To limit this, use the '--max' flag. Setting '--max' to 0 will not return all results. Rather, it will return the server's default, which may be much higher than 256. Pairing the '--max' flag with the '--offset' flag allows you to page through results.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;filter&gt;</c> via <see cref="HelmListSettings.Filter"/></li><li><c>--all</c> via <see cref="HelmListSettings.All"/></li><li><c>--chart-name</c> via <see cref="HelmListSettings.ChartName"/></li><li><c>--col-width</c> via <see cref="HelmListSettings.ColWidth"/></li><li><c>--date</c> via <see cref="HelmListSettings.Date"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--deleted</c> via <see cref="HelmListSettings.Deleted"/></li><li><c>--deleting</c> via <see cref="HelmListSettings.Deleting"/></li><li><c>--deployed</c> via <see cref="HelmListSettings.Deployed"/></li><li><c>--failed</c> via <see cref="HelmListSettings.Failed"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--max</c> via <see cref="HelmListSettings.Max"/></li><li><c>--namespace</c> via <see cref="HelmListSettings.Namespace"/></li><li><c>--offset</c> via <see cref="HelmListSettings.Offset"/></li><li><c>--output</c> via <see cref="HelmListSettings.Output"/></li><li><c>--pending</c> via <see cref="HelmListSettings.Pending"/></li><li><c>--reverse</c> via <see cref="HelmListSettings.Reverse"/></li><li><c>--short</c> via <see cref="HelmListSettings.Short"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmListSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmListSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmListSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmListSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmListSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmListSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmList(Configure<HelmListSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmListSettings()));
    /// <summary><p>This command lists all of the releases. By default, it lists only releases that are deployed or failed. Flags like '--deleted' and '--all' will alter this behavior. Such flags can be combined: '--deleted --failed'. By default, items are sorted alphabetically. Use the '-d' flag to sort by release date. If an argument is provided, it will be treated as a filter. Filters are regular expressions (Perl compatible) that are applied to the list of releases. Only items that match the filter will be returned. 	$ helm list 'ara[a-z]+' 	NAME            	UPDATED                 	CHART 	maudlin-arachnid	Mon May  9 16:07:08 2016	alpine-0.1.0 If no results are found, 'helm list' will exit 0, but with no output (or in the case of no '-q' flag, only headers). By default, up to 256 items may be returned. To limit this, use the '--max' flag. Setting '--max' to 0 will not return all results. Rather, it will return the server's default, which may be much higher than 256. Pairing the '--max' flag with the '--offset' flag allows you to page through results.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;filter&gt;</c> via <see cref="HelmListSettings.Filter"/></li><li><c>--all</c> via <see cref="HelmListSettings.All"/></li><li><c>--chart-name</c> via <see cref="HelmListSettings.ChartName"/></li><li><c>--col-width</c> via <see cref="HelmListSettings.ColWidth"/></li><li><c>--date</c> via <see cref="HelmListSettings.Date"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--deleted</c> via <see cref="HelmListSettings.Deleted"/></li><li><c>--deleting</c> via <see cref="HelmListSettings.Deleting"/></li><li><c>--deployed</c> via <see cref="HelmListSettings.Deployed"/></li><li><c>--failed</c> via <see cref="HelmListSettings.Failed"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--max</c> via <see cref="HelmListSettings.Max"/></li><li><c>--namespace</c> via <see cref="HelmListSettings.Namespace"/></li><li><c>--offset</c> via <see cref="HelmListSettings.Offset"/></li><li><c>--output</c> via <see cref="HelmListSettings.Output"/></li><li><c>--pending</c> via <see cref="HelmListSettings.Pending"/></li><li><c>--reverse</c> via <see cref="HelmListSettings.Reverse"/></li><li><c>--short</c> via <see cref="HelmListSettings.Short"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmListSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmListSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmListSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmListSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmListSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmListSettings.TlsVerify"/></li></ul></remarks>
    public static IEnumerable<(HelmListSettings Settings, IReadOnlyCollection<Output> Output)> HelmList(CombinatorialConfigure<HelmListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmList, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command packages a chart into a versioned chart archive file. If a path is given, this will look at that path for a chart (which must contain a Chart.yaml file) and then package that directory. If no path is given, this will look in the present working directory for a Chart.yaml file, and (if found) build the current directory into a chart. Versioned chart archives are used by Helm package repositories.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chartPaths&gt;</c> via <see cref="HelmPackageSettings.ChartPaths"/></li><li><c>--app-version</c> via <see cref="HelmPackageSettings.AppVersion"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--dependency-update</c> via <see cref="HelmPackageSettings.DependencyUpdate"/></li><li><c>--destination</c> via <see cref="HelmPackageSettings.Destination"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key</c> via <see cref="HelmPackageSettings.Key"/></li><li><c>--keyring</c> via <see cref="HelmPackageSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--save</c> via <see cref="HelmPackageSettings.Save"/></li><li><c>--sign</c> via <see cref="HelmPackageSettings.Sign"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--version</c> via <see cref="HelmPackageSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmPackage(HelmPackageSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command packages a chart into a versioned chart archive file. If a path is given, this will look at that path for a chart (which must contain a Chart.yaml file) and then package that directory. If no path is given, this will look in the present working directory for a Chart.yaml file, and (if found) build the current directory into a chart. Versioned chart archives are used by Helm package repositories.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chartPaths&gt;</c> via <see cref="HelmPackageSettings.ChartPaths"/></li><li><c>--app-version</c> via <see cref="HelmPackageSettings.AppVersion"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--dependency-update</c> via <see cref="HelmPackageSettings.DependencyUpdate"/></li><li><c>--destination</c> via <see cref="HelmPackageSettings.Destination"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key</c> via <see cref="HelmPackageSettings.Key"/></li><li><c>--keyring</c> via <see cref="HelmPackageSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--save</c> via <see cref="HelmPackageSettings.Save"/></li><li><c>--sign</c> via <see cref="HelmPackageSettings.Sign"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--version</c> via <see cref="HelmPackageSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmPackage(Configure<HelmPackageSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmPackageSettings()));
    /// <summary><p>This command packages a chart into a versioned chart archive file. If a path is given, this will look at that path for a chart (which must contain a Chart.yaml file) and then package that directory. If no path is given, this will look in the present working directory for a Chart.yaml file, and (if found) build the current directory into a chart. Versioned chart archives are used by Helm package repositories.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chartPaths&gt;</c> via <see cref="HelmPackageSettings.ChartPaths"/></li><li><c>--app-version</c> via <see cref="HelmPackageSettings.AppVersion"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--dependency-update</c> via <see cref="HelmPackageSettings.DependencyUpdate"/></li><li><c>--destination</c> via <see cref="HelmPackageSettings.Destination"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key</c> via <see cref="HelmPackageSettings.Key"/></li><li><c>--keyring</c> via <see cref="HelmPackageSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--save</c> via <see cref="HelmPackageSettings.Save"/></li><li><c>--sign</c> via <see cref="HelmPackageSettings.Sign"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--version</c> via <see cref="HelmPackageSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(HelmPackageSettings Settings, IReadOnlyCollection<Output> Output)> HelmPackage(CombinatorialConfigure<HelmPackageSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmPackage, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command allows you to install a plugin from a url to a VCS repo or a local path. Example usage:     $ helm plugin install https://github.com/technosophos/helm-template.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;options&gt;</c> via <see cref="HelmPluginInstallSettings.Options"/></li><li><c>&lt;paths&gt;</c> via <see cref="HelmPluginInstallSettings.Paths"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--version</c> via <see cref="HelmPluginInstallSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmPluginInstall(HelmPluginInstallSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command allows you to install a plugin from a url to a VCS repo or a local path. Example usage:     $ helm plugin install https://github.com/technosophos/helm-template.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;options&gt;</c> via <see cref="HelmPluginInstallSettings.Options"/></li><li><c>&lt;paths&gt;</c> via <see cref="HelmPluginInstallSettings.Paths"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--version</c> via <see cref="HelmPluginInstallSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmPluginInstall(Configure<HelmPluginInstallSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmPluginInstallSettings()));
    /// <summary><p>This command allows you to install a plugin from a url to a VCS repo or a local path. Example usage:     $ helm plugin install https://github.com/technosophos/helm-template.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;options&gt;</c> via <see cref="HelmPluginInstallSettings.Options"/></li><li><c>&lt;paths&gt;</c> via <see cref="HelmPluginInstallSettings.Paths"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--version</c> via <see cref="HelmPluginInstallSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(HelmPluginInstallSettings Settings, IReadOnlyCollection<Output> Output)> HelmPluginInstall(CombinatorialConfigure<HelmPluginInstallSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmPluginInstall, degreeOfParallelism, completeOnFailure);
    /// <summary><p>List installed Helm plugins.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmPluginList(HelmPluginListSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>List installed Helm plugins.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmPluginList(Configure<HelmPluginListSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmPluginListSettings()));
    /// <summary><p>List installed Helm plugins.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IEnumerable<(HelmPluginListSettings Settings, IReadOnlyCollection<Output> Output)> HelmPluginList(CombinatorialConfigure<HelmPluginListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmPluginList, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Remove one or more Helm plugins.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginRemoveSettings.Plugins"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmPluginRemove(HelmPluginRemoveSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Remove one or more Helm plugins.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginRemoveSettings.Plugins"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmPluginRemove(Configure<HelmPluginRemoveSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmPluginRemoveSettings()));
    /// <summary><p>Remove one or more Helm plugins.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginRemoveSettings.Plugins"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IEnumerable<(HelmPluginRemoveSettings Settings, IReadOnlyCollection<Output> Output)> HelmPluginRemove(CombinatorialConfigure<HelmPluginRemoveSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmPluginRemove, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Update one or more Helm plugins.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginUpdateSettings.Plugins"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmPluginUpdate(HelmPluginUpdateSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Update one or more Helm plugins.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginUpdateSettings.Plugins"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmPluginUpdate(Configure<HelmPluginUpdateSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmPluginUpdateSettings()));
    /// <summary><p>Update one or more Helm plugins.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;plugins&gt;</c> via <see cref="HelmPluginUpdateSettings.Plugins"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IEnumerable<(HelmPluginUpdateSettings Settings, IReadOnlyCollection<Output> Output)> HelmPluginUpdate(CombinatorialConfigure<HelmPluginUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmPluginUpdate, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Add a chart repository.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="HelmRepoAddSettings.Name"/></li><li><c>&lt;url&gt;</c> via <see cref="HelmRepoAddSettings.Url"/></li><li><c>--ca-file</c> via <see cref="HelmRepoAddSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmRepoAddSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmRepoAddSettings.KeyFile"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--no-update</c> via <see cref="HelmRepoAddSettings.NoUpdate"/></li><li><c>--password</c> via <see cref="HelmRepoAddSettings.Password"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--username</c> via <see cref="HelmRepoAddSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmRepoAdd(HelmRepoAddSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Add a chart repository.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="HelmRepoAddSettings.Name"/></li><li><c>&lt;url&gt;</c> via <see cref="HelmRepoAddSettings.Url"/></li><li><c>--ca-file</c> via <see cref="HelmRepoAddSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmRepoAddSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmRepoAddSettings.KeyFile"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--no-update</c> via <see cref="HelmRepoAddSettings.NoUpdate"/></li><li><c>--password</c> via <see cref="HelmRepoAddSettings.Password"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--username</c> via <see cref="HelmRepoAddSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmRepoAdd(Configure<HelmRepoAddSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmRepoAddSettings()));
    /// <summary><p>Add a chart repository.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="HelmRepoAddSettings.Name"/></li><li><c>&lt;url&gt;</c> via <see cref="HelmRepoAddSettings.Url"/></li><li><c>--ca-file</c> via <see cref="HelmRepoAddSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmRepoAddSettings.CertFile"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--key-file</c> via <see cref="HelmRepoAddSettings.KeyFile"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--no-update</c> via <see cref="HelmRepoAddSettings.NoUpdate"/></li><li><c>--password</c> via <see cref="HelmRepoAddSettings.Password"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--username</c> via <see cref="HelmRepoAddSettings.Username"/></li></ul></remarks>
    public static IEnumerable<(HelmRepoAddSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoAdd(CombinatorialConfigure<HelmRepoAddSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmRepoAdd, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Read the current directory and generate an index file based on the charts found. This tool is used for creating an 'index.yaml' file for a chart repository. To set an absolute URL to the charts, use '--url' flag. To merge the generated index with an existing index file, use the '--merge' flag. In this case, the charts found in the current directory will be merged into the existing index, with local charts taking priority over existing charts.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;directory&gt;</c> via <see cref="HelmRepoIndexSettings.Directory"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--merge</c> via <see cref="HelmRepoIndexSettings.Merge"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--url</c> via <see cref="HelmRepoIndexSettings.Url"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmRepoIndex(HelmRepoIndexSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Read the current directory and generate an index file based on the charts found. This tool is used for creating an 'index.yaml' file for a chart repository. To set an absolute URL to the charts, use '--url' flag. To merge the generated index with an existing index file, use the '--merge' flag. In this case, the charts found in the current directory will be merged into the existing index, with local charts taking priority over existing charts.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;directory&gt;</c> via <see cref="HelmRepoIndexSettings.Directory"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--merge</c> via <see cref="HelmRepoIndexSettings.Merge"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--url</c> via <see cref="HelmRepoIndexSettings.Url"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmRepoIndex(Configure<HelmRepoIndexSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmRepoIndexSettings()));
    /// <summary><p>Read the current directory and generate an index file based on the charts found. This tool is used for creating an 'index.yaml' file for a chart repository. To set an absolute URL to the charts, use '--url' flag. To merge the generated index with an existing index file, use the '--merge' flag. In this case, the charts found in the current directory will be merged into the existing index, with local charts taking priority over existing charts.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;directory&gt;</c> via <see cref="HelmRepoIndexSettings.Directory"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--merge</c> via <see cref="HelmRepoIndexSettings.Merge"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--url</c> via <see cref="HelmRepoIndexSettings.Url"/></li></ul></remarks>
    public static IEnumerable<(HelmRepoIndexSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoIndex(CombinatorialConfigure<HelmRepoIndexSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmRepoIndex, degreeOfParallelism, completeOnFailure);
    /// <summary><p>List chart repositories.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmRepoList(HelmRepoListSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>List chart repositories.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmRepoList(Configure<HelmRepoListSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmRepoListSettings()));
    /// <summary><p>List chart repositories.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IEnumerable<(HelmRepoListSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoList(CombinatorialConfigure<HelmRepoListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmRepoList, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Remove a chart repository.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="HelmRepoRemoveSettings.Name"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmRepoRemove(HelmRepoRemoveSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Remove a chart repository.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="HelmRepoRemoveSettings.Name"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmRepoRemove(Configure<HelmRepoRemoveSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmRepoRemoveSettings()));
    /// <summary><p>Remove a chart repository.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="HelmRepoRemoveSettings.Name"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IEnumerable<(HelmRepoRemoveSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoRemove(CombinatorialConfigure<HelmRepoRemoveSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmRepoRemove, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Update gets the latest information about charts from the respective chart repositories. Information is cached locally, where it is used by commands like 'helm search'. 'helm update' is the deprecated form of 'helm repo update'. It will be removed in future releases.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--strict</c> via <see cref="HelmRepoUpdateSettings.Strict"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmRepoUpdate(HelmRepoUpdateSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Update gets the latest information about charts from the respective chart repositories. Information is cached locally, where it is used by commands like 'helm search'. 'helm update' is the deprecated form of 'helm repo update'. It will be removed in future releases.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--strict</c> via <see cref="HelmRepoUpdateSettings.Strict"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmRepoUpdate(Configure<HelmRepoUpdateSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmRepoUpdateSettings()));
    /// <summary><p>Update gets the latest information about charts from the respective chart repositories. Information is cached locally, where it is used by commands like 'helm search'. 'helm update' is the deprecated form of 'helm repo update'. It will be removed in future releases.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--strict</c> via <see cref="HelmRepoUpdateSettings.Strict"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IEnumerable<(HelmRepoUpdateSettings Settings, IReadOnlyCollection<Output> Output)> HelmRepoUpdate(CombinatorialConfigure<HelmRepoUpdateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmRepoUpdate, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command uninstalls Tiller (the Helm server-side component) from your Kubernetes Cluster and optionally deletes local configuration in $HELM_HOME (default ~/.helm/).</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--force</c> via <see cref="HelmResetSettings.Force"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--remove-helm-home</c> via <see cref="HelmResetSettings.RemoveHelmHome"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmResetSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmResetSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmResetSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmResetSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmResetSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmResetSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmReset(HelmResetSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command uninstalls Tiller (the Helm server-side component) from your Kubernetes Cluster and optionally deletes local configuration in $HELM_HOME (default ~/.helm/).</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--force</c> via <see cref="HelmResetSettings.Force"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--remove-helm-home</c> via <see cref="HelmResetSettings.RemoveHelmHome"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmResetSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmResetSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmResetSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmResetSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmResetSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmResetSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmReset(Configure<HelmResetSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmResetSettings()));
    /// <summary><p>This command uninstalls Tiller (the Helm server-side component) from your Kubernetes Cluster and optionally deletes local configuration in $HELM_HOME (default ~/.helm/).</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--force</c> via <see cref="HelmResetSettings.Force"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--remove-helm-home</c> via <see cref="HelmResetSettings.RemoveHelmHome"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmResetSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmResetSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmResetSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmResetSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmResetSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmResetSettings.TlsVerify"/></li></ul></remarks>
    public static IEnumerable<(HelmResetSettings Settings, IReadOnlyCollection<Output> Output)> HelmReset(CombinatorialConfigure<HelmResetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmReset, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command rolls back a release to a previous revision. The first argument of the rollback command is the name of a release, and the second is a revision (version) number. To see revision numbers, run 'helm history RELEASE'. If you'd like to rollback to the previous release use 'helm rollback [RELEASE] 0'.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;release&gt;</c> via <see cref="HelmRollbackSettings.Release"/></li><li><c>&lt;revision&gt;</c> via <see cref="HelmRollbackSettings.Revision"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--description</c> via <see cref="HelmRollbackSettings.Description"/></li><li><c>--dry-run</c> via <see cref="HelmRollbackSettings.DryRun"/></li><li><c>--force</c> via <see cref="HelmRollbackSettings.Force"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--no-hooks</c> via <see cref="HelmRollbackSettings.NoHooks"/></li><li><c>--recreate-pods</c> via <see cref="HelmRollbackSettings.RecreatePods"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmRollbackSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmRollbackSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmRollbackSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmRollbackSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmRollbackSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmRollbackSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmRollbackSettings.TlsVerify"/></li><li><c>--wait</c> via <see cref="HelmRollbackSettings.Wait"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmRollback(HelmRollbackSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command rolls back a release to a previous revision. The first argument of the rollback command is the name of a release, and the second is a revision (version) number. To see revision numbers, run 'helm history RELEASE'. If you'd like to rollback to the previous release use 'helm rollback [RELEASE] 0'.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;release&gt;</c> via <see cref="HelmRollbackSettings.Release"/></li><li><c>&lt;revision&gt;</c> via <see cref="HelmRollbackSettings.Revision"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--description</c> via <see cref="HelmRollbackSettings.Description"/></li><li><c>--dry-run</c> via <see cref="HelmRollbackSettings.DryRun"/></li><li><c>--force</c> via <see cref="HelmRollbackSettings.Force"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--no-hooks</c> via <see cref="HelmRollbackSettings.NoHooks"/></li><li><c>--recreate-pods</c> via <see cref="HelmRollbackSettings.RecreatePods"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmRollbackSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmRollbackSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmRollbackSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmRollbackSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmRollbackSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmRollbackSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmRollbackSettings.TlsVerify"/></li><li><c>--wait</c> via <see cref="HelmRollbackSettings.Wait"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmRollback(Configure<HelmRollbackSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmRollbackSettings()));
    /// <summary><p>This command rolls back a release to a previous revision. The first argument of the rollback command is the name of a release, and the second is a revision (version) number. To see revision numbers, run 'helm history RELEASE'. If you'd like to rollback to the previous release use 'helm rollback [RELEASE] 0'.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;release&gt;</c> via <see cref="HelmRollbackSettings.Release"/></li><li><c>&lt;revision&gt;</c> via <see cref="HelmRollbackSettings.Revision"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--description</c> via <see cref="HelmRollbackSettings.Description"/></li><li><c>--dry-run</c> via <see cref="HelmRollbackSettings.DryRun"/></li><li><c>--force</c> via <see cref="HelmRollbackSettings.Force"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--no-hooks</c> via <see cref="HelmRollbackSettings.NoHooks"/></li><li><c>--recreate-pods</c> via <see cref="HelmRollbackSettings.RecreatePods"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmRollbackSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmRollbackSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmRollbackSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmRollbackSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmRollbackSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmRollbackSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmRollbackSettings.TlsVerify"/></li><li><c>--wait</c> via <see cref="HelmRollbackSettings.Wait"/></li></ul></remarks>
    public static IEnumerable<(HelmRollbackSettings Settings, IReadOnlyCollection<Output> Output)> HelmRollback(CombinatorialConfigure<HelmRollbackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmRollback, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Search reads through all of the repositories configured on the system, and looks for matches. Repositories are managed with 'helm repo' commands.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;keyword&gt;</c> via <see cref="HelmSearchSettings.Keyword"/></li><li><c>--col-width</c> via <see cref="HelmSearchSettings.ColWidth"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--regexp</c> via <see cref="HelmSearchSettings.Regexp"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--version</c> via <see cref="HelmSearchSettings.Version"/></li><li><c>--versions</c> via <see cref="HelmSearchSettings.Versions"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmSearch(HelmSearchSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Search reads through all of the repositories configured on the system, and looks for matches. Repositories are managed with 'helm repo' commands.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;keyword&gt;</c> via <see cref="HelmSearchSettings.Keyword"/></li><li><c>--col-width</c> via <see cref="HelmSearchSettings.ColWidth"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--regexp</c> via <see cref="HelmSearchSettings.Regexp"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--version</c> via <see cref="HelmSearchSettings.Version"/></li><li><c>--versions</c> via <see cref="HelmSearchSettings.Versions"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmSearch(Configure<HelmSearchSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmSearchSettings()));
    /// <summary><p>Search reads through all of the repositories configured on the system, and looks for matches. Repositories are managed with 'helm repo' commands.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;keyword&gt;</c> via <see cref="HelmSearchSettings.Keyword"/></li><li><c>--col-width</c> via <see cref="HelmSearchSettings.ColWidth"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--regexp</c> via <see cref="HelmSearchSettings.Regexp"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--version</c> via <see cref="HelmSearchSettings.Version"/></li><li><c>--versions</c> via <see cref="HelmSearchSettings.Versions"/></li></ul></remarks>
    public static IEnumerable<(HelmSearchSettings Settings, IReadOnlyCollection<Output> Output)> HelmSearch(CombinatorialConfigure<HelmSearchSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmSearch, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command starts a local chart repository server that serves charts from a local directory. The new server will provide HTTP access to a repository. By default, it will scan all of the charts in '$HELM_HOME/repository/local' and serve those over the local IPv4 TCP port (default '127.0.0.1:8879'). This command is intended to be used for educational and testing purposes only. It is best to rely on a dedicated web server or a cloud-hosted solution like Google Cloud Storage for production use. See https://github.com/helm/helm/blob/master/docs/chart_repository.md#hosting-chart-repositories for more information on hosting chart repositories in a production setting.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--address</c> via <see cref="HelmServeSettings.Address"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--repo-path</c> via <see cref="HelmServeSettings.RepoPath"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--url</c> via <see cref="HelmServeSettings.Url"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmServe(HelmServeSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command starts a local chart repository server that serves charts from a local directory. The new server will provide HTTP access to a repository. By default, it will scan all of the charts in '$HELM_HOME/repository/local' and serve those over the local IPv4 TCP port (default '127.0.0.1:8879'). This command is intended to be used for educational and testing purposes only. It is best to rely on a dedicated web server or a cloud-hosted solution like Google Cloud Storage for production use. See https://github.com/helm/helm/blob/master/docs/chart_repository.md#hosting-chart-repositories for more information on hosting chart repositories in a production setting.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--address</c> via <see cref="HelmServeSettings.Address"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--repo-path</c> via <see cref="HelmServeSettings.RepoPath"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--url</c> via <see cref="HelmServeSettings.Url"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmServe(Configure<HelmServeSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmServeSettings()));
    /// <summary><p>This command starts a local chart repository server that serves charts from a local directory. The new server will provide HTTP access to a repository. By default, it will scan all of the charts in '$HELM_HOME/repository/local' and serve those over the local IPv4 TCP port (default '127.0.0.1:8879'). This command is intended to be used for educational and testing purposes only. It is best to rely on a dedicated web server or a cloud-hosted solution like Google Cloud Storage for production use. See https://github.com/helm/helm/blob/master/docs/chart_repository.md#hosting-chart-repositories for more information on hosting chart repositories in a production setting.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--address</c> via <see cref="HelmServeSettings.Address"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--repo-path</c> via <see cref="HelmServeSettings.RepoPath"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--url</c> via <see cref="HelmServeSettings.Url"/></li></ul></remarks>
    public static IEnumerable<(HelmServeSettings Settings, IReadOnlyCollection<Output> Output)> HelmServe(CombinatorialConfigure<HelmServeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmServe, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command shows the status of a named release. The status consists of: - last deployment time - k8s namespace in which the release lives - state of the release (can be: UNKNOWN, DEPLOYED, DELETED, SUPERSEDED, FAILED or DELETING) - list of resources that this release consists of, sorted by kind - details on last test suite run, if applicable - additional notes provided by the chart.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmStatusSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--output</c> via <see cref="HelmStatusSettings.Output"/></li><li><c>--revision</c> via <see cref="HelmStatusSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmStatusSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmStatusSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmStatusSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmStatusSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmStatusSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmStatusSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmStatus(HelmStatusSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command shows the status of a named release. The status consists of: - last deployment time - k8s namespace in which the release lives - state of the release (can be: UNKNOWN, DEPLOYED, DELETED, SUPERSEDED, FAILED or DELETING) - list of resources that this release consists of, sorted by kind - details on last test suite run, if applicable - additional notes provided by the chart.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmStatusSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--output</c> via <see cref="HelmStatusSettings.Output"/></li><li><c>--revision</c> via <see cref="HelmStatusSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmStatusSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmStatusSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmStatusSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmStatusSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmStatusSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmStatusSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmStatus(Configure<HelmStatusSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmStatusSettings()));
    /// <summary><p>This command shows the status of a named release. The status consists of: - last deployment time - k8s namespace in which the release lives - state of the release (can be: UNKNOWN, DEPLOYED, DELETED, SUPERSEDED, FAILED or DELETING) - list of resources that this release consists of, sorted by kind - details on last test suite run, if applicable - additional notes provided by the chart.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;releaseName&gt;</c> via <see cref="HelmStatusSettings.ReleaseName"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--output</c> via <see cref="HelmStatusSettings.Output"/></li><li><c>--revision</c> via <see cref="HelmStatusSettings.Revision"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmStatusSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmStatusSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmStatusSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmStatusSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmStatusSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmStatusSettings.TlsVerify"/></li></ul></remarks>
    public static IEnumerable<(HelmStatusSettings Settings, IReadOnlyCollection<Output> Output)> HelmStatus(CombinatorialConfigure<HelmStatusSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmStatus, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Render chart templates locally and display the output. This does not require Tiller. However, any values that would normally be looked up or retrieved in-cluster will be faked locally. Additionally, none of the server-side testing of chart validity (e.g. whether an API is supported) is done. To render just one template in a chart, use '-x': 	$ helm template mychart -x templates/deployment.yaml.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmTemplateSettings.Chart"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--execute</c> via <see cref="HelmTemplateSettings.Execute"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--is-upgrade</c> via <see cref="HelmTemplateSettings.IsUpgrade"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kube-version</c> via <see cref="HelmTemplateSettings.KubeVersion"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--name</c> via <see cref="HelmTemplateSettings.Name"/></li><li><c>--name-template</c> via <see cref="HelmTemplateSettings.NameTemplate"/></li><li><c>--namespace</c> via <see cref="HelmTemplateSettings.Namespace"/></li><li><c>--notes</c> via <see cref="HelmTemplateSettings.Notes"/></li><li><c>--output-dir</c> via <see cref="HelmTemplateSettings.OutputDir"/></li><li><c>--set</c> via <see cref="HelmTemplateSettings.Set"/></li><li><c>--set-file</c> via <see cref="HelmTemplateSettings.SetFile"/></li><li><c>--set-string</c> via <see cref="HelmTemplateSettings.SetString"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--values</c> via <see cref="HelmTemplateSettings.Values"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmTemplate(HelmTemplateSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Render chart templates locally and display the output. This does not require Tiller. However, any values that would normally be looked up or retrieved in-cluster will be faked locally. Additionally, none of the server-side testing of chart validity (e.g. whether an API is supported) is done. To render just one template in a chart, use '-x': 	$ helm template mychart -x templates/deployment.yaml.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmTemplateSettings.Chart"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--execute</c> via <see cref="HelmTemplateSettings.Execute"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--is-upgrade</c> via <see cref="HelmTemplateSettings.IsUpgrade"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kube-version</c> via <see cref="HelmTemplateSettings.KubeVersion"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--name</c> via <see cref="HelmTemplateSettings.Name"/></li><li><c>--name-template</c> via <see cref="HelmTemplateSettings.NameTemplate"/></li><li><c>--namespace</c> via <see cref="HelmTemplateSettings.Namespace"/></li><li><c>--notes</c> via <see cref="HelmTemplateSettings.Notes"/></li><li><c>--output-dir</c> via <see cref="HelmTemplateSettings.OutputDir"/></li><li><c>--set</c> via <see cref="HelmTemplateSettings.Set"/></li><li><c>--set-file</c> via <see cref="HelmTemplateSettings.SetFile"/></li><li><c>--set-string</c> via <see cref="HelmTemplateSettings.SetString"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--values</c> via <see cref="HelmTemplateSettings.Values"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmTemplate(Configure<HelmTemplateSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmTemplateSettings()));
    /// <summary><p>Render chart templates locally and display the output. This does not require Tiller. However, any values that would normally be looked up or retrieved in-cluster will be faked locally. Additionally, none of the server-side testing of chart validity (e.g. whether an API is supported) is done. To render just one template in a chart, use '-x': 	$ helm template mychart -x templates/deployment.yaml.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmTemplateSettings.Chart"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--execute</c> via <see cref="HelmTemplateSettings.Execute"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--is-upgrade</c> via <see cref="HelmTemplateSettings.IsUpgrade"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kube-version</c> via <see cref="HelmTemplateSettings.KubeVersion"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--name</c> via <see cref="HelmTemplateSettings.Name"/></li><li><c>--name-template</c> via <see cref="HelmTemplateSettings.NameTemplate"/></li><li><c>--namespace</c> via <see cref="HelmTemplateSettings.Namespace"/></li><li><c>--notes</c> via <see cref="HelmTemplateSettings.Notes"/></li><li><c>--output-dir</c> via <see cref="HelmTemplateSettings.OutputDir"/></li><li><c>--set</c> via <see cref="HelmTemplateSettings.Set"/></li><li><c>--set-file</c> via <see cref="HelmTemplateSettings.SetFile"/></li><li><c>--set-string</c> via <see cref="HelmTemplateSettings.SetString"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--values</c> via <see cref="HelmTemplateSettings.Values"/></li></ul></remarks>
    public static IEnumerable<(HelmTemplateSettings Settings, IReadOnlyCollection<Output> Output)> HelmTemplate(CombinatorialConfigure<HelmTemplateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmTemplate, degreeOfParallelism, completeOnFailure);
    /// <summary><p>The test command runs the tests for a release. The argument this command takes is the name of a deployed release. The tests to be run are defined in the chart that was installed.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;release&gt;</c> via <see cref="HelmTestSettings.Release"/></li><li><c>--cleanup</c> via <see cref="HelmTestSettings.Cleanup"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--parallel</c> via <see cref="HelmTestSettings.Parallel"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmTestSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmTestSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmTestSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmTestSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmTestSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmTestSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmTestSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmTest(HelmTestSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>The test command runs the tests for a release. The argument this command takes is the name of a deployed release. The tests to be run are defined in the chart that was installed.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;release&gt;</c> via <see cref="HelmTestSettings.Release"/></li><li><c>--cleanup</c> via <see cref="HelmTestSettings.Cleanup"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--parallel</c> via <see cref="HelmTestSettings.Parallel"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmTestSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmTestSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmTestSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmTestSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmTestSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmTestSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmTestSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmTest(Configure<HelmTestSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmTestSettings()));
    /// <summary><p>The test command runs the tests for a release. The argument this command takes is the name of a deployed release. The tests to be run are defined in the chart that was installed.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;release&gt;</c> via <see cref="HelmTestSettings.Release"/></li><li><c>--cleanup</c> via <see cref="HelmTestSettings.Cleanup"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--parallel</c> via <see cref="HelmTestSettings.Parallel"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmTestSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmTestSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmTestSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmTestSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmTestSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmTestSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmTestSettings.TlsVerify"/></li></ul></remarks>
    public static IEnumerable<(HelmTestSettings Settings, IReadOnlyCollection<Output> Output)> HelmTest(CombinatorialConfigure<HelmTestSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmTest, degreeOfParallelism, completeOnFailure);
    /// <summary><p>This command upgrades a release to a specified version of a chart and/or updates chart values. Required arguments are release and chart. The chart argument can be one of:  - a chart reference('stable/mariadb'); use '--version' and '--devel' flags for versions other than latest,  - a path to a chart directory,  - a packaged chart,  - a fully qualified URL. To customize the chart values, use any of  - '--values'/'-f' to pass in a yaml file holding settings,  - '--set' to provide one or more key=val pairs directly,  - '--set-string' to provide key=val forcing val to be stored as a string,  - '--set-file' to provide key=path to read a single large value from a file at path. To edit or append to the existing customized values, add the  '--reuse-values' flag, otherwise any existing customized values are ignored. If no chart value arguments are provided on the command line, any existing customized values are carried forward. If you want to revert to just the values provided in the chart, use the '--reset-values' flag. You can specify any of the chart value flags multiple times. The priority will be given to the last (right-most) value specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence: 	$ helm upgrade -f myvalues.yaml -f override.yaml redis ./redis Note that the key name provided to the '--set', '--set-string' and '--set-file' flags can reference structure elements. Examples:   - mybool=TRUE   - livenessProbe.timeoutSeconds=10   - metrics.annotations[0]=hey,metrics.annotations[1]=ho which sets the top level key mybool to true, the nested timeoutSeconds to 10, and two array values, respectively. Note that the value side of the key=val provided to '--set' and '--set-string' flags will pass through shell evaluation followed by yaml type parsing to produce the final value. This may alter inputs with special characters in unexpected ways, for example 	$ helm upgrade --set pwd=3jk$o2,z=f\30.e redis ./redis results in "pwd: 3jk" and "z: f30.e". Use single quotes to avoid shell evaluation and argument delimiters, and use backslash to escape yaml special characters: 	$ helm upgrade --set pwd='3jk$o2z=f\\30.e' redis ./redis which results in the expected "pwd: 3jk$o2z=f\30.e". If a single quote occurs in your value then follow your shell convention for escaping it; for example in bash: 	$ helm upgrade --set pwd='3jk$o2z=f\\30with'\''quote' which results in "pwd: 3jk$o2z=f\30with'quote".</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmUpgradeSettings.Chart"/></li><li><c>&lt;release&gt;</c> via <see cref="HelmUpgradeSettings.Release"/></li><li><c>--atomic</c> via <see cref="HelmUpgradeSettings.Atomic"/></li><li><c>--ca-file</c> via <see cref="HelmUpgradeSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmUpgradeSettings.CertFile"/></li><li><c>--create-namespace</c> via <see cref="HelmUpgradeSettings.CreateNamespace"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--description</c> via <see cref="HelmUpgradeSettings.Description"/></li><li><c>--devel</c> via <see cref="HelmUpgradeSettings.Devel"/></li><li><c>--dry-run</c> via <see cref="HelmUpgradeSettings.DryRun"/></li><li><c>--force</c> via <see cref="HelmUpgradeSettings.Force"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--install</c> via <see cref="HelmUpgradeSettings.Install"/></li><li><c>--key-file</c> via <see cref="HelmUpgradeSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmUpgradeSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--namespace</c> via <see cref="HelmUpgradeSettings.Namespace"/></li><li><c>--no-hooks</c> via <see cref="HelmUpgradeSettings.NoHooks"/></li><li><c>--password</c> via <see cref="HelmUpgradeSettings.Password"/></li><li><c>--recreate-pods</c> via <see cref="HelmUpgradeSettings.RecreatePods"/></li><li><c>--render-subchart-notes</c> via <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></li><li><c>--repo</c> via <see cref="HelmUpgradeSettings.Repo"/></li><li><c>--reset-values</c> via <see cref="HelmUpgradeSettings.ResetValues"/></li><li><c>--reuse-values</c> via <see cref="HelmUpgradeSettings.ReuseValues"/></li><li><c>--set</c> via <see cref="HelmUpgradeSettings.Set"/></li><li><c>--set-file</c> via <see cref="HelmUpgradeSettings.SetFile"/></li><li><c>--set-string</c> via <see cref="HelmUpgradeSettings.SetString"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmUpgradeSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmUpgradeSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmUpgradeSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmUpgradeSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmUpgradeSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmUpgradeSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmUpgradeSettings.TlsVerify"/></li><li><c>--username</c> via <see cref="HelmUpgradeSettings.Username"/></li><li><c>--values</c> via <see cref="HelmUpgradeSettings.Values"/></li><li><c>--verify</c> via <see cref="HelmUpgradeSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmUpgradeSettings.Version"/></li><li><c>--wait</c> via <see cref="HelmUpgradeSettings.Wait"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmUpgrade(HelmUpgradeSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>This command upgrades a release to a specified version of a chart and/or updates chart values. Required arguments are release and chart. The chart argument can be one of:  - a chart reference('stable/mariadb'); use '--version' and '--devel' flags for versions other than latest,  - a path to a chart directory,  - a packaged chart,  - a fully qualified URL. To customize the chart values, use any of  - '--values'/'-f' to pass in a yaml file holding settings,  - '--set' to provide one or more key=val pairs directly,  - '--set-string' to provide key=val forcing val to be stored as a string,  - '--set-file' to provide key=path to read a single large value from a file at path. To edit or append to the existing customized values, add the  '--reuse-values' flag, otherwise any existing customized values are ignored. If no chart value arguments are provided on the command line, any existing customized values are carried forward. If you want to revert to just the values provided in the chart, use the '--reset-values' flag. You can specify any of the chart value flags multiple times. The priority will be given to the last (right-most) value specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence: 	$ helm upgrade -f myvalues.yaml -f override.yaml redis ./redis Note that the key name provided to the '--set', '--set-string' and '--set-file' flags can reference structure elements. Examples:   - mybool=TRUE   - livenessProbe.timeoutSeconds=10   - metrics.annotations[0]=hey,metrics.annotations[1]=ho which sets the top level key mybool to true, the nested timeoutSeconds to 10, and two array values, respectively. Note that the value side of the key=val provided to '--set' and '--set-string' flags will pass through shell evaluation followed by yaml type parsing to produce the final value. This may alter inputs with special characters in unexpected ways, for example 	$ helm upgrade --set pwd=3jk$o2,z=f\30.e redis ./redis results in "pwd: 3jk" and "z: f30.e". Use single quotes to avoid shell evaluation and argument delimiters, and use backslash to escape yaml special characters: 	$ helm upgrade --set pwd='3jk$o2z=f\\30.e' redis ./redis which results in the expected "pwd: 3jk$o2z=f\30.e". If a single quote occurs in your value then follow your shell convention for escaping it; for example in bash: 	$ helm upgrade --set pwd='3jk$o2z=f\\30with'\''quote' which results in "pwd: 3jk$o2z=f\30with'quote".</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmUpgradeSettings.Chart"/></li><li><c>&lt;release&gt;</c> via <see cref="HelmUpgradeSettings.Release"/></li><li><c>--atomic</c> via <see cref="HelmUpgradeSettings.Atomic"/></li><li><c>--ca-file</c> via <see cref="HelmUpgradeSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmUpgradeSettings.CertFile"/></li><li><c>--create-namespace</c> via <see cref="HelmUpgradeSettings.CreateNamespace"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--description</c> via <see cref="HelmUpgradeSettings.Description"/></li><li><c>--devel</c> via <see cref="HelmUpgradeSettings.Devel"/></li><li><c>--dry-run</c> via <see cref="HelmUpgradeSettings.DryRun"/></li><li><c>--force</c> via <see cref="HelmUpgradeSettings.Force"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--install</c> via <see cref="HelmUpgradeSettings.Install"/></li><li><c>--key-file</c> via <see cref="HelmUpgradeSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmUpgradeSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--namespace</c> via <see cref="HelmUpgradeSettings.Namespace"/></li><li><c>--no-hooks</c> via <see cref="HelmUpgradeSettings.NoHooks"/></li><li><c>--password</c> via <see cref="HelmUpgradeSettings.Password"/></li><li><c>--recreate-pods</c> via <see cref="HelmUpgradeSettings.RecreatePods"/></li><li><c>--render-subchart-notes</c> via <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></li><li><c>--repo</c> via <see cref="HelmUpgradeSettings.Repo"/></li><li><c>--reset-values</c> via <see cref="HelmUpgradeSettings.ResetValues"/></li><li><c>--reuse-values</c> via <see cref="HelmUpgradeSettings.ReuseValues"/></li><li><c>--set</c> via <see cref="HelmUpgradeSettings.Set"/></li><li><c>--set-file</c> via <see cref="HelmUpgradeSettings.SetFile"/></li><li><c>--set-string</c> via <see cref="HelmUpgradeSettings.SetString"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmUpgradeSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmUpgradeSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmUpgradeSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmUpgradeSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmUpgradeSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmUpgradeSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmUpgradeSettings.TlsVerify"/></li><li><c>--username</c> via <see cref="HelmUpgradeSettings.Username"/></li><li><c>--values</c> via <see cref="HelmUpgradeSettings.Values"/></li><li><c>--verify</c> via <see cref="HelmUpgradeSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmUpgradeSettings.Version"/></li><li><c>--wait</c> via <see cref="HelmUpgradeSettings.Wait"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmUpgrade(Configure<HelmUpgradeSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmUpgradeSettings()));
    /// <summary><p>This command upgrades a release to a specified version of a chart and/or updates chart values. Required arguments are release and chart. The chart argument can be one of:  - a chart reference('stable/mariadb'); use '--version' and '--devel' flags for versions other than latest,  - a path to a chart directory,  - a packaged chart,  - a fully qualified URL. To customize the chart values, use any of  - '--values'/'-f' to pass in a yaml file holding settings,  - '--set' to provide one or more key=val pairs directly,  - '--set-string' to provide key=val forcing val to be stored as a string,  - '--set-file' to provide key=path to read a single large value from a file at path. To edit or append to the existing customized values, add the  '--reuse-values' flag, otherwise any existing customized values are ignored. If no chart value arguments are provided on the command line, any existing customized values are carried forward. If you want to revert to just the values provided in the chart, use the '--reset-values' flag. You can specify any of the chart value flags multiple times. The priority will be given to the last (right-most) value specified. For example, if both myvalues.yaml and override.yaml contained a key called 'Test', the value set in override.yaml would take precedence: 	$ helm upgrade -f myvalues.yaml -f override.yaml redis ./redis Note that the key name provided to the '--set', '--set-string' and '--set-file' flags can reference structure elements. Examples:   - mybool=TRUE   - livenessProbe.timeoutSeconds=10   - metrics.annotations[0]=hey,metrics.annotations[1]=ho which sets the top level key mybool to true, the nested timeoutSeconds to 10, and two array values, respectively. Note that the value side of the key=val provided to '--set' and '--set-string' flags will pass through shell evaluation followed by yaml type parsing to produce the final value. This may alter inputs with special characters in unexpected ways, for example 	$ helm upgrade --set pwd=3jk$o2,z=f\30.e redis ./redis results in "pwd: 3jk" and "z: f30.e". Use single quotes to avoid shell evaluation and argument delimiters, and use backslash to escape yaml special characters: 	$ helm upgrade --set pwd='3jk$o2z=f\\30.e' redis ./redis which results in the expected "pwd: 3jk$o2z=f\30.e". If a single quote occurs in your value then follow your shell convention for escaping it; for example in bash: 	$ helm upgrade --set pwd='3jk$o2z=f\\30with'\''quote' which results in "pwd: 3jk$o2z=f\30with'quote".</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;chart&gt;</c> via <see cref="HelmUpgradeSettings.Chart"/></li><li><c>&lt;release&gt;</c> via <see cref="HelmUpgradeSettings.Release"/></li><li><c>--atomic</c> via <see cref="HelmUpgradeSettings.Atomic"/></li><li><c>--ca-file</c> via <see cref="HelmUpgradeSettings.CaFile"/></li><li><c>--cert-file</c> via <see cref="HelmUpgradeSettings.CertFile"/></li><li><c>--create-namespace</c> via <see cref="HelmUpgradeSettings.CreateNamespace"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--description</c> via <see cref="HelmUpgradeSettings.Description"/></li><li><c>--devel</c> via <see cref="HelmUpgradeSettings.Devel"/></li><li><c>--dry-run</c> via <see cref="HelmUpgradeSettings.DryRun"/></li><li><c>--force</c> via <see cref="HelmUpgradeSettings.Force"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--install</c> via <see cref="HelmUpgradeSettings.Install"/></li><li><c>--key-file</c> via <see cref="HelmUpgradeSettings.KeyFile"/></li><li><c>--keyring</c> via <see cref="HelmUpgradeSettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--namespace</c> via <see cref="HelmUpgradeSettings.Namespace"/></li><li><c>--no-hooks</c> via <see cref="HelmUpgradeSettings.NoHooks"/></li><li><c>--password</c> via <see cref="HelmUpgradeSettings.Password"/></li><li><c>--recreate-pods</c> via <see cref="HelmUpgradeSettings.RecreatePods"/></li><li><c>--render-subchart-notes</c> via <see cref="HelmUpgradeSettings.RenderSubchartNotes"/></li><li><c>--repo</c> via <see cref="HelmUpgradeSettings.Repo"/></li><li><c>--reset-values</c> via <see cref="HelmUpgradeSettings.ResetValues"/></li><li><c>--reuse-values</c> via <see cref="HelmUpgradeSettings.ReuseValues"/></li><li><c>--set</c> via <see cref="HelmUpgradeSettings.Set"/></li><li><c>--set-file</c> via <see cref="HelmUpgradeSettings.SetFile"/></li><li><c>--set-string</c> via <see cref="HelmUpgradeSettings.SetString"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--timeout</c> via <see cref="HelmUpgradeSettings.Timeout"/></li><li><c>--tls</c> via <see cref="HelmUpgradeSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmUpgradeSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmUpgradeSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmUpgradeSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmUpgradeSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmUpgradeSettings.TlsVerify"/></li><li><c>--username</c> via <see cref="HelmUpgradeSettings.Username"/></li><li><c>--values</c> via <see cref="HelmUpgradeSettings.Values"/></li><li><c>--verify</c> via <see cref="HelmUpgradeSettings.Verify"/></li><li><c>--version</c> via <see cref="HelmUpgradeSettings.Version"/></li><li><c>--wait</c> via <see cref="HelmUpgradeSettings.Wait"/></li></ul></remarks>
    public static IEnumerable<(HelmUpgradeSettings Settings, IReadOnlyCollection<Output> Output)> HelmUpgrade(CombinatorialConfigure<HelmUpgradeSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmUpgrade, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Verify that the given chart has a valid provenance file. Provenance files provide crytographic verification that a chart has not been tampered with, and was packaged by a trusted provider. This command can be used to verify a local chart. Several other commands provide '--verify' flags that run the same validation. To generate a signed package, use the 'helm package --sign' command.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;path&gt;</c> via <see cref="HelmVerifySettings.Path"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--keyring</c> via <see cref="HelmVerifySettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmVerify(HelmVerifySettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Verify that the given chart has a valid provenance file. Provenance files provide crytographic verification that a chart has not been tampered with, and was packaged by a trusted provider. This command can be used to verify a local chart. Several other commands provide '--verify' flags that run the same validation. To generate a signed package, use the 'helm package --sign' command.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;path&gt;</c> via <see cref="HelmVerifySettings.Path"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--keyring</c> via <see cref="HelmVerifySettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmVerify(Configure<HelmVerifySettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmVerifySettings()));
    /// <summary><p>Verify that the given chart has a valid provenance file. Provenance files provide crytographic verification that a chart has not been tampered with, and was packaged by a trusted provider. This command can be used to verify a local chart. Several other commands provide '--verify' flags that run the same validation. To generate a signed package, use the 'helm package --sign' command.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;path&gt;</c> via <see cref="HelmVerifySettings.Path"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--keyring</c> via <see cref="HelmVerifySettings.Keyring"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li></ul></remarks>
    public static IEnumerable<(HelmVerifySettings Settings, IReadOnlyCollection<Output> Output)> HelmVerify(CombinatorialConfigure<HelmVerifySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmVerify, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Show the client and server versions for Helm and tiller. This will print a representation of the client and server versions of Helm and Tiller. The output will look something like this: Client: &amp;version.Version{SemVer:"v2.0.0", GitCommit:"ff52399e51bb880526e9cd0ed8386f6433b74da1", GitTreeState:"clean"} Server: &amp;version.Version{SemVer:"v2.0.0", GitCommit:"b0c113dfb9f612a9add796549da66c0d294508a3", GitTreeState:"clean"} - SemVer is the semantic version of the release. - GitCommit is the SHA for the commit that this version was built from. - GitTreeState is "clean" if there are no local code changes when this binary was   built, and "dirty" if the binary was built from locally modified code. To print just the client version, use '--client'. To print just the server version, use '--server'.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--client</c> via <see cref="HelmVersionSettings.Client"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--server</c> via <see cref="HelmVersionSettings.Server"/></li><li><c>--short</c> via <see cref="HelmVersionSettings.Short"/></li><li><c>--template</c> via <see cref="HelmVersionSettings.Template"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmVersionSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmVersionSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmVersionSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmVersionSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmVersionSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmVersionSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmVersion(HelmVersionSettings options = null) => new HelmTasks().Run(options);
    /// <summary><p>Show the client and server versions for Helm and tiller. This will print a representation of the client and server versions of Helm and Tiller. The output will look something like this: Client: &amp;version.Version{SemVer:"v2.0.0", GitCommit:"ff52399e51bb880526e9cd0ed8386f6433b74da1", GitTreeState:"clean"} Server: &amp;version.Version{SemVer:"v2.0.0", GitCommit:"b0c113dfb9f612a9add796549da66c0d294508a3", GitTreeState:"clean"} - SemVer is the semantic version of the release. - GitCommit is the SHA for the commit that this version was built from. - GitTreeState is "clean" if there are no local code changes when this binary was   built, and "dirty" if the binary was built from locally modified code. To print just the client version, use '--client'. To print just the server version, use '--server'.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--client</c> via <see cref="HelmVersionSettings.Client"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--server</c> via <see cref="HelmVersionSettings.Server"/></li><li><c>--short</c> via <see cref="HelmVersionSettings.Short"/></li><li><c>--template</c> via <see cref="HelmVersionSettings.Template"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmVersionSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmVersionSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmVersionSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmVersionSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmVersionSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmVersionSettings.TlsVerify"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> HelmVersion(Configure<HelmVersionSettings> configurator) => new HelmTasks().Run(configurator.Invoke(new HelmVersionSettings()));
    /// <summary><p>Show the client and server versions for Helm and tiller. This will print a representation of the client and server versions of Helm and Tiller. The output will look something like this: Client: &amp;version.Version{SemVer:"v2.0.0", GitCommit:"ff52399e51bb880526e9cd0ed8386f6433b74da1", GitTreeState:"clean"} Server: &amp;version.Version{SemVer:"v2.0.0", GitCommit:"b0c113dfb9f612a9add796549da66c0d294508a3", GitTreeState:"clean"} - SemVer is the semantic version of the release. - GitCommit is the SHA for the commit that this version was built from. - GitTreeState is "clean" if there are no local code changes when this binary was   built, and "dirty" if the binary was built from locally modified code. To print just the client version, use '--client'. To print just the server version, use '--server'.</p><p>For more details, visit the <a href="https://helm.sh/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--client</c> via <see cref="HelmVersionSettings.Client"/></li><li><c>--debug</c> via <see cref="HelmOptionsBase.Debug"/></li><li><c>--home</c> via <see cref="HelmOptionsBase.Home"/></li><li><c>--host</c> via <see cref="HelmOptionsBase.Host"/></li><li><c>--kube-context</c> via <see cref="HelmOptionsBase.KubeContext"/></li><li><c>--kubeconfig</c> via <see cref="HelmOptionsBase.Kubeconfig"/></li><li><c>--server</c> via <see cref="HelmVersionSettings.Server"/></li><li><c>--short</c> via <see cref="HelmVersionSettings.Short"/></li><li><c>--template</c> via <see cref="HelmVersionSettings.Template"/></li><li><c>--tiller-connection-timeout</c> via <see cref="HelmOptionsBase.TillerConnectionTimeout"/></li><li><c>--tiller-namespace</c> via <see cref="HelmOptionsBase.TillerNamespace"/></li><li><c>--tls</c> via <see cref="HelmVersionSettings.Tls"/></li><li><c>--tls-ca-cert</c> via <see cref="HelmVersionSettings.TlsCaCert"/></li><li><c>--tls-cert</c> via <see cref="HelmVersionSettings.TlsCert"/></li><li><c>--tls-hostname</c> via <see cref="HelmVersionSettings.TlsHostname"/></li><li><c>--tls-key</c> via <see cref="HelmVersionSettings.TlsKey"/></li><li><c>--tls-verify</c> via <see cref="HelmVersionSettings.TlsVerify"/></li></ul></remarks>
    public static IEnumerable<(HelmVersionSettings Settings, IReadOnlyCollection<Output> Output)> HelmVersion(CombinatorialConfigure<HelmVersionSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(HelmVersion, degreeOfParallelism, completeOnFailure);
}
#region HelmCompletionSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmCompletionSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmCompletion), Arguments = "completion")]
public partial class HelmCompletionSettings : HelmOptionsBase
{
    /// <summary></summary>
    [Argument(Format = "{value}")] public string Shell => Get<string>(() => Shell);
}
#endregion
#region HelmCreateSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmCreateSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmCreate), Arguments = "create")]
public partial class HelmCreateSettings : HelmOptionsBase
{
    /// <summary>The named Helm starter scaffold.</summary>
    [Argument(Format = "--starter {value}", Secret = false)] public string Starter => Get<string>(() => Starter);
    /// <summary>The name of chart directory to create.</summary>
    [Argument(Format = "{value}")] public string Name => Get<string>(() => Name);
}
#endregion
#region HelmDeleteSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmDeleteSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmDelete), Arguments = "delete")]
public partial class HelmDeleteSettings : HelmOptionsBase
{
    /// <summary>Specify a description for the release.</summary>
    [Argument(Format = "--description {value}", Secret = false)] public string Description => Get<string>(() => Description);
    /// <summary>Simulate a delete.</summary>
    [Argument(Format = "--dry-run", Secret = false)] public bool? DryRun => Get<bool?>(() => DryRun);
    /// <summary>Prevent hooks from running during deletion.</summary>
    [Argument(Format = "--no-hooks", Secret = false)] public bool? NoHooks => Get<bool?>(() => NoHooks);
    /// <summary>Remove the release from the store and make its name free for later use.</summary>
    [Argument(Format = "--purge", Secret = false)] public bool? Purge => Get<bool?>(() => Purge);
    /// <summary>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</summary>
    [Argument(Format = "--timeout {value}s", Secret = false)] public long? Timeout => Get<long?>(() => Timeout);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary>The name of the releases to delete.</summary>
    [Argument(Format = "{value}", Separator = " ")] public IReadOnlyList<string> ReleaseNames => Get<List<string>>(() => ReleaseNames);
}
#endregion
#region HelmDependencyBuildSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmDependencyBuildSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmDependencyBuild), Arguments = "dependency build")]
public partial class HelmDependencyBuildSettings : HelmOptionsBase
{
    /// <summary>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</summary>
    [Argument(Format = "--keyring {value}", Secret = false)] public string Keyring => Get<string>(() => Keyring);
    /// <summary>Verify the packages against signatures.</summary>
    [Argument(Format = "--verify", Secret = false)] public bool? Verify => Get<bool?>(() => Verify);
    /// <summary>The name of the chart to build.</summary>
    [Argument(Format = "{value}")] public string Chart => Get<string>(() => Chart);
}
#endregion
#region HelmDependencyListSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmDependencyListSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmDependencyList), Arguments = "dependency list")]
public partial class HelmDependencyListSettings : HelmOptionsBase
{
    /// <summary>The name of the chart to list.</summary>
    [Argument(Format = "{value}")] public string Chart => Get<string>(() => Chart);
}
#endregion
#region HelmDependencyUpdateSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmDependencyUpdateSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmDependencyUpdate), Arguments = "dependency update")]
public partial class HelmDependencyUpdateSettings : HelmOptionsBase
{
    /// <summary>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</summary>
    [Argument(Format = "--keyring {value}", Secret = false)] public string Keyring => Get<string>(() => Keyring);
    /// <summary>Do not refresh the local repository cache.</summary>
    [Argument(Format = "--skip-refresh", Secret = false)] public bool? SkipRefresh => Get<bool?>(() => SkipRefresh);
    /// <summary>Verify the packages against signatures.</summary>
    [Argument(Format = "--verify", Secret = false)] public bool? Verify => Get<bool?>(() => Verify);
    /// <summary>The name of the chart to update.</summary>
    [Argument(Format = "{value}")] public string Chart => Get<string>(() => Chart);
}
#endregion
#region HelmFetchSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmFetchSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmFetch), Arguments = "fetch")]
public partial class HelmFetchSettings : HelmOptionsBase
{
    /// <summary>Verify certificates of HTTPS-enabled servers using this CA bundle.</summary>
    [Argument(Format = "--ca-file {value}", Secret = false)] public string CaFile => Get<string>(() => CaFile);
    /// <summary>Identify HTTPS client using this SSL certificate file.</summary>
    [Argument(Format = "--cert-file {value}", Secret = false)] public string CertFile => Get<string>(() => CertFile);
    /// <summary>Location to write the chart. If this and tardir are specified, tardir is appended to this (default ".").</summary>
    [Argument(Format = "--destination {value}", Secret = false)] public string Destination => Get<string>(() => Destination);
    /// <summary>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</summary>
    [Argument(Format = "--devel", Secret = false)] public bool? Devel => Get<bool?>(() => Devel);
    /// <summary>Identify HTTPS client using this SSL key file.</summary>
    [Argument(Format = "--key-file {value}", Secret = false)] public string KeyFile => Get<string>(() => KeyFile);
    /// <summary>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</summary>
    [Argument(Format = "--keyring {value}", Secret = false)] public string Keyring => Get<string>(() => Keyring);
    /// <summary>Chart repository password.</summary>
    [Argument(Format = "--password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Fetch the provenance file, but don't perform verification.</summary>
    [Argument(Format = "--prov", Secret = false)] public bool? Prov => Get<bool?>(() => Prov);
    /// <summary>Chart repository url where to locate the requested chart.</summary>
    [Argument(Format = "--repo {value}", Secret = false)] public string Repo => Get<string>(() => Repo);
    /// <summary>If set to true, will untar the chart after downloading it.</summary>
    [Argument(Format = "--untar", Secret = false)] public bool? Untar => Get<bool?>(() => Untar);
    /// <summary>If untar is specified, this flag specifies the name of the directory into which the chart is expanded (default ".").</summary>
    [Argument(Format = "--untardir {value}", Secret = false)] public string Untardir => Get<string>(() => Untardir);
    /// <summary>Chart repository username.</summary>
    [Argument(Format = "--username {value}", Secret = false)] public string Username => Get<string>(() => Username);
    /// <summary>Verify the package against its signature.</summary>
    [Argument(Format = "--verify", Secret = false)] public bool? Verify => Get<bool?>(() => Verify);
    /// <summary>Specific version of a chart. Without this, the latest version is fetched.</summary>
    [Argument(Format = "--version {value}", Secret = false)] public string Version => Get<string>(() => Version);
    /// <summary>The charts to fetch. Can either be specified by <c>repoName/chartName</c> or directly by an url.</summary>
    [Argument(Format = "{value}", Separator = " ")] public IReadOnlyList<string> Charts => Get<List<string>>(() => Charts);
}
#endregion
#region HelmGetSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmGetSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmGet), Arguments = "get")]
public partial class HelmGetSettings : HelmOptionsBase
{
    /// <summary>Get the named release with revision.</summary>
    [Argument(Format = "--revision {value}", Secret = false)] public int? Revision => Get<int?>(() => Revision);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary>The name of the release to get.</summary>
    [Argument(Format = "{value}")] public string ReleaseName => Get<string>(() => ReleaseName);
}
#endregion
#region HelmGetHooksSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmGetHooksSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmGetHooks), Arguments = "get hooks")]
public partial class HelmGetHooksSettings : HelmOptionsBase
{
    /// <summary>Get the named release with revision.</summary>
    [Argument(Format = "--revision {value}", Secret = false)] public int? Revision => Get<int?>(() => Revision);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary>The name of the release to get the hooks for.</summary>
    [Argument(Format = "{value}")] public string ReleaseName => Get<string>(() => ReleaseName);
}
#endregion
#region HelmGetManifestSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmGetManifestSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmGetManifest), Arguments = "get manifest")]
public partial class HelmGetManifestSettings : HelmOptionsBase
{
    /// <summary>Get the named release with revision.</summary>
    [Argument(Format = "--revision {value}", Secret = false)] public int? Revision => Get<int?>(() => Revision);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary>The name of the release to get the manifest for.</summary>
    [Argument(Format = "{value}")] public string ReleaseName => Get<string>(() => ReleaseName);
}
#endregion
#region HelmGetNotesSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmGetNotesSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmGetNotes), Arguments = "get notes")]
public partial class HelmGetNotesSettings : HelmOptionsBase
{
    /// <summary>Get the notes of the named release with revision.</summary>
    [Argument(Format = "--revision {value}", Secret = false)] public int? Revision => Get<int?>(() => Revision);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary></summary>
    [Argument(Format = "{value}")] public string ReleaseName => Get<string>(() => ReleaseName);
}
#endregion
#region HelmGetValuesSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmGetValuesSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmGetValues), Arguments = "get values")]
public partial class HelmGetValuesSettings : HelmOptionsBase
{
    /// <summary>Dump all (computed) values.</summary>
    [Argument(Format = "--all", Secret = false)] public bool? All => Get<bool?>(() => All);
    /// <summary>Output the specified format (json or yaml) (default "yaml").</summary>
    [Argument(Format = "--output {value}", Secret = false)] public string Output => Get<string>(() => Output);
    /// <summary>Get the named release with revision.</summary>
    [Argument(Format = "--revision {value}", Secret = false)] public int? Revision => Get<int?>(() => Revision);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary>The name of the release to get the values for.</summary>
    [Argument(Format = "{value}")] public string ReleaseName => Get<string>(() => ReleaseName);
}
#endregion
#region HelmHistorySettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmHistorySettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmHistory), Arguments = "history")]
public partial class HelmHistorySettings : HelmOptionsBase
{
    /// <summary>Specifies the max column width of output (default 60).</summary>
    [Argument(Format = "--col-width {value}", Secret = false)] public uint? ColWidth => Get<uint?>(() => ColWidth);
    /// <summary>Maximum number of revision to include in history (default 256).</summary>
    [Argument(Format = "--max {value}", Secret = false)] public int? Max => Get<int?>(() => Max);
    /// <summary>Prints the output in the specified format (json|table|yaml) (default "table").</summary>
    [Argument(Format = "--output {value}", Secret = false)] public string Output => Get<string>(() => Output);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary>The name of the release to get the history for.</summary>
    [Argument(Format = "{value}")] public string ReleaseName => Get<string>(() => ReleaseName);
}
#endregion
#region HelmHomeSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmHomeSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmHome), Arguments = "home")]
public partial class HelmHomeSettings : HelmOptionsBase
{
}
#endregion
#region HelmInitSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmInitSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmInit), Arguments = "init")]
public partial class HelmInitSettings : HelmOptionsBase
{
    /// <summary>Auto-mount the given service account to tiller (default true).</summary>
    [Argument(Format = "--automount-service-account-token", Secret = false)] public bool? AutomountServiceAccountToken => Get<bool?>(() => AutomountServiceAccountToken);
    /// <summary>Use the canary Tiller image.</summary>
    [Argument(Format = "--canary-image", Secret = false)] public bool? CanaryImage => Get<bool?>(() => CanaryImage);
    /// <summary>If set does not install Tiller.</summary>
    [Argument(Format = "--client-only", Secret = false)] public bool? ClientOnly => Get<bool?>(() => ClientOnly);
    /// <summary>Do not install local or remote.</summary>
    [Argument(Format = "--dry-run", Secret = false)] public bool? DryRun => Get<bool?>(() => DryRun);
    /// <summary>Force upgrade of Tiller to the current helm version.</summary>
    [Argument(Format = "--force-upgrade", Secret = false)] public bool? ForceUpgrade => Get<bool?>(() => ForceUpgrade);
    /// <summary>Limit the maximum number of revisions saved per release. Use 0 for no limit.</summary>
    [Argument(Format = "--history-max {value}", Secret = false)] public long? HistoryMax => Get<long?>(() => HistoryMax);
    /// <summary>URL for local repository (default "http://127.0.0.1:8879/charts").</summary>
    [Argument(Format = "--local-repo-url {value}", Secret = false)] public string LocalRepoUrl => Get<string>(() => LocalRepoUrl);
    /// <summary>Install Tiller with net=host.</summary>
    [Argument(Format = "--net-host", Secret = false)] public bool? NetHost => Get<bool?>(() => NetHost);
    /// <summary>Labels to specify the node on which Tiller is installed (app=tiller,helm=rocks).</summary>
    [Argument(Format = "--node-selectors {value}", Secret = false)] public string NodeSelectors => Get<string>(() => NodeSelectors);
    /// <summary>Skip installation and output Tiller's manifest in specified format (json or yaml).</summary>
    [Argument(Format = "--output {value}", Secret = false)] public HelmOutputFormat Output => Get<HelmOutputFormat>(() => Output);
    /// <summary>Override values for the Tiller Deployment manifest (can specify multiple or separate values with commas: key1=val1,key2=val2).</summary>
    [Argument(Format = "--override {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> Override => Get<Dictionary<string, object>>(() => Override);
    /// <summary>Amount of tiller instances to run on the cluster (default 1).</summary>
    [Argument(Format = "--replicas {value}", Secret = false)] public long? Replicas => Get<long?>(() => Replicas);
    /// <summary>Name of service account.</summary>
    [Argument(Format = "--service-account {value}", Secret = false)] public string ServiceAccount => Get<string>(() => ServiceAccount);
    /// <summary>Do not refresh (download) the local repository cache.</summary>
    [Argument(Format = "--skip-refresh", Secret = false)] public bool? SkipRefresh => Get<bool?>(() => SkipRefresh);
    /// <summary>URL for stable repository (default "https://kubernetes-charts.storage.googleapis.com").</summary>
    [Argument(Format = "--stable-repo-url {value}", Secret = false)] public string StableRepoUrl => Get<string>(() => StableRepoUrl);
    /// <summary>Override Tiller image.</summary>
    [Argument(Format = "--tiller-image {value}", Secret = false)] public string TillerImage => Get<string>(() => TillerImage);
    /// <summary>Install Tiller with TLS enabled.</summary>
    [Argument(Format = "--tiller-tls", Secret = false)] public bool? TillerTls => Get<bool?>(() => TillerTls);
    /// <summary>Path to TLS certificate file to install with Tiller.</summary>
    [Argument(Format = "--tiller-tls-cert {value}", Secret = false)] public string TillerTlsCert => Get<string>(() => TillerTlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from Tiller.</summary>
    [Argument(Format = "--tiller-tls-hostname {value}", Secret = false)] public string TillerTlsHostname => Get<string>(() => TillerTlsHostname);
    /// <summary>Path to TLS key file to install with Tiller.</summary>
    [Argument(Format = "--tiller-tls-key {value}", Secret = false)] public string TillerTlsKey => Get<string>(() => TillerTlsKey);
    /// <summary>Install Tiller with TLS enabled and to verify remote certificates.</summary>
    [Argument(Format = "--tiller-tls-verify", Secret = false)] public bool? TillerTlsVerify => Get<bool?>(() => TillerTlsVerify);
    /// <summary>Path to CA root certificate.</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Upgrade if Tiller is already installed.</summary>
    [Argument(Format = "--upgrade", Secret = false)] public bool? Upgrade => Get<bool?>(() => Upgrade);
    /// <summary>Block until Tiller is running and ready to receive requests.</summary>
    [Argument(Format = "--wait", Secret = false)] public bool? Wait => Get<bool?>(() => Wait);
}
#endregion
#region HelmInspectSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmInspectSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmInspect), Arguments = "inspect")]
public partial class HelmInspectSettings : HelmOptionsBase
{
    /// <summary>Chart repository url where to locate the requested chart.</summary>
    [Argument(Format = "--ca-file {value}", Secret = false)] public string CaFile => Get<string>(() => CaFile);
    /// <summary>Verify certificates of HTTPS-enabled servers using this CA bundle.</summary>
    [Argument(Format = "--cert-file {value}", Secret = false)] public string CertFile => Get<string>(() => CertFile);
    /// <summary>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</summary>
    [Argument(Format = "--devel", Secret = false)] public bool? Devel => Get<bool?>(() => Devel);
    /// <summary>Identify HTTPS client using this SSL key file.</summary>
    [Argument(Format = "--key-file {value}", Secret = false)] public string KeyFile => Get<string>(() => KeyFile);
    /// <summary>Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").</summary>
    [Argument(Format = "--keyring {value}", Secret = false)] public string Keyring => Get<string>(() => Keyring);
    /// <summary>Chart repository password where to locate the requested chart.</summary>
    [Argument(Format = "--password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Chart repository url where to locate the requested chart.</summary>
    [Argument(Format = "--repo {value}", Secret = false)] public string Repo => Get<string>(() => Repo);
    /// <summary>Chart repository username where to locate the requested chart.</summary>
    [Argument(Format = "--username {value}", Secret = false)] public string Username => Get<string>(() => Username);
    /// <summary>Verify the provenance data for this chart.</summary>
    [Argument(Format = "--verify", Secret = false)] public bool? Verify => Get<bool?>(() => Verify);
    /// <summary>Version of the chart. By default, the newest chart is shown.</summary>
    [Argument(Format = "--version {value}", Secret = false)] public string Version => Get<string>(() => Version);
    /// <summary>The name of the chart to inspect.</summary>
    [Argument(Format = "{value}")] public string Chart => Get<string>(() => Chart);
}
#endregion
#region HelmInspectChartSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmInspectChartSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmInspectChart), Arguments = "inspect chart")]
public partial class HelmInspectChartSettings : HelmOptionsBase
{
    /// <summary>Chart repository url where to locate the requested chart.</summary>
    [Argument(Format = "--ca-file {value}", Secret = false)] public string CaFile => Get<string>(() => CaFile);
    /// <summary>Verify certificates of HTTPS-enabled servers using this CA bundle.</summary>
    [Argument(Format = "--cert-file {value}", Secret = false)] public string CertFile => Get<string>(() => CertFile);
    /// <summary>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</summary>
    [Argument(Format = "--devel", Secret = false)] public bool? Devel => Get<bool?>(() => Devel);
    /// <summary>Identify HTTPS client using this SSL key file.</summary>
    [Argument(Format = "--key-file {value}", Secret = false)] public string KeyFile => Get<string>(() => KeyFile);
    /// <summary>Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").</summary>
    [Argument(Format = "--keyring {value}", Secret = false)] public string Keyring => Get<string>(() => Keyring);
    /// <summary>Chart repository password where to locate the requested chart.</summary>
    [Argument(Format = "--password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Chart repository url where to locate the requested chart.</summary>
    [Argument(Format = "--repo {value}", Secret = false)] public string Repo => Get<string>(() => Repo);
    /// <summary>Chart repository username where to locate the requested chart.</summary>
    [Argument(Format = "--username {value}", Secret = false)] public string Username => Get<string>(() => Username);
    /// <summary>Verify the provenance data for this chart.</summary>
    [Argument(Format = "--verify", Secret = false)] public bool? Verify => Get<bool?>(() => Verify);
    /// <summary>Version of the chart. By default, the newest chart is shown.</summary>
    [Argument(Format = "--version {value}", Secret = false)] public string Version => Get<string>(() => Version);
    /// <summary>The name of the chart to inspect.</summary>
    [Argument(Format = "{value}")] public string Chart => Get<string>(() => Chart);
}
#endregion
#region HelmInspectReadmeSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmInspectReadmeSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmInspectReadme), Arguments = "inspect readme")]
public partial class HelmInspectReadmeSettings : HelmOptionsBase
{
    /// <summary>Chart repository url where to locate the requested chart.</summary>
    [Argument(Format = "--ca-file {value}", Secret = false)] public string CaFile => Get<string>(() => CaFile);
    /// <summary>Verify certificates of HTTPS-enabled servers using this CA bundle.</summary>
    [Argument(Format = "--cert-file {value}", Secret = false)] public string CertFile => Get<string>(() => CertFile);
    /// <summary>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</summary>
    [Argument(Format = "--devel", Secret = false)] public bool? Devel => Get<bool?>(() => Devel);
    /// <summary>Identify HTTPS client using this SSL key file.</summary>
    [Argument(Format = "--key-file {value}", Secret = false)] public string KeyFile => Get<string>(() => KeyFile);
    /// <summary>Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").</summary>
    [Argument(Format = "--keyring {value}", Secret = false)] public string Keyring => Get<string>(() => Keyring);
    /// <summary>Chart repository url where to locate the requested chart.</summary>
    [Argument(Format = "--repo {value}", Secret = false)] public string Repo => Get<string>(() => Repo);
    /// <summary>Verify the provenance data for this chart.</summary>
    [Argument(Format = "--verify", Secret = false)] public bool? Verify => Get<bool?>(() => Verify);
    /// <summary>Version of the chart. By default, the newest chart is shown.</summary>
    [Argument(Format = "--version {value}", Secret = false)] public string Version => Get<string>(() => Version);
    /// <summary>The name of the chart to inspect.</summary>
    [Argument(Format = "{value}")] public string Chart => Get<string>(() => Chart);
}
#endregion
#region HelmInspectValuesSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmInspectValuesSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmInspectValues), Arguments = "inspect values")]
public partial class HelmInspectValuesSettings : HelmOptionsBase
{
    /// <summary>Chart repository url where to locate the requested chart.</summary>
    [Argument(Format = "--ca-file {value}", Secret = false)] public string CaFile => Get<string>(() => CaFile);
    /// <summary>Verify certificates of HTTPS-enabled servers using this CA bundle.</summary>
    [Argument(Format = "--cert-file {value}", Secret = false)] public string CertFile => Get<string>(() => CertFile);
    /// <summary>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</summary>
    [Argument(Format = "--devel", Secret = false)] public bool? Devel => Get<bool?>(() => Devel);
    /// <summary>Identify HTTPS client using this SSL key file.</summary>
    [Argument(Format = "--key-file {value}", Secret = false)] public string KeyFile => Get<string>(() => KeyFile);
    /// <summary>Path to the keyring containing public verification keys (default "~/.gnupg/pubring.gpg").</summary>
    [Argument(Format = "--keyring {value}", Secret = false)] public string Keyring => Get<string>(() => Keyring);
    /// <summary>Chart repository password where to locate the requested chart.</summary>
    [Argument(Format = "--password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Chart repository url where to locate the requested chart.</summary>
    [Argument(Format = "--repo {value}", Secret = false)] public string Repo => Get<string>(() => Repo);
    /// <summary>Chart repository username where to locate the requested chart.</summary>
    [Argument(Format = "--username {value}", Secret = false)] public string Username => Get<string>(() => Username);
    /// <summary>Verify the provenance data for this chart.</summary>
    [Argument(Format = "--verify", Secret = false)] public bool? Verify => Get<bool?>(() => Verify);
    /// <summary>Version of the chart. By default, the newest chart is shown.</summary>
    [Argument(Format = "--version {value}", Secret = false)] public string Version => Get<string>(() => Version);
    /// <summary>The name of the chart to inspect.</summary>
    [Argument(Format = "{value}")] public string Chart => Get<string>(() => Chart);
}
#endregion
#region HelmInstallSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmInstallSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmInstall), Arguments = "install")]
public partial class HelmInstallSettings : HelmOptionsBase
{
    /// <summary>If set, installation process purges chart on fail, also sets --wait flag.</summary>
    [Argument(Format = "--atomic", Secret = false)] public bool? Atomic => Get<bool?>(() => Atomic);
    /// <summary>Verify certificates of HTTPS-enabled servers using this CA bundle.</summary>
    [Argument(Format = "--ca-file {value}", Secret = false)] public string CaFile => Get<string>(() => CaFile);
    /// <summary>Identify HTTPS client using this SSL certificate file.</summary>
    [Argument(Format = "--cert-file {value}", Secret = false)] public string CertFile => Get<string>(() => CertFile);
    /// <summary>Run helm dependency update before installing the chart.</summary>
    [Argument(Format = "--dep-up", Secret = false)] public bool? DepUp => Get<bool?>(() => DepUp);
    /// <summary>Specify a description for the release.</summary>
    [Argument(Format = "--description {value}", Secret = false)] public string Description => Get<string>(() => Description);
    /// <summary>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</summary>
    [Argument(Format = "--devel", Secret = false)] public bool? Devel => Get<bool?>(() => Devel);
    /// <summary>Simulate an install.</summary>
    [Argument(Format = "--dry-run", Secret = false)] public bool? DryRun => Get<bool?>(() => DryRun);
    /// <summary>Identify HTTPS client using this SSL key file.</summary>
    [Argument(Format = "--key-file {value}", Secret = false)] public string KeyFile => Get<string>(() => KeyFile);
    /// <summary>Location of public keys used for verification (default "~/.gnupg/pubring.gpg").</summary>
    [Argument(Format = "--keyring {value}", Secret = false)] public string Keyring => Get<string>(() => Keyring);
    /// <summary>Release name. If unspecified, it will autogenerate one for you.</summary>
    [Argument(Format = "--name {value}", Secret = false)] public string Name => Get<string>(() => Name);
    /// <summary>Specify template used to name the release.</summary>
    [Argument(Format = "--name-template {value}", Secret = false)] public string NameTemplate => Get<string>(() => NameTemplate);
    /// <summary>Namespace to install the release into. Defaults to the current kube config namespace.</summary>
    [Argument(Format = "--namespace {value}", Secret = false)] public string Namespace => Get<string>(() => Namespace);
    /// <summary>Prevent CRD hooks from running, but run other hooks.</summary>
    [Argument(Format = "--no-crd-hook", Secret = false)] public bool? NoCrdHook => Get<bool?>(() => NoCrdHook);
    /// <summary>Prevent hooks from running during install.</summary>
    [Argument(Format = "--no-hooks", Secret = false)] public bool? NoHooks => Get<bool?>(() => NoHooks);
    /// <summary>Chart repository password where to locate the requested chart.</summary>
    [Argument(Format = "--password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Render subchart notes along with the parent.</summary>
    [Argument(Format = "--render-subchart-notes", Secret = false)] public bool? RenderSubchartNotes => Get<bool?>(() => RenderSubchartNotes);
    /// <summary>Re-use the given name, even if that name is already used. This is unsafe in production.</summary>
    [Argument(Format = "--replace", Secret = false)] public bool? Replace => Get<bool?>(() => Replace);
    /// <summary>Chart repository url where to locate the requested chart.</summary>
    [Argument(Format = "--repo {value}", Secret = false)] public string Repo => Get<string>(() => Repo);
    /// <summary>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</summary>
    [Argument(Format = "--set {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> Set => Get<Dictionary<string, object>>(() => Set);
    /// <summary>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</summary>
    [Argument(Format = "--set-file {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> SetFile => Get<Dictionary<string, object>>(() => SetFile);
    /// <summary>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</summary>
    [Argument(Format = "--set-string {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> SetString => Get<Dictionary<string, object>>(() => SetString);
    /// <summary>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</summary>
    [Argument(Format = "--timeout {value}s", Secret = false)] public long? Timeout => Get<long?>(() => Timeout);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary>Chart repository username where to locate the requested chart.</summary>
    [Argument(Format = "--username {value}", Secret = false)] public string Username => Get<string>(() => Username);
    /// <summary>Specify values in a YAML file or a URL(can specify multiple) (default []).</summary>
    [Argument(Format = "--values {value}", Secret = false)] public IReadOnlyList<string> Values => Get<List<string>>(() => Values);
    /// <summary>Verify the package before installing it.</summary>
    [Argument(Format = "--verify", Secret = false)] public bool? Verify => Get<bool?>(() => Verify);
    /// <summary>Specify the exact chart version to install. If this is not specified, the latest version is installed.</summary>
    [Argument(Format = "--version {value}", Secret = false)] public string Version => Get<string>(() => Version);
    /// <summary>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</summary>
    [Argument(Format = "--wait", Secret = false)] public bool? Wait => Get<bool?>(() => Wait);
    /// <summary>The name of the chart to install.</summary>
    [Argument(Format = "{value}")] public string Chart => Get<string>(() => Chart);
}
#endregion
#region HelmLintSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmLintSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmLint), Arguments = "lint")]
public partial class HelmLintSettings : HelmOptionsBase
{
    /// <summary>Namespace to put the release into (default "default").</summary>
    [Argument(Format = "--namespace {value}", Secret = false)] public string Namespace => Get<string>(() => Namespace);
    /// <summary>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</summary>
    [Argument(Format = "--set {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> Set => Get<Dictionary<string, object>>(() => Set);
    /// <summary>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</summary>
    [Argument(Format = "--set-file {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> SetFile => Get<Dictionary<string, object>>(() => SetFile);
    /// <summary>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</summary>
    [Argument(Format = "--set-string {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> SetString => Get<Dictionary<string, object>>(() => SetString);
    /// <summary>Fail on lint warnings.</summary>
    [Argument(Format = "--strict", Secret = false)] public bool? Strict => Get<bool?>(() => Strict);
    /// <summary>Specify values in a YAML file (can specify multiple) (default []).</summary>
    [Argument(Format = "--values {value}", Secret = false)] public IReadOnlyList<string> Values => Get<List<string>>(() => Values);
    /// <summary>The Path to a chart.</summary>
    [Argument(Format = "{value}")] public string Path => Get<string>(() => Path);
}
#endregion
#region HelmListSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmListSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmList), Arguments = "list")]
public partial class HelmListSettings : HelmOptionsBase
{
    /// <summary>Show all releases, not just the ones marked DEPLOYED.</summary>
    [Argument(Format = "--all", Secret = false)] public bool? All => Get<bool?>(() => All);
    /// <summary>Sort by chart name.</summary>
    [Argument(Format = "--chart-name", Secret = false)] public bool? ChartName => Get<bool?>(() => ChartName);
    /// <summary>Specifies the max column width of output (default 60).</summary>
    [Argument(Format = "--col-width {value}", Secret = false)] public uint? ColWidth => Get<uint?>(() => ColWidth);
    /// <summary>Sort by release date.</summary>
    [Argument(Format = "--date", Secret = false)] public bool? Date => Get<bool?>(() => Date);
    /// <summary>Show deleted releases.</summary>
    [Argument(Format = "--deleted", Secret = false)] public bool? Deleted => Get<bool?>(() => Deleted);
    /// <summary>Show releases that are currently being deleted.</summary>
    [Argument(Format = "--deleting", Secret = false)] public bool? Deleting => Get<bool?>(() => Deleting);
    /// <summary>Show deployed releases. If no other is specified, this will be automatically enabled.</summary>
    [Argument(Format = "--deployed", Secret = false)] public bool? Deployed => Get<bool?>(() => Deployed);
    /// <summary>Show failed releases.</summary>
    [Argument(Format = "--failed", Secret = false)] public bool? Failed => Get<bool?>(() => Failed);
    /// <summary>Maximum number of releases to fetch (default 256).</summary>
    [Argument(Format = "--max {value}", Secret = false)] public long? Max => Get<long?>(() => Max);
    /// <summary>Show releases within a specific namespace.</summary>
    [Argument(Format = "--namespace {value}", Secret = false)] public string Namespace => Get<string>(() => Namespace);
    /// <summary>Next release name in the list, used to offset from start value.</summary>
    [Argument(Format = "--offset {value}", Secret = false)] public string Offset => Get<string>(() => Offset);
    /// <summary>Output the specified format (json or yaml).</summary>
    [Argument(Format = "--output {value}", Secret = false)] public HelmOutputFormat Output => Get<HelmOutputFormat>(() => Output);
    /// <summary>Show pending releases.</summary>
    [Argument(Format = "--pending", Secret = false)] public bool? Pending => Get<bool?>(() => Pending);
    /// <summary>Reverse the sort order.</summary>
    [Argument(Format = "--reverse", Secret = false)] public bool? Reverse => Get<bool?>(() => Reverse);
    /// <summary>Output short (quiet) listing format.</summary>
    [Argument(Format = "--short", Secret = false)] public bool? Short => Get<bool?>(() => Short);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary>The filter to use.</summary>
    [Argument(Format = "{value}")] public string Filter => Get<string>(() => Filter);
}
#endregion
#region HelmPackageSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmPackageSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmPackage), Arguments = "package")]
public partial class HelmPackageSettings : HelmOptionsBase
{
    /// <summary>Set the appVersion on the chart to this version.</summary>
    [Argument(Format = "--app-version {value}", Secret = false)] public string AppVersion => Get<string>(() => AppVersion);
    /// <summary>Update dependencies from "requirements.yaml" to dir "charts/" before packaging.</summary>
    [Argument(Format = "--dependency-update", Secret = false)] public bool? DependencyUpdate => Get<bool?>(() => DependencyUpdate);
    /// <summary>Location to write the chart. (default ".").</summary>
    [Argument(Format = "--destination {value}", Secret = false)] public string Destination => Get<string>(() => Destination);
    /// <summary>Name of the key to use when signing. Used if --sign is true.</summary>
    [Argument(Format = "--key {value}", Secret = false)] public string Key => Get<string>(() => Key);
    /// <summary>Location of a public keyring (default "~/.gnupg/pubring.gpg").</summary>
    [Argument(Format = "--keyring {value}", Secret = false)] public string Keyring => Get<string>(() => Keyring);
    /// <summary>Save packaged chart to local chart repository (default true).</summary>
    [Argument(Format = "--save", Secret = false)] public bool? Save => Get<bool?>(() => Save);
    /// <summary>Use a PGP private key to sign this package.</summary>
    [Argument(Format = "--sign", Secret = false)] public bool? Sign => Get<bool?>(() => Sign);
    /// <summary>Set the version on the chart to this semver version.</summary>
    [Argument(Format = "--version {value}", Secret = false)] public string Version => Get<string>(() => Version);
    /// <summary>The paths to the charts to package.</summary>
    [Argument(Format = "{value}", Separator = " ")] public IReadOnlyList<string> ChartPaths => Get<List<string>>(() => ChartPaths);
}
#endregion
#region HelmPluginInstallSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmPluginInstallSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmPluginInstall), Arguments = "plugin install")]
public partial class HelmPluginInstallSettings : HelmOptionsBase
{
    /// <summary>Specify a version constraint. If this is not specified, the latest version is installed.</summary>
    [Argument(Format = "--version {value}", Secret = false)] public string Version => Get<string>(() => Version);
    /// <summary></summary>
    [Argument(Format = "{value}")] public string Options => Get<string>(() => Options);
    /// <summary>List of paths or urls of packages to install.</summary>
    [Argument(Format = "{value}", Separator = " ")] public IReadOnlyList<string> Paths => Get<List<string>>(() => Paths);
}
#endregion
#region HelmPluginListSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmPluginListSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmPluginList), Arguments = "plugin list")]
public partial class HelmPluginListSettings : HelmOptionsBase
{
}
#endregion
#region HelmPluginRemoveSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmPluginRemoveSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmPluginRemove), Arguments = "plugin remove")]
public partial class HelmPluginRemoveSettings : HelmOptionsBase
{
    /// <summary>List of plugins to remove.</summary>
    [Argument(Format = "{value}", Separator = " ")] public IReadOnlyList<string> Plugins => Get<List<string>>(() => Plugins);
}
#endregion
#region HelmPluginUpdateSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmPluginUpdateSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmPluginUpdate), Arguments = "plugin update")]
public partial class HelmPluginUpdateSettings : HelmOptionsBase
{
    /// <summary>List of plugins to update.</summary>
    [Argument(Format = "{value}", Separator = " ")] public IReadOnlyList<string> Plugins => Get<List<string>>(() => Plugins);
}
#endregion
#region HelmRepoAddSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmRepoAddSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmRepoAdd), Arguments = "repo add")]
public partial class HelmRepoAddSettings : HelmOptionsBase
{
    /// <summary>Verify certificates of HTTPS-enabled servers using this CA bundle.</summary>
    [Argument(Format = "--ca-file {value}", Secret = false)] public string CaFile => Get<string>(() => CaFile);
    /// <summary>Identify HTTPS client using this SSL certificate file.</summary>
    [Argument(Format = "--cert-file {value}", Secret = false)] public string CertFile => Get<string>(() => CertFile);
    /// <summary>Identify HTTPS client using this SSL key file.</summary>
    [Argument(Format = "--key-file {value}", Secret = false)] public string KeyFile => Get<string>(() => KeyFile);
    /// <summary>Raise error if repo is already registered.</summary>
    [Argument(Format = "--no-update", Secret = false)] public bool? NoUpdate => Get<bool?>(() => NoUpdate);
    /// <summary>Chart repository password.</summary>
    [Argument(Format = "--password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Chart repository username.</summary>
    [Argument(Format = "--username {value}", Secret = false)] public string Username => Get<string>(() => Username);
    /// <summary>The name of the repository to add.</summary>
    [Argument(Format = "{value}")] public string Name => Get<string>(() => Name);
    /// <summary>The url of the repository to add.</summary>
    [Argument(Format = "{value}")] public string Url => Get<string>(() => Url);
}
#endregion
#region HelmRepoIndexSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmRepoIndexSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmRepoIndex), Arguments = "repo index")]
public partial class HelmRepoIndexSettings : HelmOptionsBase
{
    /// <summary>Merge the generated index into the given index.</summary>
    [Argument(Format = "--merge {value}", Secret = false)] public string Merge => Get<string>(() => Merge);
    /// <summary>Url of chart repository.</summary>
    [Argument(Format = "--url {value}", Secret = false)] public string Url => Get<string>(() => Url);
    /// <summary>The directory of the repository.</summary>
    [Argument(Format = "{value}")] public string Directory => Get<string>(() => Directory);
}
#endregion
#region HelmRepoListSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmRepoListSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmRepoList), Arguments = "repo list")]
public partial class HelmRepoListSettings : HelmOptionsBase
{
}
#endregion
#region HelmRepoRemoveSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmRepoRemoveSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmRepoRemove), Arguments = "repo remove")]
public partial class HelmRepoRemoveSettings : HelmOptionsBase
{
    /// <summary>The name of the repository.</summary>
    [Argument(Format = "{value}")] public string Name => Get<string>(() => Name);
}
#endregion
#region HelmRepoUpdateSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmRepoUpdateSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmRepoUpdate), Arguments = "repo update")]
public partial class HelmRepoUpdateSettings : HelmOptionsBase
{
    /// <summary>Fail on update warnings.</summary>
    [Argument(Format = "--strict", Secret = false)] public bool? Strict => Get<bool?>(() => Strict);
}
#endregion
#region HelmResetSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmResetSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmReset), Arguments = "reset")]
public partial class HelmResetSettings : HelmOptionsBase
{
    /// <summary>Forces Tiller uninstall even if there are releases installed, or if Tiller is not in ready state. Releases are not deleted.).</summary>
    [Argument(Format = "--force", Secret = false)] public bool? Force => Get<bool?>(() => Force);
    /// <summary>If set deletes $HELM_HOME.</summary>
    [Argument(Format = "--remove-helm-home", Secret = false)] public bool? RemoveHelmHome => Get<bool?>(() => RemoveHelmHome);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
}
#endregion
#region HelmRollbackSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmRollbackSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmRollback), Arguments = "rollback")]
public partial class HelmRollbackSettings : HelmOptionsBase
{
    /// <summary>Specify a description for the release.</summary>
    [Argument(Format = "--description {value}", Secret = false)] public string Description => Get<string>(() => Description);
    /// <summary>Simulate a rollback.</summary>
    [Argument(Format = "--dry-run", Secret = false)] public bool? DryRun => Get<bool?>(() => DryRun);
    /// <summary>Force resource update through delete/recreate if needed.</summary>
    [Argument(Format = "--force", Secret = false)] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Prevent hooks from running during rollback.</summary>
    [Argument(Format = "--no-hooks", Secret = false)] public bool? NoHooks => Get<bool?>(() => NoHooks);
    /// <summary>Performs pods restart for the resource if applicable.</summary>
    [Argument(Format = "--recreate-pods", Secret = false)] public bool? RecreatePods => Get<bool?>(() => RecreatePods);
    /// <summary>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</summary>
    [Argument(Format = "--timeout {value}s", Secret = false)] public long? Timeout => Get<long?>(() => Timeout);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</summary>
    [Argument(Format = "--wait", Secret = false)] public bool? Wait => Get<bool?>(() => Wait);
    /// <summary>The name of the release.</summary>
    [Argument(Format = "{value}")] public string Release => Get<string>(() => Release);
    /// <summary>The revison to roll back.</summary>
    [Argument(Format = "{value}")] public string Revision => Get<string>(() => Revision);
}
#endregion
#region HelmSearchSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmSearchSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmSearch), Arguments = "search")]
public partial class HelmSearchSettings : HelmOptionsBase
{
    /// <summary>Specifies the max column width of output (default 60).</summary>
    [Argument(Format = "--col-width {value}", Secret = false)] public uint? ColWidth => Get<uint?>(() => ColWidth);
    /// <summary>Use regular expressions for searching.</summary>
    [Argument(Format = "--regexp", Secret = false)] public bool? Regexp => Get<bool?>(() => Regexp);
    /// <summary>Search using semantic versioning constraints.</summary>
    [Argument(Format = "--version {value}", Secret = false)] public string Version => Get<string>(() => Version);
    /// <summary>Show the long listing, with each version of each chart on its own line.</summary>
    [Argument(Format = "--versions", Secret = false)] public bool? Versions => Get<bool?>(() => Versions);
    /// <summary>The keyword to search for.</summary>
    [Argument(Format = "{value}")] public string Keyword => Get<string>(() => Keyword);
}
#endregion
#region HelmServeSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmServeSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmServe), Arguments = "serve")]
public partial class HelmServeSettings : HelmOptionsBase
{
    /// <summary>Address to listen on (default "127.0.0.1:8879").</summary>
    [Argument(Format = "--address {value}", Secret = false)] public string Address => Get<string>(() => Address);
    /// <summary>Local directory path from which to serve charts.</summary>
    [Argument(Format = "--repo-path {value}", Secret = false)] public string RepoPath => Get<string>(() => RepoPath);
    /// <summary>External URL of chart repository.</summary>
    [Argument(Format = "--url {value}", Secret = false)] public string Url => Get<string>(() => Url);
}
#endregion
#region HelmStatusSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmStatusSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmStatus), Arguments = "status")]
public partial class HelmStatusSettings : HelmOptionsBase
{
    /// <summary>Output the status in the specified format (json or yaml).</summary>
    [Argument(Format = "--output {value}", Secret = false)] public HelmOutputFormat Output => Get<HelmOutputFormat>(() => Output);
    /// <summary>If set, display the status of the named release with revision.</summary>
    [Argument(Format = "--revision {value}", Secret = false)] public int? Revision => Get<int?>(() => Revision);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary>The name of the release to get the status for.</summary>
    [Argument(Format = "{value}")] public string ReleaseName => Get<string>(() => ReleaseName);
}
#endregion
#region HelmTemplateSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmTemplateSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmTemplate), Arguments = "template")]
public partial class HelmTemplateSettings : HelmOptionsBase
{
    /// <summary>Only execute the given templates.</summary>
    [Argument(Format = "--execute {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> Execute => Get<Dictionary<string, object>>(() => Execute);
    /// <summary>Set .Release.IsUpgrade instead of .Release.IsInstall.</summary>
    [Argument(Format = "--is-upgrade", Secret = false)] public bool? IsUpgrade => Get<bool?>(() => IsUpgrade);
    /// <summary>Kubernetes version used as Capabilities.KubeVersion.Major/Minor (default "1.9").</summary>
    [Argument(Format = "--kube-version {value}", Secret = false)] public string KubeVersion => Get<string>(() => KubeVersion);
    /// <summary>Release name (default "release-name").</summary>
    [Argument(Format = "--name {value}", Secret = false)] public string Name => Get<string>(() => Name);
    /// <summary>Specify template used to name the release.</summary>
    [Argument(Format = "--name-template {value}", Secret = false)] public string NameTemplate => Get<string>(() => NameTemplate);
    /// <summary>Namespace to install the release into.</summary>
    [Argument(Format = "--namespace {value}", Secret = false)] public string Namespace => Get<string>(() => Namespace);
    /// <summary>Show the computed NOTES.txt file as well.</summary>
    [Argument(Format = "--notes", Secret = false)] public bool? Notes => Get<bool?>(() => Notes);
    /// <summary>Writes the executed templates to files in output-dir instead of stdout.</summary>
    [Argument(Format = "--output-dir {value}", Secret = false)] public string OutputDir => Get<string>(() => OutputDir);
    /// <summary>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</summary>
    [Argument(Format = "--set {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> Set => Get<Dictionary<string, object>>(() => Set);
    /// <summary>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</summary>
    [Argument(Format = "--set-file {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> SetFile => Get<Dictionary<string, object>>(() => SetFile);
    /// <summary>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</summary>
    [Argument(Format = "--set-string {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> SetString => Get<Dictionary<string, object>>(() => SetString);
    /// <summary>Specify values in a YAML file (can specify multiple) (default []).</summary>
    [Argument(Format = "--values {value}", Secret = false)] public IReadOnlyList<string> Values => Get<List<string>>(() => Values);
    /// <summary></summary>
    [Argument(Format = "{value}")] public string Chart => Get<string>(() => Chart);
}
#endregion
#region HelmTestSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmTestSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmTest), Arguments = "test")]
public partial class HelmTestSettings : HelmOptionsBase
{
    /// <summary>Delete test pods upon completion.</summary>
    [Argument(Format = "--cleanup", Secret = false)] public bool? Cleanup => Get<bool?>(() => Cleanup);
    /// <summary>Run test pods in parallel.</summary>
    [Argument(Format = "--parallel", Secret = false)] public bool? Parallel => Get<bool?>(() => Parallel);
    /// <summary>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</summary>
    [Argument(Format = "--timeout {value}s", Secret = false)] public long? Timeout => Get<long?>(() => Timeout);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary>The name of the release to test.</summary>
    [Argument(Format = "{value}")] public string Release => Get<string>(() => Release);
}
#endregion
#region HelmUpgradeSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmUpgradeSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmUpgrade), Arguments = "upgrade")]
public partial class HelmUpgradeSettings : HelmOptionsBase
{
    /// <summary>If set, upgrade process rolls back changes made in case of failed upgrade, also sets --wait flag.</summary>
    [Argument(Format = "--atomic", Secret = false)] public bool? Atomic => Get<bool?>(() => Atomic);
    /// <summary>Verify certificates of HTTPS-enabled servers using this CA bundle.</summary>
    [Argument(Format = "--ca-file {value}", Secret = false)] public string CaFile => Get<string>(() => CaFile);
    /// <summary>Identify HTTPS client using this SSL certificate file.</summary>
    [Argument(Format = "--cert-file {value}", Secret = false)] public string CertFile => Get<string>(() => CertFile);
    /// <summary>Specify the description to use for the upgrade, rather than the default.</summary>
    [Argument(Format = "--description {value}", Secret = false)] public string Description => Get<string>(() => Description);
    /// <summary>Use development versions, too. Equivalent to version '&gt;0.0.0-0'. If --version is set, this is ignored.</summary>
    [Argument(Format = "--devel", Secret = false)] public bool? Devel => Get<bool?>(() => Devel);
    /// <summary>Simulate an upgrade.</summary>
    [Argument(Format = "--dry-run", Secret = false)] public bool? DryRun => Get<bool?>(() => DryRun);
    /// <summary>Force resource update through delete/recreate if needed.</summary>
    [Argument(Format = "--force", Secret = false)] public bool? Force => Get<bool?>(() => Force);
    /// <summary>If a release by this name doesn't already exist, run an install.</summary>
    [Argument(Format = "--install", Secret = false)] public bool? Install => Get<bool?>(() => Install);
    /// <summary>If --install is set, create the release namespace if not present.</summary>
    [Argument(Format = "--create-namespace", Secret = false)] public bool? CreateNamespace => Get<bool?>(() => CreateNamespace);
    /// <summary>Identify HTTPS client using this SSL key file.</summary>
    [Argument(Format = "--key-file {value}", Secret = false)] public string KeyFile => Get<string>(() => KeyFile);
    /// <summary>Path to the keyring that contains public signing keys (default "~/.gnupg/pubring.gpg").</summary>
    [Argument(Format = "--keyring {value}", Secret = false)] public string Keyring => Get<string>(() => Keyring);
    /// <summary>Namespace to install the release into (only used if --install is set). Defaults to the current kube config namespace.</summary>
    [Argument(Format = "--namespace {value}", Secret = false)] public string Namespace => Get<string>(() => Namespace);
    /// <summary>Disable pre/post upgrade hooks.</summary>
    [Argument(Format = "--no-hooks", Secret = false)] public bool? NoHooks => Get<bool?>(() => NoHooks);
    /// <summary>Chart repository password where to locate the requested chart.</summary>
    [Argument(Format = "--password {value}", Secret = true)] public string Password => Get<string>(() => Password);
    /// <summary>Performs pods restart for the resource if applicable.</summary>
    [Argument(Format = "--recreate-pods", Secret = false)] public bool? RecreatePods => Get<bool?>(() => RecreatePods);
    /// <summary>Render subchart notes along with parent.</summary>
    [Argument(Format = "--render-subchart-notes", Secret = false)] public bool? RenderSubchartNotes => Get<bool?>(() => RenderSubchartNotes);
    /// <summary>Chart repository url where to locate the requested chart.</summary>
    [Argument(Format = "--repo {value}", Secret = false)] public string Repo => Get<string>(() => Repo);
    /// <summary>When upgrading, reset the values to the ones built into the chart.</summary>
    [Argument(Format = "--reset-values", Secret = false)] public bool? ResetValues => Get<bool?>(() => ResetValues);
    /// <summary>When upgrading, reuse the last release's values and merge in any overrides from the command line via --set and -f. If '--reset-values' is specified, this is ignored.</summary>
    [Argument(Format = "--reuse-values", Secret = false)] public bool? ReuseValues => Get<bool?>(() => ReuseValues);
    /// <summary>Set values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</summary>
    [Argument(Format = "--set {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> Set => Get<Dictionary<string, object>>(() => Set);
    /// <summary>Set values from respective files specified via the command line (can specify multiple or separate values with commas: key1=path1,key2=path2).</summary>
    [Argument(Format = "--set-file{key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> SetFile => Get<Dictionary<string, object>>(() => SetFile);
    /// <summary>Set STRING values on the command line (can specify multiple or separate values with commas: key1=val1,key2=val2).</summary>
    [Argument(Format = "--set-string {key}={value}", Secret = false, Separator = ",")] public IReadOnlyDictionary<string, object> SetString => Get<Dictionary<string, object>>(() => SetString);
    /// <summary>Time in seconds to wait for any individual Kubernetes operation (like Jobs for hooks) (default 300).</summary>
    [Argument(Format = "--timeout {value}s", Secret = false)] public long? Timeout => Get<long?>(() => Timeout);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
    /// <summary>Chart repository username where to locate the requested chart.</summary>
    [Argument(Format = "--username {value}", Secret = false)] public string Username => Get<string>(() => Username);
    /// <summary>Specify values in a YAML file or a URL(can specify multiple) (default []).</summary>
    [Argument(Format = "--values {value}", Secret = false)] public IReadOnlyList<string> Values => Get<List<string>>(() => Values);
    /// <summary>Verify the provenance of the chart before upgrading.</summary>
    [Argument(Format = "--verify", Secret = false)] public bool? Verify => Get<bool?>(() => Verify);
    /// <summary>Specify the exact chart version to use. If this is not specified, the latest version is used.</summary>
    [Argument(Format = "--version {value}", Secret = false)] public string Version => Get<string>(() => Version);
    /// <summary>If set, will wait until all Pods, PVCs, Services, and minimum number of Pods of a Deployment are in a ready state before marking the release as successful. It will wait for as long as --timeout.</summary>
    [Argument(Format = "--wait", Secret = false)] public bool? Wait => Get<bool?>(() => Wait);
    /// <summary>The name of the release to upgrade.</summary>
    [Argument(Format = "{value}")] public string Release => Get<string>(() => Release);
    /// <summary>The name of the chart to upgrade.</summary>
    [Argument(Format = "{value}")] public string Chart => Get<string>(() => Chart);
}
#endregion
#region HelmVerifySettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmVerifySettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmVerify), Arguments = "verify")]
public partial class HelmVerifySettings : HelmOptionsBase
{
    /// <summary>Keyring containing public keys (default "~/.gnupg/pubring.gpg").</summary>
    [Argument(Format = "--keyring {value}", Secret = false)] public string Keyring => Get<string>(() => Keyring);
    /// <summary>The path to the chart to verify.</summary>
    [Argument(Format = "{value}")] public string Path => Get<string>(() => Path);
}
#endregion
#region HelmVersionSettings
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmVersionSettings>))]
[Command(Type = typeof(HelmTasks), Command = nameof(HelmTasks.HelmVersion), Arguments = "version")]
public partial class HelmVersionSettings : HelmOptionsBase
{
    /// <summary>Client version only.</summary>
    [Argument(Format = "--client", Secret = false)] public bool? Client => Get<bool?>(() => Client);
    /// <summary>Server version only.</summary>
    [Argument(Format = "--server", Secret = false)] public bool? Server => Get<bool?>(() => Server);
    /// <summary>Print the version number.</summary>
    [Argument(Format = "--short", Secret = false)] public bool? Short => Get<bool?>(() => Short);
    /// <summary>Template for version string format.</summary>
    [Argument(Format = "--template {value}", Secret = false)] public string Template => Get<string>(() => Template);
    /// <summary>Enable TLS for request.</summary>
    [Argument(Format = "--tls", Secret = false)] public bool? Tls => Get<bool?>(() => Tls);
    /// <summary>Path to TLS CA certificate file (default "$HELM_HOME/ca.pem").</summary>
    [Argument(Format = "--tls-ca-cert {value}", Secret = false)] public string TlsCaCert => Get<string>(() => TlsCaCert);
    /// <summary>Path to TLS certificate file (default "$HELM_HOME/cert.pem").</summary>
    [Argument(Format = "--tls-cert {value}", Secret = false)] public string TlsCert => Get<string>(() => TlsCert);
    /// <summary>The server name used to verify the hostname on the returned certificates from the server.</summary>
    [Argument(Format = "--tls-hostname {value}", Secret = false)] public string TlsHostname => Get<string>(() => TlsHostname);
    /// <summary>Path to TLS key file (default "$HELM_HOME/key.pem").</summary>
    [Argument(Format = "--tls-key {value}", Secret = false)] public string TlsKey => Get<string>(() => TlsKey);
    /// <summary>Enable TLS for request and verify remote.</summary>
    [Argument(Format = "--tls-verify", Secret = false)] public bool? TlsVerify => Get<bool?>(() => TlsVerify);
}
#endregion
#region HelmOptionsBase
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmOptionsBase>))]
public partial class HelmOptionsBase : ToolOptions
{
    /// <summary>Enable verbose output.</summary>
    [Argument(Format = "--debug", Secret = false)] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Location of your Helm config. Overrides $HELM_HOME (default "~/.helm").</summary>
    [Argument(Format = "--home {value}", Secret = false)] public string Home => Get<string>(() => Home);
    /// <summary>Address of Tiller. Overrides $HELM_HOST.</summary>
    [Argument(Format = "--host {value}", Secret = false)] public string Host => Get<string>(() => Host);
    /// <summary>Name of the kubeconfig context to use.</summary>
    [Argument(Format = "--kube-context {value}", Secret = false)] public string KubeContext => Get<string>(() => KubeContext);
    /// <summary>Absolute path to the kubeconfig file to use.</summary>
    [Argument(Format = "--kubeconfig {value}", Secret = false)] public string Kubeconfig => Get<string>(() => Kubeconfig);
    /// <summary>The duration (in seconds) Helm will wait to establish a connection to tiller (default 300).</summary>
    [Argument(Format = "--tiller-connection-timeout {value}", Secret = false)] public long? TillerConnectionTimeout => Get<long?>(() => TillerConnectionTimeout);
    /// <summary>Namespace of Tiller (default "kube-system").</summary>
    [Argument(Format = "--tiller-namespace {value}", Secret = false)] public string TillerNamespace => Get<string>(() => TillerNamespace);
}
#endregion
#region HelmCompletionSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmCompletionSettingsExtensions
{
    #region Shell
    /// <inheritdoc cref="HelmCompletionSettings.Shell"/>
    [Pure] [Builder(Type = typeof(HelmCompletionSettings), Property = nameof(HelmCompletionSettings.Shell))]
    public static T SetShell<T>(this T o, string v) where T : HelmCompletionSettings => o.Modify(b => b.Set(() => o.Shell, v));
    /// <inheritdoc cref="HelmCompletionSettings.Shell"/>
    [Pure] [Builder(Type = typeof(HelmCompletionSettings), Property = nameof(HelmCompletionSettings.Shell))]
    public static T ResetShell<T>(this T o) where T : HelmCompletionSettings => o.Modify(b => b.Remove(() => o.Shell));
    #endregion
}
#endregion
#region HelmCreateSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmCreateSettingsExtensions
{
    #region Starter
    /// <inheritdoc cref="HelmCreateSettings.Starter"/>
    [Pure] [Builder(Type = typeof(HelmCreateSettings), Property = nameof(HelmCreateSettings.Starter))]
    public static T SetStarter<T>(this T o, string v) where T : HelmCreateSettings => o.Modify(b => b.Set(() => o.Starter, v));
    /// <inheritdoc cref="HelmCreateSettings.Starter"/>
    [Pure] [Builder(Type = typeof(HelmCreateSettings), Property = nameof(HelmCreateSettings.Starter))]
    public static T ResetStarter<T>(this T o) where T : HelmCreateSettings => o.Modify(b => b.Remove(() => o.Starter));
    #endregion
    #region Name
    /// <inheritdoc cref="HelmCreateSettings.Name"/>
    [Pure] [Builder(Type = typeof(HelmCreateSettings), Property = nameof(HelmCreateSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : HelmCreateSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="HelmCreateSettings.Name"/>
    [Pure] [Builder(Type = typeof(HelmCreateSettings), Property = nameof(HelmCreateSettings.Name))]
    public static T ResetName<T>(this T o) where T : HelmCreateSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
}
#endregion
#region HelmDeleteSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmDeleteSettingsExtensions
{
    #region Description
    /// <inheritdoc cref="HelmDeleteSettings.Description"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Description))]
    public static T SetDescription<T>(this T o, string v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.Description, v));
    /// <inheritdoc cref="HelmDeleteSettings.Description"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Description))]
    public static T ResetDescription<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Remove(() => o.Description));
    #endregion
    #region DryRun
    /// <inheritdoc cref="HelmDeleteSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.DryRun))]
    public static T SetDryRun<T>(this T o, bool? v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.DryRun, v));
    /// <inheritdoc cref="HelmDeleteSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.DryRun))]
    public static T ResetDryRun<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Remove(() => o.DryRun));
    /// <inheritdoc cref="HelmDeleteSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.DryRun))]
    public static T EnableDryRun<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.DryRun, true));
    /// <inheritdoc cref="HelmDeleteSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.DryRun))]
    public static T DisableDryRun<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.DryRun, false));
    /// <inheritdoc cref="HelmDeleteSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.DryRun))]
    public static T ToggleDryRun<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.DryRun, !o.DryRun));
    #endregion
    #region NoHooks
    /// <inheritdoc cref="HelmDeleteSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.NoHooks))]
    public static T SetNoHooks<T>(this T o, bool? v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.NoHooks, v));
    /// <inheritdoc cref="HelmDeleteSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.NoHooks))]
    public static T ResetNoHooks<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Remove(() => o.NoHooks));
    /// <inheritdoc cref="HelmDeleteSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.NoHooks))]
    public static T EnableNoHooks<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.NoHooks, true));
    /// <inheritdoc cref="HelmDeleteSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.NoHooks))]
    public static T DisableNoHooks<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.NoHooks, false));
    /// <inheritdoc cref="HelmDeleteSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.NoHooks))]
    public static T ToggleNoHooks<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.NoHooks, !o.NoHooks));
    #endregion
    #region Purge
    /// <inheritdoc cref="HelmDeleteSettings.Purge"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Purge))]
    public static T SetPurge<T>(this T o, bool? v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.Purge, v));
    /// <inheritdoc cref="HelmDeleteSettings.Purge"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Purge))]
    public static T ResetPurge<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Remove(() => o.Purge));
    /// <inheritdoc cref="HelmDeleteSettings.Purge"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Purge))]
    public static T EnablePurge<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.Purge, true));
    /// <inheritdoc cref="HelmDeleteSettings.Purge"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Purge))]
    public static T DisablePurge<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.Purge, false));
    /// <inheritdoc cref="HelmDeleteSettings.Purge"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Purge))]
    public static T TogglePurge<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.Purge, !o.Purge));
    #endregion
    #region Timeout
    /// <inheritdoc cref="HelmDeleteSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Timeout))]
    public static T SetTimeout<T>(this T o, long? v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="HelmDeleteSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmDeleteSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmDeleteSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmDeleteSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmDeleteSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmDeleteSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmDeleteSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmDeleteSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmDeleteSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmDeleteSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmDeleteSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmDeleteSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmDeleteSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmDeleteSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmDeleteSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmDeleteSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmDeleteSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmDeleteSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmDeleteSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region ReleaseNames
    /// <inheritdoc cref="HelmDeleteSettings.ReleaseNames"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.ReleaseNames))]
    public static T SetReleaseNames<T>(this T o, params string[] v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.ReleaseNames, v));
    /// <inheritdoc cref="HelmDeleteSettings.ReleaseNames"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.ReleaseNames))]
    public static T SetReleaseNames<T>(this T o, IEnumerable<string> v) where T : HelmDeleteSettings => o.Modify(b => b.Set(() => o.ReleaseNames, v));
    /// <inheritdoc cref="HelmDeleteSettings.ReleaseNames"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.ReleaseNames))]
    public static T AddReleaseNames<T>(this T o, params string[] v) where T : HelmDeleteSettings => o.Modify(b => b.AddCollection(() => o.ReleaseNames, v));
    /// <inheritdoc cref="HelmDeleteSettings.ReleaseNames"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.ReleaseNames))]
    public static T AddReleaseNames<T>(this T o, IEnumerable<string> v) where T : HelmDeleteSettings => o.Modify(b => b.AddCollection(() => o.ReleaseNames, v));
    /// <inheritdoc cref="HelmDeleteSettings.ReleaseNames"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.ReleaseNames))]
    public static T RemoveReleaseNames<T>(this T o, params string[] v) where T : HelmDeleteSettings => o.Modify(b => b.RemoveCollection(() => o.ReleaseNames, v));
    /// <inheritdoc cref="HelmDeleteSettings.ReleaseNames"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.ReleaseNames))]
    public static T RemoveReleaseNames<T>(this T o, IEnumerable<string> v) where T : HelmDeleteSettings => o.Modify(b => b.RemoveCollection(() => o.ReleaseNames, v));
    /// <inheritdoc cref="HelmDeleteSettings.ReleaseNames"/>
    [Pure] [Builder(Type = typeof(HelmDeleteSettings), Property = nameof(HelmDeleteSettings.ReleaseNames))]
    public static T ClearReleaseNames<T>(this T o) where T : HelmDeleteSettings => o.Modify(b => b.ClearCollection(() => o.ReleaseNames));
    #endregion
}
#endregion
#region HelmDependencyBuildSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmDependencyBuildSettingsExtensions
{
    #region Keyring
    /// <inheritdoc cref="HelmDependencyBuildSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmDependencyBuildSettings), Property = nameof(HelmDependencyBuildSettings.Keyring))]
    public static T SetKeyring<T>(this T o, string v) where T : HelmDependencyBuildSettings => o.Modify(b => b.Set(() => o.Keyring, v));
    /// <inheritdoc cref="HelmDependencyBuildSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmDependencyBuildSettings), Property = nameof(HelmDependencyBuildSettings.Keyring))]
    public static T ResetKeyring<T>(this T o) where T : HelmDependencyBuildSettings => o.Modify(b => b.Remove(() => o.Keyring));
    #endregion
    #region Verify
    /// <inheritdoc cref="HelmDependencyBuildSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmDependencyBuildSettings), Property = nameof(HelmDependencyBuildSettings.Verify))]
    public static T SetVerify<T>(this T o, bool? v) where T : HelmDependencyBuildSettings => o.Modify(b => b.Set(() => o.Verify, v));
    /// <inheritdoc cref="HelmDependencyBuildSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmDependencyBuildSettings), Property = nameof(HelmDependencyBuildSettings.Verify))]
    public static T ResetVerify<T>(this T o) where T : HelmDependencyBuildSettings => o.Modify(b => b.Remove(() => o.Verify));
    /// <inheritdoc cref="HelmDependencyBuildSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmDependencyBuildSettings), Property = nameof(HelmDependencyBuildSettings.Verify))]
    public static T EnableVerify<T>(this T o) where T : HelmDependencyBuildSettings => o.Modify(b => b.Set(() => o.Verify, true));
    /// <inheritdoc cref="HelmDependencyBuildSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmDependencyBuildSettings), Property = nameof(HelmDependencyBuildSettings.Verify))]
    public static T DisableVerify<T>(this T o) where T : HelmDependencyBuildSettings => o.Modify(b => b.Set(() => o.Verify, false));
    /// <inheritdoc cref="HelmDependencyBuildSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmDependencyBuildSettings), Property = nameof(HelmDependencyBuildSettings.Verify))]
    public static T ToggleVerify<T>(this T o) where T : HelmDependencyBuildSettings => o.Modify(b => b.Set(() => o.Verify, !o.Verify));
    #endregion
    #region Chart
    /// <inheritdoc cref="HelmDependencyBuildSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmDependencyBuildSettings), Property = nameof(HelmDependencyBuildSettings.Chart))]
    public static T SetChart<T>(this T o, string v) where T : HelmDependencyBuildSettings => o.Modify(b => b.Set(() => o.Chart, v));
    /// <inheritdoc cref="HelmDependencyBuildSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmDependencyBuildSettings), Property = nameof(HelmDependencyBuildSettings.Chart))]
    public static T ResetChart<T>(this T o) where T : HelmDependencyBuildSettings => o.Modify(b => b.Remove(() => o.Chart));
    #endregion
}
#endregion
#region HelmDependencyListSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmDependencyListSettingsExtensions
{
    #region Chart
    /// <inheritdoc cref="HelmDependencyListSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmDependencyListSettings), Property = nameof(HelmDependencyListSettings.Chart))]
    public static T SetChart<T>(this T o, string v) where T : HelmDependencyListSettings => o.Modify(b => b.Set(() => o.Chart, v));
    /// <inheritdoc cref="HelmDependencyListSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmDependencyListSettings), Property = nameof(HelmDependencyListSettings.Chart))]
    public static T ResetChart<T>(this T o) where T : HelmDependencyListSettings => o.Modify(b => b.Remove(() => o.Chart));
    #endregion
}
#endregion
#region HelmDependencyUpdateSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmDependencyUpdateSettingsExtensions
{
    #region Keyring
    /// <inheritdoc cref="HelmDependencyUpdateSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.Keyring))]
    public static T SetKeyring<T>(this T o, string v) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Set(() => o.Keyring, v));
    /// <inheritdoc cref="HelmDependencyUpdateSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.Keyring))]
    public static T ResetKeyring<T>(this T o) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Remove(() => o.Keyring));
    #endregion
    #region SkipRefresh
    /// <inheritdoc cref="HelmDependencyUpdateSettings.SkipRefresh"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.SkipRefresh))]
    public static T SetSkipRefresh<T>(this T o, bool? v) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Set(() => o.SkipRefresh, v));
    /// <inheritdoc cref="HelmDependencyUpdateSettings.SkipRefresh"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.SkipRefresh))]
    public static T ResetSkipRefresh<T>(this T o) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Remove(() => o.SkipRefresh));
    /// <inheritdoc cref="HelmDependencyUpdateSettings.SkipRefresh"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.SkipRefresh))]
    public static T EnableSkipRefresh<T>(this T o) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Set(() => o.SkipRefresh, true));
    /// <inheritdoc cref="HelmDependencyUpdateSettings.SkipRefresh"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.SkipRefresh))]
    public static T DisableSkipRefresh<T>(this T o) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Set(() => o.SkipRefresh, false));
    /// <inheritdoc cref="HelmDependencyUpdateSettings.SkipRefresh"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.SkipRefresh))]
    public static T ToggleSkipRefresh<T>(this T o) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Set(() => o.SkipRefresh, !o.SkipRefresh));
    #endregion
    #region Verify
    /// <inheritdoc cref="HelmDependencyUpdateSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.Verify))]
    public static T SetVerify<T>(this T o, bool? v) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Set(() => o.Verify, v));
    /// <inheritdoc cref="HelmDependencyUpdateSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.Verify))]
    public static T ResetVerify<T>(this T o) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Remove(() => o.Verify));
    /// <inheritdoc cref="HelmDependencyUpdateSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.Verify))]
    public static T EnableVerify<T>(this T o) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Set(() => o.Verify, true));
    /// <inheritdoc cref="HelmDependencyUpdateSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.Verify))]
    public static T DisableVerify<T>(this T o) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Set(() => o.Verify, false));
    /// <inheritdoc cref="HelmDependencyUpdateSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.Verify))]
    public static T ToggleVerify<T>(this T o) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Set(() => o.Verify, !o.Verify));
    #endregion
    #region Chart
    /// <inheritdoc cref="HelmDependencyUpdateSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.Chart))]
    public static T SetChart<T>(this T o, string v) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Set(() => o.Chart, v));
    /// <inheritdoc cref="HelmDependencyUpdateSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmDependencyUpdateSettings), Property = nameof(HelmDependencyUpdateSettings.Chart))]
    public static T ResetChart<T>(this T o) where T : HelmDependencyUpdateSettings => o.Modify(b => b.Remove(() => o.Chart));
    #endregion
}
#endregion
#region HelmFetchSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmFetchSettingsExtensions
{
    #region CaFile
    /// <inheritdoc cref="HelmFetchSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.CaFile))]
    public static T SetCaFile<T>(this T o, string v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.CaFile, v));
    /// <inheritdoc cref="HelmFetchSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.CaFile))]
    public static T ResetCaFile<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.CaFile));
    #endregion
    #region CertFile
    /// <inheritdoc cref="HelmFetchSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.CertFile))]
    public static T SetCertFile<T>(this T o, string v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.CertFile, v));
    /// <inheritdoc cref="HelmFetchSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.CertFile))]
    public static T ResetCertFile<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.CertFile));
    #endregion
    #region Destination
    /// <inheritdoc cref="HelmFetchSettings.Destination"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Destination))]
    public static T SetDestination<T>(this T o, string v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Destination, v));
    /// <inheritdoc cref="HelmFetchSettings.Destination"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Destination))]
    public static T ResetDestination<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.Destination));
    #endregion
    #region Devel
    /// <inheritdoc cref="HelmFetchSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Devel))]
    public static T SetDevel<T>(this T o, bool? v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Devel, v));
    /// <inheritdoc cref="HelmFetchSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Devel))]
    public static T ResetDevel<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.Devel));
    /// <inheritdoc cref="HelmFetchSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Devel))]
    public static T EnableDevel<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Devel, true));
    /// <inheritdoc cref="HelmFetchSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Devel))]
    public static T DisableDevel<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Devel, false));
    /// <inheritdoc cref="HelmFetchSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Devel))]
    public static T ToggleDevel<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Devel, !o.Devel));
    #endregion
    #region KeyFile
    /// <inheritdoc cref="HelmFetchSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.KeyFile))]
    public static T SetKeyFile<T>(this T o, string v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.KeyFile, v));
    /// <inheritdoc cref="HelmFetchSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.KeyFile))]
    public static T ResetKeyFile<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.KeyFile));
    #endregion
    #region Keyring
    /// <inheritdoc cref="HelmFetchSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Keyring))]
    public static T SetKeyring<T>(this T o, string v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Keyring, v));
    /// <inheritdoc cref="HelmFetchSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Keyring))]
    public static T ResetKeyring<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.Keyring));
    #endregion
    #region Password
    /// <inheritdoc cref="HelmFetchSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="HelmFetchSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Prov
    /// <inheritdoc cref="HelmFetchSettings.Prov"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Prov))]
    public static T SetProv<T>(this T o, bool? v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Prov, v));
    /// <inheritdoc cref="HelmFetchSettings.Prov"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Prov))]
    public static T ResetProv<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.Prov));
    /// <inheritdoc cref="HelmFetchSettings.Prov"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Prov))]
    public static T EnableProv<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Prov, true));
    /// <inheritdoc cref="HelmFetchSettings.Prov"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Prov))]
    public static T DisableProv<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Prov, false));
    /// <inheritdoc cref="HelmFetchSettings.Prov"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Prov))]
    public static T ToggleProv<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Prov, !o.Prov));
    #endregion
    #region Repo
    /// <inheritdoc cref="HelmFetchSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Repo))]
    public static T SetRepo<T>(this T o, string v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Repo, v));
    /// <inheritdoc cref="HelmFetchSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Repo))]
    public static T ResetRepo<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.Repo));
    #endregion
    #region Untar
    /// <inheritdoc cref="HelmFetchSettings.Untar"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Untar))]
    public static T SetUntar<T>(this T o, bool? v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Untar, v));
    /// <inheritdoc cref="HelmFetchSettings.Untar"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Untar))]
    public static T ResetUntar<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.Untar));
    /// <inheritdoc cref="HelmFetchSettings.Untar"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Untar))]
    public static T EnableUntar<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Untar, true));
    /// <inheritdoc cref="HelmFetchSettings.Untar"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Untar))]
    public static T DisableUntar<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Untar, false));
    /// <inheritdoc cref="HelmFetchSettings.Untar"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Untar))]
    public static T ToggleUntar<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Untar, !o.Untar));
    #endregion
    #region Untardir
    /// <inheritdoc cref="HelmFetchSettings.Untardir"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Untardir))]
    public static T SetUntardir<T>(this T o, string v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Untardir, v));
    /// <inheritdoc cref="HelmFetchSettings.Untardir"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Untardir))]
    public static T ResetUntardir<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.Untardir));
    #endregion
    #region Username
    /// <inheritdoc cref="HelmFetchSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="HelmFetchSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Verify
    /// <inheritdoc cref="HelmFetchSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Verify))]
    public static T SetVerify<T>(this T o, bool? v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Verify, v));
    /// <inheritdoc cref="HelmFetchSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Verify))]
    public static T ResetVerify<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.Verify));
    /// <inheritdoc cref="HelmFetchSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Verify))]
    public static T EnableVerify<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Verify, true));
    /// <inheritdoc cref="HelmFetchSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Verify))]
    public static T DisableVerify<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Verify, false));
    /// <inheritdoc cref="HelmFetchSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Verify))]
    public static T ToggleVerify<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Verify, !o.Verify));
    #endregion
    #region Version
    /// <inheritdoc cref="HelmFetchSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="HelmFetchSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Charts
    /// <inheritdoc cref="HelmFetchSettings.Charts"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Charts))]
    public static T SetCharts<T>(this T o, params string[] v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Charts, v));
    /// <inheritdoc cref="HelmFetchSettings.Charts"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Charts))]
    public static T SetCharts<T>(this T o, IEnumerable<string> v) where T : HelmFetchSettings => o.Modify(b => b.Set(() => o.Charts, v));
    /// <inheritdoc cref="HelmFetchSettings.Charts"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Charts))]
    public static T AddCharts<T>(this T o, params string[] v) where T : HelmFetchSettings => o.Modify(b => b.AddCollection(() => o.Charts, v));
    /// <inheritdoc cref="HelmFetchSettings.Charts"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Charts))]
    public static T AddCharts<T>(this T o, IEnumerable<string> v) where T : HelmFetchSettings => o.Modify(b => b.AddCollection(() => o.Charts, v));
    /// <inheritdoc cref="HelmFetchSettings.Charts"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Charts))]
    public static T RemoveCharts<T>(this T o, params string[] v) where T : HelmFetchSettings => o.Modify(b => b.RemoveCollection(() => o.Charts, v));
    /// <inheritdoc cref="HelmFetchSettings.Charts"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Charts))]
    public static T RemoveCharts<T>(this T o, IEnumerable<string> v) where T : HelmFetchSettings => o.Modify(b => b.RemoveCollection(() => o.Charts, v));
    /// <inheritdoc cref="HelmFetchSettings.Charts"/>
    [Pure] [Builder(Type = typeof(HelmFetchSettings), Property = nameof(HelmFetchSettings.Charts))]
    public static T ClearCharts<T>(this T o) where T : HelmFetchSettings => o.Modify(b => b.ClearCollection(() => o.Charts));
    #endregion
}
#endregion
#region HelmGetSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmGetSettingsExtensions
{
    #region Revision
    /// <inheritdoc cref="HelmGetSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.Revision))]
    public static T SetRevision<T>(this T o, int? v) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.Revision, v));
    /// <inheritdoc cref="HelmGetSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.Revision))]
    public static T ResetRevision<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Remove(() => o.Revision));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmGetSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmGetSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmGetSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmGetSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmGetSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmGetSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmGetSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmGetSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmGetSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmGetSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmGetSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmGetSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmGetSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmGetSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmGetSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmGetSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmGetSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmGetSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region ReleaseName
    /// <inheritdoc cref="HelmGetSettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.ReleaseName))]
    public static T SetReleaseName<T>(this T o, string v) where T : HelmGetSettings => o.Modify(b => b.Set(() => o.ReleaseName, v));
    /// <inheritdoc cref="HelmGetSettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmGetSettings), Property = nameof(HelmGetSettings.ReleaseName))]
    public static T ResetReleaseName<T>(this T o) where T : HelmGetSettings => o.Modify(b => b.Remove(() => o.ReleaseName));
    #endregion
}
#endregion
#region HelmGetHooksSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmGetHooksSettingsExtensions
{
    #region Revision
    /// <inheritdoc cref="HelmGetHooksSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.Revision))]
    public static T SetRevision<T>(this T o, int? v) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.Revision, v));
    /// <inheritdoc cref="HelmGetHooksSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.Revision))]
    public static T ResetRevision<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Remove(() => o.Revision));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmGetHooksSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmGetHooksSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmGetHooksSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmGetHooksSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmGetHooksSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmGetHooksSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmGetHooksSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmGetHooksSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmGetHooksSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmGetHooksSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmGetHooksSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmGetHooksSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmGetHooksSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmGetHooksSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmGetHooksSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmGetHooksSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmGetHooksSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmGetHooksSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region ReleaseName
    /// <inheritdoc cref="HelmGetHooksSettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.ReleaseName))]
    public static T SetReleaseName<T>(this T o, string v) where T : HelmGetHooksSettings => o.Modify(b => b.Set(() => o.ReleaseName, v));
    /// <inheritdoc cref="HelmGetHooksSettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmGetHooksSettings), Property = nameof(HelmGetHooksSettings.ReleaseName))]
    public static T ResetReleaseName<T>(this T o) where T : HelmGetHooksSettings => o.Modify(b => b.Remove(() => o.ReleaseName));
    #endregion
}
#endregion
#region HelmGetManifestSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmGetManifestSettingsExtensions
{
    #region Revision
    /// <inheritdoc cref="HelmGetManifestSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.Revision))]
    public static T SetRevision<T>(this T o, int? v) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.Revision, v));
    /// <inheritdoc cref="HelmGetManifestSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.Revision))]
    public static T ResetRevision<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Remove(() => o.Revision));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmGetManifestSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmGetManifestSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmGetManifestSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmGetManifestSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmGetManifestSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmGetManifestSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmGetManifestSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmGetManifestSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmGetManifestSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmGetManifestSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmGetManifestSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmGetManifestSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmGetManifestSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmGetManifestSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmGetManifestSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmGetManifestSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmGetManifestSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmGetManifestSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region ReleaseName
    /// <inheritdoc cref="HelmGetManifestSettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.ReleaseName))]
    public static T SetReleaseName<T>(this T o, string v) where T : HelmGetManifestSettings => o.Modify(b => b.Set(() => o.ReleaseName, v));
    /// <inheritdoc cref="HelmGetManifestSettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmGetManifestSettings), Property = nameof(HelmGetManifestSettings.ReleaseName))]
    public static T ResetReleaseName<T>(this T o) where T : HelmGetManifestSettings => o.Modify(b => b.Remove(() => o.ReleaseName));
    #endregion
}
#endregion
#region HelmGetNotesSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmGetNotesSettingsExtensions
{
    #region Revision
    /// <inheritdoc cref="HelmGetNotesSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.Revision))]
    public static T SetRevision<T>(this T o, int? v) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.Revision, v));
    /// <inheritdoc cref="HelmGetNotesSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.Revision))]
    public static T ResetRevision<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Remove(() => o.Revision));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmGetNotesSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmGetNotesSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmGetNotesSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmGetNotesSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmGetNotesSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmGetNotesSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmGetNotesSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmGetNotesSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmGetNotesSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmGetNotesSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmGetNotesSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmGetNotesSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmGetNotesSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmGetNotesSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmGetNotesSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmGetNotesSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmGetNotesSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmGetNotesSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region ReleaseName
    /// <inheritdoc cref="HelmGetNotesSettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.ReleaseName))]
    public static T SetReleaseName<T>(this T o, string v) where T : HelmGetNotesSettings => o.Modify(b => b.Set(() => o.ReleaseName, v));
    /// <inheritdoc cref="HelmGetNotesSettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmGetNotesSettings), Property = nameof(HelmGetNotesSettings.ReleaseName))]
    public static T ResetReleaseName<T>(this T o) where T : HelmGetNotesSettings => o.Modify(b => b.Remove(() => o.ReleaseName));
    #endregion
}
#endregion
#region HelmGetValuesSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmGetValuesSettingsExtensions
{
    #region All
    /// <inheritdoc cref="HelmGetValuesSettings.All"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.All))]
    public static T SetAll<T>(this T o, bool? v) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.All, v));
    /// <inheritdoc cref="HelmGetValuesSettings.All"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.All))]
    public static T ResetAll<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Remove(() => o.All));
    /// <inheritdoc cref="HelmGetValuesSettings.All"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.All))]
    public static T EnableAll<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.All, true));
    /// <inheritdoc cref="HelmGetValuesSettings.All"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.All))]
    public static T DisableAll<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.All, false));
    /// <inheritdoc cref="HelmGetValuesSettings.All"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.All))]
    public static T ToggleAll<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.All, !o.All));
    #endregion
    #region Output
    /// <inheritdoc cref="HelmGetValuesSettings.Output"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.Output))]
    public static T SetOutput<T>(this T o, string v) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="HelmGetValuesSettings.Output"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region Revision
    /// <inheritdoc cref="HelmGetValuesSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.Revision))]
    public static T SetRevision<T>(this T o, int? v) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.Revision, v));
    /// <inheritdoc cref="HelmGetValuesSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.Revision))]
    public static T ResetRevision<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Remove(() => o.Revision));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmGetValuesSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmGetValuesSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmGetValuesSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmGetValuesSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmGetValuesSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmGetValuesSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmGetValuesSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmGetValuesSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmGetValuesSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmGetValuesSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmGetValuesSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmGetValuesSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmGetValuesSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmGetValuesSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmGetValuesSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmGetValuesSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmGetValuesSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmGetValuesSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region ReleaseName
    /// <inheritdoc cref="HelmGetValuesSettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.ReleaseName))]
    public static T SetReleaseName<T>(this T o, string v) where T : HelmGetValuesSettings => o.Modify(b => b.Set(() => o.ReleaseName, v));
    /// <inheritdoc cref="HelmGetValuesSettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmGetValuesSettings), Property = nameof(HelmGetValuesSettings.ReleaseName))]
    public static T ResetReleaseName<T>(this T o) where T : HelmGetValuesSettings => o.Modify(b => b.Remove(() => o.ReleaseName));
    #endregion
}
#endregion
#region HelmHistorySettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmHistorySettingsExtensions
{
    #region ColWidth
    /// <inheritdoc cref="HelmHistorySettings.ColWidth"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.ColWidth))]
    public static T SetColWidth<T>(this T o, uint? v) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.ColWidth, v));
    /// <inheritdoc cref="HelmHistorySettings.ColWidth"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.ColWidth))]
    public static T ResetColWidth<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Remove(() => o.ColWidth));
    #endregion
    #region Max
    /// <inheritdoc cref="HelmHistorySettings.Max"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.Max))]
    public static T SetMax<T>(this T o, int? v) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.Max, v));
    /// <inheritdoc cref="HelmHistorySettings.Max"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.Max))]
    public static T ResetMax<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Remove(() => o.Max));
    #endregion
    #region Output
    /// <inheritdoc cref="HelmHistorySettings.Output"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.Output))]
    public static T SetOutput<T>(this T o, string v) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="HelmHistorySettings.Output"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.Output))]
    public static T ResetOutput<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmHistorySettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmHistorySettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmHistorySettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmHistorySettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmHistorySettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmHistorySettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmHistorySettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmHistorySettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmHistorySettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmHistorySettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmHistorySettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmHistorySettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmHistorySettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmHistorySettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmHistorySettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmHistorySettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmHistorySettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmHistorySettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region ReleaseName
    /// <inheritdoc cref="HelmHistorySettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.ReleaseName))]
    public static T SetReleaseName<T>(this T o, string v) where T : HelmHistorySettings => o.Modify(b => b.Set(() => o.ReleaseName, v));
    /// <inheritdoc cref="HelmHistorySettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmHistorySettings), Property = nameof(HelmHistorySettings.ReleaseName))]
    public static T ResetReleaseName<T>(this T o) where T : HelmHistorySettings => o.Modify(b => b.Remove(() => o.ReleaseName));
    #endregion
}
#endregion
#region HelmHomeSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmHomeSettingsExtensions
{
}
#endregion
#region HelmInitSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmInitSettingsExtensions
{
    #region AutomountServiceAccountToken
    /// <inheritdoc cref="HelmInitSettings.AutomountServiceAccountToken"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.AutomountServiceAccountToken))]
    public static T SetAutomountServiceAccountToken<T>(this T o, bool? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.AutomountServiceAccountToken, v));
    /// <inheritdoc cref="HelmInitSettings.AutomountServiceAccountToken"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.AutomountServiceAccountToken))]
    public static T ResetAutomountServiceAccountToken<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.AutomountServiceAccountToken));
    /// <inheritdoc cref="HelmInitSettings.AutomountServiceAccountToken"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.AutomountServiceAccountToken))]
    public static T EnableAutomountServiceAccountToken<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.AutomountServiceAccountToken, true));
    /// <inheritdoc cref="HelmInitSettings.AutomountServiceAccountToken"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.AutomountServiceAccountToken))]
    public static T DisableAutomountServiceAccountToken<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.AutomountServiceAccountToken, false));
    /// <inheritdoc cref="HelmInitSettings.AutomountServiceAccountToken"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.AutomountServiceAccountToken))]
    public static T ToggleAutomountServiceAccountToken<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.AutomountServiceAccountToken, !o.AutomountServiceAccountToken));
    #endregion
    #region CanaryImage
    /// <inheritdoc cref="HelmInitSettings.CanaryImage"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.CanaryImage))]
    public static T SetCanaryImage<T>(this T o, bool? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.CanaryImage, v));
    /// <inheritdoc cref="HelmInitSettings.CanaryImage"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.CanaryImage))]
    public static T ResetCanaryImage<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.CanaryImage));
    /// <inheritdoc cref="HelmInitSettings.CanaryImage"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.CanaryImage))]
    public static T EnableCanaryImage<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.CanaryImage, true));
    /// <inheritdoc cref="HelmInitSettings.CanaryImage"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.CanaryImage))]
    public static T DisableCanaryImage<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.CanaryImage, false));
    /// <inheritdoc cref="HelmInitSettings.CanaryImage"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.CanaryImage))]
    public static T ToggleCanaryImage<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.CanaryImage, !o.CanaryImage));
    #endregion
    #region ClientOnly
    /// <inheritdoc cref="HelmInitSettings.ClientOnly"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.ClientOnly))]
    public static T SetClientOnly<T>(this T o, bool? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.ClientOnly, v));
    /// <inheritdoc cref="HelmInitSettings.ClientOnly"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.ClientOnly))]
    public static T ResetClientOnly<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.ClientOnly));
    /// <inheritdoc cref="HelmInitSettings.ClientOnly"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.ClientOnly))]
    public static T EnableClientOnly<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.ClientOnly, true));
    /// <inheritdoc cref="HelmInitSettings.ClientOnly"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.ClientOnly))]
    public static T DisableClientOnly<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.ClientOnly, false));
    /// <inheritdoc cref="HelmInitSettings.ClientOnly"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.ClientOnly))]
    public static T ToggleClientOnly<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.ClientOnly, !o.ClientOnly));
    #endregion
    #region DryRun
    /// <inheritdoc cref="HelmInitSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.DryRun))]
    public static T SetDryRun<T>(this T o, bool? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.DryRun, v));
    /// <inheritdoc cref="HelmInitSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.DryRun))]
    public static T ResetDryRun<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.DryRun));
    /// <inheritdoc cref="HelmInitSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.DryRun))]
    public static T EnableDryRun<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.DryRun, true));
    /// <inheritdoc cref="HelmInitSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.DryRun))]
    public static T DisableDryRun<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.DryRun, false));
    /// <inheritdoc cref="HelmInitSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.DryRun))]
    public static T ToggleDryRun<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.DryRun, !o.DryRun));
    #endregion
    #region ForceUpgrade
    /// <inheritdoc cref="HelmInitSettings.ForceUpgrade"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.ForceUpgrade))]
    public static T SetForceUpgrade<T>(this T o, bool? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.ForceUpgrade, v));
    /// <inheritdoc cref="HelmInitSettings.ForceUpgrade"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.ForceUpgrade))]
    public static T ResetForceUpgrade<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.ForceUpgrade));
    /// <inheritdoc cref="HelmInitSettings.ForceUpgrade"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.ForceUpgrade))]
    public static T EnableForceUpgrade<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.ForceUpgrade, true));
    /// <inheritdoc cref="HelmInitSettings.ForceUpgrade"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.ForceUpgrade))]
    public static T DisableForceUpgrade<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.ForceUpgrade, false));
    /// <inheritdoc cref="HelmInitSettings.ForceUpgrade"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.ForceUpgrade))]
    public static T ToggleForceUpgrade<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.ForceUpgrade, !o.ForceUpgrade));
    #endregion
    #region HistoryMax
    /// <inheritdoc cref="HelmInitSettings.HistoryMax"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.HistoryMax))]
    public static T SetHistoryMax<T>(this T o, long? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.HistoryMax, v));
    /// <inheritdoc cref="HelmInitSettings.HistoryMax"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.HistoryMax))]
    public static T ResetHistoryMax<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.HistoryMax));
    #endregion
    #region LocalRepoUrl
    /// <inheritdoc cref="HelmInitSettings.LocalRepoUrl"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.LocalRepoUrl))]
    public static T SetLocalRepoUrl<T>(this T o, string v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.LocalRepoUrl, v));
    /// <inheritdoc cref="HelmInitSettings.LocalRepoUrl"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.LocalRepoUrl))]
    public static T ResetLocalRepoUrl<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.LocalRepoUrl));
    #endregion
    #region NetHost
    /// <inheritdoc cref="HelmInitSettings.NetHost"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.NetHost))]
    public static T SetNetHost<T>(this T o, bool? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.NetHost, v));
    /// <inheritdoc cref="HelmInitSettings.NetHost"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.NetHost))]
    public static T ResetNetHost<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.NetHost));
    /// <inheritdoc cref="HelmInitSettings.NetHost"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.NetHost))]
    public static T EnableNetHost<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.NetHost, true));
    /// <inheritdoc cref="HelmInitSettings.NetHost"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.NetHost))]
    public static T DisableNetHost<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.NetHost, false));
    /// <inheritdoc cref="HelmInitSettings.NetHost"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.NetHost))]
    public static T ToggleNetHost<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.NetHost, !o.NetHost));
    #endregion
    #region NodeSelectors
    /// <inheritdoc cref="HelmInitSettings.NodeSelectors"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.NodeSelectors))]
    public static T SetNodeSelectors<T>(this T o, string v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.NodeSelectors, v));
    /// <inheritdoc cref="HelmInitSettings.NodeSelectors"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.NodeSelectors))]
    public static T ResetNodeSelectors<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.NodeSelectors));
    #endregion
    #region Output
    /// <inheritdoc cref="HelmInitSettings.Output"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Output))]
    public static T SetOutput<T>(this T o, HelmOutputFormat v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="HelmInitSettings.Output"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region Override
    /// <inheritdoc cref="HelmInitSettings.Override"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Override))]
    public static T SetOverride<T>(this T o, IDictionary<string, object> v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.Override, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmInitSettings.Override"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Override))]
    public static T SetOverride<T>(this T o, string k, object v) where T : HelmInitSettings => o.Modify(b => b.SetDictionary(() => o.Override, k, v));
    /// <inheritdoc cref="HelmInitSettings.Override"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Override))]
    public static T AddOverride<T>(this T o, string k, object v) where T : HelmInitSettings => o.Modify(b => b.AddDictionary(() => o.Override, k, v));
    /// <inheritdoc cref="HelmInitSettings.Override"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Override))]
    public static T RemoveOverride<T>(this T o, string k) where T : HelmInitSettings => o.Modify(b => b.RemoveDictionary(() => o.Override, k));
    /// <inheritdoc cref="HelmInitSettings.Override"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Override))]
    public static T ClearOverride<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.ClearDictionary(() => o.Override));
    #endregion
    #region Replicas
    /// <inheritdoc cref="HelmInitSettings.Replicas"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Replicas))]
    public static T SetReplicas<T>(this T o, long? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.Replicas, v));
    /// <inheritdoc cref="HelmInitSettings.Replicas"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Replicas))]
    public static T ResetReplicas<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.Replicas));
    #endregion
    #region ServiceAccount
    /// <inheritdoc cref="HelmInitSettings.ServiceAccount"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.ServiceAccount))]
    public static T SetServiceAccount<T>(this T o, string v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.ServiceAccount, v));
    /// <inheritdoc cref="HelmInitSettings.ServiceAccount"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.ServiceAccount))]
    public static T ResetServiceAccount<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.ServiceAccount));
    #endregion
    #region SkipRefresh
    /// <inheritdoc cref="HelmInitSettings.SkipRefresh"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.SkipRefresh))]
    public static T SetSkipRefresh<T>(this T o, bool? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.SkipRefresh, v));
    /// <inheritdoc cref="HelmInitSettings.SkipRefresh"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.SkipRefresh))]
    public static T ResetSkipRefresh<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.SkipRefresh));
    /// <inheritdoc cref="HelmInitSettings.SkipRefresh"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.SkipRefresh))]
    public static T EnableSkipRefresh<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.SkipRefresh, true));
    /// <inheritdoc cref="HelmInitSettings.SkipRefresh"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.SkipRefresh))]
    public static T DisableSkipRefresh<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.SkipRefresh, false));
    /// <inheritdoc cref="HelmInitSettings.SkipRefresh"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.SkipRefresh))]
    public static T ToggleSkipRefresh<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.SkipRefresh, !o.SkipRefresh));
    #endregion
    #region StableRepoUrl
    /// <inheritdoc cref="HelmInitSettings.StableRepoUrl"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.StableRepoUrl))]
    public static T SetStableRepoUrl<T>(this T o, string v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.StableRepoUrl, v));
    /// <inheritdoc cref="HelmInitSettings.StableRepoUrl"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.StableRepoUrl))]
    public static T ResetStableRepoUrl<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.StableRepoUrl));
    #endregion
    #region TillerImage
    /// <inheritdoc cref="HelmInitSettings.TillerImage"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerImage))]
    public static T SetTillerImage<T>(this T o, string v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TillerImage, v));
    /// <inheritdoc cref="HelmInitSettings.TillerImage"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerImage))]
    public static T ResetTillerImage<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.TillerImage));
    #endregion
    #region TillerTls
    /// <inheritdoc cref="HelmInitSettings.TillerTls"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTls))]
    public static T SetTillerTls<T>(this T o, bool? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TillerTls, v));
    /// <inheritdoc cref="HelmInitSettings.TillerTls"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTls))]
    public static T ResetTillerTls<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.TillerTls));
    /// <inheritdoc cref="HelmInitSettings.TillerTls"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTls))]
    public static T EnableTillerTls<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TillerTls, true));
    /// <inheritdoc cref="HelmInitSettings.TillerTls"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTls))]
    public static T DisableTillerTls<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TillerTls, false));
    /// <inheritdoc cref="HelmInitSettings.TillerTls"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTls))]
    public static T ToggleTillerTls<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TillerTls, !o.TillerTls));
    #endregion
    #region TillerTlsCert
    /// <inheritdoc cref="HelmInitSettings.TillerTlsCert"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTlsCert))]
    public static T SetTillerTlsCert<T>(this T o, string v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TillerTlsCert, v));
    /// <inheritdoc cref="HelmInitSettings.TillerTlsCert"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTlsCert))]
    public static T ResetTillerTlsCert<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.TillerTlsCert));
    #endregion
    #region TillerTlsHostname
    /// <inheritdoc cref="HelmInitSettings.TillerTlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTlsHostname))]
    public static T SetTillerTlsHostname<T>(this T o, string v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TillerTlsHostname, v));
    /// <inheritdoc cref="HelmInitSettings.TillerTlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTlsHostname))]
    public static T ResetTillerTlsHostname<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.TillerTlsHostname));
    #endregion
    #region TillerTlsKey
    /// <inheritdoc cref="HelmInitSettings.TillerTlsKey"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTlsKey))]
    public static T SetTillerTlsKey<T>(this T o, string v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TillerTlsKey, v));
    /// <inheritdoc cref="HelmInitSettings.TillerTlsKey"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTlsKey))]
    public static T ResetTillerTlsKey<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.TillerTlsKey));
    #endregion
    #region TillerTlsVerify
    /// <inheritdoc cref="HelmInitSettings.TillerTlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTlsVerify))]
    public static T SetTillerTlsVerify<T>(this T o, bool? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TillerTlsVerify, v));
    /// <inheritdoc cref="HelmInitSettings.TillerTlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTlsVerify))]
    public static T ResetTillerTlsVerify<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.TillerTlsVerify));
    /// <inheritdoc cref="HelmInitSettings.TillerTlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTlsVerify))]
    public static T EnableTillerTlsVerify<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TillerTlsVerify, true));
    /// <inheritdoc cref="HelmInitSettings.TillerTlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTlsVerify))]
    public static T DisableTillerTlsVerify<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TillerTlsVerify, false));
    /// <inheritdoc cref="HelmInitSettings.TillerTlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TillerTlsVerify))]
    public static T ToggleTillerTlsVerify<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TillerTlsVerify, !o.TillerTlsVerify));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmInitSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmInitSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region Upgrade
    /// <inheritdoc cref="HelmInitSettings.Upgrade"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Upgrade))]
    public static T SetUpgrade<T>(this T o, bool? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.Upgrade, v));
    /// <inheritdoc cref="HelmInitSettings.Upgrade"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Upgrade))]
    public static T ResetUpgrade<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.Upgrade));
    /// <inheritdoc cref="HelmInitSettings.Upgrade"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Upgrade))]
    public static T EnableUpgrade<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.Upgrade, true));
    /// <inheritdoc cref="HelmInitSettings.Upgrade"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Upgrade))]
    public static T DisableUpgrade<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.Upgrade, false));
    /// <inheritdoc cref="HelmInitSettings.Upgrade"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Upgrade))]
    public static T ToggleUpgrade<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.Upgrade, !o.Upgrade));
    #endregion
    #region Wait
    /// <inheritdoc cref="HelmInitSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Wait))]
    public static T SetWait<T>(this T o, bool? v) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.Wait, v));
    /// <inheritdoc cref="HelmInitSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Wait))]
    public static T ResetWait<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Remove(() => o.Wait));
    /// <inheritdoc cref="HelmInitSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Wait))]
    public static T EnableWait<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.Wait, true));
    /// <inheritdoc cref="HelmInitSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Wait))]
    public static T DisableWait<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.Wait, false));
    /// <inheritdoc cref="HelmInitSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmInitSettings), Property = nameof(HelmInitSettings.Wait))]
    public static T ToggleWait<T>(this T o) where T : HelmInitSettings => o.Modify(b => b.Set(() => o.Wait, !o.Wait));
    #endregion
}
#endregion
#region HelmInspectSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmInspectSettingsExtensions
{
    #region CaFile
    /// <inheritdoc cref="HelmInspectSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.CaFile))]
    public static T SetCaFile<T>(this T o, string v) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.CaFile, v));
    /// <inheritdoc cref="HelmInspectSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.CaFile))]
    public static T ResetCaFile<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Remove(() => o.CaFile));
    #endregion
    #region CertFile
    /// <inheritdoc cref="HelmInspectSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.CertFile))]
    public static T SetCertFile<T>(this T o, string v) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.CertFile, v));
    /// <inheritdoc cref="HelmInspectSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.CertFile))]
    public static T ResetCertFile<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Remove(() => o.CertFile));
    #endregion
    #region Devel
    /// <inheritdoc cref="HelmInspectSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Devel))]
    public static T SetDevel<T>(this T o, bool? v) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Devel, v));
    /// <inheritdoc cref="HelmInspectSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Devel))]
    public static T ResetDevel<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Remove(() => o.Devel));
    /// <inheritdoc cref="HelmInspectSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Devel))]
    public static T EnableDevel<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Devel, true));
    /// <inheritdoc cref="HelmInspectSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Devel))]
    public static T DisableDevel<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Devel, false));
    /// <inheritdoc cref="HelmInspectSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Devel))]
    public static T ToggleDevel<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Devel, !o.Devel));
    #endregion
    #region KeyFile
    /// <inheritdoc cref="HelmInspectSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.KeyFile))]
    public static T SetKeyFile<T>(this T o, string v) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.KeyFile, v));
    /// <inheritdoc cref="HelmInspectSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.KeyFile))]
    public static T ResetKeyFile<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Remove(() => o.KeyFile));
    #endregion
    #region Keyring
    /// <inheritdoc cref="HelmInspectSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Keyring))]
    public static T SetKeyring<T>(this T o, string v) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Keyring, v));
    /// <inheritdoc cref="HelmInspectSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Keyring))]
    public static T ResetKeyring<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Remove(() => o.Keyring));
    #endregion
    #region Password
    /// <inheritdoc cref="HelmInspectSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="HelmInspectSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Repo
    /// <inheritdoc cref="HelmInspectSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Repo))]
    public static T SetRepo<T>(this T o, string v) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Repo, v));
    /// <inheritdoc cref="HelmInspectSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Repo))]
    public static T ResetRepo<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Remove(() => o.Repo));
    #endregion
    #region Username
    /// <inheritdoc cref="HelmInspectSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="HelmInspectSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Verify
    /// <inheritdoc cref="HelmInspectSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Verify))]
    public static T SetVerify<T>(this T o, bool? v) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Verify, v));
    /// <inheritdoc cref="HelmInspectSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Verify))]
    public static T ResetVerify<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Remove(() => o.Verify));
    /// <inheritdoc cref="HelmInspectSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Verify))]
    public static T EnableVerify<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Verify, true));
    /// <inheritdoc cref="HelmInspectSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Verify))]
    public static T DisableVerify<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Verify, false));
    /// <inheritdoc cref="HelmInspectSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Verify))]
    public static T ToggleVerify<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Verify, !o.Verify));
    #endregion
    #region Version
    /// <inheritdoc cref="HelmInspectSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="HelmInspectSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Chart
    /// <inheritdoc cref="HelmInspectSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Chart))]
    public static T SetChart<T>(this T o, string v) where T : HelmInspectSettings => o.Modify(b => b.Set(() => o.Chart, v));
    /// <inheritdoc cref="HelmInspectSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmInspectSettings), Property = nameof(HelmInspectSettings.Chart))]
    public static T ResetChart<T>(this T o) where T : HelmInspectSettings => o.Modify(b => b.Remove(() => o.Chart));
    #endregion
}
#endregion
#region HelmInspectChartSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmInspectChartSettingsExtensions
{
    #region CaFile
    /// <inheritdoc cref="HelmInspectChartSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.CaFile))]
    public static T SetCaFile<T>(this T o, string v) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.CaFile, v));
    /// <inheritdoc cref="HelmInspectChartSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.CaFile))]
    public static T ResetCaFile<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Remove(() => o.CaFile));
    #endregion
    #region CertFile
    /// <inheritdoc cref="HelmInspectChartSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.CertFile))]
    public static T SetCertFile<T>(this T o, string v) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.CertFile, v));
    /// <inheritdoc cref="HelmInspectChartSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.CertFile))]
    public static T ResetCertFile<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Remove(() => o.CertFile));
    #endregion
    #region Devel
    /// <inheritdoc cref="HelmInspectChartSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Devel))]
    public static T SetDevel<T>(this T o, bool? v) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Devel, v));
    /// <inheritdoc cref="HelmInspectChartSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Devel))]
    public static T ResetDevel<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Remove(() => o.Devel));
    /// <inheritdoc cref="HelmInspectChartSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Devel))]
    public static T EnableDevel<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Devel, true));
    /// <inheritdoc cref="HelmInspectChartSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Devel))]
    public static T DisableDevel<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Devel, false));
    /// <inheritdoc cref="HelmInspectChartSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Devel))]
    public static T ToggleDevel<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Devel, !o.Devel));
    #endregion
    #region KeyFile
    /// <inheritdoc cref="HelmInspectChartSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.KeyFile))]
    public static T SetKeyFile<T>(this T o, string v) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.KeyFile, v));
    /// <inheritdoc cref="HelmInspectChartSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.KeyFile))]
    public static T ResetKeyFile<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Remove(() => o.KeyFile));
    #endregion
    #region Keyring
    /// <inheritdoc cref="HelmInspectChartSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Keyring))]
    public static T SetKeyring<T>(this T o, string v) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Keyring, v));
    /// <inheritdoc cref="HelmInspectChartSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Keyring))]
    public static T ResetKeyring<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Remove(() => o.Keyring));
    #endregion
    #region Password
    /// <inheritdoc cref="HelmInspectChartSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="HelmInspectChartSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Repo
    /// <inheritdoc cref="HelmInspectChartSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Repo))]
    public static T SetRepo<T>(this T o, string v) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Repo, v));
    /// <inheritdoc cref="HelmInspectChartSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Repo))]
    public static T ResetRepo<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Remove(() => o.Repo));
    #endregion
    #region Username
    /// <inheritdoc cref="HelmInspectChartSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="HelmInspectChartSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Verify
    /// <inheritdoc cref="HelmInspectChartSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Verify))]
    public static T SetVerify<T>(this T o, bool? v) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Verify, v));
    /// <inheritdoc cref="HelmInspectChartSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Verify))]
    public static T ResetVerify<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Remove(() => o.Verify));
    /// <inheritdoc cref="HelmInspectChartSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Verify))]
    public static T EnableVerify<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Verify, true));
    /// <inheritdoc cref="HelmInspectChartSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Verify))]
    public static T DisableVerify<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Verify, false));
    /// <inheritdoc cref="HelmInspectChartSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Verify))]
    public static T ToggleVerify<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Verify, !o.Verify));
    #endregion
    #region Version
    /// <inheritdoc cref="HelmInspectChartSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="HelmInspectChartSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Chart
    /// <inheritdoc cref="HelmInspectChartSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Chart))]
    public static T SetChart<T>(this T o, string v) where T : HelmInspectChartSettings => o.Modify(b => b.Set(() => o.Chart, v));
    /// <inheritdoc cref="HelmInspectChartSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmInspectChartSettings), Property = nameof(HelmInspectChartSettings.Chart))]
    public static T ResetChart<T>(this T o) where T : HelmInspectChartSettings => o.Modify(b => b.Remove(() => o.Chart));
    #endregion
}
#endregion
#region HelmInspectReadmeSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmInspectReadmeSettingsExtensions
{
    #region CaFile
    /// <inheritdoc cref="HelmInspectReadmeSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.CaFile))]
    public static T SetCaFile<T>(this T o, string v) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.CaFile, v));
    /// <inheritdoc cref="HelmInspectReadmeSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.CaFile))]
    public static T ResetCaFile<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Remove(() => o.CaFile));
    #endregion
    #region CertFile
    /// <inheritdoc cref="HelmInspectReadmeSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.CertFile))]
    public static T SetCertFile<T>(this T o, string v) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.CertFile, v));
    /// <inheritdoc cref="HelmInspectReadmeSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.CertFile))]
    public static T ResetCertFile<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Remove(() => o.CertFile));
    #endregion
    #region Devel
    /// <inheritdoc cref="HelmInspectReadmeSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Devel))]
    public static T SetDevel<T>(this T o, bool? v) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.Devel, v));
    /// <inheritdoc cref="HelmInspectReadmeSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Devel))]
    public static T ResetDevel<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Remove(() => o.Devel));
    /// <inheritdoc cref="HelmInspectReadmeSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Devel))]
    public static T EnableDevel<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.Devel, true));
    /// <inheritdoc cref="HelmInspectReadmeSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Devel))]
    public static T DisableDevel<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.Devel, false));
    /// <inheritdoc cref="HelmInspectReadmeSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Devel))]
    public static T ToggleDevel<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.Devel, !o.Devel));
    #endregion
    #region KeyFile
    /// <inheritdoc cref="HelmInspectReadmeSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.KeyFile))]
    public static T SetKeyFile<T>(this T o, string v) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.KeyFile, v));
    /// <inheritdoc cref="HelmInspectReadmeSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.KeyFile))]
    public static T ResetKeyFile<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Remove(() => o.KeyFile));
    #endregion
    #region Keyring
    /// <inheritdoc cref="HelmInspectReadmeSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Keyring))]
    public static T SetKeyring<T>(this T o, string v) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.Keyring, v));
    /// <inheritdoc cref="HelmInspectReadmeSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Keyring))]
    public static T ResetKeyring<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Remove(() => o.Keyring));
    #endregion
    #region Repo
    /// <inheritdoc cref="HelmInspectReadmeSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Repo))]
    public static T SetRepo<T>(this T o, string v) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.Repo, v));
    /// <inheritdoc cref="HelmInspectReadmeSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Repo))]
    public static T ResetRepo<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Remove(() => o.Repo));
    #endregion
    #region Verify
    /// <inheritdoc cref="HelmInspectReadmeSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Verify))]
    public static T SetVerify<T>(this T o, bool? v) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.Verify, v));
    /// <inheritdoc cref="HelmInspectReadmeSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Verify))]
    public static T ResetVerify<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Remove(() => o.Verify));
    /// <inheritdoc cref="HelmInspectReadmeSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Verify))]
    public static T EnableVerify<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.Verify, true));
    /// <inheritdoc cref="HelmInspectReadmeSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Verify))]
    public static T DisableVerify<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.Verify, false));
    /// <inheritdoc cref="HelmInspectReadmeSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Verify))]
    public static T ToggleVerify<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.Verify, !o.Verify));
    #endregion
    #region Version
    /// <inheritdoc cref="HelmInspectReadmeSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="HelmInspectReadmeSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Chart
    /// <inheritdoc cref="HelmInspectReadmeSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Chart))]
    public static T SetChart<T>(this T o, string v) where T : HelmInspectReadmeSettings => o.Modify(b => b.Set(() => o.Chart, v));
    /// <inheritdoc cref="HelmInspectReadmeSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmInspectReadmeSettings), Property = nameof(HelmInspectReadmeSettings.Chart))]
    public static T ResetChart<T>(this T o) where T : HelmInspectReadmeSettings => o.Modify(b => b.Remove(() => o.Chart));
    #endregion
}
#endregion
#region HelmInspectValuesSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmInspectValuesSettingsExtensions
{
    #region CaFile
    /// <inheritdoc cref="HelmInspectValuesSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.CaFile))]
    public static T SetCaFile<T>(this T o, string v) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.CaFile, v));
    /// <inheritdoc cref="HelmInspectValuesSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.CaFile))]
    public static T ResetCaFile<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Remove(() => o.CaFile));
    #endregion
    #region CertFile
    /// <inheritdoc cref="HelmInspectValuesSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.CertFile))]
    public static T SetCertFile<T>(this T o, string v) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.CertFile, v));
    /// <inheritdoc cref="HelmInspectValuesSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.CertFile))]
    public static T ResetCertFile<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Remove(() => o.CertFile));
    #endregion
    #region Devel
    /// <inheritdoc cref="HelmInspectValuesSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Devel))]
    public static T SetDevel<T>(this T o, bool? v) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Devel, v));
    /// <inheritdoc cref="HelmInspectValuesSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Devel))]
    public static T ResetDevel<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Remove(() => o.Devel));
    /// <inheritdoc cref="HelmInspectValuesSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Devel))]
    public static T EnableDevel<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Devel, true));
    /// <inheritdoc cref="HelmInspectValuesSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Devel))]
    public static T DisableDevel<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Devel, false));
    /// <inheritdoc cref="HelmInspectValuesSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Devel))]
    public static T ToggleDevel<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Devel, !o.Devel));
    #endregion
    #region KeyFile
    /// <inheritdoc cref="HelmInspectValuesSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.KeyFile))]
    public static T SetKeyFile<T>(this T o, string v) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.KeyFile, v));
    /// <inheritdoc cref="HelmInspectValuesSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.KeyFile))]
    public static T ResetKeyFile<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Remove(() => o.KeyFile));
    #endregion
    #region Keyring
    /// <inheritdoc cref="HelmInspectValuesSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Keyring))]
    public static T SetKeyring<T>(this T o, string v) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Keyring, v));
    /// <inheritdoc cref="HelmInspectValuesSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Keyring))]
    public static T ResetKeyring<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Remove(() => o.Keyring));
    #endregion
    #region Password
    /// <inheritdoc cref="HelmInspectValuesSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="HelmInspectValuesSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Repo
    /// <inheritdoc cref="HelmInspectValuesSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Repo))]
    public static T SetRepo<T>(this T o, string v) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Repo, v));
    /// <inheritdoc cref="HelmInspectValuesSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Repo))]
    public static T ResetRepo<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Remove(() => o.Repo));
    #endregion
    #region Username
    /// <inheritdoc cref="HelmInspectValuesSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="HelmInspectValuesSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Verify
    /// <inheritdoc cref="HelmInspectValuesSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Verify))]
    public static T SetVerify<T>(this T o, bool? v) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Verify, v));
    /// <inheritdoc cref="HelmInspectValuesSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Verify))]
    public static T ResetVerify<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Remove(() => o.Verify));
    /// <inheritdoc cref="HelmInspectValuesSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Verify))]
    public static T EnableVerify<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Verify, true));
    /// <inheritdoc cref="HelmInspectValuesSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Verify))]
    public static T DisableVerify<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Verify, false));
    /// <inheritdoc cref="HelmInspectValuesSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Verify))]
    public static T ToggleVerify<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Verify, !o.Verify));
    #endregion
    #region Version
    /// <inheritdoc cref="HelmInspectValuesSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="HelmInspectValuesSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Chart
    /// <inheritdoc cref="HelmInspectValuesSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Chart))]
    public static T SetChart<T>(this T o, string v) where T : HelmInspectValuesSettings => o.Modify(b => b.Set(() => o.Chart, v));
    /// <inheritdoc cref="HelmInspectValuesSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmInspectValuesSettings), Property = nameof(HelmInspectValuesSettings.Chart))]
    public static T ResetChart<T>(this T o) where T : HelmInspectValuesSettings => o.Modify(b => b.Remove(() => o.Chart));
    #endregion
}
#endregion
#region HelmInstallSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmInstallSettingsExtensions
{
    #region Atomic
    /// <inheritdoc cref="HelmInstallSettings.Atomic"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Atomic))]
    public static T SetAtomic<T>(this T o, bool? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Atomic, v));
    /// <inheritdoc cref="HelmInstallSettings.Atomic"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Atomic))]
    public static T ResetAtomic<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Atomic));
    /// <inheritdoc cref="HelmInstallSettings.Atomic"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Atomic))]
    public static T EnableAtomic<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Atomic, true));
    /// <inheritdoc cref="HelmInstallSettings.Atomic"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Atomic))]
    public static T DisableAtomic<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Atomic, false));
    /// <inheritdoc cref="HelmInstallSettings.Atomic"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Atomic))]
    public static T ToggleAtomic<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Atomic, !o.Atomic));
    #endregion
    #region CaFile
    /// <inheritdoc cref="HelmInstallSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.CaFile))]
    public static T SetCaFile<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.CaFile, v));
    /// <inheritdoc cref="HelmInstallSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.CaFile))]
    public static T ResetCaFile<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.CaFile));
    #endregion
    #region CertFile
    /// <inheritdoc cref="HelmInstallSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.CertFile))]
    public static T SetCertFile<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.CertFile, v));
    /// <inheritdoc cref="HelmInstallSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.CertFile))]
    public static T ResetCertFile<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.CertFile));
    #endregion
    #region DepUp
    /// <inheritdoc cref="HelmInstallSettings.DepUp"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.DepUp))]
    public static T SetDepUp<T>(this T o, bool? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.DepUp, v));
    /// <inheritdoc cref="HelmInstallSettings.DepUp"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.DepUp))]
    public static T ResetDepUp<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.DepUp));
    /// <inheritdoc cref="HelmInstallSettings.DepUp"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.DepUp))]
    public static T EnableDepUp<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.DepUp, true));
    /// <inheritdoc cref="HelmInstallSettings.DepUp"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.DepUp))]
    public static T DisableDepUp<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.DepUp, false));
    /// <inheritdoc cref="HelmInstallSettings.DepUp"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.DepUp))]
    public static T ToggleDepUp<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.DepUp, !o.DepUp));
    #endregion
    #region Description
    /// <inheritdoc cref="HelmInstallSettings.Description"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Description))]
    public static T SetDescription<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Description, v));
    /// <inheritdoc cref="HelmInstallSettings.Description"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Description))]
    public static T ResetDescription<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Description));
    #endregion
    #region Devel
    /// <inheritdoc cref="HelmInstallSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Devel))]
    public static T SetDevel<T>(this T o, bool? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Devel, v));
    /// <inheritdoc cref="HelmInstallSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Devel))]
    public static T ResetDevel<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Devel));
    /// <inheritdoc cref="HelmInstallSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Devel))]
    public static T EnableDevel<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Devel, true));
    /// <inheritdoc cref="HelmInstallSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Devel))]
    public static T DisableDevel<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Devel, false));
    /// <inheritdoc cref="HelmInstallSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Devel))]
    public static T ToggleDevel<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Devel, !o.Devel));
    #endregion
    #region DryRun
    /// <inheritdoc cref="HelmInstallSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.DryRun))]
    public static T SetDryRun<T>(this T o, bool? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.DryRun, v));
    /// <inheritdoc cref="HelmInstallSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.DryRun))]
    public static T ResetDryRun<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.DryRun));
    /// <inheritdoc cref="HelmInstallSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.DryRun))]
    public static T EnableDryRun<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.DryRun, true));
    /// <inheritdoc cref="HelmInstallSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.DryRun))]
    public static T DisableDryRun<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.DryRun, false));
    /// <inheritdoc cref="HelmInstallSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.DryRun))]
    public static T ToggleDryRun<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.DryRun, !o.DryRun));
    #endregion
    #region KeyFile
    /// <inheritdoc cref="HelmInstallSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.KeyFile))]
    public static T SetKeyFile<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.KeyFile, v));
    /// <inheritdoc cref="HelmInstallSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.KeyFile))]
    public static T ResetKeyFile<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.KeyFile));
    #endregion
    #region Keyring
    /// <inheritdoc cref="HelmInstallSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Keyring))]
    public static T SetKeyring<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Keyring, v));
    /// <inheritdoc cref="HelmInstallSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Keyring))]
    public static T ResetKeyring<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Keyring));
    #endregion
    #region Name
    /// <inheritdoc cref="HelmInstallSettings.Name"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="HelmInstallSettings.Name"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Name))]
    public static T ResetName<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region NameTemplate
    /// <inheritdoc cref="HelmInstallSettings.NameTemplate"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.NameTemplate))]
    public static T SetNameTemplate<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.NameTemplate, v));
    /// <inheritdoc cref="HelmInstallSettings.NameTemplate"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.NameTemplate))]
    public static T ResetNameTemplate<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.NameTemplate));
    #endregion
    #region Namespace
    /// <inheritdoc cref="HelmInstallSettings.Namespace"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Namespace))]
    public static T SetNamespace<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Namespace, v));
    /// <inheritdoc cref="HelmInstallSettings.Namespace"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Namespace))]
    public static T ResetNamespace<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Namespace));
    #endregion
    #region NoCrdHook
    /// <inheritdoc cref="HelmInstallSettings.NoCrdHook"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.NoCrdHook))]
    public static T SetNoCrdHook<T>(this T o, bool? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.NoCrdHook, v));
    /// <inheritdoc cref="HelmInstallSettings.NoCrdHook"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.NoCrdHook))]
    public static T ResetNoCrdHook<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.NoCrdHook));
    /// <inheritdoc cref="HelmInstallSettings.NoCrdHook"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.NoCrdHook))]
    public static T EnableNoCrdHook<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.NoCrdHook, true));
    /// <inheritdoc cref="HelmInstallSettings.NoCrdHook"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.NoCrdHook))]
    public static T DisableNoCrdHook<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.NoCrdHook, false));
    /// <inheritdoc cref="HelmInstallSettings.NoCrdHook"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.NoCrdHook))]
    public static T ToggleNoCrdHook<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.NoCrdHook, !o.NoCrdHook));
    #endregion
    #region NoHooks
    /// <inheritdoc cref="HelmInstallSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.NoHooks))]
    public static T SetNoHooks<T>(this T o, bool? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.NoHooks, v));
    /// <inheritdoc cref="HelmInstallSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.NoHooks))]
    public static T ResetNoHooks<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.NoHooks));
    /// <inheritdoc cref="HelmInstallSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.NoHooks))]
    public static T EnableNoHooks<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.NoHooks, true));
    /// <inheritdoc cref="HelmInstallSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.NoHooks))]
    public static T DisableNoHooks<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.NoHooks, false));
    /// <inheritdoc cref="HelmInstallSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.NoHooks))]
    public static T ToggleNoHooks<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.NoHooks, !o.NoHooks));
    #endregion
    #region Password
    /// <inheritdoc cref="HelmInstallSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="HelmInstallSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region RenderSubchartNotes
    /// <inheritdoc cref="HelmInstallSettings.RenderSubchartNotes"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.RenderSubchartNotes))]
    public static T SetRenderSubchartNotes<T>(this T o, bool? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.RenderSubchartNotes, v));
    /// <inheritdoc cref="HelmInstallSettings.RenderSubchartNotes"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.RenderSubchartNotes))]
    public static T ResetRenderSubchartNotes<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.RenderSubchartNotes));
    /// <inheritdoc cref="HelmInstallSettings.RenderSubchartNotes"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.RenderSubchartNotes))]
    public static T EnableRenderSubchartNotes<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.RenderSubchartNotes, true));
    /// <inheritdoc cref="HelmInstallSettings.RenderSubchartNotes"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.RenderSubchartNotes))]
    public static T DisableRenderSubchartNotes<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.RenderSubchartNotes, false));
    /// <inheritdoc cref="HelmInstallSettings.RenderSubchartNotes"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.RenderSubchartNotes))]
    public static T ToggleRenderSubchartNotes<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.RenderSubchartNotes, !o.RenderSubchartNotes));
    #endregion
    #region Replace
    /// <inheritdoc cref="HelmInstallSettings.Replace"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Replace))]
    public static T SetReplace<T>(this T o, bool? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Replace, v));
    /// <inheritdoc cref="HelmInstallSettings.Replace"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Replace))]
    public static T ResetReplace<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Replace));
    /// <inheritdoc cref="HelmInstallSettings.Replace"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Replace))]
    public static T EnableReplace<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Replace, true));
    /// <inheritdoc cref="HelmInstallSettings.Replace"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Replace))]
    public static T DisableReplace<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Replace, false));
    /// <inheritdoc cref="HelmInstallSettings.Replace"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Replace))]
    public static T ToggleReplace<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Replace, !o.Replace));
    #endregion
    #region Repo
    /// <inheritdoc cref="HelmInstallSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Repo))]
    public static T SetRepo<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Repo, v));
    /// <inheritdoc cref="HelmInstallSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Repo))]
    public static T ResetRepo<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Repo));
    #endregion
    #region Set
    /// <inheritdoc cref="HelmInstallSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Set))]
    public static T SetSet<T>(this T o, IDictionary<string, object> v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Set, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmInstallSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Set))]
    public static T SetSet<T>(this T o, string k, object v) where T : HelmInstallSettings => o.Modify(b => b.SetDictionary(() => o.Set, k, v));
    /// <inheritdoc cref="HelmInstallSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Set))]
    public static T AddSet<T>(this T o, string k, object v) where T : HelmInstallSettings => o.Modify(b => b.AddDictionary(() => o.Set, k, v));
    /// <inheritdoc cref="HelmInstallSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Set))]
    public static T RemoveSet<T>(this T o, string k) where T : HelmInstallSettings => o.Modify(b => b.RemoveDictionary(() => o.Set, k));
    /// <inheritdoc cref="HelmInstallSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Set))]
    public static T ClearSet<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.ClearDictionary(() => o.Set));
    #endregion
    #region SetFile
    /// <inheritdoc cref="HelmInstallSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.SetFile))]
    public static T SetSetFile<T>(this T o, IDictionary<string, object> v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.SetFile, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmInstallSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.SetFile))]
    public static T SetSetFile<T>(this T o, string k, object v) where T : HelmInstallSettings => o.Modify(b => b.SetDictionary(() => o.SetFile, k, v));
    /// <inheritdoc cref="HelmInstallSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.SetFile))]
    public static T AddSetFile<T>(this T o, string k, object v) where T : HelmInstallSettings => o.Modify(b => b.AddDictionary(() => o.SetFile, k, v));
    /// <inheritdoc cref="HelmInstallSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.SetFile))]
    public static T RemoveSetFile<T>(this T o, string k) where T : HelmInstallSettings => o.Modify(b => b.RemoveDictionary(() => o.SetFile, k));
    /// <inheritdoc cref="HelmInstallSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.SetFile))]
    public static T ClearSetFile<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.ClearDictionary(() => o.SetFile));
    #endregion
    #region SetString
    /// <inheritdoc cref="HelmInstallSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.SetString))]
    public static T SetSetString<T>(this T o, IDictionary<string, object> v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.SetString, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmInstallSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.SetString))]
    public static T SetSetString<T>(this T o, string k, object v) where T : HelmInstallSettings => o.Modify(b => b.SetDictionary(() => o.SetString, k, v));
    /// <inheritdoc cref="HelmInstallSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.SetString))]
    public static T AddSetString<T>(this T o, string k, object v) where T : HelmInstallSettings => o.Modify(b => b.AddDictionary(() => o.SetString, k, v));
    /// <inheritdoc cref="HelmInstallSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.SetString))]
    public static T RemoveSetString<T>(this T o, string k) where T : HelmInstallSettings => o.Modify(b => b.RemoveDictionary(() => o.SetString, k));
    /// <inheritdoc cref="HelmInstallSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.SetString))]
    public static T ClearSetString<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.ClearDictionary(() => o.SetString));
    #endregion
    #region Timeout
    /// <inheritdoc cref="HelmInstallSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Timeout))]
    public static T SetTimeout<T>(this T o, long? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="HelmInstallSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmInstallSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmInstallSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmInstallSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmInstallSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmInstallSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmInstallSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmInstallSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmInstallSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmInstallSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmInstallSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmInstallSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmInstallSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmInstallSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmInstallSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmInstallSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmInstallSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmInstallSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmInstallSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region Username
    /// <inheritdoc cref="HelmInstallSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="HelmInstallSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Values
    /// <inheritdoc cref="HelmInstallSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Values))]
    public static T SetValues<T>(this T o, params string[] v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Values, v));
    /// <inheritdoc cref="HelmInstallSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Values))]
    public static T SetValues<T>(this T o, IEnumerable<string> v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Values, v));
    /// <inheritdoc cref="HelmInstallSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Values))]
    public static T AddValues<T>(this T o, params string[] v) where T : HelmInstallSettings => o.Modify(b => b.AddCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmInstallSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Values))]
    public static T AddValues<T>(this T o, IEnumerable<string> v) where T : HelmInstallSettings => o.Modify(b => b.AddCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmInstallSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Values))]
    public static T RemoveValues<T>(this T o, params string[] v) where T : HelmInstallSettings => o.Modify(b => b.RemoveCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmInstallSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Values))]
    public static T RemoveValues<T>(this T o, IEnumerable<string> v) where T : HelmInstallSettings => o.Modify(b => b.RemoveCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmInstallSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Values))]
    public static T ClearValues<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.ClearCollection(() => o.Values));
    #endregion
    #region Verify
    /// <inheritdoc cref="HelmInstallSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Verify))]
    public static T SetVerify<T>(this T o, bool? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Verify, v));
    /// <inheritdoc cref="HelmInstallSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Verify))]
    public static T ResetVerify<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Verify));
    /// <inheritdoc cref="HelmInstallSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Verify))]
    public static T EnableVerify<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Verify, true));
    /// <inheritdoc cref="HelmInstallSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Verify))]
    public static T DisableVerify<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Verify, false));
    /// <inheritdoc cref="HelmInstallSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Verify))]
    public static T ToggleVerify<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Verify, !o.Verify));
    #endregion
    #region Version
    /// <inheritdoc cref="HelmInstallSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="HelmInstallSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Wait
    /// <inheritdoc cref="HelmInstallSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Wait))]
    public static T SetWait<T>(this T o, bool? v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Wait, v));
    /// <inheritdoc cref="HelmInstallSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Wait))]
    public static T ResetWait<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Wait));
    /// <inheritdoc cref="HelmInstallSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Wait))]
    public static T EnableWait<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Wait, true));
    /// <inheritdoc cref="HelmInstallSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Wait))]
    public static T DisableWait<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Wait, false));
    /// <inheritdoc cref="HelmInstallSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Wait))]
    public static T ToggleWait<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Wait, !o.Wait));
    #endregion
    #region Chart
    /// <inheritdoc cref="HelmInstallSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Chart))]
    public static T SetChart<T>(this T o, string v) where T : HelmInstallSettings => o.Modify(b => b.Set(() => o.Chart, v));
    /// <inheritdoc cref="HelmInstallSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmInstallSettings), Property = nameof(HelmInstallSettings.Chart))]
    public static T ResetChart<T>(this T o) where T : HelmInstallSettings => o.Modify(b => b.Remove(() => o.Chart));
    #endregion
}
#endregion
#region HelmLintSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmLintSettingsExtensions
{
    #region Namespace
    /// <inheritdoc cref="HelmLintSettings.Namespace"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Namespace))]
    public static T SetNamespace<T>(this T o, string v) where T : HelmLintSettings => o.Modify(b => b.Set(() => o.Namespace, v));
    /// <inheritdoc cref="HelmLintSettings.Namespace"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Namespace))]
    public static T ResetNamespace<T>(this T o) where T : HelmLintSettings => o.Modify(b => b.Remove(() => o.Namespace));
    #endregion
    #region Set
    /// <inheritdoc cref="HelmLintSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Set))]
    public static T SetSet<T>(this T o, IDictionary<string, object> v) where T : HelmLintSettings => o.Modify(b => b.Set(() => o.Set, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmLintSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Set))]
    public static T SetSet<T>(this T o, string k, object v) where T : HelmLintSettings => o.Modify(b => b.SetDictionary(() => o.Set, k, v));
    /// <inheritdoc cref="HelmLintSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Set))]
    public static T AddSet<T>(this T o, string k, object v) where T : HelmLintSettings => o.Modify(b => b.AddDictionary(() => o.Set, k, v));
    /// <inheritdoc cref="HelmLintSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Set))]
    public static T RemoveSet<T>(this T o, string k) where T : HelmLintSettings => o.Modify(b => b.RemoveDictionary(() => o.Set, k));
    /// <inheritdoc cref="HelmLintSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Set))]
    public static T ClearSet<T>(this T o) where T : HelmLintSettings => o.Modify(b => b.ClearDictionary(() => o.Set));
    #endregion
    #region SetFile
    /// <inheritdoc cref="HelmLintSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.SetFile))]
    public static T SetSetFile<T>(this T o, IDictionary<string, object> v) where T : HelmLintSettings => o.Modify(b => b.Set(() => o.SetFile, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmLintSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.SetFile))]
    public static T SetSetFile<T>(this T o, string k, object v) where T : HelmLintSettings => o.Modify(b => b.SetDictionary(() => o.SetFile, k, v));
    /// <inheritdoc cref="HelmLintSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.SetFile))]
    public static T AddSetFile<T>(this T o, string k, object v) where T : HelmLintSettings => o.Modify(b => b.AddDictionary(() => o.SetFile, k, v));
    /// <inheritdoc cref="HelmLintSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.SetFile))]
    public static T RemoveSetFile<T>(this T o, string k) where T : HelmLintSettings => o.Modify(b => b.RemoveDictionary(() => o.SetFile, k));
    /// <inheritdoc cref="HelmLintSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.SetFile))]
    public static T ClearSetFile<T>(this T o) where T : HelmLintSettings => o.Modify(b => b.ClearDictionary(() => o.SetFile));
    #endregion
    #region SetString
    /// <inheritdoc cref="HelmLintSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.SetString))]
    public static T SetSetString<T>(this T o, IDictionary<string, object> v) where T : HelmLintSettings => o.Modify(b => b.Set(() => o.SetString, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmLintSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.SetString))]
    public static T SetSetString<T>(this T o, string k, object v) where T : HelmLintSettings => o.Modify(b => b.SetDictionary(() => o.SetString, k, v));
    /// <inheritdoc cref="HelmLintSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.SetString))]
    public static T AddSetString<T>(this T o, string k, object v) where T : HelmLintSettings => o.Modify(b => b.AddDictionary(() => o.SetString, k, v));
    /// <inheritdoc cref="HelmLintSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.SetString))]
    public static T RemoveSetString<T>(this T o, string k) where T : HelmLintSettings => o.Modify(b => b.RemoveDictionary(() => o.SetString, k));
    /// <inheritdoc cref="HelmLintSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.SetString))]
    public static T ClearSetString<T>(this T o) where T : HelmLintSettings => o.Modify(b => b.ClearDictionary(() => o.SetString));
    #endregion
    #region Strict
    /// <inheritdoc cref="HelmLintSettings.Strict"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Strict))]
    public static T SetStrict<T>(this T o, bool? v) where T : HelmLintSettings => o.Modify(b => b.Set(() => o.Strict, v));
    /// <inheritdoc cref="HelmLintSettings.Strict"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Strict))]
    public static T ResetStrict<T>(this T o) where T : HelmLintSettings => o.Modify(b => b.Remove(() => o.Strict));
    /// <inheritdoc cref="HelmLintSettings.Strict"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Strict))]
    public static T EnableStrict<T>(this T o) where T : HelmLintSettings => o.Modify(b => b.Set(() => o.Strict, true));
    /// <inheritdoc cref="HelmLintSettings.Strict"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Strict))]
    public static T DisableStrict<T>(this T o) where T : HelmLintSettings => o.Modify(b => b.Set(() => o.Strict, false));
    /// <inheritdoc cref="HelmLintSettings.Strict"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Strict))]
    public static T ToggleStrict<T>(this T o) where T : HelmLintSettings => o.Modify(b => b.Set(() => o.Strict, !o.Strict));
    #endregion
    #region Values
    /// <inheritdoc cref="HelmLintSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Values))]
    public static T SetValues<T>(this T o, params string[] v) where T : HelmLintSettings => o.Modify(b => b.Set(() => o.Values, v));
    /// <inheritdoc cref="HelmLintSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Values))]
    public static T SetValues<T>(this T o, IEnumerable<string> v) where T : HelmLintSettings => o.Modify(b => b.Set(() => o.Values, v));
    /// <inheritdoc cref="HelmLintSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Values))]
    public static T AddValues<T>(this T o, params string[] v) where T : HelmLintSettings => o.Modify(b => b.AddCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmLintSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Values))]
    public static T AddValues<T>(this T o, IEnumerable<string> v) where T : HelmLintSettings => o.Modify(b => b.AddCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmLintSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Values))]
    public static T RemoveValues<T>(this T o, params string[] v) where T : HelmLintSettings => o.Modify(b => b.RemoveCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmLintSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Values))]
    public static T RemoveValues<T>(this T o, IEnumerable<string> v) where T : HelmLintSettings => o.Modify(b => b.RemoveCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmLintSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Values))]
    public static T ClearValues<T>(this T o) where T : HelmLintSettings => o.Modify(b => b.ClearCollection(() => o.Values));
    #endregion
    #region Path
    /// <inheritdoc cref="HelmLintSettings.Path"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Path))]
    public static T SetPath<T>(this T o, string v) where T : HelmLintSettings => o.Modify(b => b.Set(() => o.Path, v));
    /// <inheritdoc cref="HelmLintSettings.Path"/>
    [Pure] [Builder(Type = typeof(HelmLintSettings), Property = nameof(HelmLintSettings.Path))]
    public static T ResetPath<T>(this T o) where T : HelmLintSettings => o.Modify(b => b.Remove(() => o.Path));
    #endregion
}
#endregion
#region HelmListSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmListSettingsExtensions
{
    #region All
    /// <inheritdoc cref="HelmListSettings.All"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.All))]
    public static T SetAll<T>(this T o, bool? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.All, v));
    /// <inheritdoc cref="HelmListSettings.All"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.All))]
    public static T ResetAll<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.All));
    /// <inheritdoc cref="HelmListSettings.All"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.All))]
    public static T EnableAll<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.All, true));
    /// <inheritdoc cref="HelmListSettings.All"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.All))]
    public static T DisableAll<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.All, false));
    /// <inheritdoc cref="HelmListSettings.All"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.All))]
    public static T ToggleAll<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.All, !o.All));
    #endregion
    #region ChartName
    /// <inheritdoc cref="HelmListSettings.ChartName"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.ChartName))]
    public static T SetChartName<T>(this T o, bool? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.ChartName, v));
    /// <inheritdoc cref="HelmListSettings.ChartName"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.ChartName))]
    public static T ResetChartName<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.ChartName));
    /// <inheritdoc cref="HelmListSettings.ChartName"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.ChartName))]
    public static T EnableChartName<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.ChartName, true));
    /// <inheritdoc cref="HelmListSettings.ChartName"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.ChartName))]
    public static T DisableChartName<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.ChartName, false));
    /// <inheritdoc cref="HelmListSettings.ChartName"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.ChartName))]
    public static T ToggleChartName<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.ChartName, !o.ChartName));
    #endregion
    #region ColWidth
    /// <inheritdoc cref="HelmListSettings.ColWidth"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.ColWidth))]
    public static T SetColWidth<T>(this T o, uint? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.ColWidth, v));
    /// <inheritdoc cref="HelmListSettings.ColWidth"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.ColWidth))]
    public static T ResetColWidth<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.ColWidth));
    #endregion
    #region Date
    /// <inheritdoc cref="HelmListSettings.Date"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Date))]
    public static T SetDate<T>(this T o, bool? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Date, v));
    /// <inheritdoc cref="HelmListSettings.Date"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Date))]
    public static T ResetDate<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Date));
    /// <inheritdoc cref="HelmListSettings.Date"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Date))]
    public static T EnableDate<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Date, true));
    /// <inheritdoc cref="HelmListSettings.Date"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Date))]
    public static T DisableDate<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Date, false));
    /// <inheritdoc cref="HelmListSettings.Date"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Date))]
    public static T ToggleDate<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Date, !o.Date));
    #endregion
    #region Deleted
    /// <inheritdoc cref="HelmListSettings.Deleted"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deleted))]
    public static T SetDeleted<T>(this T o, bool? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Deleted, v));
    /// <inheritdoc cref="HelmListSettings.Deleted"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deleted))]
    public static T ResetDeleted<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Deleted));
    /// <inheritdoc cref="HelmListSettings.Deleted"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deleted))]
    public static T EnableDeleted<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Deleted, true));
    /// <inheritdoc cref="HelmListSettings.Deleted"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deleted))]
    public static T DisableDeleted<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Deleted, false));
    /// <inheritdoc cref="HelmListSettings.Deleted"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deleted))]
    public static T ToggleDeleted<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Deleted, !o.Deleted));
    #endregion
    #region Deleting
    /// <inheritdoc cref="HelmListSettings.Deleting"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deleting))]
    public static T SetDeleting<T>(this T o, bool? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Deleting, v));
    /// <inheritdoc cref="HelmListSettings.Deleting"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deleting))]
    public static T ResetDeleting<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Deleting));
    /// <inheritdoc cref="HelmListSettings.Deleting"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deleting))]
    public static T EnableDeleting<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Deleting, true));
    /// <inheritdoc cref="HelmListSettings.Deleting"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deleting))]
    public static T DisableDeleting<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Deleting, false));
    /// <inheritdoc cref="HelmListSettings.Deleting"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deleting))]
    public static T ToggleDeleting<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Deleting, !o.Deleting));
    #endregion
    #region Deployed
    /// <inheritdoc cref="HelmListSettings.Deployed"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deployed))]
    public static T SetDeployed<T>(this T o, bool? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Deployed, v));
    /// <inheritdoc cref="HelmListSettings.Deployed"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deployed))]
    public static T ResetDeployed<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Deployed));
    /// <inheritdoc cref="HelmListSettings.Deployed"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deployed))]
    public static T EnableDeployed<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Deployed, true));
    /// <inheritdoc cref="HelmListSettings.Deployed"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deployed))]
    public static T DisableDeployed<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Deployed, false));
    /// <inheritdoc cref="HelmListSettings.Deployed"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Deployed))]
    public static T ToggleDeployed<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Deployed, !o.Deployed));
    #endregion
    #region Failed
    /// <inheritdoc cref="HelmListSettings.Failed"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Failed))]
    public static T SetFailed<T>(this T o, bool? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Failed, v));
    /// <inheritdoc cref="HelmListSettings.Failed"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Failed))]
    public static T ResetFailed<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Failed));
    /// <inheritdoc cref="HelmListSettings.Failed"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Failed))]
    public static T EnableFailed<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Failed, true));
    /// <inheritdoc cref="HelmListSettings.Failed"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Failed))]
    public static T DisableFailed<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Failed, false));
    /// <inheritdoc cref="HelmListSettings.Failed"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Failed))]
    public static T ToggleFailed<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Failed, !o.Failed));
    #endregion
    #region Max
    /// <inheritdoc cref="HelmListSettings.Max"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Max))]
    public static T SetMax<T>(this T o, long? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Max, v));
    /// <inheritdoc cref="HelmListSettings.Max"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Max))]
    public static T ResetMax<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Max));
    #endregion
    #region Namespace
    /// <inheritdoc cref="HelmListSettings.Namespace"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Namespace))]
    public static T SetNamespace<T>(this T o, string v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Namespace, v));
    /// <inheritdoc cref="HelmListSettings.Namespace"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Namespace))]
    public static T ResetNamespace<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Namespace));
    #endregion
    #region Offset
    /// <inheritdoc cref="HelmListSettings.Offset"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Offset))]
    public static T SetOffset<T>(this T o, string v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Offset, v));
    /// <inheritdoc cref="HelmListSettings.Offset"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Offset))]
    public static T ResetOffset<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Offset));
    #endregion
    #region Output
    /// <inheritdoc cref="HelmListSettings.Output"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Output))]
    public static T SetOutput<T>(this T o, HelmOutputFormat v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="HelmListSettings.Output"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region Pending
    /// <inheritdoc cref="HelmListSettings.Pending"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Pending))]
    public static T SetPending<T>(this T o, bool? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Pending, v));
    /// <inheritdoc cref="HelmListSettings.Pending"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Pending))]
    public static T ResetPending<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Pending));
    /// <inheritdoc cref="HelmListSettings.Pending"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Pending))]
    public static T EnablePending<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Pending, true));
    /// <inheritdoc cref="HelmListSettings.Pending"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Pending))]
    public static T DisablePending<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Pending, false));
    /// <inheritdoc cref="HelmListSettings.Pending"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Pending))]
    public static T TogglePending<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Pending, !o.Pending));
    #endregion
    #region Reverse
    /// <inheritdoc cref="HelmListSettings.Reverse"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Reverse))]
    public static T SetReverse<T>(this T o, bool? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Reverse, v));
    /// <inheritdoc cref="HelmListSettings.Reverse"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Reverse))]
    public static T ResetReverse<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Reverse));
    /// <inheritdoc cref="HelmListSettings.Reverse"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Reverse))]
    public static T EnableReverse<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Reverse, true));
    /// <inheritdoc cref="HelmListSettings.Reverse"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Reverse))]
    public static T DisableReverse<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Reverse, false));
    /// <inheritdoc cref="HelmListSettings.Reverse"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Reverse))]
    public static T ToggleReverse<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Reverse, !o.Reverse));
    #endregion
    #region Short
    /// <inheritdoc cref="HelmListSettings.Short"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Short))]
    public static T SetShort<T>(this T o, bool? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Short, v));
    /// <inheritdoc cref="HelmListSettings.Short"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Short))]
    public static T ResetShort<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Short));
    /// <inheritdoc cref="HelmListSettings.Short"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Short))]
    public static T EnableShort<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Short, true));
    /// <inheritdoc cref="HelmListSettings.Short"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Short))]
    public static T DisableShort<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Short, false));
    /// <inheritdoc cref="HelmListSettings.Short"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Short))]
    public static T ToggleShort<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Short, !o.Short));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmListSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmListSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmListSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmListSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmListSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmListSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmListSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmListSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmListSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmListSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmListSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmListSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmListSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmListSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmListSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmListSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmListSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmListSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region Filter
    /// <inheritdoc cref="HelmListSettings.Filter"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Filter))]
    public static T SetFilter<T>(this T o, string v) where T : HelmListSettings => o.Modify(b => b.Set(() => o.Filter, v));
    /// <inheritdoc cref="HelmListSettings.Filter"/>
    [Pure] [Builder(Type = typeof(HelmListSettings), Property = nameof(HelmListSettings.Filter))]
    public static T ResetFilter<T>(this T o) where T : HelmListSettings => o.Modify(b => b.Remove(() => o.Filter));
    #endregion
}
#endregion
#region HelmPackageSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmPackageSettingsExtensions
{
    #region AppVersion
    /// <inheritdoc cref="HelmPackageSettings.AppVersion"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.AppVersion))]
    public static T SetAppVersion<T>(this T o, string v) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.AppVersion, v));
    /// <inheritdoc cref="HelmPackageSettings.AppVersion"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.AppVersion))]
    public static T ResetAppVersion<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Remove(() => o.AppVersion));
    #endregion
    #region DependencyUpdate
    /// <inheritdoc cref="HelmPackageSettings.DependencyUpdate"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.DependencyUpdate))]
    public static T SetDependencyUpdate<T>(this T o, bool? v) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.DependencyUpdate, v));
    /// <inheritdoc cref="HelmPackageSettings.DependencyUpdate"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.DependencyUpdate))]
    public static T ResetDependencyUpdate<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Remove(() => o.DependencyUpdate));
    /// <inheritdoc cref="HelmPackageSettings.DependencyUpdate"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.DependencyUpdate))]
    public static T EnableDependencyUpdate<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.DependencyUpdate, true));
    /// <inheritdoc cref="HelmPackageSettings.DependencyUpdate"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.DependencyUpdate))]
    public static T DisableDependencyUpdate<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.DependencyUpdate, false));
    /// <inheritdoc cref="HelmPackageSettings.DependencyUpdate"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.DependencyUpdate))]
    public static T ToggleDependencyUpdate<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.DependencyUpdate, !o.DependencyUpdate));
    #endregion
    #region Destination
    /// <inheritdoc cref="HelmPackageSettings.Destination"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Destination))]
    public static T SetDestination<T>(this T o, string v) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.Destination, v));
    /// <inheritdoc cref="HelmPackageSettings.Destination"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Destination))]
    public static T ResetDestination<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Remove(() => o.Destination));
    #endregion
    #region Key
    /// <inheritdoc cref="HelmPackageSettings.Key"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Key))]
    public static T SetKey<T>(this T o, string v) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.Key, v));
    /// <inheritdoc cref="HelmPackageSettings.Key"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Key))]
    public static T ResetKey<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Remove(() => o.Key));
    #endregion
    #region Keyring
    /// <inheritdoc cref="HelmPackageSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Keyring))]
    public static T SetKeyring<T>(this T o, string v) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.Keyring, v));
    /// <inheritdoc cref="HelmPackageSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Keyring))]
    public static T ResetKeyring<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Remove(() => o.Keyring));
    #endregion
    #region Save
    /// <inheritdoc cref="HelmPackageSettings.Save"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Save))]
    public static T SetSave<T>(this T o, bool? v) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.Save, v));
    /// <inheritdoc cref="HelmPackageSettings.Save"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Save))]
    public static T ResetSave<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Remove(() => o.Save));
    /// <inheritdoc cref="HelmPackageSettings.Save"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Save))]
    public static T EnableSave<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.Save, true));
    /// <inheritdoc cref="HelmPackageSettings.Save"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Save))]
    public static T DisableSave<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.Save, false));
    /// <inheritdoc cref="HelmPackageSettings.Save"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Save))]
    public static T ToggleSave<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.Save, !o.Save));
    #endregion
    #region Sign
    /// <inheritdoc cref="HelmPackageSettings.Sign"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Sign))]
    public static T SetSign<T>(this T o, bool? v) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.Sign, v));
    /// <inheritdoc cref="HelmPackageSettings.Sign"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Sign))]
    public static T ResetSign<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Remove(() => o.Sign));
    /// <inheritdoc cref="HelmPackageSettings.Sign"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Sign))]
    public static T EnableSign<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.Sign, true));
    /// <inheritdoc cref="HelmPackageSettings.Sign"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Sign))]
    public static T DisableSign<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.Sign, false));
    /// <inheritdoc cref="HelmPackageSettings.Sign"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Sign))]
    public static T ToggleSign<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.Sign, !o.Sign));
    #endregion
    #region Version
    /// <inheritdoc cref="HelmPackageSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="HelmPackageSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region ChartPaths
    /// <inheritdoc cref="HelmPackageSettings.ChartPaths"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.ChartPaths))]
    public static T SetChartPaths<T>(this T o, params string[] v) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.ChartPaths, v));
    /// <inheritdoc cref="HelmPackageSettings.ChartPaths"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.ChartPaths))]
    public static T SetChartPaths<T>(this T o, IEnumerable<string> v) where T : HelmPackageSettings => o.Modify(b => b.Set(() => o.ChartPaths, v));
    /// <inheritdoc cref="HelmPackageSettings.ChartPaths"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.ChartPaths))]
    public static T AddChartPaths<T>(this T o, params string[] v) where T : HelmPackageSettings => o.Modify(b => b.AddCollection(() => o.ChartPaths, v));
    /// <inheritdoc cref="HelmPackageSettings.ChartPaths"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.ChartPaths))]
    public static T AddChartPaths<T>(this T o, IEnumerable<string> v) where T : HelmPackageSettings => o.Modify(b => b.AddCollection(() => o.ChartPaths, v));
    /// <inheritdoc cref="HelmPackageSettings.ChartPaths"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.ChartPaths))]
    public static T RemoveChartPaths<T>(this T o, params string[] v) where T : HelmPackageSettings => o.Modify(b => b.RemoveCollection(() => o.ChartPaths, v));
    /// <inheritdoc cref="HelmPackageSettings.ChartPaths"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.ChartPaths))]
    public static T RemoveChartPaths<T>(this T o, IEnumerable<string> v) where T : HelmPackageSettings => o.Modify(b => b.RemoveCollection(() => o.ChartPaths, v));
    /// <inheritdoc cref="HelmPackageSettings.ChartPaths"/>
    [Pure] [Builder(Type = typeof(HelmPackageSettings), Property = nameof(HelmPackageSettings.ChartPaths))]
    public static T ClearChartPaths<T>(this T o) where T : HelmPackageSettings => o.Modify(b => b.ClearCollection(() => o.ChartPaths));
    #endregion
}
#endregion
#region HelmPluginInstallSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmPluginInstallSettingsExtensions
{
    #region Version
    /// <inheritdoc cref="HelmPluginInstallSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmPluginInstallSettings), Property = nameof(HelmPluginInstallSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : HelmPluginInstallSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="HelmPluginInstallSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmPluginInstallSettings), Property = nameof(HelmPluginInstallSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : HelmPluginInstallSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Options
    /// <inheritdoc cref="HelmPluginInstallSettings.Options"/>
    [Pure] [Builder(Type = typeof(HelmPluginInstallSettings), Property = nameof(HelmPluginInstallSettings.Options))]
    public static T SetOptions<T>(this T o, string v) where T : HelmPluginInstallSettings => o.Modify(b => b.Set(() => o.Options, v));
    /// <inheritdoc cref="HelmPluginInstallSettings.Options"/>
    [Pure] [Builder(Type = typeof(HelmPluginInstallSettings), Property = nameof(HelmPluginInstallSettings.Options))]
    public static T ResetOptions<T>(this T o) where T : HelmPluginInstallSettings => o.Modify(b => b.Remove(() => o.Options));
    #endregion
    #region Paths
    /// <inheritdoc cref="HelmPluginInstallSettings.Paths"/>
    [Pure] [Builder(Type = typeof(HelmPluginInstallSettings), Property = nameof(HelmPluginInstallSettings.Paths))]
    public static T SetPaths<T>(this T o, params string[] v) where T : HelmPluginInstallSettings => o.Modify(b => b.Set(() => o.Paths, v));
    /// <inheritdoc cref="HelmPluginInstallSettings.Paths"/>
    [Pure] [Builder(Type = typeof(HelmPluginInstallSettings), Property = nameof(HelmPluginInstallSettings.Paths))]
    public static T SetPaths<T>(this T o, IEnumerable<string> v) where T : HelmPluginInstallSettings => o.Modify(b => b.Set(() => o.Paths, v));
    /// <inheritdoc cref="HelmPluginInstallSettings.Paths"/>
    [Pure] [Builder(Type = typeof(HelmPluginInstallSettings), Property = nameof(HelmPluginInstallSettings.Paths))]
    public static T AddPaths<T>(this T o, params string[] v) where T : HelmPluginInstallSettings => o.Modify(b => b.AddCollection(() => o.Paths, v));
    /// <inheritdoc cref="HelmPluginInstallSettings.Paths"/>
    [Pure] [Builder(Type = typeof(HelmPluginInstallSettings), Property = nameof(HelmPluginInstallSettings.Paths))]
    public static T AddPaths<T>(this T o, IEnumerable<string> v) where T : HelmPluginInstallSettings => o.Modify(b => b.AddCollection(() => o.Paths, v));
    /// <inheritdoc cref="HelmPluginInstallSettings.Paths"/>
    [Pure] [Builder(Type = typeof(HelmPluginInstallSettings), Property = nameof(HelmPluginInstallSettings.Paths))]
    public static T RemovePaths<T>(this T o, params string[] v) where T : HelmPluginInstallSettings => o.Modify(b => b.RemoveCollection(() => o.Paths, v));
    /// <inheritdoc cref="HelmPluginInstallSettings.Paths"/>
    [Pure] [Builder(Type = typeof(HelmPluginInstallSettings), Property = nameof(HelmPluginInstallSettings.Paths))]
    public static T RemovePaths<T>(this T o, IEnumerable<string> v) where T : HelmPluginInstallSettings => o.Modify(b => b.RemoveCollection(() => o.Paths, v));
    /// <inheritdoc cref="HelmPluginInstallSettings.Paths"/>
    [Pure] [Builder(Type = typeof(HelmPluginInstallSettings), Property = nameof(HelmPluginInstallSettings.Paths))]
    public static T ClearPaths<T>(this T o) where T : HelmPluginInstallSettings => o.Modify(b => b.ClearCollection(() => o.Paths));
    #endregion
}
#endregion
#region HelmPluginListSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmPluginListSettingsExtensions
{
}
#endregion
#region HelmPluginRemoveSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmPluginRemoveSettingsExtensions
{
    #region Plugins
    /// <inheritdoc cref="HelmPluginRemoveSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginRemoveSettings), Property = nameof(HelmPluginRemoveSettings.Plugins))]
    public static T SetPlugins<T>(this T o, params string[] v) where T : HelmPluginRemoveSettings => o.Modify(b => b.Set(() => o.Plugins, v));
    /// <inheritdoc cref="HelmPluginRemoveSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginRemoveSettings), Property = nameof(HelmPluginRemoveSettings.Plugins))]
    public static T SetPlugins<T>(this T o, IEnumerable<string> v) where T : HelmPluginRemoveSettings => o.Modify(b => b.Set(() => o.Plugins, v));
    /// <inheritdoc cref="HelmPluginRemoveSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginRemoveSettings), Property = nameof(HelmPluginRemoveSettings.Plugins))]
    public static T AddPlugins<T>(this T o, params string[] v) where T : HelmPluginRemoveSettings => o.Modify(b => b.AddCollection(() => o.Plugins, v));
    /// <inheritdoc cref="HelmPluginRemoveSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginRemoveSettings), Property = nameof(HelmPluginRemoveSettings.Plugins))]
    public static T AddPlugins<T>(this T o, IEnumerable<string> v) where T : HelmPluginRemoveSettings => o.Modify(b => b.AddCollection(() => o.Plugins, v));
    /// <inheritdoc cref="HelmPluginRemoveSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginRemoveSettings), Property = nameof(HelmPluginRemoveSettings.Plugins))]
    public static T RemovePlugins<T>(this T o, params string[] v) where T : HelmPluginRemoveSettings => o.Modify(b => b.RemoveCollection(() => o.Plugins, v));
    /// <inheritdoc cref="HelmPluginRemoveSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginRemoveSettings), Property = nameof(HelmPluginRemoveSettings.Plugins))]
    public static T RemovePlugins<T>(this T o, IEnumerable<string> v) where T : HelmPluginRemoveSettings => o.Modify(b => b.RemoveCollection(() => o.Plugins, v));
    /// <inheritdoc cref="HelmPluginRemoveSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginRemoveSettings), Property = nameof(HelmPluginRemoveSettings.Plugins))]
    public static T ClearPlugins<T>(this T o) where T : HelmPluginRemoveSettings => o.Modify(b => b.ClearCollection(() => o.Plugins));
    #endregion
}
#endregion
#region HelmPluginUpdateSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmPluginUpdateSettingsExtensions
{
    #region Plugins
    /// <inheritdoc cref="HelmPluginUpdateSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginUpdateSettings), Property = nameof(HelmPluginUpdateSettings.Plugins))]
    public static T SetPlugins<T>(this T o, params string[] v) where T : HelmPluginUpdateSettings => o.Modify(b => b.Set(() => o.Plugins, v));
    /// <inheritdoc cref="HelmPluginUpdateSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginUpdateSettings), Property = nameof(HelmPluginUpdateSettings.Plugins))]
    public static T SetPlugins<T>(this T o, IEnumerable<string> v) where T : HelmPluginUpdateSettings => o.Modify(b => b.Set(() => o.Plugins, v));
    /// <inheritdoc cref="HelmPluginUpdateSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginUpdateSettings), Property = nameof(HelmPluginUpdateSettings.Plugins))]
    public static T AddPlugins<T>(this T o, params string[] v) where T : HelmPluginUpdateSettings => o.Modify(b => b.AddCollection(() => o.Plugins, v));
    /// <inheritdoc cref="HelmPluginUpdateSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginUpdateSettings), Property = nameof(HelmPluginUpdateSettings.Plugins))]
    public static T AddPlugins<T>(this T o, IEnumerable<string> v) where T : HelmPluginUpdateSettings => o.Modify(b => b.AddCollection(() => o.Plugins, v));
    /// <inheritdoc cref="HelmPluginUpdateSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginUpdateSettings), Property = nameof(HelmPluginUpdateSettings.Plugins))]
    public static T RemovePlugins<T>(this T o, params string[] v) where T : HelmPluginUpdateSettings => o.Modify(b => b.RemoveCollection(() => o.Plugins, v));
    /// <inheritdoc cref="HelmPluginUpdateSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginUpdateSettings), Property = nameof(HelmPluginUpdateSettings.Plugins))]
    public static T RemovePlugins<T>(this T o, IEnumerable<string> v) where T : HelmPluginUpdateSettings => o.Modify(b => b.RemoveCollection(() => o.Plugins, v));
    /// <inheritdoc cref="HelmPluginUpdateSettings.Plugins"/>
    [Pure] [Builder(Type = typeof(HelmPluginUpdateSettings), Property = nameof(HelmPluginUpdateSettings.Plugins))]
    public static T ClearPlugins<T>(this T o) where T : HelmPluginUpdateSettings => o.Modify(b => b.ClearCollection(() => o.Plugins));
    #endregion
}
#endregion
#region HelmRepoAddSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmRepoAddSettingsExtensions
{
    #region CaFile
    /// <inheritdoc cref="HelmRepoAddSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.CaFile))]
    public static T SetCaFile<T>(this T o, string v) where T : HelmRepoAddSettings => o.Modify(b => b.Set(() => o.CaFile, v));
    /// <inheritdoc cref="HelmRepoAddSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.CaFile))]
    public static T ResetCaFile<T>(this T o) where T : HelmRepoAddSettings => o.Modify(b => b.Remove(() => o.CaFile));
    #endregion
    #region CertFile
    /// <inheritdoc cref="HelmRepoAddSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.CertFile))]
    public static T SetCertFile<T>(this T o, string v) where T : HelmRepoAddSettings => o.Modify(b => b.Set(() => o.CertFile, v));
    /// <inheritdoc cref="HelmRepoAddSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.CertFile))]
    public static T ResetCertFile<T>(this T o) where T : HelmRepoAddSettings => o.Modify(b => b.Remove(() => o.CertFile));
    #endregion
    #region KeyFile
    /// <inheritdoc cref="HelmRepoAddSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.KeyFile))]
    public static T SetKeyFile<T>(this T o, string v) where T : HelmRepoAddSettings => o.Modify(b => b.Set(() => o.KeyFile, v));
    /// <inheritdoc cref="HelmRepoAddSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.KeyFile))]
    public static T ResetKeyFile<T>(this T o) where T : HelmRepoAddSettings => o.Modify(b => b.Remove(() => o.KeyFile));
    #endregion
    #region NoUpdate
    /// <inheritdoc cref="HelmRepoAddSettings.NoUpdate"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.NoUpdate))]
    public static T SetNoUpdate<T>(this T o, bool? v) where T : HelmRepoAddSettings => o.Modify(b => b.Set(() => o.NoUpdate, v));
    /// <inheritdoc cref="HelmRepoAddSettings.NoUpdate"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.NoUpdate))]
    public static T ResetNoUpdate<T>(this T o) where T : HelmRepoAddSettings => o.Modify(b => b.Remove(() => o.NoUpdate));
    /// <inheritdoc cref="HelmRepoAddSettings.NoUpdate"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.NoUpdate))]
    public static T EnableNoUpdate<T>(this T o) where T : HelmRepoAddSettings => o.Modify(b => b.Set(() => o.NoUpdate, true));
    /// <inheritdoc cref="HelmRepoAddSettings.NoUpdate"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.NoUpdate))]
    public static T DisableNoUpdate<T>(this T o) where T : HelmRepoAddSettings => o.Modify(b => b.Set(() => o.NoUpdate, false));
    /// <inheritdoc cref="HelmRepoAddSettings.NoUpdate"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.NoUpdate))]
    public static T ToggleNoUpdate<T>(this T o) where T : HelmRepoAddSettings => o.Modify(b => b.Set(() => o.NoUpdate, !o.NoUpdate));
    #endregion
    #region Password
    /// <inheritdoc cref="HelmRepoAddSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : HelmRepoAddSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="HelmRepoAddSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : HelmRepoAddSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region Username
    /// <inheritdoc cref="HelmRepoAddSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : HelmRepoAddSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="HelmRepoAddSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : HelmRepoAddSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Name
    /// <inheritdoc cref="HelmRepoAddSettings.Name"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : HelmRepoAddSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="HelmRepoAddSettings.Name"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.Name))]
    public static T ResetName<T>(this T o) where T : HelmRepoAddSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Url
    /// <inheritdoc cref="HelmRepoAddSettings.Url"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.Url))]
    public static T SetUrl<T>(this T o, string v) where T : HelmRepoAddSettings => o.Modify(b => b.Set(() => o.Url, v));
    /// <inheritdoc cref="HelmRepoAddSettings.Url"/>
    [Pure] [Builder(Type = typeof(HelmRepoAddSettings), Property = nameof(HelmRepoAddSettings.Url))]
    public static T ResetUrl<T>(this T o) where T : HelmRepoAddSettings => o.Modify(b => b.Remove(() => o.Url));
    #endregion
}
#endregion
#region HelmRepoIndexSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmRepoIndexSettingsExtensions
{
    #region Merge
    /// <inheritdoc cref="HelmRepoIndexSettings.Merge"/>
    [Pure] [Builder(Type = typeof(HelmRepoIndexSettings), Property = nameof(HelmRepoIndexSettings.Merge))]
    public static T SetMerge<T>(this T o, string v) where T : HelmRepoIndexSettings => o.Modify(b => b.Set(() => o.Merge, v));
    /// <inheritdoc cref="HelmRepoIndexSettings.Merge"/>
    [Pure] [Builder(Type = typeof(HelmRepoIndexSettings), Property = nameof(HelmRepoIndexSettings.Merge))]
    public static T ResetMerge<T>(this T o) where T : HelmRepoIndexSettings => o.Modify(b => b.Remove(() => o.Merge));
    #endregion
    #region Url
    /// <inheritdoc cref="HelmRepoIndexSettings.Url"/>
    [Pure] [Builder(Type = typeof(HelmRepoIndexSettings), Property = nameof(HelmRepoIndexSettings.Url))]
    public static T SetUrl<T>(this T o, string v) where T : HelmRepoIndexSettings => o.Modify(b => b.Set(() => o.Url, v));
    /// <inheritdoc cref="HelmRepoIndexSettings.Url"/>
    [Pure] [Builder(Type = typeof(HelmRepoIndexSettings), Property = nameof(HelmRepoIndexSettings.Url))]
    public static T ResetUrl<T>(this T o) where T : HelmRepoIndexSettings => o.Modify(b => b.Remove(() => o.Url));
    #endregion
    #region Directory
    /// <inheritdoc cref="HelmRepoIndexSettings.Directory"/>
    [Pure] [Builder(Type = typeof(HelmRepoIndexSettings), Property = nameof(HelmRepoIndexSettings.Directory))]
    public static T SetDirectory<T>(this T o, string v) where T : HelmRepoIndexSettings => o.Modify(b => b.Set(() => o.Directory, v));
    /// <inheritdoc cref="HelmRepoIndexSettings.Directory"/>
    [Pure] [Builder(Type = typeof(HelmRepoIndexSettings), Property = nameof(HelmRepoIndexSettings.Directory))]
    public static T ResetDirectory<T>(this T o) where T : HelmRepoIndexSettings => o.Modify(b => b.Remove(() => o.Directory));
    #endregion
}
#endregion
#region HelmRepoListSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmRepoListSettingsExtensions
{
}
#endregion
#region HelmRepoRemoveSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmRepoRemoveSettingsExtensions
{
    #region Name
    /// <inheritdoc cref="HelmRepoRemoveSettings.Name"/>
    [Pure] [Builder(Type = typeof(HelmRepoRemoveSettings), Property = nameof(HelmRepoRemoveSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : HelmRepoRemoveSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="HelmRepoRemoveSettings.Name"/>
    [Pure] [Builder(Type = typeof(HelmRepoRemoveSettings), Property = nameof(HelmRepoRemoveSettings.Name))]
    public static T ResetName<T>(this T o) where T : HelmRepoRemoveSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
}
#endregion
#region HelmRepoUpdateSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmRepoUpdateSettingsExtensions
{
    #region Strict
    /// <inheritdoc cref="HelmRepoUpdateSettings.Strict"/>
    [Pure] [Builder(Type = typeof(HelmRepoUpdateSettings), Property = nameof(HelmRepoUpdateSettings.Strict))]
    public static T SetStrict<T>(this T o, bool? v) where T : HelmRepoUpdateSettings => o.Modify(b => b.Set(() => o.Strict, v));
    /// <inheritdoc cref="HelmRepoUpdateSettings.Strict"/>
    [Pure] [Builder(Type = typeof(HelmRepoUpdateSettings), Property = nameof(HelmRepoUpdateSettings.Strict))]
    public static T ResetStrict<T>(this T o) where T : HelmRepoUpdateSettings => o.Modify(b => b.Remove(() => o.Strict));
    /// <inheritdoc cref="HelmRepoUpdateSettings.Strict"/>
    [Pure] [Builder(Type = typeof(HelmRepoUpdateSettings), Property = nameof(HelmRepoUpdateSettings.Strict))]
    public static T EnableStrict<T>(this T o) where T : HelmRepoUpdateSettings => o.Modify(b => b.Set(() => o.Strict, true));
    /// <inheritdoc cref="HelmRepoUpdateSettings.Strict"/>
    [Pure] [Builder(Type = typeof(HelmRepoUpdateSettings), Property = nameof(HelmRepoUpdateSettings.Strict))]
    public static T DisableStrict<T>(this T o) where T : HelmRepoUpdateSettings => o.Modify(b => b.Set(() => o.Strict, false));
    /// <inheritdoc cref="HelmRepoUpdateSettings.Strict"/>
    [Pure] [Builder(Type = typeof(HelmRepoUpdateSettings), Property = nameof(HelmRepoUpdateSettings.Strict))]
    public static T ToggleStrict<T>(this T o) where T : HelmRepoUpdateSettings => o.Modify(b => b.Set(() => o.Strict, !o.Strict));
    #endregion
}
#endregion
#region HelmResetSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmResetSettingsExtensions
{
    #region Force
    /// <inheritdoc cref="HelmResetSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="HelmResetSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.Force))]
    public static T ResetForce<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="HelmResetSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.Force))]
    public static T EnableForce<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="HelmResetSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.Force))]
    public static T DisableForce<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="HelmResetSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region RemoveHelmHome
    /// <inheritdoc cref="HelmResetSettings.RemoveHelmHome"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.RemoveHelmHome))]
    public static T SetRemoveHelmHome<T>(this T o, bool? v) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.RemoveHelmHome, v));
    /// <inheritdoc cref="HelmResetSettings.RemoveHelmHome"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.RemoveHelmHome))]
    public static T ResetRemoveHelmHome<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Remove(() => o.RemoveHelmHome));
    /// <inheritdoc cref="HelmResetSettings.RemoveHelmHome"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.RemoveHelmHome))]
    public static T EnableRemoveHelmHome<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.RemoveHelmHome, true));
    /// <inheritdoc cref="HelmResetSettings.RemoveHelmHome"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.RemoveHelmHome))]
    public static T DisableRemoveHelmHome<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.RemoveHelmHome, false));
    /// <inheritdoc cref="HelmResetSettings.RemoveHelmHome"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.RemoveHelmHome))]
    public static T ToggleRemoveHelmHome<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.RemoveHelmHome, !o.RemoveHelmHome));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmResetSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmResetSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmResetSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmResetSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmResetSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmResetSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmResetSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmResetSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmResetSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmResetSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmResetSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmResetSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmResetSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmResetSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmResetSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmResetSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmResetSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmResetSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmResetSettings), Property = nameof(HelmResetSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmResetSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
}
#endregion
#region HelmRollbackSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmRollbackSettingsExtensions
{
    #region Description
    /// <inheritdoc cref="HelmRollbackSettings.Description"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Description))]
    public static T SetDescription<T>(this T o, string v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Description, v));
    /// <inheritdoc cref="HelmRollbackSettings.Description"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Description))]
    public static T ResetDescription<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.Description));
    #endregion
    #region DryRun
    /// <inheritdoc cref="HelmRollbackSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.DryRun))]
    public static T SetDryRun<T>(this T o, bool? v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.DryRun, v));
    /// <inheritdoc cref="HelmRollbackSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.DryRun))]
    public static T ResetDryRun<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.DryRun));
    /// <inheritdoc cref="HelmRollbackSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.DryRun))]
    public static T EnableDryRun<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.DryRun, true));
    /// <inheritdoc cref="HelmRollbackSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.DryRun))]
    public static T DisableDryRun<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.DryRun, false));
    /// <inheritdoc cref="HelmRollbackSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.DryRun))]
    public static T ToggleDryRun<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.DryRun, !o.DryRun));
    #endregion
    #region Force
    /// <inheritdoc cref="HelmRollbackSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="HelmRollbackSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Force))]
    public static T ResetForce<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="HelmRollbackSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Force))]
    public static T EnableForce<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="HelmRollbackSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Force))]
    public static T DisableForce<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="HelmRollbackSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region NoHooks
    /// <inheritdoc cref="HelmRollbackSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.NoHooks))]
    public static T SetNoHooks<T>(this T o, bool? v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.NoHooks, v));
    /// <inheritdoc cref="HelmRollbackSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.NoHooks))]
    public static T ResetNoHooks<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.NoHooks));
    /// <inheritdoc cref="HelmRollbackSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.NoHooks))]
    public static T EnableNoHooks<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.NoHooks, true));
    /// <inheritdoc cref="HelmRollbackSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.NoHooks))]
    public static T DisableNoHooks<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.NoHooks, false));
    /// <inheritdoc cref="HelmRollbackSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.NoHooks))]
    public static T ToggleNoHooks<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.NoHooks, !o.NoHooks));
    #endregion
    #region RecreatePods
    /// <inheritdoc cref="HelmRollbackSettings.RecreatePods"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.RecreatePods))]
    public static T SetRecreatePods<T>(this T o, bool? v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.RecreatePods, v));
    /// <inheritdoc cref="HelmRollbackSettings.RecreatePods"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.RecreatePods))]
    public static T ResetRecreatePods<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.RecreatePods));
    /// <inheritdoc cref="HelmRollbackSettings.RecreatePods"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.RecreatePods))]
    public static T EnableRecreatePods<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.RecreatePods, true));
    /// <inheritdoc cref="HelmRollbackSettings.RecreatePods"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.RecreatePods))]
    public static T DisableRecreatePods<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.RecreatePods, false));
    /// <inheritdoc cref="HelmRollbackSettings.RecreatePods"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.RecreatePods))]
    public static T ToggleRecreatePods<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.RecreatePods, !o.RecreatePods));
    #endregion
    #region Timeout
    /// <inheritdoc cref="HelmRollbackSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Timeout))]
    public static T SetTimeout<T>(this T o, long? v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="HelmRollbackSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmRollbackSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmRollbackSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmRollbackSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmRollbackSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmRollbackSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmRollbackSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmRollbackSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmRollbackSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmRollbackSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmRollbackSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmRollbackSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmRollbackSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmRollbackSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmRollbackSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmRollbackSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmRollbackSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmRollbackSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmRollbackSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region Wait
    /// <inheritdoc cref="HelmRollbackSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Wait))]
    public static T SetWait<T>(this T o, bool? v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Wait, v));
    /// <inheritdoc cref="HelmRollbackSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Wait))]
    public static T ResetWait<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.Wait));
    /// <inheritdoc cref="HelmRollbackSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Wait))]
    public static T EnableWait<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Wait, true));
    /// <inheritdoc cref="HelmRollbackSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Wait))]
    public static T DisableWait<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Wait, false));
    /// <inheritdoc cref="HelmRollbackSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Wait))]
    public static T ToggleWait<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Wait, !o.Wait));
    #endregion
    #region Release
    /// <inheritdoc cref="HelmRollbackSettings.Release"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Release))]
    public static T SetRelease<T>(this T o, string v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Release, v));
    /// <inheritdoc cref="HelmRollbackSettings.Release"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Release))]
    public static T ResetRelease<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.Release));
    #endregion
    #region Revision
    /// <inheritdoc cref="HelmRollbackSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Revision))]
    public static T SetRevision<T>(this T o, string v) where T : HelmRollbackSettings => o.Modify(b => b.Set(() => o.Revision, v));
    /// <inheritdoc cref="HelmRollbackSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmRollbackSettings), Property = nameof(HelmRollbackSettings.Revision))]
    public static T ResetRevision<T>(this T o) where T : HelmRollbackSettings => o.Modify(b => b.Remove(() => o.Revision));
    #endregion
}
#endregion
#region HelmSearchSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmSearchSettingsExtensions
{
    #region ColWidth
    /// <inheritdoc cref="HelmSearchSettings.ColWidth"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.ColWidth))]
    public static T SetColWidth<T>(this T o, uint? v) where T : HelmSearchSettings => o.Modify(b => b.Set(() => o.ColWidth, v));
    /// <inheritdoc cref="HelmSearchSettings.ColWidth"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.ColWidth))]
    public static T ResetColWidth<T>(this T o) where T : HelmSearchSettings => o.Modify(b => b.Remove(() => o.ColWidth));
    #endregion
    #region Regexp
    /// <inheritdoc cref="HelmSearchSettings.Regexp"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Regexp))]
    public static T SetRegexp<T>(this T o, bool? v) where T : HelmSearchSettings => o.Modify(b => b.Set(() => o.Regexp, v));
    /// <inheritdoc cref="HelmSearchSettings.Regexp"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Regexp))]
    public static T ResetRegexp<T>(this T o) where T : HelmSearchSettings => o.Modify(b => b.Remove(() => o.Regexp));
    /// <inheritdoc cref="HelmSearchSettings.Regexp"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Regexp))]
    public static T EnableRegexp<T>(this T o) where T : HelmSearchSettings => o.Modify(b => b.Set(() => o.Regexp, true));
    /// <inheritdoc cref="HelmSearchSettings.Regexp"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Regexp))]
    public static T DisableRegexp<T>(this T o) where T : HelmSearchSettings => o.Modify(b => b.Set(() => o.Regexp, false));
    /// <inheritdoc cref="HelmSearchSettings.Regexp"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Regexp))]
    public static T ToggleRegexp<T>(this T o) where T : HelmSearchSettings => o.Modify(b => b.Set(() => o.Regexp, !o.Regexp));
    #endregion
    #region Version
    /// <inheritdoc cref="HelmSearchSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : HelmSearchSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="HelmSearchSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : HelmSearchSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Versions
    /// <inheritdoc cref="HelmSearchSettings.Versions"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Versions))]
    public static T SetVersions<T>(this T o, bool? v) where T : HelmSearchSettings => o.Modify(b => b.Set(() => o.Versions, v));
    /// <inheritdoc cref="HelmSearchSettings.Versions"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Versions))]
    public static T ResetVersions<T>(this T o) where T : HelmSearchSettings => o.Modify(b => b.Remove(() => o.Versions));
    /// <inheritdoc cref="HelmSearchSettings.Versions"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Versions))]
    public static T EnableVersions<T>(this T o) where T : HelmSearchSettings => o.Modify(b => b.Set(() => o.Versions, true));
    /// <inheritdoc cref="HelmSearchSettings.Versions"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Versions))]
    public static T DisableVersions<T>(this T o) where T : HelmSearchSettings => o.Modify(b => b.Set(() => o.Versions, false));
    /// <inheritdoc cref="HelmSearchSettings.Versions"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Versions))]
    public static T ToggleVersions<T>(this T o) where T : HelmSearchSettings => o.Modify(b => b.Set(() => o.Versions, !o.Versions));
    #endregion
    #region Keyword
    /// <inheritdoc cref="HelmSearchSettings.Keyword"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Keyword))]
    public static T SetKeyword<T>(this T o, string v) where T : HelmSearchSettings => o.Modify(b => b.Set(() => o.Keyword, v));
    /// <inheritdoc cref="HelmSearchSettings.Keyword"/>
    [Pure] [Builder(Type = typeof(HelmSearchSettings), Property = nameof(HelmSearchSettings.Keyword))]
    public static T ResetKeyword<T>(this T o) where T : HelmSearchSettings => o.Modify(b => b.Remove(() => o.Keyword));
    #endregion
}
#endregion
#region HelmServeSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmServeSettingsExtensions
{
    #region Address
    /// <inheritdoc cref="HelmServeSettings.Address"/>
    [Pure] [Builder(Type = typeof(HelmServeSettings), Property = nameof(HelmServeSettings.Address))]
    public static T SetAddress<T>(this T o, string v) where T : HelmServeSettings => o.Modify(b => b.Set(() => o.Address, v));
    /// <inheritdoc cref="HelmServeSettings.Address"/>
    [Pure] [Builder(Type = typeof(HelmServeSettings), Property = nameof(HelmServeSettings.Address))]
    public static T ResetAddress<T>(this T o) where T : HelmServeSettings => o.Modify(b => b.Remove(() => o.Address));
    #endregion
    #region RepoPath
    /// <inheritdoc cref="HelmServeSettings.RepoPath"/>
    [Pure] [Builder(Type = typeof(HelmServeSettings), Property = nameof(HelmServeSettings.RepoPath))]
    public static T SetRepoPath<T>(this T o, string v) where T : HelmServeSettings => o.Modify(b => b.Set(() => o.RepoPath, v));
    /// <inheritdoc cref="HelmServeSettings.RepoPath"/>
    [Pure] [Builder(Type = typeof(HelmServeSettings), Property = nameof(HelmServeSettings.RepoPath))]
    public static T ResetRepoPath<T>(this T o) where T : HelmServeSettings => o.Modify(b => b.Remove(() => o.RepoPath));
    #endregion
    #region Url
    /// <inheritdoc cref="HelmServeSettings.Url"/>
    [Pure] [Builder(Type = typeof(HelmServeSettings), Property = nameof(HelmServeSettings.Url))]
    public static T SetUrl<T>(this T o, string v) where T : HelmServeSettings => o.Modify(b => b.Set(() => o.Url, v));
    /// <inheritdoc cref="HelmServeSettings.Url"/>
    [Pure] [Builder(Type = typeof(HelmServeSettings), Property = nameof(HelmServeSettings.Url))]
    public static T ResetUrl<T>(this T o) where T : HelmServeSettings => o.Modify(b => b.Remove(() => o.Url));
    #endregion
}
#endregion
#region HelmStatusSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmStatusSettingsExtensions
{
    #region Output
    /// <inheritdoc cref="HelmStatusSettings.Output"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.Output))]
    public static T SetOutput<T>(this T o, HelmOutputFormat v) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="HelmStatusSettings.Output"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region Revision
    /// <inheritdoc cref="HelmStatusSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.Revision))]
    public static T SetRevision<T>(this T o, int? v) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.Revision, v));
    /// <inheritdoc cref="HelmStatusSettings.Revision"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.Revision))]
    public static T ResetRevision<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Remove(() => o.Revision));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmStatusSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmStatusSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmStatusSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmStatusSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmStatusSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmStatusSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmStatusSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmStatusSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmStatusSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmStatusSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmStatusSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmStatusSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmStatusSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmStatusSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmStatusSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmStatusSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmStatusSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmStatusSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region ReleaseName
    /// <inheritdoc cref="HelmStatusSettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.ReleaseName))]
    public static T SetReleaseName<T>(this T o, string v) where T : HelmStatusSettings => o.Modify(b => b.Set(() => o.ReleaseName, v));
    /// <inheritdoc cref="HelmStatusSettings.ReleaseName"/>
    [Pure] [Builder(Type = typeof(HelmStatusSettings), Property = nameof(HelmStatusSettings.ReleaseName))]
    public static T ResetReleaseName<T>(this T o) where T : HelmStatusSettings => o.Modify(b => b.Remove(() => o.ReleaseName));
    #endregion
}
#endregion
#region HelmTemplateSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmTemplateSettingsExtensions
{
    #region Execute
    /// <inheritdoc cref="HelmTemplateSettings.Execute"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Execute))]
    public static T SetExecute<T>(this T o, IDictionary<string, object> v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.Execute, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmTemplateSettings.Execute"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Execute))]
    public static T SetExecute<T>(this T o, string k, object v) where T : HelmTemplateSettings => o.Modify(b => b.SetDictionary(() => o.Execute, k, v));
    /// <inheritdoc cref="HelmTemplateSettings.Execute"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Execute))]
    public static T AddExecute<T>(this T o, string k, object v) where T : HelmTemplateSettings => o.Modify(b => b.AddDictionary(() => o.Execute, k, v));
    /// <inheritdoc cref="HelmTemplateSettings.Execute"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Execute))]
    public static T RemoveExecute<T>(this T o, string k) where T : HelmTemplateSettings => o.Modify(b => b.RemoveDictionary(() => o.Execute, k));
    /// <inheritdoc cref="HelmTemplateSettings.Execute"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Execute))]
    public static T ClearExecute<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.ClearDictionary(() => o.Execute));
    #endregion
    #region IsUpgrade
    /// <inheritdoc cref="HelmTemplateSettings.IsUpgrade"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.IsUpgrade))]
    public static T SetIsUpgrade<T>(this T o, bool? v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.IsUpgrade, v));
    /// <inheritdoc cref="HelmTemplateSettings.IsUpgrade"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.IsUpgrade))]
    public static T ResetIsUpgrade<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Remove(() => o.IsUpgrade));
    /// <inheritdoc cref="HelmTemplateSettings.IsUpgrade"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.IsUpgrade))]
    public static T EnableIsUpgrade<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.IsUpgrade, true));
    /// <inheritdoc cref="HelmTemplateSettings.IsUpgrade"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.IsUpgrade))]
    public static T DisableIsUpgrade<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.IsUpgrade, false));
    /// <inheritdoc cref="HelmTemplateSettings.IsUpgrade"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.IsUpgrade))]
    public static T ToggleIsUpgrade<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.IsUpgrade, !o.IsUpgrade));
    #endregion
    #region KubeVersion
    /// <inheritdoc cref="HelmTemplateSettings.KubeVersion"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.KubeVersion))]
    public static T SetKubeVersion<T>(this T o, string v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.KubeVersion, v));
    /// <inheritdoc cref="HelmTemplateSettings.KubeVersion"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.KubeVersion))]
    public static T ResetKubeVersion<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Remove(() => o.KubeVersion));
    #endregion
    #region Name
    /// <inheritdoc cref="HelmTemplateSettings.Name"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="HelmTemplateSettings.Name"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Name))]
    public static T ResetName<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region NameTemplate
    /// <inheritdoc cref="HelmTemplateSettings.NameTemplate"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.NameTemplate))]
    public static T SetNameTemplate<T>(this T o, string v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.NameTemplate, v));
    /// <inheritdoc cref="HelmTemplateSettings.NameTemplate"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.NameTemplate))]
    public static T ResetNameTemplate<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Remove(() => o.NameTemplate));
    #endregion
    #region Namespace
    /// <inheritdoc cref="HelmTemplateSettings.Namespace"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Namespace))]
    public static T SetNamespace<T>(this T o, string v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.Namespace, v));
    /// <inheritdoc cref="HelmTemplateSettings.Namespace"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Namespace))]
    public static T ResetNamespace<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Remove(() => o.Namespace));
    #endregion
    #region Notes
    /// <inheritdoc cref="HelmTemplateSettings.Notes"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Notes))]
    public static T SetNotes<T>(this T o, bool? v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.Notes, v));
    /// <inheritdoc cref="HelmTemplateSettings.Notes"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Notes))]
    public static T ResetNotes<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Remove(() => o.Notes));
    /// <inheritdoc cref="HelmTemplateSettings.Notes"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Notes))]
    public static T EnableNotes<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.Notes, true));
    /// <inheritdoc cref="HelmTemplateSettings.Notes"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Notes))]
    public static T DisableNotes<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.Notes, false));
    /// <inheritdoc cref="HelmTemplateSettings.Notes"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Notes))]
    public static T ToggleNotes<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.Notes, !o.Notes));
    #endregion
    #region OutputDir
    /// <inheritdoc cref="HelmTemplateSettings.OutputDir"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.OutputDir))]
    public static T SetOutputDir<T>(this T o, string v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.OutputDir, v));
    /// <inheritdoc cref="HelmTemplateSettings.OutputDir"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.OutputDir))]
    public static T ResetOutputDir<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Remove(() => o.OutputDir));
    #endregion
    #region Set
    /// <inheritdoc cref="HelmTemplateSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Set))]
    public static T SetSet<T>(this T o, IDictionary<string, object> v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.Set, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmTemplateSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Set))]
    public static T SetSet<T>(this T o, string k, object v) where T : HelmTemplateSettings => o.Modify(b => b.SetDictionary(() => o.Set, k, v));
    /// <inheritdoc cref="HelmTemplateSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Set))]
    public static T AddSet<T>(this T o, string k, object v) where T : HelmTemplateSettings => o.Modify(b => b.AddDictionary(() => o.Set, k, v));
    /// <inheritdoc cref="HelmTemplateSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Set))]
    public static T RemoveSet<T>(this T o, string k) where T : HelmTemplateSettings => o.Modify(b => b.RemoveDictionary(() => o.Set, k));
    /// <inheritdoc cref="HelmTemplateSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Set))]
    public static T ClearSet<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.ClearDictionary(() => o.Set));
    #endregion
    #region SetFile
    /// <inheritdoc cref="HelmTemplateSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.SetFile))]
    public static T SetSetFile<T>(this T o, IDictionary<string, object> v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.SetFile, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmTemplateSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.SetFile))]
    public static T SetSetFile<T>(this T o, string k, object v) where T : HelmTemplateSettings => o.Modify(b => b.SetDictionary(() => o.SetFile, k, v));
    /// <inheritdoc cref="HelmTemplateSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.SetFile))]
    public static T AddSetFile<T>(this T o, string k, object v) where T : HelmTemplateSettings => o.Modify(b => b.AddDictionary(() => o.SetFile, k, v));
    /// <inheritdoc cref="HelmTemplateSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.SetFile))]
    public static T RemoveSetFile<T>(this T o, string k) where T : HelmTemplateSettings => o.Modify(b => b.RemoveDictionary(() => o.SetFile, k));
    /// <inheritdoc cref="HelmTemplateSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.SetFile))]
    public static T ClearSetFile<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.ClearDictionary(() => o.SetFile));
    #endregion
    #region SetString
    /// <inheritdoc cref="HelmTemplateSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.SetString))]
    public static T SetSetString<T>(this T o, IDictionary<string, object> v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.SetString, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmTemplateSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.SetString))]
    public static T SetSetString<T>(this T o, string k, object v) where T : HelmTemplateSettings => o.Modify(b => b.SetDictionary(() => o.SetString, k, v));
    /// <inheritdoc cref="HelmTemplateSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.SetString))]
    public static T AddSetString<T>(this T o, string k, object v) where T : HelmTemplateSettings => o.Modify(b => b.AddDictionary(() => o.SetString, k, v));
    /// <inheritdoc cref="HelmTemplateSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.SetString))]
    public static T RemoveSetString<T>(this T o, string k) where T : HelmTemplateSettings => o.Modify(b => b.RemoveDictionary(() => o.SetString, k));
    /// <inheritdoc cref="HelmTemplateSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.SetString))]
    public static T ClearSetString<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.ClearDictionary(() => o.SetString));
    #endregion
    #region Values
    /// <inheritdoc cref="HelmTemplateSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Values))]
    public static T SetValues<T>(this T o, params string[] v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.Values, v));
    /// <inheritdoc cref="HelmTemplateSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Values))]
    public static T SetValues<T>(this T o, IEnumerable<string> v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.Values, v));
    /// <inheritdoc cref="HelmTemplateSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Values))]
    public static T AddValues<T>(this T o, params string[] v) where T : HelmTemplateSettings => o.Modify(b => b.AddCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmTemplateSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Values))]
    public static T AddValues<T>(this T o, IEnumerable<string> v) where T : HelmTemplateSettings => o.Modify(b => b.AddCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmTemplateSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Values))]
    public static T RemoveValues<T>(this T o, params string[] v) where T : HelmTemplateSettings => o.Modify(b => b.RemoveCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmTemplateSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Values))]
    public static T RemoveValues<T>(this T o, IEnumerable<string> v) where T : HelmTemplateSettings => o.Modify(b => b.RemoveCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmTemplateSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Values))]
    public static T ClearValues<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.ClearCollection(() => o.Values));
    #endregion
    #region Chart
    /// <inheritdoc cref="HelmTemplateSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Chart))]
    public static T SetChart<T>(this T o, string v) where T : HelmTemplateSettings => o.Modify(b => b.Set(() => o.Chart, v));
    /// <inheritdoc cref="HelmTemplateSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmTemplateSettings), Property = nameof(HelmTemplateSettings.Chart))]
    public static T ResetChart<T>(this T o) where T : HelmTemplateSettings => o.Modify(b => b.Remove(() => o.Chart));
    #endregion
}
#endregion
#region HelmTestSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmTestSettingsExtensions
{
    #region Cleanup
    /// <inheritdoc cref="HelmTestSettings.Cleanup"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Cleanup))]
    public static T SetCleanup<T>(this T o, bool? v) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Cleanup, v));
    /// <inheritdoc cref="HelmTestSettings.Cleanup"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Cleanup))]
    public static T ResetCleanup<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Remove(() => o.Cleanup));
    /// <inheritdoc cref="HelmTestSettings.Cleanup"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Cleanup))]
    public static T EnableCleanup<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Cleanup, true));
    /// <inheritdoc cref="HelmTestSettings.Cleanup"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Cleanup))]
    public static T DisableCleanup<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Cleanup, false));
    /// <inheritdoc cref="HelmTestSettings.Cleanup"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Cleanup))]
    public static T ToggleCleanup<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Cleanup, !o.Cleanup));
    #endregion
    #region Parallel
    /// <inheritdoc cref="HelmTestSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Parallel))]
    public static T SetParallel<T>(this T o, bool? v) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Parallel, v));
    /// <inheritdoc cref="HelmTestSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Parallel))]
    public static T ResetParallel<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Remove(() => o.Parallel));
    /// <inheritdoc cref="HelmTestSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Parallel))]
    public static T EnableParallel<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Parallel, true));
    /// <inheritdoc cref="HelmTestSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Parallel))]
    public static T DisableParallel<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Parallel, false));
    /// <inheritdoc cref="HelmTestSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Parallel))]
    public static T ToggleParallel<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Parallel, !o.Parallel));
    #endregion
    #region Timeout
    /// <inheritdoc cref="HelmTestSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Timeout))]
    public static T SetTimeout<T>(this T o, long? v) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="HelmTestSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmTestSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmTestSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmTestSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmTestSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmTestSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmTestSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmTestSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmTestSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmTestSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmTestSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmTestSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmTestSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmTestSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmTestSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmTestSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmTestSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmTestSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmTestSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region Release
    /// <inheritdoc cref="HelmTestSettings.Release"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Release))]
    public static T SetRelease<T>(this T o, string v) where T : HelmTestSettings => o.Modify(b => b.Set(() => o.Release, v));
    /// <inheritdoc cref="HelmTestSettings.Release"/>
    [Pure] [Builder(Type = typeof(HelmTestSettings), Property = nameof(HelmTestSettings.Release))]
    public static T ResetRelease<T>(this T o) where T : HelmTestSettings => o.Modify(b => b.Remove(() => o.Release));
    #endregion
}
#endregion
#region HelmUpgradeSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmUpgradeSettingsExtensions
{
    #region Atomic
    /// <inheritdoc cref="HelmUpgradeSettings.Atomic"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Atomic))]
    public static T SetAtomic<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Atomic, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Atomic"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Atomic))]
    public static T ResetAtomic<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Atomic));
    /// <inheritdoc cref="HelmUpgradeSettings.Atomic"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Atomic))]
    public static T EnableAtomic<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Atomic, true));
    /// <inheritdoc cref="HelmUpgradeSettings.Atomic"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Atomic))]
    public static T DisableAtomic<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Atomic, false));
    /// <inheritdoc cref="HelmUpgradeSettings.Atomic"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Atomic))]
    public static T ToggleAtomic<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Atomic, !o.Atomic));
    #endregion
    #region CaFile
    /// <inheritdoc cref="HelmUpgradeSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.CaFile))]
    public static T SetCaFile<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.CaFile, v));
    /// <inheritdoc cref="HelmUpgradeSettings.CaFile"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.CaFile))]
    public static T ResetCaFile<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.CaFile));
    #endregion
    #region CertFile
    /// <inheritdoc cref="HelmUpgradeSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.CertFile))]
    public static T SetCertFile<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.CertFile, v));
    /// <inheritdoc cref="HelmUpgradeSettings.CertFile"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.CertFile))]
    public static T ResetCertFile<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.CertFile));
    #endregion
    #region Description
    /// <inheritdoc cref="HelmUpgradeSettings.Description"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Description))]
    public static T SetDescription<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Description, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Description"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Description))]
    public static T ResetDescription<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Description));
    #endregion
    #region Devel
    /// <inheritdoc cref="HelmUpgradeSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Devel))]
    public static T SetDevel<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Devel, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Devel))]
    public static T ResetDevel<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Devel));
    /// <inheritdoc cref="HelmUpgradeSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Devel))]
    public static T EnableDevel<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Devel, true));
    /// <inheritdoc cref="HelmUpgradeSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Devel))]
    public static T DisableDevel<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Devel, false));
    /// <inheritdoc cref="HelmUpgradeSettings.Devel"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Devel))]
    public static T ToggleDevel<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Devel, !o.Devel));
    #endregion
    #region DryRun
    /// <inheritdoc cref="HelmUpgradeSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.DryRun))]
    public static T SetDryRun<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.DryRun, v));
    /// <inheritdoc cref="HelmUpgradeSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.DryRun))]
    public static T ResetDryRun<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.DryRun));
    /// <inheritdoc cref="HelmUpgradeSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.DryRun))]
    public static T EnableDryRun<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.DryRun, true));
    /// <inheritdoc cref="HelmUpgradeSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.DryRun))]
    public static T DisableDryRun<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.DryRun, false));
    /// <inheritdoc cref="HelmUpgradeSettings.DryRun"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.DryRun))]
    public static T ToggleDryRun<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.DryRun, !o.DryRun));
    #endregion
    #region Force
    /// <inheritdoc cref="HelmUpgradeSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Force))]
    public static T ResetForce<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="HelmUpgradeSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Force))]
    public static T EnableForce<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="HelmUpgradeSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Force))]
    public static T DisableForce<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="HelmUpgradeSettings.Force"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region Install
    /// <inheritdoc cref="HelmUpgradeSettings.Install"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Install))]
    public static T SetInstall<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Install, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Install"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Install))]
    public static T ResetInstall<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Install));
    /// <inheritdoc cref="HelmUpgradeSettings.Install"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Install))]
    public static T EnableInstall<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Install, true));
    /// <inheritdoc cref="HelmUpgradeSettings.Install"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Install))]
    public static T DisableInstall<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Install, false));
    /// <inheritdoc cref="HelmUpgradeSettings.Install"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Install))]
    public static T ToggleInstall<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Install, !o.Install));
    #endregion
    #region CreateNamespace
    /// <inheritdoc cref="HelmUpgradeSettings.CreateNamespace"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.CreateNamespace))]
    public static T SetCreateNamespace<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.CreateNamespace, v));
    /// <inheritdoc cref="HelmUpgradeSettings.CreateNamespace"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.CreateNamespace))]
    public static T ResetCreateNamespace<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.CreateNamespace));
    /// <inheritdoc cref="HelmUpgradeSettings.CreateNamespace"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.CreateNamespace))]
    public static T EnableCreateNamespace<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.CreateNamespace, true));
    /// <inheritdoc cref="HelmUpgradeSettings.CreateNamespace"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.CreateNamespace))]
    public static T DisableCreateNamespace<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.CreateNamespace, false));
    /// <inheritdoc cref="HelmUpgradeSettings.CreateNamespace"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.CreateNamespace))]
    public static T ToggleCreateNamespace<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.CreateNamespace, !o.CreateNamespace));
    #endregion
    #region KeyFile
    /// <inheritdoc cref="HelmUpgradeSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.KeyFile))]
    public static T SetKeyFile<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.KeyFile, v));
    /// <inheritdoc cref="HelmUpgradeSettings.KeyFile"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.KeyFile))]
    public static T ResetKeyFile<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.KeyFile));
    #endregion
    #region Keyring
    /// <inheritdoc cref="HelmUpgradeSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Keyring))]
    public static T SetKeyring<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Keyring, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Keyring))]
    public static T ResetKeyring<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Keyring));
    #endregion
    #region Namespace
    /// <inheritdoc cref="HelmUpgradeSettings.Namespace"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Namespace))]
    public static T SetNamespace<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Namespace, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Namespace"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Namespace))]
    public static T ResetNamespace<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Namespace));
    #endregion
    #region NoHooks
    /// <inheritdoc cref="HelmUpgradeSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.NoHooks))]
    public static T SetNoHooks<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.NoHooks, v));
    /// <inheritdoc cref="HelmUpgradeSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.NoHooks))]
    public static T ResetNoHooks<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.NoHooks));
    /// <inheritdoc cref="HelmUpgradeSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.NoHooks))]
    public static T EnableNoHooks<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.NoHooks, true));
    /// <inheritdoc cref="HelmUpgradeSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.NoHooks))]
    public static T DisableNoHooks<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.NoHooks, false));
    /// <inheritdoc cref="HelmUpgradeSettings.NoHooks"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.NoHooks))]
    public static T ToggleNoHooks<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.NoHooks, !o.NoHooks));
    #endregion
    #region Password
    /// <inheritdoc cref="HelmUpgradeSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Password))]
    public static T SetPassword<T>(this T o, [Secret] string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Password, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Password"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Password))]
    public static T ResetPassword<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Password));
    #endregion
    #region RecreatePods
    /// <inheritdoc cref="HelmUpgradeSettings.RecreatePods"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.RecreatePods))]
    public static T SetRecreatePods<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.RecreatePods, v));
    /// <inheritdoc cref="HelmUpgradeSettings.RecreatePods"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.RecreatePods))]
    public static T ResetRecreatePods<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.RecreatePods));
    /// <inheritdoc cref="HelmUpgradeSettings.RecreatePods"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.RecreatePods))]
    public static T EnableRecreatePods<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.RecreatePods, true));
    /// <inheritdoc cref="HelmUpgradeSettings.RecreatePods"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.RecreatePods))]
    public static T DisableRecreatePods<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.RecreatePods, false));
    /// <inheritdoc cref="HelmUpgradeSettings.RecreatePods"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.RecreatePods))]
    public static T ToggleRecreatePods<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.RecreatePods, !o.RecreatePods));
    #endregion
    #region RenderSubchartNotes
    /// <inheritdoc cref="HelmUpgradeSettings.RenderSubchartNotes"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.RenderSubchartNotes))]
    public static T SetRenderSubchartNotes<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.RenderSubchartNotes, v));
    /// <inheritdoc cref="HelmUpgradeSettings.RenderSubchartNotes"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.RenderSubchartNotes))]
    public static T ResetRenderSubchartNotes<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.RenderSubchartNotes));
    /// <inheritdoc cref="HelmUpgradeSettings.RenderSubchartNotes"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.RenderSubchartNotes))]
    public static T EnableRenderSubchartNotes<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.RenderSubchartNotes, true));
    /// <inheritdoc cref="HelmUpgradeSettings.RenderSubchartNotes"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.RenderSubchartNotes))]
    public static T DisableRenderSubchartNotes<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.RenderSubchartNotes, false));
    /// <inheritdoc cref="HelmUpgradeSettings.RenderSubchartNotes"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.RenderSubchartNotes))]
    public static T ToggleRenderSubchartNotes<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.RenderSubchartNotes, !o.RenderSubchartNotes));
    #endregion
    #region Repo
    /// <inheritdoc cref="HelmUpgradeSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Repo))]
    public static T SetRepo<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Repo, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Repo"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Repo))]
    public static T ResetRepo<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Repo));
    #endregion
    #region ResetValues
    /// <inheritdoc cref="HelmUpgradeSettings.ResetValues"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.ResetValues))]
    public static T SetResetValues<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.ResetValues, v));
    /// <inheritdoc cref="HelmUpgradeSettings.ResetValues"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.ResetValues))]
    public static T ResetResetValues<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.ResetValues));
    /// <inheritdoc cref="HelmUpgradeSettings.ResetValues"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.ResetValues))]
    public static T EnableResetValues<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.ResetValues, true));
    /// <inheritdoc cref="HelmUpgradeSettings.ResetValues"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.ResetValues))]
    public static T DisableResetValues<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.ResetValues, false));
    /// <inheritdoc cref="HelmUpgradeSettings.ResetValues"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.ResetValues))]
    public static T ToggleResetValues<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.ResetValues, !o.ResetValues));
    #endregion
    #region ReuseValues
    /// <inheritdoc cref="HelmUpgradeSettings.ReuseValues"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.ReuseValues))]
    public static T SetReuseValues<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.ReuseValues, v));
    /// <inheritdoc cref="HelmUpgradeSettings.ReuseValues"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.ReuseValues))]
    public static T ResetReuseValues<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.ReuseValues));
    /// <inheritdoc cref="HelmUpgradeSettings.ReuseValues"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.ReuseValues))]
    public static T EnableReuseValues<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.ReuseValues, true));
    /// <inheritdoc cref="HelmUpgradeSettings.ReuseValues"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.ReuseValues))]
    public static T DisableReuseValues<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.ReuseValues, false));
    /// <inheritdoc cref="HelmUpgradeSettings.ReuseValues"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.ReuseValues))]
    public static T ToggleReuseValues<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.ReuseValues, !o.ReuseValues));
    #endregion
    #region Set
    /// <inheritdoc cref="HelmUpgradeSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Set))]
    public static T SetSet<T>(this T o, IDictionary<string, object> v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Set, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmUpgradeSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Set))]
    public static T SetSet<T>(this T o, string k, object v) where T : HelmUpgradeSettings => o.Modify(b => b.SetDictionary(() => o.Set, k, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Set))]
    public static T AddSet<T>(this T o, string k, object v) where T : HelmUpgradeSettings => o.Modify(b => b.AddDictionary(() => o.Set, k, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Set))]
    public static T RemoveSet<T>(this T o, string k) where T : HelmUpgradeSettings => o.Modify(b => b.RemoveDictionary(() => o.Set, k));
    /// <inheritdoc cref="HelmUpgradeSettings.Set"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Set))]
    public static T ClearSet<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.ClearDictionary(() => o.Set));
    #endregion
    #region SetFile
    /// <inheritdoc cref="HelmUpgradeSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.SetFile))]
    public static T SetSetFile<T>(this T o, IDictionary<string, object> v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.SetFile, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmUpgradeSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.SetFile))]
    public static T SetSetFile<T>(this T o, string k, object v) where T : HelmUpgradeSettings => o.Modify(b => b.SetDictionary(() => o.SetFile, k, v));
    /// <inheritdoc cref="HelmUpgradeSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.SetFile))]
    public static T AddSetFile<T>(this T o, string k, object v) where T : HelmUpgradeSettings => o.Modify(b => b.AddDictionary(() => o.SetFile, k, v));
    /// <inheritdoc cref="HelmUpgradeSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.SetFile))]
    public static T RemoveSetFile<T>(this T o, string k) where T : HelmUpgradeSettings => o.Modify(b => b.RemoveDictionary(() => o.SetFile, k));
    /// <inheritdoc cref="HelmUpgradeSettings.SetFile"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.SetFile))]
    public static T ClearSetFile<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.ClearDictionary(() => o.SetFile));
    #endregion
    #region SetString
    /// <inheritdoc cref="HelmUpgradeSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.SetString))]
    public static T SetSetString<T>(this T o, IDictionary<string, object> v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.SetString, v.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase)));
    /// <inheritdoc cref="HelmUpgradeSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.SetString))]
    public static T SetSetString<T>(this T o, string k, object v) where T : HelmUpgradeSettings => o.Modify(b => b.SetDictionary(() => o.SetString, k, v));
    /// <inheritdoc cref="HelmUpgradeSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.SetString))]
    public static T AddSetString<T>(this T o, string k, object v) where T : HelmUpgradeSettings => o.Modify(b => b.AddDictionary(() => o.SetString, k, v));
    /// <inheritdoc cref="HelmUpgradeSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.SetString))]
    public static T RemoveSetString<T>(this T o, string k) where T : HelmUpgradeSettings => o.Modify(b => b.RemoveDictionary(() => o.SetString, k));
    /// <inheritdoc cref="HelmUpgradeSettings.SetString"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.SetString))]
    public static T ClearSetString<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.ClearDictionary(() => o.SetString));
    #endregion
    #region Timeout
    /// <inheritdoc cref="HelmUpgradeSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Timeout))]
    public static T SetTimeout<T>(this T o, long? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Timeout, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Timeout"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Timeout))]
    public static T ResetTimeout<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Timeout));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmUpgradeSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmUpgradeSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmUpgradeSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmUpgradeSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmUpgradeSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmUpgradeSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmUpgradeSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmUpgradeSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmUpgradeSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmUpgradeSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmUpgradeSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmUpgradeSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmUpgradeSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmUpgradeSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmUpgradeSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmUpgradeSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmUpgradeSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
    #region Username
    /// <inheritdoc cref="HelmUpgradeSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Username"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Values
    /// <inheritdoc cref="HelmUpgradeSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Values))]
    public static T SetValues<T>(this T o, params string[] v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Values, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Values))]
    public static T SetValues<T>(this T o, IEnumerable<string> v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Values, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Values))]
    public static T AddValues<T>(this T o, params string[] v) where T : HelmUpgradeSettings => o.Modify(b => b.AddCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Values))]
    public static T AddValues<T>(this T o, IEnumerable<string> v) where T : HelmUpgradeSettings => o.Modify(b => b.AddCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Values))]
    public static T RemoveValues<T>(this T o, params string[] v) where T : HelmUpgradeSettings => o.Modify(b => b.RemoveCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Values))]
    public static T RemoveValues<T>(this T o, IEnumerable<string> v) where T : HelmUpgradeSettings => o.Modify(b => b.RemoveCollection(() => o.Values, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Values"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Values))]
    public static T ClearValues<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.ClearCollection(() => o.Values));
    #endregion
    #region Verify
    /// <inheritdoc cref="HelmUpgradeSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Verify))]
    public static T SetVerify<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Verify, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Verify))]
    public static T ResetVerify<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Verify));
    /// <inheritdoc cref="HelmUpgradeSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Verify))]
    public static T EnableVerify<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Verify, true));
    /// <inheritdoc cref="HelmUpgradeSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Verify))]
    public static T DisableVerify<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Verify, false));
    /// <inheritdoc cref="HelmUpgradeSettings.Verify"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Verify))]
    public static T ToggleVerify<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Verify, !o.Verify));
    #endregion
    #region Version
    /// <inheritdoc cref="HelmUpgradeSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Version"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Wait
    /// <inheritdoc cref="HelmUpgradeSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Wait))]
    public static T SetWait<T>(this T o, bool? v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Wait, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Wait))]
    public static T ResetWait<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Wait));
    /// <inheritdoc cref="HelmUpgradeSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Wait))]
    public static T EnableWait<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Wait, true));
    /// <inheritdoc cref="HelmUpgradeSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Wait))]
    public static T DisableWait<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Wait, false));
    /// <inheritdoc cref="HelmUpgradeSettings.Wait"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Wait))]
    public static T ToggleWait<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Wait, !o.Wait));
    #endregion
    #region Release
    /// <inheritdoc cref="HelmUpgradeSettings.Release"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Release))]
    public static T SetRelease<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Release, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Release"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Release))]
    public static T ResetRelease<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Release));
    #endregion
    #region Chart
    /// <inheritdoc cref="HelmUpgradeSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Chart))]
    public static T SetChart<T>(this T o, string v) where T : HelmUpgradeSettings => o.Modify(b => b.Set(() => o.Chart, v));
    /// <inheritdoc cref="HelmUpgradeSettings.Chart"/>
    [Pure] [Builder(Type = typeof(HelmUpgradeSettings), Property = nameof(HelmUpgradeSettings.Chart))]
    public static T ResetChart<T>(this T o) where T : HelmUpgradeSettings => o.Modify(b => b.Remove(() => o.Chart));
    #endregion
}
#endregion
#region HelmVerifySettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmVerifySettingsExtensions
{
    #region Keyring
    /// <inheritdoc cref="HelmVerifySettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmVerifySettings), Property = nameof(HelmVerifySettings.Keyring))]
    public static T SetKeyring<T>(this T o, string v) where T : HelmVerifySettings => o.Modify(b => b.Set(() => o.Keyring, v));
    /// <inheritdoc cref="HelmVerifySettings.Keyring"/>
    [Pure] [Builder(Type = typeof(HelmVerifySettings), Property = nameof(HelmVerifySettings.Keyring))]
    public static T ResetKeyring<T>(this T o) where T : HelmVerifySettings => o.Modify(b => b.Remove(() => o.Keyring));
    #endregion
    #region Path
    /// <inheritdoc cref="HelmVerifySettings.Path"/>
    [Pure] [Builder(Type = typeof(HelmVerifySettings), Property = nameof(HelmVerifySettings.Path))]
    public static T SetPath<T>(this T o, string v) where T : HelmVerifySettings => o.Modify(b => b.Set(() => o.Path, v));
    /// <inheritdoc cref="HelmVerifySettings.Path"/>
    [Pure] [Builder(Type = typeof(HelmVerifySettings), Property = nameof(HelmVerifySettings.Path))]
    public static T ResetPath<T>(this T o) where T : HelmVerifySettings => o.Modify(b => b.Remove(() => o.Path));
    #endregion
}
#endregion
#region HelmVersionSettingsExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmVersionSettingsExtensions
{
    #region Client
    /// <inheritdoc cref="HelmVersionSettings.Client"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Client))]
    public static T SetClient<T>(this T o, bool? v) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Client, v));
    /// <inheritdoc cref="HelmVersionSettings.Client"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Client))]
    public static T ResetClient<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Remove(() => o.Client));
    /// <inheritdoc cref="HelmVersionSettings.Client"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Client))]
    public static T EnableClient<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Client, true));
    /// <inheritdoc cref="HelmVersionSettings.Client"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Client))]
    public static T DisableClient<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Client, false));
    /// <inheritdoc cref="HelmVersionSettings.Client"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Client))]
    public static T ToggleClient<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Client, !o.Client));
    #endregion
    #region Server
    /// <inheritdoc cref="HelmVersionSettings.Server"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Server))]
    public static T SetServer<T>(this T o, bool? v) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Server, v));
    /// <inheritdoc cref="HelmVersionSettings.Server"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Server))]
    public static T ResetServer<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Remove(() => o.Server));
    /// <inheritdoc cref="HelmVersionSettings.Server"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Server))]
    public static T EnableServer<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Server, true));
    /// <inheritdoc cref="HelmVersionSettings.Server"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Server))]
    public static T DisableServer<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Server, false));
    /// <inheritdoc cref="HelmVersionSettings.Server"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Server))]
    public static T ToggleServer<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Server, !o.Server));
    #endregion
    #region Short
    /// <inheritdoc cref="HelmVersionSettings.Short"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Short))]
    public static T SetShort<T>(this T o, bool? v) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Short, v));
    /// <inheritdoc cref="HelmVersionSettings.Short"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Short))]
    public static T ResetShort<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Remove(() => o.Short));
    /// <inheritdoc cref="HelmVersionSettings.Short"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Short))]
    public static T EnableShort<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Short, true));
    /// <inheritdoc cref="HelmVersionSettings.Short"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Short))]
    public static T DisableShort<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Short, false));
    /// <inheritdoc cref="HelmVersionSettings.Short"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Short))]
    public static T ToggleShort<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Short, !o.Short));
    #endregion
    #region Template
    /// <inheritdoc cref="HelmVersionSettings.Template"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Template))]
    public static T SetTemplate<T>(this T o, string v) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Template, v));
    /// <inheritdoc cref="HelmVersionSettings.Template"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Template))]
    public static T ResetTemplate<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Remove(() => o.Template));
    #endregion
    #region Tls
    /// <inheritdoc cref="HelmVersionSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Tls))]
    public static T SetTls<T>(this T o, bool? v) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Tls, v));
    /// <inheritdoc cref="HelmVersionSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Tls))]
    public static T ResetTls<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Remove(() => o.Tls));
    /// <inheritdoc cref="HelmVersionSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Tls))]
    public static T EnableTls<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Tls, true));
    /// <inheritdoc cref="HelmVersionSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Tls))]
    public static T DisableTls<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Tls, false));
    /// <inheritdoc cref="HelmVersionSettings.Tls"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.Tls))]
    public static T ToggleTls<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.Tls, !o.Tls));
    #endregion
    #region TlsCaCert
    /// <inheritdoc cref="HelmVersionSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsCaCert))]
    public static T SetTlsCaCert<T>(this T o, string v) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.TlsCaCert, v));
    /// <inheritdoc cref="HelmVersionSettings.TlsCaCert"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsCaCert))]
    public static T ResetTlsCaCert<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Remove(() => o.TlsCaCert));
    #endregion
    #region TlsCert
    /// <inheritdoc cref="HelmVersionSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsCert))]
    public static T SetTlsCert<T>(this T o, string v) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.TlsCert, v));
    /// <inheritdoc cref="HelmVersionSettings.TlsCert"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsCert))]
    public static T ResetTlsCert<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Remove(() => o.TlsCert));
    #endregion
    #region TlsHostname
    /// <inheritdoc cref="HelmVersionSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsHostname))]
    public static T SetTlsHostname<T>(this T o, string v) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.TlsHostname, v));
    /// <inheritdoc cref="HelmVersionSettings.TlsHostname"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsHostname))]
    public static T ResetTlsHostname<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Remove(() => o.TlsHostname));
    #endregion
    #region TlsKey
    /// <inheritdoc cref="HelmVersionSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsKey))]
    public static T SetTlsKey<T>(this T o, string v) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.TlsKey, v));
    /// <inheritdoc cref="HelmVersionSettings.TlsKey"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsKey))]
    public static T ResetTlsKey<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Remove(() => o.TlsKey));
    #endregion
    #region TlsVerify
    /// <inheritdoc cref="HelmVersionSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsVerify))]
    public static T SetTlsVerify<T>(this T o, bool? v) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.TlsVerify, v));
    /// <inheritdoc cref="HelmVersionSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsVerify))]
    public static T ResetTlsVerify<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Remove(() => o.TlsVerify));
    /// <inheritdoc cref="HelmVersionSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsVerify))]
    public static T EnableTlsVerify<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.TlsVerify, true));
    /// <inheritdoc cref="HelmVersionSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsVerify))]
    public static T DisableTlsVerify<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.TlsVerify, false));
    /// <inheritdoc cref="HelmVersionSettings.TlsVerify"/>
    [Pure] [Builder(Type = typeof(HelmVersionSettings), Property = nameof(HelmVersionSettings.TlsVerify))]
    public static T ToggleTlsVerify<T>(this T o) where T : HelmVersionSettings => o.Modify(b => b.Set(() => o.TlsVerify, !o.TlsVerify));
    #endregion
}
#endregion
#region HelmOptionsBaseExtensions
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class HelmOptionsBaseExtensions
{
    #region Debug
    /// <inheritdoc cref="HelmOptionsBase.Debug"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : HelmOptionsBase => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="HelmOptionsBase.Debug"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.Debug))]
    public static T ResetDebug<T>(this T o) where T : HelmOptionsBase => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="HelmOptionsBase.Debug"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.Debug))]
    public static T EnableDebug<T>(this T o) where T : HelmOptionsBase => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="HelmOptionsBase.Debug"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.Debug))]
    public static T DisableDebug<T>(this T o) where T : HelmOptionsBase => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="HelmOptionsBase.Debug"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.Debug))]
    public static T ToggleDebug<T>(this T o) where T : HelmOptionsBase => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Home
    /// <inheritdoc cref="HelmOptionsBase.Home"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.Home))]
    public static T SetHome<T>(this T o, string v) where T : HelmOptionsBase => o.Modify(b => b.Set(() => o.Home, v));
    /// <inheritdoc cref="HelmOptionsBase.Home"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.Home))]
    public static T ResetHome<T>(this T o) where T : HelmOptionsBase => o.Modify(b => b.Remove(() => o.Home));
    #endregion
    #region Host
    /// <inheritdoc cref="HelmOptionsBase.Host"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.Host))]
    public static T SetHost<T>(this T o, string v) where T : HelmOptionsBase => o.Modify(b => b.Set(() => o.Host, v));
    /// <inheritdoc cref="HelmOptionsBase.Host"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.Host))]
    public static T ResetHost<T>(this T o) where T : HelmOptionsBase => o.Modify(b => b.Remove(() => o.Host));
    #endregion
    #region KubeContext
    /// <inheritdoc cref="HelmOptionsBase.KubeContext"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.KubeContext))]
    public static T SetKubeContext<T>(this T o, string v) where T : HelmOptionsBase => o.Modify(b => b.Set(() => o.KubeContext, v));
    /// <inheritdoc cref="HelmOptionsBase.KubeContext"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.KubeContext))]
    public static T ResetKubeContext<T>(this T o) where T : HelmOptionsBase => o.Modify(b => b.Remove(() => o.KubeContext));
    #endregion
    #region Kubeconfig
    /// <inheritdoc cref="HelmOptionsBase.Kubeconfig"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.Kubeconfig))]
    public static T SetKubeconfig<T>(this T o, string v) where T : HelmOptionsBase => o.Modify(b => b.Set(() => o.Kubeconfig, v));
    /// <inheritdoc cref="HelmOptionsBase.Kubeconfig"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.Kubeconfig))]
    public static T ResetKubeconfig<T>(this T o) where T : HelmOptionsBase => o.Modify(b => b.Remove(() => o.Kubeconfig));
    #endregion
    #region TillerConnectionTimeout
    /// <inheritdoc cref="HelmOptionsBase.TillerConnectionTimeout"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.TillerConnectionTimeout))]
    public static T SetTillerConnectionTimeout<T>(this T o, long? v) where T : HelmOptionsBase => o.Modify(b => b.Set(() => o.TillerConnectionTimeout, v));
    /// <inheritdoc cref="HelmOptionsBase.TillerConnectionTimeout"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.TillerConnectionTimeout))]
    public static T ResetTillerConnectionTimeout<T>(this T o) where T : HelmOptionsBase => o.Modify(b => b.Remove(() => o.TillerConnectionTimeout));
    #endregion
    #region TillerNamespace
    /// <inheritdoc cref="HelmOptionsBase.TillerNamespace"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.TillerNamespace))]
    public static T SetTillerNamespace<T>(this T o, string v) where T : HelmOptionsBase => o.Modify(b => b.Set(() => o.TillerNamespace, v));
    /// <inheritdoc cref="HelmOptionsBase.TillerNamespace"/>
    [Pure] [Builder(Type = typeof(HelmOptionsBase), Property = nameof(HelmOptionsBase.TillerNamespace))]
    public static T ResetTillerNamespace<T>(this T o) where T : HelmOptionsBase => o.Modify(b => b.Remove(() => o.TillerNamespace));
    #endregion
}
#endregion
#region HelmOutputFormat
/// <summary>Used within <see cref="HelmTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<HelmOutputFormat>))]
public partial class HelmOutputFormat : Enumeration
{
    public static HelmOutputFormat json = (HelmOutputFormat) "json";
    public static HelmOutputFormat yaml = (HelmOutputFormat) "yaml";
    public static implicit operator HelmOutputFormat(string value)
    {
        return new HelmOutputFormat { Value = value };
    }
}
#endregion
