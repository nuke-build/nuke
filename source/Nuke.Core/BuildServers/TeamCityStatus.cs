// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.BuildServers
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum TeamCityStatus
    {
        NORMAL,
        WARNING,
        ERROR,
        FAILURE
    }
}
