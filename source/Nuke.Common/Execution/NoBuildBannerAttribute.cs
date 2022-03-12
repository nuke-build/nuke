// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

// ReSharper disable TemplateIsNotCompileTimeConstantProblem
// ReSharper disable LoopCanBeConvertedToQuery
// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBeInternal

namespace Nuke.Common.Execution;

using System;
using System.Linq;

using Serilog;

[ AttributeUsage(AttributeTargets.Class | AttributeTargets.Module, AllowMultiple = false, Inherited = true) ]
public sealed class NoBuildBannerAttribute : Attribute
{
    private static bool? _isDeclared;
    public NoBuildBannerAttribute() { }

    public static bool IsDeclared => _isDeclared ??= GetIsDeclared();

    private static bool GetIsDeclared()
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            var result = IsDefined(assembly, typeof(NoBuildBannerAttribute));

            if (result)
            {
                Log.Verbose($"NoBuildBannerAttribute: Found on assembly {assembly.FullName}");

                return true;
            }

            foreach (var type in assembly.GetTypes())
            {
                if (!type.IsSubclassOf(typeof(NukeBuild)))
                {
                    continue;
                }

                result = IsDefined(type, typeof(NoBuildBannerAttribute));

                if (result)
                {
                    Log.Verbose($"NoBuildBannerAttribute: Found on type {type.FullName}");

                    return true;
                }

                Log.Verbose($"NoBuildBannerAttribute: Not found on type {type.FullName}");
            }

            Log.Verbose($"NoBuildBannerAttribute: Not found on assembly {assembly.FullName}");
        }

        return false;
    }
}
