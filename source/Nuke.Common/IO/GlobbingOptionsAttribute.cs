// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;

namespace Nuke.Common.IO
{
    /// <summary>
    /// Allows to configure the case-sensitivity used for globbing operations in <see cref="PathConstruction"/>.
    /// </summary>
    [PublicAPI]
    public sealed class GlobbingOptionsAttribute : BuildExtensionAttributeBase, IOnBeforeLogo
    {
        private readonly GlobbingCaseSensitivity _caseSensitivity;

        public GlobbingOptionsAttribute(GlobbingCaseSensitivity caseSensitivity)
        {
            _caseSensitivity = caseSensitivity;
        }

        public void OnBeforeLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            PathConstruction.GlobbingCaseSensitivity = _caseSensitivity;
        }
    }
}
