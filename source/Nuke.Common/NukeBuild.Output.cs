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
        protected internal virtual void WriteLogo()
        {
            if (IsInterceptorExecution)
                return;

            Host.WriteLogo();
            if (IsOutputDisabled(DefaultOutputKind.Logo))
                return;

            Host.WriteLogo();

            Host.Information($"NUKE Execution Engine {typeof(NukeBuild).Assembly.GetInformationalText()}");
            Host.Information();
        }

        protected internal virtual IDisposable WriteTarget(string target)
        {
            if (IsInterceptorExecution)
                return DelegateDisposable.CreateBracket();

            bool HasCustomWriteBlock() =>
                Host.GetType().GetMethod(nameof(Host.WriteBlock), BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.NonPublic) != null;

            if (IsOutputDisabled(DefaultOutputKind.TargetHeader) && !HasCustomWriteBlock() ||
                IsOutputDisabled(DefaultOutputKind.TargetCollapse) && HasCustomWriteBlock())
                return DelegateDisposable.CreateBracket();

            return Host.WriteBlock(target);
        }

        protected internal virtual void WriteErrorsAndWarnings()
        {
            if (IsOutputDisabled(DefaultOutputKind.ErrorsAndWarnings))
                return;

            Host.WriteErrorsAndWarnings();
        }

        protected internal virtual void WriteTargetOutcome()
        {
            if (IsInterceptorExecution)
                return;

            if (IsOutputDisabled(DefaultOutputKind.TargetOutcome))
                return;

            Host.WriteTargetOutcome(this);
        }

        protected internal virtual void WriteBuildOutcome()
        {
            if (IsOutputDisabled(DefaultOutputKind.BuildOutcome))
                return;

            Host.WriteBuildOutcome(this);
        }

        internal bool IsOutputDisabled(DefaultOutputKind outputKind)
        {
            return GetType()
                .GetCustomAttribute<DisableDefaultOutputAttribute>()
                ?.DisabledOutputs.Contains(outputKind)
                ?? false;
        }
    }
}
