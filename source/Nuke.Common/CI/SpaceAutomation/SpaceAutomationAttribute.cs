// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.CI.SpaceAutomation.Configuration;
using Nuke.Common.Execution;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.SpaceAutomation
{
    [PublicAPI]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class SpaceAutomationAttribute : ConfigurationAttributeBase
    {
        private readonly string _name;
        private readonly string _image;

        public SpaceAutomationAttribute(string name, string image)
        {
            _name = name;
            _image = image;
        }

        public override HostType HostType => HostType.SpaceAutomation;
        public override string ConfigurationFile => NukeBuild.RootDirectory / ".space.kts";
        public override IEnumerable<string> GeneratedFiles => new[] { ConfigurationFile };

        public override IEnumerable<string> RelevantTargetNames => InvokedTargets;
        public override IEnumerable<string> IrrelevantTargetNames => new string[0];

        private int? _resourcesCpu;
        private int? _resourcesMemory;
        private bool? _onPush;

        public int ResourcesCpu
        {
            set => _resourcesCpu = value;
            get => _resourcesCpu ?? 0;
        }

        public int ResourcesMemory
        {
            set => _resourcesMemory = value;
            get => _resourcesMemory ?? 0;
        }

        public string[] InvokedTargets { get; set; } = new string[0];

        public bool OnPush
        {
            set => _onPush = value;
            get => _onPush ?? false;
        }

        public string[] OnPushBranchIncludes { get; set; }
        public string[] OnPushBranchExcludes { get; set; }
        public string[] OnPushBranchRegexIncludes { get; set; }
        public string[] OnPushBranchRegexExcludes { get; set; }
        public string[] OnPushPathIncludes { get; set; }
        public string[] OnPushPathExcludes { get; set; }

        public string OnCronSchedule { get; set; }

        public override CustomFileWriter CreateWriter(StreamWriter streamWriter)
        {
            return new CustomFileWriter(streamWriter, indentationFactor: 4, commentPrefix: "//");
        }

        public override ConfigurationEntity GetConfiguration(NukeBuild build, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return new SpaceAutomationConfiguration
                   {
                       Name = _name,
                       Container = GetContainer()
                   };
        }

        protected virtual SpaceAutomationContainer GetContainer()
        {
            return new SpaceAutomationContainer
                   {
                       Image = _image,
                       Resources = GetResources(),
                       Triggers = GetTriggers().ToArray(),
                       BuildScript = BuildCmdPath.Replace(".cmd", ".sh"),
                       InvokedTargets = InvokedTargets
                   };
        }

        protected virtual SpaceAutomationResources GetResources()
        {
            ControlFlow.Assert(_resourcesCpu == null || ResourcesCpu > 0, "ResourcesCpu > 0");
            ControlFlow.Assert(_resourcesMemory == null || ResourcesMemory > 0, "ResourcesMemory > 0");

            return new SpaceAutomationResources { Cpu = _resourcesCpu, Memory = _resourcesMemory };
        }

        protected virtual IEnumerable<SpaceAutomationTrigger> GetTriggers()
        {
            if (_onPush != null ||
                OnPushBranchIncludes != null ||
                OnPushBranchExcludes != null ||
                OnPushBranchRegexIncludes != null ||
                OnPushBranchRegexExcludes != null ||
                OnPushPathIncludes != null ||
                OnPushPathExcludes != null)
            {
                yield return new SpaceAutomationPushTrigger
                             {
                                 OnPush = _onPush,
                                 OnPushBranchIncludes = OnPushBranchIncludes,
                                 OnPushBranchExcludes = OnPushBranchExcludes,
                                 OnPushBranchRegexIncludes = OnPushBranchRegexIncludes,
                                 OnPushBranchRegexExcludes = OnPushBranchRegexExcludes,
                                 OnPushPathIncludes = OnPushPathIncludes,
                                 OnPushPathExcludes = OnPushPathExcludes
                             };
            }

            if (OnCronSchedule != null)
                yield return new SpaceAutomationCronScheduleTrigger { CronExpression = OnCronSchedule };
        }
    }
}
