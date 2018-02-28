// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Utilities
{
    public class DelegateDisposable : IDisposable
    {
        public static IDisposable CreateBracket([InstantHandle] Action setup = null, [InstantHandle] Action cleanup = null)
        {
            setup?.Invoke();
            return new DelegateDisposable(cleanup);
        }

        [CanBeNull] private readonly Action _cleanup;

        private DelegateDisposable([CanBeNull] Action cleanup)
        {
            _cleanup = cleanup;
        }

        public void Dispose()
        {
            _cleanup?.Invoke();
        }
    }
}
