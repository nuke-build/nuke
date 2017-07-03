// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Core.Utilities;
using Nuke.Core.Utilities.Collections;

namespace Nuke.Core.BuildServers
{
    /// <summary>
    /// Interface according to the <a href="https://confluence.jetbrains.com/display/TCDL/TeamCity+Documentation">official website</a>.
    /// </summary>
    [PublicAPI]
    [BuildServer]
    public class TeamCity
    {
        public static TeamCity Instance { get; } = EnvironmentInfo.Variable("TEAMCITY_VERSION") != null
            ? new TeamCity(Console.WriteLine)
            : null;

        private readonly Action<string> _messageSink;

        private TeamCity (Action<string> messageSink)
        {
            _messageSink = messageSink;
        }

        public string BuildConfiguration => EnvironmentInfo.EnsureVariable("TEAMCITY_BUILDCONF_NAME");
        public string BuildNumber => EnvironmentInfo.EnsureVariable("BUILD_NUMBER");
        public string Version => EnvironmentInfo.EnsureVariable("TEAMCITY_VERSION");
        public string ProjectName => EnvironmentInfo.EnsureVariable("TEAMCITY_PROJECT_NAME");
        public string AgentName => EnvironmentInfo.EnsureVariable("TEAMCITY_AGENT_NAME");

        public void DisableServiceMessages ()
        {
            Write("disableServiceMessages");
        }

        public void EnableServiceMessages ()
        {
            Write("enableServiceMessages");
        }

        public void ImportData (TeamCityImportType type, string path)
        {
            Write("importData", x => x.AddKeyValue("type", type).AddKeyValue("path", path));
        }

        public void AddBuildProblem (string description)
        {
            Write("buildProblem", x => x.AddKeyValue("description", description));
        }

        public void SetBuildStatus (string text, bool prepend = false, bool append = false)
        {
            if (prepend)
                text = $"{text} {{build.status.text}}";
            if (append)
                text = $"{{build.status.text}} {text}";
            Write("buildStatus", x => x.AddKeyValue("text", text));
        }

        public void SetBuildNumber (string number)
        {
            Write("buildNumber", number);
        }

        public void SetParameter (string key, string value)
        {
            Write("setParameter", x => x.AddKeyValue(key, value));
        }

        public void AddStatisticValue (string key, string value)
        {
            Write("buildStatisticValue", x => x.AddKeyValue("key", key).AddKeyValue("value", value));
        }

        public void SetProgress (string text)
        {
            Write("progressMessage", text);
        }

        public void StartProgress (string text)
        {
            Write("progressStart", text);
        }

        public void FinishProgress (string text)
        {
            Write("progressFinish", text);
        }

        public void PublishArtifacts (string path)
        {
            Write("publishArtifacts", path);
        }

        public void OpenBlock (string name, string description = null)
        {
            Write("blockOpened", x => x.AddKeyValue("name", name).AddKeyValue("description", description));
        }

        public void CloseBlock (string name)
        {
            Write("blockClosed", x => x.AddKeyValue("name", name));
        }

        public void StartCompilation (string compiler)
        {
            Write("compilationStarted", x => x.AddKeyValue("compiler", compiler));
        }

        public void FinishCompilation (string compiler)
        {
            Write("compilationFinished", x => x.AddKeyValue("compiler", compiler));
        }

        public void WriteMessage (string text)
        {
            Write("message", x => x.AddKeyValue("text", text).AddKeyValue("status", TeamCityStatus.NORMAL));
        }

        public void WriteWarning (string text)
        {
            Write("message", x => x.AddKeyValue("text", text).AddKeyValue("status", TeamCityStatus.WARNING));
        }

        public void WriteFailure (string text)
        {
            Write("message", x => x.AddKeyValue("text", text).AddKeyValue("status", TeamCityStatus.FAILURE));
        }

        public void WriteError (string text, string errorDetails = null)
        {
            Write("message", x => x.AddKeyValue("text", text).AddKeyValue("status", TeamCityStatus.ERROR).AddKeyValue("errorDetails", errorDetails));
        }

        public void Write (string command, Func<IDictionary<string, object>, IDictionary<string, object>> dictionaryConfigurator)
        {
            Write(new[] { command }.Concat(dictionaryConfigurator(new Dictionary<string, object>())
                    .Where(x => x.Value != null)
                    .Select(x => $"{x.Key}='{Escape(x.Value.ToString())}'")
                    .ToArray()));
        }

        public void Write (string command, params string[] escapedArguments)
        {
            Write(new[] { command }.Concat(escapedArguments.Select(x => x.SingleQuote())));
        }

        public void Write (IEnumerable<string> escapedTokens)
        {
            Write(string.Join(" ", escapedTokens));
        }

        public void Write (string escapedMessage)
        {
            _messageSink($"##teamcity[{escapedMessage}]");
        }

        private string Escape (string str)
        {
            return str.Aggregate(new StringBuilder(), (sb, c) => sb.Append(Escape(c)), sb => sb.ToString());
        }

        private string Escape (char c)
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
