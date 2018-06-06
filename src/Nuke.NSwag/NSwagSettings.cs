// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;

namespace Nuke.NSwag
{
    [PublicAPI]
    [Serializable]
    public class NSwagSettings : ToolSettings
    {
        /// <summary>The runtime of the nswag tool to use.</summary>
        public string NSwagRuntime { get; set; }

        private bool _isNetCore => NSwagRuntime != null && NSwagRuntime.StartsWith("NetCore", StringComparison.OrdinalIgnoreCase);

        protected override Arguments ConfigureArguments (Arguments arguments)
        {
            ControlFlow.Assert(NSwagRuntime != null, "NSwagRuntime must be defined to detect the proper nswag executable.");
            if (!_isNetCore) return base.ConfigureArguments(arguments);

            var args = new Arguments();
            args.Add($"{NSwagTasks.GetNetCoreDllPath(NSwagRuntime)}");
            args.Concatenate(arguments);
            return base.ConfigureArguments(args);
        }

        protected string GetToolPath ()
        {
            if (_isNetCore) return DotNetTasks.DotNetPath;
            return NuGetPackageResolver.GetLocalInstalledPackageDirectory("nswag.msbuild") + "/build/Win/NSwag.exe";
        }

        protected string GetNSwagRuntime ()
        {
            return string.Empty;
        }
    }
}