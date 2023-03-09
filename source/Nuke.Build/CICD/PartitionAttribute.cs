// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;

namespace Nuke.Common.CI
{
    public class PartitionAttribute : ParameterAttribute
    {
        public PartitionAttribute(int total)
        {
            Total = total;
        }

        public int Total { get; }

        public override bool List => false;

        public override object GetValue(MemberInfo member, object instance)
        {
            var part = ParameterService.GetParameter<int?>(member);
            return part.HasValue
                ? new Partition { Part = part.Value, Total = Total }
                : Partition.Single;
        }
    }
}
