// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tools.NSwag
{
    [PublicAPI]
    [Serializable]
    public class NSwagSettings : ToolSettings
    {
        /// <summary>The runtime of the nswag tool to use.</summary>
        public string NSwagRuntime { get; set; } = NSwagTasks.Runtime.Net60.ToString();

        private bool IsNetCore => NSwagRuntime != null && NSwagRuntime.StartsWith("Net", StringComparison.OrdinalIgnoreCase);

        public override Action<OutputType, string> ProcessCustomLogger { get; internal set; }

        [NotNull]
        protected override Arguments ConfigureProcessArguments([NotNull] Arguments arguments)
        {
            if (!IsNetCore)
                return base.ConfigureProcessArguments(arguments);

            var args = new Arguments();
            args.Add($"{GetNetCoreDllPath(NSwagRuntime).DoubleQuoteIfNeeded()}");
            args.Concatenate(arguments);
            return base.ConfigureProcessArguments(args);
        }

        protected string GetProcessToolPath()
        {
            if (IsNetCore)
                return DotNetTasks.DotNetPath;
            return GetPackageFrameworkDir() / "Win" / "NSwag.exe";
        }

        protected string GetNSwagRuntime()
        {
            return string.Empty;
        }

        private string GetNetCoreDllPath(string runtime)
        {
            return GetPackageFrameworkDir() / runtime / "dotnet-nswag.dll";
        }

        private AbsolutePath GetPackageFrameworkDir()
        {
            var package = NuGetPackageResolver.GetLocalInstalledPackage("nswag.msbuild", NuGetToolPathResolver.NuGetPackagesConfigFile);
            return package.Directory / (package.Version.Version >= new Version(major: 11, minor: 18, build: 1) ? "tools" : "build");
        }
    }
}
