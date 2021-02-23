// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.IO;

namespace Nuke.Common
{
    public interface INukeBuild
    {
        // TODO: add ExitCode
        void ReportSummary(string caption, string text);

        IReadOnlyCollection<ExecutableTarget> InvokedTargets { get; }
        IReadOnlyCollection<ExecutableTarget> SkippedTargets { get; }
        IReadOnlyCollection<ExecutableTarget> ExecutingTargets { get; }

        bool IsSuccessful { get; }

        AbsolutePath RootDirectory { get; }
        AbsolutePath TemporaryDirectory { get; }
        AbsolutePath BuildAssemblyDirectory { get; }
        [CanBeNull] AbsolutePath BuildProjectDirectory { get; }
        [CanBeNull] AbsolutePath BuildProjectFile { get; }

        Verbosity Verbosity { get; }
        Host Host { get; }
        bool Plan { get; }
        bool Help { get; }
        bool NoLogo { get; }
        bool IsLocalBuild {get;}
        bool IsServerBuild {get;}
        LogLevel LogLevel {get;}
        bool Continue { get; }
    }
}
