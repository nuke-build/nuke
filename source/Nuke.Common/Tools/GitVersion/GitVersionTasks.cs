// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;
using Newtonsoft.Json;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.GitVersion
{
    partial class GitVersionTasks
    {
        public static GitVersion GitVersion (GitVersionSettings gitVersionSettings = null)
        {
            gitVersionSettings = gitVersionSettings ?? new GitVersionSettings();
            var processSettings = new ProcessSettings().EnableRedirectOutput();

            var process = ProcessTasks.StartProcess(gitVersionSettings, processSettings);
            process.AssertWaitForExit();
            if (process.ExitCode != 0)
                ProcessTasks.StartProcess(gitVersionSettings, processSettings.DisableRedirectOutput()).AssertZeroExitCode();

            var output = process.Output.EnsureOnlyStd().Select(x => x.Text);
            return JsonConvert.DeserializeObject<GitVersion>(string.Join("\r\n", output));
        }
    }
}
