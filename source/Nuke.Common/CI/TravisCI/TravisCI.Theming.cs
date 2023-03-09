// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.TravisCI
{
    public partial class TravisCI
    {
        protected internal override IDisposable WriteBlock(string text)
        {
            return DelegateDisposable.CreateBracket(
                () => Console.WriteLine($"travis_fold:start:{text}"),
                () => Console.WriteLine($"travis_fold:end:{text}"));
        }
    }
}
