// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq.Expressions;
using Nuke.Common.IO;
using Nuke.Common.ValueInjection;

namespace Nuke.Common
{
    public abstract partial class NukeBuild
    {
        AbsolutePath INukeBuild.RootDirectory => RootDirectory;
        AbsolutePath INukeBuild.TemporaryDirectory => TemporaryDirectory;
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
        LogLevel INukeBuild.LogLevel => LogLevel;
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
