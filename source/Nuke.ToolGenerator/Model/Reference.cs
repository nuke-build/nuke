using System;
using System.Linq;

namespace Nuke.ToolGenerator.Model
{
    public class Reference
    {
        public string Url { get; set; }
        public int HashCode { get; set; }
        public string XPath { get; set; }
    }
}