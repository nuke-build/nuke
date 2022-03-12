// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE
// ReSharper disable MemberCanBeInternal

namespace Nuke.Common.Execution
{
    using System;
    using System.Linq;

    using JetBrains.Annotations;

    using Serilog;

    [ AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true) ]
    public sealed class NoTargetBannerAttribute : Attribute
    {
        public NoTargetBannerAttribute() {
        }
        
        public static bool IsDeclaredOn([ NotNull ] ExecutableTarget target)
        {
            var attributes = target.Member.GetCustomAttributes(typeof(NoTargetBannerAttribute), true);

            Log.Verbose($"NoTargetBannerAttribute: rtype: {attributes?.Length}");

            return attributes is
            {
                Length: > 0,
            };
        }
    }
}
