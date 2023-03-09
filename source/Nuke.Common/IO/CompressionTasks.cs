// Copyright 2021 Maintainers of NUKE.
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
using Serilog;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class CompressionTasks
    {
        public static void Compress(AbsolutePath directory, AbsolutePath archiveFile, Predicate<FileInfo> filter = null)
        {
            if (archiveFile.HasExtension(".zip"))
                CompressZip(directory, archiveFile, filter);
            else if (archiveFile.HasExtension(".tar.gz", ".tgz"))
                CompressTarGZip(directory, archiveFile, filter);
            else if (archiveFile.HasExtension(".tar.bz2", ".tbz2", ".tbz"))
                CompressTarBZip2(directory, archiveFile, filter);
            else
                Assert.Fail($"Unknown archive extension for archive '{Path.GetFileName(archiveFile)}'");
        }

        public static void Uncompress(AbsolutePath archiveFile, AbsolutePath directory)
        {
            if (archiveFile.HasExtension(".zip"))
                UncompressZip(archiveFile, directory);
            else if (archiveFile.HasExtension(".tar.gz", ".tgz"))
                UncompressTarGZip(archiveFile, directory);
            else if (archiveFile.HasExtension(".tar.bz2", ".tbz2", ".tbz"))
                UncompressTarBZip2(archiveFile, directory);
            else
                Assert.Fail($"Unknown archive extension for archive '{Path.GetFileName(archiveFile)}'");
        }

        public static void CompressZip(
            AbsolutePath directory,
            AbsolutePath archiveFile,
            Predicate<FileInfo> filter = null,
            CompressionLevel compressionLevel = CompressionLevel.Optimal,
            FileMode fileMode = FileMode.CreateNew)
        {
            Log.Information("Compressing content of {Directory} to {File} ...", directory, Path.GetFileName(archiveFile));

            archiveFile.Parent.CreateDirectory();

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
        }

        public static void UncompressZip(AbsolutePath archiveFile, AbsolutePath directory)
        {
            Log.Information("Uncompressing {File} to {Directory} ...", Path.GetFileName(archiveFile), directory);

            using var fileStream = File.OpenRead(archiveFile);
            using var zipFile = new ICSharpCode.SharpZipLib.Zip.ZipFile(fileStream);

            var entries = zipFile.Cast<ZipEntry>().Where(x => !x.IsDirectory);
            foreach (var entry in entries)
            {
                var file = directory / entry.Name;
                file.Parent.CreateDirectory();

                using var entryStream = zipFile.GetInputStream(entry);
                using var outputStream = File.Open(file, FileMode.Create);
                entryStream.CopyTo(outputStream);
            }
        }

        public static void CompressTarGZip(
            AbsolutePath directory,
            AbsolutePath archiveFile,
            Predicate<FileInfo> filter = null,
            FileMode fileMode = FileMode.CreateNew)
        {
            CompressTar(directory, archiveFile, filter, fileMode, x => new GZipOutputStream(x));
        }

        public static void CompressTarBZip2(
            AbsolutePath directory,
            AbsolutePath archiveFile,
            Predicate<FileInfo> filter = null,
            FileMode fileMode = FileMode.CreateNew)
        {
            CompressTar(directory, archiveFile, filter, fileMode, x => new BZip2OutputStream(x));
        }

        public static void UncompressTarGZip(AbsolutePath archiveFile, AbsolutePath directory)
        {
            UncompressTar(archiveFile, directory, x => new GZipInputStream(x));
        }

        public static void UncompressTarBZip2(AbsolutePath archiveFile, AbsolutePath directory)
        {
            UncompressTar(archiveFile, directory, x => new BZip2InputStream(x));
        }

        private static void CompressTar(
            AbsolutePath directory,
            AbsolutePath archiveFile,
            Predicate<FileInfo> filter,
            FileMode fileMode,
            Func<Stream, Stream> outputStreamFactory)
        {
            Log.Information("Compressing content of {Directory} to {File} ...", directory, Path.GetFileName(archiveFile));

            archiveFile.Parent.CreateDirectory();

            var files = GetFiles(directory, filter);
            using var fileStream = File.Open(archiveFile, fileMode, FileAccess.ReadWrite);
            using var outputStream = outputStreamFactory(fileStream);
            using var tarArchive = TarArchive.CreateOutputTarArchive(outputStream);

            foreach (var file in files)
            {
                var entry = TarEntry.CreateEntryFromFile(file);
                var relativePath = PathConstruction.GetRelativePath(directory, file);
                entry.Name = PathConstruction.NormalizePath(relativePath, separator: '/');

                tarArchive.WriteEntry(entry, recurse: false);
            }
        }

        private static void UncompressTar(AbsolutePath archiveFile, AbsolutePath directory, Func<Stream, Stream> inputStreamFactory)
        {
            Log.Information("Uncompressing {File} to {Directory} ...", Path.GetFileName(archiveFile), directory);

            using var fileStream = File.OpenRead(archiveFile);
            using var inputStream = inputStreamFactory(fileStream);
            using var tarArchive = TarArchive.CreateInputTarArchive(inputStream, nameEncoding: null);

            directory.CreateDirectory();

            tarArchive.ExtractContents(directory);
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
