using System;
using System.Linq;
using JetBrains.Annotations;

namespace Nuke.ToolGenerator.Model
{
    [UsedImplicitly]
    public class Reference
    {
        public string Url { get; set; }
        public string XPath { get; set; }
    }
}
