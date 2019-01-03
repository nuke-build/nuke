// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Nuke.Common.Execution
{
    internal static class GraphService
    {
        public static void ShowGraph(IReadOnlyCollection<ExecutableTarget> executableTargets)
        {
            string GetStringFromStream(Stream stream)
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }

            var assembly = typeof(BuildManager).GetTypeInfo().Assembly;
            var resourceName = typeof(BuildManager).Namespace + ".graph.html";
            var resourceStream = assembly.GetManifestResourceStream(resourceName).NotNull("resourceStream != null");

            var graph = new StringBuilder();
            foreach (var executableTarget in executableTargets)
            {
                var dependentBy = executableTargets.Where(x => x.AllDependencies.Contains(executableTarget)).ToList();
                if (dependentBy.Count == 0)
                    graph.AppendLine(executableTarget.GetDeclaration());
                else
                    dependentBy.ForEach(x => graph.AppendLine($"{executableTarget.GetDeclaration()} --> {x.GetDeclaration()}"));
            }

            var path = Path.Combine(NukeBuild.TemporaryDirectory, "graph.html");
            var contents = GetStringFromStream(resourceStream).Replace("__GRAPH__", graph.ToString());
            File.WriteAllText(path, contents);

            // Workaround for https://github.com/dotnet/corefx/issues/10361
            Process.Start(new ProcessStartInfo
                          {
                              FileName = path,
                              UseShellExecute = true
                          });
        }

        private static string GetDeclaration(this ExecutableTarget executableTarget)
        {
            return executableTarget.IsDefault
                ? $"defaultTarget[{executableTarget.Name}]"
                : executableTarget.Name;
        }
    }
}
