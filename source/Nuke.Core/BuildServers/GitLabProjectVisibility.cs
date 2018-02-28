// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.BuildServers
{
    [PublicAPI]
    public enum GitLabProjectVisibility
    {
        Private,
        Internal,
        Public
    }
}
