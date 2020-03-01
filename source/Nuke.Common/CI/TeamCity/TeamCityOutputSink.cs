// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
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
        {
            _teamCity = teamCity;

            Console.OutputEncoding = Encoding.UTF8;
        }

        protected override string TraceCode => "37";
        protected override string InformationCode => "36";
        protected override string WarningCode => "33";
        protected override string ErrorCode => "31";
        protected override string SuccessCode => "32";

        internal override IDisposable WriteBlock(string text)
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

        protected override bool EnableWriteErrors => false;

        protected override void WriteWarning(string text, string details = null)
        {
            _teamCity.WriteWarning(text);
            if (details != null)
                _teamCity.WriteWarning(details);
        }

        protected override void ReportError(string text, string details = null)
        {
            _teamCity.WriteError(text);
            if (details != null)
                _teamCity.WriteError(details);
        }
    }
}
