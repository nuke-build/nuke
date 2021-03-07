// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

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

        public static bool FileExists(AbsolutePath path)
        {
            return File.Exists(path);
        }

        public static bool DirectoryExists(AbsolutePath path)
        {
            return Directory.Exists(path);
        }

        public static void EnsureExistingParentDirectory(AbsolutePath file)
        {
            EnsureExistingParentDirectory((string) file);
        }

        public static void EnsureExistingParentDirectory(string file)
        {
            EnsureExistingDirectory(Path.GetDirectoryName(file).NotNull($"Path.GetDirectoryName({file}) != null"));
        }

        public static void EnsureExistingDirectory(AbsolutePath directory)
        {
            EnsureExistingDirectory((string) directory);
        }

        public static void EnsureExistingDirectory(string directory)
        {
            if (Directory.Exists(directory))
                return;

            Logger.Info($"Creating directory '{directory}'...");
            Directory.CreateDirectory(directory);
        }

        public static void EnsureCleanDirectory(AbsolutePath directory)
        {
            EnsureCleanDirectory((string) directory);
        }

        public static void EnsureCleanDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                Logger.Info($"Cleaning directory '{directory}'...");
                Directory.GetFiles(directory).ForEach(DeleteFileInternal);
                Directory.GetDirectories(directory).ForEach(DeleteDirectoryInternal);
            }
            else
            {
                EnsureExistingDirectory(directory);
            }
        }

        public static void DeleteDirectory(AbsolutePath directory)
        {
            DeleteDirectory((string) directory);
        }

        public static void DeleteDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                return;

            Logger.Info($"Deleting directory '{directory}'...");
            DeleteDirectoryInternal(directory);
        }

        private static void DeleteDirectoryInternal(string directory)
        {
            if (!Directory.Exists(directory))
                return;

            Directory.GetFiles(directory).ForEach(DeleteFileInternal);
            Directory.GetDirectories(directory).ForEach(DeleteDirectoryInternal);

            Logger.Trace($"Deleting directory '{directory}'...");
            Directory.Delete(directory, recursive: false);
        }

        private static void DeleteFileInternal(string file)
        {
            Logger.Trace($"Deleting file '{file}'...");
            EnsureFileAttributes(file);
            File.Delete(file);
        }

        public static void DeleteFile(AbsolutePath file)
        {
            DeleteFile((string) file);
        }

        public static void DeleteFile(string file)
        {
            if (!File.Exists(file))
                return;

            Logger.Info($"Deleting file '{file}'...");
            EnsureFileAttributes(file);
            File.Delete(file);
        }

        public static void CopyFile(string source, string target, FileExistsPolicy policy = FileExistsPolicy.Fail, bool createDirectories = true)
        {
            if (!ShouldCopyFile(source, target, policy))
                return;

            if (createDirectories)
                EnsureExistingParentDirectory(target);

            Logger.Info($"Copying file '{source}' to '{target}'...");
            File.Copy(source, target, overwrite: true);
        }

        public static void CopyFileToDirectory(
            string source,
            string targetDirectory,
            FileExistsPolicy policy = FileExistsPolicy.Fail,
            bool createDirectories = true)
        {
            CopyFile(source, Path.Combine(targetDirectory, Path.GetFileName(source).NotNull()), policy, createDirectories);
        }

        public static void MoveFile(string source, string target, FileExistsPolicy policy = FileExistsPolicy.Fail, bool createDirectories = true)
        {
            if (!ShouldCopyFile(source, target, policy))
                return;

            if (createDirectories)
                EnsureExistingParentDirectory(target);

            Logger.Info($"Moving file from '{source}' to '{target}'...");
            if (File.Exists(target))
                File.Delete(target);

            File.Move(source, target);
        }

        public static void MoveFileToDirectory(
            string source,
            string targetDirectory,
            FileExistsPolicy policy = FileExistsPolicy.Fail,
            bool createDirectories = true)
        {
            MoveFile(source, Path.Combine(targetDirectory, Path.GetFileName(source).NotNull()), policy, createDirectories);
        }

        public static void RenameFile(string file, string newName, FileExistsPolicy policy = FileExistsPolicy.Fail)
        {
            if (Path.GetFileName(file) == newName)
                return;

            MoveFile(file, Path.Combine(Path.GetDirectoryName(file).NotNull(), newName), policy);
        }

        public static void MoveDirectory(
            string source,
            string target,
            DirectoryExistsPolicy directoryPolicy = DirectoryExistsPolicy.Fail,
            FileExistsPolicy filePolicy = FileExistsPolicy.Fail,
            bool deleteRemainingFiles = false)
        {
            ControlFlow.Assert(!Directory.Exists(target) || directoryPolicy != DirectoryExistsPolicy.Fail,
                $"!Directory.Exists({target}) || policy != DirectoryExistsPolicy.Fail");

            Logger.Info($"Moving directory from '{source}' to '{target}'...");
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
            string source,
            string targetDirectory,
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
            string source,
            string target,
            DirectoryExistsPolicy directoryPolicy = DirectoryExistsPolicy.Fail,
            FileExistsPolicy filePolicy = FileExistsPolicy.Fail,
            Func<DirectoryInfo, bool> excludeDirectory = null,
            Func<FileInfo, bool> excludeFile = null)
        {
            ControlFlow.Assert(Directory.Exists(source), $"Directory.Exists({source})");
            ControlFlow.Assert(!PathConstruction.IsDescendantPath(source, target),
                $"Target directory '{target}' must not be in source directory '{source}'.");
            //ControlFlow.Assert(!Contains(source, target), $"Target '{target}' is not contained in source '{source}'.");

            Logger.Info($"Recursively copying from '{source}' to '{target}'...");
            CopyRecursivelyInternal(source, target, directoryPolicy, filePolicy, excludeDirectory, excludeFile);
        }

        private static void CopyRecursivelyInternal(
            string source,
            string target,
            DirectoryExistsPolicy directoryPolicy,
            FileExistsPolicy filePolicy,
            [CanBeNull] Func<DirectoryInfo, bool> excludeDirectory,
            [CanBeNull] Func<FileInfo, bool> excludeFile)
        {
            if (excludeDirectory != null && excludeDirectory(new DirectoryInfo(source)))
                return;

            ControlFlow.Assert(!Directory.Exists(target) || directoryPolicy != DirectoryExistsPolicy.Fail,
                $"!Directory.Exists({target}) || directoryPolicy != DirectoryExistsPolicy.Fail");

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

        private static bool ShouldCopyFile(string sourceFile, string targetFile, FileExistsPolicy policy)
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

        public static void Touch(string path, DateTime? time = null, bool createDirectories = true)
        {
            Logger.Info($"Touching file '{path}'...");

            if (createDirectories)
                EnsureExistingParentDirectory(path);

            if (!File.Exists(path))
                File.WriteAllBytes(path, new byte[0]);

            File.SetLastWriteTime(path, time ?? DateTime.UtcNow);
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
            ControlFlow.Assert(Directory.Exists(path) || File.Exists(path), "Directory.Exists(path) || File.Exists(path)");

            return Directory.Exists(path)
                ? new DirectoryInfo(path)
                    .GetFileSystemInfos("*", SearchOption.AllDirectories)
                    .Max(x => x.LastWriteTimeUtc)
                : File.GetLastWriteTimeUtc(path);
        }

        [CanBeNull]
        public static string FindParentDirectory(string start, Func<DirectoryInfo, bool> predicate)
        {
            return FindParentDirectory(new DirectoryInfo(start), predicate)?.FullName;
        }

        [CanBeNull]
        public static DirectoryInfo FindParentDirectory(DirectoryInfo start, Func<DirectoryInfo, bool> predicate)
        {
            return start
                .DescendantsAndSelf(x => x.Parent)
                .Where(x => x != null)
                .FirstOrDefault(predicate);
        }

        public static string GetFileHash(string file)
        {
            ControlFlow.Assert(File.Exists(file), $"File.Exists({file})");

            using var md5 = MD5.Create();
            using var stream = File.OpenRead(file);
            var hash = md5.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }

        public static string GetDirectoryHash(string directory, params string[] fileGlobPatterns)
        {
            ControlFlow.Assert(Directory.Exists(directory), $"Directory.Exists({directory})");

            var files = (fileGlobPatterns.Length == 0
                    ? Directory.GetFiles(directory, "*", SearchOption.AllDirectories)
                    : PathConstruction.GlobFiles(directory, fileGlobPatterns))
                .OrderBy(x => x).ToList();

            using var md5 = MD5.Create();

            foreach (var file in files)
            {
                var relativePath = PathConstruction.GetRelativePath(directory, file);
                var unixNormalizedPath = PathConstruction.NormalizePath(relativePath, separator: '/');
                var pathBytes = Encoding.UTF8.GetBytes(unixNormalizedPath);
                md5.TransformBlock(pathBytes, inputOffset: 0, inputCount: pathBytes.Length, outputBuffer: pathBytes, outputOffset: 0);

                var contentBytes = File.ReadAllBytes(file);
                md5.TransformBlock(contentBytes, inputOffset: 0, inputCount: contentBytes.Length, outputBuffer: contentBytes, outputOffset: 0);
            }

            md5.TransformFinalBlock(new byte[0], inputOffset: 0, inputCount: 0);

            return BitConverter.ToString(md5.Hash).Replace("-", "").ToLower();
        }
    }
}
