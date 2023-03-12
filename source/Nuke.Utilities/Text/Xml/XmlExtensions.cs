// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using JetBrains.Annotations;
using Nuke.Common.IO;

namespace Nuke.Common.Utilities
{
    [PublicAPI]
    public static class XmlExtensions
    {
        /// <summary>
        /// Serializes an object as XML string.
        /// </summary>
        [Pure]
        public static string ToXml<T>(this T obj, SaveOptions options = SaveOptions.None)
        {
            var serializer = new XmlSerializer(typeof(T));
            var document = new XDocument();

            using (var writer = document.CreateWriter())
            {
                serializer.Serialize(writer, obj);
            }

            return document.ToString(options);
        }

        /// <summary>
        /// Deserializes an object from a XML string.
        /// </summary>
        [Pure]
        public static T GetXml<T>(this string content, LoadOptions options = LoadOptions.PreserveWhitespace)
        {
            var serializer = new XmlSerializer(typeof(T));
            var document = XDocument.Parse(content, options);

            using var reader = document.Root.NotNull().CreateReader();
            return (T) serializer.Deserialize(reader);
        }

        /// <summary>
        /// Serializes an <see cref="XDocument"/> to a file.
        /// </summary>
        public static void WriteXml(this AbsolutePath path, XDocument obj, SaveOptions options = SaveOptions.None)
        {
            obj.Save(path, options);
        }

        /// <summary>
        /// Serializes an object as XML to a file.
        /// </summary>
        public static void WriteXml<T>(this AbsolutePath path, T obj, SaveOptions options = SaveOptions.None)
        {
            var content = obj.ToXml(options);
            path.WriteAllText(content);
        }

        /// <summary>
        /// Deserializes an <see cref="XDocument"/> from a file.
        /// </summary>
        [Pure]
        public static XDocument ReadXml(this AbsolutePath path, LoadOptions options = LoadOptions.PreserveWhitespace)
        {
            Assert.FileExists(path);
            return XDocument.Load(path, options);
        }

        /// <summary>
        /// Deserializes an object as XML from a file.
        /// </summary>
        [Pure]
        public static T ReadXml<T>(this AbsolutePath path, LoadOptions options = LoadOptions.PreserveWhitespace)
        {
            var content = path.ReadAllText();
            return content.GetXml<T>(options);
        }

        /// <summary>
        /// Deserializes an object as XML from a file, applies updates, and serializes it back to the file.
        /// </summary>
        public static void UpdateXml<T>(
            this AbsolutePath path,
            Action<T> update,
            LoadOptions loadOptions = LoadOptions.PreserveWhitespace,
            SaveOptions saveOptions = SaveOptions.None)
        {
            var before = path.ReadAllText();
            var obj = before.GetXml<T>(loadOptions);
            update.Invoke(obj);
            var after = obj.ToXml(saveOptions);
            path.WriteAllText(after);
        }

        /// <summary>
        /// Deserializes a <see cref="XDocument"/> from a file, applies updates, and serializes it back to the file.
        /// </summary>
        public static void UpdateXml(
            this AbsolutePath path,
            Action<XDocument> update,
            LoadOptions loadOptions = LoadOptions.PreserveWhitespace,
            SaveOptions saveOptions = SaveOptions.None)
        {
            path.WriteXml(path.ReadXml(loadOptions), saveOptions);
        }
    }
}
