// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace Nuke.Core.Injection
{
    /// <inheritdoc />
    [PublicAPI]
    public abstract class StaticInjectionAttributeBase : InjectionAttributeBase
    {
        [CanBeNull]
        public abstract object GetStaticValue ();

        [CanBeNull]
        public override object GetValue (string memberName, Type memberType, NukeBuild build)
        {
            return GetStaticValue();
        }
    }
}
