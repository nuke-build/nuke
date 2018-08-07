// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Execution
{
    /// <inheritdoc />
    [PublicAPI]
    public abstract class StaticInjectionAttributeBase : InjectionAttributeBase
    {
        [CanBeNull]
        public abstract object GetStaticValue();

        [CanBeNull]
        public override object GetValue(string memberName, Type memberType)
        {
            return GetStaticValue();
        }
    }
}
