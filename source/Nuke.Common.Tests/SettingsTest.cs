// Copyright 2023 Maintainers of NUKE.
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
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities;
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
        public void TestCommon()
        {
            var logEntry = default((OutputType Type, string String));
            var settings = new DotNetRunSettings()
                .SetProcessToolPath("/path/to/dotnet")
                .SetProcessEnvironmentVariable("key", "value")
                .SetProcessExecutionTimeout(TimeSpan.FromMilliseconds(1_000))
                .SetProcessArgumentConfigurator(_ => _
                    .Add("/switch"))
                .SetProcessCustomLogger((type, str) => logEntry = (type, str))
                .EnableProcessLogInvocation();
            settings.ProcessCustomLogger.Invoke(OutputType.Err, "text");

            settings.ProcessToolPath.Should().Be("/path/to/dotnet");
            settings.ProcessEnvironmentVariables.Should().ContainSingle(x => x.Key == "key" && x.Value == "value");
            settings.ProcessExecutionTimeout.Should().Be(1_000);
            settings.ProcessArgumentConfigurator.Invoke(new Arguments()).RenderForOutput().Should().Be("/switch");
            logEntry.Should().Be((OutputType.Err, "text"));
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
                $"{projectFile.ToString().DoubleQuoteIfNeeded()} /nodeReuse:False /nologo /p:Platform=AnyCPU /p:Configuration=Release");

            Assert<MSBuildSettings>(x => x
                    .SetProjectFile(solutionFile)
                    .SetTargetPlatform(MSBuildTargetPlatform.MSIL)
                    .EnableNodeReuse()
                    .DisableNoLogo()
                    .ToggleRunCodeAnalysis(),
                $"{solutionFile.ToString().DoubleQuoteIfNeeded()} /nodeReuse:True /p:Platform=\"Any CPU\" /p:RunCodeAnalysis=True");
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
                $"-target:{projectFile.ToString().DoubleQuoteIfNeeded()} -targetargs:\"-diagnostics -HTML \\\"new folder\\data.xml\\\"\" -filter:\"+[*]* -[xunit.*]* -[NUnit.*]*\"");
        }
    }
}
