// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Core.Tooling
{
    public class FakeProcess : IProcess
    {
        public void Dispose ()
        {
        }

        public IEnumerable<Output> Output => Enumerable.Empty<Output>();

        public int ExitCode => 0;

        public void Kill ()
        {
        }

        public bool WaitForExit ()
        {
            return true;
        }
    }
}
