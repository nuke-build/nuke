// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Xunit
{
    public static partial class XunitTasks
    {
        private static string GetPackageExecutable()
        {
            return EnvironmentInfo.Is64Bit ? "xunit.console.exe" : "xunit.console.x86.exe";
        }

        public static void Xunit2(
            IEnumerable<string> assemblyFiles,
            Configure<Xunit2Settings> configurator = null,
            ProcessSettings processSettings = null)
        {
            Xunit2(x => configurator.InvokeSafe(x).AddTargetAssemblies(assemblyFiles), processSettings);
        }

        private static void AssertProcess(IProcess process, Xunit2Settings toolSettings)
        {
            process.AssertWaitForExit();
            switch (process.ExitCode)
            {
                case 0:
                    break;
                case 1:
                    ControlFlow.Fail("One or more of the tests failed.");
                    break;
                case 2:
                    ControlFlow.Fail(
                        "The help page was shown, either because it was requested, or because the user did not provide any command line arguments.");
                    break;
                case 3:
                    ControlFlow.Fail("There was a problem with one of the command line options passed to the runner.");
                    break;
                case 4:
                    ControlFlow.Fail(
                        "There was a problem loading one or more of the test assemblies (for example, if a 64-bit only assembly is run with the 32-bit test runner).");
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
