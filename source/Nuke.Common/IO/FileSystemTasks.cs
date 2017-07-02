// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Glob;
using JetBrains.Annotations;
using Nuke.Common.IO;
using Nuke.Core;
using Nuke.Core.Execution;
using Nuke.Core.Utilities.Collections;

[assembly: IconClass(typeof(FileSystemTasks), "folder-open")]

namespace Nuke.Common.IO
{
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
        public static void PrepareCleanDirectory (string directory)
        {
            if (!Directory.Exists(directory))
            {
                Logger.Info ($"Creating directory '{directory}'...");
                EnsureDirectoryExists(directory);
            }
            else
            {
                Logger.Info ($"Cleaning directory '{directory}'...");
                Directory.GetDirectories(directory).ForEach(DeleteDirectoryInternal);
                Directory.GetFiles(directory).ForEach(DeleteFile);
            }
        }

        public static void PrepareCleanDirectories (IEnumerable<string> directories)
        {
            directories.ForEach(PrepareCleanDirectory);
        }

        public static void DeleteDirectory (string directory)
        {
            if (!Directory.Exists(directory))
                return;

            Logger.Info($"Deleting directory '{directory}'...");
            DeleteDirectoryInternal(directory);
        }

        public static void DeleteDirectories (IEnumerable<string> directories)
        {
            directories.ForEach(DeleteDirectory);
        }

        public static void DeleteDirectoryInternal(string directory)
        {
            Directory.GetFiles(directory).ForEach(DeleteFile);
            Directory.GetDirectories(directory).ForEach(DeleteDirectoryInternal);
            Directory.Delete(directory, recursive: false);
        }

        private static void DeleteFile(string file)
        {
            EnsureFileAttributes(file);
            File.Delete(file);
        }

        public static void CopyRecursively (string source, string target, FileExistsPolicy policy = FileExistsPolicy.Fail)
        {
            ControlFlow.Assert(Directory.Exists(source), $"Directory.Exists({source})");
            ControlFlow.Assert(!Contains(target, source), $"Source '{source}' is not contained in target '{target}'.");
            //ControlFlow.Assert(!Contains(source, target), $"Target '{target}' is not contained in source '{source}'.");

            Logger.Info($"Copying recursively from '{source}' to '{target}'...");
            CopyRecursivelyInternal(source, target, policy);
        }

        private static bool ShouldCopyFile (string sourceFile, string targetFile, FileExistsPolicy policy)
        {
            if (!File.Exists(targetFile))
                return true;

            switch (policy)
            {
                case FileExistsPolicy.Fail:
                    ControlFlow.Fail($"File '{targetFile}' already exists.");
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

        private static void CopyRecursivelyInternal (string source, string target, FileExistsPolicy policy)
        {
            string GetDestinationPath (string path)
                => Path.Combine(target, GetRelativePath(source, path));

            Directory.CreateDirectory(target);
            Directory.GetDirectories(source).ForEach(x => CopyRecursively(x, GetDestinationPath(x), policy));

            foreach (var sourceFile in Directory.GetFiles(source))
            {
                var targetFile = GetDestinationPath(sourceFile);
                if (!ShouldCopyFile(sourceFile, targetFile, policy))
                    continue;
                
                //EnsureFileAttributes(sourceFile);
                File.Copy(sourceFile, targetFile, overwrite: true);
            }
        }

        private static bool Contains (string baseDirectory, string otherDirectory)
        {
            var otherDirectoryInfo = new DirectoryInfo(otherDirectory);
            return new DirectoryInfo(baseDirectory).DescendantsAndSelf(x => x.Parent)
                    .Any(x => x.FullName == otherDirectoryInfo.FullName);
        }

        //public static IEnumerable<string> GetFiles (string directory, string filePattern, bool includeSubDirectories = true)
        //{
        //    return Directory.GetFiles (directory, filePattern, includeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
        //}

        [Pure]
        public static IEnumerable<string> GlobFiles (string directory, params string[] globPatterns)
        {
            var directoryInfo = new DirectoryInfo(directory);
            return globPatterns.SelectMany(x => directoryInfo.GlobFiles(x)).Select(x => x.FullName);
        }

        [Pure]
        public static IEnumerable<string> GlobDirectories (string directory, params string[] globPatterns)
        {
            var directoryInfo = new DirectoryInfo(directory);
            return globPatterns.SelectMany(x => directoryInfo.GlobDirectories(x)).Select(x => x.FullName);
        }

        [Pure]
        public static string GetRelativePath (string basePath, string destinationPath)
        {
            return Uri.UnescapeDataString(new Uri($@"{basePath}\").MakeRelativeUri(new Uri(destinationPath)).ToString());
        }

        public static void Touch(string path, DateTime? time = null)
        {
            Logger.Info($"Touching file '{path}'...");

            EnsureDirectoryExists(path);

            if (!File.Exists(path))
                TextTasks.WriteAllBytes(path, new byte[0]);
            else
                File.SetLastWriteTime(path, time ?? DateTime.UtcNow);
        }

        internal static void EnsureDirectoryExists(string path)
        {
            var directoryName = Path.GetDirectoryName(path).NotNull();
            Directory.CreateDirectory(directoryName);
        }

        private static void EnsureFileAttributes (string file)
        {
            File.SetAttributes(file, FileAttributes.Normal);
        }
    }
}
