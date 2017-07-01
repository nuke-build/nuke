// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/matkoch/Nuke/blob/master/LICENSE

using System;
using System.Diagnostics;
using System.Linq;
using Nuke.ToolGenerator.Model;
using Nuke.ToolGenerator.Writers;

namespace Nuke.ToolGenerator.Generators
{
    public static class WriterExtensions
    {
        public static T WriteSummary<T> (this T writerWrapper, Tool tool)
            where T : IWriterWrapper
        {
            Trace.Assert(tool.Help != null, "tool.Help != null");

            writerWrapper.WriteLine("/// <summary>");

            writerWrapper.WriteLine($"/// {tool.Help.Paragraph()}");

            if (tool.OfficialUrl != null)
                writerWrapper.WriteLine($"/// <p>For more details, visit the <a href=\"{tool.OfficialUrl}\">official website</a>.</p>");

            writerWrapper.WriteLine("/// </summary>");
            return writerWrapper;
        }

        public static T WriteSummary<T> (this T writerWrapper, Property property)
            where T : IWriterWrapper
        {
            if (property.Help == null)
                return writerWrapper;

            return writerWrapper.WriteLine($"/// <summary>{property.Help.Paragraph()}</summary>");
        }

        public static T WriteSummaryExtension<T> (this T writerWrapper, string actionText, Property property)
            where T : IWriterWrapper
        {
            if (property.Help == null)
                return writerWrapper;

            return writerWrapper
                    .WriteLine("/// <summary>")
                    .WriteLine($"/// <p><i>Extension method for {actionText}.</i></p>")
                    .WriteLine($"/// {property.Help.Paragraph()}")
                    .WriteLine("/// </summary>");
        }

        public static T WriteSummaryInherit<T> (this T writerWrapper)
            where T : IWriterWrapper
        {
            return writerWrapper.WriteLine($"/// <inheritdoc />");
        }
    }
}
