// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Tools.MSBuild;
using Nuke.Common.Tools.OpenCover;
using Nuke.Common.Tools.Xunit;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Xunit;

namespace Nuke.Common.Tests
{
    public class SettingsTest
    {
        private static AbsolutePath RootDirectory => Constants.TryGetRootDirectoryFrom(Directory.GetCurrentDirectory()).NotNull();

        private static void Assert<T>(Configure<T> configurator, string arguments)
            where T : ToolSettings, new()
        {
            configurator.Invoke(new T()).GetProcessArguments().RenderForOutput().Should().Be(arguments);
        }

        [Fact]
        public void TestMSBuild()
        {
            var projectFile = RootDirectory / "source" / "Nuke.Common" / "Nuke.Common.csproj";
            var solutionFile = RootDirectory / "nuke-common.sln";

            Assert<MSBuildSettings>(x => x
                    .SetProjectFile(projectFile)
                    .SetTargetPlatform(MSBuildTargetPlatform.MSIL)
                    .SetConfiguration("Release")
                    .DisableNodeReuse()
                    .EnableNoLogo(),
                $"{projectFile} /nodeReuse:False /nologo /p:Platform=AnyCPU /p:Configuration=Release");

            Assert<MSBuildSettings>(x => x
                    .SetProjectFile(solutionFile)
                    .SetTargetPlatform(MSBuildTargetPlatform.MSIL)
                    .EnableNodeReuse()
                    .DisableNoLogo()
                    .ToggleRunCodeAnalysis(),
                $"{solutionFile} /nodeReuse:True /p:Platform=\"Any CPU\" /p:RunCodeAnalysis=True");
        }

        [Fact]
        public void TestXunit2()
        {
            Assert<Xunit2Settings>(x => x
                    .AddTargetAssemblies("A.csproj")
                    .AddTargetAssemblyWithConfigs("B.csproj", "D.config", "new folder\\E.config"),
                "A.csproj  B.csproj D.config B.csproj \"new folder\\E.config\"");

            Assert<Xunit2Settings>(x => x
                    .AddResultReport(Xunit2ResultFormat.HTML, "new folder\\data.html")
                    .AddResultReport(Xunit2ResultFormat.Xml, "new_folder\\data.xml"),
                "-HTML \"new folder\\data.html\" -Xml new_folder\\data.xml");

            Assert<Xunit2Settings>(x => x
                    .AddResultReport(Xunit2ResultFormat.NUnit, "new folder\\nunit.xml")
                    .EnableDiagnostics()
                    .EnableFailSkips(),
                "-failskips -diagnostics -NUnit \"new folder\\nunit.xml\"");
        }

        [Fact]
        public void TestOpenCover()
        {
            var projectFile = RootDirectory / "source" / "Nuke.Common" / "Nuke.Common.csproj";

            Assert<OpenCoverSettings>(x => x
                    .SetTargetPath(projectFile)
                    .AddFilters("+[*]*", "-[xunit.*]*", "-[NUnit.*]*")
                    .SetTargetArguments("-diagnostics -HTML \"new folder\\data.xml\""),
                $"-target:{projectFile} -targetargs:\"-diagnostics -HTML \\\"new folder\\data.xml\\\"\" -filter:\"+[*]* -[xunit.*]* -[NUnit.*]*\"");
        }
    }
}
