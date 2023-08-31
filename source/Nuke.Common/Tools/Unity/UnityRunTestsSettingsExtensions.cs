// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tools.Unity;

public static partial class UnityRunTestsSettingsExtensions
{
    #region TestPlatform

    /// <summary>
    ///   <p><em>Sets <see cref="UnityRunTestsSettings.TestPlatform"/></em></p>
    ///   <p>The platform to run tests on.</p>
    /// </summary>
    [Pure]
    public static T SetTestPlatform<T>(this T toolSettings, UnityTestPlatform testPlatform)
        where T : UnityRunTestsSettings
    {
        return toolSettings.SetTestPlatform(testPlatform.ToString());
    }

    /// <summary>
    ///   <p><em>Sets <see cref="UnityRunTestsSettings.TestPlatform"/></em></p>
    ///   <p>The platform to run tests on.</p>
    /// </summary>
    [Pure]
    public static T SetTestPlatform<T>(this T toolSettings, UnityBuildTarget buildTarget)
        where T : UnityRunTestsSettings
    {
        return toolSettings.SetTestPlatform(buildTarget.ToString());
    }

    #endregion
}
