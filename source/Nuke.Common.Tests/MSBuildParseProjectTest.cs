// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Tools.MSBuild;
using Nuke.Core.IO;
using Xunit;

namespace Nuke.Common.Tests
{
    public class MSBuildParseProjectTest
    {
        [Fact]
        public void Test ()
        {
            var currentDirectory = (PathConstruction.AbsolutePath) Directory.GetCurrentDirectory();
            var projectFile = currentDirectory / ".." / ".." / ".." / ".." / "Nuke.Common" / "Nuke.Common.csproj";

            var project = MSBuildTasks.MSBuildParseProject(projectFile, x => x.SetProperty("TargetFramework", "netstandard2.0"));
            project.IsSdkProject.Should().BeTrue();
            project.Properties["Configuration"].Should().Be("Debug");
            project.ItemGroups["PackageReference"].Should().NotContain("Octokit");

            project = MSBuildTasks.MSBuildParseProject(projectFile, x => x.SetProperty("TargetFramework", "net461").SetConfiguration("Release"));
            project.Properties["Configuration"].Should().Be("Release");
            project.ItemGroups["PackageReference"].Should().Contain("Octokit");
        }
    }
}
