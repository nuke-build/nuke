// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Nuke.GlobalTool.Rewriting.Cake;
using static Nuke.Common.Constants;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.Tooling.NuGetPackageResolver;

namespace Nuke.GlobalTool
{
    partial class Program
    {
        public const string CAKE_FILE_PATTERN = "*.cake";

        [UsedImplicitly]
        public static int CakeConvert(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            Logger.Warn(
                new[]
                {
                    "Converting .cake files is a best effort approach using syntax rewriting.",
                    "Compile errors are to be expected, however, the following elements are currently covered:",
                    "  - Target definitions",
                    "  - Default targets",
                    "  - Parameter declarations",
                    "  - Absolute paths",
                    "  - Globbing patterns",
                    "  - Tool invocations (dotnet CLI, SignTool)",
                    "  - Addin and tool references",
                }.JoinNewLine());

            Logger.Normal();
            if (!UserConfirms("Continue?"))
                return 0;
            Logger.Normal();

            if (buildScript == null &&
                UserConfirms("Should a NUKE project be created for better results?"))
            {
                Setup(args, rootDirectory: null, buildScript: null);
            }

            var buildProjectFile = File.Exists(WorkingDirectory / CurrentBuildScriptName)
                ? GetConfiguration(WorkingDirectory / CurrentBuildScriptName, evaluate: true)
                    .GetValueOrDefault(BUILD_PROJECT_FILE, defaultValue: null)
                : null;

            string GetOutputDirectory(string file)
                => Path.GetDirectoryName(buildProjectFile ?? file);

            string GetOutputFile(string file)
                => (AbsolutePath) GetOutputDirectory(file) / Path.GetFileNameWithoutExtension(file).Capitalize() + ".cs";

            GetCakeFiles().ForEach(x => File.WriteAllText(path: GetOutputFile(x), contents: GetCakeConvertedContent(File.ReadAllText(x))));

            if (buildProjectFile != null)
            {
                GetCakeFiles().SelectMany(x => GetCakePackages(File.ReadAllText(x)))
                    .ForEach(x => AddOrReplacePackage(x.PackageId, x.PackageVersion, x.PackageType, buildProjectFile));
            }

            return 0;
        }

        [UsedImplicitly]
        public static int CakeClean(string[] args, [CanBeNull] AbsolutePath rootDirectory, [CanBeNull] AbsolutePath buildScript)
        {
            var cakeFiles = GetCakeFiles().ToList();
            Logger.Info("Found .cake files:");
            cakeFiles.ForEach(x => Logger.Normal($"  - {x}"));

            if (UserConfirms("Delete?"))
                cakeFiles.ForEach(FileSystemTasks.DeleteFile);

            return 0;
        }

        private static IEnumerable<AbsolutePath> GetCakeFiles()
        {
            return (TryGetRootDirectoryFrom(WorkingDirectory) ?? WorkingDirectory).GlobFiles($"**/{CAKE_FILE_PATTERN}");
        }

        internal static string GetCakeConvertedContent(string content)
        {
            var options = new CSharpParseOptions(LanguageVersion.Latest, DocumentationMode.None, SourceCodeKind.Script);
            var syntaxTree = CSharpSyntaxTree.ParseText(content, options);
            return new CSharpSyntaxRewriter[]
                   {
                       new RemoveUsingDirectivesRewriter(),
                       new RenameFieldIdentifierRewriter(),
                       new ParameterRewriter(),
                       new AbsolutePathRewriter(),
                       new RegularFieldRewriter(),
                       new TargetDefinitionRewriter(),
                       new InvocationRewriter(),
                       new MemberAccessRewriter(),
                       new IdentifierNameRewriter(),
                       new ToolInvocationRewriter(),
                       new ClassRewriter(),
                       new FormattingRewriter()
                   }.Aggregate(syntaxTree.GetRoot(), (root, rewriter) => rewriter.Visit(root.NormalizeWhitespace(elasticTrivia: true)))
                .ToFullString();
        }

        internal static IEnumerable<(string PackageType, string PackageId, string PackageVersion)> GetCakePackages(string content)
        {
            IEnumerable<(string PackageType, string PackageId, string PackageVersion)> GetPackages(
                string packageType,
                [RegexPattern] string regexPattern)
            {
                var regex = new Regex(regexPattern);
                foreach (Match match in regex.Matches(content))
                {
                    var packageId = match.Groups["packageId"].Value;
                    var packageVersion = match.Groups["version"].Value;
                    if (packageVersion.IsNullOrEmpty())
                        packageVersion = GetLatestPackageVersion(packageId, includePrereleases: false, timeout: 10_000).GetAwaiter().GetResult();
                    yield return new(packageType, packageId, packageVersion);
                }
            }

            return GetPackages(PACKAGE_TYPE_DOWNLOAD, @"#tool ""nuget:\?package=(?'packageId'[\w\d\.]+)(&version=(?'version'[\w\d\.]+))?S*""")
                .Concat(GetPackages(PACKAGE_TYPE_REFERENCE, @"#addin ""nuget:\?package=(?'packageId'[\w\d\.]+)(&version=(?'version'[\w\d\.]+))?S*"""))
                .Where(x => !x.PackageId.ContainsOrdinalIgnoreCase("Cake"));
        }
    }
}
