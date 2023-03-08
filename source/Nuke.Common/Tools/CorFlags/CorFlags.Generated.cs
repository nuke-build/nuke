// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/CorFlags/CorFlags.json

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

namespace Nuke.Common.Tools.CorFlags
{
    /// <summary>
    ///   <p>The CorFlags Conversion tool allows you to configure the CorFlags section of the header of a portable executable image.</p>
    ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/corflags-exe-corflags-conversion-tool">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [PathToolRequirement(CorFlagsPathExecutable)]
    public partial class CorFlagsTasks
        : IRequirePathTool
    {
        public const string CorFlagsPathExecutable = "CorFlags.exe";
        /// <summary>
        ///   Path to the CorFlags executable.
        /// </summary>
        public static string CorFlagsPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("CORFLAGS_EXE") ??
            ToolPathResolver.GetPathExecutable("CorFlags.exe");
        public static Action<OutputType, string> CorFlagsLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>The CorFlags Conversion tool allows you to configure the CorFlags section of the header of a portable executable image.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/corflags-exe-corflags-conversion-tool">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> CorFlags(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(CorFlagsPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? CorFlagsLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The CorFlags Conversion tool allows you to configure the CorFlags section of the header of a portable executable image.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/corflags-exe-corflags-conversion-tool">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assembly&gt;</c> via <see cref="CorFlagsSettings.Assembly"/></li>
        ///     <li><c>-32BIT</c> via <see cref="CorFlagsSettings.Require32Bit"/></li>
        ///     <li><c>-32BITPREF</c> via <see cref="CorFlagsSettings.Prefer32Bit"/></li>
        ///     <li><c>-Force</c> via <see cref="CorFlagsSettings.Force"/></li>
        ///     <li><c>-ILONLY</c> via <see cref="CorFlagsSettings.ILOnly"/></li>
        ///     <li><c>-nologo</c> via <see cref="CorFlagsSettings.NoLogo"/></li>
        ///     <li><c>-RevertCLRHeader</c> via <see cref="CorFlagsSettings.RevertCLRHeader"/></li>
        ///     <li><c>-UpgradeCLRHeader</c> via <see cref="CorFlagsSettings.UpgradeCLRHeader"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CorFlags(CorFlagsSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new CorFlagsSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>The CorFlags Conversion tool allows you to configure the CorFlags section of the header of a portable executable image.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/corflags-exe-corflags-conversion-tool">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assembly&gt;</c> via <see cref="CorFlagsSettings.Assembly"/></li>
        ///     <li><c>-32BIT</c> via <see cref="CorFlagsSettings.Require32Bit"/></li>
        ///     <li><c>-32BITPREF</c> via <see cref="CorFlagsSettings.Prefer32Bit"/></li>
        ///     <li><c>-Force</c> via <see cref="CorFlagsSettings.Force"/></li>
        ///     <li><c>-ILONLY</c> via <see cref="CorFlagsSettings.ILOnly"/></li>
        ///     <li><c>-nologo</c> via <see cref="CorFlagsSettings.NoLogo"/></li>
        ///     <li><c>-RevertCLRHeader</c> via <see cref="CorFlagsSettings.RevertCLRHeader"/></li>
        ///     <li><c>-UpgradeCLRHeader</c> via <see cref="CorFlagsSettings.UpgradeCLRHeader"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> CorFlags(Configure<CorFlagsSettings> configurator)
        {
            return CorFlags(configurator(new CorFlagsSettings()));
        }
        /// <summary>
        ///   <p>The CorFlags Conversion tool allows you to configure the CorFlags section of the header of a portable executable image.</p>
        ///   <p>For more details, visit the <a href="https://docs.microsoft.com/en-us/dotnet/framework/tools/corflags-exe-corflags-conversion-tool">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assembly&gt;</c> via <see cref="CorFlagsSettings.Assembly"/></li>
        ///     <li><c>-32BIT</c> via <see cref="CorFlagsSettings.Require32Bit"/></li>
        ///     <li><c>-32BITPREF</c> via <see cref="CorFlagsSettings.Prefer32Bit"/></li>
        ///     <li><c>-Force</c> via <see cref="CorFlagsSettings.Force"/></li>
        ///     <li><c>-ILONLY</c> via <see cref="CorFlagsSettings.ILOnly"/></li>
        ///     <li><c>-nologo</c> via <see cref="CorFlagsSettings.NoLogo"/></li>
        ///     <li><c>-RevertCLRHeader</c> via <see cref="CorFlagsSettings.RevertCLRHeader"/></li>
        ///     <li><c>-UpgradeCLRHeader</c> via <see cref="CorFlagsSettings.UpgradeCLRHeader"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(CorFlagsSettings Settings, IReadOnlyCollection<Output> Output)> CorFlags(CombinatorialConfigure<CorFlagsSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(CorFlags, CorFlagsLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region CorFlagsSettings
    /// <summary>
    ///   Used within <see cref="CorFlagsTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class CorFlagsSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the CorFlags executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? CorFlagsTasks.CorFlagsPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? CorFlagsTasks.CorFlagsLogger;
        /// <summary>
        ///   Suppresses the Microsoft startup banner display.
        /// </summary>
        public virtual bool? NoLogo { get; internal set; }
        /// <summary>
        ///   Upgrades the CLR header version to 2.5. <em>Note</em>: Assemblies must have a CLR header version of 2.5 or greater to run natively.
        /// </summary>
        public virtual bool? UpgradeCLRHeader { get; internal set; }
        /// <summary>
        ///   Reverts the CLR header version to 2.0.
        /// </summary>
        public virtual bool? RevertCLRHeader { get; internal set; }
        /// <summary>
        ///   Forces an update even if the assembly is strong-named. <em>Important</em>: If you update a strong-named assembly, you must sign it again before executing its code.
        /// </summary>
        public virtual bool? Force { get; internal set; }
        /// <summary>
        ///   The name of the assembly for which to configure the CorFlags.
        /// </summary>
        public virtual string Assembly { get; internal set; }
        /// <summary>
        ///   Sets/clears the ILONLY flag.
        /// </summary>
        public virtual bool? ILOnly { get; internal set; }
        /// <summary>
        ///   Sets/clears the 32BITREQUIRED flag.
        /// </summary>
        public virtual bool? Require32Bit { get; internal set; }
        /// <summary>
        ///   Sets/clears the 32BITPREFERRED flag.
        /// </summary>
        public virtual bool? Prefer32Bit { get; internal set; }
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("-nologo", NoLogo)
              .Add("-UpgradeCLRHeader", UpgradeCLRHeader)
              .Add("-RevertCLRHeader", RevertCLRHeader)
              .Add("-Force", Force)
              .Add("{value}", Assembly)
              .Add("-ILONLY{value}", GetILOnly(), customValue: true)
              .Add("-32BIT{value}", GetRequire32Bit(), customValue: true)
              .Add("-32BITPREF{value}", GetPrefer32Bit(), customValue: true);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region CorFlagsSettingsExtensions
    /// <summary>
    ///   Used within <see cref="CorFlagsTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class CorFlagsSettingsExtensions
    {
        #region NoLogo
        /// <summary>
        ///   <p><em>Sets <see cref="CorFlagsSettings.NoLogo"/></em></p>
        ///   <p>Suppresses the Microsoft startup banner display.</p>
        /// </summary>
        [Pure]
        public static T SetNoLogo<T>(this T toolSettings, bool? noLogo) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = noLogo;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CorFlagsSettings.NoLogo"/></em></p>
        ///   <p>Suppresses the Microsoft startup banner display.</p>
        /// </summary>
        [Pure]
        public static T ResetNoLogo<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CorFlagsSettings.NoLogo"/></em></p>
        ///   <p>Suppresses the Microsoft startup banner display.</p>
        /// </summary>
        [Pure]
        public static T EnableNoLogo<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CorFlagsSettings.NoLogo"/></em></p>
        ///   <p>Suppresses the Microsoft startup banner display.</p>
        /// </summary>
        [Pure]
        public static T DisableNoLogo<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CorFlagsSettings.NoLogo"/></em></p>
        ///   <p>Suppresses the Microsoft startup banner display.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoLogo<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoLogo = !toolSettings.NoLogo;
            return toolSettings;
        }
        #endregion
        #region UpgradeCLRHeader
        /// <summary>
        ///   <p><em>Sets <see cref="CorFlagsSettings.UpgradeCLRHeader"/></em></p>
        ///   <p>Upgrades the CLR header version to 2.5. <em>Note</em>: Assemblies must have a CLR header version of 2.5 or greater to run natively.</p>
        /// </summary>
        [Pure]
        public static T SetUpgradeCLRHeader<T>(this T toolSettings, bool? upgradeCLRHeader) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpgradeCLRHeader = upgradeCLRHeader;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CorFlagsSettings.UpgradeCLRHeader"/></em></p>
        ///   <p>Upgrades the CLR header version to 2.5. <em>Note</em>: Assemblies must have a CLR header version of 2.5 or greater to run natively.</p>
        /// </summary>
        [Pure]
        public static T ResetUpgradeCLRHeader<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpgradeCLRHeader = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CorFlagsSettings.UpgradeCLRHeader"/></em></p>
        ///   <p>Upgrades the CLR header version to 2.5. <em>Note</em>: Assemblies must have a CLR header version of 2.5 or greater to run natively.</p>
        /// </summary>
        [Pure]
        public static T EnableUpgradeCLRHeader<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpgradeCLRHeader = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CorFlagsSettings.UpgradeCLRHeader"/></em></p>
        ///   <p>Upgrades the CLR header version to 2.5. <em>Note</em>: Assemblies must have a CLR header version of 2.5 or greater to run natively.</p>
        /// </summary>
        [Pure]
        public static T DisableUpgradeCLRHeader<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpgradeCLRHeader = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CorFlagsSettings.UpgradeCLRHeader"/></em></p>
        ///   <p>Upgrades the CLR header version to 2.5. <em>Note</em>: Assemblies must have a CLR header version of 2.5 or greater to run natively.</p>
        /// </summary>
        [Pure]
        public static T ToggleUpgradeCLRHeader<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UpgradeCLRHeader = !toolSettings.UpgradeCLRHeader;
            return toolSettings;
        }
        #endregion
        #region RevertCLRHeader
        /// <summary>
        ///   <p><em>Sets <see cref="CorFlagsSettings.RevertCLRHeader"/></em></p>
        ///   <p>Reverts the CLR header version to 2.0.</p>
        /// </summary>
        [Pure]
        public static T SetRevertCLRHeader<T>(this T toolSettings, bool? revertCLRHeader) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RevertCLRHeader = revertCLRHeader;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CorFlagsSettings.RevertCLRHeader"/></em></p>
        ///   <p>Reverts the CLR header version to 2.0.</p>
        /// </summary>
        [Pure]
        public static T ResetRevertCLRHeader<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RevertCLRHeader = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CorFlagsSettings.RevertCLRHeader"/></em></p>
        ///   <p>Reverts the CLR header version to 2.0.</p>
        /// </summary>
        [Pure]
        public static T EnableRevertCLRHeader<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RevertCLRHeader = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CorFlagsSettings.RevertCLRHeader"/></em></p>
        ///   <p>Reverts the CLR header version to 2.0.</p>
        /// </summary>
        [Pure]
        public static T DisableRevertCLRHeader<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RevertCLRHeader = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CorFlagsSettings.RevertCLRHeader"/></em></p>
        ///   <p>Reverts the CLR header version to 2.0.</p>
        /// </summary>
        [Pure]
        public static T ToggleRevertCLRHeader<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RevertCLRHeader = !toolSettings.RevertCLRHeader;
            return toolSettings;
        }
        #endregion
        #region Force
        /// <summary>
        ///   <p><em>Sets <see cref="CorFlagsSettings.Force"/></em></p>
        ///   <p>Forces an update even if the assembly is strong-named. <em>Important</em>: If you update a strong-named assembly, you must sign it again before executing its code.</p>
        /// </summary>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = force;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CorFlagsSettings.Force"/></em></p>
        ///   <p>Forces an update even if the assembly is strong-named. <em>Important</em>: If you update a strong-named assembly, you must sign it again before executing its code.</p>
        /// </summary>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CorFlagsSettings.Force"/></em></p>
        ///   <p>Forces an update even if the assembly is strong-named. <em>Important</em>: If you update a strong-named assembly, you must sign it again before executing its code.</p>
        /// </summary>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CorFlagsSettings.Force"/></em></p>
        ///   <p>Forces an update even if the assembly is strong-named. <em>Important</em>: If you update a strong-named assembly, you must sign it again before executing its code.</p>
        /// </summary>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CorFlagsSettings.Force"/></em></p>
        ///   <p>Forces an update even if the assembly is strong-named. <em>Important</em>: If you update a strong-named assembly, you must sign it again before executing its code.</p>
        /// </summary>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Force = !toolSettings.Force;
            return toolSettings;
        }
        #endregion
        #region Assembly
        /// <summary>
        ///   <p><em>Sets <see cref="CorFlagsSettings.Assembly"/></em></p>
        ///   <p>The name of the assembly for which to configure the CorFlags.</p>
        /// </summary>
        [Pure]
        public static T SetAssembly<T>(this T toolSettings, string assembly) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Assembly = assembly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CorFlagsSettings.Assembly"/></em></p>
        ///   <p>The name of the assembly for which to configure the CorFlags.</p>
        /// </summary>
        [Pure]
        public static T ResetAssembly<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Assembly = null;
            return toolSettings;
        }
        #endregion
        #region ILOnly
        /// <summary>
        ///   <p><em>Sets <see cref="CorFlagsSettings.ILOnly"/></em></p>
        ///   <p>Sets/clears the ILONLY flag.</p>
        /// </summary>
        [Pure]
        public static T SetILOnly<T>(this T toolSettings, bool? ilonly) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ILOnly = ilonly;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CorFlagsSettings.ILOnly"/></em></p>
        ///   <p>Sets/clears the ILONLY flag.</p>
        /// </summary>
        [Pure]
        public static T ResetILOnly<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ILOnly = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CorFlagsSettings.ILOnly"/></em></p>
        ///   <p>Sets/clears the ILONLY flag.</p>
        /// </summary>
        [Pure]
        public static T EnableILOnly<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ILOnly = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CorFlagsSettings.ILOnly"/></em></p>
        ///   <p>Sets/clears the ILONLY flag.</p>
        /// </summary>
        [Pure]
        public static T DisableILOnly<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ILOnly = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CorFlagsSettings.ILOnly"/></em></p>
        ///   <p>Sets/clears the ILONLY flag.</p>
        /// </summary>
        [Pure]
        public static T ToggleILOnly<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ILOnly = !toolSettings.ILOnly;
            return toolSettings;
        }
        #endregion
        #region Require32Bit
        /// <summary>
        ///   <p><em>Sets <see cref="CorFlagsSettings.Require32Bit"/></em></p>
        ///   <p>Sets/clears the 32BITREQUIRED flag.</p>
        /// </summary>
        [Pure]
        public static T SetRequire32Bit<T>(this T toolSettings, bool? require32Bit) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Require32Bit = require32Bit;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CorFlagsSettings.Require32Bit"/></em></p>
        ///   <p>Sets/clears the 32BITREQUIRED flag.</p>
        /// </summary>
        [Pure]
        public static T ResetRequire32Bit<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Require32Bit = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CorFlagsSettings.Require32Bit"/></em></p>
        ///   <p>Sets/clears the 32BITREQUIRED flag.</p>
        /// </summary>
        [Pure]
        public static T EnableRequire32Bit<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Require32Bit = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CorFlagsSettings.Require32Bit"/></em></p>
        ///   <p>Sets/clears the 32BITREQUIRED flag.</p>
        /// </summary>
        [Pure]
        public static T DisableRequire32Bit<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Require32Bit = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CorFlagsSettings.Require32Bit"/></em></p>
        ///   <p>Sets/clears the 32BITREQUIRED flag.</p>
        /// </summary>
        [Pure]
        public static T ToggleRequire32Bit<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Require32Bit = !toolSettings.Require32Bit;
            return toolSettings;
        }
        #endregion
        #region Prefer32Bit
        /// <summary>
        ///   <p><em>Sets <see cref="CorFlagsSettings.Prefer32Bit"/></em></p>
        ///   <p>Sets/clears the 32BITPREFERRED flag.</p>
        /// </summary>
        [Pure]
        public static T SetPrefer32Bit<T>(this T toolSettings, bool? prefer32Bit) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefer32Bit = prefer32Bit;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="CorFlagsSettings.Prefer32Bit"/></em></p>
        ///   <p>Sets/clears the 32BITPREFERRED flag.</p>
        /// </summary>
        [Pure]
        public static T ResetPrefer32Bit<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefer32Bit = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="CorFlagsSettings.Prefer32Bit"/></em></p>
        ///   <p>Sets/clears the 32BITPREFERRED flag.</p>
        /// </summary>
        [Pure]
        public static T EnablePrefer32Bit<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefer32Bit = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="CorFlagsSettings.Prefer32Bit"/></em></p>
        ///   <p>Sets/clears the 32BITPREFERRED flag.</p>
        /// </summary>
        [Pure]
        public static T DisablePrefer32Bit<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefer32Bit = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="CorFlagsSettings.Prefer32Bit"/></em></p>
        ///   <p>Sets/clears the 32BITPREFERRED flag.</p>
        /// </summary>
        [Pure]
        public static T TogglePrefer32Bit<T>(this T toolSettings) where T : CorFlagsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Prefer32Bit = !toolSettings.Prefer32Bit;
            return toolSettings;
        }
        #endregion
    }
    #endregion
}
