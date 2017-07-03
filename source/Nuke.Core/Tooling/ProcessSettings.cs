// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core.Utilities.Collections;

namespace Nuke.Core.Tooling
{
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    public sealed class ProcessSettings : ISettingsEntity
    {
        public static ProcessSettings EmptyEnvironmentVariables => new ProcessSettings();

        public static ProcessSettings Default
        {
            get
            {
                var environmentVariables = Environment.GetEnvironmentVariables();
                return new ProcessSettings
                       {
                           EnvironmentVariablesInternal =
                                   environmentVariables.Keys.Cast<string>()
                                           .ToDictionary(
                                               x => x,
                                               x => (string) environmentVariables[x],
                                               StringComparer.OrdinalIgnoreCase)
                       };
            }
        }

        private ProcessSettings ()
        {
        }

        public IReadOnlyDictionary<string, string> EnvironmentVariables => EnvironmentVariablesInternal.AsReadOnly();

        internal Dictionary<string, string> EnvironmentVariablesInternal { get; set; } =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public int? ExecutionTimeout { get; internal set; }
        public bool RedirectOutput { get; internal set; }
    }
}
