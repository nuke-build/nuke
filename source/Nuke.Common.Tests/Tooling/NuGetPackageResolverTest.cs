using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Xunit;
using Xunit.Abstractions;

namespace Nuke.Common.Tests.Tooling
{
    public class NuGetPackageResolverTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public NuGetPackageResolverTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void NuGetPackageResolverCacheTest()
        {
            AbsolutePath configFile = (AbsolutePath)new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName / "Tooling" / "NuGetPackageResolverCacheTest.csproj";

            var sw = new Stopwatch();
            sw.Restart();
            NuGetPackageResolver.GetLocalInstalledPackages(configFile).ToArray();
            sw.Stop();
            _testOutputHelper.WriteLine($"Cached first run {sw.Elapsed}");

            sw.Restart();
            NuGetPackageResolver.GetLocalInstalledPackages(configFile).ToArray();
            sw.Stop();
            _testOutputHelper.WriteLine($"Cached second run {sw.Elapsed}");

            NuGetPackageResolver.EnableCache = false;
            sw.Restart();
            NuGetPackageResolver.GetLocalInstalledPackages(configFile).ToArray();
            sw.Stop();
            _testOutputHelper.WriteLine($"No cache run {sw.Elapsed}");
        }
    }
}
