// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Tooling
{
    /// <summary>
    /// Abstraction for <see cref="Process"/>.
    /// </summary>
    [PublicAPI]
    public interface IProcess : IDisposable
    {
        /// <summary>
        /// Contains the output of the process execution.
        /// </summary>
        IEnumerable<Output> Output { get; }

        /// <summary>
        /// Returns <see cref="Process.ExitCode"/>.
        /// </summary>
        int ExitCode { get; }

        /// <summary>
        /// Calls <see cref="Process.Kill"/>.
        /// </summary>
        void Kill ();

        /// <summary>
        /// Waits for the process to exit. The timeout is provided via <see cref="ProcessTasks.StartProcess(string,string,string,System.Nullable{int},bool,System.Func{string,string})"/> or <see cref="ToolSettings"/>.
        /// If the process is not exiting within a given timeout, <see cref="Kill"/> is called.
        /// </summary>
        /// <returns>
        /// Returns <c>true</c>, if the process exited on its own.
        /// </returns>
        bool WaitForExit ();
    }
}
