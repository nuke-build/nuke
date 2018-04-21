// ReSharper disable All
#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

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
        public ProcessSettings()
        {
            var environmentVariables = Environment.GetEnvironmentVariables();
            EnvironmentVariablesInternal = environmentVariables.Keys.Cast<string>()
                .ToDictionary(x => x, x => (string) environmentVariables[x], StringComparer.OrdinalIgnoreCase);
        }

        public IReadOnlyDictionary<string, string> EnvironmentVariables => EnvironmentVariablesInternal.AsReadOnly();
        internal Dictionary<string, string> EnvironmentVariablesInternal { get; set; }

        public int? ExecutionTimeout { get; internal set; }
        public bool RedirectOutput { get; internal set; }
    }
}
