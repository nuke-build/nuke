// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.BuildServers;
using Nuke.Core.Utilities;

namespace Nuke.Core.OutputSinks
{
    public class TeamCityOutputSink : ConsoleOutputSink
    {
        [CanBeNull]
        public new static IOutputSink Instance { get; } = TeamCity.Instance != null ? new TeamCityOutputSink(TeamCity.Instance) : null;

        private readonly TeamCity _teamCity;

        private TeamCityOutputSink (TeamCity teamCity)
        {
            _teamCity = teamCity;
        }

        public override void Write (string text)
        {
            _teamCity.WriteMessage(text);
        }

        public override IDisposable WriteBlock (string text)
        {
            return DelegateDisposable.CreateBracket(
                () => _teamCity.OpenBlock(text),
                () => _teamCity.CloseBlock(text));
        }

        public override void Trace (string text)
        {
            _teamCity.WriteMessage(text);
        }

        public override void Info (string text)
        {
            _teamCity.WriteMessage(text);
        }

        public override void Warn (string text, string details = null)
        {
            _teamCity.WriteWarning(text);
            if (details != null)
                _teamCity.WriteWarning(details);
        }

        public override void Error (string text, string details = null)
        {
            _teamCity.WriteError(text, details);
            _teamCity.AddBuildProblem(text);
        }
    }
}
