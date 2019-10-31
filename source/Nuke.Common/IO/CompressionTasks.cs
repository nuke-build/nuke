// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;
using JetBrains.Annotations;
using Nuke.Common.Utilities;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class CompressionTasks
    {
        public static void Compress(string directory, string archiveFile, Predicate<FileInfo> filter = null)
        {
            if (archiveFile.EndsWithAny(".zip"))
                CompressZip(directory, archiveFile, filter);
            else if (archiveFile.EndsWithAny(".tar.gz", ".tgz"))
                CompressTarGZip(directory, archiveFile, filter);
            else if (archiveFile.EndsWithAny(".tar.bz2", ".tbz2", ".tbz"))
                CompressTarBZip2(directory, archiveFile, filter);
            else
                ControlFlow.Fail($"Unknown archive extension for archive '{Path.GetFileName(archiveFile)}'");
        }

        public static void Uncompress(string archiveFile, string directory)
        {
            if (archiveFile.EndsWithAny(".zip"))
                UncompressZip(archiveFile, directory);
            else if (archiveFile.EndsWithAny(".tar.gz", ".tgz"))
                UncompressTarGZip(archiveFile, directory);
            else if (archiveFile.EndsWithAny(".tar.bz2", ".tbz2", ".tbz"))
                UncompressTarBZip2(archiveFile, directory);
            else
                ControlFlow.Fail($"Unknown archive extension for archive '{Path.GetFileName(archiveFile)}'");
        }

        public static void CompressZip(
            string directory,
            string archiveFile,
            Predicate<FileInfo> filter = null,
            CompressionLevel compressionLevel = CompressionLevel.Optimal,
            FileMode fileMode = FileMode.CreateNew)
        {
            FileSystemTasks.EnsureExistingParentDirectory(archiveFile);

            var files = GetFiles(directory, filter);
            using (var fileStream = File.Open(archiveFile, fileMode, FileAccess.ReadWrite))
            using (var zipArchive = new ZipArchive(fileStream, ZipArchiveMode.Create))
            {
                // zipStream.SetLevel(1);

                foreach (var file in files)
                {
                    var relativePath = PathConstruction.GetRelativePath(directory, file);
                    var entryName = ZipEntry.CleanName(relativePath);
                    zipArchive.CreateEntryFromFile(file, entryName, compressionLevel);
                }
            }

            Logger.Info($"Compressed content of '{directory}' to '{Path.GetFileName(archiveFile)}'.");
        }

        public static void UncompressZip(string archiveFile, string directory)
        {
            using (var fileStream = File.OpenRead(archiveFile))
            using (var zipFile = new ICSharpCode.SharpZipLib.Zip.ZipFile(fileStream))
            {
                var entries = zipFile.Cast<ZipEntry>().Where(x => !x.IsDirectory);
                foreach (var entry in entries)
                {
                    var file = PathConstruction.Combine(directory, entry.Name);
                    FileSystemTasks.EnsureExistingParentDirectory(file);

                    using var entryStream = zipFile.GetInputStream(entry);
                    using var outputStream = File.Open(file, FileMode.Create);
                    entryStream.CopyTo(outputStream);
                }
            }

            Logger.Info($"Uncompressed '{archiveFile}' to '{directory}'.");
        }

        public static void CompressTarGZip(
            string directory,
            string archiveFile,
            Predicate<FileInfo> filter = null,
            FileMode fileMode = FileMode.CreateNew)
        {
            CompressTar(directory, archiveFile, filter, fileMode, x => new GZipOutputStream(x));
        }

        public static void CompressTarBZip2(
            string directory,
            string archiveFile,
            Predicate<FileInfo> filter = null,
            FileMode fileMode = FileMode.CreateNew)
        {
            CompressTar(directory, archiveFile, filter, fileMode, x => new BZip2OutputStream(x));
        }

        public static void UncompressTarGZip(string archiveFile, string directory)
        {
            UncompressTar(archiveFile, directory, x => new GZipInputStream(x));
        }

        public static void UncompressTarBZip2(string archiveFile, string directory)
        {
            UncompressTar(archiveFile, directory, x => new BZip2InputStream(x));
        }

        private static void CompressTar(
            string directory,
            string archiveFile,
            Predicate<FileInfo> filter,
            FileMode fileMode,
            Func<Stream, Stream> outputStreamFactory)
        {
            FileSystemTasks.EnsureExistingParentDirectory(archiveFile);

            var files = GetFiles(directory, filter);
            using (var fileStream = File.Open(archiveFile, fileMode, FileAccess.ReadWrite))
            using (var outputStream = outputStreamFactory(fileStream))
            using (var tarArchive = TarArchive.CreateOutputTarArchive(outputStream))
            {
                foreach (var file in files)
                {
                    var entry = TarEntry.CreateEntryFromFile(file);
                    var relativePath = PathConstruction.GetRelativePath(directory, file);
                    entry.Name = PathConstruction.NormalizePath(relativePath, separator: '/');

                    tarArchive.WriteEntry(entry, recurse: false);
                }
            }

            Logger.Info($"Compressed content of '{directory}' to '{Path.GetFileName(archiveFile)}'.");
        }

        private static void UncompressTar(string archiveFile, string directory, Func<Stream, Stream> inputStreamFactory)
        {
            using (var fileStream = File.OpenRead(archiveFile))
            using (var inputStream = inputStreamFactory(fileStream))
            using (var tarArchive = TarArchive.CreateInputTarArchive(inputStream))
            {
                FileSystemTasks.EnsureExistingDirectory(directory);

                tarArchive.ExtractContents(directory);
            }

            Logger.Info($"Uncompressed '{archiveFile}' to '{directory}'.");
        }

        private static bool EndsWithAny(this string fileName, params string[] extensions)
        {
            return extensions.Any(fileName.EndsWithOrdinalIgnoreCase);
        }

        private static List<string> GetFiles(string directory, [CanBeNull] Predicate<FileInfo> filter)
        {
            return Directory.GetFiles(directory, "*", SearchOption.AllDirectories)
                .Where(x => filter == null || filter(new FileInfo(x)))
                .OrderBy(x => x)
                .ToList();
        }
    }
}
