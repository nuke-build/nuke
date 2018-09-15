// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.BuildServers;
using Nuke.Common.Utilities;

namespace Nuke.Common.OutputSinks
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class TeamCityOutputSink : ConsoleOutputSink
    {
        private readonly TeamCity _teamCity;

        internal TeamCityOutputSink(TeamCity teamCity)
        {
            _teamCity = teamCity;
        }

        public override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => _teamCity.OpenBlock(text),
                () => _teamCity.CloseBlock(text));
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
