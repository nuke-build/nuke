// Copyright 2023 Maintainers of NUKE.
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
    public class Enumeration : IDeprecatable
    {
        [JsonIgnore]
        public Tool Tool { get; set; }

        [NotNull]
        [JsonIgnore]
        public IDeprecatable Parent => Tool;

        [JsonProperty(Required = Required.Always)]
        [RegularExpression(RegexPatterns.Name)]
        [Description("Name of the enumeration.")]
        public string Name { get; set; }

        [JsonProperty(Required = Required.Always)]
        [Description("The enumeration values.")]
        public List<string> Values { get; set; }

        [Description("Obsolete message. Enumeration is marked as obsolete when specified.")]
        public string DeprecationMessage { get; set; }
    }
}
