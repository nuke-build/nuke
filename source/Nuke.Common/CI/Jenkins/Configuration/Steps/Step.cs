// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.CI.Jenkins.Configuration.Steps
{
    /// <summary>
    /// Base class for jenkins steps, <see href="https://www.jenkins.io/doc/pipeline/steps/">Pipeline Steps Reference</see>.
    /// </summary>
    public abstract class Step : ConfigurationEntity
    {
    }
}
