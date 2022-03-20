// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    [PublicAPI]
    public enum AzurePipelinesParameterType
    {
        String,
        Number,
        Boolean
    }
}
