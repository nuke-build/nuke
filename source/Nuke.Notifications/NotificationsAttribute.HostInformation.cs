// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Nuke.Common;
using Nuke.Common.CI.AppVeyor;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.CI.GitLab;
using Nuke.Common.CI.SpaceAutomation;
using Nuke.Common.CI.TeamCity;
using Nuke.Common.Utilities;

namespace Nuke.Notifications
{
    public partial class NotificationsAttribute
    {
        bool ShouldSerialize(MemberInfo member)
        {
            return NukeBuild.Host switch
            {
                AppVeyor =>
                    member.Name.EqualsAnyOrdinalIgnoreCase(
                        nameof(AppVeyor.Url),
                        nameof(AppVeyor.AccountName),
                        nameof(AppVeyor.ProjectSlug),
                        nameof(AppVeyor.BuildId),
                        nameof(AppVeyor.BuildVersion),
                        nameof(AppVeyor.JobName),
                        nameof(AppVeyor.JobId),
                        nameof(AppVeyor.RepositoryBranch),
                        nameof(AppVeyor.ProjectName)),
                TeamCity =>
                    member.Name.EqualsAnyOrdinalIgnoreCase(
                        nameof(TeamCity.ServerUrl),
                        nameof(TeamCity.ProjectName),
                        nameof(TeamCity.ProjectId),
                        nameof(TeamCity.BuildTypeId),
                        nameof(TeamCity.BuildId),
                        nameof(TeamCity.BuildNumber),
                        nameof(TeamCity.BuildConfiguration),
                        nameof(TeamCity.BranchName)) ||
                    EnableAuthorizedActions && member.Name.EqualsAnyOrdinalIgnoreCase(
                        nameof(TeamCity.AuthUserId),
                        nameof(TeamCity.AuthPassword)),
                AzurePipelines =>
                    member.Name.EqualsAnyOrdinalIgnoreCase(
                        nameof(AzurePipelines.TeamFoundationCollectionUri),
                        nameof(AzurePipelines.TeamProject),
                        nameof(AzurePipelines.DefinitionName),
                        nameof(AzurePipelines.DefinitionId),
                        nameof(AzurePipelines.BuildId),
                        nameof(AzurePipelines.BuildNumber),
                        nameof(AzurePipelines.StageName),
                        nameof(AzurePipelines.JobId),
                        nameof(AzurePipelines.TaskInstanceId)) ||
                    EnableAuthorizedActions && member.Name.EqualsAnyOrdinalIgnoreCase(
                        nameof(AzurePipelines.AccessToken)),
                GitHubActions =>
                    member.Name.EqualsAnyOrdinalIgnoreCase(
                        nameof(GitHubActions.ServerUrl),
                        nameof(GitHubActions.Repository),
                        nameof(GitHubActions.Workflow),
                        nameof(GitHubActions.RunId),
                        nameof(GitHubActions.RunNumber),
                        nameof(GitHubActions.JobId),
                        nameof(GitHubActions.Job),
                        nameof(GitHubActions.Ref)) ||
                    EnableAuthorizedActions && member.Name.EqualsAnyOrdinalIgnoreCase(
                        nameof(GitHubActions.Token)),
                GitLab =>
                    member.Name.EqualsAnyOrdinalIgnoreCase(
                        nameof(GitLab.ProjectUrl),
                        nameof(GitLab.PipelineId),
                        nameof(GitLab.ProjectName),
                        nameof(GitLab.JobId)),
                SpaceAutomation =>
                    member.Name.EqualsAnyOrdinalIgnoreCase(
                        nameof(SpaceAutomation.ApiUrl),
                        nameof(SpaceAutomation.ProjectKey),
                        nameof(SpaceAutomation.ExecutionNumber),
                        nameof(SpaceAutomation.RepositoryName),
                        nameof(SpaceAutomation.GitBranch)) ||
                    EnableAuthorizedActions && member.Name.EqualsAnyOrdinalIgnoreCase(
                        nameof(SpaceAutomation.ClientId),
                        nameof(SpaceAutomation.ClientSecret)),
                _ =>
                    throw new NotSupportedException(NukeBuild.Host.ToString())
            };
        }

        internal class HostContractResolver : DefaultContractResolver
        {
            private readonly Func<MemberInfo, bool> _shouldSerialize;

            public HostContractResolver(Func<MemberInfo, bool> shouldSerialize)
            {
                _shouldSerialize = shouldSerialize;
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                property.ShouldSerialize = _ => _shouldSerialize.Invoke(member);
                return property;
            }
        }
    }
}
