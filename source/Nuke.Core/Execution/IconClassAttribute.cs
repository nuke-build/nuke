// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core.Execution
{
    public class IconClassAttribute : Attribute
    {
        public IconClassAttribute (string iconClass)
        {
            IconClass = iconClass;
        }

        public string IconClass { get; }
    }
}
