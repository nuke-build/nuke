// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities;
using Spectre.Console;

namespace Nuke.GlobalTool
{
    public partial class Program
    {
        private const char CommandPrefix = ':';

        private static string CurrentBuildScriptName => EnvironmentInfo.IsWin ? "build.ps1" : "build.sh";

        private static int Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            try
            {
                var rootDirectory = TryGetRootDirectory();

                var buildScript = rootDirectory != null
                    ? rootDirectory.GetFiles(CurrentBuildScriptName, depth: 2)
                        .FirstOrDefault(x => Constants.TryGetRootDirectoryFrom(x.Parent) == rootDirectory)
                    : null;

                return Handle(args, rootDirectory, buildScript);
            }
            catch (Exception exception)
            {
                Host.Error(exception.Unwrap().Message);
                return 1;
            }
        }

        private static void PrintInfo()
        {
            Host.Information($"NUKE Global Tool 🌐 {typeof(Program).Assembly.GetInformationalText()}");
        }

        [CanBeNull]
        private static AbsolutePath TryGetRootDirectory()
        {
            // TODO: copied in NukeBuild.GetRootDirectory
            var parameterValue = EnvironmentInfo.GetNamedArgument<AbsolutePath>(Constants.RootDirectoryParameterName);
            if (parameterValue != null)
                return parameterValue;

            if (EnvironmentInfo.GetNamedArgument<bool>(Constants.RootDirectoryParameterName))
                return EnvironmentInfo.WorkingDirectory;

            return Constants.TryGetRootDirectoryFrom(Directory.GetCurrentDirectory());
        }

        private static int Handle(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            var hasCommand = args.FirstOrDefault()?.StartsWithOrdinalIgnoreCase(CommandPrefix.ToString()) ?? false;
            if (hasCommand)
            {
                var command = args.First().Trim(CommandPrefix).Replace("-", string.Empty);
                if (string.IsNullOrWhiteSpace(command))
                    Assert.Fail($"No command specified. Usage is: nuke {CommandPrefix}<command> [args]");

                var availableCommands = typeof(Program).GetMethods(ReflectionUtility.Static).Where(x => x.ReturnType == typeof(int)).ToList();
                var commandHandler = availableCommands.SingleOrDefault(x => x.Name.EqualsOrdinalIgnoreCase(command));
                Assert.NotNull(commandHandler,
                    new[] { $"Command '{command}' is not supported, available commands are:" }
                        .Concat(availableCommands.Where(x => x.IsPublic).Select(x => $"  - {x.Name}").OrderBy(x => x)).JoinNewLine());
                // TODO: add assertions about return type and parameters

                var commandArguments = new object[] { args.Skip(count: 1).ToArray(), rootDirectory, buildScript };
                return (int)commandHandler.Invoke(obj: null, commandArguments);
            }

            if (rootDirectory == null || buildScript == null)
            {
                var missingItem = rootDirectory == null
                    ? $"{Constants.NukeDirectoryName} directory/file"
                    : "build.ps1/sh files";

                return PromptForConfirmation($"Could not find {missingItem}. Do you want to setup a build?")
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
            var startInfo =
                new ProcessStartInfo
                {
                    FileName = EnvironmentInfo.IsWin
                        ? ToolPathResolver.GetPathExecutable("powershell")
                        : ToolPathResolver.GetPathExecutable("bash"),
                    Arguments = EnvironmentInfo.IsWin
                        ? $"-ExecutionPolicy ByPass -NoProfile -File {buildScript.DoubleQuoteIfNeeded()} {arguments}"
                        : $"{buildScript} {arguments}"
                };
            startInfo.Environment[Constants.GlobalToolVersionEnvironmentKey] = typeof(Program).Assembly.GetVersionText();
            startInfo.Environment[Constants.GlobalToolStartTimeEnvironmentKey] = DateTime.Now.ToString("O");
            return Process.Start(startInfo).NotNull();
        }

        private static void ShowInput(string emoji, string title, string value)
        {
            AnsiConsole.MarkupLine($":{emoji}:  {$"{title}:",-25} [turquoise2 bold]{value}[/]");
        }

        private static void ShowCompletion(string title)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"[bold green]{title} completed![/] :party_popper:");
        }

        private static void ClearPreviousLine()
        {
            AnsiConsole.Cursor.MoveUp();
            Console.WriteLine(' '.Repeat(Console.WindowWidth));
            AnsiConsole.Cursor.MoveUp();
        }

        private static bool PromptForConfirmation(string question)
        {
            return AnsiConsole.Confirm(question);
        }

        private static string PromptForInput(string question, string defaultValue = null)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>(question)
                    .DefaultValue(defaultValue));
        }

        private static string PromptForSecret(string title, int? minLength = null)
        {
            Assert.False(title.EndsWith(':'));

            return AnsiConsole.Prompt(
                new TextPrompt<string>($"{title}:")
                    .Secret()
                    .Validate(x => minLength == null || x.Length >= minLength,
                        message: $"Secret must be at least {minLength} characters long"));
        }

        private static T PromptForChoice<T>(string question, params (T Value, string Description)[] choices)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<T>()
                    .Title(question)
                    .HighlightStyle(new Style(Color.Turquoise2))
                    .UseConverter(x => choices.Single(y => Equals(x, y.Value)).Description)
                    .AddChoices(choices.Select(x => x.Value)));
            return choice;
        }

        private static void ConfirmExecution(string title, Action action)
        {
            Assert.False(title.EndsWith('?'));

            var confirmation = PromptForConfirmation($"{title}?");
            ClearPreviousLine();

            if (confirmation)
            {
                AnsiConsole.MarkupLine($":hourglass_not_done:  {title} ...");
                action.Invoke();
                ClearPreviousLine();
            }

            var (emoji, color) = confirmation ? ("check_mark", "green") : ("multiply", "red");
            AnsiConsole.MarkupLine($"[{color}]:{emoji}:[/]  {title}");
        }
    }
}
