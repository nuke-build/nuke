// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using VerifyTests;

namespace Nuke.Common.Tests
{
    public static class VerifyTestsInitializer
    {
        [ModuleInitializer]
        public static void Initialize()
        {
            Environment.SetEnvironmentVariable("DiffEngine_Disabled", "true");
            VerifierSettings.DisableClipboard();
            VerifyDiffPlex.Initialize();
        }
    }
}
