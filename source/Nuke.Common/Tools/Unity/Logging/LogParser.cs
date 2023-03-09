// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nuke.Common.Tools.Unity.Logging
{
    internal class LogParser
    {
        private readonly Stack<MatchedBlock> _blockStack;
        private readonly Action<string, LogLevel> _logLineAction;
        private readonly Action<MatchedBlock> _logBlockStartAction;
        private readonly Action<MatchedBlock> _logBlockEndAction;

        private readonly IReadOnlyList<BlockMatcher> _blockMatchers =
            new[]
            {
                new BlockMatcher("Player statistics", "\\*\\*\\*Player size statistics\\*\\*\\*", "Unloading.*", endMatchType: MatchType.Exclusive),
                new BlockMatcher("Lightmap", "---- Lightmapping Start for (.*) ----", "---- Lightmapping End for (.*) ----"),
                new BlockMatcher("Compile", "-----Compiler Commandline Arguments:", "-----EndCompilerOutput---------------"),
                new BlockMatcher("Update", "Updating (.+) - GUID: .*", "\\s*done: hash - .+"),
                new BlockMatcher("Prepare Build", "---- PrepareBuild Start ----", "---- PrepareBuild End ----")
            };

        private readonly IReadOnlyList<LineMatcher> _lineMatchers =
            new[]
            {
                // Warnings
                new LineMatcher("Script attached to.*?is missing or no valid script is attached.", LogLevel.Warning),
                new LineMatcher(".*?warning CS\\d+.*?", LogLevel.Warning),
                new LineMatcher("There are inconsistent line endings in the.*?", LogLevel.Warning),
                new LineMatcher("This might lead to incorrect line numbers in stacktraces and compiler errors.*?", LogLevel.Warning),
                new LineMatcher("WARNING.*", LogLevel.Warning),

                // Errors
                new LineMatcher(".*?error CS\\d+.*?", LogLevel.Error),
                new LineMatcher("Compilation failed:.*", LogLevel.Error),
                new LineMatcher("Scripts have compiler errors\\..*", LogLevel.Error),
                new LineMatcher("An error occured", LogLevel.Warning)
            };

        public LogParser(
            Action<string, LogLevel> logLineAction,
            Action<MatchedBlock> logBlockStartAction,
            Action<MatchedBlock> logBlockEndAction)
        {
            _logLineAction = logLineAction ?? throw new ArgumentNullException(nameof(logLineAction));
            _logBlockStartAction = logBlockStartAction ?? throw new ArgumentNullException(nameof(logBlockStartAction));
            _logBlockEndAction = logBlockEndAction ?? throw new ArgumentNullException(nameof(logBlockEndAction));

            _blockStack = new Stack<MatchedBlock>();
        }

        public void Log(string message)
        {
            if (_blockStack.Count != 0)
            {
                var match = _blockStack.Peek().MatchesEnd(message);
                switch (match)
                {
                    case MatchType.Inclusive:
                        LogLine(message);
                        LogBlockEnd();
                        return;
                    case MatchType.Exclusive:
                        LogBlockEnd();
                        break;
                }
            }

            var block = _blockMatchers.Select(x => x.MatchesBeginning(message)).FirstOrDefault(x => x != null);

            if (block != null)
            {
                switch (block.MatchType)
                {
                    case MatchType.Inclusive:
                        LogBlockStart(block);
                        break;
                    case MatchType.Exclusive:
                        LogLine(message);
                        LogBlockStart(block);
                        return;
                }
            }

            LogLine(message);
        }

        private void LogBlockStart(MatchedBlock block)
        {
            _blockStack.Push(block);
            _logBlockStartAction(block);
        }

        private void LogLine(string message)
        {
            var line = _lineMatchers.FirstOrDefault(x => x.Matches(message));
            Log(message, line?.LogLevel ?? LogLevel.Normal);
        }

        private void LogBlockEnd()
        {
            var block = _blockStack.Pop();
            _logBlockEndAction(block);
        }

        private void Log(string message, LogLevel logLevel)
        {
            message = message.TrimEnd('\r', '\n');
            _logLineAction(message, logLevel);
        }
    }
}
