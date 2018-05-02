// ReSharper disable All
#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.BuildServers;
using Nuke.Core.Utilities;

namespace Nuke.Core.OutputSinks
{
    [UsedImplicitly]
    internal class TeamCityOutputSink : ConsoleOutputSink
    {
        private readonly TeamCity _teamCity;

        internal TeamCityOutputSink(TeamCity teamCity)
        {
            _teamCity = teamCity;
        }

        public override void Write(string text)
        {
            _teamCity.WriteMessage(text);
        }

        public override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => _teamCity.OpenBlock(text),
                () => _teamCity.CloseBlock(text));
        }

        public override void Trace(string text)
        {
            _teamCity.WriteMessage(text);
        }

        public override void Info(string text)
        {
            _teamCity.WriteMessage(text);
        }

        public override void Warn(string text, string details = null)
        {
            _teamCity.WriteWarning(text);
            if (details != null)
                _teamCity.WriteWarning(details);
        }

        public override void Error(string text, string details = null)
        {
            _teamCity.WriteError(text, details);
            _teamCity.AddBuildProblem(text);
        }
    }
}
