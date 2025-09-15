// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Execution;

[PublicAPI]
public class ArgumentsFromParametersFileAttribute : BuildExtensionAttributeBase, IOnBuildCreated
{
    public void OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets)
    {
        // TODO: probably remove
        if (!Constants.GetNukeDirectory(NukeBuild.RootDirectory).DirectoryExists())
            return;


        // IEnumerable<string> ConvertToArguments(string profile, string name, string[] values)
        // {
        //     var member = parameterMembers.SingleOrDefault(x => ParameterService.GetParameterMemberName(x).EqualsOrdinalIgnoreCase(name));
        //     var scalarType = member?.GetMemberType().GetScalarType();
        //     var mustDecrypt = (member?.HasCustomAttribute<SecretAttribute>() ?? false) && !BuildServerConfigurationGeneration.IsActive;
        //     var decryptedValues = values.Select(x => mustDecrypt ? DecryptValue(profile, name, x) : x);
        //     var convertedValues = decryptedValues.Select(x => ConvertValue(scalarType, x)).ToList();
        //     Log.Verbose("Passing value for {Member} ({Value})",
        //         member?.GetDisplayName() ?? "<unresolved>",
        //         !mustDecrypt ? convertedValues.JoinComma() : "secret");
        //     return new[] { $"--{ParameterService.GetParameterDashedName(name)}" }.Concat(convertedValues);
        // }
        //

        //
        // // TODO: Abstract AbsolutePath/Solution/Project etc.
        // string ConvertValue(Type scalarType, string value)
        //     => scalarType == typeof(AbsolutePath) ||
        //        typeof(Solution).IsAssignableFrom(scalarType) ||
        //        scalarType == typeof(Project)
        //         ? EnvironmentInfo.WorkingDirectory.GetUnixRelativePathTo(NukeBuild.RootDirectory / value)
        //         : value;

        var parameterMembers = ValueInjectionUtility.GetParameterMembers(Build.GetType(), includeUnlisted: true);
        var jobjectsAndProfiles = new[] { (File: Constants.GetDefaultParametersFile(NukeBuild.RootDirectory), Profile: Constants.DefaultProfileName) }
            .Where(x => File.Exists(x.File))
            .Concat(NukeBuild.LoadedLocalProfiles.Select(x => (File: Constants.GetParametersProfileFile(NukeBuild.RootDirectory, x), Profile: x)))
            .ForEachLazy(x => Assert.FileExists(x.File))
            .Select(x => (JObject: JObject.Parse(File.ReadAllText(x.File)), x.Profile))
            .Reverse();

        var passwords = new Dictionary<string, string>();

        string DecryptValue(string profile, string name, string value)
            => EncryptionUtility.Decrypt(
                value,
                passwords[profile] = passwords.GetValueOrDefault(profile) ?? CredentialStore.GetPassword(profile, Build.RootDirectory),
                name);

        ParameterService.Instance.ArgumentsFromFilesService = (parameter, destinationType) =>
        {
            var (property, profile) = jobjectsAndProfiles.Select(x => (Property: x.JObject.Property(parameter), x.Profile))
                .Where(x => x.Property != null)
                .FirstOrDefault();
            if (property == null)
                return null;

            var member = parameterMembers.SingleOrDefault(x => ParameterService.GetParameterMemberName(x).EqualsOrdinalIgnoreCase(parameter));
            var scalarType = member?.GetMemberType().GetScalarType();
            if (typeof(IAbsolutePathHolder).IsAssignableFrom(scalarType))
                return property.Value.ToObject<string>().Apply(x => !PathConstruction.HasPathRoot(x) ? NukeBuild.RootDirectory / x : (AbsolutePath)x);

            if ((member?.HasCustomAttribute<SecretAttribute>() ?? false) &&
                !BuildServerConfigurationGeneration.IsActive)
                return DecryptValue(profile, parameter, property.Value.ToObject<string>());

            return property.Value.ToObject(destinationType);
        };
    }
}
