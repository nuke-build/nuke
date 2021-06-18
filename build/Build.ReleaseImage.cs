// Copyright 2020 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Utilities;
using Nuke.Common.Utilities.Collections;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using static Nuke.Common.IO.CompressionTasks;
using static Nuke.Common.IO.HttpTasks;
using static Nuke.Common.Logger;

partial class Build
{
    string[] FontDownloadUrls =>
        new[]
        {
            "https://github.com/googlefonts/roboto/releases/latest/download/roboto-unhinted.zip",
            "https://github.com/JetBrains/JetBrainsMono/releases/download/v1.0.6/JetBrainsMono-1.0.6.zip"
        };

    AbsolutePath FontDirectory => TemporaryDirectory / "fonts";
    IReadOnlyCollection<AbsolutePath> FontArchives => FontDirectory.GlobFiles("*.*");
    IReadOnlyCollection<AbsolutePath> FontFiles => FontDirectory.GlobFiles("**/[!\\.]*.ttf");
    readonly FontCollection FontCollection = new FontCollection();

    Target InstallFonts => _ => _
        .Executes(() =>
        {
            FontDownloadUrls.ForEach(x => HttpDownloadFile(x, FontDirectory / new Uri(x).Segments.Last(), requestConfigurator: x => x.Timeout = 120000));
            FontArchives.ForEach(x => Uncompress(x, FontDirectory / Path.GetFileNameWithoutExtension(x)));

            FontFiles.ForEach(x => FontCollection.Install(x));
            FontCollection.Families.ForEach(x => Normal($"Installed font {x.Name.SingleQuote()}"));
        });

    AbsolutePath WatermarkImageFile => RootDirectory / "images" / "logo-watermark.png";
    AbsolutePath ReleaseImageFile => TemporaryDirectory / "release-image.png";

    Target ReleaseImage => _ => _
        .DependsOn(InstallFonts)
        .Executes(() =>
        {
            const float logoScaling = 0.37f;
            var logo = Image.Load(WatermarkImageFile);
            logo.Mutate(x => x.Resize((int) (logo.Width * logoScaling), (int) (logo.Height * logoScaling)));

            var robotoFont = FontCollection.Families.Single(x => x.Name == "Roboto Black");
            var graphicsOptions =
                new TextGraphicsOptions
                {
                    TextOptions = new TextOptions
                                  {
                                      HorizontalAlignment = HorizontalAlignment.Center,
                                      VerticalAlignment = VerticalAlignment.Center
                                  }
                };

            const int width = 1200;
            const int height = 675;
            var image = new Image<Rgba64>(width: width, height: height);
            image.Mutate(x => x
                .BackgroundColor(Color.FromRgb(r: 25, g: 25, b: 25))
                .DrawImage(
                    logo,
                    location: new Point(image.Width / 2 - logo.Width / 2, image.Height / 2 - logo.Height / 2),
                    opacity: 0.05f)
                .DrawText(
                    text: "New Release".ToUpperInvariant(),
                    font: robotoFont.CreateFont(70),
                    color: Color.WhiteSmoke,
                    location: new PointF(image.Width / 2f, image.Height / 2f - 100),
                    options: graphicsOptions)
                .DrawText(
                    text: MajorMinorPatchVersion,
                    font: robotoFont.CreateFont(180),
                    color: Color.WhiteSmoke,
                    location: new PointF(image.Width / 2f, image.Height / 2f),
                    options: graphicsOptions));

            using var fileStream = new FileStream(ReleaseImageFile, FileMode.Create);
            image.SaveAsPng(fileStream);
        });
}
