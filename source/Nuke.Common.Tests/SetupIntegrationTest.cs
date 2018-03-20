// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Nuke.Core;
using Nuke.Core.IO;
using Nuke.Core.Utilities;
using Xunit;
using Xunit.Abstractions;
using static Nuke.Core.IO.PathConstruction;

namespace Nuke.Common.Tests
{
    public class SetupIntegrationTest : IntegrationTestBase
    {
        public SetupIntegrationTest(ITestOutputHelper testOutputHelper)
            : base(testOutputHelper)
        {
        }

        public void Test()
        {
            CopySolutionFile();

            ExecuteSetup();

            AssertOutput();
        }

        private void CopySolutionFile(RelativePath solutionFileRelative = null)
        {
            var solutionDirectory = TestOutputDirectory / (solutionFileRelative ?? string.Empty);
            FileSystemTasks.EnsureExistingDirectory(solutionDirectory);
            File.WriteAllText(solutionDirectory / "Dummy.sln",
                @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.27130.2036
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"") = ""ClassLibrary1"", ""ClassLibrary1\ClassLibrary1.csproj"", ""{3B8A39C0-EB3C-42F7-8880-F9C2F7F8852A}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{3B8A39C0-EB3C-42F7-8880-F9C2F7F8852A}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{3B8A39C0-EB3C-42F7-8880-F9C2F7F8852A}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{3B8A39C0-EB3C-42F7-8880-F9C2F7F8852A}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{3B8A39C0-EB3C-42F7-8880-F9C2F7F8852A}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {C58E3D98-D10A-40C6-B6AB-517BCCD785AD}
	EndGlobalSection
EndGlobal
",
                Encoding.UTF8);
        }

        private void ExecuteSetup(
            RelativePath setupDirectoryRelative = null,
            int? solutionChoice = null,
            TargetPlatform targetPlatform = TargetPlatform.Core,
            ProjectFormat projectFormat = ProjectFormat.Sdk,
            string nugetVersion = null,
            string nukeVersion = null,
            string buildDirectoryName = null,
            string buildProjectName = null)
        {
            var bootstrappingDirectory = RootDirectory / "bootstrapping";
            var setupFileName = EnvironmentInfo.IsWin ? "setup.ps1" : "setup.sh";
            var workingDirectory = TestOutputDirectory / (setupDirectoryRelative ?? string.Empty);
            FileSystemTasks.EnsureExistingDirectory(workingDirectory);
            var setupFileAbsolute = workingDirectory / setupFileName;

            var bootstrappingUri = EnvironmentInfo.IsWin ? new Uri(bootstrappingDirectory).AbsoluteUri : $"file://{bootstrappingDirectory}";
            var content = File.ReadAllText(bootstrappingDirectory / setupFileName)
                .Replace("https://raw.githubusercontent.com/nuke-build/nuke/master/bootstrapping", bootstrappingUri)
                .Replace("[guid]::NewGuid().ToString().ToUpper()", "99351CF7-E7C8-45AE-8A5B-E3E964AC5F12".DoubleQuote())
                .Replace("$(python -c \"import uuid; print str(uuid.uuid4()).upper()\")", "99351CF7-E7C8-45AE-8A5B-E3E964AC5F12".DoubleQuote())
                .ReplaceRegex("\\$NukeVersion = \\$\\(Invoke.*", x => "$NukeVersion = \"1.3.3.7\"")
                .ReplaceRegex("NUKE_VERSION=\\$\\(curl.*", x => "NUKE_VERSION=\"1.3.3.7\"");
            File.WriteAllText(setupFileAbsolute, content);

            TestOutputHelper.WriteLine("Starting setup script...");
            var process = new Process
                          {
                              StartInfo = new ProcessStartInfo
                                          {
                                              FileName = EnvironmentInfo.IsWin ? "powershell" : "bash",
                                              Arguments = setupFileAbsolute,
                                              WorkingDirectory = workingDirectory,
                                              UseShellExecute = false,
                                              RedirectStandardInput = true,
                                              RedirectStandardOutput = true,
                                              RedirectStandardError = true
                                          }
                          };

            process.OutputDataReceived += (s, e) =>
            {
                Logger.Log(e.Data);
                TestOutputHelper.WriteLine("STD: " + e.Data);
            };
            process.ErrorDataReceived += (s, e) =>
            {
                Logger.Error(e.Data);
                TestOutputHelper.WriteLine("ERR: " + e.Data);
            };
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            if (solutionChoice.HasValue)
                process.StandardInput.WriteLine(solutionChoice.Value);

            process.StandardInput.WriteLine(EnvironmentInfo.IsWin
                ? targetPlatform == TargetPlatform.Framework ? "F" : "C"
                : ((int) targetPlatform).ToString());

            if (targetPlatform == TargetPlatform.Framework)
            {
                process.StandardInput.WriteLine(EnvironmentInfo.IsWin
                    ? projectFormat == ProjectFormat.Legacy ? "L" : "S"
                    : ((int) projectFormat).ToString());

                process.StandardInput.WriteLine(nugetVersion);
            }

            if (targetPlatform == TargetPlatform.Core || projectFormat == ProjectFormat.Sdk)
                process.StandardInput.WriteLine(nukeVersion);

            process.StandardInput.WriteLine(buildDirectoryName);
            process.StandardInput.WriteLine(buildProjectName);

            process.WaitForExit();
            Trace.Assert(process.ExitCode == 0);

            File.WriteAllText(TestOutputDirectory / "structure.txt",
                Directory.GetFiles(TestOutputDirectory, "*", SearchOption.AllDirectories)
                    .Select(x => GetRelativePath(TestOutputDirectory, x).Replace(oldChar: '\\', newChar: '/'))
                    .OrderBy(x => x.Length)
                    .ThenBy(x => x).JoinNewLine(PlatformFamily.Windows));
        }

        private void AssertOutput()
        {
            FileSystemTasks.EnsureExistingDirectory(ApprovalDirectory);
            var oldFiles = Directory.GetFiles(ApprovalDirectory, "*.tmp");
            foreach (var oldFile in oldFiles)
                File.Delete(oldFile);

            var fixFiles = new List<string>();
            var builder = new StringBuilder();

            var enumerable = Directory.GetFiles(TestOutputDirectory, "*", SearchOption.AllDirectories);
            foreach (var file in enumerable)
            {
                var fileName = Path.GetFileName(file);
                var approvalFile = ApprovalDirectory / (fileName + ".gold");
                var tempFile = Path.ChangeExtension(approvalFile, "tmp").NotNull();
                File.Move(file, tempFile);

                string fixFile = null;
                if (!File.Exists(approvalFile))
                {
                    fixFile = CreateMoveScript(approvalFile, tempFile);
                    builder.AppendLine($"{fileName} COPY {fixFile}");
                }
                else if (!File.ReadAllText(approvalFile).Equals(File.ReadAllText(tempFile)))
                {
                    fixFile = CreateMoveScript(approvalFile, tempFile);
                    builder.AppendLine($"{fileName} COPY {fixFile}");
                    builder.AppendLine($"{fileName} COMPARE {CreateRiderComparisonScript(approvalFile, tempFile)}");
                }
                else
                    File.Delete(tempFile);

                if (fixFile != null)
                    fixFiles.Add(fixFile);
            }

            if (fixFiles.Count > 0)
                TestOutputHelper.WriteLine($"COPY ALL {CreateCompositeScript(fixFiles)}");

            TestOutputHelper.WriteLine(builder.ToString());

            Assert.True(fixFiles.Count == 0);
        }

        public enum TargetPlatform
        {
            Framework,
            Core
        }

        public enum ProjectFormat
        {
            Legacy,
            Sdk
        }
    }
}
