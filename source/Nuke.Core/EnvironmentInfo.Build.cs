// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;

namespace Nuke.Core
{
    public static partial class EnvironmentInfo
    {
        /// <summary>
        /// The assembly executing the build.
        /// </summary>
        public static Assembly BuildAssembly =>
#if NETCORE
                Assembly.GetEntryAssembly();
#else
                Assembly.GetExecutingAssembly();

#endif
    }
}
