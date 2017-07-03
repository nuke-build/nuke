// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.ToolGenerator.Model;
using Nuke.ToolGenerator.Writers;

namespace Nuke.ToolGenerator.Generators
{
    public static class WriterExtensions
    {
        public static T WriteSummary<T> (this T writerWrapper, Task task)
            where T : IWriterWrapper
        {
            return WriteSummary(writerWrapper, task.Help ?? task.Tool.Help, task.Tool.OfficialUrl);
        }

        public static T WriteSummary<T> (this T writerWrapper, Property property)
            where T : IWriterWrapper
        {
            return WriteSummary(writerWrapper, property.Help, url: null);
        }

        public static T WriteSummary<T> (this T writerWrapper, DataClass dataClass)
            where T : IWriterWrapper
        {
            return WriteSummary(writerWrapper, dataClass.Tool.Help, url: null);
        }

        public static T WriteSummary<T> (this T writerWrapper, Enumeration enumeration)
            where T : IWriterWrapper
        {
            return WriteSummary(writerWrapper, enumeration.Tool.Help, url: null);
        }

        public static T WriteSummaryExtension<T> (this T writerWrapper, string actionText, Property property)
            where T : IWriterWrapper
        {
            return WriteSummary(writerWrapper, $"<p><i>Extension method for {actionText}.</i></p>{property.Help.Paragraph()}", url: null);
        }

        private static T WriteSummary<T> (T writerWrapper, [CanBeNull] string help, [CanBeNull] string url)
            where T : IWriterWrapper
        {
            if (help == null)
                return writerWrapper;

            var officialUrlParagraph = url != null
                ? $"<p>For more details, visit the <a href=\"{url}\">official website</a>.</p>"
                : string.Empty;

            writerWrapper.WriteLine($"/// <summary>{help.Paragraph()}{officialUrlParagraph}</summary>");
            return writerWrapper;
        }

        public static T WriteSummaryInherit<T> (this T writerWrapper)
            where T : IWriterWrapper
        {
            return writerWrapper.WriteLine($"/// <inheritdoc />");
        }
    }
}
