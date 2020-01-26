// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Utilities
{
    public static class ResourceUtility
    {
        public static string GetResourceAllText<T>(string postfix)
        {
            return new StreamReader(GetResource<T>(postfix)).ReadToEnd();
        }

        public static string[] GetResourceAllLines<T>(string postfix)
        {
            var lines = new List<string>();

            using (var streamReader = new StreamReader(GetResource<T>(postfix)))
            {
                while (!streamReader.EndOfStream)
                {
                    lines.Add(streamReader.ReadLine());
                }
            }

            return lines.ToArray();
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
                .NotNull($"Resource '{fullResourceName}' not found. Available resources are:"
                    .Concat(assembly.GetManifestResourceNames().Select(x => $"  - {x}"))
                    .JoinNewLine());
        }
    }
}
