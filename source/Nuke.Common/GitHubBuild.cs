// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using JetBrains.Annotations;
using Nuke.Common.Git;
using Nuke.Common.Tools.GitVersion;
using Nuke.Core;

namespace Nuke.Common
{
    /// <summary>
    /// In addition to <see cref="Build"/>, automatically loads <see cref="GitVersion"/> and <see cref="GitRepository"/>.
    /// </summary>
    [PublicAPI]
    public abstract class GitHubBuild : Build
    {
    }
}
