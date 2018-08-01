// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using Nuke.CodeGeneration.Model;
using Nuke.Common;
using Nuke.Common.Git;
using static Nuke.CodeGeneration.CodeGenerator;
using static Nuke.CodeGeneration.ReferenceUpdater;
using static Nuke.CodeGeneration.SchemaGenerator;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.Git.GitTasks;

partial class Build
{
    string SpecificationsDirectory => BuildProjectDirectory / "specifications";
    string ReferencesDirectory => BuildProjectDirectory / "references";
    string GenerationDirectory => RootDirectory / "source" / "Nuke.Common" / "Tools";
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
                GenerationDirectory,
                baseNamespace: "Nuke.Common.Tools",
                useNestedNamespaces: true,
                gitRepository: GitRepository.SetBranch(MasterBranch));
        });
}
