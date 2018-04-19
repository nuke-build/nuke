// Copyright Matthias Koch, Sebastian Karasek 2018.
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
