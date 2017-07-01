// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.ToolGenerator.Model
{
    public enum AssertionType
    {
        /// <summary>
        /// Generates an assertion for <c>value != null</c>.
        /// </summary>
        NotNull,

        /// <summary>
        /// Generates an assertion for <c>File.Exists(value)</c>.
        /// </summary>
        File,

        /// <summary>
        /// Generates an assertion for <c>Directory.Exists(value)</c>.
        /// </summary>
        Directory,

        /// <summary>
        /// Generates an assertion for <c>File.Exists(value) || value == null</c>.
        /// </summary>
        FileOrNull,

        /// <summary>
        /// Generates an assertion for <c>Directory.Exists(value) || value == null</c>.
        /// </summary>
        DirectoryOrNull
    }
}
