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

        private bool? _cloneRepository;
        private int? _cloneDepth;
        
        private int? _resourcesCpu;
        private int? _resourcesMemory;
        private bool? _onPush;
        
        private bool? _failOnNonZeroExitCode;
        private bool? _failOnTestFailed;
        private bool? _failOnOutOfMemory;
        private bool? _failOnTimeout;
        private int? _failOnTimeoutInMinutes;

        public string VolumeSize { get; set; }
        
        public bool CloneRepository
        {
            set => _cloneRepository = value;
            get => _cloneRepository ?? true;
        }
        
        public int CloneDepth
        {
            set => _cloneDepth = value;
            get => _cloneDepth ?? 1;
        }
        
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
        
        public bool FailOnNonZeroExitCode
        {
            set => _failOnNonZeroExitCode = value;
            get => _failOnNonZeroExitCode ?? false;
        }

        public bool FailOnTestFailed
        {
            set => _failOnTestFailed = value;
            get => _failOnTestFailed ?? false;
        }
        
        public bool FailOnOutOfMemory
        {
            set => _failOnOutOfMemory = value;
            get => _failOnOutOfMemory ?? false;
        }
        
        public bool FailOnTimeout
        {
            set => _failOnTimeout = value;
            get => _failOnTimeout ?? false;
        }

        public int FailOnTimeoutInMinutes
        {
            set => _failOnTimeoutInMinutes = value;
            get => _failOnTimeoutInMinutes ?? 120;
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
                       CloneRepository = _cloneRepository,
                       CloneDepth = _cloneDepth,
                       Container = GetContainer(),
                       Triggers = GetTriggers().ToArray(),
                       FailureConditions = GetFailureConditions().ToArray()
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

        protected virtual IEnumerable<SpaceAutomationFailureCondition> GetFailureConditions()
        {
            if (_failOnNonZeroExitCode != null)
                yield return new SpaceAutomationNonZeroExitCodeFailureCondition { NonZeroExitCode = _failOnNonZeroExitCode };
            
            if (_failOnTestFailed != null)
                yield return new SpaceAutomationTestFailedFailureCondition { TestFailed = _failOnTestFailed };
            
            if (_failOnOutOfMemory != null)
                yield return new SpaceAutomationOutOfMemoryFailureCondition { OutOfMemory = _failOnOutOfMemory };
            
            ControlFlow.Assert(FailOnTimeoutInMinutes > 0 && FailOnTimeoutInMinutes <= 120, "FailOnTimeoutInMinutes > 0 && FailOnTimeoutInMinutes <= 120");
            if (_failOnTimeout != null || _failOnTimeoutInMinutes != null)
            {
                yield return new SpaceAutomationTimeoutFailureCondition
                             {
                                 Timeout = _failOnTimeout,
                                 TimeoutInMinutes = _failOnTimeoutInMinutes
                             };
            }
        }
    }
}
