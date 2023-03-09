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
    public class TeamCityVcsRoot : ConfigurationEntity
    {
        public string Id => "DslContext.settingsRoot";

        public override void Write(CustomFileWriter writer)
        {
        }
    }
}
