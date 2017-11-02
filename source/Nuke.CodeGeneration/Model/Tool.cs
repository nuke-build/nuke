// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Nuke.CodeGeneration.Model
{
    [UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.WithMembers)]
    [DebuggerDisplay("{" + nameof(DefinitionFile) + "}")]
    public class Tool
    {
        [JsonProperty("$schema")]
        private string Schema { get; set; } = "./_schema.json#";

        [JsonProperty]
        private string[] License { get; set; } =
            {
                "Copyright Matthias Koch 2017.",
                "Distributed under the MIT License.",
                "https://github.com/nuke-build/tools/blob/master/LICENSE"
            };

        [JsonIgnore]
        public string DefinitionFile { get; set; }
        [JsonIgnore]
        public string GenerationFileBase { get; set; }
        [JsonIgnore]
        public string RepositoryUrl { get; set; }

        public List<string> References { get; set; } = new List<string>();

        public string Name { get; set; }
        public string OfficialUrl { get; set; }
        public string Help { get; set; }
        public string PackageId { get; set; }
        public string PackageExecutable { get; set; }
        public string EnvironmentExecutable { get; set; }
        public string PathExecutable { get; set; }
        public bool CustomExecutable { get; set; }

        public List<Task> Tasks { get; set; } = new List<Task>();
        public List<Property> CommonTaskProperties { get; set; } = new List<Property>();

        public List<DataClass> DataClasses { get; set; } = new List<DataClass>();
        public List<Enumeration> Enumerations { get; set; } = new List<Enumeration>();
    }
}
