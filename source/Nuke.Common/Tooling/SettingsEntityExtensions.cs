// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Nuke.Common.Tooling
{
    public static class SettingsEntityExtensions
    {
        public static T NewInstance<T>(this T settingsEntity)
            where T : ISettingsEntity
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, settingsEntity);
                memoryStream.Seek(offset: 0, loc: SeekOrigin.Begin);
                var newInstance = (T) binaryFormatter.Deserialize(memoryStream);
                var toolSettings = newInstance as ToolSettings;
                if (toolSettings != null)
                    toolSettings.ArgumentConfigurator = ((ToolSettings) (object) settingsEntity).ArgumentConfigurator;
                return newInstance;
            }
        }
    }
}
