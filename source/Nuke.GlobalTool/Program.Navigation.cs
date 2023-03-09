// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using static Nuke.Common.Constants;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        // function nuke- { nuke :PopDirectory; cd $(nuke :GetNextDirectory) }
        // function nuke/ { nuke :PushWithChosenRootDirectory; cd $(nuke :GetNextDirectory) }
        // function nuke. { nuke :PushWithCurrentRootDirectory; cd $(nuke :GetNextDirectory) }
        // function nuke.. { nuke :PushWithParentRootDirectory; cd $(nuke :GetNextDirectory) }

        private static string SessionId
            => EnvironmentInfo.Platform switch
            {
                PlatformFamily.OSX => EnvironmentInfo.GetVariable("TERM_SESSION_ID").NotNull()[7..],
                PlatformFamily.Windows => EnvironmentInfo.GetVariable("WT_SESSION").NotNull(),
                _ => throw new NotSupportedException($"{EnvironmentInfo.Platform} has no session id selector.")
            };

        private static AbsolutePath SessionFile => GlobalTemporaryDirectory / $"nuke-{SessionId}.dat";

        [UsedImplicitly]
        private static int GetNextDirectory(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            var content = SessionFile.Existing()?.ReadAllLines();
            if (content == null || string.IsNullOrWhiteSpace(content[0]))
            {
                Console.WriteLine(EnvironmentInfo.WorkingDirectory);
                return 1;
            }

            var nextDirectory = content[0];
            content[0] = string.Empty;
            SessionFile.WriteAllLines(content);
            Console.WriteLine(nextDirectory);
            return 0;
        }

        [UsedImplicitly]
        private static int PopDirectory(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            var content = SessionFile.Existing()?.ReadAllLines().ToList();
            if (content == null || content.Count <= 1)
            {
                Console.Error.WriteLine("No previous directory");
                return 1;
            }

            content[0] = content[1];
            content.RemoveAt(1);
            SessionFile.WriteAllLines(content);
            return 0;
        }

        [UsedImplicitly]
        private static int PushWithCurrentRootDirectory(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            return PushAndSetNext(() => rootDirectory.NotNull("No root directory"));
        }

        [UsedImplicitly]
        private static int PushWithParentRootDirectory(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            return PushAndSetNext(() => TryGetRootDirectoryFrom(Path.GetDirectoryName(rootDirectory.NotNull("No root directory")))
                .NotNull("No parent root directory"));
        }

        [UsedImplicitly]
        private static int PushWithChosenRootDirectory(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            return PushAndSetNext(() =>
            {
                var directories = EnvironmentInfo.WorkingDirectory.GlobDirectories($"**/{NukeDirectoryName}")
                    .Concat(EnvironmentInfo.WorkingDirectory.GlobFiles($"**/{NukeDirectoryName}"))
                    .Where(x => !x.Equals(EnvironmentInfo.WorkingDirectory))
                    .Select(x => x.Parent)
                    .Select(x => (x, EnvironmentInfo.WorkingDirectory.GetRelativePathTo(x).ToString()))
                    .OrderBy(x => x.Item2).ToArray();

                return PromptForChoice("Where to go next?", directories);
            });
        }

        private static int PushAndSetNext(Func<string> directoryProvider)
        {
            try
            {
                var content = SessionFile.Existing()?.ReadAllLines().ToList() ?? new List<string> { null };
                content[0] = directoryProvider.Invoke();
                content.Insert(index: 1, EnvironmentInfo.WorkingDirectory);
                SessionFile.WriteAllLines(content);
                return 0;
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine(exception.Message);
                return 1;
            }
        }
    }
}
