// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Unity;

public static partial class UnityRunTestsSettingsExtensions
{
    #region TestPlatform

    /// <summary>
    ///   <p><em>Sets <see cref="UnityRunTestsSettings.TestPlatform"/></em></p>
    ///   <p>The platform to run tests on.</p>
    /// </summary>
    [Pure]
    public static UnityRunTestsSettings SetTestPlatform(this UnityRunTestsSettings toolSettings, UnityTestPlatform testPlatform)
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TestPlatform = testPlatform.ToString();
        return toolSettings;
    }

    /// <summary>
    ///   <p><em>Sets <see cref="UnityRunTestsSettings.TestPlatform"/></em></p>
    ///   <p>The platform to run tests on.</p>
    /// </summary>
    [Pure]
    public static UnityRunTestsSettings SetTestPlatform(this UnityRunTestsSettings toolSettings, UnityBuildTarget buildTarget)
    {
        toolSettings = toolSettings.NewInstance();
        toolSettings.TestPlatform = buildTarget.ToString();
        return toolSettings;
    }

    #endregion
}
