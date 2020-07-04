// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.BuildProfiles
{
    [PublicAPI]
    public class LoadBuildProfilesAttribute : BuildProfileManagementAttributeBase, IOnBeforeLogo
    {
        public void OnBeforeLogo(NukeBuild build, IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            void LoadProfile(string profile)
            {
                var profileFile = GetProfileFile(profile);
                var profileContent = TextTasks.ReadAllText(profileFile);
                JsonConvert.PopulateObject(profileContent, build, GetSerializerSettings(profile));
            }

            NukeBuild.LoadedProfiles.ForEach(LoadProfile);
        }
    }
}
