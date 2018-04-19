#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Nuke.Core.IO
{
    [PublicAPI]
    [Obsolete("Namespace 'Core' is deprecated. Simply do a text replace from 'Nuke.Core' to 'Nuke.Common' to resolve all warnings.")]
    public static class TextTasks
    {
        private static UTF8Encoding UTF8NoBom => new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        public static void WriteAllText(string path, IEnumerable<string> lines, Encoding encoding = null)
        {
            WriteAllText(path, lines.ToArray(), encoding);
        }

        public static void WriteAllText(string path, string[] lines, Encoding encoding = null)
        {
            WriteAllText(path, string.Join(EnvironmentInfo.NewLine, lines), encoding);
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
            return File.ReadAllText(path, encoding ?? Encoding.UTF8);
        }

        public static string[] ReadAllLines(string path, Encoding encoding = null)
        {
            return File.ReadAllLines(path, encoding ?? Encoding.UTF8);
        }

        public static byte[] ReadAllBytes(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}
