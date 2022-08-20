// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using Serilog;

namespace Nuke.Common.Execution
{
    [PublicAPI]
    public class HandleReSharperSurrogateArgumentsAttribute : BuildExtensionAttributeBase, IOnBuildCreated
    {
        private const string SurrogateFileName = "nuke.tmp";

        public void OnBuildCreated(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            var surrogateFile = NukeBuild.BuildAssemblyDirectory / SurrogateFileName;
            if (!File.Exists(surrogateFile))
                return;

            var argumentLines = File.ReadAllLines(surrogateFile);
            var lastWriteTime = File.GetLastWriteTime(surrogateFile);

            Assert.HasSingleItem(argumentLines, $"{SurrogateFileName} must have only one single line");
            File.Delete(surrogateFile);
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
