// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tools.Xunit
{
    partial class Xunit2SettingsExtensions
    {
        public static Xunit2Settings AddTargetAssemblies(this Xunit2Settings toolSettings, IEnumerable<string> assemblyFiles)
        {
            return assemblyFiles.Aggregate(
                toolSettings,
                (current, assembly) => current.AddTargetAssemblyWithConfigs(assembly, string.Empty));
        }

        public static Xunit2Settings AddTargetAssemblies(this Xunit2Settings toolSettings, params string[] assemblyFiles)
        {
            return toolSettings.AddTargetAssemblies(assemblyFiles.AsEnumerable());
        }
    }
}
