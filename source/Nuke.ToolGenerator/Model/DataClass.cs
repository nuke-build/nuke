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

        public virtual string Name { get; set; }
        public string BaseClass { get; set; }
        public bool NoExtensionMethods { get; set; }
        public bool NoArguments { get; set; }
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
