// Copyright 2018 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using Colorful;
using Nuke.Common.Utilities;

namespace Nuke.Common.OutputSinks
{
    [ExcludeFromCodeCoverage]
    public static class FigletTransform
    {
        public static string GetText(string text, string integratedFontName = null)
        {
            integratedFontName = integratedFontName ?? "cybermedium";

            var fullResourceName = $"{typeof(IOutputSink).Namespace}.Fonts.{integratedFontName}.flf";
            var assembly = typeof(FigletTransform).GetTypeInfo().Assembly;
            var resourceStream = assembly.GetManifestResourceStream(fullResourceName);

            return GetText(text, resourceStream.NotNull("resourceStream != null"));
        }

        public static string GetText(string text, Stream stream)
        {
            var figlet = new Figlet(FigletFont.Load(stream));

            var textWithFont = figlet.ToAscii(text).ToString()
                .Split(new[] { EnvironmentInfo.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => !string.IsNullOrWhiteSpace(x));

            return EnvironmentInfo.NewLine +
                   textWithFont.JoinNewLine() +
                   EnvironmentInfo.NewLine;
        }
    }
}
