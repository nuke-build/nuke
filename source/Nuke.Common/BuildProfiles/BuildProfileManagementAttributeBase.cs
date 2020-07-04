// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DeviceId;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nuke.Common.Execution;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.BuildProfiles
{
    public class BuildProfileManagementAttributeBase : BuildExtensionAttributeBase
    {
        private const string DefaultProfile = "default";
        private const char Separator = ':';

        public static string[] GetLoadProfiles()
        {
            return new[] { DefaultProfile }
                .Where(x => File.Exists(GetProfileFile(x)))
                .Concat(EnvironmentInfo.GetParameter(() => NukeBuild.LoadedProfiles) ?? new string[0])
                .ToArray();
        }

        public static string GetSaveProfile()
        {
            return EnvironmentInfo.GetParameter(() => NukeBuild.SaveProfile)
                   ?? (EnvironmentInfo.GetParameter<bool>(() => NukeBuild.SaveProfile)
                       ? DefaultProfile
                       : null);
        }

        private static string GetProfileName(string profile)
        {
            return profile.Split(Separator).First();
        }

        private static string GetProfileKey(string profile)
        {
            return profile.Split(Separator).ElementAtOrDefault(1) ??
                   new DeviceIdBuilder()
                       .AddMachineName()
                       .AddUserName()
                       .AddMotherboardSerialNumber().ToString();
        }

        protected static string GetProfileFile(string profile)
        {
            return Path.ChangeExtension(NukeBuild.TemporaryDirectory / GetProfileName(profile), ".json");
        }

        protected JsonSerializerSettings GetSerializerSettings(string profile)
        {
            return new JsonSerializerSettings
                   {
                       ContractResolver = new CustomContractResolver(GetProfileKey(profile), ShouldSerialize)
                   };
        }

        protected virtual bool ShouldSerialize(MemberInfo member)
        {
            return EnvironmentInfo.HasArgument(member);
        }

        private class CustomContractResolver : DefaultContractResolver
        {
            private readonly string _key;
            private readonly Func<MemberInfo, bool> _shouldSerialize;

            public CustomContractResolver(string key, Func<MemberInfo, bool> shouldSerialize)
            {
                _key = key;
                _shouldSerialize = shouldSerialize;
            }

            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                return type.GetFields(ReflectionService.All)
                    .Concat(type.GetProperties(ReflectionService.All).Cast<MemberInfo>())
                    .Where(x => x.HasCustomAttribute<ParameterAttribute>())
                    .Select(x => CreateProperty(x, memberSerialization))
                    .ToList();
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                property.ShouldSerialize = x => _shouldSerialize(member);

                var secretAttribute = member.GetCustomAttribute<SecretAttribute>();
                if (secretAttribute != null)
                    property.Converter = secretAttribute.GetConverter(member, _key);

                if (member is FieldInfo)
                {
                    property.Writable = true;
                    property.Readable = true;
                }

                return property;
            }
        }
    }
}
