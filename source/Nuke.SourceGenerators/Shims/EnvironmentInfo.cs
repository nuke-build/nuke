// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.Common.IO;

namespace Nuke.Common
{
    internal partial class EnvironmentInfo
    {
        public static AbsolutePath WorkingDirectory => (AbsolutePath) Directory.GetCurrentDirectory();
    }
}
