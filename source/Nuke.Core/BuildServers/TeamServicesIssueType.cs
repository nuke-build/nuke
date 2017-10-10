// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using JetBrains.Annotations;

namespace Nuke.Core.BuildServers
{
    [PublicAPI]
    public enum TeamServicesIssueType
    {
        Warning,
        Error
    }
}
