using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Nuke.ToolGenerator.Model
{
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
        [JsonConverter (typeof (StringEnumConverter))]
        public AssertionType? Assertion { get; set; }
        
        /// <summary>
        /// The format how the property is renderd.
        /// </summary>
        public string Format { get; set; }
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
        /// If set to <v>true</v>, the value won't be rendered in clear text.
        /// </summary>
        public bool Secret { get; set; }
        /// <summary>
        /// If set to <v>true</v>, the argument will be rendered when the property is set to false. At the same time, the default value is set to <v>true</v>.
        /// </summary>
        public bool Negate { get; set; }
        /// <summary>
        /// If set to <v>true</v>, will call a custom value provider method.
        /// </summary>
        public bool CustomValue { get; set; }
        
        /// <summary>
        /// The help text.
        /// </summary>
        public string Help { get; set; }
    }
}