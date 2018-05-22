using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Octokit;

internal static class GitHubCommitHashFetcher
    {
        public static string FetchHashForReference (string reference)
        {
           
            return FetchHashForReferenceAsync(reference).GetAwaiter().GetResult();
        }

        private  async static Task<string> FetchHashForReferenceAsync (string reference)
        {
            var client = new GitHubClient(new ProductHeaderValue("Nuke.NSwag"));
            var gitReference = await client.Git.Reference.Get("RSuter", "NSwag", reference);
            return gitReference.Object.Sha;
            
        }
}

