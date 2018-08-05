// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;

namespace Nuke.NSwag
{
    [PublicAPI]
    [Serializable]
    public class NSwagSettings : ToolSettings
    {
        /// <summary>The runtime of the nswag tool to use.</summary>
        public string NSwagRuntime { get; set; } = NSwagTasks.Runtime.Win.ToString();

        private bool _isNetCore => NSwagRuntime != null && NSwagRuntime.StartsWith("NetCore", StringComparison.OrdinalIgnoreCase);


        [NotNull]
        protected override Arguments ConfigureArguments ([NotNull]Arguments arguments)
        {
            if (!_isNetCore) return base.ConfigureArguments(arguments);

            var args = new Arguments();
            args.Add($"{GetNetCoreDllPath(NSwagRuntime)}");
            args.Concatenate(arguments);
            return base.ConfigureArguments(args);
        }

        protected string GetToolPath ()
        {
            if (_isNetCore) return DotNetTasks.DotNetPath;
            return GetPackageFrameworkDir() / "build"/"Win"/"NSwag.exe";
        }

        protected string GetNSwagRuntime ()
        {
            return string.Empty;
        }

        private string GetNetCoreDllPath(string runtime)
        {
            return GetPackageFrameworkDir() / "build" / runtime / "dotnet-nswag.dll";
        }

        private PathConstruction.AbsolutePath GetPackageFrameworkDir()
        {
            var package = NuGetPackageResolver.GetLocalInstalledPackage("nswag.msbuild")
                .NotNull("Package NSwag.MSBuild not found. Please install the package to your build project.");

            return package.Directory / (package.Version.Version >= new Version(major: 11, minor: 18, build: 1) ? "tools" : "build");
        }
    }
}