// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class TextTasks
    {
        public static UTF8Encoding UTF8NoBom => new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        public static void WriteAllLines(string path, IEnumerable<string> lines, Encoding encoding = null)
        {
            WriteAllLines(path, lines.ToArray(), encoding);
        }

        public static void WriteAllLines(string path, string[] lines, Encoding encoding = null)
        {
            FileSystemTasks.EnsureExistingParentDirectory(path);
            File.WriteAllLines(path, lines, encoding ?? UTF8NoBom);
        }

        public static void WriteAllText(string path, string content, Encoding encoding = null)
        {
            FileSystemTasks.EnsureExistingParentDirectory(path);
            File.WriteAllText(path, content, encoding ?? UTF8NoBom);
        }

        public static void WriteAllBytes(string path, byte[] bytes)
        {
            FileSystemTasks.EnsureExistingParentDirectory(path);
            File.WriteAllBytes(path, bytes);
        }

        public static string ReadAllText(string path, Encoding encoding = null)
        {
            ControlFlow.Assert(File.Exists(path), $"File.Exists({path})");
            return File.ReadAllText(path, encoding ?? Encoding.UTF8);
        }

        public static string[] ReadAllLines(string path, Encoding encoding = null)
        {
            ControlFlow.Assert(File.Exists(path), $"File.Exists({path})");
            return File.ReadAllLines(path, encoding ?? Encoding.UTF8);
        }

        public static byte[] ReadAllBytes(string path)
        {
            ControlFlow.Assert(File.Exists(path), $"File.Exists({path})");
            return File.ReadAllBytes(path);
        }
    }
}
