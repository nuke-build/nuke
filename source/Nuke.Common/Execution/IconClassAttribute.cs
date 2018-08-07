// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Execution
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
