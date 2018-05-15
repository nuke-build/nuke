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
    public class DataClass
    {
        [JsonIgnore]
        public Tool Tool { get; set; }

        [JsonProperty(Required = Required.Always)]
        [RegularExpression(RegexPatterns.Name)]
        [Description("Name of the data class.")]
        public virtual string Name { get; set; }

        [Description("The base class to inherit from.")]
        public string BaseClass { get; set; }

        [Description("Skips appendig of extension methods.")]
        public bool NoExtensionMethods { get; set; }

        [Description("Omits argument parsing.")]
        public bool NoArguments { get; set; }

        [Description("Properties of the data class.")]
        public List<Property> Properties { get; set; } = new List<Property>();
    }

    [UsedImplicitly]
    public class SettingsClass : DataClass
    {
        [JsonIgnore]
        public Task Task { get; set; }

        [JsonProperty(Required = Required.Default)]
        public override string Name => $"{Tool.Name}{Task.Postfix}Settings";
    }
}
