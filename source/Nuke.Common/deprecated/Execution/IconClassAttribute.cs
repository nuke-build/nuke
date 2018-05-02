// ReSharper disable All
#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core.Execution
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class IconClassAttribute : Attribute
    {
        // ReSharper disable UnusedParameter.Local
        public IconClassAttribute(Type type, string iconClass)
            // ReSharper restore UnusedParameter.Local
        {
        }
    }
}
