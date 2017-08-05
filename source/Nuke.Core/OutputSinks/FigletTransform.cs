// Copyright Matthias Koch 2017.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Colorful;
using Nuke.Core.Utilities;

namespace Nuke.Core.OutputSinks
{
    public static class FigletTransform
    {
        public static string GetText (string text, string integratedFontName = null)
        {
            integratedFontName = integratedFontName ?? "cybermedium";

            var fullResourceName = $"{typeof(OutputSink).Namespace}.Fonts.{integratedFontName}.flf";
            var assembly = typeof(FigletTransform).GetTypeInfo().Assembly;
            var resourceStream = assembly.GetManifestResourceStream(fullResourceName);

            return GetText(text, resourceStream.NotNull("resourceStream != null"));
        }

        public static string GetText (string text, Stream stream)
        {
            var figlet = new Figlet(FigletFont.Load(stream));

            var textWithFont = figlet.ToAscii(text).ToString()
                    .Split(new[] { EnvironmentInfo.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => !string.IsNullOrWhiteSpace(x));

            return EnvironmentInfo.NewLine +
                   textWithFont.Join(EnvironmentInfo.NewLine) +
                   EnvironmentInfo.NewLine;
        }
    }
}
