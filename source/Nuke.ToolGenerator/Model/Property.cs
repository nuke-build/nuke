// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nuke.ToolGenerator.Model
{
    [Serializable]
    [UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.WithMembers)]
    public class Property
    {
        [NonSerialized]
        private DataClass _dataClass;

        [JsonIgnore]
        public DataClass DataClass
        {
            get => _dataClass;
            set => _dataClass = value;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public AssertionType? Assertion { get; set; }
        public string Format { get; set; }
        public string ItemFormat { get; set; }
        public bool NoArgument { get; set; }
        public bool CustomImpl { get; set; }
        public bool NoExtensionMethod { get; set; }
        public char? Separator { get; set; }
        public char? DisallowedCharacter { get; set; }
        public bool QuoteMultiple { get; set; }
        public string Default { get; set; }
        public bool Secret { get; set; }
        public bool CustomValue { get; set; }
        public bool CreateOverload { get; set; }
        public string Help { get; set; }

        public List<Property> Delegates { get; set; } = new List<Property>();
    }
}
