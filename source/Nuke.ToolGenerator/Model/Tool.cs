// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Nuke.ToolGenerator.Model
{
    [UsedImplicitly]
    [DebuggerDisplay("{" + nameof(DefinitionFile) + "}")]
    public class Tool
    {
        [JsonIgnore]
        public string DefinitionFile { get; set; }

        [JsonIgnore]
        public string GenerationFile { get; set; }

        [JsonIgnore]
        public string ReferenceFile { get; set; }

        public Reference Reference { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The url to the tool's offical website.
        /// </summary>
        /// <remarks>
        /// This official url is copied to all involved top-level members.
        /// </remarks>
        public string OfficialUrl { get; set; }

        /// <summary>
        /// The brief help text, best taken from the project website.
        /// </summary>
        /// <remarks>
        /// This help text is copied to all involved top-level members.
        /// </remarks>
        public string Help { get; set; }

        /// <summary>
        /// The task.
        /// </summary>
        [CanBeNull]
        public Task Task { get; set; }

        /// <summary>
        /// The list of data classes.
        /// </summary>
        public List<DataClass> DataClasses { get; set; } = new List<DataClass>();

        /// <summary>
        /// The list of enumerations.
        /// </summary>
        public List<Enumeration> Enumerations { get; set; } = new List<Enumeration>();
    }
}
