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

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    [InterpolatedStringHandler]
    public ref struct ArgumentStringHandler
    {
        private DefaultInterpolatedStringHandler _builder;

        public ArgumentStringHandler(
            int literalLength,
            int formattedCount,
            out bool handlerIsValid)
        {
            _builder = new(literalLength, formattedCount);
            SecretValues = new List<string>();
            handlerIsValid = true;
        }

        public List<string> SecretValues { get; }

        public void AppendLiteral(string value)
        {
            _builder.AppendLiteral(value);
        }

        public void AppendFormatted(object obj, int alignment = 0, string format = null)
        {
            AppendFormatted(obj.ToString(), alignment, format);
        }

        public void AppendFormatted(string value, int alignment = 0, string format = null)
        {
            if (format == "r")
                SecretValues.Add(value);
            else if (!(value.IsDoubleQuoted() || value.IsSingleQuoted() || format == "nq"))
                (value, format) = (value.DoubleQuoteIfNeeded(), null);

            _builder.AppendFormatted(value, alignment, format);
        }

        public void AppendFormatted(AbsolutePath path, int alignment = 0, string format = null)
        {
            _builder.AppendFormatted(path, alignment, format ?? "dn");
        }

        public string ToStringAndClear()
        {
            return _builder.ToStringAndClear();
        }
    }
}
#endif
