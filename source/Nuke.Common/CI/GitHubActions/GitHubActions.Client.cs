// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Net;

namespace Nuke.Common.CI.GitHubActions
{
    public partial class GitHubActions
    {
        public async Task CreateComment(int issue, string text)
        {
            await _httpClient.Value
                .CreateRequest(HttpMethod.Post, $"repos/{Repository}/issues/{issue}/comments")
                .WithJsonContent(new { body = text })
                .GetResponseAsync();
        }

        private JObject GetJobDetails(long runId)
        {
            var response = _httpClient.Value
                .CreateRequest(HttpMethod.Get, $"repos/{Repository}/actions/runs/{runId}/jobs")
                .GetResponse()
                .AssertSuccessfulStatusCode();

            return response.GetBodyAsJson().GetAwaiter().GetResult()
                .GetChildren("jobs")
                .Single(x => x.GetPropertyStringValue("name") == Job);
        }

        private long GetJobId()
        {
            return GetJobDetails(RunId).GetPropertyValue<long>("id");
        }
    }
}
