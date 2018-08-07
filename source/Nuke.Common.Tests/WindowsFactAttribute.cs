// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Xunit;

namespace Nuke.Common.Tests
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WindowsFactAttribute : FactAttribute
    {
        public override string Skip => !EnvironmentInfo.IsWin ? "Only applies to Windows." : null;
    }
}
