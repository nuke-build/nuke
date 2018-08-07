// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.BuildServers
{
    [PublicAPI]
    public enum TeamServicesJobStatus
    {
        Canceled,
        Failed,
        Succeeded,
        SucceededWithIssues
    }
}
