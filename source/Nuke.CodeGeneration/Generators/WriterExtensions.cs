// Copyright Matthias Koch, Sebastian Karasek 2018.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using JetBrains.Annotations;
using Nuke.CodeGeneration.Model;
using Nuke.CodeGeneration.Writers;

namespace Nuke.CodeGeneration.Generators
{
    public static class WriterExtensions
    {
        public static T WriteSummary<T>(this T writerWrapper, Task task)
            where T : IWriterWrapper
        {
            return writerWrapper.WriteSummary(task.Help ?? task.Tool.Help, task.OfficialUrl ?? task.Tool.OfficialUrl);
        }

        public static T WriteSummary<T>(this T writerWrapper, Property property)
            where T : IWriterWrapper
        {
            return writerWrapper.WriteSummary(property.Help);
        }

        public static T WriteSummary<T>(this T writerWrapper, DataClass dataClass)
            where T : IWriterWrapper
        {
            return writerWrapper.WriteSummary($"Used within <see cref={dataClass.Tool.GetClassName().DoubleQuote()}/>.");
        }

        public static T WriteSummary<T>(this T writerWrapper, Enumeration enumeration)
            where T : IWriterWrapper
        {
            return writerWrapper.WriteSummary($"Used within <see cref={enumeration.Tool.GetClassName().DoubleQuote()}/>.");
        }

        public static T WriteSummaryExtension<T>(this T writerWrapper, string actionText, Property property, Property alternativeProperty = null)
            where T : IWriterWrapper
        {
            return writerWrapper.WriteSummary($"<p><em>{actionText}.</em></p>{(property.Help ?? alternativeProperty?.Help).Paragraph()}");
        }

        public static T WriteSummary<T>(this T writerWrapper, [CanBeNull] string help, string url = null)
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
    }
}
