// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Injection;
using Nuke.Core.Tooling;

namespace Nuke.Common.Tools.GitVersion
{
    /// <inheritdoc/>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class GitVersionAttribute : StaticInjectionAttributeBase
    {
        public static GitVersion Value { get; private set; }

        public override Type InjectionType => typeof(GitVersion);

        [CanBeNull]
        public override object GetStaticValue ()
        {
            // TODO: https://github.com/GitTools/GitVersion/issues/1097
            if (EnvironmentInfo.IsUnix)
            {
                Logger.Warn($"{nameof(GitVersion)} does not work in UNIX environments.");
                return null;
            }

            return Value = Value ??
                           GitVersionTasks.GitVersion(
                               s => GitVersionTasks.DefaultGitVersion,
                               new ProcessSettings().EnableRedirectOutput());
        }
    }
}
