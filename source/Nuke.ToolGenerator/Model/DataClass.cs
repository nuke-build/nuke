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
    public class DataClass
    {
        [JsonIgnore]
        public Tool Tool { get; set; }

        /// <summary>
        /// The name of the data class.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// The base class to inherit from.
        /// </summary>
        public string BaseClass { get; set; }

        /// <summary>
        /// If set to <c>true</c>, no extension methods will be generated.
        /// </summary>
        public bool SkipExtensionMethods { get; set; }

        public bool NoArguments { get; set; }

        /// <summary>
        /// The list of properties.
        /// </summary>
        public List<Property> Properties { get; set; } = new List<Property>();
    }

    [UsedImplicitly]
    public class SettingsClass : DataClass
    {
        [JsonIgnore]
        public Task Task { get; set; }

        public override string Name => $"{Tool.Name}{Task.Postfix}Settings";
    }
}
