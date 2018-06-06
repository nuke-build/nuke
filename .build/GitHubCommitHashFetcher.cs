// Copyright Sebastian Karasek, Matthias Koch 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nswag/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Octokit;

internal static class GitHubCommitHashFetcher
{
    public static string FetchShortHashForReference (string reference)
    {
        return FetchShortHashForReferenceAsync(reference).GetAwaiter().GetResult();
    }

    private async static Task<string> FetchShortHashForReferenceAsync (string reference)
    {
        var client = new GitHubClient(new ProductHeaderValue("Nuke.NSwag"));
        var gitReference = await client.Git.Reference.Get("RSuter", "NSwag", reference);
        return gitReference.Object.Sha.Substring(startIndex: 0, length: 10);
    }
}

