// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.CodeGeneration.Model
{
    public enum AssertionType
    {
        NotNull,
        File,
        Directory,
        FileOrNull,
        DirectoryOrNull
    }
}
