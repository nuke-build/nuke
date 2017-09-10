// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Newtonsoft.Json;
using Nuke.Core;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.GitVersion
{
    partial class GitVersionTasks
    {
        public static GitVersionSettings DefaultGitVersion => new GitVersionSettings()
                .SetWorkingDirectory(NukeBuild.Instance.RootDirectory);

        public static GitVersion GitVersion (Configure<GitVersionSettings> configurator = null)
        {
            var toolSettings = configurator.InvokeSafe(new GitVersionSettings());
            var processSettings = new ProcessSettings().EnableRedirectOutput();

            var process = ProcessTasks.StartProcess(toolSettings, processSettings);
            process.AssertWaitForExit();
            if (process.ExitCode != 0)
                ProcessTasks.StartProcess(toolSettings, processSettings.DisableRedirectOutput()).AssertZeroExitCode();

            var output = process.Output.EnsureOnlyStd().Select(x => x.Text);
            return JsonConvert.DeserializeObject<GitVersion>(string.Join("\r\n", output));
        }
    }
}
