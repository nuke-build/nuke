// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tools.MSpec
{
    public partial class MSpecSettings
    {
        private string GetProcessToolPath()
        {
            return MSpecTasks.GetToolPath();
        }
    }
}
