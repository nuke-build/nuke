// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitHubActions.Configuration
{
    public abstract class GitHubActionsConfigurationEntity
    {
        public abstract void Write(CustomFileWriter writer);
    }
}
