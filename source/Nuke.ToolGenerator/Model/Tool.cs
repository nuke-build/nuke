// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Nuke.ToolGenerator.Model
{
    [UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.WithMembers)]
    [DebuggerDisplay("{" + nameof(DefinitionFile) + "}")]
    public class Tool
    {
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
        /// NuGet package id that contains the executable.
        /// </summary>
        /// <remarks>
        /// Also requires <see cref="PackageExecutable"/> to be set.
        /// </remarks>
        public string PackageId { get; set; }

        /// <summary>
        /// Name of the executable that is contained in a NuGet package.
        /// </summary>
        /// <remarks>
        /// Also requires <see cref="PackageId"/> to bet set.
        /// </remarks>
        public string PackageExecutable { get; set; }

        /// <summary>
        /// Environment variable that holds the path to the executable.
        /// </summary>
        public string EnvironmentExecutable { get; set; }

        /// <summary>
        /// Defines a executable to use from PATH.
        /// </summary>
        public string PathExecutable { get; set; }

        /// <summary>
        /// If set to <c>true</c>, will call a custom executable provider method.
        /// </summary>
        public bool CustomExecutable { get; set; }

        [CanBeNull]
        public string IconClass { get; set; }

        /// <summary>
        /// The list of tasks.
        /// </summary>
        public List<Task> Tasks { get; set; } = new List<Task>();

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
