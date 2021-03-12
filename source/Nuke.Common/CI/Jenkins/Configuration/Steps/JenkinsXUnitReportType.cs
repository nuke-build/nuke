// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.CI.Jenkins.Configuration.Steps
{
    public enum JenkinsXUnitReportType
    {
        AUnit,
        BoostTest,
        CTest,
        CUnit,
        Check,
        CppTest,
        CppUnit,
        embUnit,
        FPCUnit,
        GoogleTest,
        JUnit,
        NUnit2,
        NUnit3,
        MSTest,
        MbUnit,
        PHPUnit,
        QtTest,
        UnitTest,
        Valgrind,
        gtester,
        xUnitDotNet
    }
}
