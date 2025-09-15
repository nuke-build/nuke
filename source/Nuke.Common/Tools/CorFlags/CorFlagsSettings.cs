// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Reflection;

namespace Nuke.Common.Tools.CorFlags;

partial class CorFlagsSettings
{
    string FormatBoolean(bool? value, PropertyInfo property)
        => value switch
        {
            true => "+",
            false => "-",
            null => null
        };
}
