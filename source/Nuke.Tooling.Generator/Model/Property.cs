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
    [Serializable]
    [UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.WithMembers)]
    public class Property : IDeprecatable
    {
        [NonSerialized] private DataClass _dataClass;

        [JsonIgnore]
        public DataClass DataClass
        {
            get => _dataClass;
            set => _dataClass = value;
        }

        [JsonIgnore]
        [NotNull]
        public IDeprecatable Parent => DataClass;

        [JsonProperty(Required = Required.Always)]
        [RegularExpression(RegexPatterns.Name)]
        [Description("Name of the property.")]
        public string Name { get; set; }

        [JsonProperty(Required = Required.Always)]
        [Description("Type of the property. I.e., bool, int, string, List<int>, Dictionary<string, object>, Lookup<string, int.>")]
        public string Type { get; set; }

        [Description("Name used when serializing to JSON.")]
        public string Json { get; set; }

        [Description("Argument formatting for the property. '{value}' is replaced by the value of the property.")]
        public string Format { get; set; }

        [Description("Item formatting for dictionaries. '{key}' and '{value}' are replaced accordingly.")]
        public string ItemFormat { get; set; }

        [Description("Omits argument parsing.")]
        public bool NoArgument { get; set; }

        [Description("Custom implementation of the property.")]
        public bool CustomImpl { get; set; }

        [Description("Separator used for items of collection types.")]
        public char? Separator { get; set; }

        [Description("Character that must be double-quoted.")]
        public char? DisallowedCharacter { get; set; }

        [Description("Specifies if list items should be double quoted.")]
        public bool QuoteMultiple { get; set; }

        [Description("Default value that will be used if no value is given.")]
        public string Default { get; set; }

        [Description("Specifies that the value is secret and should be hidden in output.")]
        public bool? Secret { get; set; }

        [Description("Custom implementation of value presentation.")]
        public bool CustomValue { get; set; }

        [Description("Specifies that an overload for the property should be created.")]
        public bool CreateOverload { get; set; }

        [Description("Help text for the property.")]
        public string Help { get; set; }

        [Description("Dictionary delegates for named properties.")]
        public List<Property> Delegates { get; set; } = new();

        [Description("Obsolete message. Property is marked as obsolete when specified.")]
        public string DeprecationMessage { get; set; }

        public bool OnlyDelegates { get; set; }

        public bool IsTailArgument { get; set; }
    }
}
