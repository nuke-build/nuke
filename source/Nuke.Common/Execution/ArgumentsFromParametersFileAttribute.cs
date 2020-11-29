// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;
using static Nuke.Common.CI.BuildServerConfigurationGenerationAttributeBase;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public class ArgumentsFromParametersFileAttribute : BuildExtensionAttributeBase, IOnBeforeLogo
    {
        public void OnBeforeLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var parameterMembers = ValueInjectionUtility.GetParameterMembers(build.GetType(), includeUnlisted: true);

            IEnumerable<string> ConvertToArguments(string name, string[] values)
            {
                var member = parameterMembers.SingleOrDefault(x => x.Name.EqualsOrdinalIgnoreCase(name));
                var scalarType = member?.GetMemberType().GetScalarType();
                Logger.Trace($"Passing argument for '{name}'{(member != null ? $" on '{member.DeclaringType.NotNull().Name}'" : string.Empty)}.");
                return new[] { $"--{ParameterService.GetParameterDashedName(name)}" }.Concat(values.Select(x => ConvertValue(scalarType, x)));
            }

            // TODO: Abstract AbsolutePath/Solution/Project etc.
            string ConvertValue(Type scalarType, string value)
                => scalarType == typeof(AbsolutePath) ||
                   scalarType == typeof(Solution) ||
                   scalarType == typeof(Project)
                    ? EnvironmentInfo.WorkingDirectory.GetUnixRelativePathTo(NukeBuild.RootDirectory / value)
                    : value;

            var arguments = GetParameters().SelectMany(x => ConvertToArguments(x.Name, x.Values)).ToArray();
            ParameterService.Instance.ArgumentsFromFilesService = new ParameterService(() => arguments, () => throw new NotSupportedException());
        }

        private IEnumerable<(string Name, string[] Values)> GetParameters()
        {
            JObject Load(string file)
            {
                try
                {
                    return JObject.Parse(File.ReadAllText(file));
                }
                catch (Exception exception)
                {
                    throw new Exception($"Failed to parse file '{file}'.", exception);
                }
            }

            return new[]
                   {
                       Constants.GetLocalParametersFile(NukeBuild.RootDirectory),
                       Constants.GetLocalParametersUserFile(NukeBuild.RootDirectory)
                   }
                .Where(x => File.Exists(x))
                .Select(x => Load(x))
                .SelectMany(GetParameters);
        }

        private IEnumerable<(string Name, string[] Values)> GetParameters(JObject json)
        {
            var profiles = json["$profiles"]
                               ?.Children<JProperty>()
                               .Where(x => x.Name.EqualsAnyOrdinalIgnoreCase(NukeBuild.LoadedLocalProfiles))
                               .SelectMany(x => x.Values<JObject>()).ToArray()
                           ?? new JObject[0];

            json.Remove("$schema");
            json.Remove("$profiles");

            IEnumerable<string> GetValues(JProperty property)
                => property.Value is JArray array
                    ? array.Values<string>()
                    : property.Values<string>();

            return new[] { json }.Concat(profiles).SelectMany(x => x.Properties()).Select(x => (x.Name, GetValues(x).ToArray()));
        }
    }
}
