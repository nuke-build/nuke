// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common.ProjectModel
{
    public class ProjectFromAttribute : ParameterAttribute
    {
        private readonly string _solutionMember;

        public ProjectFromAttribute(string solutionMember)
        {
            _solutionMember = solutionMember;
        }

        public override int Priority => -1;

        public override string Description => $"Project from solution";

        public override object GetValue(MemberInfo member, object instance)
        {
            var solution = GetSolution(instance);

            Project TryGetProject(Func<Project, bool> filter)
                => solution.AllProjects.SingleOrDefault(filter);

            Project GetProject(string name)
                => TryGetProject(x => x.Name.EqualsOrdinalIgnoreCase(name))
                    .NotNull($"No project '{name}' found in solution '{solution.FileName}'.");

            if (Name != null)
                return GetProject(Name);

            var projectNamePart = member.Name.TrimEnd("Project");
            var project = TryGetProject(x => x.Name
                .Replace(".", string.Empty)
                .Replace("-", string.Empty)
                .EndsWithOrdinalIgnoreCase(projectNamePart));
            if (project != null)
                return project;

            var parameterValue = ParameterService.Instance.GetParameter<string>(member);
            if (parameterValue != null)
                return GetProject(parameterValue);

            return null;
        }

        public override IEnumerable<(string, object)> GetValueSet(MemberInfo member, object instance)
        {
            if (member.GetValue(instance) != null)
                return null;

            var solution = GetSolution(instance);
            return solution.AllProjects.Select(x => (x.Name, (object) x));
        }

        private Solution GetSolution(object instance)
        {
            var solutionMember = instance.GetType().GetMember(_solutionMember, ReflectionService.All)
                .SingleOrDefault()
                .NotNull($"No single member '{_solutionMember}' found for type '{instance.GetType()}'.");
            return solutionMember.GetValue<Solution>(instance);
        }
    }
}
