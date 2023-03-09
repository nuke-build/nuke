// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Nuke.Common.Execution;

namespace Nuke.Common.Tests
{
    public static class ExecutionTestsInitializer
    {
        [ModuleInitializer]
        public static void Initialize()
        {
            Environment.SetEnvironmentVariable(Telemetry.OptOutEnvironmentKey, "true");
        }
    }
}
