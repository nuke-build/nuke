// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    public sealed class ProcessSettings : ISettingsEntity
    {
        public ProcessSettings()
        {
            var variables = EnvironmentInfo.GetVariables();
            EnvironmentVariablesInternal = new Dictionary<string, string>(variables, variables.Comparer);
        }

        public IReadOnlyDictionary<string, string> EnvironmentVariables => EnvironmentVariablesInternal.AsReadOnly();
        internal Dictionary<string, string> EnvironmentVariablesInternal { get; set; }

        public int? ExecutionTimeout { get; internal set; }
        public bool RedirectOutput { get; internal set; }
    }
}
