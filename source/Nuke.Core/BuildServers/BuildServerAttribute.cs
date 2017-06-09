// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core.BuildServers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BuildServerAttribute : Attribute
    {
    }
}
