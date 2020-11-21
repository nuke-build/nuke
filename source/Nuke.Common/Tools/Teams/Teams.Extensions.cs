﻿// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Nuke.Common.Tools.Teams
{
    public partial class TeamsMessage
    {
        [JsonProperty("@type")]
        internal string Type => "MessageCard";
        [JsonProperty("@context")]
        internal string Context => "http://schema.org/extensions";
    }
}
