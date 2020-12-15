// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tooling
{
    public delegate IReadOnlyCollection<Output> Tool(
        string arguments = null,
        string workingDirectory = null,
        IReadOnlyDictionary<string, string> environmentVariables = null,
        int? timeout = null,
        bool? logOutput = null,
        bool? logInvocation = null,
        bool? logTimestamp = null,
        string logFile = null,
        Action<OutputType, string> customLogger = null,
        Func<string, string> outputFilter = null);

    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public sealed class CommandFormatAttribute : Attribute
    {
        public CommandFormatAttribute(string format)
        {
            Format = format;
        }

        public string Format { get; }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public sealed class ArgumentFormatAttribute : Attribute
    {
        public ArgumentFormatAttribute(string format)
        {
            Format = format;
        }

        public string Format { get; }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public sealed class ItemFormatAttribute : Attribute
    {
        public ItemFormatAttribute(string format)
        {
            Format = format;
        }

        public string Format { get; }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public sealed class SeparatorAttribute : Attribute
    {
        public SeparatorAttribute(string separator)
        {
            Separator = separator;
        }

        public string Separator { get; }
    }

    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    public sealed class DelegateAttribute : Attribute
    {
        public DelegateAttribute(string delegate_, string separator)
        {
            Delegate = delegate_;
            Separator = separator;
        }

        public string Delegate { get; }
        public string Separator { get; }
    }
}
