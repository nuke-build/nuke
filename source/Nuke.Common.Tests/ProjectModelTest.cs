// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Nuke.Common.ProjectModel;
using Xunit;
using static Nuke.Common.IO.PathConstruction;

// ReSharper disable ArgumentsStyleLiteral

namespace Nuke.Common.Tests
{
    public class ProjectModelTest
    {
        private static AbsolutePath SolutionFile
            => (AbsolutePath) Directory.GetCurrentDirectory() / ".." / ".." / ".." / ".." / ".." / "nuke-common.sln";

        [Fact]
        public void SolutionTest()
        {
            var solution = ProjectModelTasks.ParseSolution(SolutionFile);

            solution.Projects.Where(x => x.Is(ProjectType.SolutionFolder)).Select(x => x.Name)
                .Should().BeEquivalentTo("bootstrapping", "misc");

            solution.Projects.Where(x => x.Is(ProjectType.CSharpProject)).Should().HaveCount(6);

            var buildProject = solution.Projects.SingleOrDefault(x => x.Name == ".build");
            buildProject.Should().NotBeNull();
            buildProject.Is(ProjectType.CSharpProject).Should().BeTrue();
        }

        [Fact]
        public void SolutionGetProjectsTest()
        {
            var solution = ProjectModelTasks.ParseSolution(SolutionFile);

            solution.GetProjects("*.Tests").Should().HaveCount(1);
        }

//        [Fact]
//        public void ProjectTest ()
//        {
//            //EnvironmentInfo.SetVariable("VisualStudioVersion", @"15.0");
//            EnvironmentInfo.SetVariable("VSINSTALLDIR", @"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional");
//            //EnvironmentInfo.SetVariable("MSBuildSDKsPath", @"C:\Program Files\dotnet\sdk\2.0.0\Sdks");
//            EnvironmentInfo.SetVariable("MSBuildExtensionsPath", @"..\..\..");
//
//            var netstandardProject = ProjectModelTasks.ParseSolution(SolutionFile, targetFramework: "netstandard2.0")
//                    .Projects.Single(x => x.Name == "Nuke.Common");
//            var netframeworkProject = ProjectModelTasks.ParseSolution(SolutionFile, targetFramework: "net461")
//                    .Projects.Single(x => x.Name == "Nuke.Common");
//
//            netstandardProject.Items["PackageReference"].Should().Contain("NETStandard.Library");
//            netframeworkProject.Items["PackageReference"].Should().Contain("Octokit");
//        }
    }
}
