// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Core;
using Xunit;

namespace Nuke.Common.Tests
{
    [AttributeUsage(AttributeTargets.Method)]
    public class WindowsFactAttribute : FactAttribute
    {
        public override string Skip => !EnvironmentInfo.IsWin ? "Only applying to Windows." : null;
    }
}
