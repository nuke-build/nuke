#pragma warning disable 618
// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Core.Tooling
{
    public class CapturedProcessStartInfo
    {
        public string ToolPath { get; set; }
        public string Arguments { get; set; }
        public string WorkingDirectory { get; set; }
        public Func<string, string> OutputFilter { get; set; }
    }
}
