// Copyright 2019 Maintainers of NUKE.
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
    public abstract class ToolSettings : ISettingsEntity
    {
        protected ToolSettings()
        {
            ProcessEnvironmentVariablesInternal = EnvironmentInfo.Variables.ToDictionary(x => x.Key, x => x.Value);
            VerbosityMapping.Apply(this);
        }

        public virtual string ProcessToolPath { get; internal set; }
        public virtual string ProcessWorkingDirectory { get; internal set; }

        public IReadOnlyDictionary<string, string> ProcessEnvironmentVariables => ProcessEnvironmentVariablesInternal.AsReadOnly();
        internal Dictionary<string, string> ProcessEnvironmentVariablesInternal { get; set; }
        public int? ProcessExecutionTimeout { get; internal set; }
        public bool? ProcessLogOutput { get; internal set; }
        public bool? ProcessLogInvocation { get; internal set; }
        public bool? ProcessLogTimestamp { get; internal set; }
        public string ProcessLogFile { get; internal set; }

        public abstract Action<OutputType, string> ProcessCustomLogger { get; }

        [NonSerialized]
        private Func<Arguments, Arguments> _processArgumentConfigurator = x => x;

        public virtual Func<Arguments, Arguments> ProcessArgumentConfigurator
        {
            get => _processArgumentConfigurator;
            internal set => _processArgumentConfigurator = value;
        }

        public virtual IArguments GetProcessArguments()
        {
            AssertValid();

            var arguments = new Arguments();
            arguments = ConfigureProcessArguments(arguments);
            arguments = ProcessArgumentConfigurator(arguments);
            return arguments;
        }

        public bool HasValidToolPath()
        {
            try
            {
                ControlFlow.Assert(File.Exists(ProcessToolPath), "File.Exists(ProcessToolPath)");
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected virtual Arguments ConfigureProcessArguments(Arguments arguments)
        {
            return arguments;
        }

        protected virtual Arguments GetProcessArgumentsInternal()
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
