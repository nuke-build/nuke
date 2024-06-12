// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

#if NET6_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common.Tooling;

[PublicAPI]
[InterpolatedStringHandler]
public ref struct ArgumentStringHandler
{
    private DefaultInterpolatedStringHandler _builder;
    private readonly List<string> _secretValues;

    public ArgumentStringHandler(
        int literalLength,
        int formattedCount,
        out bool handlerIsValid)
    {
        _builder = new(literalLength, formattedCount);
        _secretValues = new List<string>();
        handlerIsValid = true;
    }

    public static implicit operator ArgumentStringHandler(string value)
    {
        return $"{value.NotNull()}";
    }

    public void AppendLiteral(string value)
    {
        _builder.AppendLiteral(value);
    }

    public void AppendFormatted(object obj, int alignment = 0, string format = null)
    {
        if (obj is string value)
        {
            if (format == "r")
                _secretValues.Add(value);
            else if (!(value.IsDoubleQuoted() || value.IsSingleQuoted() || format == "nq"))
                (value, format) = (value.DoubleQuoteIfNeeded(), null);
            AppendFormatted(value, alignment, format);
        }
        else if (obj is IAbsolutePathHolder holder)
            AppendFormatted(holder, alignment, format);
        else
            AppendFormatted(obj.ToString(), alignment, format);
    }

    private void AppendFormatted(string value, int alignment, string format)
    {
        _builder.AppendFormatted(value, alignment, format);
    }

    private void AppendFormatted(IAbsolutePathHolder holder, int alignment, string format)
    {
        _builder.AppendFormatted(holder.Path, alignment, format ?? AbsolutePath.DoubleQuoteIfNeeded);
    }

    public void AppendFormatted(IEnumerable<IAbsolutePathHolder> paths, int alignment = 0, string format = null)
    {
        var list = paths.ToList();
        for (var i = 0; i < list.Count; i++)
        {
            _builder.AppendFormatted(list[i], alignment, format ?? AbsolutePath.DoubleQuoteIfNeeded);
            if (i + 1 < list.Count)
                _builder.AppendLiteral(" ");
        }
    }

    public string ToStringAndClear()
    {
        var value = _builder.ToStringAndClear();
        return value.IndexOf(value: '"', startIndex: 1) == value.Length - 1
            ? value.TrimMatchingDoubleQuotes()
            : value;
    }

    public Func<string, string> GetFilter()
    {
        var secretValues = _secretValues;
        return x => secretValues.Aggregate(x, (arguments, value) => arguments.Replace(value, Arguments.Redacted));
    }
}
#endif
