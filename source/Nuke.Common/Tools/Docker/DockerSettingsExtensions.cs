// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;

namespace Nuke.Common.Tools.Docker
{
    [PublicAPI]
    public static class DockerSettingsExtensions
    {
        public static T SetCliSettings<T>(this T settings, Configure<CliSettings> configure)
            where T : DockerSettings
        {
            var dockerSettings = settings.NewInstance();
            dockerSettings.CliSettings = settings.CliSettings = configure.InvokeSafe(new CliSettings());
            return dockerSettings;
        }

        public static T ResetCliSettings<T>(this T settings)
            where T : DockerSettings
        {
            var dockerSettings = settings.NewInstance();
            dockerSettings.CliSettings = new CliSettings();
            return dockerSettings;
        }
    }
}
