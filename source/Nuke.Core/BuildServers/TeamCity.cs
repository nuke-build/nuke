// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using JetBrains.Annotations;
using Nuke.Core.Utilities;
using Nuke.Core.Utilities.Collections;
using Refit;
using static Nuke.Core.EnvironmentInfo;

namespace Nuke.Core.BuildServers
{
    /// <summary>
    /// Interface according to the <a href="https://confluence.jetbrains.com/display/TCDL/Build+Script+Interaction+with+TeamCity">official website</a>.
    /// </summary>
    [PublicAPI]
    [BuildServer]
    public class TeamCity
    {
        private static Lazy<TeamCity> s_instance = new Lazy<TeamCity>(() => new TeamCity());

        public static TeamCity Instance => NukeBuild.Instance?.Host == HostType.TeamCity ? s_instance.Value : null;

        internal static bool IsRunningTeamCity => Variable("TEAMCITY_VERSION") != null;

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

        private static IReadOnlyDictionary<string, string> ParseDictionary(string file)
        {
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

                var index = line.IndexOf(value: '=');
                var key = line.Substring(startIndex: 0, length: index)
                    .Replace(".", "_")
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
        private readonly Lazy<ITeamCityRestClient> _restClient;

        internal TeamCity()
            : this(messageSink: null)
        {
        }

        internal TeamCity([CanBeNull] Action<string> messageSink)
        {
            _messageSink = messageSink ?? Console.WriteLine;

            _systemProperties = GetLazy(() => ParseDictionary(EnsureVariable("TEAMCITY_BUILD_PROPERTIES_FILE")));
            _configurationProperties = GetLazy(() => ParseDictionary(SystemProperties["TEAMCITY_CONFIGURATION_PROPERTIES_FILE"]));
            _runnerProperties = GetLazy(() => ParseDictionary(SystemProperties["TEAMCITY_RUNNER_PROPERTIES_FILE"]));

            _restClient = GetLazy(() => CreateRestClient<ITeamCityRestClient>());
        }

        public T CreateRestClient<T>()
        {
            return CreateRestClient<T>(ServerUrl, SystemProperties["TEAMCITY_AUTH_USERID"], SystemProperties["TEAMCITY_AUTH_PASSWORD"]);
        }

        public IReadOnlyDictionary<string, string> ConfigurationProperties => _configurationProperties.Value;
        public IReadOnlyDictionary<string, string> SystemProperties => _systemProperties.Value;
        public IReadOnlyDictionary<string, string> RunnerProperties => _runnerProperties.Value;

        public ITeamCityRestClient RestClient => _restClient.Value;

        public string BuildConfiguration => EnsureVariable("TEAMCITY_BUILDCONF_NAME");
        [NoConvert] public string BuildNumber => EnsureVariable("BUILD_NUMBER");
        public string Version => EnsureVariable("TEAMCITY_VERSION");
        public string ProjectName => EnsureVariable("TEAMCITY_PROJECT_NAME");
        public string ServerUrl => ConfigurationProperties["TEAMCITY_SERVERURL"];

        public void DisableServiceMessages()
        {
            Write("disableServiceMessages");
        }

        public void EnableServiceMessages()
        {
            Write("enableServiceMessages");
        }

        public void ImportData(TeamCityImportType type, string path)
        {
            Write("importData", x => x.AddKeyValue("type", type).AddKeyValue("path", path));
        }

        public void AddBuildProblem(string description)
        {
            Write("buildProblem", x => x.AddKeyValue("description", description));
        }

        public void SetBuildStatus(string text, bool prepend = false, bool append = false)
        {
            if (prepend)
                text = $"{text} {{build.status.text}}";
            if (append)
                text = $"{{build.status.text}} {text}";
            Write("buildStatus", x => x.AddKeyValue("text", text));
        }

        public void SetBuildNumber(string number)
        {
            Write("buildNumber", number);
        }

        public void SetParameter(string key, string value)
        {
            Write("setParameter", x => x.AddKeyValue(key, value));
        }

        public void AddStatisticValue(string key, string value)
        {
            Write("buildStatisticValue", x => x.AddKeyValue("key", key).AddKeyValue("value", value));
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
            Write("blockOpened", x => x.AddKeyValue("name", name).AddKeyValue("description", description));
        }

        public void CloseBlock(string name)
        {
            Write("blockClosed", x => x.AddKeyValue("name", name));
        }

        public void StartCompilation(string compiler)
        {
            Write("compilationStarted", x => x.AddKeyValue("compiler", compiler));
        }

        public void FinishCompilation(string compiler)
        {
            Write("compilationFinished", x => x.AddKeyValue("compiler", compiler));
        }

        public void WriteMessage(string text)
        {
            Write("message", x => x.AddKeyValue("text", text).AddKeyValue("status", TeamCityStatus.NORMAL));
        }

        public void WriteWarning(string text)
        {
            Write("message", x => x.AddKeyValue("text", text).AddKeyValue("status", TeamCityStatus.WARNING));
        }

        public void WriteFailure(string text)
        {
            Write("message", x => x.AddKeyValue("text", text).AddKeyValue("status", TeamCityStatus.FAILURE));
        }

        public void WriteError(string text, string errorDetails = null)
        {
            Write("message", x => x.AddKeyValue("text", text).AddKeyValue("status", TeamCityStatus.ERROR).AddKeyValue("errorDetails", errorDetails));
        }

        public void Write(string command, Func<IDictionary<string, object>, IDictionary<string, object>> dictionaryConfigurator)
        {
            Write(new[] { command }.Concat(dictionaryConfigurator(new Dictionary<string, object>())
                .Where(x => x.Value != null)
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
            return str.Aggregate(new StringBuilder(), (sb, c) => sb.Append(Escape(c)), sb => sb.ToString());
        }

        private string Escape(char c)
        {
            switch (c)
            {
                case '\n':
                    return "|n";
                case '\'':
                    return "|'";
                case '\r':
                    return "|r";
                case '|':
                    return "||";
                case '[':
                    return "|[";
                case ']':
                    return "|]";
                default:
                    // TODO: unicode
                    return c.ToString();
            }
        }
    }
}
