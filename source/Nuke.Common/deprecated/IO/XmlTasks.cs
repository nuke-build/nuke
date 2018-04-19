#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using JetBrains.Annotations;

namespace Nuke.Core.IO
{
    [PublicAPI]
    [Obsolete("Namespace 'Core' is deprecated. Simply do a text replace from 'Nuke.Core' to 'Nuke.Common' to resolve all warnings.")]
    public static class XmlTasks
    {
        public static IEnumerable<string> XmlPeek(string path, string xpath)
        {
            var (elements, attributes) = GetObjects(XDocument.Load(path), xpath);
            ControlFlow.Assert(elements.Count == 0 || attributes.Count == 0, "elements.Count == 0 || attributes.Count == 0");

            return elements.Count != 0 ? elements.Select(x => x.Value) : attributes.Select(x => x.Value);
        }

        [CanBeNull]
        public static string XmlPeekSingle(string path, string xpath)
        {
            var values = XmlPeek(path, xpath).ToList();
            ControlFlow.Assert(values.Count <= 1, "values.Count <= 1");
            return values.SingleOrDefault();
        }

        public static void XmlPoke(string path, string xpath, object value)
        {
            var document = XDocument.Load(path, LoadOptions.PreserveWhitespace);
            var (elements, attributes) = GetObjects(document, xpath);

            ControlFlow.Assert((elements.Count == 1 || attributes.Count == 1) && !(elements.Count == 0 && attributes.Count == 0),
                "(elements.Count == 1 || attributes.Count == 1) && !(elements.Count == 0 && attributes.Count == 0)");

            elements.SingleOrDefault()?.SetValue(value);
            attributes.SingleOrDefault()?.SetValue(value);

            var writerSettings = new XmlWriterSettings { OmitXmlDeclaration = document.Declaration == null };
            using (var xmlWriter = XmlWriter.Create(path, writerSettings))
            {
                document.Save(xmlWriter);
            }
        }

        private static (IReadOnlyCollection<XElement> Elements, IReadOnlyCollection<XAttribute> Attributes) GetObjects(
            XDocument document,
            string xpath)
        {
            var objects = ((IEnumerable) document.XPathEvaluate(xpath)).Cast<XObject>().ToList();
            return (objects.OfType<XElement>().ToList().AsReadOnly(),
                objects.OfType<XAttribute>().ToList().AsReadOnly());
        }
    }
}
