// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public abstract class CustomStepConfigurationEntityAttribute<T> : Attribute
{
    public abstract T Get();

}
