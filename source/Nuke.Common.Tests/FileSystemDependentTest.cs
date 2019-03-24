// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuke.Common.IO;
using Xunit.Abstractions;

namespace Nuke.Common.Tests
{
    public abstract class FileSystemDependentTest
    {
        public ITestOutputHelper TestOutputHelper { get; }
        public string TestName { get; }
        public string ExecutionDirectory { get; }
        public string TestProjectDirectory { get; }
        public string RootDirectory { get; }
        public string TestTempDirectory { get; }

        protected FileSystemDependentTest(ITestOutputHelper testOutputHelper)
        {
            TestOutputHelper = testOutputHelper;

            TestName = ((ITest) testOutputHelper.GetType()
                .GetField("test", BindingFlags.NonPublic | BindingFlags.Instance).NotNull()
                .GetValue(testOutputHelper)).TestCase.TestMethod.Method.Name;

            ExecutionDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).NotNull();
            RootDirectory = FileSystemTasks.FindParentDirectory(ExecutionDirectory, x => x.GetFiles(".nuke").Any());
            TestProjectDirectory = FileSystemTasks.FindParentDirectory(ExecutionDirectory, x => x.GetFiles("*.csproj").Any());
            TestTempDirectory = Path.Combine(ExecutionDirectory, "temp", $"{GetType().Name}.{TestName}");

            FileSystemTasks.EnsureCleanDirectory(TestTempDirectory);
        }
    }
}
