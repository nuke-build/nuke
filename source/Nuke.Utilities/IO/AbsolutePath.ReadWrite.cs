// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Nuke.Common.Utilities;

namespace Nuke.Common.IO
{
    partial class AbsolutePathExtensions
    {
        public static Encoding DefaultEncoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);
        public static PlatformFamily? DefaultLineBreakType = EnvironmentInfo.Platform;
        public static bool DefaultEofLineBreak = true;

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
            File.AppendAllLines(path, lines, encoding ?? DefaultEncoding);
        }

        /// <summary>
        /// Appends the string to a file.
        /// </summary>
        public static void AppendAllText(this AbsolutePath path, string content, Encoding encoding = null)
        {
            path.Parent.CreateDirectory();
            File.AppendAllText(path, content, encoding ?? DefaultEncoding);
        }

        /// <summary>
        /// Writes all lines to a file.
        /// </summary>
        public static void WriteAllLines(
            this AbsolutePath path,
            IEnumerable<string> lines,
            Encoding encoding = null,
            PlatformFamily? platformFamily = null,
            bool? eofLineBreak = null)
        {
            WriteAllLines(path, lines.ToArray(), encoding, platformFamily, eofLineBreak);
        }

        /// <summary>
        /// Writes all lines to a file.
        /// </summary>
        public static void WriteAllLines(
            this AbsolutePath path,
            string[] lines,
            Encoding encoding = null,
            PlatformFamily? platformFamily = null,
            bool? eofLineBreak = null)
        {
            if (eofLineBreak ?? DefaultEofLineBreak)
                lines = lines.Concat(new[] { string.Empty }).ToArray();

            path.WriteAllText(lines.JoinNewLine(platformFamily ?? DefaultLineBreakType), encoding);
        }

        /// <summary>
        /// Writes the string to a file.
        /// </summary>
        public static void WriteAllText(
            this AbsolutePath path,
            string content,
            Encoding encoding = null,
            bool? eofLineBreak = null)
        {
            path.Parent.CreateDirectory();

            if (eofLineBreak ?? DefaultEofLineBreak)
            {
                var windowsLineBreaks = content.Contains("\r\n");
                content = content.TrimEnd('\r', '\n');
                content += windowsLineBreaks ? "\r\n" : "\n";
            }

            File.WriteAllText(path, content, encoding ?? DefaultEncoding);
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

        /// <summary>
        /// Updates the text of a file.
        /// </summary>
        public static void UpdateText(this AbsolutePath path, Func<string, string> update, Encoding encoding = null)
        {
            var oldText = path.ReadAllText(encoding);
            var newText = update.Invoke(oldText);
            path.WriteAllText(newText, encoding);
        }
    }
}
