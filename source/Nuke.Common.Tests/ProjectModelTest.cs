﻿// Copyright 2019 Maintainers of NUKE.
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
        public void SolutionTest()
        {
            var solution = ProjectModelTasks.ParseSolution(SolutionFile);

            solution.SolutionFolders.Select(x => x.Name).Should().BeEquivalentTo("misc");
            solution.AllProjects.Where(x => x.Is(ProjectType.CSharpProject)).Should().HaveCount(9);

            var buildProject = solution.AllProjects.SingleOrDefault(x => x.Name == "_build");
            buildProject.Should().NotBeNull();
            buildProject.Is(ProjectType.CSharpProject).Should().BeTrue();

            // solution.SaveAs(solution.Path + ".bak");
        }

        [Fact]
        public void SolutionGetProjectsTest()
        {
            var solution = ProjectModelTasks.ParseSolution(SolutionFile);

            solution.GetProjects("*.Tests").Should().HaveCount(2);
        }

        [Fact]
        public void ProjectTest()
        {
            var solution = ProjectModelTasks.ParseSolution(SolutionFile);
            solution.Projects.First().GetMSBuildProject();
        }
    }
}
