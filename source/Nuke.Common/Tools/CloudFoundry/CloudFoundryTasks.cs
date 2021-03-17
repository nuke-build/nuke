// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.CloudFoundry
{
    public static partial class CloudFoundryTasks
    {
        public static string GetToolPath()
        {
            return ToolPathResolver.GetPackageExecutable($"CloudFoundry.CommandLine.{CurrentOsRid}", IsWindows ? "cf.exe" : "cf");
        }

        private static bool IsWindows => EnvironmentInfo.Platform == PlatformFamily.Windows;

        private static string CurrentOsRid
            => EnvironmentInfo.Platform switch
            {
                PlatformFamily.Windows => Environment.Is64BitOperatingSystem ? "win-x64" : "win-x32",
                PlatformFamily.Linux => Environment.Is64BitOperatingSystem ? "linux-x64" : "linux-x32",
                PlatformFamily.OSX => "osx-x64",
                _ => throw new PlatformNotSupportedException()
            };

        /// <summary>
        ///   Create task which will complete when creation of an asynchronous service is complete.
        ///   This uses polling to query it repeatedly
        /// </summary>
        public static async Task CloudFoundryEnsureServiceReady(string serviceInstance) => await CloudFoundryEnsureServiceReady(serviceInstance, TimeSpan.FromSeconds(5));

        /// <summary>
        ///   Create task which will complete when creation of an asynchronous service is complete.
        ///   This uses polling to query it repeatedly
        /// </summary>
        public static async Task CloudFoundryEnsureServiceReady(string serviceInstance, TimeSpan checkInterval)
        {
            var guid = CloudFoundry($"service {serviceInstance} --guid", logOutput: false, logInvocation: false).First().Text;
            bool IsCreating()
            {
                var jsonString = CloudFoundryCurl(c => c
                        .SetPath($"/v2/service_instances/{guid}")
                        .DisableProcessLogOutput()
                        .DisableProcessLogInvocation())
                    .EnsureOnlyStd()
                    .Aggregate(new StringBuilder(), (sb, output) => sb.AppendLine(output.Text), sb => sb.ToString());
                var response = JObject.Parse(jsonString);
                if (response.ContainsKey("error_code"))
                    throw new Exception($"Service creation failed with \n{response["description"]}");
                return response.SelectToken("entity.last_operation.state")?.ToString() == "in progress";
            }

            Logger.Normal($"Waiting service {serviceInstance} to finish provisioning");
            while (IsCreating())
            {
                await Task.Delay(checkInterval);
            }
            Logger.Normal($"Service {serviceInstance} is finished provisioning");
        }
    }
}
