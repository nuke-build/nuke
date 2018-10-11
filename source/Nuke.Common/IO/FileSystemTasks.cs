// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using JetBrains.Annotations;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class FileSystemTasks
    {
        public enum FileExistsPolicy
        {
            Fail,
            Skip,
            Overwrite,
            OverwriteIfNewer
        }

        public static void EnsureExistingParentDirectory(string file)
        {
            EnsureExistingDirectory(Path.GetDirectoryName(file).NotNull($"Path.GetDirectoryName({file}) != null"));
        }

        public static void EnsureExistingDirectory(string directory)
        {
            if (Directory.Exists(directory))
                return;

            Logger.Info($"Creating directory '{directory}'...");
            Directory.CreateDirectory(directory);
        }

        public static void EnsureExistingDirectories(IEnumerable<string> directories)
        {
            directories.ForEach(EnsureExistingDirectory);
        }

        public static void EnsureCleanDirectory(string directory)
        {
            if (Directory.Exists(directory))
            {
                Logger.Info($"Cleaning directory '{directory}'...");
                DeleteDirectoryInternal(directory);
                Directory.CreateDirectory(directory);
            }
            else
            {
                EnsureExistingDirectory(directory);
            }
        }

        public static void EnsureCleanDirectories(IEnumerable<string> directories)
        {
            directories.ForEach(EnsureCleanDirectory);
        }

        public static void DeleteDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                return;

            Logger.Info($"Deleting directory '{directory}'...");
            DeleteDirectoryInternal(directory);
        }

        public static void DeleteDirectories(IEnumerable<string> directories)
        {
            var directoryList = directories.ToList();
            directoryList.ForEach(DeleteDirectory);
        }

        public static void DeleteDirectoryInternal(string directory)
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

        public static void DeleteFile(string file)
        {
            if (!File.Exists(file))
                return;

            Logger.Info($"Deleting file '{file}'...");
            EnsureFileAttributes(file);
            File.Delete(file);
        }

        public static void CopyFile(string source, string target, FileExistsPolicy policy = FileExistsPolicy.Fail)
        {
            if (!ShouldCopyFile(source, target, policy))
                return;

            Logger.Info($"Copying file '{source}' to '{target}'...");
            File.Copy(source, target, overwrite: ShouldCopyFile(source, target, policy));
        }

        public static void MoveFile(string source, string target, FileExistsPolicy policy = FileExistsPolicy.Fail)
        {
            if (!ShouldCopyFile(source, target, policy))
                return;

            Logger.Info($"Moving file from '{source}' to '{target}'...");
            if (File.Exists(target))
                File.Delete(target);

            File.Move(source, target);
        }

        public static void MoveDirectory(string source, string target)
        {
            Logger.Info($"Moving directory from '{source}' to '{target}'...");
            Directory.Move(source, target);
        }

        public static void CopyDirectoryRecursively(string source, string target, FileExistsPolicy policy = FileExistsPolicy.Fail)
        {
            ControlFlow.Assert(Directory.Exists(source), $"Directory.Exists({source})");
            ControlFlow.Assert(!Contains(target, source), $"Source '{source}' is not contained in target '{target}'.");
            //ControlFlow.Assert(!Contains(source, target), $"Target '{target}' is not contained in source '{source}'.");

            Logger.Info($"Copying recursively from '{source}' to '{target}'...");
            CopyRecursivelyInternal(source, target, policy);
        }

        private static bool ShouldCopyFile(string sourceFile, string targetFile, FileExistsPolicy policy)
        {
            if (!File.Exists(targetFile))
                return true;

            switch (policy)
            {
                case FileExistsPolicy.Fail:
                    ControlFlow.Fail($"File '{targetFile}' already exists.");
                    // ReSharper disable once HeuristicUnreachableCode
                    return false;
                case FileExistsPolicy.Skip:
                    return false;
                case FileExistsPolicy.Overwrite:
                    return true;
                case FileExistsPolicy.OverwriteIfNewer:
                    return File.GetLastWriteTimeUtc(targetFile) < File.GetLastWriteTimeUtc(sourceFile);
                default:
                    throw new ArgumentOutOfRangeException(nameof(policy), policy, message: null);
            }
        }

        private static void CopyRecursivelyInternal(string source, string target, FileExistsPolicy policy)
        {
            string GetDestinationPath(string path)
                => Path.Combine(target, PathConstruction.GetRelativePath(source, path));

            Directory.CreateDirectory(target);
            Directory.GetDirectories(source).ForEach(x => CopyRecursivelyInternal(x, GetDestinationPath(x), policy));

            foreach (var sourceFile in Directory.GetFiles(source))
            {
                var targetFile = GetDestinationPath(sourceFile);
                if (!ShouldCopyFile(sourceFile, targetFile, policy))
                    continue;

                //EnsureFileAttributes(sourceFile);
                File.Copy(sourceFile, targetFile, overwrite: true);
            }
        }

        private static bool Contains(string baseDirectory, string otherDirectory)
        {
            var otherDirectoryInfo = new DirectoryInfo(otherDirectory);
            return new DirectoryInfo(baseDirectory).DescendantsAndSelf(x => x.Parent)
                .Any(x => x.FullName == otherDirectoryInfo.FullName);
        }

        //public static IEnumerable<string> GetFiles (string directory, string filePattern, bool includeSubDirectories = true)
        //{
        //    return Directory.GetFiles (directory, filePattern, includeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        //}

        public static void Touch(string path, DateTime? time = null)
        {
            Logger.Info($"Touching file '{path}'...");

            EnsureExistingParentDirectory(path);

            if (!File.Exists(path))
                File.WriteAllBytes(path, new byte[0]);
            else
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

            using (var md5 = MD5.Create())
            using (var stream = File.OpenRead(file))
            {
                var hash = md5.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        public static string GetDirectoryHash(string directory, params string[] fileGlobPatterns)
        {
            ControlFlow.Assert(Directory.Exists(directory), $"Directory.Exists({directory})");

            var files = (fileGlobPatterns.Length == 0
                    ? Directory.GetFiles(directory, "*", SearchOption.AllDirectories)
                    : PathConstruction.GlobFiles(directory, fileGlobPatterns))
                .OrderBy(x => x).ToList();

            using (var md5 = MD5.Create())
            {
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
}
