// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core.BuildServers;
using Nuke.Core.Utilities;

namespace Nuke.Core.OutputSinks
{
    public class TeamServicesOutputSink : ConsoleOutputSink
    {
        public new static IOutputSink Instance { get; } = TeamServices.Instance != null ? new TeamServicesOutputSink(TeamServices.Instance) : null;

        private readonly TeamServices _teamServices;

        private TeamServicesOutputSink(TeamServices teamServices)
        {
            _teamServices = teamServices;
        }

        public override void Warn (string text, string details = null)
        {
            _teamServices.LogIssue(TeamServicesIssueType.Warning, text);
            if (details != null)
                Console.WriteLine(details);
        }

        public override void Error (string text, string details = null)
        {
            _teamServices.LogIssue(TeamServicesIssueType.Error, text);
            if (details != null)
                Console.WriteLine(details);
        }
    }
}
