// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Tooling;

public interface IRequireTool;
public interface IRequireToolWithVersion;


public interface IRequirePathTool : IRequireTool;

public interface IRequireNuGetPackage : IRequireTool, IRequireToolWithVersion;

public interface IRequireNpmPackage : IRequireTool, IRequireToolWithVersion;

public interface IRequireAptGetPackage : IRequireTool;


public class ToolRequirement;

public class PathToolRequirement(string pathExecutable) : ToolRequirement
{
    public string PathExecutable { get; init => field = pathExecutable; }
}

public class NuGetPackageRequirement(string packageId, string version = null) : ToolRequirement
{
    public string PackageId { get; init => field = packageId; }
    public string Version { get; init => field = version ?? NuGetVersionResolver.GetLatestVersion(packageId, includePrereleases: false).GetAwaiter().GetResult(); }
}

public class NpmPackageRequirement(string packageId, string version = null) : ToolRequirement
{
    public string PackageId { get; init => field = packageId; }
    public string Version { get; init => field = version ?? NpmVersionResolver.GetLatestVersion(packageId).GetAwaiter().GetResult(); }
}

public class AptGetPackageRequirement(string packageId) : ToolRequirement
{
    public string PackageId { get; init => field = packageId; }
}
