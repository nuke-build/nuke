// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Core.Tooling
{
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class ToolSettings : ISettingsEntity
    {
        public virtual string ToolPath { get; internal set; }
        public virtual string WorkingDirectory { get; internal set; }
        public virtual Func<Arguments, Arguments> ArgumentConfigurator { get; internal set; } = x => x;

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
