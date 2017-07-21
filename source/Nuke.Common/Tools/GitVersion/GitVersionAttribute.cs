// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Injection;

namespace Nuke.Common.Tools.GitVersion
{
    /// <inheritdoc/>
    [PublicAPI]
    public class GitVersionAttribute : InjectionAttributeBase
    {
        public override Type InjectionType => typeof(GitVersion);

        [CanBeNull]
        protected override object GetValue (FieldInfo field, NukeBuild buildInstance)
        {
            return EnvironmentInfo.IsWin && DefaultSettings.GitVersion.HasValidToolPath()
                ? GitVersionTasks.GitVersion(s => DefaultSettings.GitVersion)
                : null;
        }
    }
}
