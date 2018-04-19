#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Tooling
{
    public delegate T Configure<T>(T settings);

    public static class ConfigureExtensions
    {
        public static T InvokeSafe<T>([CanBeNull] this Configure<T> configurator, T obj)
        {
            return (configurator ?? (x => x)).Invoke(obj);
        }
    }
}
