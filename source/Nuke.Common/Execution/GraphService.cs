// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Nuke.Common.Execution
{
    internal static class GraphService
    {
        public static void ShowGraph<T>(T build)
            where T : NukeBuild
        {
            string GetStringFromStream(Stream stream)
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }

            var assembly = typeof(BuildExecutor).GetTypeInfo().Assembly;
            var resourceName = typeof(BuildExecutor).Namespace + ".graph.html";
            var resourceStream = assembly.GetManifestResourceStream(resourceName).NotNull("resourceStream != null");

            var graph = new StringBuilder();
            foreach (var target in build.TargetDefinitions)
            {
                var dependendBy = build.TargetDefinitions.Where(x => x.TargetDefinitionDependencies.Contains(target)).ToList();
                if (dependendBy.Count == 0)
                    graph.AppendLine(target.Name);
                else
                    dependendBy.ForEach(x => graph.AppendLine($"{target.Name} --> {x.Name}"));
            }

            var path = Path.Combine(build.TemporaryDirectory, "graph.html");
            var contents = GetStringFromStream(resourceStream).Replace("__GRAPH__", graph.ToString());
            File.WriteAllText(path, contents);

            // Workaround for https://github.com/dotnet/corefx/issues/10361
            Process.Start(new ProcessStartInfo
                          {
                              FileName = path,
                              UseShellExecute = true
                          });
        }
    }
}
