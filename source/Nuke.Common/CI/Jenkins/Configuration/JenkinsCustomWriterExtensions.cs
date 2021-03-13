﻿// Copyright 2021 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.Jenkins.Configuration
{
    public static class JenkinsCustomWriterExtensions
    {
        public static IDisposable WriteJenkinsPipelineBlock(this CustomFileWriter writer, string text)
        {
            return DelegateDisposable
                .CreateBracket(
                    () => writer.WriteLine(string.IsNullOrWhiteSpace(text)
                        ? "{"
                        : $"{text} {{"),
                    () => writer.WriteLine("}"))
                .CombineWith(writer.Indent());
        }
    }
}