// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core
{
    [PublicAPI]
    public enum LogLevel
    {
        Trace,
        Information,
        Warning,
        Error
    }
}
