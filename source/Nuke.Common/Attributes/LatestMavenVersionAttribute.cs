// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using NuGet.Versioning;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public class LatestMavenVersionAttribute : ValueInjectionAttributeBase
    {
        private readonly string _repository;
        private readonly string _groupId;
        private readonly string _artifactId;

        public LatestMavenVersionAttribute(string repository, string groupId, string artifactId = null)
        {
            _repository = repository;
            _groupId = groupId;
            _artifactId = artifactId;
        }

        public bool IncludePrerelease { get; set; }

        public override object GetValue(MemberInfo member, object instance)
        {
            var endpoint = _repository.TrimStart("https").TrimStart("http").TrimStart("://").TrimEnd("/");
            var uri = $"https://{endpoint}/{_groupId.Replace(".", "/")}/{_artifactId ?? _groupId}/maven-metadata.xml";
            var content = HttpTasks.HttpDownloadString(uri);
            var versions = XmlTasks.XmlPeekFromString(content, ".//version").ToList();
            var version = versions
                .Select(NuGetVersion.Parse)
                .OrderByDescending(x => x)
                .FirstOrDefault(x => !x.IsPrerelease || IncludePrerelease);
            return member.GetMemberType() == typeof(string)
                ? version?.ToNormalizedString()
                : version;
        }
    }
}
