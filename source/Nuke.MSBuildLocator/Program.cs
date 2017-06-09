// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Tools.MSBuild;

namespace Nuke.MSBuildLocator
{
    public static class Program
    {
        [STAThread]
        public static void Main ()
        {
            var msbuildPath = MSBuildToolPathResolver.Resolve();
            Console.WriteLine(msbuildPath);
        }
    }
}
