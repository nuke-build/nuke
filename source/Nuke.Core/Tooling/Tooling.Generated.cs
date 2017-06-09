using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Tooling;
using Nuke.Core.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Core.Tooling
{
  [PublicAPI]
  [Serializable]
  [ExcludeFromCodeCoverage]
  public partial class ToolSettings : ISettingsEntity
  {
    public virtual string ToolPath { get; internal set; }
    public virtual string WorkingDirectory { get; internal set; }
    public virtual Func<Arguments, Arguments> ArgumentConfigurator { get; internal set; } = x => x;
  }
  [PublicAPI]
  [ExcludeFromCodeCoverage]
  public static partial class ToolSettingsExtensions
  {
    ///<summary>Sets <see cref="ToolSettings.ToolPath"/> -- <inheritdoc cref="ToolSettings.ToolPath" /></summary>
    [Pure]
    public static T SetToolPath<T> (this T toolSettings, [CanBeNull] string toolPath) where T : ToolSettings
    {
      var newToolSettings = toolSettings.NewInstance();
      newToolSettings.ToolPath = toolPath;
      return newToolSettings;
    }
    ///<summary>Sets <see cref="ToolSettings.WorkingDirectory"/> -- <inheritdoc cref="ToolSettings.WorkingDirectory" /></summary>
    [Pure]
    public static T SetWorkingDirectory<T> (this T toolSettings, [CanBeNull] string workingDirectory) where T : ToolSettings
    {
      var newToolSettings = toolSettings.NewInstance();
      newToolSettings.WorkingDirectory = workingDirectory;
      return newToolSettings;
    }
    ///<summary>Sets <see cref="ToolSettings.ArgumentConfigurator"/> -- <inheritdoc cref="ToolSettings.ArgumentConfigurator" /></summary>
    [Pure]
    public static T SetArgumentConfigurator<T> (this T toolSettings, [CanBeNull] Func<Arguments, Arguments> argumentConfigurator) where T : ToolSettings
    {
      var newToolSettings = toolSettings.NewInstance();
      newToolSettings.ArgumentConfigurator = argumentConfigurator;
      return newToolSettings;
    }
  }
  [PublicAPI]
  [Serializable]
  [ExcludeFromCodeCoverage]
  public partial class ProcessSettings : ISettingsEntity
  {
    public virtual IReadOnlyDictionary<string, string> EnvironmentVariables => EnvironmentVariablesInternal.AsReadOnly();
    internal Dictionary<string, string> EnvironmentVariablesInternal { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    public virtual int? ExecutionTimeout { get; internal set; }
    public virtual bool RedirectOutput { get; internal set; }
  }
  [PublicAPI]
  [ExcludeFromCodeCoverage]
  public static partial class ProcessSettingsExtensions
  {
    [Pure]
    public static ProcessSettings AddEnvironmentVariable (this ProcessSettings processSettings, string environmentVariableKey, string environmentVariableValue)
    {
      var newProcessSettings = processSettings.NewInstance();
      newProcessSettings.EnvironmentVariablesInternal.Add(environmentVariableKey, environmentVariableValue);
      return newProcessSettings;
    }
    [Pure]
    public static ProcessSettings RemoveEnvironmentVariable (this ProcessSettings processSettings, string environmentVariableKey)
    {
      var newProcessSettings = processSettings.NewInstance();
      newProcessSettings.EnvironmentVariablesInternal.Remove(environmentVariableKey);
      return newProcessSettings;
    }
    [Pure]
    public static ProcessSettings SetEnvironmentVariable (this ProcessSettings processSettings, string environmentVariableKey, string environmentVariableValue)
    {
      var newProcessSettings = processSettings.NewInstance();
      newProcessSettings.EnvironmentVariablesInternal[environmentVariableKey] = environmentVariableValue;
      return newProcessSettings;
    }
    [Pure]
    public static ProcessSettings ClearEnvironmentVariables (this ProcessSettings processSettings)
    {
      var newProcessSettings = processSettings.NewInstance();
      newProcessSettings.EnvironmentVariablesInternal.Clear();
      return newProcessSettings;
    }
    ///<summary>Sets <see cref="ProcessSettings.ExecutionTimeout"/> -- <inheritdoc cref="ProcessSettings.ExecutionTimeout" /></summary>
    [Pure]
    public static ProcessSettings SetExecutionTimeout (this ProcessSettings processSettings, [CanBeNull] int? executionTimeout)
    {
      var newProcessSettings = processSettings.NewInstance();
      newProcessSettings.ExecutionTimeout = executionTimeout;
      return newProcessSettings;
    }
    ///<summary>Sets <see cref="ProcessSettings.RedirectOutput"/> -- <inheritdoc cref="ProcessSettings.RedirectOutput" /></summary>
    [Pure]
    public static ProcessSettings SetRedirectOutput (this ProcessSettings processSettings, bool redirectOutput)
    {
      var newProcessSettings = processSettings.NewInstance();
      newProcessSettings.RedirectOutput = redirectOutput;
      return newProcessSettings;
    }
    ///<summary>Enables <see cref="ProcessSettings.RedirectOutput"/> -- <inheritdoc cref="ProcessSettings.RedirectOutput" /></summary>
    [Pure]
    public static ProcessSettings EnableRedirectOutput (this ProcessSettings processSettings)
    {
      var newProcessSettings = processSettings.NewInstance();
      newProcessSettings.RedirectOutput = true;
      return newProcessSettings;
    }
    ///<summary>Disables <see cref="ProcessSettings.RedirectOutput"/> -- <inheritdoc cref="ProcessSettings.RedirectOutput" /></summary>
    [Pure]
    public static ProcessSettings DisableRedirectOutput (this ProcessSettings processSettings)
    {
      var newProcessSettings = processSettings.NewInstance();
      newProcessSettings.RedirectOutput = false;
      return newProcessSettings;
    }
  }
}
