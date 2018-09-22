// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tooling
{
    [PublicAPI]
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class ToolSettings : ISettingsEntity
    {
        public ToolSettings()
        {
            var variables = EnvironmentInfo.GetVariables();
            EnvironmentVariablesInternal = new Dictionary<string, string>(variables, variables.Comparer);
            LogOutput = true; // TODO: could be controlled by NukeBuild parameter
        }

        public virtual string ToolPath { get; internal set; }
        public virtual string WorkingDirectory { get; internal set; }

        public IReadOnlyDictionary<string, string> EnvironmentVariables => EnvironmentVariablesInternal.AsReadOnly();
        internal Dictionary<string, string> EnvironmentVariablesInternal { get; set; }
        public int? ExecutionTimeout { get; internal set; }
        public bool LogOutput { get; internal set; }

        protected internal virtual Func<string, LogLevel> LogLevelParser => null;

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
