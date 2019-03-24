// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.CodeGeneration.Model;
using Nuke.Common;
using Nuke.Common.Git;
using static Nuke.CodeGeneration.CodeGenerator;
using static Nuke.CodeGeneration.ReferenceUpdater;
using static Nuke.CodeGeneration.SchemaGenerator;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.Git.GitTasks;

partial class Build
{
    string SpecificationsDirectory => BuildProjectDirectory / "specifications";
    string ReferencesDirectory => BuildProjectDirectory / "references";
    AbsolutePath GenerationDirectory => RootDirectory / "source" / "Nuke.Common" / "Tools";
    string ToolSchemaFile => SourceDirectory / "Nuke.CodeGeneration" / "schema.json";

    Target References => _ => _
        .Requires(() => GitHasCleanWorkingCopy())
        .Executes(() =>
        {
            EnsureCleanDirectory(ReferencesDirectory);

            UpdateReferences(SpecificationsDirectory, ReferencesDirectory);
        });

    Target Generate => _ => _
        .Executes(() =>
        {
            GenerateSchema<Tool>(
                ToolSchemaFile,
                GitRepository.GetGitHubDownloadUrl(ToolSchemaFile, MasterBranch),
                "Tool specification schema file by NUKE");

            GenerateCode(
                SpecificationsDirectory,
                outputFileProvider: x => GenerationDirectory / x.Name / x.DefaultOutputFileName,
                namespaceProvider: x => $"Nuke.Common.Tools.{x.Name}",
                sourceFileProvider: x => GitRepository.SetBranch(MasterBranch).GetGitHubBrowseUrl(x.SpecificationFile));
        });
}
