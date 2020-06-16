// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common.Execution;

namespace Nuke.Common.BuildProfiles
{
    [PublicAPI]
    public class SaveBuildProfileAttribute : BuildProfileManagementAttributeBase, IOnBeforeLogo
    {
        public void OnBeforeLogo(
            NukeBuild build,
            IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            if (NukeBuild.SaveProfile == null)
                return;

            var profileFile = GetProfileFile(NukeBuild.SaveProfile);
            var content = JsonConvert.SerializeObject(build, Formatting.Indented, GetSerializerSettings(NukeBuild.SaveProfile));
            File.WriteAllText(profileFile, content);

            Environment.Exit(0);
        }
    }
}
