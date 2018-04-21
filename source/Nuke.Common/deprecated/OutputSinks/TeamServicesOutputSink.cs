// ReSharper disable All
#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.BuildServers;

namespace Nuke.Core.OutputSinks
{
    [UsedImplicitly]
    internal class TeamServicesOutputSink : ConsoleOutputSink
    {
        private readonly TeamServices _teamServices;

        internal TeamServicesOutputSink(TeamServices teamServices)
        {
            _teamServices = teamServices;
        }

        public override void Warn(string text, string details = null)
        {
            _teamServices.LogIssue(TeamServicesIssueType.Warning, text);
            if (details != null)
                Console.WriteLine(details);
        }

        public override void Error(string text, string details = null)
        {
            _teamServices.LogIssue(TeamServicesIssueType.Error, text);
            if (details != null)
                Console.WriteLine(details);
        }
    }
}
