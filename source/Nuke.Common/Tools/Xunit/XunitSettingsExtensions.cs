// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tools.Xunit
{
    partial class XunitSettingsExtensions
    {
        public static XunitSettings AddTargetAssemblies (this XunitSettings xunitSettings, IEnumerable<string> assemblyFiles)
        {
            return assemblyFiles.Aggregate(xunitSettings, (current, assembly) => current.AddTargetAssemblyWithConfig(assembly, targetAssemblyWithConfigValue: null));
        }

        public static XunitSettings AddTargetAssemblies (this XunitSettings xunitSettings, params string[] assemblyFiles)
        {
            return xunitSettings.AddTargetAssemblies(assemblyFiles.AsEnumerable());
        }
    }
}
