﻿// Copyright 2024 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.CI.AzurePipelines.Configuration;

[PublicAPI]
public abstract class AzurePipelineStepAttribute : CustomStepConfigurationEntityAttribute<AzurePipelinesStep>
{

}
