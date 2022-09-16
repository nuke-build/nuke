// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.Common.IO
{
    [PublicAPI]
    [Serializable]
    [TypeConverter(typeof(TypeConverter))]
    [DebuggerDisplay("{" + nameof(_path) + "}")]
    public class AbsolutePath : IFormattable
    {
        public const string DoubleQuote = "d";
        public const string DoubleQuoteIfNeeded = "dn";
        public const string SingleQuote = "s";
        public const string SingleQuoteIfNeeded = "sn";
        public const string NoQuotes = "nq";

        public class TypeConverter : System.ComponentModel.TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
            }

            public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
            {
                if (value is string stringValue)
                {
                    return HasPathRoot(stringValue)
                        ? (AbsolutePath) stringValue
                        : EnvironmentInfo.WorkingDirectory / stringValue;
                }

                if (value is null)
                    return null;

                return base.ConvertFrom(context, culture, value);
            }
        }

        public static AbsolutePath Create(string path)
        {
            return new AbsolutePath(path);
        }

        private readonly string _path;

        private AbsolutePath(string path)
        {
            _path = NormalizePath(path);
        }

        [ContractAnnotation("null => null")]
        public static implicit operator AbsolutePath([CanBeNull] string path)
        {
            if (path is null)
                return null;

            Assert.True(HasPathRoot(path), $"Path '{path}' must be rooted");
            return new AbsolutePath(path);
        }

        public static implicit operator string([CanBeNull] AbsolutePath path)
        {
            return path?.ToString();
        }

        public string Name => Path.GetFileName(_path);
        public string NameWithoutExtension => Path.GetFileNameWithoutExtension(_path);

        [CanBeNull]
        public AbsolutePath Parent =>
            !IsWinRoot(_path.TrimEnd(WinSeparator)) && !IsUncRoot(_path) && !IsUnixRoot(_path)
                ? this / ".."
                : null;

        public static AbsolutePath operator /(AbsolutePath left, [CanBeNull] string right)
        {
            return new AbsolutePath(Combine(left.NotNull(), right));
        }

        public static AbsolutePath operator +(AbsolutePath left, [CanBeNull] string right)
        {
            return new AbsolutePath(left.ToString() + right);
        }

        public static bool operator ==(AbsolutePath a, AbsolutePath b)
        {
            return EqualityComparer<AbsolutePath>.Default.Equals(a, b);
        }

        public static bool operator !=(AbsolutePath a, AbsolutePath b)
        {
            return !EqualityComparer<AbsolutePath>.Default.Equals(a, b);
        }

        protected bool Equals(AbsolutePath other)
        {
            var stringComparison = HasWinRoot(_path) ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            return string.Equals(_path, other._path, stringComparison);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(objA: null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((AbsolutePath) obj);
        }

        public override int GetHashCode()
        {
            return _path?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return ((IFormattable)this).ToString(format: null, formatProvider: null);
        }

        public string ToString(string format)
        {
            return ((IFormattable)this).ToString(format, formatProvider: null);
        }

        string IFormattable.ToString(string format, IFormatProvider formatProvider)
        {
            return format switch
            {
                DoubleQuote => _path.DoubleQuote(),
                DoubleQuoteIfNeeded => _path.DoubleQuoteIfNeeded(),
                SingleQuote => _path.SingleQuote(),
                SingleQuoteIfNeeded => _path.SingleQuoteIfNeeded(),
                null or NoQuotes => _path,
                _ => throw new ArgumentException($"Format '{format}' is not recognized")
            };
        }
    }
}
