// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Nuke.GlobalTool.Tests
{
    public class ProgramTest
    {
        [Theory]
        [InlineData(
            @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.27703.2047
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""ConsoleApp1"", ""ConsoleApp1\ConsoleApp1.csproj"", ""{1992CC3B-CF32-485C-8DBC-77D0B6F18A82}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{1992CC3B-CF32-485C-8DBC-77D0B6F18A82}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{1992CC3B-CF32-485C-8DBC-77D0B6F18A82}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{1992CC3B-CF32-485C-8DBC-77D0B6F18A82}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{1992CC3B-CF32-485C-8DBC-77D0B6F18A82}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {61B2112A-2DA2-45AC-AFF5-6C50A10BB92F}
	EndGlobalSection
EndGlobal
",
            @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.27703.2047
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""ConsoleApp1"", ""ConsoleApp1\ConsoleApp1.csproj"", ""{1992CC3B-CF32-485C-8DBC-77D0B6F18A82}""
EndProject
Project(""{KIND}"") = ""NAME"", ""RELATIVE"", ""{GUID}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{GUID}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{GUID}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{1992CC3B-CF32-485C-8DBC-77D0B6F18A82}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{1992CC3B-CF32-485C-8DBC-77D0B6F18A82}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{1992CC3B-CF32-485C-8DBC-77D0B6F18A82}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{1992CC3B-CF32-485C-8DBC-77D0B6F18A82}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {61B2112A-2DA2-45AC-AFF5-6C50A10BB92F}
	EndGlobalSection
EndGlobal
")]
        [InlineData(
            @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.27703.2047
MinimumVisualStudioVersion = 10.0.40219.1
Global
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {77D83C53-98F5-4275-8217-14700BCA05BB}
	EndGlobalSection
EndGlobal
",
            @"
Microsoft Visual Studio Solution File, Format Version 12.00
Project(""{KIND}"") = ""NAME"", ""RELATIVE"", ""{GUID}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{GUID}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{GUID}.Release|Any CPU.ActiveCfg = Release|Any CPU
	EndGlobalSection
EndGlobal
")]
        [InlineData(
            @"
Microsoft Visual Studio Solution File, Format Version 12.00
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
EndGlobal
",
            @"
Microsoft Visual Studio Solution File, Format Version 12.00
Project(""{KIND}"") = ""NAME"", ""RELATIVE"", ""{GUID}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{GUID}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{GUID}.Release|Any CPU.ActiveCfg = Release|Any CPU
	EndGlobalSection
EndGlobal
")]
        public void Test(string input, string expected)
        {
            var content = input.Split(Environment.NewLine).ToList();
            Program.UpdateSolutionFileContent(content, "RELATIVE", "GUID", "KIND", "NAME");

            content.Should().BeEquivalentTo(expected.Split(Environment.NewLine));
        }
    }
}
