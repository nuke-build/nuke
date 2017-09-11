// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace System.Diagnostics.CodeAnalysis
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class ExcludeAssemblyFromCodeCoverageAttribute : Attribute
    {
    }
}
