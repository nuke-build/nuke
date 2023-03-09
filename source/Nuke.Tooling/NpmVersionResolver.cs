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
    public static class NpmVersionResolver
    {
        private static readonly HttpClient s_client = new();

        [ItemCanBeNull]
        public static async Task<string> GetLatestVersion(string packageId)
        {
            try
            {
                var url = $"https://registry.npmjs.org/{packageId}";
                var jsonString = await s_client.GetStringAsync(url);
                var jsonObject = JsonConvert.DeserializeObject<JObject>(jsonString);
                return (jsonObject["dist-tags"]?["latest"]).NotNull().Value<string>();
            }
            catch
            {
                return null;
            }
        }
    }
}
