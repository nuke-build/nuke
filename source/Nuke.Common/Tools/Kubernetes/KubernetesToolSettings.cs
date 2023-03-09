// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Kubernetes
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public abstract class KubernetesToolSettings : ToolSettings
    {
        public KubernetesCommonSettings CommonSettings { get; internal set; }

        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            if (CommonSettings != null)
                arguments.Concatenate(CommonSettings.CreateArguments());
            return base.ConfigureProcessArguments(arguments);
        }
    }
}
