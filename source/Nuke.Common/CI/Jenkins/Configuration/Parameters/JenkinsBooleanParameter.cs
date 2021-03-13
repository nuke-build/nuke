// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration.Parameters
{
    /// <summary>
    /// Represents a boolean jenkins parameter, see <see href="https://www.jenkins.io/doc/book/pipeline/syntax/#available-parameters">booleanParam</see>.
    /// </summary>
    public class JenkinsBooleanParameter : JenkinsParameter
    {
        /// <inheritdoc />
        public JenkinsBooleanParameter(string name, bool defaultValue, string description = "")
            : base(name, defaultValue ? "true" : "false", description)
        {
        }

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            var str = $"booleanParam name: {Name.SingleQuote()}, defaultValue: {DefaultValue}, description: {Description.SingleQuote()}";
            writer.WriteLine(str);
        }
    }
}
