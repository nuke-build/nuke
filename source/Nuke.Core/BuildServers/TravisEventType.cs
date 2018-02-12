using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Nuke.Core.BuildServers
{
    [PublicAPI]
    [SuppressMessage("ReSharper", "InconsistentNaming")]

    public enum TravisEventType

    {
        push,
        pull_request,
        api,
        cron
    }
}
