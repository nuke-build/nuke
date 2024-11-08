// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Xunit;

partial class XunitTasks
{
    protected override string GetToolPath(ToolOptions options = null)
    {
        return NuGetToolPathResolver.GetPackageExecutable(
            packageId: PackageId,
            packageExecutable: EnvironmentInfo.Is64Bit ? "xunit.console.exe" : "xunit.console.x86.exe",
            framework: (options as IToolOptionsWithFramework)?.Framework);
    }

    protected override Func<IProcess, object> GetExitHandler(ToolOptions options = null)
    {
        return x => x.ExitCode switch
        {
            0 => default,
            1 => throw new Exception("One or more of the tests failed"),
            2 => throw new Exception("The help page was shown, either because it was requested, or because the user did not provide any command line arguments"),
            3 => throw new Exception("There was a problem with one of the command line options passed to the runner"),
            4 => throw new Exception("There was a problem loading one or more of the test assemblies (for example, if a 64-bit only assembly is run with the 32-bit test runner)"),
            _ => throw new NotSupportedException()
        };
    }
}
