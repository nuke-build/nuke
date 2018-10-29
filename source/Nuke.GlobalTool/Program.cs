// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.GlobalTool
{
    public static partial class Program
    {
        private const char c_commandPrefix = ':';

        private static int Main(string[] args)
        {
            try
            {
                var rootDirectory = FileSystemTasks.FindParentDirectory(
                    Directory.GetCurrentDirectory(),
                    x => x.GetFiles(NukeBuild.ConfigurationFileName).Any());

                var buildScript = rootDirectory != null
                    ? new DirectoryInfo(rootDirectory)
                        .EnumerateFiles($"build.{(EnvironmentInfo.IsWin ? "ps1" : "sh")}", maxDepth: 2)
                        .FirstOrDefault()?.FullName.DoubleQuoteIfNeeded()
                    : null;
                
                return Handle(args, rootDirectory, buildScript);
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
                return 1;
            }
        }

        private static int Handle(string[] args, [CanBeNull] string rootDirectory, [CanBeNull] string buildScript)
        {
            var hasCommand = args.FirstOrDefault()?.StartsWithOrdinalIgnoreCase(c_commandPrefix.ToString()) ?? false;
            if (hasCommand)
            {
                var command = args.First().Trim(c_commandPrefix);
                if (string.IsNullOrWhiteSpace(command))
                    ControlFlow.Fail($"No command specified. Usage is: nuke {c_commandPrefix}<command> [args]");

                var commandHandler = typeof(Program).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                    .SingleOrDefault(x => x.Name.EqualsOrdinalIgnoreCase(command));
                ControlFlow.Assert(commandHandler != null, $"Command '{command}' is not supported.");
                // TODO: add assertions about return type and parameters

                var commandArguments = new object[] { args.Skip(count: 1).ToArray(), rootDirectory, buildScript };
                return (int) commandHandler.Invoke(obj: null, commandArguments);
            }

            if (buildScript == null)
            {
                if (UserConfirms($"Could not find {NukeBuild.ConfigurationFileName} file. Do you want to setup a build?"))
                    return Setup(new string[0], rootDirectory, buildScript: null);
                return 0;
            }

            // TODO: docker

            var arguments = args.Select(x => x.DoubleQuoteIfNeeded()).JoinSpace();
            var process = Build(buildScript, arguments);
            process.WaitForExit();
            return process.ExitCode;
        }

        private static Process Build(string buildScript, string arguments)
        {
            return Process.Start(
                new ProcessStartInfo
                {
                    FileName = EnvironmentInfo.IsWin 
                        ? ToolPathResolver.GetPathExecutable("powershell") 
                        : ToolPathResolver.GetPathExecutable("bash"),
                    Arguments = EnvironmentInfo.IsWin
                        ? $"-ExecutionPolicy ByPass -NoProfile -File {buildScript} {arguments}"
                        : $"{buildScript} {arguments}"
                }).NotNull();
        }

        private static bool UserConfirms(string question)
        {
            ConsoleKey response;
            do
            {
                Logger.Log($"{question} [y/n]");
                response = Console.ReadKey(intercept: true).Key;
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return response == ConsoleKey.Y;
        }
    }
}
