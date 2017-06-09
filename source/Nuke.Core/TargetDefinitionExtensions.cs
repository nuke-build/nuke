// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core
{
    public static class TargetDefinitionExtensions
    {
        public static ITargetDefinition Executes (this ITargetDefinition definition, Target target)
        {
            target(definition);
            return definition;
        }
    }
}
