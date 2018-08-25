// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public string Schema { get; set; } = "https://raw.githubusercontent.com/nuke-build/nuke/master/source/Nuke.CodeGeneration/schema.json";

        [JsonProperty] public string[] License { get; set; }

        [JsonIgnore] public string DefinitionFile { get; set; }

        [JsonIgnore] public string RepositoryUrl { get; set; }

        [Description("Contains all references on which this definition is based on. Allows checking for updates.")]
        public List<string> References { get; set; } = new List<string>();

        [JsonProperty(Required = Required.Always)]
        [RegularExpression(RegexPatterns.Name)]
        [Description("Name of the Tool.")]
        public string Name { get; set; }

        [Url]
        [JsonProperty(Required = Required.Always)]
        [Description("Url to the official website.")]
        public string OfficialUrl { get; set; }

        [Description(
            "Help or introduction text to for the tool. Supports 'a-href', 'c', 'em', 'b', 'ul', 'li' and 'para' tags for better formatting.")]
        public string Help { get; set; }

        [Description("ID for the NuGet package.")]
        public string PackageId { get; set; }

        [Description("Exact name of the main executable found in the './tools' folder. Case-sensitive.")]
        public string PackageExecutable { get; set; }

        [Description("Exact name of the environment variable that contains the path to the executable.")]
        public string EnvironmentExecutable { get; set; }

        [Description("Exact name of the executable that can be found via 'where' or 'which'.")]
        public string PathExecutable { get; set; }

        [Description("Defines that locating the executable is implemented customly.")]
        public bool CustomExecutable { get; set; }

        [Description("Enables custom log level parsing.")]
        public bool LogLevelParsing { get; set; }

        [Description("Help or introduction text to for the tool. Can contain HTML tags for better formatting.")]
        public List<Task> Tasks { get; set; } = new List<Task>();

        [Description("Common properties for all tasks.")]
        public List<Property> CommonTaskProperties { get; set; } = new List<Property>();

        [Description("Named common property sets which can be used by tasks.")]
        public Dictionary<string, List<Property>> CommonTaskPropertySets { get; set; } = new Dictionary<string, List<Property>>();

        [Description("Common used data classes.")]
        public List<DataClass> DataClasses { get; set; } = new List<DataClass>();

        [Description("Used enumerations.")]
        public List<Enumeration> Enumerations { get; set; } = new List<Enumeration>();
    }
}
