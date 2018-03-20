// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tools.MSBuild;

namespace Nuke.MSBuildLocator
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var msbuildPath = MSBuildToolPathResolver.Resolve();
            Console.WriteLine(msbuildPath);
        }
    }
}
