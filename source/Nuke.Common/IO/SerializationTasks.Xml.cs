// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using JetBrains.Annotations;

namespace Nuke.Common.IO
{
    public static partial class SerializationTasks
    {
        [Obsolete($"Use {nameof(SerializationTasks)}.{nameof(WriteXml)} as {nameof(AbsolutePath)} extension method")]
        public static void XmlSerializeToFile<T>(T obj, string path, SaveOptions options = SaveOptions.None)
        {
            TextTasks.WriteAllText(path, XmlSerialize(obj, options));
        }

        [Pure]
        [Obsolete($"Use {nameof(SerializationTasks)}.{nameof(ReadXml)} as {nameof(AbsolutePath)} extension method")]
        public static T XmlDeserializeFromFile<T>(string path, LoadOptions options = LoadOptions.PreserveWhitespace)
        {
            Assert.FileExists(path);
            return XmlDeserialize<T>(File.ReadAllText(path), options);
        }

        [Pure]
        public static string XmlSerialize<T>(T obj, SaveOptions options = SaveOptions.None)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var xmlDocument = new XDocument();

            using (var writer = xmlDocument.CreateWriter())
            {
                xmlSerializer.Serialize(writer, obj);
            }

            return xmlDocument.ToString(options);
        }

        [Pure]
        public static T XmlDeserialize<T>(string content, LoadOptions options = LoadOptions.PreserveWhitespace)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var xmlDocument = XDocument.Parse(content, options);

            using var reader = xmlDocument.Root.NotNull().CreateReader();
            return (T) xmlSerializer.Deserialize(reader);
        }

        [Obsolete($"Use {nameof(SerializationTasks)}.{nameof(UpdateXml)} as {nameof(AbsolutePath)} extension method")]
        public static void XmlUpdateFile<T>(
            string path,
            Action<T> update,
            LoadOptions loadOptions = LoadOptions.PreserveWhitespace,
            SaveOptions saveOptions = SaveOptions.None)
        {
            var obj = XmlDeserializeFromFile<T>(path, loadOptions);
            update.Invoke(obj);
            XmlSerializeToFile(obj, path, saveOptions);
        }
    }
}
