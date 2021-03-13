﻿// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.CI.Jenkins.Configuration.Parameters
{
    public enum JenkinsParameterType
    {
        StringParameter,
        TextParameter,
        BooleanParameter,
        ChoiceParameter,
        PasswordParameter,
        GitParameter
    }
}