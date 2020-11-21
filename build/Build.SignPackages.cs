// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Components;

partial class Build : ISignPackages
{
    // https://ci.appveyor.com/tools/encrypt

    public IEnumerable<AbsolutePath> SignPathPackages => PackageFiles
        .Where(x => Path.GetFileName(x).StartsWithAny(
            "Nuke.Common",
            "Nuke.Components",
            "Nuke.CodeGeneration",
            "Nuke.GlobalTool"));

    public Target SignPackages => _ => _
        .Inherit<ISignPackages>(x => x.SignPackages)
        .TriggeredBy(Pack);
}
