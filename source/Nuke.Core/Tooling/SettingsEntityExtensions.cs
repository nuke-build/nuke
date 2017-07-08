// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
#if !NETCORE
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#endif

namespace Nuke.Core.Tooling
{
    public static class SettingsEntityExtensions
    {
        public static T NewInstance<T> (this T settingsEntity)
            where T : ISettingsEntity
        {
#if NETCORE
            return settingsEntity;
#else
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
#endif
        }
    }
}
