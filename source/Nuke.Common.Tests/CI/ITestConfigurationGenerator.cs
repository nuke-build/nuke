// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.Common.CI;

namespace Nuke.Common.Tests.CI
{
    public interface ITestConfigurationGenerator : IConfigurationGenerator
    {
        StreamWriter Stream { set; }
    }
}
