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
    internal class AnsiColorOutputSink : ConsoleOutputSink
    {
        public string ResetSequence { get; } = "\u001b[0m";
        public string TraceSequence { get; }
        public string InformationSequence { get; }
        public string WarningSequence { get; }
        public string ErrorSequence { get; }
        public string SuccessSequence { get; }

        public AnsiColorOutputSink(
            string traceCode = "37",
            string informationCode = "96;1",
            string warningCode = "93;1",
            string errorCode = "91;1",
            string successCode = "92;1")
        {
            TraceSequence = $"\u001b[{traceCode}m";
            InformationSequence = $"\u001b[{informationCode}m";
            WarningSequence = $"\u001b[{warningCode}m";
            ErrorSequence = $"\u001b[{errorCode}m";
            SuccessSequence = $"\u001b[{successCode}m";
        }

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

        public override void WriteNormal(string text)
        {
            Console.WriteLine(text);
        }

        public override void WriteTrace(string text)
        {
            Console.WriteLine(FormatTrace(text));
        }

        public override void WriteInformation(string text)
        {
            Console.WriteLine(FormatInformation(text));
        }

        public override void WriteWarning(string text, string details = null)
        {
            Console.WriteLine(FormatWarning(text));
            if (details != null)
                Console.WriteLine(FormatWarning(details));
        }

        public override void WriteError(string text, string details = null)
        {
            Console.WriteLine(FormatError(text));
            if (details != null)
                Console.WriteLine(FormatError(details));
        }

        public override void WriteSuccess(string text)
        {
            Console.WriteLine(FormatSuccess(text));
        }
    }
}
