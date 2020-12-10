// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Helm
{
    [PublicAPI]
    [Serializable]
    public class HelmToolSettings : ToolSettings
    {
        /// <summary>
        /// Common settings for Helm, like kubecontext, Tiller namespace ...
        /// </summary>
        public HelmCommonSettings CommonSettings { get; internal set; }

        public override Action<OutputType, string> ProcessCustomLogger { get; }

        protected override Arguments ConfigureProcessArguments([NotNull] Arguments arguments)
        {
            if (CommonSettings != null)
                arguments.Concatenate(CommonSettings.CreateArguments());
            return base.ConfigureProcessArguments(arguments);
        }
    }
}
