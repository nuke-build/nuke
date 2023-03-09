// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NuGet.Versioning;
using Nuke.Common;
using Nuke.Common.IO;
using VerifyXunit;
using Xunit;

namespace Nuke.GlobalTool.Tests
{
    [UsesVerify]
    public class CakeConversionTests
    {
        private static AbsolutePath RootDirectory => Constants.TryGetRootDirectoryFrom(EnvironmentInfo.WorkingDirectory);

        [Theory]
        [MemberData(nameof(CakeFileNames))]
        public Task Test(AbsolutePath file)
        {
            var converted = Program.GetCakeConvertedContent(file.ReadAllText());
            return Verifier.Verify(converted, extension: "cs")
                .UseDirectory(CakeScriptsDirectory)
                .UseFileName(file.NameWithoutExtension);
        }

        [Fact]
        public void TestPackages()
        {
            var content = (CakeScriptsDirectory / "references.cake").ReadAllText();

            var packages = Program.GetCakePackages(content).ToList();
            packages.Should().Contain((Program.PACKAGE_TYPE_DOWNLOAD, "GitVersion.CommandLine", "4.0.0"));
            packages.Should().Contain((Program.PACKAGE_TYPE_REFERENCE, "SharpZipLib", "1.2.0"));
            packages.Should().Contain(x => x.Id == "TeamCity.Dotnet.Integration" &&
                                           NuGetVersion.Parse(x.Version) > NuGetVersion.Parse("1.0.10"));
            packages.Should().NotContain(x => x.Id.Contains("Cake"));
        }

        private static AbsolutePath CakeScriptsDirectory => RootDirectory / "source" / "Nuke.GlobalTool.Tests" / "cake-scripts";

        public static IEnumerable<object[]> CakeFileNames
            => CakeScriptsDirectory.GlobFiles(Program.CAKE_FILE_PATTERN).Select(x => new object[] { x });
    }
}
