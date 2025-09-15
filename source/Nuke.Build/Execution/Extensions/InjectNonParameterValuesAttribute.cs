// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;

namespace Nuke.Common.ValueInjection;

internal class InjectNonParameterValuesAttribute : BuildExtensionAttributeBase, IOnBuildInitialized
{
    public void OnBuildInitialized(
        IReadOnlyCollection<ExecutableTarget> executableTargets,
        IReadOnlyCollection<ExecutableTarget> executionPlan)
    {
        ValueInjectionUtility.InjectValues(Build, (member, attribute) =>
        {
            if (attribute.GetType() == typeof(ParameterAttribute))
                return false;

            if (!Build.GetType().HasCustomAttribute<OnDemandValueInjectionAttribute>() &&
                !member.HasCustomAttribute<OnDemandAttribute>())
                return true;

            if (member.HasCustomAttribute<RequiredAttribute>())
                return false;

            var requiredMembers = executionPlan.SelectMany(x => x.DelegateRequirements)
                .Where(x => x is not Expression<Func<bool>>)
                .Select(x => x.GetMemberInfo()).ToList();

            return requiredMembers.Contains(member);
        });
    }
}
