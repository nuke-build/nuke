// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Tooling
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class FriendlyStringAttribute : Attribute
    {
        public FriendlyStringAttribute (string friendlyString)
        {
            FriendlyString = friendlyString;
        }

        public string FriendlyString { get; }
    }
}
