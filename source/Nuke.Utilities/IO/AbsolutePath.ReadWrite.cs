// Copyright 2022 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Nuke.Common.IO
{
    partial class AbsolutePathExtensions
    {
        public static UTF8Encoding UTF8NoBom => new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        /// <summary>
        /// Appends all lines to a file.
        /// </summary>
        public static void AppendAllLines(this AbsolutePath path, IEnumerable<string> lines, Encoding encoding = null)
        {
            AppendAllLines(path, lines.ToArray(), encoding);
        }

        /// <summary>
        /// Appends all lines to a file.
        /// </summary>
        public static void AppendAllLines(this AbsolutePath path, string[] lines, Encoding encoding = null)
        {
            path.Parent.CreateDirectory();
            File.AppendAllLines(path, lines, encoding ?? UTF8NoBom);
        }

        /// <summary>
        /// Appends the string to a file.
        /// </summary>
        public static void AppendAllText(this AbsolutePath path, string content, Encoding encoding = null)
        {
            path.Parent.CreateDirectory();
            File.AppendAllText(path, content, encoding ?? UTF8NoBom);
        }

        /// <summary>
        /// Writes all lines to a file.
        /// </summary>
        public static void WriteAllLines(this AbsolutePath path, IEnumerable<string> lines, Encoding encoding = null)
        {
            WriteAllLines(path, lines.ToArray(), encoding);
        }

        /// <summary>
        /// Writes all lines to a file.
        /// </summary>
        public static void WriteAllLines(this AbsolutePath path, string[] lines, Encoding encoding = null)
        {
            path.Parent.CreateDirectory();
            File.WriteAllLines(path, lines, encoding ?? UTF8NoBom);
        }

        /// <summary>
        /// Writes the string to a file.
        /// </summary>
        public static void WriteAllText(this AbsolutePath path, string content, Encoding encoding = null)
        {
            path.Parent.CreateDirectory();
            File.WriteAllText(path, content, encoding ?? UTF8NoBom);
        }

        /// <summary>
        /// Writes all bytes to a file.
        /// </summary>
        public static void WriteAllBytes(this AbsolutePath path, byte[] bytes)
        {
            path.Parent.CreateDirectory();
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// Reads the file as single string.
        /// </summary>
        public static string ReadAllText(this AbsolutePath path, Encoding encoding = null)
        {
            Assert.FileExists(path);
            return File.ReadAllText(path, encoding ?? Encoding.UTF8);
        }

        /// <summary>
        /// Reads the file as a collection of strings (new-line separated).
        /// </summary>
        public static string[] ReadAllLines(this AbsolutePath path, Encoding encoding = null)
        {
            Assert.FileExists(path);
            return File.ReadAllLines(path, encoding ?? Encoding.UTF8);
        }

        /// <summary>
        /// Reads the file as a collection of bytes.
        /// </summary>
        public static byte[] ReadAllBytes(this AbsolutePath path)
        {
            Assert.FileExists(path);
            return File.ReadAllBytes(path);
        }
    }
}
