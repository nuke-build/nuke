// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities
{
    public static class DisposableExtensions
    {
        public static IDisposable CombineWith(this IDisposable disposable, [InstantHandle] Action setup = null, [InstantHandle] Action cleanup = null)
        {
            return DelegateDisposable.CreateBracket(
                setup,
                () =>
                {
                    cleanup?.Invoke();
                    disposable.Dispose();
                });
        }

        public static IDisposable CombineWith(this IDisposable disposable, IDisposable otherDisposable)
        {
            return disposable.CombineWith(cleanup: otherDisposable.Dispose);
        }
    }
}
