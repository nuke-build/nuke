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
    internal sealed class JenkinsParametersReader
    {
        private readonly NukeBuild _build;

        /// <summary>
        /// Initializes a new instance of <see cref="JenkinsParametersReader"/> class.
        /// </summary>
        /// <param name="build">Instance of <see cref="NukeBuild"/>.</param>
        public JenkinsParametersReader(NukeBuild build)
        {
            _build = build;
        }

        public IEnumerable<JenkinsParameter> GetGlobalParameters(IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return ValueInjectionUtility.GetParameterMembers(_build.GetType(), includeUnlisted: false)
                .Except(relevantTargets.SelectMany(x => x.Requirements
                    .Where(y => !(y is Expression<Func<bool>>))
                    .Select(y => y.GetMemberInfo())))
                .Where(x => x.DeclaringType != typeof(NukeBuild) || x.Name == nameof(NukeBuild.Verbosity))
                .Select(GetParameter);
        }

        private JenkinsParameter GetParameter(MemberInfo member)
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
            JenkinsParameterType GetParameterType()
            {
                if (member.GetMemberType() == typeof(bool?))
                    return JenkinsParameterType.BooleanParameter;

                if (member.GetMemberType().IsEnum)
                    return JenkinsParameterType.ChoiceParameter;

                return JenkinsParameterType.StringParameter;
            }

            var parameterType = GetParameterType();

            JenkinsParameter parameter = parameterType switch
            {
                JenkinsParameterType.StringParameter =>
                    new JenkinsStringParameter(member.Name, defaultValue?.ToString() ?? "", attribute.Description),

                JenkinsParameterType.BooleanParameter =>
                    new JenkinsBooleanParameter(member.Name, bool.Parse(defaultValue?.ToString() ?? "false"), attribute.Description),

                JenkinsParameterType.ChoiceParameter
                    => new JenkinsChoiceParameter(member.Name,
                        defaultValue?.ToString() ?? "",
                        attribute.Description,
                        valueSet?.Select(x => x.Text).ToArray()),

                _ => throw new ArgumentException("The selected parameter type is not currently supported")
            };

            return parameter;
        }
    }
}
