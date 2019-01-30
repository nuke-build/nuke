// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    partial class ToolSettingsExtensions
    {
        public static T When<T>(this T settings, bool condition, Configure<T> configurator)
            where T : ToolSettings
        {
            return condition ? configurator(settings) : settings;
        }
    }
}
