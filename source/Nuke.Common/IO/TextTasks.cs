// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Nuke.Common.IO
{
    [PublicAPI]
    public static class TextTasks
    {
        public static UTF8Encoding UTF8NoBom => new(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.WriteAllLines)} extension method")]
        [CodeTemplate(
            searchTemplate: "WriteAllLines($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.WriteAllLines($args$)",
            ReplaceMessage = "Replace with $expr$.WriteAllLines($args$)",
            Message = $"WARNING: {nameof(WriteAllLines)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "TextTasks.WriteAllLines($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.WriteAllLines($args$)",
            ReplaceMessage = "Replace with $expr$.WriteAllLines($args$)",
            Message = $"WARNING: {nameof(WriteAllLines)} is obsolete")]
        public static void WriteAllLines(string path, IEnumerable<string> lines, Encoding encoding = null)
        {
            WriteAllLines(path, lines.ToArray(), encoding);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.WriteAllLines)} extension method")]
        [CodeTemplate(
            searchTemplate: "WriteAllLines($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.WriteAllLines($args$)",
            ReplaceMessage = "Replace with $expr$.WriteAllLines($args$)",
            Message = $"WARNING: {nameof(WriteAllLines)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "TextTasks.WriteAllLines($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.WriteAllLines($args$)",
            ReplaceMessage = "Replace with $expr$.WriteAllLines($args$)",
            Message = $"WARNING: {nameof(WriteAllLines)} is obsolete")]
        public static void WriteAllLines(string path, string[] lines, Encoding encoding = null)
        {
            ((AbsolutePath)path).WriteAllLines(lines, encoding);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.WriteAllText)} extension method")]
        [CodeTemplate(
            searchTemplate: "WriteAllText($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.WriteAllText($args$)",
            ReplaceMessage = "Replace with $expr$.WriteAllText($args$)",
            Message = $"WARNING: {nameof(WriteAllText)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "TextTasks.WriteAllText($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.WriteAllText($args$)",
            ReplaceMessage = "Replace with $expr$.WriteAllText($args$)",
            Message = $"WARNING: {nameof(WriteAllText)} is obsolete")]
        public static void WriteAllText(string path, string content, Encoding encoding = null)
        {
            ((AbsolutePath)path).WriteAllText(content, encoding);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.WriteAllBytes)} extension method")]
        public static void WriteAllBytes(string path, byte[] bytes)
        {
            ((AbsolutePath)path).WriteAllBytes(bytes);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.ReadAllText)} extension method")]
        [CodeTemplate(
            searchTemplate: "ReadAllText($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadAllText($args$)",
            ReplaceMessage = "Replace with $expr$.ReadAllText($args$)",
            Message = $"WARNING: {nameof(ReadAllText)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "TextTasks.ReadAllText($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadAllText($args$)",
            ReplaceMessage = "Replace with $expr$.ReadAllText($args$)",
            Message = $"WARNING: {nameof(ReadAllText)} is obsolete")]
        public static string ReadAllText(string path, Encoding encoding = null)
        {
            return ((AbsolutePath)path).ReadAllText(encoding);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.ReadAllLines)} extension method")]
        [CodeTemplate(
            searchTemplate: "ReadAllLines($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadAllLines($args$)",
            ReplaceMessage = "Replace with $expr$.ReadAllLines($args$)",
            Message = $"WARNING: {nameof(ReadAllLines)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "TextTasks.ReadAllLines($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadAllLines($args$)",
            ReplaceMessage = "Replace with $expr$.ReadAllLines($args$)",
            Message = $"WARNING: {nameof(ReadAllLines)} is obsolete")]
        public static string[] ReadAllLines(string path, Encoding encoding = null)
        {
            return ((AbsolutePath)path).ReadAllLines(encoding);
        }

        [Obsolete($"Use {nameof(AbsolutePath)}.{nameof(AbsolutePathExtensions.ReadAllBytes)} extension method")]
        [CodeTemplate(
            searchTemplate: "ReadAllBytes($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadAllBytes($args$)",
            ReplaceMessage = "Replace with $expr$.ReadAllBytes($args$)",
            Message = $"WARNING: {nameof(ReadAllBytes)} is obsolete")]
        [CodeTemplate(
            searchTemplate: "TextTasks.ReadAllBytes($expr{'Nuke.Common.IO.AbsolutePath', true}$, $args$)",
            ReplaceTemplate = "$expr$.ReadAllBytes($args$)",
            ReplaceMessage = "Replace with $expr$.ReadAllBytes($args$)",
            Message = $"WARNING: {nameof(ReadAllBytes)} is obsolete")]
        public static byte[] ReadAllBytes(string path)
        {
            return ((AbsolutePath)path).ReadAllBytes();
        }
    }
}
