// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Nuke.Common.Tools.MSBuild;
using Nuke.Core.IO;

namespace Nuke.Common.Tests
{
    public class MSBuildParseTest
    {
        [WindowsFact]
        public void Test ()
        {
            var currentDirectory = (PathConstruction.AbsolutePath) Directory.GetCurrentDirectory();
            var projectFile = currentDirectory / ".." / ".." / ".." / ".." / "Nuke.Common" / "Nuke.Common.csproj";

            var project = MSBuildTasks.MSBuildParse(projectFile, x => x.SetProperty("TargetFramework", "netstandard1.6"));
            project.IsSdkProject.Should().BeTrue();
            project.Properties["Configuration"].Should().Be("Debug");
            project.ItemGroups["PackageReference"].Should().NotContain("Octokit");

            project = MSBuildTasks.MSBuildParse(projectFile, x => x.SetProperty("TargetFramework", "net46").SetConfiguration("Release"));
            project.Properties["Configuration"].Should().Be("Release");
            project.ItemGroups["PackageReference"].Should().Contain("Octokit");
        }
    }
}
