// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common
{
    public abstract partial class NukeBuild
    {
        /// <summary>
        /// Method that is invoked after the instance of the build was created.
        /// </summary>
        protected internal virtual void OnBuildCreated()
        {
        }

        /// <summary>
        /// Method that is invoked after build instance is initialized. I.e., value injection and requirement validation has finished.
        /// </summary>
        protected internal virtual void OnBuildInitialized()
        {
        }

        /// <summary>
        /// Method that is invoked after the build has finished (successful or failed).
        /// </summary>
        protected internal virtual void OnBuildFinished()
        {
        }

        /// <summary>
        /// Method that is invoked before a target is about to start.
        /// </summary>
        protected internal virtual void OnTargetStart(string target)
        {
        }

        /// <summary>
        /// Method that is invoked when a shadow target is absent.
        /// </summary>
        protected internal virtual void OnTargetAbsent(string target)
        {
        }

        /// <summary>
        /// Method that is invoked when a target is skipped.
        /// </summary>
        protected internal virtual void OnTargetSkipped(string target)
        {
        }

        /// <summary>
        /// Method that is invoked when a target has been executed successfully. 
        /// </summary>
        protected internal virtual void OnTargetExecuted(string target)
        {
        }

        /// <summary>
        /// Method that is invoked when a target has failed. 
        /// </summary>
        protected internal virtual void OnTargetFailed(string target)
        {
        }
    }
}
