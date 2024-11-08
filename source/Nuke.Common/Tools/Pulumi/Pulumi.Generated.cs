// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Pulumi/Pulumi.json

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

namespace Nuke.Common.Tools.Pulumi;

/// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[PathToolRequirement(PathExecutable)]
[PathTool(Executable = PathExecutable)]
public partial class PulumiTasks : ToolTasks, IRequirePathTool
{
    public static string PulumiPath => new PulumiTasks().GetToolPath();
    public const string PathExecutable = "pulumi";
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> Pulumi(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new PulumiTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiUpSettings.Color"/></li><li><c>--config</c> via <see cref="PulumiUpSettings.Config"/></li><li><c>--config-file</c> via <see cref="PulumiUpSettings.ConfigFile"/></li><li><c>--config-path</c> via <see cref="PulumiUpSettings.ConfigPath"/></li><li><c>--cwd</c> via <see cref="PulumiUpSettings.Cwd"/></li><li><c>--debug</c> via <see cref="PulumiUpSettings.Debug"/></li><li><c>--diff</c> via <see cref="PulumiUpSettings.Diff"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiUpSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiUpSettings.Emoji"/></li><li><c>--expect-no-changes</c> via <see cref="PulumiUpSettings.ExpectNoChanges"/></li><li><c>--logflow</c> via <see cref="PulumiUpSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiUpSettings.LogToStderr"/></li><li><c>--message</c> via <see cref="PulumiUpSettings.Message"/></li><li><c>--non-interactive</c> via <see cref="PulumiUpSettings.NonInteractive"/></li><li><c>--parallel</c> via <see cref="PulumiUpSettings.Parallel"/></li><li><c>--policy-pack</c> via <see cref="PulumiUpSettings.PolicyPack"/></li><li><c>--policy-pack-config</c> via <see cref="PulumiUpSettings.PolicyPackConfig"/></li><li><c>--profiling</c> via <see cref="PulumiUpSettings.Profiling"/></li><li><c>--refresh</c> via <see cref="PulumiUpSettings.Refresh"/></li><li><c>--replace</c> via <see cref="PulumiUpSettings.Replace"/></li><li><c>--secrets-provider</c> via <see cref="PulumiUpSettings.SecretsProvider"/></li><li><c>--show-config</c> via <see cref="PulumiUpSettings.ShowConfig"/></li><li><c>--show-reads</c> via <see cref="PulumiUpSettings.ShowReads"/></li><li><c>--show-replacement-steps</c> via <see cref="PulumiUpSettings.ShowReplacementSteps"/></li><li><c>--show-sames</c> via <see cref="PulumiUpSettings.ShowSames"/></li><li><c>--skip-preview</c> via <see cref="PulumiUpSettings.SkipPreview"/></li><li><c>--stack</c> via <see cref="PulumiUpSettings.Stack"/></li><li><c>--suppress-outputs</c> via <see cref="PulumiUpSettings.SuppressOutputs"/></li><li><c>--suppress-permalink</c> via <see cref="PulumiUpSettings.SuppressPermalink"/></li><li><c>--target</c> via <see cref="PulumiUpSettings.Target"/></li><li><c>--target-dependents</c> via <see cref="PulumiUpSettings.TargetDependents"/></li><li><c>--target-replace</c> via <see cref="PulumiUpSettings.TargetReplace"/></li><li><c>--tracing</c> via <see cref="PulumiUpSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiUpSettings.Verbose"/></li><li><c>--yes</c> via <see cref="PulumiUpSettings.Yes"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiUp(PulumiUpSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiUpSettings.Color"/></li><li><c>--config</c> via <see cref="PulumiUpSettings.Config"/></li><li><c>--config-file</c> via <see cref="PulumiUpSettings.ConfigFile"/></li><li><c>--config-path</c> via <see cref="PulumiUpSettings.ConfigPath"/></li><li><c>--cwd</c> via <see cref="PulumiUpSettings.Cwd"/></li><li><c>--debug</c> via <see cref="PulumiUpSettings.Debug"/></li><li><c>--diff</c> via <see cref="PulumiUpSettings.Diff"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiUpSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiUpSettings.Emoji"/></li><li><c>--expect-no-changes</c> via <see cref="PulumiUpSettings.ExpectNoChanges"/></li><li><c>--logflow</c> via <see cref="PulumiUpSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiUpSettings.LogToStderr"/></li><li><c>--message</c> via <see cref="PulumiUpSettings.Message"/></li><li><c>--non-interactive</c> via <see cref="PulumiUpSettings.NonInteractive"/></li><li><c>--parallel</c> via <see cref="PulumiUpSettings.Parallel"/></li><li><c>--policy-pack</c> via <see cref="PulumiUpSettings.PolicyPack"/></li><li><c>--policy-pack-config</c> via <see cref="PulumiUpSettings.PolicyPackConfig"/></li><li><c>--profiling</c> via <see cref="PulumiUpSettings.Profiling"/></li><li><c>--refresh</c> via <see cref="PulumiUpSettings.Refresh"/></li><li><c>--replace</c> via <see cref="PulumiUpSettings.Replace"/></li><li><c>--secrets-provider</c> via <see cref="PulumiUpSettings.SecretsProvider"/></li><li><c>--show-config</c> via <see cref="PulumiUpSettings.ShowConfig"/></li><li><c>--show-reads</c> via <see cref="PulumiUpSettings.ShowReads"/></li><li><c>--show-replacement-steps</c> via <see cref="PulumiUpSettings.ShowReplacementSteps"/></li><li><c>--show-sames</c> via <see cref="PulumiUpSettings.ShowSames"/></li><li><c>--skip-preview</c> via <see cref="PulumiUpSettings.SkipPreview"/></li><li><c>--stack</c> via <see cref="PulumiUpSettings.Stack"/></li><li><c>--suppress-outputs</c> via <see cref="PulumiUpSettings.SuppressOutputs"/></li><li><c>--suppress-permalink</c> via <see cref="PulumiUpSettings.SuppressPermalink"/></li><li><c>--target</c> via <see cref="PulumiUpSettings.Target"/></li><li><c>--target-dependents</c> via <see cref="PulumiUpSettings.TargetDependents"/></li><li><c>--target-replace</c> via <see cref="PulumiUpSettings.TargetReplace"/></li><li><c>--tracing</c> via <see cref="PulumiUpSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiUpSettings.Verbose"/></li><li><c>--yes</c> via <see cref="PulumiUpSettings.Yes"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiUp(Configure<PulumiUpSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiUpSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiUpSettings.Color"/></li><li><c>--config</c> via <see cref="PulumiUpSettings.Config"/></li><li><c>--config-file</c> via <see cref="PulumiUpSettings.ConfigFile"/></li><li><c>--config-path</c> via <see cref="PulumiUpSettings.ConfigPath"/></li><li><c>--cwd</c> via <see cref="PulumiUpSettings.Cwd"/></li><li><c>--debug</c> via <see cref="PulumiUpSettings.Debug"/></li><li><c>--diff</c> via <see cref="PulumiUpSettings.Diff"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiUpSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiUpSettings.Emoji"/></li><li><c>--expect-no-changes</c> via <see cref="PulumiUpSettings.ExpectNoChanges"/></li><li><c>--logflow</c> via <see cref="PulumiUpSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiUpSettings.LogToStderr"/></li><li><c>--message</c> via <see cref="PulumiUpSettings.Message"/></li><li><c>--non-interactive</c> via <see cref="PulumiUpSettings.NonInteractive"/></li><li><c>--parallel</c> via <see cref="PulumiUpSettings.Parallel"/></li><li><c>--policy-pack</c> via <see cref="PulumiUpSettings.PolicyPack"/></li><li><c>--policy-pack-config</c> via <see cref="PulumiUpSettings.PolicyPackConfig"/></li><li><c>--profiling</c> via <see cref="PulumiUpSettings.Profiling"/></li><li><c>--refresh</c> via <see cref="PulumiUpSettings.Refresh"/></li><li><c>--replace</c> via <see cref="PulumiUpSettings.Replace"/></li><li><c>--secrets-provider</c> via <see cref="PulumiUpSettings.SecretsProvider"/></li><li><c>--show-config</c> via <see cref="PulumiUpSettings.ShowConfig"/></li><li><c>--show-reads</c> via <see cref="PulumiUpSettings.ShowReads"/></li><li><c>--show-replacement-steps</c> via <see cref="PulumiUpSettings.ShowReplacementSteps"/></li><li><c>--show-sames</c> via <see cref="PulumiUpSettings.ShowSames"/></li><li><c>--skip-preview</c> via <see cref="PulumiUpSettings.SkipPreview"/></li><li><c>--stack</c> via <see cref="PulumiUpSettings.Stack"/></li><li><c>--suppress-outputs</c> via <see cref="PulumiUpSettings.SuppressOutputs"/></li><li><c>--suppress-permalink</c> via <see cref="PulumiUpSettings.SuppressPermalink"/></li><li><c>--target</c> via <see cref="PulumiUpSettings.Target"/></li><li><c>--target-dependents</c> via <see cref="PulumiUpSettings.TargetDependents"/></li><li><c>--target-replace</c> via <see cref="PulumiUpSettings.TargetReplace"/></li><li><c>--tracing</c> via <see cref="PulumiUpSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiUpSettings.Verbose"/></li><li><c>--yes</c> via <see cref="PulumiUpSettings.Yes"/></li></ul></remarks>
    public static IEnumerable<(PulumiUpSettings Settings, IReadOnlyCollection<Output> Output)> PulumiUp(CombinatorialConfigure<PulumiUpSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiUp, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiPreviewSettings.Color"/></li><li><c>--config</c> via <see cref="PulumiPreviewSettings.Config"/></li><li><c>--config-file</c> via <see cref="PulumiPreviewSettings.ConfigFile"/></li><li><c>--config-path</c> via <see cref="PulumiPreviewSettings.ConfigPath"/></li><li><c>--cwd</c> via <see cref="PulumiPreviewSettings.Cwd"/></li><li><c>--debug</c> via <see cref="PulumiPreviewSettings.Debug"/></li><li><c>--diff</c> via <see cref="PulumiPreviewSettings.Diff"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiPreviewSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiPreviewSettings.Emoji"/></li><li><c>--expect-no-changes</c> via <see cref="PulumiPreviewSettings.ExpectNoChanges"/></li><li><c>--json</c> via <see cref="PulumiPreviewSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiPreviewSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiPreviewSettings.LogToStderr"/></li><li><c>--message</c> via <see cref="PulumiPreviewSettings.Message"/></li><li><c>--non-interactive</c> via <see cref="PulumiPreviewSettings.NonInteractive"/></li><li><c>--parallel</c> via <see cref="PulumiPreviewSettings.Parallel"/></li><li><c>--policy-pack</c> via <see cref="PulumiPreviewSettings.PolicyPack"/></li><li><c>--policy-pack-config</c> via <see cref="PulumiPreviewSettings.PolicyPackConfig"/></li><li><c>--profiling</c> via <see cref="PulumiPreviewSettings.Profiling"/></li><li><c>--refresh</c> via <see cref="PulumiPreviewSettings.Refresh"/></li><li><c>--replace</c> via <see cref="PulumiPreviewSettings.Replace"/></li><li><c>--show-config</c> via <see cref="PulumiPreviewSettings.ShowConfig"/></li><li><c>--show-reads</c> via <see cref="PulumiPreviewSettings.ShowReads"/></li><li><c>--show-replacement-steps</c> via <see cref="PulumiPreviewSettings.ShowReplacementSteps"/></li><li><c>--show-sames</c> via <see cref="PulumiPreviewSettings.ShowSames"/></li><li><c>--stack</c> via <see cref="PulumiPreviewSettings.Stack"/></li><li><c>--suppress-outputs</c> via <see cref="PulumiPreviewSettings.SuppressOutputs"/></li><li><c>--suppress-permalink</c> via <see cref="PulumiPreviewSettings.SuppressPermalink"/></li><li><c>--target</c> via <see cref="PulumiPreviewSettings.Target"/></li><li><c>--target-dependents</c> via <see cref="PulumiPreviewSettings.TargetDependents"/></li><li><c>--target-replace</c> via <see cref="PulumiPreviewSettings.TargetReplace"/></li><li><c>--tracing</c> via <see cref="PulumiPreviewSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiPreviewSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiPreview(PulumiPreviewSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiPreviewSettings.Color"/></li><li><c>--config</c> via <see cref="PulumiPreviewSettings.Config"/></li><li><c>--config-file</c> via <see cref="PulumiPreviewSettings.ConfigFile"/></li><li><c>--config-path</c> via <see cref="PulumiPreviewSettings.ConfigPath"/></li><li><c>--cwd</c> via <see cref="PulumiPreviewSettings.Cwd"/></li><li><c>--debug</c> via <see cref="PulumiPreviewSettings.Debug"/></li><li><c>--diff</c> via <see cref="PulumiPreviewSettings.Diff"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiPreviewSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiPreviewSettings.Emoji"/></li><li><c>--expect-no-changes</c> via <see cref="PulumiPreviewSettings.ExpectNoChanges"/></li><li><c>--json</c> via <see cref="PulumiPreviewSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiPreviewSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiPreviewSettings.LogToStderr"/></li><li><c>--message</c> via <see cref="PulumiPreviewSettings.Message"/></li><li><c>--non-interactive</c> via <see cref="PulumiPreviewSettings.NonInteractive"/></li><li><c>--parallel</c> via <see cref="PulumiPreviewSettings.Parallel"/></li><li><c>--policy-pack</c> via <see cref="PulumiPreviewSettings.PolicyPack"/></li><li><c>--policy-pack-config</c> via <see cref="PulumiPreviewSettings.PolicyPackConfig"/></li><li><c>--profiling</c> via <see cref="PulumiPreviewSettings.Profiling"/></li><li><c>--refresh</c> via <see cref="PulumiPreviewSettings.Refresh"/></li><li><c>--replace</c> via <see cref="PulumiPreviewSettings.Replace"/></li><li><c>--show-config</c> via <see cref="PulumiPreviewSettings.ShowConfig"/></li><li><c>--show-reads</c> via <see cref="PulumiPreviewSettings.ShowReads"/></li><li><c>--show-replacement-steps</c> via <see cref="PulumiPreviewSettings.ShowReplacementSteps"/></li><li><c>--show-sames</c> via <see cref="PulumiPreviewSettings.ShowSames"/></li><li><c>--stack</c> via <see cref="PulumiPreviewSettings.Stack"/></li><li><c>--suppress-outputs</c> via <see cref="PulumiPreviewSettings.SuppressOutputs"/></li><li><c>--suppress-permalink</c> via <see cref="PulumiPreviewSettings.SuppressPermalink"/></li><li><c>--target</c> via <see cref="PulumiPreviewSettings.Target"/></li><li><c>--target-dependents</c> via <see cref="PulumiPreviewSettings.TargetDependents"/></li><li><c>--target-replace</c> via <see cref="PulumiPreviewSettings.TargetReplace"/></li><li><c>--tracing</c> via <see cref="PulumiPreviewSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiPreviewSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiPreview(Configure<PulumiPreviewSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiPreviewSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiPreviewSettings.Color"/></li><li><c>--config</c> via <see cref="PulumiPreviewSettings.Config"/></li><li><c>--config-file</c> via <see cref="PulumiPreviewSettings.ConfigFile"/></li><li><c>--config-path</c> via <see cref="PulumiPreviewSettings.ConfigPath"/></li><li><c>--cwd</c> via <see cref="PulumiPreviewSettings.Cwd"/></li><li><c>--debug</c> via <see cref="PulumiPreviewSettings.Debug"/></li><li><c>--diff</c> via <see cref="PulumiPreviewSettings.Diff"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiPreviewSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiPreviewSettings.Emoji"/></li><li><c>--expect-no-changes</c> via <see cref="PulumiPreviewSettings.ExpectNoChanges"/></li><li><c>--json</c> via <see cref="PulumiPreviewSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiPreviewSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiPreviewSettings.LogToStderr"/></li><li><c>--message</c> via <see cref="PulumiPreviewSettings.Message"/></li><li><c>--non-interactive</c> via <see cref="PulumiPreviewSettings.NonInteractive"/></li><li><c>--parallel</c> via <see cref="PulumiPreviewSettings.Parallel"/></li><li><c>--policy-pack</c> via <see cref="PulumiPreviewSettings.PolicyPack"/></li><li><c>--policy-pack-config</c> via <see cref="PulumiPreviewSettings.PolicyPackConfig"/></li><li><c>--profiling</c> via <see cref="PulumiPreviewSettings.Profiling"/></li><li><c>--refresh</c> via <see cref="PulumiPreviewSettings.Refresh"/></li><li><c>--replace</c> via <see cref="PulumiPreviewSettings.Replace"/></li><li><c>--show-config</c> via <see cref="PulumiPreviewSettings.ShowConfig"/></li><li><c>--show-reads</c> via <see cref="PulumiPreviewSettings.ShowReads"/></li><li><c>--show-replacement-steps</c> via <see cref="PulumiPreviewSettings.ShowReplacementSteps"/></li><li><c>--show-sames</c> via <see cref="PulumiPreviewSettings.ShowSames"/></li><li><c>--stack</c> via <see cref="PulumiPreviewSettings.Stack"/></li><li><c>--suppress-outputs</c> via <see cref="PulumiPreviewSettings.SuppressOutputs"/></li><li><c>--suppress-permalink</c> via <see cref="PulumiPreviewSettings.SuppressPermalink"/></li><li><c>--target</c> via <see cref="PulumiPreviewSettings.Target"/></li><li><c>--target-dependents</c> via <see cref="PulumiPreviewSettings.TargetDependents"/></li><li><c>--target-replace</c> via <see cref="PulumiPreviewSettings.TargetReplace"/></li><li><c>--tracing</c> via <see cref="PulumiPreviewSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiPreviewSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiPreviewSettings Settings, IReadOnlyCollection<Output> Output)> PulumiPreview(CombinatorialConfigure<PulumiPreviewSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiPreview, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiConfigSettings.Color"/></li><li><c>--config-file</c> via <see cref="PulumiConfigSettings.ConfigFile"/></li><li><c>--cwd</c> via <see cref="PulumiConfigSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiConfigSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiConfigSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiConfigSettings.Profiling"/></li><li><c>--show-secrets</c> via <see cref="PulumiConfigSettings.ShowSecrets"/></li><li><c>--stack</c> via <see cref="PulumiConfigSettings.Stack"/></li><li><c>--tracing</c> via <see cref="PulumiConfigSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiConfig(PulumiConfigSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiConfigSettings.Color"/></li><li><c>--config-file</c> via <see cref="PulumiConfigSettings.ConfigFile"/></li><li><c>--cwd</c> via <see cref="PulumiConfigSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiConfigSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiConfigSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiConfigSettings.Profiling"/></li><li><c>--show-secrets</c> via <see cref="PulumiConfigSettings.ShowSecrets"/></li><li><c>--stack</c> via <see cref="PulumiConfigSettings.Stack"/></li><li><c>--tracing</c> via <see cref="PulumiConfigSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiConfig(Configure<PulumiConfigSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiConfigSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiConfigSettings.Color"/></li><li><c>--config-file</c> via <see cref="PulumiConfigSettings.ConfigFile"/></li><li><c>--cwd</c> via <see cref="PulumiConfigSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiConfigSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiConfigSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiConfigSettings.Profiling"/></li><li><c>--show-secrets</c> via <see cref="PulumiConfigSettings.ShowSecrets"/></li><li><c>--stack</c> via <see cref="PulumiConfigSettings.Stack"/></li><li><c>--tracing</c> via <see cref="PulumiConfigSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiConfigSettings Settings, IReadOnlyCollection<Output> Output)> PulumiConfig(CombinatorialConfigure<PulumiConfigSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiConfig, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiConfigCopySettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigCopySettings.Cwd"/></li><li><c>--dest</c> via <see cref="PulumiConfigCopySettings.Destination"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigCopySettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigCopySettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiConfigCopySettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigCopySettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigCopySettings.NonInteractive"/></li><li><c>--path</c> via <see cref="PulumiConfigCopySettings.Path"/></li><li><c>--profiling</c> via <see cref="PulumiConfigCopySettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiConfigCopySettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigCopySettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiConfigCopy(PulumiConfigCopySettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiConfigCopySettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigCopySettings.Cwd"/></li><li><c>--dest</c> via <see cref="PulumiConfigCopySettings.Destination"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigCopySettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigCopySettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiConfigCopySettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigCopySettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigCopySettings.NonInteractive"/></li><li><c>--path</c> via <see cref="PulumiConfigCopySettings.Path"/></li><li><c>--profiling</c> via <see cref="PulumiConfigCopySettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiConfigCopySettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigCopySettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiConfigCopy(Configure<PulumiConfigCopySettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiConfigCopySettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiConfigCopySettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigCopySettings.Cwd"/></li><li><c>--dest</c> via <see cref="PulumiConfigCopySettings.Destination"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigCopySettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigCopySettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiConfigCopySettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigCopySettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigCopySettings.NonInteractive"/></li><li><c>--path</c> via <see cref="PulumiConfigCopySettings.Path"/></li><li><c>--profiling</c> via <see cref="PulumiConfigCopySettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiConfigCopySettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigCopySettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiConfigCopySettings Settings, IReadOnlyCollection<Output> Output)> PulumiConfigCopy(CombinatorialConfigure<PulumiConfigCopySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiConfigCopy, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;key&gt;</c> via <see cref="PulumiConfigGetSettings.Key"/></li><li><c>--color</c> via <see cref="PulumiConfigGetSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigGetSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigGetSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigGetSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiConfigGetSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiConfigGetSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigGetSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigGetSettings.NonInteractive"/></li><li><c>--path</c> via <see cref="PulumiConfigGetSettings.Path"/></li><li><c>--profiling</c> via <see cref="PulumiConfigGetSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiConfigGetSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigGetSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiConfigGet(PulumiConfigGetSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;key&gt;</c> via <see cref="PulumiConfigGetSettings.Key"/></li><li><c>--color</c> via <see cref="PulumiConfigGetSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigGetSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigGetSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigGetSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiConfigGetSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiConfigGetSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigGetSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigGetSettings.NonInteractive"/></li><li><c>--path</c> via <see cref="PulumiConfigGetSettings.Path"/></li><li><c>--profiling</c> via <see cref="PulumiConfigGetSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiConfigGetSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigGetSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiConfigGet(Configure<PulumiConfigGetSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiConfigGetSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;key&gt;</c> via <see cref="PulumiConfigGetSettings.Key"/></li><li><c>--color</c> via <see cref="PulumiConfigGetSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigGetSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigGetSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigGetSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiConfigGetSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiConfigGetSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigGetSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigGetSettings.NonInteractive"/></li><li><c>--path</c> via <see cref="PulumiConfigGetSettings.Path"/></li><li><c>--profiling</c> via <see cref="PulumiConfigGetSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiConfigGetSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigGetSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiConfigGetSettings Settings, IReadOnlyCollection<Output> Output)> PulumiConfigGet(CombinatorialConfigure<PulumiConfigGetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiConfigGet, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiConfigRefreshSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigRefreshSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigRefreshSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigRefreshSettings.Emoji"/></li><li><c>--force</c> via <see cref="PulumiConfigRefreshSettings.Force"/></li><li><c>--logflow</c> via <see cref="PulumiConfigRefreshSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigRefreshSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigRefreshSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiConfigRefreshSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiConfigRefreshSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigRefreshSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiConfigRefresh(PulumiConfigRefreshSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiConfigRefreshSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigRefreshSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigRefreshSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigRefreshSettings.Emoji"/></li><li><c>--force</c> via <see cref="PulumiConfigRefreshSettings.Force"/></li><li><c>--logflow</c> via <see cref="PulumiConfigRefreshSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigRefreshSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigRefreshSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiConfigRefreshSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiConfigRefreshSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigRefreshSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiConfigRefresh(Configure<PulumiConfigRefreshSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiConfigRefreshSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiConfigRefreshSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigRefreshSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigRefreshSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigRefreshSettings.Emoji"/></li><li><c>--force</c> via <see cref="PulumiConfigRefreshSettings.Force"/></li><li><c>--logflow</c> via <see cref="PulumiConfigRefreshSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigRefreshSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigRefreshSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiConfigRefreshSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiConfigRefreshSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigRefreshSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiConfigRefreshSettings Settings, IReadOnlyCollection<Output> Output)> PulumiConfigRefresh(CombinatorialConfigure<PulumiConfigRefreshSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiConfigRefresh, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;key&gt;</c> via <see cref="PulumiConfigRemoveSettings.Key"/></li><li><c>--color</c> via <see cref="PulumiConfigRemoveSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigRemoveSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigRemoveSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigRemoveSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiConfigRemoveSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigRemoveSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigRemoveSettings.NonInteractive"/></li><li><c>--path</c> via <see cref="PulumiConfigRemoveSettings.Path"/></li><li><c>--profiling</c> via <see cref="PulumiConfigRemoveSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiConfigRemoveSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigRemoveSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiConfigRemove(PulumiConfigRemoveSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;key&gt;</c> via <see cref="PulumiConfigRemoveSettings.Key"/></li><li><c>--color</c> via <see cref="PulumiConfigRemoveSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigRemoveSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigRemoveSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigRemoveSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiConfigRemoveSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigRemoveSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigRemoveSettings.NonInteractive"/></li><li><c>--path</c> via <see cref="PulumiConfigRemoveSettings.Path"/></li><li><c>--profiling</c> via <see cref="PulumiConfigRemoveSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiConfigRemoveSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigRemoveSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiConfigRemove(Configure<PulumiConfigRemoveSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiConfigRemoveSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;key&gt;</c> via <see cref="PulumiConfigRemoveSettings.Key"/></li><li><c>--color</c> via <see cref="PulumiConfigRemoveSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigRemoveSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigRemoveSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigRemoveSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiConfigRemoveSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigRemoveSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigRemoveSettings.NonInteractive"/></li><li><c>--path</c> via <see cref="PulumiConfigRemoveSettings.Path"/></li><li><c>--profiling</c> via <see cref="PulumiConfigRemoveSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiConfigRemoveSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigRemoveSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiConfigRemoveSettings Settings, IReadOnlyCollection<Output> Output)> PulumiConfigRemove(CombinatorialConfigure<PulumiConfigRemoveSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiConfigRemove, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;key&gt;</c> via <see cref="PulumiConfigSetSettings.Key"/></li><li><c>&lt;value&gt;</c> via <see cref="PulumiConfigSetSettings.Value"/></li><li><c>--color</c> via <see cref="PulumiConfigSetSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigSetSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigSetSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigSetSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiConfigSetSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigSetSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigSetSettings.NonInteractive"/></li><li><c>--path</c> via <see cref="PulumiConfigSetSettings.Path"/></li><li><c>--plaintext</c> via <see cref="PulumiConfigSetSettings.Plaintext"/></li><li><c>--profiling</c> via <see cref="PulumiConfigSetSettings.Profiling"/></li><li><c>--secret</c> via <see cref="PulumiConfigSetSettings.Secret"/></li><li><c>--tracing</c> via <see cref="PulumiConfigSetSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigSetSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiConfigSet(PulumiConfigSetSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;key&gt;</c> via <see cref="PulumiConfigSetSettings.Key"/></li><li><c>&lt;value&gt;</c> via <see cref="PulumiConfigSetSettings.Value"/></li><li><c>--color</c> via <see cref="PulumiConfigSetSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigSetSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigSetSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigSetSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiConfigSetSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigSetSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigSetSettings.NonInteractive"/></li><li><c>--path</c> via <see cref="PulumiConfigSetSettings.Path"/></li><li><c>--plaintext</c> via <see cref="PulumiConfigSetSettings.Plaintext"/></li><li><c>--profiling</c> via <see cref="PulumiConfigSetSettings.Profiling"/></li><li><c>--secret</c> via <see cref="PulumiConfigSetSettings.Secret"/></li><li><c>--tracing</c> via <see cref="PulumiConfigSetSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigSetSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiConfigSet(Configure<PulumiConfigSetSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiConfigSetSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;key&gt;</c> via <see cref="PulumiConfigSetSettings.Key"/></li><li><c>&lt;value&gt;</c> via <see cref="PulumiConfigSetSettings.Value"/></li><li><c>--color</c> via <see cref="PulumiConfigSetSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiConfigSetSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiConfigSetSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiConfigSetSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiConfigSetSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiConfigSetSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiConfigSetSettings.NonInteractive"/></li><li><c>--path</c> via <see cref="PulumiConfigSetSettings.Path"/></li><li><c>--plaintext</c> via <see cref="PulumiConfigSetSettings.Plaintext"/></li><li><c>--profiling</c> via <see cref="PulumiConfigSetSettings.Profiling"/></li><li><c>--secret</c> via <see cref="PulumiConfigSetSettings.Secret"/></li><li><c>--tracing</c> via <see cref="PulumiConfigSetSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiConfigSetSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiConfigSetSettings Settings, IReadOnlyCollection<Output> Output)> PulumiConfigSet(CombinatorialConfigure<PulumiConfigSetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiConfigSet, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackSettings.Profiling"/></li><li><c>--show-ids</c> via <see cref="PulumiStackSettings.ShowIds"/></li><li><c>--show-name</c> via <see cref="PulumiStackSettings.ShowName"/></li><li><c>--show-secrets</c> via <see cref="PulumiStackSettings.ShowSecrets"/></li><li><c>--show-urns</c> via <see cref="PulumiStackSettings.ShowUrns"/></li><li><c>--stack</c> via <see cref="PulumiStackSettings.Stack"/></li><li><c>--tracing</c> via <see cref="PulumiStackSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStack(PulumiStackSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackSettings.Profiling"/></li><li><c>--show-ids</c> via <see cref="PulumiStackSettings.ShowIds"/></li><li><c>--show-name</c> via <see cref="PulumiStackSettings.ShowName"/></li><li><c>--show-secrets</c> via <see cref="PulumiStackSettings.ShowSecrets"/></li><li><c>--show-urns</c> via <see cref="PulumiStackSettings.ShowUrns"/></li><li><c>--stack</c> via <see cref="PulumiStackSettings.Stack"/></li><li><c>--tracing</c> via <see cref="PulumiStackSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStack(Configure<PulumiStackSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackSettings.Profiling"/></li><li><c>--show-ids</c> via <see cref="PulumiStackSettings.ShowIds"/></li><li><c>--show-name</c> via <see cref="PulumiStackSettings.ShowName"/></li><li><c>--show-secrets</c> via <see cref="PulumiStackSettings.ShowSecrets"/></li><li><c>--show-urns</c> via <see cref="PulumiStackSettings.ShowUrns"/></li><li><c>--stack</c> via <see cref="PulumiStackSettings.Stack"/></li><li><c>--tracing</c> via <see cref="PulumiStackSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStack(CombinatorialConfigure<PulumiStackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStack, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;newSecretsProvider&gt;</c> via <see cref="PulumiStackChangeSecretsProviderSettings.NewSecretsProvider"/></li><li><c>--color</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackChangeSecretsProviderSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackChangeSecretsProviderSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackChangeSecretsProviderSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackChangeSecretsProvider(PulumiStackChangeSecretsProviderSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;newSecretsProvider&gt;</c> via <see cref="PulumiStackChangeSecretsProviderSettings.NewSecretsProvider"/></li><li><c>--color</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackChangeSecretsProviderSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackChangeSecretsProviderSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackChangeSecretsProviderSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackChangeSecretsProvider(Configure<PulumiStackChangeSecretsProviderSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackChangeSecretsProviderSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;newSecretsProvider&gt;</c> via <see cref="PulumiStackChangeSecretsProviderSettings.NewSecretsProvider"/></li><li><c>--color</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackChangeSecretsProviderSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackChangeSecretsProviderSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackChangeSecretsProviderSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackChangeSecretsProviderSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackChangeSecretsProviderSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackChangeSecretsProvider(CombinatorialConfigure<PulumiStackChangeSecretsProviderSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackChangeSecretsProvider, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackExportSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackExportSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackExportSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackExportSettings.Emoji"/></li><li><c>--file</c> via <see cref="PulumiStackExportSettings.File"/></li><li><c>--logflow</c> via <see cref="PulumiStackExportSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackExportSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackExportSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackExportSettings.Profiling"/></li><li><c>--show-secrets</c> via <see cref="PulumiStackExportSettings.ShowSecrets"/></li><li><c>--tracing</c> via <see cref="PulumiStackExportSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackExportSettings.Verbose"/></li><li><c>--version</c> via <see cref="PulumiStackExportSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackExport(PulumiStackExportSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackExportSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackExportSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackExportSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackExportSettings.Emoji"/></li><li><c>--file</c> via <see cref="PulumiStackExportSettings.File"/></li><li><c>--logflow</c> via <see cref="PulumiStackExportSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackExportSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackExportSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackExportSettings.Profiling"/></li><li><c>--show-secrets</c> via <see cref="PulumiStackExportSettings.ShowSecrets"/></li><li><c>--tracing</c> via <see cref="PulumiStackExportSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackExportSettings.Verbose"/></li><li><c>--version</c> via <see cref="PulumiStackExportSettings.Version"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackExport(Configure<PulumiStackExportSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackExportSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackExportSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackExportSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackExportSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackExportSettings.Emoji"/></li><li><c>--file</c> via <see cref="PulumiStackExportSettings.File"/></li><li><c>--logflow</c> via <see cref="PulumiStackExportSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackExportSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackExportSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackExportSettings.Profiling"/></li><li><c>--show-secrets</c> via <see cref="PulumiStackExportSettings.ShowSecrets"/></li><li><c>--tracing</c> via <see cref="PulumiStackExportSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackExportSettings.Verbose"/></li><li><c>--version</c> via <see cref="PulumiStackExportSettings.Version"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackExportSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackExport(CombinatorialConfigure<PulumiStackExportSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackExport, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;file&gt;</c> via <see cref="PulumiStackGraphSettings.File"/></li><li><c>--color</c> via <see cref="PulumiStackGraphSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackGraphSettings.Cwd"/></li><li><c>--dependency-edge-color</c> via <see cref="PulumiStackGraphSettings.DependencyEdgeColor"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackGraphSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackGraphSettings.Emoji"/></li><li><c>--ignore-dependency-edges</c> via <see cref="PulumiStackGraphSettings.IgnoreDependencyEdges"/></li><li><c>--ignore-parent-edges</c> via <see cref="PulumiStackGraphSettings.IgnoreParentEdges"/></li><li><c>--logflow</c> via <see cref="PulumiStackGraphSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackGraphSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackGraphSettings.NonInteractive"/></li><li><c>--parent-edge-color</c> via <see cref="PulumiStackGraphSettings.ParentEdgeColor"/></li><li><c>--profiling</c> via <see cref="PulumiStackGraphSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackGraphSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackGraphSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackGraph(PulumiStackGraphSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;file&gt;</c> via <see cref="PulumiStackGraphSettings.File"/></li><li><c>--color</c> via <see cref="PulumiStackGraphSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackGraphSettings.Cwd"/></li><li><c>--dependency-edge-color</c> via <see cref="PulumiStackGraphSettings.DependencyEdgeColor"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackGraphSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackGraphSettings.Emoji"/></li><li><c>--ignore-dependency-edges</c> via <see cref="PulumiStackGraphSettings.IgnoreDependencyEdges"/></li><li><c>--ignore-parent-edges</c> via <see cref="PulumiStackGraphSettings.IgnoreParentEdges"/></li><li><c>--logflow</c> via <see cref="PulumiStackGraphSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackGraphSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackGraphSettings.NonInteractive"/></li><li><c>--parent-edge-color</c> via <see cref="PulumiStackGraphSettings.ParentEdgeColor"/></li><li><c>--profiling</c> via <see cref="PulumiStackGraphSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackGraphSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackGraphSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackGraph(Configure<PulumiStackGraphSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackGraphSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;file&gt;</c> via <see cref="PulumiStackGraphSettings.File"/></li><li><c>--color</c> via <see cref="PulumiStackGraphSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackGraphSettings.Cwd"/></li><li><c>--dependency-edge-color</c> via <see cref="PulumiStackGraphSettings.DependencyEdgeColor"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackGraphSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackGraphSettings.Emoji"/></li><li><c>--ignore-dependency-edges</c> via <see cref="PulumiStackGraphSettings.IgnoreDependencyEdges"/></li><li><c>--ignore-parent-edges</c> via <see cref="PulumiStackGraphSettings.IgnoreParentEdges"/></li><li><c>--logflow</c> via <see cref="PulumiStackGraphSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackGraphSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackGraphSettings.NonInteractive"/></li><li><c>--parent-edge-color</c> via <see cref="PulumiStackGraphSettings.ParentEdgeColor"/></li><li><c>--profiling</c> via <see cref="PulumiStackGraphSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackGraphSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackGraphSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackGraphSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackGraph(CombinatorialConfigure<PulumiStackGraphSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackGraph, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackHistorySettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackHistorySettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackHistorySettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackHistorySettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiStackHistorySettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiStackHistorySettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackHistorySettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackHistorySettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackHistorySettings.Profiling"/></li><li><c>--show-secrets</c> via <see cref="PulumiStackHistorySettings.ShowSecrets"/></li><li><c>--tracing</c> via <see cref="PulumiStackHistorySettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackHistorySettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackHistory(PulumiStackHistorySettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackHistorySettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackHistorySettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackHistorySettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackHistorySettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiStackHistorySettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiStackHistorySettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackHistorySettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackHistorySettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackHistorySettings.Profiling"/></li><li><c>--show-secrets</c> via <see cref="PulumiStackHistorySettings.ShowSecrets"/></li><li><c>--tracing</c> via <see cref="PulumiStackHistorySettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackHistorySettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackHistory(Configure<PulumiStackHistorySettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackHistorySettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackHistorySettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackHistorySettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackHistorySettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackHistorySettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiStackHistorySettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiStackHistorySettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackHistorySettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackHistorySettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackHistorySettings.Profiling"/></li><li><c>--show-secrets</c> via <see cref="PulumiStackHistorySettings.ShowSecrets"/></li><li><c>--tracing</c> via <see cref="PulumiStackHistorySettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackHistorySettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackHistorySettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackHistory(CombinatorialConfigure<PulumiStackHistorySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackHistory, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackImportSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackImportSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackImportSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackImportSettings.Emoji"/></li><li><c>--file</c> via <see cref="PulumiStackImportSettings.File"/></li><li><c>--force</c> via <see cref="PulumiStackImportSettings.Force"/></li><li><c>--logflow</c> via <see cref="PulumiStackImportSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackImportSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackImportSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackImportSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackImportSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackImportSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackImport(PulumiStackImportSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackImportSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackImportSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackImportSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackImportSettings.Emoji"/></li><li><c>--file</c> via <see cref="PulumiStackImportSettings.File"/></li><li><c>--force</c> via <see cref="PulumiStackImportSettings.Force"/></li><li><c>--logflow</c> via <see cref="PulumiStackImportSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackImportSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackImportSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackImportSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackImportSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackImportSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackImport(Configure<PulumiStackImportSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackImportSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackImportSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackImportSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackImportSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackImportSettings.Emoji"/></li><li><c>--file</c> via <see cref="PulumiStackImportSettings.File"/></li><li><c>--force</c> via <see cref="PulumiStackImportSettings.Force"/></li><li><c>--logflow</c> via <see cref="PulumiStackImportSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackImportSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackImportSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackImportSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackImportSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackImportSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackImportSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackImport(CombinatorialConfigure<PulumiStackImportSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackImport, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;organizationAndName&gt;</c> via <see cref="PulumiStackInitSettings.OrganizationAndName"/></li><li><c>--color</c> via <see cref="PulumiStackInitSettings.Color"/></li><li><c>--copy-config-from</c> via <see cref="PulumiStackInitSettings.CopyConfigFrom"/></li><li><c>--cwd</c> via <see cref="PulumiStackInitSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackInitSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackInitSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackInitSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackInitSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackInitSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackInitSettings.Profiling"/></li><li><c>--secrets-provider</c> via <see cref="PulumiStackInitSettings.SecretsProvider"/></li><li><c>--tracing</c> via <see cref="PulumiStackInitSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackInitSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackInit(PulumiStackInitSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;organizationAndName&gt;</c> via <see cref="PulumiStackInitSettings.OrganizationAndName"/></li><li><c>--color</c> via <see cref="PulumiStackInitSettings.Color"/></li><li><c>--copy-config-from</c> via <see cref="PulumiStackInitSettings.CopyConfigFrom"/></li><li><c>--cwd</c> via <see cref="PulumiStackInitSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackInitSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackInitSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackInitSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackInitSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackInitSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackInitSettings.Profiling"/></li><li><c>--secrets-provider</c> via <see cref="PulumiStackInitSettings.SecretsProvider"/></li><li><c>--tracing</c> via <see cref="PulumiStackInitSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackInitSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackInit(Configure<PulumiStackInitSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackInitSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;organizationAndName&gt;</c> via <see cref="PulumiStackInitSettings.OrganizationAndName"/></li><li><c>--color</c> via <see cref="PulumiStackInitSettings.Color"/></li><li><c>--copy-config-from</c> via <see cref="PulumiStackInitSettings.CopyConfigFrom"/></li><li><c>--cwd</c> via <see cref="PulumiStackInitSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackInitSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackInitSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackInitSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackInitSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackInitSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackInitSettings.Profiling"/></li><li><c>--secrets-provider</c> via <see cref="PulumiStackInitSettings.SecretsProvider"/></li><li><c>--tracing</c> via <see cref="PulumiStackInitSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackInitSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackInitSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackInit(CombinatorialConfigure<PulumiStackInitSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackInit, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--all</c> via <see cref="PulumiStackListSettings.All"/></li><li><c>--color</c> via <see cref="PulumiStackListSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackListSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackListSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackListSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiStackListSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiStackListSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackListSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackListSettings.NonInteractive"/></li><li><c>--organization</c> via <see cref="PulumiStackListSettings.Organization"/></li><li><c>--profiling</c> via <see cref="PulumiStackListSettings.Profiling"/></li><li><c>--project</c> via <see cref="PulumiStackListSettings.Project"/></li><li><c>--tag</c> via <see cref="PulumiStackListSettings.Tag"/></li><li><c>--tracing</c> via <see cref="PulumiStackListSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackListSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackList(PulumiStackListSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--all</c> via <see cref="PulumiStackListSettings.All"/></li><li><c>--color</c> via <see cref="PulumiStackListSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackListSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackListSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackListSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiStackListSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiStackListSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackListSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackListSettings.NonInteractive"/></li><li><c>--organization</c> via <see cref="PulumiStackListSettings.Organization"/></li><li><c>--profiling</c> via <see cref="PulumiStackListSettings.Profiling"/></li><li><c>--project</c> via <see cref="PulumiStackListSettings.Project"/></li><li><c>--tag</c> via <see cref="PulumiStackListSettings.Tag"/></li><li><c>--tracing</c> via <see cref="PulumiStackListSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackListSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackList(Configure<PulumiStackListSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackListSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--all</c> via <see cref="PulumiStackListSettings.All"/></li><li><c>--color</c> via <see cref="PulumiStackListSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackListSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackListSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackListSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiStackListSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiStackListSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackListSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackListSettings.NonInteractive"/></li><li><c>--organization</c> via <see cref="PulumiStackListSettings.Organization"/></li><li><c>--profiling</c> via <see cref="PulumiStackListSettings.Profiling"/></li><li><c>--project</c> via <see cref="PulumiStackListSettings.Project"/></li><li><c>--tag</c> via <see cref="PulumiStackListSettings.Tag"/></li><li><c>--tracing</c> via <see cref="PulumiStackListSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackListSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackListSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackList(CombinatorialConfigure<PulumiStackListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackList, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;propertyName&gt;</c> via <see cref="PulumiStackOutputSettings.PropertyName"/></li><li><c>--color</c> via <see cref="PulumiStackOutputSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackOutputSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackOutputSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackOutputSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiStackOutputSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiStackOutputSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackOutputSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackOutputSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackOutputSettings.Profiling"/></li><li><c>--show-secrets</c> via <see cref="PulumiStackOutputSettings.ShowSecrets"/></li><li><c>--tracing</c> via <see cref="PulumiStackOutputSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackOutputSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackOutput(PulumiStackOutputSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;propertyName&gt;</c> via <see cref="PulumiStackOutputSettings.PropertyName"/></li><li><c>--color</c> via <see cref="PulumiStackOutputSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackOutputSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackOutputSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackOutputSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiStackOutputSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiStackOutputSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackOutputSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackOutputSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackOutputSettings.Profiling"/></li><li><c>--show-secrets</c> via <see cref="PulumiStackOutputSettings.ShowSecrets"/></li><li><c>--tracing</c> via <see cref="PulumiStackOutputSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackOutputSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackOutput(Configure<PulumiStackOutputSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackOutputSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;propertyName&gt;</c> via <see cref="PulumiStackOutputSettings.PropertyName"/></li><li><c>--color</c> via <see cref="PulumiStackOutputSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackOutputSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackOutputSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackOutputSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiStackOutputSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiStackOutputSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackOutputSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackOutputSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackOutputSettings.Profiling"/></li><li><c>--show-secrets</c> via <see cref="PulumiStackOutputSettings.ShowSecrets"/></li><li><c>--tracing</c> via <see cref="PulumiStackOutputSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackOutputSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackOutputSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackOutput(CombinatorialConfigure<PulumiStackOutputSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackOutput, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;newStackName&gt;</c> via <see cref="PulumiStackRenameSettings.NewStackName"/></li><li><c>--color</c> via <see cref="PulumiStackRenameSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackRenameSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackRenameSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackRenameSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackRenameSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackRenameSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackRenameSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackRenameSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackRenameSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackRenameSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackRename(PulumiStackRenameSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;newStackName&gt;</c> via <see cref="PulumiStackRenameSettings.NewStackName"/></li><li><c>--color</c> via <see cref="PulumiStackRenameSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackRenameSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackRenameSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackRenameSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackRenameSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackRenameSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackRenameSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackRenameSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackRenameSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackRenameSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackRename(Configure<PulumiStackRenameSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackRenameSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;newStackName&gt;</c> via <see cref="PulumiStackRenameSettings.NewStackName"/></li><li><c>--color</c> via <see cref="PulumiStackRenameSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackRenameSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackRenameSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackRenameSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackRenameSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackRenameSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackRenameSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackRenameSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackRenameSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackRenameSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackRenameSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackRename(CombinatorialConfigure<PulumiStackRenameSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackRename, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;stackName&gt;</c> via <see cref="PulumiStackRemoveSettings.StackName"/></li><li><c>--color</c> via <see cref="PulumiStackRemoveSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackRemoveSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackRemoveSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackRemoveSettings.Emoji"/></li><li><c>--force</c> via <see cref="PulumiStackRemoveSettings.Force"/></li><li><c>--logflow</c> via <see cref="PulumiStackRemoveSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackRemoveSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackRemoveSettings.NonInteractive"/></li><li><c>--preserve-config</c> via <see cref="PulumiStackRemoveSettings.PreserveConfig"/></li><li><c>--profiling</c> via <see cref="PulumiStackRemoveSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackRemoveSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackRemoveSettings.Verbose"/></li><li><c>--yes</c> via <see cref="PulumiStackRemoveSettings.Yes"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackRemove(PulumiStackRemoveSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;stackName&gt;</c> via <see cref="PulumiStackRemoveSettings.StackName"/></li><li><c>--color</c> via <see cref="PulumiStackRemoveSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackRemoveSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackRemoveSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackRemoveSettings.Emoji"/></li><li><c>--force</c> via <see cref="PulumiStackRemoveSettings.Force"/></li><li><c>--logflow</c> via <see cref="PulumiStackRemoveSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackRemoveSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackRemoveSettings.NonInteractive"/></li><li><c>--preserve-config</c> via <see cref="PulumiStackRemoveSettings.PreserveConfig"/></li><li><c>--profiling</c> via <see cref="PulumiStackRemoveSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackRemoveSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackRemoveSettings.Verbose"/></li><li><c>--yes</c> via <see cref="PulumiStackRemoveSettings.Yes"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackRemove(Configure<PulumiStackRemoveSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackRemoveSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;stackName&gt;</c> via <see cref="PulumiStackRemoveSettings.StackName"/></li><li><c>--color</c> via <see cref="PulumiStackRemoveSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackRemoveSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackRemoveSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackRemoveSettings.Emoji"/></li><li><c>--force</c> via <see cref="PulumiStackRemoveSettings.Force"/></li><li><c>--logflow</c> via <see cref="PulumiStackRemoveSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackRemoveSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackRemoveSettings.NonInteractive"/></li><li><c>--preserve-config</c> via <see cref="PulumiStackRemoveSettings.PreserveConfig"/></li><li><c>--profiling</c> via <see cref="PulumiStackRemoveSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackRemoveSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackRemoveSettings.Verbose"/></li><li><c>--yes</c> via <see cref="PulumiStackRemoveSettings.Yes"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackRemoveSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackRemove(CombinatorialConfigure<PulumiStackRemoveSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackRemove, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;stackName&gt;</c> via <see cref="PulumiStackSelectSettings.StackName"/></li><li><c>--color</c> via <see cref="PulumiStackSelectSettings.Color"/></li><li><c>--create</c> via <see cref="PulumiStackSelectSettings.Create"/></li><li><c>--cwd</c> via <see cref="PulumiStackSelectSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackSelectSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackSelectSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackSelectSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackSelectSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackSelectSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackSelectSettings.Profiling"/></li><li><c>--secrets-provider</c> via <see cref="PulumiStackSelectSettings.SecretsProvider"/></li><li><c>--tracing</c> via <see cref="PulumiStackSelectSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackSelectSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackSelect(PulumiStackSelectSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;stackName&gt;</c> via <see cref="PulumiStackSelectSettings.StackName"/></li><li><c>--color</c> via <see cref="PulumiStackSelectSettings.Color"/></li><li><c>--create</c> via <see cref="PulumiStackSelectSettings.Create"/></li><li><c>--cwd</c> via <see cref="PulumiStackSelectSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackSelectSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackSelectSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackSelectSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackSelectSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackSelectSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackSelectSettings.Profiling"/></li><li><c>--secrets-provider</c> via <see cref="PulumiStackSelectSettings.SecretsProvider"/></li><li><c>--tracing</c> via <see cref="PulumiStackSelectSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackSelectSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackSelect(Configure<PulumiStackSelectSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackSelectSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;stackName&gt;</c> via <see cref="PulumiStackSelectSettings.StackName"/></li><li><c>--color</c> via <see cref="PulumiStackSelectSettings.Color"/></li><li><c>--create</c> via <see cref="PulumiStackSelectSettings.Create"/></li><li><c>--cwd</c> via <see cref="PulumiStackSelectSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackSelectSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackSelectSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackSelectSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackSelectSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackSelectSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackSelectSettings.Profiling"/></li><li><c>--secrets-provider</c> via <see cref="PulumiStackSelectSettings.SecretsProvider"/></li><li><c>--tracing</c> via <see cref="PulumiStackSelectSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackSelectSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackSelectSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackSelect(CombinatorialConfigure<PulumiStackSelectSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackSelect, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="PulumiStackTagSetSettings.Name"/></li><li><c>&lt;value&gt;</c> via <see cref="PulumiStackTagSetSettings.Value"/></li><li><c>--color</c> via <see cref="PulumiStackTagSetSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackTagSetSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackTagSetSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackTagSetSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackTagSetSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackTagSetSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackTagSetSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackTagSetSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackTagSetSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackTagSetSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackTagSet(PulumiStackTagSetSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="PulumiStackTagSetSettings.Name"/></li><li><c>&lt;value&gt;</c> via <see cref="PulumiStackTagSetSettings.Value"/></li><li><c>--color</c> via <see cref="PulumiStackTagSetSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackTagSetSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackTagSetSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackTagSetSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackTagSetSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackTagSetSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackTagSetSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackTagSetSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackTagSetSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackTagSetSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackTagSet(Configure<PulumiStackTagSetSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackTagSetSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="PulumiStackTagSetSettings.Name"/></li><li><c>&lt;value&gt;</c> via <see cref="PulumiStackTagSetSettings.Value"/></li><li><c>--color</c> via <see cref="PulumiStackTagSetSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackTagSetSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackTagSetSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackTagSetSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackTagSetSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackTagSetSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackTagSetSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackTagSetSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackTagSetSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackTagSetSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackTagSetSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackTagSet(CombinatorialConfigure<PulumiStackTagSetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackTagSet, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="PulumiStackTagGetSettings.Name"/></li><li><c>--color</c> via <see cref="PulumiStackTagGetSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackTagGetSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackTagGetSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackTagGetSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackTagGetSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackTagGetSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackTagGetSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackTagGetSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackTagGetSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackTagGetSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackTagGet(PulumiStackTagGetSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="PulumiStackTagGetSettings.Name"/></li><li><c>--color</c> via <see cref="PulumiStackTagGetSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackTagGetSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackTagGetSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackTagGetSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackTagGetSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackTagGetSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackTagGetSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackTagGetSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackTagGetSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackTagGetSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackTagGet(Configure<PulumiStackTagGetSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackTagGetSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="PulumiStackTagGetSettings.Name"/></li><li><c>--color</c> via <see cref="PulumiStackTagGetSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackTagGetSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackTagGetSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackTagGetSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackTagGetSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackTagGetSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackTagGetSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackTagGetSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackTagGetSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackTagGetSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackTagGetSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackTagGet(CombinatorialConfigure<PulumiStackTagGetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackTagGet, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="PulumiStackTagRemoveSettings.Name"/></li><li><c>--color</c> via <see cref="PulumiStackTagRemoveSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackTagRemoveSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackTagRemoveSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackTagRemoveSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackTagRemoveSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackTagRemoveSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackTagRemoveSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackTagRemoveSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackTagRemoveSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackTagRemoveSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackTagRemove(PulumiStackTagRemoveSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="PulumiStackTagRemoveSettings.Name"/></li><li><c>--color</c> via <see cref="PulumiStackTagRemoveSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackTagRemoveSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackTagRemoveSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackTagRemoveSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackTagRemoveSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackTagRemoveSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackTagRemoveSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackTagRemoveSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackTagRemoveSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackTagRemoveSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackTagRemove(Configure<PulumiStackTagRemoveSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackTagRemoveSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;name&gt;</c> via <see cref="PulumiStackTagRemoveSettings.Name"/></li><li><c>--color</c> via <see cref="PulumiStackTagRemoveSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackTagRemoveSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackTagRemoveSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackTagRemoveSettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiStackTagRemoveSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackTagRemoveSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackTagRemoveSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackTagRemoveSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackTagRemoveSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackTagRemoveSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackTagRemoveSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackTagRemove(CombinatorialConfigure<PulumiStackTagRemoveSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackTagRemove, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackTagListSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackTagListSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackTagListSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackTagListSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiStackTagListSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiStackTagListSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackTagListSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackTagListSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackTagListSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackTagListSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackTagListSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackTagList(PulumiStackTagListSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackTagListSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackTagListSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackTagListSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackTagListSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiStackTagListSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiStackTagListSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackTagListSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackTagListSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackTagListSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackTagListSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackTagListSettings.Verbose"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiStackTagList(Configure<PulumiStackTagListSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiStackTagListSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiStackTagListSettings.Color"/></li><li><c>--cwd</c> via <see cref="PulumiStackTagListSettings.Cwd"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiStackTagListSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiStackTagListSettings.Emoji"/></li><li><c>--json</c> via <see cref="PulumiStackTagListSettings.Json"/></li><li><c>--logflow</c> via <see cref="PulumiStackTagListSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiStackTagListSettings.LogToStderr"/></li><li><c>--non-interactive</c> via <see cref="PulumiStackTagListSettings.NonInteractive"/></li><li><c>--profiling</c> via <see cref="PulumiStackTagListSettings.Profiling"/></li><li><c>--tracing</c> via <see cref="PulumiStackTagListSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiStackTagListSettings.Verbose"/></li></ul></remarks>
    public static IEnumerable<(PulumiStackTagListSettings Settings, IReadOnlyCollection<Output> Output)> PulumiStackTagList(CombinatorialConfigure<PulumiStackTagListSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiStackTagList, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;template&gt;</c> via <see cref="PulumiNewSettings.Template"/></li><li><c>--color</c> via <see cref="PulumiNewSettings.Color"/></li><li><c>--config</c> via <see cref="PulumiNewSettings.Config"/></li><li><c>--config-path</c> via <see cref="PulumiNewSettings.ConfigPath"/></li><li><c>--cwd</c> via <see cref="PulumiNewSettings.Cwd"/></li><li><c>--description</c> via <see cref="PulumiNewSettings.Description"/></li><li><c>--dir</c> via <see cref="PulumiNewSettings.Directory"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiNewSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiNewSettings.Emoji"/></li><li><c>--force</c> via <see cref="PulumiNewSettings.Force"/></li><li><c>--generate-only</c> via <see cref="PulumiNewSettings.GenerateOnly"/></li><li><c>--logflow</c> via <see cref="PulumiNewSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiNewSettings.LogToStderr"/></li><li><c>--name</c> via <see cref="PulumiNewSettings.Name"/></li><li><c>--non-interactive</c> via <see cref="PulumiNewSettings.NonInteractive"/></li><li><c>--offline</c> via <see cref="PulumiNewSettings.Offline"/></li><li><c>--profiling</c> via <see cref="PulumiNewSettings.Profiling"/></li><li><c>--secrets-provider</c> via <see cref="PulumiNewSettings.SecretsProvider"/></li><li><c>--stack</c> via <see cref="PulumiNewSettings.Stack"/></li><li><c>--tracing</c> via <see cref="PulumiNewSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiNewSettings.Verbose"/></li><li><c>--yes</c> via <see cref="PulumiNewSettings.Yes"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiNew(PulumiNewSettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;template&gt;</c> via <see cref="PulumiNewSettings.Template"/></li><li><c>--color</c> via <see cref="PulumiNewSettings.Color"/></li><li><c>--config</c> via <see cref="PulumiNewSettings.Config"/></li><li><c>--config-path</c> via <see cref="PulumiNewSettings.ConfigPath"/></li><li><c>--cwd</c> via <see cref="PulumiNewSettings.Cwd"/></li><li><c>--description</c> via <see cref="PulumiNewSettings.Description"/></li><li><c>--dir</c> via <see cref="PulumiNewSettings.Directory"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiNewSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiNewSettings.Emoji"/></li><li><c>--force</c> via <see cref="PulumiNewSettings.Force"/></li><li><c>--generate-only</c> via <see cref="PulumiNewSettings.GenerateOnly"/></li><li><c>--logflow</c> via <see cref="PulumiNewSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiNewSettings.LogToStderr"/></li><li><c>--name</c> via <see cref="PulumiNewSettings.Name"/></li><li><c>--non-interactive</c> via <see cref="PulumiNewSettings.NonInteractive"/></li><li><c>--offline</c> via <see cref="PulumiNewSettings.Offline"/></li><li><c>--profiling</c> via <see cref="PulumiNewSettings.Profiling"/></li><li><c>--secrets-provider</c> via <see cref="PulumiNewSettings.SecretsProvider"/></li><li><c>--stack</c> via <see cref="PulumiNewSettings.Stack"/></li><li><c>--tracing</c> via <see cref="PulumiNewSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiNewSettings.Verbose"/></li><li><c>--yes</c> via <see cref="PulumiNewSettings.Yes"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiNew(Configure<PulumiNewSettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiNewSettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>&lt;template&gt;</c> via <see cref="PulumiNewSettings.Template"/></li><li><c>--color</c> via <see cref="PulumiNewSettings.Color"/></li><li><c>--config</c> via <see cref="PulumiNewSettings.Config"/></li><li><c>--config-path</c> via <see cref="PulumiNewSettings.ConfigPath"/></li><li><c>--cwd</c> via <see cref="PulumiNewSettings.Cwd"/></li><li><c>--description</c> via <see cref="PulumiNewSettings.Description"/></li><li><c>--dir</c> via <see cref="PulumiNewSettings.Directory"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiNewSettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiNewSettings.Emoji"/></li><li><c>--force</c> via <see cref="PulumiNewSettings.Force"/></li><li><c>--generate-only</c> via <see cref="PulumiNewSettings.GenerateOnly"/></li><li><c>--logflow</c> via <see cref="PulumiNewSettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiNewSettings.LogToStderr"/></li><li><c>--name</c> via <see cref="PulumiNewSettings.Name"/></li><li><c>--non-interactive</c> via <see cref="PulumiNewSettings.NonInteractive"/></li><li><c>--offline</c> via <see cref="PulumiNewSettings.Offline"/></li><li><c>--profiling</c> via <see cref="PulumiNewSettings.Profiling"/></li><li><c>--secrets-provider</c> via <see cref="PulumiNewSettings.SecretsProvider"/></li><li><c>--stack</c> via <see cref="PulumiNewSettings.Stack"/></li><li><c>--tracing</c> via <see cref="PulumiNewSettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiNewSettings.Verbose"/></li><li><c>--yes</c> via <see cref="PulumiNewSettings.Yes"/></li></ul></remarks>
    public static IEnumerable<(PulumiNewSettings Settings, IReadOnlyCollection<Output> Output)> PulumiNew(CombinatorialConfigure<PulumiNewSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiNew, degreeOfParallelism, completeOnFailure);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiDestroySettings.Color"/></li><li><c>--config-file</c> via <see cref="PulumiDestroySettings.ConfigFile"/></li><li><c>--cwd</c> via <see cref="PulumiDestroySettings.Cwd"/></li><li><c>--debug</c> via <see cref="PulumiDestroySettings.Debug"/></li><li><c>--diff</c> via <see cref="PulumiDestroySettings.Diff"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiDestroySettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiDestroySettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiDestroySettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiDestroySettings.LogToStderr"/></li><li><c>--message</c> via <see cref="PulumiDestroySettings.Message"/></li><li><c>--non-interactive</c> via <see cref="PulumiDestroySettings.NonInteractive"/></li><li><c>--parallel</c> via <see cref="PulumiDestroySettings.Parallel"/></li><li><c>--profiling</c> via <see cref="PulumiDestroySettings.Profiling"/></li><li><c>--refresh</c> via <see cref="PulumiDestroySettings.Refresh"/></li><li><c>--show-config</c> via <see cref="PulumiDestroySettings.ShowConfig"/></li><li><c>--show-replacement-steps</c> via <see cref="PulumiDestroySettings.ShowReplacementSteps"/></li><li><c>--show-sames</c> via <see cref="PulumiDestroySettings.ShowSames"/></li><li><c>--skip-preview</c> via <see cref="PulumiDestroySettings.SkipPreview"/></li><li><c>--stack</c> via <see cref="PulumiDestroySettings.Stack"/></li><li><c>--suppress-outputs</c> via <see cref="PulumiDestroySettings.SuppressOutputs"/></li><li><c>--suppress-permalink</c> via <see cref="PulumiDestroySettings.SuppressPermalink"/></li><li><c>--target</c> via <see cref="PulumiDestroySettings.Target"/></li><li><c>--target-dependents</c> via <see cref="PulumiDestroySettings.TargetDependents"/></li><li><c>--tracing</c> via <see cref="PulumiDestroySettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiDestroySettings.Verbose"/></li><li><c>--yes</c> via <see cref="PulumiDestroySettings.Yes"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiDestroy(PulumiDestroySettings options = null) => new PulumiTasks().Run(options);
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiDestroySettings.Color"/></li><li><c>--config-file</c> via <see cref="PulumiDestroySettings.ConfigFile"/></li><li><c>--cwd</c> via <see cref="PulumiDestroySettings.Cwd"/></li><li><c>--debug</c> via <see cref="PulumiDestroySettings.Debug"/></li><li><c>--diff</c> via <see cref="PulumiDestroySettings.Diff"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiDestroySettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiDestroySettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiDestroySettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiDestroySettings.LogToStderr"/></li><li><c>--message</c> via <see cref="PulumiDestroySettings.Message"/></li><li><c>--non-interactive</c> via <see cref="PulumiDestroySettings.NonInteractive"/></li><li><c>--parallel</c> via <see cref="PulumiDestroySettings.Parallel"/></li><li><c>--profiling</c> via <see cref="PulumiDestroySettings.Profiling"/></li><li><c>--refresh</c> via <see cref="PulumiDestroySettings.Refresh"/></li><li><c>--show-config</c> via <see cref="PulumiDestroySettings.ShowConfig"/></li><li><c>--show-replacement-steps</c> via <see cref="PulumiDestroySettings.ShowReplacementSteps"/></li><li><c>--show-sames</c> via <see cref="PulumiDestroySettings.ShowSames"/></li><li><c>--skip-preview</c> via <see cref="PulumiDestroySettings.SkipPreview"/></li><li><c>--stack</c> via <see cref="PulumiDestroySettings.Stack"/></li><li><c>--suppress-outputs</c> via <see cref="PulumiDestroySettings.SuppressOutputs"/></li><li><c>--suppress-permalink</c> via <see cref="PulumiDestroySettings.SuppressPermalink"/></li><li><c>--target</c> via <see cref="PulumiDestroySettings.Target"/></li><li><c>--target-dependents</c> via <see cref="PulumiDestroySettings.TargetDependents"/></li><li><c>--tracing</c> via <see cref="PulumiDestroySettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiDestroySettings.Verbose"/></li><li><c>--yes</c> via <see cref="PulumiDestroySettings.Yes"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> PulumiDestroy(Configure<PulumiDestroySettings> configurator) => new PulumiTasks().Run(configurator.Invoke(new PulumiDestroySettings()));
    /// <summary><p>Pulumi is an <a href="https://github.com/pulumi/pulumi">open source</a> infrastructure as code tool for creating, deploying and managing cloud infrastructure. Pulumi works with traditional infrastructure like VMs, networks, and databases, in addition to modern architectures, including containers, Kubernetes clusters, and serverless functions. Pulumi supports dozens of public, private, and hybrid cloud service providers.</p><p>For more details, visit the <a href="https://www.pulumi.com/">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--color</c> via <see cref="PulumiDestroySettings.Color"/></li><li><c>--config-file</c> via <see cref="PulumiDestroySettings.ConfigFile"/></li><li><c>--cwd</c> via <see cref="PulumiDestroySettings.Cwd"/></li><li><c>--debug</c> via <see cref="PulumiDestroySettings.Debug"/></li><li><c>--diff</c> via <see cref="PulumiDestroySettings.Diff"/></li><li><c>--disable-integrity-checking</c> via <see cref="PulumiDestroySettings.DisableIntegrityChecking"/></li><li><c>--emoji</c> via <see cref="PulumiDestroySettings.Emoji"/></li><li><c>--logflow</c> via <see cref="PulumiDestroySettings.LogFlow"/></li><li><c>--logtostderr</c> via <see cref="PulumiDestroySettings.LogToStderr"/></li><li><c>--message</c> via <see cref="PulumiDestroySettings.Message"/></li><li><c>--non-interactive</c> via <see cref="PulumiDestroySettings.NonInteractive"/></li><li><c>--parallel</c> via <see cref="PulumiDestroySettings.Parallel"/></li><li><c>--profiling</c> via <see cref="PulumiDestroySettings.Profiling"/></li><li><c>--refresh</c> via <see cref="PulumiDestroySettings.Refresh"/></li><li><c>--show-config</c> via <see cref="PulumiDestroySettings.ShowConfig"/></li><li><c>--show-replacement-steps</c> via <see cref="PulumiDestroySettings.ShowReplacementSteps"/></li><li><c>--show-sames</c> via <see cref="PulumiDestroySettings.ShowSames"/></li><li><c>--skip-preview</c> via <see cref="PulumiDestroySettings.SkipPreview"/></li><li><c>--stack</c> via <see cref="PulumiDestroySettings.Stack"/></li><li><c>--suppress-outputs</c> via <see cref="PulumiDestroySettings.SuppressOutputs"/></li><li><c>--suppress-permalink</c> via <see cref="PulumiDestroySettings.SuppressPermalink"/></li><li><c>--target</c> via <see cref="PulumiDestroySettings.Target"/></li><li><c>--target-dependents</c> via <see cref="PulumiDestroySettings.TargetDependents"/></li><li><c>--tracing</c> via <see cref="PulumiDestroySettings.Tracing"/></li><li><c>--verbose</c> via <see cref="PulumiDestroySettings.Verbose"/></li><li><c>--yes</c> via <see cref="PulumiDestroySettings.Yes"/></li></ul></remarks>
    public static IEnumerable<(PulumiDestroySettings Settings, IReadOnlyCollection<Output> Output)> PulumiDestroy(CombinatorialConfigure<PulumiDestroySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(PulumiDestroy, degreeOfParallelism, completeOnFailure);
}
#region PulumiUpSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiUpSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiUp), Arguments = "up")]
public partial class PulumiUpSettings : ToolOptions
{
    /// <summary>Config to use during the update.</summary>
    [Argument(Format = "--config {value}")] public IReadOnlyList<string> Config => Get<List<string>>(() => Config);
    /// <summary>Use the configuration values in the specified file rather than detecting the file name.</summary>
    [Argument(Format = "--config-file {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>Config keys contain a path to a property in a map or list to set.</summary>
    [Argument(Format = "--config-path")] public bool? ConfigPath => Get<bool?>(() => ConfigPath);
    /// <summary>Print detailed debugging output during resource operations.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Display operation as a rich diff showing the overall change.</summary>
    [Argument(Format = "--diff")] public bool? Diff => Get<bool?>(() => Diff);
    /// <summary>Return an error if any changes occur during this update.</summary>
    [Argument(Format = "--expect-no-changes")] public bool? ExpectNoChanges => Get<bool?>(() => ExpectNoChanges);
    /// <summary>Optional message to associate with the update operation.</summary>
    [Argument(Format = "--message {value}")] public string Message => Get<string>(() => Message);
    /// <summary>Allow P resource operations to run in parallel at once (1 for no parallelism). Defaults to unbounded. (default <c>2147483647</c>).</summary>
    [Argument(Format = "--parallel {value}")] public int? Parallel => Get<int?>(() => Parallel);
    /// <summary>Run one or more policy packs as part of this update.</summary>
    [Argument(Format = "--policy-pack {value}")] public IReadOnlyList<string> PolicyPack => Get<List<string>>(() => PolicyPack);
    /// <summary>Path to JSON file containing the config for the policy pack of the corresponding <c>--policy-pack</c> flag.</summary>
    [Argument(Format = "--policy-pack-config {value}")] public IReadOnlyList<string> PolicyPackConfig => Get<List<string>>(() => PolicyPackConfig);
    /// <summary>Refresh the state of the stack's resources before this update.</summary>
    [Argument(Format = "--refresh")] public bool? Refresh => Get<bool?>(() => Refresh);
    /// <summary>Specify resources to replace. Multiple resources can be specified using <c>--replace urn1 --replace urn2</c>.</summary>
    [Argument(Format = "--replace {value}")] public IReadOnlyList<string> Replace => Get<List<string>>(() => Replace);
    /// <summary>The type of the provider that should be used to encrypt and decrypt secrets (possible choices: <c>default</c>, <c>passphrase</c>, <c>awskms</c>, <c>azurekeyvault</c>, <c>gcpkms</c>, <c>hashivault</c>). Only used when creating a new stack from an existing template (default <c>default</c>).</summary>
    [Argument(Format = "--secrets-provider {value}")] public PulumiSecretsProvider SecretsProvider => Get<PulumiSecretsProvider>(() => SecretsProvider);
    /// <summary>Show configuration keys and variables.</summary>
    [Argument(Format = "--show-config")] public bool? ShowConfig => Get<bool?>(() => ShowConfig);
    /// <summary>Show resources that are being read in, alongside those being managed directly in the stack.</summary>
    [Argument(Format = "--show-reads")] public bool? ShowReads => Get<bool?>(() => ShowReads);
    /// <summary>Show detailed resource replacement creates and deletes instead of a single step.</summary>
    [Argument(Format = "--show-replacement-steps")] public bool? ShowReplacementSteps => Get<bool?>(() => ShowReplacementSteps);
    /// <summary>Show resources that don't need be updated because they haven't changed, alongside those that do.</summary>
    [Argument(Format = "--show-sames")] public bool? ShowSames => Get<bool?>(() => ShowSames);
    /// <summary>Do not perform a preview before performing the update.</summary>
    [Argument(Format = "--skip-preview")] public bool? SkipPreview => Get<bool?>(() => SkipPreview);
    /// <summary>The name of the stack to operate on. Defaults to the current stack.</summary>
    [Argument(Format = "--stack {value}")] public string Stack => Get<string>(() => Stack);
    /// <summary>Suppress display of stack outputs (in case they contain sensitive values).</summary>
    [Argument(Format = "--suppress-outputs")] public bool? SuppressOutputs => Get<bool?>(() => SuppressOutputs);
    /// <summary>Suppress display of the state permalink.</summary>
    [Argument(Format = "--suppress-permalink")] public bool? SuppressPermalink => Get<bool?>(() => SuppressPermalink);
    /// <summary>Specify a single resource URN to update. Other resources will not be updated. Multiple resources can be specified using <c>--target urn1 --target urn2</c>.</summary>
    [Argument(Format = "--target {value}")] public IReadOnlyList<string> Target => Get<List<string>>(() => Target);
    /// <summary>Allows updating of dependent targets discovered but not specified in <c>--target</c> list.</summary>
    [Argument(Format = "--target-dependents")] public bool? TargetDependents => Get<bool?>(() => TargetDependents);
    /// <summary>Specify a single resource URN to replace. Other resources will not be updated. Shorthand for <c>--target urn --replace urn</c>.</summary>
    [Argument(Format = "--target-replace {value}")] public IReadOnlyList<string> TargetReplace => Get<List<string>>(() => TargetReplace);
    /// <summary>Automatically approve and perform the update after previewing it.</summary>
    [Argument(Format = "--yes")] public bool? Yes => Get<bool?>(() => Yes);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiPreviewSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiPreviewSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiPreview), Arguments = "preview")]
public partial class PulumiPreviewSettings : ToolOptions
{
    /// <summary>Config to use during the update.</summary>
    [Argument(Format = "--config {value}")] public IReadOnlyList<string> Config => Get<List<string>>(() => Config);
    /// <summary>Use the configuration values in the specified file rather than detecting the file name.</summary>
    [Argument(Format = "--config-file {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>Config keys contain a path to a property in a map or list to set.</summary>
    [Argument(Format = "--config-path")] public bool? ConfigPath => Get<bool?>(() => ConfigPath);
    /// <summary>Print detailed debugging output during resource operations.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Display operation as a rich diff showing the overall change.</summary>
    [Argument(Format = "--diff")] public bool? Diff => Get<bool?>(() => Diff);
    /// <summary>Return an error if any changes occur during this update.</summary>
    [Argument(Format = "--expect-no-changes")] public bool? ExpectNoChanges => Get<bool?>(() => ExpectNoChanges);
    /// <summary>Serialize the preview diffs, operations, and overall output as JSON.</summary>
    [Argument(Format = "--json")] public bool? Json => Get<bool?>(() => Json);
    /// <summary>Optional message to associate with the update operation.</summary>
    [Argument(Format = "--message {value}")] public string Message => Get<string>(() => Message);
    /// <summary>Allow P resource operations to run in parallel at once (1 for no parallelism). Defaults to unbounded. (default <c>2147483647</c>).</summary>
    [Argument(Format = "--parallel {value}")] public int? Parallel => Get<int?>(() => Parallel);
    /// <summary>Run one or more policy packs as part of this update.</summary>
    [Argument(Format = "--policy-pack {value}")] public IReadOnlyList<string> PolicyPack => Get<List<string>>(() => PolicyPack);
    /// <summary>Path to JSON file containing the config for the policy pack of the corresponding <c>--policy-pack</c> flag.</summary>
    [Argument(Format = "--policy-pack-config {value}")] public IReadOnlyList<string> PolicyPackConfig => Get<List<string>>(() => PolicyPackConfig);
    /// <summary>Refresh the state of the stack's resources before this update.</summary>
    [Argument(Format = "--refresh")] public bool? Refresh => Get<bool?>(() => Refresh);
    /// <summary>Specify resources to replace. Multiple resources can be specified using <c>--replace urn1 --replace urn2</c>.</summary>
    [Argument(Format = "--replace {value}")] public IReadOnlyList<string> Replace => Get<List<string>>(() => Replace);
    /// <summary>Show configuration keys and variables.</summary>
    [Argument(Format = "--show-config")] public bool? ShowConfig => Get<bool?>(() => ShowConfig);
    /// <summary>Show resources that are being read in, alongside those being managed directly in the stack.</summary>
    [Argument(Format = "--show-reads")] public bool? ShowReads => Get<bool?>(() => ShowReads);
    /// <summary>Show detailed resource replacement creates and deletes instead of a single step.</summary>
    [Argument(Format = "--show-replacement-steps")] public bool? ShowReplacementSteps => Get<bool?>(() => ShowReplacementSteps);
    /// <summary>Show resources that don't need be updated because they haven't changed, alongside those that do.</summary>
    [Argument(Format = "--show-sames")] public bool? ShowSames => Get<bool?>(() => ShowSames);
    /// <summary>The name of the stack to operate on. Defaults to the current stack.</summary>
    [Argument(Format = "--stack {value}")] public string Stack => Get<string>(() => Stack);
    /// <summary>Suppress display of stack outputs (in case they contain sensitive values).</summary>
    [Argument(Format = "--suppress-outputs")] public bool? SuppressOutputs => Get<bool?>(() => SuppressOutputs);
    /// <summary>Suppress display of the state permalink.</summary>
    [Argument(Format = "--suppress-permalink")] public bool? SuppressPermalink => Get<bool?>(() => SuppressPermalink);
    /// <summary>Specify a single resource URN to update. Other resources will not be updated. Multiple resources can be specified using <c>--target urn1 --target urn2</c>.</summary>
    [Argument(Format = "--target {value}")] public IReadOnlyList<string> Target => Get<List<string>>(() => Target);
    /// <summary>Allows updating of dependent targets discovered but not specified in <c>--target</c> list.</summary>
    [Argument(Format = "--target-dependents")] public bool? TargetDependents => Get<bool?>(() => TargetDependents);
    /// <summary>Specify a single resource URN to replace. Other resources will not be updated. Shorthand for <c>--target urn --replace urn</c>.</summary>
    [Argument(Format = "--target-replace {value}")] public IReadOnlyList<string> TargetReplace => Get<List<string>>(() => TargetReplace);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiConfigSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiConfigSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiConfig), Arguments = "config")]
public partial class PulumiConfigSettings : ToolOptions
{
    /// <summary>Use the configuration values in the specified file rather than detecting the file name.</summary>
    [Argument(Format = "--config-file {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>Serialize the preview diffs, operations, and overall output as JSON.</summary>
    [Argument(Format = "--json")] public bool? Json => Get<bool?>(() => Json);
    /// <summary>Show secret values when listing config instead of displaying blinded values.</summary>
    [Argument(Format = "--show-secrets")] public bool? ShowSecrets => Get<bool?>(() => ShowSecrets);
    /// <summary>The name of the stack to operate on. Defaults to the current stack.</summary>
    [Argument(Format = "--stack {value}")] public string Stack => Get<string>(() => Stack);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiConfigCopySettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiConfigCopySettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiConfigCopy), Arguments = "config cp")]
public partial class PulumiConfigCopySettings : ToolOptions
{
    /// <summary>The name of the new stack to copy the config to.</summary>
    [Argument(Format = "--dest {value}")] public string Destination => Get<string>(() => Destination);
    /// <summary>The key contains a path to a property in a map or list to set.</summary>
    [Argument(Format = "--path {value}")] public string Path => Get<string>(() => Path);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiConfigGetSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiConfigGetSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiConfigGet), Arguments = "config get")]
public partial class PulumiConfigGetSettings : ToolOptions
{
    /// <summary>The key to the key-value pair in the configuration.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Key => Get<string>(() => Key);
    /// <summary>Serialize the preview diffs, operations, and overall output as JSON.</summary>
    [Argument(Format = "--json")] public bool? Json => Get<bool?>(() => Json);
    /// <summary>The key contains a path to a property in a map or list to set.</summary>
    [Argument(Format = "--path {value}")] public string Path => Get<string>(() => Path);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiConfigRefreshSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiConfigRefreshSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiConfigRefresh), Arguments = "config refresh")]
public partial class PulumiConfigRefreshSettings : ToolOptions
{
    /// <summary>Overwrite configuration file, if it exists, without creating a backup.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiConfigRemoveSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiConfigRemoveSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiConfigRemove), Arguments = "config rm")]
public partial class PulumiConfigRemoveSettings : ToolOptions
{
    /// <summary>The key to the key-value pair in the configuration.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Key => Get<string>(() => Key);
    /// <summary>The key contains a path to a property in a map or list to set.</summary>
    [Argument(Format = "--path {value}")] public string Path => Get<string>(() => Path);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiConfigSetSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiConfigSetSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiConfigSet), Arguments = "config set")]
public partial class PulumiConfigSetSettings : ToolOptions
{
    /// <summary>The key to the key-value pair in the configuration.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Key => Get<string>(() => Key);
    /// <summary>The new value for specified configuration key.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Value => Get<string>(() => Value);
    /// <summary>The key contains a path to a property in a map or list to set.</summary>
    [Argument(Format = "--path {value}")] public string Path => Get<string>(() => Path);
    /// <summary>Save the value as plaintext (unencrypted).</summary>
    [Argument(Format = "--plaintext")] public bool? Plaintext => Get<bool?>(() => Plaintext);
    /// <summary>Encrypt the value instead of storing it in plaintext.</summary>
    [Argument(Format = "--secret")] public bool? Secret => Get<bool?>(() => Secret);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStack), Arguments = "stack")]
public partial class PulumiStackSettings : ToolOptions
{
    /// <summary>Display each resource's provider-assigned unique ID.</summary>
    [Argument(Format = "--show-ids")] public bool? ShowIds => Get<bool?>(() => ShowIds);
    /// <summary>Display only the stack name.</summary>
    [Argument(Format = "--show-name")] public bool? ShowName => Get<bool?>(() => ShowName);
    /// <summary>Display stack outputs which are marked as secret in plaintext.</summary>
    [Argument(Format = "--show-secrets")] public bool? ShowSecrets => Get<bool?>(() => ShowSecrets);
    /// <summary>Display each resource's Pulumi-assigned globally unique URN.</summary>
    [Argument(Format = "--show-urns")] public bool? ShowUrns => Get<bool?>(() => ShowUrns);
    /// <summary>The name of the stack to operate on. Defaults to the current stack.</summary>
    [Argument(Format = "--stack {value}")] public string Stack => Get<string>(() => Stack);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackChangeSecretsProviderSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackChangeSecretsProviderSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackChangeSecretsProvider), Arguments = "stack change-secrets-provider")]
public partial class PulumiStackChangeSecretsProviderSettings : ToolOptions
{
    /// <summary>The name of the new secrets provider.</summary>
    [Argument(Format = "{value}", Position = 1)] public string NewSecretsProvider => Get<string>(() => NewSecretsProvider);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackExportSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackExportSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackExport), Arguments = "stack export")]
public partial class PulumiStackExportSettings : ToolOptions
{
    /// <summary>A filename to write stack output to.</summary>
    [Argument(Format = "--file {value}")] public string File => Get<string>(() => File);
    /// <summary>Display stack outputs which are marked as secret in plaintext.</summary>
    [Argument(Format = "--show-secrets")] public bool? ShowSecrets => Get<bool?>(() => ShowSecrets);
    /// <summary>Previous stack version to export. (If unset, will export the latest.).</summary>
    [Argument(Format = "--version {value}")] public string Version => Get<string>(() => Version);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackGraphSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackGraphSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackGraph), Arguments = "stack graph")]
public partial class PulumiStackGraphSettings : ToolOptions
{
    /// <summary>A file that will have a Graphviz DOT graph written to it.</summary>
    [Argument(Format = "{value}", Position = 1)] public string File => Get<string>(() => File);
    /// <summary>Sets the color of dependency edges in the graph (default <c>#246C60</c>).</summary>
    [Argument(Format = "--dependency-edge-color {value}")] public string DependencyEdgeColor => Get<string>(() => DependencyEdgeColor);
    /// <summary>Ignores edges introduced by dependency resource relationships.</summary>
    [Argument(Format = "--ignore-dependency-edges")] public bool? IgnoreDependencyEdges => Get<bool?>(() => IgnoreDependencyEdges);
    /// <summary>Ignores edges introduced by parent/child resource relationships.</summary>
    [Argument(Format = "--ignore-parent-edges")] public bool? IgnoreParentEdges => Get<bool?>(() => IgnoreParentEdges);
    /// <summary>Sets the color of parent edges in the graph (default <c>#AA6639</c>).</summary>
    [Argument(Format = "--parent-edge-color {value}")] public string ParentEdgeColor => Get<string>(() => ParentEdgeColor);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackHistorySettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackHistorySettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackHistory), Arguments = "stack history")]
public partial class PulumiStackHistorySettings : ToolOptions
{
    /// <summary>Serialize the preview diffs, operations, and overall output as JSON.</summary>
    [Argument(Format = "--json")] public bool? Json => Get<bool?>(() => Json);
    /// <summary>Show secret values when listing config instead of displaying blinded values.</summary>
    [Argument(Format = "--show-secrets")] public bool? ShowSecrets => Get<bool?>(() => ShowSecrets);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackImportSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackImportSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackImport), Arguments = "stack import")]
public partial class PulumiStackImportSettings : ToolOptions
{
    /// <summary>A filename to read stack input from.</summary>
    [Argument(Format = "--file {value}")] public string File => Get<string>(() => File);
    /// <summary>Force the import to occur, even if apparent errors are discovered beforehand (not recommended).</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackInitSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackInitSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackInit), Arguments = "stack init")]
public partial class PulumiStackInitSettings : ToolOptions
{
    /// <summary>The stack name, optionally preceded by the organization name and a slash: <c>[&lt;org-name&gt;/]&lt;stack-name&gt;</c></summary>
    [Argument(Format = "{value}", Position = 1)] public string OrganizationAndName => Get<string>(() => OrganizationAndName);
    /// <summary>The name of the stack to copy existing config from.</summary>
    [Argument(Format = "--copy-config-from {value}")] public string CopyConfigFrom => Get<string>(() => CopyConfigFrom);
    /// <summary>The type of the provider that should be used to encrypt and decrypt secrets (possible choices: <c>default</c>, <c>passphrase</c>, <c>awskms</c>, <c>azurekeyvault</c>, <c>gcpkms</c>, <c>hashivault</c>) (default <c>default</c>).</summary>
    [Argument(Format = "--secrets-provider {value}")] public PulumiSecretsProvider SecretsProvider => Get<PulumiSecretsProvider>(() => SecretsProvider);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackListSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackListSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackList), Arguments = "stack ls")]
public partial class PulumiStackListSettings : ToolOptions
{
    /// <summary>List all stacks instead of just stacks for the current project.</summary>
    [Argument(Format = "--all")] public bool? All => Get<bool?>(() => All);
    /// <summary>Emit output as JSON.</summary>
    [Argument(Format = "--json")] public bool? Json => Get<bool?>(() => Json);
    /// <summary>Filter returned stacks to those in a specific organization.</summary>
    [Argument(Format = "--organization {value}")] public string Organization => Get<string>(() => Organization);
    /// <summary>Filter returned stacks to those with a specific project name.</summary>
    [Argument(Format = "--project {value}")] public string Project => Get<string>(() => Project);
    /// <summary>Filter returned stacks to those in a specific tag (<c>tag-name</c> or <c>tag-name=tag-value</c>).</summary>
    [Argument(Format = "--tag {value}")] public string Tag => Get<string>(() => Tag);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackOutputSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackOutputSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackOutput), Arguments = "stack output")]
public partial class PulumiStackOutputSettings : ToolOptions
{
    /// <summary>The name of the property whose output value should be listed. This is optional.</summary>
    [Argument(Format = "{value}", Position = 1)] public string PropertyName => Get<string>(() => PropertyName);
    /// <summary>Emit output as JSON.</summary>
    [Argument(Format = "--json")] public bool? Json => Get<bool?>(() => Json);
    /// <summary>Display outputs which are marked as secret in plaintext.</summary>
    [Argument(Format = "--show-secrets")] public bool? ShowSecrets => Get<bool?>(() => ShowSecrets);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackRenameSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackRenameSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackRename), Arguments = "stack rename")]
public partial class PulumiStackRenameSettings : ToolOptions
{
    /// <summary>The new name for the stack.</summary>
    [Argument(Format = "{value}", Position = 1)] public string NewStackName => Get<string>(() => NewStackName);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackRemoveSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackRemoveSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackRemove), Arguments = "stack rm")]
public partial class PulumiStackRemoveSettings : ToolOptions
{
    /// <summary>The name for the stack to be removed.</summary>
    [Argument(Format = "{value}", Position = 1)] public string StackName => Get<string>(() => StackName);
    /// <summary>Forces deletion of the stack, leaving behind any resources managed by the stack.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Do not delete the corresponding Pulumi.&lt;stack-name&gt;.yaml configuration file for the stack.</summary>
    [Argument(Format = "--preserve-config")] public bool? PreserveConfig => Get<bool?>(() => PreserveConfig);
    /// <summary>Skip confirmation prompts, and proceed with removal anyway.</summary>
    [Argument(Format = "--yes")] public bool? Yes => Get<bool?>(() => Yes);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackSelectSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackSelectSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackSelect), Arguments = "stack select")]
public partial class PulumiStackSelectSettings : ToolOptions
{
    /// <summary>The name of the stack that should be selected.</summary>
    [Argument(Format = "{value}", Position = 1)] public string StackName => Get<string>(() => StackName);
    /// <summary>If selected stack does not exist, create it.</summary>
    [Argument(Format = "--create")] public bool? Create => Get<bool?>(() => Create);
    /// <summary>Use with <c>--create</c> flag, The type of the provider that should be used to encrypt and decrypt secrets (possible choices: <c>default</c>, <c>passphrase</c>, <c>awskms</c>, <c>azurekeyvault</c>, <c>gcpkms</c>, <c>hashivault</c>) (default <c>default</c>).</summary>
    [Argument(Format = "--secrets-provider {value}")] public PulumiSecretsProvider SecretsProvider => Get<PulumiSecretsProvider>(() => SecretsProvider);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackTagSetSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackTagSetSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackTagSet), Arguments = "stack tag set")]
public partial class PulumiStackTagSetSettings : ToolOptions
{
    /// <summary>The name of the tag to be set.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Name => Get<string>(() => Name);
    /// <summary>The value of the tag to be set.</summary>
    [Argument(Format = "{value}", Position = 2)] public string Value => Get<string>(() => Value);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackTagGetSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackTagGetSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackTagGet), Arguments = "stack tag get")]
public partial class PulumiStackTagGetSettings : ToolOptions
{
    /// <summary>The name of the tag to be set.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Name => Get<string>(() => Name);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackTagRemoveSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackTagRemoveSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackTagRemove), Arguments = "stack tag rm")]
public partial class PulumiStackTagRemoveSettings : ToolOptions
{
    /// <summary>The name of the tag to be set.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Name => Get<string>(() => Name);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiStackTagListSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiStackTagListSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiStackTagList), Arguments = "stack tag ls")]
public partial class PulumiStackTagListSettings : ToolOptions
{
    /// <summary>Emit output as JSON.</summary>
    [Argument(Format = "--json")] public bool? Json => Get<bool?>(() => Json);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiNewSettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiNewSettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiNew), Arguments = "new")]
public partial class PulumiNewSettings : ToolOptions
{
    /// <summary>The template or URL to base the new stack off of.</summary>
    [Argument(Format = "{value}", Position = 1)] public string Template => Get<string>(() => Template);
    /// <summary>Config to save.</summary>
    [Argument(Format = "--config {value}")] public IReadOnlyList<string> Config => Get<List<string>>(() => Config);
    /// <summary>Config keys contain a path to a property in a map or list to set.</summary>
    [Argument(Format = "--config-path")] public bool? ConfigPath => Get<bool?>(() => ConfigPath);
    /// <summary>The project description; if not specified, a prompt will request it.</summary>
    [Argument(Format = "--description {value}")] public string Description => Get<string>(() => Description);
    /// <summary>The location to place the generated project; if not specified, the current directory is used.</summary>
    [Argument(Format = "--dir {value}")] public string Directory => Get<string>(() => Directory);
    /// <summary>Forces content to be generated even if it would change existing files.</summary>
    [Argument(Format = "--force")] public bool? Force => Get<bool?>(() => Force);
    /// <summary>Generate the project only; do not create a stack, save config, or install dependencies.</summary>
    [Argument(Format = "--generate-only")] public bool? GenerateOnly => Get<bool?>(() => GenerateOnly);
    /// <summary>The project name; if not specified, a prompt will request it.</summary>
    [Argument(Format = "--name {value}")] public string Name => Get<string>(() => Name);
    /// <summary>Use locally cached templates without making any network requests.</summary>
    [Argument(Format = "--offline")] public bool? Offline => Get<bool?>(() => Offline);
    /// <summary>The type of the provider that should be used to encrypt and decrypt secrets (possible choices: <c>default</c>, <c>passphrase</c>, <c>awskms</c>, <c>azurekeyvault</c>, <c>gcpkms</c>, <c>hashivault</c>) (default <c>default</c>).</summary>
    [Argument(Format = "--secrets-provider {value}")] public PulumiSecretsProvider SecretsProvider => Get<PulumiSecretsProvider>(() => SecretsProvider);
    /// <summary>The stack name; either an existing stack or stack to create; if not specified, a prompt will request it.</summary>
    [Argument(Format = "--stack {value}")] public string Stack => Get<string>(() => Stack);
    /// <summary>Skip prompts and proceed with default values.</summary>
    [Argument(Format = "--yes")] public bool? Yes => Get<bool?>(() => Yes);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiDestroySettings
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiDestroySettings>))]
[Command(Type = typeof(PulumiTasks), Command = nameof(PulumiTasks.PulumiDestroy), Arguments = "destroy")]
public partial class PulumiDestroySettings : ToolOptions
{
    /// <summary>Use the configuration values in the specified file rather than detecting the file name.</summary>
    [Argument(Format = "--config-file {value}")] public string ConfigFile => Get<string>(() => ConfigFile);
    /// <summary>Print detailed debugging output during resource operations.</summary>
    [Argument(Format = "--debug")] public bool? Debug => Get<bool?>(() => Debug);
    /// <summary>Display operation as a rich diff showing the overall change.</summary>
    [Argument(Format = "--diff")] public bool? Diff => Get<bool?>(() => Diff);
    /// <summary>Optional message to associate with the destroy operation.</summary>
    [Argument(Format = "--message {value}")] public string Message => Get<string>(() => Message);
    /// <summary>Allow P resource operations to run in parallel at once (1 for no parallelism). Defaults to unbounded. (default <c>2147483647</c>).</summary>
    [Argument(Format = "--parallel {value}")] public int? Parallel => Get<int?>(() => Parallel);
    /// <summary>Refresh the state of the stack's resources before this update.</summary>
    [Argument(Format = "--refresh")] public bool? Refresh => Get<bool?>(() => Refresh);
    /// <summary>Show configuration keys and variables.</summary>
    [Argument(Format = "--show-config")] public bool? ShowConfig => Get<bool?>(() => ShowConfig);
    /// <summary>Show detailed resource replacement creates and deletes instead of a single step.</summary>
    [Argument(Format = "--show-replacement-steps")] public bool? ShowReplacementSteps => Get<bool?>(() => ShowReplacementSteps);
    /// <summary>Show resources that don't need to be updated because they haven't changed, alongside those that do.</summary>
    [Argument(Format = "--show-sames")] public bool? ShowSames => Get<bool?>(() => ShowSames);
    /// <summary>Do not perform a preview before performing the destroy.</summary>
    [Argument(Format = "--skip-preview")] public bool? SkipPreview => Get<bool?>(() => SkipPreview);
    /// <summary>The stack name; either an existing stack or stack to create; if not specified, a prompt will request it.</summary>
    [Argument(Format = "--stack {value}")] public string Stack => Get<string>(() => Stack);
    /// <summary>Suppress display of stack outputs (in case they contain sensitive values).</summary>
    [Argument(Format = "--suppress-outputs")] public bool? SuppressOutputs => Get<bool?>(() => SuppressOutputs);
    /// <summary>Suppress display of the state permalink.</summary>
    [Argument(Format = "--suppress-permalink")] public bool? SuppressPermalink => Get<bool?>(() => SuppressPermalink);
    /// <summary>Specify a single resource URN to destroy. All resources necessary to destroy this target will also be destroyed. Multiple resources can be specified using: <c>--target urn1 --target urn2</c>.</summary>
    [Argument(Format = "--target {value}")] public IReadOnlyList<string> Target => Get<List<string>>(() => Target);
    /// <summary>Allows destroying of dependent targets discovered but not specified in <c>--target</c> list.</summary>
    [Argument(Format = "--target-dependents")] public bool? TargetDependents => Get<bool?>(() => TargetDependents);
    /// <summary>Automatically approve and perform the destroy after previewing it.</summary>
    [Argument(Format = "--yes")] public bool? Yes => Get<bool?>(() => Yes);
    /// <summary>Colorize output. Choices are: always, never, raw, auto (default <c>auto</c>).</summary>
    [Argument(Format = "--color {value}")] public string Color => Get<string>(() => Color);
    /// <summary>Run pulumi as if it had been started in another directory.</summary>
    [Argument(Format = "--cwd {value}")] public string Cwd => Get<string>(() => Cwd);
    /// <summary>Disable integrity checking of checkpoint files.</summary>
    [Argument(Format = "--disable-integrity-checking")] public bool? DisableIntegrityChecking => Get<bool?>(() => DisableIntegrityChecking);
    /// <summary>Enable emojis in the output.</summary>
    [Argument(Format = "--emoji")] public bool? Emoji => Get<bool?>(() => Emoji);
    /// <summary>Flow log settings to child processes (like plugins).</summary>
    [Argument(Format = "--logflow")] public bool? LogFlow => Get<bool?>(() => LogFlow);
    /// <summary>Log to stderr instead of to files.</summary>
    [Argument(Format = "--logtostderr")] public bool? LogToStderr => Get<bool?>(() => LogToStderr);
    /// <summary>Disable interactive mode for all commands.</summary>
    [Argument(Format = "--non-interactive")] public bool? NonInteractive => Get<bool?>(() => NonInteractive);
    /// <summary>Emit CPU and memory profiles and an execution trace to <c>[filename].[pid].{cpu,mem,trace}</c>, respectively.</summary>
    [Argument(Format = "--profiling {value}")] public string Profiling => Get<string>(() => Profiling);
    /// <summary>Emit tracing to the specified endpoint. Use the file: scheme to write tracing data to a local file.</summary>
    [Argument(Format = "--tracing {value}")] public string Tracing => Get<string>(() => Tracing);
    /// <summary>Enable verbose logging (e.g., <c>v=3</c>); anything >3 is very verbose.</summary>
    [Argument(Format = "--verbose {value}")] public int? Verbose => Get<int?>(() => Verbose);
}
#endregion
#region PulumiUpSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiUpSettingsExtensions
{
    #region Config
    /// <inheritdoc cref="PulumiUpSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Config))]
    public static T SetConfig<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Config, v));
    /// <inheritdoc cref="PulumiUpSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Config))]
    public static T SetConfig<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Config, v));
    /// <inheritdoc cref="PulumiUpSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Config))]
    public static T AddConfig<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.AddCollection(() => o.Config, v));
    /// <inheritdoc cref="PulumiUpSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Config))]
    public static T AddConfig<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.AddCollection(() => o.Config, v));
    /// <inheritdoc cref="PulumiUpSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Config))]
    public static T RemoveConfig<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.RemoveCollection(() => o.Config, v));
    /// <inheritdoc cref="PulumiUpSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Config))]
    public static T RemoveConfig<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.RemoveCollection(() => o.Config, v));
    /// <inheritdoc cref="PulumiUpSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Config))]
    public static T ClearConfig<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.ClearCollection(() => o.Config));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="PulumiUpSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="PulumiUpSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region ConfigPath
    /// <inheritdoc cref="PulumiUpSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ConfigPath))]
    public static T SetConfigPath<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ConfigPath, v));
    /// <inheritdoc cref="PulumiUpSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ConfigPath))]
    public static T ResetConfigPath<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.ConfigPath));
    /// <inheritdoc cref="PulumiUpSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ConfigPath))]
    public static T EnableConfigPath<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ConfigPath, true));
    /// <inheritdoc cref="PulumiUpSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ConfigPath))]
    public static T DisableConfigPath<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ConfigPath, false));
    /// <inheritdoc cref="PulumiUpSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ConfigPath))]
    public static T ToggleConfigPath<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ConfigPath, !o.ConfigPath));
    #endregion
    #region Debug
    /// <inheritdoc cref="PulumiUpSettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="PulumiUpSettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="PulumiUpSettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="PulumiUpSettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="PulumiUpSettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Diff
    /// <inheritdoc cref="PulumiUpSettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Diff))]
    public static T SetDiff<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Diff, v));
    /// <inheritdoc cref="PulumiUpSettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Diff))]
    public static T ResetDiff<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Diff));
    /// <inheritdoc cref="PulumiUpSettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Diff))]
    public static T EnableDiff<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Diff, true));
    /// <inheritdoc cref="PulumiUpSettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Diff))]
    public static T DisableDiff<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Diff, false));
    /// <inheritdoc cref="PulumiUpSettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Diff))]
    public static T ToggleDiff<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Diff, !o.Diff));
    #endregion
    #region ExpectNoChanges
    /// <inheritdoc cref="PulumiUpSettings.ExpectNoChanges"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ExpectNoChanges))]
    public static T SetExpectNoChanges<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ExpectNoChanges, v));
    /// <inheritdoc cref="PulumiUpSettings.ExpectNoChanges"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ExpectNoChanges))]
    public static T ResetExpectNoChanges<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.ExpectNoChanges));
    /// <inheritdoc cref="PulumiUpSettings.ExpectNoChanges"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ExpectNoChanges))]
    public static T EnableExpectNoChanges<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ExpectNoChanges, true));
    /// <inheritdoc cref="PulumiUpSettings.ExpectNoChanges"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ExpectNoChanges))]
    public static T DisableExpectNoChanges<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ExpectNoChanges, false));
    /// <inheritdoc cref="PulumiUpSettings.ExpectNoChanges"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ExpectNoChanges))]
    public static T ToggleExpectNoChanges<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ExpectNoChanges, !o.ExpectNoChanges));
    #endregion
    #region Message
    /// <inheritdoc cref="PulumiUpSettings.Message"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Message))]
    public static T SetMessage<T>(this T o, string v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Message, v));
    /// <inheritdoc cref="PulumiUpSettings.Message"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Message))]
    public static T ResetMessage<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Message));
    #endregion
    #region Parallel
    /// <inheritdoc cref="PulumiUpSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Parallel))]
    public static T SetParallel<T>(this T o, int? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Parallel, v));
    /// <inheritdoc cref="PulumiUpSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Parallel))]
    public static T ResetParallel<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Parallel));
    #endregion
    #region PolicyPack
    /// <inheritdoc cref="PulumiUpSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPack))]
    public static T SetPolicyPack<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.PolicyPack, v));
    /// <inheritdoc cref="PulumiUpSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPack))]
    public static T SetPolicyPack<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.PolicyPack, v));
    /// <inheritdoc cref="PulumiUpSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPack))]
    public static T AddPolicyPack<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.AddCollection(() => o.PolicyPack, v));
    /// <inheritdoc cref="PulumiUpSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPack))]
    public static T AddPolicyPack<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.AddCollection(() => o.PolicyPack, v));
    /// <inheritdoc cref="PulumiUpSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPack))]
    public static T RemovePolicyPack<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.RemoveCollection(() => o.PolicyPack, v));
    /// <inheritdoc cref="PulumiUpSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPack))]
    public static T RemovePolicyPack<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.RemoveCollection(() => o.PolicyPack, v));
    /// <inheritdoc cref="PulumiUpSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPack))]
    public static T ClearPolicyPack<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.ClearCollection(() => o.PolicyPack));
    #endregion
    #region PolicyPackConfig
    /// <inheritdoc cref="PulumiUpSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPackConfig))]
    public static T SetPolicyPackConfig<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.PolicyPackConfig, v));
    /// <inheritdoc cref="PulumiUpSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPackConfig))]
    public static T SetPolicyPackConfig<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.PolicyPackConfig, v));
    /// <inheritdoc cref="PulumiUpSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPackConfig))]
    public static T AddPolicyPackConfig<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.AddCollection(() => o.PolicyPackConfig, v));
    /// <inheritdoc cref="PulumiUpSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPackConfig))]
    public static T AddPolicyPackConfig<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.AddCollection(() => o.PolicyPackConfig, v));
    /// <inheritdoc cref="PulumiUpSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPackConfig))]
    public static T RemovePolicyPackConfig<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.RemoveCollection(() => o.PolicyPackConfig, v));
    /// <inheritdoc cref="PulumiUpSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPackConfig))]
    public static T RemovePolicyPackConfig<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.RemoveCollection(() => o.PolicyPackConfig, v));
    /// <inheritdoc cref="PulumiUpSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.PolicyPackConfig))]
    public static T ClearPolicyPackConfig<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.ClearCollection(() => o.PolicyPackConfig));
    #endregion
    #region Refresh
    /// <inheritdoc cref="PulumiUpSettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Refresh))]
    public static T SetRefresh<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Refresh, v));
    /// <inheritdoc cref="PulumiUpSettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Refresh))]
    public static T ResetRefresh<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Refresh));
    /// <inheritdoc cref="PulumiUpSettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Refresh))]
    public static T EnableRefresh<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Refresh, true));
    /// <inheritdoc cref="PulumiUpSettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Refresh))]
    public static T DisableRefresh<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Refresh, false));
    /// <inheritdoc cref="PulumiUpSettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Refresh))]
    public static T ToggleRefresh<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Refresh, !o.Refresh));
    #endregion
    #region Replace
    /// <inheritdoc cref="PulumiUpSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Replace))]
    public static T SetReplace<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Replace, v));
    /// <inheritdoc cref="PulumiUpSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Replace))]
    public static T SetReplace<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Replace, v));
    /// <inheritdoc cref="PulumiUpSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Replace))]
    public static T AddReplace<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.AddCollection(() => o.Replace, v));
    /// <inheritdoc cref="PulumiUpSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Replace))]
    public static T AddReplace<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.AddCollection(() => o.Replace, v));
    /// <inheritdoc cref="PulumiUpSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Replace))]
    public static T RemoveReplace<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.RemoveCollection(() => o.Replace, v));
    /// <inheritdoc cref="PulumiUpSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Replace))]
    public static T RemoveReplace<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.RemoveCollection(() => o.Replace, v));
    /// <inheritdoc cref="PulumiUpSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Replace))]
    public static T ClearReplace<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.ClearCollection(() => o.Replace));
    #endregion
    #region SecretsProvider
    /// <inheritdoc cref="PulumiUpSettings.SecretsProvider"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SecretsProvider))]
    public static T SetSecretsProvider<T>(this T o, PulumiSecretsProvider v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SecretsProvider, v));
    /// <inheritdoc cref="PulumiUpSettings.SecretsProvider"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SecretsProvider))]
    public static T ResetSecretsProvider<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.SecretsProvider));
    #endregion
    #region ShowConfig
    /// <inheritdoc cref="PulumiUpSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowConfig))]
    public static T SetShowConfig<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowConfig, v));
    /// <inheritdoc cref="PulumiUpSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowConfig))]
    public static T ResetShowConfig<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.ShowConfig));
    /// <inheritdoc cref="PulumiUpSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowConfig))]
    public static T EnableShowConfig<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowConfig, true));
    /// <inheritdoc cref="PulumiUpSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowConfig))]
    public static T DisableShowConfig<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowConfig, false));
    /// <inheritdoc cref="PulumiUpSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowConfig))]
    public static T ToggleShowConfig<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowConfig, !o.ShowConfig));
    #endregion
    #region ShowReads
    /// <inheritdoc cref="PulumiUpSettings.ShowReads"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowReads))]
    public static T SetShowReads<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowReads, v));
    /// <inheritdoc cref="PulumiUpSettings.ShowReads"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowReads))]
    public static T ResetShowReads<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.ShowReads));
    /// <inheritdoc cref="PulumiUpSettings.ShowReads"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowReads))]
    public static T EnableShowReads<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowReads, true));
    /// <inheritdoc cref="PulumiUpSettings.ShowReads"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowReads))]
    public static T DisableShowReads<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowReads, false));
    /// <inheritdoc cref="PulumiUpSettings.ShowReads"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowReads))]
    public static T ToggleShowReads<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowReads, !o.ShowReads));
    #endregion
    #region ShowReplacementSteps
    /// <inheritdoc cref="PulumiUpSettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowReplacementSteps))]
    public static T SetShowReplacementSteps<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowReplacementSteps, v));
    /// <inheritdoc cref="PulumiUpSettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowReplacementSteps))]
    public static T ResetShowReplacementSteps<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.ShowReplacementSteps));
    /// <inheritdoc cref="PulumiUpSettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowReplacementSteps))]
    public static T EnableShowReplacementSteps<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowReplacementSteps, true));
    /// <inheritdoc cref="PulumiUpSettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowReplacementSteps))]
    public static T DisableShowReplacementSteps<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowReplacementSteps, false));
    /// <inheritdoc cref="PulumiUpSettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowReplacementSteps))]
    public static T ToggleShowReplacementSteps<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowReplacementSteps, !o.ShowReplacementSteps));
    #endregion
    #region ShowSames
    /// <inheritdoc cref="PulumiUpSettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowSames))]
    public static T SetShowSames<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowSames, v));
    /// <inheritdoc cref="PulumiUpSettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowSames))]
    public static T ResetShowSames<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.ShowSames));
    /// <inheritdoc cref="PulumiUpSettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowSames))]
    public static T EnableShowSames<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowSames, true));
    /// <inheritdoc cref="PulumiUpSettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowSames))]
    public static T DisableShowSames<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowSames, false));
    /// <inheritdoc cref="PulumiUpSettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.ShowSames))]
    public static T ToggleShowSames<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.ShowSames, !o.ShowSames));
    #endregion
    #region SkipPreview
    /// <inheritdoc cref="PulumiUpSettings.SkipPreview"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SkipPreview))]
    public static T SetSkipPreview<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SkipPreview, v));
    /// <inheritdoc cref="PulumiUpSettings.SkipPreview"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SkipPreview))]
    public static T ResetSkipPreview<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.SkipPreview));
    /// <inheritdoc cref="PulumiUpSettings.SkipPreview"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SkipPreview))]
    public static T EnableSkipPreview<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SkipPreview, true));
    /// <inheritdoc cref="PulumiUpSettings.SkipPreview"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SkipPreview))]
    public static T DisableSkipPreview<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SkipPreview, false));
    /// <inheritdoc cref="PulumiUpSettings.SkipPreview"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SkipPreview))]
    public static T ToggleSkipPreview<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SkipPreview, !o.SkipPreview));
    #endregion
    #region Stack
    /// <inheritdoc cref="PulumiUpSettings.Stack"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Stack))]
    public static T SetStack<T>(this T o, string v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Stack, v));
    /// <inheritdoc cref="PulumiUpSettings.Stack"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Stack))]
    public static T ResetStack<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Stack));
    #endregion
    #region SuppressOutputs
    /// <inheritdoc cref="PulumiUpSettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SuppressOutputs))]
    public static T SetSuppressOutputs<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SuppressOutputs, v));
    /// <inheritdoc cref="PulumiUpSettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SuppressOutputs))]
    public static T ResetSuppressOutputs<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.SuppressOutputs));
    /// <inheritdoc cref="PulumiUpSettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SuppressOutputs))]
    public static T EnableSuppressOutputs<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SuppressOutputs, true));
    /// <inheritdoc cref="PulumiUpSettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SuppressOutputs))]
    public static T DisableSuppressOutputs<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SuppressOutputs, false));
    /// <inheritdoc cref="PulumiUpSettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SuppressOutputs))]
    public static T ToggleSuppressOutputs<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SuppressOutputs, !o.SuppressOutputs));
    #endregion
    #region SuppressPermalink
    /// <inheritdoc cref="PulumiUpSettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SuppressPermalink))]
    public static T SetSuppressPermalink<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SuppressPermalink, v));
    /// <inheritdoc cref="PulumiUpSettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SuppressPermalink))]
    public static T ResetSuppressPermalink<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.SuppressPermalink));
    /// <inheritdoc cref="PulumiUpSettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SuppressPermalink))]
    public static T EnableSuppressPermalink<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SuppressPermalink, true));
    /// <inheritdoc cref="PulumiUpSettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SuppressPermalink))]
    public static T DisableSuppressPermalink<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SuppressPermalink, false));
    /// <inheritdoc cref="PulumiUpSettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.SuppressPermalink))]
    public static T ToggleSuppressPermalink<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.SuppressPermalink, !o.SuppressPermalink));
    #endregion
    #region Target
    /// <inheritdoc cref="PulumiUpSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Target))]
    public static T SetTarget<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Target, v));
    /// <inheritdoc cref="PulumiUpSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Target))]
    public static T SetTarget<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Target, v));
    /// <inheritdoc cref="PulumiUpSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Target))]
    public static T AddTarget<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.AddCollection(() => o.Target, v));
    /// <inheritdoc cref="PulumiUpSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Target))]
    public static T AddTarget<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.AddCollection(() => o.Target, v));
    /// <inheritdoc cref="PulumiUpSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Target))]
    public static T RemoveTarget<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.RemoveCollection(() => o.Target, v));
    /// <inheritdoc cref="PulumiUpSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Target))]
    public static T RemoveTarget<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.RemoveCollection(() => o.Target, v));
    /// <inheritdoc cref="PulumiUpSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Target))]
    public static T ClearTarget<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.ClearCollection(() => o.Target));
    #endregion
    #region TargetDependents
    /// <inheritdoc cref="PulumiUpSettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.TargetDependents))]
    public static T SetTargetDependents<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.TargetDependents, v));
    /// <inheritdoc cref="PulumiUpSettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.TargetDependents))]
    public static T ResetTargetDependents<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.TargetDependents));
    /// <inheritdoc cref="PulumiUpSettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.TargetDependents))]
    public static T EnableTargetDependents<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.TargetDependents, true));
    /// <inheritdoc cref="PulumiUpSettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.TargetDependents))]
    public static T DisableTargetDependents<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.TargetDependents, false));
    /// <inheritdoc cref="PulumiUpSettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.TargetDependents))]
    public static T ToggleTargetDependents<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.TargetDependents, !o.TargetDependents));
    #endregion
    #region TargetReplace
    /// <inheritdoc cref="PulumiUpSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.TargetReplace))]
    public static T SetTargetReplace<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.TargetReplace, v));
    /// <inheritdoc cref="PulumiUpSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.TargetReplace))]
    public static T SetTargetReplace<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.TargetReplace, v));
    /// <inheritdoc cref="PulumiUpSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.TargetReplace))]
    public static T AddTargetReplace<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.AddCollection(() => o.TargetReplace, v));
    /// <inheritdoc cref="PulumiUpSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.TargetReplace))]
    public static T AddTargetReplace<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.AddCollection(() => o.TargetReplace, v));
    /// <inheritdoc cref="PulumiUpSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.TargetReplace))]
    public static T RemoveTargetReplace<T>(this T o, params string[] v) where T : PulumiUpSettings => o.Modify(b => b.RemoveCollection(() => o.TargetReplace, v));
    /// <inheritdoc cref="PulumiUpSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.TargetReplace))]
    public static T RemoveTargetReplace<T>(this T o, IEnumerable<string> v) where T : PulumiUpSettings => o.Modify(b => b.RemoveCollection(() => o.TargetReplace, v));
    /// <inheritdoc cref="PulumiUpSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.TargetReplace))]
    public static T ClearTargetReplace<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.ClearCollection(() => o.TargetReplace));
    #endregion
    #region Yes
    /// <inheritdoc cref="PulumiUpSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Yes))]
    public static T SetYes<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Yes, v));
    /// <inheritdoc cref="PulumiUpSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Yes))]
    public static T ResetYes<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Yes));
    /// <inheritdoc cref="PulumiUpSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Yes))]
    public static T EnableYes<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Yes, true));
    /// <inheritdoc cref="PulumiUpSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Yes))]
    public static T DisableYes<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Yes, false));
    /// <inheritdoc cref="PulumiUpSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Yes))]
    public static T ToggleYes<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Yes, !o.Yes));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiUpSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiUpSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiUpSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiUpSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiUpSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiUpSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiUpSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiUpSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiUpSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiUpSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiUpSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiUpSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiUpSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiUpSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiUpSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiUpSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiUpSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiUpSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiUpSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiUpSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiUpSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiUpSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiUpSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiUpSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiUpSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiUpSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiUpSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiUpSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiUpSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiUpSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiUpSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiUpSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiUpSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiUpSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiUpSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiUpSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiUpSettings), Property = nameof(PulumiUpSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiUpSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiPreviewSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiPreviewSettingsExtensions
{
    #region Config
    /// <inheritdoc cref="PulumiPreviewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Config))]
    public static T SetConfig<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Config, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Config))]
    public static T SetConfig<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Config, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Config))]
    public static T AddConfig<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.AddCollection(() => o.Config, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Config))]
    public static T AddConfig<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.AddCollection(() => o.Config, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Config))]
    public static T RemoveConfig<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.RemoveCollection(() => o.Config, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Config))]
    public static T RemoveConfig<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.RemoveCollection(() => o.Config, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Config))]
    public static T ClearConfig<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.ClearCollection(() => o.Config));
    #endregion
    #region ConfigFile
    /// <inheritdoc cref="PulumiPreviewSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="PulumiPreviewSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region ConfigPath
    /// <inheritdoc cref="PulumiPreviewSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ConfigPath))]
    public static T SetConfigPath<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ConfigPath, v));
    /// <inheritdoc cref="PulumiPreviewSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ConfigPath))]
    public static T ResetConfigPath<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.ConfigPath));
    /// <inheritdoc cref="PulumiPreviewSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ConfigPath))]
    public static T EnableConfigPath<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ConfigPath, true));
    /// <inheritdoc cref="PulumiPreviewSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ConfigPath))]
    public static T DisableConfigPath<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ConfigPath, false));
    /// <inheritdoc cref="PulumiPreviewSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ConfigPath))]
    public static T ToggleConfigPath<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ConfigPath, !o.ConfigPath));
    #endregion
    #region Debug
    /// <inheritdoc cref="PulumiPreviewSettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="PulumiPreviewSettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="PulumiPreviewSettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="PulumiPreviewSettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Diff
    /// <inheritdoc cref="PulumiPreviewSettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Diff))]
    public static T SetDiff<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Diff, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Diff))]
    public static T ResetDiff<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Diff));
    /// <inheritdoc cref="PulumiPreviewSettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Diff))]
    public static T EnableDiff<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Diff, true));
    /// <inheritdoc cref="PulumiPreviewSettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Diff))]
    public static T DisableDiff<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Diff, false));
    /// <inheritdoc cref="PulumiPreviewSettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Diff))]
    public static T ToggleDiff<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Diff, !o.Diff));
    #endregion
    #region ExpectNoChanges
    /// <inheritdoc cref="PulumiPreviewSettings.ExpectNoChanges"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ExpectNoChanges))]
    public static T SetExpectNoChanges<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ExpectNoChanges, v));
    /// <inheritdoc cref="PulumiPreviewSettings.ExpectNoChanges"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ExpectNoChanges))]
    public static T ResetExpectNoChanges<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.ExpectNoChanges));
    /// <inheritdoc cref="PulumiPreviewSettings.ExpectNoChanges"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ExpectNoChanges))]
    public static T EnableExpectNoChanges<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ExpectNoChanges, true));
    /// <inheritdoc cref="PulumiPreviewSettings.ExpectNoChanges"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ExpectNoChanges))]
    public static T DisableExpectNoChanges<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ExpectNoChanges, false));
    /// <inheritdoc cref="PulumiPreviewSettings.ExpectNoChanges"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ExpectNoChanges))]
    public static T ToggleExpectNoChanges<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ExpectNoChanges, !o.ExpectNoChanges));
    #endregion
    #region Json
    /// <inheritdoc cref="PulumiPreviewSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Json))]
    public static T SetJson<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Json, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Json))]
    public static T ResetJson<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Json));
    /// <inheritdoc cref="PulumiPreviewSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Json))]
    public static T EnableJson<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Json, true));
    /// <inheritdoc cref="PulumiPreviewSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Json))]
    public static T DisableJson<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Json, false));
    /// <inheritdoc cref="PulumiPreviewSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Json))]
    public static T ToggleJson<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Json, !o.Json));
    #endregion
    #region Message
    /// <inheritdoc cref="PulumiPreviewSettings.Message"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Message))]
    public static T SetMessage<T>(this T o, string v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Message, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Message"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Message))]
    public static T ResetMessage<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Message));
    #endregion
    #region Parallel
    /// <inheritdoc cref="PulumiPreviewSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Parallel))]
    public static T SetParallel<T>(this T o, int? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Parallel, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Parallel"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Parallel))]
    public static T ResetParallel<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Parallel));
    #endregion
    #region PolicyPack
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPack))]
    public static T SetPolicyPack<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.PolicyPack, v));
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPack))]
    public static T SetPolicyPack<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.PolicyPack, v));
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPack))]
    public static T AddPolicyPack<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.AddCollection(() => o.PolicyPack, v));
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPack))]
    public static T AddPolicyPack<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.AddCollection(() => o.PolicyPack, v));
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPack))]
    public static T RemovePolicyPack<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.RemoveCollection(() => o.PolicyPack, v));
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPack))]
    public static T RemovePolicyPack<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.RemoveCollection(() => o.PolicyPack, v));
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPack"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPack))]
    public static T ClearPolicyPack<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.ClearCollection(() => o.PolicyPack));
    #endregion
    #region PolicyPackConfig
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPackConfig))]
    public static T SetPolicyPackConfig<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.PolicyPackConfig, v));
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPackConfig))]
    public static T SetPolicyPackConfig<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.PolicyPackConfig, v));
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPackConfig))]
    public static T AddPolicyPackConfig<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.AddCollection(() => o.PolicyPackConfig, v));
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPackConfig))]
    public static T AddPolicyPackConfig<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.AddCollection(() => o.PolicyPackConfig, v));
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPackConfig))]
    public static T RemovePolicyPackConfig<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.RemoveCollection(() => o.PolicyPackConfig, v));
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPackConfig))]
    public static T RemovePolicyPackConfig<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.RemoveCollection(() => o.PolicyPackConfig, v));
    /// <inheritdoc cref="PulumiPreviewSettings.PolicyPackConfig"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.PolicyPackConfig))]
    public static T ClearPolicyPackConfig<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.ClearCollection(() => o.PolicyPackConfig));
    #endregion
    #region Refresh
    /// <inheritdoc cref="PulumiPreviewSettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Refresh))]
    public static T SetRefresh<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Refresh, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Refresh))]
    public static T ResetRefresh<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Refresh));
    /// <inheritdoc cref="PulumiPreviewSettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Refresh))]
    public static T EnableRefresh<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Refresh, true));
    /// <inheritdoc cref="PulumiPreviewSettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Refresh))]
    public static T DisableRefresh<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Refresh, false));
    /// <inheritdoc cref="PulumiPreviewSettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Refresh))]
    public static T ToggleRefresh<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Refresh, !o.Refresh));
    #endregion
    #region Replace
    /// <inheritdoc cref="PulumiPreviewSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Replace))]
    public static T SetReplace<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Replace, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Replace))]
    public static T SetReplace<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Replace, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Replace))]
    public static T AddReplace<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.AddCollection(() => o.Replace, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Replace))]
    public static T AddReplace<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.AddCollection(() => o.Replace, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Replace))]
    public static T RemoveReplace<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.RemoveCollection(() => o.Replace, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Replace))]
    public static T RemoveReplace<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.RemoveCollection(() => o.Replace, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Replace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Replace))]
    public static T ClearReplace<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.ClearCollection(() => o.Replace));
    #endregion
    #region ShowConfig
    /// <inheritdoc cref="PulumiPreviewSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowConfig))]
    public static T SetShowConfig<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowConfig, v));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowConfig))]
    public static T ResetShowConfig<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.ShowConfig));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowConfig))]
    public static T EnableShowConfig<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowConfig, true));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowConfig))]
    public static T DisableShowConfig<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowConfig, false));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowConfig))]
    public static T ToggleShowConfig<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowConfig, !o.ShowConfig));
    #endregion
    #region ShowReads
    /// <inheritdoc cref="PulumiPreviewSettings.ShowReads"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowReads))]
    public static T SetShowReads<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowReads, v));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowReads"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowReads))]
    public static T ResetShowReads<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.ShowReads));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowReads"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowReads))]
    public static T EnableShowReads<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowReads, true));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowReads"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowReads))]
    public static T DisableShowReads<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowReads, false));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowReads"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowReads))]
    public static T ToggleShowReads<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowReads, !o.ShowReads));
    #endregion
    #region ShowReplacementSteps
    /// <inheritdoc cref="PulumiPreviewSettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowReplacementSteps))]
    public static T SetShowReplacementSteps<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowReplacementSteps, v));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowReplacementSteps))]
    public static T ResetShowReplacementSteps<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.ShowReplacementSteps));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowReplacementSteps))]
    public static T EnableShowReplacementSteps<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowReplacementSteps, true));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowReplacementSteps))]
    public static T DisableShowReplacementSteps<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowReplacementSteps, false));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowReplacementSteps))]
    public static T ToggleShowReplacementSteps<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowReplacementSteps, !o.ShowReplacementSteps));
    #endregion
    #region ShowSames
    /// <inheritdoc cref="PulumiPreviewSettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowSames))]
    public static T SetShowSames<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowSames, v));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowSames))]
    public static T ResetShowSames<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.ShowSames));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowSames))]
    public static T EnableShowSames<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowSames, true));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowSames))]
    public static T DisableShowSames<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowSames, false));
    /// <inheritdoc cref="PulumiPreviewSettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.ShowSames))]
    public static T ToggleShowSames<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.ShowSames, !o.ShowSames));
    #endregion
    #region Stack
    /// <inheritdoc cref="PulumiPreviewSettings.Stack"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Stack))]
    public static T SetStack<T>(this T o, string v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Stack, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Stack"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Stack))]
    public static T ResetStack<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Stack));
    #endregion
    #region SuppressOutputs
    /// <inheritdoc cref="PulumiPreviewSettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.SuppressOutputs))]
    public static T SetSuppressOutputs<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.SuppressOutputs, v));
    /// <inheritdoc cref="PulumiPreviewSettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.SuppressOutputs))]
    public static T ResetSuppressOutputs<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.SuppressOutputs));
    /// <inheritdoc cref="PulumiPreviewSettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.SuppressOutputs))]
    public static T EnableSuppressOutputs<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.SuppressOutputs, true));
    /// <inheritdoc cref="PulumiPreviewSettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.SuppressOutputs))]
    public static T DisableSuppressOutputs<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.SuppressOutputs, false));
    /// <inheritdoc cref="PulumiPreviewSettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.SuppressOutputs))]
    public static T ToggleSuppressOutputs<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.SuppressOutputs, !o.SuppressOutputs));
    #endregion
    #region SuppressPermalink
    /// <inheritdoc cref="PulumiPreviewSettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.SuppressPermalink))]
    public static T SetSuppressPermalink<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.SuppressPermalink, v));
    /// <inheritdoc cref="PulumiPreviewSettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.SuppressPermalink))]
    public static T ResetSuppressPermalink<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.SuppressPermalink));
    /// <inheritdoc cref="PulumiPreviewSettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.SuppressPermalink))]
    public static T EnableSuppressPermalink<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.SuppressPermalink, true));
    /// <inheritdoc cref="PulumiPreviewSettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.SuppressPermalink))]
    public static T DisableSuppressPermalink<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.SuppressPermalink, false));
    /// <inheritdoc cref="PulumiPreviewSettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.SuppressPermalink))]
    public static T ToggleSuppressPermalink<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.SuppressPermalink, !o.SuppressPermalink));
    #endregion
    #region Target
    /// <inheritdoc cref="PulumiPreviewSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Target))]
    public static T SetTarget<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Target, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Target))]
    public static T SetTarget<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Target, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Target))]
    public static T AddTarget<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.AddCollection(() => o.Target, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Target))]
    public static T AddTarget<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.AddCollection(() => o.Target, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Target))]
    public static T RemoveTarget<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.RemoveCollection(() => o.Target, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Target))]
    public static T RemoveTarget<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.RemoveCollection(() => o.Target, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Target))]
    public static T ClearTarget<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.ClearCollection(() => o.Target));
    #endregion
    #region TargetDependents
    /// <inheritdoc cref="PulumiPreviewSettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.TargetDependents))]
    public static T SetTargetDependents<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.TargetDependents, v));
    /// <inheritdoc cref="PulumiPreviewSettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.TargetDependents))]
    public static T ResetTargetDependents<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.TargetDependents));
    /// <inheritdoc cref="PulumiPreviewSettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.TargetDependents))]
    public static T EnableTargetDependents<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.TargetDependents, true));
    /// <inheritdoc cref="PulumiPreviewSettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.TargetDependents))]
    public static T DisableTargetDependents<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.TargetDependents, false));
    /// <inheritdoc cref="PulumiPreviewSettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.TargetDependents))]
    public static T ToggleTargetDependents<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.TargetDependents, !o.TargetDependents));
    #endregion
    #region TargetReplace
    /// <inheritdoc cref="PulumiPreviewSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.TargetReplace))]
    public static T SetTargetReplace<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.TargetReplace, v));
    /// <inheritdoc cref="PulumiPreviewSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.TargetReplace))]
    public static T SetTargetReplace<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.TargetReplace, v));
    /// <inheritdoc cref="PulumiPreviewSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.TargetReplace))]
    public static T AddTargetReplace<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.AddCollection(() => o.TargetReplace, v));
    /// <inheritdoc cref="PulumiPreviewSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.TargetReplace))]
    public static T AddTargetReplace<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.AddCollection(() => o.TargetReplace, v));
    /// <inheritdoc cref="PulumiPreviewSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.TargetReplace))]
    public static T RemoveTargetReplace<T>(this T o, params string[] v) where T : PulumiPreviewSettings => o.Modify(b => b.RemoveCollection(() => o.TargetReplace, v));
    /// <inheritdoc cref="PulumiPreviewSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.TargetReplace))]
    public static T RemoveTargetReplace<T>(this T o, IEnumerable<string> v) where T : PulumiPreviewSettings => o.Modify(b => b.RemoveCollection(() => o.TargetReplace, v));
    /// <inheritdoc cref="PulumiPreviewSettings.TargetReplace"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.TargetReplace))]
    public static T ClearTargetReplace<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.ClearCollection(() => o.TargetReplace));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiPreviewSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiPreviewSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiPreviewSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiPreviewSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiPreviewSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiPreviewSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiPreviewSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiPreviewSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiPreviewSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiPreviewSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiPreviewSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiPreviewSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiPreviewSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiPreviewSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiPreviewSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiPreviewSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiPreviewSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiPreviewSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiPreviewSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiPreviewSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiPreviewSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiPreviewSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiPreviewSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiPreviewSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiPreviewSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiPreviewSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiPreviewSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiPreviewSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiPreviewSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiPreviewSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiPreviewSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiPreviewSettings), Property = nameof(PulumiPreviewSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiPreviewSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiConfigSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiConfigSettingsExtensions
{
    #region ConfigFile
    /// <inheritdoc cref="PulumiConfigSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="PulumiConfigSettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region Json
    /// <inheritdoc cref="PulumiConfigSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Json))]
    public static T SetJson<T>(this T o, bool? v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Json, v));
    /// <inheritdoc cref="PulumiConfigSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Json))]
    public static T ResetJson<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.Json));
    /// <inheritdoc cref="PulumiConfigSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Json))]
    public static T EnableJson<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Json, true));
    /// <inheritdoc cref="PulumiConfigSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Json))]
    public static T DisableJson<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Json, false));
    /// <inheritdoc cref="PulumiConfigSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Json))]
    public static T ToggleJson<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Json, !o.Json));
    #endregion
    #region ShowSecrets
    /// <inheritdoc cref="PulumiConfigSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.ShowSecrets))]
    public static T SetShowSecrets<T>(this T o, bool? v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.ShowSecrets, v));
    /// <inheritdoc cref="PulumiConfigSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.ShowSecrets))]
    public static T ResetShowSecrets<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.ShowSecrets));
    /// <inheritdoc cref="PulumiConfigSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.ShowSecrets))]
    public static T EnableShowSecrets<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.ShowSecrets, true));
    /// <inheritdoc cref="PulumiConfigSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.ShowSecrets))]
    public static T DisableShowSecrets<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.ShowSecrets, false));
    /// <inheritdoc cref="PulumiConfigSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.ShowSecrets))]
    public static T ToggleShowSecrets<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.ShowSecrets, !o.ShowSecrets));
    #endregion
    #region Stack
    /// <inheritdoc cref="PulumiConfigSettings.Stack"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Stack))]
    public static T SetStack<T>(this T o, string v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Stack, v));
    /// <inheritdoc cref="PulumiConfigSettings.Stack"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Stack))]
    public static T ResetStack<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.Stack));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiConfigSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiConfigSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiConfigSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiConfigSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiConfigSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiConfigSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiConfigSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiConfigSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiConfigSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiConfigSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiConfigSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiConfigSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiConfigSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiConfigSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiConfigSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiConfigSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiConfigSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiConfigSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiConfigSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiConfigSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiConfigSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiConfigSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiConfigSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiConfigSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiConfigSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiConfigSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiConfigSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiConfigSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiConfigSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiConfigSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiConfigSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiConfigSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiConfigSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiConfigSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiConfigSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiConfigSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSettings), Property = nameof(PulumiConfigSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiConfigSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiConfigCopySettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiConfigCopySettingsExtensions
{
    #region Destination
    /// <inheritdoc cref="PulumiConfigCopySettings.Destination"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Destination))]
    public static T SetDestination<T>(this T o, string v) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.Destination, v));
    /// <inheritdoc cref="PulumiConfigCopySettings.Destination"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Destination))]
    public static T ResetDestination<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Remove(() => o.Destination));
    #endregion
    #region Path
    /// <inheritdoc cref="PulumiConfigCopySettings.Path"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Path))]
    public static T SetPath<T>(this T o, string v) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.Path, v));
    /// <inheritdoc cref="PulumiConfigCopySettings.Path"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Path))]
    public static T ResetPath<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Remove(() => o.Path));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiConfigCopySettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiConfigCopySettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiConfigCopySettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiConfigCopySettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiConfigCopySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiConfigCopySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiConfigCopySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiConfigCopySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiConfigCopySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiConfigCopySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiConfigCopySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiConfigCopySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiConfigCopySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiConfigCopySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiConfigCopySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiConfigCopySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiConfigCopySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiConfigCopySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiConfigCopySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiConfigCopySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiConfigCopySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiConfigCopySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiConfigCopySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiConfigCopySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiConfigCopySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiConfigCopySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiConfigCopySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiConfigCopySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiConfigCopySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiConfigCopySettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiConfigCopySettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiConfigCopySettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiConfigCopySettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiConfigCopySettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiConfigCopySettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiConfigCopySettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiConfigCopySettings), Property = nameof(PulumiConfigCopySettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiConfigCopySettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiConfigGetSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiConfigGetSettingsExtensions
{
    #region Key
    /// <inheritdoc cref="PulumiConfigGetSettings.Key"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Key))]
    public static T SetKey<T>(this T o, string v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Key, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.Key"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Key))]
    public static T ResetKey<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.Key));
    #endregion
    #region Json
    /// <inheritdoc cref="PulumiConfigGetSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Json))]
    public static T SetJson<T>(this T o, bool? v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Json, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Json))]
    public static T ResetJson<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.Json));
    /// <inheritdoc cref="PulumiConfigGetSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Json))]
    public static T EnableJson<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Json, true));
    /// <inheritdoc cref="PulumiConfigGetSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Json))]
    public static T DisableJson<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Json, false));
    /// <inheritdoc cref="PulumiConfigGetSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Json))]
    public static T ToggleJson<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Json, !o.Json));
    #endregion
    #region Path
    /// <inheritdoc cref="PulumiConfigGetSettings.Path"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Path))]
    public static T SetPath<T>(this T o, string v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Path, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.Path"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Path))]
    public static T ResetPath<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.Path));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiConfigGetSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiConfigGetSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiConfigGetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiConfigGetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiConfigGetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiConfigGetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiConfigGetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiConfigGetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiConfigGetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiConfigGetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiConfigGetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiConfigGetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiConfigGetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiConfigGetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiConfigGetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiConfigGetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiConfigGetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiConfigGetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiConfigGetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiConfigGetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiConfigGetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiConfigGetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiConfigGetSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiConfigGetSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiConfigGetSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiConfigGetSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiConfigGetSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiConfigGetSettings), Property = nameof(PulumiConfigGetSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiConfigGetSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiConfigRefreshSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiConfigRefreshSettingsExtensions
{
    #region Force
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Force))]
    public static T ResetForce<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Force))]
    public static T EnableForce<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Force))]
    public static T DisableForce<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiConfigRefreshSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiConfigRefreshSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiConfigRefreshSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiConfigRefreshSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiConfigRefreshSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRefreshSettings), Property = nameof(PulumiConfigRefreshSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiConfigRefreshSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiConfigRemoveSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiConfigRemoveSettingsExtensions
{
    #region Key
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Key"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Key))]
    public static T SetKey<T>(this T o, string v) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.Key, v));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Key"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Key))]
    public static T ResetKey<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Remove(() => o.Key));
    #endregion
    #region Path
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Path"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Path))]
    public static T SetPath<T>(this T o, string v) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.Path, v));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Path"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Path))]
    public static T ResetPath<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Remove(() => o.Path));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiConfigRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiConfigRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiConfigRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiConfigRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiConfigRemoveSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiConfigRemoveSettings), Property = nameof(PulumiConfigRemoveSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiConfigRemoveSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiConfigSetSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiConfigSetSettingsExtensions
{
    #region Key
    /// <inheritdoc cref="PulumiConfigSetSettings.Key"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Key))]
    public static T SetKey<T>(this T o, string v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Key, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.Key"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Key))]
    public static T ResetKey<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.Key));
    #endregion
    #region Value
    /// <inheritdoc cref="PulumiConfigSetSettings.Value"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Value))]
    public static T SetValue<T>(this T o, string v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Value, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.Value"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Value))]
    public static T ResetValue<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.Value));
    #endregion
    #region Path
    /// <inheritdoc cref="PulumiConfigSetSettings.Path"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Path))]
    public static T SetPath<T>(this T o, string v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Path, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.Path"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Path))]
    public static T ResetPath<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.Path));
    #endregion
    #region Plaintext
    /// <inheritdoc cref="PulumiConfigSetSettings.Plaintext"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Plaintext))]
    public static T SetPlaintext<T>(this T o, bool? v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Plaintext, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.Plaintext"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Plaintext))]
    public static T ResetPlaintext<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.Plaintext));
    /// <inheritdoc cref="PulumiConfigSetSettings.Plaintext"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Plaintext))]
    public static T EnablePlaintext<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Plaintext, true));
    /// <inheritdoc cref="PulumiConfigSetSettings.Plaintext"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Plaintext))]
    public static T DisablePlaintext<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Plaintext, false));
    /// <inheritdoc cref="PulumiConfigSetSettings.Plaintext"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Plaintext))]
    public static T TogglePlaintext<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Plaintext, !o.Plaintext));
    #endregion
    #region Secret
    /// <inheritdoc cref="PulumiConfigSetSettings.Secret"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Secret))]
    public static T SetSecret<T>(this T o, bool? v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Secret, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.Secret"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Secret))]
    public static T ResetSecret<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.Secret));
    /// <inheritdoc cref="PulumiConfigSetSettings.Secret"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Secret))]
    public static T EnableSecret<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Secret, true));
    /// <inheritdoc cref="PulumiConfigSetSettings.Secret"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Secret))]
    public static T DisableSecret<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Secret, false));
    /// <inheritdoc cref="PulumiConfigSetSettings.Secret"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Secret))]
    public static T ToggleSecret<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Secret, !o.Secret));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiConfigSetSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiConfigSetSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiConfigSetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiConfigSetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiConfigSetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiConfigSetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiConfigSetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiConfigSetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiConfigSetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiConfigSetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiConfigSetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiConfigSetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiConfigSetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiConfigSetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiConfigSetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiConfigSetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiConfigSetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiConfigSetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiConfigSetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiConfigSetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiConfigSetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiConfigSetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiConfigSetSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiConfigSetSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiConfigSetSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiConfigSetSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiConfigSetSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiConfigSetSettings), Property = nameof(PulumiConfigSetSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiConfigSetSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackSettingsExtensions
{
    #region ShowIds
    /// <inheritdoc cref="PulumiStackSettings.ShowIds"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowIds))]
    public static T SetShowIds<T>(this T o, bool? v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowIds, v));
    /// <inheritdoc cref="PulumiStackSettings.ShowIds"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowIds))]
    public static T ResetShowIds<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.ShowIds));
    /// <inheritdoc cref="PulumiStackSettings.ShowIds"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowIds))]
    public static T EnableShowIds<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowIds, true));
    /// <inheritdoc cref="PulumiStackSettings.ShowIds"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowIds))]
    public static T DisableShowIds<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowIds, false));
    /// <inheritdoc cref="PulumiStackSettings.ShowIds"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowIds))]
    public static T ToggleShowIds<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowIds, !o.ShowIds));
    #endregion
    #region ShowName
    /// <inheritdoc cref="PulumiStackSettings.ShowName"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowName))]
    public static T SetShowName<T>(this T o, bool? v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowName, v));
    /// <inheritdoc cref="PulumiStackSettings.ShowName"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowName))]
    public static T ResetShowName<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.ShowName));
    /// <inheritdoc cref="PulumiStackSettings.ShowName"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowName))]
    public static T EnableShowName<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowName, true));
    /// <inheritdoc cref="PulumiStackSettings.ShowName"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowName))]
    public static T DisableShowName<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowName, false));
    /// <inheritdoc cref="PulumiStackSettings.ShowName"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowName))]
    public static T ToggleShowName<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowName, !o.ShowName));
    #endregion
    #region ShowSecrets
    /// <inheritdoc cref="PulumiStackSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowSecrets))]
    public static T SetShowSecrets<T>(this T o, bool? v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowSecrets, v));
    /// <inheritdoc cref="PulumiStackSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowSecrets))]
    public static T ResetShowSecrets<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.ShowSecrets));
    /// <inheritdoc cref="PulumiStackSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowSecrets))]
    public static T EnableShowSecrets<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowSecrets, true));
    /// <inheritdoc cref="PulumiStackSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowSecrets))]
    public static T DisableShowSecrets<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowSecrets, false));
    /// <inheritdoc cref="PulumiStackSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowSecrets))]
    public static T ToggleShowSecrets<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowSecrets, !o.ShowSecrets));
    #endregion
    #region ShowUrns
    /// <inheritdoc cref="PulumiStackSettings.ShowUrns"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowUrns))]
    public static T SetShowUrns<T>(this T o, bool? v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowUrns, v));
    /// <inheritdoc cref="PulumiStackSettings.ShowUrns"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowUrns))]
    public static T ResetShowUrns<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.ShowUrns));
    /// <inheritdoc cref="PulumiStackSettings.ShowUrns"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowUrns))]
    public static T EnableShowUrns<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowUrns, true));
    /// <inheritdoc cref="PulumiStackSettings.ShowUrns"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowUrns))]
    public static T DisableShowUrns<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowUrns, false));
    /// <inheritdoc cref="PulumiStackSettings.ShowUrns"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.ShowUrns))]
    public static T ToggleShowUrns<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.ShowUrns, !o.ShowUrns));
    #endregion
    #region Stack
    /// <inheritdoc cref="PulumiStackSettings.Stack"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Stack))]
    public static T SetStack<T>(this T o, string v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.Stack, v));
    /// <inheritdoc cref="PulumiStackSettings.Stack"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Stack))]
    public static T ResetStack<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.Stack));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackSettings), Property = nameof(PulumiStackSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackChangeSecretsProviderSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackChangeSecretsProviderSettingsExtensions
{
    #region NewSecretsProvider
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.NewSecretsProvider"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.NewSecretsProvider))]
    public static T SetNewSecretsProvider<T>(this T o, string v) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.NewSecretsProvider, v));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.NewSecretsProvider"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.NewSecretsProvider))]
    public static T ResetNewSecretsProvider<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Remove(() => o.NewSecretsProvider));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackChangeSecretsProviderSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackChangeSecretsProviderSettings), Property = nameof(PulumiStackChangeSecretsProviderSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackChangeSecretsProviderSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackExportSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackExportSettingsExtensions
{
    #region File
    /// <inheritdoc cref="PulumiStackExportSettings.File"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.File))]
    public static T SetFile<T>(this T o, string v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.File, v));
    /// <inheritdoc cref="PulumiStackExportSettings.File"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.File))]
    public static T ResetFile<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.File));
    #endregion
    #region ShowSecrets
    /// <inheritdoc cref="PulumiStackExportSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.ShowSecrets))]
    public static T SetShowSecrets<T>(this T o, bool? v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.ShowSecrets, v));
    /// <inheritdoc cref="PulumiStackExportSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.ShowSecrets))]
    public static T ResetShowSecrets<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.ShowSecrets));
    /// <inheritdoc cref="PulumiStackExportSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.ShowSecrets))]
    public static T EnableShowSecrets<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.ShowSecrets, true));
    /// <inheritdoc cref="PulumiStackExportSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.ShowSecrets))]
    public static T DisableShowSecrets<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.ShowSecrets, false));
    /// <inheritdoc cref="PulumiStackExportSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.ShowSecrets))]
    public static T ToggleShowSecrets<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.ShowSecrets, !o.ShowSecrets));
    #endregion
    #region Version
    /// <inheritdoc cref="PulumiStackExportSettings.Version"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Version))]
    public static T SetVersion<T>(this T o, string v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.Version, v));
    /// <inheritdoc cref="PulumiStackExportSettings.Version"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Version))]
    public static T ResetVersion<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.Version));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackExportSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackExportSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackExportSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackExportSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackExportSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackExportSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackExportSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackExportSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackExportSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackExportSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackExportSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackExportSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackExportSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackExportSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackExportSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackExportSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackExportSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackExportSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackExportSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackExportSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackExportSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackExportSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackExportSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackExportSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackExportSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackExportSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackExportSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackExportSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackExportSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackExportSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackExportSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackExportSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackExportSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackExportSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackExportSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackExportSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackExportSettings), Property = nameof(PulumiStackExportSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackExportSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackGraphSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackGraphSettingsExtensions
{
    #region File
    /// <inheritdoc cref="PulumiStackGraphSettings.File"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.File))]
    public static T SetFile<T>(this T o, string v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.File, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.File"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.File))]
    public static T ResetFile<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.File));
    #endregion
    #region DependencyEdgeColor
    /// <inheritdoc cref="PulumiStackGraphSettings.DependencyEdgeColor"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.DependencyEdgeColor))]
    public static T SetDependencyEdgeColor<T>(this T o, string v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.DependencyEdgeColor, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.DependencyEdgeColor"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.DependencyEdgeColor))]
    public static T ResetDependencyEdgeColor<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.DependencyEdgeColor));
    #endregion
    #region IgnoreDependencyEdges
    /// <inheritdoc cref="PulumiStackGraphSettings.IgnoreDependencyEdges"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.IgnoreDependencyEdges))]
    public static T SetIgnoreDependencyEdges<T>(this T o, bool? v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.IgnoreDependencyEdges, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.IgnoreDependencyEdges"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.IgnoreDependencyEdges))]
    public static T ResetIgnoreDependencyEdges<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.IgnoreDependencyEdges));
    /// <inheritdoc cref="PulumiStackGraphSettings.IgnoreDependencyEdges"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.IgnoreDependencyEdges))]
    public static T EnableIgnoreDependencyEdges<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.IgnoreDependencyEdges, true));
    /// <inheritdoc cref="PulumiStackGraphSettings.IgnoreDependencyEdges"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.IgnoreDependencyEdges))]
    public static T DisableIgnoreDependencyEdges<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.IgnoreDependencyEdges, false));
    /// <inheritdoc cref="PulumiStackGraphSettings.IgnoreDependencyEdges"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.IgnoreDependencyEdges))]
    public static T ToggleIgnoreDependencyEdges<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.IgnoreDependencyEdges, !o.IgnoreDependencyEdges));
    #endregion
    #region IgnoreParentEdges
    /// <inheritdoc cref="PulumiStackGraphSettings.IgnoreParentEdges"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.IgnoreParentEdges))]
    public static T SetIgnoreParentEdges<T>(this T o, bool? v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.IgnoreParentEdges, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.IgnoreParentEdges"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.IgnoreParentEdges))]
    public static T ResetIgnoreParentEdges<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.IgnoreParentEdges));
    /// <inheritdoc cref="PulumiStackGraphSettings.IgnoreParentEdges"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.IgnoreParentEdges))]
    public static T EnableIgnoreParentEdges<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.IgnoreParentEdges, true));
    /// <inheritdoc cref="PulumiStackGraphSettings.IgnoreParentEdges"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.IgnoreParentEdges))]
    public static T DisableIgnoreParentEdges<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.IgnoreParentEdges, false));
    /// <inheritdoc cref="PulumiStackGraphSettings.IgnoreParentEdges"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.IgnoreParentEdges))]
    public static T ToggleIgnoreParentEdges<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.IgnoreParentEdges, !o.IgnoreParentEdges));
    #endregion
    #region ParentEdgeColor
    /// <inheritdoc cref="PulumiStackGraphSettings.ParentEdgeColor"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.ParentEdgeColor))]
    public static T SetParentEdgeColor<T>(this T o, string v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.ParentEdgeColor, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.ParentEdgeColor"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.ParentEdgeColor))]
    public static T ResetParentEdgeColor<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.ParentEdgeColor));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackGraphSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackGraphSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackGraphSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackGraphSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackGraphSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackGraphSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackGraphSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackGraphSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackGraphSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackGraphSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackGraphSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackGraphSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackGraphSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackGraphSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackGraphSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackGraphSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackGraphSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackGraphSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackGraphSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackGraphSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackGraphSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackGraphSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackGraphSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackGraphSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackGraphSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackGraphSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackGraphSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackGraphSettings), Property = nameof(PulumiStackGraphSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackGraphSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackHistorySettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackHistorySettingsExtensions
{
    #region Json
    /// <inheritdoc cref="PulumiStackHistorySettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Json))]
    public static T SetJson<T>(this T o, bool? v) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Json, v));
    /// <inheritdoc cref="PulumiStackHistorySettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Json))]
    public static T ResetJson<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Remove(() => o.Json));
    /// <inheritdoc cref="PulumiStackHistorySettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Json))]
    public static T EnableJson<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Json, true));
    /// <inheritdoc cref="PulumiStackHistorySettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Json))]
    public static T DisableJson<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Json, false));
    /// <inheritdoc cref="PulumiStackHistorySettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Json))]
    public static T ToggleJson<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Json, !o.Json));
    #endregion
    #region ShowSecrets
    /// <inheritdoc cref="PulumiStackHistorySettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.ShowSecrets))]
    public static T SetShowSecrets<T>(this T o, bool? v) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.ShowSecrets, v));
    /// <inheritdoc cref="PulumiStackHistorySettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.ShowSecrets))]
    public static T ResetShowSecrets<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Remove(() => o.ShowSecrets));
    /// <inheritdoc cref="PulumiStackHistorySettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.ShowSecrets))]
    public static T EnableShowSecrets<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.ShowSecrets, true));
    /// <inheritdoc cref="PulumiStackHistorySettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.ShowSecrets))]
    public static T DisableShowSecrets<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.ShowSecrets, false));
    /// <inheritdoc cref="PulumiStackHistorySettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.ShowSecrets))]
    public static T ToggleShowSecrets<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.ShowSecrets, !o.ShowSecrets));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackHistorySettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackHistorySettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackHistorySettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackHistorySettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackHistorySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackHistorySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackHistorySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackHistorySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackHistorySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackHistorySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackHistorySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackHistorySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackHistorySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackHistorySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackHistorySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackHistorySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackHistorySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackHistorySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackHistorySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackHistorySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackHistorySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackHistorySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackHistorySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackHistorySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackHistorySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackHistorySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackHistorySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackHistorySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackHistorySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackHistorySettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackHistorySettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackHistorySettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackHistorySettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackHistorySettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackHistorySettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackHistorySettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackHistorySettings), Property = nameof(PulumiStackHistorySettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackHistorySettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackImportSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackImportSettingsExtensions
{
    #region File
    /// <inheritdoc cref="PulumiStackImportSettings.File"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.File))]
    public static T SetFile<T>(this T o, string v) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.File, v));
    /// <inheritdoc cref="PulumiStackImportSettings.File"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.File))]
    public static T ResetFile<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Remove(() => o.File));
    #endregion
    #region Force
    /// <inheritdoc cref="PulumiStackImportSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="PulumiStackImportSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Force))]
    public static T ResetForce<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="PulumiStackImportSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Force))]
    public static T EnableForce<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="PulumiStackImportSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Force))]
    public static T DisableForce<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="PulumiStackImportSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackImportSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackImportSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackImportSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackImportSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackImportSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackImportSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackImportSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackImportSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackImportSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackImportSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackImportSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackImportSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackImportSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackImportSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackImportSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackImportSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackImportSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackImportSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackImportSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackImportSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackImportSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackImportSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackImportSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackImportSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackImportSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackImportSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackImportSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackImportSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackImportSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackImportSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackImportSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackImportSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackImportSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackImportSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackImportSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackImportSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackImportSettings), Property = nameof(PulumiStackImportSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackImportSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackInitSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackInitSettingsExtensions
{
    #region OrganizationAndName
    /// <inheritdoc cref="PulumiStackInitSettings.OrganizationAndName"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.OrganizationAndName))]
    public static T SetOrganizationAndName<T>(this T o, string v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.OrganizationAndName, v));
    /// <inheritdoc cref="PulumiStackInitSettings.OrganizationAndName"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.OrganizationAndName))]
    public static T ResetOrganizationAndName<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.OrganizationAndName));
    #endregion
    #region CopyConfigFrom
    /// <inheritdoc cref="PulumiStackInitSettings.CopyConfigFrom"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.CopyConfigFrom))]
    public static T SetCopyConfigFrom<T>(this T o, string v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.CopyConfigFrom, v));
    /// <inheritdoc cref="PulumiStackInitSettings.CopyConfigFrom"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.CopyConfigFrom))]
    public static T ResetCopyConfigFrom<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.CopyConfigFrom));
    #endregion
    #region SecretsProvider
    /// <inheritdoc cref="PulumiStackInitSettings.SecretsProvider"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.SecretsProvider))]
    public static T SetSecretsProvider<T>(this T o, PulumiSecretsProvider v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.SecretsProvider, v));
    /// <inheritdoc cref="PulumiStackInitSettings.SecretsProvider"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.SecretsProvider))]
    public static T ResetSecretsProvider<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.SecretsProvider));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackInitSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackInitSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackInitSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackInitSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackInitSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackInitSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackInitSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackInitSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackInitSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackInitSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackInitSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackInitSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackInitSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackInitSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackInitSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackInitSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackInitSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackInitSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackInitSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackInitSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackInitSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackInitSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackInitSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackInitSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackInitSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackInitSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackInitSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackInitSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackInitSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackInitSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackInitSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackInitSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackInitSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackInitSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackInitSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackInitSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackInitSettings), Property = nameof(PulumiStackInitSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackInitSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackListSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackListSettingsExtensions
{
    #region All
    /// <inheritdoc cref="PulumiStackListSettings.All"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.All))]
    public static T SetAll<T>(this T o, bool? v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.All, v));
    /// <inheritdoc cref="PulumiStackListSettings.All"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.All))]
    public static T ResetAll<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.All));
    /// <inheritdoc cref="PulumiStackListSettings.All"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.All))]
    public static T EnableAll<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.All, true));
    /// <inheritdoc cref="PulumiStackListSettings.All"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.All))]
    public static T DisableAll<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.All, false));
    /// <inheritdoc cref="PulumiStackListSettings.All"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.All))]
    public static T ToggleAll<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.All, !o.All));
    #endregion
    #region Json
    /// <inheritdoc cref="PulumiStackListSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Json))]
    public static T SetJson<T>(this T o, bool? v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Json, v));
    /// <inheritdoc cref="PulumiStackListSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Json))]
    public static T ResetJson<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.Json));
    /// <inheritdoc cref="PulumiStackListSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Json))]
    public static T EnableJson<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Json, true));
    /// <inheritdoc cref="PulumiStackListSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Json))]
    public static T DisableJson<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Json, false));
    /// <inheritdoc cref="PulumiStackListSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Json))]
    public static T ToggleJson<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Json, !o.Json));
    #endregion
    #region Organization
    /// <inheritdoc cref="PulumiStackListSettings.Organization"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Organization))]
    public static T SetOrganization<T>(this T o, string v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Organization, v));
    /// <inheritdoc cref="PulumiStackListSettings.Organization"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Organization))]
    public static T ResetOrganization<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.Organization));
    #endregion
    #region Project
    /// <inheritdoc cref="PulumiStackListSettings.Project"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Project))]
    public static T SetProject<T>(this T o, string v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Project, v));
    /// <inheritdoc cref="PulumiStackListSettings.Project"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Project))]
    public static T ResetProject<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.Project));
    #endregion
    #region Tag
    /// <inheritdoc cref="PulumiStackListSettings.Tag"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Tag))]
    public static T SetTag<T>(this T o, string v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Tag, v));
    /// <inheritdoc cref="PulumiStackListSettings.Tag"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Tag))]
    public static T ResetTag<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.Tag));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackListSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackListSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackListSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackListSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackListSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackListSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackListSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackListSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackListSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackListSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackListSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackListSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackListSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackListSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackListSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackListSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackListSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackListSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackListSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackListSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackListSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackListSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackListSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackListSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackListSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackListSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackListSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackListSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackListSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackListSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackListSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackListSettings), Property = nameof(PulumiStackListSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackListSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackOutputSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackOutputSettingsExtensions
{
    #region PropertyName
    /// <inheritdoc cref="PulumiStackOutputSettings.PropertyName"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.PropertyName))]
    public static T SetPropertyName<T>(this T o, string v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.PropertyName, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.PropertyName"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.PropertyName))]
    public static T ResetPropertyName<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.PropertyName));
    #endregion
    #region Json
    /// <inheritdoc cref="PulumiStackOutputSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Json))]
    public static T SetJson<T>(this T o, bool? v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Json, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Json))]
    public static T ResetJson<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.Json));
    /// <inheritdoc cref="PulumiStackOutputSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Json))]
    public static T EnableJson<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Json, true));
    /// <inheritdoc cref="PulumiStackOutputSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Json))]
    public static T DisableJson<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Json, false));
    /// <inheritdoc cref="PulumiStackOutputSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Json))]
    public static T ToggleJson<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Json, !o.Json));
    #endregion
    #region ShowSecrets
    /// <inheritdoc cref="PulumiStackOutputSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.ShowSecrets))]
    public static T SetShowSecrets<T>(this T o, bool? v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.ShowSecrets, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.ShowSecrets))]
    public static T ResetShowSecrets<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.ShowSecrets));
    /// <inheritdoc cref="PulumiStackOutputSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.ShowSecrets))]
    public static T EnableShowSecrets<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.ShowSecrets, true));
    /// <inheritdoc cref="PulumiStackOutputSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.ShowSecrets))]
    public static T DisableShowSecrets<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.ShowSecrets, false));
    /// <inheritdoc cref="PulumiStackOutputSettings.ShowSecrets"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.ShowSecrets))]
    public static T ToggleShowSecrets<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.ShowSecrets, !o.ShowSecrets));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackOutputSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackOutputSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackOutputSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackOutputSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackOutputSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackOutputSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackOutputSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackOutputSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackOutputSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackOutputSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackOutputSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackOutputSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackOutputSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackOutputSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackOutputSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackOutputSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackOutputSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackOutputSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackOutputSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackOutputSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackOutputSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackOutputSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackOutputSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackOutputSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackOutputSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackOutputSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackOutputSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackOutputSettings), Property = nameof(PulumiStackOutputSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackOutputSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackRenameSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackRenameSettingsExtensions
{
    #region NewStackName
    /// <inheritdoc cref="PulumiStackRenameSettings.NewStackName"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.NewStackName))]
    public static T SetNewStackName<T>(this T o, string v) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.NewStackName, v));
    /// <inheritdoc cref="PulumiStackRenameSettings.NewStackName"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.NewStackName))]
    public static T ResetNewStackName<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Remove(() => o.NewStackName));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackRenameSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackRenameSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackRenameSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackRenameSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackRenameSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackRenameSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackRenameSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackRenameSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackRenameSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackRenameSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackRenameSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackRenameSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackRenameSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackRenameSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackRenameSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackRenameSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackRenameSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackRenameSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackRenameSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackRenameSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackRenameSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackRenameSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackRenameSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackRenameSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackRenameSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackRenameSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackRenameSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackRenameSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackRenameSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackRenameSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackRenameSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackRenameSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackRenameSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackRenameSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackRenameSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackRenameSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackRenameSettings), Property = nameof(PulumiStackRenameSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackRenameSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackRemoveSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackRemoveSettingsExtensions
{
    #region StackName
    /// <inheritdoc cref="PulumiStackRemoveSettings.StackName"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.StackName))]
    public static T SetStackName<T>(this T o, string v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.StackName, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.StackName"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.StackName))]
    public static T ResetStackName<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.StackName));
    #endregion
    #region Force
    /// <inheritdoc cref="PulumiStackRemoveSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Force))]
    public static T ResetForce<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Force))]
    public static T EnableForce<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Force))]
    public static T DisableForce<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region PreserveConfig
    /// <inheritdoc cref="PulumiStackRemoveSettings.PreserveConfig"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.PreserveConfig))]
    public static T SetPreserveConfig<T>(this T o, bool? v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.PreserveConfig, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.PreserveConfig"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.PreserveConfig))]
    public static T ResetPreserveConfig<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.PreserveConfig));
    /// <inheritdoc cref="PulumiStackRemoveSettings.PreserveConfig"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.PreserveConfig))]
    public static T EnablePreserveConfig<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.PreserveConfig, true));
    /// <inheritdoc cref="PulumiStackRemoveSettings.PreserveConfig"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.PreserveConfig))]
    public static T DisablePreserveConfig<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.PreserveConfig, false));
    /// <inheritdoc cref="PulumiStackRemoveSettings.PreserveConfig"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.PreserveConfig))]
    public static T TogglePreserveConfig<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.PreserveConfig, !o.PreserveConfig));
    #endregion
    #region Yes
    /// <inheritdoc cref="PulumiStackRemoveSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Yes))]
    public static T SetYes<T>(this T o, bool? v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Yes, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Yes))]
    public static T ResetYes<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.Yes));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Yes))]
    public static T EnableYes<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Yes, true));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Yes))]
    public static T DisableYes<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Yes, false));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Yes))]
    public static T ToggleYes<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Yes, !o.Yes));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackRemoveSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackRemoveSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackRemoveSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackRemoveSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackRemoveSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackRemoveSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackRemoveSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackRemoveSettings), Property = nameof(PulumiStackRemoveSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackRemoveSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackSelectSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackSelectSettingsExtensions
{
    #region StackName
    /// <inheritdoc cref="PulumiStackSelectSettings.StackName"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.StackName))]
    public static T SetStackName<T>(this T o, string v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.StackName, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.StackName"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.StackName))]
    public static T ResetStackName<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.StackName));
    #endregion
    #region Create
    /// <inheritdoc cref="PulumiStackSelectSettings.Create"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Create))]
    public static T SetCreate<T>(this T o, bool? v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Create, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.Create"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Create))]
    public static T ResetCreate<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.Create));
    /// <inheritdoc cref="PulumiStackSelectSettings.Create"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Create))]
    public static T EnableCreate<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Create, true));
    /// <inheritdoc cref="PulumiStackSelectSettings.Create"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Create))]
    public static T DisableCreate<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Create, false));
    /// <inheritdoc cref="PulumiStackSelectSettings.Create"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Create))]
    public static T ToggleCreate<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Create, !o.Create));
    #endregion
    #region SecretsProvider
    /// <inheritdoc cref="PulumiStackSelectSettings.SecretsProvider"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.SecretsProvider))]
    public static T SetSecretsProvider<T>(this T o, PulumiSecretsProvider v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.SecretsProvider, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.SecretsProvider"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.SecretsProvider))]
    public static T ResetSecretsProvider<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.SecretsProvider));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackSelectSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackSelectSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackSelectSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackSelectSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackSelectSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackSelectSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackSelectSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackSelectSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackSelectSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackSelectSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackSelectSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackSelectSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackSelectSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackSelectSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackSelectSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackSelectSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackSelectSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackSelectSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackSelectSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackSelectSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackSelectSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackSelectSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackSelectSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackSelectSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackSelectSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackSelectSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackSelectSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackSelectSettings), Property = nameof(PulumiStackSelectSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackSelectSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackTagSetSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackTagSetSettingsExtensions
{
    #region Name
    /// <inheritdoc cref="PulumiStackTagSetSettings.Name"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="PulumiStackTagSetSettings.Name"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Name))]
    public static T ResetName<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Value
    /// <inheritdoc cref="PulumiStackTagSetSettings.Value"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Value))]
    public static T SetValue<T>(this T o, string v) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.Value, v));
    /// <inheritdoc cref="PulumiStackTagSetSettings.Value"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Value))]
    public static T ResetValue<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Remove(() => o.Value));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackTagSetSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackTagSetSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackTagSetSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackTagSetSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackTagSetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackTagSetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackTagSetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackTagSetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackTagSetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackTagSetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackTagSetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackTagSetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackTagSetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackTagSetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackTagSetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackTagSetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackTagSetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackTagSetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackTagSetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackTagSetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackTagSetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackTagSetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackTagSetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackTagSetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackTagSetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackTagSetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackTagSetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackTagSetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackTagSetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackTagSetSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackTagSetSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackTagSetSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackTagSetSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackTagSetSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackTagSetSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackTagSetSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagSetSettings), Property = nameof(PulumiStackTagSetSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackTagSetSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackTagGetSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackTagGetSettingsExtensions
{
    #region Name
    /// <inheritdoc cref="PulumiStackTagGetSettings.Name"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="PulumiStackTagGetSettings.Name"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Name))]
    public static T ResetName<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackTagGetSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackTagGetSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackTagGetSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackTagGetSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackTagGetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackTagGetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackTagGetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackTagGetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackTagGetSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackTagGetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackTagGetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackTagGetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackTagGetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackTagGetSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackTagGetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackTagGetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackTagGetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackTagGetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackTagGetSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackTagGetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackTagGetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackTagGetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackTagGetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackTagGetSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackTagGetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackTagGetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackTagGetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackTagGetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackTagGetSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackTagGetSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackTagGetSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackTagGetSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackTagGetSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackTagGetSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackTagGetSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackTagGetSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagGetSettings), Property = nameof(PulumiStackTagGetSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackTagGetSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackTagRemoveSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackTagRemoveSettingsExtensions
{
    #region Name
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Name"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Name"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Name))]
    public static T ResetName<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackTagRemoveSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagRemoveSettings), Property = nameof(PulumiStackTagRemoveSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackTagRemoveSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiStackTagListSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiStackTagListSettingsExtensions
{
    #region Json
    /// <inheritdoc cref="PulumiStackTagListSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Json))]
    public static T SetJson<T>(this T o, bool? v) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Json, v));
    /// <inheritdoc cref="PulumiStackTagListSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Json))]
    public static T ResetJson<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Remove(() => o.Json));
    /// <inheritdoc cref="PulumiStackTagListSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Json))]
    public static T EnableJson<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Json, true));
    /// <inheritdoc cref="PulumiStackTagListSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Json))]
    public static T DisableJson<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Json, false));
    /// <inheritdoc cref="PulumiStackTagListSettings.Json"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Json))]
    public static T ToggleJson<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Json, !o.Json));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiStackTagListSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiStackTagListSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiStackTagListSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiStackTagListSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiStackTagListSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiStackTagListSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiStackTagListSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiStackTagListSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiStackTagListSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiStackTagListSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiStackTagListSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiStackTagListSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiStackTagListSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiStackTagListSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiStackTagListSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiStackTagListSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiStackTagListSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiStackTagListSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiStackTagListSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiStackTagListSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiStackTagListSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiStackTagListSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiStackTagListSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiStackTagListSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiStackTagListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiStackTagListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiStackTagListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiStackTagListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiStackTagListSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiStackTagListSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiStackTagListSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiStackTagListSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiStackTagListSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiStackTagListSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiStackTagListSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiStackTagListSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiStackTagListSettings), Property = nameof(PulumiStackTagListSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiStackTagListSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiNewSettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiNewSettingsExtensions
{
    #region Template
    /// <inheritdoc cref="PulumiNewSettings.Template"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Template))]
    public static T SetTemplate<T>(this T o, string v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Template, v));
    /// <inheritdoc cref="PulumiNewSettings.Template"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Template))]
    public static T ResetTemplate<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Template));
    #endregion
    #region Config
    /// <inheritdoc cref="PulumiNewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Config))]
    public static T SetConfig<T>(this T o, params string[] v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Config, v));
    /// <inheritdoc cref="PulumiNewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Config))]
    public static T SetConfig<T>(this T o, IEnumerable<string> v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Config, v));
    /// <inheritdoc cref="PulumiNewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Config))]
    public static T AddConfig<T>(this T o, params string[] v) where T : PulumiNewSettings => o.Modify(b => b.AddCollection(() => o.Config, v));
    /// <inheritdoc cref="PulumiNewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Config))]
    public static T AddConfig<T>(this T o, IEnumerable<string> v) where T : PulumiNewSettings => o.Modify(b => b.AddCollection(() => o.Config, v));
    /// <inheritdoc cref="PulumiNewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Config))]
    public static T RemoveConfig<T>(this T o, params string[] v) where T : PulumiNewSettings => o.Modify(b => b.RemoveCollection(() => o.Config, v));
    /// <inheritdoc cref="PulumiNewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Config))]
    public static T RemoveConfig<T>(this T o, IEnumerable<string> v) where T : PulumiNewSettings => o.Modify(b => b.RemoveCollection(() => o.Config, v));
    /// <inheritdoc cref="PulumiNewSettings.Config"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Config))]
    public static T ClearConfig<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.ClearCollection(() => o.Config));
    #endregion
    #region ConfigPath
    /// <inheritdoc cref="PulumiNewSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.ConfigPath))]
    public static T SetConfigPath<T>(this T o, bool? v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.ConfigPath, v));
    /// <inheritdoc cref="PulumiNewSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.ConfigPath))]
    public static T ResetConfigPath<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.ConfigPath));
    /// <inheritdoc cref="PulumiNewSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.ConfigPath))]
    public static T EnableConfigPath<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.ConfigPath, true));
    /// <inheritdoc cref="PulumiNewSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.ConfigPath))]
    public static T DisableConfigPath<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.ConfigPath, false));
    /// <inheritdoc cref="PulumiNewSettings.ConfigPath"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.ConfigPath))]
    public static T ToggleConfigPath<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.ConfigPath, !o.ConfigPath));
    #endregion
    #region Description
    /// <inheritdoc cref="PulumiNewSettings.Description"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Description))]
    public static T SetDescription<T>(this T o, string v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Description, v));
    /// <inheritdoc cref="PulumiNewSettings.Description"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Description))]
    public static T ResetDescription<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Description));
    #endregion
    #region Directory
    /// <inheritdoc cref="PulumiNewSettings.Directory"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Directory))]
    public static T SetDirectory<T>(this T o, string v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Directory, v));
    /// <inheritdoc cref="PulumiNewSettings.Directory"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Directory))]
    public static T ResetDirectory<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Directory));
    #endregion
    #region Force
    /// <inheritdoc cref="PulumiNewSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Force))]
    public static T SetForce<T>(this T o, bool? v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Force, v));
    /// <inheritdoc cref="PulumiNewSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Force))]
    public static T ResetForce<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Force));
    /// <inheritdoc cref="PulumiNewSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Force))]
    public static T EnableForce<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Force, true));
    /// <inheritdoc cref="PulumiNewSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Force))]
    public static T DisableForce<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Force, false));
    /// <inheritdoc cref="PulumiNewSettings.Force"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Force))]
    public static T ToggleForce<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Force, !o.Force));
    #endregion
    #region GenerateOnly
    /// <inheritdoc cref="PulumiNewSettings.GenerateOnly"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.GenerateOnly))]
    public static T SetGenerateOnly<T>(this T o, bool? v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.GenerateOnly, v));
    /// <inheritdoc cref="PulumiNewSettings.GenerateOnly"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.GenerateOnly))]
    public static T ResetGenerateOnly<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.GenerateOnly));
    /// <inheritdoc cref="PulumiNewSettings.GenerateOnly"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.GenerateOnly))]
    public static T EnableGenerateOnly<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.GenerateOnly, true));
    /// <inheritdoc cref="PulumiNewSettings.GenerateOnly"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.GenerateOnly))]
    public static T DisableGenerateOnly<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.GenerateOnly, false));
    /// <inheritdoc cref="PulumiNewSettings.GenerateOnly"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.GenerateOnly))]
    public static T ToggleGenerateOnly<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.GenerateOnly, !o.GenerateOnly));
    #endregion
    #region Name
    /// <inheritdoc cref="PulumiNewSettings.Name"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="PulumiNewSettings.Name"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Name))]
    public static T ResetName<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Offline
    /// <inheritdoc cref="PulumiNewSettings.Offline"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Offline))]
    public static T SetOffline<T>(this T o, bool? v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Offline, v));
    /// <inheritdoc cref="PulumiNewSettings.Offline"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Offline))]
    public static T ResetOffline<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Offline));
    /// <inheritdoc cref="PulumiNewSettings.Offline"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Offline))]
    public static T EnableOffline<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Offline, true));
    /// <inheritdoc cref="PulumiNewSettings.Offline"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Offline))]
    public static T DisableOffline<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Offline, false));
    /// <inheritdoc cref="PulumiNewSettings.Offline"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Offline))]
    public static T ToggleOffline<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Offline, !o.Offline));
    #endregion
    #region SecretsProvider
    /// <inheritdoc cref="PulumiNewSettings.SecretsProvider"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.SecretsProvider))]
    public static T SetSecretsProvider<T>(this T o, PulumiSecretsProvider v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.SecretsProvider, v));
    /// <inheritdoc cref="PulumiNewSettings.SecretsProvider"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.SecretsProvider))]
    public static T ResetSecretsProvider<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.SecretsProvider));
    #endregion
    #region Stack
    /// <inheritdoc cref="PulumiNewSettings.Stack"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Stack))]
    public static T SetStack<T>(this T o, string v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Stack, v));
    /// <inheritdoc cref="PulumiNewSettings.Stack"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Stack))]
    public static T ResetStack<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Stack));
    #endregion
    #region Yes
    /// <inheritdoc cref="PulumiNewSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Yes))]
    public static T SetYes<T>(this T o, bool? v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Yes, v));
    /// <inheritdoc cref="PulumiNewSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Yes))]
    public static T ResetYes<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Yes));
    /// <inheritdoc cref="PulumiNewSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Yes))]
    public static T EnableYes<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Yes, true));
    /// <inheritdoc cref="PulumiNewSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Yes))]
    public static T DisableYes<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Yes, false));
    /// <inheritdoc cref="PulumiNewSettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Yes))]
    public static T ToggleYes<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Yes, !o.Yes));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiNewSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiNewSettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiNewSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiNewSettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiNewSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiNewSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiNewSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiNewSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiNewSettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiNewSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiNewSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiNewSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiNewSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiNewSettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiNewSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiNewSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiNewSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiNewSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiNewSettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiNewSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiNewSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiNewSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiNewSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiNewSettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiNewSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiNewSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiNewSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiNewSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiNewSettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiNewSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiNewSettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiNewSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiNewSettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiNewSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiNewSettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiNewSettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiNewSettings), Property = nameof(PulumiNewSettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiNewSettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiDestroySettingsExtensions
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class PulumiDestroySettingsExtensions
{
    #region ConfigFile
    /// <inheritdoc cref="PulumiDestroySettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ConfigFile))]
    public static T SetConfigFile<T>(this T o, string v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ConfigFile, v));
    /// <inheritdoc cref="PulumiDestroySettings.ConfigFile"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ConfigFile))]
    public static T ResetConfigFile<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.ConfigFile));
    #endregion
    #region Debug
    /// <inheritdoc cref="PulumiDestroySettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Debug))]
    public static T SetDebug<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Debug, v));
    /// <inheritdoc cref="PulumiDestroySettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Debug))]
    public static T ResetDebug<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Debug));
    /// <inheritdoc cref="PulumiDestroySettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Debug))]
    public static T EnableDebug<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Debug, true));
    /// <inheritdoc cref="PulumiDestroySettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Debug))]
    public static T DisableDebug<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Debug, false));
    /// <inheritdoc cref="PulumiDestroySettings.Debug"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Debug))]
    public static T ToggleDebug<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Debug, !o.Debug));
    #endregion
    #region Diff
    /// <inheritdoc cref="PulumiDestroySettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Diff))]
    public static T SetDiff<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Diff, v));
    /// <inheritdoc cref="PulumiDestroySettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Diff))]
    public static T ResetDiff<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Diff));
    /// <inheritdoc cref="PulumiDestroySettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Diff))]
    public static T EnableDiff<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Diff, true));
    /// <inheritdoc cref="PulumiDestroySettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Diff))]
    public static T DisableDiff<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Diff, false));
    /// <inheritdoc cref="PulumiDestroySettings.Diff"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Diff))]
    public static T ToggleDiff<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Diff, !o.Diff));
    #endregion
    #region Message
    /// <inheritdoc cref="PulumiDestroySettings.Message"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Message))]
    public static T SetMessage<T>(this T o, string v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Message, v));
    /// <inheritdoc cref="PulumiDestroySettings.Message"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Message))]
    public static T ResetMessage<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Message));
    #endregion
    #region Parallel
    /// <inheritdoc cref="PulumiDestroySettings.Parallel"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Parallel))]
    public static T SetParallel<T>(this T o, int? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Parallel, v));
    /// <inheritdoc cref="PulumiDestroySettings.Parallel"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Parallel))]
    public static T ResetParallel<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Parallel));
    #endregion
    #region Refresh
    /// <inheritdoc cref="PulumiDestroySettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Refresh))]
    public static T SetRefresh<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Refresh, v));
    /// <inheritdoc cref="PulumiDestroySettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Refresh))]
    public static T ResetRefresh<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Refresh));
    /// <inheritdoc cref="PulumiDestroySettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Refresh))]
    public static T EnableRefresh<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Refresh, true));
    /// <inheritdoc cref="PulumiDestroySettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Refresh))]
    public static T DisableRefresh<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Refresh, false));
    /// <inheritdoc cref="PulumiDestroySettings.Refresh"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Refresh))]
    public static T ToggleRefresh<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Refresh, !o.Refresh));
    #endregion
    #region ShowConfig
    /// <inheritdoc cref="PulumiDestroySettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowConfig))]
    public static T SetShowConfig<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ShowConfig, v));
    /// <inheritdoc cref="PulumiDestroySettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowConfig))]
    public static T ResetShowConfig<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.ShowConfig));
    /// <inheritdoc cref="PulumiDestroySettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowConfig))]
    public static T EnableShowConfig<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ShowConfig, true));
    /// <inheritdoc cref="PulumiDestroySettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowConfig))]
    public static T DisableShowConfig<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ShowConfig, false));
    /// <inheritdoc cref="PulumiDestroySettings.ShowConfig"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowConfig))]
    public static T ToggleShowConfig<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ShowConfig, !o.ShowConfig));
    #endregion
    #region ShowReplacementSteps
    /// <inheritdoc cref="PulumiDestroySettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowReplacementSteps))]
    public static T SetShowReplacementSteps<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ShowReplacementSteps, v));
    /// <inheritdoc cref="PulumiDestroySettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowReplacementSteps))]
    public static T ResetShowReplacementSteps<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.ShowReplacementSteps));
    /// <inheritdoc cref="PulumiDestroySettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowReplacementSteps))]
    public static T EnableShowReplacementSteps<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ShowReplacementSteps, true));
    /// <inheritdoc cref="PulumiDestroySettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowReplacementSteps))]
    public static T DisableShowReplacementSteps<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ShowReplacementSteps, false));
    /// <inheritdoc cref="PulumiDestroySettings.ShowReplacementSteps"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowReplacementSteps))]
    public static T ToggleShowReplacementSteps<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ShowReplacementSteps, !o.ShowReplacementSteps));
    #endregion
    #region ShowSames
    /// <inheritdoc cref="PulumiDestroySettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowSames))]
    public static T SetShowSames<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ShowSames, v));
    /// <inheritdoc cref="PulumiDestroySettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowSames))]
    public static T ResetShowSames<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.ShowSames));
    /// <inheritdoc cref="PulumiDestroySettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowSames))]
    public static T EnableShowSames<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ShowSames, true));
    /// <inheritdoc cref="PulumiDestroySettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowSames))]
    public static T DisableShowSames<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ShowSames, false));
    /// <inheritdoc cref="PulumiDestroySettings.ShowSames"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.ShowSames))]
    public static T ToggleShowSames<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.ShowSames, !o.ShowSames));
    #endregion
    #region SkipPreview
    /// <inheritdoc cref="PulumiDestroySettings.SkipPreview"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SkipPreview))]
    public static T SetSkipPreview<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.SkipPreview, v));
    /// <inheritdoc cref="PulumiDestroySettings.SkipPreview"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SkipPreview))]
    public static T ResetSkipPreview<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.SkipPreview));
    /// <inheritdoc cref="PulumiDestroySettings.SkipPreview"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SkipPreview))]
    public static T EnableSkipPreview<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.SkipPreview, true));
    /// <inheritdoc cref="PulumiDestroySettings.SkipPreview"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SkipPreview))]
    public static T DisableSkipPreview<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.SkipPreview, false));
    /// <inheritdoc cref="PulumiDestroySettings.SkipPreview"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SkipPreview))]
    public static T ToggleSkipPreview<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.SkipPreview, !o.SkipPreview));
    #endregion
    #region Stack
    /// <inheritdoc cref="PulumiDestroySettings.Stack"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Stack))]
    public static T SetStack<T>(this T o, string v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Stack, v));
    /// <inheritdoc cref="PulumiDestroySettings.Stack"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Stack))]
    public static T ResetStack<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Stack));
    #endregion
    #region SuppressOutputs
    /// <inheritdoc cref="PulumiDestroySettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SuppressOutputs))]
    public static T SetSuppressOutputs<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.SuppressOutputs, v));
    /// <inheritdoc cref="PulumiDestroySettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SuppressOutputs))]
    public static T ResetSuppressOutputs<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.SuppressOutputs));
    /// <inheritdoc cref="PulumiDestroySettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SuppressOutputs))]
    public static T EnableSuppressOutputs<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.SuppressOutputs, true));
    /// <inheritdoc cref="PulumiDestroySettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SuppressOutputs))]
    public static T DisableSuppressOutputs<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.SuppressOutputs, false));
    /// <inheritdoc cref="PulumiDestroySettings.SuppressOutputs"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SuppressOutputs))]
    public static T ToggleSuppressOutputs<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.SuppressOutputs, !o.SuppressOutputs));
    #endregion
    #region SuppressPermalink
    /// <inheritdoc cref="PulumiDestroySettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SuppressPermalink))]
    public static T SetSuppressPermalink<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.SuppressPermalink, v));
    /// <inheritdoc cref="PulumiDestroySettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SuppressPermalink))]
    public static T ResetSuppressPermalink<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.SuppressPermalink));
    /// <inheritdoc cref="PulumiDestroySettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SuppressPermalink))]
    public static T EnableSuppressPermalink<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.SuppressPermalink, true));
    /// <inheritdoc cref="PulumiDestroySettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SuppressPermalink))]
    public static T DisableSuppressPermalink<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.SuppressPermalink, false));
    /// <inheritdoc cref="PulumiDestroySettings.SuppressPermalink"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.SuppressPermalink))]
    public static T ToggleSuppressPermalink<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.SuppressPermalink, !o.SuppressPermalink));
    #endregion
    #region Target
    /// <inheritdoc cref="PulumiDestroySettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Target))]
    public static T SetTarget<T>(this T o, params string[] v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Target, v));
    /// <inheritdoc cref="PulumiDestroySettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Target))]
    public static T SetTarget<T>(this T o, IEnumerable<string> v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Target, v));
    /// <inheritdoc cref="PulumiDestroySettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Target))]
    public static T AddTarget<T>(this T o, params string[] v) where T : PulumiDestroySettings => o.Modify(b => b.AddCollection(() => o.Target, v));
    /// <inheritdoc cref="PulumiDestroySettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Target))]
    public static T AddTarget<T>(this T o, IEnumerable<string> v) where T : PulumiDestroySettings => o.Modify(b => b.AddCollection(() => o.Target, v));
    /// <inheritdoc cref="PulumiDestroySettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Target))]
    public static T RemoveTarget<T>(this T o, params string[] v) where T : PulumiDestroySettings => o.Modify(b => b.RemoveCollection(() => o.Target, v));
    /// <inheritdoc cref="PulumiDestroySettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Target))]
    public static T RemoveTarget<T>(this T o, IEnumerable<string> v) where T : PulumiDestroySettings => o.Modify(b => b.RemoveCollection(() => o.Target, v));
    /// <inheritdoc cref="PulumiDestroySettings.Target"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Target))]
    public static T ClearTarget<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.ClearCollection(() => o.Target));
    #endregion
    #region TargetDependents
    /// <inheritdoc cref="PulumiDestroySettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.TargetDependents))]
    public static T SetTargetDependents<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.TargetDependents, v));
    /// <inheritdoc cref="PulumiDestroySettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.TargetDependents))]
    public static T ResetTargetDependents<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.TargetDependents));
    /// <inheritdoc cref="PulumiDestroySettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.TargetDependents))]
    public static T EnableTargetDependents<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.TargetDependents, true));
    /// <inheritdoc cref="PulumiDestroySettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.TargetDependents))]
    public static T DisableTargetDependents<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.TargetDependents, false));
    /// <inheritdoc cref="PulumiDestroySettings.TargetDependents"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.TargetDependents))]
    public static T ToggleTargetDependents<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.TargetDependents, !o.TargetDependents));
    #endregion
    #region Yes
    /// <inheritdoc cref="PulumiDestroySettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Yes))]
    public static T SetYes<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Yes, v));
    /// <inheritdoc cref="PulumiDestroySettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Yes))]
    public static T ResetYes<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Yes));
    /// <inheritdoc cref="PulumiDestroySettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Yes))]
    public static T EnableYes<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Yes, true));
    /// <inheritdoc cref="PulumiDestroySettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Yes))]
    public static T DisableYes<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Yes, false));
    /// <inheritdoc cref="PulumiDestroySettings.Yes"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Yes))]
    public static T ToggleYes<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Yes, !o.Yes));
    #endregion
    #region Color
    /// <inheritdoc cref="PulumiDestroySettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Color))]
    public static T SetColor<T>(this T o, string v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Color, v));
    /// <inheritdoc cref="PulumiDestroySettings.Color"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Color))]
    public static T ResetColor<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Color));
    #endregion
    #region Cwd
    /// <inheritdoc cref="PulumiDestroySettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Cwd))]
    public static T SetCwd<T>(this T o, string v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Cwd, v));
    /// <inheritdoc cref="PulumiDestroySettings.Cwd"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Cwd))]
    public static T ResetCwd<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Cwd));
    #endregion
    #region DisableIntegrityChecking
    /// <inheritdoc cref="PulumiDestroySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.DisableIntegrityChecking))]
    public static T SetDisableIntegrityChecking<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, v));
    /// <inheritdoc cref="PulumiDestroySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.DisableIntegrityChecking))]
    public static T ResetDisableIntegrityChecking<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.DisableIntegrityChecking));
    /// <inheritdoc cref="PulumiDestroySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.DisableIntegrityChecking))]
    public static T EnableDisableIntegrityChecking<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, true));
    /// <inheritdoc cref="PulumiDestroySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.DisableIntegrityChecking))]
    public static T DisableDisableIntegrityChecking<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, false));
    /// <inheritdoc cref="PulumiDestroySettings.DisableIntegrityChecking"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.DisableIntegrityChecking))]
    public static T ToggleDisableIntegrityChecking<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.DisableIntegrityChecking, !o.DisableIntegrityChecking));
    #endregion
    #region Emoji
    /// <inheritdoc cref="PulumiDestroySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Emoji))]
    public static T SetEmoji<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Emoji, v));
    /// <inheritdoc cref="PulumiDestroySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Emoji))]
    public static T ResetEmoji<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Emoji));
    /// <inheritdoc cref="PulumiDestroySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Emoji))]
    public static T EnableEmoji<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Emoji, true));
    /// <inheritdoc cref="PulumiDestroySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Emoji))]
    public static T DisableEmoji<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Emoji, false));
    /// <inheritdoc cref="PulumiDestroySettings.Emoji"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Emoji))]
    public static T ToggleEmoji<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Emoji, !o.Emoji));
    #endregion
    #region LogFlow
    /// <inheritdoc cref="PulumiDestroySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.LogFlow))]
    public static T SetLogFlow<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.LogFlow, v));
    /// <inheritdoc cref="PulumiDestroySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.LogFlow))]
    public static T ResetLogFlow<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.LogFlow));
    /// <inheritdoc cref="PulumiDestroySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.LogFlow))]
    public static T EnableLogFlow<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.LogFlow, true));
    /// <inheritdoc cref="PulumiDestroySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.LogFlow))]
    public static T DisableLogFlow<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.LogFlow, false));
    /// <inheritdoc cref="PulumiDestroySettings.LogFlow"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.LogFlow))]
    public static T ToggleLogFlow<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.LogFlow, !o.LogFlow));
    #endregion
    #region LogToStderr
    /// <inheritdoc cref="PulumiDestroySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.LogToStderr))]
    public static T SetLogToStderr<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.LogToStderr, v));
    /// <inheritdoc cref="PulumiDestroySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.LogToStderr))]
    public static T ResetLogToStderr<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.LogToStderr));
    /// <inheritdoc cref="PulumiDestroySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.LogToStderr))]
    public static T EnableLogToStderr<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.LogToStderr, true));
    /// <inheritdoc cref="PulumiDestroySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.LogToStderr))]
    public static T DisableLogToStderr<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.LogToStderr, false));
    /// <inheritdoc cref="PulumiDestroySettings.LogToStderr"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.LogToStderr))]
    public static T ToggleLogToStderr<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.LogToStderr, !o.LogToStderr));
    #endregion
    #region NonInteractive
    /// <inheritdoc cref="PulumiDestroySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.NonInteractive))]
    public static T SetNonInteractive<T>(this T o, bool? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.NonInteractive, v));
    /// <inheritdoc cref="PulumiDestroySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.NonInteractive))]
    public static T ResetNonInteractive<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.NonInteractive));
    /// <inheritdoc cref="PulumiDestroySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.NonInteractive))]
    public static T EnableNonInteractive<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.NonInteractive, true));
    /// <inheritdoc cref="PulumiDestroySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.NonInteractive))]
    public static T DisableNonInteractive<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.NonInteractive, false));
    /// <inheritdoc cref="PulumiDestroySettings.NonInteractive"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.NonInteractive))]
    public static T ToggleNonInteractive<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.NonInteractive, !o.NonInteractive));
    #endregion
    #region Profiling
    /// <inheritdoc cref="PulumiDestroySettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Profiling))]
    public static T SetProfiling<T>(this T o, string v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Profiling, v));
    /// <inheritdoc cref="PulumiDestroySettings.Profiling"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Profiling))]
    public static T ResetProfiling<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Profiling));
    #endregion
    #region Tracing
    /// <inheritdoc cref="PulumiDestroySettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Tracing))]
    public static T SetTracing<T>(this T o, string v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Tracing, v));
    /// <inheritdoc cref="PulumiDestroySettings.Tracing"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Tracing))]
    public static T ResetTracing<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Tracing));
    #endregion
    #region Verbose
    /// <inheritdoc cref="PulumiDestroySettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Verbose))]
    public static T SetVerbose<T>(this T o, int? v) where T : PulumiDestroySettings => o.Modify(b => b.Set(() => o.Verbose, v));
    /// <inheritdoc cref="PulumiDestroySettings.Verbose"/>
    [Pure] [Builder(Type = typeof(PulumiDestroySettings), Property = nameof(PulumiDestroySettings.Verbose))]
    public static T ResetVerbose<T>(this T o) where T : PulumiDestroySettings => o.Modify(b => b.Remove(() => o.Verbose));
    #endregion
}
#endregion
#region PulumiSecretsProvider
/// <summary>Used within <see cref="PulumiTasks"/>.</summary>
[PublicAPI]
[Serializable]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<PulumiSecretsProvider>))]
public partial class PulumiSecretsProvider : Enumeration
{
    public static PulumiSecretsProvider default_ = (PulumiSecretsProvider) "default";
    public static PulumiSecretsProvider passphrase = (PulumiSecretsProvider) "passphrase";
    public static PulumiSecretsProvider awskms = (PulumiSecretsProvider) "awskms";
    public static PulumiSecretsProvider azurekeyvault = (PulumiSecretsProvider) "azurekeyvault";
    public static PulumiSecretsProvider gcpkms = (PulumiSecretsProvider) "gcpkms";
    public static PulumiSecretsProvider hashivault = (PulumiSecretsProvider) "hashivault";
    public static implicit operator PulumiSecretsProvider(string value)
    {
        return new PulumiSecretsProvider { Value = value };
    }
}
#endregion
