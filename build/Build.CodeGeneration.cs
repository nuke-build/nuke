// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using JetBrains.Annotations;
using Nuke.CodeGeneration.Model;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Utilities.Collections;
using static Nuke.CodeGeneration.CodeGenerator;
using static Nuke.CodeGeneration.ReferenceUpdater;
using static Nuke.CodeGeneration.SchemaGenerator;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.Git.GitTasks;

partial class Build
{
    AbsolutePath SpecificationsDirectory => RootDirectory / "source" / "Nuke.Common" / "Tools";
    string ReferencesDirectory => BuildProjectDirectory / "references";
    string ToolSchemaFile => SourceDirectory / "Nuke.CodeGeneration" / "schema.json";

    Target References => _ => _
        .Requires(() => GitHasCleanWorkingCopy())
        .Executes(() =>
        {
            EnsureCleanDirectory(ReferencesDirectory);

            UpdateReferences(SpecificationsDirectory, ReferencesDirectory);
        });

    [UsedImplicitly]
    Target GenerateTools => _ => _
        .Executes(() =>
        {
            GenerateSchema<Tool>(
                ToolSchemaFile,
                GitRepository.GetGitHubDownloadUrl(ToolSchemaFile, MasterBranch),
                "Tool specification schema file by NUKE");

            SpecificationsDirectory.GlobFiles("*/*.json").ForEach(x =>
                GenerateCode(
                    x,
                    namespaceProvider: x => $"Nuke.Common.Tools.{x.Name}",
                    sourceFileProvider: x => GitRepository.SetBranch(MasterBranch).GetGitHubBrowseUrl(x.SpecificationFile)));
        });
}
