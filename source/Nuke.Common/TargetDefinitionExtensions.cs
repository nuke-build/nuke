// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common
{
    public static class TargetDefinitionExtensions
    {
        public static ITargetDefinition Executes(this ITargetDefinition definition, Target target)
        {
            target(definition);
            return definition;
        }
    }
}
