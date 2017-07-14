// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nuke.ToolGenerator.Model
{
    [UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.WithMembers)]
    public class Property
    {
        /// <summary>
        /// The name of the property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the property.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A built-in assertion that is validated during argument generation.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public AssertionType? Assertion { get; set; }

        /// <summary>
        /// The format how the property is rendered.
        /// </summary>
        public string Format { get; set; }

        public bool NoArgument { get; set; }

        /// <summary>
        /// Defines the separator between items of lists or dictionaries.
        /// </summary>
        public string MainSeparator { get; set; }

        /// <summary>
        /// Defines the separator for key-value pairs.
        /// </summary>
        public string KeyValueSeparator { get; set; }

        /// <summary>
        /// Defines the default value.
        /// </summary>
        public string Default { get; set; }

        /// <summary>
        /// If set to <c>true</c>, the value won't be rendered in clear text.
        /// </summary>
        public bool Secret { get; set; }

        /// <summary>
        /// If set to <c>true</c>, will call a custom value provider method.
        /// </summary>
        public bool CustomValue { get; set; }

        /// <summary>
        /// Defines whether to create a task overload for that property.
        /// </summary>
        public bool CreateOverload { get; set; }

        /// <summary>
        /// The help text.
        /// </summary>
        public string Help { get; set; }
    }
}
