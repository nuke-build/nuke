// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities;
using Xunit;

namespace Nuke.Common.Tests
{
    public class SolutionModelTest
    {
        private static AbsolutePath RootDirectory => Constants.TryGetRootDirectoryFrom(EnvironmentInfo.WorkingDirectory).NotNull();

        private static AbsolutePath SolutionFile => RootDirectory / "nuke-common.sln";

        [Fact]
        public void SolutionTest()
        {
            var solution = SolutionModelTasks.ParseSolution(SolutionFile);

            solution.SolutionFolders.Select(x => x.Name).Should().BeEquivalentTo("misc");
            solution.AllProjects.Where(x => x.Is(ProjectType.CSharpProject)).Should().HaveCountGreaterOrEqualTo(9);

            var buildProject = solution.AllProjects.SingleOrDefault(x => x.Name == "_build");
            buildProject.Should().NotBeNull();
            buildProject.Is(ProjectType.CSharpProject).Should().BeTrue();

            // solution.SaveAs(solution.Path + ".bak");
        }

        [Fact]
        public void SolutionGetProjectsTest()
        {
            var solution = SolutionModelTasks.ParseSolution(SolutionFile);

            solution.GetProjects("*.Tests").Should().HaveCountGreaterOrEqualTo(2);
        }

        [Fact]
        public void DuplicatedProjectTest()
        {
            var content = """
                Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "_build", "build\_build.csproj", "{BB6A9024-24DB-4170-A09B-02349148A78F}"
                EndProject
                Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "_build", "build\_build.csproj", "{BB6A9024-24DB-4170-A09B-02349148A78F}"
                EndProject
                Global
                EndGlobal
                """.SplitLineBreaks();

            Action action = () => SolutionSerializer.DeserializeFromContent<Solution>(content);
            action.Should().Throw<Exception>()
                .Where(x => x.Message.Contains("Solution contains duplicated project ids") &&
                            x.Message.Contains(" - bb6a9024-24db-4170-a09b-02349148a78f"));
        }

        [Fact]
        public void DuplicatedSolutionConfigurationTest()
        {
            var content = """
                
                Global
                	GlobalSection(SolutionConfigurationPlatforms) = preSolution
                		Debug|Any CPU = Debug|Any CPU
                		Debug|Any CPU = Debug|Any CPU
                		Release|Any CPU = Release|Any CPU
                	EndGlobalSection
                EndGlobal
                """.SplitLineBreaks();

            Action action = () => SolutionSerializer.DeserializeFromContent<Solution>(content);
            action.Should().Throw<Exception>()
                .Where(x => x.Message.Contains("Solution contains duplicated SolutionConfigurationPlatforms entries") &&
                            x.Message.Contains(" - Debug|Any CPU"));
        }

        [Fact]
        public void DuplicatedProjectConfigurationTest()
        {
            var content = """
                
                Global
                	GlobalSection(ProjectConfigurationPlatforms) = postSolution
                		{BB6A9024-24DB-4170-A09B-02349148A78F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
                		{BB6A9024-24DB-4170-A09B-02349148A78F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
                		{BB6A9024-24DB-4170-A09B-02349148A78F}.Release|Any CPU.ActiveCfg = Debug|Any CPU
                	EndGlobalSection
                EndGlobal
                """.SplitLineBreaks();

            Action action = () => SolutionSerializer.DeserializeFromContent<Solution>(content);
            action.Should().Throw<Exception>()
                .Where(x => x.Message.Contains("Solution contains duplicated ProjectConfigurationPlatforms entries") &&
                            x.Message.Contains(" - {BB6A9024-24DB-4170-A09B-02349148A78F}.Debug|Any CPU.ActiveCfg"));
        }
    }
}
