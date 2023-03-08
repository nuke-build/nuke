// Generated from https://github.com/nuke-build/nuke/blob/master/source/Nuke.Common/Tools/Git/Git.json

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

namespace Nuke.Common.Tools.Git
{
    /// <summary>
    ///   <p>Git is a <a href="https://git-scm.com/about/free-and-open-source">free and open source</a> distributed version control system designed to handle everything from small to very large projects with speed and efficiency. Git is <a href="https://git-scm.com/documentation">easy to learn</a> and has a <a href="https://git-scm.com/about/small-and-fast">tiny footprint with lightning fast performance</a>. It outclasses SCM tools like Subversion, CVS, Perforce, and ClearCase with features like <a href="https://git-scm.com/about/branching-and-merging">cheap local branching</a>, convenient <a href="https://git-scm.com/about/staging-area">staging areas</a>, and <a href="https://git-scm.com/about/distributed">multiple workflows</a>.</p>
    ///   <p>For more details, visit the <a href="https://git-scm.com/">official website</a>.</p>
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [PathToolRequirement(GitPathExecutable)]
    public partial class GitTasks
        : IRequirePathTool
    {
        public const string GitPathExecutable = "git";
        /// <summary>
        ///   Path to the Git executable.
        /// </summary>
        public static string GitPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("GIT_EXE") ??
            ToolPathResolver.GetPathExecutable("git");
        public static Action<OutputType, string> GitLogger { get; set; } = ProcessTasks.DefaultLogger;
        /// <summary>
        ///   <p>Git is a <a href="https://git-scm.com/about/free-and-open-source">free and open source</a> distributed version control system designed to handle everything from small to very large projects with speed and efficiency. Git is <a href="https://git-scm.com/documentation">easy to learn</a> and has a <a href="https://git-scm.com/about/small-and-fast">tiny footprint with lightning fast performance</a>. It outclasses SCM tools like Subversion, CVS, Perforce, and ClearCase with features like <a href="https://git-scm.com/about/branching-and-merging">cheap local branching</a>, convenient <a href="https://git-scm.com/about/staging-area">staging areas</a>, and <a href="https://git-scm.com/about/distributed">multiple workflows</a>.</p>
        ///   <p>For more details, visit the <a href="https://git-scm.com/">official website</a>.</p>
        /// </summary>
        public static IReadOnlyCollection<Output> Git(ref ArgumentStringHandler arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool? logOutput = null, bool? logInvocation = null, Action<OutputType, string> customLogger = null)
        {
            using var process = ProcessTasks.StartProcess(GitPath, ref arguments, workingDirectory, environmentVariables, timeout, logOutput, logInvocation, customLogger ?? GitLogger);
            process.AssertZeroExitCode();
            return process.Output;
        }
    }
}
