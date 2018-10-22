using System;
using System.Linq;

namespace Nuke.Common.Tools.MSpec
{
    public partial class MSpecSettings
    {
        private string GetToolPath()
        {
            return MSpecTasks.GetToolPath();
        }
    }
}