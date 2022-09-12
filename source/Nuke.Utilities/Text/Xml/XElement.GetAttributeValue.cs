// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Xml.Linq;

namespace Nuke.Common.Utilities
{
    public static partial class XElementExtensions
    {
        public static string GetAttributeValue(this XElement element, string name)
        {
            return element.Attribute(name).NotNull().Value;
        }
    }
}
