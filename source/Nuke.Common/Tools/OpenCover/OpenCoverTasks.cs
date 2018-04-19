// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.OpenCover
{
    partial class OpenCoverTasks
    {
        public static OpenCoverSettings DefaultOpenCover => new OpenCoverSettings()
            .SetWorkingDirectory(NukeBuild.Instance.RootDirectory)
            .SetRegistration(RegistrationType.User)
            .SetTargetExitCodeOffset(targetExitCodeOffset: 0)
            .SetFilters(
                "+[*]*",
                "-[xunit.*]*",
                "-[NUnit.*]*",
                "-[FluentAssertions.*]*",
                "-[Machine.Specifications.*]*")
            .SetExcludeByAttributes(
                "*.Explicit*",
                "*.Ignore*",
                "System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute")
            .SetExcludeByFile(
                "*/*.Generated.cs",
                "*/*.Designer.cs",
                "*/*.g.cs",
                "*/*.g.i.cs");

        [Obsolete("Use " + nameof(OpenCoverSettings) + "." + nameof(OpenCoverSettingsExtensions.SetTargetSettings) + " instead.")]
        public static void OpenCover(Action testAction, Configure<OpenCoverSettings> configurator = null, ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            OpenCover(x => configurator(x).SetTestAction(testAction));
        }

        [Obsolete("Use " + nameof(OpenCoverSettings) + "." + nameof(OpenCoverSettingsExtensions.SetTargetSettings) + " instead.")]
        public static void OpenCover(
            Action testAction,
            string output,
            Configure<OpenCoverSettings> configurator = null,
            ProcessSettings processSettings = null)
        {
            configurator = configurator ?? (x => x);
            OpenCover(testAction, x => configurator(x).SetOutput(output));
        }
    }
}
