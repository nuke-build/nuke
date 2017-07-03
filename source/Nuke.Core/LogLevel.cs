// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core
{
    [TypeConverter(typeof(LogLevelTypeConverter))]
    public enum LogLevel
    {
        Trace,
        Information,
        Warning,
        Failure
    }

    public class LogLevelTypeConverter : TypeConverter
    {
        private readonly Dictionary<string, LogLevel> _logLevelDictionary
                = new Dictionary<string, LogLevel>(StringComparer.OrdinalIgnoreCase)
                  {
                      { "verbose", LogLevel.Trace },
                      { "normal", LogLevel.Information },
                      { "minimal", LogLevel.Warning },
                      { "quiet", LogLevel.Failure }
                  };

        [CanBeNull]
        public override object ConvertFrom ([NotNull] ITypeDescriptorContext context, [NotNull] CultureInfo culture, [CanBeNull] object value)
        {
            var verbosity = value as string;
            if (verbosity == null)
                return null;

            return _logLevelDictionary.TryGetValue(verbosity, out var logLevel) ? (object) logLevel : null;
        }
    }
}
