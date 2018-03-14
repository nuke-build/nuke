// Copyright Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuke.Core;
using Nuke.Core.IO;
using Nuke.Core.Utilities;
using Xunit.Abstractions;
using static Nuke.Core.IO.PathConstruction;

namespace Nuke.Common.Tests
{
    public class IntegrationTestBase
    {
        public AbsolutePath RootDirectory => TestProjectDirectory / ".." / "..";
        public AbsolutePath TestProjectDirectory => (AbsolutePath) Directory.GetCurrentDirectory() / ".." / ".." / "..";
        public AbsolutePath ApprovalDirectory => TestProjectDirectory / "approvals" / TestName;

        public ITestOutputHelper TestOutputHelper { get; }
        public AbsolutePath TestOutputDirectory { get; }
        public string TestName { get; }

        public IntegrationTestBase(ITestOutputHelper testOutputHelper)
        {
            TestOutputHelper = testOutputHelper;

            TestName = ((ITest) testOutputHelper.GetType()
                .GetField("test", BindingFlags.NonPublic | BindingFlags.Instance).NotNull()
                .GetValue(testOutputHelper)).TestCase.TestMethod.Method.Name;

            FileSystemTasks.EnsureCleanDirectory(".tmp");
            TestOutputDirectory = (AbsolutePath) Path.GetFullPath(".tmp");
            Directory.CreateDirectory(TestOutputDirectory / ".git");
        }

        protected string CreateCompositeScript(IReadOnlyCollection<string> fixFiles)
        {
            return CreateScript(fixFiles.Select(x => $"start {x}").JoinNewLine());
        }

        protected string CreateMoveScript(string gold, string temp)
        {
            return CreateScript($"{(EnvironmentInfo.IsWin ? "move /Y" : "mv")} {temp.DoubleQuoteIfNeeded()} {gold.DoubleQuoteIfNeeded()}");
        }

        protected string CreateRiderComparisonScript(string gold, string temp)
        {
            var userDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var riderDirectory = Directory.GetDirectories(userDirectory, ".Rider*.*").LastOrDefault();
            if (riderDirectory == null || !Directory.Exists(riderDirectory))
                return null;

            var homeFile = Path.Combine(riderDirectory, "system/.home");
            if (!File.Exists(homeFile))
                return null;

            var text = File.ReadAllText(homeFile).Trim();
            var riderExecutable = Path.Combine(text, "bin", GetRiderExecutable());
            if (!File.Exists(riderExecutable))
                return null;

            return CreateScript($"start {riderExecutable} diff {gold.DoubleQuoteIfNeeded()} {temp.DoubleQuoteIfNeeded()}");
        }

        private string CreateScript(string content)
        {
            var scriptFile = Path.ChangeExtension(Path.GetTempFileName(), "bat");
            File.WriteAllText(scriptFile, content);
            
            return new Uri(scriptFile).AbsoluteUri;
        }

        private string GetRiderExecutable()
        {
            switch (EnvironmentInfo.Platform)
            {
                case PlatformFamily.Windows:
                    return EnvironmentInfo.Is64Bit ? "rider64.exe" : "rider.exe";
                case PlatformFamily.OSX:
                    return "rider";
                case PlatformFamily.Linux:
                    return "rider.sh";
                default:
                    throw new NotSupportedException("Unknown environment.");
            }
        }
    }
}
