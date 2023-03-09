// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ValueInjection;

namespace Nuke.Common
{
    public abstract partial class NukeBuild
    {
        IReadOnlyCollection<ExecutableTarget> INukeBuild.ExecutableTargets => ExecutableTargets;
        bool INukeBuild.IsInterceptorExecution => IsInterceptorExecution;
        string[] INukeBuild.LoadedLocalProfiles => LoadedLocalProfiles;
        bool INukeBuild.IsOutputEnabled(DefaultOutput output) => IsOutputEnabled(output);

        AbsolutePath INukeBuild.RootDirectory => RootDirectory;
        AbsolutePath INukeBuild.TemporaryDirectory => TemporaryDirectory;
        AbsolutePath INukeBuild.BuildAssemblyFile => BuildAssemblyFile;
        AbsolutePath INukeBuild.BuildAssemblyDirectory => BuildAssemblyDirectory;
        AbsolutePath INukeBuild.BuildProjectDirectory => BuildProjectDirectory;
        AbsolutePath INukeBuild.BuildProjectFile => BuildProjectFile;
        Verbosity INukeBuild.Verbosity => Verbosity;
        Host INukeBuild.Host => Host;
        bool INukeBuild.Plan => Plan;
        bool INukeBuild.Help => Help;
        bool INukeBuild.NoLogo => NoLogo;
        bool INukeBuild.IsLocalBuild => IsLocalBuild;
        bool INukeBuild.IsServerBuild => IsServerBuild;
        bool INukeBuild.Continue => Continue;

        T INukeBuild.TryGetValue<T>(Expression<Func<T>> parameterExpression)
        {
            return ValueInjectionUtility.TryGetValue(parameterExpression);
        }

        T INukeBuild.TryGetValue<T>(Expression<Func<object>> parameterExpression)
        {
            return ValueInjectionUtility.TryGetValue<T>(parameterExpression);
        }
    }
}
