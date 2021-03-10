// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Text;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration.Parameters
{
    /// <summary>
    /// Represents a git jenkins parameter, see <see href="https://plugins.jenkins.io/git-parameter/">git parameter plugin</see>.
    /// </summary>
    public class GitParameter : Parameter
    {
        /// <inheritdoc />
        public GitParameter(string name, string defaultValue, string description = "")
            : base(name, defaultValue, description)
        {
        }

        /// <summary>
        /// The type of the list of parameters:
        /// Tag - list of all commit tags in repository - returns Tag Name
        /// Branch - list of all branch in repository - returns Branch Name
        /// Revision - list of all revision sha1 in repository followed by its author and date - returns Tag SHA1
        /// </summary>
        public GitParameterType GitParameterType { get; set; }

        /// <summary>
        /// Which value is selected, after loaded parameters. If you choose 'default', but default value is not present on the list, nothing is selected.
        /// </summary>
        public GitParameterSelectedValue ParameterSelectedValue { get; set; } = GitParameterSelectedValue.TOP;

        /// <summary>
        /// Select how to sort the downloaded parameters. Only applies to a branch or a tag.
        ///  When smart sorting is chosen, the compare treats a sequence of digits as a single character.
        /// </summary>
        public GitParameterSortMode ParameterSortMode { get; set; } = GitParameterSortMode.ASCENDING;

        /// <summary>
        /// Name of branch to look in. Used only if listing revisions.
        /// </summary>
        public string Branch { get; set; }

        /// <summary>
        /// Regex used to filter displayed branches. If blank, the filter will default to ".*".
        /// Remote branches will be listed with the remote name first. E.g., "origin/master"
        /// </summary>
        public string BranchFilter { get; set; }

        /// <summary>
        /// This parameter is used to get tag from git.
        /// If is blank, parameter is set to "*".
        /// Properly is executed command: git ls-remote -t $repository$ "*" or git ls-remote -t $repository$ "$tagFilter".
        /// git-ls-remote documentation.
        /// </summary>
        public string TagFilter { get; set; }

        /// <inheritdoc />
        public override void Write(CustomFileWriter writer)
        {
            //gitParameter branch: '', branchFilter: '.*', defaultValue: 'k', description: 'kkkkk', name: 'k', quickFilterEnabled: true, selectedValue: 'NONE', sortMode: 'NONE', tagFilter: '*', type: 'PT_TAG'

            var builder = new StringBuilder();

            builder.Append("gitParameter ");
            if (Branch != null)
            {
                builder.Append($"branch:{Branch.SingleQuote()},");
            }

            if (BranchFilter != null)
            {
                builder.Append($" branchFilter: {BranchFilter.SingleQuote()},");
            }

            if (TagFilter != null)
            {
                builder.Append($" tagFilter: {TagFilter.SingleQuote()},");
            }

            builder.Append($" type: {GitParameterType.ToString().SingleQuote()},");

            builder.Append($" description: {Description.SingleQuote()},");
            builder.Append($" name: {Name.SingleQuote()},");
            builder.Append(" quickFilterEnabled: true,");
            builder.Append($" selectedValue: {ParameterSelectedValue.ToString().SingleQuote()},");
            builder.Append($" sortMode: {ParameterSortMode.ToString().SingleQuote()},");
            builder.Append($" defaultValue: {DefaultValue.SingleQuote()}");

            writer.WriteLine(builder.ToString());
        }
    }
}
