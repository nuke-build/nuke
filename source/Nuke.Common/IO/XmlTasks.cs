// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Core;
using Nuke.Core.Execution;

#if !NETCORE
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using System.Xml.XPath;
#endif

[assembly: IconClass(typeof(XmlTasks), "file-empty2")]

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class XmlTasks
    {
#if !NETCORE
        public static void XmlSerialize<T>(T obj, string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, obj);
                File.WriteAllBytes(path, memoryStream.GetBuffer());
            }
        }
        
        [Pure]
        public static T XmlDeserialize<T>(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            var bytes = File.ReadAllBytes(path);
            using (var memoryStream = new MemoryStream(bytes))
            {
                return (T) xmlSerializer.Deserialize(memoryStream);
            }
        }
#endif
        
        public static IEnumerable<string> XmlPeek (string path, string xpath)
        {
            var (elements, attributes) = GetObjects(XDocument.Load(path), xpath);
            ControlFlow.Assert(!(elements.Count != 0 && attributes.Count != 0), "!(elements.Count != 0 && attributes.Count != 0)");

            return elements.Count != 0 ? elements.Select(x => x.Value) : attributes.Select(x => x.Value);
        }

        [CanBeNull]
        public static string XmlPeekSingle (string path, string xpath)
        {
            var values = XmlPeek(path, xpath).ToList();
            ControlFlow.Assert(values.Count <= 1, "values.Count <= 1");
            return values.SingleOrDefault();
        }

        public static void XmlPoke (string path, string xpath, object value)
        {
            var (elements, attributes) = GetObjects(XDocument.Load(path), xpath);

            ControlFlow.Assert(elements.Count == 1 || attributes.Count == 1, "elements.Count == 1 || attributes.Count == 1");
            ControlFlow.Assert(elements.Count == 0 || attributes.Count == 0, "elements.Count == 0 || attributes.Count == 0");

            elements.SingleOrDefault()?.SetValue(value);
            attributes.SingleOrDefault()?.SetValue(value);
        }

        private static (IReadOnlyCollection<XElement> Elements, IReadOnlyCollection<XAttribute> Attributes) GetObjects (
            XDocument document,
            string xpath)
        {
#if NETCORE
            throw new NotImplementedException();
#else
            var objects = ((IEnumerable) document.XPathEvaluate(xpath)).Cast<XObject>().ToList();
            return (objects.OfType<XElement>().ToList().AsReadOnly(),
                    objects.OfType<XAttribute>().ToList().AsReadOnly());
#endif
        }
    }
}
