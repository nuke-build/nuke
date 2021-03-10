// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration.Parameters
{
    /// <summary>
    /// Represents a choice jenkins parameter, see <see href="https://www.jenkins.io/doc/book/pipeline/syntax/#available-parameters">choice</see>.
    /// </summary>
    public class ChoiceParameter : Parameter
    {
        private readonly string[] _choices;

        /// <inheritdoc />
        public ChoiceParameter(string name, string defaultValue, string description, params string[] choices)
            : base(name, defaultValue, description)
        {
            _choices = choices;
        }

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            var choicesList = _choices.ToList();
            if (choicesList.Contains(DefaultValue) && choicesList.IndexOf(DefaultValue) != 0)
            {
                choicesList.Remove(DefaultValue);
                choicesList.Insert(index: 0, DefaultValue);
            }

            var choices = string.Join(",", choicesList.Select(x => x.SingleQuote()));
            writer.WriteLine($"choice name: {Name.SingleQuote()}, choices: [{choices}], description: {Description.SingleQuote()}");
        }
    }
}
