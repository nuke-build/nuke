// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.CodeGeneration.Model
{
    public interface IDeprecatable
    {
        [CanBeNull]
        string DeprecationMessage { get; }

        [CanBeNull]
        IDeprecatable Parent { get; }
    }

    public static class DeprecatableExtensions
    {
        [Pure]
        public static bool IsDeprecated(this IDeprecatable deprecatable)
        {
            return deprecatable.DeprecationMessage != null || deprecatable.Parent != null && deprecatable.Parent.IsDeprecated();
        }

        [Pure]
        [CanBeNull]
        public static string GetDeprecationMessage(this IDeprecatable deprecatable)
        {
            var message = deprecatable.DeprecationMessage;
            if (!string.IsNullOrEmpty(message))
                return message;
            return deprecatable.Parent?.GetDeprecationMessage();
        }
    }
}
