// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;

namespace Nuke.Common.BuildServers
{
    [PublicAPI]
    public enum TeamCityImportTool
    {
        /// <summary>dotCover reports</summary>
        dotcover,

        /// <summary>PartCover reports</summary>
        partcover,

        /// <summary>NCover reports</summary>
        ncover,

        /// <summary>NCover3 reports</summary>
        ncover3
    }
}
