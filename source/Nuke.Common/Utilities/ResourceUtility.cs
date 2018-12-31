// Copyright 2018 Maintainers and Contributors of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Nuke.Common.Utilities
{
    public static class ResourceUtility
    {
        public static string GetResourceText<T>(string postfix)
        {
            return new StreamReader(GetResource<T>(postfix)).ReadToEnd();
        }

        public static Stream GetResource<T>(string postfix)
        {
            return GetResource(typeof(T), postfix);
        }

        public static Stream GetResource(Type typeForNamespace, string postfix)
        {
            var fullResourceName = $"{typeForNamespace.Namespace}.{postfix}";
            var assembly = typeForNamespace.GetTypeInfo().Assembly;
            return assembly.GetManifestResourceStream(fullResourceName)
                .NotNull(new[] { $"Resource '{fullResourceName}' not found. Available resources are:" }
                    .Concat(assembly.GetManifestResourceNames().Select(x => $"  - {x}"))
                    .JoinNewLine());
        }
    }
}
