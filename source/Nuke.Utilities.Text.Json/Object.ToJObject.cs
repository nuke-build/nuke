// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nuke.Common.Utilities;

public static class ObjectExtensions
{
    public static JObject ToJObject(this object obj, JsonSerializer serializer = null)
    {
        serializer ??= JsonSerializer.CreateDefault();
        return JObject.FromObject(obj, serializer);
    }
}
