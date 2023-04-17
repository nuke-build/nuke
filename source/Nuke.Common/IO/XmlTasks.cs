﻿// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using JetBrains.Annotations;

namespace Nuke.Common.IO;

[PublicAPI]
public static class XmlTasks
{
    public static IEnumerable<string> XmlPeek(string path, string xpath, params (string prefix, string uri)[] namespaces)
    {
        return XmlPeek(XDocument.Load(path), xpath, namespaces);
    }

    public static IEnumerable<string> XmlPeekFromString(string content, string xpath, params (string prefix, string uri)[] namespaces)
    {
        return XmlPeek(XDocument.Parse(content), xpath, namespaces);
    }

    public static IEnumerable<XElement> XmlPeekElements(string path, string xpath, params (string prefix, string uri)[] namespaces)
    {
        return XmlPeekElements(XDocument.Load(path), xpath, namespaces);
    }

    public static IEnumerable<XElement> XmlPeekElementsFromString(string content, string xpath, params (string prefix, string uri)[] namespaces)
    {
        return XmlPeekElements(XDocument.Load(content), xpath, namespaces);
    }

    [CanBeNull]
    public static string XmlPeekSingle(string path, string xpath, params (string prefix, string uri)[] namespaces)
    {
        return XmlPeekSingle(() => XmlPeek(path, xpath, namespaces));
    }

    [CanBeNull]
    public static string XmlPeekSingleFromString(string content, string xpath, params (string prefix, string uri)[] namespaces)
    {
        return XmlPeekSingle(() => XmlPeekFromString(content, xpath, namespaces));
    }

    public static void XmlPoke(string path, string xpath, object value, params (string prefix, string uri)[] namespaces)
    {
        XmlPoke(path, xpath, value, Encoding.UTF8, namespaces);
    }

    public static void XmlPoke(string path, string xpath, object value, Encoding encoding, params (string prefix, string uri)[] namespaces)
    {
        var document = XDocument.Load(path, LoadOptions.PreserveWhitespace);
        var (elements, attributes) = GetObjects(document, xpath, namespaces);
        Assert.True((elements.Count == 1 || attributes.Count == 1) && !(elements.Count == 0 && attributes.Count == 0));

        elements.SingleOrDefault()?.SetValue(value);
        attributes.SingleOrDefault()?.SetValue(value);

        var writerSettings = new XmlWriterSettings { OmitXmlDeclaration = document.Declaration == null, Encoding = encoding };
        using var xmlWriter = XmlWriter.Create(path, writerSettings);
        document.Save(xmlWriter);
    }

    private static IEnumerable<string> XmlPeek(XDocument document, string xpath, (string prefix, string uri)[] namespaces)
    {
        var (elements, attributes) = GetObjects(document, xpath, namespaces);
        Assert.True(elements.Count == 0 || attributes.Count == 0);
        return elements.Count != 0 ? elements.Select(x => x.Value) : attributes.Select(x => x.Value);
    }

    private static IEnumerable<XElement> XmlPeekElements(XDocument document, string xpath, (string prefix, string uri)[] namespaces)
    {
        var (elements, attributes) = GetObjects(document, xpath, namespaces);
        Assert.True(elements.Count == 0 || attributes.Count == 0);
        return elements;
    }

    private static string XmlPeekSingle(Func<IEnumerable<string>> selector)
    {
        var values = selector.Invoke().ToList();
        Assert.True(values.Count <= 1);
        return values.SingleOrDefault();
    }

    private static (IReadOnlyCollection<XElement> Elements, IReadOnlyCollection<XAttribute> Attributes) GetObjects(
        XDocument document,
        string xpath,
        params (string prefix, string uri)[] namespaces)
    {
        XmlNamespaceManager xmlNamespaceManager = null;

        if (namespaces?.Length > 0)
        {
            var reader = document.CreateReader();
            if (reader.NameTable != null)
            {
                xmlNamespaceManager = new XmlNamespaceManager(reader.NameTable);
                foreach (var (prefix, uri) in namespaces)
                    xmlNamespaceManager.AddNamespace(prefix, uri);
            }
        }

        var objects = ((IEnumerable) document.XPathEvaluate(xpath, xmlNamespaceManager)).Cast<XObject>().ToList();
        return (objects.OfType<XElement>().ToList().AsReadOnly(),
            objects.OfType<XAttribute>().ToList().AsReadOnly());
    }
}
