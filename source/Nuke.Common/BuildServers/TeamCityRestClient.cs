// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Refit;

namespace Nuke.Core.BuildServers
{
    [PublicAPI]
    [Headers("Accept: application/json")]
    public interface ITeamCityRestClient
    {
        [Get("/buildQueue")]
        Task<BuildQueue> GetBuildQueue();

        [Headers("Accept: text/plain")]
        [Get("/builds/{build}/pin")]
        Task<bool> IsPinned(Build build);
    }

    [PublicAPI]
    public class TeamCityRestObject
    {
        public string Href { get; }
    }

    public class BuildQueue : TeamCityRestObject
    {
        [JsonProperty("build")]
        public Build[] Builds { get; private set; }
    }

    public class Build : TeamCityRestObject
    {
        public int Id { get; set; }
        public string BuildTypeId { get; set; }

        [JsonProperty("defaultBranch")]
        public bool IsDefaultBranch { get; set; }

        public string BranchName { get; set; }
        public string State { get; set; }

        public string WebUrl { get; set; }

        public override string ToString()
        {
            return $"buildId:{Id.NotNull("Id != null")}";
        }
    }
}
