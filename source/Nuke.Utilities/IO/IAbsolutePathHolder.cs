// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.IO;

public interface IAbsolutePathHolder
{
    AbsolutePath Path { get; }
}
