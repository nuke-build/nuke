// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.Netlify
{
    partial class NetlifyTasks
    {
        private static string GetResult(IProcess process, NetlifySitesCreateSettings toolSettings)
        {
            return process.Output.EnsureOnlyStd().Select(x => x.Text)
                .Single(x => x.Contains("Site ID:"))
                .SplitSpace().Last();
        }
    }
}
