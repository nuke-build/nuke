// Copyright 2019 Maintainers of NUKE.
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
        public string NSwagRuntime { get; set; } = NSwagTasks.Runtime.Win.ToString();

        private bool IsNetCore => NSwagRuntime != null && NSwagRuntime.StartsWith("NetCore", StringComparison.OrdinalIgnoreCase);

        public override Action<OutputType, string> CustomLogger { get; }

        [NotNull]
        protected override Arguments ConfigureArguments([NotNull] Arguments arguments)
        {
            if (!IsNetCore)
                return base.ConfigureArguments(arguments);

            var args = new Arguments();
            args.Add($"{GetNetCoreDllPath(NSwagRuntime).DoubleQuoteIfNeeded()}");
            args.Concatenate(arguments);
            return base.ConfigureArguments(args);
        }

        protected string GetToolPath()
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

        private PathConstruction.AbsolutePath GetPackageFrameworkDir()
        {
            var package = NuGetPackageResolver.GetLocalInstalledPackage("nswag.msbuild", ToolPathResolver.NuGetPackagesConfigFile);
            return package.Directory / (package.Version.Version >= new Version(major: 11, minor: 18, build: 1) ? "tools" : "build");
        }
    }
}
