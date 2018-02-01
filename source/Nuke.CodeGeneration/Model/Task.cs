// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Nuke.CodeGeneration.Model
{
    [UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.WithMembers)]
    public class Task
    {
        [JsonIgnore]
        public Tool Tool { get; set; }

        [CanBeNull] public string Help { get; set; }
        [CanBeNull] public string Postfix { get; set; }
        [CanBeNull] public string ReturnType { get; set; }
        public bool OmitCommonProperties { get; set; }
        public bool CustomStart { get; set; }
        public bool CustomAssertion { get; set; }
        public string DefiniteArgument { get; set; }
        public SettingsClass SettingsClass { get; set; }
    }
}
