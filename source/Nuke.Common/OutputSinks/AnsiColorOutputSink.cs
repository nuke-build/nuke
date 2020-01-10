// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.OutputSinks
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class AnsiColorOutputSink : OutputSink
    {
        public string ResetSequence { get; } = "\u001b[0m";
        public string TraceSequence => $"\u001b[{TraceCode}m";
        public string InformationSequence => $"\u001b[{InformationCode}m";
        public string WarningSequence => $"\u001b[{WarningCode}m";
        public string ErrorSequence => $"\u001b[{ErrorCode}m";
        public string SuccessSequence => $"\u001b[{SuccessCode}m";

        protected virtual string TraceCode => "37";
        protected virtual string InformationCode => "96;1";
        protected virtual string WarningCode => "93;1";
        protected virtual string ErrorCode => "91;1";
        protected virtual string SuccessCode => "92;1";

        protected override string FormatBlockText(string text)
        {
            return FormatInformation(text);
        }

        public string FormatTrace(string text)
        {
            return $"{TraceSequence}{text}{ResetSequence}";
        }

        public string FormatInformation(string text)
        {
            return $"{InformationSequence}{text}{ResetSequence}";
        }

        public string FormatSuccess(string text)
        {
            return $"{SuccessSequence}{text}{ResetSequence}";
        }

        public string FormatWarning(string text)
        {
            return $"{WarningSequence}{text}{ResetSequence}";
        }

        public string FormatError(string text)
        {
            return $"{ErrorSequence}{text}{ResetSequence}";
        }

        internal override void WriteNormal(string text)
        {
            Console.WriteLine(text);
        }

        internal override void WriteTrace(string text)
        {
            Console.WriteLine(FormatTrace(text));
        }

        internal override void WriteInformation(string text)
        {
            Console.WriteLine(FormatInformation(text));
        }

        protected override void WriteWarning(string text, string details = null)
        {
            Console.WriteLine(FormatWarning(text));
            if (details != null)
                Console.WriteLine(FormatWarning(details));
        }

        protected override void WriteError(string text, string details = null)
        {
            Console.WriteLine(FormatError(text));
            if (details != null)
                Console.WriteLine(FormatError(details));
        }

        internal override void WriteSuccess(string text)
        {
            Console.WriteLine(FormatSuccess(text));
        }
    }
}
