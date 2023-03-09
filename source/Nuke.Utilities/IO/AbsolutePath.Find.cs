// Copyright 2023 Maintainers of NUKE.
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
        /// <summary>
        /// Finds the first parent that fulfills the condition.
        /// </summary>
        [Pure]
        [CanBeNull]
        public static AbsolutePath FindParent(this AbsolutePath path, Func<AbsolutePath, bool> predicate)
        {
            Assert.True(path.FileExists());
            return path.NotNull().Descendants(x => x.Parent).FirstOrDefault(predicate);
        }


        /// <summary>
        /// Finds the first parent (starting with self) that fulfills the condition.
        /// </summary>
        [Pure]
        [CanBeNull]
        public static AbsolutePath FindParentOrSelf(this AbsolutePath path, Func<AbsolutePath, bool> predicate)
        {
            Assert.True(path.FileExists() || path.DirectoryExists());
            return path.NotNull().DescendantsAndSelf(x => x.Parent).FirstOrDefault(predicate);
        }
    }
}
