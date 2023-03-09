// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.Common.CI.SpaceAutomation;

namespace Nuke.Common.Tests.CI
{
    public class TestSpaceAutomationAttribute : SpaceAutomationAttribute, ITestConfigurationGenerator
    {
        public TestSpaceAutomationAttribute(string jobName, string image)
            : base(jobName, image)
        {
        }

        public StreamWriter Stream { get; set; }

        protected override StreamWriter CreateStream()
        {
            return Stream;
        }
    }
}
