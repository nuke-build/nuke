// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.IO;

[Flags]
public enum ExistsPolicy
{
    DirectoryFail = 1,
    DirectoryMerge = 2,
    FileFail = 4,
    FileSkip = 8,
    FileOverwrite = 16,
    FileOverwriteIfNewer = 32,

    Fail = DirectoryFail | FileFail,
    MergeAndSkip = DirectoryMerge | FileSkip,
    MergeAndOverwrite = DirectoryMerge | FileOverwrite,
    MergeAndOverwriteIfNewer = DirectoryMerge | FileOverwriteIfNewer
}

partial class AbsolutePathExtensions
{
    /// <summary>
    /// Renames the file or directory.
    /// </summary>
    public static AbsolutePath Rename(
        this AbsolutePath source,
        string newName,
        ExistsPolicy policy = ExistsPolicy.Fail)
    {
        return source.Move(source.Parent / newName, policy);
    }

    /// <summary>
    /// Renames the file or directory.
    /// </summary>
    public static AbsolutePath Rename(
        this AbsolutePath source,
        Func<AbsolutePath, string> newName,
        ExistsPolicy policy = ExistsPolicy.Fail)
    {
        return source.Rename(newName.Invoke(source), policy);
    }

    /// <summary>
    /// Renames the file without changing the extension.
    /// </summary>
    public static AbsolutePath RenameWithoutExtension(
        this AbsolutePath source,
        string newName,
        ExistsPolicy policy = ExistsPolicy.Fail)
    {
        return source.Move(source.Parent / newName + source.Extension, policy);
    }

    /// <summary>
    /// Renames the file without changing the extension.
    /// </summary>
    public static AbsolutePath RenameWithoutExtension(
        this AbsolutePath source,
        Func<AbsolutePath, string> newName,
        ExistsPolicy policy = ExistsPolicy.Fail)
    {
        return source.RenameWithoutExtension(newName.Invoke(source), policy);
    }

    /// <summary>
    /// Moves the file or directory to another directory.
    /// </summary>
    public static AbsolutePath MoveToDirectory(
        this AbsolutePath source,
        AbsolutePath target,
        ExistsPolicy policy = ExistsPolicy.Fail,
        bool createDirectories = true)
    {
        return source.Move(target / source.Name, policy, createDirectories);
    }

    /// <summary>
    /// Copies the file or directory to another directory.
    /// </summary>
    public static AbsolutePath CopyToDirectory(
        this AbsolutePath source,
        AbsolutePath target,
        ExistsPolicy policy = ExistsPolicy.Fail,
        Func<AbsolutePath, bool> excludeDirectory = null,
        Func<AbsolutePath, bool> excludeFile = null,
        bool createDirectories = true)
    {
        return source.Copy(target / source.Name, policy, excludeDirectory, excludeFile, createDirectories);
    }

    /// <summary>
    /// Moves the file or directory.
    /// </summary>
    public static AbsolutePath Move(
        this AbsolutePath source,
        Func<AbsolutePath, AbsolutePath> newPath,
        ExistsPolicy policy = ExistsPolicy.Fail,
        bool createDirectories = true)
    {
        return source.Move(newPath.Invoke(source), policy, createDirectories);
    }

    /// <summary>
    /// Moves the file or directory.
    /// </summary>
    public static AbsolutePath Move(
        this AbsolutePath source,
        AbsolutePath target,
        ExistsPolicy policy = ExistsPolicy.Fail,
        bool createDirectories = true,
        bool deleteRemainingFiles = false)
    {
        Assert.True(source.DirectoryExists() || source.FileExists());

        if (source.DirectoryExists())
            return MoveDirectory(source, target, policy, createDirectories, deleteRemainingFiles);

        if (source.FileExists())
            return MoveFile(source, target, policy, createDirectories);

        throw new Exception("Unreachable");
    }

    /// <summary>
    /// Copies the file or directory.
    /// </summary>
    public static AbsolutePath Copy(
        this AbsolutePath source,
        AbsolutePath target,
        ExistsPolicy policy = ExistsPolicy.Fail,
        Func<AbsolutePath, bool> excludeDirectory = null,
        Func<AbsolutePath, bool> excludeFile = null,
        bool createDirectories = true)
    {
        Assert.True(source.DirectoryExists() || source.FileExists());

        if (source.DirectoryExists())
            return CopyDirectory(source, target, policy, excludeDirectory, excludeFile, createDirectories);

        if (source.FileExists())
            return CopyFile(source, target, policy, createDirectories);

        throw new Exception("Unreachable");
    }

    private static AbsolutePath MoveFile(
        this AbsolutePath source,
        AbsolutePath target,
        ExistsPolicy policy = ExistsPolicy.Fail,
        bool createDirectories = true)
    {
        return HandleFile(source, target, policy, createDirectories, () =>
        {
            target.DeleteFile();
            File.Move(source, target);
        });
    }

    private static AbsolutePath CopyFile(
        this AbsolutePath source,
        AbsolutePath target,
        ExistsPolicy policy = ExistsPolicy.Fail,
        bool createDirectories = true)
    {
        return HandleFile(source, target, policy, createDirectories, () =>
        {
            File.Copy(source, target, overwrite: true);
        });
    }

    private static AbsolutePath HandleFile(
        AbsolutePath source,
        AbsolutePath target,
        ExistsPolicy policy,
        bool createDirectories,
        Action action)
    {
        if (File.Exists(target) && !Permitted())
            return source;

        if (createDirectories)
            target.Parent.CreateDirectory();

        action.Invoke();
        return target;

        bool Permitted()
        {
            var filePolicies = ExistsPolicy.FileFail | ExistsPolicy.FileSkip | ExistsPolicy.FileOverwrite | ExistsPolicy.FileOverwriteIfNewer;
            return (policy & filePolicies) switch
            {
                ExistsPolicy.FileFail => throw new Exception($"File '{target}' already exists"),
                ExistsPolicy.FileSkip => false,
                ExistsPolicy.FileOverwrite => true,
                ExistsPolicy.FileOverwriteIfNewer => File.GetLastWriteTimeUtc(target) < File.GetLastWriteTimeUtc(source),
                _ => throw new ArgumentOutOfRangeException(nameof(policy), policy, message: "Multiple file policies set")
            };
        }
    }

    private static AbsolutePath MoveDirectory(
        this AbsolutePath source,
        AbsolutePath target,
        ExistsPolicy policy = ExistsPolicy.Fail,
        bool createDirectories = true,
        bool deleteRemainingFiles = false)
    {
        return HandleDirectory(source, target, policy, createDirectories, () =>
        {
            source.GetDirectories().ForEach(x => x.MoveDirectory(target / source.GetRelativePathTo(x), policy));
            source.GetFiles().ForEach(x => x.MoveFile(target / source.GetRelativePathTo(x), policy));

            if (!source.ToDirectoryInfo().EnumerateFileSystemInfos().Any() || deleteRemainingFiles)
                source.DeleteDirectory();
        });
    }

    private static AbsolutePath CopyDirectory(
        this AbsolutePath source,
        AbsolutePath target,
        ExistsPolicy policy = ExistsPolicy.Fail,
        Func<AbsolutePath, bool> excludeDirectory = null,
        Func<AbsolutePath, bool> excludeFile = null,
        bool createDirectories = true)
    {
        return HandleDirectory(source, target, policy, createDirectories, () =>
        {
            source.GetDirectories().WhereNot(excludeDirectory).ForEach(x => x.CopyDirectory(target / source.GetRelativePathTo(x), policy, excludeDirectory, excludeFile));
            source.GetFiles().WhereNot(excludeFile).ForEach(x => x.CopyFile(target / source.GetRelativePathTo(x), policy));
        });
    }

    private static AbsolutePath HandleDirectory(
        AbsolutePath source,
        AbsolutePath target,
        ExistsPolicy policy,
        bool createDirectories,
        Action action)
    {
        Assert.DirectoryExists(source);
        Assert.False(source.Contains(target), $"Target directory '{target}' must not be in source directory '{source}'");
        Assert.True(!Directory.Exists(target) || (policy.HasFlag(ExistsPolicy.DirectoryMerge) && !policy.HasFlag(ExistsPolicy.DirectoryFail)),
            "Policy disallows merging directories");

        if (createDirectories)
            target.CreateDirectory();

        action.Invoke();
        return target;
    }
}
