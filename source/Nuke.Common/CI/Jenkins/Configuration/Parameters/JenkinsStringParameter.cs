// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration.Parameters
{
    /// <summary>
    /// Represents a string jenkins parameter, see <see href="https://www.jenkins.io/doc/book/pipeline/syntax/#available-parameters">string</see>.
    /// </summary>
    public class JenkinsStringParameter : JenkinsParameter
    {
        /// <inheritdoc />
        public JenkinsStringParameter(string name, string defaultValue, string description = "")
            : base(name, defaultValue, description)
        {
        }

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            var str = $"string name: {Name.SingleQuote()}, defaultValue: {DefaultValue.SingleQuote()}, description: {Description.SingleQuote()}";
            writer.WriteLine(str);
        }
    }
}
