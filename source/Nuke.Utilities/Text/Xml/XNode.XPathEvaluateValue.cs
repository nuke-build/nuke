// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Nuke.Common.Utilities
{
    public static partial class XNodeExtensions
    {
        public static IEnumerable<string> XPathSelectElementValues(this XNode node, string query, params (string prefix, string uri)[] namespaces)
        {
            return node.XPathSelect<XElement>(query, namespaces).Select(x => x.Value);
        }

        public static IEnumerable<string> XPathSelectAttributeValues(this XNode node, string query, params (string prefix, string uri)[] namespaces)
        {
            return node.XPathSelect<XAttribute>(query, namespaces).Select(x => x.Value);
        }

        public static IEnumerable<XElement> XPathSelectElements(this XNode node, string query, params (string prefix, string uri)[] namespaces)
        {
            return node.XPathSelect<XElement>(query, namespaces);
        }

        public static IEnumerable<XAttribute> XPathSelectAttributes(this XNode node, string query, params (string prefix, string uri)[] namespaces)
        {
            return node.XPathSelect<XAttribute>(query, namespaces);
        }

        private static IEnumerable<T> XPathSelect<T>(this XNode node, string query, params (string prefix, string uri)[] namespaces)
        {
            XmlNamespaceManager xmlNamespaceManager = null;

            if (namespaces?.Length > 0)
            {
                var reader = node.CreateReader();
                if (reader.NameTable != null)
                {
                    xmlNamespaceManager = new XmlNamespaceManager(reader.NameTable);
                    foreach (var (prefix, uri) in namespaces)
                        xmlNamespaceManager.AddNamespace(prefix, uri);
                }
            }

            return ((IEnumerable)node.XPathEvaluate(query, xmlNamespaceManager)).Cast<T>();
        }
    }
}
