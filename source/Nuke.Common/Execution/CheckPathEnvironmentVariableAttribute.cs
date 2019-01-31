// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class)]
    public class CheckPathEnvironmentVariableAttribute : Attribute, IPostLogoBuildExtension
    {
        public void Execute(NukeBuild build)
        {
            ProcessTasks.CheckPathEnvironmentVariable();
        }
    }
}
