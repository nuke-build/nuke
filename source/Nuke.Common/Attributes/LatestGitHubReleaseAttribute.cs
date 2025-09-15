// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using NuGet.Versioning;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.Tooling;

[PublicAPI]
public class LatestGitHubReleaseAttribute : ValueInjectionAttributeBase
{
    private readonly string _identifier;

    public LatestGitHubReleaseAttribute(string identifier)
    {
        _identifier = identifier;
    }

    public bool IncludePrerelease { get; set; }
    public bool UseTagName { get; set; }

    [RegexPattern]
    public string Pattern { get; set; } = @"v?(?<version>\d+\.\d+(?:\.\d+)?(?:\.\d+)?(?:-\w+)?)";

    public override object GetValue(MemberInfo member, object instance)
    {
        var repository = GitRepository.FromUrl($"https://github.com/{_identifier}");
        var releases = GitHubTasks.GitHubClient.Repository.Release
            .GetAll(repository.GetGitHubOwner(), repository.GetGitHubName()).GetAwaiter().GetResult();
        var versions = releases
            .Select(x => Regex.Match((!UseTagName ? x.Name : x.TagName).NotNullOrWhiteSpace(), Pattern))
            .Select(x => x.Groups["version"].Value)
            .Select(NuGetVersion.Parse)
            .OrderByDescending(x => x);

        if (member.GetMemberType() == typeof(NuGetVersion[]))
            return versions.ToArray();

        var latestVersion = versions.FirstOrDefault(x => !x.IsPrerelease || IncludePrerelease);
        return member.GetMemberType() == typeof(NuGetVersion)
            ? latestVersion
            : latestVersion?.ToString();
    }
}
