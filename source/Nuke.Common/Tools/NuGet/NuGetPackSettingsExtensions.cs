// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tools.NuGet
{
    public static partial class NuGetPackSettingsExtensions
    {
        /// <summary><p><i>Extension method for setting 'configuration' in <see cref="NuGetPackSettings.Properties"/>.</i></p></summary>
        [Pure]
        public static NuGetPackSettings SetConfiguration(this NuGetPackSettings toolSettings, string configuration)
        {
            return toolSettings.SetProperty("configuration", configuration);
        }
    }
}
