// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Threading.Tasks;
using FluentAssertions;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Xunit;

namespace Nuke.Common.Tests;

public class NuGetPackageResolverTest
{
    private static AbsolutePath RootDirectory => Constants.TryGetRootDirectoryFrom(EnvironmentInfo.WorkingDirectory).NotNull();

    private static AbsolutePath ProjectFile => RootDirectory / "source" / "Nuke.Tooling.Tests" / "Nuke.Tooling.Tests.csproj";
    private static AbsolutePath AssetsFile => ProjectFile.Parent / "obj" / "project.assets.json";

    private const string XunitConsolePackageVersion = "2.6.1";

    [Theory]
    [InlineData("SpecK", true, true, "1.0.1-ci00055")]
    [InlineData("SpecK", false, true, "1.0.0")]
    [InlineData("Nuke.Generation.Specifications", false, false, null)]
    [InlineData("Nuke.Generation.Specifications", true, false, "0.1.0-alpha0019")]
    [InlineData("PathConstruction", false, false, "0.1.0")]
    public async Task TestGetLatestPackageVersion(string packageId, bool includePrereleases, bool includeUnlisted, string expected)
    {
        var result = await NuGetVersionResolver.GetLatestVersion(packageId, includePrereleases, includeUnlisted);
        result.Should().Be(expected);
    }

    [Fact]
    public void TestGetGlobalInstalledPackage()
    {
        var result = NuGetPackageResolver.GetGlobalInstalledPackage("xunit.runner.console", version: null, packagesConfigFile: null);
        result.Should().NotBeNull();
        result.Id.Should().Be("xunit.runner.console");
        result.File.Name.Should().EndWith("nupkg");
        result.Version.OriginalVersion.Should().Be(XunitConsolePackageVersion);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("net6.0")]
    public void TestGetLocalInstalledPackageViaProjectFile(string framework)
    {
        var result = NuGetPackageResolver.GetLocalInstalledPackage("xunit.runner.console", ProjectFile, framework: framework, resolveDependencies: false);
        result.Should().NotBeNull();
        result.Version.OriginalVersion.Should().Be(XunitConsolePackageVersion);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("net6.0")]
    public void TestGetLocalInstalledPackageViaAssetsFile(string framework)
    {
        var result = NuGetPackageResolver.GetLocalInstalledPackage("xunit.runner.console", AssetsFile, framework: framework, resolveDependencies: false);
        result.Version.OriginalVersion.Should().Be(XunitConsolePackageVersion);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("net6.0")]
    public void TestGetLocalInstalledPackagesViaProjectFile(string framework)
    {
        var result = NuGetPackageResolver.GetLocalInstalledPackages(ProjectFile, framework: framework, resolveDependencies: false);
        result.Should().Contain(x => x.Id == "xunit.runner.console");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("net6.0")]
    public void TestGetLocalInstalledPackagesViaAssetsFile(string framework)
    {
        var result = NuGetPackageResolver.GetLocalInstalledPackages(AssetsFile, framework: framework, resolveDependencies: false);
        result.Should().Contain(x => x.Id == "xunit.runner.console");
    }
}
