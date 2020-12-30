using System;
using System.IO;
using System.Linq;
using Nuke.Common.CI.AppVeyor;

namespace Nuke.Common.Tests.CI
{
    public class TestAppVeyorConfigurationGenerator : AppVeyorConfigurationGenerator, ITestConfigurationGenerator
    {
        public TestAppVeyorConfigurationGenerator(AppVeyorImage image, params AppVeyorImage[] images)
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
