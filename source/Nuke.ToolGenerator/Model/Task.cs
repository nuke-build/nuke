// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Nuke.ToolGenerator.Model
{
    [UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.WithMembers)]
    public class Task
    {
        [JsonIgnore]
        public Tool Tool { get; set; }

        [CanBeNull]
        public string Help { get; set; }

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
        /// The related settings class.
        /// </summary>
        public SettingsClass SettingsClass { get; set; }
    }
}
