// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.ToolGenerator.Model
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
