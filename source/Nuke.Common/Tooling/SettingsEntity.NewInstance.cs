// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static partial class SettingsEntityExtensions
    {
        public static T NewInstance<T>(this T settingsEntity)
            where T : ISettingsEntity
        {
            var binaryFormatter = new BinaryFormatter();

            using var memoryStream = new MemoryStream();
            binaryFormatter.Serialize(memoryStream, settingsEntity);
            memoryStream.Seek(offset: 0, loc: SeekOrigin.Begin);

            var newInstance = (T) binaryFormatter.Deserialize(memoryStream);
            if (newInstance is ToolSettings toolSettings)
                toolSettings.ProcessArgumentConfigurator = ((ToolSettings) (object) settingsEntity).ProcessArgumentConfigurator;

            return newInstance;
        }
    }
}
