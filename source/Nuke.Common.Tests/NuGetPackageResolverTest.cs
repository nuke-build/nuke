// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.CodeDom;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Xunit;

namespace Nuke.Common.Tests
{
    public class NuGetPackageResolverTest
    {
        private static AbsolutePath RootDirectory => Constants.TryGetRootDirectoryFrom(Directory.GetCurrentDirectory()).NotNull();

        private static AbsolutePath BuildProjectFile => RootDirectory / "build" / "_build.csproj";
        private static AbsolutePath BuildAssetsFile => RootDirectory / "build" / "obj" / "project.assets.json";

        private const string XunitConsolePackageVersion = "2.4.1";

        [Theory]
        [InlineData("SpecK", true, true, "1.0.1-ci00055")]
        [InlineData("SpecK", false, true, "1.0.0")]
        [InlineData("Nuke.Generation.Specifications", false, false, null)]
        [InlineData("Nuke.Generation.Specifications", true, false, "0.1.0-alpha0019")]
        [InlineData("PathConstruction", false, false, "0.1.0")]
        public async Task TestGetLatestPackageVersion(string packageId, bool includePrereleases, bool includeUnlisted, string expected)
        {
            var result = await NuGetPackageResolver.GetLatestPackageVersion(packageId, includePrereleases, includeUnlisted);
            result.Should().Be(expected);
        }

        [Fact]
        public void TestGetGlobalInstalledPackage()
        {
            var result = NuGetPackageResolver.GetGlobalInstalledPackage("xunit.runner.console", version: null, packagesConfigFile: null);
            result.Should().NotBeNull();
            result.Id.Should().Be("xunit.runner.console");
            result.FileName.Should().EndWith("nupkg");
            result.Version.OriginalVersion.Should().Be(XunitConsolePackageVersion);
        }

        [Fact]
        public void TestGetLocalInstalledPackageViaProjectFile()
        {
            var result = NuGetPackageResolver.GetLocalInstalledPackage("xunit.runner.console", BuildProjectFile, resolveDependencies: false);
            result.Should().NotBeNull();
            result.Version.OriginalVersion.Should().Be(XunitConsolePackageVersion);
        }

        [Fact]
        public void TestGetLocalInstalledPackageViaAssetsFile()
        {
            var result = NuGetPackageResolver.GetLocalInstalledPackage("xunit.runner.console", BuildAssetsFile, resolveDependencies: false);
            result.Version.OriginalVersion.Should().Be(XunitConsolePackageVersion);
        }

        [Fact]
        public void TestGetLocalInstalledPackagesViaProjectFile()
        {
            var result = NuGetPackageResolver.GetLocalInstalledPackages(BuildProjectFile, resolveDependencies: false);
            result.Should().Contain(x => x.Id == "JetBrains.ReSharper.GlobalTools");
        }

        [Fact]
        public void TestGetLocalInstalledPackagesViaAssetsFile()
        {
            var result = NuGetPackageResolver.GetLocalInstalledPackages(BuildAssetsFile, resolveDependencies: false);
            result.Should().Contain(x => x.Id == "JetBrains.ReSharper.GlobalTools");
        }
    }
}
