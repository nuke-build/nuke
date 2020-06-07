// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Tools.Git;

namespace Nuke.Common.CI
{
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class BuildServer : IBuildServer
    {
        public static BuildServer Instance = NukeBuild.Host switch
        {
            HostType.Bamboo => new BuildServer(Bamboo.Bamboo.Instance),
            HostType.Bitrise => new BuildServer(Bitrise.Bitrise.Instance),
            HostType.Jenkins => new BuildServer(Jenkins.Jenkins.Instance),
            HostType.Travis => new BuildServer(TravisCI.TravisCI.Instance),
            HostType.AppVeyor => new BuildServer(AppVeyor.AppVeyor.Instance),
            HostType.AzurePipelines => new BuildServer(AzurePipelines.AzurePipelines.Instance),
            HostType.GitLab => new BuildServer(GitLab.GitLab.Instance),
            HostType.TeamCity => new BuildServer(TeamCity.TeamCity.Instance),
            HostType.GitHubActions => new BuildServer(GitHubActions.GitHubActions.Instance),
            HostType.Console => new BuildServer(new ConsoleBuildServer()),
            _ => throw new NotSupportedException("HostType is not sulpported!")
        };

        private readonly IBuildServer _buildServer;

        private BuildServer(IBuildServer buildServer)
        {
            _buildServer = buildServer;
        }

        public HostType Host => _buildServer.Host;
        public string BuildNumber => _buildServer.BuildNumber;

        public string SourceBranch => _buildServer.SourceBranch;

        public string TargetBranch => _buildServer.TargetBranch;

        public AbsolutePath SourceDirectory => _buildServer.SourceDirectory;

        public AbsolutePath OutputDirectory => _buildServer.OutputDirectory;

        public void IssueWarning(string message, string file, int? line, int? column, string code)
        {
            _buildServer.IssueWarning(message, file, line, column, code);
        }

        public void IssueError(string message, string file, int? line, int? column, string code)
        {
            _buildServer.IssueError(message, file, line, column, code);
        }

        public void SetEnvironmentVariable(string name, string value)
        {
            _buildServer.SetEnvironmentVariable(name, value);
        }

        public void SetOutputParameter(string name, string value)
        {
            _buildServer.SetOutputParameter(name, value);
        }

        public void PublishArtifact(AbsolutePath artifactPath)
        {
            _buildServer.PublishArtifact(artifactPath);
        }

        public void UpdateBuildNumber(string buildNumber)
        {
            _buildServer.UpdateBuildNumber(buildNumber);
        }

        class ConsoleBuildServer : IBuildServer
        {
            HostType IBuildServer.Host => HostType.Console;
            string IBuildServer.BuildNumber => "local";
            string IBuildServer.SourceBranch => GitTasks.GitCurrentBranch();
            string IBuildServer.TargetBranch => null;
            AbsolutePath IBuildServer.SourceDirectory => NukeBuild.RootDirectory;
            AbsolutePath IBuildServer.OutputDirectory => null;

            void IBuildServer.IssueWarning(string message, string file, int? line, int? column, string code)
            {
                Logger.Warn(message);
            }

            void IBuildServer.IssueError(string message, string file, int? line, int? column, string code)
            {
                Logger.Error(message);
            }

            void IBuildServer.SetEnvironmentVariable(string name, string value)
            {
            }

            void IBuildServer.SetOutputParameter(string name, string value)
            {
            }

            void IBuildServer.PublishArtifact(AbsolutePath artifactPath)
            {
            }

            void IBuildServer.UpdateBuildNumber(string buildNumber)
            {
            }
        }
    }
}
