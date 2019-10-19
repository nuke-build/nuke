using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.AzurePipelines.Configuration
{
    public static class AzurePipelinesCustomWriterExtensions
    {
        public static IDisposable WriteBlock(this CustomFileWriter writer, string text)
        {
            return DelegateDisposable
                .CreateBracket(() => writer.WriteLine(text))
                .CombineWith(writer.Indent());
        }
    }
}