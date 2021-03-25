// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tools.NerdbankGitVersioning;
using static Nuke.Common.ValueInjection.ValueInjectionUtility;

namespace Nuke.Components
{
    [PublicAPI]
    public interface IHazNerdbankGitVersioning
    {
        [NerdbankGitVersioning] [Required] NerdbankGitVersioning Versioning => TryGetValue(() => Versioning);
    }
}
