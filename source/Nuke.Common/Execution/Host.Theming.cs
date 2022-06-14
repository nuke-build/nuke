// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Execution;
using Nuke.Common.Execution.Theming;
using Nuke.Common.Utilities;

namespace Nuke.Common
{
    public partial class Host
    {
        private const string SevereMessagesOutputTemplate = "[{Level:u3}] {ExecutingTarget}: {Message:l}{NewLine}";

        internal static string DefaultOutputTemplate => "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:l}{NewLine}{Exception}";

        internal static void Success(string text = null)
        {
            (Instance?.Theme ?? Logging.DefaultTheme).WriteSuccess(text);
        }

        internal static void Verbose(string text = null)
        {
            (Instance?.Theme ?? Logging.DefaultTheme).WriteVerbose(text);
        }

        internal static void Debug(string text = null)
        {
            (Instance?.Theme ?? Logging.DefaultTheme).WriteDebug(text);
        }

        internal static void Information(string text = null)
        {
            (Instance?.Theme ?? Logging.DefaultTheme).WriteInformation(text);
        }

        internal static void Warning(string text = null)
        {
            (Instance?.Theme ?? Logging.DefaultTheme).WriteWarning(text);
        }

        internal static void Error(string text = null)
        {
            (Instance?.Theme ?? Logging.DefaultTheme).WriteError(text);
        }
    }
}
