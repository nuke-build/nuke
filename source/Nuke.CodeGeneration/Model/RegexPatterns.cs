// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.CodeGeneration.Model
{
    internal static class RegexPatterns
    {
        public const string Name = "^[A-Z][a-z]+(?:[A-Z0-9][a-z0-9]+)*$";
    }
}
