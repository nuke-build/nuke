// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.ClangSharpPInvokeGenerator
{
    public partial class ClangSharpPInvokeGeneratorTasks
    {
        public static void CustomExitHandler(ToolSettings toolSettings, IProcess process)
        {
            process.AssertNonNegativeExitCode();
        }
    }
}
