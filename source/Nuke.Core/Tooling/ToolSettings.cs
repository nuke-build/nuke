// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Nuke.Core.Tooling
{
    [SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global")]
    partial class ToolSettings
    {
        public virtual IArguments GetArguments ()
        {
            AssertValid();
            // TODO: ArgumentConfigurator can't be serialized!
            return ArgumentConfigurator(GetArgumentsInternal());
        }

        protected virtual Arguments GetArgumentsInternal ()
        {
            return new Arguments();
        }

        protected virtual void AssertValid ()
        {
        }

        public sealed override string ToString ()
        {
            return base.ToString();
        }
    }
}
