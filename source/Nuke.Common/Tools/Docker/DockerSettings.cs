// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Docker
{
    [PublicAPI]
    [Serializable]
    public abstract class DockerSettings : ToolSettings
    {
        public CliSettings CliSettings { get; internal set; }

        protected string GetCliSettings()
        {
            return string.Empty;
        }

        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            if (CliSettings != null)
                arguments = CliSettings.CreateArguments().Concatenate(arguments);
            return base.ConfigureProcessArguments(arguments);
        }
    }
}
