// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;
using Serilog;

namespace Nuke.Common.IO
{
    public enum DirectoryExistsPolicy
    {
        Fail,
        Merge
    }

    public enum FileExistsPolicy
    {
        Fail,
        Skip,
        Overwrite,
        OverwriteIfNewer
    }

    [PublicAPI]
    public static class FileSystemTasks
    {
        public static bool IsDotDirectory(DirectoryInfo directory)
        {
            return directory.Name.StartsWith(".");
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePath.Parent)}.{nameof(AbsolutePathExtensions.CreateDirectory)}")]
        [CodeTemplate(
            searchTemplate: "EnsureExistingParentDirectory($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.Parent.CreateDirectory()",
            ReplaceMessage = "Replace with $expr$.Parent.CreateDirectory()",
            Message = $"WARNING: {nameof(EnsureExistingParentDirectory)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "FileSystemTasks.EnsureExistingParentDirectory($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.Parent.CreateDirectory()",
            ReplaceMessage = "Replace with $expr$.Parent.CreateDirectory()",
            Message = $"WARNING: {nameof(EnsureExistingParentDirectory)} is obsolete")]
        public static void EnsureExistingParentDirectory(AbsolutePath file)
        {
            EnsureExistingParentDirectory((string) file);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePath.Parent)}.{nameof(AbsolutePathExtensions.CreateDirectory)}")]
        public static void EnsureExistingParentDirectory(string file)
        {
            EnsureExistingDirectory(Path.GetDirectoryName(file).NotNull($"Path.GetDirectoryName({file}) != null"));
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.CreateDirectory)}")]
        [CodeTemplate(
            searchTemplate: "EnsureExistingDirectory($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.CreateDirectory()",
            ReplaceMessage = "Replace with $expr$.CreateDirectory()",
            Message = $"WARNING: {nameof(EnsureExistingDirectory)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "FileSystemTasks.EnsureExistingDirectory($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.CreateDirectory()",
            ReplaceMessage = "Replace with $expr$.CreateDirectory()",
            Message = $"WARNING: {nameof(EnsureExistingDirectory)} is obsolete")]
        public static void EnsureExistingDirectory(AbsolutePath directory)
        {
            EnsureExistingDirectory((string) directory);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.CreateDirectory)}")]
        public static void EnsureExistingDirectory(string directory)
        {
            if (Directory.Exists(directory))
                return;

            Log.Information("Creating directory {Directory}...", directory);
            Directory.CreateDirectory(directory);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.CreateOrCleanDirectory)}")]
        [CodeTemplate(
            searchTemplate: "EnsureCleanDirectory($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.CreateOrCleanDirectory()",
            ReplaceMessage = "Replace with $expr$.CreateOrCleanDirectory()",
            Message = $"WARNING: {nameof(EnsureCleanDirectory)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "FileSystemTasks.EnsureCleanDirectory($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.CreateOrCleanDirectory()",
            ReplaceMessage = "Replace with $expr$.CreateOrCleanDirectory()",
            Message = $"WARNING: {nameof(EnsureCleanDirectory)} is obsolete")]
        public static void EnsureCleanDirectory(AbsolutePath directory)
        {
            EnsureCleanDirectory((string) directory);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.CreateOrCleanDirectory)}")]
        public static void EnsureCleanDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                Log.Information("Cleaning directory {Directory}...", directory);
                Directory.GetFiles(directory).ForEach(DeleteFileInternal);
                Directory.GetDirectories(directory).ForEach(DeleteDirectoryInternal);
            }
            else
            {
                EnsureExistingDirectory(directory);
            }
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.DeleteDirectory)}")]
        [CodeTemplate(
            searchTemplate: "DeleteDirectory($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.DeleteDirectory()",
            ReplaceMessage = "Replace with $expr$.DeleteDirectory()",
            Message = $"WARNING: {nameof(DeleteDirectory)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "FileSystemTasks.DeleteDirectory($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.DeleteDirectory()",
            ReplaceMessage = "Replace with $expr$.DeleteDirectory()",
            Message = $"WARNING: {nameof(DeleteDirectory)} is obsolete")]
        public static void DeleteDirectory(AbsolutePath directory)
        {
            DeleteDirectory((string) directory);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.DeleteDirectory)}")]
        public static void DeleteDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                return;

            Log.Information("Deleting directory {Directory}...", directory);
            DeleteDirectoryInternal(directory);
        }

        private static void DeleteDirectoryInternal(string directory)
        {
            if (!Directory.Exists(directory))
                return;

            // Check if directory is not a symlink
            if (!File.GetAttributes(directory).HasFlag(FileAttributes.ReparsePoint))
            {
                Directory.GetFiles(directory).ForEach(DeleteFileInternal);
                Directory.GetDirectories(directory).ForEach(DeleteDirectoryInternal);
            }

            Log.Verbose("Deleting directory {Directory}...", directory);
            Directory.Delete(directory, recursive: false);
        }

        private static void DeleteFileInternal(string file)
        {
            Log.Verbose("Deleting file {File}...", file);
            EnsureFileAttributes(file);
            File.Delete(file);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.DeleteFile)}")]
        [CodeTemplate(
            searchTemplate: "DeleteFile($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.DeleteFile()",
            ReplaceMessage = "Replace with $expr$.DeleteFile()",
            Message = $"WARNING: {nameof(DeleteFile)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "FileSystemTasks.DeleteFile($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.DeleteFile()",
            ReplaceMessage = "Replace with $expr$.DeleteFile()",
            Message = $"WARNING: {nameof(DeleteFile)} is obsolete")]
        public static void DeleteFile(AbsolutePath file)
        {
            DeleteFile((string) file);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.DeleteFile)}")]
        public static void DeleteFile(string file)
        {
            if (!File.Exists(file))
                return;

            Log.Information("Deleting file {File}...", file);
            EnsureFileAttributes(file);
            File.Delete(file);
        }

        public static void CopyFile(AbsolutePath source, AbsolutePath target, FileExistsPolicy policy = FileExistsPolicy.Fail, bool createDirectories = true)
        {
            if (!ShouldCopyFile(source, target, policy))
                return;

            if (createDirectories)
                target.Parent.CreateDirectory();

            Log.Information("Copying file {Source} to {Target}...", source, target);
            File.Copy(source, target, overwrite: true);
        }

        public static void CopyFileToDirectory(
            AbsolutePath source,
            AbsolutePath targetDirectory,
            FileExistsPolicy policy = FileExistsPolicy.Fail,
            bool createDirectories = true)
        {
            CopyFile(source, Path.Combine(targetDirectory, Path.GetFileName(source).NotNull()), policy, createDirectories);
        }

        public static void MoveFile(AbsolutePath source, AbsolutePath target, FileExistsPolicy policy = FileExistsPolicy.Fail, bool createDirectories = true)
        {
            if (!ShouldCopyFile(source, target, policy))
                return;

            if (createDirectories)
                target.Parent.CreateDirectory();

            Log.Information("Moving file from {Source} to {Target}...", source, target);
            if (File.Exists(target))
                File.Delete(target);

            File.Move(source, target);
        }

        public static void MoveFileToDirectory(
            AbsolutePath source,
            AbsolutePath targetDirectory,
            FileExistsPolicy policy = FileExistsPolicy.Fail,
            bool createDirectories = true)
        {
            MoveFile(source, Path.Combine(targetDirectory, Path.GetFileName(source).NotNull()), policy, createDirectories);
        }

        public static void RenameFile(AbsolutePath file, string newName, FileExistsPolicy policy = FileExistsPolicy.Fail)
        {
            if (Path.GetFileName(file) == newName)
                return;

            MoveFile(file, Path.Combine(Path.GetDirectoryName(file).NotNull(), newName), policy);
        }

        public static void MoveDirectory(
            AbsolutePath source,
            AbsolutePath target,
            DirectoryExistsPolicy directoryPolicy = DirectoryExistsPolicy.Fail,
            FileExistsPolicy filePolicy = FileExistsPolicy.Fail,
            bool deleteRemainingFiles = false)
        {
            Assert.True(!Directory.Exists(target) || directoryPolicy != DirectoryExistsPolicy.Fail);
            Log.Information("Moving directory from {Source} to {Target}...", source, target);
            if (!Directory.Exists(target))
            {
                Directory.Move(source, target);
            }
            else
            {
                Directory.GetDirectories(source).ForEach(x => MoveDirectoryToDirectory(x, target, directoryPolicy, filePolicy));
                Directory.GetFiles(source).ForEach(x => MoveFileToDirectory(x, target, filePolicy));

                if (!new DirectoryInfo(source).EnumerateFileSystemInfos().Any() || deleteRemainingFiles)
                    DeleteDirectoryInternal(source);
            }
        }

        public static void MoveDirectoryToDirectory(
            AbsolutePath source,
            AbsolutePath targetDirectory,
            DirectoryExistsPolicy directoryPolicy = DirectoryExistsPolicy.Fail,
            FileExistsPolicy filePolicy = FileExistsPolicy.Fail)
        {
            MoveDirectory(source, Path.Combine(targetDirectory, new DirectoryInfo(source).Name), directoryPolicy, filePolicy);
        }

        public static void RenameDirectory(
            string directory,
            string newName,
            DirectoryExistsPolicy directoryPolicy = DirectoryExistsPolicy.Fail,
            FileExistsPolicy filePolicy = FileExistsPolicy.Fail)
        {
            MoveDirectory(directory, Path.Combine(Path.GetDirectoryName(directory).NotNull(), newName), directoryPolicy, filePolicy);
        }

        public static void CopyDirectoryRecursively(
            AbsolutePath source,
            AbsolutePath target,
            DirectoryExistsPolicy directoryPolicy = DirectoryExistsPolicy.Fail,
            FileExistsPolicy filePolicy = FileExistsPolicy.Fail,
            Func<DirectoryInfo, bool> excludeDirectory = null,
            Func<FileInfo, bool> excludeFile = null)
        {
            Assert.DirectoryExists(source);
            Assert.False(PathConstruction.IsDescendantPath(source, target),
                $"Target directory '{target}' must not be in source directory '{source}'");
            //ControlFlow.Assert(!Contains(source, target), $"Target '{target}' is not contained in source '{source}'.");

            Log.Information("Recursively copying from {Source} to {Target}...", source, target);
            CopyRecursivelyInternal(source, target, directoryPolicy, filePolicy, excludeDirectory, excludeFile);
        }

        private static void CopyRecursivelyInternal(
            AbsolutePath source,
            AbsolutePath target,
            DirectoryExistsPolicy directoryPolicy,
            FileExistsPolicy filePolicy,
            [CanBeNull] Func<DirectoryInfo, bool> excludeDirectory,
            [CanBeNull] Func<FileInfo, bool> excludeFile)
        {
            if (excludeDirectory != null && excludeDirectory(new DirectoryInfo(source)))
                return;

            Assert.True(!Directory.Exists(target) || directoryPolicy != DirectoryExistsPolicy.Fail);

            string GetDestinationPath(string path)
                => Path.Combine(target, PathConstruction.GetRelativePath(source, path));

            Directory.CreateDirectory(target);
            foreach (var sourceFile in Directory.GetFiles(source))
            {
                if (excludeFile != null && excludeFile(new FileInfo(sourceFile)))
                    continue;

                var targetFile = GetDestinationPath(sourceFile);
                if (!ShouldCopyFile(sourceFile, targetFile, filePolicy))
                    continue;

                //EnsureFileAttributes(sourceFile);
                File.Copy(sourceFile, targetFile, overwrite: true);
            }

            Directory.GetDirectories(source)
                .ForEach(x => CopyRecursivelyInternal(
                    x,
                    GetDestinationPath(x),
                    directoryPolicy,
                    filePolicy,
                    excludeDirectory,
                    excludeFile));
        }

        private static bool ShouldCopyFile(AbsolutePath sourceFile, AbsolutePath targetFile, FileExistsPolicy policy)
        {
            if (!File.Exists(targetFile))
                return true;

            return policy switch
            {
                FileExistsPolicy.Fail => throw new Exception($"File '{targetFile}' already exists."),
                FileExistsPolicy.Skip => false,
                FileExistsPolicy.Overwrite => true,
                FileExistsPolicy.OverwriteIfNewer => File.GetLastWriteTimeUtc(targetFile) < File.GetLastWriteTimeUtc(sourceFile),
                _ => throw new ArgumentOutOfRangeException(nameof(policy), policy, message: null)
            };
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.TouchFile)}")]
        [CodeTemplate(
            searchTemplate: "Touch($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.TouchFile()",
            ReplaceMessage = "Replace with $expr$.TouchFile()",
            Message = $"WARNING: {nameof(Touch)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "FileSystemTasks.Touch($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.TouchFile()",
            ReplaceMessage = "Replace with $expr$.TouchFile()",
            Message = $"WARNING: {nameof(Touch)} is obsolete")]
        public static void Touch(AbsolutePath path, DateTime? time = null, bool createDirectories = true)
        {
            Log.Information("Touching file {Path}...", path);
            path.TouchFile();
        }

        private static void EnsureFileAttributes(string file)
        {
            File.SetAttributes(file, FileAttributes.Normal);
        }

        /// <summary>
        /// Returns the time the file or directory was last written to. For directories, the latest time for the whole content is returned.
        /// </summary>
        public static DateTime GetLastWriteTimeUtc(string path)
        {
            Assert.True(Directory.Exists(path) || File.Exists(path));

            return Directory.Exists(path)
                ? new DirectoryInfo(path)
                    .GetFileSystemInfos("*", SearchOption.AllDirectories)
                    .Max(x => x.LastWriteTimeUtc)
                : File.GetLastWriteTimeUtc(path);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.FindParentOrSelf)}")]
        [CodeTemplate(
            searchTemplate: "FindParentDirectory($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.FindParentOrSelf($args$)",
            ReplaceMessage = "Replace with $expr$.FindParentOrSelf($args$)",
            Message = $"WARNING: {nameof(FindParentDirectory)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "FileSystemTasks.FindParentDirectory($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.FindParentOrSelf($args$)",
            ReplaceMessage = "Replace with $expr$.FindParentOrSelf($args$)",
            Message = $"WARNING: {nameof(FindParentDirectory)} is obsolete")]
        [CanBeNull]
        public static string FindParentDirectory(string start, Func<DirectoryInfo, bool> predicate)
        {
            return ((AbsolutePath)start).FindParentOrSelf(x => predicate.Invoke(x.ToDirectoryInfo()));
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.FindParentOrSelf)}")]
        [CanBeNull]
        public static DirectoryInfo FindParentDirectory(DirectoryInfo start, Func<DirectoryInfo, bool> predicate)
        {
            return ((AbsolutePath)start.FullName).FindParentOrSelf(x => predicate.Invoke(x.ToDirectoryInfo())).ToDirectoryInfo();
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.GetFileHash)}")]
        [CodeTemplate(
            searchTemplate: "GetFileHash($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.GetFileHash()",
            ReplaceMessage = "Replace with $expr$.GetFileHash()",
            Message = $"WARNING: {nameof(GetFileHash)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "FileSystemTasks.GetFileHash($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.GetFileHash()",
            ReplaceMessage = "Replace with $expr$.GetFileHash()",
            Message = $"WARNING: {nameof(GetFileHash)} is obsolete")]
        public static string GetFileHash(string file)
        {
            return ((AbsolutePath)file).GetFileHash();
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.GetDirectoryHash)}")]
        [CodeTemplate(
            searchTemplate: "GetDirectoryHash($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.GetDirectoryHash()",
            ReplaceMessage = "Replace with $expr$.GetDirectoryHash()",
            Message = $"WARNING: {nameof(GetDirectoryHash)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "FileSystemTasks.GetDirectoryHash($expr{'Nuke.Common.IO.AbsolutePath', true}$)",
            ReplaceTemplate = "$expr$.GetDirectoryHash()",
            ReplaceMessage = "Replace with $expr$.GetDirectoryHash()",
            Message = $"WARNING: {nameof(GetDirectoryHash)} is obsolete")]
        public static string GetDirectoryHash(string directory, params string[] fileGlobPatterns)
        {
            return fileGlobPatterns.Length == 0
                ? ((AbsolutePath)directory).GetDirectoryHash()
                : ((AbsolutePath)directory).GlobFiles(fileGlobPatterns).GetFileSetHash(directory);
        }
    }
}
