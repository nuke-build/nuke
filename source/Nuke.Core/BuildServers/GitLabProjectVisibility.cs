using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.BuildServers
{
    [PublicAPI]
    public enum GitLabProjectVisibility
    {
        Private,
        Internal,
        Public
    }
}
