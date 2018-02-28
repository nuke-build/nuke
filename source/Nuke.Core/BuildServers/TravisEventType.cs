// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

// ReSharper disable InconsistentNaming

namespace Nuke.Core.BuildServers
{
    [PublicAPI]
    public enum TravisEventType
    {
        push,
        pull_request,
        api,
        cron
    }
}
