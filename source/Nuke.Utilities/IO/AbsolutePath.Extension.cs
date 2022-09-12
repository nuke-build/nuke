// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.IO
{
    partial class AbsolutePathExtensions
    {
        public static bool HasExtension(this AbsolutePath path, string extension, params string[] alternativeExtensions)
        {
            return path.ToString().EndsWithAnyOrdinalIgnoreCase(extension.Concat(alternativeExtensions));
        }

        public static AbsolutePath WithExtension(this AbsolutePath path, string extension)
        {
            return path.Parent / Path.ChangeExtension(path.Name, extension);
        }
    }
}
