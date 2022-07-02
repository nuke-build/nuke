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

            if (IsOutputDisabled(DefaultOutput.Logo))
                return;

            Host.WriteLogo();

            Host.Information($"NUKE Execution Engine {typeof(NukeBuild).Assembly.GetInformationalText()}");
            Host.Information();
        }

        protected internal virtual IDisposable WriteTarget(string target)
        {
            if (IsInterceptorExecution)
                return DelegateDisposable.CreateBracket();

            bool CanCollape() =>
                Host.GetType().GetMethod(nameof(Host.WriteBlock), BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.NonPublic) != null;

            if (IsOutputDisabled(DefaultOutput.TargetHeader) && !CanCollape() ||
                IsOutputDisabled(DefaultOutput.TargetCollapse) && CanCollape())
                return DelegateDisposable.CreateBracket();

            return Host.WriteBlock(target);
        }

        protected internal virtual void WriteErrorsAndWarnings()
        {
            if (IsOutputDisabled(DefaultOutput.RepeatedErrorsAndWarnings))
                return;

            Host.WriteErrorsAndWarnings();
        }

        protected internal virtual void WriteTargetOutcome()
        {
            if (IsInterceptorExecution)
                return;

            if (IsOutputDisabled(DefaultOutput.TargetOutcome))
                return;

            Host.WriteTargetOutcome(this);
        }

        protected internal virtual void WriteBuildOutcome()
        {
            if (IsOutputDisabled(DefaultOutput.BuildOutcome))
                return;

            Host.WriteBuildOutcome(this);
        }

        internal bool IsOutputDisabled(DefaultOutput output)
        {
            return GetType()
                .GetCustomAttribute<DisableDefaultOutputAttribute>()
                ?.DisabledOutputs.Contains(output)
                ?? false;
        }
    }
}
