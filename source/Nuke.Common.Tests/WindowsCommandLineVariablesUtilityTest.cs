using FluentAssertions;
using Nuke.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Nuke.Common.Tests
{
    public class WindowsCommandLineVariablesUtilityTest
    {
        [Fact]
        public void TeamCity_IsWinCmdInternalVariable_ShouldThrowNullReferenceException_WhenInputIsNull()
        {
            var sut = new WindowsCommandLineVariablesUtility();
            sut.Invoking(_ => _.TeamCity_IsWinCmdInternalVariable(null))
                .Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [MemberData(nameof(GetTestData))]
        public void TeamCity_IsWinCmdInternalVariable_ShouldDetermineOnlyUndocumentedWindowsCmdVariablesFromTeamCityInput(string line, bool result)
        {
            var sut = new WindowsCommandLineVariablesUtility();
            sut.TeamCity_IsWinCmdInternalVariable(line).Should().Be(result);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            return new List<object[]>()
            {
                new object[] { "FIRST_VAR", false },
                new object[] { @"env.=:: =::\", true },
                new object[] { @"env.=C: =C:\BuildAgent\bin", true },
                new object[] { @"env.=ExitCode =00000000", true },
                new object[] { @"env.=ExitCodeAscii =00000000", true },
                new object[] { @"env.ALLUSERSPROFILE =C:\ProgramData", false },
                new object[] { @"env.ANT_HOME =C:\ant", false },
                new object[] { @"env.ANT_OPTS =-Xms384m -Xmx500m -XX:MaxPermSize=384m", false },
                new object[] { @"env.Ant_Version =1.8.2", false },
                new object[] { @"env.APPDATA =C:\Users\buildagent_sa\AppData\Roaming", false },
                new object[] { @"env.Browser.Chrome.Version =79.0.3945.117", false },
                new object[] { @"env.Browser.FF.Versions =45.0.1", false },
                new object[] { @"env.Browser.IE.Version =<empty>", false },
                new object[] { @"env.ChocolateyInstall =C:\ProgramData\chocolatey", false },
                new object[] { @"env.CommonProgramFiles =C:\Program Files\Common Files", false },
                new object[] { @"env.CommonProgramFiles(x86) =C:\Program Files (x86)\Common Files", false },
                new object[] { @"env.CommonProgramW6432 =C:\Program Files\Common Files", false },
                new object[] { @"env.ComSpec =C:\Windows\system32\cmd.exe", false },
                new object[] { @"env.FP_NO_HOST_CHECK =NO", false },
                new object[] { @"env.FxCop_Version =10.0", false },
                new object[] { @"env.Ghostscript_Version =9.15", false },
                new object[] { @"env.JDK_16 =C:\Program Files\Java\jdk1.6.0_33", false },
                new object[] { @"env.JDK_16_x64 =C:\Program Files\Java\jdk1.6.0_33", false },
                new object[] { @"env.JDK_17 =C:\Program Files\Java\jdk1.7.0_51", false },
                new object[] { @"env.JDK_17_x64 =C:\Program Files\Java\jdk1.7.0_51", false },
                new object[] { @"env.PROCESSOR_ARCHITECTURE =AMD64", false },
                new object[] { @"env.PROCESSOR_IDENTIFIER =Intel64 Family 6 Model 37 Stepping 1, GenuineIntel", false },
                new object[] { @"env.PROCESSOR_LEVEL =6", false },
                new object[] { @"dep.BuildBootstrapper.env.=:: =::\", true },
                new object[] { @"dep.BuildBootstrapper.env.=C: =C:\BuildAgent\bin", true },
                new object[] { @"dep.BuildBootstrapper.env.=ExitCode =00000000", true },
                new object[] { @"dep.BuildBootstrapper.env.=ExitCodeAscii =00000000", true },
                new object[] { @"dep.BuildBootstrapper.env.ALLUSERSPROFILE =C:\ProgramData", false },
                new object[] { @"dep.BuildBootstrapper.env.ANT_HOME =C:\ant", false },
                new object[] { @"dep.BuildBootstrapper.env.ANT_OPTS =-Xms384m -Xmx500m -XX:MaxPermSize=384m", false },
                new object[] { @"dep.BuildBootstrapper.env.Ant_Version =1.8.2", false },
                new object[] { @"dep.BuildBootstrapper.env.ChocolateyInstall =C:\ProgramData\chocolatey", false },
                new object[] { @"dep.BuildBootstrapper.env.CodeContractsInstallDir =C:\Program Files (x86)\Microsoft\Contracts\", false },
                new object[] { @"dep.BuildBootstrapper.env.CommonProgramFiles =C:\Program Files\Common Files", false },
                new object[] { @"dep.BuildBootstrapper.env.CommonProgramFiles(x86) =C:\Program Files (x86)\Common Files", false },
                new object[] { @"dep.BuildBootstrapper.env.CommonProgramW6432 =C:\Program Files\Common Files", false }
            };
        }
    }
}
