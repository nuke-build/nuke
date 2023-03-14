// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common.Execution
{
    internal class InjectPreviousStateAttribute : BuildExtensionAttributeBase, IOnBuildCreated
    {
        public void OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var stateFile = Build.TemporaryDirectory / "state.json";
            if (!stateFile.Exists())
                return;

            var state = stateFile.ReadJson();
            var jsonSerializer = new JsonSerializer { ContractResolver = new StateResolver() };
            foreach (var property in state.Properties())
            {
                var member = Build.GetType().GetMember(property.Name, ReflectionUtility.All).SingleOrDefault();
                var value = property.Value.ToObject(member.GetMemberType(), jsonSerializer);
                member.SetValue(Build, value);
            }
        }
    }

    internal class SerializeCurrentStateAttribute : BuildExtensionAttributeBase, IOnBuildFinished
    {
        public void OnBuildFinished()
        {
            var stateFile = Build.TemporaryDirectory / "state.json";
            var settings = new JsonSerializerSettings { ContractResolver = new StateResolver(), Formatting = Formatting.Indented };
            stateFile.WriteJson(Build, settings);
        }
    }

    public class StateResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            property.Readable = true;
            property.Writable = true;
            property.ShouldSerialize =
                obj => member.GetValue(obj) != member.GetMemberType().GetDefaultValue() ||
                       member.GetCustomAttribute<StateAttribute>() is { DefaultValueHandling: ValueHandling.Include };
            return property;
        }

        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            return objectType.IsAssignableTo(typeof(NukeBuild))
                ? objectType.GetAllMembers(x => x.HasCustomAttribute<StateAttribute>(), ReflectionUtility.All, allowAmbiguity: false).ToList()
                : base.GetSerializableMembers(objectType);
        }
    }
}
