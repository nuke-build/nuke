// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration
{
    /// <summary>
    /// Jenkins configuration.
    /// </summary>
    public class JenkinsConfiguration : ConfigurationEntity
    {
        private readonly JenkinsPipeline _pipeline;

        /// <summary>
        /// Initializes a new instance of <see cref="JenkinsConfiguration"/>.
        /// </summary>
        /// <param name="pipeline">Jenkins pipeline.</param>
        internal JenkinsConfiguration(JenkinsPipeline pipeline)
        {
            _pipeline = pipeline;
        }

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            _pipeline.Write(writer);
        }
    }
}
