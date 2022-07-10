// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
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

            Host.Information($"NUKE Execution Engine {typeof(NukeBuild).Assembly.GetInformationalText()}");
            Host.Information();
        }

        protected internal virtual IDisposable WriteTarget(string target)
        {
            if (IsInterceptorExecution)
                return DelegateDisposable.CreateBracket();

            return Host.WriteBlock(target);
        }

        protected internal virtual void WriteSummary()
        {
            if (IsInterceptorExecution)
                return;

            Host.WriteSummary(this);
        }
    }
}
