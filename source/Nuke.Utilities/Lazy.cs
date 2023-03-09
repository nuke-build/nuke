// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;

namespace Nuke.Common.Utilities
{
    public static class Lazy
    {
        /// <summary>
        /// Creates a <see cref="Lazy{T}"/> from a delegate.
        /// </summary>
        public static Lazy<T> Create<T>(Func<T> provider)
        {
            return new Lazy<T>(provider);
        }
    }
}
