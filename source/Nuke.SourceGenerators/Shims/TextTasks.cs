// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;

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
