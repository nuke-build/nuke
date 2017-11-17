// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Core;
using Nuke.Core.Injection;

namespace Nuke.Common.Git
{
    /// <inheritdoc/>
    [PublicAPI]
    [UsedImplicitly(ImplicitUseKindFlags.Default)]
    public class GitRepositoryAttribute : StaticInjectionAttributeBase
    {
        public static GitRepository Value { get; private set; }

        public override Type InjectionType => typeof(GitRepository);

        [CanBeNull]
        public override object GetStaticValue ()
        {
            return Value = Value
                           ?? ControlFlow.SuppressErrors(() =>
                               GitRepository.TryParse(NukeBuild.Instance.RootDirectory));
        }
    }
}
