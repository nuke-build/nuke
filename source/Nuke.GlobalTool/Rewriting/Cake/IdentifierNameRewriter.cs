// Copyright 2023 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Nuke.Common;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.MSBuild;

namespace Nuke.GlobalTool.Rewriting.Cake
{
    internal class IdentifierNameRewriter : SafeSyntaxRewriter
    {
        private static Dictionary<string, string> Replacements =>
            new()
            {
                ["DotNetCoreVerbosity"] = nameof(DotNetVerbosity),
                ["MSBuildToolVersion"] = nameof(MSBuildToolsVersion),
                ["PlatformTarget"] = nameof(MSBuildTargetPlatform),
                ["IsRunningOnUnix"] = nameof(EnvironmentInfo.IsUnix),
                ["IsRunningOnWindows"] = nameof(EnvironmentInfo.IsWin),
                ["EnvironmentVariable"] = "GetVariable<string>",
            };

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            return Replacements.TryGetValue(node.Identifier.Text, out var replacement)
                ? node.WithIdentifier(SyntaxFactory.Identifier(replacement))
                : node;
        }
    }
}
