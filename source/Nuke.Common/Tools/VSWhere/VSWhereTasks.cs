// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.VSWhere;

partial class VSWhereTasks
{
    public const string VcComponent = "Microsoft.VisualStudio.Component.VC.Tools.x86.x64";
    public const string MsBuildComponent = "Microsoft.Component.MSBuild";
    public const string NetCoreComponent = "Microsoft.Net.Core.Component.SDK";

    protected override object GetResult<T>(ToolOptions options, IReadOnlyCollection<Output> output)
    {
        if (options is not VSWhereSettings { UTF8: true, Property: null } vswhereOptions ||
            !vswhereOptions.Format.Equals(VSWhereFormat.json))
            return null;

        return output.EnsureOnlyStd().StdToJson<VSWhereResult[]>().ToList();
    }
}
