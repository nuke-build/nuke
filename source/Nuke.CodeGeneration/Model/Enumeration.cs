// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Nuke.CodeGeneration.Model
{
    [UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.WithMembers)]
    public class Enumeration
    {
        [JsonIgnore]
        public Tool Tool { get; set; }

        [JsonProperty(Required = Required.Always)]
        [RegularExpression(RegexPatterns.Name)]
        [Description("Name of the enumeration.")]
        public string Name { get; set; }

        [JsonProperty(Required = Required.Always)]
        [Description("The enumeration values.")]
        public List<string> Values { get; set; }
    }
}
