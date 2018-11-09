// Generated from https://github.com/nuke-build/nuke/blob/master/build/specifications/Git.json
// Generated with Nuke.CodeGeneration version LOCAL (OSX, .NETStandard,Version=v2.0)

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

namespace Nuke.Common.Tools.Git
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static partial class GitTasks
    {
        /// <summary><p>Path to the Git executable.</p></summary>
        public static string GitPath =>
            ToolPathResolver.TryGetEnvironmentExecutable("GIT_EXE") ??
            ToolPathResolver.GetPathExecutable("git");
        /// <summary><p>Git is a <a href="https://git-scm.com/about/free-and-open-source">free and open source</a> distributed version control system designed to handle everything from small to very large projects with speed and efficiency. Git is <a href="https://git-scm.com/documentation">easy to learn</a> and has a <a href="https://git-scm.com/about/small-and-fast">tiny footprint with lightning fast performance</a>. It outclasses SCM tools like Subversion, CVS, Perforce, and ClearCase with features like <a href="https://git-scm.com/about/branching-and-merging">cheap local branching</a>, convenient <a href="https://git-scm.com/about/staging-area">staging areas</a>, and <a href="https://git-scm.com/about/distributed">multiple workflows</a>.</p></summary>
        public static IReadOnlyCollection<Output> Git(string arguments, string workingDirectory = null, IReadOnlyDictionary<string, string> environmentVariables = null, int? timeout = null, bool logOutput = true, Func<string, string> outputFilter = null)
        {
            var process = ProcessTasks.StartProcess(GitPath, arguments, workingDirectory, environmentVariables, timeout, logOutput, null, outputFilter);
            process.AssertZeroExitCode();
            return process.Output;
        }
    }
}
