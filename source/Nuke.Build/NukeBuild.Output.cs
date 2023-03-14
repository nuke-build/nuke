// Copyright 2023 Maintainers of NUKE.
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
        internal void WriteLogo()
        {
            if (IsInterceptorExecution)
                return;

            if (IsOutputEnabled(DefaultOutput.Logo))
                Host.WriteLogo();

            Host.Information($"NUKE Execution Engine {typeof(NukeBuild).Assembly.GetInformationalText()}");
            Host.Information();
        }

        internal IDisposable WriteTarget(string target)
        {
            bool CanCollapse() =>
                Host.GetType().GetMethod(nameof(Host.WriteBlock), ReflectionUtility.Instance | BindingFlags.DeclaredOnly) != null;

            if (IsInterceptorExecution)
                return DelegateDisposable.CreateBracket();

            if (IsOutputEnabled(DefaultOutput.TargetHeader) && !CanCollapse() ||
                IsOutputEnabled(DefaultOutput.TargetCollapse) && CanCollapse())
                return Host.WriteBlock(target);

            return DelegateDisposable.CreateBracket();
        }

        internal void WriteErrorsAndWarnings()
        {
            if (IsInterceptorExecution)
                return;

            if (IsOutputEnabled(DefaultOutput.ErrorsAndWarnings))
                Host.WriteErrorsAndWarnings();
        }

        internal void WriteTargetOutcome()
        {
            if (IsInterceptorExecution)
                return;

            if (IsOutputEnabled(DefaultOutput.TargetOutcome))
                Host.WriteTargetOutcome(this);
        }

        internal void WriteBuildOutcome()
        {
            if (IsInterceptorExecution)
                return;

            if (IsOutputEnabled(DefaultOutput.BuildOutcome))
                Host.WriteBuildOutcome(this);
        }

        private bool IsOutputEnabled(DefaultOutput output)
        {
            return !GetType().GetCustomAttributes<DisableDefaultOutputAttribute>()
                .Where(x => x.IsApplicable(this))
                .Any(x => x.DisabledOutputs.Contains(output));
        }
    }
}
