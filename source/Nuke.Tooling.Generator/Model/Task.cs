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
    [UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.WithMembers)]
    public class Task : IDeprecatable
    {
        [JsonIgnore]
        public Tool Tool { get; set; }

        [NotNull]
        [JsonIgnore]
        public IDeprecatable Parent => Tool;

        [CanBeNull]
        [Description(
            "Help or introduction text to for the tool. Supports 'a-href', 'c', 'em', 'b', 'ul', 'li' and 'para' tags for better formatting.")]
        public string Help { get; set; }

        [CanBeNull]
        [Description("Postfix for the task alias.")]
        [RegularExpression(RegexPatterns.Name)]
        public string Postfix { get; set; }

        [CanBeNull]
        [Description("Return type of the task.")]
        public string ReturnType { get; set; }

        [Description("Skips appending of common task properties.")]
        public bool OmitCommonProperties { get; set; }

        [Description("Appends the properties of the named property sets.")]
        public List<string> CommonPropertySets { get; set; } = new();

        [Description("Generates a pre-process hook")]
        public bool PreProcess { get; set; }

        [Description("Generates a post-process hook")]
        public bool PostProcess { get; set; }

        [Description("Enables log level parsing")]
        public bool LogLevelParsing { get; set; }

        [Description("Custom start implementation.")]
        public bool CustomStart { get; set; }

        [Description("Custom process assertion implementation.")]
        public bool CustomAssertion { get; set; }

        [Description("Argument that will always be printed independently of any set property.")]
        public string DefiniteArgument { get; set; }

        [CanBeNull]
        [Description("Url of the task. If not specified, the tool url will be used.")]
        public string OfficialUrl { get; set; }

        [Description("The settings of the task.")]
        public SettingsClass SettingsClass { get; set; } = new();

        [Description("Obsolete message. Task is marked as obsolete when specified.")]
        public string DeprecationMessage { get; set; }
    }
}
