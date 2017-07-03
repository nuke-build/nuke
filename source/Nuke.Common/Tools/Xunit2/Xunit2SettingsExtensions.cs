// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tools.Xunit2
{
    partial class Xunit2SettingsExtensions
    {
        public static Xunit2Settings AddTargetAssemblies (this Xunit2Settings xunitSettings, IEnumerable<string> assemblyFiles)
        {
            return assemblyFiles.Aggregate(
                xunitSettings,
                (current, assembly) => current.AddTargetAssemblyWithConfig(assembly, targetAssemblyWithConfigValue: null));
        }

        public static Xunit2Settings AddTargetAssemblies (this Xunit2Settings xunitSettings, params string[] assemblyFiles)
        {
            return xunitSettings.AddTargetAssemblies(assemblyFiles.AsEnumerable());
        }
    }
}
