// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common.IO;
using Serilog;

namespace Nuke.Common.Execution
{
    internal class HandleReSharperSurrogateArgumentsAttribute : BuildExtensionAttributeBase, IOnBuildCreated
    {
        private const string SurrogateFileName = "nuke.tmp";

        private AbsolutePath SurrogateFile => Build.BuildAssemblyDirectory / SurrogateFileName;

        public void OnBuildCreated(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (!SurrogateFile.Exists())
                return;

            var argumentLines = SurrogateFile.ReadAllLines();
            var lastWriteTime = File.GetLastWriteTime(SurrogateFile);

            Assert.HasSingleItem(argumentLines, $"{SurrogateFileName} must have only one single line");
            SurrogateFile.DeleteFile();
            if (lastWriteTime.AddMinutes(value: 1) < DateTime.Now)
            {
                Log.Warning("Last write time of {File} was {LastWriteTime}. Skipping ...", SurrogateFileName, lastWriteTime);
                return;
            }

            var arguments = argumentLines.Single();
            EnvironmentInfo.ArgumentParser = new ArgumentParser(arguments);
        }
    }
}
