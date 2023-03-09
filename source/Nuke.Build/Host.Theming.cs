// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Execution;

namespace Nuke.Common
{
    public partial class Host
    {
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
