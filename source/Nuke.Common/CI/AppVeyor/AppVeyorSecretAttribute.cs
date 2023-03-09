// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.CI.AppVeyor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AppVeyorSecretAttribute : Attribute
    {
        public AppVeyorSecretAttribute(string parameter, string value)
        {
            Parameter = parameter;
            Value = value;
        }

        public string Parameter { get; }
        public string Value { get; }
    }
}
