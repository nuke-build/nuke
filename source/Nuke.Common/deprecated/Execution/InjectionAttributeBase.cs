#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Execution
{
    /// <summary>
    ///     Value injection is executed prior to build execution. Fields marked
    ///     with the attribute can be declared as <em>requirement</em> for any <see cref="Target" />
    ///     definitions using <see cref="ITargetDefinition.Requires"/>,
    ///     <see cref="ITargetDefinition.Requires{T}(System.Linq.Expressions.Expression{System.Func{T}}[])" />, or
    ///     <see cref="ITargetDefinition.Requires{T}(System.Linq.Expressions.Expression{System.Func{T?}}[])" />
    ///     and will therefore be subject for validation at execution start.
    /// </summary>
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    [MeansImplicitUse(ImplicitUseKindFlags.Default)]
    public abstract class InjectionAttributeBase : Attribute
    {
        [CanBeNull]
        public abstract object GetValue(string memberName, Type memberType);
    }
}
