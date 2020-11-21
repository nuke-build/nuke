﻿// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public class LatestMyGetVersionAttribute : ValueInjectionAttributeBase
    {
        private readonly string _feed;
        private readonly string _package;

        public LatestMyGetVersionAttribute(string feed, string package)
        {
            _feed = feed;
            _package = package;
        }

        public override object GetValue(MemberInfo member, object instance)
        {
            var rssFile = NukeBuild.TemporaryDirectory / $"{_feed}.xml";
            HttpTasks.HttpDownloadFile($"https://www.myget.org/RSS/{_feed}", rssFile);
            return XmlTasks.XmlPeek(rssFile, ".//title")
                // TODO: regex?
                .First(x => x.Contains($" {_package} "))
                .Split('(').Last()
                .Split(')').First()
                .TrimStart("version ");
        }
    }
}
