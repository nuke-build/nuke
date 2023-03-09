// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.AzurePipelines
{
    [PublicAPI]
    public enum AzurePipelinesIssueType
    {
        Warning,
        Error
    }
}
