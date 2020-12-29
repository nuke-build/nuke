// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;

namespace Nuke.Components
{
    public interface IHazArtifacts : INukeBuild
    {
        AbsolutePath ArtifactsDirectory => RootDirectory / "artifacts";
    }
}
