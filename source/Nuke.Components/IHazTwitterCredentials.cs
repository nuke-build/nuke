// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;

namespace Nuke.Components
{
    [PublicAPI]
    [ParameterPrefix(Twitter)]
    public interface IHazTwitterCredentials : INukeBuild
    {
        public const string Twitter = nameof(Twitter);

        [Parameter] [Secret] string ConsumerKey => TryGetValue(() => ConsumerKey);
        [Parameter] [Secret] string ConsumerSecret => TryGetValue(() => ConsumerSecret);
        [Parameter] [Secret] string AccessToken => TryGetValue(() => AccessToken);
        [Parameter] [Secret] string AccessTokenSecret => TryGetValue(() => AccessTokenSecret);
    }
}
