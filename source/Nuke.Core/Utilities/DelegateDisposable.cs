// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core.Utilities
{
    internal class DelegateDisposable : IDisposable
    {
        public static IDisposable CreateBracket (Action setup, Action cleanup)
        {
            setup();
            return new DelegateDisposable(cleanup);
        }

        private readonly Action _cleanup;

        public DelegateDisposable (Action cleanup)
        {
            _cleanup = cleanup;
        }

        public void Dispose ()
        {
            _cleanup();
        }
    }
}
