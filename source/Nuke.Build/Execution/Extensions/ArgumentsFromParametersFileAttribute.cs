// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;
using Serilog;

namespace Nuke.Common.Execution
{
    internal class ArgumentsFromParametersFileAttribute : BuildExtensionAttributeBase, IOnBuildCreated
    {
        public void OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            // TODO: probably remove
            if (!Directory.Exists(Constants.GetNukeDirectory(Build.RootDirectory)))
                return;

            var parameterMembers = ValueInjectionUtility.GetParameterMembers(Build.GetType(), includeUnlisted: true);
            var passwords = new Dictionary<string, string>();

            IEnumerable<string> ConvertToArguments(string profile, string name, string[] values)
            {
                var member = parameterMembers.SingleOrDefault(x => ParameterService.GetParameterMemberName(x).EqualsOrdinalIgnoreCase(name));
                var scalarType = member?.GetMemberType().GetScalarType();
                var mustDecrypt = (member?.HasCustomAttribute<SecretAttribute>() ?? false) && !BuildServerConfigurationGeneration.IsActive;
                var decryptedValues = values.Select(x => mustDecrypt ? DecryptValue(profile, name, x) : x);
                var convertedValues = decryptedValues.Select(x => ConvertValue(scalarType, x)).ToList();
                Log.Verbose("Passing value for {Member} ({Value})",
                    member?.GetDisplayName() ?? "<unresolved>",
                    !mustDecrypt ? convertedValues.JoinComma() : "secret");
                return new[] { $"--{ParameterService.GetParameterDashedName(name)}" }.Concat(convertedValues);
            }

            string DecryptValue(string profile, string name, string value)
                => EncryptionUtility.Decrypt(
                    value,
                    passwords[profile] = passwords.GetValueOrDefault(profile) ?? EncryptionUtility.GetPassword(profile, Build.RootDirectory),
                    name);

            // TODO: Abstract AbsolutePath/Solution/Project etc.
            string ConvertValue(Type scalarType, string value)
                => scalarType == typeof(AbsolutePath) ||
                   typeof(Solution).IsAssignableFrom(scalarType) ||
                   scalarType == typeof(Project)
                    ? EnvironmentInfo.WorkingDirectory.GetUnixRelativePathTo(Build.RootDirectory / value)
                    : value;

            var arguments = GetParameters().SelectMany(x => ConvertToArguments(x.Profile, x.Name, x.Values)).ToArray();
            ParameterService.Instance.ArgumentsFromFilesService = new ArgumentParser(arguments);
        }

        private IEnumerable<(string Profile, string Name, string[] Values)> GetParameters()
        {
            IEnumerable<string> GetValues(JProperty property)
            // TODO: if property is object || property is array && array contains objects => base64
                => property.Value is JArray array
                    ? array.Values<string>()
                    : property.Values<string>();

            IEnumerable<(string Name, string[] Values)> Load(AbsolutePath file)
            {
                try
                {
                    var jobject = JObject.Parse(file.ReadAllText());
                    // TODO: use NukeBuild instance to match members and walk through structure to replace secrets and absolute-paths
                    return jobject.Properties()
                        .Where(x => x.Name != "$schema")
                        .Select(x => (x.Name, GetValues(x).ToArray()));
                }
                catch (Exception exception)
                {
                    throw new Exception($"Failed parsing parameters file '{file}'.", exception);
                }
            }

            return new[] { (File: Constants.GetDefaultParametersFile(Build.RootDirectory), Profile: Constants.DefaultProfileName) }
                .Where(x => x.File.Exists())
                .Concat(Build.LoadedLocalProfiles.Select(x => (File: Constants.GetParametersProfileFile(Build.RootDirectory, x), Profile: x)))
                .ForEachLazy(x => Assert.FileExists(x.File))
                .SelectMany(x => Load(x.File), (x, r) => (x.Profile, r.Name, r.Values));
        }
    }
}
