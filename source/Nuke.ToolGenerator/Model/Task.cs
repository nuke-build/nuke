// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Nuke.ToolGenerator.Model
{
    [UsedImplicitly]
    public class Task
    {
        [JsonIgnore]
        public Tool Tool { get; set; }

        // TODO: summary
        public bool SkipAttributes { get; set; }

        // TODO: summary
        [CanBeNull]
        public string IconClass { get; set; }

        /// <summary>
        /// The postfix that is appended to the task method. Usually, this is used for subcommands.
        /// </summary>
        [CanBeNull]
        public string Postfix { get; set; }

        /// <summary>
        /// If set to <c>true</c>, will generate a call to <c>StartProcess</c> which needs to be implemented in a partial class definition  .
        /// </summary>
        public bool CustomStart { get; set; }

        /// <summary>
        /// If set to <c>true</c>, will generate a call to <c>AssertProcess</c> which needs to be implemented in a partial class definition.
        /// Otherwise, just asserts the exit code to be zero.
        /// </summary>
        public bool CustomAssertion { get; set; }

        /// <summary>
        /// The argument that is always rendered.
        /// </summary>
        public string DefiniteArgument { get; set; }

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
        /// Custom expression that returns the executable.
        /// </summary>
        public string CustomExecutable { get; set; }

        /// <summary>
        /// The related settings class.
        /// </summary>
        public SettingsClass SettingsClass { get; set; }
    }
}
