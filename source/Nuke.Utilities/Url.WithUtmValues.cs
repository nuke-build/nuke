// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Utilities;

[PublicAPI]
[DebuggerNonUserCode]
[DebuggerStepThrough]
public static class UrlExtensions
{
    public static Uri WithUtmValues(this Uri uri, string medium, string source, string campaign = null, string content = null)
    {
        var lastSegment = uri.Segments.Last().Trim('/').Apply(x => x.IsNullOrWhiteSpace() ? null : x);

        var dictionary = new Dictionary<string, string>
                         {
                             ["utm_medium"] = medium.NotNullOrWhiteSpace(),
                             ["utm_source"] = source.NotNullOrWhiteSpace(),
                             ["utm_campaign"] = campaign ?? lastSegment,
                             ["utm_content"] = content ?? (campaign != null ? lastSegment : null),
                         };

        var query = dictionary.Where(x => x.Value != null).Select(x => $"{x.Key}={x.Value}").Join("&");
        return new Uri(uri.AbsoluteUri + "?" + query);
    }
}
