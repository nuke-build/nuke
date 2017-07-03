// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;

namespace Nuke.Core
{
    public static partial class EnvironmentInfo
    {
        /// <summary>
        /// The build entry assembly.
        /// </summary>
        public static Assembly BuildAssembly => Assembly.GetEntryAssembly();
    }
}
