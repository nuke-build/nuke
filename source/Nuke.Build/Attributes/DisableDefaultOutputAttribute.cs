// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class)]
    public class DisableDefaultOutputAttribute : Attribute
    {
        public DisableDefaultOutputAttribute(params DefaultOutput[] disabledOutputs)
        {
            DisabledOutputs = disabledOutputs.Length > 0
                ? disabledOutputs
                : Enum.GetValues(typeof(DefaultOutput)).Cast<DefaultOutput>().ToArray();
        }

        public DefaultOutput[] DisabledOutputs { get; }

        public virtual bool IsApplicable(INukeBuild build)
        {
            return true;
        }
    }

    public enum DefaultOutput
    {
        Logo,
        TargetHeader,
        TargetCollapse,
        ErrorsAndWarnings,
        TargetOutcome,
        BuildOutcome,
        Timestamps
    }
}
