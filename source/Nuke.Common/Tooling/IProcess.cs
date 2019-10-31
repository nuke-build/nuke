// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.Tooling
{
    /// <summary>
    /// Abstraction for <see cref="Process"/>.
    /// </summary>
    [PublicAPI]
    public interface IProcess : IDisposable
    {
        /// <summary>
        /// Returns the invoked file name.
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Returns the arguments with filtered secrets.
        /// </summary>
        string Arguments { get; }

        /// <summary>
        /// Returns the working directory.
        /// </summary>
        string WorkingDirectory { get; }

        /// <summary>
        /// Contains the output of the process execution.
        /// </summary>
        IReadOnlyCollection<Output> Output { get; }

        /// <summary>
        /// Returns <see cref="Process.ExitCode"/>.
        /// </summary>
        int ExitCode { get; }

        /// <summary>
        /// Calls <see cref="Process.Kill()"/>.
        /// </summary>
        void Kill();

        /// <summary>
        /// Waits for the process to exit. If the process is not exiting within a given timeout, <see cref="Kill"/> is called.
        /// </summary>
        /// <returns>
        /// Returns <c>true</c>, if the process exited on its own.
        /// </returns>
        bool WaitForExit();
    }
}
