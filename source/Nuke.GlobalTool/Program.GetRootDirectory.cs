// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using static Nuke.Common.Constants;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        [UsedImplicitly]
        public static int GetRootDirectory(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            if (rootDirectory == null)
                Console.Error.WriteLine("No root directory found.");

            Console.WriteLine(rootDirectory ?? EnvironmentInfo.WorkingDirectory);
            return 0;
        }

        [UsedImplicitly]
        public static int GetParentRootDirectory(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            if (rootDirectory == null)
            {
                Console.Error.WriteLine("No root directory found.");
                Console.WriteLine(EnvironmentInfo.WorkingDirectory);
                return 0;
            }

            var parentRootDirectory = TryGetRootDirectoryFrom(Path.GetDirectoryName(rootDirectory));
            if (parentRootDirectory == null)
                Console.Error.WriteLine("No parent root directory found.");

            Console.WriteLine(parentRootDirectory ?? EnvironmentInfo.WorkingDirectory);
            return 0;
        }
    }
}
