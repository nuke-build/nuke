// Copyright Matthias Koch, Sebastian Karasek 2018.
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
