﻿// Copyright 2022 Maintainers of NUKE.
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

        internal bool IsOutputEnabled(DefaultOutput output)
        {
            return !(GetType().GetCustomAttribute<DisableDefaultOutputAttribute>()?.DisabledOutputs.Contains(output) ?? false);
        }
    }
}
