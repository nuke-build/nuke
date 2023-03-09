// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Text.RegularExpressions;
using Nuke.Common.Tooling;
using Serilog;

namespace Nuke.Common.Tools.DocFX
{
    partial class DocFXTasks
    {
        private const string TimestampPattern = @"^\[\d\d\-\d\d\-\d\d\s\d\d\:\d\d\:\d\d\.\d\d\d\]";

        private static readonly Regex MetadataNoFilesFoundRegex = new($@"{TimestampPattern}Info\:\[ExtractMetadata\]No\ files\ are\ found", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex ErrorRegex = new($@"{TimestampPattern}Error\:", RegexOptions.Singleline | RegexOptions.Compiled);
        private static readonly Regex WarningRegex = new($@"{TimestampPattern}Warning\:", RegexOptions.Singleline | RegexOptions.Compiled);

        internal static void CustomLogger(OutputType type, string output)
        {
            if (type == OutputType.Err ||
                ErrorRegex.IsMatch(output))
            {
                Log.Error(output);
                return;
            }

            if (WarningRegex.IsMatch(output) ||
                MetadataNoFilesFoundRegex.IsMatch(output))
            {
                Log.Warning(output);
                return;
            }

            Log.Debug(output);
        }
    }
}
