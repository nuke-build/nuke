// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tests
{
    public static class HostInitializer
    {
        [ModuleInitializer]
        public static void Initialize()
        {
            NukeBuild.Host = new SilentHost();
        }

        private class SilentHost : Host
        {
            protected internal override IDisposable WriteBlock(string text)
            {
                return DelegateDisposable.CreateBracket();
            }
        }
    }
}
