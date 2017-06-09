using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.ToolGenerator.Model
{
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