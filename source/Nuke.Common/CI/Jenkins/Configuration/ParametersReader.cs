// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Nuke.Common.CI.Jenkins.Configuration.Parameters;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.CI.Jenkins.Configuration
{
    /// <summary>
    /// Parameters reader, as helper class for Jenkins parameter.
    /// </summary>
    internal sealed class ParametersReader
    {
        private readonly NukeBuild _build;

        /// <summary>
        /// Initializes a new instance of <see cref="ParametersReader"/> class.
        /// </summary>
        /// <param name="build">Instance of <see cref="NukeBuild"/>.</param>
        public ParametersReader(NukeBuild build)
        {
            _build = build;
        }

        public IEnumerable<Parameter> GetGlobalParameters(IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return ValueInjectionUtility.GetParameterMembers(_build.GetType(), includeUnlisted: false)
                .Except(relevantTargets.SelectMany(x => x.Requirements
                    .Where(y => !(y is Expression<Func<bool>>))
                    .Select(y => y.GetMemberInfo())))
                .Where(x => x.DeclaringType != typeof(NukeBuild) || x.Name == nameof(NukeBuild.Verbosity))
                .Select(GetParameter);
        }

        private Parameter GetParameter(MemberInfo member)
        {
            var attribute = member.GetCustomAttribute<ParameterAttribute>();
            var valueSet = ParameterService.GetParameterValueSet(member, _build);

            var defaultValue = member.GetValue(_build);
            if (defaultValue != null &&
                (member.GetMemberType() == typeof(AbsolutePath) ||
                 member.GetMemberType() == typeof(Solution) ||
                 member.GetMemberType() == typeof(Project)))
                defaultValue = (UnixRelativePath) PathConstruction.GetRelativePath(NukeBuild.RootDirectory, defaultValue.ToString());

            // get other parameter types !
            ParameterType GetParameterType()
            {
                if (member.GetMemberType() == typeof(bool?))
                    return ParameterType.BooleanParameter;

                if (member.GetMemberType().IsEnum)
                    return ParameterType.ChoiceParameter;

                return ParameterType.StringParameter;
            }

            var parameterType = GetParameterType();

            Parameter parameter = parameterType switch
            {
                ParameterType.StringParameter =>
                    new StringParameter(member.Name, defaultValue?.ToString() ?? "", attribute.Description),

                ParameterType.BooleanParameter =>
                    new BooleanParameter(member.Name, bool.Parse(defaultValue?.ToString() ?? "false"), attribute.Description),

                ParameterType.ChoiceParameter
                    => new ChoiceParameter(member.Name,
                        defaultValue?.ToString() ?? "",
                        attribute.Description,
                        valueSet?.Select(x => x.Text).ToArray()),

                _ => throw new ArgumentException("The selected parameter type is not currently supported")
            };

            return parameter;
        }
    }
}
