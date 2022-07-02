// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using System.Reflection;
using Nuke.Common.Utilities;

namespace Nuke.Common
{
    partial class NukeBuild
    {
        /// <summary>
        ///     Indicates whether the specified output kind should not be displayed by the host
        ///     for the current build.
        /// </summary>
        /// <param name="outputKind">The output kind to check.</param>
        /// <returns>
        ///     <see langword="true"/> if the output kind specified by <paramref name="outputKind"/> should not be output
        ///     for the current build, <see langword="false"/> otherwise.
        /// </returns>
        protected bool IsOutputDisabled(DefaultOutputKind outputKind)
        {
            return GetType()
                .GetCustomAttributes<DisableDefaultOutputAttribute>()
                .Any(a => a.IsOutputDisabled(outputKind));
        }

        protected internal virtual void WriteLogo()
        {
            if (IsInterceptorExecution)
                return;

            Host.WriteLogo();
            if (!IsOutputDisabled(DefaultOutputKind.Logo))
            {
                Host.WriteLogo();
            }

            Host.Information($"NUKE Execution Engine {typeof(NukeBuild).Assembly.GetInformationalText()}");
            Host.Information();
        }

        protected internal virtual IDisposable WriteTarget(string target)
        {
            if (IsInterceptorExecution)
                return DelegateDisposable.CreateBracket();

            if (IsHostWriteBlockOverridden() && IsOutputDisabled(DefaultOutputKind.TargetCollapse))
            {
                // All hosts that override WriteBlock do it to support expand/collapse and it is disabled,
                // so do not call WriteBlock at all.
                return DelegateDisposable.CreateBracket();
            }

            if (!IsHostWriteBlockOverridden() && IsOutputDisabled(DefaultOutputKind.TargetHeader))
            {
                return DelegateDisposable.CreateBracket();
            }

            return Host.WriteBlock(target);
        }

        private bool IsHostWriteBlockOverridden()
        {
            return Host.GetType().GetMethod(
                       nameof(Host.WriteBlock),
                       BindingFlags.Instance | BindingFlags.NonPublic,
                       Type.DefaultBinder,
                       new[] { typeof(string) },
                       modifiers: null)!.DeclaringType !=
                   typeof(Host);
        }

        protected internal virtual void WriteSummary()
        {
            if (IsInterceptorExecution)
                return;

            if (!IsOutputDisabled(DefaultOutputKind.Summary))
            {
                return;
            }

            Host.WriteSummary(this);
        }
    }
}
