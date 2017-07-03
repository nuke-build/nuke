// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core.Execution
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class IconClassAttribute : Attribute
    {
        public IconClassAttribute (Type type, string iconClass)
        {
            Type = type;
            IconClass = iconClass;
        }

        public Type Type { get; }
        public string IconClass { get; }
    }
}
