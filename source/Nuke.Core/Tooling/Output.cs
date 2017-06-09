// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Tooling
{
    [PublicAPI]
    public struct Output
    {
        public OutputType Type;
        public string Text;
    }
}
