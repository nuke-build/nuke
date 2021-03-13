// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.Common.CI.Jenkins;

namespace Nuke.Common.Tests.CI
{
    public class TestJenkinsAttribute : JenkinsAttribute, ITestConfigurationGenerator
    {
        public TestJenkinsAttribute(string jenkinsFileName)
            : base(jenkinsFileName)
        {
        }

        public StreamWriter Stream { get; set; }

        protected override StreamWriter CreateStream()
        {
            return Stream;
        }
    }
}
