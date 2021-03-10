// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.CI.Jenkins.Configuration.Parameters
{
    /// <summary>
    /// Abstract class for a Jenkins parameter.
    /// </summary>
    public abstract class Parameter : ConfigurationEntity
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <param name="description">Parameter description.</param>
        protected Parameter(string name, string defaultValue, string description = "")
        {
            Name = name;
            Description = description;
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// Parameter name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Parameter description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Default value.
        /// </summary>
        public string DefaultValue { get; }
    }
}
