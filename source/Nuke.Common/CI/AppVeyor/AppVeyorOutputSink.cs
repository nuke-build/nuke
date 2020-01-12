// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.OutputSinks;

namespace Nuke.Common.CI.AppVeyor
{
    [UsedImplicitly]
    [ExcludeFromCodeCoverage]
    internal class AppVeyorOutputSink : AnsiColorOutputSink
    {
        private readonly AppVeyor _appVeyor;
        private int _messageCount;

        internal AppVeyorOutputSink(AppVeyor appVeyor)
        {
            _appVeyor = appVeyor;
        }

        protected override string TraceCode => "90";
        protected override string InformationCode => "36;1";
        protected override string WarningCode => "33;1";
        protected override string ErrorCode => "31;1";
        protected override string SuccessCode => "32;1";

        protected override void ReportWarning(string text, string details = null)
        {
            IncreaseAndCheckMessageCount();
            _appVeyor.WriteWarning(text, details);
        }

        protected override void ReportError(string text, string details = null)
        {
            IncreaseAndCheckMessageCount();
            _appVeyor.WriteError(text, details);
        }

        private void IncreaseAndCheckMessageCount()
        {
            _messageCount++;

            if (_messageCount == 501)
            {
                base.WriteWarning("AppVeyor has a default limit of 500 messages. " +
                                  "If you're getting an exception from 'appveyor.exe' after this message, " +
                                  "contact https://appveyor.com/support to resolve this issue for your account.");
            }
        }
    }
}
