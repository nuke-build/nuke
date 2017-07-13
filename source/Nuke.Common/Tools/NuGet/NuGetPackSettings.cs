// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;

namespace Nuke.Common.Tools.NuGet
{
    partial class NuGetPackSettings
    {
        [CanBeNull]
        private string GetProperties ()
        {
            ControlFlow.Assert(
                !Properties.ContainsKey("configuration") || Configuration == null || Properties["configuration"] == Configuration,
                "!Properties.ContainsKey('configuration') || Configuration == null || Properties['configuration'] == Configuration");

            var properties = new Dictionary<string, string>(PropertiesInternal);
            if (Configuration != null)
                properties["configuration"] = Configuration;

            return properties.Count != 0
                ? string.Join(";", properties.Select(x => $"{x.Key}={x.Value}"))
                : null;
        }
    }
}
