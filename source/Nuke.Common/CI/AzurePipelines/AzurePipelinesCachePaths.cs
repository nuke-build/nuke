// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.CI.AzurePipelines
{
    // https://docs.microsoft.com/en-us/azure/devops/pipelines/release/caching?view=azure-devops
    public static class AzurePipelinesCachePaths
    {
        public const string Nuke = ".nuke/temp";
        public const string NuGet = "~/.nuget/packages";
        public const string Npm = "~/.npm";
        public const string Gradle = "~/.gradle";
        public const string Docker = "~/docker";
    }
}
