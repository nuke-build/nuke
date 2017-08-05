// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Utilities
{
    internal class DelegateDisposable : IDisposable
    {
        public static IDisposable CreateBracket (Action setup = null, Action cleanup = null)
        {
            setup?.Invoke();
            return new DelegateDisposable(cleanup);
        }

        [CanBeNull]
        private readonly Action _cleanup;

        private DelegateDisposable ([CanBeNull] Action cleanup)
        {
            _cleanup = cleanup;
        }

        public void Dispose ()
        {
            _cleanup?.Invoke();
        }
    }
}
