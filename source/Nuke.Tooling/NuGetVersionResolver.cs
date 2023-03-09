// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    public static class NuGetVersionResolver
    {
        private static readonly HttpClient s_client = new();

        [ItemCanBeNull]
        public static async Task<string> GetLatestVersion(string packageId, bool includePrereleases, bool includeUnlisted = false)
        {
            try
            {
                var url = includeUnlisted
                    ? $"https://api.nuget.org/v3/flatcontainer/{packageId.ToLowerInvariant()}/index.json"
                    : $"https://api-v2v3search-0.nuget.org/query?q=packageid:{packageId}&prerelease={includePrereleases}";
                var jsonString = await s_client.GetStringAsync(url);
                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonString);
                return includeUnlisted
                    ? jsonObject.First.NotNull().First.NotNull().Children()
                        .Select(x => x.Value<string>())
                        .Last(x => includePrereleases || !x.Contains("-"))
                    : jsonObject["data"].NotNull().Single()["version"].NotNull().ToString();
            }
            catch
            {
                return null;
            }
        }
    }
}
