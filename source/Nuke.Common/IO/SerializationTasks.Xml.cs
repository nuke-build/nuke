// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using JetBrains.Annotations;

namespace Nuke.Common.IO
{
    public static partial class SerializationTasks
    {
        public static void XmlSerializeToFile(object obj, string path)
        {
            TextTasks.WriteAllText(path, XmlSerialize(obj));
        }

        [Pure]
        public static T XmlDeserializeFromFile<T>(string path)
        {
            return XmlDeserialize<T>(File.ReadAllText(path));
        }

        [Pure]
        public static string XmlSerialize<T>(T obj)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            using var streamWriter = new StringWriter();
            xmlSerializer.Serialize(streamWriter, obj);
            return streamWriter.ToString();
        }

        [Pure]
        public static T XmlDeserialize<T>(string content)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            using var memoryStream = new StringReader(content);
            return (T) xmlSerializer.Deserialize(memoryStream);
        }
    }
}
