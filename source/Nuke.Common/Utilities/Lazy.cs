// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;

namespace Nuke.Common.Utilities
{
    public static class Lazy
    {
        public static Lazy<T> Create<T>(Func<T> provider)
        {
            return new Lazy<T>(provider);
        }
    }
}
