// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities;
using static Nuke.Common.ControlFlow;

namespace Nuke.Common.Execution
{
    internal static partial class Telemetry
    {
        // https://docs.microsoft.com/en-us/dotnet/core/tools/telemetry
        // https://dotnet.microsoft.com/platform/telemetry
        // https://docs.microsoft.com/en-us/azure/azure-monitor/app/console
        // https://docs.microsoft.com/en-us/azure/azure-monitor/app/ip-collection

        public const string OptOutEnvironmentKey = "NUKE_TELEMETRY_OPTOUT";
        public const int CurrentVersion = 1;

        // private const string InstrumentationKey = "310c87d7-60e1-48c1-b452-19e8f4801fba";
        private const string InstrumentationKey = "4b987be9-f807-4846-b777-4291f3a5ad8b";
        private const string VersionPropertyName = "NukeTelemetryVersion";

        private static readonly TelemetryClient s_client;
        private static readonly int? s_confirmedVersion;

        static Telemetry()
        {
            var optoutParameter = ParameterService.GetParameter<string>(OptOutEnvironmentKey) ?? string.Empty;
            if (optoutParameter == "1" || optoutParameter.EqualsOrdinalIgnoreCase(bool.TrueString))
                return;

            ProjectModelTasks.Initialize();
            s_confirmedVersion = SuppressErrors(CheckAwareness, includeStackTrace: true);
            if (s_confirmedVersion == null)
                return;

            var configuration = TelemetryConfiguration.CreateDefault();
            configuration.ConnectionString = $"InstrumentationKey={InstrumentationKey}";
            s_client = new TelemetryClient(configuration);
            s_client.Context.Session.Id = Guid.NewGuid().ToString();
            s_client.Context.Location.Ip = "N/A";
            s_client.Context.Cloud.RoleInstance = "N/A";
        }

        private static int? CheckAwareness()
        {
            AbsolutePath GetCookieFile(string name, int version)
                => Constants.GlobalNukeDirectory / "telemetry-awareness" / $"v{version}" / name;

            // Check for calls from Nuke.GlobalTool and custom global tools
            if (SuppressErrors(() => NukeBuild.BuildProjectFile, logWarning: false) == null)
            {
                var cookieName = Assembly.GetEntryAssembly().NotNull().GetName().Name;
                var cookieFile = GetCookieFile(cookieName, CurrentVersion);
                if (!cookieFile.Exists())
                {
                    PrintDisclosure($"create awareness cookie for {cookieName.SingleQuote()}");
                    cookieFile.TouchFile();
                }

                return CurrentVersion;
            }

            var project = ProjectModelTasks.ParseProject(NukeBuild.BuildProjectFile);
            var property = project.Properties.SingleOrDefault(x => x.Name.EqualsOrdinalIgnoreCase(VersionPropertyName));
            if (property?.EvaluatedValue != CurrentVersion.ToString())
            {
                if (NukeBuild.IsServerBuild)
                {
                    PrintDisclosure(action: null);
                    return null;
                }

                PrintDisclosure($"set the {VersionPropertyName.SingleQuote()} property");
                project.SetProperty(VersionPropertyName, CurrentVersion.ToString());
                project.Save();
            }

            for (var version = CurrentVersion; version > 0; version--)
            {
                var cookieFile = GetCookieFile("Nuke.GlobalTool", version);
                if (cookieFile.FileExists())
                    return version;
            }

            return NukeBuild.IsServerBuild ? CurrentVersion : null;
        }

        private static void PrintDisclosure(string action)
        {
            var disclosure =
                new[]
                {
                    $"Telemetry v{CurrentVersion}",
                    "------------",
                    "NUKE collects anonymous usage data in order to help us improve your experience.",
                    "Read more about scope, data points, and opt-out: https://nuke.build/telemetry",
                    string.Empty
                }.JoinNewLine();

            if (action != null &&
                Environment.UserInteractive &&
                !Console.IsInputRedirected)
            {
                Host.Information(disclosure);
                Thread.Sleep(2000);
                Host.Information($"Press <Enter> to {action} ...");
                WaitForEnter();
            }
            else
            {
                Host.Warning(disclosure);
                Host.Warning("Run in interactive console to fix this warning");
            }
        }

        private static void WaitForEnter()
        {
            ConsoleKey response;
            do
            {
                response = Console.ReadKey(intercept: true).Key;
            } while (response != ConsoleKey.Enter);
        }
    }
}
