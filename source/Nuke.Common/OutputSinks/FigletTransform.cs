// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Colorful;
using Nuke.Common.Utilities;

namespace Nuke.Common.OutputSinks
{
    [ExcludeFromCodeCoverage]
    public class FigletTransform
    {
        public static string GetText(string text, string integratedFontName = null)
        {
            var resource = ResourceUtility.GetResource<FigletTransform>($"Fonts.{integratedFontName ?? "cybermedium"}.flf");
            return GetText(text, resource);
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
