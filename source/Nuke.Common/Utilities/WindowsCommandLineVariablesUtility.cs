using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Nuke.Common.Utilities
{
    public class WindowsCommandLineVariablesUtility
    {
        /*
            Undocumented Dynamic variables (read only)

            %__APPDIR__%   The directory path to the current application .exe, terminated with a trailing backslash. (Global) - discuss
            %__CD__%   The current directory, terminated with a trailing backslash. (Global)
            %=C:%   The current directory of the C: drive. ( See Raymond Chen's explanation of this.)
            %=D:%   The current directory of the D: drive if drive D: has been accessed in the current CMD session.
            %DPATH%   Related to the (deprecated) DPATH command.
            %=ExitCode%   The most recent exit code returned by an external command, such as CMD /C EXIT n, converted to hex.
            %=ExitCodeAscii%   The most recent exit code returned by an external command, as ASCII. (Values 0-32 do not display because those map to ASCII control codes.)
            %FIRMWARE_TYPE% The boot type of the system: Legacy ,UEFI,Not implemented ,Unknown Windows 8/2012.
            %KEYS%   Related to the (deprecated) KEYS command.
         */

        private const string DriveCurrentDirectoryRegexString = @".*[=]+[A-Z]*[:]+[\s]*=.+";
        private const string LastExitCodeRegexString = @".*[=]+ExitCode|ExitCodeAscii[:]*[\s]*=\d+";

        private readonly Regex _driveCurrentDirectoryRegex = new Regex(DriveCurrentDirectoryRegexString);
        private readonly Regex _lastExitCodeRegex = new Regex(LastExitCodeRegexString);

        [JetBrains.Annotations.Pure]
        public bool TeamCity_IsWinCmdInternalVariable(string input)
        {
            return _driveCurrentDirectoryRegex.IsMatch(input) || _lastExitCodeRegex.IsMatch(input);
        }
    }
}
