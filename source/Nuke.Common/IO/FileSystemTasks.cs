// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (!Directory.Exists(directory))
            {
                EnsureExistingDirectory(directory);
            }
            else
            {
                Logger.Info($"Cleaning directory '{directory}'...");
                Directory.GetDirectories(directory).ForEach(DeleteDirectoryInternal);
                Directory.GetFiles(directory).ForEach(DeleteFile);
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

            if (PathConstruction.IsDescendantPath(EnvironmentInfo.BuildProjectDirectory, directory))
            {
                Logger.Warn($"Skipping directory '{directory}' because it is contained in the build project directory...");
                return;
            }

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
            
            Directory.GetFiles(directory).ForEach(DeleteFile);
            Directory.GetDirectories(directory).ForEach(DeleteDirectoryInternal);

            Logger.Trace($"Deleting directory '{directory}'...");
            Directory.Delete(directory, recursive: false);
            ControlFlow.Assert(!Directory.Exists(directory), $"Cannot delete directory '{directory}'.");
        }

        private static void DeleteFile(string file)
        {
            Logger.Trace($"Deleting file '{file}'...");
            EnsureFileAttributes(file);
            File.Delete(file);
        }

        public static void CopyRecursively(string source, string target, FileExistsPolicy policy = FileExistsPolicy.Fail)
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
    }
}
