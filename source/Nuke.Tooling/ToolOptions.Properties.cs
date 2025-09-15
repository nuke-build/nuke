// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using Serilog.Events;
// ReSharper disable ArrangeMethodOrOperatorBody

namespace Nuke.Common.Tooling;

partial class ToolOptions
{
    /// <summary>Defines the path of the tool to be invoked. In most cases, the tool path is automatically resolved from the PATH environment variable or a NuGet package.</summary>
    public string ProcessToolPath => Get<string>(() => ProcessToolPath);

    /// <summary>Defines the working directory for the process.</summary>
    public string ProcessWorkingDirectory => Get<string>(() => ProcessWorkingDirectory);

    /// <summary>Collection of environment variables to be passed to the process. By default, the environment variables of the current process are used.</summary>
    public IReadOnlyDictionary<string, string> ProcessEnvironmentVariables => Get<Dictionary<string, string>>(() => ProcessEnvironmentVariables);

    /// <summary>Defines the execution timeout of the invoked process.</summary>
    public int? ProcessExecutionTimeout => Get<int?>(() => ProcessExecutionTimeout);

    /// <summary>Defines whether to log output.</summary>
    public bool? ProcessOutputLogging => Get<bool?>(() => ProcessOutputLogging);

    /// <summary>Defines whether to log the invocation.</summary>
    public bool? ProcessInvocationLogging => Get<bool?>(() => ProcessInvocationLogging);

    /// <summary>Defines whether to handle the process on exit.</summary>
    public bool? ProcessExitHandling => Get<bool?>(() => ProcessExitHandling);

    /// <summary>Collection of secret values to be redacted from log output.</summary>
    public IReadOnlyList<string> ProcessRedactedSecrets => Get<List<string>>(() => ProcessRedactedSecrets);

    /// <summary>Collection of additional arguments to append.</summary>
    public IReadOnlyList<string> ProcessAdditionalArguments => Get<List<string>>(() => ProcessAdditionalArguments);
}

[PublicAPI]
public static partial class ToolOptionsExtensions
{
    #region ToolOptions.ProcessToolPath

    /// <inheritdoc cref="ToolOptions.ProcessToolPath"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessToolPath))]
    public static T SetProcessToolPath<T>(this T o, string value) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessToolPath, value));

    /// <inheritdoc cref="ToolOptions.ProcessToolPath"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessToolPath))]
    public static T ResetProcessToolPath<T>(this T o) where T : ToolOptions => o.Modify(b => b.Remove(() => o.ProcessToolPath));

    #endregion

    #region ToolOptions.ProcessWorkingDirectory

    /// <inheritdoc cref="ToolOptions.ProcessWorkingDirectory"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessWorkingDirectory))]
    public static T SetProcessWorkingDirectory<T>(this T o, string value) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessWorkingDirectory, value));

    /// <inheritdoc cref="ToolOptions.ProcessWorkingDirectory"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessWorkingDirectory))]
    public static T ResetProcessWorkingDirectory<T>(this T o) where T : ToolOptions => o.Modify(b => b.Remove(() => o.ProcessWorkingDirectory));

    #endregion

    #region ToolOptions.ProcessEnvironmentVariables

    /// <inheritdoc cref="ToolOptions.ProcessEnvironmentVariables"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessEnvironmentVariables))]
    public static T SetProcessEnvironmentVariables<T>(this T o, ReadOnlyDictionary<string, string> values) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessEnvironmentVariables, values));

    /// <inheritdoc cref="ToolOptions.ProcessEnvironmentVariables"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessEnvironmentVariables))]
    public static T SetProcessEnvironmentVariables<T>(this T o, Dictionary<string, string> values) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessEnvironmentVariables, values));

    /// <inheritdoc cref="ToolOptions.ProcessEnvironmentVariables"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessEnvironmentVariables))]
    public static T AddProcessEnvironmentVariables<T>(this T o, ReadOnlyDictionary<string, string> values) where T : ToolOptions => o.Modify(b => b.AddDictionary(() => o.ProcessEnvironmentVariables, values));

    /// <inheritdoc cref="ToolOptions.ProcessEnvironmentVariables"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessEnvironmentVariables))]
    public static T AddProcessEnvironmentVariables<T>(this T o, Dictionary<string, string> values) where T : ToolOptions => o.Modify(b => b.AddDictionary(() => o.ProcessEnvironmentVariables, values));

    /// <inheritdoc cref="ToolOptions.ProcessEnvironmentVariables"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessEnvironmentVariables))]
    public static T AddProcessEnvironmentVariable<T>(this T o, string key, string value) where T : ToolOptions => o.Modify(b => b.AddDictionary(() => o.ProcessEnvironmentVariables, key, value));

    /// <inheritdoc cref="ToolOptions.ProcessEnvironmentVariables"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessEnvironmentVariables))]
    public static T SetProcessEnvironmentVariable<T>(this T o, string key, string value) where T : ToolOptions => o.Modify(b => b.SetDictionary(() => o.ProcessEnvironmentVariables, key, value));

    /// <inheritdoc cref="ToolOptions.ProcessEnvironmentVariables"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessEnvironmentVariables))]
    public static T SetProcessEnvironmentVariable<T>(this T o, string key, object value) where T : ToolOptions => o.Modify(b => b.SetDictionary(() => o.ProcessEnvironmentVariables, key, value.ToString()));

    /// <inheritdoc cref="ToolOptions.ProcessEnvironmentVariables"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessEnvironmentVariables))]
    public static T RemoveProcessEnvironmentVariable<T>(this T o, string key) where T : ToolOptions => o.Modify(b => b.RemoveDictionary(() => o.ProcessEnvironmentVariables, key));

    /// <inheritdoc cref="ToolOptions.ProcessEnvironmentVariables"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessEnvironmentVariables))]
    public static T ClearProcessEnvironmentVariables<T>(this T o) where T : ToolOptions => o.Modify(b => b.ClearDictionary(() => o.ProcessEnvironmentVariables));

    /// <inheritdoc cref="ToolOptions.ProcessEnvironmentVariables"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessEnvironmentVariables))]
    public static T ResetProcessEnvironmentVariables<T>(this T o) where T : ToolOptions => o.Modify(b => b.Remove(() => o.ProcessEnvironmentVariables));

    #endregion

    #region ToolOptions.ProcessExecutionTimeout

    /// <inheritdoc cref="ToolOptions.ProcessExecutionTimeout"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessExecutionTimeout))]
    public static T SetProcessExecutionTimeout<T>(this T o, int? value) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessExecutionTimeout, value));

    /// <inheritdoc cref="ToolOptions.ProcessExecutionTimeout"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessExecutionTimeout))]
    public static T SetProcessExecutionTimeout<T>(this T o, TimeSpan value) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessExecutionTimeout, value.TotalMilliseconds));

    /// <inheritdoc cref="ToolOptions.ProcessExecutionTimeout"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessExecutionTimeout))]
    public static T ResetProcessExecutionTimeout<T>(this T o) where T : ToolOptions => o.Modify(b => b.Remove(() => o.ProcessExecutionTimeout));

    #endregion

    #region ToolOptions.ProcessOutputLogging

    /// <inheritdoc cref="ToolOptions.ProcessOutputLogging"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessOutputLogging))]
    public static T SetProcessOutputLogging<T>(this T o, bool? value) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessOutputLogging, value));

    /// <inheritdoc cref="ToolOptions.ProcessOutputLogging"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessOutputLogging))]
    public static T EnableProcessOutputLogging<T>(this T o) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessOutputLogging, value: true));

    /// <inheritdoc cref="ToolOptions.ProcessOutputLogging"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessOutputLogging))]
    public static T DisableProcessOutputLogging<T>(this T o) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessOutputLogging, value: false));

    /// <inheritdoc cref="ToolOptions.ProcessOutputLogging"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessOutputLogging))]
    public static T ResetProcessOutputLogging<T>(this T o) where T : ToolOptions => o.Modify(b => b.Remove(() => o.ProcessOutputLogging));

    #endregion

    #region ToolOptions.ProcessInvocationLogging

    /// <inheritdoc cref="ToolOptions.ProcessInvocationLogging"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessInvocationLogging))]
    public static T SetProcessInvocationLogging<T>(this T o, bool? value) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessInvocationLogging, value));

    /// <inheritdoc cref="ToolOptions.ProcessInvocationLogging"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessInvocationLogging))]
    public static T EnableProcessInvocationLogging<T>(this T o) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessInvocationLogging, value: true));

    /// <inheritdoc cref="ToolOptions.ProcessInvocationLogging"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessInvocationLogging))]
    public static T DisableProcessInvocationLogging<T>(this T o) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessInvocationLogging, value: false));

    /// <inheritdoc cref="ToolOptions.ProcessInvocationLogging"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessInvocationLogging))]
    public static T ResetProcessInvocationLogging<T>(this T o) where T : ToolOptions => o.Modify(b => b.Remove(() => o.ProcessInvocationLogging));

    #endregion

    #region ToolOptions.ProcessExitHandling

    /// <inheritdoc cref="ToolOptions.ProcessExitHandling"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessExitHandling))]
    public static T SetProcessExitHandling<T>(this T o, bool? value) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessExitHandling, value));

    /// <inheritdoc cref="ToolOptions.ProcessExitHandling"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessExitHandling))]
    public static T EnableProcessExitHandling<T>(this T o) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessExitHandling, value: true));

    /// <inheritdoc cref="ToolOptions.ProcessExitHandling"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessExitHandling))]
    public static T DisableProcessExitHandling<T>(this T o) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessExitHandling, value: false));

    /// <inheritdoc cref="ToolOptions.ProcessExitHandling"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessExitHandling))]
    public static T ToggleProcessExitHandling<T>(this T o) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessExitHandling, !o.ProcessExitHandling));

    /// <inheritdoc cref="ToolOptions.ProcessExitHandling"/>
    [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessExitHandling))]
    public static T ResetProcessExitHandling<T>(this T o) where T : ToolOptions => o.Modify(b => b.Remove(() => o.ProcessExitHandling));

    #endregion

    #region ToolOptions.ProcessRedactedSecrets

    /// <inheritdoc cref="ToolOptions.ProcessRedactedSecrets"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessRedactedSecrets))]
    public static T SetProcessRedactedSecrets<T>(this T o, params string[] v) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessRedactedSecrets, v));
    /// <inheritdoc cref="ToolOptions.ProcessRedactedSecrets"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessRedactedSecrets))]
    public static T SetProcessRedactedSecrets<T>(this T o, IEnumerable<string> v) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessRedactedSecrets, v));
    /// <inheritdoc cref="ToolOptions.ProcessRedactedSecrets"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessRedactedSecrets))]
    public static T AddProcessRedactedSecrets<T>(this T o, params string[] v) where T : ToolOptions => o.Modify(b => b.AddCollection(() => o.ProcessRedactedSecrets, v));
    /// <inheritdoc cref="ToolOptions.ProcessRedactedSecrets"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessRedactedSecrets))]
    public static T AddProcessRedactedSecrets<T>(this T o, IEnumerable<string> v) where T : ToolOptions => o.Modify(b => b.AddCollection(() => o.ProcessRedactedSecrets, v));
    /// <inheritdoc cref="ToolOptions.ProcessRedactedSecrets"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessRedactedSecrets))]
    public static T RemoveProcessRedactedSecrets<T>(this T o, params string[] v) where T : ToolOptions => o.Modify(b => b.RemoveCollection(() => o.ProcessRedactedSecrets, v));
    /// <inheritdoc cref="ToolOptions.ProcessRedactedSecrets"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessRedactedSecrets))]
    public static T RemoveProcessRedactedSecrets<T>(this T o, IEnumerable<string> v) where T : ToolOptions => o.Modify(b => b.RemoveCollection(() => o.ProcessRedactedSecrets, v));
    /// <inheritdoc cref="ToolOptions.ProcessRedactedSecrets"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessRedactedSecrets))]
    public static T ClearProcessRedactedSecrets<T>(this T o) where T : ToolOptions => o.Modify(b => b.ClearCollection(() => o.ProcessRedactedSecrets));

    #endregion

    #region ToolOptions.ProcessAdditionalArguments

    /// <inheritdoc cref="ToolOptions.ProcessAdditionalArguments"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessAdditionalArguments))]
    public static T SetProcessAdditionalArguments<T>(this T o, params string[] v) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessAdditionalArguments, v));
    /// <inheritdoc cref="ToolOptions.ProcessAdditionalArguments"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessAdditionalArguments))]
    public static T SetProcessAdditionalArguments<T>(this T o, IEnumerable<string> v) where T : ToolOptions => o.Modify(b => b.Set(() => o.ProcessAdditionalArguments, v));
    /// <inheritdoc cref="ToolOptions.ProcessAdditionalArguments"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessAdditionalArguments))]
    public static T AddProcessAdditionalArguments<T>(this T o, params string[] v) where T : ToolOptions => o.Modify(b => b.AddCollection(() => o.ProcessAdditionalArguments, v));
    /// <inheritdoc cref="ToolOptions.ProcessAdditionalArguments"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessAdditionalArguments))]
    public static T AddProcessAdditionalArguments<T>(this T o, IEnumerable<string> v) where T : ToolOptions => o.Modify(b => b.AddCollection(() => o.ProcessAdditionalArguments, v));
    /// <inheritdoc cref="ToolOptions.ProcessAdditionalArguments"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessAdditionalArguments))]
    public static T RemoveProcessAdditionalArguments<T>(this T o, params string[] v) where T : ToolOptions => o.Modify(b => b.RemoveCollection(() => o.ProcessAdditionalArguments, v));
    /// <inheritdoc cref="ToolOptions.ProcessAdditionalArguments"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessAdditionalArguments))]
    public static T RemoveProcessAdditionalArguments<T>(this T o, IEnumerable<string> v) where T : ToolOptions => o.Modify(b => b.RemoveCollection(() => o.ProcessAdditionalArguments, v));
    /// <inheritdoc cref="ToolOptions.ProcessAdditionalArguments"/>
    [Pure] [Builder(Type = typeof(ToolOptions), Property = nameof(ToolOptions.ProcessAdditionalArguments))]
    public static T ClearProcessAdditionalArguments<T>(this T o) where T : ToolOptions => o.Modify(b => b.ClearCollection(() => o.ProcessAdditionalArguments));

    #endregion
}
