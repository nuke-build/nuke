// Copyright Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/arodus/nuke-plugin-nswag/blob/master/LICENSE

using System.IO;
using Nuke.Common.Tools;
using Nuke.Common.Tools.DotNet;
using Nuke.Core;

namespace Nuke.NSwag
{
    public class NSwagSettings : DotNetSettings
    {
        protected string GetToolPath()
        {
            var packagesConfigFile = NuGetPackageResolver.GetBuildPackagesConfigFile();
            Path.GetDirectoryName(NuGetPackageResolver.GetLocalInstalledPackage("NSwag.MSBuild", packagesConfigFile)
                .NotNull(string.Format("Could not find package '{0}' via '{1}'.", "NSwag.MSBuild", packagesConfigFile))
                .FileName).NotNull("packageDirectory != null");
            return ToolPath;
        }
    }
}