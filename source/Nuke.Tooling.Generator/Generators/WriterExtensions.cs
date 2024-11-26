// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Nuke.CodeGeneration.Model;
using Nuke.CodeGeneration.Writers;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using Serilog;

namespace Nuke.CodeGeneration.Generators;

public static class WriterExtensions
{
    public static T WriteObsoleteAttributeWhenObsolete<T>(this T writerWrapper, IDeprecatable deprecatable)
        where T : IWriterWrapper
    {
        if (!deprecatable.IsDeprecated())
            return writerWrapper;

        var message = deprecatable.GetDeprecationMessage();
        var obsoleteText = string.IsNullOrEmpty(message) ? string.Empty : $"(\"{message}\")";
        return writerWrapper.WriteLine($"[Obsolete{obsoleteText}]");
    }

    public static T WriteSummary<T>(this T writerWrapper, Tool tool)
        where T : IWriterWrapper
    {
        var paragraphs = new List<string>();
        paragraphs.Add(tool.Help.Paragraph());
        paragraphs.Add(GetOfficialUrlText(tool.OfficialUrl).Paragraph());
        return writerWrapper.WriteSummary(paragraphs.ToArray());
    }

    public static T WriteSummary<T>(this T writerWrapper, Task task)
        where T : IWriterWrapper
    {
        var paragraphs = new List<string>();
        paragraphs.Add((task.Help ?? task.Tool.Help).Paragraph());
        paragraphs.Add(GetOfficialUrlText(task.OfficialUrl ?? task.Tool.OfficialUrl).Paragraph());
        return writerWrapper.WriteSummary(paragraphs.ToArray());
    }

    public static T WriteRemarks<T>(this T writerWrapper, Task task)
        where T : IWriterWrapper
    {
        var lines = new List<string>();
        lines.Add(("This is a <a href=\"http://www.nuke.build/docs/authoring-builds/cli-tools.html#fluent-apis\">"
                   + "CLI wrapper with fluent API</a> that allows to modify the following arguments:").Paragraph());
        lines.AddRange(GetArgumentsList(task.SettingsClass));

        return writerWrapper
            .WriteLine($"/// <remarks>{lines.Join(string.Empty)}</remarks>");
    }

    private static IEnumerable<string> GetArgumentsList(DataClass dataClass)
    {
        var allDataClasses = dataClass.Tool.Tasks.Select(x => x.SettingsClass).Concat(dataClass.Tool.DataClasses).ToList();
        var typeHierarchy = dataClass.DescendantsAndSelf(x => allDataClasses.FirstOrDefault(y => y.Name == x.BaseClass));
        var properties = typeHierarchy.SelectMany(x => x.Properties, (x, y) => (Class: x, Property: y)).Where(x => !string.IsNullOrEmpty(x.Property.Format)).ToList();
        if (properties.Count == 0)
            yield break;

        string GetArgument(Property property)
        {
            var valueIndex = property.Format.IndexOf(value: '{');
            var argument = valueIndex == -1
                ? property.Format
                : valueIndex != 0
                    ? property.Format.Substring(startIndex: 0, valueIndex).TrimEnd(':', '=', ' ')
                    : $"&lt;{property.Name.ToInstance()}&gt;";
            if (!argument.Any(char.IsLetter))
                Log.Warning("Format for property {ClassName}.{PropertyName} is all non-letters", property.DataClass.Tool.Name, property.Name);
            return argument;
        }

        var propertiesWithArgument = properties
            .Select(x => new { Property = x.Class.Name + "." + x.Property.Name, Argument = GetArgument(x.Property) })
            .OrderBy(x => !x.Argument.StartsWith("&lt;"))
            .ThenBy(x => x.Argument);

        yield return "<ul>";
        foreach (var pair in propertiesWithArgument)
            yield return $"<li><c>{pair.Argument}</c> via {pair.Property.ToSeeCref()}</li>";
        yield return "</ul>";
    }

    public static T WriteSummary<T>(this T writerWrapper, DataClass dataClass)
        where T : IWriterWrapper
    {
        return writerWrapper.WriteSummary(GetUsedWithinText(dataClass.Tool));
    }

    public static T WriteSummary<T>(this T writerWrapper, Enumeration enumeration)
        where T : IWriterWrapper
    {
        return writerWrapper.WriteSummary(GetUsedWithinText(enumeration.Tool));
    }

    public static T WriteSummaryExtension<T>(this T writerWrapper, string actionText, Property property, Property alternativeProperty = null)
        where T : IWriterWrapper
    {
        return writerWrapper.WriteSummary(
            actionText.Emphasize().Paragraph(),
            (property.Help ?? alternativeProperty?.Help).Paragraph());
    }

    private static string GetUsedWithinText(Tool tool)
    {
        return $"Used within {tool.GetClassName().ToSeeCref()}.";
    }

    private static string GetOfficialUrlText(string url)
    {
        return $"For more details, visit the <a href=\"{url}\">official website</a>.";
    }

    public static T WriteSummary<T>(this T writerWrapper, params string[] lines)
        where T : IWriterWrapper
    {
        lines = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();

        if (lines.Length == 0)
            return writerWrapper;

        writerWrapper.WriteLine($"/// <summary>{lines.Join(string.Empty)}</summary>");

        return writerWrapper;
    }
}
