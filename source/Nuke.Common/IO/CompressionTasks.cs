// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class CompressionTasks
    {
        [Obsolete($"Use {nameof(CompressionExtensions)}.{nameof(CompressionExtensions.CompressTo)} as {nameof(AbsolutePath)} extension method")]
        public static void Compress(AbsolutePath directory, AbsolutePath archiveFile, Predicate<FileInfo> filter = null)
        {
            filter ??= _ => true;
            directory.CompressTo(archiveFile, x => filter(new FileInfo(x)));
        }

        [Obsolete($"Use {nameof(CompressionExtensions)}.{nameof(CompressionExtensions.UncompressTo)} as {nameof(AbsolutePath)} extension method")]
        public static void Uncompress(AbsolutePath archiveFile, AbsolutePath directory)
        {
            archiveFile.UncompressTo(directory);
        }

        [Obsolete($"Use {nameof(CompressionExtensions)}.{nameof(CompressionExtensions.ZipTo)} as {nameof(AbsolutePath)} extension method")]
        public static void CompressZip(
            AbsolutePath directory,
            AbsolutePath archiveFile,
            Predicate<FileInfo> filter = null,
            CompressionLevel compressionLevel = CompressionLevel.Optimal,
            FileMode fileMode = FileMode.CreateNew)
        {
            filter ??= _ => true;
            directory.ZipTo(archiveFile, x => filter(new FileInfo(x)), compressionLevel, fileMode);
        }

        [Obsolete($"Use {nameof(CompressionExtensions)}.{nameof(CompressionExtensions.UnZipTo)} as {nameof(AbsolutePath)} extension method")]
        public static void UncompressZip(AbsolutePath archiveFile, AbsolutePath directory)
        {
            archiveFile.UnZipTo(directory);
        }

        [Obsolete($"Use {nameof(CompressionExtensions)}.{nameof(CompressionExtensions.TarGZipTo)} as {nameof(AbsolutePath)} extension method")]
        public static void CompressTarGZip(
            AbsolutePath directory,
            AbsolutePath archiveFile,
            Predicate<FileInfo> filter = null,
            FileMode fileMode = FileMode.CreateNew)
        {
            filter ??= _ => true;
            directory.TarGZipTo(archiveFile, x => filter(new FileInfo(x)), fileMode);
        }

        [Obsolete($"Use {nameof(CompressionExtensions)}.{nameof(CompressionExtensions.TarGZipTo)} as {nameof(AbsolutePath)} extension method")]
        public static void CompressTarGZip(
            AbsolutePath baseDirectory,
            AbsolutePath archiveFile,
            IEnumerable<AbsolutePath> files,
            FileMode fileMode = FileMode.CreateNew)
        {
            baseDirectory.TarGZipTo(archiveFile, files, fileMode);
        }

        [Obsolete($"Use {nameof(CompressionExtensions)}.{nameof(CompressionExtensions.TarBZip2To)} as {nameof(AbsolutePath)} extension method")]
        public static void CompressTarBZip2(
            AbsolutePath directory,
            AbsolutePath archiveFile,
            Predicate<FileInfo> filter = null,
            FileMode fileMode = FileMode.CreateNew)
        {
            filter ??= _ => true;
            directory.TarBZip2To(archiveFile, x => filter(new FileInfo(x)), fileMode);
        }

        [Obsolete($"Use {nameof(CompressionExtensions)}.{nameof(CompressionExtensions.UnTarGZipTo)} as {nameof(AbsolutePath)} extension method")]
        public static void UncompressTarGZip(AbsolutePath archiveFile, AbsolutePath directory)
        {
            archiveFile.UnTarGZipTo(directory);
        }

        [Obsolete($"Use {nameof(CompressionExtensions)}.{nameof(CompressionExtensions.UnTarBZip2To)} as {nameof(AbsolutePath)} extension method")]
        public static void UncompressTarBZip2(AbsolutePath archiveFile, AbsolutePath directory)
        {
            archiveFile.UnTarBZip2To(directory);
        }
    }
}
