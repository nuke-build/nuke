﻿// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.GlobalTool
{
    public partial class Program
    {
        private const char CommandPrefix = ':';

        private static int Main(string[] args)
        {
            try
            {
                // TODO: parse from --root argument
                var rootDirectory = Constants.TryGetRootDirectoryFrom(Directory.GetCurrentDirectory());

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

        private static void PrintInfo()
        {
            Logger.Info($"NUKE Global Tool {typeof(Program).Assembly.GetInformationalText()}");
        }

        private static int Handle(string[] args, [CanBeNull] string rootDirectory, [CanBeNull] string buildScript)
        {
            var hasCommand = args.FirstOrDefault()?.StartsWithOrdinalIgnoreCase(CommandPrefix.ToString()) ?? false;
            if (hasCommand)
            {
                var command = args.First().Trim(CommandPrefix);
                if (string.IsNullOrWhiteSpace(command))
                    ControlFlow.Fail($"No command specified. Usage is: nuke {CommandPrefix}<command> [args]");

                var commandHandler = typeof(Program).GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                    .SingleOrDefault(x => x.Name.EqualsOrdinalIgnoreCase(command));
                ControlFlow.Assert(commandHandler != null, $"Command '{command}' is not supported.");
                // TODO: add assertions about return type and parameters

                var commandArguments = new object[] { args.Skip(count: 1).ToArray(), rootDirectory, buildScript };
                return (int) commandHandler.Invoke(obj: null, commandArguments);
            }

            if (rootDirectory == null || buildScript == null)
            {
                var missingFile = rootDirectory == null
                    ? Constants.ConfigurationFileName
                    : "build.ps1/sh";

                return UserConfirms($"Could not find {missingFile} file. Do you want to setup a build?")
                    ? Setup(new string[0], rootDirectory, buildScript: null)
                    : 0;
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
                Logger.Normal($"{question} [y/n]");
                response = Console.ReadKey(intercept: true).Key;
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return response == ConsoleKey.Y;
        }
    }
}
