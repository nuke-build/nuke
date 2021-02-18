// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.ValueInjection;

namespace Nuke.Components
{
    [PublicAPI]
    [ParameterPrefix(Twitter)]
    public interface IHazTwitterCredentials : INukeBuild
    {
        public const string Twitter = nameof(Twitter);

        [Parameter] [Secret] string ConsumerKey => ValueInjectionUtility.TryGetValue(() => ConsumerKey);
        [Parameter] [Secret] string ConsumerSecret => ValueInjectionUtility.TryGetValue(() => ConsumerSecret);
        [Parameter] [Secret] string AccessToken => ValueInjectionUtility.TryGetValue(() => AccessToken);
        [Parameter] [Secret] string AccessTokenSecret => ValueInjectionUtility.TryGetValue(() => AccessTokenSecret);

    }
}
