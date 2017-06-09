// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core.Tooling
{
    public delegate T Configure<T> (T settings)
        where T : ToolSettings;
}
