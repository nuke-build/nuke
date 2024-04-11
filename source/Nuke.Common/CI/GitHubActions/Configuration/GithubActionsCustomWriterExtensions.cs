// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;
using Nuke.Common.Utilities;

namespace Nuke.Common.CI.GitHubActions.Configuration;

public static class GithubActionsCustomWriterExtensions
{
    public static void WriteInlineArray(this CustomFileWriter writer, string property, string[] values)
    {
        if (values.Length == 0)
        {
            return;
        }

        if (values.Length <= 1)
        {
            writer.WriteLine($"{property}: {values.Single()}");
            return;
        }

        writer.WriteLine($"{property}: [ {values.JoinCommaSpace()} ]");
    }
}
