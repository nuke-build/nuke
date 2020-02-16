// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class ConfigurationAttributeBase : Attribute, IConfigurationGenerator
    {
        public string Name => HostType + (string.IsNullOrEmpty(IdPostfix) ? string.Empty : $" ({IdPostfix})");
        public string Id => HostType + (string.IsNullOrEmpty(IdPostfix) ? string.Empty : $"_{IdPostfix}");
        public virtual string IdPostfix => string.Empty;
        public bool AutoGenerate { get; set; } = true;
        public abstract HostType HostType { get; }
        public abstract IEnumerable<string> GeneratedFiles { get; }
        public abstract IEnumerable<string> RelevantTargetNames { get; }
        public abstract IEnumerable<string> IrrelevantTargetNames { get; }

        protected virtual string BuildCmdPath =>
            NukeBuild.RootDirectory.GlobFiles("build.cmd", "*/build.cmd")
                .Select(x => NukeBuild.RootDirectory.GetUnixRelativePathTo(x))
                .FirstOrDefault().NotNull("BuildCmdPath != null");

        public abstract CustomFileWriter CreateWriter();
        public abstract ConfigurationEntity GetConfiguration(NukeBuild build, IReadOnlyCollection<ExecutableTarget> relevantTargets);
        public virtual void SerializeState()
        {
        }
    }
}
