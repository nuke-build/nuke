// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.OutputSinks;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TeamCity
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class TeamCityOutputSink : AnsiColorOutputSink
    {
        private readonly TeamCity _teamCity;

        public TeamCityOutputSink(TeamCity teamCity)
            : base(
                traceCode: "37",
                informationCode: "36",
                warningCode: "33",
                errorCode: "31",
                successCode: "32")
        {
            _teamCity = teamCity;
        }

        public override IDisposable WriteBlock(string text)
        {
            var stopWatch = new Stopwatch();

            return DelegateDisposable.CreateBracket(
                () =>
                {
                    _teamCity.OpenBlock(text);
                    stopWatch.Start();
                },
                () =>
                {
                    _teamCity.CloseBlock(text);
                    _teamCity.AddStatisticValue(
                        $"NUKE_DURATION_{text.SplitCamelHumpsWithSeparator("_").ToUpper()}",
                        stopWatch.ElapsedMilliseconds.ToString());
                    stopWatch.Stop();
                });
        }
    }
}
