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

namespace Nuke.Common.Tools.SignClient;

/// <summary><p>Code Signing client for Authenticode, NuGet, VSIX, and more</p><p>For more details, visit the <a href="https://discoverdot.net/projects/sign-service">official website</a>.</p></summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[NuGetPackageRequirement(PackageId)]
[NuGetTool(Id = PackageId, Executable = PackageExecutable)]
public partial class SignClientTasks : ToolTasks, IRequireNuGetPackage
{
    public static string SignClientPath => new SignClientTasks().GetToolPath();
    public const string PackageId = "SignClient";
    public const string PackageExecutable = "SignClient.exe";
    /// <summary><p>Code Signing client for Authenticode, NuGet, VSIX, and more</p><p>For more details, visit the <a href="https://discoverdot.net/projects/sign-service">official website</a>.</p></summary>
    public static IReadOnlyCollection<Output> SignClient(ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> logger = null, Func<IProcess, object> exitHandler = null) => new SignClientTasks().Run(arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, logger, exitHandler);
    /// <summary><p>Code Signing client for Authenticode, NuGet, VSIX, and more</p><p>For more details, visit the <a href="https://discoverdot.net/projects/sign-service">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--baseDirectory</c> via <see cref="SignClientSignSettings.BaseDirectory"/></li><li><c>--config</c> via <see cref="SignClientSignSettings.Config"/></li><li><c>--description</c> via <see cref="SignClientSignSettings.Description"/></li><li><c>--descriptionUrl</c> via <see cref="SignClientSignSettings.DescriptionUrl"/></li><li><c>--fileList</c> via <see cref="SignClientSignSettings.FileList"/></li><li><c>--input</c> via <see cref="SignClientSignSettings.Input"/></li><li><c>--maxConcurrency</c> via <see cref="SignClientSignSettings.MaxConcurrency"/></li><li><c>--name</c> via <see cref="SignClientSignSettings.Name"/></li><li><c>--output</c> via <see cref="SignClientSignSettings.Output"/></li><li><c>--secret</c> via <see cref="SignClientSignSettings.Secret"/></li><li><c>--user</c> via <see cref="SignClientSignSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SignClientSign(SignClientSignSettings options = null) => new SignClientTasks().Run(options);
    /// <summary><p>Code Signing client for Authenticode, NuGet, VSIX, and more</p><p>For more details, visit the <a href="https://discoverdot.net/projects/sign-service">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--baseDirectory</c> via <see cref="SignClientSignSettings.BaseDirectory"/></li><li><c>--config</c> via <see cref="SignClientSignSettings.Config"/></li><li><c>--description</c> via <see cref="SignClientSignSettings.Description"/></li><li><c>--descriptionUrl</c> via <see cref="SignClientSignSettings.DescriptionUrl"/></li><li><c>--fileList</c> via <see cref="SignClientSignSettings.FileList"/></li><li><c>--input</c> via <see cref="SignClientSignSettings.Input"/></li><li><c>--maxConcurrency</c> via <see cref="SignClientSignSettings.MaxConcurrency"/></li><li><c>--name</c> via <see cref="SignClientSignSettings.Name"/></li><li><c>--output</c> via <see cref="SignClientSignSettings.Output"/></li><li><c>--secret</c> via <see cref="SignClientSignSettings.Secret"/></li><li><c>--user</c> via <see cref="SignClientSignSettings.Username"/></li></ul></remarks>
    public static IReadOnlyCollection<Output> SignClientSign(Configure<SignClientSignSettings> configurator) => new SignClientTasks().Run(configurator.Invoke(new SignClientSignSettings()));
    /// <summary><p>Code Signing client for Authenticode, NuGet, VSIX, and more</p><p>For more details, visit the <a href="https://discoverdot.net/projects/sign-service">official website</a>.</p></summary>
    /// <remarks><p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p><ul><li><c>--baseDirectory</c> via <see cref="SignClientSignSettings.BaseDirectory"/></li><li><c>--config</c> via <see cref="SignClientSignSettings.Config"/></li><li><c>--description</c> via <see cref="SignClientSignSettings.Description"/></li><li><c>--descriptionUrl</c> via <see cref="SignClientSignSettings.DescriptionUrl"/></li><li><c>--fileList</c> via <see cref="SignClientSignSettings.FileList"/></li><li><c>--input</c> via <see cref="SignClientSignSettings.Input"/></li><li><c>--maxConcurrency</c> via <see cref="SignClientSignSettings.MaxConcurrency"/></li><li><c>--name</c> via <see cref="SignClientSignSettings.Name"/></li><li><c>--output</c> via <see cref="SignClientSignSettings.Output"/></li><li><c>--secret</c> via <see cref="SignClientSignSettings.Secret"/></li><li><c>--user</c> via <see cref="SignClientSignSettings.Username"/></li></ul></remarks>
    public static IEnumerable<(SignClientSignSettings Settings, IReadOnlyCollection<Output> Output)> SignClientSign(CombinatorialConfigure<SignClientSignSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false) => configurator.Invoke(SignClientSign, degreeOfParallelism, completeOnFailure);
}
#region SignClientSignSettings
/// <summary>Used within <see cref="SignClientTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
[TypeConverter(typeof(TypeConverter<SignClientSignSettings>))]
[Command(Type = typeof(SignClientTasks), Command = nameof(SignClientTasks.SignClientSign), Arguments = "sign")]
public partial class SignClientSignSettings : ToolOptions
{
    /// <summary>Path to config json file</summary>
    [Argument(Format = "--config {value}")] public string Config => Get<string>(() => Config);
    /// <summary>Path to input file</summary>
    [Argument(Format = "--input {value}")] public string Input => Get<string>(() => Input);
    /// <summary>Base directory for files to override the working directory</summary>
    [Argument(Format = "--baseDirectory {value}")] public string BaseDirectory => Get<string>(() => BaseDirectory);
    /// <summary>Path to output file. May be same as input to overwrite</summary>
    [Argument(Format = "--output {value}")] public string Output => Get<string>(() => Output);
    /// <summary>Path to file containing paths of files to sign within an archive</summary>
    [Argument(Format = "--fileList {value}")] public string FileList => Get<string>(() => FileList);
    /// <summary>Client Secret</summary>
    [Argument(Format = "--secret {value}", Secret = true)] public string Secret => Get<string>(() => Secret);
    /// <summary>Username</summary>
    [Argument(Format = "--user {value}")] public string Username => Get<string>(() => Username);
    /// <summary>Name of project for tracking</summary>
    [Argument(Format = "--name {value}")] public string Name => Get<string>(() => Name);
    /// <summary>Description</summary>
    [Argument(Format = "--description {value}")] public string Description => Get<string>(() => Description);
    /// <summary>Description Url</summary>
    [Argument(Format = "--descriptionUrl {value}")] public string DescriptionUrl => Get<string>(() => DescriptionUrl);
    /// <summary>Maximum concurrency (default is 4)</summary>
    [Argument(Format = "--maxConcurrency {value}")] public string MaxConcurrency => Get<string>(() => MaxConcurrency);
}
#endregion
#region SignClientSignSettingsExtensions
/// <summary>Used within <see cref="SignClientTasks"/>.</summary>
[PublicAPI]
[ExcludeFromCodeCoverage]
public static partial class SignClientSignSettingsExtensions
{
    #region Config
    /// <inheritdoc cref="SignClientSignSettings.Config"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Config))]
    public static T SetConfig<T>(this T o, string v) where T : SignClientSignSettings => o.Modify(b => b.Set(() => o.Config, v));
    /// <inheritdoc cref="SignClientSignSettings.Config"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Config))]
    public static T ResetConfig<T>(this T o) where T : SignClientSignSettings => o.Modify(b => b.Remove(() => o.Config));
    #endregion
    #region Input
    /// <inheritdoc cref="SignClientSignSettings.Input"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Input))]
    public static T SetInput<T>(this T o, string v) where T : SignClientSignSettings => o.Modify(b => b.Set(() => o.Input, v));
    /// <inheritdoc cref="SignClientSignSettings.Input"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Input))]
    public static T ResetInput<T>(this T o) where T : SignClientSignSettings => o.Modify(b => b.Remove(() => o.Input));
    #endregion
    #region BaseDirectory
    /// <inheritdoc cref="SignClientSignSettings.BaseDirectory"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.BaseDirectory))]
    public static T SetBaseDirectory<T>(this T o, string v) where T : SignClientSignSettings => o.Modify(b => b.Set(() => o.BaseDirectory, v));
    /// <inheritdoc cref="SignClientSignSettings.BaseDirectory"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.BaseDirectory))]
    public static T ResetBaseDirectory<T>(this T o) where T : SignClientSignSettings => o.Modify(b => b.Remove(() => o.BaseDirectory));
    #endregion
    #region Output
    /// <inheritdoc cref="SignClientSignSettings.Output"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Output))]
    public static T SetOutput<T>(this T o, string v) where T : SignClientSignSettings => o.Modify(b => b.Set(() => o.Output, v));
    /// <inheritdoc cref="SignClientSignSettings.Output"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Output))]
    public static T ResetOutput<T>(this T o) where T : SignClientSignSettings => o.Modify(b => b.Remove(() => o.Output));
    #endregion
    #region FileList
    /// <inheritdoc cref="SignClientSignSettings.FileList"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.FileList))]
    public static T SetFileList<T>(this T o, string v) where T : SignClientSignSettings => o.Modify(b => b.Set(() => o.FileList, v));
    /// <inheritdoc cref="SignClientSignSettings.FileList"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.FileList))]
    public static T ResetFileList<T>(this T o) where T : SignClientSignSettings => o.Modify(b => b.Remove(() => o.FileList));
    #endregion
    #region Secret
    /// <inheritdoc cref="SignClientSignSettings.Secret"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Secret))]
    public static T SetSecret<T>(this T o, [Secret] string v) where T : SignClientSignSettings => o.Modify(b => b.Set(() => o.Secret, v));
    /// <inheritdoc cref="SignClientSignSettings.Secret"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Secret))]
    public static T ResetSecret<T>(this T o) where T : SignClientSignSettings => o.Modify(b => b.Remove(() => o.Secret));
    #endregion
    #region Username
    /// <inheritdoc cref="SignClientSignSettings.Username"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Username))]
    public static T SetUsername<T>(this T o, string v) where T : SignClientSignSettings => o.Modify(b => b.Set(() => o.Username, v));
    /// <inheritdoc cref="SignClientSignSettings.Username"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Username))]
    public static T ResetUsername<T>(this T o) where T : SignClientSignSettings => o.Modify(b => b.Remove(() => o.Username));
    #endregion
    #region Name
    /// <inheritdoc cref="SignClientSignSettings.Name"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Name))]
    public static T SetName<T>(this T o, string v) where T : SignClientSignSettings => o.Modify(b => b.Set(() => o.Name, v));
    /// <inheritdoc cref="SignClientSignSettings.Name"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Name))]
    public static T ResetName<T>(this T o) where T : SignClientSignSettings => o.Modify(b => b.Remove(() => o.Name));
    #endregion
    #region Description
    /// <inheritdoc cref="SignClientSignSettings.Description"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Description))]
    public static T SetDescription<T>(this T o, string v) where T : SignClientSignSettings => o.Modify(b => b.Set(() => o.Description, v));
    /// <inheritdoc cref="SignClientSignSettings.Description"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.Description))]
    public static T ResetDescription<T>(this T o) where T : SignClientSignSettings => o.Modify(b => b.Remove(() => o.Description));
    #endregion
    #region DescriptionUrl
    /// <inheritdoc cref="SignClientSignSettings.DescriptionUrl"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.DescriptionUrl))]
    public static T SetDescriptionUrl<T>(this T o, string v) where T : SignClientSignSettings => o.Modify(b => b.Set(() => o.DescriptionUrl, v));
    /// <inheritdoc cref="SignClientSignSettings.DescriptionUrl"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.DescriptionUrl))]
    public static T ResetDescriptionUrl<T>(this T o) where T : SignClientSignSettings => o.Modify(b => b.Remove(() => o.DescriptionUrl));
    #endregion
    #region MaxConcurrency
    /// <inheritdoc cref="SignClientSignSettings.MaxConcurrency"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.MaxConcurrency))]
    public static T SetMaxConcurrency<T>(this T o, string v) where T : SignClientSignSettings => o.Modify(b => b.Set(() => o.MaxConcurrency, v));
    /// <inheritdoc cref="SignClientSignSettings.MaxConcurrency"/>
    [Pure] [Builder(Type = typeof(SignClientSignSettings), Property = nameof(SignClientSignSettings.MaxConcurrency))]
    public static T ResetMaxConcurrency<T>(this T o) where T : SignClientSignSettings => o.Modify(b => b.Remove(() => o.MaxConcurrency));
    #endregion
}
#endregion
