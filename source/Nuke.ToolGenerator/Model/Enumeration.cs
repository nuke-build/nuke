// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.ToolGenerator.Model
{
    [UsedImplicitly]
    public class Enumeration
    {
        /// <summary>
        /// The name of the enumeration.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Defines whether the enumeration is a flag-enum.
        /// </summary>
        public bool IsFlags { get; set; }

        /// <summary>
        /// The list of values defined.
        /// </summary>
        /// <remarks>
        /// Starting from index zero.
        /// </remarks>
        public List<string> Values { get; set; }
    }
}
