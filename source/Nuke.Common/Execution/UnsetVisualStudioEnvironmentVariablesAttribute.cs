// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public class UnsetVisualStudioEnvironmentVariablesAttribute : BuildExtensionAttributeBase, IOnBeforeLogo
    {
        public void OnBeforeLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            new[]
            {
                "MSBuildLoadMicrosoftTargetsReadOnly",
                "VisualStudioDir",
                "VisualStudioEdition",
                "VisualStudioVersion",
                "VSAPPIDDIR",
                "VSAPPIDNAME",
                "VSLANG",
                "VSLOGGER_UNIQUEID",
                "VSSKUEDITION"
            }.ForEach(x => Environment.SetEnvironmentVariable(x, value: null));
        }
    }
}
