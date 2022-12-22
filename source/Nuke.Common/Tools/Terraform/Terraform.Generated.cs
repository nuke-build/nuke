// Generated from https://github.com/matt-psaltis/nuke/blob/master/source/Nuke.Common/Tools/Terraform/Terraform.json

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

namespace Nuke.Common.Tools.Terraform
{
    /// <summary>
    ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class TerraformTasks
    {
        /// <summary>
        ///   Path to the Terraform executable.
        /// </summary>
        public static string TerraformPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("TERRAFORM_EXE") ??
            ToolPathResolver.GetPathExecutable("terraform");
        public static Action<OutputType, string> TerraformLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Terraform(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            using var process = ProcessTasks.StartProcess(TerraformPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, TerraformLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Initialize a new or existing Terraform working directory by creating initial files, loading any remote state, downloading modules, etc.  This is the first command that should be run for any new or existing Terraform configuration per machine. This sets up all the local data necessary to run Terraform that is typically not committed to version control.  This command is always safe to run multiple times. Though subsequent runs may give errors, this command will never delete your configuration or state. Even so, if you have important information, please back it up prior to running this command, just in case.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-backend</c> via <see cref="TerraformInitSettings.Backend"/></li>
        ///     <li><c>-backend-config</c> via <see cref="TerraformInitSettings.BackendConfig"/></li>
        ///     <li><c>-chdir</c> via <see cref="TerraformInitSettings.ChangeDirectory"/></li>
        ///     <li><c>-force-copy</c> via <see cref="TerraformInitSettings.ForceCopy"/></li>
        ///     <li><c>-from-module</c> via <see cref="TerraformInitSettings.FromModule"/></li>
        ///     <li><c>-get</c> via <see cref="TerraformInitSettings.GetModules"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformInitSettings.Help"/></li>
        ///     <li><c>-ignore-remote-version</c> via <see cref="TerraformInitSettings.IgnoreRemoteVersion"/></li>
        ///     <li><c>-input</c> via <see cref="TerraformInitSettings.Input"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformInitSettings.Json"/></li>
        ///     <li><c>-lock</c> via <see cref="TerraformInitSettings.Lock"/></li>
        ///     <li><c>-lock-timeout</c> via <see cref="TerraformInitSettings.LockTimeout"/></li>
        ///     <li><c>-lockfile</c> via <see cref="TerraformInitSettings.LockFile"/></li>
        ///     <li><c>-migrate-state</c> via <see cref="TerraformInitSettings.MigrateState"/></li>
        ///     <li><c>-no-color</c> via <see cref="TerraformInitSettings.NoColor"/></li>
        ///     <li><c>-plugin-dir</c> via <see cref="TerraformInitSettings.PluginDirectory"/></li>
        ///     <li><c>-reconfigure</c> via <see cref="TerraformInitSettings.Reconfigure"/></li>
        ///     <li><c>-upgrade</c> via <see cref="TerraformInitSettings.Upgrade"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformInitSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformInit(TerraformInitSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new TerraformInitSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Initialize a new or existing Terraform working directory by creating initial files, loading any remote state, downloading modules, etc.  This is the first command that should be run for any new or existing Terraform configuration per machine. This sets up all the local data necessary to run Terraform that is typically not committed to version control.  This command is always safe to run multiple times. Though subsequent runs may give errors, this command will never delete your configuration or state. Even so, if you have important information, please back it up prior to running this command, just in case.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-backend</c> via <see cref="TerraformInitSettings.Backend"/></li>
        ///     <li><c>-backend-config</c> via <see cref="TerraformInitSettings.BackendConfig"/></li>
        ///     <li><c>-chdir</c> via <see cref="TerraformInitSettings.ChangeDirectory"/></li>
        ///     <li><c>-force-copy</c> via <see cref="TerraformInitSettings.ForceCopy"/></li>
        ///     <li><c>-from-module</c> via <see cref="TerraformInitSettings.FromModule"/></li>
        ///     <li><c>-get</c> via <see cref="TerraformInitSettings.GetModules"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformInitSettings.Help"/></li>
        ///     <li><c>-ignore-remote-version</c> via <see cref="TerraformInitSettings.IgnoreRemoteVersion"/></li>
        ///     <li><c>-input</c> via <see cref="TerraformInitSettings.Input"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformInitSettings.Json"/></li>
        ///     <li><c>-lock</c> via <see cref="TerraformInitSettings.Lock"/></li>
        ///     <li><c>-lock-timeout</c> via <see cref="TerraformInitSettings.LockTimeout"/></li>
        ///     <li><c>-lockfile</c> via <see cref="TerraformInitSettings.LockFile"/></li>
        ///     <li><c>-migrate-state</c> via <see cref="TerraformInitSettings.MigrateState"/></li>
        ///     <li><c>-no-color</c> via <see cref="TerraformInitSettings.NoColor"/></li>
        ///     <li><c>-plugin-dir</c> via <see cref="TerraformInitSettings.PluginDirectory"/></li>
        ///     <li><c>-reconfigure</c> via <see cref="TerraformInitSettings.Reconfigure"/></li>
        ///     <li><c>-upgrade</c> via <see cref="TerraformInitSettings.Upgrade"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformInitSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformInit(Configure<TerraformInitSettings> configurator)
        {
            return TerraformInit(configurator(new TerraformInitSettings()));
        }
        /// <summary>
        ///   <p>Initialize a new or existing Terraform working directory by creating initial files, loading any remote state, downloading modules, etc.  This is the first command that should be run for any new or existing Terraform configuration per machine. This sets up all the local data necessary to run Terraform that is typically not committed to version control.  This command is always safe to run multiple times. Though subsequent runs may give errors, this command will never delete your configuration or state. Even so, if you have important information, please back it up prior to running this command, just in case.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-backend</c> via <see cref="TerraformInitSettings.Backend"/></li>
        ///     <li><c>-backend-config</c> via <see cref="TerraformInitSettings.BackendConfig"/></li>
        ///     <li><c>-chdir</c> via <see cref="TerraformInitSettings.ChangeDirectory"/></li>
        ///     <li><c>-force-copy</c> via <see cref="TerraformInitSettings.ForceCopy"/></li>
        ///     <li><c>-from-module</c> via <see cref="TerraformInitSettings.FromModule"/></li>
        ///     <li><c>-get</c> via <see cref="TerraformInitSettings.GetModules"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformInitSettings.Help"/></li>
        ///     <li><c>-ignore-remote-version</c> via <see cref="TerraformInitSettings.IgnoreRemoteVersion"/></li>
        ///     <li><c>-input</c> via <see cref="TerraformInitSettings.Input"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformInitSettings.Json"/></li>
        ///     <li><c>-lock</c> via <see cref="TerraformInitSettings.Lock"/></li>
        ///     <li><c>-lock-timeout</c> via <see cref="TerraformInitSettings.LockTimeout"/></li>
        ///     <li><c>-lockfile</c> via <see cref="TerraformInitSettings.LockFile"/></li>
        ///     <li><c>-migrate-state</c> via <see cref="TerraformInitSettings.MigrateState"/></li>
        ///     <li><c>-no-color</c> via <see cref="TerraformInitSettings.NoColor"/></li>
        ///     <li><c>-plugin-dir</c> via <see cref="TerraformInitSettings.PluginDirectory"/></li>
        ///     <li><c>-reconfigure</c> via <see cref="TerraformInitSettings.Reconfigure"/></li>
        ///     <li><c>-upgrade</c> via <see cref="TerraformInitSettings.Upgrade"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformInitSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(TerraformInitSettings Settings, IReadOnlyCollection<Output> Output)> TerraformInit(CombinatorialConfigure<TerraformInitSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(TerraformInit, TerraformLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] plan [options]    Generates a speculative execution plan, showing what actions Terraform   would take to apply the current configuration. This command will not   actually perform the planned actions.    You can optionally save the plan to a file, which you can then pass to   the "apply" command to perform exactly the actions described in the plan.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-chdir</c> via <see cref="TerraformPlanSettings.ChangeDirectory"/></li>
        ///     <li><c>-compact-warnings</c> via <see cref="TerraformPlanSettings.CompactWarnings"/></li>
        ///     <li><c>-destroy</c> via <see cref="TerraformPlanSettings.Destroy"/></li>
        ///     <li><c>-detailed-exitcode</c> via <see cref="TerraformPlanSettings.DetailedExitcode"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformPlanSettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformPlanSettings.Json"/></li>
        ///     <li><c>-out</c> via <see cref="TerraformPlanSettings.PlanOutput"/></li>
        ///     <li><c>-parallelism</c> via <see cref="TerraformPlanSettings.Parallelism"/></li>
        ///     <li><c>-refresh</c> via <see cref="TerraformPlanSettings.Refresh"/></li>
        ///     <li><c>-refresh-only</c> via <see cref="TerraformPlanSettings.RefreshOnly"/></li>
        ///     <li><c>-replace</c> via <see cref="TerraformPlanSettings.Replace"/></li>
        ///     <li><c>-target</c> via <see cref="TerraformPlanSettings.Target"/></li>
        ///     <li><c>-var</c> via <see cref="TerraformPlanSettings.Variable"/></li>
        ///     <li><c>-var</c> via <see cref="TerraformPlanSettings.SecretVariable"/></li>
        ///     <li><c>-var-file</c> via <see cref="TerraformPlanSettings.VariableFile"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformPlanSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformPlan(TerraformPlanSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new TerraformPlanSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] plan [options]    Generates a speculative execution plan, showing what actions Terraform   would take to apply the current configuration. This command will not   actually perform the planned actions.    You can optionally save the plan to a file, which you can then pass to   the "apply" command to perform exactly the actions described in the plan.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-chdir</c> via <see cref="TerraformPlanSettings.ChangeDirectory"/></li>
        ///     <li><c>-compact-warnings</c> via <see cref="TerraformPlanSettings.CompactWarnings"/></li>
        ///     <li><c>-destroy</c> via <see cref="TerraformPlanSettings.Destroy"/></li>
        ///     <li><c>-detailed-exitcode</c> via <see cref="TerraformPlanSettings.DetailedExitcode"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformPlanSettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformPlanSettings.Json"/></li>
        ///     <li><c>-out</c> via <see cref="TerraformPlanSettings.PlanOutput"/></li>
        ///     <li><c>-parallelism</c> via <see cref="TerraformPlanSettings.Parallelism"/></li>
        ///     <li><c>-refresh</c> via <see cref="TerraformPlanSettings.Refresh"/></li>
        ///     <li><c>-refresh-only</c> via <see cref="TerraformPlanSettings.RefreshOnly"/></li>
        ///     <li><c>-replace</c> via <see cref="TerraformPlanSettings.Replace"/></li>
        ///     <li><c>-target</c> via <see cref="TerraformPlanSettings.Target"/></li>
        ///     <li><c>-var</c> via <see cref="TerraformPlanSettings.Variable"/></li>
        ///     <li><c>-var</c> via <see cref="TerraformPlanSettings.SecretVariable"/></li>
        ///     <li><c>-var-file</c> via <see cref="TerraformPlanSettings.VariableFile"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformPlanSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformPlan(Configure<TerraformPlanSettings> configurator)
        {
            return TerraformPlan(configurator(new TerraformPlanSettings()));
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] plan [options]    Generates a speculative execution plan, showing what actions Terraform   would take to apply the current configuration. This command will not   actually perform the planned actions.    You can optionally save the plan to a file, which you can then pass to   the "apply" command to perform exactly the actions described in the plan.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-chdir</c> via <see cref="TerraformPlanSettings.ChangeDirectory"/></li>
        ///     <li><c>-compact-warnings</c> via <see cref="TerraformPlanSettings.CompactWarnings"/></li>
        ///     <li><c>-destroy</c> via <see cref="TerraformPlanSettings.Destroy"/></li>
        ///     <li><c>-detailed-exitcode</c> via <see cref="TerraformPlanSettings.DetailedExitcode"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformPlanSettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformPlanSettings.Json"/></li>
        ///     <li><c>-out</c> via <see cref="TerraformPlanSettings.PlanOutput"/></li>
        ///     <li><c>-parallelism</c> via <see cref="TerraformPlanSettings.Parallelism"/></li>
        ///     <li><c>-refresh</c> via <see cref="TerraformPlanSettings.Refresh"/></li>
        ///     <li><c>-refresh-only</c> via <see cref="TerraformPlanSettings.RefreshOnly"/></li>
        ///     <li><c>-replace</c> via <see cref="TerraformPlanSettings.Replace"/></li>
        ///     <li><c>-target</c> via <see cref="TerraformPlanSettings.Target"/></li>
        ///     <li><c>-var</c> via <see cref="TerraformPlanSettings.Variable"/></li>
        ///     <li><c>-var</c> via <see cref="TerraformPlanSettings.SecretVariable"/></li>
        ///     <li><c>-var-file</c> via <see cref="TerraformPlanSettings.VariableFile"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformPlanSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(TerraformPlanSettings Settings, IReadOnlyCollection<Output> Output)> TerraformPlan(CombinatorialConfigure<TerraformPlanSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(TerraformPlan, TerraformLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] validate [options] Validate the configuration files in a directory, referring only to the configuration and not accessing any remote services such as remote state, provider APIs, etc. Validate runs checks that verify whether a configuration is syntactically valid and internally consistent, regardless of any provided variables or existing state. It is thus primarily useful for general verification of reusable modules, including correctness of attribute names and value types. It is safe to run this command automatically, for example as a post-save check in a text editor or as a test step for a re-usable module in a CI system. Validation requires an initialized working directory with any referenced plugins and modules installed. To initialize a working directory for validation without accessing any configured remote backend, use: terraform init -backend=false. To verify configuration in the context of a particular run (a particular target workspace, input variable values, etc), use the 'terraform plan' command instead, which includes an implied validation check.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-chdir</c> via <see cref="TerraformValidateSettings.ChangeDirectory"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformValidateSettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformValidateSettings.Json"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformValidateSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformValidate(TerraformValidateSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new TerraformValidateSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] validate [options] Validate the configuration files in a directory, referring only to the configuration and not accessing any remote services such as remote state, provider APIs, etc. Validate runs checks that verify whether a configuration is syntactically valid and internally consistent, regardless of any provided variables or existing state. It is thus primarily useful for general verification of reusable modules, including correctness of attribute names and value types. It is safe to run this command automatically, for example as a post-save check in a text editor or as a test step for a re-usable module in a CI system. Validation requires an initialized working directory with any referenced plugins and modules installed. To initialize a working directory for validation without accessing any configured remote backend, use: terraform init -backend=false. To verify configuration in the context of a particular run (a particular target workspace, input variable values, etc), use the 'terraform plan' command instead, which includes an implied validation check.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-chdir</c> via <see cref="TerraformValidateSettings.ChangeDirectory"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformValidateSettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformValidateSettings.Json"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformValidateSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformValidate(Configure<TerraformValidateSettings> configurator)
        {
            return TerraformValidate(configurator(new TerraformValidateSettings()));
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] validate [options] Validate the configuration files in a directory, referring only to the configuration and not accessing any remote services such as remote state, provider APIs, etc. Validate runs checks that verify whether a configuration is syntactically valid and internally consistent, regardless of any provided variables or existing state. It is thus primarily useful for general verification of reusable modules, including correctness of attribute names and value types. It is safe to run this command automatically, for example as a post-save check in a text editor or as a test step for a re-usable module in a CI system. Validation requires an initialized working directory with any referenced plugins and modules installed. To initialize a working directory for validation without accessing any configured remote backend, use: terraform init -backend=false. To verify configuration in the context of a particular run (a particular target workspace, input variable values, etc), use the 'terraform plan' command instead, which includes an implied validation check.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-chdir</c> via <see cref="TerraformValidateSettings.ChangeDirectory"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformValidateSettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformValidateSettings.Json"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformValidateSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(TerraformValidateSettings Settings, IReadOnlyCollection<Output> Output)> TerraformValidate(CombinatorialConfigure<TerraformValidateSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(TerraformValidate, TerraformLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] force-unlock LOCK_ID Manually unlock the state for the defined configuration. This will not modify your infrastructure. This command removes the lock on the state for the current workspace. The behavior of this lock is dependent on the backend being used. Local state files cannot be unlocked by another process.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;lockId&gt;</c> via <see cref="TerraformForceUnlockSettings.LockId"/></li>
        ///     <li><c>-chdir</c> via <see cref="TerraformForceUnlockSettings.ChangeDirectory"/></li>
        ///     <li><c>-force</c> via <see cref="TerraformForceUnlockSettings.Force"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformForceUnlockSettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformForceUnlockSettings.Json"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformForceUnlockSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformForceUnlock(TerraformForceUnlockSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new TerraformForceUnlockSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] force-unlock LOCK_ID Manually unlock the state for the defined configuration. This will not modify your infrastructure. This command removes the lock on the state for the current workspace. The behavior of this lock is dependent on the backend being used. Local state files cannot be unlocked by another process.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;lockId&gt;</c> via <see cref="TerraformForceUnlockSettings.LockId"/></li>
        ///     <li><c>-chdir</c> via <see cref="TerraformForceUnlockSettings.ChangeDirectory"/></li>
        ///     <li><c>-force</c> via <see cref="TerraformForceUnlockSettings.Force"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformForceUnlockSettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformForceUnlockSettings.Json"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformForceUnlockSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformForceUnlock(Configure<TerraformForceUnlockSettings> configurator)
        {
            return TerraformForceUnlock(configurator(new TerraformForceUnlockSettings()));
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] force-unlock LOCK_ID Manually unlock the state for the defined configuration. This will not modify your infrastructure. This command removes the lock on the state for the current workspace. The behavior of this lock is dependent on the backend being used. Local state files cannot be unlocked by another process.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;lockId&gt;</c> via <see cref="TerraformForceUnlockSettings.LockId"/></li>
        ///     <li><c>-chdir</c> via <see cref="TerraformForceUnlockSettings.ChangeDirectory"/></li>
        ///     <li><c>-force</c> via <see cref="TerraformForceUnlockSettings.Force"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformForceUnlockSettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformForceUnlockSettings.Json"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformForceUnlockSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(TerraformForceUnlockSettings Settings, IReadOnlyCollection<Output> Output)> TerraformForceUnlock(CombinatorialConfigure<TerraformForceUnlockSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(TerraformForceUnlock, TerraformLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] graph [options] Produces a representation of the dependency graph between different objects in the current configuration and state. The graph is presented in the DOT language. The typical program that can read this format is GraphViz, but many web services are also available to read this format.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-chdir</c> via <see cref="TerraformGraphSettings.ChangeDirectory"/></li>
        ///     <li><c>-draw-cycles</c> via <see cref="TerraformGraphSettings.DrawCycles"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformGraphSettings.Help"/></li>
        ///     <li><c>-plan</c> via <see cref="TerraformGraphSettings.Plan"/></li>
        ///     <li><c>-type</c> via <see cref="TerraformGraphSettings.Type"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformGraphSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformGraph(TerraformGraphSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new TerraformGraphSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] graph [options] Produces a representation of the dependency graph between different objects in the current configuration and state. The graph is presented in the DOT language. The typical program that can read this format is GraphViz, but many web services are also available to read this format.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-chdir</c> via <see cref="TerraformGraphSettings.ChangeDirectory"/></li>
        ///     <li><c>-draw-cycles</c> via <see cref="TerraformGraphSettings.DrawCycles"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformGraphSettings.Help"/></li>
        ///     <li><c>-plan</c> via <see cref="TerraformGraphSettings.Plan"/></li>
        ///     <li><c>-type</c> via <see cref="TerraformGraphSettings.Type"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformGraphSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformGraph(Configure<TerraformGraphSettings> configurator)
        {
            return TerraformGraph(configurator(new TerraformGraphSettings()));
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] graph [options] Produces a representation of the dependency graph between different objects in the current configuration and state. The graph is presented in the DOT language. The typical program that can read this format is GraphViz, but many web services are also available to read this format.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-chdir</c> via <see cref="TerraformGraphSettings.ChangeDirectory"/></li>
        ///     <li><c>-draw-cycles</c> via <see cref="TerraformGraphSettings.DrawCycles"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformGraphSettings.Help"/></li>
        ///     <li><c>-plan</c> via <see cref="TerraformGraphSettings.Plan"/></li>
        ///     <li><c>-type</c> via <see cref="TerraformGraphSettings.Type"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformGraphSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(TerraformGraphSettings Settings, IReadOnlyCollection<Output> Output)> TerraformGraph(CombinatorialConfigure<TerraformGraphSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(TerraformGraph, TerraformLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] apply [options] [PLAN] Creates or updates infrastructure according to Terraform configuration files in the current directory. By default, Terraform will generate a new plan and present it for your approval before taking any action. You can optionally provide a plan file created by a previous call to "terraform plan", in which case Terraform will take the actions described in that plan without any confirmation prompt.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;planFile&gt;</c> via <see cref="TerraformApplySettings.PlanFile"/></li>
        ///     <li><c>-auto-approve</c> via <see cref="TerraformApplySettings.AutoApprove"/></li>
        ///     <li><c>-backup</c> via <see cref="TerraformApplySettings.Backup"/></li>
        ///     <li><c>-chdir</c> via <see cref="TerraformApplySettings.ChangeDirectory"/></li>
        ///     <li><c>-compact-warnings</c> via <see cref="TerraformApplySettings.CompactWarnings"/></li>
        ///     <li><c>-destroy</c> via <see cref="TerraformApplySettings.Destroy"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformApplySettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformApplySettings.Json"/></li>
        ///     <li><c>-lock</c> via <see cref="TerraformApplySettings.Lock"/></li>
        ///     <li><c>-lock-timeout</c> via <see cref="TerraformApplySettings.LockTimeout"/></li>
        ///     <li><c>-no-color</c> via <see cref="TerraformApplySettings.NoColor"/></li>
        ///     <li><c>-parallelism</c> via <see cref="TerraformApplySettings.Parallelism"/></li>
        ///     <li><c>-state</c> via <see cref="TerraformApplySettings.State"/></li>
        ///     <li><c>-state-out</c> via <see cref="TerraformApplySettings.StateOutput"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformApplySettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformApply(TerraformApplySettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new TerraformApplySettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] apply [options] [PLAN] Creates or updates infrastructure according to Terraform configuration files in the current directory. By default, Terraform will generate a new plan and present it for your approval before taking any action. You can optionally provide a plan file created by a previous call to "terraform plan", in which case Terraform will take the actions described in that plan without any confirmation prompt.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;planFile&gt;</c> via <see cref="TerraformApplySettings.PlanFile"/></li>
        ///     <li><c>-auto-approve</c> via <see cref="TerraformApplySettings.AutoApprove"/></li>
        ///     <li><c>-backup</c> via <see cref="TerraformApplySettings.Backup"/></li>
        ///     <li><c>-chdir</c> via <see cref="TerraformApplySettings.ChangeDirectory"/></li>
        ///     <li><c>-compact-warnings</c> via <see cref="TerraformApplySettings.CompactWarnings"/></li>
        ///     <li><c>-destroy</c> via <see cref="TerraformApplySettings.Destroy"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformApplySettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformApplySettings.Json"/></li>
        ///     <li><c>-lock</c> via <see cref="TerraformApplySettings.Lock"/></li>
        ///     <li><c>-lock-timeout</c> via <see cref="TerraformApplySettings.LockTimeout"/></li>
        ///     <li><c>-no-color</c> via <see cref="TerraformApplySettings.NoColor"/></li>
        ///     <li><c>-parallelism</c> via <see cref="TerraformApplySettings.Parallelism"/></li>
        ///     <li><c>-state</c> via <see cref="TerraformApplySettings.State"/></li>
        ///     <li><c>-state-out</c> via <see cref="TerraformApplySettings.StateOutput"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformApplySettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformApply(Configure<TerraformApplySettings> configurator)
        {
            return TerraformApply(configurator(new TerraformApplySettings()));
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] apply [options] [PLAN] Creates or updates infrastructure according to Terraform configuration files in the current directory. By default, Terraform will generate a new plan and present it for your approval before taking any action. You can optionally provide a plan file created by a previous call to "terraform plan", in which case Terraform will take the actions described in that plan without any confirmation prompt.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;planFile&gt;</c> via <see cref="TerraformApplySettings.PlanFile"/></li>
        ///     <li><c>-auto-approve</c> via <see cref="TerraformApplySettings.AutoApprove"/></li>
        ///     <li><c>-backup</c> via <see cref="TerraformApplySettings.Backup"/></li>
        ///     <li><c>-chdir</c> via <see cref="TerraformApplySettings.ChangeDirectory"/></li>
        ///     <li><c>-compact-warnings</c> via <see cref="TerraformApplySettings.CompactWarnings"/></li>
        ///     <li><c>-destroy</c> via <see cref="TerraformApplySettings.Destroy"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformApplySettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformApplySettings.Json"/></li>
        ///     <li><c>-lock</c> via <see cref="TerraformApplySettings.Lock"/></li>
        ///     <li><c>-lock-timeout</c> via <see cref="TerraformApplySettings.LockTimeout"/></li>
        ///     <li><c>-no-color</c> via <see cref="TerraformApplySettings.NoColor"/></li>
        ///     <li><c>-parallelism</c> via <see cref="TerraformApplySettings.Parallelism"/></li>
        ///     <li><c>-state</c> via <see cref="TerraformApplySettings.State"/></li>
        ///     <li><c>-state-out</c> via <see cref="TerraformApplySettings.StateOutput"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformApplySettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(TerraformApplySettings Settings, IReadOnlyCollection<Output> Output)> TerraformApply(CombinatorialConfigure<TerraformApplySettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(TerraformApply, TerraformLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] refresh [options] Update the state file of your infrastructure with metadata that matches the physical resources they are tracking. This will not modify your infrastructure, but it can modify your state file to update metadata. This metadata might cause new changes to occur when you generate a plan or call apply next.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-chdir</c> via <see cref="TerraformRefreshSettings.ChangeDirectory"/></li>
        ///     <li><c>-compact-warnings</c> via <see cref="TerraformRefreshSettings.CompactWarnings"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformRefreshSettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformRefreshSettings.Json"/></li>
        ///     <li><c>-lock</c> via <see cref="TerraformRefreshSettings.Lock"/></li>
        ///     <li><c>-lock-timeout</c> via <see cref="TerraformRefreshSettings.LockTimeout"/></li>
        ///     <li><c>-no-color</c> via <see cref="TerraformRefreshSettings.NoColor"/></li>
        ///     <li><c>-parallelism</c> via <see cref="TerraformRefreshSettings.Parallelism"/></li>
        ///     <li><c>-target</c> via <see cref="TerraformRefreshSettings.Target"/></li>
        ///     <li><c>-var</c> via <see cref="TerraformRefreshSettings.Variable"/></li>
        ///     <li><c>-var</c> via <see cref="TerraformRefreshSettings.SecretVariable"/></li>
        ///     <li><c>-var-file</c> via <see cref="TerraformRefreshSettings.VariableFile"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformRefreshSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformRefresh(TerraformRefreshSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new TerraformRefreshSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] refresh [options] Update the state file of your infrastructure with metadata that matches the physical resources they are tracking. This will not modify your infrastructure, but it can modify your state file to update metadata. This metadata might cause new changes to occur when you generate a plan or call apply next.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-chdir</c> via <see cref="TerraformRefreshSettings.ChangeDirectory"/></li>
        ///     <li><c>-compact-warnings</c> via <see cref="TerraformRefreshSettings.CompactWarnings"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformRefreshSettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformRefreshSettings.Json"/></li>
        ///     <li><c>-lock</c> via <see cref="TerraformRefreshSettings.Lock"/></li>
        ///     <li><c>-lock-timeout</c> via <see cref="TerraformRefreshSettings.LockTimeout"/></li>
        ///     <li><c>-no-color</c> via <see cref="TerraformRefreshSettings.NoColor"/></li>
        ///     <li><c>-parallelism</c> via <see cref="TerraformRefreshSettings.Parallelism"/></li>
        ///     <li><c>-target</c> via <see cref="TerraformRefreshSettings.Target"/></li>
        ///     <li><c>-var</c> via <see cref="TerraformRefreshSettings.Variable"/></li>
        ///     <li><c>-var</c> via <see cref="TerraformRefreshSettings.SecretVariable"/></li>
        ///     <li><c>-var-file</c> via <see cref="TerraformRefreshSettings.VariableFile"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformRefreshSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> TerraformRefresh(Configure<TerraformRefreshSettings> configurator)
        {
            return TerraformRefresh(configurator(new TerraformRefreshSettings()));
        }
        /// <summary>
        ///   <p>Usage: terraform [global options] refresh [options] Update the state file of your infrastructure with metadata that matches the physical resources they are tracking. This will not modify your infrastructure, but it can modify your state file to update metadata. This metadata might cause new changes to occur when you generate a plan or call apply next.</p>
        ///   <p>For more details, visit the <a href="https://www.terraform.io/">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-chdir</c> via <see cref="TerraformRefreshSettings.ChangeDirectory"/></li>
        ///     <li><c>-compact-warnings</c> via <see cref="TerraformRefreshSettings.CompactWarnings"/></li>
        ///     <li><c>-help</c> via <see cref="TerraformRefreshSettings.Help"/></li>
        ///     <li><c>-json</c> via <see cref="TerraformRefreshSettings.Json"/></li>
        ///     <li><c>-lock</c> via <see cref="TerraformRefreshSettings.Lock"/></li>
        ///     <li><c>-lock-timeout</c> via <see cref="TerraformRefreshSettings.LockTimeout"/></li>
        ///     <li><c>-no-color</c> via <see cref="TerraformRefreshSettings.NoColor"/></li>
        ///     <li><c>-parallelism</c> via <see cref="TerraformRefreshSettings.Parallelism"/></li>
        ///     <li><c>-target</c> via <see cref="TerraformRefreshSettings.Target"/></li>
        ///     <li><c>-var</c> via <see cref="TerraformRefreshSettings.Variable"/></li>
        ///     <li><c>-var</c> via <see cref="TerraformRefreshSettings.SecretVariable"/></li>
        ///     <li><c>-var-file</c> via <see cref="TerraformRefreshSettings.VariableFile"/></li>
        ///     <li><c>-version</c> via <see cref="TerraformRefreshSettings.Version"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(TerraformRefreshSettings Settings, IReadOnlyCollection<Output> Output)> TerraformRefresh(CombinatorialConfigure<TerraformRefreshSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(TerraformRefresh, TerraformLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region TerraformInitSettings
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class TerraformInitSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Terraform executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? TerraformTasks.TerraformPath;
        public override Action<OutputType, string> ProcessCustomLogger => TerraformTasks.TerraformLogger;
        /// <summary>
        ///   Disable backend or Terraform Cloud initialization for this configuration and use what was previously initialized instead. Aliases: -cloud=false.
        /// </summary>
        public virtual bool? Backend { get; internal set; }
        /// <summary>
        ///   Configuration to be merged with what is in the configuration file's 'backend' block. This can be either a path to an HCL file with key/value assignments (same format as terraform.tfvars) or a 'key=value' format, and can be specified multiple times. The backend type must be in the configuration itself.
        /// </summary>
        public virtual string BackendConfig { get; internal set; }
        /// <summary>
        ///   Suppress prompts about copying state data when initializating a new state backend. This is equivalent to providing a "yes" to all confirmation prompts.
        /// </summary>
        public virtual bool? ForceCopy { get; internal set; }
        /// <summary>
        ///   Copy the contents of the given module into the target directory before initialization.
        /// </summary>
        public virtual string FromModule { get; internal set; }
        /// <summary>
        ///   Disable downloading modules for this configuration.
        /// </summary>
        public virtual bool? GetModules { get; internal set; }
        /// <summary>
        ///   Disable interactive prompts. Note that some actions may require interactive prompts and will error if input is disabled.
        /// </summary>
        public virtual bool? Input { get; internal set; }
        /// <summary>
        ///   Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.
        /// </summary>
        public virtual bool? Lock { get; internal set; }
        /// <summary>
        ///   Duration to retry a state lock.
        /// </summary>
        public virtual int? LockTimeout { get; internal set; }
        /// <summary>
        ///   If specified, output won't contain any color.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Directory containing plugin binaries. This overrides all default search paths for plugins, and prevents the automatic installation of plugins. This flag can be used multiple times.
        /// </summary>
        public virtual string PluginDirectory { get; internal set; }
        /// <summary>
        ///   Reconfigure a backend, ignoring any saved configuration.
        /// </summary>
        public virtual bool? Reconfigure { get; internal set; }
        /// <summary>
        ///   Reconfigure a backend, and attempt to migrate any existing state.
        /// </summary>
        public virtual bool? MigrateState { get; internal set; }
        /// <summary>
        ///   Install the latest module and provider versions allowed within configured constraints, overriding the default behavior of selecting exactly the version recorded in the dependency lockfile.
        /// </summary>
        public virtual bool? Upgrade { get; internal set; }
        /// <summary>
        ///   Set a dependency lockfile mode. Currently only "readonly" is valid.
        /// </summary>
        public virtual bool? LockFile { get; internal set; }
        /// <summary>
        ///   A rare option used for Terraform Cloud and the remote backend only. Set this to ignore checking that the local and remote Terraform versions use compatible state representations, making an operation proceed even when there is a potential mismatch. See the documentation on configuring Terraform with Terraform Cloud for more information.
        /// </summary>
        public virtual bool? IgnoreRemoteVersion { get; internal set; }
        /// <summary>
        ///   Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   Help for Terraform.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Switch to a different working directory before executing the given subcommand.
        /// </summary>
        public virtual string ChangeDirectory { get; internal set; }
        /// <summary>
        ///   An alias for the "version" subcommand.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("init")
              .Add("-backend", Backend)
              .Add("-backend-config={value}", BackendConfig)
              .Add("-force-copy", ForceCopy)
              .Add("-from-module={value}", FromModule)
              .Add("-get", GetModules)
              .Add("-input", Input)
              .Add("-lock", Lock)
              .Add("-lock-timeout", LockTimeout)
              .Add("-no-color", NoColor)
              .Add("-plugin-dir={value}", PluginDirectory)
              .Add("-reconfigure", Reconfigure)
              .Add("-migrate-state", MigrateState)
              .Add("-upgrade", Upgrade)
              .Add("-lockfile", LockFile)
              .Add("-ignore-remote-version", IgnoreRemoteVersion)
              .Add("-json", Json)
              .Add("-help", Help)
              .Add("-chdir={value}", ChangeDirectory)
              .Add("-version", Version);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region TerraformPlanSettings
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class TerraformPlanSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Terraform executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? TerraformTasks.TerraformPath;
        public override Action<OutputType, string> ProcessCustomLogger => TerraformTasks.TerraformLogger;
        /// <summary>
        ///   Select the "destroy" planning mode, which creates a plan to destroy all objects currently managed by this Terraform configuration instead of the usual behavior.
        /// </summary>
        public virtual bool? Destroy { get; internal set; }
        /// <summary>
        ///   Select the "refresh only" planning mode, which checks whether remote objects still match the outcome of the most recent Terraform apply but does not propose any actions to undo any changes made outside of Terraform.
        /// </summary>
        public virtual bool? RefreshOnly { get; internal set; }
        /// <summary>
        ///   Skip checking for external changes to remote objects while creating the plan. This can potentially make planning faster, but at the expense of possibly planning against a stale record of the remote system state.
        /// </summary>
        public virtual bool? Refresh { get; internal set; }
        /// <summary>
        ///   Force replacement of a particular resource instance using its resource address. If the plan would've normally produced an update or no-op action for this instance, Terraform will plan to replace it instead. You can use this option multiple times to replace more than one object.
        /// </summary>
        public virtual string Replace { get; internal set; }
        /// <summary>
        ///   Limit the planning operation to only the given module, resource, or resource instance and all of its dependencies. You can use this option multiple times to include more than one object. This is for exceptional use only.
        /// </summary>
        public virtual string Target { get; internal set; }
        /// <summary>
        ///   Set a value for one of the input variables in the root module of the configuration. Use this option more than once to set more than one variable.
        /// </summary>
        public virtual string Variable { get; internal set; }
        /// <summary>
        ///   Set a value for one of the input variables in the root module of the configuration. Use this option more than once to set more than one variable.
        /// </summary>
        public virtual string SecretVariable { get; internal set; }
        /// <summary>
        ///   Load variable values from the given file, in addition to the default files terraform.tfvars and *.auto.tfvars. Use this option more than once to include more than one variables file.
        /// </summary>
        public virtual string VariableFile { get; internal set; }
        /// <summary>
        ///   If Terraform produces any warnings that are not accompanied by errors, shows them in a more compact form that includes only the summary messages.
        /// </summary>
        public virtual bool? CompactWarnings { get; internal set; }
        /// <summary>
        ///   Return detailed exit codes when the command exits. This will change the meaning of exit codes to:	0 - Succeeded, diff is empty (no changes)	1 - Errored	2 - Succeeded, there is a diff
        /// </summary>
        public virtual bool? DetailedExitcode { get; internal set; }
        /// <summary>
        ///   Write a plan file to the given path. This can be used as input to the "apply" command.
        /// </summary>
        public virtual string PlanOutput { get; internal set; }
        /// <summary>
        ///   Limit the number of concurrent operations. Defaults to 10.
        /// </summary>
        public virtual int? Parallelism { get; internal set; }
        /// <summary>
        ///   Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   Help for Terraform.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Switch to a different working directory before executing the given subcommand.
        /// </summary>
        public virtual string ChangeDirectory { get; internal set; }
        /// <summary>
        ///   An alias for the "version" subcommand.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("plan")
              .Add("-destroy", Destroy)
              .Add("-refresh-only", RefreshOnly)
              .Add("-refresh", Refresh)
              .Add("-replace={value}", Replace)
              .Add("-target={value}", Target)
              .Add("-var={value}", Variable)
              .Add("-var={value}", SecretVariable, secret: true)
              .Add("-var-file={value}", VariableFile)
              .Add("-compact-warnings", CompactWarnings)
              .Add("-detailed-exitcode", DetailedExitcode)
              .Add("-out={value}", PlanOutput)
              .Add("-parallelism={value}", Parallelism)
              .Add("-json", Json)
              .Add("-help", Help)
              .Add("-chdir={value}", ChangeDirectory)
              .Add("-version", Version);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region TerraformValidateSettings
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class TerraformValidateSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Terraform executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? TerraformTasks.TerraformPath;
        public override Action<OutputType, string> ProcessCustomLogger => TerraformTasks.TerraformLogger;
        /// <summary>
        ///   Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   Help for Terraform.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Switch to a different working directory before executing the given subcommand.
        /// </summary>
        public virtual string ChangeDirectory { get; internal set; }
        /// <summary>
        ///   An alias for the "version" subcommand.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("validate")
              .Add("-json", Json)
              .Add("-help", Help)
              .Add("-chdir={value}", ChangeDirectory)
              .Add("-version", Version);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region TerraformForceUnlockSettings
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class TerraformForceUnlockSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Terraform executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? TerraformTasks.TerraformPath;
        public override Action<OutputType, string> ProcessCustomLogger => TerraformTasks.TerraformLogger;
        /// <summary>
        ///   Don't ask for input for unlock confirmation.
        /// </summary>
        public virtual bool? Force { get; internal set; } = true;
        /// <summary>
        ///   Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   Help for Terraform.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Switch to a different working directory before executing the given subcommand.
        /// </summary>
        public virtual string ChangeDirectory { get; internal set; }
        /// <summary>
        ///   An alias for the "version" subcommand.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        /// <summary>
        ///   The Lock Id to unlock
        /// </summary>
        public virtual string LockId { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("force-unlock")
              .Add("-force", Force)
              .Add("-json", Json)
              .Add("-help", Help)
              .Add("-chdir={value}", ChangeDirectory)
              .Add("-version", Version)
              .Add("{value}", LockId);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region TerraformGraphSettings
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class TerraformGraphSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Terraform executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? TerraformTasks.TerraformPath;
        public override Action<OutputType, string> ProcessCustomLogger => TerraformTasks.TerraformLogger;
        /// <summary>
        ///   Render graph using the specified plan file instead of the configuration in the current directory.
        /// </summary>
        public virtual string Plan { get; internal set; }
        /// <summary>
        ///   Highlight any cycles in the graph with colored edges. This helps when diagnosing cycle errors.
        /// </summary>
        public virtual bool? DrawCycles { get; internal set; }
        /// <summary>
        ///   Type of graph to output. Can be: plan, plan-refresh-only, plan-destroy, or apply. By default Terraform chooses "plan", or "apply" if you also set the -plan=... option.
        /// </summary>
        public virtual string Type { get; internal set; }
        /// <summary>
        ///   Help for Terraform.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Switch to a different working directory before executing the given subcommand.
        /// </summary>
        public virtual string ChangeDirectory { get; internal set; }
        /// <summary>
        ///   An alias for the "version" subcommand.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("graph")
              .Add("-plan={value}", Plan)
              .Add("-draw-cycles", DrawCycles)
              .Add("-type={value}", Type)
              .Add("-help", Help)
              .Add("-chdir={value}", ChangeDirectory)
              .Add("-version", Version);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region TerraformApplySettings
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class TerraformApplySettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Terraform executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? TerraformTasks.TerraformPath;
        public override Action<OutputType, string> ProcessCustomLogger => TerraformTasks.TerraformLogger;
        /// <summary>
        ///   Skip interactive approval of plan before applying.
        /// </summary>
        public virtual bool? AutoApprove { get; internal set; } = true;
        /// <summary>
        ///   Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.
        /// </summary>
        public virtual string Backup { get; internal set; }
        /// <summary>
        ///   Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.
        /// </summary>
        public virtual bool? CompactWarnings { get; internal set; }
        /// <summary>
        ///   Destroy Terraform-managed infrastructure. The command "terraform destroy" is a convenience alias for this option.
        /// </summary>
        public virtual bool? Destroy { get; internal set; }
        /// <summary>
        ///   Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.
        /// </summary>
        public virtual bool? Lock { get; internal set; }
        /// <summary>
        ///   Duration to retry a state lock.
        /// </summary>
        public virtual int? LockTimeout { get; internal set; }
        /// <summary>
        ///   If specified, output won't contain any color.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Limit the number of concurrent operations. Defaults to 10.
        /// </summary>
        public virtual int? Parallelism { get; internal set; }
        /// <summary>
        ///   Path to read and save state (unless state-out is specified). Defaults to "terraform.tfstate".
        /// </summary>
        public virtual string State { get; internal set; }
        /// <summary>
        ///   Path to write state to that is different than "-state". This can be used to preserve the old state.
        /// </summary>
        public virtual string StateOutput { get; internal set; }
        /// <summary>
        ///   Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   Help for Terraform.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Switch to a different working directory before executing the given subcommand.
        /// </summary>
        public virtual string ChangeDirectory { get; internal set; }
        /// <summary>
        ///   An alias for the "version" subcommand.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        /// <summary>
        ///   The path to the Terraform plan file.
        /// </summary>
        public virtual string PlanFile { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("apply")
              .Add("-auto-approve", AutoApprove)
              .Add("-backup={value}", Backup)
              .Add("-compact-warnings", CompactWarnings)
              .Add("-destroy", Destroy)
              .Add("-lock", Lock)
              .Add("-lock-timeout", LockTimeout)
              .Add("-no-color", NoColor)
              .Add("-parallelism", Parallelism)
              .Add("-state={value}", State)
              .Add("-state-out={value}", StateOutput)
              .Add("-json", Json)
              .Add("-help", Help)
              .Add("-chdir={value}", ChangeDirectory)
              .Add("-version", Version)
              .Add("{value}", PlanFile);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region TerraformRefreshSettings
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class TerraformRefreshSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the Terraform executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? TerraformTasks.TerraformPath;
        public override Action<OutputType, string> ProcessCustomLogger => TerraformTasks.TerraformLogger;
        /// <summary>
        ///   Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.
        /// </summary>
        public virtual bool? CompactWarnings { get; internal set; }
        /// <summary>
        ///   Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.
        /// </summary>
        public virtual bool? Lock { get; internal set; }
        /// <summary>
        ///   Duration to retry a state lock.
        /// </summary>
        public virtual int? LockTimeout { get; internal set; }
        /// <summary>
        ///   If specified, output won't contain any color.
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///   Limit the number of concurrent operations. Defaults to 10.
        /// </summary>
        public virtual int? Parallelism { get; internal set; }
        /// <summary>
        ///   Limit the planning operation to only the given module, resource, or resource instance and all of its dependencies. You can use this option multiple times to include more than one object. This is for exceptional use only.
        /// </summary>
        public virtual string Target { get; internal set; }
        /// <summary>
        ///   Set a value for one of the input variables in the root module of the configuration. Use this option more than once to set more than one variable.
        /// </summary>
        public virtual string Variable { get; internal set; }
        /// <summary>
        ///   Set a value for one of the input variables in the root module of the configuration. Use this option more than once to set more than one variable.
        /// </summary>
        public virtual string SecretVariable { get; internal set; }
        /// <summary>
        ///   Load variable values from the given file, in addition to the default files terraform.tfvars and *.auto.tfvars. Use this option more than once to include more than one variables file.
        /// </summary>
        public virtual string VariableFile { get; internal set; }
        /// <summary>
        ///   Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///   Help for Terraform.
        /// </summary>
        public virtual bool? Help { get; internal set; }
        /// <summary>
        ///   Switch to a different working directory before executing the given subcommand.
        /// </summary>
        public virtual string ChangeDirectory { get; internal set; }
        /// <summary>
        ///   An alias for the "version" subcommand.
        /// </summary>
        public virtual bool? Version { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("refresh")
              .Add("-compact-warnings", CompactWarnings)
              .Add("-lock", Lock)
              .Add("-lock-timeout", LockTimeout)
              .Add("-no-color", NoColor)
              .Add("-parallelism", Parallelism)
              .Add("-target={value}", Target)
              .Add("-var={value}", Variable)
              .Add("-var={value}", SecretVariable, secret: true)
              .Add("-var-file={value}", VariableFile)
              .Add("-json", Json)
              .Add("-help", Help)
              .Add("-chdir={value}", ChangeDirectory)
              .Add("-version", Version);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region TerraformInitSettingsExtensions
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class TerraformInitSettingsExtensions
    {
        #region Backend
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.Backend"/></em></p>
        ///   <p>Disable backend or Terraform Cloud initialization for this configuration and use what was previously initialized instead. Aliases: -cloud=false.</p>
        /// </summary>
        [Pure]
        public static T SetBackend<T>(this T toolSettings, bool? backend) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Backend = backend;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.Backend"/></em></p>
        ///   <p>Disable backend or Terraform Cloud initialization for this configuration and use what was previously initialized instead. Aliases: -cloud=false.</p>
        /// </summary>
        [Pure]
        public static T ResetBackend<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Backend = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.Backend"/></em></p>
        ///   <p>Disable backend or Terraform Cloud initialization for this configuration and use what was previously initialized instead. Aliases: -cloud=false.</p>
        /// </summary>
        [Pure]
        public static T EnableBackend<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Backend = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.Backend"/></em></p>
        ///   <p>Disable backend or Terraform Cloud initialization for this configuration and use what was previously initialized instead. Aliases: -cloud=false.</p>
        /// </summary>
        [Pure]
        public static T DisableBackend<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Backend = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.Backend"/></em></p>
        ///   <p>Disable backend or Terraform Cloud initialization for this configuration and use what was previously initialized instead. Aliases: -cloud=false.</p>
        /// </summary>
        [Pure]
        public static T ToggleBackend<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Backend = !toolSettings.Backend;
            return toolSettings;
        }
        #endregion
        #region BackendConfig
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.BackendConfig"/></em></p>
        ///   <p>Configuration to be merged with what is in the configuration file's 'backend' block. This can be either a path to an HCL file with key/value assignments (same format as terraform.tfvars) or a 'key=value' format, and can be specified multiple times. The backend type must be in the configuration itself.</p>
        /// </summary>
        [Pure]
        public static T SetBackendConfig<T>(this T toolSettings, string backendConfig) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BackendConfig = backendConfig;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.BackendConfig"/></em></p>
        ///   <p>Configuration to be merged with what is in the configuration file's 'backend' block. This can be either a path to an HCL file with key/value assignments (same format as terraform.tfvars) or a 'key=value' format, and can be specified multiple times. The backend type must be in the configuration itself.</p>
        /// </summary>
        [Pure]
        public static T ResetBackendConfig<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BackendConfig = null;
            return toolSettings;
        }
        #endregion
        #region ForceCopy
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.ForceCopy"/></em></p>
        ///   <p>Suppress prompts about copying state data when initializating a new state backend. This is equivalent to providing a "yes" to all confirmation prompts.</p>
        /// </summary>
        [Pure]
        public static T SetForceCopy<T>(this T toolSettings, bool? forceCopy) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceCopy = forceCopy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.ForceCopy"/></em></p>
        ///   <p>Suppress prompts about copying state data when initializating a new state backend. This is equivalent to providing a "yes" to all confirmation prompts.</p>
        /// </summary>
        [Pure]
        public static T ResetForceCopy<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceCopy = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.ForceCopy"/></em></p>
        ///   <p>Suppress prompts about copying state data when initializating a new state backend. This is equivalent to providing a "yes" to all confirmation prompts.</p>
        /// </summary>
        [Pure]
        public static T EnableForceCopy<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceCopy = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.ForceCopy"/></em></p>
        ///   <p>Suppress prompts about copying state data when initializating a new state backend. This is equivalent to providing a "yes" to all confirmation prompts.</p>
        /// </summary>
        [Pure]
        public static T DisableForceCopy<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceCopy = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.ForceCopy"/></em></p>
        ///   <p>Suppress prompts about copying state data when initializating a new state backend. This is equivalent to providing a "yes" to all confirmation prompts.</p>
        /// </summary>
        [Pure]
        public static T ToggleForceCopy<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ForceCopy = !toolSettings.ForceCopy;
            return toolSettings;
        }
        #endregion
        #region FromModule
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.FromModule"/></em></p>
        ///   <p>Copy the contents of the given module into the target directory before initialization.</p>
        /// </summary>
        [Pure]
        public static T SetFromModule<T>(this T toolSettings, string fromModule) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromModule = fromModule;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.FromModule"/></em></p>
        ///   <p>Copy the contents of the given module into the target directory before initialization.</p>
        /// </summary>
        [Pure]
        public static T ResetFromModule<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FromModule = null;
            return toolSettings;
        }
        #endregion
        #region GetModules
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.GetModules"/></em></p>
        ///   <p>Disable downloading modules for this configuration.</p>
        /// </summary>
        [Pure]
        public static T SetGetModules<T>(this T toolSettings, bool? getModules) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GetModules = getModules;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.GetModules"/></em></p>
        ///   <p>Disable downloading modules for this configuration.</p>
        /// </summary>
        [Pure]
        public static T ResetGetModules<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GetModules = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.GetModules"/></em></p>
        ///   <p>Disable downloading modules for this configuration.</p>
        /// </summary>
        [Pure]
        public static T EnableGetModules<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GetModules = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.GetModules"/></em></p>
        ///   <p>Disable downloading modules for this configuration.</p>
        /// </summary>
        [Pure]
        public static T DisableGetModules<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GetModules = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.GetModules"/></em></p>
        ///   <p>Disable downloading modules for this configuration.</p>
        /// </summary>
        [Pure]
        public static T ToggleGetModules<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.GetModules = !toolSettings.GetModules;
            return toolSettings;
        }
        #endregion
        #region Input
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.Input"/></em></p>
        ///   <p>Disable interactive prompts. Note that some actions may require interactive prompts and will error if input is disabled.</p>
        /// </summary>
        [Pure]
        public static T SetInput<T>(this T toolSettings, bool? input) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.Input"/></em></p>
        ///   <p>Disable interactive prompts. Note that some actions may require interactive prompts and will error if input is disabled.</p>
        /// </summary>
        [Pure]
        public static T ResetInput<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.Input"/></em></p>
        ///   <p>Disable interactive prompts. Note that some actions may require interactive prompts and will error if input is disabled.</p>
        /// </summary>
        [Pure]
        public static T EnableInput<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.Input"/></em></p>
        ///   <p>Disable interactive prompts. Note that some actions may require interactive prompts and will error if input is disabled.</p>
        /// </summary>
        [Pure]
        public static T DisableInput<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.Input"/></em></p>
        ///   <p>Disable interactive prompts. Note that some actions may require interactive prompts and will error if input is disabled.</p>
        /// </summary>
        [Pure]
        public static T ToggleInput<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = !toolSettings.Input;
            return toolSettings;
        }
        #endregion
        #region Lock
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T SetLock<T>(this T toolSettings, bool? @lock) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = @lock;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T ResetLock<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T EnableLock<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T DisableLock<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T ToggleLock<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = !toolSettings.Lock;
            return toolSettings;
        }
        #endregion
        #region LockTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.LockTimeout"/></em></p>
        ///   <p>Duration to retry a state lock.</p>
        /// </summary>
        [Pure]
        public static T SetLockTimeout<T>(this T toolSettings, int? lockTimeout) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockTimeout = lockTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.LockTimeout"/></em></p>
        ///   <p>Duration to retry a state lock.</p>
        /// </summary>
        [Pure]
        public static T ResetLockTimeout<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockTimeout = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region PluginDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.PluginDirectory"/></em></p>
        ///   <p>Directory containing plugin binaries. This overrides all default search paths for plugins, and prevents the automatic installation of plugins. This flag can be used multiple times.</p>
        /// </summary>
        [Pure]
        public static T SetPluginDirectory<T>(this T toolSettings, string pluginDirectory) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginDirectory = pluginDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.PluginDirectory"/></em></p>
        ///   <p>Directory containing plugin binaries. This overrides all default search paths for plugins, and prevents the automatic installation of plugins. This flag can be used multiple times.</p>
        /// </summary>
        [Pure]
        public static T ResetPluginDirectory<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PluginDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Reconfigure
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.Reconfigure"/></em></p>
        ///   <p>Reconfigure a backend, ignoring any saved configuration.</p>
        /// </summary>
        [Pure]
        public static T SetReconfigure<T>(this T toolSettings, bool? reconfigure) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reconfigure = reconfigure;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.Reconfigure"/></em></p>
        ///   <p>Reconfigure a backend, ignoring any saved configuration.</p>
        /// </summary>
        [Pure]
        public static T ResetReconfigure<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reconfigure = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.Reconfigure"/></em></p>
        ///   <p>Reconfigure a backend, ignoring any saved configuration.</p>
        /// </summary>
        [Pure]
        public static T EnableReconfigure<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reconfigure = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.Reconfigure"/></em></p>
        ///   <p>Reconfigure a backend, ignoring any saved configuration.</p>
        /// </summary>
        [Pure]
        public static T DisableReconfigure<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reconfigure = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.Reconfigure"/></em></p>
        ///   <p>Reconfigure a backend, ignoring any saved configuration.</p>
        /// </summary>
        [Pure]
        public static T ToggleReconfigure<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Reconfigure = !toolSettings.Reconfigure;
            return toolSettings;
        }
        #endregion
        #region MigrateState
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.MigrateState"/></em></p>
        ///   <p>Reconfigure a backend, and attempt to migrate any existing state.</p>
        /// </summary>
        [Pure]
        public static T SetMigrateState<T>(this T toolSettings, bool? migrateState) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MigrateState = migrateState;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.MigrateState"/></em></p>
        ///   <p>Reconfigure a backend, and attempt to migrate any existing state.</p>
        /// </summary>
        [Pure]
        public static T ResetMigrateState<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MigrateState = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.MigrateState"/></em></p>
        ///   <p>Reconfigure a backend, and attempt to migrate any existing state.</p>
        /// </summary>
        [Pure]
        public static T EnableMigrateState<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MigrateState = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.MigrateState"/></em></p>
        ///   <p>Reconfigure a backend, and attempt to migrate any existing state.</p>
        /// </summary>
        [Pure]
        public static T DisableMigrateState<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MigrateState = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.MigrateState"/></em></p>
        ///   <p>Reconfigure a backend, and attempt to migrate any existing state.</p>
        /// </summary>
        [Pure]
        public static T ToggleMigrateState<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MigrateState = !toolSettings.MigrateState;
            return toolSettings;
        }
        #endregion
        #region Upgrade
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.Upgrade"/></em></p>
        ///   <p>Install the latest module and provider versions allowed within configured constraints, overriding the default behavior of selecting exactly the version recorded in the dependency lockfile.</p>
        /// </summary>
        [Pure]
        public static T SetUpgrade<T>(this T toolSettings, bool? upgrade) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Upgrade = upgrade;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.Upgrade"/></em></p>
        ///   <p>Install the latest module and provider versions allowed within configured constraints, overriding the default behavior of selecting exactly the version recorded in the dependency lockfile.</p>
        /// </summary>
        [Pure]
        public static T ResetUpgrade<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Upgrade = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.Upgrade"/></em></p>
        ///   <p>Install the latest module and provider versions allowed within configured constraints, overriding the default behavior of selecting exactly the version recorded in the dependency lockfile.</p>
        /// </summary>
        [Pure]
        public static T EnableUpgrade<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Upgrade = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.Upgrade"/></em></p>
        ///   <p>Install the latest module and provider versions allowed within configured constraints, overriding the default behavior of selecting exactly the version recorded in the dependency lockfile.</p>
        /// </summary>
        [Pure]
        public static T DisableUpgrade<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Upgrade = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.Upgrade"/></em></p>
        ///   <p>Install the latest module and provider versions allowed within configured constraints, overriding the default behavior of selecting exactly the version recorded in the dependency lockfile.</p>
        /// </summary>
        [Pure]
        public static T ToggleUpgrade<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Upgrade = !toolSettings.Upgrade;
            return toolSettings;
        }
        #endregion
        #region LockFile
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.LockFile"/></em></p>
        ///   <p>Set a dependency lockfile mode. Currently only "readonly" is valid.</p>
        /// </summary>
        [Pure]
        public static T SetLockFile<T>(this T toolSettings, bool? lockFile) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFile = lockFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.LockFile"/></em></p>
        ///   <p>Set a dependency lockfile mode. Currently only "readonly" is valid.</p>
        /// </summary>
        [Pure]
        public static T ResetLockFile<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFile = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.LockFile"/></em></p>
        ///   <p>Set a dependency lockfile mode. Currently only "readonly" is valid.</p>
        /// </summary>
        [Pure]
        public static T EnableLockFile<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFile = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.LockFile"/></em></p>
        ///   <p>Set a dependency lockfile mode. Currently only "readonly" is valid.</p>
        /// </summary>
        [Pure]
        public static T DisableLockFile<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFile = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.LockFile"/></em></p>
        ///   <p>Set a dependency lockfile mode. Currently only "readonly" is valid.</p>
        /// </summary>
        [Pure]
        public static T ToggleLockFile<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockFile = !toolSettings.LockFile;
            return toolSettings;
        }
        #endregion
        #region IgnoreRemoteVersion
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.IgnoreRemoteVersion"/></em></p>
        ///   <p>A rare option used for Terraform Cloud and the remote backend only. Set this to ignore checking that the local and remote Terraform versions use compatible state representations, making an operation proceed even when there is a potential mismatch. See the documentation on configuring Terraform with Terraform Cloud for more information.</p>
        /// </summary>
        [Pure]
        public static T SetIgnoreRemoteVersion<T>(this T toolSettings, bool? ignoreRemoteVersion) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreRemoteVersion = ignoreRemoteVersion;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.IgnoreRemoteVersion"/></em></p>
        ///   <p>A rare option used for Terraform Cloud and the remote backend only. Set this to ignore checking that the local and remote Terraform versions use compatible state representations, making an operation proceed even when there is a potential mismatch. See the documentation on configuring Terraform with Terraform Cloud for more information.</p>
        /// </summary>
        [Pure]
        public static T ResetIgnoreRemoteVersion<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreRemoteVersion = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.IgnoreRemoteVersion"/></em></p>
        ///   <p>A rare option used for Terraform Cloud and the remote backend only. Set this to ignore checking that the local and remote Terraform versions use compatible state representations, making an operation proceed even when there is a potential mismatch. See the documentation on configuring Terraform with Terraform Cloud for more information.</p>
        /// </summary>
        [Pure]
        public static T EnableIgnoreRemoteVersion<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreRemoteVersion = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.IgnoreRemoteVersion"/></em></p>
        ///   <p>A rare option used for Terraform Cloud and the remote backend only. Set this to ignore checking that the local and remote Terraform versions use compatible state representations, making an operation proceed even when there is a potential mismatch. See the documentation on configuring Terraform with Terraform Cloud for more information.</p>
        /// </summary>
        [Pure]
        public static T DisableIgnoreRemoteVersion<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreRemoteVersion = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.IgnoreRemoteVersion"/></em></p>
        ///   <p>A rare option used for Terraform Cloud and the remote backend only. Set this to ignore checking that the local and remote Terraform versions use compatible state representations, making an operation proceed even when there is a potential mismatch. See the documentation on configuring Terraform with Terraform Cloud for more information.</p>
        /// </summary>
        [Pure]
        public static T ToggleIgnoreRemoteVersion<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreRemoteVersion = !toolSettings.IgnoreRemoteVersion;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T SetJson<T>(this T toolSettings, bool? json) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T ResetJson<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T EnableJson<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T DisableJson<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T ToggleJson<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region ChangeDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetChangeDirectory<T>(this T toolSettings, string changeDirectory) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = changeDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetChangeDirectory<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformInitSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformInitSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformInitSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T EnableVersion<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformInitSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T DisableVersion<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformInitSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ToggleVersion<T>(this T toolSettings) where T : TerraformInitSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region TerraformPlanSettingsExtensions
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class TerraformPlanSettingsExtensions
    {
        #region Destroy
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.Destroy"/></em></p>
        ///   <p>Select the "destroy" planning mode, which creates a plan to destroy all objects currently managed by this Terraform configuration instead of the usual behavior.</p>
        /// </summary>
        [Pure]
        public static T SetDestroy<T>(this T toolSettings, bool? destroy) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destroy = destroy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.Destroy"/></em></p>
        ///   <p>Select the "destroy" planning mode, which creates a plan to destroy all objects currently managed by this Terraform configuration instead of the usual behavior.</p>
        /// </summary>
        [Pure]
        public static T ResetDestroy<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destroy = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformPlanSettings.Destroy"/></em></p>
        ///   <p>Select the "destroy" planning mode, which creates a plan to destroy all objects currently managed by this Terraform configuration instead of the usual behavior.</p>
        /// </summary>
        [Pure]
        public static T EnableDestroy<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destroy = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformPlanSettings.Destroy"/></em></p>
        ///   <p>Select the "destroy" planning mode, which creates a plan to destroy all objects currently managed by this Terraform configuration instead of the usual behavior.</p>
        /// </summary>
        [Pure]
        public static T DisableDestroy<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destroy = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformPlanSettings.Destroy"/></em></p>
        ///   <p>Select the "destroy" planning mode, which creates a plan to destroy all objects currently managed by this Terraform configuration instead of the usual behavior.</p>
        /// </summary>
        [Pure]
        public static T ToggleDestroy<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destroy = !toolSettings.Destroy;
            return toolSettings;
        }
        #endregion
        #region RefreshOnly
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.RefreshOnly"/></em></p>
        ///   <p>Select the "refresh only" planning mode, which checks whether remote objects still match the outcome of the most recent Terraform apply but does not propose any actions to undo any changes made outside of Terraform.</p>
        /// </summary>
        [Pure]
        public static T SetRefreshOnly<T>(this T toolSettings, bool? refreshOnly) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RefreshOnly = refreshOnly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.RefreshOnly"/></em></p>
        ///   <p>Select the "refresh only" planning mode, which checks whether remote objects still match the outcome of the most recent Terraform apply but does not propose any actions to undo any changes made outside of Terraform.</p>
        /// </summary>
        [Pure]
        public static T ResetRefreshOnly<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RefreshOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformPlanSettings.RefreshOnly"/></em></p>
        ///   <p>Select the "refresh only" planning mode, which checks whether remote objects still match the outcome of the most recent Terraform apply but does not propose any actions to undo any changes made outside of Terraform.</p>
        /// </summary>
        [Pure]
        public static T EnableRefreshOnly<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RefreshOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformPlanSettings.RefreshOnly"/></em></p>
        ///   <p>Select the "refresh only" planning mode, which checks whether remote objects still match the outcome of the most recent Terraform apply but does not propose any actions to undo any changes made outside of Terraform.</p>
        /// </summary>
        [Pure]
        public static T DisableRefreshOnly<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RefreshOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformPlanSettings.RefreshOnly"/></em></p>
        ///   <p>Select the "refresh only" planning mode, which checks whether remote objects still match the outcome of the most recent Terraform apply but does not propose any actions to undo any changes made outside of Terraform.</p>
        /// </summary>
        [Pure]
        public static T ToggleRefreshOnly<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RefreshOnly = !toolSettings.RefreshOnly;
            return toolSettings;
        }
        #endregion
        #region Refresh
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.Refresh"/></em></p>
        ///   <p>Skip checking for external changes to remote objects while creating the plan. This can potentially make planning faster, but at the expense of possibly planning against a stale record of the remote system state.</p>
        /// </summary>
        [Pure]
        public static T SetRefresh<T>(this T toolSettings, bool? refresh) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Refresh = refresh;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.Refresh"/></em></p>
        ///   <p>Skip checking for external changes to remote objects while creating the plan. This can potentially make planning faster, but at the expense of possibly planning against a stale record of the remote system state.</p>
        /// </summary>
        [Pure]
        public static T ResetRefresh<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Refresh = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformPlanSettings.Refresh"/></em></p>
        ///   <p>Skip checking for external changes to remote objects while creating the plan. This can potentially make planning faster, but at the expense of possibly planning against a stale record of the remote system state.</p>
        /// </summary>
        [Pure]
        public static T EnableRefresh<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Refresh = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformPlanSettings.Refresh"/></em></p>
        ///   <p>Skip checking for external changes to remote objects while creating the plan. This can potentially make planning faster, but at the expense of possibly planning against a stale record of the remote system state.</p>
        /// </summary>
        [Pure]
        public static T DisableRefresh<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Refresh = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformPlanSettings.Refresh"/></em></p>
        ///   <p>Skip checking for external changes to remote objects while creating the plan. This can potentially make planning faster, but at the expense of possibly planning against a stale record of the remote system state.</p>
        /// </summary>
        [Pure]
        public static T ToggleRefresh<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Refresh = !toolSettings.Refresh;
            return toolSettings;
        }
        #endregion
        #region Replace
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.Replace"/></em></p>
        ///   <p>Force replacement of a particular resource instance using its resource address. If the plan would've normally produced an update or no-op action for this instance, Terraform will plan to replace it instead. You can use this option multiple times to replace more than one object.</p>
        /// </summary>
        [Pure]
        public static T SetReplace<T>(this T toolSettings, string replace) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Replace = replace;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.Replace"/></em></p>
        ///   <p>Force replacement of a particular resource instance using its resource address. If the plan would've normally produced an update or no-op action for this instance, Terraform will plan to replace it instead. You can use this option multiple times to replace more than one object.</p>
        /// </summary>
        [Pure]
        public static T ResetReplace<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Replace = null;
            return toolSettings;
        }
        #endregion
        #region Target
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.Target"/></em></p>
        ///   <p>Limit the planning operation to only the given module, resource, or resource instance and all of its dependencies. You can use this option multiple times to include more than one object. This is for exceptional use only.</p>
        /// </summary>
        [Pure]
        public static T SetTarget<T>(this T toolSettings, string target) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Target = target;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.Target"/></em></p>
        ///   <p>Limit the planning operation to only the given module, resource, or resource instance and all of its dependencies. You can use this option multiple times to include more than one object. This is for exceptional use only.</p>
        /// </summary>
        [Pure]
        public static T ResetTarget<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Target = null;
            return toolSettings;
        }
        #endregion
        #region Variable
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.Variable"/></em></p>
        ///   <p>Set a value for one of the input variables in the root module of the configuration. Use this option more than once to set more than one variable.</p>
        /// </summary>
        [Pure]
        public static T SetVariable<T>(this T toolSettings, string variable) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variable = variable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.Variable"/></em></p>
        ///   <p>Set a value for one of the input variables in the root module of the configuration. Use this option more than once to set more than one variable.</p>
        /// </summary>
        [Pure]
        public static T ResetVariable<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variable = null;
            return toolSettings;
        }
        #endregion
        #region SecretVariable
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.SecretVariable"/></em></p>
        ///   <p>Set a value for one of the input variables in the root module of the configuration. Use this option more than once to set more than one variable.</p>
        /// </summary>
        [Pure]
        public static T SetSecretVariable<T>(this T toolSettings, [Secret] string secretVariable) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SecretVariable = secretVariable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.SecretVariable"/></em></p>
        ///   <p>Set a value for one of the input variables in the root module of the configuration. Use this option more than once to set more than one variable.</p>
        /// </summary>
        [Pure]
        public static T ResetSecretVariable<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SecretVariable = null;
            return toolSettings;
        }
        #endregion
        #region VariableFile
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.VariableFile"/></em></p>
        ///   <p>Load variable values from the given file, in addition to the default files terraform.tfvars and *.auto.tfvars. Use this option more than once to include more than one variables file.</p>
        /// </summary>
        [Pure]
        public static T SetVariableFile<T>(this T toolSettings, string variableFile) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariableFile = variableFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.VariableFile"/></em></p>
        ///   <p>Load variable values from the given file, in addition to the default files terraform.tfvars and *.auto.tfvars. Use this option more than once to include more than one variables file.</p>
        /// </summary>
        [Pure]
        public static T ResetVariableFile<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariableFile = null;
            return toolSettings;
        }
        #endregion
        #region CompactWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.CompactWarnings"/></em></p>
        ///   <p>If Terraform produces any warnings that are not accompanied by errors, shows them in a more compact form that includes only the summary messages.</p>
        /// </summary>
        [Pure]
        public static T SetCompactWarnings<T>(this T toolSettings, bool? compactWarnings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = compactWarnings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.CompactWarnings"/></em></p>
        ///   <p>If Terraform produces any warnings that are not accompanied by errors, shows them in a more compact form that includes only the summary messages.</p>
        /// </summary>
        [Pure]
        public static T ResetCompactWarnings<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformPlanSettings.CompactWarnings"/></em></p>
        ///   <p>If Terraform produces any warnings that are not accompanied by errors, shows them in a more compact form that includes only the summary messages.</p>
        /// </summary>
        [Pure]
        public static T EnableCompactWarnings<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformPlanSettings.CompactWarnings"/></em></p>
        ///   <p>If Terraform produces any warnings that are not accompanied by errors, shows them in a more compact form that includes only the summary messages.</p>
        /// </summary>
        [Pure]
        public static T DisableCompactWarnings<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformPlanSettings.CompactWarnings"/></em></p>
        ///   <p>If Terraform produces any warnings that are not accompanied by errors, shows them in a more compact form that includes only the summary messages.</p>
        /// </summary>
        [Pure]
        public static T ToggleCompactWarnings<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = !toolSettings.CompactWarnings;
            return toolSettings;
        }
        #endregion
        #region DetailedExitcode
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.DetailedExitcode"/></em></p>
        ///   <p>Return detailed exit codes when the command exits. This will change the meaning of exit codes to:	0 - Succeeded, diff is empty (no changes)	1 - Errored	2 - Succeeded, there is a diff</p>
        /// </summary>
        [Pure]
        public static T SetDetailedExitcode<T>(this T toolSettings, bool? detailedExitcode) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedExitcode = detailedExitcode;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.DetailedExitcode"/></em></p>
        ///   <p>Return detailed exit codes when the command exits. This will change the meaning of exit codes to:	0 - Succeeded, diff is empty (no changes)	1 - Errored	2 - Succeeded, there is a diff</p>
        /// </summary>
        [Pure]
        public static T ResetDetailedExitcode<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedExitcode = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformPlanSettings.DetailedExitcode"/></em></p>
        ///   <p>Return detailed exit codes when the command exits. This will change the meaning of exit codes to:	0 - Succeeded, diff is empty (no changes)	1 - Errored	2 - Succeeded, there is a diff</p>
        /// </summary>
        [Pure]
        public static T EnableDetailedExitcode<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedExitcode = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformPlanSettings.DetailedExitcode"/></em></p>
        ///   <p>Return detailed exit codes when the command exits. This will change the meaning of exit codes to:	0 - Succeeded, diff is empty (no changes)	1 - Errored	2 - Succeeded, there is a diff</p>
        /// </summary>
        [Pure]
        public static T DisableDetailedExitcode<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedExitcode = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformPlanSettings.DetailedExitcode"/></em></p>
        ///   <p>Return detailed exit codes when the command exits. This will change the meaning of exit codes to:	0 - Succeeded, diff is empty (no changes)	1 - Errored	2 - Succeeded, there is a diff</p>
        /// </summary>
        [Pure]
        public static T ToggleDetailedExitcode<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DetailedExitcode = !toolSettings.DetailedExitcode;
            return toolSettings;
        }
        #endregion
        #region PlanOutput
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.PlanOutput"/></em></p>
        ///   <p>Write a plan file to the given path. This can be used as input to the "apply" command.</p>
        /// </summary>
        [Pure]
        public static T SetPlanOutput<T>(this T toolSettings, string planOutput) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PlanOutput = planOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.PlanOutput"/></em></p>
        ///   <p>Write a plan file to the given path. This can be used as input to the "apply" command.</p>
        /// </summary>
        [Pure]
        public static T ResetPlanOutput<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PlanOutput = null;
            return toolSettings;
        }
        #endregion
        #region Parallelism
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.Parallelism"/></em></p>
        ///   <p>Limit the number of concurrent operations. Defaults to 10.</p>
        /// </summary>
        [Pure]
        public static T SetParallelism<T>(this T toolSettings, int? parallelism) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallelism = parallelism;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.Parallelism"/></em></p>
        ///   <p>Limit the number of concurrent operations. Defaults to 10.</p>
        /// </summary>
        [Pure]
        public static T ResetParallelism<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallelism = null;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T SetJson<T>(this T toolSettings, bool? json) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T ResetJson<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformPlanSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T EnableJson<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformPlanSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T DisableJson<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformPlanSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T ToggleJson<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformPlanSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformPlanSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformPlanSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region ChangeDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetChangeDirectory<T>(this T toolSettings, string changeDirectory) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = changeDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetChangeDirectory<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformPlanSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformPlanSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformPlanSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T EnableVersion<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformPlanSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T DisableVersion<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformPlanSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ToggleVersion<T>(this T toolSettings) where T : TerraformPlanSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region TerraformValidateSettingsExtensions
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class TerraformValidateSettingsExtensions
    {
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformValidateSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T SetJson<T>(this T toolSettings, bool? json) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformValidateSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T ResetJson<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformValidateSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T EnableJson<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformValidateSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T DisableJson<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformValidateSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T ToggleJson<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformValidateSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformValidateSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformValidateSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformValidateSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformValidateSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region ChangeDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformValidateSettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetChangeDirectory<T>(this T toolSettings, string changeDirectory) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = changeDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformValidateSettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetChangeDirectory<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformValidateSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformValidateSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformValidateSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T EnableVersion<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformValidateSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T DisableVersion<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformValidateSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ToggleVersion<T>(this T toolSettings) where T : TerraformValidateSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region TerraformForceUnlockSettingsExtensions
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class TerraformForceUnlockSettingsExtensions
    {
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformForceUnlockSettings.Force"/></em></p>
        ///   <p>Don't ask for input for unlock confirmation.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformForceUnlockSettings.Force"/></em></p>
        ///   <p>Don't ask for input for unlock confirmation.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformForceUnlockSettings.Force"/></em></p>
        ///   <p>Don't ask for input for unlock confirmation.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformForceUnlockSettings.Force"/></em></p>
        ///   <p>Don't ask for input for unlock confirmation.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformForceUnlockSettings.Force"/></em></p>
        ///   <p>Don't ask for input for unlock confirmation.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformForceUnlockSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T SetJson<T>(this T toolSettings, bool? json) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformForceUnlockSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T ResetJson<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformForceUnlockSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T EnableJson<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformForceUnlockSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T DisableJson<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformForceUnlockSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T ToggleJson<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformForceUnlockSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformForceUnlockSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformForceUnlockSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformForceUnlockSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformForceUnlockSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region ChangeDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformForceUnlockSettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetChangeDirectory<T>(this T toolSettings, string changeDirectory) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = changeDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformForceUnlockSettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetChangeDirectory<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformForceUnlockSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformForceUnlockSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformForceUnlockSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T EnableVersion<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformForceUnlockSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T DisableVersion<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformForceUnlockSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ToggleVersion<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
        #region LockId
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformForceUnlockSettings.LockId"/></em></p>
        ///   <p>The Lock Id to unlock</p>
        /// </summary>
        [Pure]
        public static T SetLockId<T>(this T toolSettings, string lockId) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockId = lockId;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformForceUnlockSettings.LockId"/></em></p>
        ///   <p>The Lock Id to unlock</p>
        /// </summary>
        [Pure]
        public static T ResetLockId<T>(this T toolSettings) where T : TerraformForceUnlockSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockId = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region TerraformGraphSettingsExtensions
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class TerraformGraphSettingsExtensions
    {
        #region Plan
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformGraphSettings.Plan"/></em></p>
        ///   <p>Render graph using the specified plan file instead of the configuration in the current directory.</p>
        /// </summary>
        [Pure]
        public static T SetPlan<T>(this T toolSettings, string plan) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Plan = plan;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformGraphSettings.Plan"/></em></p>
        ///   <p>Render graph using the specified plan file instead of the configuration in the current directory.</p>
        /// </summary>
        [Pure]
        public static T ResetPlan<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Plan = null;
            return toolSettings;
        }
        #endregion
        #region DrawCycles
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformGraphSettings.DrawCycles"/></em></p>
        ///   <p>Highlight any cycles in the graph with colored edges. This helps when diagnosing cycle errors.</p>
        /// </summary>
        [Pure]
        public static T SetDrawCycles<T>(this T toolSettings, bool? drawCycles) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DrawCycles = drawCycles;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformGraphSettings.DrawCycles"/></em></p>
        ///   <p>Highlight any cycles in the graph with colored edges. This helps when diagnosing cycle errors.</p>
        /// </summary>
        [Pure]
        public static T ResetDrawCycles<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DrawCycles = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformGraphSettings.DrawCycles"/></em></p>
        ///   <p>Highlight any cycles in the graph with colored edges. This helps when diagnosing cycle errors.</p>
        /// </summary>
        [Pure]
        public static T EnableDrawCycles<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DrawCycles = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformGraphSettings.DrawCycles"/></em></p>
        ///   <p>Highlight any cycles in the graph with colored edges. This helps when diagnosing cycle errors.</p>
        /// </summary>
        [Pure]
        public static T DisableDrawCycles<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DrawCycles = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformGraphSettings.DrawCycles"/></em></p>
        ///   <p>Highlight any cycles in the graph with colored edges. This helps when diagnosing cycle errors.</p>
        /// </summary>
        [Pure]
        public static T ToggleDrawCycles<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DrawCycles = !toolSettings.DrawCycles;
            return toolSettings;
        }
        #endregion
        #region Type
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformGraphSettings.Type"/></em></p>
        ///   <p>Type of graph to output. Can be: plan, plan-refresh-only, plan-destroy, or apply. By default Terraform chooses "plan", or "apply" if you also set the -plan=... option.</p>
        /// </summary>
        [Pure]
        public static T SetType<T>(this T toolSettings, string type) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Type = type;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformGraphSettings.Type"/></em></p>
        ///   <p>Type of graph to output. Can be: plan, plan-refresh-only, plan-destroy, or apply. By default Terraform chooses "plan", or "apply" if you also set the -plan=... option.</p>
        /// </summary>
        [Pure]
        public static T ResetType<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Type = null;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformGraphSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformGraphSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformGraphSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformGraphSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformGraphSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region ChangeDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformGraphSettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetChangeDirectory<T>(this T toolSettings, string changeDirectory) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = changeDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformGraphSettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetChangeDirectory<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformGraphSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformGraphSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformGraphSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T EnableVersion<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformGraphSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T DisableVersion<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformGraphSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ToggleVersion<T>(this T toolSettings) where T : TerraformGraphSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region TerraformApplySettingsExtensions
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class TerraformApplySettingsExtensions
    {
        #region AutoApprove
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.AutoApprove"/></em></p>
        ///   <p>Skip interactive approval of plan before applying.</p>
        /// </summary>
        [Pure]
        public static T SetAutoApprove<T>(this T toolSettings, bool? autoApprove) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutoApprove = autoApprove;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.AutoApprove"/></em></p>
        ///   <p>Skip interactive approval of plan before applying.</p>
        /// </summary>
        [Pure]
        public static T ResetAutoApprove<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutoApprove = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformApplySettings.AutoApprove"/></em></p>
        ///   <p>Skip interactive approval of plan before applying.</p>
        /// </summary>
        [Pure]
        public static T EnableAutoApprove<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutoApprove = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformApplySettings.AutoApprove"/></em></p>
        ///   <p>Skip interactive approval of plan before applying.</p>
        /// </summary>
        [Pure]
        public static T DisableAutoApprove<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutoApprove = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformApplySettings.AutoApprove"/></em></p>
        ///   <p>Skip interactive approval of plan before applying.</p>
        /// </summary>
        [Pure]
        public static T ToggleAutoApprove<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AutoApprove = !toolSettings.AutoApprove;
            return toolSettings;
        }
        #endregion
        #region Backup
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.Backup"/></em></p>
        ///   <p>Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.</p>
        /// </summary>
        [Pure]
        public static T SetBackup<T>(this T toolSettings, string backup) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Backup = backup;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.Backup"/></em></p>
        ///   <p>Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.</p>
        /// </summary>
        [Pure]
        public static T ResetBackup<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Backup = null;
            return toolSettings;
        }
        #endregion
        #region CompactWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.CompactWarnings"/></em></p>
        ///   <p>Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.</p>
        /// </summary>
        [Pure]
        public static T SetCompactWarnings<T>(this T toolSettings, bool? compactWarnings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = compactWarnings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.CompactWarnings"/></em></p>
        ///   <p>Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.</p>
        /// </summary>
        [Pure]
        public static T ResetCompactWarnings<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformApplySettings.CompactWarnings"/></em></p>
        ///   <p>Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.</p>
        /// </summary>
        [Pure]
        public static T EnableCompactWarnings<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformApplySettings.CompactWarnings"/></em></p>
        ///   <p>Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.</p>
        /// </summary>
        [Pure]
        public static T DisableCompactWarnings<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformApplySettings.CompactWarnings"/></em></p>
        ///   <p>Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.</p>
        /// </summary>
        [Pure]
        public static T ToggleCompactWarnings<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = !toolSettings.CompactWarnings;
            return toolSettings;
        }
        #endregion
        #region Destroy
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.Destroy"/></em></p>
        ///   <p>Destroy Terraform-managed infrastructure. The command "terraform destroy" is a convenience alias for this option.</p>
        /// </summary>
        [Pure]
        public static T SetDestroy<T>(this T toolSettings, bool? destroy) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destroy = destroy;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.Destroy"/></em></p>
        ///   <p>Destroy Terraform-managed infrastructure. The command "terraform destroy" is a convenience alias for this option.</p>
        /// </summary>
        [Pure]
        public static T ResetDestroy<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destroy = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformApplySettings.Destroy"/></em></p>
        ///   <p>Destroy Terraform-managed infrastructure. The command "terraform destroy" is a convenience alias for this option.</p>
        /// </summary>
        [Pure]
        public static T EnableDestroy<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destroy = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformApplySettings.Destroy"/></em></p>
        ///   <p>Destroy Terraform-managed infrastructure. The command "terraform destroy" is a convenience alias for this option.</p>
        /// </summary>
        [Pure]
        public static T DisableDestroy<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destroy = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformApplySettings.Destroy"/></em></p>
        ///   <p>Destroy Terraform-managed infrastructure. The command "terraform destroy" is a convenience alias for this option.</p>
        /// </summary>
        [Pure]
        public static T ToggleDestroy<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Destroy = !toolSettings.Destroy;
            return toolSettings;
        }
        #endregion
        #region Lock
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T SetLock<T>(this T toolSettings, bool? @lock) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = @lock;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T ResetLock<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformApplySettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T EnableLock<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformApplySettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T DisableLock<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformApplySettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T ToggleLock<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = !toolSettings.Lock;
            return toolSettings;
        }
        #endregion
        #region LockTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.LockTimeout"/></em></p>
        ///   <p>Duration to retry a state lock.</p>
        /// </summary>
        [Pure]
        public static T SetLockTimeout<T>(this T toolSettings, int? lockTimeout) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockTimeout = lockTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.LockTimeout"/></em></p>
        ///   <p>Duration to retry a state lock.</p>
        /// </summary>
        [Pure]
        public static T ResetLockTimeout<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockTimeout = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformApplySettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformApplySettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformApplySettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region Parallelism
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.Parallelism"/></em></p>
        ///   <p>Limit the number of concurrent operations. Defaults to 10.</p>
        /// </summary>
        [Pure]
        public static T SetParallelism<T>(this T toolSettings, int? parallelism) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallelism = parallelism;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.Parallelism"/></em></p>
        ///   <p>Limit the number of concurrent operations. Defaults to 10.</p>
        /// </summary>
        [Pure]
        public static T ResetParallelism<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallelism = null;
            return toolSettings;
        }
        #endregion
        #region State
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.State"/></em></p>
        ///   <p>Path to read and save state (unless state-out is specified). Defaults to "terraform.tfstate".</p>
        /// </summary>
        [Pure]
        public static T SetState<T>(this T toolSettings, string state) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.State = state;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.State"/></em></p>
        ///   <p>Path to read and save state (unless state-out is specified). Defaults to "terraform.tfstate".</p>
        /// </summary>
        [Pure]
        public static T ResetState<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.State = null;
            return toolSettings;
        }
        #endregion
        #region StateOutput
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.StateOutput"/></em></p>
        ///   <p>Path to write state to that is different than "-state". This can be used to preserve the old state.</p>
        /// </summary>
        [Pure]
        public static T SetStateOutput<T>(this T toolSettings, string stateOutput) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StateOutput = stateOutput;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.StateOutput"/></em></p>
        ///   <p>Path to write state to that is different than "-state". This can be used to preserve the old state.</p>
        /// </summary>
        [Pure]
        public static T ResetStateOutput<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StateOutput = null;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T SetJson<T>(this T toolSettings, bool? json) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T ResetJson<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformApplySettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T EnableJson<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformApplySettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T DisableJson<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformApplySettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T ToggleJson<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformApplySettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformApplySettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformApplySettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region ChangeDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetChangeDirectory<T>(this T toolSettings, string changeDirectory) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = changeDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetChangeDirectory<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformApplySettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T EnableVersion<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformApplySettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T DisableVersion<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformApplySettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ToggleVersion<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
        #region PlanFile
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformApplySettings.PlanFile"/></em></p>
        ///   <p>The path to the Terraform plan file.</p>
        /// </summary>
        [Pure]
        public static T SetPlanFile<T>(this T toolSettings, string planFile) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PlanFile = planFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformApplySettings.PlanFile"/></em></p>
        ///   <p>The path to the Terraform plan file.</p>
        /// </summary>
        [Pure]
        public static T ResetPlanFile<T>(this T toolSettings) where T : TerraformApplySettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PlanFile = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region TerraformRefreshSettingsExtensions
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class TerraformRefreshSettingsExtensions
    {
        #region CompactWarnings
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.CompactWarnings"/></em></p>
        ///   <p>Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.</p>
        /// </summary>
        [Pure]
        public static T SetCompactWarnings<T>(this T toolSettings, bool? compactWarnings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = compactWarnings;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.CompactWarnings"/></em></p>
        ///   <p>Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.</p>
        /// </summary>
        [Pure]
        public static T ResetCompactWarnings<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformRefreshSettings.CompactWarnings"/></em></p>
        ///   <p>Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.</p>
        /// </summary>
        [Pure]
        public static T EnableCompactWarnings<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformRefreshSettings.CompactWarnings"/></em></p>
        ///   <p>Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.</p>
        /// </summary>
        [Pure]
        public static T DisableCompactWarnings<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformRefreshSettings.CompactWarnings"/></em></p>
        ///   <p>Path to backup the existing state file before modifying. Defaults to the "-state-out" path with ".backup" extension. Set to "-" to disable backup.</p>
        /// </summary>
        [Pure]
        public static T ToggleCompactWarnings<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CompactWarnings = !toolSettings.CompactWarnings;
            return toolSettings;
        }
        #endregion
        #region Lock
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T SetLock<T>(this T toolSettings, bool? @lock) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = @lock;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T ResetLock<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformRefreshSettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T EnableLock<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformRefreshSettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T DisableLock<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformRefreshSettings.Lock"/></em></p>
        ///   <p>Don't hold a state lock during backend migration. This is dangerous if others might concurrently run commands against the same workspace.</p>
        /// </summary>
        [Pure]
        public static T ToggleLock<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lock = !toolSettings.Lock;
            return toolSettings;
        }
        #endregion
        #region LockTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.LockTimeout"/></em></p>
        ///   <p>Duration to retry a state lock.</p>
        /// </summary>
        [Pure]
        public static T SetLockTimeout<T>(this T toolSettings, int? lockTimeout) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockTimeout = lockTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.LockTimeout"/></em></p>
        ///   <p>Duration to retry a state lock.</p>
        /// </summary>
        [Pure]
        public static T ResetLockTimeout<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LockTimeout = null;
            return toolSettings;
        }
        #endregion
        #region NoColor
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformRefreshSettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformRefreshSettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformRefreshSettings.NoColor"/></em></p>
        ///   <p>If specified, output won't contain any color.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }
        #endregion
        #region Parallelism
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.Parallelism"/></em></p>
        ///   <p>Limit the number of concurrent operations. Defaults to 10.</p>
        /// </summary>
        [Pure]
        public static T SetParallelism<T>(this T toolSettings, int? parallelism) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallelism = parallelism;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.Parallelism"/></em></p>
        ///   <p>Limit the number of concurrent operations. Defaults to 10.</p>
        /// </summary>
        [Pure]
        public static T ResetParallelism<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallelism = null;
            return toolSettings;
        }
        #endregion
        #region Target
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.Target"/></em></p>
        ///   <p>Limit the planning operation to only the given module, resource, or resource instance and all of its dependencies. You can use this option multiple times to include more than one object. This is for exceptional use only.</p>
        /// </summary>
        [Pure]
        public static T SetTarget<T>(this T toolSettings, string target) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Target = target;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.Target"/></em></p>
        ///   <p>Limit the planning operation to only the given module, resource, or resource instance and all of its dependencies. You can use this option multiple times to include more than one object. This is for exceptional use only.</p>
        /// </summary>
        [Pure]
        public static T ResetTarget<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Target = null;
            return toolSettings;
        }
        #endregion
        #region Variable
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.Variable"/></em></p>
        ///   <p>Set a value for one of the input variables in the root module of the configuration. Use this option more than once to set more than one variable.</p>
        /// </summary>
        [Pure]
        public static T SetVariable<T>(this T toolSettings, string variable) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variable = variable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.Variable"/></em></p>
        ///   <p>Set a value for one of the input variables in the root module of the configuration. Use this option more than once to set more than one variable.</p>
        /// </summary>
        [Pure]
        public static T ResetVariable<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Variable = null;
            return toolSettings;
        }
        #endregion
        #region SecretVariable
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.SecretVariable"/></em></p>
        ///   <p>Set a value for one of the input variables in the root module of the configuration. Use this option more than once to set more than one variable.</p>
        /// </summary>
        [Pure]
        public static T SetSecretVariable<T>(this T toolSettings, [Secret] string secretVariable) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SecretVariable = secretVariable;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.SecretVariable"/></em></p>
        ///   <p>Set a value for one of the input variables in the root module of the configuration. Use this option more than once to set more than one variable.</p>
        /// </summary>
        [Pure]
        public static T ResetSecretVariable<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SecretVariable = null;
            return toolSettings;
        }
        #endregion
        #region VariableFile
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.VariableFile"/></em></p>
        ///   <p>Load variable values from the given file, in addition to the default files terraform.tfvars and *.auto.tfvars. Use this option more than once to include more than one variables file.</p>
        /// </summary>
        [Pure]
        public static T SetVariableFile<T>(this T toolSettings, string variableFile) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariableFile = variableFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.VariableFile"/></em></p>
        ///   <p>Load variable values from the given file, in addition to the default files terraform.tfvars and *.auto.tfvars. Use this option more than once to include more than one variables file.</p>
        /// </summary>
        [Pure]
        public static T ResetVariableFile<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariableFile = null;
            return toolSettings;
        }
        #endregion
        #region Json
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T SetJson<T>(this T toolSettings, bool? json) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T ResetJson<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformRefreshSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T EnableJson<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformRefreshSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T DisableJson<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformRefreshSettings.Json"/></em></p>
        ///   <p>Produce output in a machine-readable JSON format, suitable for use in text editor integrations and other automated systems. Always disables color.</p>
        /// </summary>
        [Pure]
        public static T ToggleJson<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }
        #endregion
        #region Help
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T SetHelp<T>(this T toolSettings, bool? help) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = help;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ResetHelp<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformRefreshSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T EnableHelp<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformRefreshSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T DisableHelp<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformRefreshSettings.Help"/></em></p>
        ///   <p>Help for Terraform.</p>
        /// </summary>
        [Pure]
        public static T ToggleHelp<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Help = !toolSettings.Help;
            return toolSettings;
        }
        #endregion
        #region ChangeDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetChangeDirectory<T>(this T toolSettings, string changeDirectory) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = changeDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.ChangeDirectory"/></em></p>
        ///   <p>Switch to a different working directory before executing the given subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetChangeDirectory<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ChangeDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="TerraformRefreshSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, bool? version) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="TerraformRefreshSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="TerraformRefreshSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T EnableVersion<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="TerraformRefreshSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T DisableVersion<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="TerraformRefreshSettings.Version"/></em></p>
        ///   <p>An alias for the "version" subcommand.</p>
        /// </summary>
        [Pure]
        public static T ToggleVersion<T>(this T toolSettings) where T : TerraformRefreshSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = !toolSettings.Version;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region TerraformOutputFormat
    /// <summary>
    ///   Used within <see cref="TerraformTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<TerraformOutputFormat>))]
    public partial class TerraformOutputFormat : Enumeration
    {
        public static TerraformOutputFormat json = (TerraformOutputFormat) "json";
        public static TerraformOutputFormat yaml = (TerraformOutputFormat) "yaml";
        public static implicit operator TerraformOutputFormat(string value)
        {
            return new TerraformOutputFormat { Value = value };
        }
    }
    #endregion
}
