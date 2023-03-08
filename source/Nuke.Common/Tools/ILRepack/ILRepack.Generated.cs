// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/ILRepack/ILRepack.json

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

namespace Nuke.Common.Tools.ILRepack
{
    /// <summary>
    ///   <p>ILRepack is meant at replacing <a href="https://github.com/dotnet/ILMerge">ILMerge</a> / <a href="https://evain.net/blog/articles/2006/11/06/an-introduction-to-mono-merge">Mono.Merge</a>.<para/>The former being closed-source (<a href="https://github.com/Microsoft/ILMerge">now open-sourced</a>), impossible to customize, slow, resource consuming and many more. The later being deprecated, unsupported, and based on an old version of Mono.Cecil.<para/>Here we're using latest (slightly modified) Cecil sources (0.9), you can find the fork <a href="https://github.com/gluck/cecil">here</a>. Mono.Posix is also required (build only, it gets merged afterwards) for executable bit set on target file.</p>
    ///   <p>For more details, visit the <a href="https://github.com/gluck/il-repack#readme">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [NuGetPackageRequirement(ILRepackPackageId)]
    public partial class ILRepackTasks
        : IRequireNuGetPackage
    {
        public const string ILRepackPackageId = "ILRepack";
        /// <summary>
        ///   Path to the ILRepack executable.
        /// </summary>
        public static string ILRepackPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("ILREPACK_EXE") ??
            NuGetToolPathResolver.GetPackageExecutable("ILRepack", "ILRepack.exe");
        public static Action<OutputType, string> ILRepackLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>ILRepack is meant at replacing <a href="https://github.com/dotnet/ILMerge">ILMerge</a> / <a href="https://evain.net/blog/articles/2006/11/06/an-introduction-to-mono-merge">Mono.Merge</a>.<para/>The former being closed-source (<a href="https://github.com/Microsoft/ILMerge">now open-sourced</a>), impossible to customize, slow, resource consuming and many more. The later being deprecated, unsupported, and based on an old version of Mono.Cecil.<para/>Here we're using latest (slightly modified) Cecil sources (0.9), you can find the fork <a href="https://github.com/gluck/cecil">here</a>. Mono.Posix is also required (build only, it gets merged afterwards) for executable bit set on target file.</p>
        ///   <p>For more details, visit the <a href="https://github.com/gluck/il-repack#readme">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> ILRepack(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(ILRepackPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? ILRepackLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>ILRepack is meant at replacing <a href="https://github.com/dotnet/ILMerge">ILMerge</a> / <a href="https://evain.net/blog/articles/2006/11/06/an-introduction-to-mono-merge">Mono.Merge</a>.<para/>The former being closed-source (<a href="https://github.com/Microsoft/ILMerge">now open-sourced</a>), impossible to customize, slow, resource consuming and many more. The later being deprecated, unsupported, and based on an old version of Mono.Cecil.<para/>Here we're using latest (slightly modified) Cecil sources (0.9), you can find the fork <a href="https://github.com/gluck/cecil">here</a>. Mono.Posix is also required (build only, it gets merged afterwards) for executable bit set on target file.</p>
        ///   <p>For more details, visit the <a href="https://github.com/gluck/il-repack#readme">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assemblies&gt;</c> via <see cref="ILRepackSettings.Assemblies"/></li>
        ///     <li><c>--allowdup</c> via <see cref="ILRepackSettings.AllowDuplicate"/></li>
        ///     <li><c>--allowduplicateresources</c> via <see cref="ILRepackSettings.AllowDuplicateResources"/></li>
        ///     <li><c>--allowMultiple</c> via <see cref="ILRepackSettings.AllowMultiple"/></li>
        ///     <li><c>--attr</c> via <see cref="ILRepackSettings.Attr"/></li>
        ///     <li><c>--copyattrs</c> via <see cref="ILRepackSettings.CopyAttributes"/></li>
        ///     <li><c>--delaysign</c> via <see cref="ILRepackSettings.DelaySign"/></li>
        ///     <li><c>--internalize</c> via <see cref="ILRepackSettings.Internalize"/></li>
        ///     <li><c>--internalize</c> via <see cref="ILRepackSettings.InternalizeExcludeFile"/></li>
        ///     <li><c>--keycontainer</c> via <see cref="ILRepackSettings.KeyContainer"/></li>
        ///     <li><c>--keyfile</c> via <see cref="ILRepackSettings.KeyFile"/></li>
        ///     <li><c>--lib</c> via <see cref="ILRepackSettings.Lib"/></li>
        ///     <li><c>--log</c> via <see cref="ILRepackSettings.LogFile"/></li>
        ///     <li><c>--ndebug</c> via <see cref="ILRepackSettings.NoDebug"/></li>
        ///     <li><c>--out</c> via <see cref="ILRepackSettings.Output"/></li>
        ///     <li><c>--parallel</c> via <see cref="ILRepackSettings.Parallel"/></li>
        ///     <li><c>--pause</c> via <see cref="ILRepackSettings.Pause"/></li>
        ///     <li><c>--renameInternalized</c> via <see cref="ILRepackSettings.RenameInternalized"/></li>
        ///     <li><c>--repackdrop:AttributeClass</c> via <see cref="ILRepackSettings.RepackDrop"/></li>
        ///     <li><c>--target</c> via <see cref="ILRepackSettings.Target"/></li>
        ///     <li><c>--targetplatform</c> via <see cref="ILRepackSettings.TargetPlatform"/></li>
        ///     <li><c>--union</c> via <see cref="ILRepackSettings.Union"/></li>
        ///     <li><c>--ver</c> via <see cref="ILRepackSettings.Version"/></li>
        ///     <li><c>--verbose</c> via <see cref="ILRepackSettings.Verbose"/></li>
        ///     <li><c>--wildcards</c> via <see cref="ILRepackSettings.Wildcards"/></li>
        ///     <li><c>--xmldocs</c> via <see cref="ILRepackSettings.Xmldocs"/></li>
        ///     <li><c>--zeropekind</c> via <see cref="ILRepackSettings.ZeroPekind"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ILRepack(ILRepackSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new ILRepackSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            process.AssertZeroExitCode();
            return process.Output;
        }
        /// <summary>
        ///   <p>ILRepack is meant at replacing <a href="https://github.com/dotnet/ILMerge">ILMerge</a> / <a href="https://evain.net/blog/articles/2006/11/06/an-introduction-to-mono-merge">Mono.Merge</a>.<para/>The former being closed-source (<a href="https://github.com/Microsoft/ILMerge">now open-sourced</a>), impossible to customize, slow, resource consuming and many more. The later being deprecated, unsupported, and based on an old version of Mono.Cecil.<para/>Here we're using latest (slightly modified) Cecil sources (0.9), you can find the fork <a href="https://github.com/gluck/cecil">here</a>. Mono.Posix is also required (build only, it gets merged afterwards) for executable bit set on target file.</p>
        ///   <p>For more details, visit the <a href="https://github.com/gluck/il-repack#readme">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assemblies&gt;</c> via <see cref="ILRepackSettings.Assemblies"/></li>
        ///     <li><c>--allowdup</c> via <see cref="ILRepackSettings.AllowDuplicate"/></li>
        ///     <li><c>--allowduplicateresources</c> via <see cref="ILRepackSettings.AllowDuplicateResources"/></li>
        ///     <li><c>--allowMultiple</c> via <see cref="ILRepackSettings.AllowMultiple"/></li>
        ///     <li><c>--attr</c> via <see cref="ILRepackSettings.Attr"/></li>
        ///     <li><c>--copyattrs</c> via <see cref="ILRepackSettings.CopyAttributes"/></li>
        ///     <li><c>--delaysign</c> via <see cref="ILRepackSettings.DelaySign"/></li>
        ///     <li><c>--internalize</c> via <see cref="ILRepackSettings.Internalize"/></li>
        ///     <li><c>--internalize</c> via <see cref="ILRepackSettings.InternalizeExcludeFile"/></li>
        ///     <li><c>--keycontainer</c> via <see cref="ILRepackSettings.KeyContainer"/></li>
        ///     <li><c>--keyfile</c> via <see cref="ILRepackSettings.KeyFile"/></li>
        ///     <li><c>--lib</c> via <see cref="ILRepackSettings.Lib"/></li>
        ///     <li><c>--log</c> via <see cref="ILRepackSettings.LogFile"/></li>
        ///     <li><c>--ndebug</c> via <see cref="ILRepackSettings.NoDebug"/></li>
        ///     <li><c>--out</c> via <see cref="ILRepackSettings.Output"/></li>
        ///     <li><c>--parallel</c> via <see cref="ILRepackSettings.Parallel"/></li>
        ///     <li><c>--pause</c> via <see cref="ILRepackSettings.Pause"/></li>
        ///     <li><c>--renameInternalized</c> via <see cref="ILRepackSettings.RenameInternalized"/></li>
        ///     <li><c>--repackdrop:AttributeClass</c> via <see cref="ILRepackSettings.RepackDrop"/></li>
        ///     <li><c>--target</c> via <see cref="ILRepackSettings.Target"/></li>
        ///     <li><c>--targetplatform</c> via <see cref="ILRepackSettings.TargetPlatform"/></li>
        ///     <li><c>--union</c> via <see cref="ILRepackSettings.Union"/></li>
        ///     <li><c>--ver</c> via <see cref="ILRepackSettings.Version"/></li>
        ///     <li><c>--verbose</c> via <see cref="ILRepackSettings.Verbose"/></li>
        ///     <li><c>--wildcards</c> via <see cref="ILRepackSettings.Wildcards"/></li>
        ///     <li><c>--xmldocs</c> via <see cref="ILRepackSettings.Xmldocs"/></li>
        ///     <li><c>--zeropekind</c> via <see cref="ILRepackSettings.ZeroPekind"/></li>
        ///   </ul>
        /// </remarks>
        public static IReadOnlyCollection<Output> ILRepack(Configure<ILRepackSettings> configurator)
        {
            return ILRepack(configurator(new ILRepackSettings()));
        }
        /// <summary>
        ///   <p>ILRepack is meant at replacing <a href="https://github.com/dotnet/ILMerge">ILMerge</a> / <a href="https://evain.net/blog/articles/2006/11/06/an-introduction-to-mono-merge">Mono.Merge</a>.<para/>The former being closed-source (<a href="https://github.com/Microsoft/ILMerge">now open-sourced</a>), impossible to customize, slow, resource consuming and many more. The later being deprecated, unsupported, and based on an old version of Mono.Cecil.<para/>Here we're using latest (slightly modified) Cecil sources (0.9), you can find the fork <a href="https://github.com/gluck/cecil">here</a>. Mono.Posix is also required (build only, it gets merged afterwards) for executable bit set on target file.</p>
        ///   <p>For more details, visit the <a href="https://github.com/gluck/il-repack#readme">official website</a>.</p>
        /// </summary>
        /// <remarks>
        ///   <p>This is a <a href="http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis">CLI wrapper with fluent API</a> that allows to modify the following arguments:</p>
        ///   <ul>
        ///     <li><c>&lt;assemblies&gt;</c> via <see cref="ILRepackSettings.Assemblies"/></li>
        ///     <li><c>--allowdup</c> via <see cref="ILRepackSettings.AllowDuplicate"/></li>
        ///     <li><c>--allowduplicateresources</c> via <see cref="ILRepackSettings.AllowDuplicateResources"/></li>
        ///     <li><c>--allowMultiple</c> via <see cref="ILRepackSettings.AllowMultiple"/></li>
        ///     <li><c>--attr</c> via <see cref="ILRepackSettings.Attr"/></li>
        ///     <li><c>--copyattrs</c> via <see cref="ILRepackSettings.CopyAttributes"/></li>
        ///     <li><c>--delaysign</c> via <see cref="ILRepackSettings.DelaySign"/></li>
        ///     <li><c>--internalize</c> via <see cref="ILRepackSettings.Internalize"/></li>
        ///     <li><c>--internalize</c> via <see cref="ILRepackSettings.InternalizeExcludeFile"/></li>
        ///     <li><c>--keycontainer</c> via <see cref="ILRepackSettings.KeyContainer"/></li>
        ///     <li><c>--keyfile</c> via <see cref="ILRepackSettings.KeyFile"/></li>
        ///     <li><c>--lib</c> via <see cref="ILRepackSettings.Lib"/></li>
        ///     <li><c>--log</c> via <see cref="ILRepackSettings.LogFile"/></li>
        ///     <li><c>--ndebug</c> via <see cref="ILRepackSettings.NoDebug"/></li>
        ///     <li><c>--out</c> via <see cref="ILRepackSettings.Output"/></li>
        ///     <li><c>--parallel</c> via <see cref="ILRepackSettings.Parallel"/></li>
        ///     <li><c>--pause</c> via <see cref="ILRepackSettings.Pause"/></li>
        ///     <li><c>--renameInternalized</c> via <see cref="ILRepackSettings.RenameInternalized"/></li>
        ///     <li><c>--repackdrop:AttributeClass</c> via <see cref="ILRepackSettings.RepackDrop"/></li>
        ///     <li><c>--target</c> via <see cref="ILRepackSettings.Target"/></li>
        ///     <li><c>--targetplatform</c> via <see cref="ILRepackSettings.TargetPlatform"/></li>
        ///     <li><c>--union</c> via <see cref="ILRepackSettings.Union"/></li>
        ///     <li><c>--ver</c> via <see cref="ILRepackSettings.Version"/></li>
        ///     <li><c>--verbose</c> via <see cref="ILRepackSettings.Verbose"/></li>
        ///     <li><c>--wildcards</c> via <see cref="ILRepackSettings.Wildcards"/></li>
        ///     <li><c>--xmldocs</c> via <see cref="ILRepackSettings.Xmldocs"/></li>
        ///     <li><c>--zeropekind</c> via <see cref="ILRepackSettings.ZeroPekind"/></li>
        ///   </ul>
        /// </remarks>
        public static IEnumerable<(ILRepackSettings Settings, IReadOnlyCollection<Output> Output)> ILRepack(CombinatorialConfigure<ILRepackSettings> configurator, int degreeOfParallelism = 1, bool completeOnFailure = false)
        {
            return configurator.Invoke(ILRepack, ILRepackLogger, degreeOfParallelism, completeOnFailure);
        }
    }
    #region ILRepackSettings
    /// <summary>
    ///   Used within <see cref="ILRepackTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public partial class ILRepackSettings : ToolSettings
    {
        /// <summary>
        ///   Path to the ILRepack executable.
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? ILRepackTasks.ILRepackPath;
        public override Action<OutputType, string> ProcessCustomLogger => base.ProcessCustomLogger ?? ILRepackTasks.ILRepackLogger;
        /// <summary>
        ///   Specifies a keyfile to sign the output assembly.
        /// </summary>
        public virtual string KeyFile { get; internal set; }
        /// <summary>
        ///   Specifies a key container to sign the output assembly (takes precedence over <c>--keyfile</c>).
        /// </summary>
        public virtual string KeyContainer { get; internal set; }
        /// <summary>
        ///   Enable logging (to a file, if given) (default is disabled).
        /// </summary>
        public virtual string LogFile { get; internal set; }
        /// <summary>
        ///   Target assembly version.
        /// </summary>
        public virtual string Version { get; internal set; }
        /// <summary>
        ///   Merges types with identical names into one.
        /// </summary>
        public virtual bool? Union { get; internal set; }
        /// <summary>
        ///   Disables symbol file generation.
        /// </summary>
        public virtual bool? NoDebug { get; internal set; }
        /// <summary>
        ///   Copy assembly attributes (by default only the primary assembly attributes are copied).
        /// </summary>
        public virtual bool? CopyAttributes { get; internal set; }
        /// <summary>
        ///   Take assembly attributes from the given assembly file.
        /// </summary>
        public virtual string Attr { get; internal set; }
        /// <summary>
        ///   When <c>--copyattrs</c> is specified, allows multiple attributes (if type allows).
        /// </summary>
        public virtual bool? AllowMultiple { get; internal set; }
        /// <summary>
        ///   Specify target assembly kind (<c>library</c>, <c>exe</c>, <c>winexe</c> supported, default is same as first assembly).
        /// </summary>
        public virtual ILRepackTarget Target { get; internal set; }
        /// <summary>
        ///   Specify target platform (v1, v1.1, v2, v4 supported).
        /// </summary>
        public virtual string TargetPlatform { get; internal set; }
        /// <summary>
        ///   Merges XML documentation as well.
        /// </summary>
        public virtual bool? Xmldocs { get; internal set; }
        /// <summary>
        ///   Adds the path to the search directories for referenced assemblies (can be specified multiple times).
        /// </summary>
        public virtual string Lib { get; internal set; }
        /// <summary>
        ///   Sets all types but the ones from the first assembly <c>internal</c>.
        /// </summary>
        public virtual bool? Internalize { get; internal set; }
        /// <summary>
        ///   Exclude file contains one regex per line to compare against fullname of types NOT to internalize.
        /// </summary>
        public virtual string InternalizeExcludeFile { get; internal set; }
        /// <summary>
        ///   Rename all internalized types.
        /// </summary>
        public virtual bool? RenameInternalized { get; internal set; }
        /// <summary>
        ///   Sets the key, but don't sign the assembly.
        /// </summary>
        public virtual bool? DelaySign { get; internal set; }
        /// <summary>
        ///   Allows the specified type for being duplicated in input assemblies.
        /// </summary>
        public virtual IReadOnlyList<string> AllowDuplicate => AllowDuplicateInternal.AsReadOnly();
        internal List<string> AllowDuplicateInternal { get; set; } = new List<string>();
        /// <summary>
        ///   Allows to duplicate resources in output assembly (by default they're ignored).
        /// </summary>
        public virtual bool? AllowDuplicateResources { get; internal set; }
        /// <summary>
        ///   Allows assemblies with Zero <c>PeKind</c> (but obviously only IL will get merged).
        /// </summary>
        public virtual bool? ZeroPekind { get; internal set; }
        /// <summary>
        ///   Allows (and resolves) file wildcards (e.g. <c>*.dll</c>) in input assemblies.
        /// </summary>
        public virtual bool? Wildcards { get; internal set; }
        /// <summary>
        ///   Use as many CPUs as possible to merge the assemblies.
        /// </summary>
        public virtual bool? Parallel { get; internal set; }
        /// <summary>
        ///   Pause execution once completed (good for debugging).
        /// </summary>
        public virtual bool? Pause { get; internal set; }
        /// <summary>
        ///   Allows dropping specific members during merging (<a href="https://github.com/gluck/il-repack/issues/215">#215</a>).
        /// </summary>
        public virtual bool? RepackDrop { get; internal set; }
        /// <summary>
        ///   Shows more logs.
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///   Target assembly path, <c>symbol/config/doc</c> files will be written here as well.
        /// </summary>
        public virtual string Output { get; internal set; }
        /// <summary>
        ///   Primary and other assemblies to be merged.
        /// </summary>
        public virtual IReadOnlyList<string> Assemblies => AssembliesInternal.AsReadOnly();
        internal List<string> AssembliesInternal { get; set; } = new List<string>();
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
              .Add("--keyfile:{value}", KeyFile)
              .Add("--keycontainer:{value}", KeyContainer)
              .Add("--log:{value}", LogFile)
              .Add("--ver:{value}", Version)
              .Add("--union", Union)
              .Add("--ndebug", NoDebug)
              .Add("--copyattrs", CopyAttributes)
              .Add("--attr:{value}", Attr)
              .Add("--allowMultiple", AllowMultiple)
              .Add("--target:{value}", Target)
              .Add("--targetplatform:{value}", TargetPlatform)
              .Add("--xmldocs", Xmldocs)
              .Add("--lib:{value}", Lib)
              .Add("--internalize", Internalize)
              .Add("--internalize:{value}", InternalizeExcludeFile)
              .Add("--renameInternalized", RenameInternalized)
              .Add("--delaysign", DelaySign)
              .Add("--allowdup:{value}", AllowDuplicate)
              .Add("--allowduplicateresources", AllowDuplicateResources)
              .Add("--zeropekind", ZeroPekind)
              .Add("--wildcards", Wildcards)
              .Add("--parallel", Parallel)
              .Add("--pause", Pause)
              .Add("--repackdrop:AttributeClass", RepackDrop)
              .Add("--verbose", Verbose)
              .Add("--out:{value}", Output)
              .Add("{value}", Assemblies);
            return base.ConfigureProcessArguments(arguments);
        }
    }
    #endregion
    #region ILRepackSettingsExtensions
    /// <summary>
    ///   Used within <see cref="ILRepackTasks"/>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class ILRepackSettingsExtensions
    {
        #region KeyFile
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.KeyFile"/></em></p>
        ///   <p>Specifies a keyfile to sign the output assembly.</p>
        /// </summary>
        [Pure]
        public static T SetKeyFile<T>(this T toolSettings, string keyFile) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = keyFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.KeyFile"/></em></p>
        ///   <p>Specifies a keyfile to sign the output assembly.</p>
        /// </summary>
        [Pure]
        public static T ResetKeyFile<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyFile = null;
            return toolSettings;
        }
        #endregion
        #region KeyContainer
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.KeyContainer"/></em></p>
        ///   <p>Specifies a key container to sign the output assembly (takes precedence over <c>--keyfile</c>).</p>
        /// </summary>
        [Pure]
        public static T SetKeyContainer<T>(this T toolSettings, string keyContainer) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyContainer = keyContainer;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.KeyContainer"/></em></p>
        ///   <p>Specifies a key container to sign the output assembly (takes precedence over <c>--keyfile</c>).</p>
        /// </summary>
        [Pure]
        public static T ResetKeyContainer<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.KeyContainer = null;
            return toolSettings;
        }
        #endregion
        #region LogFile
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.LogFile"/></em></p>
        ///   <p>Enable logging (to a file, if given) (default is disabled).</p>
        /// </summary>
        [Pure]
        public static T SetLogFile<T>(this T toolSettings, string logFile) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = logFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.LogFile"/></em></p>
        ///   <p>Enable logging (to a file, if given) (default is disabled).</p>
        /// </summary>
        [Pure]
        public static T ResetLogFile<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.LogFile = null;
            return toolSettings;
        }
        #endregion
        #region Version
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Version"/></em></p>
        ///   <p>Target assembly version.</p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = version;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.Version"/></em></p>
        ///   <p>Target assembly version.</p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Version = null;
            return toolSettings;
        }
        #endregion
        #region Union
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Union"/></em></p>
        ///   <p>Merges types with identical names into one.</p>
        /// </summary>
        [Pure]
        public static T SetUnion<T>(this T toolSettings, bool? union) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Union = union;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.Union"/></em></p>
        ///   <p>Merges types with identical names into one.</p>
        /// </summary>
        [Pure]
        public static T ResetUnion<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Union = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.Union"/></em></p>
        ///   <p>Merges types with identical names into one.</p>
        /// </summary>
        [Pure]
        public static T EnableUnion<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Union = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.Union"/></em></p>
        ///   <p>Merges types with identical names into one.</p>
        /// </summary>
        [Pure]
        public static T DisableUnion<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Union = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.Union"/></em></p>
        ///   <p>Merges types with identical names into one.</p>
        /// </summary>
        [Pure]
        public static T ToggleUnion<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Union = !toolSettings.Union;
            return toolSettings;
        }
        #endregion
        #region NoDebug
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.NoDebug"/></em></p>
        ///   <p>Disables symbol file generation.</p>
        /// </summary>
        [Pure]
        public static T SetNoDebug<T>(this T toolSettings, bool? noDebug) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDebug = noDebug;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.NoDebug"/></em></p>
        ///   <p>Disables symbol file generation.</p>
        /// </summary>
        [Pure]
        public static T ResetNoDebug<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDebug = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.NoDebug"/></em></p>
        ///   <p>Disables symbol file generation.</p>
        /// </summary>
        [Pure]
        public static T EnableNoDebug<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDebug = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.NoDebug"/></em></p>
        ///   <p>Disables symbol file generation.</p>
        /// </summary>
        [Pure]
        public static T DisableNoDebug<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDebug = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.NoDebug"/></em></p>
        ///   <p>Disables symbol file generation.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoDebug<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoDebug = !toolSettings.NoDebug;
            return toolSettings;
        }
        #endregion
        #region CopyAttributes
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.CopyAttributes"/></em></p>
        ///   <p>Copy assembly attributes (by default only the primary assembly attributes are copied).</p>
        /// </summary>
        [Pure]
        public static T SetCopyAttributes<T>(this T toolSettings, bool? copyAttributes) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CopyAttributes = copyAttributes;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.CopyAttributes"/></em></p>
        ///   <p>Copy assembly attributes (by default only the primary assembly attributes are copied).</p>
        /// </summary>
        [Pure]
        public static T ResetCopyAttributes<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CopyAttributes = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.CopyAttributes"/></em></p>
        ///   <p>Copy assembly attributes (by default only the primary assembly attributes are copied).</p>
        /// </summary>
        [Pure]
        public static T EnableCopyAttributes<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CopyAttributes = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.CopyAttributes"/></em></p>
        ///   <p>Copy assembly attributes (by default only the primary assembly attributes are copied).</p>
        /// </summary>
        [Pure]
        public static T DisableCopyAttributes<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CopyAttributes = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.CopyAttributes"/></em></p>
        ///   <p>Copy assembly attributes (by default only the primary assembly attributes are copied).</p>
        /// </summary>
        [Pure]
        public static T ToggleCopyAttributes<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.CopyAttributes = !toolSettings.CopyAttributes;
            return toolSettings;
        }
        #endregion
        #region Attr
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Attr"/></em></p>
        ///   <p>Take assembly attributes from the given assembly file.</p>
        /// </summary>
        [Pure]
        public static T SetAttr<T>(this T toolSettings, string attr) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Attr = attr;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.Attr"/></em></p>
        ///   <p>Take assembly attributes from the given assembly file.</p>
        /// </summary>
        [Pure]
        public static T ResetAttr<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Attr = null;
            return toolSettings;
        }
        #endregion
        #region AllowMultiple
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.AllowMultiple"/></em></p>
        ///   <p>When <c>--copyattrs</c> is specified, allows multiple attributes (if type allows).</p>
        /// </summary>
        [Pure]
        public static T SetAllowMultiple<T>(this T toolSettings, bool? allowMultiple) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowMultiple = allowMultiple;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.AllowMultiple"/></em></p>
        ///   <p>When <c>--copyattrs</c> is specified, allows multiple attributes (if type allows).</p>
        /// </summary>
        [Pure]
        public static T ResetAllowMultiple<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowMultiple = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.AllowMultiple"/></em></p>
        ///   <p>When <c>--copyattrs</c> is specified, allows multiple attributes (if type allows).</p>
        /// </summary>
        [Pure]
        public static T EnableAllowMultiple<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowMultiple = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.AllowMultiple"/></em></p>
        ///   <p>When <c>--copyattrs</c> is specified, allows multiple attributes (if type allows).</p>
        /// </summary>
        [Pure]
        public static T DisableAllowMultiple<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowMultiple = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.AllowMultiple"/></em></p>
        ///   <p>When <c>--copyattrs</c> is specified, allows multiple attributes (if type allows).</p>
        /// </summary>
        [Pure]
        public static T ToggleAllowMultiple<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowMultiple = !toolSettings.AllowMultiple;
            return toolSettings;
        }
        #endregion
        #region Target
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Target"/></em></p>
        ///   <p>Specify target assembly kind (<c>library</c>, <c>exe</c>, <c>winexe</c> supported, default is same as first assembly).</p>
        /// </summary>
        [Pure]
        public static T SetTarget<T>(this T toolSettings, ILRepackTarget target) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Target = target;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.Target"/></em></p>
        ///   <p>Specify target assembly kind (<c>library</c>, <c>exe</c>, <c>winexe</c> supported, default is same as first assembly).</p>
        /// </summary>
        [Pure]
        public static T ResetTarget<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Target = null;
            return toolSettings;
        }
        #endregion
        #region TargetPlatform
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.TargetPlatform"/></em></p>
        ///   <p>Specify target platform (v1, v1.1, v2, v4 supported).</p>
        /// </summary>
        [Pure]
        public static T SetTargetPlatform<T>(this T toolSettings, string targetPlatform) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPlatform = targetPlatform;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.TargetPlatform"/></em></p>
        ///   <p>Specify target platform (v1, v1.1, v2, v4 supported).</p>
        /// </summary>
        [Pure]
        public static T ResetTargetPlatform<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetPlatform = null;
            return toolSettings;
        }
        #endregion
        #region Xmldocs
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Xmldocs"/></em></p>
        ///   <p>Merges XML documentation as well.</p>
        /// </summary>
        [Pure]
        public static T SetXmldocs<T>(this T toolSettings, bool? xmldocs) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Xmldocs = xmldocs;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.Xmldocs"/></em></p>
        ///   <p>Merges XML documentation as well.</p>
        /// </summary>
        [Pure]
        public static T ResetXmldocs<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Xmldocs = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.Xmldocs"/></em></p>
        ///   <p>Merges XML documentation as well.</p>
        /// </summary>
        [Pure]
        public static T EnableXmldocs<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Xmldocs = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.Xmldocs"/></em></p>
        ///   <p>Merges XML documentation as well.</p>
        /// </summary>
        [Pure]
        public static T DisableXmldocs<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Xmldocs = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.Xmldocs"/></em></p>
        ///   <p>Merges XML documentation as well.</p>
        /// </summary>
        [Pure]
        public static T ToggleXmldocs<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Xmldocs = !toolSettings.Xmldocs;
            return toolSettings;
        }
        #endregion
        #region Lib
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Lib"/></em></p>
        ///   <p>Adds the path to the search directories for referenced assemblies (can be specified multiple times).</p>
        /// </summary>
        [Pure]
        public static T SetLib<T>(this T toolSettings, string lib) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lib = lib;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.Lib"/></em></p>
        ///   <p>Adds the path to the search directories for referenced assemblies (can be specified multiple times).</p>
        /// </summary>
        [Pure]
        public static T ResetLib<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Lib = null;
            return toolSettings;
        }
        #endregion
        #region Internalize
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Internalize"/></em></p>
        ///   <p>Sets all types but the ones from the first assembly <c>internal</c>.</p>
        /// </summary>
        [Pure]
        public static T SetInternalize<T>(this T toolSettings, bool? internalize) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Internalize = internalize;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.Internalize"/></em></p>
        ///   <p>Sets all types but the ones from the first assembly <c>internal</c>.</p>
        /// </summary>
        [Pure]
        public static T ResetInternalize<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Internalize = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.Internalize"/></em></p>
        ///   <p>Sets all types but the ones from the first assembly <c>internal</c>.</p>
        /// </summary>
        [Pure]
        public static T EnableInternalize<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Internalize = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.Internalize"/></em></p>
        ///   <p>Sets all types but the ones from the first assembly <c>internal</c>.</p>
        /// </summary>
        [Pure]
        public static T DisableInternalize<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Internalize = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.Internalize"/></em></p>
        ///   <p>Sets all types but the ones from the first assembly <c>internal</c>.</p>
        /// </summary>
        [Pure]
        public static T ToggleInternalize<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Internalize = !toolSettings.Internalize;
            return toolSettings;
        }
        #endregion
        #region InternalizeExcludeFile
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.InternalizeExcludeFile"/></em></p>
        ///   <p>Exclude file contains one regex per line to compare against fullname of types NOT to internalize.</p>
        /// </summary>
        [Pure]
        public static T SetInternalizeExcludeFile<T>(this T toolSettings, string internalizeExcludeFile) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InternalizeExcludeFile = internalizeExcludeFile;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.InternalizeExcludeFile"/></em></p>
        ///   <p>Exclude file contains one regex per line to compare against fullname of types NOT to internalize.</p>
        /// </summary>
        [Pure]
        public static T ResetInternalizeExcludeFile<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.InternalizeExcludeFile = null;
            return toolSettings;
        }
        #endregion
        #region RenameInternalized
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.RenameInternalized"/></em></p>
        ///   <p>Rename all internalized types.</p>
        /// </summary>
        [Pure]
        public static T SetRenameInternalized<T>(this T toolSettings, bool? renameInternalized) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenameInternalized = renameInternalized;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.RenameInternalized"/></em></p>
        ///   <p>Rename all internalized types.</p>
        /// </summary>
        [Pure]
        public static T ResetRenameInternalized<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenameInternalized = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.RenameInternalized"/></em></p>
        ///   <p>Rename all internalized types.</p>
        /// </summary>
        [Pure]
        public static T EnableRenameInternalized<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenameInternalized = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.RenameInternalized"/></em></p>
        ///   <p>Rename all internalized types.</p>
        /// </summary>
        [Pure]
        public static T DisableRenameInternalized<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenameInternalized = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.RenameInternalized"/></em></p>
        ///   <p>Rename all internalized types.</p>
        /// </summary>
        [Pure]
        public static T ToggleRenameInternalized<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RenameInternalized = !toolSettings.RenameInternalized;
            return toolSettings;
        }
        #endregion
        #region DelaySign
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.DelaySign"/></em></p>
        ///   <p>Sets the key, but don't sign the assembly.</p>
        /// </summary>
        [Pure]
        public static T SetDelaySign<T>(this T toolSettings, bool? delaySign) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DelaySign = delaySign;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.DelaySign"/></em></p>
        ///   <p>Sets the key, but don't sign the assembly.</p>
        /// </summary>
        [Pure]
        public static T ResetDelaySign<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DelaySign = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.DelaySign"/></em></p>
        ///   <p>Sets the key, but don't sign the assembly.</p>
        /// </summary>
        [Pure]
        public static T EnableDelaySign<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DelaySign = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.DelaySign"/></em></p>
        ///   <p>Sets the key, but don't sign the assembly.</p>
        /// </summary>
        [Pure]
        public static T DisableDelaySign<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DelaySign = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.DelaySign"/></em></p>
        ///   <p>Sets the key, but don't sign the assembly.</p>
        /// </summary>
        [Pure]
        public static T ToggleDelaySign<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DelaySign = !toolSettings.DelaySign;
            return toolSettings;
        }
        #endregion
        #region AllowDuplicate
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.AllowDuplicate"/> to a new list</em></p>
        ///   <p>Allows the specified type for being duplicated in input assemblies.</p>
        /// </summary>
        [Pure]
        public static T SetAllowDuplicate<T>(this T toolSettings, params string[] allowDuplicate) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowDuplicateInternal = allowDuplicate.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.AllowDuplicate"/> to a new list</em></p>
        ///   <p>Allows the specified type for being duplicated in input assemblies.</p>
        /// </summary>
        [Pure]
        public static T SetAllowDuplicate<T>(this T toolSettings, IEnumerable<string> allowDuplicate) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowDuplicateInternal = allowDuplicate.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ILRepackSettings.AllowDuplicate"/></em></p>
        ///   <p>Allows the specified type for being duplicated in input assemblies.</p>
        /// </summary>
        [Pure]
        public static T AddAllowDuplicate<T>(this T toolSettings, params string[] allowDuplicate) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowDuplicateInternal.AddRange(allowDuplicate);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ILRepackSettings.AllowDuplicate"/></em></p>
        ///   <p>Allows the specified type for being duplicated in input assemblies.</p>
        /// </summary>
        [Pure]
        public static T AddAllowDuplicate<T>(this T toolSettings, IEnumerable<string> allowDuplicate) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowDuplicateInternal.AddRange(allowDuplicate);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ILRepackSettings.AllowDuplicate"/></em></p>
        ///   <p>Allows the specified type for being duplicated in input assemblies.</p>
        /// </summary>
        [Pure]
        public static T ClearAllowDuplicate<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowDuplicateInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ILRepackSettings.AllowDuplicate"/></em></p>
        ///   <p>Allows the specified type for being duplicated in input assemblies.</p>
        /// </summary>
        [Pure]
        public static T RemoveAllowDuplicate<T>(this T toolSettings, params string[] allowDuplicate) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(allowDuplicate);
            toolSettings.AllowDuplicateInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ILRepackSettings.AllowDuplicate"/></em></p>
        ///   <p>Allows the specified type for being duplicated in input assemblies.</p>
        /// </summary>
        [Pure]
        public static T RemoveAllowDuplicate<T>(this T toolSettings, IEnumerable<string> allowDuplicate) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(allowDuplicate);
            toolSettings.AllowDuplicateInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
        #region AllowDuplicateResources
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.AllowDuplicateResources"/></em></p>
        ///   <p>Allows to duplicate resources in output assembly (by default they're ignored).</p>
        /// </summary>
        [Pure]
        public static T SetAllowDuplicateResources<T>(this T toolSettings, bool? allowDuplicateResources) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowDuplicateResources = allowDuplicateResources;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.AllowDuplicateResources"/></em></p>
        ///   <p>Allows to duplicate resources in output assembly (by default they're ignored).</p>
        /// </summary>
        [Pure]
        public static T ResetAllowDuplicateResources<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowDuplicateResources = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.AllowDuplicateResources"/></em></p>
        ///   <p>Allows to duplicate resources in output assembly (by default they're ignored).</p>
        /// </summary>
        [Pure]
        public static T EnableAllowDuplicateResources<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowDuplicateResources = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.AllowDuplicateResources"/></em></p>
        ///   <p>Allows to duplicate resources in output assembly (by default they're ignored).</p>
        /// </summary>
        [Pure]
        public static T DisableAllowDuplicateResources<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowDuplicateResources = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.AllowDuplicateResources"/></em></p>
        ///   <p>Allows to duplicate resources in output assembly (by default they're ignored).</p>
        /// </summary>
        [Pure]
        public static T ToggleAllowDuplicateResources<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AllowDuplicateResources = !toolSettings.AllowDuplicateResources;
            return toolSettings;
        }
        #endregion
        #region ZeroPekind
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.ZeroPekind"/></em></p>
        ///   <p>Allows assemblies with Zero <c>PeKind</c> (but obviously only IL will get merged).</p>
        /// </summary>
        [Pure]
        public static T SetZeroPekind<T>(this T toolSettings, bool? zeroPekind) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ZeroPekind = zeroPekind;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.ZeroPekind"/></em></p>
        ///   <p>Allows assemblies with Zero <c>PeKind</c> (but obviously only IL will get merged).</p>
        /// </summary>
        [Pure]
        public static T ResetZeroPekind<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ZeroPekind = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.ZeroPekind"/></em></p>
        ///   <p>Allows assemblies with Zero <c>PeKind</c> (but obviously only IL will get merged).</p>
        /// </summary>
        [Pure]
        public static T EnableZeroPekind<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ZeroPekind = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.ZeroPekind"/></em></p>
        ///   <p>Allows assemblies with Zero <c>PeKind</c> (but obviously only IL will get merged).</p>
        /// </summary>
        [Pure]
        public static T DisableZeroPekind<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ZeroPekind = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.ZeroPekind"/></em></p>
        ///   <p>Allows assemblies with Zero <c>PeKind</c> (but obviously only IL will get merged).</p>
        /// </summary>
        [Pure]
        public static T ToggleZeroPekind<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ZeroPekind = !toolSettings.ZeroPekind;
            return toolSettings;
        }
        #endregion
        #region Wildcards
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Wildcards"/></em></p>
        ///   <p>Allows (and resolves) file wildcards (e.g. <c>*.dll</c>) in input assemblies.</p>
        /// </summary>
        [Pure]
        public static T SetWildcards<T>(this T toolSettings, bool? wildcards) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wildcards = wildcards;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.Wildcards"/></em></p>
        ///   <p>Allows (and resolves) file wildcards (e.g. <c>*.dll</c>) in input assemblies.</p>
        /// </summary>
        [Pure]
        public static T ResetWildcards<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wildcards = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.Wildcards"/></em></p>
        ///   <p>Allows (and resolves) file wildcards (e.g. <c>*.dll</c>) in input assemblies.</p>
        /// </summary>
        [Pure]
        public static T EnableWildcards<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wildcards = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.Wildcards"/></em></p>
        ///   <p>Allows (and resolves) file wildcards (e.g. <c>*.dll</c>) in input assemblies.</p>
        /// </summary>
        [Pure]
        public static T DisableWildcards<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wildcards = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.Wildcards"/></em></p>
        ///   <p>Allows (and resolves) file wildcards (e.g. <c>*.dll</c>) in input assemblies.</p>
        /// </summary>
        [Pure]
        public static T ToggleWildcards<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Wildcards = !toolSettings.Wildcards;
            return toolSettings;
        }
        #endregion
        #region Parallel
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Parallel"/></em></p>
        ///   <p>Use as many CPUs as possible to merge the assemblies.</p>
        /// </summary>
        [Pure]
        public static T SetParallel<T>(this T toolSettings, bool? parallel) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallel = parallel;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.Parallel"/></em></p>
        ///   <p>Use as many CPUs as possible to merge the assemblies.</p>
        /// </summary>
        [Pure]
        public static T ResetParallel<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallel = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.Parallel"/></em></p>
        ///   <p>Use as many CPUs as possible to merge the assemblies.</p>
        /// </summary>
        [Pure]
        public static T EnableParallel<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallel = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.Parallel"/></em></p>
        ///   <p>Use as many CPUs as possible to merge the assemblies.</p>
        /// </summary>
        [Pure]
        public static T DisableParallel<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallel = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.Parallel"/></em></p>
        ///   <p>Use as many CPUs as possible to merge the assemblies.</p>
        /// </summary>
        [Pure]
        public static T ToggleParallel<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Parallel = !toolSettings.Parallel;
            return toolSettings;
        }
        #endregion
        #region Pause
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Pause"/></em></p>
        ///   <p>Pause execution once completed (good for debugging).</p>
        /// </summary>
        [Pure]
        public static T SetPause<T>(this T toolSettings, bool? pause) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = pause;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.Pause"/></em></p>
        ///   <p>Pause execution once completed (good for debugging).</p>
        /// </summary>
        [Pure]
        public static T ResetPause<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.Pause"/></em></p>
        ///   <p>Pause execution once completed (good for debugging).</p>
        /// </summary>
        [Pure]
        public static T EnablePause<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.Pause"/></em></p>
        ///   <p>Pause execution once completed (good for debugging).</p>
        /// </summary>
        [Pure]
        public static T DisablePause<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.Pause"/></em></p>
        ///   <p>Pause execution once completed (good for debugging).</p>
        /// </summary>
        [Pure]
        public static T TogglePause<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Pause = !toolSettings.Pause;
            return toolSettings;
        }
        #endregion
        #region RepackDrop
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.RepackDrop"/></em></p>
        ///   <p>Allows dropping specific members during merging (<a href="https://github.com/gluck/il-repack/issues/215">#215</a>).</p>
        /// </summary>
        [Pure]
        public static T SetRepackDrop<T>(this T toolSettings, bool? repackDrop) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepackDrop = repackDrop;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.RepackDrop"/></em></p>
        ///   <p>Allows dropping specific members during merging (<a href="https://github.com/gluck/il-repack/issues/215">#215</a>).</p>
        /// </summary>
        [Pure]
        public static T ResetRepackDrop<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepackDrop = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.RepackDrop"/></em></p>
        ///   <p>Allows dropping specific members during merging (<a href="https://github.com/gluck/il-repack/issues/215">#215</a>).</p>
        /// </summary>
        [Pure]
        public static T EnableRepackDrop<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepackDrop = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.RepackDrop"/></em></p>
        ///   <p>Allows dropping specific members during merging (<a href="https://github.com/gluck/il-repack/issues/215">#215</a>).</p>
        /// </summary>
        [Pure]
        public static T DisableRepackDrop<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepackDrop = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.RepackDrop"/></em></p>
        ///   <p>Allows dropping specific members during merging (<a href="https://github.com/gluck/il-repack/issues/215">#215</a>).</p>
        /// </summary>
        [Pure]
        public static T ToggleRepackDrop<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.RepackDrop = !toolSettings.RepackDrop;
            return toolSettings;
        }
        #endregion
        #region Verbose
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Verbose"/></em></p>
        ///   <p>Shows more logs.</p>
        /// </summary>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.Verbose"/></em></p>
        ///   <p>Shows more logs.</p>
        /// </summary>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Enables <see cref="ILRepackSettings.Verbose"/></em></p>
        ///   <p>Shows more logs.</p>
        /// </summary>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Disables <see cref="ILRepackSettings.Verbose"/></em></p>
        ///   <p>Shows more logs.</p>
        /// </summary>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Toggles <see cref="ILRepackSettings.Verbose"/></em></p>
        ///   <p>Shows more logs.</p>
        /// </summary>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }
        #endregion
        #region Output
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Output"/></em></p>
        ///   <p>Target assembly path, <c>symbol/config/doc</c> files will be written here as well.</p>
        /// </summary>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, string output) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = output;
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Resets <see cref="ILRepackSettings.Output"/></em></p>
        ///   <p>Target assembly path, <c>symbol/config/doc</c> files will be written here as well.</p>
        /// </summary>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Output = null;
            return toolSettings;
        }
        #endregion
        #region Assemblies
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Assemblies"/> to a new list</em></p>
        ///   <p>Primary and other assemblies to be merged.</p>
        /// </summary>
        [Pure]
        public static T SetAssemblies<T>(this T toolSettings, params string[] assemblies) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal = assemblies.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Sets <see cref="ILRepackSettings.Assemblies"/> to a new list</em></p>
        ///   <p>Primary and other assemblies to be merged.</p>
        /// </summary>
        [Pure]
        public static T SetAssemblies<T>(this T toolSettings, IEnumerable<string> assemblies) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal = assemblies.ToList();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ILRepackSettings.Assemblies"/></em></p>
        ///   <p>Primary and other assemblies to be merged.</p>
        /// </summary>
        [Pure]
        public static T AddAssemblies<T>(this T toolSettings, params string[] assemblies) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal.AddRange(assemblies);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Adds values to <see cref="ILRepackSettings.Assemblies"/></em></p>
        ///   <p>Primary and other assemblies to be merged.</p>
        /// </summary>
        [Pure]
        public static T AddAssemblies<T>(this T toolSettings, IEnumerable<string> assemblies) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal.AddRange(assemblies);
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Clears <see cref="ILRepackSettings.Assemblies"/></em></p>
        ///   <p>Primary and other assemblies to be merged.</p>
        /// </summary>
        [Pure]
        public static T ClearAssemblies<T>(this T toolSettings) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.AssembliesInternal.Clear();
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ILRepackSettings.Assemblies"/></em></p>
        ///   <p>Primary and other assemblies to be merged.</p>
        /// </summary>
        [Pure]
        public static T RemoveAssemblies<T>(this T toolSettings, params string[] assemblies) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assemblies);
            toolSettings.AssembliesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        /// <summary>
        ///   <p><em>Removes values from <see cref="ILRepackSettings.Assemblies"/></em></p>
        ///   <p>Primary and other assemblies to be merged.</p>
        /// </summary>
        [Pure]
        public static T RemoveAssemblies<T>(this T toolSettings, IEnumerable<string> assemblies) where T : ILRepackSettings
        {
            toolSettings = toolSettings.NewInstance();
            var hashSet = new HashSet<string>(assemblies);
            toolSettings.AssembliesInternal.RemoveAll(x => hashSet.Contains(x));
            return toolSettings;
        }
        #endregion
    }
    #endregion
    #region ILRepackTarget
    /// <summary>
    ///   Used within <see cref="ILRepackTasks"/>.
    /// </summary>
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    [TypeConverter(typeof(TypeConverter<ILRepackTarget>))]
    public partial class ILRepackTarget : Enumeration
    {
        public static ILRepackTarget library = (ILRepackTarget) "library";
        public static ILRepackTarget exe = (ILRepackTarget) "exe";
        public static ILRepackTarget winexe = (ILRepackTarget) "winexe";
        public static implicit operator ILRepackTarget(string value)
        {
            return new ILRepackTarget { Value = value };
        }
    }
    #endregion
}
