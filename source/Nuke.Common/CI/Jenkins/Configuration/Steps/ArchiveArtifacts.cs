// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration.Steps
{
    /// <summary>
    /// Used for the Jenkins Core functionality to <see href="https://www.jenkins.io/doc/pipeline/steps/core/#archiveartifacts-archive-the-artifacts">archive artifacts</see>.
    /// </summary>
    /// <remarks>Parameter FollowSymlinks is not supported yet.</remarks>
    internal class ArchiveArtifacts : Step
    {
        private readonly string _includesPattern;
        private readonly string _excludesPattern;

        /// <summary>
        /// Initializes a new instance of <see cref="ArchiveArtifacts"/> class.
        /// </summary>
        /// <param name="includesPattern">Include pattern.</param>
        /// <param name="excludesPattern">Exclude pattern.</param>
        public ArchiveArtifacts(string includesPattern, string excludesPattern = "")

        {
            _includesPattern = includesPattern;
            _excludesPattern = excludesPattern;
        }

        /// <summary>
        /// Allow empty archive or not.
        /// </summary>
        public bool AllowEmptyArchive { get; set; } = true;

        /// <summary>
        /// Use fingerprint or not.
        /// </summary>
        public bool Fingerprint { get; set; } = true;

        /// <summary>
        /// Archive only if successful.
        /// </summary>
        public bool OnlyIfSuccesful { get; set; }

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine($"archiveArtifacts allowEmptyArchive: {AllowEmptyArchive.ToString().ToLowerInvariant()},"
                             + $" artifacts: {_includesPattern.DoubleQuote()},"
                             + $" excludes: {_excludesPattern.DoubleQuote()},"
                             + $" fingerprint: {Fingerprint.ToString().ToLowerInvariant()},"
                             + $" onlyIfSuccessful: {OnlyIfSuccesful.ToString().ToLowerInvariant()}");
        }
    }
}
