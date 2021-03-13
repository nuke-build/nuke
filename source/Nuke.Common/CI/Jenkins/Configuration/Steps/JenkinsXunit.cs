// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration.Steps
{
    /// <summary>
    /// Used to publish tests results with <see href="https://plugins.jenkins.io/xunit/">xUnit</see> plugin.
    /// </summary>
    internal class JenkinsXunit : JenkinsStep
    {
        private readonly JenkinsXUnitReportType _xUnitReportType;
        private readonly string _includesPattern;
        private readonly string _excludesPattern;

        /// <summary>
        /// Initializes a new instance of <see cref="JenkinsXunit"/> class.
        /// </summary>
        /// <param name="xUnitReportType">Report type.</param>
        /// <param name="includesPattern">Include pattern.</param>
        /// <param name="excludesPattern">Exclude pattern.</param>
        public JenkinsXunit(JenkinsXUnitReportType xUnitReportType, string includesPattern, string excludesPattern = "")
        {
            _xUnitReportType = xUnitReportType;
            _includesPattern = includesPattern;
            _excludesPattern = excludesPattern;
        }

        /// <summary>
        /// Skip if no test files.
        /// </summary>
        public bool SkipNoTestFiles { get; set; } = true;

        /// <summary>
        /// Stop processing if error.
        /// </summary>
        public bool StopProcessingIfError { get; set; } = true;

        /// <summary>
        /// Fail if no new tests.
        /// </summary>
        public bool FailIfNoNewTests { get; set; } = true;

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine(
                $"xunit([{_xUnitReportType}(excludesPattern: {_excludesPattern.DoubleQuote()},"
                + $" pattern: {_includesPattern.DoubleQuote()},"
                + $" skipNoTestFiles: {SkipNoTestFiles.ToString().ToLowerInvariant()},"
                + $" stopProcessingIfError: {StopProcessingIfError.ToString().ToLowerInvariant()},"
                + $" failIfNotNew: {FailIfNoNewTests.ToString().ToLowerInvariant()})])");
        }
    }
}
