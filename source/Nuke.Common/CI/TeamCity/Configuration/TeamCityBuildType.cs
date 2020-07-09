// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;
using Nuke.Common.ValueInjection;

namespace Nuke.Common.CI.TeamCity.Configuration
{
    public class TeamCityBuildType : ConfigurationEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TeamCityBuildTypeVcsRoot VcsRoot { get; set; }
        public bool IsComposite { get; set; }
        public bool IsDeployment { get; set; }
        public string BuildCmdPath { get; set; }
        public string[] InvokedTargets { get; set; }
        public Partition Partition { get; set; }
        public string PartitionName { get; set; }
        public TeamCityConfigurationParameter[] Parameters { get; set; }
        public string[] ArtifactRules { get; set; }
        public TeamCityAgentPlatform Platform { get; set; }

        public TeamCityTrigger[] Triggers { get; set; }
        public TeamCityDependency[] Dependencies { get; set; }

        public override void Write(CustomFileWriter writer)
        {
            writer.WriteLine($"object {Id} : BuildType({{");
            using (writer.Indent())
            {
                writer.WriteLine($"name = {Name.DoubleQuote()}");

                if (Description != null)
                    writer.WriteLine($"description = {Description.DoubleQuote()}");

                if (IsComposite)
                    writer.WriteLine("type = Type.COMPOSITE");
                if (IsDeployment)
                    writer.WriteLine("type = Type.DEPLOYMENT");

                VcsRoot.Write(writer);
                WriteArtifacts(writer);

                if (!IsComposite)
                    WriteSteps(writer);

                WriteParameters(writer);
                WriteTriggers(writer);
                WriteDependencies(writer);
            }

            writer.WriteLine("})");
        }

        public virtual void WriteDependencies(CustomFileWriter writer)
        {
            if (!Dependencies?.Any() ?? true)
                return;

            using (writer.WriteBlock("dependencies"))
            {
                foreach (var dependency in Dependencies)
                    dependency.Write(writer);
            }
        }

        public virtual void WriteParameters(CustomFileWriter writer)
        {
            if (!Parameters?.Any() ?? true)
                return;

            using (writer.WriteBlock("params"))
            {
                foreach (var parameter in Parameters)
                    parameter.Write(writer);
            }
        }

        public virtual void WriteArtifacts(CustomFileWriter writer)
        {
            writer.WriteArray("artifactRules", ArtifactRules);
        }

        private void WriteTriggers(CustomFileWriter writer)
        {
            if (!Triggers?.Any() ?? true)
                return;

            using (writer.WriteBlock("triggers"))
            {
                foreach (var trigger in Triggers)
                    trigger.Write(writer);
            }
        }

        public virtual void WriteSteps(CustomFileWriter writer)
        {
            using (writer.WriteBlock("steps"))
            {
                var arguments = $"{InvokedTargets.JoinSpace()} --skip";
                if (Partition != null)
                    arguments += $" --{ParameterService.GetParameterDashedName(PartitionName)} {Partition.Part}";

                using (writer.WriteBlock("exec"))
                {
                    var path = Platform == TeamCityAgentPlatform.Windows
                        ? BuildCmdPath
                        : BuildCmdPath.Replace(".cmd", ".sh");
                    writer.WriteLine($"path = {path.DoubleQuote()}");
                    writer.WriteLine($"arguments = {arguments.DoubleQuote()}");
                }
            }
        }
    }
}
