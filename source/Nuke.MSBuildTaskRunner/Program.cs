// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Nuke.CodeGeneration;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.IO.PathConstruction;

namespace Nuke.MSBuildTaskRunner
{
    public class Program
    {
        [Parameter] static bool Debug;

        [Parameter] static TaskAction Action;
        [Parameter(Separator = ";")] static AbsolutePath[] Files;
        [Parameter] static string ProjectAssetsFile;
        [Parameter] static string NuGetPackageRoot;
        [Parameter] static string TargetFramework;

        public static int Main()
        {
            InjectionUtility.InjectValues<Program>();

            if (Debug)
            {
                Warning("Waiting for debugger to attach...");
                SpinWait.SpinUntil(() => Debugger.IsAttached);
            }

            try
            {
                switch (Action)
                {
                    case TaskAction.CodeGeneration:
                        CodeGenerator.GenerateCode(Files.Select(x => x.ToString()).ToList());
                        break;
                    case TaskAction.ExternalFilesDownload:
                        var results = Files.Select(x => x.ToString()).Select(DownloadExternalFiles).ToList();
                        ControlFlow.Assert(results.All(x => x.Result), "results.All(x => x.Result)");
                        break;
                    case TaskAction.GlobalToolPackaging:
                        GetAdditionalPackageFiles().ForEach(x => Console.WriteLine(x));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(Action));
                }

                return 0;
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return -1;
            }
        }

        private static void Error(string text)
        {
            Console.Error.WriteLine($"error: {text}");
        }

        private static void Warning(string text)
        {
            Console.WriteLine($"warning: {text}");
        }

        private static async Task<bool> DownloadExternalFiles(string sharedFile)
        {
            try
            {
                var lines = File.ReadAllLines(sharedFile).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                var uriConversion = Uri.TryCreate(lines.FirstOrDefault(), UriKind.Absolute, out var uri);
                ControlFlow.Assert(uriConversion, $"Could not parse URI from first line of '{sharedFile}'.");

                var outputFile = sharedFile.Substring(startIndex: 0, length: sharedFile.Length - 4);
                var previousHash = File.Exists(outputFile) ? FileSystemTasks.GetFileHash(outputFile) : null;

                var template = (await HttpTasks.HttpDownloadStringAsync(uri.OriginalString)).SplitLineBreaks();
                var replacements = lines.Skip(1)
                    .Where(x => x.Contains('='))
                    .Select(x => x.Split('='))
                    .Where(x => x.Length == 2)
                    .ToDictionary(
                        x => $"_{x.First().Trim('_').ToUpperInvariant()}_",
                        x => x.ElementAt(1));
                var definitions = lines.Skip(1)
                    .Where(x => !x.Contains('=') && !string.IsNullOrWhiteSpace(x))
                    .Select(x => x.ToUpperInvariant())
                    .ToList();

                File.WriteAllLines(outputFile, TemplateUtility.FillTemplate(template, definitions, replacements));
                var newHash = FileSystemTasks.GetFileHash(outputFile);

                if (newHash != previousHash)
                    Warning($"External file '{outputFile}' has been updated.");

                return true;
            }
            catch (Exception exception)
            {
                Error(exception.Message);
                return false;
            }
        }

        private static IEnumerable<string> GetAdditionalPackageFiles()
        {
            var assetFileContent = File.ReadAllText(ProjectAssetsFile);
            var reader = JsonReaderWriterFactory.CreateJsonReader(
                Encoding.UTF8.GetBytes(assetFileContent),
                new XmlDictionaryReaderQuotas());

            var root = XElement.Load(reader);
            var packages = root.XPathSelectElements("//libraries/*/path")
                .Select(x => x.Value.Split(new[] { "/" }, StringSplitOptions.None))
                .Select(x => new
                             {
                                 Id = x[0],
                                 Version = x[1]
                             })
                .Select(x => new
                             {
                                 x.Id,
                                 Directory = Path.Combine(NuGetPackageRoot, x.Id, x.Version, "tools")
                             }).ToList();

            var files = packages
                .Where(x => Directory.Exists(x.Directory))
                .SelectMany(
                    x => Directory.GetFiles(x.Directory, "*", SearchOption.AllDirectories),
                    (x, f) => new
                              {
                                  x.Id,
                                  AbsolutePath = f,
                                  PackageRelativePath = GetRelativePath(x.Directory, f)
                              }).ToList();

            foreach (var file in files)
            {
                var packagePath = Path.Combine("tools",
                    TargetFramework,
                    "any",
                    file.Id,
                    file.PackageRelativePath);

                yield return $"{file.AbsolutePath}@{packagePath}";
            }
        }
    }
}
