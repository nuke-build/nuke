// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common
{
    [PublicAPI]
    public enum LogLevel
    {
        Trace,
        Normal,
        Warning,
        Error
    }
}
