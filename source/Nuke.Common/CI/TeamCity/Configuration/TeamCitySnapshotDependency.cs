// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    [PublicAPI]
    public class TeamCitySnapshotDependency : TeamCityDependency
    {
        public TeamCityBuildType BuildType { get; set; }
        public TeamCityDependencyFailureAction FailureAction { get; set; }
        public TeamCityDependencyFailureAction CancelAction { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            static string FormatAction(TeamCityDependencyFailureAction action)
                => "FailureAction." +
                   action.ToString().SplitCamelHumps().JoinUnderscore().ToUpperInvariant();

            using (writer.WriteBlock($"snapshot({BuildType.Id})"))
            {
                writer.WriteLine($"onDependencyFailure = {FormatAction(FailureAction)}");
                writer.WriteLine($"onDependencyCancel = {FormatAction(CancelAction)}");
            }
        }
    }
}
