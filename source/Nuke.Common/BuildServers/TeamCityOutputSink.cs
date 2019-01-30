// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.OutputSinks;
using Nuke.Common.Utilities;

namespace Nuke.Common.BuildServers
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class TeamCityOutputSink : AnsiColorOutputSink
    {
        private readonly TeamCity _teamCity;

        public TeamCityOutputSink(TeamCity teamCity)
            : base(traceCode: "37", informationCode: "36", warningCode: "33", errorCode: "31", successCode: "32")
        {
            _teamCity = teamCity;
        }

        public override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => _teamCity.OpenBlock(text),
                () => _teamCity.CloseBlock(text));
        }
    }
}
