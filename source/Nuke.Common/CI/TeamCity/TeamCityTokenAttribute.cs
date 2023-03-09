// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.TeamCity
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TeamCityTokenAttribute : Attribute
    {
        public TeamCityTokenAttribute(string name, string guid)
        {
            Name = name;
            Guid = guid;
        }

        public string Name { get; }
        public string Guid { get; }
    }
}
