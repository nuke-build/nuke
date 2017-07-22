// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Injection;

namespace Nuke.Common.Tools.GitVersion
{
    /// <inheritdoc/>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class GitVersionAttribute : StaticInjectionAttributeBase
    {
        private static Lazy<GitVersion> s_value = new Lazy<GitVersion>(() =>
            EnvironmentInfo.IsWin && DefaultSettings.GitVersion.HasValidToolPath()
                ? GitVersionTasks.GitVersion(s => DefaultSettings.GitVersion)
                : null);

        public override Type InjectionType => typeof(GitVersion);

        [CanBeNull]
        public override object GetStaticValue ()
        {
            return s_value.Value;
        }
    }
}
