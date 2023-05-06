// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;

namespace Nuke.Common.IO;

partial class AbsolutePathExtensions
{
    /// <summary>
    /// Renames the file or directory.
    /// </summary>
    public static AbsolutePath Rename(this AbsolutePath path, string newName)
    {
        return path.Move(path.Parent / newName);
    }

    /// <summary>
    /// Renames the file or directory.
    /// </summary>
    public static AbsolutePath Rename(this AbsolutePath path, Func<AbsolutePath, string> newName)
    {
        return path.Rename(newName.Invoke(path));
    }

    /// <summary>
    /// Renames the file without changing the extension.
    /// </summary>
    public static AbsolutePath RenameWithoutExtension(this AbsolutePath path, string newName)
    {
        Assert.True(path.FileExists());
        return path.Move(path.Parent / newName + path.Extension);
    }

    /// <summary>
    /// Renames the file without changing the extension.
    /// </summary>
    public static AbsolutePath RenameWithoutExtension(this AbsolutePath path, Func<AbsolutePath, string> newName)
    {
        return path.RenameWithoutExtension(newName.Invoke(path));
    }

    /// <summary>
    /// Moves the file or directory to another directory.
    /// </summary>
    public static AbsolutePath MoveToDirectory(this AbsolutePath path, AbsolutePath directory)
    {
        Assert.True(directory.Exists());
        return path.Move(directory / path.Name);
    }

    /// <summary>
    /// Moves the file or directory.
    /// </summary>
    public static AbsolutePath Move(this AbsolutePath path, Func<AbsolutePath, AbsolutePath> newPath)
    {
        return path.Move(newPath.Invoke(path));
    }

    /// <summary>
    /// Moves the file or directory.
    /// </summary>
    public static AbsolutePath Move(this AbsolutePath path, AbsolutePath newPath)
    {
        Assert.True(path.DirectoryExists() || path.FileExists());

        if (path.DirectoryExists())
            Directory.Move(path, newPath);
        else if (path.FileExists())
            File.Move(path, newPath);

        return path;
    }
}
