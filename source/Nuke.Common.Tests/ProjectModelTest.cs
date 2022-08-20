// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Xunit;

namespace Nuke.Common.Tests
{
    public class ProjectModelTest
    {
        private static AbsolutePath RootDirectory => Constants.TryGetRootDirectoryFrom(Directory.GetCurrentDirectory()).NotNull();

        private static AbsolutePath SolutionFile => RootDirectory / "nuke-common.sln";

        [Fact]
        public void ProjectTest()
        {
            var solution = SolutionModelTasks.ParseSolution(SolutionFile);
            var project = solution.Projects.Single(x => x.Name == "Nuke.Common");

            var action = new Action(() => project.GetMSBuildProject());
            action.Should().NotThrow();

            project.GetTargetFrameworks().Should().HaveCount(2).And.Contain("netcoreapp2.1");
            project.HasPackageReference("Glob").Should().BeTrue();
            project.GetPackageReferenceVersion("YamlDotNet").Should().Be("11.2.1");
        }
    }
}
