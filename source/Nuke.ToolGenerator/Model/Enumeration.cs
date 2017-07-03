// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Nuke.ToolGenerator.Model
{
    [UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.WithMembers)]
    public class Enumeration
    {
        [JsonIgnore]
        public Tool Tool { get; set; }

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
