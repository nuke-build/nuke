// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.Common;
using Nuke.Common.Utilities.Collections;
using Octokit;
using Octokit.Internal;

// ReSharper disable ArrangeMethodOrOperatorBody
// ReSharper disable ArrangeTypeMemberModifiers
// ReSharper disable ArrangeTypeModifiers

internal static class GitHubTasks
{
    static readonly ProductHeaderValue s_productHeader = new ProductHeaderValue("Nuke.NSwag");

    public static Commit GetCommit(string owner, string name, string commitSha, string token = null)
    {
        return CreateClient(token).Git.Commit.Get(owner, name, commitSha)
            .GetAwaiter()
            .GetResult();
    }

    public static IReadOnlyList<Release> GetLatestReleases(string owner, string name, int numberOfReleases, string token = null)
    {
        Logger.Info("Fetching latest releases...");
        return CreateClient(token).Repository.Release.GetAll(owner, name, new ApiOptions { PageSize = numberOfReleases, PageCount = 1, StartPage = 1})
            .GetAwaiter()
            .GetResult();
    }

    public static void CreatePullRequestIfNeeded(string repositoryIdentifier, string branch, string head, string body, string token)
    {
        var (owner, name) = repositoryIdentifier.Split(separator: '/');
        try
        {
            var result = CreateClient(token).PullRequest.Create(owner, name, new NewPullRequest(head, branch, "master") { Body = body })
                .GetAwaiter()
                .GetResult();
            Logger.Info($"Pull request '{result.Head}' with id '{result.Id}' was succesfully created.");
        }
        catch (ApiException ex)
        {
            if ((int) ex.StatusCode != 422) throw;
            Logger.Info($"Pull request from branch '{branch}' already exists.");
        }
    }

    private static GitHubClient CreateClient(string token = null)
    {
        return string.IsNullOrEmpty(token)
            ? new GitHubClient(s_productHeader)
            : new GitHubClient(s_productHeader, new InMemoryCredentialStore(new Credentials(token)));
    }
}