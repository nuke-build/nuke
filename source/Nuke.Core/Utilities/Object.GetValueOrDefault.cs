// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Utilities
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class ObjectExtensions
    {
        [CanBeNull]
        public static TValue GetValueOrDefault<T, TValue> ([CanBeNull] this T obj, Func<T, TValue> valueSelector, Func<TValue> defaultSelector = null)
            where T : class
        {
            defaultSelector = defaultSelector ?? (() => default(TValue));

            return obj != null
                ? valueSelector(obj)
                : defaultSelector();
        }
    }
}
