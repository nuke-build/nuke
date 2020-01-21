using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Nuke.Common.Utilities
{
    public class WindowsCommandLineVariablesUtility
    {
        private const string DriveCurrentDirectoryRegexString = @".*[=]+[A-Z]*[:]+[\s]*=.+";
        private const string LastExitCodeRegexString = @".*[=]+ExitCode[:]*[\s]*=\d+";

        private readonly Regex _driveCurrentDirectoryRegex = new Regex(DriveCurrentDirectoryRegexString);
        private readonly Regex _lastExitCodeRegex = new Regex(LastExitCodeRegexString);

        [JetBrains.Annotations.Pure]
        public bool TeamCity_IsWinCmdInternalVariable(string input)
        {
            return _driveCurrentDirectoryRegex.IsMatch(input) || _lastExitCodeRegex.IsMatch(input);
        }
    }
}
