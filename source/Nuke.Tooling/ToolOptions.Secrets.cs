// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tooling;

partial class ToolOptions
{
    internal partial IEnumerable<string> GetSecrets()
    {
        return (ProcessRedactedSecrets ?? [])
            .Concat(InternalOptions.Properties()
                .Select(x => (Token: x.Value, Property: GetType().GetProperty(x.Name).NotNull()))
                .Select(x => (x.Token, x.Property, Attribute: x.Property.GetCustomAttribute<ArgumentAttribute>()))
                .Where(x => x.Attribute?.Secret ?? false)
                .Select(x =>
                {
                    Assert.True(x.Property.GetMemberType() == typeof(string));
                    return x.Token.Value<string>();
                }));
    }
}
