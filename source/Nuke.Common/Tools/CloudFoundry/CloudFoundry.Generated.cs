// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/CloudFoundry.json

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

namespace Nuke.Common.Tools.CloudFoundry
{
    /// <summary>
    ///   <p>Cloud Foundry CLI is the official command line client for Cloud Foundry</p>
    ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryTasks
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public static string CloudFoundryPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("CLOUDFOUNDRY_EXE") ??
            GetToolPath();
        public static Action<OutputType, string> CloudFoundryLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Cloud Foundry CLI is the official command line client for Cloud Foundry</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> CloudFoundry(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(CloudFoundryPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, CloudFoundryLogger, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Push a new app or sync changes to an existing app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryPushSettings.AppName"/></li>
        ///     <li><c>--docker-username</c> via <see cref="CloudFoundryPushSettings.DockerUsername"/></li>
        ///     <li><c>--droplet</c> via <see cref="CloudFoundryPushSettings.Droplet"/></li>
        ///     <li><c>--no-manifest</c> via <see cref="CloudFoundryPushSettings.IgnoreManifest"/></li>
        ///     <li><c>--no-route</c> via <see cref="CloudFoundryPushSettings.NoRoute"/></li>
        ///     <li><c>--no-start</c> via <see cref="CloudFoundryPushSettings.NoStart"/></li>
        ///     <li><c>--random-route</c> via <see cref="CloudFoundryPushSettings.RandomRoute"/></li>
        ///     <li><c>--route-path</c> via <see cref="CloudFoundryPushSettings.RoutePath"/></li>
        ///     <li><c>-b</c> via <see cref="CloudFoundryPushSettings.Buildpack"/></li>
        ///     <li><c>-c</c> via <see cref="CloudFoundryPushSettings.Command"/></li>
        ///     <li><c>-d</c> via <see cref="CloudFoundryPushSettings.Domain"/></li>
        ///     <li><c>-f</c> via <see cref="CloudFoundryPushSettings.Manifest"/></li>
        ///     <li><c>-n</c> via <see cref="CloudFoundryPushSettings.Hostname"/></li>
        ///     <li><c>-o</c> via <see cref="CloudFoundryPushSettings.DockerImage"/></li>
        ///     <li><c>-p</c> via <see cref="CloudFoundryPushSettings.Path"/></li>
        ///     <li><c>-s</c> via <see cref="CloudFoundryPushSettings.Stack"/></li>
        ///     <li><c>-t</c> via <see cref="CloudFoundryPushSettings.StartupTimeout"/></li>
        ///     <li><c>-u</c> via <see cref="CloudFoundryPushSettings.HealthCheckType"/></li>
        ///     <li><c>-var</c> via <see cref="CloudFoundryPushSettings.Variables"/></li>
        ///     <li><c>-vars-file</c> via <see cref="CloudFoundryPushSettings.VariablesFile"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryPush(CloudFoundryPushSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryPushSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Push a new app or sync changes to an existing app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryPushSettings.AppName"/></li>
        ///     <li><c>--docker-username</c> via <see cref="CloudFoundryPushSettings.DockerUsername"/></li>
        ///     <li><c>--droplet</c> via <see cref="CloudFoundryPushSettings.Droplet"/></li>
        ///     <li><c>--no-manifest</c> via <see cref="CloudFoundryPushSettings.IgnoreManifest"/></li>
        ///     <li><c>--no-route</c> via <see cref="CloudFoundryPushSettings.NoRoute"/></li>
        ///     <li><c>--no-start</c> via <see cref="CloudFoundryPushSettings.NoStart"/></li>
        ///     <li><c>--random-route</c> via <see cref="CloudFoundryPushSettings.RandomRoute"/></li>
        ///     <li><c>--route-path</c> via <see cref="CloudFoundryPushSettings.RoutePath"/></li>
        ///     <li><c>-b</c> via <see cref="CloudFoundryPushSettings.Buildpack"/></li>
        ///     <li><c>-c</c> via <see cref="CloudFoundryPushSettings.Command"/></li>
        ///     <li><c>-d</c> via <see cref="CloudFoundryPushSettings.Domain"/></li>
        ///     <li><c>-f</c> via <see cref="CloudFoundryPushSettings.Manifest"/></li>
        ///     <li><c>-n</c> via <see cref="CloudFoundryPushSettings.Hostname"/></li>
        ///     <li><c>-o</c> via <see cref="CloudFoundryPushSettings.DockerImage"/></li>
        ///     <li><c>-p</c> via <see cref="CloudFoundryPushSettings.Path"/></li>
        ///     <li><c>-s</c> via <see cref="CloudFoundryPushSettings.Stack"/></li>
        ///     <li><c>-t</c> via <see cref="CloudFoundryPushSettings.StartupTimeout"/></li>
        ///     <li><c>-u</c> via <see cref="CloudFoundryPushSettings.HealthCheckType"/></li>
        ///     <li><c>-var</c> via <see cref="CloudFoundryPushSettings.Variables"/></li>
        ///     <li><c>-vars-file</c> via <see cref="CloudFoundryPushSettings.VariablesFile"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryPush(Configure<CloudFoundryPushSettings> configurator)
        {
            return CloudFoundryPush(configurator(new CloudFoundryPushSettings()));
        }
        /// <summary>
        ///   <p>Push a new app or sync changes to an existing app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryPushSettings.AppName"/></li>
        ///     <li><c>--docker-username</c> via <see cref="CloudFoundryPushSettings.DockerUsername"/></li>
        ///     <li><c>--droplet</c> via <see cref="CloudFoundryPushSettings.Droplet"/></li>
        ///     <li><c>--no-manifest</c> via <see cref="CloudFoundryPushSettings.IgnoreManifest"/></li>
        ///     <li><c>--no-route</c> via <see cref="CloudFoundryPushSettings.NoRoute"/></li>
        ///     <li><c>--no-start</c> via <see cref="CloudFoundryPushSettings.NoStart"/></li>
        ///     <li><c>--random-route</c> via <see cref="CloudFoundryPushSettings.RandomRoute"/></li>
        ///     <li><c>--route-path</c> via <see cref="CloudFoundryPushSettings.RoutePath"/></li>
        ///     <li><c>-b</c> via <see cref="CloudFoundryPushSettings.Buildpack"/></li>
        ///     <li><c>-c</c> via <see cref="CloudFoundryPushSettings.Command"/></li>
        ///     <li><c>-d</c> via <see cref="CloudFoundryPushSettings.Domain"/></li>
        ///     <li><c>-f</c> via <see cref="CloudFoundryPushSettings.Manifest"/></li>
        ///     <li><c>-n</c> via <see cref="CloudFoundryPushSettings.Hostname"/></li>
        ///     <li><c>-o</c> via <see cref="CloudFoundryPushSettings.DockerImage"/></li>
        ///     <li><c>-p</c> via <see cref="CloudFoundryPushSettings.Path"/></li>
        ///     <li><c>-s</c> via <see cref="CloudFoundryPushSettings.Stack"/></li>
        ///     <li><c>-t</c> via <see cref="CloudFoundryPushSettings.StartupTimeout"/></li>
        ///     <li><c>-u</c> via <see cref="CloudFoundryPushSettings.HealthCheckType"/></li>
        ///     <li><c>-var</c> via <see cref="CloudFoundryPushSettings.Variables"/></li>
        ///     <li><c>-vars-file</c> via <see cref="CloudFoundryPushSettings.VariablesFile"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryPushSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryPush(CombinatorialConfigure<CloudFoundryPushSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryPush, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Log user in to specific endpoint and optionally set target</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--skip-ssl-validation</c> via <see cref="CloudFoundryLoginSettings.SkipSslValidation"/></li>
        ///     <li><c>-a</c> via <see cref="CloudFoundryLoginSettings.ApiEndpoint"/></li>
        ///     <li><c>-o</c> via <see cref="CloudFoundryLoginSettings.Org"/></li>
        ///     <li><c>-p</c> via <see cref="CloudFoundryLoginSettings.Password"/></li>
        ///     <li><c>-s</c> via <see cref="CloudFoundryLoginSettings.Space"/></li>
        ///     <li><c>-u</c> via <see cref="CloudFoundryLoginSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryLogin(CloudFoundryLoginSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryLoginSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Log user in to specific endpoint and optionally set target</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--skip-ssl-validation</c> via <see cref="CloudFoundryLoginSettings.SkipSslValidation"/></li>
        ///     <li><c>-a</c> via <see cref="CloudFoundryLoginSettings.ApiEndpoint"/></li>
        ///     <li><c>-o</c> via <see cref="CloudFoundryLoginSettings.Org"/></li>
        ///     <li><c>-p</c> via <see cref="CloudFoundryLoginSettings.Password"/></li>
        ///     <li><c>-s</c> via <see cref="CloudFoundryLoginSettings.Space"/></li>
        ///     <li><c>-u</c> via <see cref="CloudFoundryLoginSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryLogin(Configure<CloudFoundryLoginSettings> configurator)
        {
            return CloudFoundryLogin(configurator(new CloudFoundryLoginSettings()));
        }
        /// <summary>
        ///   <p>Log user in to specific endpoint and optionally set target</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--skip-ssl-validation</c> via <see cref="CloudFoundryLoginSettings.SkipSslValidation"/></li>
        ///     <li><c>-a</c> via <see cref="CloudFoundryLoginSettings.ApiEndpoint"/></li>
        ///     <li><c>-o</c> via <see cref="CloudFoundryLoginSettings.Org"/></li>
        ///     <li><c>-p</c> via <see cref="CloudFoundryLoginSettings.Password"/></li>
        ///     <li><c>-s</c> via <see cref="CloudFoundryLoginSettings.Space"/></li>
        ///     <li><c>-u</c> via <see cref="CloudFoundryLoginSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryLoginSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryLogin(CombinatorialConfigure<CloudFoundryLoginSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryLogin, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Authenticate non-interactively</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;password&gt;</c> via <see cref="CloudFoundryAuthSettings.Password"/></li>
        ///     <li><c>&lt;username&gt;</c> via <see cref="CloudFoundryAuthSettings.Username"/></li>
        ///     <li><c>--client-credentials</c> via <see cref="CloudFoundryAuthSettings.ClientCredentials"/></li>
        ///     <li><c>-origin</c> via <see cref="CloudFoundryAuthSettings.Origin"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryAuth(CloudFoundryAuthSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryAuthSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Authenticate non-interactively</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;password&gt;</c> via <see cref="CloudFoundryAuthSettings.Password"/></li>
        ///     <li><c>&lt;username&gt;</c> via <see cref="CloudFoundryAuthSettings.Username"/></li>
        ///     <li><c>--client-credentials</c> via <see cref="CloudFoundryAuthSettings.ClientCredentials"/></li>
        ///     <li><c>-origin</c> via <see cref="CloudFoundryAuthSettings.Origin"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryAuth(Configure<CloudFoundryAuthSettings> configurator)
        {
            return CloudFoundryAuth(configurator(new CloudFoundryAuthSettings()));
        }
        /// <summary>
        ///   <p>Authenticate non-interactively</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;password&gt;</c> via <see cref="CloudFoundryAuthSettings.Password"/></li>
        ///     <li><c>&lt;username&gt;</c> via <see cref="CloudFoundryAuthSettings.Username"/></li>
        ///     <li><c>--client-credentials</c> via <see cref="CloudFoundryAuthSettings.ClientCredentials"/></li>
        ///     <li><c>-origin</c> via <see cref="CloudFoundryAuthSettings.Origin"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryAuthSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryAuth(CombinatorialConfigure<CloudFoundryAuthSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryAuth, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Change or view the instance count, disk space limit, and memory limit for an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-i</c> via <see cref="CloudFoundryScaleSettings.Instances"/></li>
        ///     <li><c>-k</c> via <see cref="CloudFoundryScaleSettings.Disk"/></li>
        ///     <li><c>-m</c> via <see cref="CloudFoundryScaleSettings.Memory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryScale(CloudFoundryScaleSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryScaleSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Change or view the instance count, disk space limit, and memory limit for an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-i</c> via <see cref="CloudFoundryScaleSettings.Instances"/></li>
        ///     <li><c>-k</c> via <see cref="CloudFoundryScaleSettings.Disk"/></li>
        ///     <li><c>-m</c> via <see cref="CloudFoundryScaleSettings.Memory"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryScale(Configure<CloudFoundryScaleSettings> configurator)
        {
            return CloudFoundryScale(configurator(new CloudFoundryScaleSettings()));
        }
        /// <summary>
        ///   <p>Change or view the instance count, disk space limit, and memory limit for an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-i</c> via <see cref="CloudFoundryScaleSettings.Instances"/></li>
        ///     <li><c>-k</c> via <see cref="CloudFoundryScaleSettings.Disk"/></li>
        ///     <li><c>-m</c> via <see cref="CloudFoundryScaleSettings.Memory"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryScaleSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryScale(CombinatorialConfigure<CloudFoundryScaleSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryScale, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Set an env variable for an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundrySetEnvSettings.AppName"/></li>
        ///     <li><c>&lt;envVarName&gt;</c> via <see cref="CloudFoundrySetEnvSettings.EnvVarName"/></li>
        ///     <li><c>&lt;envVarValue&gt;</c> via <see cref="CloudFoundrySetEnvSettings.EnvVarValue"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundrySetEnv(CloudFoundrySetEnvSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundrySetEnvSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Set an env variable for an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundrySetEnvSettings.AppName"/></li>
        ///     <li><c>&lt;envVarName&gt;</c> via <see cref="CloudFoundrySetEnvSettings.EnvVarName"/></li>
        ///     <li><c>&lt;envVarValue&gt;</c> via <see cref="CloudFoundrySetEnvSettings.EnvVarValue"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundrySetEnv(Configure<CloudFoundrySetEnvSettings> configurator)
        {
            return CloudFoundrySetEnv(configurator(new CloudFoundrySetEnvSettings()));
        }
        /// <summary>
        ///   <p>Set an env variable for an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundrySetEnvSettings.AppName"/></li>
        ///     <li><c>&lt;envVarName&gt;</c> via <see cref="CloudFoundrySetEnvSettings.EnvVarName"/></li>
        ///     <li><c>&lt;envVarValue&gt;</c> via <see cref="CloudFoundrySetEnvSettings.EnvVarValue"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundrySetEnvSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundrySetEnv(CombinatorialConfigure<CloudFoundrySetEnvSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundrySetEnv, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Executes a request to the targeted API endpoint</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;path&gt;</c> via <see cref="CloudFoundryCurlSettings.Path"/></li>
        ///     <li><c>-d</c> via <see cref="CloudFoundryCurlSettings.HttpData"/></li>
        ///     <li><c>-i</c> via <see cref="CloudFoundryCurlSettings.IncludeResponseHeaders"/></li>
        ///     <li><c>-X</c> via <see cref="CloudFoundryCurlSettings.HttpMethod"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryCurl(CloudFoundryCurlSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryCurlSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Executes a request to the targeted API endpoint</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;path&gt;</c> via <see cref="CloudFoundryCurlSettings.Path"/></li>
        ///     <li><c>-d</c> via <see cref="CloudFoundryCurlSettings.HttpData"/></li>
        ///     <li><c>-i</c> via <see cref="CloudFoundryCurlSettings.IncludeResponseHeaders"/></li>
        ///     <li><c>-X</c> via <see cref="CloudFoundryCurlSettings.HttpMethod"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryCurl(Configure<CloudFoundryCurlSettings> configurator)
        {
            return CloudFoundryCurl(configurator(new CloudFoundryCurlSettings()));
        }
        /// <summary>
        ///   <p>Executes a request to the targeted API endpoint</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;path&gt;</c> via <see cref="CloudFoundryCurlSettings.Path"/></li>
        ///     <li><c>-d</c> via <see cref="CloudFoundryCurlSettings.HttpData"/></li>
        ///     <li><c>-i</c> via <see cref="CloudFoundryCurlSettings.IncludeResponseHeaders"/></li>
        ///     <li><c>-X</c> via <see cref="CloudFoundryCurlSettings.HttpMethod"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryCurlSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryCurl(CombinatorialConfigure<CloudFoundryCurlSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryCurl, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Set or view target api url</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;url&gt;</c> via <see cref="CloudFoundryApiSettings.Url"/></li>
        ///     <li><c>--skip-ssl-validation</c> via <see cref="CloudFoundryApiSettings.SkipSSLValidation"/></li>
        ///     <li><c>--unset</c> via <see cref="CloudFoundryApiSettings.Unset"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryApi(CloudFoundryApiSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryApiSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Set or view target api url</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;url&gt;</c> via <see cref="CloudFoundryApiSettings.Url"/></li>
        ///     <li><c>--skip-ssl-validation</c> via <see cref="CloudFoundryApiSettings.SkipSSLValidation"/></li>
        ///     <li><c>--unset</c> via <see cref="CloudFoundryApiSettings.Unset"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryApi(Configure<CloudFoundryApiSettings> configurator)
        {
            return CloudFoundryApi(configurator(new CloudFoundryApiSettings()));
        }
        /// <summary>
        ///   <p>Set or view target api url</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;url&gt;</c> via <see cref="CloudFoundryApiSettings.Url"/></li>
        ///     <li><c>--skip-ssl-validation</c> via <see cref="CloudFoundryApiSettings.SkipSSLValidation"/></li>
        ///     <li><c>--unset</c> via <see cref="CloudFoundryApiSettings.Unset"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryApiSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryApi(CombinatorialConfigure<CloudFoundryApiSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryApi, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Make a user-provided service instance available to CF apps</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;serviceInstanceName&gt;</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.ServiceInstanceName"/></li>
        ///     <li><c>-l</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.LogUrl"/></li>
        ///     <li><c>-p</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.Credentials"/></li>
        ///     <li><c>-r</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.RouteUrl"/></li>
        ///     <li><c>-t</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.Tags"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryCreateUserProvidedService(CloudFoundryCreateUserProvidedServiceSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryCreateUserProvidedServiceSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Make a user-provided service instance available to CF apps</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;serviceInstanceName&gt;</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.ServiceInstanceName"/></li>
        ///     <li><c>-l</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.LogUrl"/></li>
        ///     <li><c>-p</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.Credentials"/></li>
        ///     <li><c>-r</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.RouteUrl"/></li>
        ///     <li><c>-t</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.Tags"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryCreateUserProvidedService(Configure<CloudFoundryCreateUserProvidedServiceSettings> configurator)
        {
            return CloudFoundryCreateUserProvidedService(configurator(new CloudFoundryCreateUserProvidedServiceSettings()));
        }
        /// <summary>
        ///   <p>Make a user-provided service instance available to CF apps</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;serviceInstanceName&gt;</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.ServiceInstanceName"/></li>
        ///     <li><c>-l</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.LogUrl"/></li>
        ///     <li><c>-p</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.Credentials"/></li>
        ///     <li><c>-r</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.RouteUrl"/></li>
        ///     <li><c>-t</c> via <see cref="CloudFoundryCreateUserProvidedServiceSettings.Tags"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryCreateUserProvidedServiceSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryCreateUserProvidedService(CombinatorialConfigure<CloudFoundryCreateUserProvidedServiceSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryCreateUserProvidedService, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Start an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryStartSettings.AppName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryStart(CloudFoundryStartSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryStartSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Start an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryStartSettings.AppName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryStart(Configure<CloudFoundryStartSettings> configurator)
        {
            return CloudFoundryStart(configurator(new CloudFoundryStartSettings()));
        }
        /// <summary>
        ///   <p>Start an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryStartSettings.AppName"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryStartSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryStart(CombinatorialConfigure<CloudFoundryStartSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryStart, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Stop an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryStopSettings.AppName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryStop(CloudFoundryStopSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryStopSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Stop an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryStopSettings.AppName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryStop(Configure<CloudFoundryStopSettings> configurator)
        {
            return CloudFoundryStop(configurator(new CloudFoundryStopSettings()));
        }
        /// <summary>
        ///   <p>Stop an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryStopSettings.AppName"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryStopSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryStop(CombinatorialConfigure<CloudFoundryStopSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryStop, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Stop all instances of the app, then start them again. This causes downtime.</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryRestartSettings.AppName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryRestart(CloudFoundryRestartSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryRestartSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Stop all instances of the app, then start them again. This causes downtime.</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryRestartSettings.AppName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryRestart(Configure<CloudFoundryRestartSettings> configurator)
        {
            return CloudFoundryRestart(configurator(new CloudFoundryRestartSettings()));
        }
        /// <summary>
        ///   <p>Stop all instances of the app, then start them again. This causes downtime.</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryRestartSettings.AppName"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryRestartSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryRestart(CombinatorialConfigure<CloudFoundryRestartSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryRestart, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Recreate the app's executable artifact using the latest pushed app files and the latest environment (variables, service bindings, buildpack, stack, etc.). This action will cause app downtime.</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryRestageSettings.AppName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryRestage(CloudFoundryRestageSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryRestageSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Recreate the app's executable artifact using the latest pushed app files and the latest environment (variables, service bindings, buildpack, stack, etc.). This action will cause app downtime.</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryRestageSettings.AppName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryRestage(Configure<CloudFoundryRestageSettings> configurator)
        {
            return CloudFoundryRestage(configurator(new CloudFoundryRestageSettings()));
        }
        /// <summary>
        ///   <p>Recreate the app's executable artifact using the latest pushed app files and the latest environment (variables, service bindings, buildpack, stack, etc.). This action will cause app downtime.</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryRestageSettings.AppName"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryRestageSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryRestage(CombinatorialConfigure<CloudFoundryRestageSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryRestage, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Delete an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryDeleteApplicationSettings.AppName"/></li>
        ///     <li><c>-r</c> via <see cref="CloudFoundryDeleteApplicationSettings.DeleteRoutes"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryDeleteApplication(CloudFoundryDeleteApplicationSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryDeleteApplicationSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Delete an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryDeleteApplicationSettings.AppName"/></li>
        ///     <li><c>-r</c> via <see cref="CloudFoundryDeleteApplicationSettings.DeleteRoutes"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryDeleteApplication(Configure<CloudFoundryDeleteApplicationSettings> configurator)
        {
            return CloudFoundryDeleteApplication(configurator(new CloudFoundryDeleteApplicationSettings()));
        }
        /// <summary>
        ///   <p>Delete an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryDeleteApplicationSettings.AppName"/></li>
        ///     <li><c>-r</c> via <see cref="CloudFoundryDeleteApplicationSettings.DeleteRoutes"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryDeleteApplicationSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryDeleteApplication(CombinatorialConfigure<CloudFoundryDeleteApplicationSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryDeleteApplication, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Create a service instance</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;instanceName&gt;</c> via <see cref="CloudFoundryCreateServiceSettings.InstanceName"/></li>
        ///     <li><c>&lt;plan&gt;</c> via <see cref="CloudFoundryCreateServiceSettings.Plan"/></li>
        ///     <li><c>&lt;service&gt;</c> via <see cref="CloudFoundryCreateServiceSettings.Service"/></li>
        ///     <li><c>-c</c> via <see cref="CloudFoundryCreateServiceSettings.ConfigurationParameters"/></li>
        ///     <li><c>-t</c> via <see cref="CloudFoundryCreateServiceSettings.Tags"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryCreateService(CloudFoundryCreateServiceSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryCreateServiceSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Create a service instance</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;instanceName&gt;</c> via <see cref="CloudFoundryCreateServiceSettings.InstanceName"/></li>
        ///     <li><c>&lt;plan&gt;</c> via <see cref="CloudFoundryCreateServiceSettings.Plan"/></li>
        ///     <li><c>&lt;service&gt;</c> via <see cref="CloudFoundryCreateServiceSettings.Service"/></li>
        ///     <li><c>-c</c> via <see cref="CloudFoundryCreateServiceSettings.ConfigurationParameters"/></li>
        ///     <li><c>-t</c> via <see cref="CloudFoundryCreateServiceSettings.Tags"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryCreateService(Configure<CloudFoundryCreateServiceSettings> configurator)
        {
            return CloudFoundryCreateService(configurator(new CloudFoundryCreateServiceSettings()));
        }
        /// <summary>
        ///   <p>Create a service instance</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;instanceName&gt;</c> via <see cref="CloudFoundryCreateServiceSettings.InstanceName"/></li>
        ///     <li><c>&lt;plan&gt;</c> via <see cref="CloudFoundryCreateServiceSettings.Plan"/></li>
        ///     <li><c>&lt;service&gt;</c> via <see cref="CloudFoundryCreateServiceSettings.Service"/></li>
        ///     <li><c>-c</c> via <see cref="CloudFoundryCreateServiceSettings.ConfigurationParameters"/></li>
        ///     <li><c>-t</c> via <see cref="CloudFoundryCreateServiceSettings.Tags"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryCreateServiceSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryCreateService(CombinatorialConfigure<CloudFoundryCreateServiceSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryCreateService, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Delete a service instance</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;serviceInstance&gt;</c> via <see cref="CloudFoundryDeleteServiceSettings.ServiceInstance"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryDeleteService(CloudFoundryDeleteServiceSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryDeleteServiceSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Delete a service instance</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;serviceInstance&gt;</c> via <see cref="CloudFoundryDeleteServiceSettings.ServiceInstance"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryDeleteService(Configure<CloudFoundryDeleteServiceSettings> configurator)
        {
            return CloudFoundryDeleteService(configurator(new CloudFoundryDeleteServiceSettings()));
        }
        /// <summary>
        ///   <p>Delete a service instance</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;serviceInstance&gt;</c> via <see cref="CloudFoundryDeleteServiceSettings.ServiceInstance"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryDeleteServiceSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryDeleteService(CombinatorialConfigure<CloudFoundryDeleteServiceSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryDeleteService, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Show service instance info</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;serviceInstance&gt;</c> via <see cref="CloudFoundryGetServiceInfoSettings.ServiceInstance"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryGetServiceInfo(CloudFoundryGetServiceInfoSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryGetServiceInfoSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Show service instance info</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;serviceInstance&gt;</c> via <see cref="CloudFoundryGetServiceInfoSettings.ServiceInstance"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryGetServiceInfo(Configure<CloudFoundryGetServiceInfoSettings> configurator)
        {
            return CloudFoundryGetServiceInfo(configurator(new CloudFoundryGetServiceInfoSettings()));
        }
        /// <summary>
        ///   <p>Show service instance info</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;serviceInstance&gt;</c> via <see cref="CloudFoundryGetServiceInfoSettings.ServiceInstance"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryGetServiceInfoSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryGetServiceInfo(CombinatorialConfigure<CloudFoundryGetServiceInfoSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryGetServiceInfo, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Bind service instance</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryBindServiceSettings.AppName"/></li>
        ///     <li><c>&lt;serviceInstance&gt;</c> via <see cref="CloudFoundryBindServiceSettings.ServiceInstance"/></li>
        ///     <li><c>--binding-name</c> via <see cref="CloudFoundryBindServiceSettings.BindingName"/></li>
        ///     <li><c>-c</c> via <see cref="CloudFoundryBindServiceSettings.ConfigurationParameters"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryBindService(CloudFoundryBindServiceSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryBindServiceSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Bind service instance</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryBindServiceSettings.AppName"/></li>
        ///     <li><c>&lt;serviceInstance&gt;</c> via <see cref="CloudFoundryBindServiceSettings.ServiceInstance"/></li>
        ///     <li><c>--binding-name</c> via <see cref="CloudFoundryBindServiceSettings.BindingName"/></li>
        ///     <li><c>-c</c> via <see cref="CloudFoundryBindServiceSettings.ConfigurationParameters"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryBindService(Configure<CloudFoundryBindServiceSettings> configurator)
        {
            return CloudFoundryBindService(configurator(new CloudFoundryBindServiceSettings()));
        }
        /// <summary>
        ///   <p>Bind service instance</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryBindServiceSettings.AppName"/></li>
        ///     <li><c>&lt;serviceInstance&gt;</c> via <see cref="CloudFoundryBindServiceSettings.ServiceInstance"/></li>
        ///     <li><c>--binding-name</c> via <see cref="CloudFoundryBindServiceSettings.BindingName"/></li>
        ///     <li><c>-c</c> via <see cref="CloudFoundryBindServiceSettings.ConfigurationParameters"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryBindServiceSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryBindService(CombinatorialConfigure<CloudFoundryBindServiceSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryBindService, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Bind service instance</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryUnbindServiceSettings.AppName"/></li>
        ///     <li><c>&lt;serviceInstance&gt;</c> via <see cref="CloudFoundryUnbindServiceSettings.ServiceInstance"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryUnbindService(CloudFoundryUnbindServiceSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryUnbindServiceSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Bind service instance</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryUnbindServiceSettings.AppName"/></li>
        ///     <li><c>&lt;serviceInstance&gt;</c> via <see cref="CloudFoundryUnbindServiceSettings.ServiceInstance"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryUnbindService(Configure<CloudFoundryUnbindServiceSettings> configurator)
        {
            return CloudFoundryUnbindService(configurator(new CloudFoundryUnbindServiceSettings()));
        }
        /// <summary>
        ///   <p>Bind service instance</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryUnbindServiceSettings.AppName"/></li>
        ///     <li><c>&lt;serviceInstance&gt;</c> via <see cref="CloudFoundryUnbindServiceSettings.ServiceInstance"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryUnbindServiceSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryUnbindService(CombinatorialConfigure<CloudFoundryUnbindServiceSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryUnbindService, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Remove an env variable from an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryUnsetEnvSettings.AppName"/></li>
        ///     <li><c>&lt;environmentalVariableName&gt;</c> via <see cref="CloudFoundryUnsetEnvSettings.EnvironmentalVariableName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryUnsetEnv(CloudFoundryUnsetEnvSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryUnsetEnvSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Remove an env variable from an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryUnsetEnvSettings.AppName"/></li>
        ///     <li><c>&lt;environmentalVariableName&gt;</c> via <see cref="CloudFoundryUnsetEnvSettings.EnvironmentalVariableName"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryUnsetEnv(Configure<CloudFoundryUnsetEnvSettings> configurator)
        {
            return CloudFoundryUnsetEnv(configurator(new CloudFoundryUnsetEnvSettings()));
        }
        /// <summary>
        ///   <p>Remove an env variable from an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryUnsetEnvSettings.AppName"/></li>
        ///     <li><c>&lt;environmentalVariableName&gt;</c> via <see cref="CloudFoundryUnsetEnvSettings.EnvironmentalVariableName"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryUnsetEnvSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryUnsetEnv(CombinatorialConfigure<CloudFoundryUnsetEnvSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryUnsetEnv, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Create a url route in a space for later use</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;domain&gt;</c> via <see cref="CloudFoundryCreateRouteSettings.Domain"/></li>
        ///     <li><c>&lt;space&gt;</c> via <see cref="CloudFoundryCreateRouteSettings.Space"/></li>
        ///     <li><c>--hostname</c> via <see cref="CloudFoundryCreateRouteSettings.Hostname"/></li>
        ///     <li><c>--path</c> via <see cref="CloudFoundryCreateRouteSettings.Path"/></li>
        ///     <li><c>--port</c> via <see cref="CloudFoundryCreateRouteSettings.Port"/></li>
        ///     <li><c>--random-port</c> via <see cref="CloudFoundryCreateRouteSettings.RandomPort"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryCreateRoute(CloudFoundryCreateRouteSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryCreateRouteSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Create a url route in a space for later use</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;domain&gt;</c> via <see cref="CloudFoundryCreateRouteSettings.Domain"/></li>
        ///     <li><c>&lt;space&gt;</c> via <see cref="CloudFoundryCreateRouteSettings.Space"/></li>
        ///     <li><c>--hostname</c> via <see cref="CloudFoundryCreateRouteSettings.Hostname"/></li>
        ///     <li><c>--path</c> via <see cref="CloudFoundryCreateRouteSettings.Path"/></li>
        ///     <li><c>--port</c> via <see cref="CloudFoundryCreateRouteSettings.Port"/></li>
        ///     <li><c>--random-port</c> via <see cref="CloudFoundryCreateRouteSettings.RandomPort"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryCreateRoute(Configure<CloudFoundryCreateRouteSettings> configurator)
        {
            return CloudFoundryCreateRoute(configurator(new CloudFoundryCreateRouteSettings()));
        }
        /// <summary>
        ///   <p>Create a url route in a space for later use</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;domain&gt;</c> via <see cref="CloudFoundryCreateRouteSettings.Domain"/></li>
        ///     <li><c>&lt;space&gt;</c> via <see cref="CloudFoundryCreateRouteSettings.Space"/></li>
        ///     <li><c>--hostname</c> via <see cref="CloudFoundryCreateRouteSettings.Hostname"/></li>
        ///     <li><c>--path</c> via <see cref="CloudFoundryCreateRouteSettings.Path"/></li>
        ///     <li><c>--port</c> via <see cref="CloudFoundryCreateRouteSettings.Port"/></li>
        ///     <li><c>--random-port</c> via <see cref="CloudFoundryCreateRouteSettings.RandomPort"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryCreateRouteSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryCreateRoute(CombinatorialConfigure<CloudFoundryCreateRouteSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryCreateRoute, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Add a url route to an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryMapRouteSettings.AppName"/></li>
        ///     <li><c>&lt;domain&gt;</c> via <see cref="CloudFoundryMapRouteSettings.Domain"/></li>
        ///     <li><c>--hostname</c> via <see cref="CloudFoundryMapRouteSettings.Hostname"/></li>
        ///     <li><c>--path</c> via <see cref="CloudFoundryMapRouteSettings.Path"/></li>
        ///     <li><c>--port</c> via <see cref="CloudFoundryMapRouteSettings.Port"/></li>
        ///     <li><c>--random-port</c> via <see cref="CloudFoundryMapRouteSettings.RandomPort"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryMapRoute(CloudFoundryMapRouteSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryMapRouteSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Add a url route to an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryMapRouteSettings.AppName"/></li>
        ///     <li><c>&lt;domain&gt;</c> via <see cref="CloudFoundryMapRouteSettings.Domain"/></li>
        ///     <li><c>--hostname</c> via <see cref="CloudFoundryMapRouteSettings.Hostname"/></li>
        ///     <li><c>--path</c> via <see cref="CloudFoundryMapRouteSettings.Path"/></li>
        ///     <li><c>--port</c> via <see cref="CloudFoundryMapRouteSettings.Port"/></li>
        ///     <li><c>--random-port</c> via <see cref="CloudFoundryMapRouteSettings.RandomPort"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryMapRoute(Configure<CloudFoundryMapRouteSettings> configurator)
        {
            return CloudFoundryMapRoute(configurator(new CloudFoundryMapRouteSettings()));
        }
        /// <summary>
        ///   <p>Add a url route to an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryMapRouteSettings.AppName"/></li>
        ///     <li><c>&lt;domain&gt;</c> via <see cref="CloudFoundryMapRouteSettings.Domain"/></li>
        ///     <li><c>--hostname</c> via <see cref="CloudFoundryMapRouteSettings.Hostname"/></li>
        ///     <li><c>--path</c> via <see cref="CloudFoundryMapRouteSettings.Path"/></li>
        ///     <li><c>--port</c> via <see cref="CloudFoundryMapRouteSettings.Port"/></li>
        ///     <li><c>--random-port</c> via <see cref="CloudFoundryMapRouteSettings.RandomPort"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryMapRouteSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryMapRoute(CombinatorialConfigure<CloudFoundryMapRouteSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryMapRoute, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Remove a url route from an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryUnmapRouteSettings.AppName"/></li>
        ///     <li><c>&lt;domain&gt;</c> via <see cref="CloudFoundryUnmapRouteSettings.Domain"/></li>
        ///     <li><c>--hostname</c> via <see cref="CloudFoundryUnmapRouteSettings.Hostname"/></li>
        ///     <li><c>--path</c> via <see cref="CloudFoundryUnmapRouteSettings.Path"/></li>
        ///     <li><c>--port</c> via <see cref="CloudFoundryUnmapRouteSettings.Port"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryUnmapRoute(CloudFoundryUnmapRouteSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryUnmapRouteSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Remove a url route from an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryUnmapRouteSettings.AppName"/></li>
        ///     <li><c>&lt;domain&gt;</c> via <see cref="CloudFoundryUnmapRouteSettings.Domain"/></li>
        ///     <li><c>--hostname</c> via <see cref="CloudFoundryUnmapRouteSettings.Hostname"/></li>
        ///     <li><c>--path</c> via <see cref="CloudFoundryUnmapRouteSettings.Path"/></li>
        ///     <li><c>--port</c> via <see cref="CloudFoundryUnmapRouteSettings.Port"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryUnmapRoute(Configure<CloudFoundryUnmapRouteSettings> configurator)
        {
            return CloudFoundryUnmapRoute(configurator(new CloudFoundryUnmapRouteSettings()));
        }
        /// <summary>
        ///   <p>Remove a url route from an app</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;appName&gt;</c> via <see cref="CloudFoundryUnmapRouteSettings.AppName"/></li>
        ///     <li><c>&lt;domain&gt;</c> via <see cref="CloudFoundryUnmapRouteSettings.Domain"/></li>
        ///     <li><c>--hostname</c> via <see cref="CloudFoundryUnmapRouteSettings.Hostname"/></li>
        ///     <li><c>--path</c> via <see cref="CloudFoundryUnmapRouteSettings.Path"/></li>
        ///     <li><c>--port</c> via <see cref="CloudFoundryUnmapRouteSettings.Port"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryUnmapRouteSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryUnmapRoute(CombinatorialConfigure<CloudFoundryUnmapRouteSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryUnmapRoute, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Create a space</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;space&gt;</c> via <see cref="CloudFoundryCreateSpaceSettings.Space"/></li>
        ///     <li><c>-o</c> via <see cref="CloudFoundryCreateSpaceSettings.Org"/></li>
        ///     <li><c>-q</c> via <see cref="CloudFoundryCreateSpaceSettings.Quota"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryCreateSpace(CloudFoundryCreateSpaceSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryCreateSpaceSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Create a space</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;space&gt;</c> via <see cref="CloudFoundryCreateSpaceSettings.Space"/></li>
        ///     <li><c>-o</c> via <see cref="CloudFoundryCreateSpaceSettings.Org"/></li>
        ///     <li><c>-q</c> via <see cref="CloudFoundryCreateSpaceSettings.Quota"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryCreateSpace(Configure<CloudFoundryCreateSpaceSettings> configurator)
        {
            return CloudFoundryCreateSpace(configurator(new CloudFoundryCreateSpaceSettings()));
        }
        /// <summary>
        ///   <p>Create a space</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;space&gt;</c> via <see cref="CloudFoundryCreateSpaceSettings.Space"/></li>
        ///     <li><c>-o</c> via <see cref="CloudFoundryCreateSpaceSettings.Org"/></li>
        ///     <li><c>-q</c> via <see cref="CloudFoundryCreateSpaceSettings.Quota"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryCreateSpaceSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryCreateSpace(CombinatorialConfigure<CloudFoundryCreateSpaceSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryCreateSpace, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Delete a space</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;space&gt;</c> via <see cref="CloudFoundryDeleteSpaceSettings.Space"/></li>
        ///     <li><c>-o</c> via <see cref="CloudFoundryDeleteSpaceSettings.Org"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryDeleteSpace(CloudFoundryDeleteSpaceSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryDeleteSpaceSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Delete a space</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;space&gt;</c> via <see cref="CloudFoundryDeleteSpaceSettings.Space"/></li>
        ///     <li><c>-o</c> via <see cref="CloudFoundryDeleteSpaceSettings.Org"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryDeleteSpace(Configure<CloudFoundryDeleteSpaceSettings> configurator)
        {
            return CloudFoundryDeleteSpace(configurator(new CloudFoundryDeleteSpaceSettings()));
        }
        /// <summary>
        ///   <p>Delete a space</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;space&gt;</c> via <see cref="CloudFoundryDeleteSpaceSettings.Space"/></li>
        ///     <li><c>-o</c> via <see cref="CloudFoundryDeleteSpaceSettings.Org"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryDeleteSpaceSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryDeleteSpace(CombinatorialConfigure<CloudFoundryDeleteSpaceSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryDeleteSpace, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
        /// <summary>
        ///   <p>Set or view the targeted org or space</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-o</c> via <see cref="CloudFoundryTargetSettings.Org"/></li>
        ///     <li><c>-s</c> via <see cref="CloudFoundryTargetSettings.Space"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryTarget(CloudFoundryTargetSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CloudFoundryTargetSettings();
            var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Set or view the targeted org or space</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-o</c> via <see cref="CloudFoundryTargetSettings.Org"/></li>
        ///     <li><c>-s</c> via <see cref="CloudFoundryTargetSettings.Space"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CloudFoundryTarget(Configure<CloudFoundryTargetSettings> configurator)
        {
            return CloudFoundryTarget(configurator(new CloudFoundryTargetSettings()));
        }
        /// <summary>
        ///   <p>Set or view the targeted org or space</p>
        ///   <p>For more details, visit the <a href="https://docs.cloudfoundry.org/cf-cli/cf-help.html">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>-o</c> via <see cref="CloudFoundryTargetSettings.Org"/></li>
        ///     <li><c>-s</c> via <see cref="CloudFoundryTargetSettings.Space"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CloudFoundryTargetSettings Settings, IReadOnlyCollection<Output> Output)> CloudFoundryTarget(CombinatorialConfigure<CloudFoundryTargetSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CloudFoundryTarget, CloudFoundryLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region CloudFoundryPushSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryPushSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        /// <summary>
        ///   The name of the application.
        /// </summary>
        public virtual string AppName { get; internal set; }
        /// <summary>
        ///   Buildpack to be used
        /// </summary>
        public virtual IReadOnlyList<string> Buildpack => BuildpackInternal.AsReadOnly();
        internal List<string> BuildpackInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Startup command
        /// </summary>
        public virtual string Command { get; internal set; }
        /// <summary>
        ///   Specify a custom domain (e.g. private-domain.example.com, apps.internal.com) to use instead of the default domain
        /// </summary>
        public virtual string Domain { get; internal set; }
        /// <summary>
        ///   Docker-image to be used (e.g. user/docker-image-name)
        /// </summary>
        public virtual string DockerImage { get; internal set; }
        /// <summary>
        ///   Docker-image to be used (e.g. user/docker-image-name)
        /// </summary>
        public virtual string DockerUsername { get; internal set; }
        /// <summary>
        ///   Path to a tgz file with a pre-staged app
        /// </summary>
        public virtual string Droplet { get; internal set; }
        /// <summary>
        ///   Path to manifest
        /// </summary>
        public virtual string Manifest { get; internal set; }
        /// <summary>
        ///   Application health check type
        /// </summary>
        public virtual HealthCheckType HealthCheckType { get; internal set; }
        /// <summary>
        ///   Hostname (e.g. my-subdomain)
        /// </summary>
        public virtual string Hostname { get; internal set; }
        /// <summary>
        ///   Ignore manifest file
        /// </summary>
        public virtual bool? IgnoreManifest { get; internal set; }
        /// <summary>
        ///   Do not map a route to this app and remove routes from previous pushes of this app
        /// </summary>
        public virtual bool? NoRoute { get; internal set; }
        /// <summary>
        ///   Do not start an app after pushing
        /// </summary>
        public virtual bool? NoStart { get; internal set; }
        /// <summary>
        ///   Path to app directory or to a zip file of the contents of the app directory
        /// </summary>
        public virtual string Path { get; internal set; }
        /// <summary>
        ///   Create a random route for this app
        /// </summary>
        public virtual bool? RandomRoute { get; internal set; }
        /// <summary>
        ///   Path for the route
        /// </summary>
        public virtual string RoutePath { get; internal set; }
        /// <summary>
        ///   Stack to use (a stack is a pre-built file system, including an operating system, that can run apps)
        /// </summary>
        public virtual Stack Stack { get; internal set; }
        /// <summary>
        ///   Path to a variable substitution file for manifest; can specify multiple times
        /// </summary>
        public virtual string VariablesFile { get; internal set; }
        /// <summary>
        ///   Variable key value pair for variable substitution in manifest
        /// </summary>
        public virtual IReadOnlyDictionary<string, string> Variables => VariablesInternal.AsReadOnly();
        internal Dictionary<string,string> VariablesInternal { get; set; } = new Dictionary<string,string>(StringComparer.OrdinalIgnoreCase);
        /// <summary>
        ///   Time (in seconds) allowed to elapse between starting up an app and the first healthy response from the app
        /// </summary>
        public virtual int? StartupTimeout { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("push")
              .Add("{value}", AppName)
              .Add("-b {value}", Buildpack)
              .Add("-c {value}", Command)
              .Add("-d {value}", Domain)
              .Add("-o {value}", DockerImage)
              .Add("--docker-username {value}", DockerUsername)
              .Add("--droplet {value}", Droplet)
              .Add("-f {value}", Manifest)
              .Add("-u {value}", HealthCheckType)
              .Add("-n {value}", Hostname)
              .Add("--no-manifest", IgnoreManifest)
              .Add("--no-route", NoRoute)
              .Add("--no-start", NoStart)
              .Add("-p {value}", Path)
              .Add("--random-route", RandomRoute)
              .Add("--route-path {value}", RoutePath)
              .Add("-s {value}", Stack)
              .Add("-vars-file {value}", VariablesFile)
              .Add("-var {value}", Variables, "{key}={value}")
              .Add("-t {value}", StartupTimeout);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryLoginSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryLoginSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string Username { get; internal set; }
        public virtual string Password { get; internal set; }
        /// <summary>
        ///   API endpoint (e.g. https://api.example.com)
        /// </summary>
        public virtual string ApiEndpoint { get; internal set; }
        public virtual string Org { get; internal set; }
        public virtual string Space { get; internal set; }
        /// <summary>
        ///   Skip verification of the API endpoint
        /// </summary>
        public virtual bool? SkipSslValidation { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("login")
              .Add("-u {value}", Username)
              .Add("-p {value}", Password, secret: true)
              .Add("-a {value}", ApiEndpoint)
              .Add("-o {value}", Org)
              .Add("-s {value}", Space)
              .Add("--skip-ssl-validation", SkipSslValidation);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryAuthSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryAuthSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string Username { get; internal set; }
        public virtual string Password { get; internal set; }
        public virtual string Origin { get; internal set; }
        /// <summary>
        ///   Use (non-user) service account (also called client credentials)
        /// </summary>
        public virtual bool? ClientCredentials { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("auth")
              .Add("{value}", Username)
              .Add("{value}", Password, secret: true)
              .Add("-origin {value}", Origin)
              .Add("--client-credentials", ClientCredentials);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryScaleSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryScaleSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        /// <summary>
        ///   Number of instances
        /// </summary>
        public virtual string Instances { get; internal set; }
        /// <summary>
        ///   Disk limit (e.g. 256M, 1024M, 1G)
        /// </summary>
        public virtual string Disk { get; internal set; }
        /// <summary>
        ///   Memory limit (e.g. 256M, 1024M, 1G)
        /// </summary>
        public virtual string Memory { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("scale -f")
              .Add("-i {value}", Instances)
              .Add("-k {value}", Disk)
              .Add("-m {value}", Memory);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundrySetEnvSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundrySetEnvSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        /// <summary>
        ///   App Name
        /// </summary>
        public virtual string AppName { get; internal set; }
        /// <summary>
        ///   Name of the environmental variable
        /// </summary>
        public virtual string EnvVarName { get; internal set; }
        /// <summary>
        ///   Value of the environmental variable
        /// </summary>
        public virtual string EnvVarValue { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("set-env")
              .Add("{value}", AppName)
              .Add("{value}", EnvVarName)
              .Add("{value}", EnvVarValue);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryCurlSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryCurlSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        /// <summary>
        ///   CAPI Path to invoke (ex. /v2/info)
        /// </summary>
        public virtual string Path { get; internal set; }
        /// <summary>
        ///   Include response headers in the output
        /// </summary>
        public virtual bool? IncludeResponseHeaders { get; internal set; }
        /// <summary>
        ///   HTTP method (GET,POST,PUT,DELETE,etc). Default is GET
        /// </summary>
        public virtual string HttpMethod { get; internal set; }
        /// <summary>
        ///   HTTP method (GET,POST,PUT,DELETE,etc). Default is GET
        /// </summary>
        public virtual string HttpData { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("curl")
              .Add("{value}", Path)
              .Add("-i", IncludeResponseHeaders)
              .Add("-X {value}", HttpMethod)
              .Add("-d {value}", HttpData);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryApiSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryApiSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string Url { get; internal set; }
        /// <summary>
        ///   Skip verification of the API endpoint
        /// </summary>
        public virtual bool? SkipSSLValidation { get; internal set; }
        /// <summary>
        ///   Remove all api endpoint targeting
        /// </summary>
        public virtual bool? Unset { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("api")
              .Add("{value}", Url)
              .Add("--skip-ssl-validation", SkipSSLValidation)
              .Add("--unset", Unset);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryCreateUserProvidedServiceSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryCreateUserProvidedServiceSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string ServiceInstanceName { get; internal set; }
        /// <summary>
        ///   URL to which requests for bound routes will be forwarded. Scheme for this URL must be https
        /// </summary>
        public virtual string RouteUrl { get; internal set; }
        /// <summary>
        ///   URL to which logs for bound applications will be streamed
        /// </summary>
        public virtual string LogUrl { get; internal set; }
        /// <summary>
        ///   Comma separated list of tags to assign to service. ex. 'db, relational'
        /// </summary>
        public virtual string Tags { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("cups")
              .Add("{value}", ServiceInstanceName)
              .Add("-p {value}", GetCredentials(), customValue: true)
              .Add("-r {value}", RouteUrl)
              .Add("-l {value}", LogUrl)
              .Add("-t {value}", Tags);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryStartSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryStartSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string AppName { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("start")
              .Add("{value}", AppName);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryStopSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryStopSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string AppName { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("stop")
              .Add("{value}", AppName);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryRestartSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryRestartSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string AppName { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("restart")
              .Add("{value}", AppName);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryRestageSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryRestageSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string AppName { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("restage")
              .Add("{value}", AppName);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryDeleteApplicationSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryDeleteApplicationSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string AppName { get; internal set; }
        /// <summary>
        ///   Also delete any mapped routes
        /// </summary>
        public virtual bool? DeleteRoutes { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("delete")
              .Add("{value} -f", AppName)
              .Add("-r", DeleteRoutes);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryCreateServiceSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryCreateServiceSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        /// <summary>
        ///   Service type
        /// </summary>
        public virtual string Service { get; internal set; }
        /// <summary>
        ///   Service plan
        /// </summary>
        public virtual string Plan { get; internal set; }
        /// <summary>
        ///   Instance name
        /// </summary>
        public virtual string InstanceName { get; internal set; }
        /// <summary>
        ///   Valid JSON object containing service-specific configuration parameters, provided either in-line or in a file
        /// </summary>
        public virtual string ConfigurationParameters { get; internal set; }
        /// <summary>
        ///   User provided tags
        /// </summary>
        public virtual IReadOnlyList<string> Tags => TagsInternal.AsReadOnly();
        internal List<string> TagsInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("create-service")
              .Add("{value}", Service)
              .Add("{value}", Plan)
              .Add("{value}", InstanceName)
              .Add("-c {value}", ConfigurationParameters)
              .Add("-t {value}", Tags);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryDeleteServiceSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryDeleteServiceSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        /// <summary>
        ///   Service Instance
        /// </summary>
        public virtual string ServiceInstance { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("delete-service")
              .Add("{value} -f", ServiceInstance);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryGetServiceInfoSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryGetServiceInfoSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        /// <summary>
        ///   Service Instance
        /// </summary>
        public virtual string ServiceInstance { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("service")
              .Add("{value}", ServiceInstance);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryBindServiceSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryBindServiceSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string AppName { get; internal set; }
        public virtual string ServiceInstance { get; internal set; }
        /// <summary>
        ///   Name to expose service instance to app process with (Default: service instance name)
        /// </summary>
        public virtual string BindingName { get; internal set; }
        /// <summary>
        ///   Valid JSON object containing service-specific configuration parameters, provided either in-line or in a file
        /// </summary>
        public virtual string ConfigurationParameters { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("bind-service")
              .Add("{value}", AppName)
              .Add("{value}", ServiceInstance)
              .Add("--binding-name {value}", BindingName)
              .Add("-c {value}", ConfigurationParameters);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryUnbindServiceSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryUnbindServiceSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string AppName { get; internal set; }
        public virtual string ServiceInstance { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("bind-service")
              .Add("{value}", AppName)
              .Add("{value}", ServiceInstance);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryUnsetEnvSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryUnsetEnvSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string AppName { get; internal set; }
        public virtual string EnvironmentalVariableName { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("set-env")
              .Add("{value}", AppName)
              .Add("{value}", EnvironmentalVariableName);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryCreateRouteSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryCreateRouteSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string Space { get; internal set; }
        public virtual string Domain { get; internal set; }
        /// <summary>
        ///   Hostname for the HTTP route (required for shared domains)
        /// </summary>
        public virtual string Hostname { get; internal set; }
        /// <summary>
        ///   Path for the HTTP route
        /// </summary>
        public virtual string Path { get; internal set; }
        /// <summary>
        ///   Port for the TCP route
        /// </summary>
        public virtual int? Port { get; internal set; }
        /// <summary>
        ///   Create a random port for the TCP route
        /// </summary>
        public virtual bool? RandomPort { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("create-route")
              .Add("{value}", Space)
              .Add("{value}", Domain)
              .Add("--hostname {value}", Hostname)
              .Add("--path {value}", Path)
              .Add("--port {value}", Port)
              .Add("--random-port", RandomPort);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryMapRouteSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryMapRouteSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string AppName { get; internal set; }
        public virtual string Domain { get; internal set; }
        /// <summary>
        ///   Hostname for the HTTP route (required for shared domains)
        /// </summary>
        public virtual string Hostname { get; internal set; }
        /// <summary>
        ///   Path for the HTTP route
        /// </summary>
        public virtual string Path { get; internal set; }
        /// <summary>
        ///   Port for the TCP route
        /// </summary>
        public virtual int? Port { get; internal set; }
        /// <summary>
        ///   Create a random port for the TCP route
        /// </summary>
        public virtual bool? RandomPort { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("map-route")
              .Add("{value}", AppName)
              .Add("{value}", Domain)
              .Add("--hostname {value}", Hostname)
              .Add("--path {value}", Path)
              .Add("--port {value}", Port)
              .Add("--random-port", RandomPort);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryUnmapRouteSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryUnmapRouteSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string AppName { get; internal set; }
        public virtual string Domain { get; internal set; }
        /// <summary>
        ///   Hostname for the HTTP route (required for shared domains)
        /// </summary>
        public virtual string Hostname { get; internal set; }
        /// <summary>
        ///   Path for the HTTP route
        /// </summary>
        public virtual string Path { get; internal set; }
        /// <summary>
        ///   Port for the TCP route
        /// </summary>
        public virtual int? Port { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("unmap-route")
              .Add("{value}", AppName)
              .Add("{value}", Domain)
              .Add("--hostname {value}", Hostname)
              .Add("--path {value}", Path)
              .Add("--port {value}", Port);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryCreateSpaceSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryCreateSpaceSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string Space { get; internal set; }
        public virtual string Org { get; internal set; }
        /// <summary>
        ///   Quota to assign to the newly created space
        /// </summary>
        public virtual string Quota { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("create-space")
              .Add("{value}", Space)
              .Add("-o {value}", Org)
              .Add("-q {value}", Quota);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryDeleteSpaceSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryDeleteSpaceSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string Space { get; internal set; }
        public virtual string Org { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("delete-space")
              .Add("{value} -f", Space)
              .Add("-o {value}", Org);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryTargetSettings
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CloudFoundryTargetSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CloudFoundry executable.
        /// </summary>
        public override string ToolPath => base.ToolPath ?? CloudFoundryTasks.CloudFoundryPath;
        public override Action<OutputType, string> CustomLogger => CloudFoundryTasks.CloudFoundryLogger;
        public virtual string Space { get; internal set; }
        public virtual string Org { get; internal set; }
        protected override Arguments ConfigureArguments(Arguments arguments)
        {
            arguments
              .Add("target")
              .Add("-s {value}", Space)
              .Add("-o {value}", Org);
            return base.ConfigureArguments(arguments);
        }
    }
    #endregion
    #region CloudFoundryPushSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryPushSettingsExtensions
    {
        #region AppName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.AppName"/></em></p>
        ///   <p>The name of the application.</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetAppName(this CloudFoundryPushSettings toolSettings, string appName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = appName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.AppName"/></em></p>
        ///   <p>The name of the application.</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetAppName(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = null;
            return toolSettings;
        }
        #endregion
        #region Buildpack
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.Buildpack"/> to a new list</em></p>
        ///   <p>Buildpack to be used</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetBuildpack(this CloudFoundryPushSettings toolSettings, params string[] buildpack)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildpackInternal = buildpack.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.Buildpack"/> to a new list</em></p>
        ///   <p>Buildpack to be used</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetBuildpack(this CloudFoundryPushSettings toolSettings, IEnumerable<string> buildpack)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildpackInternal = buildpack.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CloudFoundryPushSettings.Buildpack"/></em></p>
        ///   <p>Buildpack to be used</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings AddBuildpack(this CloudFoundryPushSettings toolSettings, params string[] buildpack)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildpackInternal.AddRange(buildpack);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CloudFoundryPushSettings.Buildpack"/></em></p>
        ///   <p>Buildpack to be used</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings AddBuildpack(this CloudFoundryPushSettings toolSettings, IEnumerable<string> buildpack)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildpackInternal.AddRange(buildpack);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CloudFoundryPushSettings.Buildpack"/></em></p>
        ///   <p>Buildpack to be used</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ClearBuildpack(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BuildpackInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CloudFoundryPushSettings.Buildpack"/></em></p>
        ///   <p>Buildpack to be used</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings RemoveBuildpack(this CloudFoundryPushSettings toolSettings, params string[] buildpack)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(buildpack);
            toolSettings.BuildpackInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CloudFoundryPushSettings.Buildpack"/></em></p>
        ///   <p>Buildpack to be used</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings RemoveBuildpack(this CloudFoundryPushSettings toolSettings, IEnumerable<string> buildpack)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(buildpack);
            toolSettings.BuildpackInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region Command
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.Command"/></em></p>
        ///   <p>Startup command</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetCommand(this CloudFoundryPushSettings toolSettings, string command)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.Command"/></em></p>
        ///   <p>Startup command</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetCommand(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = null;
            return toolSettings;
        }
        #endregion
        #region Domain
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.Domain"/></em></p>
        ///   <p>Specify a custom domain (e.g. private-domain.example.com, apps.internal.com) to use instead of the default domain</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetDomain(this CloudFoundryPushSettings toolSettings, string domain)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = domain;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.Domain"/></em></p>
        ///   <p>Specify a custom domain (e.g. private-domain.example.com, apps.internal.com) to use instead of the default domain</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetDomain(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = null;
            return toolSettings;
        }
        #endregion
        #region DockerImage
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.DockerImage"/></em></p>
        ///   <p>Docker-image to be used (e.g. user/docker-image-name)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetDockerImage(this CloudFoundryPushSettings toolSettings, string dockerImage)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DockerImage = dockerImage;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.DockerImage"/></em></p>
        ///   <p>Docker-image to be used (e.g. user/docker-image-name)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetDockerImage(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DockerImage = null;
            return toolSettings;
        }
        #endregion
        #region DockerUsername
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.DockerUsername"/></em></p>
        ///   <p>Docker-image to be used (e.g. user/docker-image-name)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetDockerUsername(this CloudFoundryPushSettings toolSettings, string dockerUsername)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DockerUsername = dockerUsername;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.DockerUsername"/></em></p>
        ///   <p>Docker-image to be used (e.g. user/docker-image-name)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetDockerUsername(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DockerUsername = null;
            return toolSettings;
        }
        #endregion
        #region Droplet
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.Droplet"/></em></p>
        ///   <p>Path to a tgz file with a pre-staged app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetDroplet(this CloudFoundryPushSettings toolSettings, string droplet)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Droplet = droplet;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.Droplet"/></em></p>
        ///   <p>Path to a tgz file with a pre-staged app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetDroplet(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Droplet = null;
            return toolSettings;
        }
        #endregion
        #region Manifest
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.Manifest"/></em></p>
        ///   <p>Path to manifest</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetManifest(this CloudFoundryPushSettings toolSettings, string manifest)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manifest = manifest;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.Manifest"/></em></p>
        ///   <p>Path to manifest</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetManifest(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Manifest = null;
            return toolSettings;
        }
        #endregion
        #region HealthCheckType
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.HealthCheckType"/></em></p>
        ///   <p>Application health check type</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetHealthCheckType(this CloudFoundryPushSettings toolSettings, HealthCheckType healthCheckType)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HealthCheckType = healthCheckType;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.HealthCheckType"/></em></p>
        ///   <p>Application health check type</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetHealthCheckType(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HealthCheckType = null;
            return toolSettings;
        }
        #endregion
        #region Hostname
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.Hostname"/></em></p>
        ///   <p>Hostname (e.g. my-subdomain)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetHostname(this CloudFoundryPushSettings toolSettings, string hostname)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Hostname = hostname;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.Hostname"/></em></p>
        ///   <p>Hostname (e.g. my-subdomain)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetHostname(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Hostname = null;
            return toolSettings;
        }
        #endregion
        #region IgnoreManifest
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.IgnoreManifest"/></em></p>
        ///   <p>Ignore manifest file</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetIgnoreManifest(this CloudFoundryPushSettings toolSettings, bool? ignoreManifest)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreManifest = ignoreManifest;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.IgnoreManifest"/></em></p>
        ///   <p>Ignore manifest file</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetIgnoreManifest(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreManifest = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CloudFoundryPushSettings.IgnoreManifest"/></em></p>
        ///   <p>Ignore manifest file</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings EnableIgnoreManifest(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreManifest = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CloudFoundryPushSettings.IgnoreManifest"/></em></p>
        ///   <p>Ignore manifest file</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings DisableIgnoreManifest(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreManifest = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CloudFoundryPushSettings.IgnoreManifest"/></em></p>
        ///   <p>Ignore manifest file</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ToggleIgnoreManifest(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IgnoreManifest = !toolSettings.IgnoreManifest;
            return toolSettings;
        }
        #endregion
        #region NoRoute
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.NoRoute"/></em></p>
        ///   <p>Do not map a route to this app and remove routes from previous pushes of this app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetNoRoute(this CloudFoundryPushSettings toolSettings, bool? noRoute)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRoute = noRoute;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.NoRoute"/></em></p>
        ///   <p>Do not map a route to this app and remove routes from previous pushes of this app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetNoRoute(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRoute = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CloudFoundryPushSettings.NoRoute"/></em></p>
        ///   <p>Do not map a route to this app and remove routes from previous pushes of this app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings EnableNoRoute(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRoute = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CloudFoundryPushSettings.NoRoute"/></em></p>
        ///   <p>Do not map a route to this app and remove routes from previous pushes of this app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings DisableNoRoute(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRoute = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CloudFoundryPushSettings.NoRoute"/></em></p>
        ///   <p>Do not map a route to this app and remove routes from previous pushes of this app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ToggleNoRoute(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoRoute = !toolSettings.NoRoute;
            return toolSettings;
        }
        #endregion
        #region NoStart
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.NoStart"/></em></p>
        ///   <p>Do not start an app after pushing</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetNoStart(this CloudFoundryPushSettings toolSettings, bool? noStart)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoStart = noStart;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.NoStart"/></em></p>
        ///   <p>Do not start an app after pushing</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetNoStart(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoStart = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CloudFoundryPushSettings.NoStart"/></em></p>
        ///   <p>Do not start an app after pushing</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings EnableNoStart(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoStart = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CloudFoundryPushSettings.NoStart"/></em></p>
        ///   <p>Do not start an app after pushing</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings DisableNoStart(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoStart = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CloudFoundryPushSettings.NoStart"/></em></p>
        ///   <p>Do not start an app after pushing</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ToggleNoStart(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoStart = !toolSettings.NoStart;
            return toolSettings;
        }
        #endregion
        #region Path
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.Path"/></em></p>
        ///   <p>Path to app directory or to a zip file of the contents of the app directory</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetPath(this CloudFoundryPushSettings toolSettings, string path)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = path;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.Path"/></em></p>
        ///   <p>Path to app directory or to a zip file of the contents of the app directory</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetPath(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = null;
            return toolSettings;
        }
        #endregion
        #region RandomRoute
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.RandomRoute"/></em></p>
        ///   <p>Create a random route for this app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetRandomRoute(this CloudFoundryPushSettings toolSettings, bool? randomRoute)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomRoute = randomRoute;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.RandomRoute"/></em></p>
        ///   <p>Create a random route for this app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetRandomRoute(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomRoute = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CloudFoundryPushSettings.RandomRoute"/></em></p>
        ///   <p>Create a random route for this app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings EnableRandomRoute(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomRoute = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CloudFoundryPushSettings.RandomRoute"/></em></p>
        ///   <p>Create a random route for this app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings DisableRandomRoute(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomRoute = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CloudFoundryPushSettings.RandomRoute"/></em></p>
        ///   <p>Create a random route for this app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ToggleRandomRoute(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomRoute = !toolSettings.RandomRoute;
            return toolSettings;
        }
        #endregion
        #region RoutePath
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.RoutePath"/></em></p>
        ///   <p>Path for the route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetRoutePath(this CloudFoundryPushSettings toolSettings, string routePath)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RoutePath = routePath;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.RoutePath"/></em></p>
        ///   <p>Path for the route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetRoutePath(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RoutePath = null;
            return toolSettings;
        }
        #endregion
        #region Stack
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.Stack"/></em></p>
        ///   <p>Stack to use (a stack is a pre-built file system, including an operating system, that can run apps)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetStack(this CloudFoundryPushSettings toolSettings, Stack stack)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Stack = stack;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.Stack"/></em></p>
        ///   <p>Stack to use (a stack is a pre-built file system, including an operating system, that can run apps)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetStack(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Stack = null;
            return toolSettings;
        }
        #endregion
        #region VariablesFile
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.VariablesFile"/></em></p>
        ///   <p>Path to a variable substitution file for manifest; can specify multiple times</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetVariablesFile(this CloudFoundryPushSettings toolSettings, string variablesFile)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesFile = variablesFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.VariablesFile"/></em></p>
        ///   <p>Path to a variable substitution file for manifest; can specify multiple times</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetVariablesFile(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesFile = null;
            return toolSettings;
        }
        #endregion
        #region Variables
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.Variables"/> to a new dictionary</em></p>
        ///   <p>Variable key value pair for variable substitution in manifest</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetVariables(this CloudFoundryPushSettings toolSettings, IDictionary<string, string> variables)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal = variables.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CloudFoundryPushSettings.Variables"/></em></p>
        ///   <p>Variable key value pair for variable substitution in manifest</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ClearVariables(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="CloudFoundryPushSettings.Variables"/></em></p>
        ///   <p>Variable key value pair for variable substitution in manifest</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings AddVariable(this CloudFoundryPushSettings toolSettings, string variableKey, string variableValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Add(variableKey, variableValue);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="CloudFoundryPushSettings.Variables"/></em></p>
        ///   <p>Variable key value pair for variable substitution in manifest</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings RemoveVariable(this CloudFoundryPushSettings toolSettings, string variableKey)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal.Remove(variableKey);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="CloudFoundryPushSettings.Variables"/></em></p>
        ///   <p>Variable key value pair for variable substitution in manifest</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetVariable(this CloudFoundryPushSettings toolSettings, string variableKey, string variableValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.VariablesInternal[variableKey] = variableValue;
            return toolSettings;
        }
        #endregion
        #region StartupTimeout
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryPushSettings.StartupTimeout"/></em></p>
        ///   <p>Time (in seconds) allowed to elapse between starting up an app and the first healthy response from the app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings SetStartupTimeout(this CloudFoundryPushSettings toolSettings, int? startupTimeout)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupTimeout = startupTimeout;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryPushSettings.StartupTimeout"/></em></p>
        ///   <p>Time (in seconds) allowed to elapse between starting up an app and the first healthy response from the app</p>
        /// </summary>
        [Pure]
        public static CloudFoundryPushSettings ResetStartupTimeout(this CloudFoundryPushSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupTimeout = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryLoginSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryLoginSettingsExtensions
    {
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryLoginSettings.Username"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings SetUsername(this CloudFoundryLoginSettings toolSettings, string username)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryLoginSettings.Username"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings ResetUsername(this CloudFoundryLoginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryLoginSettings.Password"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings SetPassword(this CloudFoundryLoginSettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryLoginSettings.Password"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings ResetPassword(this CloudFoundryLoginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region ApiEndpoint
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryLoginSettings.ApiEndpoint"/></em></p>
        ///   <p>API endpoint (e.g. https://api.example.com)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings SetApiEndpoint(this CloudFoundryLoginSettings toolSettings, string apiEndpoint)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiEndpoint = apiEndpoint;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryLoginSettings.ApiEndpoint"/></em></p>
        ///   <p>API endpoint (e.g. https://api.example.com)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings ResetApiEndpoint(this CloudFoundryLoginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ApiEndpoint = null;
            return toolSettings;
        }
        #endregion
        #region Org
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryLoginSettings.Org"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings SetOrg(this CloudFoundryLoginSettings toolSettings, string org)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Org = org;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryLoginSettings.Org"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings ResetOrg(this CloudFoundryLoginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Org = null;
            return toolSettings;
        }
        #endregion
        #region Space
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryLoginSettings.Space"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings SetSpace(this CloudFoundryLoginSettings toolSettings, string space)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = space;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryLoginSettings.Space"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings ResetSpace(this CloudFoundryLoginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = null;
            return toolSettings;
        }
        #endregion
        #region SkipSslValidation
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryLoginSettings.SkipSslValidation"/></em></p>
        ///   <p>Skip verification of the API endpoint</p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings SetSkipSslValidation(this CloudFoundryLoginSettings toolSettings, bool? skipSslValidation)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSslValidation = skipSslValidation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryLoginSettings.SkipSslValidation"/></em></p>
        ///   <p>Skip verification of the API endpoint</p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings ResetSkipSslValidation(this CloudFoundryLoginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSslValidation = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CloudFoundryLoginSettings.SkipSslValidation"/></em></p>
        ///   <p>Skip verification of the API endpoint</p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings EnableSkipSslValidation(this CloudFoundryLoginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSslValidation = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CloudFoundryLoginSettings.SkipSslValidation"/></em></p>
        ///   <p>Skip verification of the API endpoint</p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings DisableSkipSslValidation(this CloudFoundryLoginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSslValidation = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CloudFoundryLoginSettings.SkipSslValidation"/></em></p>
        ///   <p>Skip verification of the API endpoint</p>
        /// </summary>
        [Pure]
        public static CloudFoundryLoginSettings ToggleSkipSslValidation(this CloudFoundryLoginSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSslValidation = !toolSettings.SkipSslValidation;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryAuthSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryAuthSettingsExtensions
    {
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryAuthSettings.Username"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryAuthSettings SetUsername(this CloudFoundryAuthSettings toolSettings, string username)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryAuthSettings.Username"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryAuthSettings ResetUsername(this CloudFoundryAuthSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Password
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryAuthSettings.Password"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryAuthSettings SetPassword(this CloudFoundryAuthSettings toolSettings, string password)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = password;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryAuthSettings.Password"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryAuthSettings ResetPassword(this CloudFoundryAuthSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Password = null;
            return toolSettings;
        }
        #endregion
        #region Origin
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryAuthSettings.Origin"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryAuthSettings SetOrigin(this CloudFoundryAuthSettings toolSettings, string origin)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Origin = origin;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryAuthSettings.Origin"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryAuthSettings ResetOrigin(this CloudFoundryAuthSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Origin = null;
            return toolSettings;
        }
        #endregion
        #region ClientCredentials
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryAuthSettings.ClientCredentials"/></em></p>
        ///   <p>Use (non-user) service account (also called client credentials)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryAuthSettings SetClientCredentials(this CloudFoundryAuthSettings toolSettings, bool? clientCredentials)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCredentials = clientCredentials;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryAuthSettings.ClientCredentials"/></em></p>
        ///   <p>Use (non-user) service account (also called client credentials)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryAuthSettings ResetClientCredentials(this CloudFoundryAuthSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCredentials = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CloudFoundryAuthSettings.ClientCredentials"/></em></p>
        ///   <p>Use (non-user) service account (also called client credentials)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryAuthSettings EnableClientCredentials(this CloudFoundryAuthSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCredentials = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CloudFoundryAuthSettings.ClientCredentials"/></em></p>
        ///   <p>Use (non-user) service account (also called client credentials)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryAuthSettings DisableClientCredentials(this CloudFoundryAuthSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCredentials = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CloudFoundryAuthSettings.ClientCredentials"/></em></p>
        ///   <p>Use (non-user) service account (also called client credentials)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryAuthSettings ToggleClientCredentials(this CloudFoundryAuthSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ClientCredentials = !toolSettings.ClientCredentials;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryScaleSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryScaleSettingsExtensions
    {
        #region Instances
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryScaleSettings.Instances"/></em></p>
        ///   <p>Number of instances</p>
        /// </summary>
        [Pure]
        public static CloudFoundryScaleSettings SetInstances(this CloudFoundryScaleSettings toolSettings, string instances)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Instances = instances;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryScaleSettings.Instances"/></em></p>
        ///   <p>Number of instances</p>
        /// </summary>
        [Pure]
        public static CloudFoundryScaleSettings ResetInstances(this CloudFoundryScaleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Instances = null;
            return toolSettings;
        }
        #endregion
        #region Disk
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryScaleSettings.Disk"/></em></p>
        ///   <p>Disk limit (e.g. 256M, 1024M, 1G)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryScaleSettings SetDisk(this CloudFoundryScaleSettings toolSettings, string disk)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Disk = disk;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryScaleSettings.Disk"/></em></p>
        ///   <p>Disk limit (e.g. 256M, 1024M, 1G)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryScaleSettings ResetDisk(this CloudFoundryScaleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Disk = null;
            return toolSettings;
        }
        #endregion
        #region Memory
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryScaleSettings.Memory"/></em></p>
        ///   <p>Memory limit (e.g. 256M, 1024M, 1G)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryScaleSettings SetMemory(this CloudFoundryScaleSettings toolSettings, string memory)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Memory = memory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryScaleSettings.Memory"/></em></p>
        ///   <p>Memory limit (e.g. 256M, 1024M, 1G)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryScaleSettings ResetMemory(this CloudFoundryScaleSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Memory = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundrySetEnvSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundrySetEnvSettingsExtensions
    {
        #region AppName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundrySetEnvSettings.AppName"/></em></p>
        ///   <p>App Name</p>
        /// </summary>
        [Pure]
        public static CloudFoundrySetEnvSettings SetAppName(this CloudFoundrySetEnvSettings toolSettings, string appName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = appName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundrySetEnvSettings.AppName"/></em></p>
        ///   <p>App Name</p>
        /// </summary>
        [Pure]
        public static CloudFoundrySetEnvSettings ResetAppName(this CloudFoundrySetEnvSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = null;
            return toolSettings;
        }
        #endregion
        #region EnvVarName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundrySetEnvSettings.EnvVarName"/></em></p>
        ///   <p>Name of the environmental variable</p>
        /// </summary>
        [Pure]
        public static CloudFoundrySetEnvSettings SetEnvVarName(this CloudFoundrySetEnvSettings toolSettings, string envVarName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnvVarName = envVarName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundrySetEnvSettings.EnvVarName"/></em></p>
        ///   <p>Name of the environmental variable</p>
        /// </summary>
        [Pure]
        public static CloudFoundrySetEnvSettings ResetEnvVarName(this CloudFoundrySetEnvSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnvVarName = null;
            return toolSettings;
        }
        #endregion
        #region EnvVarValue
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundrySetEnvSettings.EnvVarValue"/></em></p>
        ///   <p>Value of the environmental variable</p>
        /// </summary>
        [Pure]
        public static CloudFoundrySetEnvSettings SetEnvVarValue(this CloudFoundrySetEnvSettings toolSettings, string envVarValue)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnvVarValue = envVarValue;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundrySetEnvSettings.EnvVarValue"/></em></p>
        ///   <p>Value of the environmental variable</p>
        /// </summary>
        [Pure]
        public static CloudFoundrySetEnvSettings ResetEnvVarValue(this CloudFoundrySetEnvSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnvVarValue = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryCurlSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryCurlSettingsExtensions
    {
        #region Path
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCurlSettings.Path"/></em></p>
        ///   <p>CAPI Path to invoke (ex. /v2/info)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCurlSettings SetPath(this CloudFoundryCurlSettings toolSettings, string path)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = path;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCurlSettings.Path"/></em></p>
        ///   <p>CAPI Path to invoke (ex. /v2/info)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCurlSettings ResetPath(this CloudFoundryCurlSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = null;
            return toolSettings;
        }
        #endregion
        #region IncludeResponseHeaders
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCurlSettings.IncludeResponseHeaders"/></em></p>
        ///   <p>Include response headers in the output</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCurlSettings SetIncludeResponseHeaders(this CloudFoundryCurlSettings toolSettings, bool? includeResponseHeaders)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeResponseHeaders = includeResponseHeaders;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCurlSettings.IncludeResponseHeaders"/></em></p>
        ///   <p>Include response headers in the output</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCurlSettings ResetIncludeResponseHeaders(this CloudFoundryCurlSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeResponseHeaders = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CloudFoundryCurlSettings.IncludeResponseHeaders"/></em></p>
        ///   <p>Include response headers in the output</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCurlSettings EnableIncludeResponseHeaders(this CloudFoundryCurlSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeResponseHeaders = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CloudFoundryCurlSettings.IncludeResponseHeaders"/></em></p>
        ///   <p>Include response headers in the output</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCurlSettings DisableIncludeResponseHeaders(this CloudFoundryCurlSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeResponseHeaders = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CloudFoundryCurlSettings.IncludeResponseHeaders"/></em></p>
        ///   <p>Include response headers in the output</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCurlSettings ToggleIncludeResponseHeaders(this CloudFoundryCurlSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.IncludeResponseHeaders = !toolSettings.IncludeResponseHeaders;
            return toolSettings;
        }
        #endregion
        #region HttpMethod
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCurlSettings.HttpMethod"/></em></p>
        ///   <p>HTTP method (GET,POST,PUT,DELETE,etc). Default is GET</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCurlSettings SetHttpMethod(this CloudFoundryCurlSettings toolSettings, string httpMethod)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpMethod = httpMethod;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCurlSettings.HttpMethod"/></em></p>
        ///   <p>HTTP method (GET,POST,PUT,DELETE,etc). Default is GET</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCurlSettings ResetHttpMethod(this CloudFoundryCurlSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpMethod = null;
            return toolSettings;
        }
        #endregion
        #region HttpData
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCurlSettings.HttpData"/></em></p>
        ///   <p>HTTP method (GET,POST,PUT,DELETE,etc). Default is GET</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCurlSettings SetHttpData(this CloudFoundryCurlSettings toolSettings, string httpData)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpData = httpData;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCurlSettings.HttpData"/></em></p>
        ///   <p>HTTP method (GET,POST,PUT,DELETE,etc). Default is GET</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCurlSettings ResetHttpData(this CloudFoundryCurlSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.HttpData = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryApiSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryApiSettingsExtensions
    {
        #region Url
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryApiSettings.Url"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryApiSettings SetUrl(this CloudFoundryApiSettings toolSettings, string url)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = url;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryApiSettings.Url"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryApiSettings ResetUrl(this CloudFoundryApiSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Url = null;
            return toolSettings;
        }
        #endregion
        #region SkipSSLValidation
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryApiSettings.SkipSSLValidation"/></em></p>
        ///   <p>Skip verification of the API endpoint</p>
        /// </summary>
        [Pure]
        public static CloudFoundryApiSettings SetSkipSSLValidation(this CloudFoundryApiSettings toolSettings, bool? skipSSLValidation)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSSLValidation = skipSSLValidation;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryApiSettings.SkipSSLValidation"/></em></p>
        ///   <p>Skip verification of the API endpoint</p>
        /// </summary>
        [Pure]
        public static CloudFoundryApiSettings ResetSkipSSLValidation(this CloudFoundryApiSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSSLValidation = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CloudFoundryApiSettings.SkipSSLValidation"/></em></p>
        ///   <p>Skip verification of the API endpoint</p>
        /// </summary>
        [Pure]
        public static CloudFoundryApiSettings EnableSkipSSLValidation(this CloudFoundryApiSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSSLValidation = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CloudFoundryApiSettings.SkipSSLValidation"/></em></p>
        ///   <p>Skip verification of the API endpoint</p>
        /// </summary>
        [Pure]
        public static CloudFoundryApiSettings DisableSkipSSLValidation(this CloudFoundryApiSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSSLValidation = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CloudFoundryApiSettings.SkipSSLValidation"/></em></p>
        ///   <p>Skip verification of the API endpoint</p>
        /// </summary>
        [Pure]
        public static CloudFoundryApiSettings ToggleSkipSSLValidation(this CloudFoundryApiSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SkipSSLValidation = !toolSettings.SkipSSLValidation;
            return toolSettings;
        }
        #endregion
        #region Unset
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryApiSettings.Unset"/></em></p>
        ///   <p>Remove all api endpoint targeting</p>
        /// </summary>
        [Pure]
        public static CloudFoundryApiSettings SetUnset(this CloudFoundryApiSettings toolSettings, bool? unset)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Unset = unset;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryApiSettings.Unset"/></em></p>
        ///   <p>Remove all api endpoint targeting</p>
        /// </summary>
        [Pure]
        public static CloudFoundryApiSettings ResetUnset(this CloudFoundryApiSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Unset = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CloudFoundryApiSettings.Unset"/></em></p>
        ///   <p>Remove all api endpoint targeting</p>
        /// </summary>
        [Pure]
        public static CloudFoundryApiSettings EnableUnset(this CloudFoundryApiSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Unset = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CloudFoundryApiSettings.Unset"/></em></p>
        ///   <p>Remove all api endpoint targeting</p>
        /// </summary>
        [Pure]
        public static CloudFoundryApiSettings DisableUnset(this CloudFoundryApiSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Unset = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CloudFoundryApiSettings.Unset"/></em></p>
        ///   <p>Remove all api endpoint targeting</p>
        /// </summary>
        [Pure]
        public static CloudFoundryApiSettings ToggleUnset(this CloudFoundryApiSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Unset = !toolSettings.Unset;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryCreateUserProvidedServiceSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryCreateUserProvidedServiceSettingsExtensions
    {
        #region ServiceInstanceName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateUserProvidedServiceSettings.ServiceInstanceName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateUserProvidedServiceSettings SetServiceInstanceName(this CloudFoundryCreateUserProvidedServiceSettings toolSettings, string serviceInstanceName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceInstanceName = serviceInstanceName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateUserProvidedServiceSettings.ServiceInstanceName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateUserProvidedServiceSettings ResetServiceInstanceName(this CloudFoundryCreateUserProvidedServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceInstanceName = null;
            return toolSettings;
        }
        #endregion
        #region RouteUrl
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateUserProvidedServiceSettings.RouteUrl"/></em></p>
        ///   <p>URL to which requests for bound routes will be forwarded. Scheme for this URL must be https</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateUserProvidedServiceSettings SetRouteUrl(this CloudFoundryCreateUserProvidedServiceSettings toolSettings, string routeUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RouteUrl = routeUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateUserProvidedServiceSettings.RouteUrl"/></em></p>
        ///   <p>URL to which requests for bound routes will be forwarded. Scheme for this URL must be https</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateUserProvidedServiceSettings ResetRouteUrl(this CloudFoundryCreateUserProvidedServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RouteUrl = null;
            return toolSettings;
        }
        #endregion
        #region LogUrl
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateUserProvidedServiceSettings.LogUrl"/></em></p>
        ///   <p>URL to which logs for bound applications will be streamed</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateUserProvidedServiceSettings SetLogUrl(this CloudFoundryCreateUserProvidedServiceSettings toolSettings, string logUrl)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogUrl = logUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateUserProvidedServiceSettings.LogUrl"/></em></p>
        ///   <p>URL to which logs for bound applications will be streamed</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateUserProvidedServiceSettings ResetLogUrl(this CloudFoundryCreateUserProvidedServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogUrl = null;
            return toolSettings;
        }
        #endregion
        #region Tags
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateUserProvidedServiceSettings.Tags"/></em></p>
        ///   <p>Comma separated list of tags to assign to service. ex. 'db, relational'</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateUserProvidedServiceSettings SetTags(this CloudFoundryCreateUserProvidedServiceSettings toolSettings, string tags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tags = tags;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateUserProvidedServiceSettings.Tags"/></em></p>
        ///   <p>Comma separated list of tags to assign to service. ex. 'db, relational'</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateUserProvidedServiceSettings ResetTags(this CloudFoundryCreateUserProvidedServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Tags = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryStartSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryStartSettingsExtensions
    {
        #region AppName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryStartSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryStartSettings SetAppName(this CloudFoundryStartSettings toolSettings, string appName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = appName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryStartSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryStartSettings ResetAppName(this CloudFoundryStartSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryStopSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryStopSettingsExtensions
    {
        #region AppName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryStopSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryStopSettings SetAppName(this CloudFoundryStopSettings toolSettings, string appName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = appName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryStopSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryStopSettings ResetAppName(this CloudFoundryStopSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryRestartSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryRestartSettingsExtensions
    {
        #region AppName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryRestartSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryRestartSettings SetAppName(this CloudFoundryRestartSettings toolSettings, string appName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = appName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryRestartSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryRestartSettings ResetAppName(this CloudFoundryRestartSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryRestageSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryRestageSettingsExtensions
    {
        #region AppName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryRestageSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryRestageSettings SetAppName(this CloudFoundryRestageSettings toolSettings, string appName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = appName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryRestageSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryRestageSettings ResetAppName(this CloudFoundryRestageSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryDeleteApplicationSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryDeleteApplicationSettingsExtensions
    {
        #region AppName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryDeleteApplicationSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteApplicationSettings SetAppName(this CloudFoundryDeleteApplicationSettings toolSettings, string appName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = appName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryDeleteApplicationSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteApplicationSettings ResetAppName(this CloudFoundryDeleteApplicationSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = null;
            return toolSettings;
        }
        #endregion
        #region DeleteRoutes
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryDeleteApplicationSettings.DeleteRoutes"/></em></p>
        ///   <p>Also delete any mapped routes</p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteApplicationSettings SetDeleteRoutes(this CloudFoundryDeleteApplicationSettings toolSettings, bool? deleteRoutes)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeleteRoutes = deleteRoutes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryDeleteApplicationSettings.DeleteRoutes"/></em></p>
        ///   <p>Also delete any mapped routes</p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteApplicationSettings ResetDeleteRoutes(this CloudFoundryDeleteApplicationSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeleteRoutes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CloudFoundryDeleteApplicationSettings.DeleteRoutes"/></em></p>
        ///   <p>Also delete any mapped routes</p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteApplicationSettings EnableDeleteRoutes(this CloudFoundryDeleteApplicationSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeleteRoutes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CloudFoundryDeleteApplicationSettings.DeleteRoutes"/></em></p>
        ///   <p>Also delete any mapped routes</p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteApplicationSettings DisableDeleteRoutes(this CloudFoundryDeleteApplicationSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeleteRoutes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CloudFoundryDeleteApplicationSettings.DeleteRoutes"/></em></p>
        ///   <p>Also delete any mapped routes</p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteApplicationSettings ToggleDeleteRoutes(this CloudFoundryDeleteApplicationSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DeleteRoutes = !toolSettings.DeleteRoutes;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryCreateServiceSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryCreateServiceSettingsExtensions
    {
        #region Service
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateServiceSettings.Service"/></em></p>
        ///   <p>Service type</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings SetService(this CloudFoundryCreateServiceSettings toolSettings, string service)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = service;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateServiceSettings.Service"/></em></p>
        ///   <p>Service type</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings ResetService(this CloudFoundryCreateServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Service = null;
            return toolSettings;
        }
        #endregion
        #region Plan
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateServiceSettings.Plan"/></em></p>
        ///   <p>Service plan</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings SetPlan(this CloudFoundryCreateServiceSettings toolSettings, string plan)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Plan = plan;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateServiceSettings.Plan"/></em></p>
        ///   <p>Service plan</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings ResetPlan(this CloudFoundryCreateServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Plan = null;
            return toolSettings;
        }
        #endregion
        #region InstanceName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateServiceSettings.InstanceName"/></em></p>
        ///   <p>Instance name</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings SetInstanceName(this CloudFoundryCreateServiceSettings toolSettings, string instanceName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InstanceName = instanceName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateServiceSettings.InstanceName"/></em></p>
        ///   <p>Instance name</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings ResetInstanceName(this CloudFoundryCreateServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InstanceName = null;
            return toolSettings;
        }
        #endregion
        #region ConfigurationParameters
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateServiceSettings.ConfigurationParameters"/></em></p>
        ///   <p>Valid JSON object containing service-specific configuration parameters, provided either in-line or in a file</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings SetConfigurationParameters(this CloudFoundryCreateServiceSettings toolSettings, string configurationParameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationParameters = configurationParameters;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateServiceSettings.ConfigurationParameters"/></em></p>
        ///   <p>Valid JSON object containing service-specific configuration parameters, provided either in-line or in a file</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings ResetConfigurationParameters(this CloudFoundryCreateServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationParameters = null;
            return toolSettings;
        }
        #endregion
        #region Tags
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateServiceSettings.Tags"/> to a new list</em></p>
        ///   <p>User provided tags</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings SetTags(this CloudFoundryCreateServiceSettings toolSettings, params string[] tags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagsInternal = tags.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateServiceSettings.Tags"/> to a new list</em></p>
        ///   <p>User provided tags</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings SetTags(this CloudFoundryCreateServiceSettings toolSettings, IEnumerable<string> tags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagsInternal = tags.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CloudFoundryCreateServiceSettings.Tags"/></em></p>
        ///   <p>User provided tags</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings AddTags(this CloudFoundryCreateServiceSettings toolSettings, params string[] tags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagsInternal.AddRange(tags);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="CloudFoundryCreateServiceSettings.Tags"/></em></p>
        ///   <p>User provided tags</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings AddTags(this CloudFoundryCreateServiceSettings toolSettings, IEnumerable<string> tags)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagsInternal.AddRange(tags);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="CloudFoundryCreateServiceSettings.Tags"/></em></p>
        ///   <p>User provided tags</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings ClearTags(this CloudFoundryCreateServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TagsInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CloudFoundryCreateServiceSettings.Tags"/></em></p>
        ///   <p>User provided tags</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings RemoveTags(this CloudFoundryCreateServiceSettings toolSettings, params string[] tags)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(tags);
            toolSettings.TagsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="CloudFoundryCreateServiceSettings.Tags"/></em></p>
        ///   <p>User provided tags</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateServiceSettings RemoveTags(this CloudFoundryCreateServiceSettings toolSettings, IEnumerable<string> tags)
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(tags);
            toolSettings.TagsInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryDeleteServiceSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryDeleteServiceSettingsExtensions
    {
        #region ServiceInstance
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryDeleteServiceSettings.ServiceInstance"/></em></p>
        ///   <p>Service Instance</p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteServiceSettings SetServiceInstance(this CloudFoundryDeleteServiceSettings toolSettings, string serviceInstance)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceInstance = serviceInstance;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryDeleteServiceSettings.ServiceInstance"/></em></p>
        ///   <p>Service Instance</p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteServiceSettings ResetServiceInstance(this CloudFoundryDeleteServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceInstance = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryGetServiceInfoSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryGetServiceInfoSettingsExtensions
    {
        #region ServiceInstance
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryGetServiceInfoSettings.ServiceInstance"/></em></p>
        ///   <p>Service Instance</p>
        /// </summary>
        [Pure]
        public static CloudFoundryGetServiceInfoSettings SetServiceInstance(this CloudFoundryGetServiceInfoSettings toolSettings, string serviceInstance)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceInstance = serviceInstance;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryGetServiceInfoSettings.ServiceInstance"/></em></p>
        ///   <p>Service Instance</p>
        /// </summary>
        [Pure]
        public static CloudFoundryGetServiceInfoSettings ResetServiceInstance(this CloudFoundryGetServiceInfoSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceInstance = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryBindServiceSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryBindServiceSettingsExtensions
    {
        #region AppName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryBindServiceSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryBindServiceSettings SetAppName(this CloudFoundryBindServiceSettings toolSettings, string appName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = appName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryBindServiceSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryBindServiceSettings ResetAppName(this CloudFoundryBindServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = null;
            return toolSettings;
        }
        #endregion
        #region ServiceInstance
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryBindServiceSettings.ServiceInstance"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryBindServiceSettings SetServiceInstance(this CloudFoundryBindServiceSettings toolSettings, string serviceInstance)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceInstance = serviceInstance;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryBindServiceSettings.ServiceInstance"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryBindServiceSettings ResetServiceInstance(this CloudFoundryBindServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceInstance = null;
            return toolSettings;
        }
        #endregion
        #region BindingName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryBindServiceSettings.BindingName"/></em></p>
        ///   <p>Name to expose service instance to app process with (Default: service instance name)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryBindServiceSettings SetBindingName(this CloudFoundryBindServiceSettings toolSettings, string bindingName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BindingName = bindingName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryBindServiceSettings.BindingName"/></em></p>
        ///   <p>Name to expose service instance to app process with (Default: service instance name)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryBindServiceSettings ResetBindingName(this CloudFoundryBindServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BindingName = null;
            return toolSettings;
        }
        #endregion
        #region ConfigurationParameters
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryBindServiceSettings.ConfigurationParameters"/></em></p>
        ///   <p>Valid JSON object containing service-specific configuration parameters, provided either in-line or in a file</p>
        /// </summary>
        [Pure]
        public static CloudFoundryBindServiceSettings SetConfigurationParameters(this CloudFoundryBindServiceSettings toolSettings, string configurationParameters)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationParameters = configurationParameters;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryBindServiceSettings.ConfigurationParameters"/></em></p>
        ///   <p>Valid JSON object containing service-specific configuration parameters, provided either in-line or in a file</p>
        /// </summary>
        [Pure]
        public static CloudFoundryBindServiceSettings ResetConfigurationParameters(this CloudFoundryBindServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ConfigurationParameters = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryUnbindServiceSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryUnbindServiceSettingsExtensions
    {
        #region AppName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryUnbindServiceSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnbindServiceSettings SetAppName(this CloudFoundryUnbindServiceSettings toolSettings, string appName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = appName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryUnbindServiceSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnbindServiceSettings ResetAppName(this CloudFoundryUnbindServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = null;
            return toolSettings;
        }
        #endregion
        #region ServiceInstance
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryUnbindServiceSettings.ServiceInstance"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnbindServiceSettings SetServiceInstance(this CloudFoundryUnbindServiceSettings toolSettings, string serviceInstance)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceInstance = serviceInstance;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryUnbindServiceSettings.ServiceInstance"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnbindServiceSettings ResetServiceInstance(this CloudFoundryUnbindServiceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ServiceInstance = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryUnsetEnvSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryUnsetEnvSettingsExtensions
    {
        #region AppName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryUnsetEnvSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnsetEnvSettings SetAppName(this CloudFoundryUnsetEnvSettings toolSettings, string appName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = appName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryUnsetEnvSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnsetEnvSettings ResetAppName(this CloudFoundryUnsetEnvSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = null;
            return toolSettings;
        }
        #endregion
        #region EnvironmentalVariableName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryUnsetEnvSettings.EnvironmentalVariableName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnsetEnvSettings SetEnvironmentalVariableName(this CloudFoundryUnsetEnvSettings toolSettings, string environmentalVariableName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnvironmentalVariableName = environmentalVariableName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryUnsetEnvSettings.EnvironmentalVariableName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnsetEnvSettings ResetEnvironmentalVariableName(this CloudFoundryUnsetEnvSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.EnvironmentalVariableName = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryCreateRouteSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryCreateRouteSettingsExtensions
    {
        #region Space
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateRouteSettings.Space"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings SetSpace(this CloudFoundryCreateRouteSettings toolSettings, string space)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = space;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateRouteSettings.Space"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings ResetSpace(this CloudFoundryCreateRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = null;
            return toolSettings;
        }
        #endregion
        #region Domain
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateRouteSettings.Domain"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings SetDomain(this CloudFoundryCreateRouteSettings toolSettings, string domain)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = domain;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateRouteSettings.Domain"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings ResetDomain(this CloudFoundryCreateRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = null;
            return toolSettings;
        }
        #endregion
        #region Hostname
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateRouteSettings.Hostname"/></em></p>
        ///   <p>Hostname for the HTTP route (required for shared domains)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings SetHostname(this CloudFoundryCreateRouteSettings toolSettings, string hostname)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Hostname = hostname;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateRouteSettings.Hostname"/></em></p>
        ///   <p>Hostname for the HTTP route (required for shared domains)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings ResetHostname(this CloudFoundryCreateRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Hostname = null;
            return toolSettings;
        }
        #endregion
        #region Path
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateRouteSettings.Path"/></em></p>
        ///   <p>Path for the HTTP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings SetPath(this CloudFoundryCreateRouteSettings toolSettings, string path)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = path;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateRouteSettings.Path"/></em></p>
        ///   <p>Path for the HTTP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings ResetPath(this CloudFoundryCreateRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = null;
            return toolSettings;
        }
        #endregion
        #region Port
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateRouteSettings.Port"/></em></p>
        ///   <p>Port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings SetPort(this CloudFoundryCreateRouteSettings toolSettings, int? port)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = port;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateRouteSettings.Port"/></em></p>
        ///   <p>Port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings ResetPort(this CloudFoundryCreateRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = null;
            return toolSettings;
        }
        #endregion
        #region RandomPort
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateRouteSettings.RandomPort"/></em></p>
        ///   <p>Create a random port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings SetRandomPort(this CloudFoundryCreateRouteSettings toolSettings, bool? randomPort)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomPort = randomPort;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateRouteSettings.RandomPort"/></em></p>
        ///   <p>Create a random port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings ResetRandomPort(this CloudFoundryCreateRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomPort = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CloudFoundryCreateRouteSettings.RandomPort"/></em></p>
        ///   <p>Create a random port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings EnableRandomPort(this CloudFoundryCreateRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomPort = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CloudFoundryCreateRouteSettings.RandomPort"/></em></p>
        ///   <p>Create a random port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings DisableRandomPort(this CloudFoundryCreateRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomPort = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CloudFoundryCreateRouteSettings.RandomPort"/></em></p>
        ///   <p>Create a random port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateRouteSettings ToggleRandomPort(this CloudFoundryCreateRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomPort = !toolSettings.RandomPort;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryMapRouteSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryMapRouteSettingsExtensions
    {
        #region AppName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryMapRouteSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings SetAppName(this CloudFoundryMapRouteSettings toolSettings, string appName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = appName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryMapRouteSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings ResetAppName(this CloudFoundryMapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = null;
            return toolSettings;
        }
        #endregion
        #region Domain
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryMapRouteSettings.Domain"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings SetDomain(this CloudFoundryMapRouteSettings toolSettings, string domain)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = domain;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryMapRouteSettings.Domain"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings ResetDomain(this CloudFoundryMapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = null;
            return toolSettings;
        }
        #endregion
        #region Hostname
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryMapRouteSettings.Hostname"/></em></p>
        ///   <p>Hostname for the HTTP route (required for shared domains)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings SetHostname(this CloudFoundryMapRouteSettings toolSettings, string hostname)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Hostname = hostname;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryMapRouteSettings.Hostname"/></em></p>
        ///   <p>Hostname for the HTTP route (required for shared domains)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings ResetHostname(this CloudFoundryMapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Hostname = null;
            return toolSettings;
        }
        #endregion
        #region Path
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryMapRouteSettings.Path"/></em></p>
        ///   <p>Path for the HTTP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings SetPath(this CloudFoundryMapRouteSettings toolSettings, string path)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = path;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryMapRouteSettings.Path"/></em></p>
        ///   <p>Path for the HTTP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings ResetPath(this CloudFoundryMapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = null;
            return toolSettings;
        }
        #endregion
        #region Port
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryMapRouteSettings.Port"/></em></p>
        ///   <p>Port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings SetPort(this CloudFoundryMapRouteSettings toolSettings, int? port)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = port;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryMapRouteSettings.Port"/></em></p>
        ///   <p>Port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings ResetPort(this CloudFoundryMapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = null;
            return toolSettings;
        }
        #endregion
        #region RandomPort
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryMapRouteSettings.RandomPort"/></em></p>
        ///   <p>Create a random port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings SetRandomPort(this CloudFoundryMapRouteSettings toolSettings, bool? randomPort)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomPort = randomPort;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryMapRouteSettings.RandomPort"/></em></p>
        ///   <p>Create a random port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings ResetRandomPort(this CloudFoundryMapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomPort = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CloudFoundryMapRouteSettings.RandomPort"/></em></p>
        ///   <p>Create a random port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings EnableRandomPort(this CloudFoundryMapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomPort = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CloudFoundryMapRouteSettings.RandomPort"/></em></p>
        ///   <p>Create a random port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings DisableRandomPort(this CloudFoundryMapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomPort = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CloudFoundryMapRouteSettings.RandomPort"/></em></p>
        ///   <p>Create a random port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryMapRouteSettings ToggleRandomPort(this CloudFoundryMapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RandomPort = !toolSettings.RandomPort;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryUnmapRouteSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryUnmapRouteSettingsExtensions
    {
        #region AppName
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryUnmapRouteSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnmapRouteSettings SetAppName(this CloudFoundryUnmapRouteSettings toolSettings, string appName)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = appName;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryUnmapRouteSettings.AppName"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnmapRouteSettings ResetAppName(this CloudFoundryUnmapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AppName = null;
            return toolSettings;
        }
        #endregion
        #region Domain
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryUnmapRouteSettings.Domain"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnmapRouteSettings SetDomain(this CloudFoundryUnmapRouteSettings toolSettings, string domain)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = domain;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryUnmapRouteSettings.Domain"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnmapRouteSettings ResetDomain(this CloudFoundryUnmapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Domain = null;
            return toolSettings;
        }
        #endregion
        #region Hostname
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryUnmapRouteSettings.Hostname"/></em></p>
        ///   <p>Hostname for the HTTP route (required for shared domains)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnmapRouteSettings SetHostname(this CloudFoundryUnmapRouteSettings toolSettings, string hostname)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Hostname = hostname;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryUnmapRouteSettings.Hostname"/></em></p>
        ///   <p>Hostname for the HTTP route (required for shared domains)</p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnmapRouteSettings ResetHostname(this CloudFoundryUnmapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Hostname = null;
            return toolSettings;
        }
        #endregion
        #region Path
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryUnmapRouteSettings.Path"/></em></p>
        ///   <p>Path for the HTTP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnmapRouteSettings SetPath(this CloudFoundryUnmapRouteSettings toolSettings, string path)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = path;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryUnmapRouteSettings.Path"/></em></p>
        ///   <p>Path for the HTTP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnmapRouteSettings ResetPath(this CloudFoundryUnmapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Path = null;
            return toolSettings;
        }
        #endregion
        #region Port
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryUnmapRouteSettings.Port"/></em></p>
        ///   <p>Port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnmapRouteSettings SetPort(this CloudFoundryUnmapRouteSettings toolSettings, int? port)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = port;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryUnmapRouteSettings.Port"/></em></p>
        ///   <p>Port for the TCP route</p>
        /// </summary>
        [Pure]
        public static CloudFoundryUnmapRouteSettings ResetPort(this CloudFoundryUnmapRouteSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Port = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryCreateSpaceSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryCreateSpaceSettingsExtensions
    {
        #region Space
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateSpaceSettings.Space"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateSpaceSettings SetSpace(this CloudFoundryCreateSpaceSettings toolSettings, string space)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = space;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateSpaceSettings.Space"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateSpaceSettings ResetSpace(this CloudFoundryCreateSpaceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = null;
            return toolSettings;
        }
        #endregion
        #region Org
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateSpaceSettings.Org"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateSpaceSettings SetOrg(this CloudFoundryCreateSpaceSettings toolSettings, string org)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Org = org;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateSpaceSettings.Org"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateSpaceSettings ResetOrg(this CloudFoundryCreateSpaceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Org = null;
            return toolSettings;
        }
        #endregion
        #region Quota
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryCreateSpaceSettings.Quota"/></em></p>
        ///   <p>Quota to assign to the newly created space</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateSpaceSettings SetQuota(this CloudFoundryCreateSpaceSettings toolSettings, string quota)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quota = quota;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryCreateSpaceSettings.Quota"/></em></p>
        ///   <p>Quota to assign to the newly created space</p>
        /// </summary>
        [Pure]
        public static CloudFoundryCreateSpaceSettings ResetQuota(this CloudFoundryCreateSpaceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Quota = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryDeleteSpaceSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryDeleteSpaceSettingsExtensions
    {
        #region Space
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryDeleteSpaceSettings.Space"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteSpaceSettings SetSpace(this CloudFoundryDeleteSpaceSettings toolSettings, string space)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = space;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryDeleteSpaceSettings.Space"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteSpaceSettings ResetSpace(this CloudFoundryDeleteSpaceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = null;
            return toolSettings;
        }
        #endregion
        #region Org
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryDeleteSpaceSettings.Org"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteSpaceSettings SetOrg(this CloudFoundryDeleteSpaceSettings toolSettings, string org)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Org = org;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryDeleteSpaceSettings.Org"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryDeleteSpaceSettings ResetOrg(this CloudFoundryDeleteSpaceSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Org = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region CloudFoundryTargetSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CloudFoundryTargetSettingsExtensions
    {
        #region Space
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryTargetSettings.Space"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryTargetSettings SetSpace(this CloudFoundryTargetSettings toolSettings, string space)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = space;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryTargetSettings.Space"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryTargetSettings ResetSpace(this CloudFoundryTargetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Space = null;
            return toolSettings;
        }
        #endregion
        #region Org
        /// <summary>
        ///   <p><em>Sets <see cref="CloudFoundryTargetSettings.Org"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryTargetSettings SetOrg(this CloudFoundryTargetSettings toolSettings, string org)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Org = org;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CloudFoundryTargetSettings.Org"/></em></p>
        /// </summary>
        [Pure]
        public static CloudFoundryTargetSettings ResetOrg(this CloudFoundryTargetSettings toolSettings)
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Org = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region HealthCheckType
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<HealthCheckType>))]
    public partial class HealthCheckType : Enumeration
    {
        public static HealthCheckType None = (HealthCheckType) "None";
        public static HealthCheckType Process = (HealthCheckType) "Process";
        public static HealthCheckType Port = (HealthCheckType) "Port";
        public static HealthCheckType Http = (HealthCheckType) "Http";
        public static explicit operator HealthCheckType(string value)
        {
            return new HealthCheckType { Value = value };
        }
    }
    #endregion
    #region Stack
    /// <summary>
    ///   Used within <see cref="CloudFoundryTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<Stack>))]
    public partial class Stack : Enumeration
    {
        public static Stack cflinuxfs2 = (Stack) "cflinuxfs2";
        public static Stack cflinuxfs3 = (Stack) "cflinuxfs3";
        public static Stack windows = (Stack) "windows";
        public static Stack windows2012R2 = (Stack) "windows2012R2";
        public static Stack windows2016 = (Stack) "windows2016";
        public static explicit operator Stack(string value)
        {
            return new Stack { Value = value };
        }
    }
    #endregion
}
