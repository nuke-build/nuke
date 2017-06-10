// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

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
