// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using JetBrains.Annotations;

namespace Nuke.Common.OutputSinks
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    public class PlainAnsiOutputSink : OutputSink
    {
        protected internal override char CornerCharacter { get; } = '+';
        protected internal override char HorizontalEdgeCharacter { get; } = '=';
        protected internal override char SlimHorizontalEdgeCharacter { get; } = '-';
        protected internal override char VerticalEdgeCharacter { get; } = '|';
        protected internal override char PaddingCharacter { get; } = ' ';
        
        protected internal override void WriteLogo()
        {
            Logger.Normal("###    ## ##    ## ##   ## #######");
            Logger.Normal("####   ## ##    ## ##  ##  ##     ");
            Logger.Normal("## ##  ## ##    ## #####   #####  ");
            Logger.Normal("##  ## ## ##    ## ##  ##  ##     ");
            Logger.Normal("##   ####  ######  ##   ## #######");
        }

        protected override void WriteSuccessfulBuild()
        {
            WriteSuccess($"[NUKE] Build succeeded on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}.");
        }

        protected override void WriteFailedBuild()
        {
            WriteError($"[NUKE] Build failed on {DateTime.Now.ToString(CultureInfo.CurrentCulture)}.");
        }

        internal override void WriteNormal(string text) 
        {
            Console.WriteLine(text);
        }

        internal override void WriteSuccess(string text) 
        {
            Console.WriteLine($"[SUCCESS] {text}");
        }

        internal override void WriteTrace(string text)
        {
            Console.WriteLine($"[TRACE] {text}");
        }

        internal override void WriteInformation(string text)
        {
            Console.WriteLine($"[INFO] {text}");
        }

        protected override void WriteWarning(string text, string details = null)
        {
            Console.WriteLine($"[WARNING] {text}");
            WriteDetails(details);
        }

        protected override void WriteError(string text, string details = null)
        {
            Console.WriteLine($"[ERROR] {text}");
            WriteDetails(details);
        }
        
        private void WriteDetails(string details = null) 
        {
            if (!string.IsNullOrEmpty(details))
            {
                Console.WriteLine($"[DETAILS]\n{details}");
            }
        }
    }
}
