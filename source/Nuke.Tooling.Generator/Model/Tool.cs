// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Nuke.CodeGeneration.Model
{
    [UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.WithMembers)]
    [DebuggerDisplay("{" + nameof(SpecificationFile) + "}")]
    public class Tool : IDeprecatable
    {
        [JsonProperty("$schema")]
        public string Schema => "https://raw.githubusercontent.com/nuke-build/nuke/master/source/Nuke.Tooling.Generator/schema.json";

        [JsonIgnore] public string SpecificationFile { get; set; }
        [JsonIgnore] public string DefaultOutputFile => Path.ChangeExtension(SpecificationFile, "Generated.cs");
        [JsonIgnore] public string DefaultOutputFileName => Path.GetFileName(DefaultOutputFile);

        [JsonIgnore] public string SourceFile { get; set; }

        [JsonIgnore] public string Namespace { get; set; }

        [CanBeNull] [JsonIgnore] public IDeprecatable Parent => null;

        [Description("Contains all references on which this definition is based on. Allows checking for updates.")]
        public List<string> References { get; set; } = new();
        public List<string> Imports { get; set; } = new();

        [JsonProperty(Required = Required.Always)]
        [RegularExpression(RegexPatterns.Name)]
        [Description("Name of the Tool.")]
        public string Name { get; set; }

        [Url]
        [JsonProperty(Required = Required.Always)]
        [Description("Url to the official website.")]
        public string OfficialUrl { get; set; }

        [Description("Obsolete message. Tool is marked as obsolete when specified.")]
        public string DeprecationMessage { get; set; }

        [Description(
            "Help or introduction text to for the tool. Supports 'a-href', 'c', 'em', 'b', 'ul', 'li' and 'para' tags for better formatting.")]
        public string Help { get; set; }

        [JsonProperty(PropertyName = "nugetPackageId")]
        [Description("ID for the NuGet package.")]
        public string NuGetPackageId { get; set; }

        [Description("ID for the NPM package.")]
        public string NpmPackageId { get; set; }

        [JsonProperty(PropertyName = "aptPackageId")]
        [Description("ID for the AptGet package.")]
        public string AptGetPackageId { get; set; }

        [Description("Exact name of the main executable found in the './tools' folder. Case-sensitive.")]
        public string PackageExecutable { get; set; }

        [Description("Exact name of the executable that can be found via 'where' or 'which'.")]
        public string PathExecutable { get; set; }

        [Description("Defines that locating the executable is implemented customly.")]
        public bool CustomExecutable { get; set; }

        [Description("Enables custom logger.")]
        public bool CustomLogger { get; set; }

        [Description("Help or introduction text to for the tool. Can contain HTML tags for better formatting.")]
        public List<Task> Tasks { get; set; } = new();

        [Description("Common properties for all tasks.")]
        public List<Property> CommonTaskProperties { get; set; } = new();

        [Description("Named common property sets which can be used by tasks.")]
        public Dictionary<string, List<Property>> CommonTaskPropertySets { get; set; } = new();

        [Description("Common used data classes.")]
        public List<DataClass> DataClasses { get; set; } = new();

        [Description("Used enumerations.")]
        public List<Enumeration> Enumerations { get; set; } = new();

        [CanBeNull]
        [Description("Can be used to store additional information about the tool.")]
        [JsonProperty("_metadata")]
        public Dictionary<string, object> Metadata { get; set; }
    }
}
