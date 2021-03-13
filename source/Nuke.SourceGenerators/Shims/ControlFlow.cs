// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace Nuke.Common.IO
{
    public static class TextTasks
    {
        public static string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}

namespace Nuke.Common
{
    public static class ControlFlow
    {
        [ContractAnnotation("obj:null=>halt")]
        public static T NotNull<T>(this T obj, string message = null)
        {
            return obj ?? throw new Exception(message ?? $"{typeof(T).Name} != null");
        }

        public static void Assert(bool condition, string message)
        {
            if (!condition)
                throw new Exception(message);
        }
    }
}
