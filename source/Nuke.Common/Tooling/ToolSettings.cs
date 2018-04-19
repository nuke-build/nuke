// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
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

        [NonSerialized]
        private Func<Arguments, Arguments> _argumentConfigurator = x => x;

        public virtual Func<Arguments, Arguments> ArgumentConfigurator
        {
            get => _argumentConfigurator;
            internal set => _argumentConfigurator = value;
        }

        public virtual IArguments GetArguments()
        {
            AssertValid();

            var arguments = new Arguments();
            arguments = ConfigureArguments(arguments);
            arguments = ArgumentConfigurator(arguments);
            return arguments;
        }

        public bool HasValidToolPath()
        {
            try
            {
                ControlFlow.Assert(File.Exists(ToolPath), "File.Exists(ToolPath)");
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected virtual Arguments ConfigureArguments(Arguments arguments)
        {
            return arguments;
        }

        protected virtual Arguments GetArgumentsInternal()
        {
            return new Arguments();
        }

        protected virtual void AssertValid()
        {
        }

        public sealed override string ToString()
        {
            return base.ToString();
        }
    }
}
