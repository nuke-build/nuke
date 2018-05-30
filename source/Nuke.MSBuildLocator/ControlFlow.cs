// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.MSBuildLocator
{
    [PublicAPI]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public static class ControlFlow
    {
        [AssertionMethod]
        [ContractAnnotation("condition: false => halt")]
        public static void Assert(
            [AssertionCondition(AssertionConditionType.IS_TRUE)]
            bool condition,
            string text)
        {
            if (!condition)
                throw new Exception($"Assertion \"{text}\" failed.");
        }

        [AssertionMethod]
        [ContractAnnotation("obj: null => halt")]
        public static T NotNull<T>(
            [AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [CanBeNull]
            this T obj,
            string text = null)
            where T : class
        {
            if (obj == null)
                throw new Exception($"Assertion \"{text ?? "obj != null"}\" failed.");
            return obj;
        }
    }
}
