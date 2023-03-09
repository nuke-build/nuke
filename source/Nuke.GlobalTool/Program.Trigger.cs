// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tools.Git;
using Nuke.Common.Utilities;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        [UsedImplicitly]
        public static int Trigger(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            var repository = GitRepository.FromLocalDirectory(rootDirectory.NotNull()).NotNull("No Git repository");
            Assert.NotNull(repository.Branch, "Git repository must not be detached");
            Assert.NotEmpty(args);

            try
            {
                var messageBody = args.JoinSpace();
                GitTasks.Git($"commit --allow-empty -m {messageBody.DoubleQuote()}");
                GitTasks.Git($"push {repository.RemoteName} {repository.Head}:{repository.RemoteBranch}");
                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}
