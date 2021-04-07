// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.CI
{
    [PublicAPI]
    public static class ArtifactExtensions
    {
        // private static readonly TargetDefinitionMetadata<int> PartitionKey =
        //     new TargetDefinitionMetadata<int>(nameof(PartitionKey));
        //
        // private static readonly TargetDefinitionMetadata<List<string>> ArtifactProductsKey =
        //     new TargetDefinitionMetadata<List<string>>(nameof(ArtifactProductsKey));
        //
        // private static readonly TargetDefinitionMetadata<LookupTable<Target, string>> ArtifactDependenciesKey =
        //     new TargetDefinitionMetadata<LookupTable<Target, string>>(nameof(ArtifactDependenciesKey));

        internal static readonly Dictionary<ITargetDefinition, (string, int)> Partitions =
            new Dictionary<ITargetDefinition, (string, int)>();

        internal static readonly LookupTable<ITargetDefinition, string> ArtifactProducts =
            new LookupTable<ITargetDefinition, string>();

        internal static readonly LookupTable<ITargetDefinition, (Target, string[])> ArtifactDependencies =
            new LookupTable<ITargetDefinition, (Target, string[])>();

        public static ITargetDefinition Produces(this ITargetDefinition targetDefinition, params string[] artifacts)
        {
            ArtifactProducts.AddRange(targetDefinition, artifacts);
            return targetDefinition;
        }

        public static ITargetDefinition Consumes(this ITargetDefinition targetDefinition, params Target[] targets)
        {
            targets.ForEach(x => targetDefinition.Consumes(x));
            return targetDefinition;
        }

        public static ITargetDefinition Consumes(this ITargetDefinition targetDefinition, Target target, params string[] artifacts)
        {
            ArtifactDependencies.Add(targetDefinition, (target, artifacts));
            return targetDefinition;
        }

        public static ITargetDefinition Partition(this ITargetDefinition targetDefinition, Expression<Func<Partition>> partition)
        {
            var member = partition.GetMemberInfo();
            Partitions.Add(targetDefinition, (member.Name, member.GetCustomAttribute<PartitionAttribute>().Total));
            return targetDefinition;
        }
    }
}
