// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/SignClient/SignClient.json

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

namespace Nuke.Common.Tools.SignClient
{
    /// <summary>
    ///   <p>Code Signing client for Authenticode, NuGet, VSIX, and more</p>
    ///   <p>For more details, visit the <a href="https://discoverdot.net/projects/sign-service">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(SignClientPackageId)]
    public partial class SignClientTasks
        : IRequireNuGetPackage
    {
        public const string SignClientPackageId = "SignClient";
        /// <summary>
        ///   Path to the SignClient executable.
        /// </summary>
        public static string SignClientPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("SIGNCLIENT_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("SignClient", "SignClient.exe");
        public static Action<OutputType, string> SignClientLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Code Signing client for Authenticode, NuGet, VSIX, and more</p>
        ///   <p>For more details, visit the <a href="https://discoverdot.net/projects/sign-service">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> SignClient(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(SignClientPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? SignClientLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Code Signing client for Authenticode, NuGet, VSIX, and more</p>
        ///   <p>For more details, visit the <a href="https://discoverdot.net/projects/sign-service">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--baseDirectory</c> via <see cref="SignClientSignSettings.BaseDirectory"/></li>
        ///     <li><c>--config</c> via <see cref="SignClientSignSettings.Config"/></li>
        ///     <li><c>--description</c> via <see cref="SignClientSignSettings.Description"/></li>
        ///     <li><c>--descriptionUrl</c> via <see cref="SignClientSignSettings.DescriptionUrl"/></li>
        ///     <li><c>--fileList</c> via <see cref="SignClientSignSettings.FileList"/></li>
        ///     <li><c>--input</c> via <see cref="SignClientSignSettings.Input"/></li>
        ///     <li><c>--maxConcurrency</c> via <see cref="SignClientSignSettings.MaxConcurrency"/></li>
        ///     <li><c>--name</c> via <see cref="SignClientSignSettings.Name"/></li>
        ///     <li><c>--output</c> via <see cref="SignClientSignSettings.Output"/></li>
        ///     <li><c>--secret</c> via <see cref="SignClientSignSettings.Secret"/></li>
        ///     <li><c>--user</c> via <see cref="SignClientSignSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> SignClientSign(SignClientSignSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new SignClientSignSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>Code Signing client for Authenticode, NuGet, VSIX, and more</p>
        ///   <p>For more details, visit the <a href="https://discoverdot.net/projects/sign-service">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--baseDirectory</c> via <see cref="SignClientSignSettings.BaseDirectory"/></li>
        ///     <li><c>--config</c> via <see cref="SignClientSignSettings.Config"/></li>
        ///     <li><c>--description</c> via <see cref="SignClientSignSettings.Description"/></li>
        ///     <li><c>--descriptionUrl</c> via <see cref="SignClientSignSettings.DescriptionUrl"/></li>
        ///     <li><c>--fileList</c> via <see cref="SignClientSignSettings.FileList"/></li>
        ///     <li><c>--input</c> via <see cref="SignClientSignSettings.Input"/></li>
        ///     <li><c>--maxConcurrency</c> via <see cref="SignClientSignSettings.MaxConcurrency"/></li>
        ///     <li><c>--name</c> via <see cref="SignClientSignSettings.Name"/></li>
        ///     <li><c>--output</c> via <see cref="SignClientSignSettings.Output"/></li>
        ///     <li><c>--secret</c> via <see cref="SignClientSignSettings.Secret"/></li>
        ///     <li><c>--user</c> via <see cref="SignClientSignSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> SignClientSign(Configure<SignClientSignSettings> configurator)
        {
            return SignClientSign(configurator(new SignClientSignSettings()));
        }
        /// <summary>
        ///   <p>Code Signing client for Authenticode, NuGet, VSIX, and more</p>
        ///   <p>For more details, visit the <a href="https://discoverdot.net/projects/sign-service">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>--baseDirectory</c> via <see cref="SignClientSignSettings.BaseDirectory"/></li>
        ///     <li><c>--config</c> via <see cref="SignClientSignSettings.Config"/></li>
        ///     <li><c>--description</c> via <see cref="SignClientSignSettings.Description"/></li>
        ///     <li><c>--descriptionUrl</c> via <see cref="SignClientSignSettings.DescriptionUrl"/></li>
        ///     <li><c>--fileList</c> via <see cref="SignClientSignSettings.FileList"/></li>
        ///     <li><c>--input</c> via <see cref="SignClientSignSettings.Input"/></li>
        ///     <li><c>--maxConcurrency</c> via <see cref="SignClientSignSettings.MaxConcurrency"/></li>
        ///     <li><c>--name</c> via <see cref="SignClientSignSettings.Name"/></li>
        ///     <li><c>--output</c> via <see cref="SignClientSignSettings.Output"/></li>
        ///     <li><c>--secret</c> via <see cref="SignClientSignSettings.Secret"/></li>
        ///     <li><c>--user</c> via <see cref="SignClientSignSettings.Username"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(SignClientSignSettings Settings, IReadOnlyCollection<Output> Output)> SignClientSign(CombinatorialConfigure<SignClientSignSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(SignClientSign, SignClientLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region SignClientSignSettings
    /// <summary>
    ///   Used within <see cref="SignClientTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class SignClientSignSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the SignClient executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? SignClientTasks.SignClientPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? SignClientTasks.SignClientLogger;
        /// <summary>
        ///   Path to config json file
        /// </summary>
        public virtual string Config { get; internal set; }
        /// <summary>
        ///   Path to input file
        /// </summary>
        public virtual string Input { get; internal set; }
        /// <summary>
        ///   Base directory for files to override the working directory
        /// </summary>
        public virtual string BaseDirectory { get; internal set; }
        /// <summary>
        ///   Path to output file. May be same as input to overwrite
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   Path to file containing paths of files to sign within an archive
        /// </summary>
        public virtual string FileList { get; internal set; }
        /// <summary>
        ///   Client Secret
        /// </summary>
        public virtual string Secret { get; internal set; }
        /// <summary>
        ///   Username
        /// </summary>
        public virtual string Username { get; internal set; }
        /// <summary>
        ///   Name of project for tracking
        /// </summary>
        public virtual string Name { get; internal set; }
        /// <summary>
        ///   Description
        /// </summary>
        public virtual string Description { get; internal set; }
        /// <summary>
        ///   Description Url
        /// </summary>
        public virtual string DescriptionUrl { get; internal set; }
        /// <summary>
        ///   Maximum concurrency (default is 4)
        /// </summary>
        public virtual string MaxConcurrency { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("sign")
              .Add("--config {value}", Config)
              .Add("--input {value}", Input)
              .Add("--baseDirectory {value}", BaseDirectory)
              .Add("--output {value}", Output)
              .Add("--fileList {value}", FileList)
              .Add("--secret {value}", Secret, secret: true)
              .Add("--user {value}", Username)
              .Add("--name {value}", Name)
              .Add("--description {value}", Description)
              .Add("--descriptionUrl {value}", DescriptionUrl)
              .Add("--maxConcurrency {value}", MaxConcurrency);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region SignClientSignSettingsExtensions
    /// <summary>
    ///   Used within <see cref="SignClientTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class SignClientSignSettingsExtensions
    {
        #region Config
        /// <summary>
        ///   <p><em>Sets <see cref="SignClientSignSettings.Config"/></em></p>
        ///   <p>Path to config json file</p>
        /// </summary>
        [Pure]
        public static T SetConfig<T>(this T toolSettings, string config) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Config = config;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignClientSignSettings.Config"/></em></p>
        ///   <p>Path to config json file</p>
        /// </summary>
        [Pure]
        public static T ResetConfig<T>(this T toolSettings) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Config = null;
            return toolSettings;
        }
        #endregion
        #region Input
        /// <summary>
        ///   <p><em>Sets <see cref="SignClientSignSettings.Input"/></em></p>
        ///   <p>Path to input file</p>
        /// </summary>
        [Pure]
        public static T SetInput<T>(this T toolSettings, string input) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = input;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignClientSignSettings.Input"/></em></p>
        ///   <p>Path to input file</p>
        /// </summary>
        [Pure]
        public static T ResetInput<T>(this T toolSettings) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Input = null;
            return toolSettings;
        }
        #endregion
        #region BaseDirectory
        /// <summary>
        ///   <p><em>Sets <see cref="SignClientSignSettings.BaseDirectory"/></em></p>
        ///   <p>Base directory for files to override the working directory</p>
        /// </summary>
        [Pure]
        public static T SetBaseDirectory<T>(this T toolSettings, string baseDirectory) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseDirectory = baseDirectory;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignClientSignSettings.BaseDirectory"/></em></p>
        ///   <p>Base directory for files to override the working directory</p>
        /// </summary>
        [Pure]
        public static T ResetBaseDirectory<T>(this T toolSettings) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.BaseDirectory = null;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="SignClientSignSettings.Output"/></em></p>
        ///   <p>Path to output file. May be same as input to overwrite</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, string output) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignClientSignSettings.Output"/></em></p>
        ///   <p>Path to output file. May be same as input to overwrite</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region FileList
        /// <summary>
        ///   <p><em>Sets <see cref="SignClientSignSettings.FileList"/></em></p>
        ///   <p>Path to file containing paths of files to sign within an archive</p>
        /// </summary>
        [Pure]
        public static T SetFileList<T>(this T toolSettings, string fileList) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileList = fileList;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignClientSignSettings.FileList"/></em></p>
        ///   <p>Path to file containing paths of files to sign within an archive</p>
        /// </summary>
        [Pure]
        public static T ResetFileList<T>(this T toolSettings) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.FileList = null;
            return toolSettings;
        }
        #endregion
        #region Secret
        /// <summary>
        ///   <p><em>Sets <see cref="SignClientSignSettings.Secret"/></em></p>
        ///   <p>Client Secret</p>
        /// </summary>
        [Pure]
        public static T SetSecret<T>(this T toolSettings, [Secret] string secret) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Secret = secret;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignClientSignSettings.Secret"/></em></p>
        ///   <p>Client Secret</p>
        /// </summary>
        [Pure]
        public static T ResetSecret<T>(this T toolSettings) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Secret = null;
            return toolSettings;
        }
        #endregion
        #region Username
        /// <summary>
        ///   <p><em>Sets <see cref="SignClientSignSettings.Username"/></em></p>
        ///   <p>Username</p>
        /// </summary>
        [Pure]
        public static T SetUsername<T>(this T toolSettings, string username) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = username;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignClientSignSettings.Username"/></em></p>
        ///   <p>Username</p>
        /// </summary>
        [Pure]
        public static T ResetUsername<T>(this T toolSettings) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Username = null;
            return toolSettings;
        }
        #endregion
        #region Name
        /// <summary>
        ///   <p><em>Sets <see cref="SignClientSignSettings.Name"/></em></p>
        ///   <p>Name of project for tracking</p>
        /// </summary>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignClientSignSettings.Name"/></em></p>
        ///   <p>Name of project for tracking</p>
        /// </summary>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }
        #endregion
        #region Description
        /// <summary>
        ///   <p><em>Sets <see cref="SignClientSignSettings.Description"/></em></p>
        ///   <p>Description</p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = description;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignClientSignSettings.Description"/></em></p>
        ///   <p>Description</p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Description = null;
            return toolSettings;
        }
        #endregion
        #region DescriptionUrl
        /// <summary>
        ///   <p><em>Sets <see cref="SignClientSignSettings.DescriptionUrl"/></em></p>
        ///   <p>Description Url</p>
        /// </summary>
        [Pure]
        public static T SetDescriptionUrl<T>(this T toolSettings, string descriptionUrl) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DescriptionUrl = descriptionUrl;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignClientSignSettings.DescriptionUrl"/></em></p>
        ///   <p>Description Url</p>
        /// </summary>
        [Pure]
        public static T ResetDescriptionUrl<T>(this T toolSettings) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DescriptionUrl = null;
            return toolSettings;
        }
        #endregion
        #region MaxConcurrency
        /// <summary>
        ///   <p><em>Sets <see cref="SignClientSignSettings.MaxConcurrency"/></em></p>
        ///   <p>Maximum concurrency (default is 4)</p>
        /// </summary>
        [Pure]
        public static T SetMaxConcurrency<T>(this T toolSettings, string maxConcurrency) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxConcurrency = maxConcurrency;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="SignClientSignSettings.MaxConcurrency"/></em></p>
        ///   <p>Maximum concurrency (default is 4)</p>
        /// </summary>
        [Pure]
        public static T ResetMaxConcurrency<T>(this T toolSettings) where T : SignClientSignSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.MaxConcurrency = null;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
