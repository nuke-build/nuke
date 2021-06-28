﻿// Copyright 2020 Maintainers of NUKE.
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

        private bool? _onPush;
        private int? _timeoutInMinutes;

        public SpaceAutomationAttribute(string name, string image)
        {
            _name = name;
            _image = image;
        }

        public override Type HostType => typeof(SpaceAutomation);
        public override string ConfigurationFile => NukeBuild.RootDirectory / ".space.kts";
        public override IEnumerable<string> GeneratedFiles => new[] { ConfigurationFile };

        public override IEnumerable<string> RelevantTargetNames => InvokedTargets;
        public override IEnumerable<string> IrrelevantTargetNames => new string[0];

        public string VolumeSize { get; set; }
        public string ResourcesCpu { get; set; }
        public string ResourcesMemory { get; set; }
        public string[] RefSpec { get; set; } = { "refs/heads/*:refs/heads/*" };

        public string[] InvokedTargets { get; set; } = new string[0];

        public bool OnPush
        {
            set => _onPush = value;
            get => throw new NotSupportedException();
        }

        public string[] OnPushBranchIncludes { get; set; }
        public string[] OnPushBranchExcludes { get; set; }
        public string[] OnPushBranchRegexIncludes { get; set; }
        public string[] OnPushBranchRegexExcludes { get; set; }
        public string[] OnPushPathIncludes { get; set; }
        public string[] OnPushPathExcludes { get; set; }

        public string OnCronSchedule { get; set; }

        public int TimeoutInMinutes
        {
            set => _timeoutInMinutes = value;
            get => throw new NotSupportedException();
        }

        public override CustomFileWriter CreateWriter(StreamWriter streamWriter)
        {
            return new CustomFileWriter(streamWriter, indentationFactor: 4, commentPrefix: "//");
        }

        public override ConfigurationEntity GetConfiguration(NukeBuild build, IReadOnlyCollection<ExecutableTarget> relevantTargets)
        {
            return new SpaceAutomationConfiguration
                   {
                       Name = _name,
                       VolumeSize = VolumeSize,
                       RefSpec = RefSpec,
                       Container = GetContainer(),
                       Triggers = GetTriggers().ToArray(),
                       TimeoutInMinutes = _timeoutInMinutes
                   };
        }

        protected virtual SpaceAutomationContainer GetContainer()
        {
            return new SpaceAutomationContainer
                   {
                       Image = _image,
                       Resources = GetResources(),
                       BuildScript = BuildCmdPath.Replace(".cmd", ".sh"),
                       InvokedTargets = InvokedTargets
                   };
        }

        protected virtual SpaceAutomationResources GetResources()
        {
            return new SpaceAutomationResources
                   {
                       Cpu = ResourcesCpu,
                       Memory = ResourcesMemory
                   };
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
