// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using Nuke.Common.Tooling;

namespace Nuke.Common;

public abstract class RequiresAttribute : Attribute
{
    public abstract ToolRequirement GetRequirement();
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true)]
public class RequiresAttribute<T> : RequiresAttribute
    where T : IRequireTool
{
    public string Version { get; set; }

    public override ToolRequirement GetRequirement()
    {
        return typeof(T).GetCustomAttribute<ToolRequirementAttributeBase>().NotNull().GetRequirement(Version);
    }
}
