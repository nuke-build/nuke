// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tooling;

internal class ObjectFromFieldConverter(Type type, string name) : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var rootProperty = GetRootMember(value.GetType());
        var options = JToken.FromObject(rootProperty.GetValue(value).NotNull(), serializer);
        options.WriteTo(writer);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        existingValue = Activator.CreateInstance(objectType);
        var rootProperty = GetRootMember(objectType);
        var jobject = JObject.Load(reader);
        rootProperty.SetValue(existingValue, jobject.ToObject(rootProperty.GetMemberType(), serializer));
        return existingValue;
    }

    public override bool CanRead => true;

    public override bool CanConvert(Type objectType)
    {
        return objectType.IsGenericType
            ? objectType.GetGenericTypeDefinition() == type
            : objectType.IsAssignableTo(type);
    }

    private MemberInfo GetRootMember(Type objectType)
    {
        return objectType.GetMembers(BindingFlags.Instance | BindingFlags.NonPublic).First(x => x.Name == name);
    }
}
