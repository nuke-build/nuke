using System;
using System.IO;
using System.Linq;
using Nuke.Common.IO;

namespace Nuke.Common
{
    internal partial class EnvironmentInfo
    {
        public static AbsolutePath WorkingDirectory => (AbsolutePath) Directory.GetCurrentDirectory();
    }
}
