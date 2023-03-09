// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Kubernetes
{
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public abstract class KubernetesExecBaseSettings : KubernetesToolSettings
    {
        public virtual string Command { get; internal set; }
        public virtual IReadOnlyList<string> Arguments => ArgumentsInternal.AsReadOnly();
        internal List<string> ArgumentsInternal { get; set; } = new();

        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            var args = new Arguments()
                .Add("-- {value}", Command)
                .Add("{value}", Arguments, separator: ' ');
            return base.ConfigureProcessArguments(arguments).Concatenate(args);
        }
    }
}
