// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotCover;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;

namespace Nuke.Common.CI.TeamCity
{
    /// <summary>
    /// Interface according to the <a href="https://confluence.jetbrains.com/display/TCDL/Build+Script+Interaction+with+TeamCity">official website</a>.
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public partial class TeamCity : Host, IBuildServer
    {
        public new static TeamCity Instance => Host.Instance as TeamCity;

        internal static bool IsRunningTeamCity => EnvironmentInfo.HasVariable("TEAMCITY_VERSION");

        [CanBeNull]
        private static IReadOnlyDictionary<string, string> ParseDictionary([CanBeNull] AbsolutePath file)
        {
            if (file == null)
                return null;

            var lines = file.ReadAllLines();
            var dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            try
            {
                for (var i = 0; i < lines.Length; i++)
                {
                    var line = lines[i]
                        .Replace("\\:", ":")
                        .Replace("\\=", "=")
                        .Replace("\\\\", "\\");
                    if (string.IsNullOrWhiteSpace(line) || line[index: 0] == '#')
                        continue;

                    var index = line.IndexOfRegex(@"[^\.]=") + 1;
                    var key = line.Substring(startIndex: 0, length: index)
                        .Replace("secure:", string.Empty);
                    var value = line.Substring(index + 1);

                    dictionary.Add(key, value);
                }

                return dictionary;
            }
            catch (Exception exception)
            {
                Log.Warning(exception, "Could not parse dictionary from {File}", file);
                return null;
            }
        }

        private readonly Action<string> _messageSink;

        private readonly Lazy<IReadOnlyDictionary<string, string>> _systemProperties;
        private readonly Lazy<IReadOnlyDictionary<string, string>> _configurationProperties;
        private readonly Lazy<IReadOnlyDictionary<string, string>> _runnerProperties;
        private readonly Lazy<IReadOnlyCollection<string>> _recentlyFailedTests;

        internal TeamCity()
            : this(messageSink: null)
        {
        }

        internal TeamCity(Action<string> messageSink)
        {
            _messageSink = messageSink ?? Console.WriteLine;

            _systemProperties = Lazy.Create(() => ParseDictionary(EnvironmentInfo.GetVariable("TEAMCITY_BUILD_PROPERTIES_FILE")));
            _configurationProperties = Lazy.Create(() => ParseDictionary(SystemProperties?["teamcity.configuration.properties.file"]));
            _runnerProperties = Lazy.Create(() => ParseDictionary(SystemProperties?["teamcity.runner.properties.file"]));
            _recentlyFailedTests = Lazy.Create(() =>
            {
                var file = (AbsolutePath) SystemProperties?["teamcity.tests.recentlyFailedTests.file"];
                return file.FileExists()
                    ? file.ReadAllLines().ToImmutableList() as IReadOnlyCollection<string>
                    : new string[0];
            });
        }

        string IBuildServer.Branch => BranchName;
        string IBuildServer.Commit => BuildVcsNumber;

        public IReadOnlyDictionary<string, string> ConfigurationProperties => _configurationProperties.Value;
        public IReadOnlyDictionary<string, string> SystemProperties => _systemProperties.Value;
        public IReadOnlyDictionary<string, string> RunnerProperties => _runnerProperties.Value;
        public IReadOnlyCollection<string> RecentlyFailedTests => _recentlyFailedTests.Value;

        public string BuildConfiguration => SystemProperties?["teamcity.buildConfName"];
        public string BuildTypeId => SystemProperties?["teamcity.buildType.id"];
        [NoConvert] public string BuildNumber => EnvironmentInfo.GetVariable("BUILD_NUMBER");
        public string BuildVcsNumber => SystemProperties?["build.vcs.number"];
        public string Version => SystemProperties?["teamcity.version"];
        public string ProjectName => SystemProperties?["teamcity.projectName"];
        public string ServerUrl => ConfigurationProperties?["teamcity.serverUrl"];
        public string AuthUserId => SystemProperties["teamcity.auth.userId"];
        public string AuthPassword => SystemProperties["teamcity.auth.password"];
        public string ProjectId => ConfigurationProperties?["teamcity.project.id"];
        public long BuildId => long.Parse(ConfigurationProperties?["teamcity.build.id"] ?? 0.ToString());
        public bool IsBuildPersonal => bool.Parse(SystemProperties?.GetValueOrDefault("build.is.personal") ?? bool.FalseString);
        public bool IsPullRequest => ConfigurationProperties?.GetValueOrDefault("teamcity.pullRequest.number") != null;
        [CanBeNull] public long? PullRequestNumber => IsPullRequest ? long.Parse(ConfigurationProperties["teamcity.pullRequest.number"]) : null;
        [CanBeNull] public string PullRequestSourceBranch => IsPullRequest ? ConfigurationProperties["teamcity.pullRequest.source.branch"] : null;
        [CanBeNull] public string PullRequestTargetBranch => IsPullRequest ? ConfigurationProperties["teamcity.pullRequest.target.branch"] : null;
        [CanBeNull] public string PullRequestTitle => IsPullRequest ? ConfigurationProperties["teamcity.pullRequest.title"] : null;

        [NoConvert] public string BranchName => ConfigurationProperties?.GetValueOrDefault("teamcity.build.branch")
            .NotNull("Configuration property 'teamcity.build.branch' is null. See https://youtrack.jetbrains.com/issue/TW-62888.");

        public void DisableServiceMessages()
        {
            Write("disableServiceMessages");
        }

        public void EnableServiceMessages()
        {
            Write("enableServiceMessages");
        }

        public void ImportData(
            TeamCityImportType type,
            string path,
            TeamCityImportTool? tool = null,
            bool? verbose = null,
            bool? parseOutOfDate = null,
            TeamCityNoDataPublishedAction? action = null)
        {
            Assert.True(
                type != TeamCityImportType.dotNetCoverage || tool != null,
                $"Importing data of type '{type}' requires to specify the tool");
            if (tool == TeamCityImportTool.dotcover &&
                ConfigurationProperties["teamcity.dotCover.home"].EndsWithOrdinalIgnoreCase("bundled"))
            {
                Log.Warning("Configuration parameter 'teamcity.dotCover.home' is set to the bundled version." +
                            "Adding the {AttributeName} will automatically set " +
                            $"it to '{nameof(DotCoverTasks)}.{nameof(DotCoverTasks.DotCoverPath)}'",
                    nameof(TeamCitySetDotCoverHomePathAttribute));
            }

            Write("importData",
                x => x
                    .AddPair("type", type)
                    .AddPair("path", path)
                    .AddPairWhenValueNotNull("tool", tool)
                    .AddPairWhenValueNotNull("verbose", verbose)
                    .AddPairWhenValueNotNull("parseOutOfDate", parseOutOfDate)
                    .AddPairWhenValueNotNull("whenNoDataPublished", action));
        }

        public void AddBuildProblem(string description)
        {
            Write("buildProblem", x => x.AddPair("description", description));
        }

        public void SetBuildStatus(string text, bool prepend = false, bool append = false)
        {
            if (prepend)
                text = $"{text} {{build.status.text}}";
            if (append)
                text = $"{{build.status.text}} {text}";
            Write("buildStatus", x => x.AddPair("text", text));
        }

        public void SetBuildNumber(string number)
        {
            Write("buildNumber", number);
            EnvironmentInfo.SetVariable("BUILD_NUMBER", number);
        }

        public void SetConfigurationParameter(string name, string value)
        {
            Write("setParameter", x => x.AddPair("name", name.Replace("_", ".")).AddPair("value", value));
        }

        public void SetEnvironmentVariable(string name, string value)
        {
            Write("setParameter", x => x.AddPair("name", $"env.{name}").AddPair("value", value));
        }

        public void SetSystemProperty(string name, string value)
        {
            Write("setParameter", x => x.AddPair("name", $"system.{name}").AddPair("value", value));
        }

        public void AddStatisticValue(string key, string value)
        {
            Write("buildStatisticValue",
                x => x
                    .AddPair("key", key)
                    .AddPair("value", value));
        }

        public void SetProgress(string text)
        {
            Write("progressMessage", text);
        }

        public void StartProgress(string text)
        {
            Write("progressStart", text);
        }

        public void FinishProgress(string text)
        {
            Write("progressFinish", text);
        }

        public void PublishArtifacts(string path)
        {
            Write("publishArtifacts", path);
        }

        public void OpenBlock(string name, string description = null)
        {
            Write("blockOpened",
                x => x
                    .AddPair("name", name)
                    .AddPairWhenValueNotNull("description", description));
        }

        public void CloseBlock(string name)
        {
            Write("blockClosed", x => x.AddPair("name", name));
        }

        public void StartCompilation(string compiler)
        {
            Write("compilationStarted", x => x.AddPair("compiler", compiler));
        }

        public void FinishCompilation(string compiler)
        {
            Write("compilationFinished", x => x.AddPair("compiler", compiler));
        }

        public void WriteMessage(string text)
        {
            Write("message",
                x => x
                    .AddPair("text", text)
                    .AddPair("status", TeamCityStatus.NORMAL));
        }

        public void WriteWarning(string text)
        {
            Write("message",
                x => x
                    .AddPair("text", text)
                    .AddPair("status", TeamCityStatus.WARNING));
        }

        public void WriteFailure(string text)
        {
            Write("message",
                x => x
                    .AddPair("text", text)
                    .AddPair("status", TeamCityStatus.FAILURE));
        }

        public void WriteError(string text, string errorDetails = null)
        {
            Write("message",
                x => x
                    .AddPair("text", text)
                    .AddPair("status", TeamCityStatus.ERROR)
                    .AddPairWhenValueNotNull("errorDetails", errorDetails));
        }

        public void Write(string command, Func<IDictionary<string, object>, IDictionary<string, object>> dictionaryConfigurator)
        {
            Write(new[] { command }.Concat(dictionaryConfigurator(new Dictionary<string, object>())
                .Select(x => $"{x.Key}='{Escape(x.Value.ToString())}'")
                .ToArray()));
        }

        public void Write(string command, params string[] escapedArguments)
        {
            Write(new[] { command }.Concat(escapedArguments.Select(x => x.SingleQuote())));
        }

        public void Write(IEnumerable<string> escapedTokens)
        {
            Write(string.Join(" ", escapedTokens));
        }

        public void Write(string escapedMessage)
        {
            _messageSink($"##teamcity[{escapedMessage}]");
        }

        private string Escape(string str)
        {
            return str.Aggregate(
                new StringBuilder(),
                (sb, c) => sb.Append(c switch
                {
                    '\n' => "|n",
                    '\'' => "|'",
                    '\r' => "|r",
                    '|' => "||",
                    '[' => "|[",
                    ']' => "|]",
                    _ => c.ToString()
                }),
                sb => sb.ToString());
        }
    }
}
