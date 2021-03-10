// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration.Steps
{
    /// <summary>
    /// Represents a if else block, see <see href="https://www.jenkins.io/doc/book/pipeline/syntax/#flow-control">Flow Control</see>.
    /// </summary>
    internal class IfElseScripted : Step
    {
        private readonly string _condition;
        private readonly Step _ifTrue;
        private readonly Step _ifFalse;

        /// <summary>
        /// Initializes a new instance of <see cref="IfElseScripted"/> class.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifTrue"></param>
        /// <param name="ifFalse"></param>
        public IfElseScripted(string condition, Step ifTrue, Step ifFalse)
        {
            _condition = condition;
            _ifTrue = ifTrue;
            _ifFalse = ifFalse;
        }

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            using (writer.WriteBlock($"if ({_condition})"))
            {
                _ifTrue.Write(writer);
            }

            using (writer.WriteBlock("else"))
            {
                _ifFalse.Write(writer);
            }
        }
    }
}
