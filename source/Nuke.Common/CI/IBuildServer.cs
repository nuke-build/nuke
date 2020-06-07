// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;

namespace Nuke.Common.CI
{
    [PublicAPI]
    public interface IBuildServer
    {
        HostType Host { get; }
        public string BuildNumber { get; }
        public string SourceBranch { get; }
        [CanBeNull] public string TargetBranch { get; }
        public AbsolutePath SourceDirectory { get; }
        [CanBeNull] public AbsolutePath OutputDirectory { get; }

        void IssueWarning(string message, string file = null, int? line = null, int? column = null, string code = null);
        void IssueError(string message, string file = null, int? line = null, int? column = null, string code = null);
        void SetEnvironmentVariable(string name, string value);
        void SetOutputParameter(string name, string value);
        void PublishArtifact(AbsolutePath artifactPath);
        void UpdateBuildNumber(string buildNumber);
    }
}
