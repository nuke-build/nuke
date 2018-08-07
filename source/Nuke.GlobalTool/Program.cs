// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.GlobalTool
{
    public static partial class Program
    {
        private static string ScriptHost => EnvironmentInfo.IsWin ? "powershell" : "bash";
        private static string ScriptExtension => EnvironmentInfo.IsWin ? "ps1" : "sh";
        
        private const char c_commandPrefix = ':';

        private static void Main(string[] args)
        {
            try
            {
                Handle(args);
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message);
                Environment.Exit(exitCode: 1);
            }
        }

        private static void Handle(string[] args)
        {
            var rootDirectory = FileSystemTasks.FindParentDirectory(
                Directory.GetCurrentDirectory(),
                x => x.GetFiles(NukeBuild.ConfigurationFile).Any());
            
            var hasCommand = args.FirstOrDefault()?.StartsWithOrdinalIgnoreCase(c_commandPrefix.ToString()) ?? false;
            if (hasCommand)
            {
                var command = args.First().Trim(trimChar: c_commandPrefix);
                if (string.IsNullOrWhiteSpace(command))
                    ControlFlow.Fail($"No command specified. Usage is: nuke {c_commandPrefix}<command> [args]");

                var commandHandler = typeof(Program).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                    .SingleOrDefault(x => x.Name.EqualsOrdinalIgnoreCase(command));
                ControlFlow.Assert(commandHandler != null, $"Command '{command}' is not supported.");

                try
                {
                    commandHandler.Invoke(obj: null, parameters: new object[] { rootDirectory, args.Skip(count: 1).ToArray() });
                    return;
                }
                catch (TargetInvocationException ex)
                {
                    ControlFlow.Fail(ex.InnerException.Message);
                }
            }

            var buildScript = rootDirectory != null
                ? new DirectoryInfo(rootDirectory)
                    .EnumerateFiles($"build.{ScriptExtension}", maxDepth: 2)
                    .FirstOrDefault()?.FullName.DoubleQuoteIfNeeded()
                : null;

            if (buildScript == null)
            {
                if (UserConfirms($"Could not find {NukeBuild.ConfigurationFile} file. Do you want to setup a build?"))
                    Setup(rootDirectory, new string[0]);
                return;
            }

            // TODO: docker

            var arguments = args.Select(x => x.DoubleQuoteIfNeeded()).JoinSpace();
            var process = Process.Start(
                ScriptHost,
                EnvironmentInfo.IsWin
                    ? $"-File {buildScript} {arguments}"
                    : $"{buildScript} {arguments}").NotNull();

            process.WaitForExit();
            Environment.Exit(process.ExitCode);
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
