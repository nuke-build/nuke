// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.ToolGenerator
{
    public static class Extensions
    {
        [AssertionMethod]
        [ContractAnnotation("obj: null => halt")]
        public static T NotNull<T> ([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull] this T obj, string text = null)
            where T : class
        {
            if (obj == null)
                throw new Exception($"Assertion \"{text ?? "obj != null"}\" failed.");
            return obj;
        }

        public static void ForEach<T> (this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
                action(item);
        }
    }
}
