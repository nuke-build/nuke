// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Net;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;

namespace Nuke.GlobalTool
{
    public class Program
    {
        private static string ScriptHost => EnvironmentInfo.IsWin ? "powershell" : "bash";
        private static string ScriptExtension => EnvironmentInfo.IsWin ? "ps1" : "sh";

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
            var hasCommand = args.FirstOrDefault()?.StartsWithOrdinalIgnoreCase("!") ?? false;
            if (hasCommand)
            {
                var command = args.First().Trim(trimChar: '!');
                if (string.IsNullOrWhiteSpace(command))
                    ControlFlow.Fail("No command specified. Usage is: nuke !<command> [args]");

                var arguments = args.Skip(count: 1).JoinSpace();
                if (command.EqualsOrdinalIgnoreCase("setup"))
                {
                    Setup(arguments);
                    return;
                }

                ControlFlow.Fail($"Command '{command}' is not supported.");
            }

            var currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            var rootDirectory = FileSystemTasks.FindParentDirectory(currentDirectory, x => x.GetFiles(NukeBuild.ConfigurationFile).Any());
            var buildScript = rootDirectory?
                .EnumerateFiles($"build.{ScriptExtension}", maxDepth: 2)
                .FirstOrDefault()?.FullName;

            if (buildScript == null)
            {
                if (UserConfirms($"Could not find {NukeBuild.ConfigurationFile} file. Do you want to setup a build?"))
                    Setup();
                return;
            }

            // TODO: docker
            RunScript(buildScript, args.Select(x => x.DoubleQuoteIfNeeded()).JoinSpace());
        }

        private static void Setup(string args = null)
        {
            // TODO: embed all bootstrapping files and reimplement setup for offline usage?
            // TODO: alternatively, use a similar approach as in SetupIntegrationTest
            var setupScript = Path.Combine(Directory.GetCurrentDirectory(), $"setup.{ScriptExtension}");
            if (!File.Exists(setupScript))
            {
                using (var webClient = new WebClient())
                {
                    var setupScriptUrl = $"https://nuke.build/{ScriptHost}";
                    Logger.Log($"Downloading setup script from {setupScriptUrl}");
                    webClient.DownloadFile(setupScriptUrl, setupScript);
                }
            }

            RunScript(setupScript, args);
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

        private static void RunScript(string file, string arguments = null)
        {
            file = file.DoubleQuoteIfNeeded();
            
            var process = ProcessTasks.StartProcess(
                ScriptHost,
                EnvironmentInfo.IsWin
                    ? $"-File {file} {arguments}"
                    : $"{file} {arguments}");

            process.AssertZeroExitCode();
        }
    }
}
