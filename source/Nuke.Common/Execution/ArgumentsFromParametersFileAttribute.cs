// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;
using static Nuke.Common.CI.BuildServerConfigurationGenerationAttributeBase;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public class ArgumentsFromParametersFileAttribute : BuildExtensionAttributeBase, IOnBuildCreated
    {
        private bool GenerationMode { get; } = EnvironmentInfo.GetParameter<string>(ConfigurationParameterName) != null;

        public void OnBuildCreated(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (!Directory.Exists(Constants.GetNukeDirectory(NukeBuild.RootDirectory)))
                return;

            var parameterMembers = ValueInjectionUtility.GetParameterMembers(build.GetType(), includeUnlisted: true);
            var passwords = new Dictionary<string, byte[]>();

            IEnumerable<string> ConvertToArguments(string profile, string name, string[] values)
            {
                var member = parameterMembers.SingleOrDefault(x => x.Name.EqualsOrdinalIgnoreCase(name));
                var scalarType = member?.GetMemberType().GetScalarType();
                var mustDecrypt = (member?.HasCustomAttribute<SecretAttribute>() ?? false) && !GenerationMode;
                var decryptedValues = values.Select(x => mustDecrypt ? DecryptValue(profile, name, x) : x);
                var convertedValues = decryptedValues.Select(x => ConvertValue(scalarType, x));
                Logger.Trace($"Passing argument for '{name}'{(member != null ? $" on '{member.DeclaringType.NotNull().Name}'" : string.Empty)}.");
                return new[] { $"--{ParameterService.GetParameterDashedName(name)}" }.Concat(convertedValues);
            }

            string DecryptValue(string profile, string name, string value)
                => EncryptionUtility.Decrypt(
                    value,
                    passwords[profile] = passwords.GetValueOrDefault(profile) ?? Encoding.UTF8.GetBytes(EncryptionUtility.GetPassword(profile)),
                    name);

            // TODO: Abstract AbsolutePath/Solution/Project etc.
            string ConvertValue(Type scalarType, string value)
                => scalarType == typeof(AbsolutePath) ||
                   typeof(Solution).IsAssignableFrom(scalarType) ||
                   scalarType == typeof(Project)
                    ? EnvironmentInfo.WorkingDirectory.GetUnixRelativePathTo(NukeBuild.RootDirectory / value)
                    : value;

            var arguments = GetParameters().SelectMany(x => ConvertToArguments(x.Profile, x.Name, x.Values)).ToArray();
            ParameterService.Instance.ArgumentsFromFilesService = new ParameterService(() => arguments, () => throw new NotSupportedException());
        }

        private IEnumerable<(string Profile, string Name, string[] Values)> GetParameters()
        {
            IEnumerable<string> GetValues(JProperty property)
                => property.Value is JArray array
                    ? array.Values<string>()
                    : property.Values<string>();

            IEnumerable<(string Name, string[] Values)> Load(AbsolutePath file)
            {
                try
                {
                    var jobject = JObject.Parse(File.ReadAllText(file));
                    return jobject.Properties()
                        .Where(x => x.Name != "$schema")
                        .Select(x => (x.Name, GetValues(x).ToArray()));
                }
                catch (Exception exception)
                {
                    throw new Exception($"Failed to parse parameters file '{file}'.", exception);
                }
            }

            return new[] { (File: Constants.GetDefaultParametersFile(NukeBuild.RootDirectory), Profile: Constants.DefaultProfileName) }
                .Concat(NukeBuild.LoadedLocalProfiles.Select(x => (File: Constants.GetParametersProfileFile(NukeBuild.RootDirectory, x), Profile: x)))
                .ForEachLazy(x => ControlFlow.Assert(File.Exists(x.File), $"File.Exists({x.File})"))
                .SelectMany(x => Load(x.File), (x, r) => (x.Profile, r.Name, r.Values));
        }
    }
}
