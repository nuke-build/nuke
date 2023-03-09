// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Threading.Tasks;
using Nuke.Common.Tooling;
using Serilog;

namespace Nuke.Common.Tools.CloudFoundry
{
    public static partial class CloudFoundryTasks
    {
        public static string GetToolPath()
        {
            return NuGetToolPathResolver.GetPackageExecutable($"CloudFoundry.CommandLine.{CurrentOsRid}", IsWindows ? "cf.exe" : "cf");
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
        public static async Task CloudFoundryEnsureServiceReady(string serviceInstance)
        {
            await CloudFoundryEnsureServiceReady(serviceInstance, TimeSpan.FromSeconds(5));
        }

        /// <summary>
        ///   Create task which will complete when creation of an asynchronous service is complete.
        ///   This uses polling to query it repeatedly
        /// </summary>
        public static async Task CloudFoundryEnsureServiceReady(string serviceInstance, TimeSpan checkInterval)
        {
            var guid = CloudFoundry($"service {serviceInstance} --guid", logOutput: false, logInvocation: false).First().Text;

            bool IsCreating()
            {
                var output = CloudFoundryCurl(c => c
                    .SetPath($"/v2/service_instances/{guid}")
                    .DisableProcessLogOutput()
                    .DisableProcessLogInvocation());

                var response = output.StdToJson();
                if (response.ContainsKey("error_code"))
                    Assert.Fail($"Service creation failed with \n{response["description"]}");

                return response.SelectToken("entity.last_operation.state")?.ToString() == "in progress";
            }

            Log.Debug($"Waiting service {serviceInstance} to finish provisioning");

            while (IsCreating())
            {
                await Task.Delay(checkInterval);
            }

            Log.Debug($"Service {serviceInstance} is finished provisioning");
        }
    }
}
