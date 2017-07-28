// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Tooling
{
    [Serializable]
    [PublicAPI]
    public abstract class Enumeration
    {
        protected string Value { get; set; }

        public override string ToString ()
        {
            return Value.NotNull("Value != null");
        }
    }
}
