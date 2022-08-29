// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.IO
{
    partial class AbsolutePathExtensions
    {
        [Pure]
        [CanBeNull]
        public static AbsolutePath FindParent(this AbsolutePath path, Func<AbsolutePath, bool> predicate)
        {
            Assert.True(path.FileExists());
            return path.NotNull().Descendants(x => x.Parent).FirstOrDefault(predicate);
        }

        
        [Pure]
        [CanBeNull]
        public static AbsolutePath FindParentOrSelf(this AbsolutePath path, Func<AbsolutePath, bool> predicate)
        {
            Assert.True(path.FileExists() || path.DirectoryExists());
            return path.NotNull().DescendantsAndSelf(x => x.Parent).FirstOrDefault(predicate);
        }
    }
}
