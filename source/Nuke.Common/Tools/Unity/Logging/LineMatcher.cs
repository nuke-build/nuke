// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Nuke.Common.Tools.Unity.Logging
{
    internal class LineMatcher
    {
        public string RegexPattern { get; }
        public LogLevel LogLevel { get; }

        public LineMatcher(string regexPattern, LogLevel logLevel)
        {
            RegexPattern = regexPattern;
            LogLevel = logLevel;
        }

        public bool Matches(string message)
        {
            return Regex.IsMatch(message, RegexPattern);
        }
    }
}
