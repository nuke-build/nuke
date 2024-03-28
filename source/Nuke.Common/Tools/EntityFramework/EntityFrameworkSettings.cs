// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.EntityFramework;

[PublicAPI]
[Serializable]
public abstract class EntityFrameworkSettings : ToolSettings
{
    protected string GetProcessToolPath()
    {
        return EntityFrameworkTasks.GetToolPath();
    }
}
