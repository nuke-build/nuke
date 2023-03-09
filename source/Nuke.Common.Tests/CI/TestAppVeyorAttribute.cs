// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.Common.CI.AppVeyor;

namespace Nuke.Common.Tests.CI
{
    public class TestAppVeyorAttribute : AppVeyorAttribute, ITestConfigurationGenerator
    {
        public TestAppVeyorAttribute(AppVeyorImage image, params AppVeyorImage[] images)
            : base(image, images)
        {
        }

        public StreamWriter Stream { get; set; }

        protected override StreamWriter CreateStream()
        {
            return Stream;
        }
    }
}
