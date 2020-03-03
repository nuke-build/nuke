﻿// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Tools.DotCover;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Refit;

namespace Nuke.Common.CI.TeamCity
{
    /// <summary>
    /// Interface according to the <a href="https://confluence.jetbrains.com/display/TCDL/Build+Script+Interaction+with+TeamCity">official website</a>.
    /// </summary>
    [PublicAPI]
    [CI]
    [ExcludeFromCodeCoverage]
    public class TeamCity
    {
        private static Lazy<TeamCity> s_instance = new Lazy<TeamCity>(() => new TeamCity());

        public static TeamCity Instance => NukeBuild.Host == HostType.TeamCity ? s_instance.Value : null;

        internal static bool IsRunningTeamCity => !Environment.GetEnvironmentVariable("TEAMCITY_VERSION").IsNullOrEmpty();

        public static T CreateRestClient<T>(string serverUrl, string username, string password)
        {
            var credentials = new NetworkCredential(username, password);
            var baseAddress = new Uri($"{serverUrl}/app/rest");
            var httpClient = new HttpClient(new HttpClientHandler { Credentials = credentials }) { BaseAddress = baseAddress };

            return RestService.For<T>(httpClient);
        }

        private static Lazy<T> GetLazy<T>(Func<T> provider)
        {
            return new Lazy<T>(provider);
        }

        [CanBeNull]
        private static IReadOnlyDictionary<string, string> ParseDictionary([CanBeNull] string file)
        {
            if (file == null)
                return null;

            var lines = File.ReadAllLines(file);
            var dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i]
                    .Replace("\\:", ":")
                    .Replace("\\=", "=")
                    .Replace("\\\\", "\\");
                if (line[index: 0] == '#' || string.IsNullOrWhiteSpace(line))
                    continue;

                var index = line.IndexOfRegex(@"[^\.]=") + 1;
                var key = line.Substring(startIndex: 0, length: index)
                    .Replace("secure:", string.Empty);
                var value = line.Substring(index + 1);

                dictionary.Add(key, value);
            }

            return dictionary;
        }

        private readonly Action<string> _messageSink;

        private readonly Lazy<IReadOnlyDictionary<string, string>> _systemProperties;
        private readonly Lazy<IReadOnlyDictionary<string, string>> _configurationProperties;
        private readonly Lazy<IReadOnlyDictionary<string, string>> _runnerProperties;
        private readonly Lazy<IReadOnlyCollection<string>> _recentlyFailedTests;
        private readonly Lazy<ITeamCityRestClient> _restClient;

        internal TeamCity(Action<string> messageSink = null)
        {
            _messageSink = messageSink ?? Console.WriteLine;

            _systemProperties = GetLazy(() => ParseDictionary(EnvironmentInfo.GetVariable<string>("TEAMCITY_BUILD_PROPERTIES_FILE")));
            _configurationProperties = GetLazy(() => ParseDictionary(SystemProperties?["teamcity.configuration.properties.file"]));
            _runnerProperties = GetLazy(() => ParseDictionary(SystemProperties?["teamcity.runner.properties.file"]));
            _recentlyFailedTests = GetLazy(() =>
            {
                var file = SystemProperties?["teamcity.tests.recentlyFailedTests.file"];
                return File.Exists(file)
                    ? TextTasks.ReadAllLines(file).ToImmutableList() as IReadOnlyCollection<string>
                    : new string[0];
            });

            _restClient = GetLazy(() => CreateRestClient<ITeamCityRestClient>());
        }

        public T CreateRestClient<T>()
        {
            return CreateRestClient<T>(ServerUrl, SystemProperties["teamcity.auth.userId"], SystemProperties["teamcity.auth.password"]);
        }

        public IReadOnlyDictionary<string, string> ConfigurationProperties => _configurationProperties.Value;
        public IReadOnlyDictionary<string, string> SystemProperties => _systemProperties.Value;
        public IReadOnlyDictionary<string, string> RunnerProperties => _runnerProperties.Value;
        public IReadOnlyCollection<string> RecentlyFailedTests => _recentlyFailedTests.Value;

        public ITeamCityRestClient RestClient => _restClient.Value;

        public string BuildConfiguration => SystemProperties["teamcity.buildConfName"];
        public string BuildTypeId => SystemProperties["teamcity.buildType.id"];
        [NoConvert] public string BuildNumber => SystemProperties["build.number"];
        public string Version => SystemProperties["teamcity.version"];
        public string ProjectName => SystemProperties["teamcity.projectName"];
        public string ServerUrl => ConfigurationProperties["teamcity.serverUrl"];
        [NoConvert] public string BranchName => ConfigurationProperties.GetValueOrDefault("teamcity.build.branch")
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
            ControlFlow.Assert(
                type != TeamCityImportType.dotNetCoverage || tool != null,
                $"Importing data of type '{type}' requires to specify the tool.");
            ControlFlow.AssertWarn(
                tool == TeamCityImportTool.dotcover &&
                ConfigurationProperties["teamcity.dotCover.home"].EndsWithOrdinalIgnoreCase("bundled"),
                new[]
                {
                    "Configuration parameter 'teamcity.dotCover.home' is set to the bundled version.",
                    $"Adding the '{nameof(TeamCitySetDotCoverHomePathAttribute)}' will automatically set " +
                    $"it to '{nameof(DotCoverTasks)}.{nameof(DotCoverTasks.DotCoverPath)}'."
                }.JoinNewLine());

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
